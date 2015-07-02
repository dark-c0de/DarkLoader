using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SigScan.Classes;
using System.Net;

namespace DarkLoader
{
    public partial class MainForm : Form
    {
        bool WeRunningYup = false;
        bool HaloIsRunning = false;
        bool forceLoading = false;
        Process HaloOnline;

        //Lets keep the previous scan in memory so only the first scan is slow.
        IntPtr pAddr;
        IntPtr MpPatchAddr;
        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            [Out] byte[] lpBuffer,
            int dwSize,
            out int lpNumberOfBytesRead
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(
            IntPtr hProcess,
            IntPtr lpBaseAddress,
            byte[] lpBuffer,
            int nSize,
            out int lpNumberOfBytesWritten);


        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WeRunningYup = true;
            comboGameModes.SelectedIndex = 2;
            comboGameTypes.SelectedIndex = 0;
            string HaloMapDir = Application.StartupPath + @"\maps\";
            DirectoryInfo d = new DirectoryInfo(HaloMapDir);

            foreach (var file in d.GetFiles("*.map"))
            {
                byte[] MapHeader = new byte[756];
                byte[] BuildVersion = new byte[32]; //0.4.1.327043 cert_MS26_new
                byte[] MapName = new byte[36];
                byte[] MapTagDir = new byte[256];
                using (BinaryReader reader = new BinaryReader(new FileStream(HaloMapDir + file.Name, FileMode.Open, FileAccess.Read)))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    reader.Read(MapHeader, 0, 756);

                    int MapTagDirOffset = HelperFunctions.SearchBytes(MapHeader, Encoding.ASCII.GetBytes("level"));

                    reader.BaseStream.Seek(284, SeekOrigin.Begin);
                    reader.Read(BuildVersion, 0, 32);
                    reader.BaseStream.Seek(MapTagDirOffset - 36, SeekOrigin.Begin);
                    reader.Read(MapName, 0, 36);
                    reader.BaseStream.Seek(MapTagDirOffset, SeekOrigin.Begin);
                    reader.Read(MapTagDir, 0, 256);
                }
                listMapNames.Items.Add(System.Text.Encoding.UTF8.GetString(MapName).Replace("\0", ""));
                listMapInfo.Items.Add(System.Text.Encoding.UTF8.GetString(BuildVersion).Replace("\0", "") + " " + System.Text.Encoding.UTF8.GetString(MapTagDir).Replace("\0", ""));
            }
            Thread haloWatcher = new Thread(IsHaloRunning);
            haloWatcher.Start();

