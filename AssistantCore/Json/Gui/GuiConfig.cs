using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantCore.Json.Gui
{
    public class GuiConfig
    {
        public string ADBPath = "";
        public string ADBAdress = "";
        public string ADBPort = "";

        public bool auto_adb = false;
        public bool auto_start = false;
        public bool auto_play = false;

        public bool isLeiDian = false;

        public bool isShowedUpdateInfomations = false;
        public string version = "v0.0.0";
    }
}
