using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpload
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
            fileWatcher.Created += fileWatcher_Created;
        }

        // PROGRAM CONFIG INFO
        private string ServerAddress;
        private int Port;
        private string Username;
        private string Password;
        private string WatchedDir;
        private string FilenamePattern;
        private System.Net.NetworkCredential nc;


        // FORM UI
        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall &&
                e.CloseReason != CloseReason.WindowsShutDown &&
                e.CloseReason != CloseReason.TaskManagerClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        private void btnChooseDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDir.Text = dialog.SelectedPath;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            try { uploadThread.Abort(); }
            catch { }
            Application.Exit();
        }


        // A FLAG THAT CHECK IF FILE MONITOR IS STARTED
        private bool state;
        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                if (state)
                {
                    btnStartStop.Text = "Stop";
                    notifyIcon.Icon = Properties.Resources.database_start;
                }
                else
                {
                    btnStartStop.Text = "Start";
                    notifyIcon.Icon = Properties.Resources.database_stop;
                }
            }
        }
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!State)
            {
                if (!int.TryParse(txtPort.Text, out Port))
                {
                    MessageBox.Show("Please input right port number!");
                    txtPort.Focus();
                    return;
                }
                ServerAddress = txtServer.Text;
                Username = txtUsername.Text;
                Password = txtPassword.Text;
                if (txtDir.Text == string.Empty) { MessageBox.Show("Please choose a folder!"); return; }
                WatchedDir = txtDir.Text;
                FilenamePattern = txtFNTemplate.Text;

                nc = new System.Net.NetworkCredential(Username, Password);
                FlagFtp.FtpClient testClient = new FlagFtp.FtpClient(nc);
                try
                {
                    testClient.GetDirectories(new Uri(string.Format(
                        @"ftp://{0}:{1}/",
                        ServerAddress,
                        Port)));
                }
                catch (Exception ex) { MessageBox.Show("Unable to connect to server!"); return; }
            }

            State = !State;
            txtServer.Enabled = 
                txtPort.Enabled =
                txtUsername.Enabled = 
                txtPassword.Enabled =
                txtFNTemplate.Enabled = 
                !State;
            fileWatcher.Path = WatchedDir;
            fileWatcher.EnableRaisingEvents = State;
            notifyIcon.Text = string.Format(@"AutoUpload{0}Current State:{1}",
                Environment.NewLine,
                State ? "Started" : "Stopped");

            this.Hide();
            notifyIcon.ShowBalloonTip(5000, "AutoUpload", "Successful Started!", ToolTipIcon.Info);
        }


        // fileWatcher EVENT
        private void fileWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            while (!System.IO.File.Exists(e.FullPath)) { System.Threading.Thread.Sleep(100); }
            fileQueue.Enqueue(new QueuedFile(e.FullPath, e.Name));
            if (uploadThread != null)
            {
                if (uploadThread.ThreadState != System.Threading.ThreadState.Running)
                {
                    try { uploadThread.Abort(); }
                    catch { }
                    uploadThread_Init();
                    uploadThread.Start();
                }
            }
            else
            {
                uploadThread_Init();
                uploadThread.Start();
            }
        }

        
        // FILE LIST
        struct QueuedFile
        {
            public QueuedFile(string fp, string n) { FullName = fp; Name = n; } 
            public string FullName; public string Name; }
        private Queue<QueuedFile> fileQueue = new Queue<QueuedFile>();


        // UPLOAD THERAD
        private System.Threading.Thread uploadThread = null;
        private bool uploadThread_Init()
        {
            try
            {
                FlagFtp.FtpClient client = new FlagFtp.FtpClient(nc);

                uploadThread = new System.Threading.Thread(() =>
                {
                    while (fileQueue.Count > 0)
                    {
#if !DEBUG
                        try
                        {
#endif
                        if (!System.IO.File.Exists(fileQueue.Peek().FullName))
                        {
                            fileQueue.Dequeue(); continue;
                        }
                            string ObjFile = string.Format(@"ftp://{0}:{1}{2}",
                                ServerAddress,
                                Port,
                                (FilenamePattern.StartsWith("/") ? "" : "/") + FilenamePattern);
                            ObjFile = ObjFile.Replace("%file%", fileQueue.Peek().Name);
                            DateTime time = DateTime.Now;
                            ObjFile = ObjFile.Replace("%year%", time.Year.ToString("0000"));
                            ObjFile = ObjFile.Replace("%month%", time.Month.ToString("00"));
                            ObjFile = ObjFile.Replace("%day%", time.Day.ToString("00"));
                            ObjFile = ObjFile.Replace("%hour%", time.Hour.ToString("00"));
                            ObjFile = ObjFile.Replace("%minute%", time.Minute.ToString("00"));
                            ObjFile = ObjFile.Replace("%second%", time.Second.ToString("00"));
                            ObjFile = ObjFile.Replace("%client_user%", Environment.UserName);
                            ObjFile = ObjFile.Replace("%server_user%", Username);

                            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex(
                                @"%random\((\d+)\)%");
                            System.Text.RegularExpressions.MatchCollection matches = regEx.Matches(ObjFile);
                            foreach (System.Text.RegularExpressions.Match match in matches)
                            {
                                int digit;
                                if (!int.TryParse(match.Groups[1].Value, out digit))
                                {
                                    digit = 100;
                                }
                                Random rand = new Random();
                                ObjFile = ObjFile.Replace(match.Groups[0].Value, rand.Next(digit).ToString());
                            }

                            

                            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                            System.IO.StreamReader md5_streamReader = new System.IO.StreamReader(fileQueue.Peek().FullName);
                            StringBuilder sb = new StringBuilder();
                            byte[] md5_result = md5.ComputeHash(md5_streamReader.BaseStream);
                            for (int i = 0; i < md5_result.Length; i++)
                            {
                                sb.AppendFormat("{0:x2}", md5_result[i]);
                            }
                            ObjFile = ObjFile.Replace("%md5%", sb.ToString());
                            md5_streamReader.Close();

                            try
                            {
                                if (client.FileExists(new Uri(ObjFile)))
                                {
                                    if (!System.IO.Directory.Exists(WatchedDir + "\\Failed")) { System.IO.Directory.CreateDirectory(WatchedDir + "\\Failed"); }
                                    System.IO.File.Move(fileQueue.Peek().FullName, WatchedDir + "\\Failed");
                                    throw new Exception(string.Format(@"File {0} exists in server!", ObjFile));
                                }
                            } catch {}

                            System.IO.Stream writer = client.OpenWrite(new Uri(ObjFile));
                            System.IO.StreamReader reader = new System.IO.StreamReader(fileQueue.Peek().FullName);
                            const int buffer_readsize = 1024 * 32;
                            byte[] buffer = new byte[buffer_readsize];
                            int buffer_size = 0;
                            do {
                                buffer_size = reader.BaseStream.Read(buffer,  0, buffer_readsize);
                                writer.Write(buffer, 0, buffer_size);
                            } while (buffer_size == buffer_readsize);
                            writer.Close();
                            reader.Close();

                            if (!System.IO.Directory.Exists(WatchedDir + "\\Complete")) { System.IO.Directory.CreateDirectory(WatchedDir + "\\Complete"); }
                            System.IO.File.Move(fileQueue.Peek().FullName, WatchedDir + "\\Complete\\" + fileQueue.Peek().Name);
                            fileQueue.Dequeue();

#if !DEBUG
                        }
                        catch (Exception ex)
                        {
                        }
#endif
                    }

                });
            }
            catch (Exception ex)
            {
                notifyIcon.BalloonTipIcon = ToolTipIcon.Error;
                notifyIcon.BalloonTipText = ex.ToString();
                notifyIcon.ShowBalloonTip(3000);
                return false;
            }
            return true;
        }
    }
}
