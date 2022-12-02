namespace ArknightsAssistant_GUI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.infomationCenter = new System.Windows.Forms.RichTextBox();
            this.mainCheckBoxList = new System.Windows.Forms.CheckedListBox();
            this.bt_start = new System.Windows.Forms.Button();
            this.cb_afterMisson = new System.Windows.Forms.ComboBox();
            this.l_afterMisson = new System.Windows.Forms.Label();
            this.cb_useMedicines = new System.Windows.Forms.CheckBox();
            this.cb_useRocks = new System.Windows.Forms.CheckBox();
            this.cb_playTimes = new System.Windows.Forms.CheckBox();
            this.cb_selectResource = new System.Windows.Forms.CheckBox();
            this.cb_resourceNum = new System.Windows.Forms.CheckBox();
            this.l_levelSelecter = new System.Windows.Forms.Label();
            this.tb_medicineNum = new System.Windows.Forms.TextBox();
            this.tb_rockNum = new System.Windows.Forms.TextBox();
            this.tb_playTimes = new System.Windows.Forms.TextBox();
            this.tb_useless1 = new System.Windows.Forms.TextBox();
            this.cb_useless1 = new System.Windows.Forms.ComboBox();
            this.cb_levelSelecter = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsddb_tools = new System.Windows.Forms.ToolStripDropDownButton();
            this.bt_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddb_help = new System.Windows.Forms.ToolStripDropDownButton();
            this.bt_checkupdates = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_aboutthissoft = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infomationCenter
            // 
            this.infomationCenter.Location = new System.Drawing.Point(897, 39);
            this.infomationCenter.Name = "infomationCenter";
            this.infomationCenter.ReadOnly = true;
            this.infomationCenter.Size = new System.Drawing.Size(349, 661);
            this.infomationCenter.TabIndex = 0;
            this.infomationCenter.Text = "";
            // 
            // mainCheckBoxList
            // 
            this.mainCheckBoxList.FormattingEnabled = true;
            this.mainCheckBoxList.Location = new System.Drawing.Point(12, 39);
            this.mainCheckBoxList.Name = "mainCheckBoxList";
            this.mainCheckBoxList.Size = new System.Drawing.Size(266, 544);
            this.mainCheckBoxList.TabIndex = 1;
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(12, 637);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(266, 63);
            this.bt_start.TabIndex = 2;
            this.bt_start.Text = "开始执行";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // cb_afterMisson
            // 
            this.cb_afterMisson.FormattingEnabled = true;
            this.cb_afterMisson.Location = new System.Drawing.Point(122, 596);
            this.cb_afterMisson.Name = "cb_afterMisson";
            this.cb_afterMisson.Size = new System.Drawing.Size(156, 32);
            this.cb_afterMisson.TabIndex = 3;
            // 
            // l_afterMisson
            // 
            this.l_afterMisson.AutoSize = true;
            this.l_afterMisson.Location = new System.Drawing.Point(12, 599);
            this.l_afterMisson.Name = "l_afterMisson";
            this.l_afterMisson.Size = new System.Drawing.Size(104, 24);
            this.l_afterMisson.TabIndex = 4;
            this.l_afterMisson.Text = "任务完成后:";
            // 
            // cb_useMedicines
            // 
            this.cb_useMedicines.AutoSize = true;
            this.cb_useMedicines.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_useMedicines.Location = new System.Drawing.Point(358, 39);
            this.cb_useMedicines.Name = "cb_useMedicines";
            this.cb_useMedicines.Size = new System.Drawing.Size(142, 35);
            this.cb_useMedicines.TabIndex = 5;
            this.cb_useMedicines.Text = "吃理智药:";
            this.cb_useMedicines.UseVisualStyleBackColor = true;
            // 
            // cb_useRocks
            // 
            this.cb_useRocks.AutoSize = true;
            this.cb_useRocks.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_useRocks.Location = new System.Drawing.Point(358, 99);
            this.cb_useRocks.Name = "cb_useRocks";
            this.cb_useRocks.Size = new System.Drawing.Size(118, 35);
            this.cb_useRocks.TabIndex = 6;
            this.cb_useRocks.Text = "碎石头:";
            this.cb_useRocks.UseVisualStyleBackColor = true;
            // 
            // cb_playTimes
            // 
            this.cb_playTimes.AutoSize = true;
            this.cb_playTimes.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_playTimes.Location = new System.Drawing.Point(358, 159);
            this.cb_playTimes.Name = "cb_playTimes";
            this.cb_playTimes.Size = new System.Drawing.Size(142, 35);
            this.cb_playTimes.TabIndex = 7;
            this.cb_playTimes.Text = "刷关次数:";
            this.cb_playTimes.UseVisualStyleBackColor = true;
            // 
            // cb_selectResource
            // 
            this.cb_selectResource.AutoSize = true;
            this.cb_selectResource.Enabled = false;
            this.cb_selectResource.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_selectResource.Location = new System.Drawing.Point(358, 219);
            this.cb_selectResource.Name = "cb_selectResource";
            this.cb_selectResource.Size = new System.Drawing.Size(142, 35);
            this.cb_selectResource.TabIndex = 8;
            this.cb_selectResource.Text = "指定材料:";
            this.cb_selectResource.UseVisualStyleBackColor = true;
            // 
            // cb_resourceNum
            // 
            this.cb_resourceNum.AutoSize = true;
            this.cb_resourceNum.Enabled = false;
            this.cb_resourceNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_resourceNum.Location = new System.Drawing.Point(358, 279);
            this.cb_resourceNum.Name = "cb_resourceNum";
            this.cb_resourceNum.Size = new System.Drawing.Size(142, 35);
            this.cb_resourceNum.TabIndex = 9;
            this.cb_resourceNum.Text = "材料数量:";
            this.cb_resourceNum.UseVisualStyleBackColor = true;
            // 
            // l_levelSelecter
            // 
            this.l_levelSelecter.AutoSize = true;
            this.l_levelSelecter.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.l_levelSelecter.Location = new System.Drawing.Point(358, 339);
            this.l_levelSelecter.Name = "l_levelSelecter";
            this.l_levelSelecter.Size = new System.Drawing.Size(116, 31);
            this.l_levelSelecter.TabIndex = 10;
            this.l_levelSelecter.Text = "关卡选择:";
            // 
            // tb_medicineNum
            // 
            this.tb_medicineNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_medicineNum.Location = new System.Drawing.Point(515, 39);
            this.tb_medicineNum.Name = "tb_medicineNum";
            this.tb_medicineNum.Size = new System.Drawing.Size(216, 38);
            this.tb_medicineNum.TabIndex = 11;
            this.tb_medicineNum.Text = "999";
            // 
            // tb_rockNum
            // 
            this.tb_rockNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_rockNum.Location = new System.Drawing.Point(515, 99);
            this.tb_rockNum.Name = "tb_rockNum";
            this.tb_rockNum.Size = new System.Drawing.Size(216, 38);
            this.tb_rockNum.TabIndex = 12;
            this.tb_rockNum.Text = "1";
            // 
            // tb_playTimes
            // 
            this.tb_playTimes.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_playTimes.Location = new System.Drawing.Point(515, 159);
            this.tb_playTimes.Name = "tb_playTimes";
            this.tb_playTimes.Size = new System.Drawing.Size(216, 38);
            this.tb_playTimes.TabIndex = 13;
            this.tb_playTimes.Text = "999";
            // 
            // tb_useless1
            // 
            this.tb_useless1.Enabled = false;
            this.tb_useless1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tb_useless1.Location = new System.Drawing.Point(515, 279);
            this.tb_useless1.Name = "tb_useless1";
            this.tb_useless1.Size = new System.Drawing.Size(216, 38);
            this.tb_useless1.TabIndex = 14;
            // 
            // cb_useless1
            // 
            this.cb_useless1.Enabled = false;
            this.cb_useless1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_useless1.FormattingEnabled = true;
            this.cb_useless1.Location = new System.Drawing.Point(515, 219);
            this.cb_useless1.Name = "cb_useless1";
            this.cb_useless1.Size = new System.Drawing.Size(216, 39);
            this.cb_useless1.TabIndex = 15;
            // 
            // cb_levelSelecter
            // 
            this.cb_levelSelecter.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cb_levelSelecter.FormattingEnabled = true;
            this.cb_levelSelecter.Location = new System.Drawing.Point(515, 336);
            this.cb_levelSelecter.Name = "cb_levelSelecter";
            this.cb_levelSelecter.Size = new System.Drawing.Size(216, 39);
            this.cb_levelSelecter.TabIndex = 16;
            this.cb_levelSelecter.Text = "上一次";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddb_tools,
            this.tsddb_help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1258, 33);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsddb_tools
            // 
            this.tsddb_tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_settings});
            this.tsddb_tools.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_tools.Image")));
            this.tsddb_tools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_tools.Name = "tsddb_tools";
            this.tsddb_tools.Size = new System.Drawing.Size(88, 28);
            this.tsddb_tools.Text = "工具";
            // 
            // bt_settings
            // 
            this.bt_settings.Name = "bt_settings";
            this.bt_settings.Size = new System.Drawing.Size(146, 34);
            this.bt_settings.Text = "设置";
            this.bt_settings.Click += new System.EventHandler(this.bt_settings_Click);
            // 
            // tsddb_help
            // 
            this.tsddb_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bt_checkupdates,
            this.bt_aboutthissoft});
            this.tsddb_help.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_help.Image")));
            this.tsddb_help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_help.Name = "tsddb_help";
            this.tsddb_help.Size = new System.Drawing.Size(88, 28);
            this.tsddb_help.Text = "帮助";
            // 
            // bt_checkupdates
            // 
            this.bt_checkupdates.Enabled = false;
            this.bt_checkupdates.Name = "bt_checkupdates";
            this.bt_checkupdates.Size = new System.Drawing.Size(270, 34);
            this.bt_checkupdates.Text = "检查更新";
            // 
            // bt_aboutthissoft
            // 
            this.bt_aboutthissoft.Name = "bt_aboutthissoft";
            this.bt_aboutthissoft.Size = new System.Drawing.Size(270, 34);
            this.bt_aboutthissoft.Text = "关于此软件";
            this.bt_aboutthissoft.Click += new System.EventHandler(this.bt_aboutthissoft_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1258, 712);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.cb_levelSelecter);
            this.Controls.Add(this.cb_useless1);
            this.Controls.Add(this.tb_useless1);
            this.Controls.Add(this.tb_playTimes);
            this.Controls.Add(this.tb_rockNum);
            this.Controls.Add(this.tb_medicineNum);
            this.Controls.Add(this.l_levelSelecter);
            this.Controls.Add(this.cb_resourceNum);
            this.Controls.Add(this.cb_selectResource);
            this.Controls.Add(this.cb_playTimes);
            this.Controls.Add(this.cb_useRocks);
            this.Controls.Add(this.cb_useMedicines);
            this.Controls.Add(this.l_afterMisson);
            this.Controls.Add(this.cb_afterMisson);
            this.Controls.Add(this.bt_start);
            this.Controls.Add(this.mainCheckBoxList);
            this.Controls.Add(this.infomationCenter);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "ArknightsAssistant - 内部测试专用版本 v0.0.02";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox infomationCenter;
        private CheckedListBox mainCheckBoxList;
        private Button bt_start;
        private ComboBox cb_afterMisson;
        private Label l_afterMisson;
        private CheckBox cb_useMedicines;
        private CheckBox cb_useRocks;
        private CheckBox cb_playTimes;
        private CheckBox cb_selectResource;
        private CheckBox cb_resourceNum;
        private Label l_levelSelecter;
        private TextBox tb_medicineNum;
        private TextBox tb_rockNum;
        private TextBox tb_playTimes;
        private TextBox tb_useless1;
        private ComboBox cb_useless1;
        private ComboBox cb_levelSelecter;
        private ToolStrip toolStrip1;
        private ToolStripDropDownButton tsddb_tools;
        private ToolStripMenuItem bt_settings;
        private ToolStripDropDownButton tsddb_help;
        private ToolStripMenuItem bt_checkupdates;
        private ToolStripMenuItem bt_aboutthissoft;
    }
}