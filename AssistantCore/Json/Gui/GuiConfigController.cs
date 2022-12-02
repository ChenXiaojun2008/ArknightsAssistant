using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AssistantCore.Json.Gui
{
    public class GuiConfigController
    {
        public GuiConfig config = new GuiConfig();

        public void setAdbPath(string adbPath) => config.ADBPath = adbPath;
        public void setAutoStart(bool isAutoStart) => config.auto_start = isAutoStart;
        public void setAutoPlay(bool isAutoPlay) => config.auto_play = isAutoPlay;

        public void readFromFile(string path)
        {
            if (!File.Exists(path))
                writeToFile(path);
            string json = File.ReadAllText(path);
            config = JsonConvert.DeserializeObject<GuiConfig>(json);
        }
        public void writeToFile(string path)
        {
            string resultJson = JsonConvert.SerializeObject(config);
            File.WriteAllText(path, resultJson);
        }
    }
}
