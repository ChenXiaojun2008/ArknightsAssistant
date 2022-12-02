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
            //��ʼ������
            this.Text = $"ArknightsAssistant - {controller.config.version}";

            //��ʼ����ѡ
            this.mainCheckBoxList.Items.AddRange(new string[] { "��ʼ����", "ˢ����/�ؿ�", "��ȡ������", "���ʺ���" });
            this.cb_levelSelecter.Items.AddRange(new string[] { "��һ��", "��ǰ" });

            //��ʼ����־ϵͳ
            if (File.Exists("Logs/latest.txt"))
            {
                File.Delete("Logs/latest.txt");
            }
            log.init(controller.config.version);

            //��ʼ����Ϣ��ʾ
            infomation = new InfomationSystem.InfomationSystem(this.infomationCenter);

            //��ʾ������־
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
            //�ر�adb����

            if (File.Exists("01.jpg"))
                File.Delete("01.jpg");

            log.close();

            #region alphaTestResourcesCollect
            /*DebugZip zip = new DebugZip();
            zip.zipFolder("Debug/ResourcesCollect/", "debugResources.zip");
            Directory.Delete("Debug/ResourcesCollect/", true);
            Directory.CreateDirectory("Debug/ResourcesCollect/");
            MessageBox.Show("�ѽ�alpha�ռ��ļ�������debugResources.zip���뽫���ļ������������ߣ���л����ArknightsAssistant�Ŀ���֧��");*/
            #endregion
        }

        private void bt_start_Click(object sender, EventArgs e)
        {
            if (adbPath is null)
                return;

            infomation.clear();

            infomation.writeLine("��������ģ����");
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
                        case "��ʼ����":
                            actuator.add(1);
                            break;

                        case "ˢ����/�ؿ�":
                            switch (cb_levelSelecter.Text)
                            {
                                case "��һ��":
                                    actuator.add(2);
                                    break;
                                case "��ǰ":
                                    actuator.add(3);
                                    break;
                            }
                            break;

                        case "��ȡ������":
                            actuator.add(4);
                            break;

                        case "���ʺ���":
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
                        infomation.writeLine("��ʼ���� \"��ʼ����\"");
                        Thread thread0 = new Thread(actuator.thread);
                        thread0.Start(new string[] { $"{adbPath}", $"start" });
                        while (thread0.IsAlive)
                            Application.DoEvents();
                        infomation.writeLine("������� \"��ʼ����\"");
                        break;
                    #endregion
                    #region play_lasttime
                    case 2:
                        infomation.writeLine("��ʼ���� \"ˢ����/�ؿ�\"");
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

                            infomation.writeLine($"��ʼ��ս ��{j}��");

                            Thread thread1_1 = new Thread(actuator.thread);
                            thread1_1.Start(new string[] { adbPath, "play" });
                            while (thread1_1.IsAlive)
                                Application.DoEvents();

                            Thread thread1_2 = new Thread(actuator.thread_afterPlay);
                            thread1_2.Start(adbPath);
                            while (thread1_2.IsAlive)
                                Application.DoEvents();
                        }
                        infomation.writeLine($"������ʶ��ϵͳ����v0.0.06a�汾����֧�֣������ڴ�");
                        infomation.writeLine("������� \"ˢ����/�ؿ�\"");
                        break;
                    #endregion
                    #region play_now
                    case 3:
                        infomation.writeLine("��ʼ���� \"ˢ����/�ؿ�\"");
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

                            infomation.writeLine($"��ʼ��ս ��{j}��");

                            Thread thread1_1 = new Thread(actuator.thread);
                            thread1_1.Start(new string[] { adbPath, "play" });
                            while (thread1_1.IsAlive)
                                Application.DoEvents();

                            Thread thread1_2 = new Thread(actuator.thread_afterPlay);
                            thread1_2.Start(adbPath);
                            while (thread1_2.IsAlive)
                                Application.DoEvents();
                        }
                        infomation.writeLine($"������ʶ��ϵͳ����v0.0.06a�汾����֧�֣������ڴ�");
                        infomation.writeLine("������� \"ˢ����/�ؿ�\"");
                        break;
                    #endregion
                    #region receive_rewards
                    case 4:
                        infomation.writeLine("��ʼ���� \"��ȡ������\"");
                        Thread thread_receiveRewards = new Thread(actuator.thread);
                        thread_receiveRewards.Start(new string[] { $"{adbPath}", $"receiveRewards" });
                        while (thread_receiveRewards.IsAlive)
                            Application.DoEvents();
                        infomation.writeLine("������� \"��ȡ������\"");
                        break;
                    #endregion
                    #region friend_collect
                    case 5:
                        infomation.writeLine("��ʼ���� \"���ʺ���\"");
                        Thread thread_friend_collect = new Thread(actuator.thread);
                        thread_friend_collect.Start(new string[] { $"{adbPath}", $"collectFriends" });
                        while (thread_friend_collect.IsAlive)
                            Application.DoEvents();

                        Thread thread_friend_collect1 = new Thread(actuator.thread_collectFriends);
                        thread_friend_collect1.Start(adbPath);
                        while (thread_friend_collect1.IsAlive)
                            Application.DoEvents();
                        infomation.writeLine("������� \"���ʺ���\"");
                        break;
                    #endregion

                        #region infrastructure
                        /*case 000:
                            infomation.writeLine("��ʼ���� \"��������(Test)\"");
                            Thread thread_click_infrastructure = new Thread(actuator.thread);
                            thread_click_infrastructure.Start(new string[] { $"{adbPath}", $"infrastructure" });
                            while (thread_click_infrastructure.IsAlive)
                                Application.DoEvents();
                            infomation.writeLine("������� \"��������(Test)\"");
                            break;*/
                        #endregion //next version
                }

                //���ɷ������һ��
                if (actuator.missonTypes[i] == 1)
                {
                    Thread thread_wait = new Thread(actuator.thread_wait);
                    thread_wait.Start(new string[] { adbPath, "Resources/MainPanel/terminal.jpg" });
                    while (thread_wait.IsAlive)
                        Application.DoEvents();
                }
            }

            infomation.writeLine("�������������");

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