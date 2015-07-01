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
            this.SuspendLayout();
            // 
            // listMapNames
            // 
            this.listMapNames.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMapNames.FormattingEnabled = true;
            this.listMapNames.ItemHeight = 18;
            this.listMapNames.Location = new System.Drawing.Point(15, 11);
            this.listMapNames.Name = "listMapNames";
            this.listMapNames.Size = new System.Drawing.Size(115, 292);
            this.listMapNames.TabIndex = 0;
            // 
            // btnLaunchHaloOnline
            // 
            this.btnLaunchHaloOnline.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunchHaloOnline.Location = new System.Drawing.Point(365, 308);
            this.btnLaunchHaloOnline.Name = "btnLaunchHaloOnline";
            this.btnLaunchHaloOnline.Size = new System.Drawing.Size(107, 23);
            this.btnLaunchHaloOnline.TabIndex = 1;
            this.btnLaunchHaloOnline.Text = "Launch Halo Online";
            this.btnLaunchHaloOnline.UseVisualStyleBackColor = true;
            this.btnLaunchHaloOnline.Click += new System.EventHandler(this.btnLaunchHaloOnline_Click);
            // 
            // listMapInfo
            // 
            this.listMapInfo.Enabled = false;
            this.listMapInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMapInfo.FormattingEnabled = true;
            this.listMapInfo.Location = new System.Drawing.Point(136, 182);
            this.listMapInfo.Name = "listMapInfo";
            this.listMapInfo.Size = new System.Drawing.Size(336, 121);
            this.listMapInfo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(345, 156);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // btnHaloClick
            // 
            this.btnHaloClick.Location = new System.Drawing.Point(14, 308);
            this.btnHaloClick.Name = "btnHaloClick";
            this.btnHaloClick.Size = new System.Drawing.Size(75, 23);
            this.btnHaloClick.TabIndex = 4;
            this.btnHaloClick.Text = "Halo.Click";
            this.btnHaloClick.UseVisualStyleBackColor = true;
            this.btnHaloClick.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDarkLoad
            // 
            this.btnDarkLoad.Enabled = false;
            this.btnDarkLoad.Location = new System.Drawing.Point(284, 308);
            this.btnDarkLoad.Name = "btnDarkLoad";
            this.btnDarkLoad.Size = new System.Drawing.Size(75, 23);
            this.btnDarkLoad.TabIndex = 5;
            this.btnDarkLoad.Text = "DarkLoad";
            this.btnDarkLoad.UseVisualStyleBackColor = true;
            this.btnDarkLoad.Click += new System.EventHandler(this.button3_Click);
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
            this.comboGameModes.Location = new System.Drawing.Point(194, 309);
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
            this.comboGameTypes.Location = new System.Drawing.Point(104, 309);
            this.comboGameTypes.Name = "comboGameTypes";
            this.comboGameTypes.Size = new System.Drawing.Size(84, 21);
            this.comboGameTypes.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 47);
            this.button1.TabIndex = 8;
            this.button1.Text = "Doesn\'t Work?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboGameTypes);
            this.Controls.Add(this.comboGameModes);
            this.Controls.Add(this.btnDarkLoad);
            this.Controls.Add(this.btnHaloClick);
            this.Controls.Add(this.btnLaunchHaloOnline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listMapInfo);
            this.Controls.Add(this.listMapNames);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "DarkLoader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}

