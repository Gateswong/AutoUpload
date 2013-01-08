namespace AutoUpload
{
    partial class formMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lbServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbFNTemplate = new System.Windows.Forms.Label();
            this.txtFNTemplate = new System.Windows.Forms.TextBox();
            this.lbHelp = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.fileWatcher = new System.IO.FileSystemWatcher();
            this.lbDir = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(205, 366);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 0;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lbServer
            // 
            this.lbServer.AutoSize = true;
            this.lbServer.Location = new System.Drawing.Point(12, 9);
            this.lbServer.Name = "lbServer";
            this.lbServer.Size = new System.Drawing.Size(71, 12);
            this.lbServer.TabIndex = 1;
            this.lbServer.Text = "Server:Port";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(89, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(124, 21);
            this.txtServer.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(219, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(61, 21);
            this.txtPort.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(89, 33);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(191, 21);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(89, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(191, 21);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(12, 36);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(53, 12);
            this.lbUser.TabIndex = 6;
            this.lbUser.Text = "Username";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(12, 63);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 12);
            this.lbPassword.TabIndex = 6;
            this.lbPassword.Text = "Password";
            // 
            // lbFNTemplate
            // 
            this.lbFNTemplate.AutoSize = true;
            this.lbFNTemplate.Location = new System.Drawing.Point(12, 144);
            this.lbFNTemplate.Name = "lbFNTemplate";
            this.lbFNTemplate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbFNTemplate.Size = new System.Drawing.Size(149, 12);
            this.lbFNTemplate.TabIndex = 7;
            this.lbFNTemplate.Text = "Target Filename Template";
            // 
            // txtFNTemplate
            // 
            this.txtFNTemplate.Location = new System.Drawing.Point(12, 159);
            this.txtFNTemplate.Name = "txtFNTemplate";
            this.txtFNTemplate.Size = new System.Drawing.Size(268, 21);
            this.txtFNTemplate.TabIndex = 8;
            // 
            // lbHelp
            // 
            this.lbHelp.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHelp.Location = new System.Drawing.Point(12, 183);
            this.lbHelp.Name = "lbHelp";
            this.lbHelp.Size = new System.Drawing.Size(268, 180);
            this.lbHelp.TabIndex = 9;
            this.lbHelp.Text = resources.GetString("lbHelp.Text");
            // 
            // notifyIcon
            // 
            this.notifyIcon.Text = "AutoUpload\r\n- Current not running.";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // fileWatcher
            // 
            this.fileWatcher.EnableRaisingEvents = true;
            this.fileWatcher.NotifyFilter = System.IO.NotifyFilters.FileName;
            this.fileWatcher.SynchronizingObject = this;
            this.fileWatcher.Created += new System.IO.FileSystemEventHandler(this.fileWatcher_Created);
            // 
            // lbDir
            // 
            this.lbDir.AutoSize = true;
            this.lbDir.Location = new System.Drawing.Point(12, 105);
            this.lbDir.Name = "lbDir";
            this.lbDir.Size = new System.Drawing.Size(125, 12);
            this.lbDir.TabIndex = 10;
            this.lbDir.Text = "Directory to monitor";
            // 
            // txtDir
            // 
            this.txtDir.Enabled = false;
            this.txtDir.Location = new System.Drawing.Point(12, 120);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(230, 21);
            this.txtDir.TabIndex = 11;
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Location = new System.Drawing.Point(245, 120);
            this.btnChooseDir.Margin = new System.Windows.Forms.Padding(0);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(35, 23);
            this.btnChooseDir.TabIndex = 12;
            this.btnChooseDir.Text = "...";
            this.btnChooseDir.UseVisualStyleBackColor = true;
            this.btnChooseDir.Click += new System.EventHandler(this.btnChooseDir_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(12, 366);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 392);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnChooseDir);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.lbDir);
            this.Controls.Add(this.lbHelp);
            this.Controls.Add(this.txtFNTemplate);
            this.Controls.Add(this.lbFNTemplate);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lbServer);
            this.Controls.Add(this.btnStartStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formMain";
            this.Text = "AutoUpload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fileWatcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lbServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbFNTemplate;
        private System.Windows.Forms.TextBox txtFNTemplate;
        private System.Windows.Forms.Label lbHelp;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.IO.FileSystemWatcher fileWatcher;
        private System.Windows.Forms.Button btnChooseDir;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label lbDir;
        private System.Windows.Forms.Button btnExit;
    }
}

