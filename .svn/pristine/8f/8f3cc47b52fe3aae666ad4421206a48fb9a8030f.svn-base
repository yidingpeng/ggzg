using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Device
{
    /// <summary>
    /// 设备送检人及下次提醒日期设置窗体
    /// </summary>
    public partial class FrmExpireDate : Form
    {
        /// <summary>
        /// 送检人ID
        /// </summary>
        public int InspectionManID { get; set; }

        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime? ExpreDate { get; set; }

        /// <summary>
        /// 设备送检人及下次提醒日期设置窗体 构造函数
        /// </summary>
        public FrmExpireDate()
        {
            InitializeComponent();
        }

        //加载函数
        private void Frm_ExpireDate_Load(object sender, EventArgs e)
        {
            try
            {
                List<UserModel> list = DIService.GetService<IBLL_System>().GetUserList();
                cmbUser.DisplayMember = "empName";
                cmbUser.ValueMember = "userID";
                cmbUser.DataSource = list;
                cmbUser.SelectedValue = PublicVariable.CurEmpID;
                dtpDate.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //确定按钮点击事件
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dtpDate.Checked)
                {
                    MessageBox.Show("请选择设备到期提醒日期!");
                    return;
                }
                InspectionManID = cmbUser.SelectedValue.ToInt();
                ExpreDate = dtpDate.Value;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //取消按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
