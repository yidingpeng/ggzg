using RW.PMS.Common;
using RW.PMS.IBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseEnty = RW.PMS.Model.BaseInfo;
using SysEnty = RW.PMS.Model.Sys;
using DevEnty = RW.PMS.Model.Device;
using entity = RW.PMS.Model.Follow;
using RW.PMS.Utils;
using RW.PMS.Model.Sys;
namespace RW.PMS.WinForm.UI.Follow
{
    public partial class FrmFaultRepairEdit : Form
    {
        private string frm_empId = "";
        private string frm_empName = "";

        private string frm_actionType = "";
        private int frm_ID = 0;

        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        IBLL_Follow Bll = DIService.GetService<IBLL_Follow>();
        IBLL_BaseInfo BaseBll = DIService.GetService<IBLL_BaseInfo>();

        public FrmFaultRepairEdit(string _actionType, int ID)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            frm_actionType = _actionType;
            frm_ID = ID;

            frm_empId = PublicVariable.CurEmpID.ToString();
            frm_empName = PublicVariable.CurEmpName;
        }

        //窗体加载
        private void FrmFaultRepairEdit_Load(object sender, EventArgs e)
        {
            try
            {
                BindDDL();
                BindData();
            }
            catch (Exception)
            {

                throw;
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
                devAll.Insert(0, new BaseEnty.DeviceModel { ID = 0, DevName = "--请选择--" });
                this.cmbDevice.DataSource = devAll;
                this.cmbDevice.ValueMember = "ID";
                this.cmbDevice.DisplayMember = "DevName";

                List<SysEnty.BaseDataModel> Arealist = Sysbll.GetBaseDataTypeValue("faultCode");
                Arealist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });
                this.cmbFaultCode.DataSource = Arealist;
                this.cmbFaultCode.ValueMember = "ID";
                this.cmbFaultCode.DisplayMember = "Bdname";

