namespace DarkLoader
{
    partial class PatchEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listPatches = new System.Windows.Forms.ListBox();
            this.grpScanBytes = new System.Windows.Forms.GroupBox();
            this.lblPatternLength = new System.Windows.Forms.Label();
            this.btnFillX = new System.Windows.Forms.Button();
            this.txtPatternBytesSearch = new System.Windows.Forms.TextBox();
            this.btnPatchScanTest = new System.Windows.Forms.Button();
            this.txtPatternOffset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPatternMatch = new System.Windows.Forms.TextBox();
            this.grpPatchList = new System.Windows.Forms.GroupBox();
            this.btnDeletePatch = new System.Windows.Forms.Button();
            this.btnNewPatch = new System.Windows.Forms.Button();
            this.btnPatchSave = new System.Windows.Forms.Button();
            this.btnReloadPatchList = new System.Windows.Forms.Button();
            this.grpPatchInfo = new System.Windows.Forms.GroupBox();
            this.txtPatchDescription = new System.Windows.Forms.TextBox();
            this.txtPatchAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPatchTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPatchResults = new System.Windows.Forms.GroupBox();
            this.lblPatternResultCount = new System.Windows.Forms.Label();
            this.listPatternResults = new System.Windows.Forms.ListBox();
            this.grpPatch = new System.Windows.Forms.GroupBox();
            this.btnClearPatch = new System.Windows.Forms.Button();
            this.lblBytePatchLength = new System.Windows.Forms.Label();
            this.chkPatchBeforeStartup = new System.Windows.Forms.CheckBox();
            this.chkRunOnStartup = new System.Windows.Forms.CheckBox();
            this.txtBytesToPatch = new System.Windows.Forms.TextBox();
            this.btnTestPatchWrite = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.chkPatchReplaceAll = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadLatestPatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byteHexHelperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearPattern = new System.Windows.Forms.Button();
            this.grpScanBytes.SuspendLayout();
            this.grpPatchList.SuspendLayout();
            this.grpPatchInfo.SuspendLayout();
            this.grpPatchResults.SuspendLayout();
            this.grpPatch.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listPatches
            // 
            this.listPatches.FormattingEnabled = true;
            this.listPatches.Location = new System.Drawing.Point(6, 19);
            this.listPatches.Name = "listPatches";
            this.listPatches.Size = new System.Drawing.Size(189, 342);
            this.listPatches.TabIndex = 0;
            this.listPatches.SelectedIndexChanged += new System.EventHandler(this.listPatches_SelectedIndexChanged);
            // 
            // grpScanBytes
            // 
            this.grpScanBytes.Controls.Add(this.btnClearPattern);
            this.grpScanBytes.Controls.Add(this.lblPatternLength);
            this.grpScanBytes.Controls.Add(this.btnFillX);
            this.grpScanBytes.Controls.Add(this.txtPatternBytesSearch);
            this.grpScanBytes.Controls.Add(this.btnPatchScanTest);
            this.grpScanBytes.Controls.Add(this.txtPatternOffset);
            this.grpScanBytes.Controls.Add(this.label6);
            this.grpScanBytes.Controls.Add(this.label5);
            this.grpScanBytes.Controls.Add(this.label4);
            this.grpScanBytes.Controls.Add(this.txtPatternMatch);
            this.grpScanBytes.Enabled = false;
            this.grpScanBytes.Location = new System.Drawing.Point(218, 40);
            this.grpScanBytes.Name = "grpScanBytes";
            this.grpScanBytes.Size = new System.Drawing.Size(496, 137);
            this.grpScanBytes.TabIndex = 2;
            this.grpScanBytes.TabStop = false;
            this.grpScanBytes.Text = "Pattern Scan Bytes";
            // 
            // lblPatternLength
            // 
            this.lblPatternLength.AutoSize = true;
            this.lblPatternLength.Location = new System.Drawing.Point(445, 9);
            this.lblPatternLength.Name = "lblPatternLength";
            this.lblPatternLength.Size = new System.Drawing.Size(42, 13);
            this.lblPatternLength.TabIndex = 12;
            this.lblPatternLength.Text = "0 Bytes";
            // 
            // btnFillX
            // 
            this.btnFillX.Location = new System.Drawing.Point(446, 67);
            this.btnFillX.Name = "btnFillX";
            this.btnFillX.Size = new System.Drawing.Size(43, 20);
            this.btnFillX.TabIndex = 10;
            this.btnFillX.Text = "Fill";
            this.btnFillX.UseVisualStyleBackColor = true;
            this.btnFillX.Click += new System.EventHandler(this.btnFillX_Click);
            // 
            // txtPatternBytesSearch
            // 
            this.txtPatternBytesSearch.Location = new System.Drawing.Point(57, 24);
            this.txtPatternBytesSearch.Multiline = true;
            this.txtPatternBytesSearch.Name = "txtPatternBytesSearch";
            this.txtPatternBytesSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPatternBytesSearch.Size = new System.Drawing.Size(432, 37);
            this.txtPatternBytesSearch.TabIndex = 9;
            this.txtPatternBytesSearch.TextChanged += new System.EventHandler(this.txtPatternBytesSearch_TextChanged);
            // 
            // btnPatchScanTest
            // 
            this.btnPatchScanTest.Location = new System.Drawing.Point(372, 98);
            this.btnPatchScanTest.Name = "btnPatchScanTest";
            this.btnPatchScanTest.Size = new System.Drawing.Size(115, 23);
            this.btnPatchScanTest.TabIndex = 7;
            this.btnPatchScanTest.Text = "Test Pattern";
            this.btnPatchScanTest.UseVisualStyleBackColor = true;
            this.btnPatchScanTest.Click += new System.EventHandler(this.btnPatchScanTest_click);
            // 
            // txtPatternOffset
            // 
            this.txtPatternOffset.Location = new System.Drawing.Point(57, 98);
            this.txtPatternOffset.Name = "txtPatternOffset";
            this.txtPatternOffset.Size = new System.Drawing.Size(81, 20);
            this.txtPatternOffset.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Offset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pattern";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Match";
            // 
            // txtPatternMatch
            // 
            this.txtPatternMatch.Location = new System.Drawing.Point(57, 67);
            this.txtPatternMatch.Name = "txtPatternMatch";
            this.txtPatternMatch.Size = new System.Drawing.Size(383, 20);
            this.txtPatternMatch.TabIndex = 2;
            // 
            // grpPatchList
            // 
            this.grpPatchList.Controls.Add(this.btnDeletePatch);
            this.grpPatchList.Controls.Add(this.btnNewPatch);
            this.grpPatchList.Controls.Add(this.btnPatchSave);
            this.grpPatchList.Controls.Add(this.btnReloadPatchList);
            this.grpPatchList.Controls.Add(this.listPatches);
            this.grpPatchList.Location = new System.Drawing.Point(12, 40);
            this.grpPatchList.Name = "grpPatchList";
            this.grpPatchList.Size = new System.Drawing.Size(200, 394);
            this.grpPatchList.TabIndex = 3;
            this.grpPatchList.TabStop = false;
            this.grpPatchList.Text = "Patch List";
            // 
            // btnDeletePatch
            // 
            this.btnDeletePatch.Enabled = false;
            this.btnDeletePatch.Location = new System.Drawing.Point(65, 365);
            this.btnDeletePatch.Name = "btnDeletePatch";
            this.btnDeletePatch.Size = new System.Drawing.Size(26, 23);
            this.btnDeletePatch.TabIndex = 5;
            this.btnDeletePatch.Text = "-";
            this.btnDeletePatch.UseVisualStyleBackColor = true;
            this.btnDeletePatch.Click += new System.EventHandler(this.btnDeletePatch_Click);
            // 
            // btnNewPatch
            // 
            this.btnNewPatch.Location = new System.Drawing.Point(97, 365);
            this.btnNewPatch.Name = "btnNewPatch";
            this.btnNewPatch.Size = new System.Drawing.Size(26, 23);
            this.btnNewPatch.TabIndex = 4;
            this.btnNewPatch.Text = "+";
            this.btnNewPatch.UseVisualStyleBackColor = true;
            this.btnNewPatch.Click += new System.EventHandler(this.btnNewPatch_Click);
            // 
            // btnPatchSave
            // 
            this.btnPatchSave.Enabled = false;
            this.btnPatchSave.Location = new System.Drawing.Point(129, 365);
            this.btnPatchSave.Name = "btnPatchSave";
            this.btnPatchSave.Size = new System.Drawing.Size(65, 23);
            this.btnPatchSave.TabIndex = 2;
            this.btnPatchSave.Text = "Save";
            this.btnPatchSave.UseVisualStyleBackColor = true;
            this.btnPatchSave.Click += new System.EventHandler(this.btnPatchSave_Click);
            // 
            // btnReloadPatchList
            // 
            this.btnReloadPatchList.Location = new System.Drawing.Point(6, 365);
            this.btnReloadPatchList.Name = "btnReloadPatchList";
            this.btnReloadPatchList.Size = new System.Drawing.Size(53, 23);
            this.btnReloadPatchList.TabIndex = 1;
            this.btnReloadPatchList.Text = "Reload";
            this.btnReloadPatchList.UseVisualStyleBackColor = true;
            this.btnReloadPatchList.Click += new System.EventHandler(this.btnReloadPatchList_Click);
            // 
            // grpPatchInfo
            // 
            this.grpPatchInfo.Controls.Add(this.txtPatchDescription);
            this.grpPatchInfo.Controls.Add(this.txtPatchAuthor);
            this.grpPatchInfo.Controls.Add(this.label3);
            this.grpPatchInfo.Controls.Add(this.label2);
            this.grpPatchInfo.Controls.Add(this.txtPatchTitle);
            this.grpPatchInfo.Controls.Add(this.label1);
            this.grpPatchInfo.Enabled = false;
            this.grpPatchInfo.Location = new System.Drawing.Point(218, 318);
            this.grpPatchInfo.Name = "grpPatchInfo";
            this.grpPatchInfo.Size = new System.Drawing.Size(664, 116);
            this.grpPatchInfo.TabIndex = 4;
            this.grpPatchInfo.TabStop = false;
            this.grpPatchInfo.Text = "Patch Info";
            // 
            // txtPatchDescription
            // 
            this.txtPatchDescription.Location = new System.Drawing.Point(162, 32);
            this.txtPatchDescription.Multiline = true;
            this.txtPatchDescription.Name = "txtPatchDescription";
            this.txtPatchDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPatchDescription.Size = new System.Drawing.Size(496, 62);
            this.txtPatchDescription.TabIndex = 9;
            // 
            // txtPatchAuthor
            // 
            this.txtPatchAuthor.Location = new System.Drawing.Point(9, 74);
            this.txtPatchAuthor.Name = "txtPatchAuthor";
            this.txtPatchAuthor.Size = new System.Drawing.Size(144, 20);
            this.txtPatchAuthor.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description";
            // 
            // txtPatchTitle
            // 
            this.txtPatchTitle.Location = new System.Drawing.Point(9, 32);
            this.txtPatchTitle.Name = "txtPatchTitle";
            this.txtPatchTitle.Size = new System.Drawing.Size(144, 20);
            this.txtPatchTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // grpPatchResults
            // 
            this.grpPatchResults.Controls.Add(this.lblPatternResultCount);
            this.grpPatchResults.Controls.Add(this.listPatternResults);
            this.grpPatchResults.Enabled = false;
            this.grpPatchResults.Location = new System.Drawing.Point(720, 40);
            this.grpPatchResults.Name = "grpPatchResults";
            this.grpPatchResults.Size = new System.Drawing.Size(162, 278);
            this.grpPatchResults.TabIndex = 5;
            this.grpPatchResults.TabStop = false;
            this.grpPatchResults.Text = "Pattern Test Results";
            // 
            // lblPatternResultCount
            // 
            this.lblPatternResultCount.AutoSize = true;
            this.lblPatternResultCount.Location = new System.Drawing.Point(6, 259);
            this.lblPatternResultCount.Name = "lblPatternResultCount";
            this.lblPatternResultCount.Size = new System.Drawing.Size(51, 13);
            this.lblPatternResultCount.TabIndex = 1;
            this.lblPatternResultCount.Text = "0 Results";
            // 
            // listPatternResults
            // 
            this.listPatternResults.FormattingEnabled = true;
            this.listPatternResults.Location = new System.Drawing.Point(6, 19);
            this.listPatternResults.Name = "listPatternResults";
            this.listPatternResults.Size = new System.Drawing.Size(150, 238);
            this.listPatternResults.TabIndex = 0;
            this.listPatternResults.SelectedIndexChanged += new System.EventHandler(this.listPatternResults_SelectedIndexChanged);
            // 
            // grpPatch
            // 
            this.grpPatch.Controls.Add(this.btnClearPatch);
            this.grpPatch.Controls.Add(this.lblBytePatchLength);
            this.grpPatch.Controls.Add(this.chkPatchBeforeStartup);
            this.grpPatch.Controls.Add(this.chkRunOnStartup);
            this.grpPatch.Controls.Add(this.txtBytesToPatch);
            this.grpPatch.Controls.Add(this.btnTestPatchWrite);
            this.grpPatch.Controls.Add(this.label7);
            this.grpPatch.Controls.Add(this.chkPatchReplaceAll);
            this.grpPatch.Enabled = false;
            this.grpPatch.Location = new System.Drawing.Point(218, 183);
            this.grpPatch.Name = "grpPatch";
            this.grpPatch.Size = new System.Drawing.Size(496, 135);
            this.grpPatch.TabIndex = 6;
            this.grpPatch.TabStop = false;
            this.grpPatch.Text = "Patch";
            // 
            // btnClearPatch
            // 
            this.btnClearPatch.Location = new System.Drawing.Point(291, 104);
            this.btnClearPatch.Name = "btnClearPatch";
            this.btnClearPatch.Size = new System.Drawing.Size(75, 23);
            this.btnClearPatch.TabIndex = 14;
            this.btnClearPatch.Text = "Clear";
            this.btnClearPatch.UseVisualStyleBackColor = true;
            this.btnClearPatch.Click += new System.EventHandler(this.btnClearPatch_Click);
            // 
            // lblBytePatchLength
            // 
            this.lblBytePatchLength.AutoSize = true;
            this.lblBytePatchLength.Location = new System.Drawing.Point(445, 23);
            this.lblBytePatchLength.Name = "lblBytePatchLength";
            this.lblBytePatchLength.Size = new System.Drawing.Size(42, 13);
            this.lblBytePatchLength.TabIndex = 13;
            this.lblBytePatchLength.Text = "0 Bytes";
            // 
            // chkPatchBeforeStartup
            // 
            this.chkPatchBeforeStartup.AutoSize = true;
            this.chkPatchBeforeStartup.Location = new System.Drawing.Point(111, 85);
            this.chkPatchBeforeStartup.Name = "chkPatchBeforeStartup";
            this.chkPatchBeforeStartup.Size = new System.Drawing.Size(149, 17);
            this.chkPatchBeforeStartup.TabIndex = 6;
            this.chkPatchBeforeStartup.Text = "Patch EXE Before Startup";
            this.chkPatchBeforeStartup.UseVisualStyleBackColor = true;
            // 
            // chkRunOnStartup
            // 
            this.chkRunOnStartup.AutoSize = true;
            this.chkRunOnStartup.Location = new System.Drawing.Point(266, 85);
            this.chkRunOnStartup.Name = "chkRunOnStartup";
            this.chkRunOnStartup.Size = new System.Drawing.Size(100, 17);
            this.chkRunOnStartup.TabIndex = 5;
            this.chkRunOnStartup.Text = "Run On Startup";
            this.chkRunOnStartup.UseVisualStyleBackColor = true;
            // 
            // txtBytesToPatch
            // 
            this.txtBytesToPatch.Location = new System.Drawing.Point(19, 39);
            this.txtBytesToPatch.Multiline = true;
            this.txtBytesToPatch.Name = "txtBytesToPatch";
            this.txtBytesToPatch.Size = new System.Drawing.Size(470, 40);
            this.txtBytesToPatch.TabIndex = 4;
            this.txtBytesToPatch.TextChanged += new System.EventHandler(this.txtBytesToPatch_TextChanged);
            // 
            // btnTestPatchWrite
            // 
            this.btnTestPatchWrite.Location = new System.Drawing.Point(372, 104);
            this.btnTestPatchWrite.Name = "btnTestPatchWrite";
            this.btnTestPatchWrite.Size = new System.Drawing.Size(118, 23);
            this.btnTestPatchWrite.TabIndex = 3;
            this.btnTestPatchWrite.Text = "Test Patch";
            this.btnTestPatchWrite.UseVisualStyleBackColor = true;
            this.btnTestPatchWrite.Click += new System.EventHandler(this.btnTestPatchWrite_click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Bytes to patch ";
            // 
            // chkPatchReplaceAll
            // 
            this.chkPatchReplaceAll.AutoSize = true;
            this.chkPatchReplaceAll.Location = new System.Drawing.Point(372, 85);
            this.chkPatchReplaceAll.Name = "chkPatchReplaceAll";
            this.chkPatchReplaceAll.Size = new System.Drawing.Size(118, 17);
            this.chkPatchReplaceAll.TabIndex = 0;
            this.chkPatchReplaceAll.Text = "Replace All Results";
            this.chkPatchReplaceAll.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 452);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(894, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(26, 17);
            this.lblStatusBar.Text = "Idle";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoryViewerToolStripMenuItem,
            this.downloadLatestPatchesToolStripMenuItem,
            this.byteHexHelperToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // memoryViewerToolStripMenuItem
            // 
            this.memoryViewerToolStripMenuItem.Name = "memoryViewerToolStripMenuItem";
            this.memoryViewerToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.memoryViewerToolStripMenuItem.Text = "Memory Viewer";
            this.memoryViewerToolStripMenuItem.Click += new System.EventHandler(this.memoryViewerToolStripMenuItem_Click);
            // 
            // downloadLatestPatchesToolStripMenuItem
            // 
            this.downloadLatestPatchesToolStripMenuItem.Name = "downloadLatestPatchesToolStripMenuItem";
            this.downloadLatestPatchesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.downloadLatestPatchesToolStripMenuItem.Text = "Download Latest Patches";
            this.downloadLatestPatchesToolStripMenuItem.Click += new System.EventHandler(this.downloadLatestPatchesToolStripMenuItem_Click);
            // 
            // byteHexHelperToolStripMenuItem
            // 
            this.byteHexHelperToolStripMenuItem.Name = "byteHexHelperToolStripMenuItem";
            this.byteHexHelperToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.byteHexHelperToolStripMenuItem.Text = "Byte Hex Helper";
            this.byteHexHelperToolStripMenuItem.Click += new System.EventHandler(this.byteHexHelperToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // btnClearPattern
            // 
            this.btnClearPattern.Location = new System.Drawing.Point(291, 98);
            this.btnClearPattern.Name = "btnClearPattern";
            this.btnClearPattern.Size = new System.Drawing.Size(75, 23);
            this.btnClearPattern.TabIndex = 15;
            this.btnClearPattern.Text = "Clear";
            this.btnClearPattern.UseVisualStyleBackColor = true;
            this.btnClearPattern.Click += new System.EventHandler(this.btnClearPattern_Click);
            // 
            // PatchEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 474);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpPatch);
            this.Controls.Add(this.grpPatchResults);
            this.Controls.Add(this.grpPatchInfo);
            this.Controls.Add(this.grpScanBytes);
            this.Controls.Add(this.grpPatchList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PatchEditor";
            this.Text = "DarkLoader - PatchEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatchEditor_FormClosing);
            this.Load += new System.EventHandler(this.PatchEditor_Load);
            this.grpScanBytes.ResumeLayout(false);
            this.grpScanBytes.PerformLayout();
            this.grpPatchList.ResumeLayout(false);
            this.grpPatchInfo.ResumeLayout(false);
            this.grpPatchInfo.PerformLayout();
            this.grpPatchResults.ResumeLayout(false);
            this.grpPatchResults.PerformLayout();
            this.grpPatch.ResumeLayout(false);
            this.grpPatch.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listPatches;
        private System.Windows.Forms.GroupBox grpScanBytes;
        private System.Windows.Forms.GroupBox grpPatchList;
        private System.Windows.Forms.Button btnDeletePatch;
        private System.Windows.Forms.Button btnNewPatch;
        private System.Windows.Forms.Button btnPatchSave;
        private System.Windows.Forms.Button btnReloadPatchList;
        private System.Windows.Forms.GroupBox grpPatchInfo;
        private System.Windows.Forms.TextBox txtPatchAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPatchTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPatchScanTest;
        private System.Windows.Forms.TextBox txtPatternOffset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPatternMatch;
        private System.Windows.Forms.GroupBox grpPatchResults;
        private System.Windows.Forms.ListBox listPatternResults;
        private System.Windows.Forms.GroupBox grpPatch;
        private System.Windows.Forms.Button btnTestPatchWrite;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPatchReplaceAll;
        private System.Windows.Forms.TextBox txtPatternBytesSearch;
        private System.Windows.Forms.TextBox txtPatchDescription;
        private System.Windows.Forms.TextBox txtBytesToPatch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
        private System.Windows.Forms.CheckBox chkRunOnStartup;
        private System.Windows.Forms.Button btnFillX;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkPatchBeforeStartup;
        private System.Windows.Forms.ToolStripMenuItem downloadLatestPatchesToolStripMenuItem;
        private System.Windows.Forms.Label lblPatternLength;
        private System.Windows.Forms.Label lblPatternResultCount;
        private System.Windows.Forms.Label lblBytePatchLength;
        private System.Windows.Forms.ToolStripMenuItem byteHexHelperToolStripMenuItem;
        private System.Windows.Forms.Button btnClearPatch;
        private System.Windows.Forms.Button btnClearPattern;
    }
}