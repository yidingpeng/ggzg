namespace RW.PMS.WinForm.UI.Follow
{
    partial class FrmFollowFeedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFollowFeedback));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolbtnDel = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.col_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_orderCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fbareaname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gwname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_createtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_feedMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_feedType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.col_ID,
            this.fb_orderCode,
            this.fbareaname,
            this.gwname,
            this.empName,
            this.fb_createtime,
            this.fb_feedMemo,
            this.fb_feedType,
            this.fb_remark,
            this.isok,
            this.fb_result});
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
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 10;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1466, 690);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 30);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnAdd,
            this.toolbtnEdit,
            this.toolbtnDel,
            this.toolbtnRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1466, 59);
            this.toolStrip1.TabIndex = 76;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // toolbtnAdd
            // 
            this.toolbtnAdd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.toolbtnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnAdd.Image")));
            this.toolbtnAdd.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnAdd.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnAdd.Name = "toolbtnAdd";
            this.toolbtnAdd.Size = new System.Drawing.Size(46, 56);
            this.toolbtnAdd.Text = "新增";
            this.toolbtnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnAdd.ToolTipText = "新增";
            this.toolbtnAdd.Click += new System.EventHandler(this.toolbtnAdd_Click);
            // 
            // toolbtnEdit
            // 
            this.toolbtnEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.toolbtnEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnEdit.Image")));
            this.toolbtnEdit.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnEdit.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnEdit.Name = "toolbtnEdit";
            this.toolbtnEdit.Size = new System.Drawing.Size(46, 56);
            this.toolbtnEdit.Text = "修改";
            this.toolbtnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnEdit.Click += new System.EventHandler(this.toolbtnEdit_Click);
            // 
            // toolbtnDel
            // 
            this.toolbtnDel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.toolbtnDel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.toolbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnDel.Image")));
            this.toolbtnDel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnDel.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnDel.Name = "toolbtnDel";
            this.toolbtnDel.Size = new System.Drawing.Size(46, 56);
            this.toolbtnDel.Text = "删除";
            this.toolbtnDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnDel.ToolTipText = "异常下线";
            this.toolbtnDel.Click += new System.EventHandler(this.toolbtnDel_Click);
            // 
            // toolbtnRefresh
            // 
            this.toolbtnRefresh.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.toolbtnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolbtnRefresh.Image")));
            this.toolbtnRefresh.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRefresh.Margin = new System.Windows.Forms.Padding(20, 1, 0, 2);
            this.toolbtnRefresh.Name = "toolbtnRefresh";
            this.toolbtnRefresh.Size = new System.Drawing.Size(46, 56);
            this.toolbtnRefresh.Text = "刷新";
            this.toolbtnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolbtnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolbtnRefresh.Click += new System.EventHandler(this.toolbtnRefresh_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1466, 690);
            this.panel1.TabIndex = 77;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1466, 690);
            this.panel3.TabIndex = 1;
            // 
            // col_ID
            // 
            this.col_ID.DataPropertyName = "ID";
            this.col_ID.HeaderText = "ID";
            this.col_ID.Name = "col_ID";
            this.col_ID.ReadOnly = true;
            this.col_ID.Visible = false;
            // 
            // fb_orderCode
            // 
            this.fb_orderCode.DataPropertyName = "fb_orderCode";
            this.fb_orderCode.HeaderText = "流水号编码";
            this.fb_orderCode.Name = "fb_orderCode";
            this.fb_orderCode.ReadOnly = true;
            this.fb_orderCode.Visible = false;
            // 
            // fbareaname
            // 
            this.fbareaname.DataPropertyName = "fb_areaName";
            this.fbareaname.HeaderText = "区域名称";
            this.fbareaname.Name = "fbareaname";
            this.fbareaname.ReadOnly = true;
            this.fbareaname.Visible = false;
            // 
            // gwname
            // 
            this.gwname.DataPropertyName = "fb_gwName";
            this.gwname.HeaderText = "工位名称";
            this.gwname.Name = "gwname";
            this.gwname.ReadOnly = true;
            // 
            // empName
            // 
            this.empName.DataPropertyName = "fb_oper";
            this.empName.HeaderText = "操作员名称";
            this.empName.Name = "empName";
            this.empName.ReadOnly = true;
            // 
            // fb_createtime
            // 
            this.fb_createtime.DataPropertyName = "fb_createtime";
            this.fb_createtime.HeaderText = "故障时间";
            this.fb_createtime.Name = "fb_createtime";
            this.fb_createtime.ReadOnly = true;
            // 
            // fb_feedMemo
            // 
            this.fb_feedMemo.DataPropertyName = "fb_feedMemo";
            this.fb_feedMemo.HeaderText = "故障内容";
            this.fb_feedMemo.Name = "fb_feedMemo";
            this.fb_feedMemo.ReadOnly = true;
            // 
            // fb_feedType
            // 
            this.fb_feedType.DataPropertyName = "fb_feedTypeText";
            this.fb_feedType.HeaderText = "故障类型";
            this.fb_feedType.Name = "fb_feedType";
            this.fb_feedType.ReadOnly = true;
            // 
            // fb_remark
            // 
            this.fb_remark.DataPropertyName = "fb_remark";
            this.fb_remark.HeaderText = "备注";
            this.fb_remark.Name = "fb_remark";
            this.fb_remark.ReadOnly = true;
            // 
            // isok
            // 
            this.isok.DataPropertyName = "IsokText";
            this.isok.HeaderText = "是否处理";
            this.isok.Name = "isok";
            this.isok.ReadOnly = true;
            // 
            // fb_result
            // 
            this.fb_result.DataPropertyName = "fb_result";
            this.fb_result.HeaderText = "处理结果";
            this.fb_result.Name = "fb_result";
            this.fb_result.ReadOnly = true;
            // 
            // FrmFollowFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1466, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFollowFeedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "故障上报";
            this.Load += new System.EventHandler(this.FrmFollowFeedback_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolbtnAdd;
        private System.Windows.Forms.ToolStripButton toolbtnEdit;
        private System.Windows.Forms.ToolStripButton toolbtnDel;
        private System.Windows.Forms.ToolStripButton toolbtnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_orderCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn fbareaname;
        private System.Windows.Forms.DataGridViewTextBoxColumn gwname;
        private System.Windows.Forms.DataGridViewTextBoxColumn empName;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_createtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_feedMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_feedType;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn isok;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_result;
    }
}