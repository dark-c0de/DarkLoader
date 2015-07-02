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
            this.button1 = new System.Windows.Forms.Button();
            this.groupTools = new System.Windows.Forms.GroupBox();
            this.btnHideHud = new System.Windows.Forms.Button();
            this.btnShowHud = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupTools.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.btnLaunchHaloOnline.Location = new System.Drawing.Point(50, 15);
            this.btnLaunchHaloOnline.Name = "btnLaunchHaloOnline";
            this.btnLaunchHaloOnline.Size = new System.Drawing.Size(107, 33);
            this.btnLaunchHaloOnline.TabIndex = 1;
            this.btnLaunchHaloOnline.Text = "Launch Halo Online";
            this.btnLaunchHaloOnline.UseVisualStyleBackColor = true;
            this.btnLaunchHaloOnline.Click += new System.EventHandler(this.btnLaunchHaloOnline_Click);
            // 
            // listMapInfo
            // 
            this.listMapInfo.BackColor = System.Drawing.SystemColors.Control;
            this.listMapInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listMapInfo.Enabled = false;
            this.listMapInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMapInfo.FormattingEnabled = true;
            this.listMapInfo.Location = new System.Drawing.Point(8, 20);
            this.listMapInfo.Name = "listMapInfo";
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
            this.btnDarkLoad.Location = new System.Drawing.Point(163, 15);
            this.btnDarkLoad.Name = "btnDarkLoad";
            this.btnDarkLoad.Size = new System.Drawing.Size(107, 33);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 47);
            this.button1.TabIndex = 8;
            this.button1.Text = "Doesn\'t Work?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupTools
            // 
            this.groupTools.Controls.Add(this.btnShowHud);
            this.groupTools.Controls.Add(this.btnHideHud);
            this.groupTools.Location = new System.Drawing.Point(526, 12);
            this.groupTools.Name = "groupTools";
            this.groupTools.Size = new System.Drawing.Size(171, 362);
            this.groupTools.TabIndex = 9;
            this.groupTools.TabStop = false;
            this.groupTools.Text = "Tools";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 386);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnHaloClick);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupTools);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DarkLoader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupTools.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupTools;
        private System.Windows.Forms.Button btnHideHud;
        private System.Windows.Forms.Button btnShowHud;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
    }
}

