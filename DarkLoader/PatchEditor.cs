using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkLoader
{
    public partial class PatchEditor : Form
    {
        public static IntPtr CurrentPatchAddress;
        MagicPatches.Patches patches;
        public static bool FormShowing = false;
        public PatchEditor()
        {
            InitializeComponent();
        }

        private void btnPatchScanTest_click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "btnPatchScanTest_click", "");
            if (MainForm.HaloIsRunning)
            {
                listPatternResults.Items.Clear();
                Thread patchScanTest = new Thread(PatchScanTest);
                patchScanTest.Start();
            }
            else
            {

                MessageBox.Show("Halo isn't running, I can't search for a patch!");
            }
        }

        private void PatchScanTest()
        {
            IntPtr PatchReturnAddress;
            byte[] searchBytePattern = HelperFunctions.StringToByteArray(txtPatternBytesSearch.Text);
            string match = txtPatternMatch.Text;
            int offset = Convert.ToInt32(txtScanOffset.Text);
            PatchReturnAddress = MagicPatches.ScanForPattern(MainForm.HaloOnline, searchBytePattern, match, offset);

            if (PatchReturnAddress == null || PatchReturnAddress.ToInt32() <= 0)
            {
                GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "PatchScanTest", "No results, bad patch?");
                MessageBox.Show("No results, bad patch?");
            }
            else
            {
                GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "PatchScanTest", "Found Results!");
                while (PatchReturnAddress.ToInt32() > 0)
                {
                    this.Invoke((MethodInvoker)delegate()
                    {
                        listPatternResults.Items.Add(PatchReturnAddress.ToString("X"));
                    });
                    IntPtr startOffset = PatchReturnAddress + 0x1;
                    PatchReturnAddress = MagicPatches.ScanForPattern(MainForm.HaloOnline, searchBytePattern, match, offset, startOffset);
                }
            }
        }

        private void listPatternResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPatternResults.SelectedItems.Count > 0)
            {
                string item = listPatternResults.SelectedItems[0].ToString();
                CurrentPatchAddress = (IntPtr)Convert.ToInt32(item, 16);
                GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "listPatternResults_SelectedIndexChanged", item);
            }
            if (!MemoryView.FormShowing)
            {
                MemoryView mv = new MemoryView();
                mv.Show();
            }
            else
            {
                MemoryView.LoadMemoryView();
            }
        }

        private void PatchEditor_Load(object sender, EventArgs e)
        {
            LogFile.WriteToLog("------------ Loaded PatchEditor ------------");
            FormShowing = true;
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "PatchEditor_Load", "");
            lblStatusBar.Text = "Loading Patches....";
            Thread loadPatches = new Thread(LoadPatches);
            loadPatches.Start();
        }
        private void LoadPatches()
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "LoadPatches", "");
            if (!File.Exists(Program.PatchFile))
            {
                File.WriteAllText(Program.PatchFile, "{}");
            }
            string patchList = File.ReadAllText(Program.PatchFile);
            patches = JsonConvert.DeserializeObject<MagicPatches.Patches>(patchList);
            this.Invoke((MethodInvoker)delegate()
                  {
                      int index = listPatches.SelectedIndex;
                      listPatches.Items.Clear();
                      listPatternResults.Items.Clear();
                      foreach (var patch in patches.PatchList)
                      {

                          listPatches.Items.Add(patch.title);

                      }
                      listPatches.SelectedIndex = index;
                      lblStatusBar.Text = "Loaded Patches";
                  });
        }

        private void btnPatchSave_Click(object sender, EventArgs e)
        {
            SavePatch();
        }
        private void SavePatch()
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "SavePatch", txtPatchTitle.Text);
            lblStatusBar.Text = "Saving Patch....";
            MagicPatches.Patch patch = new MagicPatches.Patch
            {
                title = txtPatchTitle.Text,
                author = txtPatchAuthor.Text,
                description = txtPatchDescription.Text,
                pattern = txtPatternBytesSearch.Text,
                match = txtPatternMatch.Text,
                offset = Convert.ToInt32(txtScanOffset.Text),
                patch = txtBytesToPatch.Text,
                recursivePatch = chkPatchReplaceAll.Checked,
                patchOnStartup = chkRunOnStartup.Checked,
                patchBeforeStartup = chkPatchBeforeStartup.Checked
            };
            if (patches.PatchList.ElementAtOrDefault(listPatches.SelectedIndex) != null)
            {
                patches.PatchList.RemoveAt(listPatches.SelectedIndex);
            }
            patches.PatchList.Add(patch);

            WritePatchesToDisk();
        }
        private void listPatches_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listPatches.SelectedItems.Count > 0)
            {
                int index = listPatches.SelectedIndex;
                if (patches.PatchList.ElementAtOrDefault(listPatches.SelectedIndex) != null)
                {
                    txtPatchTitle.Text = patches.PatchList[index].title;
                    txtPatchAuthor.Text = patches.PatchList[index].author;
                    txtPatchDescription.Text = patches.PatchList[index].description;
                    txtPatternBytesSearch.Text = patches.PatchList[index].pattern;
                    txtPatternMatch.Text = patches.PatchList[index].match;
                    txtScanOffset.Text = patches.PatchList[index].offset.ToString();
                    txtBytesToPatch.Text = patches.PatchList[index].patch;
                    chkPatchReplaceAll.Checked = patches.PatchList[index].recursivePatch;
                    chkRunOnStartup.Checked = patches.PatchList[index].patchOnStartup;
                    chkPatchBeforeStartup.Checked = patches.PatchList[index].patchBeforeStartup;
                    grpPatch.Enabled = true;
                    grpPatchInfo.Enabled = true;
                    grpPatchResults.Enabled = true;
                    grpScanBytes.Enabled = true;
                    btnPatchSave.Enabled = true;
                    btnDeletePatch.Enabled = true;
                }
                listPatternResults.Items.Clear();
            }
        }

        private void btnNewPatch_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "btnNewPatch_Click", "");
            listPatches.Items.Add("New Patch");
            listPatches.SelectedIndex = listPatches.Items.Count - 1;
            txtPatchTitle.Text = "New Patch";
            txtPatchAuthor.Text = "";
            txtPatchDescription.Text = "";
            txtPatternBytesSearch.Text = "";
            txtPatternMatch.Text = "";
            txtScanOffset.Text = "0";
            txtBytesToPatch.Text = "";
            chkPatchReplaceAll.Checked = false;
            chkRunOnStartup.Checked = false;
            chkPatchBeforeStartup.Checked = false;
            listPatternResults.Items.Clear();
            SavePatch();

        }

        private void btnDeletePatch_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "btnDeletePatch_Click", "");
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove the patch named \"" + listPatches.SelectedItems[0].ToString() + "\"", "Delete Patch?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int index = listPatches.SelectedIndex;
                patches.PatchList.RemoveAt(index);
                listPatches.SelectedIndex = index - 1;
                WritePatchesToDisk();
            }
        }
        private void WritePatchesToDisk()
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "WritePatchesToDisk", "");
            string jsonPatch = JsonConvert.SerializeObject(patches, Formatting.Indented);
            File.WriteAllText(Program.PatchFile, jsonPatch);
            LoadPatches(); //reload patches in tag editor
            Thread loadPatches = new Thread(MagicPatches.LoadPatches); //reload patches in main app
            loadPatches.Start();
            lblStatusBar.Text = "Patches Saved";
        }

        private void btnReloadPatchList_Click(object sender, EventArgs e)
        {
            lblStatusBar.Text = "Loading Patches....";
            Thread loadPatches = new Thread(LoadPatches);
            loadPatches.Start();
        }

        private void btnTestPatchWrite_click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "btnTestPatchWrite_click", "");
            if (MainForm.HaloIsRunning)
            {
                Thread testPatchWrite = new Thread(TestPatchWrite);
                testPatchWrite.Start();
            }
            else
            {
                MessageBox.Show("Halo isn't running, I can't test a patch write!");
            }

        }
        private void TestPatchWrite()
        {
            if (listPatternResults.Items.Count > 0)
            {
                MagicPatches.Patch tmpPatch = new MagicPatches.Patch
                {
                    title = txtPatchTitle.Text,
                    author = txtPatchAuthor.Text,
                    description = txtPatchDescription.Text,
                    pattern = txtPatternBytesSearch.Text,
                    match = txtPatternMatch.Text,
                    offset = Convert.ToInt32(txtScanOffset.Text),
                    patch = txtBytesToPatch.Text,
                    recursivePatch = chkPatchReplaceAll.Checked,
                    patchOnStartup = chkRunOnStartup.Checked,
                    patchBeforeStartup = chkPatchBeforeStartup.Checked
                };
                if (tmpPatch.recursivePatch)
                {
                    if (MagicPatches.PatchRecursive(tmpPatch))
                    {
                        GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "TestPatchWrite", "Patch Successful");
                        MessageBox.Show("Patch Successful");
                    }
                    else
                    {
                        GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "TestPatchWrite", "Patch Failed.");
                        MessageBox.Show("Patch Failed.");
                    }
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate()
                   {
                       if (listPatternResults.SelectedItems.Count > 0)
                       {
                           string item = listPatternResults.SelectedItems[0].ToString();
                           CurrentPatchAddress = (IntPtr)Convert.ToInt32(item, 16);
                           MagicPatches.PatchSingleAddress(tmpPatch, CurrentPatchAddress);
                       }
                       else
                       {
                           MessageBox.Show("If you're not running a full run, you need to select an address in the patch test results.");
                       }
                   });
                }

            }
            else
            {
                MessageBox.Show("You need to run a pattern scan test before you can test writing.");
            }
        }
        private void btnFillX_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "btnFillX_Click", "");
            byte[] searchBytePattern = HelperFunctions.StringToByteArray(txtPatternBytesSearch.Text);
            txtPatternMatch.Text = HelperFunctions.Repeat("x", searchBytePattern.Length);
        }

        private void memoryViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "memoryViewerToolStripMenuItem_Click", "");
            if (!MemoryView.FormShowing)
            {
                MemoryView mv = new MemoryView();
                mv.Show();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "helpToolStripMenuItem_Click", "");
            Process.Start("https://github.com/dark-c0de/DarkLoader/wiki");
        }

        private void downloadLatestPatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "downloadLatestPatchesToolStripMenuItem_Click", "");
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to download the latest Patch File? This will overwrite any changes you've made! Please backup your changes before hitting OK.", "Replace Patches?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Program.GetLatestPatchJson(true);
                LoadPatches();
            }
        }

        private void PatchEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            GoogleAnalyticsApi.TrackEvent("PatchEditor.cs", "PatchEditor_FormClosing", "");
            FormShowing = false;
        }
    }
}