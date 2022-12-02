using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace AssistantCore.Json.Items
{
    public class ItemsController
    {
        public Items items = new Items();

        public void readFromFile(string path)
        {
            if (!File.Exists(path))
                writeToFile(path);
            string json = File.ReadAllText(path);
            items = JsonConvert.DeserializeObject<Items>(json);
        }
        public void writeToFile(string path)
        {
            string resultJson = JsonConvert.SerializeObject(items);
            File.WriteAllText(path, resultJson);
        }
    }
}
