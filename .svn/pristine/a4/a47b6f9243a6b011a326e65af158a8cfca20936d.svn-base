using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Device;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Device
{
    /// <summary>
    /// 设备到期提醒窗体
    /// </summary>
    public partial class FrmDeviceRemind : Form
    {
        IBLL_Device devBLL = DIService.GetService<IBLL_Device>();
        IBLL_System bllSystem = DIService.GetService<IBLL_System>();

        /// <summary>
        /// 设备到期提醒窗体构造函数
        /// </summary>
        public FrmDeviceRemind()
        {
            InitializeComponent();
            //dgv
            dgvData.AutoGenerateColumns = false;//取消自动创建列
            dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;//选中单元格后为编辑状态
        }

        private void Frm_DeviceRemind_Load(object sender, EventArgs e)
        {
            BindDate();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindDate()
        {
            try
            {
                var list = devBLL.GetToolsRemindCount(PublicVariable.LocalIP);
                dgvData.DataSource = list;

                SysconfigModel config = bllSystem.GetConfigByCode("devExpireIsAssembly");
                if (config != null)
                    PublicVariable.DevExpireIsAssembly = config.cfg_value == "1" ? true : false;

                var Expirelist = list.Where(x => x.Status == "已到期").ToList();
                if (Expirelist.Count > 0)
                    PublicVariable.IsDevExpire = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 送检
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInspection_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvData.Rows.Count == 0)
                {
                    MessageBox.Show("没有可送检的数据!", "温馨提示");
                    return;
                }


                List<DeviceRemindModel> list = new List<DeviceRemindModel>();
                for (int i = 0; i < dgvData.Rows.Count; i++)
                {
                    DataGridViewRow dr = dgvData.Rows[i];
                    string strCheck = dr.Cells["col_check"].Value + "";
                    if (strCheck != "1") continue;

                    DeviceRemindModel model = new DeviceRemindModel();
                    model.TId = dr.Cells["col_TId"].Value.ToInt();
                    model.ToolId = dr.Cells["col_toolId"].Value.ToInt();
                    model.ToolName = dr.Cells["col_toolName"].Value + "";
                    model.DevCertificateNo = dr.Cells["col_CertificateNo"].Value + "";
                    model.DevPurchaseDate = dr.Cells["col_DevPurchaseDate"].Value.ToDateTime();
                    model.DevExpireDate = dr.Cells["col_devExpireDate"].Value.ToDateTime();
                    model.DevStatus = dr.Cells["col_status"].Value.ToInt();
                    model.Devremark = dr.Cells["col_remark"].Value + "";
                    list.Add(model);
                }

                if (list.Count == 0)
                {
                    MessageBox.Show("请勾选需送检的设备/器具再执行此操作!", "温馨提示");
                    return;
                }

                //DialogResult dialogSend = MessageBox.Show("确定设备已送检？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.None);
                //if (dialogSend != DialogResult.OK)
                //    return;

                FrmExpireDate f = new FrmExpireDate();
                f.ShowDialog();

                if (f.DialogResult == DialogResult.Cancel) return;

                //送检人赋值
                foreach (var item in list)
                {
                    item.EmpID = f.InspectionManID;
                    item.DevExpireDate = f.ExpreDate;
                }

                //保存送检
                if (devBLL.SaveInspection(list))
                {
                    MessageBox.Show("保存成功!", "温馨提示");
                    BindDate();//刷新
                }
                else
                {
                    MessageBox.Show("保存失败!", "温馨提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错：" + ex.Message, "温馨提示");
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (PublicVariable.IsDevExpire)
            {
                if (MessageBox.Show("该设备有已到期的器具，继续登录无法进行工艺指导，确定登录吗？", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                    Application.Exit();
                else
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgvr in dgvData.Rows)
                {
                    dgvr.Cells["col_check"].Value = ckbCheckAll.Checked;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
