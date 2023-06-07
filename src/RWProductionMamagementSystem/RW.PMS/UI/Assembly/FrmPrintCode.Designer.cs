
namespace RW.PMS.WinForm.UI.Assembly
{
    partial class FrmPrintCode
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
            this.lblHidGJID = new System.Windows.Forms.Label();
            this.cmbToolName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHidGJID
            // 
            this.lblHidGJID.AutoSize = true;
            this.lblHidGJID.Location = new System.Drawing.Point(453, 83);
            this.lblHidGJID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHidGJID.Name = "lblHidGJID";
            this.lblHidGJID.Size = new System.Drawing.Size(0, 18);
            this.lblHidGJID.TabIndex = 6;
            this.lblHidGJID.Visible = false;
            // 
            // cmbToolName
            // 
            this.cmbToolName.FormattingEnabled = true;
            this.cmbToolName.Location = new System.Drawing.Point(172, 56);
            this.cmbToolName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbToolName.Name = "cmbToolName";
            this.cmbToolName.Size = new System.Drawing.Size(220, 26);
            this.cmbToolName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(67, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "扳手信息：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 54);
            this.button1.TabIndex = 10;
            this.button1.Text = "打印";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmPrintCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 249);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblHidGJID);
            this.Controls.Add(this.cmbToolName);
            this.Controls.Add(this.label1);
            this.Name = "FrmPrintCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印条码";
            this.Load += new System.EventHandler(this.FrmPrintCode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHidGJID;
        private System.Windows.Forms.ComboBox cmbToolName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}