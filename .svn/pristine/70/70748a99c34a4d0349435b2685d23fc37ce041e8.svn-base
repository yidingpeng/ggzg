using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RW.PMS.IBLL;
using RW.PMS.Common;
using BaseEnty = RW.PMS.Model.BaseInfo;
using SysEnty = RW.PMS.Model.Sys;
using DevEnty = RW.PMS.Model.Device;
using RW.PMS.Model.Sys;
using RW.PMS.Model.Device;
using System.IO;
using RW.PMS.Model.BaseInfo;
using RW.PMS.WinForm.Utils;
using RW.PMS.WinForm.Common;
using RW.PMS.Utils.Security;
using System.Configuration;

namespace RW.PMS.WinForm.UI.Device
{
    /// <summary>
    /// 设备点检
    /// </summary>
    public partial class FrmDeviceChecking : Form
    {
        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo BaseBll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Account _accountBLL = DIService.GetService<IBLL_Account>();
        public FrmDeviceChecking()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;

            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;//选中单元格后为编辑状态

            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;  //设置自动换行

            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;//设置自动调整高度

            dataGridView1.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True; //让整个DataGridView的所有cell都可以自动换行。

            //dataGridView1.Columns["col_checkItem"].CellTemplate.Style.WrapMode = DataGridViewTriState.True;


        }
        string _loginIsUseCard = "0";
        CardOperation _cardOpertion = null;
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDeviceChecking_Load(object sender, EventArgs e)
        {
            try
            {
                BindDDL();
                BindData();

                if (_loginIsUseCard == "1")
                {
                    _loginIsUseCard = Sysbll.GetConfigByCode("LoginIsUseCard").cfg_value;
                    _cardOpertion = new CardOperation(this);
                    _cardOpertion.IsConnBeep = true;
                    _cardOpertion.Open();
                    _cardOpertion.CardReader += _cardOpertion_CardReader;
                    _cardOpertion.ReadStart();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void _cardOpertion_CardReader(object sender, string e)
        {
            /*   txtcard.Text = e.Substring(0, 8);*///只取前8位字符串结果。
            if (e.ToUpper().StartsWith("E"))
            {
                //卡号登录
                UserModel userModel = new UserModel();
                //userModel.userName = txtName.Text.Trim();
                //userModel.cardNo = txtcard.Text.Trim();
                userModel.deleted = 0;
                userModel.inStatus = 1;
                var empInfo = Sysbll.GetUser(userModel);
                if (empInfo == null)
                {
                    RWMessageBox.Show("没有找到卡号对应的员工信息！");
                    return;
                }

                BaseGongweiRightModel model = new BaseGongweiRightModel();
                model.empID = empInfo.userID;
                model.IP = PublicVariable.LocalIP;
                if (string.IsNullOrEmpty(model.IP))
                {
                    RWMessageBox.Show("未获取到本机的IP地址，请检查！");
                    return;
                }
                //需要在修改完basebll后取消注释
                List<BaseGongweiRightModel> list = BaseBll.GetRightList(model);
                if (list.Count == 0)
                {
                    RWMessageBox.Show("没有权限！");
                    return;
                }

                //EmpID = empInfo.userID;
                //EmpName = empInfo.empName;
                //IsAdmin = empInfo.roleName == "管理员";

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("员工卡号有错误，请换成正确的卡，卡号须以E开头");
            }
        }


        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        private void BindDDL()
        {

            try
            {
                List<BaseEnty.DeviceModel> devAll = Devbll.GetDevice();
                this.cmbDevice.DataSource = devAll;
                this.cmbDevice.ValueMember = "ID";
                this.cmbDevice.DisplayMember = "DevName";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            ckbCheckAll.Checked = true;

            string IP = PublicVariable.LocalIP;
            List<BaseEnty.DeviceModel> devlist = Devbll.GetDevice().Where(x => x.DevIP == IP).ToList();
            if (devlist.Count > 0)
            {
                this.cmbDevice.SelectedValue = devlist[0].ID;

                cmbDevice_SelectionChangeCommitted(null, null);
            }
            txtChecker.Text = PublicVariable.CurEmpName;
            txtChecker.Tag = PublicVariable.CurEmpID;
            txtAssignedTo.Text = "";
            txtAssignedTo.Tag = 0;
            txtRemark.Text = "";
            txtRemark.Text = "";

        }
        /// <summary>
        /// 全选反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ckbCheckAll.Checked)
                {
                    foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
                    {
                        dgvr.Cells["col_check"].Value = "1";
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgvr in this.dataGridView1.Rows)
                    {
                        dgvr.Cells["col_check"].Value = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 获取员工ID和名称
        /// </summary>
        /// <param name="txt"></param>
        private void textBoxEnter(TextBox txt)
        {
            try
            {
                UserModel model = new UserModel();
                model.cardNo = txt.Text.Trim();
                UserModel empEnty = Sysbll.GetUser(model);
                if (empEnty != null)
                {
                    txt.Text = empEnty.empName;
                    txt.Tag = empEnty.userID;
                    this.ProcessTabKey(true);
                }
                else
                {
                    MessageBox.Show("提示：找不到员工信息！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region 数据验证

                int devID = Convert.ToInt32(cmbDevice.SelectedValue);

                string Checker = this.txtChecker.Text.Trim();

                if (devID == 0 || string.IsNullOrEmpty(Checker))
                {
                    MessageBox.Show("设备和点检者不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                #region 主表数据

                DevEnty.DeviceCheckingModel mainEnty = new DevEnty.DeviceCheckingModel();
                mainEnty.DevID = devID;

                mainEnty.CheckTime = DateTime.Now.Year + "年" + DateTime.Now.Month + "月";

                mainEnty.CheckerID = txtChecker.Text.Trim() != "" && txtChecker.Tag.ToString() != "" ? Convert.ToInt32(txtChecker.Tag) : 0;

                mainEnty.Remark = txtRemark.Text;
                #endregion

                List<DevEnty.DeviceCheckingDetailsModel> checkEntyList = new List<DevEnty.DeviceCheckingDetailsModel>();
                int dataGridveViewCount = 0;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewRow dr = dataGridView1.Rows[i];
                    if (dr.Cells["col_check"].Value != null)
                    {
                        if (dr.Cells["col_check"].Value.ToString() == "1")
                        {
                            dataGridveViewCount++;

                            DevEnty.DeviceCheckingDetailsModel checkEnty = new DevEnty.DeviceCheckingDetailsModel();

                            if (dr.Cells["ItemCheckResult"].Value == null)
                            {
                                MessageBox.Show("点检结果不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            checkEnty.DevTypeID = Convert.ToInt32(dr.Cells["dsc_category"].Value);
                            checkEnty.CheckItem = dr.Cells["dsc_project"].Value != null ? dr.Cells["dsc_project"].Value.ToString() : "";
                            checkEnty.spotID = dr.Cells["spotid"].Value.ToString();
                            checkEnty.MonitorID = Convert.ToInt32(this.MonitorID.Tag);

                            if (this.cbxdate.SelectedText.ToString() == "开机前")
                            {
                                checkEnty.SpotTime = 0;
                            }
                            else if (this.cbxdate.SelectedText.ToString() == "开机")
                            {
                                checkEnty.SpotTime = 1;
                            }
                            else
                            {
                                checkEnty.SpotTime = 2;
                            }


                            if (dr.Cells["ItemCheckResult"].Value.ToString() == "正常")
                            {
                                checkEnty.ItemCheckResult = "√";
                            }
                            else if (dr.Cells["ItemCheckResult"].Value.ToString() == "可以使用，需注意")
                            {
                                checkEnty.ItemCheckResult = "O";
                            }
                            else if (dr.Cells["ItemCheckResult"].Value.ToString() == "已损坏")
                            {
                                checkEnty.ItemCheckResult = "X";
                            }
                            else
                            {
                                checkEnty.ItemCheckResult = "/";
                            }

                            checkEnty.ItemCheckerID = txtAssignedTo.Text.Trim() != "" && txtAssignedTo.Tag.ToString() != "" ? Convert.ToInt32(txtAssignedTo.Tag) : 0;
                            checkEnty.Remark = dr.Cells["Remark"].Value != null ? dr.Cells["Remark"].Value.ToString() : "";
                            checkEnty.CheckerTime = dtp_checkTime.Value;
                            checkEntyList.Add(checkEnty);
                        }
                    }
                }

                if (dataGridveViewCount == 0 || checkEntyList.Count == 0)
                {
                    MessageBox.Show("请勾选要点检的项点", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool Result = Devbll.SaveDeviceCheck(mainEnty, checkEntyList);
                if (Result)
                {
                    MessageBox.Show("保存成功！");
                    BindData();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("出错：" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 担当者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAssignedTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBoxEnter(txtAssignedTo);
            }
        }
        /// <summary>
        /// 点检者
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtChecker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBoxEnter(txtChecker);
            }
        }

        /// <summary>
        ///dataGridView复选框实现单选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    bool a = (bool)dataGridView1.CurrentRow.Cells["col_OK"].EditedFormattedValue;
            //    bool b = (bool)dataGridView1.CurrentRow.Cells["col_NG"].EditedFormattedValue;


            //    if (dataGridView1.Rows.Count <= 0)
            //    {
            //        return;
            //    }
            //    if (e.ColumnIndex == 5 && e.RowIndex >= 0)
            //    {
            //        if (e.ColumnIndex == 5 && e.RowIndex >= 0 && a == true)
            //        {
            //            dataGridView1.CurrentRow.Cells["col_NG"].Value = false;
            //        }
            //        if (e.ColumnIndex == 6 && e.RowIndex >= 0 && b == true)
            //        {
            //            dataGridView1.CurrentRow.Cells["col_OK"].Value = false;
            //        }
            //    }
            //    if (e.ColumnIndex == 6 && e.RowIndex >= 0)
            //    {
            //        if (e.ColumnIndex == 5 && e.RowIndex >= 0 && a == true)
            //        {
            //            dataGridView1.CurrentRow.Cells["col_NG"].Value = false;
            //        }
            //        if (e.ColumnIndex == 6 && e.RowIndex >= 0 && b == true)
            //        {
            //            dataGridView1.CurrentRow.Cells["col_OK"].Value = false;
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        private void cmbDevice_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DeviceSpotCheckModel md = new DeviceSpotCheckModel() { };

            md.dsc_device = Convert.ToInt32(this.cmbDevice.SelectedValue);

            md.dsc_class = 1;

            int count = 1000;

            List<DeviceSpotCheckModel> dclist = Devbll.DeviceSpotCheckPage(md, out count);

            int sum = dclist.Count;

            for (int i = 0; i < sum; i++)
            {
                while (dclist[i].dsc_class == 0)
                {
                    dclist.RemoveAt(i);

                    sum--;

                    if (sum == 0 || dclist.Count - 1 < i)
                    {
                        break;
                    }
                }
            }

            dataGridView1.DataSource = dclist;

            btnSave.Enabled = true;
        }

        private void MonitorID_Leave(object sender, EventArgs e)
        {
            string result = System.Text.RegularExpressions.Regex.Replace(MonitorID.Text, @"[^0-9]+", "");

            if (MonitorID.Text.Length > 21 && result.Length >= 5)
            {
                UserModel user = Sysbll.GetUser(new UserModel { cardNo = result, deleted = 0, inStatus = 1 });

                MonitorID.Text = user.empName;
                MonitorID.Tag = user.userID;
            }
        }
        private void txtAssignedTo_Leave(object sender, EventArgs e)
        {
            string result = System.Text.RegularExpressions.Regex.Replace(txtAssignedTo.Text, @"[^0-9]+", "");

            if (txtAssignedTo.Text.Length > 21 && result.Length >= 5)
            {
                UserModel user = Sysbll.GetUser(new UserModel { cardNo = result, deleted = 0, inStatus = 1 });

                txtAssignedTo.Text = user.empName;
                txtAssignedTo.Tag = user.userID;
            }
        }

    }
}
