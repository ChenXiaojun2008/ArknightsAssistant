using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssistantCore.Json.Gui;

namespace ArknightsAssistant_GUI
{
    public partial class UpdateInfomation : Form
    {
        public UpdateInfomation()
        {
            InitializeComponent();
        }
        private void UpdateInfomation_Load(object sender, EventArgs e)
        {
            GuiConfigController controller = new GuiConfigController();
            controller.readFromFile("gui.json");

            var files = new List<FileInfo>();
            files.AddRange(new DirectoryInfo(Application.StartupPath).GetFiles());

            for (int i = 0; i < files.Count; i++)
            {
                if (Path.GetFileName(files[i].FullName).Contains("Update") && Path.GetFileName(files[i].FullName).ToLower().Contains("txt"))
                {
                    this.rtb_content.Text = File.ReadAllText(files[i].FullName);
                    this.label_version.Text = Path.GetFileNameWithoutExtension(files[i].FullName).Split("-")[1];
                    controller.config.version = Path.GetFileNameWithoutExtension(files[i].FullName).Split("-")[1];
                }
            }


            controller.config.isShowedUpdateInfomations = true;
            controller.writeToFile("gui.json");
        }

        private void bt_accept_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
