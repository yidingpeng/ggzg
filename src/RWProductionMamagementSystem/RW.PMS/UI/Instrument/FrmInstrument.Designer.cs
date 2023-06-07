namespace RW.PMS.WinForm.UI.Instrument
{
    partial class FrmInstrument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInstrument));
            this.serialPortTH2516B = new System.IO.Ports.SerialPort(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdoDC = new System.Windows.Forms.RadioButton();
            this.rdoAC = new System.Windows.Forms.RadioButton();
            this.lblJYNYTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnJYNYStopTest = new System.Windows.Forms.Button();
            this.btnJYNYStartTest = new System.Windows.Forms.Button();
            this.txtJYNYResult1 = new System.Windows.Forms.TextBox();
            this.txtJYNYResult = new System.Windows.Forms.TextBox();
            this.txtJYNYContent = new System.Windows.Forms.TextBox();
            this.textBox39 = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoHot = new System.Windows.Forms.RadioButton();
            this.rdoCold = new System.Windows.Forms.RadioButton();
            this.lblJYDZTime = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnJYDZStopTest = new System.Windows.Forms.Button();
            this.btnJYDZStartTest = new System.Windows.Forms.Button();
            this.txtHotResult1 = new System.Windows.Forms.TextBox();
            this.txtHotResult = new System.Windows.Forms.TextBox();
            this.txtJYDZRtContent = new System.Windows.Forms.TextBox();
            this.txtColdResult1 = new System.Windows.Forms.TextBox();
            this.txtColdResult = new System.Windows.Forms.TextBox();
            this.txtJYDZLtContent = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.undTemperature = new System.Windows.Forms.TextBox();
            this.undHumidity = new System.Windows.Forms.TextBox();
            this.txtWU1 = new System.Windows.Forms.TextBox();
            this.txtVW1 = new System.Windows.Forms.TextBox();
            this.txtUV1 = new System.Windows.Forms.TextBox();
            this.txtResultWU = new System.Windows.Forms.TextBox();
            this.txtResultVW = new System.Windows.Forms.TextBox();
            this.txtResultUV = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnReadUV = new System.Windows.Forms.Button();
            this.btnReadVW = new System.Windows.Forms.Button();
            this.txtWU = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.btnReadWU = new System.Windows.Forms.Button();
            this.txtVW = new System.Windows.Forms.TextBox();
            this.txtUV = new System.Windows.Forms.TextBox();
            this.txtWUTitle = new System.Windows.Forms.TextBox();
            this.txtVWTitle = new System.Windows.Forms.TextBox();
            this.txtUVTitle = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblVal = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.serialPortTH9110A = new System.IO.Ports.SerialPort(this.components);
            this.serialPortTH9310 = new System.IO.Ports.SerialPort(this.components);
            this.TemperatureOPCTagValueCharge1 = new RW.PMS.WinForm.Module.TemperatureOPCTagValueCharge();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureOPCTagValueCharge1)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPortTH2516B
            // 
            this.serialPortTH2516B.ReadTimeout = 5000;
            this.serialPortTH2516B.WriteTimeout = 5000;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 625);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(686, 586);
            this.panel3.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnOk);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 485);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(686, 101);
            this.panel6.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(243, 29);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(164, 60);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确 定(&S)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox4);
            this.panel5.Controls.Add(this.groupBox3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 224);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(686, 261);
            this.panel5.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.rdoDC);
            this.groupBox4.Controls.Add(this.rdoAC);
            this.groupBox4.Controls.Add(this.lblJYNYTime);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnJYNYStopTest);
            this.groupBox4.Controls.Add(this.btnJYNYStartTest);
            this.groupBox4.Controls.Add(this.txtJYNYResult1);
            this.groupBox4.Controls.Add(this.txtJYNYResult);
            this.groupBox4.Controls.Add(this.txtJYNYContent);
            this.groupBox4.Controls.Add(this.textBox39);
            this.groupBox4.Controls.Add(this.textBox40);
            this.groupBox4.Controls.Add(this.textBox41);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("宋体", 12.75F);
            this.groupBox4.Location = new System.Drawing.Point(0, 150);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(686, 111);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "绕组绝缘耐压测量";
            // 
            // rdoDC
            // 
            this.rdoDC.AutoSize = true;
            this.rdoDC.Location = new System.Drawing.Point(407, 23);
            this.rdoDC.Name = "rdoDC";
            this.rdoDC.Size = new System.Drawing.Size(44, 21);
            this.rdoDC.TabIndex = 3;
            this.rdoDC.Text = "DC";
            this.rdoDC.UseVisualStyleBackColor = true;
            // 
            // rdoAC
            // 
            this.rdoAC.AutoSize = true;
            this.rdoAC.Checked = true;
            this.rdoAC.Location = new System.Drawing.Point(321, 23);
            this.rdoAC.Name = "rdoAC";
            this.rdoAC.Size = new System.Drawing.Size(44, 21);
            this.rdoAC.TabIndex = 2;
            this.rdoAC.TabStop = true;
            this.rdoAC.Text = "AC";
            this.rdoAC.UseVisualStyleBackColor = true;
            // 
            // lblJYNYTime
            // 
            this.lblJYNYTime.AutoSize = true;
            this.lblJYNYTime.Location = new System.Drawing.Point(584, 25);
            this.lblJYNYTime.Name = "lblJYNYTime";
            this.lblJYNYTime.Size = new System.Drawing.Size(80, 17);
            this.lblJYNYTime.TabIndex = 5;
            this.lblJYNYTime.Text = "00:00:00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(485, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "剩余时间：";
            // 
            // btnJYNYStopTest
            // 
            this.btnJYNYStopTest.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnJYNYStopTest.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJYNYStopTest.Location = new System.Drawing.Point(176, 21);
            this.btnJYNYStopTest.Name = "btnJYNYStopTest";
            this.btnJYNYStopTest.Size = new System.Drawing.Size(102, 29);
            this.btnJYNYStopTest.TabIndex = 1;
            this.btnJYNYStopTest.Text = "停止试验";
            this.btnJYNYStopTest.UseVisualStyleBackColor = false;
            this.btnJYNYStopTest.Click += new System.EventHandler(this.btnJYNYStopTest_Click);
            // 
            // btnJYNYStartTest
            // 
            this.btnJYNYStartTest.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnJYNYStartTest.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJYNYStartTest.Location = new System.Drawing.Point(50, 21);
            this.btnJYNYStartTest.Name = "btnJYNYStartTest";
            this.btnJYNYStartTest.Size = new System.Drawing.Size(102, 29);
            this.btnJYNYStartTest.TabIndex = 0;
            this.btnJYNYStartTest.Text = "开始试验";
            this.btnJYNYStartTest.UseVisualStyleBackColor = false;
            this.btnJYNYStartTest.Click += new System.EventHandler(this.btnJYNYStartTest_Click);
            // 
            // txtJYNYResult1
            // 
            this.txtJYNYResult1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtJYNYResult1.Location = new System.Drawing.Point(535, 79);
            this.txtJYNYResult1.Name = "txtJYNYResult1";
            this.txtJYNYResult1.ReadOnly = true;
            this.txtJYNYResult1.Size = new System.Drawing.Size(136, 27);
            this.txtJYNYResult1.TabIndex = 11;
            this.txtJYNYResult1.Text = "合格/不合格";
            this.txtJYNYResult1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtJYNYResult
            // 
            this.txtJYNYResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtJYNYResult.Location = new System.Drawing.Point(417, 79);
            this.txtJYNYResult.Name = "txtJYNYResult";
            this.txtJYNYResult.ReadOnly = true;
            this.txtJYNYResult.Size = new System.Drawing.Size(119, 27);
            this.txtJYNYResult.TabIndex = 10;
            this.txtJYNYResult.Text = "0";
            this.txtJYNYResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtJYNYResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJYNYResult_KeyPress);
            // 
            // txtJYNYContent
            // 
            this.txtJYNYContent.BackColor = System.Drawing.SystemColors.Control;
            this.txtJYNYContent.Font = new System.Drawing.Font("宋体", 12F);
            this.txtJYNYContent.Location = new System.Drawing.Point(8, 80);
            this.txtJYNYContent.Name = "txtJYNYContent";
            this.txtJYNYContent.ReadOnly = true;
            this.txtJYNYContent.Size = new System.Drawing.Size(410, 26);
            this.txtJYNYContent.TabIndex = 9;
            this.txtJYNYContent.Text = "AC/DCxV电压 耐压x分钟，绝缘未破坏，漏电流xmA以下";
            this.txtJYNYContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox39
            // 
            this.textBox39.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox39.Location = new System.Drawing.Point(535, 55);
            this.textBox39.Name = "textBox39";
            this.textBox39.ReadOnly = true;
            this.textBox39.Size = new System.Drawing.Size(136, 27);
            this.textBox39.TabIndex = 8;
            this.textBox39.Text = "判定";
            this.textBox39.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox40
            // 
            this.textBox40.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox40.Location = new System.Drawing.Point(417, 55);
            this.textBox40.Name = "textBox40";
            this.textBox40.ReadOnly = true;
            this.textBox40.Size = new System.Drawing.Size(119, 27);
            this.textBox40.TabIndex = 7;
            this.textBox40.Text = "结果（mA）";
            this.textBox40.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox41
            // 
            this.textBox41.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox41.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox41.Location = new System.Drawing.Point(8, 55);
            this.textBox41.Name = "textBox41";
            this.textBox41.ReadOnly = true;
            this.textBox41.Size = new System.Drawing.Size(410, 26);
            this.textBox41.TabIndex = 6;
            this.textBox41.Text = "判断标准";
            this.textBox41.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.rdoHot);
            this.groupBox3.Controls.Add(this.rdoCold);
            this.groupBox3.Controls.Add(this.lblJYDZTime);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnJYDZStopTest);
            this.groupBox3.Controls.Add(this.btnJYDZStartTest);
            this.groupBox3.Controls.Add(this.txtHotResult1);
            this.groupBox3.Controls.Add(this.txtHotResult);
            this.groupBox3.Controls.Add(this.txtJYDZRtContent);
            this.groupBox3.Controls.Add(this.txtColdResult1);
            this.groupBox3.Controls.Add(this.txtColdResult);
            this.groupBox3.Controls.Add(this.txtJYDZLtContent);
            this.groupBox3.Controls.Add(this.textBox30);
            this.groupBox3.Controls.Add(this.textBox31);
            this.groupBox3.Controls.Add(this.textBox32);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("宋体", 12.75F);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(686, 150);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "绕组绝缘电阻测量";
            // 
            // rdoHot
            // 
            this.rdoHot.AutoSize = true;
            this.rdoHot.Location = new System.Drawing.Point(398, 27);
            this.rdoHot.Name = "rdoHot";
            this.rdoHot.Size = new System.Drawing.Size(60, 21);
            this.rdoHot.TabIndex = 3;
            this.rdoHot.Text = "热态";
            this.rdoHot.UseVisualStyleBackColor = true;
            // 
            // rdoCold
            // 
            this.rdoCold.AutoSize = true;
            this.rdoCold.Checked = true;
            this.rdoCold.Location = new System.Drawing.Point(312, 27);
            this.rdoCold.Name = "rdoCold";
            this.rdoCold.Size = new System.Drawing.Size(60, 21);
            this.rdoCold.TabIndex = 2;
            this.rdoCold.TabStop = true;
            this.rdoCold.Text = "冷态";
            this.rdoCold.UseVisualStyleBackColor = true;
            // 
            // lblJYDZTime
            // 
            this.lblJYDZTime.AutoSize = true;
            this.lblJYDZTime.Location = new System.Drawing.Point(585, 27);
            this.lblJYDZTime.Name = "lblJYDZTime";
            this.lblJYDZTime.Size = new System.Drawing.Size(80, 17);
            this.lblJYDZTime.TabIndex = 5;
            this.lblJYDZTime.Text = "00:00:00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "剩余时间：";
            // 
            // btnJYDZStopTest
            // 
            this.btnJYDZStopTest.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnJYDZStopTest.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJYDZStopTest.Location = new System.Drawing.Point(177, 24);
            this.btnJYDZStopTest.Name = "btnJYDZStopTest";
            this.btnJYDZStopTest.Size = new System.Drawing.Size(102, 29);
            this.btnJYDZStopTest.TabIndex = 1;
            this.btnJYDZStopTest.Text = "停止试验";
            this.btnJYDZStopTest.UseVisualStyleBackColor = false;
            this.btnJYDZStopTest.Click += new System.EventHandler(this.btnJYDZStopTest_Click);
            // 
            // btnJYDZStartTest
            // 
            this.btnJYDZStartTest.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnJYDZStartTest.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnJYDZStartTest.Location = new System.Drawing.Point(51, 24);
            this.btnJYDZStartTest.Name = "btnJYDZStartTest";
            this.btnJYDZStartTest.Size = new System.Drawing.Size(102, 29);
            this.btnJYDZStartTest.TabIndex = 0;
            this.btnJYDZStartTest.Text = "开始试验";
            this.btnJYDZStartTest.UseVisualStyleBackColor = false;
            this.btnJYDZStartTest.Click += new System.EventHandler(this.btnJYDZStartTest_Click);
            // 
            // txtHotResult1
            // 
            this.txtHotResult1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtHotResult1.Location = new System.Drawing.Point(473, 109);
            this.txtHotResult1.Name = "txtHotResult1";
            this.txtHotResult1.ReadOnly = true;
            this.txtHotResult1.Size = new System.Drawing.Size(199, 27);
            this.txtHotResult1.TabIndex = 14;
            this.txtHotResult1.Text = "合格/不合格";
            this.txtHotResult1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHotResult
            // 
            this.txtHotResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtHotResult.Location = new System.Drawing.Point(303, 109);
            this.txtHotResult.Name = "txtHotResult";
            this.txtHotResult.ReadOnly = true;
            this.txtHotResult.Size = new System.Drawing.Size(171, 27);
            this.txtHotResult.TabIndex = 13;
            this.txtHotResult.Text = "0";
            this.txtHotResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHotResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHotResult_KeyPress);
            // 
            // txtJYDZRtContent
            // 
            this.txtJYDZRtContent.BackColor = System.Drawing.SystemColors.Control;
            this.txtJYDZRtContent.Location = new System.Drawing.Point(8, 109);
            this.txtJYDZRtContent.Name = "txtJYDZRtContent";
            this.txtJYDZRtContent.ReadOnly = true;
            this.txtJYDZRtContent.Size = new System.Drawing.Size(296, 27);
            this.txtJYDZRtContent.TabIndex = 12;
            this.txtJYDZRtContent.Text = "DCxV电压 x分钟,热态时>xMΩ";
            this.txtJYDZRtContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtColdResult1
            // 
            this.txtColdResult1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtColdResult1.Location = new System.Drawing.Point(473, 83);
            this.txtColdResult1.Name = "txtColdResult1";
            this.txtColdResult1.ReadOnly = true;
            this.txtColdResult1.Size = new System.Drawing.Size(199, 27);
            this.txtColdResult1.TabIndex = 11;
            this.txtColdResult1.Text = "合格/不合格";
            this.txtColdResult1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtColdResult
            // 
            this.txtColdResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtColdResult.Location = new System.Drawing.Point(303, 83);
            this.txtColdResult.Name = "txtColdResult";
            this.txtColdResult.ReadOnly = true;
            this.txtColdResult.Size = new System.Drawing.Size(171, 27);
            this.txtColdResult.TabIndex = 10;
            this.txtColdResult.Text = "0";
            this.txtColdResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtColdResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtColdResult_KeyPress);
            // 
            // txtJYDZLtContent
            // 
            this.txtJYDZLtContent.BackColor = System.Drawing.SystemColors.Control;
            this.txtJYDZLtContent.Location = new System.Drawing.Point(8, 83);
            this.txtJYDZLtContent.Name = "txtJYDZLtContent";
            this.txtJYDZLtContent.ReadOnly = true;
            this.txtJYDZLtContent.Size = new System.Drawing.Size(296, 27);
            this.txtJYDZLtContent.TabIndex = 9;
            this.txtJYDZLtContent.Text = "DCxV电压 x分钟,冷态时>xMΩ";
            this.txtJYDZLtContent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox30
            // 
            this.textBox30.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox30.Location = new System.Drawing.Point(473, 57);
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(199, 27);
            this.textBox30.TabIndex = 8;
            this.textBox30.Text = "判定";
            this.textBox30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox31
            // 
            this.textBox31.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox31.Location = new System.Drawing.Point(303, 57);
            this.textBox31.Name = "textBox31";
            this.textBox31.ReadOnly = true;
            this.textBox31.Size = new System.Drawing.Size(171, 27);
            this.textBox31.TabIndex = 7;
            this.textBox31.Text = "结果(MΩ)";
            this.textBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox32
            // 
            this.textBox32.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox32.Location = new System.Drawing.Point(8, 57);
            this.textBox32.Name = "textBox32";
            this.textBox32.ReadOnly = true;
            this.textBox32.Size = new System.Drawing.Size(296, 27);
            this.textBox32.TabIndex = 6;
            this.textBox32.Text = "判断标准(MΩ)";
            this.textBox32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(686, 224);
            this.panel4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.undTemperature);
            this.groupBox1.Controls.Add(this.undHumidity);
            this.groupBox1.Controls.Add(this.txtWU1);
            this.groupBox1.Controls.Add(this.txtVW1);
            this.groupBox1.Controls.Add(this.txtUV1);
            this.groupBox1.Controls.Add(this.txtResultWU);
            this.groupBox1.Controls.Add(this.txtResultVW);
            this.groupBox1.Controls.Add(this.txtResultUV);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.btnReadUV);
            this.groupBox1.Controls.Add(this.btnReadVW);
            this.groupBox1.Controls.Add(this.txtWU);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox21);
            this.groupBox1.Controls.Add(this.btnReadWU);
            this.groupBox1.Controls.Add(this.txtVW);
            this.groupBox1.Controls.Add(this.txtUV);
            this.groupBox1.Controls.Add(this.txtWUTitle);
            this.groupBox1.Controls.Add(this.txtVWTitle);
            this.groupBox1.Controls.Add(this.txtUVTitle);
            this.groupBox1.Controls.Add(this.textBox12);
            this.groupBox1.Controls.Add(this.textBox11);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "三相绕组测量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(549, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 32;
            this.label2.Text = "环境湿度(%)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(547, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 32;
            this.label1.Text = "环境温度(℃)";
            // 
            // undTemperature
            // 
            this.undTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.undTemperature.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.undTemperature.Location = new System.Drawing.Point(553, 75);
            this.undTemperature.Name = "undTemperature";
            this.undTemperature.Size = new System.Drawing.Size(100, 22);
            this.undTemperature.TabIndex = 31;
            this.undTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // undHumidity
            // 
            this.undHumidity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.undHumidity.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.undHumidity.Location = new System.Drawing.Point(553, 129);
            this.undHumidity.Name = "undHumidity";
            this.undHumidity.Size = new System.Drawing.Size(100, 22);
            this.undHumidity.TabIndex = 31;
            this.undHumidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtWU1
            // 
            this.txtWU1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtWU1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtWU1.Location = new System.Drawing.Point(251, 129);
            this.txtWU1.Name = "txtWU1";
            this.txtWU1.Size = new System.Drawing.Size(141, 26);
            this.txtWU1.TabIndex = 30;
            this.txtWU1.Text = "0";
            this.txtWU1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVW1
            // 
            this.txtVW1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtVW1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtVW1.Location = new System.Drawing.Point(251, 104);
            this.txtVW1.Name = "txtVW1";
            this.txtVW1.Size = new System.Drawing.Size(141, 26);
            this.txtVW1.TabIndex = 29;
            this.txtVW1.Text = "0";
            this.txtVW1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUV1
            // 
            this.txtUV1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtUV1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtUV1.Location = new System.Drawing.Point(251, 79);
            this.txtUV1.Name = "txtUV1";
            this.txtUV1.Size = new System.Drawing.Size(141, 26);
            this.txtUV1.TabIndex = 28;
            this.txtUV1.Text = "0";
            this.txtUV1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtResultWU
            // 
            this.txtResultWU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtResultWU.Location = new System.Drawing.Point(391, 129);
            this.txtResultWU.Name = "txtResultWU";
            this.txtResultWU.ReadOnly = true;
            this.txtResultWU.Size = new System.Drawing.Size(145, 26);
            this.txtResultWU.TabIndex = 0;
            this.txtResultWU.Text = "合格/不合格";
            this.txtResultWU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtResultVW
            // 
            this.txtResultVW.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtResultVW.Location = new System.Drawing.Point(391, 104);
            this.txtResultVW.Name = "txtResultVW";
            this.txtResultVW.ReadOnly = true;
            this.txtResultVW.Size = new System.Drawing.Size(145, 26);
            this.txtResultVW.TabIndex = 14;
            this.txtResultVW.Text = "合格/不合格";
            this.txtResultVW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtResultUV
            // 
            this.txtResultUV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtResultUV.Location = new System.Drawing.Point(391, 79);
            this.txtResultUV.Name = "txtResultUV";
            this.txtResultUV.ReadOnly = true;
            this.txtResultUV.Size = new System.Drawing.Size(145, 26);
            this.txtResultUV.TabIndex = 11;
            this.txtResultUV.Text = "合格/不合格";
            this.txtResultUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox1.Location = new System.Drawing.Point(391, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(145, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "判定";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.button4.Font = new System.Drawing.Font("宋体", 12F);
            this.button4.Location = new System.Drawing.Point(8, 161);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 41);
            this.button4.TabIndex = 1;
            this.button4.Text = "清空数据";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnReadUV
            // 
            this.btnReadUV.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnReadUV.Location = new System.Drawing.Point(146, 161);
            this.btnReadUV.Name = "btnReadUV";
            this.btnReadUV.Size = new System.Drawing.Size(115, 41);
            this.btnReadUV.TabIndex = 2;
            this.btnReadUV.Text = "读取U-V数据";
            this.btnReadUV.UseVisualStyleBackColor = false;
            this.btnReadUV.Click += new System.EventHandler(this.btnReadUV_Click);
            // 
            // btnReadVW
            // 
            this.btnReadVW.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnReadVW.Location = new System.Drawing.Point(277, 161);
            this.btnReadVW.Name = "btnReadVW";
            this.btnReadVW.Size = new System.Drawing.Size(115, 41);
            this.btnReadVW.TabIndex = 3;
            this.btnReadVW.Text = "读取V-W数据";
            this.btnReadVW.UseVisualStyleBackColor = false;
            this.btnReadVW.Click += new System.EventHandler(this.btnReadVW_Click);
            // 
            // txtWU
            // 
            this.txtWU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtWU.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtWU.Location = new System.Drawing.Point(137, 129);
            this.txtWU.Name = "txtWU";
            this.txtWU.ReadOnly = true;
            this.txtWU.Size = new System.Drawing.Size(115, 26);
            this.txtWU.TabIndex = 16;
            this.txtWU.Text = "0";
            this.txtWU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWU.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWU_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox2.Location = new System.Drawing.Point(251, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(141, 26);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "20℃时的换算值";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox21.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox21.Location = new System.Drawing.Point(137, 54);
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(115, 26);
            this.textBox21.TabIndex = 7;
            this.textBox21.Text = "测量值";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnReadWU
            // 
            this.btnReadWU.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnReadWU.Location = new System.Drawing.Point(407, 161);
            this.btnReadWU.Name = "btnReadWU";
            this.btnReadWU.Size = new System.Drawing.Size(116, 41);
            this.btnReadWU.TabIndex = 4;
            this.btnReadWU.Text = "读取U-W数据";
            this.btnReadWU.UseVisualStyleBackColor = false;
            this.btnReadWU.Click += new System.EventHandler(this.btnReadWU_Click);
            // 
            // txtVW
            // 
            this.txtVW.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtVW.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtVW.Location = new System.Drawing.Point(137, 104);
            this.txtVW.Name = "txtVW";
            this.txtVW.ReadOnly = true;
            this.txtVW.Size = new System.Drawing.Size(115, 26);
            this.txtVW.TabIndex = 13;
            this.txtVW.Text = "0";
            this.txtVW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVW.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVW_KeyPress);
            // 
            // txtUV
            // 
            this.txtUV.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtUV.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtUV.Location = new System.Drawing.Point(137, 79);
            this.txtUV.Name = "txtUV";
            this.txtUV.ReadOnly = true;
            this.txtUV.Size = new System.Drawing.Size(115, 26);
            this.txtUV.TabIndex = 10;
            this.txtUV.Text = "0";
            this.txtUV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUV_KeyPress);
            // 
            // txtWUTitle
            // 
            this.txtWUTitle.BackColor = System.Drawing.SystemColors.Control;
            this.txtWUTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtWUTitle.Location = new System.Drawing.Point(8, 129);
            this.txtWUTitle.Name = "txtWUTitle";
            this.txtWUTitle.ReadOnly = true;
            this.txtWUTitle.Size = new System.Drawing.Size(130, 26);
            this.txtWUTitle.TabIndex = 15;
            this.txtWUTitle.Text = "U-W(MΩ)";
            this.txtWUTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtVWTitle
            // 
            this.txtVWTitle.BackColor = System.Drawing.SystemColors.Control;
            this.txtVWTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtVWTitle.Location = new System.Drawing.Point(8, 104);
            this.txtVWTitle.Name = "txtVWTitle";
            this.txtVWTitle.ReadOnly = true;
            this.txtVWTitle.Size = new System.Drawing.Size(130, 26);
            this.txtVWTitle.TabIndex = 12;
            this.txtVWTitle.Text = "V-W(MΩ)";
            this.txtVWTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUVTitle
            // 
            this.txtUVTitle.BackColor = System.Drawing.SystemColors.Control;
            this.txtUVTitle.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtUVTitle.Location = new System.Drawing.Point(8, 79);
            this.txtUVTitle.Margin = new System.Windows.Forms.Padding(0);
            this.txtUVTitle.Name = "txtUVTitle";
            this.txtUVTitle.ReadOnly = true;
            this.txtUVTitle.Size = new System.Drawing.Size(130, 26);
            this.txtUVTitle.TabIndex = 9;
            this.txtUVTitle.Text = "U-V(MΩ)";
            this.txtUVTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox12.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox12.Location = new System.Drawing.Point(8, 54);
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(130, 26);
            this.textBox12.TabIndex = 6;
            this.textBox12.Text = "端子符号";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox11.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox11.Location = new System.Drawing.Point(8, 29);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(528, 26);
            this.textBox11.TabIndex = 2;
            this.textBox11.Text = "定子绕组电阻";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblVal);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 39);
            this.panel2.TabIndex = 0;
            // 
            // lblVal
            // 
            this.lblVal.AutoSize = true;
            this.lblVal.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVal.ForeColor = System.Drawing.Color.Red;
            this.lblVal.Location = new System.Drawing.Point(360, 10);
            this.lblVal.Name = "lblVal";
            this.lblVal.Size = new System.Drawing.Size(19, 19);
            this.lblVal.TabIndex = 1;
            this.lblVal.Text = "0";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(280, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(85, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "目标值：";
            // 
            // serialPortTH9110A
            // 
            this.serialPortTH9110A.PortName = "COM4";
            this.serialPortTH9110A.ReadTimeout = 5000;
            this.serialPortTH9110A.WriteTimeout = 5000;
            // 
            // serialPortTH9310
            // 
            this.serialPortTH9310.PortName = "COM5";
            this.serialPortTH9310.ReadTimeout = 5000;
            this.serialPortTH9310.WriteTimeout = 5000;
            // 
            // TemperatureOPCTagValueCharge1
            // 
            this.TemperatureOPCTagValueCharge1.NameValueChanged += new RW.PMS.WinForm.Module.NameValueHandler<object>(this.TemperatureOPCTagValueCharge1_NameValueChanged);
            // 
            // FrmInstrument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 625);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInstrument";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "试验信息";
            this.Load += new System.EventHandler(this.FrmInstrument_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TemperatureOPCTagValueCharge1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPortTH2516B;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblVal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWU;
        private System.Windows.Forms.TextBox txtVW;
        private System.Windows.Forms.TextBox txtUV;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox txtWUTitle;
        private System.Windows.Forms.TextBox txtVWTitle;
        private System.Windows.Forms.TextBox txtUVTitle;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button btnReadUV;
        private System.Windows.Forms.Button btnReadVW;
        private System.Windows.Forms.Button btnReadWU;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdoDC;
        private System.Windows.Forms.RadioButton rdoAC;
        private System.Windows.Forms.Label lblJYNYTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnJYNYStopTest;
        private System.Windows.Forms.Button btnJYNYStartTest;
        private System.Windows.Forms.TextBox txtJYNYResult1;
        private System.Windows.Forms.TextBox txtJYNYResult;
        private System.Windows.Forms.TextBox txtJYNYContent;
        private System.Windows.Forms.TextBox textBox39;
        private System.Windows.Forms.TextBox textBox40;
        private System.Windows.Forms.TextBox textBox41;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoHot;
        private System.Windows.Forms.RadioButton rdoCold;
        private System.Windows.Forms.Label lblJYDZTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnJYDZStopTest;
        private System.Windows.Forms.Button btnJYDZStartTest;
        private System.Windows.Forms.TextBox txtHotResult1;
        private System.Windows.Forms.TextBox txtHotResult;
        private System.Windows.Forms.TextBox txtJYDZRtContent;
        private System.Windows.Forms.TextBox txtColdResult1;
        private System.Windows.Forms.TextBox txtColdResult;
        private System.Windows.Forms.TextBox txtJYDZLtContent;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnOk;
        private System.IO.Ports.SerialPort serialPortTH9110A;
        private System.Windows.Forms.TextBox txtResultWU;
        private System.Windows.Forms.TextBox txtResultVW;
        private System.Windows.Forms.TextBox txtResultUV;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPortTH9310;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtWU1;
        private System.Windows.Forms.TextBox txtVW1;
        private System.Windows.Forms.TextBox txtUV1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox undTemperature;
        private System.Windows.Forms.TextBox undHumidity;
        private Module.TemperatureOPCTagValueCharge TemperatureOPCTagValueCharge1;
    }
}