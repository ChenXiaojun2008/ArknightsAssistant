using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AssistantCore.Json.ActionScript
{
    public class ActionScript
    {
        public ActionList list = new ActionList();

        public void readFromFile(string path)
        {
            string json = File.ReadAllText(path);
            list = JsonConvert.DeserializeObject<ActionList>(json);
        }
        public void writeToFile(string path)
        {
            string resultJson = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, resultJson);
        }
    }
}
