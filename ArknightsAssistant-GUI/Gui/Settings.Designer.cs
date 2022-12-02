namespace ArknightsAssistant_GUI
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ADB设置");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("全局设置", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gb_adbSettings = new System.Windows.Forms.GroupBox();
            this.bt_selectAdbPath = new System.Windows.Forms.Button();
            this.cb_autoAdbPath = new System.Windows.Forms.CheckBox();
            this.tb_adbPath = new System.Windows.Forms.TextBox();
            this.l_adbPath = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.bt_comfirm = new System.Windows.Forms.Button();
            this.l_adbPort = new System.Windows.Forms.Label();
            this.tb_adbPort = new System.Windows.Forms.TextBox();
            this.gb_adbSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.treeView1.Location = new System.Drawing.Point(12, 52);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "n_ADBSettings";
            treeNode1.Text = "ADB设置";
            treeNode2.Name = "n_globalSettings";
            treeNode2.Text = "全局设置";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(241, 396);
            this.treeView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 34);
            this.textBox1.TabIndex = 1;
            // 
            // gb_adbSettings
            // 
            this.gb_adbSettings.Controls.Add(this.tb_adbPort);
            this.gb_adbSettings.Controls.Add(this.l_adbPort);
            this.gb_adbSettings.Controls.Add(this.bt_selectAdbPath);
            this.gb_adbSettings.Controls.Add(this.cb_autoAdbPath);
            this.gb_adbSettings.Controls.Add(this.tb_adbPath);
            this.gb_adbSettings.Controls.Add(this.l_adbPath);
            this.gb_adbSettings.Location = new System.Drawing.Point(273, 12);
            this.gb_adbSettings.Name = "gb_adbSettings";
            this.gb_adbSettings.Size = new System.Drawing.Size(601, 436);
            this.gb_adbSettings.TabIndex = 2;
            this.gb_adbSettings.TabStop = false;
            this.gb_adbSettings.Text = "ADB设置";
            // 
            // bt_selectAdbPath
            // 
            this.bt_selectAdbPath.Location = new System.Drawing.Point(507, 35);
            this.bt_selectAdbPath.Name = "bt_selectAdbPath";
            this.bt_selectAdbPath.Size = new System.Drawing.Size(67, 34);
            this.bt_selectAdbPath.TabIndex = 3;
            this.bt_selectAdbPath.Text = "...";
            this.bt_selectAdbPath.UseVisualStyleBackColor = true;
            this.bt_selectAdbPath.Click += new System.EventHandler(this.bt_selectAdbPath_Click);
            // 
            // cb_autoAdbPath
            // 
            this.cb_autoAdbPath.AutoSize = true;
            this.cb_autoAdbPath.Location = new System.Drawing.Point(26, 120);
            this.cb_autoAdbPath.Name = "cb_autoAdbPath";
            this.cb_autoAdbPath.Size = new System.Drawing.Size(182, 28);
            this.cb_autoAdbPath.TabIndex = 2;
            this.cb_autoAdbPath.Text = "自动获得ADB路径";
            this.cb_autoAdbPath.UseVisualStyleBackColor = true;
            this.cb_autoAdbPath.CheckedChanged += new System.EventHandler(this.cb_autoAdbPath_CheckedChanged);
            // 
            // tb_adbPath
            // 
            this.tb_adbPath.Location = new System.Drawing.Point(144, 37);
            this.tb_adbPath.Name = "tb_adbPath";
            this.tb_adbPath.ReadOnly = true;
            this.tb_adbPath.Size = new System.Drawing.Size(357, 30);
            this.tb_adbPath.TabIndex = 1;
            // 
            // l_adbPath
            // 
            this.l_adbPath.AutoSize = true;
            this.l_adbPath.Location = new System.Drawing.Point(26, 40);
            this.l_adbPath.Name = "l_adbPath";
            this.l_adbPath.Size = new System.Drawing.Size(88, 24);
            this.l_adbPath.TabIndex = 0;
            this.l_adbPath.Text = "ADB路径:";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Location = new System.Drawing.Point(762, 457);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(112, 34);
            this.bt_cancel.TabIndex = 3;
            this.bt_cancel.Text = "取消";
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // bt_comfirm
            // 
            this.bt_comfirm.Location = new System.Drawing.Point(644, 457);
            this.bt_comfirm.Name = "bt_comfirm";
            this.bt_comfirm.Size = new System.Drawing.Size(112, 34);
            this.bt_comfirm.TabIndex = 4;
            this.bt_comfirm.Text = "确定";
            this.bt_comfirm.UseVisualStyleBackColor = true;
            this.bt_comfirm.Click += new System.EventHandler(this.bt_comfirm_Click);
            // 
            // l_adbPort
            // 
            this.l_adbPort.AutoSize = true;
            this.l_adbPort.Location = new System.Drawing.Point(26, 83);
            this.l_adbPort.Name = "l_adbPort";
            this.l_adbPort.Size = new System.Drawing.Size(88, 24);
            this.l_adbPort.TabIndex = 4;
            this.l_adbPort.Text = "ADB端口:";
            // 
            // tb_adbPort
            // 
            this.tb_adbPort.Location = new System.Drawing.Point(144, 80);
            this.tb_adbPort.Name = "tb_adbPort";
            this.tb_adbPort.Size = new System.Drawing.Size(150, 30);
            this.tb_adbPort.TabIndex = 5;
            // 
            // Settings
            // 
            this.AcceptButton = this.bt_comfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bt_cancel;
            this.ClientSize = new System.Drawing.Size(886, 503);
            this.Controls.Add(this.bt_comfirm);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.gb_adbSettings);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Settings";
            this.Text = "设置";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.gb_adbSettings.ResumeLayout(false);
            this.gb_adbSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TreeView treeView1;
        private TextBox textBox1;
        private GroupBox gb_adbSettings;
        private Button bt_selectAdbPath;
        private CheckBox cb_autoAdbPath;
        private TextBox tb_adbPath;
        private Label l_adbPath;
        private Button bt_cancel;
        private Button bt_comfirm;
        private TextBox tb_adbPort;
        private Label l_adbPort;
    }
}