namespace RW.PMS.WinForm.UI.Device
{
    partial class FrmDeviceExec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeviceExec));
            this.txtReadCard = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDevCardno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExec = new System.Windows.Forms.Button();
            this.txtExecTime = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtPlanTime = new System.Windows.Forms.TextBox();
            this.txtplanMemo = new System.Windows.Forms.TextBox();
            this.txtDevIP = new System.Windows.Forms.TextBox();
            this.txtDevNo = new System.Windows.Forms.TextBox();
            this.txtDevName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtReadCard
            // 
            this.txtReadCard.Enabled = false;
            this.txtReadCard.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReadCard.Location = new System.Drawing.Point(470, 400);
            this.txtReadCard.Name = "txtReadCard";
            this.txtReadCard.ReadOnly = true;
            this.txtReadCard.Size = new System.Drawing.Size(142, 29);
            this.txtReadCard.TabIndex = 45;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(374, 404);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 21);
            this.label12.TabIndex = 44;
            this.label12.Text = "读到的卡号";
            // 
            // txtDevCardno
            // 
            this.txtDevCardno.Enabled = false;
            this.txtDevCardno.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDevCardno.Location = new System.Drawing.Point(224, 401);
            this.txtDevCardno.Name = "txtDevCardno";
            this.txtDevCardno.ReadOnly = true;
            this.txtDevCardno.Size = new System.Drawing.Size(144, 29);
            this.txtDevCardno.TabIndex = 43;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(125, 403);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 42;
            this.label9.Text = "执行卡号";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(421, 451);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(113, 36);
            this.btnExit.TabIndex = 41;
            this.btnExit.Text = "关 闭";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExec
            // 
            this.btnExec.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExec.Location = new System.Drawing.Point(224, 451);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(113, 36);
            this.btnExec.TabIndex = 40;
            this.btnExec.Text = "执 行";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // txtExecTime
            // 
            this.txtExecTime.Enabled = false;
            this.txtExecTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtExecTime.Location = new System.Drawing.Point(224, 355);
            this.txtExecTime.Name = "txtExecTime";
            this.txtExecTime.ReadOnly = true;
            this.txtExecTime.Size = new System.Drawing.Size(388, 29);
            this.txtExecTime.TabIndex = 39;
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStatus.Location = new System.Drawing.Point(224, 309);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(388, 29);
            this.txtStatus.TabIndex = 38;
            // 
            // txtPlanTime
            // 
            this.txtPlanTime.Enabled = false;
            this.txtPlanTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPlanTime.Location = new System.Drawing.Point(224, 266);
            this.txtPlanTime.Name = "txtPlanTime";
            this.txtPlanTime.ReadOnly = true;
            this.txtPlanTime.Size = new System.Drawing.Size(388, 29);
            this.txtPlanTime.TabIndex = 37;
            // 
            // txtplanMemo
            // 
            this.txtplanMemo.Enabled = false;
            this.txtplanMemo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtplanMemo.Location = new System.Drawing.Point(224, 224);
            this.txtplanMemo.Name = "txtplanMemo";
            this.txtplanMemo.ReadOnly = true;
            this.txtplanMemo.Size = new System.Drawing.Size(388, 29);
            this.txtplanMemo.TabIndex = 36;
            // 
            // txtDevIP
            // 
            this.txtDevIP.Enabled = false;
            this.txtDevIP.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDevIP.Location = new System.Drawing.Point(224, 178);
            this.txtDevIP.Name = "txtDevIP";
            this.txtDevIP.ReadOnly = true;
            this.txtDevIP.Size = new System.Drawing.Size(388, 29);
            this.txtDevIP.TabIndex = 35;
            // 
            // txtDevNo
            // 
            this.txtDevNo.Enabled = false;
            this.txtDevNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDevNo.Location = new System.Drawing.Point(224, 136);
            this.txtDevNo.Name = "txtDevNo";
            this.txtDevNo.ReadOnly = true;
            this.txtDevNo.Size = new System.Drawing.Size(388, 29);
            this.txtDevNo.TabIndex = 34;
            // 
            // txtDevName
            // 
            this.txtDevName.Enabled = false;
            this.txtDevName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDevName.Location = new System.Drawing.Point(224, 91);
            this.txtDevName.Name = "txtDevName";
            this.txtDevName.ReadOnly = true;
            this.txtDevName.Size = new System.Drawing.Size(388, 29);
            this.txtDevName.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(204, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(363, 28);
            this.label8.TabIndex = 32;
            this.label8.Text = "工 位 机 设 备 本 月 保 养 计 划 执 行 ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(93, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 21);
            this.label7.TabIndex = 31;
            this.label7.Text = "保养执行时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(93, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.label6.TabIndex = 30;
            this.label6.Text = "保养执行状态";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(93, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 29;
            this.label5.Text = "计划保养时间";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(125, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 21);
            this.label4.TabIndex = 28;
            this.label4.Text = "保养内容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(142, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 27;
            this.label3.Text = "设备IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(125, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 26;
            this.label2.Text = "设备编码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(125, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "设备名称";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmDeviceExec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 520);
            this.Controls.Add(this.txtReadCard);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDevCardno);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExec);
            this.Controls.Add(this.txtExecTime);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtPlanTime);
            this.Controls.Add(this.txtplanMemo);
            this.Controls.Add(this.txtDevIP);
            this.Controls.Add(this.txtDevNo);
            this.Controls.Add(this.txtDevName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDeviceExec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备保养执行";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DeviceExec_FormClosing);
            this.Load += new System.EventHandler(this.Frm_DeviceExec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReadCard;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDevCardno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.TextBox txtExecTime;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtPlanTime;
        private System.Windows.Forms.TextBox txtplanMemo;
        private System.Windows.Forms.TextBox txtDevIP;
        private System.Windows.Forms.TextBox txtDevNo;
        private System.Windows.Forms.TextBox txtDevName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}