using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkLoader
{
    public partial class MemoryView : Form
    {
        public static ByteViewer bv;
        public static bool FormShowing = false;

        public MemoryView()
        {
            InitializeComponent();
        }
        
        private void MemoryView_Load(object sender, EventArgs e)
        {
            LogFile.WriteToLog("------------ Loaded Memory View ------------");
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "MemoryView_Load", "");
            FormShowing = true;
            bv = new ByteViewer();
            bv.Dock = DockStyle.Fill;
            Controls.Add(bv);
            if (MainForm.HaloIsRunning)
            {
                LoadMemoryView();
            }
        }
        public static void LoadMemoryView(){
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "LoadMemoryView", "");
            byte[] someBytes = new byte[512];

            IntPtr pw = Memory.OpenProcess(0x001F0FFF, true, MainForm.HaloOnline.Id);

            int readAt = (int)PatchEditor.CurrentPatchAddress;
            someBytes = Memory.ReadMemory((int)pw, readAt, 512);
            bv.SetBytes(someBytes);
        }

        private void MemoryView_FormClosing(object sender, FormClosingEventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "MemoryView_FormClosing", "");
            FormShowing = false;
        }
    }
}
