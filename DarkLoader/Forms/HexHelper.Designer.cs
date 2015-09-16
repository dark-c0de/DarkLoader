namespace DarkLoader.Forms
{
    partial class HexHelper
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBytes = new System.Windows.Forms.TextBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.chkUnicode = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBytes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bytes";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtText);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Text";
            // 
            // txtBytes
            // 
            this.txtBytes.Location = new System.Drawing.Point(6, 19);
            this.txtBytes.Multiline = true;
            this.txtBytes.Name = "txtBytes";
            this.txtBytes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBytes.Size = new System.Drawing.Size(526, 75);
            this.txtBytes.TabIndex = 0;
            this.txtBytes.TextChanged += new System.EventHandler(this.txtBytes_TextChanged);
            this.txtBytes.Enter += new System.EventHandler(this.txtBytes_Enter);
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(6, 19);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtText.Size = new System.Drawing.Size(526, 75);
            this.txtText.TabIndex = 1;
            this.txtText.TextChanged += new System.EventHandler(this.txtText_TextChanged);
            this.txtText.Enter += new System.EventHandler(this.txtText_Enter);
            // 
            // chkUnicode
            // 
            this.chkUnicode.AutoSize = true;
            this.chkUnicode.Location = new System.Drawing.Point(484, 223);
            this.chkUnicode.Name = "chkUnicode";
            this.chkUnicode.Size = new System.Drawing.Size(66, 17);
            this.chkUnicode.TabIndex = 2;
            this.chkUnicode.Text = "Unicode";
            this.chkUnicode.UseVisualStyleBackColor = true;
            this.chkUnicode.CheckedChanged += new System.EventHandler(this.chkUnicode_CheckedChanged);
            // 
            // HexHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 252);
            this.Controls.Add(this.chkUnicode);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "HexHelper";
            this.Text = "HexHelper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HexHelper_FormClosing);
            this.Load += new System.EventHandler(this.HexHelper_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBytes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.CheckBox chkUnicode;
    }
}