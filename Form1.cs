using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Helper;
using Test.Model;
using Test.Schedule;

namespace Test
{
    public partial class Form1 : Form
    {
        private string _desktopPath = $"{Environment.CurrentDirectory}\\FileRun";
        private string _pathFileExe = $"{Environment.CurrentDirectory}\\FileRun\\bizfly-backup.exe";
        private string _pathFileYaml = $"{Environment.CurrentDirectory}\\FileRun\\agent.yaml";
        private string _pathCheckError = $"{Environment.CurrentDirectory}\\error.txt";
        private Scheduler sc = new Scheduler();
        public static string _versionCurrent = "";

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /* Check program is running */
            if (GetProcessIsRunning("bizfly-backup").Any())
            {
                MessageBox.Show("Bạn hãy ấn nút tắt và bắt đầu cập nhật phần mềm !!!", "Thông báo");
                return;
            }

            btnUpdateFirmWare.Enabled = false;

            /* Delete all  old file .exe, download new file */
            DirectoryInfo di = new DirectoryInfo(_desktopPath);

            foreach (FileInfo file in di.GetFiles())
            {
                if (file.Name.Contains("bizfly-backup"))
                {
                    file.Delete();
                    break;
                }
            }

            await DownloadAgent();
            btnUpdateFirmWare.Enabled = true;
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private async void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            await Task.Delay(1_000);

            MessageBox.Show("Thành công", "Thông báo");
            progressBar1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* 
             * Function: Auto start on win
             * 
             * Check app exit on schedule at window start follow step: 
             * 1: Press window + r
             * 2: Enter: "regedit"
             * 3: Follow by RUN_KEY lines below
             */

            ServiceWindowHelper.Start("bizfly");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            /* Schedule task */
            if (!await sc.checkScheduleStartAsync())
            {
                await sc.StartAsync(10, 22, lbIsStatus);
                await sc.StartAsync(0, 0, lbUpdateReady);
            }
            else
            {
                await sc.StopAsync();
            }

            /* Check folder */
            if (!Directory.Exists(_desktopPath))
            {
                Directory.CreateDirectory(_desktopPath);
            }

            /* Config tray icon function */
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            MenuItem zoomOutMenuItem = new MenuItem("Thu nhỏ", new EventHandler(ZoomOut));
            MenuItem zoomInMenuItem = new MenuItem("Phóng lớn", new EventHandler(Open));
            MenuItem exitMenuItem = new MenuItem("Thoát", new EventHandler(Exit));

            notifyIcon1.ContextMenu = new ContextMenu(new MenuItem[] { zoomInMenuItem, zoomOutMenuItem, exitMenuItem });
            notifyIcon1.Visible = true;

            /* Check .exe is running in process */
            if(GetProcessIsRunning("bizfly-backup").Any())
            {
                lbIsStatus.Text = "Đang chạy";
                btnOn.Enabled = false;
                btnOff.Enabled = true;
                btnReset.Enabled = true;
            }
            else
            {
                lbIsStatus.Text = "Đang dừng";
                btnOff.Enabled = false;
                btnReset.Enabled = false;
                btnOn.Enabled = true;
            }

            /* Check user configured app start on with windows */
            if (!String.IsNullOrEmpty(ServiceWindowHelper.CheckReady("bizfly")))
            {
                cbStartOnWindows.Checked = true;
            }
            else
            {
                cbStartOnWindows.Checked = false;
            }

            /* Show key on text box */
            IEnumerable<string> listKey = FileHelper.ReadFileToList(_pathFileYaml);
            if(listKey.Any())
            {
                Regex rgx = new Regex(@"(?<=api_url: |machine_id: |secret_key: |access_key: )(\w*\W*)*");

                foreach (string item in listKey)
                {
                    if(!String.IsNullOrEmpty(item))
                    {
                        if(item.StartsWith("access_key"))
                        {
                            txtAccessKey.Text = rgx.Match(item).Value ?? "";
                        }
                        else if (item.StartsWith("api_url"))
                        {
                            txtApiUrl.Text = rgx.Match(item).Value ?? "";
                        }
                        else if (item.StartsWith("machine_id"))
                        {
                            txtMachineId.Text = rgx.Match(item).Value ?? "";
                        }
                        else
                        {
                            txtSecretKey.Text = rgx.Match(item).Value ?? "";
                        }
                    }
                }
            }
        }

