using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkLoader
{
    static class Program
    {
        public static string PatchFile = "DarkLoader-Patches.json";
#if DEBUG
        public static bool IsDebug = true;
#else
        public static bool IsDebug = false;
#endif

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!File.Exists(Application.StartupPath + @"\maps\tags.dat"))
            {
                MessageBox.Show("Please load DarkLoader from your Halo Online Installation Directory.", "Halo.Click - DarkLoader");
                Application.Exit();
            }
            else
            {
                GetVersionJson();
                GetLatestPatchJson();
                Application.Run(new MainForm());
            }
        }

        public static void GetVersionJson(bool force = false)
        {
            //If they don't have a version, let's download the latest from GitHub
            if (!File.Exists("DarkLoader-Versions.json") || force)
            {
                var url = "https://raw.githubusercontent.com/dark-c0de/DarkLoader/master/DarkLoader-Versions.json";
                try
                {
                    var versionFile = (new WebClient()).DownloadString(url);
                    File.WriteAllText("DarkLoader-Versions.json", versionFile);
                }
                catch (Exception e)
                {
                    MessageBox.Show("There was an error downloading the latest version file. Firewall?\n\n" + e.Message);
                }
            }
        }
        public static void GetLatestPatchJson(bool force = false)
        {
            //If they don't have a patch file, let's download the latest from GitHub
            if (!File.Exists(PatchFile) || force)
            {
                var url = "https://raw.githubusercontent.com/dark-c0de/DarkLoader/master/DarkLoader-Patches.json";
                try
                {
                    var patchFile = (new WebClient()).DownloadString(url);
                    File.WriteAllText(PatchFile, patchFile);
                    Program.GetVersionJson(true);
                }
                catch (Exception e)
                {
                    MessageBox.Show("There was an error downloading the latest " + PatchFile + ". Firewall?\n\n" + e.Message);
                }
            }
        }
    }
}