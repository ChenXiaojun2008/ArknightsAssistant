using ArknightsAssistant_GUI.Gui;

using AssistantCore.Adb;
using AssistantCore.Adb.ScreenShot;
using AssistantCore.Debug.Log;
using AssistantCore.Debug.Zip;
using AssistantCore.Json.Gui;
using AssistantCore.OpenCV.MatchSystem;

namespace ArknightsAssistant_GUI
{
    public partial class Main : Form
    {
        private string? adbPath;
        private bool isConnected = false;

        private GuiConfigController controller = new GuiConfigController();
        private AdbScreenShot? adbScreenShot;
        private MatchSystem matchSystem = new MatchSystem();
        private InfomationSystem.InfomationSystem? infomation;
        private LogSystem log = new LogSystem();

        public Main()
        {
            controller.readFromFile("gui.json");
            if (controller.config.ADBPath is not "")
            {
                this.adbPath = controller.config.ADBPath;
            }

            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //初始化标题
            this.Text = $"ArknightsAssistant - {controller.config.version}";

            //初始化多选
            this.mainCheckBoxList.Items.AddRange(new string[] { "开始唤醒", "刷理智/关卡", "领取任务奖励", "访问好友" });
            this.cb_levelSelecter.Items.AddRange(new string[] { "上一次", "当前" });

            //初始化日志系统
            if (File.Exists("Logs/latest.txt"))
            {
                File.Delete("Logs/latest.txt");
            }
            log.init(controller.config.version);

            //初始化信息显示
            infomation = new InfomationSystem.InfomationSystem(this.infomationCenter);

            //显示更新日志
            if(controller.config.isShowedUpdateInfomations == false)
            {
                UpdateInfomation updateInfomation = new UpdateInfomation();
                updateInfomation.Show();
            }
        }
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            AdbProcess process = new AdbProcess(adbPath);
            process.close();
            //关闭adb进程

            if (File.Exists("01.jpg"))
                File.Delete("01.jpg");

            log.close();

            #region alphaTestResourcesCollect
            /*DebugZip zip = new DebugZip();
            zip.zipFolder("Debug/ResourcesCollect/", "debugResources.zip");
            Directory.Delete("Debug/ResourcesCollect/", true);
            Directory.CreateDirectory("Debug/ResourcesCollect/");
            MessageBox.Show("已将alpha收集文件保存至debugResources.zip，请将此文件发送至开发者，感谢您对ArknightsAssistant的开发支持");*/
            #endregion
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (adbPath is null)
                return;

            infomation.clear();

            infomation.writeLine("正在连接模拟器");
            if (controller.config.isLeiDian == false && isConnected == false)
            {
                AdbProcess process = new AdbProcess(controller.config.ADBPath);

                process.disconnect();
                process.connect();

                isConnected = true;
            }

            this.bt_start.Enabled = false;

            Actuator.Actuator actuator = new Actuator.Actuator();
            adbScreenShot = new AdbScreenShot(adbPath);

            for (int i = 0, counti = mainCheckBoxList.Items.Count; i < counti; i++)
            {
                if (mainCheckBoxList.GetItemChecked(i))
                {
                    switch (mainCheckBoxList.GetItemText(mainCheckBoxList.Items[i]))
                    {
                        case "开始唤醒":
                            actuator.add(1);
                            break;

                        case "刷理智/关卡":
                            switch (cb_levelSelecter.Text)
                            {
                                case "上一次":
                                    actuator.add(2);
                                    break;
                                case "当前":
                                    actuator.add(3);
                                    break;
                            }
                            break;

                        case "领取任务奖励":
                            actuator.add(4);
                            break;

                        case "访问好友":
                            actuator.add(5);
                            break;
                    }
                }
            }

