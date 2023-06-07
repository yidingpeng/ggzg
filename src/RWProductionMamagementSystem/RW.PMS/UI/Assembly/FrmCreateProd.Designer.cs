
namespace RW.PMS.WinForm.UI.Assembly
{
    partial class FrmCreateProd
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
            this.txtProdNo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.labTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtProdNo
            // 
            this.txtProdNo.Depth = 0;
            this.txtProdNo.Hint = "";
            this.txtProdNo.Location = new System.Drawing.Point(208, 61);
            this.txtProdNo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtProdNo.Name = "txtProdNo";
            this.txtProdNo.PasswordChar = '\0';
            this.txtProdNo.SelectedText = "";
            this.txtProdNo.SelectionLength = 0;
            this.txtProdNo.SelectionStart = 0;
            this.txtProdNo.Size = new System.Drawing.Size(196, 23);
            this.txtProdNo.TabIndex = 17;
            this.txtProdNo.UseSystemPasswordChar = false;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(53, 65);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(137, 19);
            this.materialLabel6.TabIndex = 16;
            this.materialLabel6.Text = "请输入产品编号：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(191, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 18;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labTip
            // 
            this.labTip.AutoSize = true;
            this.labTip.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTip.ForeColor = System.Drawing.Color.Red;
            this.labTip.Location = new System.Drawing.Point(132, 100);
            this.labTip.Name = "labTip";
            this.labTip.Size = new System.Drawing.Size(58, 21);
            this.labTip.TabIndex = 19;
            this.labTip.Text = "提示：";
            this.labTip.Visible = false;
            // 
            // FrmCreateProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 201);
            this.Controls.Add(this.labTip);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtProdNo);
            this.Controls.Add(this.materialLabel6);
            this.Name = "FrmCreateProd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增产品信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtProdNo;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labTip;
    }
}