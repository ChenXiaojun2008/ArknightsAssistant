using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantCore.Json.Items
{
    public class Item
    {
        public string itemName = "无法识别";
        public string path = "";
    }
    public class DetectedItem
    {
        public string name = "未知";
        public int number = 0;
    }

    public class Items
    {
        public List<Item> items = new List<Item>();
        public string version = "v0.0.01a";
    }
}
