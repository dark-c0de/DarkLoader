using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DarkLoader
{
    public static class MagicPatches
    {
        public static Patches LoadedPatches;
        public class Patch
        {
            public string title { get; set; }
            public string author { get; set; }
            public string description { get; set; }
            public string pattern { get; set; }
            public string match { get; set; }
            public int offset { get; set; }
            public string patch { get; set; }
            public bool recursivePatch { get; set; }
            public bool patchOnStartup { get; set; }
            public bool patchBeforeStartup { get; set; }
        }
        public class Patches
        {
            public List<Patch> PatchList { get; set; }

            public Patches()
            {
                PatchList = new List<Patch>();
            }
        }
        public static bool RunPatch(string title)
        {
            Patch patch = FindByTitle(title);

            if (patch.recursivePatch)
            {
                return PatchRecursive(patch);

            }
            else
            {
                return PatchFirst(patch);

            }
        }
        public static Patch FindByTitle(string title)
        {
            return LoadedPatches.PatchList.First(patch => patch.title == title);
        }
        public static void RunStartupPatches()
        {
            foreach(var patch in LoadedPatches.PatchList.FindAll(patch => patch.patchOnStartup == true)){
                if (patch.recursivePatch)
                {
                    PatchRecursive(patch);
                }
                else
                {
                    PatchFirst(patch);
                }
            }
        }

        public static void LoadPatches()
        {
            if (!File.Exists(Program.PatchFile))
            {
                MessageBox.Show("No Patch ("+Program.PatchFile+") file. Failing miserably.");
                Application.Exit();
                return;
            }
            string patchList = File.ReadAllText(Program.PatchFile);
            LoadedPatches = JsonConvert.DeserializeObject<MagicPatches.Patches>(patchList);
        }

        //TODO: Add pattern scanning functionality.
        public static void ExePatches(byte[] bytes)
        {
            LogFile.WriteToLog("Starting ExePatches");

            foreach (var patch in LoadedPatches.PatchList.FindAll(patch => patch.patchBeforeStartup == true))
            {
                byte[] patchBytes = HelperFunctions.StringToByteArray(patch.patch);
                byte[] patchPattern = HelperFunctions.StringToByteArray(patch.pattern);
                int result = Convert.ToInt32(IndexOfBytes(bytes, patchPattern, patch.match));
               
                if (result > 0)
                {
                    Buffer.BlockCopy(patchBytes, 0, bytes, result + patch.offset, patchBytes.Length);
                    LogFile.WriteToLog("Exe Patch (" + patch.title + ") found and patched at " + (result + patch.offset).ToString("X"));
                    result = Convert.ToInt32(IndexOfBytes(bytes, patchPattern, patch.match));
                    while (patch.recursivePatch && result > 0)
                    {
                        Buffer.BlockCopy(patchBytes, 0, bytes, result + patch.offset, patchBytes.Length);
                        LogFile.WriteToLog("Recursive Exe Patch (" + patch.title + ") found and patched at " + (result + patch.offset).ToString("X"));
                        result = Convert.ToInt32(IndexOfBytes(bytes, patchPattern, patch.match));
                    }
                }
            }
        }
        public static unsafe long IndexOfBytes(this byte[] haystack, byte[] needle, string match, long startOffset = 0)
        {
            fixed (byte* h = haystack) fixed (byte* n = needle)
            {
                for (byte* hNext = h + startOffset, hEnd = h + haystack.LongLength + 1 - needle.LongLength, nEnd = n + needle.LongLength; hNext < hEnd; hNext++)
                    for (byte* hInc = hNext, nInc = n; *nInc == *hInc; hInc++)
                        if (++nInc == nEnd)
                            return hNext - h;
                return -1;
            }
        }

        //This returns an IntPtr of the address found from a byte pattern match.
        public static IntPtr ScanForPattern(Process p, byte[] pattern, string match, int offset, IntPtr startOffset = new IntPtr())
        {
            if (startOffset.ToInt32() == 0)
            {
                startOffset = p.MainModule.BaseAddress;
            }

            //TODO: We need to scan the entire memory (p.WorkingSet64) but that wont all fit in a C# app. 
            //TODO: We'll need to loop through all the memory eventually...
            IntPtr endOffset = IntPtr.Subtract((IntPtr)p.MainModule.ModuleMemorySize, (int)startOffset);
     
            SigScan.Classes.SigScan _sigScan = new SigScan.Classes.SigScan();
            _sigScan.Process = p;

            _sigScan.Address = startOffset;
            _sigScan.Size = (int)endOffset;

            return _sigScan.FindPattern(pattern, match, offset);
        }

        //This will apply a patch to a specific address
        public static void PatchSingleAddress(Patch patch, IntPtr address)
        {
            byte[] patchBytes = HelperFunctions.StringToByteArray(patch.patch);
            IntPtr p = Memory.OpenProcess(0x001F0FFF, true, MainForm.HaloOnline.Id);

            Memory.WriteProtectedMemory(p, address, patchBytes, patchBytes.Length);
        }
        //This will apply a patch to all patch results
        public static bool PatchRecursive(Patch patch)
        {
            LogFile.WriteToLog("Starting recusive memory patch for " + patch.title);
            byte[] patchBytes = HelperFunctions.StringToByteArray(patch.patch);
            byte[] patternBytes = HelperFunctions.StringToByteArray(patch.pattern);
            IntPtr p = Memory.OpenProcess(0x001F0FFF, true, MainForm.HaloOnline.Id);
            IntPtr PatchReturnAddress;

            PatchReturnAddress = MagicPatches.ScanForPattern(MainForm.HaloOnline, patternBytes, patch.match, patch.offset);

            if (PatchReturnAddress == null || PatchReturnAddress.ToInt32() <= 0)
            {
                return false;
            }
            else
            {
                bool patched = false;
                while (PatchReturnAddress.ToInt32() > 0)
                {
                    Memory.WriteProtectedMemory(p, PatchReturnAddress, patchBytes, patchBytes.Length);
                    LogFile.WriteToLog("Recursive Memory Patch (" + patch.title + ") found and patched at " + PatchReturnAddress.ToString("X"));
                    patched = true;
                    IntPtr startOffset = PatchReturnAddress + 0x1;
                    PatchReturnAddress = MagicPatches.ScanForPattern(MainForm.HaloOnline, patternBytes, patch.match, patch.offset, startOffset);
                }
                return patched;
            }
        }

        //This will apply a patch to only the first value found
        public static bool PatchFirst(Patch patch)
        {
            byte[] patchBytes = HelperFunctions.StringToByteArray(patch.patch);
            byte[] patternBytes = HelperFunctions.StringToByteArray(patch.pattern);
            IntPtr p = Memory.OpenProcess(0x001F0FFF, true, MainForm.HaloOnline.Id);
            IntPtr PatchReturnAddress;

            PatchReturnAddress = MagicPatches.ScanForPattern(MainForm.HaloOnline, patternBytes, patch.match, patch.offset);

            if (PatchReturnAddress == null || PatchReturnAddress.ToInt32() <= 0)
            {
                return false;
            }
            else
            {
                Memory.WriteProtectedMemory(p, PatchReturnAddress, patchBytes, patchBytes.Length);
                LogFile.WriteToLog("Memory Patch (" + patch.title + ") found and patched at " + PatchReturnAddress.ToString("X"));
                return true;
            }
        }
    }
}