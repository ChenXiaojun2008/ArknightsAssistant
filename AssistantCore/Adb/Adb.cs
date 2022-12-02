using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using AssistantCore.Debug.Log;
using AssistantCore.Json.Gui;

namespace AssistantCore.Adb
{
    public class AdbProcess
    {
        private GuiConfigController controller = new GuiConfigController();
        private string? adbPath;
        private LogSystem log = new LogSystem();

        public AdbProcess(string? adbPath)
        {
            this.adbPath = adbPath;

            controller.readFromFile("gui.json");
        }

        public void RunCmdCommand(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Verb = "runas";
            process.Start();
            process.StandardInput.AutoFlush = true;
            process.StandardInput.WriteLine(command);
            process.WaitForExit();
            log.writeLine(process.StandardOutput.ReadToEnd());
            process.Close();
        }

        public void connect()
        {
            RunCmdCommand($"\"{adbPath}\" connect {controller.config.ADBAdress}:{controller.config.ADBPort} &exit");
        }
        public void disconnect()
        {
            RunCmdCommand($"\"{adbPath}\" disconnect &exit");
        }
        
        public void writeLine(string command)
        {
            if(controller.config.isLeiDian is true)
            {
                RunCmdCommand($"\"{adbPath}\" -s {controller.config.ADBAdress} {command} &exit");
            }

            RunCmdCommand($"\"{adbPath}\" -s {controller.config.ADBAdress}:{controller.config.ADBPort} {command} &exit");
        }

        public void close()
        {
            writeLine("kill-server");
        }
    }
}