            for (int i = 0; i < actuator.missonTypes.Count; i++)
            {
                switch (actuator.missonTypes[i])
                {
                    #region start
                    case 1:
                        infomation.writeLine("开始任务 \"开始唤醒\"");
                        Thread thread0 = new Thread(actuator.thread);
                        thread0.Start(new string[] { $"{adbPath}", $"start" });
                        while (thread0.IsAlive)
                            Application.DoEvents();
                        infomation.writeLine("完成任务 \"开始唤醒\"");
                        break;
                    #endregion
                    #region play_lasttime
                    case 2:
                        infomation.writeLine("开始任务 \"刷理智/关卡\"");
                        int medTimes = 1, rockTimes = 1, playTimes = 1;
                        if (cb_playTimes.Checked == false)
                            playTimes = 999;
                        else
                            playTimes = int.Parse(tb_playTimes.Text);
                        Thread thread_before1 = new Thread(actuator.thread);
                        thread_before1.Start(new string[] { $"{adbPath}", $"playlasttime" });
                        Thread.Sleep(500);
                        while (thread_before1.IsAlive)
                            Application.DoEvents();
                        for (int j = 1; j <= playTimes; j++)
                        {
                            Thread thread1_0 = new Thread(actuator.thread);
                            thread1_0.Start(new string[] { $"{adbPath}", "click_play" });
                            while (thread1_0.IsAlive)
                                Application.DoEvents();

                            if (cb_useMedicines.Checked == true && medTimes <= int.Parse(tb_medicineNum.Text))
                            {
                                Thread thread1_0_1 = new Thread(actuator.thread);
                                thread1_0_1.Start(new string[] { adbPath, "usemed" });
                                while (thread1_0_1.IsAlive)
                                    Application.DoEvents();
                                medTimes++;
                            }
                            if (cb_useRocks.Checked == true && rockTimes <= int.Parse(tb_rockNum.Text))
                            {
                                Thread thread1_0_2 = new Thread(actuator.thread);
                                thread1_0_2.Start(new string[] { adbPath, "userock" });
                                while (thread1_0_2.IsAlive)
                                    Application.DoEvents();
                                rockTimes++;
                            }

                            adbScreenShot.shotOnce(Application.StartupPath);
                            if (matchSystem.matchTemplate("01.jpg", "Resources/MainPanel/usemed.jpg").similarity > 0.85 || matchSystem.matchTemplate("01.jpg", "Resources/MainPanel/userock.jpg").similarity > 0.85)
                                break;

                            infomation.writeLine($"开始作战 第{j}次");

                            Thread thread1_1 = new Thread(actuator.thread);
                            thread1_1.Start(new string[] { adbPath, "play" });
                            while (thread1_1.IsAlive)
                                Application.DoEvents();

                            Thread thread1_2 = new Thread(actuator.thread_afterPlay);
                            thread1_2.Start(adbPath);
                            while (thread1_2.IsAlive)
                                Application.DoEvents();
                        }
                        infomation.writeLine($"掉落物识别系统将在v0.0.06a版本更新支持，尽情期待");
                        infomation.writeLine("完成任务 \"刷理智/关卡\"");
                        break;
                    #endregion
                    #region play_now
                    case 3:
                        infomation.writeLine("开始任务 \"刷理智/关卡\"");
                        int medTimes_1 = 1, rockTimes_1 = 1, playTimes_1 = 1;
                        if (cb_playTimes.Checked == false)
                            playTimes_1 = 999;
                        else
                            playTimes_1 = int.Parse(tb_playTimes.Text);

                        for (int j = 1; j <= playTimes_1; j++)
                        {
                            Thread thread1_0 = new Thread(actuator.thread);
                            thread1_0.Start(new string[] { $"{adbPath}", "click_play" });
                            while (thread1_0.IsAlive)
                                Application.DoEvents();

                            if (cb_useMedicines.Checked == true && medTimes_1 <= int.Parse(tb_medicineNum.Text))
                            {
                                Thread thread1_0_1 = new Thread(actuator.thread);
                                thread1_0_1.Start(new string[] { adbPath, "usemed" });
                                while (thread1_0_1.IsAlive)
                                    Application.DoEvents();
                                medTimes_1++;
                            }
                            if (cb_useRocks.Checked == true && rockTimes_1 <= int.Parse(tb_rockNum.Text))
                            {
                                Thread thread1_0_2 = new Thread(actuator.thread);
                                thread1_0_2.Start(new string[] { adbPath, "userock" });
                                while (thread1_0_2.IsAlive)
                                    Application.DoEvents();
                                rockTimes_1++;
                            }

                            adbScreenShot.shotOnce(Application.StartupPath);
                            if (matchSystem.matchTemplate("01.jpg", "Resources/MainPanel/usemed.jpg").similarity > 0.85 || matchSystem.matchTemplate("01.jpg", "Resources/MainPanel/userock.jpg").similarity > 0.85)
                                break;

                            infomation.writeLine($"开始作战 第{j}次");

                            Thread thread1_1 = new Thread(actuator.thread);
                            thread1_1.Start(new string[] { adbPath, "play" });
                            while (thread1_1.IsAlive)
                                Application.DoEvents();

                            Thread thread1_2 = new Thread(actuator.thread_afterPlay);
                            thread1_2.Start(adbPath);
                            while (thread1_2.IsAlive)
                                Application.DoEvents();
                        }
                        infomation.writeLine($"掉落物识别系统将在v0.0.06a版本更新支持，尽情期待");
                        infomation.writeLine("完成任务 \"刷理智/关卡\"");
                        break;
                    #endregion
                    #region receive_rewards
                    case 4:
                        infomation.writeLine("开始任务 \"领取任务奖励\"");
                        Thread thread_receiveRewards = new Thread(actuator.thread);
                        thread_receiveRewards.Start(new string[] { $"{adbPath}", $"receiveRewards" });
                        while (thread_receiveRewards.IsAlive)
                            Application.DoEvents();
                        infomation.writeLine("完成任务 \"领取任务奖励\"");
                        break;
                    #endregion
                    #region friend_collect
                    case 5:
                        infomation.writeLine("开始任务 \"访问好友\"");
                        Thread thread_friend_collect = new Thread(actuator.thread);
                        thread_friend_collect.Start(new string[] { $"{adbPath}", $"collectFriends" });
                        while (thread_friend_collect.IsAlive)
                            Application.DoEvents();

                        Thread thread_friend_collect1 = new Thread(actuator.thread_collectFriends);
                        thread_friend_collect1.Start(adbPath);
                        while (thread_friend_collect1.IsAlive)
                            Application.DoEvents();
                        infomation.writeLine("完成任务 \"访问好友\"");
                        break;
                    #endregion

                        #region infrastructure
                        /*case 000:
                            infomation.writeLine("开始任务 \"基建换班(Test)\"");
                            Thread thread_click_infrastructure = new Thread(actuator.thread);
                            thread_click_infrastructure.Start(new string[] { $"{adbPath}", $"infrastructure" });
                            while (thread_click_infrastructure.IsAlive)
                                Application.DoEvents();
                            infomation.writeLine("完成任务 \"基建换班(Test)\"");
                            break;*/
                        #endregion //next version
                }

                //检查可否进行下一步
                if (actuator.missonTypes[i] == 1)
                {
                    Thread thread_wait = new Thread(actuator.thread_wait);
                    thread_wait.Start(new string[] { adbPath, "Resources/MainPanel/terminal.jpg" });
                    while (thread_wait.IsAlive)
                        Application.DoEvents();
                }
            }

            infomation.writeLine("已完成所有任务");

            this.bt_start.Enabled = true;
        }

        //toolstrip
        private void bt_settings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
        private void bt_aboutthissoft_Click(object sender, EventArgs e)
        {
            About about = new About(controller.config.version);
            about.Show();
        }
    }
}