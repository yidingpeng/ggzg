namespace RW.PMS.WinForm.UI.Assembly
{
    partial class FrmAssemblyFollow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssemblyFollow));
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.txtProdNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pf_prodNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prod_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prodModel_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agw_gwName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agw_oper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agw_starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agw_finishtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agw_finishStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agw_resultMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agx_gxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agx_starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agx_finishtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agx_finishStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agx_resultMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agb_gbName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agb_starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agb_finishtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agb_finishStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agb_resultMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agj_gjName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agj_wlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agj_starttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agj_finishtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agj_resultMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agj_value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agj_gjwlCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(657, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "查 询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 473);
            this.panel1.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 108);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(872, 365);
            this.panel5.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(872, 365);
            this.panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pf_prodNo,
            this.prod_name,
            this.prodModel_name,
            this.agw_gwName,
            this.agw_oper,
            this.agw_starttime,
            this.agw_finishtime,
            this.agw_finishStatusText,
            this.agw_resultMemo,
            this.agx_gxName,
            this.agx_starttime,
            this.agx_finishtime,
            this.agx_finishStatusText,
            this.agx_resultMemo,
            this.agb_gbName,
            this.agb_starttime,
            this.agb_finishtime,
            this.agb_finishStatusText,
            this.agb_resultMemo,
            this.agj_gjName,
            this.agj_wlName,
            this.agj_starttime,
            this.agj_finishtime,
            this.agj_resultMemo,
            this.agj_value,
            this.agj_gjwlCode});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(872, 365);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dateTimePicker2);
            this.panel4.Controls.Add(this.txtProdNo);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.dateTimePicker1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(872, 55);
            this.panel4.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(524, 10);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(110, 29);
            this.dateTimePicker2.TabIndex = 6;
            // 
            // txtProdNo
            // 
            this.txtProdNo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProdNo.Location = new System.Drawing.Point(129, 11);
            this.txtProdNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdNo.Name = "txtProdNo";
            this.txtProdNo.Size = new System.Drawing.Size(155, 29);
            this.txtProdNo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(479, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "——";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(365, 11);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(110, 29);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(47, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "产品编号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(322, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "日期";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(872, 53);
            this.panel2.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(872, 52);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "装 配 记 录";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pf_prodNo
            // 
            this.pf_prodNo.DataPropertyName = "pf_prodNo";
            this.pf_prodNo.HeaderText = "产品编号";
            this.pf_prodNo.Name = "pf_prodNo";
            this.pf_prodNo.ReadOnly = true;
            // 
            // prod_name
            // 
            this.prod_name.DataPropertyName = "prod_name";
            this.prod_name.HeaderText = "产品名称";
            this.prod_name.Name = "prod_name";
            this.prod_name.ReadOnly = true;
            // 
            // prodModel_name
            // 
            this.prodModel_name.DataPropertyName = "prodModel_name";
            this.prodModel_name.HeaderText = "产品型号";
            this.prodModel_name.Name = "prodModel_name";
            this.prodModel_name.ReadOnly = true;
            // 
            // agw_gwName
            // 
            this.agw_gwName.DataPropertyName = "agw_gwName";
            this.agw_gwName.HeaderText = "工位名称";
            this.agw_gwName.Name = "agw_gwName";
            this.agw_gwName.ReadOnly = true;
            // 
            // agw_oper
            // 
            this.agw_oper.DataPropertyName = "agw_oper";
            this.agw_oper.HeaderText = "工位操作员";
            this.agw_oper.Name = "agw_oper";
            this.agw_oper.ReadOnly = true;
            this.agw_oper.Width = 115;
            // 
            // agw_starttime
            // 
            this.agw_starttime.DataPropertyName = "agw_starttime";
            this.agw_starttime.HeaderText = "工位开始时间";
            this.agw_starttime.Name = "agw_starttime";
            this.agw_starttime.ReadOnly = true;
            this.agw_starttime.Width = 135;
            // 
            // agw_finishtime
            // 
            this.agw_finishtime.DataPropertyName = "agw_finishtime";
            this.agw_finishtime.HeaderText = "工位完成时间";
            this.agw_finishtime.Name = "agw_finishtime";
            this.agw_finishtime.ReadOnly = true;
            this.agw_finishtime.Width = 135;
            // 
            // agw_finishStatusText
            // 
            this.agw_finishStatusText.DataPropertyName = "agw_finishStatusText";
            this.agw_finishStatusText.HeaderText = "工位完成状态";
            this.agw_finishStatusText.Name = "agw_finishStatusText";
            this.agw_finishStatusText.ReadOnly = true;
            this.agw_finishStatusText.Width = 135;
            // 
            // agw_resultMemo
            // 
            this.agw_resultMemo.DataPropertyName = "agw_resultMemo";
            this.agw_resultMemo.HeaderText = "工位质量结果";
            this.agw_resultMemo.Name = "agw_resultMemo";
            this.agw_resultMemo.ReadOnly = true;
            this.agw_resultMemo.Width = 135;
            // 
            // agx_gxName
            // 
            this.agx_gxName.DataPropertyName = "agx_gxName";
            this.agx_gxName.HeaderText = "工序名称";
            this.agx_gxName.Name = "agx_gxName";
            this.agx_gxName.ReadOnly = true;
            // 
            // agx_starttime
            // 
            this.agx_starttime.DataPropertyName = "agx_starttime";
            this.agx_starttime.HeaderText = "工序开始时间";
            this.agx_starttime.Name = "agx_starttime";
            this.agx_starttime.ReadOnly = true;
            this.agx_starttime.Width = 135;
            // 
            // agx_finishtime
            // 
            this.agx_finishtime.DataPropertyName = "agx_finishtime";
            this.agx_finishtime.HeaderText = "工序完成时间";
            this.agx_finishtime.Name = "agx_finishtime";
            this.agx_finishtime.ReadOnly = true;
            this.agx_finishtime.Width = 135;
            // 
            // agx_finishStatusText
            // 
            this.agx_finishStatusText.DataPropertyName = "agx_finishStatusText";
            this.agx_finishStatusText.HeaderText = "工序完成状态";
            this.agx_finishStatusText.Name = "agx_finishStatusText";
            this.agx_finishStatusText.ReadOnly = true;
            this.agx_finishStatusText.Width = 135;
            // 
            // agx_resultMemo
            // 
            this.agx_resultMemo.DataPropertyName = "agx_resultMemo";
            this.agx_resultMemo.HeaderText = "工序质量结果";
            this.agx_resultMemo.Name = "agx_resultMemo";
            this.agx_resultMemo.ReadOnly = true;
            this.agx_resultMemo.Width = 135;
            // 
            // agb_gbName
            // 
            this.agb_gbName.DataPropertyName = "agb_gbName";
            this.agb_gbName.HeaderText = "工步质量结果";
            this.agb_gbName.Name = "agb_gbName";
            this.agb_gbName.ReadOnly = true;
            this.agb_gbName.Width = 135;
            // 
            // agb_starttime
            // 
            this.agb_starttime.DataPropertyName = "agb_starttime";
            this.agb_starttime.HeaderText = "工步开始时间";
            this.agb_starttime.Name = "agb_starttime";
            this.agb_starttime.ReadOnly = true;
            this.agb_starttime.Width = 135;
            // 
            // agb_finishtime
            // 
            this.agb_finishtime.DataPropertyName = "agb_finishtime";
            this.agb_finishtime.HeaderText = "工步完成时间";
            this.agb_finishtime.Name = "agb_finishtime";
            this.agb_finishtime.ReadOnly = true;
            this.agb_finishtime.Width = 135;
            // 
            // agb_finishStatusText
            // 
            this.agb_finishStatusText.DataPropertyName = "agb_finishStatusText";
            this.agb_finishStatusText.HeaderText = "工步完成状态";
            this.agb_finishStatusText.Name = "agb_finishStatusText";
            this.agb_finishStatusText.ReadOnly = true;
            this.agb_finishStatusText.Width = 135;
            // 
            // agb_resultMemo
            // 
            this.agb_resultMemo.DataPropertyName = "agb_resultMemo";
            this.agb_resultMemo.HeaderText = "工步质量结果";
            this.agb_resultMemo.Name = "agb_resultMemo";
            this.agb_resultMemo.ReadOnly = true;
            this.agb_resultMemo.Width = 135;
            // 
            // agj_gjName
            // 
            this.agj_gjName.DataPropertyName = "agj_gjName";
            this.agj_gjName.HeaderText = "工具";
            this.agj_gjName.Name = "agj_gjName";
            this.agj_gjName.ReadOnly = true;
            // 
            // agj_wlName
            // 
            this.agj_wlName.DataPropertyName = "agj_wlName";
            this.agj_wlName.HeaderText = "物料";
            this.agj_wlName.Name = "agj_wlName";
            this.agj_wlName.ReadOnly = true;
            // 
            // agj_starttime
            // 
            this.agj_starttime.DataPropertyName = "agj_starttime";
            this.agj_starttime.HeaderText = "工具物料开始时间";
            this.agj_starttime.Name = "agj_starttime";
            this.agj_starttime.ReadOnly = true;
            this.agj_starttime.Width = 155;
            // 
            // agj_finishtime
            // 
            this.agj_finishtime.DataPropertyName = "agj_finishtime";
            this.agj_finishtime.HeaderText = "工具物料完成时间";
            this.agj_finishtime.Name = "agj_finishtime";
            this.agj_finishtime.ReadOnly = true;
            this.agj_finishtime.Width = 135;
            // 
            // agj_resultMemo
            // 
            this.agj_resultMemo.DataPropertyName = "agj_resultMemo";
            this.agj_resultMemo.HeaderText = "工具物料质量结果";
            this.agj_resultMemo.Name = "agj_resultMemo";
            this.agj_resultMemo.ReadOnly = true;
            this.agj_resultMemo.Width = 135;
            // 
            // agj_value
            // 
            this.agj_value.DataPropertyName = "agj_value";
            this.agj_value.HeaderText = "工具结果值";
            this.agj_value.Name = "agj_value";
            this.agj_value.ReadOnly = true;
            this.agj_value.Width = 115;
            // 
            // agj_gjwlCode
            // 
            this.agj_gjwlCode.DataPropertyName = "agj_gjwlCode";
            this.agj_gjwlCode.HeaderText = "工装编码";
            this.agj_gjwlCode.Name = "agj_gjwlCode";
            this.agj_gjwlCode.ReadOnly = true;
            // 
            // FrmAssemblyFollow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 473);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAssemblyFollow";
            this.Text = "产品装配记录";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAssemblyFollow_Load);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProdNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn pf_prodNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn prod_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn prodModel_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn agw_gwName;
        private System.Windows.Forms.DataGridViewTextBoxColumn agw_oper;
        private System.Windows.Forms.DataGridViewTextBoxColumn agw_starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agw_finishtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agw_finishStatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn agw_resultMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn agx_gxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn agx_starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agx_finishtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agx_finishStatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn agx_resultMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn agb_gbName;
        private System.Windows.Forms.DataGridViewTextBoxColumn agb_starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agb_finishtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agb_finishStatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn agb_resultMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn agj_gjName;
        private System.Windows.Forms.DataGridViewTextBoxColumn agj_wlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn agj_starttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agj_finishtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn agj_resultMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn agj_value;
        private System.Windows.Forms.DataGridViewTextBoxColumn agj_gjwlCode;
    }
}