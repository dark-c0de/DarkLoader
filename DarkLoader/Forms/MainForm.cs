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
using Newtonsoft.Json;
namespace DarkLoader
{
    public partial class MainForm : Form
    {
        public static Process HaloOnline;
        public static bool HaloIsRunning = false;

        //Lets keep the previous scan in memory so only the first scan is slow.
        IntPtr pAddr;
        IntPtr MpPatchAddr;

        bool WeRunningYup = false;
       
        bool forceLoading = false;

        string HaloOnlineEXE = "eldorado";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LogFile.WriteToLog("------------- Started DarkLoader -------------");
            GoogleAnalyticsApi.TrackPageview("MainForm.cs", "MainForm_Load", "");

            txtHaloLaunchArguments.Text = Properties.Settings.Default.HOLaunchArguments;
            Thread loadPatches = new Thread(MagicPatches.LoadPatches);
            loadPatches.Start();
            WeRunningYup = true;

            //Set Default Game Mode combo boxes to 
            comboGameModes.SelectedIndex = 2;
            comboGameTypes.SelectedIndex = 0;

            //Are we running the new halo_online.exe build? If so, set the exe name accordingly.
            if (File.Exists(Application.StartupPath + @"\halo_online.exe"))
            {
                HaloOnlineEXE = "halo_online";
            }

            //Let's load the maps up and pull out their info
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

            //Let's keep an eye out for Halo starting and stopping.
            Thread haloWatcher = new Thread(IsHaloRunning);
            haloWatcher.Start();

            //Let's keep an eye out for frost so we can kill it and hijack the session tokens
            Thread frostWatcher = new Thread(FrostWatcher);
            frostWatcher.Start();

