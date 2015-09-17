using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DarkLoader.Forms
{
    public partial class HexHelper : Form
    {
        public static bool FormShowing = false;
        public HexHelper()
        {
            InitializeComponent();
        }

        private void HexHelper_Load(object sender, EventArgs e)
        {
            GoogleAnalyticsApi.TrackPageview("HexHelper.cs", "HexHelper_Load", "");
            FormShowing = true;
        }

        private void HexHelper_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormShowing = false;
        }

        bool DontUpdateBytes = true;
        bool DontUpdateText = true;
        private void txtBytes_TextChanged(object sender, EventArgs e)
        {
            UpdateText();
        }
        private void UpdateText()
        {
            if (!DontUpdateBytes)
            {
                try
                {
                    byte[] Bytes = HelperFunctions.StringToByteArray(txtBytes.Text);
                    if (chkUnicode.Checked)
                    {
                        txtText.Text = System.Text.Encoding.Unicode.GetString(Bytes);
                    }
                    else
                    {
                        txtText.Text = System.Text.Encoding.UTF8.GetString(Bytes);
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            UpdateBytes();
        }
        private void UpdateBytes()
        {
            if (!DontUpdateText)
            {
                try
                {
                    byte[] Bytes;
                    if (chkUnicode.Checked)
                    {
                        Bytes = System.Text.Encoding.Unicode.GetBytes(txtText.Text);
                    }
                    else
                    {
                        Bytes = System.Text.Encoding.UTF8.GetBytes(txtText.Text);
                    }
                    txtBytes.Text = BitConverter.ToString(Bytes).Replace("-", " ");
                }
                catch (Exception)
                {
                }
            }
        }
        private void txtBytes_Enter(object sender, EventArgs e)
        {
            DontUpdateBytes = false;
            DontUpdateText = true;
        }

        private void txtText_Enter(object sender, EventArgs e)
        {
            DontUpdateBytes = true;
            DontUpdateText = false;
        }

        private void chkUnicode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateBytes();
        }
    }
}