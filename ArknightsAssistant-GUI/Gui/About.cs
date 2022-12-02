using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArknightsAssistant_GUI.Gui
{
    public partial class About : Form
    {
        private string version;

        public About(string version)
        {
            this.version = version;
            InitializeComponent();
        }
        private void About_Load(object sender, EventArgs e)
        {
            this.l_version.Text = version;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/ChenXiaojun2008/ArknightsAssistant");
        }

    }
}
