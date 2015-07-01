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
                byte[] BuildVersion = new byte[32]; //0.4.1.327043 cert_MS26_new
                byte[] MapName = new byte[36];
                byte[] MapTagDir = new byte[256];
                using (BinaryReader reader = new BinaryReader(new FileStream(HaloMapDir + file.Name, FileMode.Open, FileAccess.Read)))
                {
                    reader.BaseStream.Seek(284, SeekOrigin.Begin);
                    reader.Read(BuildVersion, 0, 32);
                    reader.BaseStream.Seek(436, SeekOrigin.Begin);
                    reader.Read(MapName, 0, 36);
                    reader.BaseStream.Seek(472, SeekOrigin.Begin);
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

                if (Application.ProductVersion != versionString)
                {
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
                        this.btnDarkLoad.Invoke(new MethodInvoker(delegate { btnDarkLoad.Enabled = true; }));
                        HaloIsRunning = true;
                    }
                    else
                    {
                        this.btnDarkLoad.Invoke(new MethodInvoker(delegate { btnDarkLoad.Enabled = false; }));
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
        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://halo.click/", "");
        }


        IntPtr PtrMapName;
        IntPtr PtrMapReset;
        IntPtr PtrMapTime;
        IntPtr PtrMapType;
        IntPtr PtrGameType;
        IntPtr PtrMpPatch;

        private void button3_Click(object sender, EventArgs e)
        {
            if (listMapNames.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a map to load on the side list.", "DarkLoader");
                return;
            }
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

                    if (pAddr == null || pAddr.ToInt32() == 0)
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

                if (MpPatchAddr == null || MpPatchAddr.ToInt32() == 0)
                {
                    IntPtr startOffset = HaloOnline.MainModule.BaseAddress;
                    IntPtr endOffset = IntPtr.Add(startOffset, HaloOnline.MainModule.ModuleMemorySize);

                    SigScan.Classes.SigScan _sigScan = new SigScan.Classes.SigScan();

                    _sigScan.Process = HaloOnline;
                    _sigScan.Address = startOffset;
                    _sigScan.Size = HaloOnline.MainModule.ModuleMemorySize;
                    MpPatchAddr = _sigScan.FindPattern(new byte[] { 0x8B, 0xCE, 0x66, 0x89, 0x43, 0x02, 0xE8, 0x9E, 0x15, 0x00, 0x00, 0x8B, 0x47, 0x10 }, "xxxxx??????xxx", 7);
                    PtrMpPatch = MpPatchAddr - 0x1;
                }

                //Pointer finds 0xF605FE - actual is 0xF605FD

                if (PtrMpPatch.ToInt32() == 0)
                {
                    MessageBox.Show("Failed to find pointer... Go file a bug report.");
                    return;

                }

                byte[] nop = { 0x90, 0x90, 0x90, 0x90, 0x90 };
                WriteProcessMemory(p, PtrMpPatch, nop, 5, out lpNumberOfBytesWritten);

                byte[] mapReset = { 0x1 };

                // sets map type
                byte[] mapType = { 0, 0, 0, 0 };
                BitConverter.GetBytes(Convert.ToInt32(comboGameModes.SelectedIndex)).CopyTo(mapType, 0);
                // sets gametype
                byte[] gameType = { 0, 0, 0, 0 };
                BitConverter.GetBytes(Convert.ToInt32(comboGameTypes.SelectedIndex)).CopyTo(gameType, 0);

                // Infinite play time
                byte[] mapTime = { 0x0 };

                // Grab map name from selected listbox
                byte[] mapName = new byte[36];
                Encoding.ASCII.GetBytes(listMapNames.SelectedItem.ToString()).CopyTo(mapName, 0);

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
                HaloOnline.Arguments = "-window --account 123 --sign-in-code 123";
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
    }
}
