namespace RW.PMS.WinForm.UI.Assembly
{
    partial class FrmTorque
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
            this.lblTorque = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.btnOK = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtAngle = new System.Windows.Forms.NumericUpDown();
            this.txtTorque = new System.Windows.Forms.NumericUpDown();
            this.lblMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTorque)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTorque
            // 
            this.lblTorque.AutoSize = true;
            this.lblTorque.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTorque.Location = new System.Drawing.Point(40, 133);
            this.lblTorque.Name = "lblTorque";
            this.lblTorque.Size = new System.Drawing.Size(103, 29);
            this.lblTorque.TabIndex = 0;
            this.lblTorque.Text = "扭力：";
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAngle.Location = new System.Drawing.Point(40, 133);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(103, 29);
            this.lblAngle.TabIndex = 1;
            this.lblAngle.Text = "角度：";
            // 
            // btnOK
            // 
            this.btnOK.Depth = 0;
            this.btnOK.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(192, 196);
            this.btnOK.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOK.Name = "btnOK";
            this.btnOK.Primary = true;
            this.btnOK.Size = new System.Drawing.Size(113, 44);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确 认";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtAngle
            // 
            this.txtAngle.DecimalPlaces = 2;
            this.txtAngle.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAngle.Location = new System.Drawing.Point(145, 127);
            this.txtAngle.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(287, 41);
            this.txtAngle.TabIndex = 1;
            // 
            // txtTorque
            // 
            this.txtTorque.DecimalPlaces = 2;
            this.txtTorque.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTorque.Location = new System.Drawing.Point(144, 127);
            this.txtTorque.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtTorque.Name = "txtTorque";
            this.txtTorque.Size = new System.Drawing.Size(288, 41);
            this.txtTorque.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(50, 81);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(58, 29);
            this.lblMsg.TabIndex = 7;
            this.lblMsg.Text = "msg";
            // 
            // FrmTorque
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 258);
            this.Controls.Add(this.txtTorque);
            this.Controls.Add(this.lblTorque);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtAngle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblAngle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTorque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "扭力采集";
            ((System.ComponentModel.ISupportInitialize)(this.txtAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTorque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTorque;
        private System.Windows.Forms.Label lblAngle;
        private MaterialSkin.Controls.MaterialRaisedButton btnOK;
        public System.Windows.Forms.NumericUpDown txtAngle;
        public System.Windows.Forms.NumericUpDown txtTorque;
        public System.Windows.Forms.Label lblMsg;
    }
}