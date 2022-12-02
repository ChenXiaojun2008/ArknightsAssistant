using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantCore.Adb.Touch
{
    public class AdbTouch
    {
        private AdbProcess _adbProcess;

        public AdbTouch(string adbPath)
        {
            _adbProcess = new AdbProcess(adbPath);
        }

        public void click(int X, int Y)
        {
            _adbProcess.writeLine($"shell input tap {X} {Y}");
        }
        public void swipe(int X, int Y, int X1, int Y1)
        {
            _adbProcess.writeLine($"shell input swipe {X} {Y} {X1} {Y1}");
        }
    }
}
