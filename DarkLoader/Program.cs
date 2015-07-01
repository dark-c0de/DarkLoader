using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkLoader
{
    static class Program
    {
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
                MessageBox.Show("Please load DarkLoader from your Halo Online Installation Directory.","Halo.Click - DarkLoader");
                Application.Exit();
            }
            else
            {
                Application.Run(new MainForm());
            }
           
        }
    }
}
