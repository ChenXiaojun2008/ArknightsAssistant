using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AssistantCore.Adb.ScreenShot
{
    public class AdbScreenShot
    {
        private AdbProcess _adbProcess;

        public AdbScreenShot(string adbPath)
        {
            _adbProcess = new AdbProcess(adbPath);
        }

        public void shotOnce(string targetPath)
        {
            _adbProcess.writeLine("shell screencap -p /sdcard/01.jpg");
            _adbProcess.writeLine("pull /sdcard/01.jpg");
            Thread.Sleep(500);
        }
    }
}