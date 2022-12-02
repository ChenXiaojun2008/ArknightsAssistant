using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AssistantCore.Adb;
using AssistantCore.Json.Gui;

namespace ArknightsAssistant_GUI
{
    public partial class Settings : Form
    {
        private GuiConfigController controller = new GuiConfigController();

        public Settings()
        {
            InitializeComponent();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            controller.readFromFile("gui.json");

            this.tb_adbPath.Text = controller.config.ADBPath;
            this.tb_adbPort.Text = controller.config.ADBPort;
            this.cb_autoAdbPath.Checked = controller.config.auto_adb;

            if (controller.config.auto_adb == true) 
            {
                this.tb_adbPort.Enabled = false;
                this.bt_selectAdbPath.Enabled = false;
            }
        }

        private void bt_selectAdbPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择您的模拟器adb.exe并打开";
            dialog.Filter = "可运行程序|*.exe";
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
                this.tb_adbPath.Text = dialog.FileName;

            if (this.tb_adbPath.Text is null)
            {
                MessageBox.Show("您尚未选择任何可执行文件,请重新选择", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.tb_adbPath.Text.ToLower().Contains("adb") is false)
            {
                this.tb_adbPath.Text = null;
                MessageBox.Show("您选择的不是adb.exe，请重新选择", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            controller.setAdbPath(this.tb_adbPath.Text);
        }
        private void cb_autoAdbPath_CheckedChanged(object sender, EventArgs e)
        {
            if(this.cb_autoAdbPath.Checked == true)
            {
                controller.config.auto_adb = true;
                this.tb_adbPath.Enabled = false;
                this.bt_selectAdbPath.Enabled = false;
                this.tb_adbPort.Enabled = false;

                AutoGetAdb autoGetAdb = new AutoGetAdb();
                string[]? adbInfomation = autoGetAdb.GetSimulatorAdb();
                this.tb_adbPath.Text = adbInfomation[0];
                if (adbInfomation[0] is null)
                    return;
                if (adbInfomation[0] == "Need Root")
                {
                    MessageBox.Show("您的模拟器可能拥有管理员权限,请以管理员权限启动此软件以获得ADB地址", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (adbInfomation[2] == "雷电模拟器")
                {
                    controller.config.ADBPath = adbInfomation[0];
                    controller.config.ADBAdress = adbInfomation[1];
                    controller.config.isLeiDian = true;
                    return;
                }

                string[] infomationCache = adbInfomation[1].Split(":");
                controller.config.ADBPath = adbInfomation[0];
                controller.config.ADBAdress = infomationCache[0];
                controller.config.ADBPort = infomationCache[1];
                controller.config.isLeiDian = false;

                this.tb_adbPort.Text = infomationCache[1];
            }
            else
            {
                controller.setAdbPath("");
                controller.config.auto_adb = false;
                this.tb_adbPath.Text = "";
                this.tb_adbPath.Enabled = true;
                this.bt_selectAdbPath.Enabled = true;
                this.tb_adbPort.Enabled = true;
            }
        }

        private void bt_comfirm_Click(object sender, EventArgs e)
        {
            controller.writeToFile("gui.json");
            this.Close();
        }
        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
