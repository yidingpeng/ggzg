﻿
namespace RW.PMS.WinForm.UI
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.MenuBarToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolbtnChecking = new System.Windows.Forms.ToolStripButton();
            this.toolbtnStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRecord = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDevice = new System.Windows.Forms.ToolStripButton();
            this.toolbtnPoint = new System.Windows.Forms.ToolStripButton();
            this.toolbtnFormula = new System.Windows.Forms.ToolStripButton();
            this.toolbtnExit = new System.Windows.Forms.ToolStripButton();
            this.toolbtnLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolbtnShutdown = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cartesianChart2 = new LiveCharts.WinForms.CartesianChart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTorqueShow2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAngle2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTorqueShow = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTorque = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFormulaCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.cmbProdNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ucEllipseDialAisle1 = new HZH_Controls.Controls.UCEllipseDialAisle();
            this.label4 = new System.Windows.Forms.Label();
            this.axTcpClient1 = new SocketHelper.AxTcpClient(this.components);
            this.axTcpClient2 = new SocketHelper.AxTcpClient(this.components);
            this.tmrTorque = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panelTitle.SuspendLayout();
            this.MenuBarToolStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.Controls.Add(this.lblTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1920, 55);
            this.panelTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Window;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1920, 52);
            this.lblTitle.TabIndex = 26;
            this.lblTitle.Text = "RWAMS 桩 工 混 线 回 转 支 承 扭 矩 管 理 系 统";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuBarToolStrip
            // 
            this.MenuBarToolStrip.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuBarToolStrip.ImageScalingSize = new System.Drawing.Size(70, 60);
            this.MenuBarToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnChecking,
            this.toolbtnStart,
            this.toolStripButton1,
            this.toolbtnRecord,
            this.toolbtnDevice,
            this.toolbtnPoint,
            this.toolbtnFormula,
            this.toolbtnExit,
            this.toolbtnLog,
            this.toolStripButton2,
            this.toolbtnShutdown});
            this.MenuBarToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuBarToolStrip.Location = new System.Drawing.Point(0, 55);
            this.MenuBarToolStrip.Name = "MenuBarToolStrip";
            this.MenuBarToolStrip.Size = new System.Drawing.Size(1920, 68);
            this.MenuBarToolStrip.TabIndex = 74;
            this.MenuBarToolStrip.Text = "toolStrip1";
            // 
            // toolbtnChecking
            // 
            this.toolbtnChecking.AutoSize = false;
            this.toolbtnChecking.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbtnChecking.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnChecking.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnChecking.Image")));
            this.toolbtnChecking.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnChecking.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnChecking.Name = "toolbtnChecking";
            this.toolbtnChecking.Size = new System.Drawing.Size(65, 65);
            this.toolbtnChecking.Text = "产品型号";
            this.toolbtnChecking.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnChecking.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnChecking.Click += new System.EventHandler(this.toolbtnChecking_Click);
            // 
            // toolbtnStart
            // 
            this.toolbtnStart.AutoSize = false;
            this.toolbtnStart.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbtnStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnStart.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnStart.Image")));
            this.toolbtnStart.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnStart.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnStart.Name = "toolbtnStart";
            this.toolbtnStart.Size = new System.Drawing.Size(65, 65);
            this.toolbtnStart.Text = "下发配方";
            this.toolbtnStart.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnStart.Click += new System.EventHandler(this.toolbtnStart_Click_1);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 65);
            this.toolStripButton1.Text = "启动装配";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolbtnRecord
            // 
            this.toolbtnRecord.AutoSize = false;
            this.toolbtnRecord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbtnRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnRecord.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnRecord.Image")));
            this.toolbtnRecord.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRecord.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnRecord.Name = "toolbtnRecord";
            this.toolbtnRecord.Size = new System.Drawing.Size(65, 65);
            this.toolbtnRecord.Text = "拧紧记录";
            this.toolbtnRecord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnRecord.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnRecord.Click += new System.EventHandler(this.toolbtnRecord_Click);
            // 
            // toolbtnDevice
            // 
            this.toolbtnDevice.AutoSize = false;
            this.toolbtnDevice.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbtnDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnDevice.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnDevice.Image")));
            this.toolbtnDevice.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDevice.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnDevice.Name = "toolbtnDevice";
            this.toolbtnDevice.Size = new System.Drawing.Size(65, 65);
            this.toolbtnDevice.Text = "维保信息";
            this.toolbtnDevice.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnDevice.ToolTipText = "维保信息";
            this.toolbtnDevice.Click += new System.EventHandler(this.toolbtnDevice_Click);
            // 
            // toolbtnPoint
            // 
            this.toolbtnPoint.AutoSize = false;
            this.toolbtnPoint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.toolbtnPoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnPoint.Image = global::RW.PMS.WinForm.Properties.Resources.report;
            this.toolbtnPoint.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnPoint.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnPoint.Name = "toolbtnPoint";
            this.toolbtnPoint.Size = new System.Drawing.Size(65, 65);
            this.toolbtnPoint.Text = "点位信息";
            this.toolbtnPoint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnPoint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnPoint.Click += new System.EventHandler(this.toolbtnPoint_Click);
            // 
            // toolbtnFormula
            // 
            this.toolbtnFormula.AutoSize = false;
            this.toolbtnFormula.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.toolbtnFormula.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnFormula.Image = global::RW.PMS.WinForm.Properties.Resources.refresh2;
            this.toolbtnFormula.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnFormula.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnFormula.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnFormula.Name = "toolbtnFormula";
            this.toolbtnFormula.Size = new System.Drawing.Size(65, 65);
            this.toolbtnFormula.Text = "配方管理";
            this.toolbtnFormula.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnFormula.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnFormula.Click += new System.EventHandler(this.toolbtnFormula_Click);
            // 
            // toolbtnExit
            // 
            this.toolbtnExit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolbtnExit.AutoSize = false;
            this.toolbtnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolbtnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnExit.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnExit.Image")));
            this.toolbtnExit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnExit.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolbtnExit.Name = "toolbtnExit";
            this.toolbtnExit.Size = new System.Drawing.Size(65, 65);
            this.toolbtnExit.Text = "退出系统";
            this.toolbtnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnExit.Click += new System.EventHandler(this.toolbtnExit_Click);
            // 
            // toolbtnLog
            // 
            this.toolbtnLog.AutoSize = false;
            this.toolbtnLog.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.toolbtnLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnLog.Image = global::RW.PMS.WinForm.Properties.Resources.clipboard;
            this.toolbtnLog.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnLog.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnLog.Name = "toolbtnLog";
            this.toolbtnLog.Size = new System.Drawing.Size(65, 65);
            this.toolbtnLog.Text = "日志查看";
            this.toolbtnLog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnLog.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnLog.Click += new System.EventHandler(this.toolbtnLog_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolStripButton2.Image = global::RW.PMS.WinForm.Properties.Resources.custom_reports;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(65, 65);
            this.toolStripButton2.Text = "打印图表";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolbtnShutdown
            // 
            this.toolbtnShutdown.AutoSize = false;
            this.toolbtnShutdown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.toolbtnShutdown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnShutdown.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnShutdown.Image")));
            this.toolbtnShutdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnShutdown.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnShutdown.Name = "toolbtnShutdown";
            this.toolbtnShutdown.Size = new System.Drawing.Size(65, 65);
            this.toolbtnShutdown.Text = "关机";
            this.toolbtnShutdown.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnShutdown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnShutdown.Click += new System.EventHandler(this.toolbtnShutdown_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.45763F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.54237F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 879F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 126);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95.8159F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 934F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 937);
            this.tableLayoutPanel1.TabIndex = 75;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(489, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(526, 925);
            this.panel2.TabIndex = 83;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cartesianChart2);
            this.groupBox4.Location = new System.Drawing.Point(10, 585);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(523, 330);
            this.groupBox4.TabIndex = 85;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "拧紧曲线2";
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart2.Location = new System.Drawing.Point(3, 17);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(517, 310);
            this.cartesianChart2.TabIndex = 1;
            this.cartesianChart2.Text = "cartesianChart2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTorqueShow2);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lblAngle2);
            this.groupBox3.Location = new System.Drawing.Point(10, 138);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(523, 80);
            this.groupBox3.TabIndex = 86;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "拧紧轴2";
            // 
            // lblTorqueShow2
            // 
            this.lblTorqueShow2.AutoSize = true;
            this.lblTorqueShow2.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTorqueShow2.Location = new System.Drawing.Point(270, 17);
            this.lblTorqueShow2.Name = "lblTorqueShow2";
            this.lblTorqueShow2.Size = new System.Drawing.Size(85, 43);
            this.lblTorqueShow2.TabIndex = 82;
            this.lblTorqueShow2.Text = "扭力";
            this.lblTorqueShow2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F);
            this.label10.Location = new System.Drawing.Point(185, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 20);
            this.label10.TabIndex = 80;
            this.label10.Text = "°";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 15F);
            this.label12.Location = new System.Drawing.Point(368, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 81;
            this.label12.Text = "牛·米";
            // 
            // lblAngle2
            // 
            this.lblAngle2.AutoSize = true;
            this.lblAngle2.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAngle2.Location = new System.Drawing.Point(101, 17);
            this.lblAngle2.Name = "lblAngle2";
            this.lblAngle2.Size = new System.Drawing.Size(85, 43);
            this.lblAngle2.TabIndex = 83;
            this.lblAngle2.Text = "角度";
            this.lblAngle2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTorqueShow);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblAngle);
            this.groupBox2.Location = new System.Drawing.Point(10, 47);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 80);
            this.groupBox2.TabIndex = 85;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "拧紧轴1";
            // 
            // lblTorqueShow
            // 
            this.lblTorqueShow.AutoSize = true;
            this.lblTorqueShow.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTorqueShow.Location = new System.Drawing.Point(269, 19);
            this.lblTorqueShow.Name = "lblTorqueShow";
            this.lblTorqueShow.Size = new System.Drawing.Size(85, 43);
            this.lblTorqueShow.TabIndex = 82;
            this.lblTorqueShow.Text = "扭力";
            this.lblTorqueShow.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F);
            this.label6.Location = new System.Drawing.Point(184, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 20);
            this.label6.TabIndex = 80;
            this.label6.Text = "°";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F);
            this.label7.Location = new System.Drawing.Point(367, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 81;
            this.label7.Text = "牛·米";
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Font = new System.Drawing.Font("微软雅黑", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAngle.Location = new System.Drawing.Point(100, 19);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(85, 43);
            this.lblAngle.TabIndex = 83;
            this.lblAngle.Text = "角度";
            this.lblAngle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cartesianChart1);
            this.groupBox1.Location = new System.Drawing.Point(10, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 330);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "拧紧曲线1";
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartesianChart1.Location = new System.Drawing.Point(3, 17);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(517, 310);
            this.cartesianChart1.TabIndex = 1;
            this.cartesianChart1.Text = "cartesianChart1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(8, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 28);
            this.label8.TabIndex = 76;
            this.label8.Text = "拧紧信息：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblTorque);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblFormulaCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtLog);
            this.panel1.Controls.Add(this.cmbProdNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 925);
            this.panel1.TabIndex = 0;
            // 
            // lblTorque
            // 
            this.lblTorque.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTorque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblTorque.Location = new System.Drawing.Point(158, 95);
            this.lblTorque.Name = "lblTorque";
            this.lblTorque.Size = new System.Drawing.Size(196, 23);
            this.lblTorque.TabIndex = 82;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(43, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 81;
            this.label3.Text = "产品扭矩：";
            // 
            // lblFormulaCode
            // 
            this.lblFormulaCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFormulaCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblFormulaCode.Location = new System.Drawing.Point(158, 58);
            this.lblFormulaCode.Name = "lblFormulaCode";
            this.lblFormulaCode.Size = new System.Drawing.Size(196, 23);
            this.lblFormulaCode.TabIndex = 80;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(43, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 22);
            this.label2.TabIndex = 79;
            this.label2.Text = "配方编号：";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txtLog.Font = new System.Drawing.Font("宋体", 12F);
            this.txtLog.ForeColor = System.Drawing.Color.Black;
            this.txtLog.Location = new System.Drawing.Point(2, 132);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(490, 793);
            this.txtLog.TabIndex = 78;
            // 
            // cmbProdNo
            // 
            this.cmbProdNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProdNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdNo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbProdNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbProdNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbProdNo.FormattingEnabled = true;
            this.cmbProdNo.Location = new System.Drawing.Point(162, 16);
            this.cmbProdNo.Name = "cmbProdNo";
            this.cmbProdNo.Size = new System.Drawing.Size(241, 29);
            this.cmbProdNo.TabIndex = 77;
            this.cmbProdNo.SelectedIndexChanged += new System.EventHandler(this.cmbformula_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(43, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 76;
            this.label1.Text = "产品型号：";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.ucEllipseDialAisle1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(1024, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(874, 925);
            this.panel3.TabIndex = 84;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(576, 60);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(66, 56);
            this.pictureBox4.TabIndex = 87;
            this.pictureBox4.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(485, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 19);
            this.label14.TabIndex = 86;
            this.label14.Text = "拧紧异常：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(112, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 70);
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(410, 68);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(51, 55);
            this.pictureBox3.TabIndex = 85;
            this.pictureBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(312, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 19);
            this.label13.TabIndex = 84;
            this.label13.Text = "正在拧紧：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(251, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(47, 61);
            this.pictureBox2.TabIndex = 83;
            this.pictureBox2.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(177, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 19);
            this.label11.TabIndex = 82;
            this.label11.Text = "已拧紧：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(36, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 19);
            this.label9.TabIndex = 80;
            this.label9.Text = "未拧紧：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(400, 488);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 56);
            this.label5.TabIndex = 78;
            this.label5.Text = " ";
            // 
            // ucEllipseDialAisle1
            // 
            this.ucEllipseDialAisle1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucEllipseDialAisle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucEllipseDialAisle1.BorderColor = System.Drawing.Color.Empty;
            this.ucEllipseDialAisle1.CentreItem = ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.CentreItem")));
            this.ucEllipseDialAisle1.Enabled = false;
            this.ucEllipseDialAisle1.EnabledClick = false;
            this.ucEllipseDialAisle1.Items = new HZH_Controls.Controls.EllipseDialAisleItem[] {
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items1"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items2"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items3"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items4"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items5"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items6"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items7"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items8"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items9"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items10"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items11"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items12"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items13"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items14"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items15"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items16"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items17"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items18"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items19"))),
        ((HZH_Controls.Controls.EllipseDialAisleItem)(resources.GetObject("ucEllipseDialAisle1.Items20")))};
            this.ucEllipseDialAisle1.ItemSize = 18;
            this.ucEllipseDialAisle1.Location = new System.Drawing.Point(77, 164);
            this.ucEllipseDialAisle1.Margin = new System.Windows.Forms.Padding(4);
            this.ucEllipseDialAisle1.Name = "ucEllipseDialAisle1";
            this.ucEllipseDialAisle1.Size = new System.Drawing.Size(700, 700);
            this.ucEllipseDialAisle1.TabIndex = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(15, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 28);
            this.label4.TabIndex = 77;
            this.label4.Text = "拧紧位置虚拟画面：";
            // 
            // axTcpClient1
            // 
            this.axTcpClient1.Isclosed = false;
            this.axTcpClient1.IsStartTcpthreading = false;
            this.axTcpClient1.Receivestr = null;
            this.axTcpClient1.ReConectedCount = 0;
            this.axTcpClient1.ReConnectionTime = 3000;
            this.axTcpClient1.ServerIp = null;
            this.axTcpClient1.ServerPort = 0;
            this.axTcpClient1.Tcpclient = null;
            this.axTcpClient1.Tcpthread = null;
            this.axTcpClient1.OnReceviceByte += new SocketHelper.AxTcpClient.ReceviceByteEventHandler(this.axTcpClient1_OnReceviceByte);
            this.axTcpClient1.OnErrorMsg += new SocketHelper.AxTcpClient.ErrorMsgEventHandler(this.axTcpClient_OnErrorMsg);
            this.axTcpClient1.OnStateInfo += new SocketHelper.AxTcpClient.StateInfoEventHandler(this.axTcpClient1_OnStateInfo);
            // 
            // axTcpClient2
            // 
            this.axTcpClient2.Isclosed = false;
            this.axTcpClient2.IsStartTcpthreading = false;
            this.axTcpClient2.Receivestr = null;
            this.axTcpClient2.ReConectedCount = 0;
            this.axTcpClient2.ReConnectionTime = 3000;
            this.axTcpClient2.ServerIp = null;
            this.axTcpClient2.ServerPort = 0;
            this.axTcpClient2.Tcpclient = null;
            this.axTcpClient2.Tcpthread = null;
            // 
            // tmrTorque
            // 
            this.tmrTorque.Interval = 6000;
            this.tmrTorque.Tick += new System.EventHandler(this.tmrTorque_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.MenuBarToolStrip);
            this.Controls.Add(this.panelTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1438, 822);
            this.Name = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load_1);
            this.panelTitle.ResumeLayout(false);
            this.MenuBarToolStrip.ResumeLayout(false);
            this.MenuBarToolStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ToolStrip MenuBarToolStrip;
        private System.Windows.Forms.ToolStripButton toolbtnChecking;
        private System.Windows.Forms.ToolStripButton toolbtnRecord;
        private System.Windows.Forms.ToolStripButton toolbtnDevice;
        private System.Windows.Forms.ToolStripButton toolbtnExit;
        private System.Windows.Forms.ToolStripButton toolbtnShutdown;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton toolbtnPoint;
        private System.Windows.Forms.ToolStripButton toolbtnLog;
        private System.Windows.Forms.ToolStripButton toolbtnFormula;
        private System.Windows.Forms.ToolStripButton toolbtnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProdNo;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormulaCode;
        private System.Windows.Forms.Label lblTorque;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTorqueShow;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTorqueShow2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblAngle2;
        private System.Windows.Forms.GroupBox groupBox2;
        private SocketHelper.AxTcpClient axTcpClient1;
        private SocketHelper.AxTcpClient axTcpClient2;
        private System.Windows.Forms.Timer tmrTorque;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label5;
        private HZH_Controls.Controls.UCEllipseDialAisle ucEllipseDialAisle1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.GroupBox groupBox4;
        private LiveCharts.WinForms.CartesianChart cartesianChart2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}