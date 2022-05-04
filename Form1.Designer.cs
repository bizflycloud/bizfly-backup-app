
namespace Test
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnUpdateFirmWare = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPathFileYaml = new System.Windows.Forms.TextBox();
            this.lbPathFile = new System.Windows.Forms.Label();
            this.btnSelectFileYaml = new System.Windows.Forms.Button();
            this.cbShowSecretKey = new System.Windows.Forms.CheckBox();
            this.cbStartOnWindows = new System.Windows.Forms.CheckBox();
            this.btnSaveSecret = new System.Windows.Forms.Button();
            this.lbUpdateReady = new System.Windows.Forms.Label();
            this.txtSecretKey = new System.Windows.Forms.TextBox();
            this.txtMachineId = new System.Windows.Forms.TextBox();
            this.txtApiUrl = new System.Windows.Forms.TextBox();
            this.txtAccessKey = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.lbIsStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdateFirmWare
            // 
            this.btnUpdateFirmWare.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdateFirmWare.Location = new System.Drawing.Point(6, 286);
            this.btnUpdateFirmWare.Name = "btnUpdateFirmWare";
            this.btnUpdateFirmWare.Size = new System.Drawing.Size(131, 23);
            this.btnUpdateFirmWare.TabIndex = 0;
            this.btnUpdateFirmWare.Text = "Cập nhật phần mềm";
            this.btnUpdateFirmWare.UseVisualStyleBackColor = true;
            this.btnUpdateFirmWare.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 315);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(419, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "VcCorp";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.Open);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPathFileYaml);
            this.groupBox1.Controls.Add(this.lbPathFile);
            this.groupBox1.Controls.Add(this.btnSelectFileYaml);
            this.groupBox1.Controls.Add(this.cbShowSecretKey);
            this.groupBox1.Controls.Add(this.cbStartOnWindows);
            this.groupBox1.Controls.Add(this.btnSaveSecret);
            this.groupBox1.Controls.Add(this.lbUpdateReady);
            this.groupBox1.Controls.Add(this.txtSecretKey);
            this.groupBox1.Controls.Add(this.txtMachineId);
            this.groupBox1.Controls.Add(this.txtApiUrl);
            this.groupBox1.Controls.Add(this.txtAccessKey);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnOff);
            this.groupBox1.Controls.Add(this.btnOn);
            this.groupBox1.Controls.Add(this.lbIsStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnUpdateFirmWare);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 344);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quản lý backup";
            // 
            // txtPathFileYaml
            // 
            this.txtPathFileYaml.Location = new System.Drawing.Point(113, 176);
            this.txtPathFileYaml.Name = "txtPathFileYaml";
            this.txtPathFileYaml.ReadOnly = true;
            this.txtPathFileYaml.Size = new System.Drawing.Size(289, 20);
            this.txtPathFileYaml.TabIndex = 21;
            // 
            // lbPathFile
            // 
            this.lbPathFile.AutoSize = true;
            this.lbPathFile.Location = new System.Drawing.Point(6, 179);
            this.lbPathFile.Name = "lbPathFile";
            this.lbPathFile.Size = new System.Drawing.Size(76, 13);
            this.lbPathFile.TabIndex = 20;
            this.lbPathFile.Text = "ĐƯỜNG DẪN:";
            // 
            // btnSelectFileYaml
            // 
            this.btnSelectFileYaml.Location = new System.Drawing.Point(113, 243);
            this.btnSelectFileYaml.Name = "btnSelectFileYaml";
            this.btnSelectFileYaml.Size = new System.Drawing.Size(66, 23);
            this.btnSelectFileYaml.TabIndex = 19;
            this.btnSelectFileYaml.Text = "Chọn file";
            this.btnSelectFileYaml.UseVisualStyleBackColor = true;
            this.btnSelectFileYaml.Click += new System.EventHandler(this.btnSelectFileYaml_Click);
            // 
            // cbShowSecretKey
            // 
            this.cbShowSecretKey.AutoSize = true;
            this.cbShowSecretKey.Location = new System.Drawing.Point(410, 150);
            this.cbShowSecretKey.Name = "cbShowSecretKey";
            this.cbShowSecretKey.Size = new System.Drawing.Size(15, 14);
            this.cbShowSecretKey.TabIndex = 18;
            this.cbShowSecretKey.UseVisualStyleBackColor = true;
            this.cbShowSecretKey.CheckedChanged += new System.EventHandler(this.cbShowSecretKey_CheckedChanged);
            // 
            // cbStartOnWindows
            // 
            this.cbStartOnWindows.AutoSize = true;
            this.cbStartOnWindows.Location = new System.Drawing.Point(282, 290);
            this.cbStartOnWindows.Name = "cbStartOnWindows";
            this.cbStartOnWindows.Size = new System.Drawing.Size(149, 17);
            this.cbStartOnWindows.TabIndex = 4;
            this.cbStartOnWindows.Text = "Khởi động cùng Windows";
            this.cbStartOnWindows.UseVisualStyleBackColor = true;
            this.cbStartOnWindows.CheckedChanged += new System.EventHandler(this.cbStartOnWindows_CheckedChanged);
            // 
            // btnSaveSecret
            // 
            this.btnSaveSecret.Location = new System.Drawing.Point(339, 214);
            this.btnSaveSecret.Name = "btnSaveSecret";
            this.btnSaveSecret.Size = new System.Drawing.Size(63, 23);
            this.btnSaveSecret.TabIndex = 17;
            this.btnSaveSecret.Text = "Lưu";
            this.btnSaveSecret.UseVisualStyleBackColor = true;
            this.btnSaveSecret.Click += new System.EventHandler(this.btnSaveSecret_Click);
            // 
            // lbUpdateReady
            // 
            this.lbUpdateReady.AutoSize = true;
            this.lbUpdateReady.Location = new System.Drawing.Point(332, 291);
            this.lbUpdateReady.Name = "lbUpdateReady";
            this.lbUpdateReady.Size = new System.Drawing.Size(0, 13);
            this.lbUpdateReady.TabIndex = 16;
            this.lbUpdateReady.TextChanged += new System.EventHandler(this.lbUpdateReady_TextChanged);
            // 
            // txtSecretKey
            // 
            this.txtSecretKey.Location = new System.Drawing.Point(113, 147);
            this.txtSecretKey.Name = "txtSecretKey";
            this.txtSecretKey.Size = new System.Drawing.Size(289, 20);
            this.txtSecretKey.TabIndex = 15;
            this.txtSecretKey.UseSystemPasswordChar = true;
            // 
            // txtMachineId
            // 
            this.txtMachineId.Location = new System.Drawing.Point(113, 117);
            this.txtMachineId.Name = "txtMachineId";
            this.txtMachineId.Size = new System.Drawing.Size(289, 20);
            this.txtMachineId.TabIndex = 14;
            // 
            // txtApiUrl
            // 
            this.txtApiUrl.Location = new System.Drawing.Point(113, 87);
            this.txtApiUrl.Name = "txtApiUrl";
            this.txtApiUrl.Size = new System.Drawing.Size(289, 20);
            this.txtApiUrl.TabIndex = 13;
            // 
            // txtAccessKey
            // 
            this.txtAccessKey.Location = new System.Drawing.Point(113, 61);
            this.txtAccessKey.Name = "txtAccessKey";
            this.txtAccessKey.Size = new System.Drawing.Size(289, 20);
            this.txtAccessKey.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "SECRET_KEY:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "MACHINE_ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "API_URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "ACCESS_KEY:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(253, 214);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Khởi động lại";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnOff
            // 
            this.btnOff.Location = new System.Drawing.Point(185, 214);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(62, 23);
            this.btnOff.TabIndex = 6;
            this.btnOff.Text = "Dừng";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnOn
            // 
            this.btnOn.Location = new System.Drawing.Point(113, 214);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(66, 23);
            this.btnOn.TabIndex = 5;
            this.btnOn.Text = "Bật";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // lbIsStatus
            // 
            this.lbIsStatus.AutoSize = true;
            this.lbIsStatus.Location = new System.Drawing.Point(110, 29);
            this.lbIsStatus.Name = "lbIsStatus";
            this.lbIsStatus.Size = new System.Drawing.Size(60, 13);
            this.lbIsStatus.TabIndex = 4;
            this.lbIsStatus.Text = "Đang dừng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Trạng thái:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 367);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bizfly backup";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateFirmWare;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Label lbIsStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSecretKey;
        private System.Windows.Forms.TextBox txtMachineId;
        private System.Windows.Forms.TextBox txtApiUrl;
        private System.Windows.Forms.TextBox txtAccessKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbUpdateReady;
        private System.Windows.Forms.Button btnSaveSecret;
        private System.Windows.Forms.CheckBox cbStartOnWindows;
        private System.Windows.Forms.CheckBox cbShowSecretKey;
        private System.Windows.Forms.TextBox txtPathFileYaml;
        private System.Windows.Forms.Label lbPathFile;
        private System.Windows.Forms.Button btnSelectFileYaml;
    }
}