                List<SysEnty.BaseDataModel> Levellist = Sysbll.GetBaseDataTypeValue("faultLevel");
                Levellist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });
                this.cmbFaultLevel.DataSource = Levellist;
                this.cmbFaultLevel.ValueMember = "ID";
                this.cmbFaultLevel.DisplayMember = "Bdname";

                List<SysEnty.BaseDataModel> faultTypelist = Sysbll.GetBaseDataTypeValue("faultType");
                faultTypelist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });
                this.cmbFaultClass.DataSource = faultTypelist;
                this.cmbFaultClass.ValueMember = "ID";
                this.cmbFaultClass.DisplayMember = "Bdname";

                List<SysEnty.BaseDataModel> Emergencylist = Sysbll.GetBaseDataTypeValue("repariEmergency");
                Emergencylist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });
                this.cmbEmergency.DataSource = Emergencylist;
                this.cmbEmergency.ValueMember = "ID";
                this.cmbEmergency.DisplayMember = "Bdname";

                List<SysEnty.BaseDataModel> Carlist = Sysbll.GetBaseDataTypeValue("subwayType");
                Carlist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });
                this.cmbCarModel.DataSource = Carlist;
                this.cmbCarModel.ValueMember = "ID";
                this.cmbCarModel.DisplayMember = "Bdname";

                List<BaseEnty.BaseProductModelModel> prodMlist = BaseBll.GetProductModel();
                prodMlist.Insert(0, new BaseEnty.BaseProductModelModel { ID = 0, Pmodel = "--请选择--" });
                this.cmbProdModel.DataSource = prodMlist;
                this.cmbProdModel.ValueMember = "ID";
                this.cmbProdModel.DisplayMember = "Pmodel";
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
            if (frm_actionType == EDAEnums.ActionType.Add.ToString())
            {
                string IP = PublicVariable.LocalIP;
                List<BaseEnty.DeviceModel> devlist = Devbll.GetDevice().Where(x => x.DevIP == IP).ToList();
                if (devlist.Count > 0)
                {
                    this.cmbDevice.SelectedValue = devlist[0].ID;
                }
                this.txtOper.Tag = frm_empId;
                this.txtOper.Text = frm_empName;
            }
            else if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                SetControlData();
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool IsTrue = IsResult();
            if (IsTrue)
            {
                if (frm_actionType == EDAEnums.ActionType.Add.ToString())
                {
                    entity.FollowFaultRepairModel frmEnty = GetFollowFaultRepair();
                    bool Result = Bll.AddFollow_FaultRepair(frmEnty);
                    if (Result)
                    {
                        MessageBox.Show("保存成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("保存失败！");
                    }
                }
                else if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
                {
                    entity.FollowFaultRepairModel frmEnty = GetFollowFaultRepair();
                    frmEnty.ID = Convert.ToInt32(frm_ID);
                    bool Result = Bll.UpdateFollow_FaultRepair(frmEnty);
                    if (Result)
                    {
                        MessageBox.Show("修改成功！");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("修改失败！");
                    }
                }
            }
            else
            {
                MessageBox.Show("带*的为必填项！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        public bool IsResult()
        {
            if (this.cmbDevice.SelectedValue.ToString() == "0" || this.txtOper.Text.Trim() == "" ||
                this.cmbFaultLevel.SelectedValue.ToString() == "0" || this.cmbFaultClass.SelectedValue.ToString() == "0" ||
                this.cmbEmergency.SelectedValue.ToString() == "0" || this.txtFaultMemo.Text.Trim() == "" ||
                this.txtRepairMemo.Text.Trim() == "")
            {

                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 给实体赋值
        /// </summary>
        /// <returns></returns>
        public entity.FollowFaultRepairModel GetFollowFaultRepair()
        {
            entity.FollowFaultRepairModel frmEnty = new entity.FollowFaultRepairModel();
            frmEnty.Fr_devID = Convert.ToInt32(this.cmbDevice.SelectedValue);
            frmEnty.Fr_devName = this.cmbDevice.Text;
            frmEnty.Fr_operID = Convert.ToInt32(this.txtOper.Tag);
            frmEnty.Fr_oper = this.txtOper.Text.Trim();
            frmEnty.Fr_createtime = this.dtpCreatetime.Value;
            frmEnty.Fr_faultCode = Convert.ToInt32(this.cmbFaultCode.SelectedValue);
            frmEnty.Fr_faultLevel = Convert.ToInt32(this.cmbFaultLevel.SelectedValue);
            frmEnty.Fr_faultClass = Convert.ToInt32(this.cmbFaultClass.SelectedValue);
            frmEnty.Pf_prodModelID = Convert.ToInt32(this.cmbProdModel.SelectedValue);
            frmEnty.Pf_carModelID = Convert.ToInt32(this.cmbCarModel.SelectedValue);
            frmEnty.Pf_carNo = this.txtCarNo.Text.Trim();
            frmEnty.Pf_prodNo = this.txtProdNo.Text.Trim();
            frmEnty.Fr_faultMemo = this.txtFaultMemo.Text.Trim();
            frmEnty.Fr_repairMemo = this.txtRepairMemo.Text.Trim();
            frmEnty.Fr_emergency = Convert.ToInt32(this.cmbEmergency.SelectedValue);
            frmEnty.Fr_remark = this.txtRemark.Text.Trim();
            return frmEnty;
        }

        /// <summary>
        /// 修改赋值
        /// </summary>
        public void SetControlData()
        {
            entity.FollowFaultRepairModel frmEnty = Bll.GetFollowFaultRepairId(frm_ID);
            this.cmbDevice.SelectedValue = frmEnty.Fr_devID;
            this.txtOper.Tag = frmEnty.Fr_operID.ToString();
            this.txtOper.Text = frmEnty.Fr_oper;
            this.dtpCreatetime.Value = Convert.ToDateTime(frmEnty.Fr_createtime);
            this.cmbFaultCode.SelectedValue = frmEnty.Fr_faultCode;
            this.cmbFaultLevel.SelectedValue = frmEnty.Fr_faultLevel;
            this.cmbFaultClass.SelectedValue = frmEnty.Fr_faultClass;
            this.cmbEmergency.SelectedValue = frmEnty.Fr_emergency;
            this.cmbProdModel.SelectedValue = frmEnty.Pf_prodModelID;
            this.cmbCarModel.SelectedValue = frmEnty.Pf_carModelID;
            this.txtCarNo.Text = frmEnty.Pf_carNo;
            this.txtProdNo.Text = frmEnty.Pf_prodNo;
            this.txtFaultMemo.Text = frmEnty.Fr_faultMemo;
            this.txtRepairMemo.Text = frmEnty.Fr_repairMemo;
            this.txtRemark.Text = frmEnty.Fr_remark;
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
                SysEnty.UserModel empEnty = Sysbll.GetUser(model);
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
        private void txtOper_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBoxEnter(txtOper);
            }
        }

    }
}
