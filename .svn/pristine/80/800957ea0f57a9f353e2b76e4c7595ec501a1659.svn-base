namespace RW.PMS.WinForm.Sockets
{
    partial class FrmSocketTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSocketTest));
            this.txtLog = new System.Windows.Forms.TextBox();
            this.axTcpClient = new SocketHelper.AxTcpClient(this.components);
            this.cmbPsetNo = new System.Windows.Forms.ComboBox();
            this.btnPSet = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.btnCannect = new System.Windows.Forms.Button();
            this.tmrTorque = new System.Windows.Forms.Timer(this.components);
            this.btnEnable = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.btnCannectSocket = new System.Windows.Forms.Button();
            this.btnStopSocket = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Info;
            this.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtLog.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Location = new System.Drawing.Point(12, 75);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(744, 316);
            this.txtLog.TabIndex = 3;
            // 
            // axTcpClient
            // 
            this.axTcpClient.Isclosed = false;
            this.axTcpClient.IsStartTcpthreading = false;
            this.axTcpClient.Receivestr = null;
            this.axTcpClient.ReConectedCount = 0;
            this.axTcpClient.ReConnectionTime = 3000;
            this.axTcpClient.ServerIp = null;
            this.axTcpClient.ServerPort = 0;
            this.axTcpClient.Tcpclient = null;
            this.axTcpClient.Tcpthread = null;
            this.axTcpClient.OnReceviceByte += new SocketHelper.AxTcpClient.ReceviceByteEventHandler(this.axTcpClient_OnReceviceByte);
            this.axTcpClient.OnErrorMsg += new SocketHelper.AxTcpClient.ErrorMsgEventHandler(this.axTcpClient_OnErrorMsg);
            this.axTcpClient.OnStateInfo += new SocketHelper.AxTcpClient.StateInfoEventHandler(this.axTcpClient_OnStateInfo);
            // 
            // cmbPsetNo
            // 
            this.cmbPsetNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPsetNo.FormattingEnabled = true;
            this.cmbPsetNo.Items.AddRange(new object[] {
            "001",
            "002",
            "003",
            "004",
            "005",
            "006",
            "007",
            "008"});
            this.cmbPsetNo.Location = new System.Drawing.Point(336, 441);
            this.cmbPsetNo.Name = "cmbPsetNo";
            this.cmbPsetNo.Size = new System.Drawing.Size(121, 20);
            this.cmbPsetNo.TabIndex = 4;
            // 
            // btnPSet
            // 
            this.btnPSet.Enabled = false;
            this.btnPSet.Location = new System.Drawing.Point(463, 439);
            this.btnPSet.Name = "btnPSet";
            this.btnPSet.Size = new System.Drawing.Size(75, 23);
            this.btnPSet.TabIndex = 5;
            this.btnPSet.Text = "切换";
            this.btnPSet.UseVisualStyleBackColor = true;
            this.btnPSet.Click += new System.EventHandler(this.btnPSet_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(255, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消订阅";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Enabled = false;
            this.btnSubscribe.Location = new System.Drawing.Point(174, 439);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(75, 23);
            this.btnSubscribe.TabIndex = 7;
            this.btnSubscribe.Text = "订阅";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // btnCannect
            // 
            this.btnCannect.Enabled = false;
            this.btnCannect.Location = new System.Drawing.Point(12, 439);
            this.btnCannect.Name = "btnCannect";
            this.btnCannect.Size = new System.Drawing.Size(75, 23);
            this.btnCannect.TabIndex = 8;
            this.btnCannect.Text = "连接控制器";
            this.btnCannect.UseVisualStyleBackColor = true;
            this.btnCannect.Click += new System.EventHandler(this.btnCannect_Click);
            // 
            // tmrTorque
            // 
            this.tmrTorque.Interval = 5000;
            this.tmrTorque.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // btnEnable
            // 
            this.btnEnable.Enabled = false;
            this.btnEnable.Location = new System.Drawing.Point(544, 439);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(75, 23);
            this.btnEnable.TabIndex = 9;
            this.btnEnable.Text = "使能";
            this.btnEnable.UseVisualStyleBackColor = true;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(12, 405);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 10;
            this.txtIP.Text = "192.168.0.1";
            // 
            // btnCannectSocket
            // 
            this.btnCannectSocket.Location = new System.Drawing.Point(229, 404);
            this.btnCannectSocket.Name = "btnCannectSocket";
            this.btnCannectSocket.Size = new System.Drawing.Size(75, 23);
            this.btnCannectSocket.TabIndex = 11;
            this.btnCannectSocket.Text = "连接Socket";
            this.btnCannectSocket.UseVisualStyleBackColor = true;
            this.btnCannectSocket.Click += new System.EventHandler(this.btnCannectSocket_Click);
            // 
            // btnStopSocket
            // 
            this.btnStopSocket.Enabled = false;
            this.btnStopSocket.Location = new System.Drawing.Point(310, 404);
            this.btnStopSocket.Name = "btnStopSocket";
            this.btnStopSocket.Size = new System.Drawing.Size(75, 23);
            this.btnStopSocket.TabIndex = 12;
            this.btnStopSocket.Text = "断开Socket";
            this.btnStopSocket.UseVisualStyleBackColor = true;
            this.btnStopSocket.Click += new System.EventHandler(this.btnStopSocket_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(93, 439);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "断开控制器";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(118, 405);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 21);
            this.txtPort.TabIndex = 14;
            this.txtPort.Text = "4545";
            // 
            // FrmSocketTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 479);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStopSocket);
            this.Controls.Add(this.btnCannectSocket);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnEnable);
            this.Controls.Add(this.btnCannect);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPSet);
            this.Controls.Add(this.cmbPsetNo);
            this.Controls.Add(this.txtLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmSocketTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingersoll Rand - Test";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSocketTest_FormClosing);
            this.Load += new System.EventHandler(this.socketTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private SocketHelper.AxTcpClient axTcpClient;
        private System.Windows.Forms.ComboBox cmbPsetNo;
        private System.Windows.Forms.Button btnPSet;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.Button btnCannect;
        private System.Windows.Forms.Timer tmrTorque;
        private System.Windows.Forms.Button btnEnable;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Button btnCannectSocket;
        private System.Windows.Forms.Button btnStopSocket;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtPort;
    }
}