namespace DarkLoader
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listMapNames = new System.Windows.Forms.ListBox();
            this.btnLaunchHaloOnline = new System.Windows.Forms.Button();
            this.listMapInfo = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHaloClick = new System.Windows.Forms.Button();
            this.btnDarkLoad = new System.Windows.Forms.Button();
            this.comboGameModes = new System.Windows.Forms.ComboBox();
            this.comboGameTypes = new System.Windows.Forms.ComboBox();
            this.btnHelpMe = new System.Windows.Forms.Button();
            this.groupTools = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowHud = new System.Windows.Forms.Button();
            this.btnHideHud = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPatchEditor = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtHaloLaunchArguments = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txt4gameArguments = new System.Windows.Forms.TextBox();
            this.btn4gamePlay = new System.Windows.Forms.Button();
            this.groupTools.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // listMapNames
            // 
            this.listMapNames.BackColor = System.Drawing.SystemColors.Control;
            this.listMapNames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listMapNames.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMapNames.FormattingEnabled = true;
            this.listMapNames.ItemHeight = 18;
            this.listMapNames.Location = new System.Drawing.Point(8, 20);
            this.listMapNames.Name = "listMapNames";
            this.listMapNames.Size = new System.Drawing.Size(110, 270);
            this.listMapNames.TabIndex = 0;
            // 
            // btnLaunchHaloOnline
            // 
            this.btnLaunchHaloOnline.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunchHaloOnline.Location = new System.Drawing.Point(17, 15);
            this.btnLaunchHaloOnline.Name = "btnLaunchHaloOnline";
            this.btnLaunchHaloOnline.Size = new System.Drawing.Size(130, 33);
            this.btnLaunchHaloOnline.TabIndex = 1;
            this.btnLaunchHaloOnline.Text = "Launch Halo Online";
            this.btnLaunchHaloOnline.UseVisualStyleBackColor = true;
            this.btnLaunchHaloOnline.Click += new System.EventHandler(this.btnLaunchHaloOnline_Click);
            // 
            // listMapInfo
            // 
            this.listMapInfo.BackColor = System.Drawing.SystemColors.Control;
            this.listMapInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listMapInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMapInfo.FormattingEnabled = true;
            this.listMapInfo.Location = new System.Drawing.Point(8, 20);
            this.listMapInfo.Name = "listMapInfo";
            this.listMapInfo.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listMapInfo.Size = new System.Drawing.Size(346, 91);
            this.listMapInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(157, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 156);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnHaloClick
            // 
            this.btnHaloClick.Location = new System.Drawing.Point(445, 69);
            this.btnHaloClick.Name = "btnHaloClick";
            this.btnHaloClick.Size = new System.Drawing.Size(75, 23);
            this.btnHaloClick.TabIndex = 4;
            this.btnHaloClick.Text = "Halo.Click";
            this.btnHaloClick.UseVisualStyleBackColor = true;
            this.btnHaloClick.Click += new System.EventHandler(this.btnHaloClick_Click);
            // 
            // btnDarkLoad
            // 
            this.btnDarkLoad.Enabled = false;
            this.btnDarkLoad.Location = new System.Drawing.Point(167, 15);
            this.btnDarkLoad.Name = "btnDarkLoad";
            this.btnDarkLoad.Size = new System.Drawing.Size(130, 33);
            this.btnDarkLoad.TabIndex = 5;
            this.btnDarkLoad.Text = "DarkLoad";
            this.btnDarkLoad.UseVisualStyleBackColor = true;
            this.btnDarkLoad.Click += new System.EventHandler(this.btnDarkLoad_Click);
            // 
            // comboGameModes
            // 
            this.comboGameModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGameModes.FormattingEnabled = true;
            this.comboGameModes.Items.AddRange(new object[] {
            "None",
            "Campaign",
            "Multiplayer",
            "Mainmenu",
            "Shared",
            "Unknown 6",
            "Unknown 7",
            "Unknown 8",
            "Unknown 9",
            "Unknown 10"});
            this.comboGameModes.Location = new System.Drawing.Point(101, 22);
            this.comboGameModes.Name = "comboGameModes";
            this.comboGameModes.Size = new System.Drawing.Size(84, 21);
            this.comboGameModes.TabIndex = 6;
            // 
            // comboGameTypes
            // 
            this.comboGameTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGameTypes.FormattingEnabled = true;
            this.comboGameTypes.Items.AddRange(new object[] {
            "None",
            "CTF",
            "Slayer",
            "Oddball",
            "Koth",
            "Forge",
            "VIP",
            "Juggernaut",
            "Territories",
            "Assault",
            "Infection"});
            this.comboGameTypes.Location = new System.Drawing.Point(11, 22);
            this.comboGameTypes.Name = "comboGameTypes";
            this.comboGameTypes.Size = new System.Drawing.Size(84, 21);
            this.comboGameTypes.TabIndex = 7;
            // 
            // btnHelpMe
            // 
            this.btnHelpMe.Location = new System.Drawing.Point(445, 20);
            this.btnHelpMe.Name = "btnHelpMe";
            this.btnHelpMe.Size = new System.Drawing.Size(75, 47);
            this.btnHelpMe.TabIndex = 8;
            this.btnHelpMe.Text = "Doesn\'t Work?";
            this.btnHelpMe.UseVisualStyleBackColor = true;
            this.btnHelpMe.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupTools
            // 
            this.groupTools.Controls.Add(this.label2);
            this.groupTools.Controls.Add(this.btnShowHud);
            this.groupTools.Controls.Add(this.btnHideHud);
            this.groupTools.Location = new System.Drawing.Point(526, 12);
            this.groupTools.Name = "groupTools";
            this.groupTools.Size = new System.Drawing.Size(171, 165);
            this.groupTools.TabIndex = 9;
            this.groupTools.TabStop = false;
            this.groupTools.Text = "Tools";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 91);
            this.label2.TabIndex = 2;
            this.label2.Text = "Note:\r\nSpeed is a bit slow because\r\nwe are doing pattern scans.\r\n\r\nWe will fix th" +
    "e slowness in \r\nnewer releases. Until then, \r\nthis might be slow!";
            // 
            // btnShowHud
            // 
            this.btnShowHud.Location = new System.Drawing.Point(9, 20);
            this.btnShowHud.Name = "btnShowHud";
            this.btnShowHud.Size = new System.Drawing.Size(75, 23);
            this.btnShowHud.TabIndex = 1;
            this.btnShowHud.Text = "Show Hud";
            this.btnShowHud.UseVisualStyleBackColor = true;
            this.btnShowHud.Click += new System.EventHandler(this.btnShowHud_Click);
            // 
            // btnHideHud
            // 
            this.btnHideHud.Location = new System.Drawing.Point(90, 20);
            this.btnHideHud.Name = "btnHideHud";
            this.btnHideHud.Size = new System.Drawing.Size(75, 23);
            this.btnHideHud.TabIndex = 0;
            this.btnHideHud.Text = "Hide Hud";
            this.btnHideHud.UseVisualStyleBackColor = true;
            this.btnHideHud.Click += new System.EventHandler(this.btnHideHud_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listMapNames);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 299);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Maps";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listMapInfo);
            this.groupBox3.Location = new System.Drawing.Point(156, 186);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(364, 125);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Map Tag Data";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboGameModes);
            this.groupBox4.Controls.Add(this.comboGameTypes);
            this.groupBox4.Location = new System.Drawing.Point(12, 317);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 57);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Load Options";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnLaunchHaloOnline);
            this.groupBox5.Controls.Add(this.btnDarkLoad);
            this.groupBox5.Location = new System.Drawing.Point(213, 317);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(307, 57);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPatchEditor);
            this.groupBox1.Location = new System.Drawing.Point(526, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(174, 57);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Developer Tools";
            // 
            // btnPatchEditor
            // 
            this.btnPatchEditor.Location = new System.Drawing.Point(9, 22);
            this.btnPatchEditor.Name = "btnPatchEditor";
            this.btnPatchEditor.Size = new System.Drawing.Size(156, 23);
            this.btnPatchEditor.TabIndex = 0;
            this.btnPatchEditor.Text = "Patch Editor";
            this.btnPatchEditor.UseVisualStyleBackColor = true;
            this.btnPatchEditor.Click += new System.EventHandler(this.btnPatchEditor_click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtHaloLaunchArguments);
            this.groupBox6.Location = new System.Drawing.Point(12, 380);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(325, 46);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Halo Online Launch Arguments";
            // 
            // txtHaloLaunchArguments
            // 
            this.txtHaloLaunchArguments.Location = new System.Drawing.Point(11, 19);
            this.txtHaloLaunchArguments.Name = "txtHaloLaunchArguments";
            this.txtHaloLaunchArguments.Size = new System.Drawing.Size(304, 21);
            this.txtHaloLaunchArguments.TabIndex = 0;
            this.txtHaloLaunchArguments.Text = "-window";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn4gamePlay);
            this.groupBox7.Controls.Add(this.txt4gameArguments);
            this.groupBox7.Location = new System.Drawing.Point(349, 380);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(348, 46);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "4game";
            // 
            // txt4gameArguments
            // 
            this.txt4gameArguments.Location = new System.Drawing.Point(69, 19);
            this.txt4gameArguments.Name = "txt4gameArguments";
            this.txt4gameArguments.Size = new System.Drawing.Size(273, 21);
            this.txt4gameArguments.TabIndex = 0;
            this.txt4gameArguments.Text = "--account 123 --sign-in-code 123 --environment MS29_LIVE-AutoDefault-https -frost" +
    "Zone eu";
            // 
            // btn4gamePlay
            // 
            this.btn4gamePlay.Location = new System.Drawing.Point(6, 19);
            this.btn4gamePlay.Name = "btn4gamePlay";
            this.btn4gamePlay.Size = new System.Drawing.Size(57, 21);
            this.btn4gamePlay.TabIndex = 1;
            this.btn4gamePlay.Text = "Play";
            this.btn4gamePlay.UseVisualStyleBackColor = true;
            this.btn4gamePlay.Click += new System.EventHandler(this.btn4gamePlay_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 438);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnHaloClick);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupTools);
            this.Controls.Add(this.btnHelpMe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DarkLoader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupTools.ResumeLayout(false);
            this.groupTools.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listMapNames;
        private System.Windows.Forms.Button btnLaunchHaloOnline;
        private System.Windows.Forms.ListBox listMapInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHaloClick;
        private System.Windows.Forms.Button btnDarkLoad;
        private System.Windows.Forms.ComboBox comboGameModes;
        private System.Windows.Forms.ComboBox comboGameTypes;
        private System.Windows.Forms.Button btnHelpMe;
        private System.Windows.Forms.GroupBox groupTools;
        private System.Windows.Forms.Button btnHideHud;
        private System.Windows.Forms.Button btnShowHud;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPatchEditor;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtHaloLaunchArguments;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txt4gameArguments;
        private System.Windows.Forms.Button btn4gamePlay;
    }
}