        void ZoomOut(object sender, EventArgs e)
        {
            this.Hide();
        }

        void Open(object sender, EventArgs e)
        {
            this.Show();
        }

        void Exit(object sender, EventArgs e)
        {
            KillProcess("bizfly-backup");
            this.Dispose();
            this.Close();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            RunAgentasService();
            return;
        }

        private void btnOff_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Phần mềm đang chạy, bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            switch (result)
            {
                case DialogResult.Yes:
                {
                    KillProcess("bizfly-backup");

                    lbIsStatus.Text = "Đang dừng";
                    btnOff.Enabled = false;
                    btnReset.Enabled = false;
                    btnOn.Enabled = true;

                    return;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            /* Dont exit app, must kill app by task manager */
            //this.Hide();
            //e.Cancel = true;

            KillProcess("bizfly-backup");
            this.Dispose();
            this.Close();
        }

        private bool CheckKeyFile(string path)
        {
            List<string> data = FileHelper.ReadFileToList(path);

            if(data.Any())
            {
                Regex rgx = new Regex(@"(?<=api_url: |machine_id: |secret_key: |access_key: )(\w*\W*)*");

                foreach (string item in data)
                {
                    bool check = rgx.IsMatch(item);
                    if(!check)
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        private async Task DownloadAgent()
        {
            HttpClientHelper http = new HttpClientHelper();
            string json = await http.Get(@"https://backup-staging.bizflycloud.vn/dashboard/download-urls");
            TypeSystemModel mode = JsonHelper.ConvertToObject<TypeSystemModel>(json);
            if(mode?.lastest_version == null)
            {
                MessageBox.Show("Lỗi khi tải file", "Thông báo");
                return;
            }

            _versionCurrent = mode.lastest_version;

            /* Check type Cpu pc local */
            string urlDownloadFileExe = Environment.Is64BitOperatingSystem ? mode.windows.amd64 : mode.windows._386;

            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += DownloadProgressChanged;
                wc.DownloadFileCompleted += DownloadFileCompleted;

                wc.DownloadFileAsync(new Uri(urlDownloadFileExe), _desktopPath + "\\bizfly-backup.exe");
            }
        }

        private Process[] GetProcessIsRunning(string nameProcess)
        {
            return Process.GetProcessesByName(nameProcess);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            KillProcess("bizfly-backup");
            RunAgentasService();
            btnReset.Enabled = true;
        }

        private void RunAgentasService()
        {
            /* Check file yaml, .exe */
            if (!File.Exists(_pathFileExe))
            {
                MessageBox.Show("Bạn hãy cập nhật phần mềm", "Thông báo");
                return;
            }

            /* Save in4 user if not exit */
            if (!CheckKeyFile(_pathFileYaml))
            {
                string accessKey = txtAccessKey.Text.Trim();
                string apiUrl = txtApiUrl.Text.Trim();
                string machineId = txtMachineId.Text.Trim();
                string secretKey = txtSecretKey.Text.Trim();

                if (String.IsNullOrEmpty(accessKey) || String.IsNullOrEmpty(apiUrl) ||
                    String.IsNullOrEmpty(machineId) || String.IsNullOrEmpty(secretKey))
                {
                    MessageBox.Show("Xin nhập đủ key!!!", "Thông báo");
                    return;
                }
                else
                {
                    /* Write key to file */
                    string  data = $"access_key: {accessKey}{Environment.NewLine}";
                            data += $"api_url: {apiUrl}{Environment.NewLine}";
                            data += $"machine_id: {machineId}{Environment.NewLine}";
                            data += $"secret_key: {secretKey}{Environment.NewLine}";

                    FileHelper.WriteFile(_pathFileYaml, data);
                }
            }

            string cmd = $"\"{_pathFileExe}\"";
            string param = $" agent --config=\"{_pathFileYaml}\"";

            try
            {
                CmdHelper.Command(cmd, param, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra!!!", "Thông báo");
                FileHelper.WriteFile(_pathCheckError, ex.ToString());

                btnOff.Enabled = false;
                btnReset.Enabled = false;

                return;
            }

            lbIsStatus.Text = "Đang chạy";
            btnOff.Enabled = true;
            btnReset.Enabled = true;
            btnOn.Enabled = false;

            return;
        }

        private void KillProcess(string nameProcess)
        {
            Process[] pr = GetProcessIsRunning(nameProcess);

            if(pr.Any())
            {
                foreach(Process item in pr)
                {
                    item.Kill();
                }    
            }
        }

        private void lbUpdateReady_TextChanged(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(lbUpdateReady.Text))
            {
                lbUpdateReady.BackColor = Color.Red;
                MessageBox.Show("Đã có bản cập nhật mới!!!", "Thông báo");
                lbUpdateReady.Text = "";
            }
        }

        private void cbStartOnWindows_CheckedChanged(object sender, EventArgs e)
        {
            /* 
             * Function: Auto start on win
             * 
             * Check app exit on schedule at window start follow step: 
             * 1: Press window + r
             * 2: Enter: "regedit"
             * 3: Follow by RUN_KEY lines below
             */

            if(cbStartOnWindows.Checked)
            {
                ServiceWindowHelper.Start("bizfly");
            }
            else
            {
                ServiceWindowHelper.Delete("bizfly");
            }

            MessageBox.Show("Thành công", "Thông báo");
            return;
        }

        private void cbShowSecretKey_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowSecretKey.Checked == true)
            {
                txtSecretKey.UseSystemPasswordChar = PasswordPropertyTextAttribute.No.Password;
            }
            else
            {
                txtSecretKey.UseSystemPasswordChar = PasswordPropertyTextAttribute.Yes.Password;
            }

            return;
        }

        private void btnSaveSecret_Click(object sender, EventArgs e)
        {
            string accessKey = txtAccessKey.Text.Trim();
            string apiUrl = txtApiUrl.Text.Trim();
            string machineId = txtMachineId.Text.Trim();
            string secretKey = txtSecretKey.Text.Trim();

            if (String.IsNullOrEmpty(accessKey) || String.IsNullOrEmpty(apiUrl) ||
                String.IsNullOrEmpty(machineId) || String.IsNullOrEmpty(secretKey))
            {
                MessageBox.Show("Xin nhập đủ key !!!", "Thông báo");
                return;
            }
            else
            {
                /* Write key to file */
                string  data = $"access_key: {accessKey}{Environment.NewLine}";
                        data += $"api_url: {apiUrl}{Environment.NewLine}";
                        data += $"machine_id: {machineId}{Environment.NewLine}";
                        data += $"secret_key: {secretKey}{Environment.NewLine}";

                FileHelper.WriteFile(_pathFileYaml, data);
                return;
            }
        }

        private void btnSelectFileYaml_Click(object sender, EventArgs e)
        {
            using (FileDialog fileDialog = new OpenFileDialog())
            {
                if (DialogResult.OK == fileDialog.ShowDialog())
                {
                    string sourceFile = fileDialog.FileName;
                    txtPathFileYaml.Text = sourceFile;

                    /* Move selected file to folder code */
                    if (sourceFile.Contains(".yaml"))
                    {
                        /* Delete old file */
                        if(File.Exists(_pathFileYaml))
                        {
                            File.Delete(_pathFileYaml);
                        }

                        File.Move(sourceFile, _pathFileYaml);
                        return;
                    }   
                    else
                    {
                        MessageBox.Show("File chọn không đúng định dạng!!!", "Thông báo");
                        return;
                    }    
                }
            }
        }
    }
}
