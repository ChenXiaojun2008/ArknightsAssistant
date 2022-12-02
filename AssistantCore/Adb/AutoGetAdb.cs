using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssistantCore.Adb
{
    public class AutoGetAdb
    {
        private string[]? GetSimulatorPath()
        {
            Process[] process;

            //BlueStack
            process = Process.GetProcessesByName("HD-Player");
            if (process.ToList().Count != 0)
            {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
                return new string[] { "BlueStack", Path.GetDirectoryName(process[0].MainModule.FileName) };
#pragma warning restore CS8604 // 引用类型参数可能为 null。
            }

            //雷电模拟器
            process = Process.GetProcessesByName("dnplayer");
            if (process.ToList().Count != 0)
            {
#pragma warning disable CS8604 // 引用类型参数可能为 null。
                return new string[] { "雷电模拟器", Path.GetDirectoryName(process[0].MainModule.FileName) };
#pragma warning restore CS8604 // 引用类型参数可能为 null。
            }

            //MUMU 模拟器
            process = Process.GetProcessesByName("NemuPlayer");
            if (process.ToList().Count != 0)
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(string.Format(@"{0}..\..\", Path.GetDirectoryName(process[0].MainModule.FileName)));
                    return new string[] { "MUMU", Path.GetDirectoryName(di.FullName) + @"\vmonitor\bin\" };
                }
                catch
                {
                    return new string[] { "Need Root" };
                }
            }

            return null;
        }
        private string? GetSimulatorAdbPath(string simPath)
        {
            if (simPath is null)
                return null;

            var files = new List<FileInfo>();
            files.AddRange(new DirectoryInfo(simPath).GetFiles());

            for (int i = 0; i < files.Count; i++) 
            {
                if (Path.GetFileName(files[i].FullName).ToLower().Contains("adb") && Path.GetFileName(files[i].FullName).ToLower().Contains("exe"))
                {
                    return files[i].FullName;
                }
            }

            return null;
        }

        public string[]? GetSimulatorAdb()
        {
            string[]? simInfomation = GetSimulatorPath();
            if (simInfomation[0] is null)
                return null;
            if (simInfomation[0] == "Need Root")
                return new string[] { "Need Root" };

            switch(simInfomation[0])
            {
                case "BlueStack":
                    return new string[] { GetSimulatorAdbPath(simInfomation[1]), "127.0.0.1:5555", "BlueStack" };

                case "雷电模拟器":
                    return new string[] { GetSimulatorAdbPath(simInfomation[1]), "emulator-5554", "雷电模拟器" };

                case "MUMU":
                    return new string[] { GetSimulatorAdbPath(simInfomation[1]), "127.0.0.1:7555", "MUMU" };
            }

            return null;
        }
    }
}
