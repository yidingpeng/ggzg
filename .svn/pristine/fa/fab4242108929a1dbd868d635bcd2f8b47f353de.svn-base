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
    public partial class FrmFeedbackEdit : Form
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

        public FrmFeedbackEdit(string _actionType, int ID)
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

        //初始化
        private void FrmFeedbackEdit_Load(object sender, EventArgs e)
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
            List<SysEnty.BaseDataModel> faultTypelist = Sysbll.GetBaseDataTypeValue("feedType");
            faultTypelist.Insert(0, new SysEnty.BaseDataModel { ID = 0, bdname = "--请选择--" });
            this.cmbfeedType.DataSource = faultTypelist;
            this.cmbfeedType.ValueMember = "ID";
            this.cmbfeedType.DisplayMember = "Bdname";
        }

        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (frm_actionType == EDAEnums.ActionType.Add.ToString())
            {
                if (!string.IsNullOrEmpty(this.txtfeedMemo.Text.Trim()))
                {
                    entity.FollowFeedbackModel feedback = SetFollowFeedback();
                    bool Result = BLL.AddFollow_Feedback(feedback);
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
                entity.FollowFeedbackModel feedback = SetFollowFeedback();
                feedback.ID = Convert.ToInt32(frm_ID);
                bool Result = BLL.UpdateFollow_Feedback(feedback);
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

        //取消 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //给实体赋值
        public entity.FollowFeedbackModel SetFollowFeedback()
        {
            entity.FollowFeedbackModel fb = new entity.FollowFeedbackModel();
            fb.fb_areaID = Convert.ToInt32(this.labareaID.Text.Trim());
            fb.fb_areaName = this.labareaName.Text.Trim();
            fb.fb_gwID = Convert.ToInt32(this.labgwID.Text);
            fb.fb_gwName = this.labgwName.Text.Trim();
            fb.fb_operID = Convert.ToInt32(this.laboperID.Text);
            fb.fb_oper = this.laboper.Text;
            fb.fb_feedMemo = this.txtfeedMemo.Text.Trim();
            fb.fb_feedType = Convert.ToInt32(this.cmbfeedType.SelectedValue);
            fb.fb_remark = this.txtremark.Text.Trim();
            fb.fb_isok = 0;
            fb.fb_createtime = Convert.ToDateTime(PublicVariable.GetServerTime());
            return fb;
        }
         
        //修改赋值
        public void SetFollowFeedbackdata()
        {
            entity.FollowFeedbackModel feedback = BLL.GetFollowFeedbackId(frm_ID);
            this.laborderCode.Text = feedback.fb_orderCode;
            this.labareaID.Text = feedback.fb_areaID.ToString();
            this.labareaName.Text = feedback.fb_areaName;
            this.labgwID.Text = feedback.fb_gwID.ToString();
            this.labgwName.Text = feedback.fb_gwName;
            this.laboperID.Text = feedback.fb_operID.ToString();
            this.laboper.Text = feedback.fb_oper;
            this.labcreatetime.Text = Convert.ToDateTime(feedback.fb_createtime).ToString("yyyy-MM-dd HH:mm:ss");
            this.txtfeedMemo.Text = feedback.fb_feedMemo;
            this.cmbfeedType.SelectedValue = feedback.fb_feedType;
            this.txtremark.Text = feedback.fb_remark;
        }
    }
}
