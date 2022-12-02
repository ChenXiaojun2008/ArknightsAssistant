namespace ArknightsAssistant_GUI
{
    partial class UpdateInfomation
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
            this.label_1 = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.rtb_content = new System.Windows.Forms.RichTextBox();
            this.bt_accept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_1.Location = new System.Drawing.Point(25, 22);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(193, 37);
            this.label_1.TabIndex = 0;
            this.label_1.Text = "您已经更新至:";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.Font = new System.Drawing.Font("Microsoft YaHei UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_version.Location = new System.Drawing.Point(224, 22);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(214, 37);
            this.label_version.TabIndex = 2;
            this.label_version.Text = "v0.0.00a-fix00";
            // 
            // rtb_content
            // 
            this.rtb_content.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_content.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rtb_content.Location = new System.Drawing.Point(34, 74);
            this.rtb_content.Name = "rtb_content";
            this.rtb_content.Size = new System.Drawing.Size(731, 326);
            this.rtb_content.TabIndex = 3;
            this.rtb_content.Text = "";
            // 
            // bt_accept
            // 
            this.bt_accept.Location = new System.Drawing.Point(671, 413);
            this.bt_accept.Name = "bt_accept";
            this.bt_accept.Size = new System.Drawing.Size(118, 34);
            this.bt_accept.TabIndex = 4;
            this.bt_accept.Text = "确认";
            this.bt_accept.UseVisualStyleBackColor = true;
            this.bt_accept.Click += new System.EventHandler(this.bt_accept_Click);
            // 
            // UpdateInfomation
            // 
            this.AcceptButton = this.bt_accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 459);
            this.Controls.Add(this.bt_accept);
            this.Controls.Add(this.rtb_content);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateInfomation";
            this.Text = "更新内容";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UpdateInfomation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_1;
        private Label label_version;
        private RichTextBox rtb_content;
        private Button bt_accept;
    }
}