            Thread checkUpdates = new Thread(CheckForUpdates);
            checkUpdates.Start();
        }
        private void CheckForUpdates()
        {
            var url = "https://halowiki.llf.to/darkloader/latest.txt";
            try
            {
                var versionString = (new WebClient()).DownloadString(url);
                Version newVersion = Version.Parse(versionString);
                Version currentVersion = Version.Parse(Application.ProductVersion);
                if (currentVersion <= newVersion)
                {
                    this.Invoke(new MethodInvoker(delegate { this.Text = "DarkLoader - Update Available!"; }));

                    DialogResult result1 = MessageBox.Show("There's a new version of DarkLoader available. Would you like to download it?", "Oh goody!", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        Process.Start("https://github.com/dark-c0de/DarkLoader/releases", "");
                    }
                }
            }
            catch (Exception) { }
        }
        private void IsHaloRunning()
        {
            while (WeRunningYup)
            {
                HaloOnline = Process.GetProcessesByName("eldorado").FirstOrDefault();
                try
                {
                    if (HaloOnline != null)
                    {
                        if (!forceLoading)
                        {
                            this.btnDarkLoad.Invoke(new MethodInvoker(delegate { btnDarkLoad.Enabled = true; groupTools.Enabled = true; }));
                        }
                        HaloIsRunning = true;
                    }
                    else
                    {
                        this.btnDarkLoad.Invoke(new MethodInvoker(delegate { btnDarkLoad.Enabled = false; groupTools.Enabled = false; }));
                        HaloIsRunning = false;
                        HaloOnline = null;
                        pAddr = new IntPtr(0);
                        MpPatchAddr = new IntPtr(0);
                    }
                }
                catch (Exception)
                {
                    //Let's just not
                }
                Thread.Sleep(200);
            }
        }
        private void btnHaloClick_Click(object sender, EventArgs e)
        {
            Process.Start("https://forum.halo.click/index.php?/topic/234-program-darkloader/", "");
        }


        IntPtr PtrMapName;
        IntPtr PtrMapReset;
        IntPtr PtrMapTime;
        IntPtr PtrMapType;
        IntPtr PtrGameType;
        IntPtr PtrMpPatch;
        
        private void btnDarkLoad_Click(object sender, EventArgs e)
        {
            if (listMapNames.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a map to load on the side list.", "DarkLoader");
                return;
            }
            forceLoading = true;
            btnDarkLoad.Text = "Scanning";
            btnDarkLoad.Enabled = false;

            Thread forceLoadMap = new Thread(ForceLoadMap);
            forceLoadMap.Start();
        }

        private void ForceLoadMap()
        {
            //Do Magic
            try
            {
                IntPtr p = OpenProcess(0x001F0FFF, true, HaloOnline.Id);

                if (pAddr == null || pAddr.ToInt32() == 0)
                {
                    IntPtr startOffset = HaloOnline.MainModule.BaseAddress;
                    IntPtr endOffset = IntPtr.Add(startOffset, HaloOnline.MainModule.ModuleMemorySize);

                    SigScan.Classes.SigScan _sigScan = new SigScan.Classes.SigScan();

                    _sigScan.Process = HaloOnline;
                    _sigScan.Address = startOffset;
                    _sigScan.Size = HaloOnline.MainModule.ModuleMemorySize;
                    pAddr = _sigScan.FindPattern(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x6D, 0x61, 0x70, 0x73, 0x5C, 0x6D, 0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75 }, "xxxxxxxxxxxxxxxxxxxxx", 0);

                    if (pAddr == null || pAddr.ToInt32() <= 0)
                    {
                        MessageBox.Show("DarkLoader failed to find the map loading code...\nThis could mean two things:\n\n1. You tried loading a map already and closed + opened HaloLoader on the same EXE (You have to keep it running!)\n2. This version of Halo Online is not supported.");
                        return;
                    }
                    //pAddr = 4BB300C
                    PtrMapName = pAddr + 0xD;    //0x4BB3019
                    PtrMapReset = pAddr - 0x2C;  //0x4BB2FE0
                    PtrMapTime = pAddr + 0x435;  //0x4BB3441
                    PtrMapType = pAddr - 0x1C;   //0x4BB2FF0
                    PtrGameType = PtrMapReset + 0x33C;  //0x4BB331C
                }
                //Pattern Scan Finds (4BB300C)
                //Map Title = Mainmenu (04BB3019)

                int lpNumberOfBytesWritten = 0;


                //Patch Multiplayer Loading
                /*
                 *   eldorado.Scaleform::Event::TryAcquireCancel+155147 - 8B CE                 - mov ecx,esi
                 *   eldorado.Scaleform::Event::TryAcquireCancel+155149 - 66 89 43 02           - mov [ebx+02],ax
                 *   eldorado.Scaleform::Event::TryAcquireCancel+15514D - E8 9E150000           - call eldorado.Scaleform::Event::TryAcquireCancel+1566F0
                 *   eldorado.Scaleform::Event::TryAcquireCancel+155152 - 8B 47 10              - mov eax,[edi+10]
                 *
                 * */

                if (MpPatchAddr == null || MpPatchAddr.ToInt32() <= 0)
                {
                    IntPtr startOffset = HaloOnline.MainModule.BaseAddress;
                    IntPtr endOffset = IntPtr.Add(startOffset, HaloOnline.MainModule.ModuleMemorySize);


                    //New builds of Halo Online
                    SigScan.Classes.SigScan _sigScan = new SigScan.Classes.SigScan();

                    _sigScan.Process = HaloOnline;
                    _sigScan.Address = startOffset;
                    _sigScan.Size = HaloOnline.MainModule.ModuleMemorySize;
                    MpPatchAddr = _sigScan.FindPattern(new byte[] { 0x8B, 0xCE, 0x66, 0x89, 0x43, 0x02, 0xE8, 0x9E, 0x15, 0x00, 0x00, 0x8B, 0x47, 0x10 }, "xxxxx??????xxx", 7);

                    if (MpPatchAddr == null || MpPatchAddr.ToInt32() <= 0)
                    {
                        //Original Halo Online - Eldewrito!
                        MpPatchAddr = _sigScan.FindPattern(new byte[] { 0x17, 0x56, 0x66, 0x89, 0x47, 0x02, 0xE8, 0x4C, 0xFB, 0xFF, 0xFF, 0x57, 0x53, 0x56 }, "xxxxx??????xxx", 7);
                    }

                    PtrMpPatch = MpPatchAddr - 0x1;
                }

                //Pointer finds 0xF605FE - actual is 0xF605FD

                if (PtrMpPatch.ToInt32() <= 0)
                {
                    MessageBox.Show("Failed to find pointer... Go file a bug report.");
                    return;

                }
                this.btnDarkLoad.Invoke(new MethodInvoker(delegate { btnDarkLoad.Text = "Patching"; }));
                byte[] nop = { 0x90, 0x90, 0x90, 0x90, 0x90 };
                WriteProcessMemory(p, PtrMpPatch, nop, 5, out lpNumberOfBytesWritten);

                byte[] mapReset = { 0x1 };
                // sets map type
                byte[] mapType = { 0, 0, 0, 0 };
                // sets gametype
                byte[] gameType = { 0, 0, 0, 0 };
                // Infinite play time
                byte[] mapTime = { 0x0 };
                // Grab map name from selected listbox
                byte[] mapName = new byte[36];
                this.comboGameModes.Invoke(new MethodInvoker(delegate
                {
                    BitConverter.GetBytes(Convert.ToInt32(comboGameModes.SelectedIndex)).CopyTo(mapType, 0);
                    BitConverter.GetBytes(Convert.ToInt32(comboGameTypes.SelectedIndex)).CopyTo(gameType, 0);
                    Encoding.ASCII.GetBytes(listMapNames.SelectedItem.ToString()).CopyTo(mapName, 0);
                }));
                WriteProcessMemory(p, PtrGameType, gameType, 4, out lpNumberOfBytesWritten);
                WriteProcessMemory(p, PtrMapType, mapType, 4, out lpNumberOfBytesWritten);
                WriteProcessMemory(p, PtrMapName, mapName, mapName.Length, out lpNumberOfBytesWritten);
                WriteProcessMemory(p, PtrMapTime, mapTime, 1, out lpNumberOfBytesWritten);
                WriteProcessMemory(p, PtrMapReset, mapReset, 1, out lpNumberOfBytesWritten);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong...\n" + ex.Message, "DarkLoader Error");
            }
            this.btnDarkLoad.Invoke(new MethodInvoker(delegate
            {
                btnDarkLoad.Text = "DarkLoad";
                btnDarkLoad.Enabled = true;
            }));
            forceLoading = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WeRunningYup = false;
        }

        private void btnLaunchHaloOnline_Click(object sender, EventArgs e)
        {
            if (!HaloIsRunning)
            {
                ProcessStartInfo HaloOnline = new ProcessStartInfo();
                HaloOnline.FileName = Application.StartupPath + @"\eldorado.exe";
                HaloOnline.WorkingDirectory = Application.StartupPath;
                HaloOnline.Arguments = "-window --account 123 --sign-in-code 123 -launcher";
                Process.Start(HaloOnline);
            }
            else
            {
                MessageBox.Show("Halo Online is already running!", "DarkLoader uh...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/dark-c0de/DarkLoader/issues", "");
        }


        IntPtr HudPatchAddr;
        private void btnHideHud_Click(object sender, EventArgs e)
        {
            /*
             * Halo Online Build Live_release_0.4.1.332089
             * 
             * Pattern for Hud Toggle
             * F0 3F D9 5D 93 A8 E2 DD 83 3F 00
             * 
             * Replace E2 DD 83 3F with C3 F5 48 40 to hide hud
             * Change it back to bring it back
             */
            if (HudPatchAddr == null || HudPatchAddr.ToInt32() <= 0)
            {
                IntPtr startOffset = HaloOnline.MainModule.BaseAddress;
                IntPtr endOffset = IntPtr.Add(startOffset, HaloOnline.MainModule.ModuleMemorySize);

                SigScan.Classes.SigScan _sigScan = new SigScan.Classes.SigScan();

                _sigScan.Process = HaloOnline;
                _sigScan.Address = startOffset;
                _sigScan.Size = HaloOnline.MainModule.ModuleMemorySize;
                HudPatchAddr = _sigScan.FindPattern(new byte[] { 0xF0, 0x3F, 0xD9, 0x5D, 0x93, 0xA8, 0xE2, 0xDD, 0x83, 0x3F, 0x00 }, "xxxxxxxxxxx", 6);

                if (HudPatchAddr == null || HudPatchAddr.ToInt32() <= 0)
                {
                    //unsupported gmae
                    //Original Halo Online - Eldewrito!
                    // HudPatchAddr = _sigScan.FindPattern(new byte[] { 0x17, 0x56, 0x66, 0x89, 0x47, 0x02, 0xE8, 0x4C, 0xFB, 0xFF, 0xFF, 0x57, 0x53, 0x56 }, "xxxxx??????xxx", 7);
                }
            }
            int lpNumberOfBytesWritten;
            IntPtr p = OpenProcess(0x001F0FFF, true, HaloOnline.Id);
            byte[] HudPatch = { 0xC3, 0xF5, 0x48, 0x40 };
            WriteProcessMemory(p, HudPatchAddr, HudPatch, 4, out lpNumberOfBytesWritten);
        }

        private void btnShowHud_Click(object sender, EventArgs e)
        {
            /*
            * Halo Online Build Live_release_0.4.1.332089
            * 
            * Pattern for Hud Toggle
            * F0 3F D9 5D 93 A8 E2 DD 83 3F 00
            * 
            * Replace E2 DD 83 3F with C3 F5 48 40 to hide hud
            * Change it back to bring it back
            */
            if (HudPatchAddr == null || HudPatchAddr.ToInt32() <= 0)
            {
                IntPtr startOffset = HaloOnline.MainModule.BaseAddress;
                IntPtr endOffset = IntPtr.Add(startOffset, HaloOnline.MainModule.ModuleMemorySize);

                SigScan.Classes.SigScan _sigScan = new SigScan.Classes.SigScan();

                _sigScan.Process = HaloOnline;
                _sigScan.Address = startOffset;
                _sigScan.Size = HaloOnline.MainModule.ModuleMemorySize;
                HudPatchAddr = _sigScan.FindPattern(new byte[] { 0xF0, 0x3F, 0xD9, 0x5D, 0x93, 0xA8, 0xE2, 0xDD, 0x83, 0x3F, 0x00 }, "xxxxxxxxxxx", 6);

                if (HudPatchAddr == null || HudPatchAddr.ToInt32() <= 0)
                {
                    //unsupported gmae
                    //Original Halo Online - Eldewrito!
                    // HudPatchAddr = _sigScan.FindPattern(new byte[] { 0x17, 0x56, 0x66, 0x89, 0x47, 0x02, 0xE8, 0x4C, 0xFB, 0xFF, 0xFF, 0x57, 0x53, 0x56 }, "xxxxx??????xxx", 7);
                }
            }
            int lpNumberOfBytesWritten;
            IntPtr p = OpenProcess(0x001F0FFF, true, HaloOnline.Id);
            byte[] HudPatch = { 0xE2, 0xDD, 0x83, 0x3F };
            WriteProcessMemory(p, HudPatchAddr, HudPatch, 4, out lpNumberOfBytesWritten);
        }
    }
}