            //Let's make sure people are running the greatest latest turd available
            if (!Program.IsDebug)
            {
                Thread checkUpdates = new Thread(CheckForUpdates);
                checkUpdates.Start();
            }
        }
        bool inLauncherLoop = false;
        private void FrostWatcher()
        {
            string FrostLogFile = Application.StartupPath + "/Frost/launcherUpdater.log";
            if (File.Exists(FrostLogFile))
            {
                File.Delete(FrostLogFile);
            }
            while (WeRunningYup)
            {
                try
                {
                    bool LaunchRequest = false;
                    if (File.Exists(FrostLogFile))
                    {
                        var forstProcessess = Process.GetProcesses().Where(pr => pr.ProcessName.Contains("frost"));

                        foreach (var process in forstProcessess)
                        {
                            process.WaitForExit();
                        }
                        string FrostLog = File.ReadAllText(FrostLogFile);
                        File.Delete(FrostLogFile + "-DarkBackup.log");
                        File.Move(FrostLogFile, FrostLogFile + "-DarkBackup.log");

                        if (FrostLog != "")
                        {
                            string launchOptions = FrostLog.Split(new[] { '\r', '\n' }).FirstOrDefault().Split(new[] { "halo_online.exe" }, StringSplitOptions.None)[1];
                            this.Invoke(new MethodInvoker(delegate
                            {
                                txt4gameArguments.Text = launchOptions;
                            }));
                            LaunchRequest = true;
                        }
                    }
                    if (LaunchRequest)
                    {
                        this.Invoke(new MethodInvoker(delegate
                              {
                                  splash = new Forms.Splash();
                                  splash.Show();
                              }));
                        inLauncherLoop = true;
                        Thread launcherLoop = new Thread(KillFrostLauncherLoop);
                        launcherLoop.Start();
                        GoogleAnalyticsApi.TrackEvent("MainForm.cs", "FrostWatcher", "Started Halo Online from 4game");
                        LaunchHaloOnline();
                        inLauncherLoop = false;
                    }
                }
                catch (Exception e)
                {
                    GoogleAnalyticsApi.TrackEvent("Errors", "FrostWatcher", e.Message);
                }
            }
        }
        private void KillFrostLauncherLoop()
        {
            while (inLauncherLoop)
            {
                try
                {
                    var haloProcesses = Process.GetProcesses().Where(pr => pr.ProcessName.Contains("halo"));

                    foreach (var process in haloProcesses)
                    {
                        process.Kill();
                    }

                    haloProcesses = Process.GetProcesses().Where(pr => pr.ProcessName.Contains("Halo"));

                    foreach (var process in haloProcesses)
                    {
                        process.Kill();
                    }
                }
                catch (Exception)
                {

                }
                Thread.Sleep(10);
            }
        }
        private void CheckForUpdates()
        {
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "CheckForUpdates", "");
            var url = "https://raw.githubusercontent.com/dark-c0de/DarkLoader/master/DarkLoader-Versions.json";
            try
            {
                var versionJson = (new WebClient()).DownloadString(url);
                FileVersions.NewFiles = JsonConvert.DeserializeObject<FileVersions.Files>(versionJson);
                FileVersions.OldFiles = JsonConvert.DeserializeObject<FileVersions.Files>(File.ReadAllText("DarkLoader-Versions.json"));
                FileVersions.File file = FileVersions.FindNewByFilename("DarkLoader.exe");
                Version newVersion = Version.Parse(file.version);
                Version currentVersion = Version.Parse(Application.ProductVersion);
                if (currentVersion < newVersion)
                {
                    this.Invoke(new MethodInvoker(delegate { this.Text = "DarkLoader - Update Available!"; }));

                    DialogResult result1 = MessageBox.Show("There's a new version of DarkLoader available. Would you like to download it?", "Oh goody!", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        Process.Start(file.url);
                    }
                }

                FileVersions.File patchesNew = FileVersions.FindNewByFilename("DarkLoader-Patches.json");
                FileVersions.File patchesOld = FileVersions.FindOldByFilename("DarkLoader-Patches.json");

                if (Convert.ToInt32(patchesNew.version) > Convert.ToInt32(patchesOld.version))
                {
                    DialogResult result1 = MessageBox.Show("There's new patches available for DarkLoader. Would you like to download them?", "Oh goody!", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to download the latest Patch File? This will overwrite any changes you've made! If you haven't made any, you'll be fine. If you have, please backup your changes before hitting OK.", "Replace Patches?", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Program.GetLatestPatchJson(true);
                        }
                    }
                }
            }
            catch (Exception e) {
                GoogleAnalyticsApi.TrackEvent("Errors", "CheckForUpdates", e.Message);
            }
        }
        private void IsHaloRunning()
        {
            while (WeRunningYup)
            {
                try
                {
                    if (!HaloOnline.HasExited)
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
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btnHaloClick_Click", "");
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
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btnDarkLoad_Click", "");
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
                IntPtr p = Memory.OpenProcess(0x001F0FFF, true, HaloOnline.Id);

                if (pAddr == null || pAddr.ToInt32() == 0)
                {
                    pAddr = MagicPatches.ScanForPattern(HaloOnline, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x6D, 0x61, 0x70, 0x73, 0x5C, 0x6D, 0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75 }, "xxxxxxxxxxxxxxxxxxxxx", 0);

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
                    //New builds of Halo Online

                    MpPatchAddr = MagicPatches.ScanForPattern(HaloOnline, new byte[] { 0x8B, 0xCE, 0x66, 0x89, 0x43, 0x02, 0xE8, 0x9E, 0x15, 0x00, 0x00, 0x8B, 0x47, 0x10 }, "xxxxx??????xxx", 7);

                    if (MpPatchAddr == null || MpPatchAddr.ToInt32() <= 0)
                    {
                        //Original Halo Online - Eldewrito!
                        MpPatchAddr = MagicPatches.ScanForPattern(HaloOnline, new byte[] { 0x17, 0x56, 0x66, 0x89, 0x47, 0x02, 0xE8, 0x4C, 0xFB, 0xFF, 0xFF, 0x57, 0x53, 0x56 }, "xxxxx??????xxx", 7);
                    }

                    PtrMpPatch = MpPatchAddr - 0x1;
                }

                //Pointer finds 0xF605FE - actual is 0xF605FD

                if (PtrMpPatch.ToInt32() <= 0)
                {
                    GoogleAnalyticsApi.TrackEvent("MainForm.cs", "ForceLoadMap", "Failed to find PtrMpPatch!");
                    MessageBox.Show("Failed to find pointer... Go file a bug report.");
                    return;

                }
                this.btnDarkLoad.Invoke(new MethodInvoker(delegate { btnDarkLoad.Text = "Patching"; }));
                byte[] nop = { 0x90, 0x90, 0x90, 0x90, 0x90 };
                Memory.WriteProcessMemory(p, PtrMpPatch, nop, 5, out lpNumberOfBytesWritten);

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
                Memory.WriteProcessMemory(p, PtrGameType, gameType, 4, out lpNumberOfBytesWritten);
                Memory.WriteProcessMemory(p, PtrMapType, mapType, 4, out lpNumberOfBytesWritten);
                Memory.WriteProcessMemory(p, PtrMapName, mapName, mapName.Length, out lpNumberOfBytesWritten);
                Memory.WriteProcessMemory(p, PtrMapTime, mapTime, 1, out lpNumberOfBytesWritten);
                Memory.WriteProcessMemory(p, PtrMapReset, mapReset, 1, out lpNumberOfBytesWritten);
            }
            catch (Exception ex)
            {
                GoogleAnalyticsApi.TrackEvent("MainForm.cs", "ForceLoadMap", ex.Message);
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
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "MainForm_FormClosing","");
            WeRunningYup = false;
        }
        Forms.Splash splash;
        private void btnLaunchHaloOnline_Click(object sender, EventArgs e)
        {
            btnLaunchHaloOnline.Enabled = false;
            btnLaunchHaloOnline.Text = "Launching...";
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btnLaunchHaloOnline_Click", "");
            splash = new Forms.Splash();
            splash.Show();
            Thread startHalo = new Thread(LaunchHaloOnline);
            startHalo.Start();
        }

        private void LaunchHaloOnline()
        {
            var darkLoadedProcesses = Process.GetProcesses().Where(pr => pr.ProcessName.Contains("darkloaded"));

            foreach (var process in darkLoadedProcesses)
            {
                process.Kill();
                process.WaitForExit();
            }
            if (!HaloIsRunning)
            {
                try
                {
                    byte[] HaloExeBytes = File.ReadAllBytes(Application.StartupPath + @"\" + HaloOnlineEXE + ".exe");

                    string tmpExe = Path.Combine(Application.StartupPath, "darkloaded.exe");
                    string gameShield = Path.Combine(Application.StartupPath, "gameShieldDll.dll");

                    MagicPatches.ExePatches(HaloExeBytes);

                    File.WriteAllBytes(tmpExe, HaloExeBytes);
                    Thread.Sleep(100);
                    if (File.Exists(gameShield))
                    {
                        if (File.Exists(gameShield + ".nope"))
                        {
                            File.Delete(gameShield + ".nope");
                        }
                        File.Move(gameShield, gameShield + ".nope");
                    }
                    HaloOnline = new System.Diagnostics.Process();
                    HaloOnline.StartInfo.FileName = tmpExe;
                    HaloOnline.StartInfo.WorkingDirectory = Application.StartupPath;
                    HaloOnline.StartInfo.Arguments = txtHaloLaunchArguments.Text + " " + txt4gameArguments.Text + " -launcher";

                    HaloOnline.Start();

                    Thread.Sleep(3000);
                    Memory.SuspendProcess(HaloOnline.Id);
                    MagicPatches.RunStartupPatches();
                    Memory.ResumeProcess(HaloOnline.Id);
                    this.Invoke(new MethodInvoker(delegate
                    {
                        splash.Hide();
                    }));
                }
                catch (Exception e)
                {
                    this.Invoke(new MethodInvoker(delegate
                      {
                          splash.Hide();
                      }));
                    GoogleAnalyticsApi.TrackEvent("MainForm.cs", "LaunchHaloOnline", e.Message);
                    MessageBox.Show("Failed to start Halo Online!\n\n" + e.Message, "Something bad happened.");
                }
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    splash.Hide();
                }));
                GoogleAnalyticsApi.TrackEvent("MainForm.cs", "LaunchHaloOnline", "Halo Already Running");
                MessageBox.Show("Halo Online is already running!", "DarkLoader uh...");
            }
            this.Invoke(new MethodInvoker(delegate
                       {
                           btnLaunchHaloOnline.Enabled = true;
                           btnLaunchHaloOnline.Text = "Launch Halo Online";
                       }));

        }

        private void btnIssues_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btnIssues_Click","");
            Process.Start("https://github.com/dark-c0de/DarkLoader/issues", "");
        }

        private void btnHideHud_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btnHideHud_Click", "");
            btnHideHud.Text = "Scanning";
            btnHideHud.Enabled = false;

            MagicPatches.RunPatch("Hud Hide");

            btnHideHud.Text = "Hide Hud";
            btnHideHud.Enabled = true;
        }

        private void btnShowHud_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btnShowHud_Click", "");
            btnShowHud.Text = "Scanning";
            btnShowHud.Enabled = false;

            MagicPatches.RunPatch("Hud Show");
            
            btnShowHud.Text = "Show Hud";
            btnShowHud.Enabled = true;

        }

        PatchEditor patchy;
        private void btnPatchEditor_click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btnPatchEditor_click", "");
            if (!PatchEditor.FormShowing)
            {
                patchy = new PatchEditor();
                patchy.Show();
            }
            else
            {
                patchy.Focus();
            }
        }

        private void btn4gamePlay_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("MainForm.cs", "btn4gamePlay_Click", "");
            MessageBox.Show("Login to 4game and hit Play like you would normally load Halo Online. DarkLoader will catch it and DarkLoad so you can play online.");
            Process.Start("https://ru.4game.com/halo/play/");
        }

        private void comboGameTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboGameTypes.SelectedIndex > 0)
            {
                GoogleAnalyticsApi.TrackEvent("MainForm.cs", "comboGameTypes_SelectedIndexChanged", comboGameTypes.SelectedItem.ToString());
            }
        }

        private void comboGameModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboGameModes.SelectedIndex > 0)
            {
                GoogleAnalyticsApi.TrackEvent("MainForm.cs", "comboGameModes_SelectedIndexChanged", comboGameModes.SelectedItem.ToString());
            }
        }

        private void txtHaloLaunchArguments_TextChanged(object sender, EventArgs e)
        {
           Properties.Settings.Default.HOLaunchArguments =  txtHaloLaunchArguments.Text;
           Properties.Settings.Default.Save();
        }
    }
}