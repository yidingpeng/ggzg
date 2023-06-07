using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RW.PMS.IBLL;
using RW.PMS.Common;
using entity = RW.PMS.Model.Follow;
using SysEnty = RW.PMS.Model.Sys;

namespace RW.PMS.WinForm.UI.Follow
{
    public partial class FrmFeedbackAdd : Form
    {
        private string frm_empId = "";
        private string frm_empName = "";
        private string frm_areaID = "";
        private string frm_gwID = "";
        private string frm_gwName = "";
        private string frm_areaName = "";
        private string frm_areaCode = "";

        private string frm_actionType = "";
        private int frm_ID = 0;

        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        private static IBLL_Follow BLL = DIService.GetService<IBLL_Follow>();
        public FrmFeedbackAdd(string _actionType, int ID)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();

            frm_actionType = _actionType;
            frm_ID = ID;

            frm_empId = PublicVariable.CurEmpID.ToString();
            frm_empName = PublicVariable.CurEmpName;
            frm_gwID = PublicVariable.CurGwID.ToString();
            frm_gwName = PublicVariable.CurGwName;
            frm_areaID = PublicVariable.CurAreaID.ToString();
            frm_areaName = PublicVariable.CurAreaName;
            frm_areaCode = PublicVariable.CurAreaBDCode;
        }

        private void FrmFeedbackAdd_Load(object sender, EventArgs e)
        {
            BindDDL();
            if (frm_actionType == EDAEnums.ActionType.Add.ToString())
            {
                this.labareaID.Text = frm_areaID;
                this.labareaName.Text = frm_areaName;
                this.labgwID.Text = frm_gwID;
                this.labgwName.Text = frm_gwName;
                this.laboperID.Text = frm_empId;
                this.laboper.Text = frm_empName;
                this.labcreatetime.Text = Convert.ToDateTime(PublicVariable.GetServerTime()).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                SetFollowFeedbackdata();
            }

        }
        public void BindDDL()
        {
            List<SysEnty.BaseDataModel> faultTypelist = Sysbll.GetBaseDataValue("feedType");
            faultTypelist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });

            this.cmbfeedType.DataSource = faultTypelist;
            this.cmbfeedType.ValueMember = "ID";
            this.cmbfeedType.DisplayMember = "Bdname";
        }
        public void Bindcft()
        {
            List<SysEnty.BaseDataModel> faultTypelist = Sysbll.GetBaseDataSubitemValue("feedType", Convert.ToInt32(this.cmbfeedType.SelectedValue));
            faultTypelist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });

            this.cmbFeedTypeItem.DataSource = faultTypelist;
            this.cmbFeedTypeItem.ValueMember = "ID";
            this.cmbFeedTypeItem.DisplayMember = "Bdname";

            cmbFeedTypeItem.Enabled = true;
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cmbfeedType.SelectedValue) == 0 || Convert.ToInt32(this.cmbFeedTypeItem.SelectedValue) == 0)
            {
                MessageBox.Show("请选择异常类型");

                return;
            }
            if (frm_actionType == EDAEnums.ActionType.Add.ToString())
            {
                if (!string.IsNullOrEmpty(this.txtfeedMemo.Text.Trim()))
                {
                    entity.FollowAbnormalModel feedback = SetFollowFeedback();
                    bool Result = BLL.AddFollow_Abnormal(feedback);
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
                else
                {
                    MessageBox.Show("反馈信息不能为空！");
                }
            }
            else if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                entity.FollowAbnormalModel feedback = SetFollowFeedback();
                feedback.ID = Convert.ToInt32(frm_ID);
                bool Result = BLL.UpdateFollow_Abnormal(feedback);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //给实体赋值
        public entity.FollowAbnormalModel SetFollowFeedback()
        {
            entity.FollowAbnormalModel fb = new entity.FollowAbnormalModel();
            fb.fa_areaID = Convert.ToInt32(this.labareaID.Text.Trim());
            fb.fa_areaName = this.labareaName.Text.Trim();
            fb.fa_gwID = Convert.ToInt32(this.labgwID.Text);
            fb.fa_gwName = this.labgwName.Text.Trim();
            fb.fa_operID = Convert.ToInt32(this.laboperID.Text);
            fb.fa_oper = this.laboper.Text;
            fb.fa_feedMemo = this.txtfeedMemo.Text.Trim();
            fb.fa_feedType = Convert.ToInt32(this.cmbFeedTypeItem.SelectedValue);
            fb.fa_remark = this.txtremark.Text.Trim();
            fb.fa_isok = 0;
            fb.fa_createtime = Convert.ToDateTime(PublicVariable.GetServerTime());
            fb.fa_agvstate = radioButton1.Checked ? 0 : 1;
            return fb;
        }

        //修改赋值
        public void SetFollowFeedbackdata()
        {
            entity.FollowAbnormalModel feedback = BLL.GetFollowAbnormalId(frm_ID);

            this.cmbfeedType.SelectedValue = Sysbll.GetBaseDataTypebyID("feedType", feedback.fa_feedType);

            Bindcft();

            this.cmbFeedTypeItem.SelectedValue = feedback.fa_feedType;

            this.laborderCode.Text = feedback.fa_orderCode;
            this.labareaID.Text = feedback.fa_areaID.ToString();
            this.labareaName.Text = feedback.fa_areaName;
            this.labgwID.Text = feedback.fa_gwID.ToString();
            this.labgwName.Text = feedback.fa_gwName;
            this.laboperID.Text = feedback.fa_operID.ToString();
            this.laboper.Text = feedback.fa_oper;
            this.labcreatetime.Text = Convert.ToDateTime(feedback.fa_createtime).ToString("yyyy-MM-dd HH:mm:ss");
            this.txtfeedMemo.Text = feedback.fa_feedMemo;
            this.txtremark.Text = feedback.fa_remark;
            if (feedback.fa_agvstate == 0)
            {
                this.radioButton1.Checked = true;
            }
            else
            {
                this.radioButton2.Checked = true;
            }

        }

        private void cmbfeedType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Bindcft();
        }

        private void cmbFeedTypeItem_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cmbFeedTypeItem.SelectedValue) != 0)
            {
                bool agvstate = BLL.SelectAGVstateId(Convert.ToInt32(this.cmbFeedTypeItem.SelectedValue));

                if (!agvstate)
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = true;
                }
            }

        }
    }
}
