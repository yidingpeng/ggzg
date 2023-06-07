namespace RW.PMS.WinForm
{
    partial class FrmScanQRcode
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
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbTit = new System.Windows.Forms.Label();
            this.lblQRcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtValue.Location = new System.Drawing.Point(148, 100);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(264, 29);
            this.txtValue.TabIndex = 1;
            this.txtValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValue_KeyPress);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(305, 162);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "button1";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbTit
            // 
            this.lbTit.AutoSize = true;
            this.lbTit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTit.Location = new System.Drawing.Point(77, 46);
            this.lbTit.Name = "lbTit";
            this.lbTit.Size = new System.Drawing.Size(63, 22);
            this.lbTit.TabIndex = 4;
            this.lbTit.Text = "提 示：";
            this.lbTit.Visible = false;
            // 
            // lblQRcode
            // 
            this.lblQRcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblQRcode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQRcode.Location = new System.Drawing.Point(2, 103);
            this.lblQRcode.Name = "lblQRcode";
            this.lblQRcode.ReadOnly = true;
            this.lblQRcode.Size = new System.Drawing.Size(138, 22);
            this.lblQRcode.TabIndex = 5;
            this.lblQRcode.Text = "二维码";
            this.lblQRcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmScanQRcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 197);
            this.Controls.Add(this.lblQRcode);
            this.Controls.Add(this.lbTit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtValue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmScanQRcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "扫码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbTit;
        public System.Windows.Forms.TextBox lblQRcode;
        private System.Windows.Forms.TextBox txtValue;
    }
}