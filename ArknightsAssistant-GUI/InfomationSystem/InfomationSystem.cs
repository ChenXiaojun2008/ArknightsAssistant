using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArknightsAssistant_GUI.InfomationSystem
{
    internal class InfomationSystem
    {
        RichTextBox rtb_infomationCenter;

        public InfomationSystem(RichTextBox rtb)
        {
            rtb_infomationCenter = rtb;
        }

        public void writeLine(string content)
        {
            if(rtb_infomationCenter.Text == "")
            {
                rtb_infomationCenter.Text += $"[{DateTime.Now.ToLongTimeString().ToString()}] {content}";
            }
            else
            {
                rtb_infomationCenter.Text += $"\n[{DateTime.Now.ToLongTimeString().ToString()}] {content}";
            }
        }
        public void clear()
        {
            rtb_infomationCenter.Clear();
        }
    }
}
