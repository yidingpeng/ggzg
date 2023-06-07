namespace RW.PMS.WinForm.UI.Follow
{
    partial class FrmFeedbackAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFeedbackAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbFeedTypeItem = new System.Windows.Forms.ComboBox();
            this.tx1 = new System.Windows.Forms.Label();
            this.laborderCode = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbfeedType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.labcreatetime = new System.Windows.Forms.Label();
            this.laboperID = new System.Windows.Forms.Label();
            this.labgwID = new System.Windows.Forms.Label();
            this.laboper = new System.Windows.Forms.Label();
            this.labareaID = new System.Windows.Forms.Label();
            this.labgwName = new System.Windows.Forms.Label();
            this.labareaName = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.txtfeedMemo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbFeedTypeItem);
            this.groupBox1.Controls.Add(this.tx1);
            this.groupBox1.Controls.Add(this.laborderCode);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbfeedType);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.labcreatetime);
            this.groupBox1.Controls.Add(this.laboperID);
            this.groupBox1.Controls.Add(this.labgwID);
            this.groupBox1.Controls.Add(this.laboper);
            this.groupBox1.Controls.Add(this.labareaID);
            this.groupBox1.Controls.Add(this.labgwName);
            this.groupBox1.Controls.Add(this.labareaName);
            this.groupBox1.Controls.Add(this.txtremark);
            this.groupBox1.Controls.Add(this.txtfeedMemo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 619);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "异常信息";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(262, 295);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 25);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.Text = "禁用";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(143, 295);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(60, 25);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "启用";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 21);
            this.label8.TabIndex = 21;
            this.label8.Text = "AGV状态：";
            // 
            // cmbFeedTypeItem
            // 
            this.cmbFeedTypeItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFeedTypeItem.Enabled = false;
            this.cmbFeedTypeItem.FormattingEnabled = true;
            this.cmbFeedTypeItem.Location = new System.Drawing.Point(341, 245);
            this.cmbFeedTypeItem.Name = "cmbFeedTypeItem";
            this.cmbFeedTypeItem.Size = new System.Drawing.Size(179, 29);
            this.cmbFeedTypeItem.TabIndex = 17;
            this.cmbFeedTypeItem.SelectionChangeCommitted += new System.EventHandler(this.cmbFeedTypeItem_SelectionChangeCommitted);
            // 
            // tx1
            // 
            this.tx1.AutoSize = true;
            this.tx1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tx1.ForeColor = System.Drawing.Color.Red;
            this.tx1.Location = new System.Drawing.Point(651, 342);
            this.tx1.Name = "tx1";
            this.tx1.Size = new System.Drawing.Size(18, 22);
            this.tx1.TabIndex = 15;
            this.tx1.Text = "*";
            // 
            // laborderCode
            // 
            this.laborderCode.AutoSize = true;
            this.laborderCode.Location = new System.Drawing.Point(143, 42);
            this.laborderCode.Name = "laborderCode";
            this.laborderCode.Size = new System.Drawing.Size(17, 21);
            this.laborderCode.TabIndex = 14;
            this.laborderCode.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "流水号编码：";
            // 
            // cmbfeedType
            // 
            this.cmbfeedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfeedType.FormattingEnabled = true;
            this.cmbfeedType.Location = new System.Drawing.Point(143, 245);
            this.cmbfeedType.Name = "cmbfeedType";
            this.cmbfeedType.Size = new System.Drawing.Size(179, 29);
            this.cmbfeedType.TabIndex = 12;
            this.cmbfeedType.SelectionChangeCommitted += new System.EventHandler(this.cmbfeedType_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "异常类型：";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(385, 544);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 55);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取  消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(182, 544);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 55);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labcreatetime
            // 
            this.labcreatetime.AutoSize = true;
            this.labcreatetime.Location = new System.Drawing.Point(143, 200);
            this.labcreatetime.Name = "labcreatetime";
            this.labcreatetime.Size = new System.Drawing.Size(17, 21);
            this.labcreatetime.TabIndex = 1;
            this.labcreatetime.Text = "*";
            // 
            // laboperID
            // 
            this.laboperID.AutoSize = true;
            this.laboperID.Location = new System.Drawing.Point(28, 160);
            this.laboperID.Name = "laboperID";
            this.laboperID.Size = new System.Drawing.Size(17, 21);
            this.laboperID.TabIndex = 8;
            this.laboperID.Text = "*";
            this.laboperID.Visible = false;
            // 
            // labgwID
            // 
            this.labgwID.AutoSize = true;
            this.labgwID.Location = new System.Drawing.Point(28, 120);
            this.labgwID.Name = "labgwID";
            this.labgwID.Size = new System.Drawing.Size(17, 21);
            this.labgwID.TabIndex = 8;
            this.labgwID.Text = "*";
            this.labgwID.Visible = false;
            // 
            // laboper
            // 
            this.laboper.AutoSize = true;
            this.laboper.Location = new System.Drawing.Point(143, 160);
            this.laboper.Name = "laboper";
            this.laboper.Size = new System.Drawing.Size(17, 21);
            this.laboper.TabIndex = 8;
            this.laboper.Text = "*";
            // 
            // labareaID
            // 
            this.labareaID.AutoSize = true;
            this.labareaID.Location = new System.Drawing.Point(28, 80);
            this.labareaID.Name = "labareaID";
            this.labareaID.Size = new System.Drawing.Size(17, 21);
            this.labareaID.TabIndex = 8;
            this.labareaID.Text = "*";
            this.labareaID.Visible = false;
            // 
            // labgwName
            // 
            this.labgwName.AutoSize = true;
            this.labgwName.Location = new System.Drawing.Point(143, 120);
            this.labgwName.Name = "labgwName";
            this.labgwName.Size = new System.Drawing.Size(17, 21);
            this.labgwName.TabIndex = 8;
            this.labgwName.Text = "*";
            // 
            // labareaName
            // 
            this.labareaName.AutoSize = true;
            this.labareaName.Location = new System.Drawing.Point(143, 80);
            this.labareaName.Name = "labareaName";
            this.labareaName.Size = new System.Drawing.Size(17, 21);
            this.labareaName.TabIndex = 8;
            this.labareaName.Text = "*";
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(143, 436);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(505, 83);
            this.txtremark.TabIndex = 9;
            // 
            // txtfeedMemo
            // 
            this.txtfeedMemo.Location = new System.Drawing.Point(143, 340);
            this.txtfeedMemo.Multiline = true;
            this.txtfeedMemo.Name = "txtfeedMemo";
            this.txtfeedMemo.Size = new System.Drawing.Size(505, 83);
            this.txtfeedMemo.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 436);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "备注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 340);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "异常信息：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "异常时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "操作员：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "工位：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "区域：";
            // 
            // FrmFeedbackAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 643);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFeedbackAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "异常反馈";
            this.Load += new System.EventHandler(this.FrmFeedbackAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label tx1;
        private System.Windows.Forms.Label laborderCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbfeedType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label labcreatetime;
        private System.Windows.Forms.Label laboperID;
        private System.Windows.Forms.Label labgwID;
        private System.Windows.Forms.Label laboper;
        private System.Windows.Forms.Label labareaID;
        private System.Windows.Forms.Label labgwName;
        private System.Windows.Forms.Label labareaName;
        private System.Windows.Forms.TextBox txtremark;
        private System.Windows.Forms.TextBox txtfeedMemo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFeedTypeItem;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label8;
    }
}