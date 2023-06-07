using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RW.PMS.WinForm;
using RW.PMS.IBLL;
using RW.PMS.Common;
using entity = RW.PMS.Model.Follow;

namespace RW.PMS.WinForm.UI.Follow
{
    public partial class FrmFollowFeedReport : Form
    {
        private string frm_empId = "";
        private string frm_empName = "";
        private string frm_areaID = "";
        private string frm_gwID = "";
        private string frm_gwName = "";
        private string frm_areaName = "";
        private string frm_areaCode = "";

        private static IBLL_Follow BLL = DIService.GetService<IBLL_Follow>();

        public FrmFollowFeedReport()
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            frm_empId = PublicVariable.CurEmpID.ToString();
            frm_empName = PublicVariable.CurEmpName;
            frm_gwID = PublicVariable.CurGwID.ToString();
            frm_gwName = PublicVariable.CurGwName;
            frm_areaID = PublicVariable.CurAreaID.ToString();
            frm_areaName = PublicVariable.CurAreaName;
            frm_areaCode = PublicVariable.CurAreaBDCode;
        }

        private void FrmFollowFeedReport_Load(object sender, EventArgs e)
        {
            bindData();
        }


        //绑定查询
        public void bindData()
        {
            List<entity.FollowAbnormalModel> list = BLL.GetFollowAbnormal(Convert.ToInt32(frm_areaID), Convert.ToInt32(frm_gwID), Convert.ToInt32(frm_empId));
            dataGridView1.DataSource = list;
        }
        //添加
        private void toolbtnAdd_Click(object sender, EventArgs e)
        {
            FrmFeedbackAdd feedback = new FrmFeedbackAdd(EDAEnums.ActionType.Add.ToString(), 0);
            DialogResult dialogresult = feedback.ShowDialog();
            //判断是否返回为OK，刷新窗体
            if (dialogresult == DialogResult.OK)
            {
                bindData();
            }
        }
        //修改
        private void toolbtnEdit_Click(object sender, EventArgs e)
        {
            //获取ID
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["col_ID"].Value) : 0;
            if (ID != 0)
            {
                FrmFeedbackAdd feedback = new FrmFeedbackAdd(EDAEnums.ActionType.Edit.ToString(), ID);
                DialogResult dialogresult = feedback.ShowDialog();
                //判断是否返回为OK，刷新窗体
                if (dialogresult == DialogResult.OK)
                {
                    bindData();
                }
            }
            else
            {
                MessageBox.Show("请选择需要修改的数据！");
            }
        }
        //删除
        private void toolbtnDel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult value = MessageBox.Show("你确定是否删除该反馈？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (value == DialogResult.Yes)
                {
                    //获取ID
                    int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["col_ID"].Value) : 0;
                    if (ID != 0)
                    {
                        bool result = BLL.DeleteFollow_Abnormal(ID);
                        if (result)
                        {
                            MessageBox.Show("删除成功！");
                            bindData();
                        }
                        else
                            MessageBox.Show("删除失败！");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //刷新
        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            bindData();
        }
        //双击进入编辑
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //获取ID
            int ID = dataGridView1.SelectedRows.Count > 0 ? Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["col_ID"].Value) : 0;
            FrmFeedbackAdd feedback = new FrmFeedbackAdd(EDAEnums.ActionType.Edit.ToString(), ID);
            DialogResult dialogresult = feedback.ShowDialog();
            //判断是否返回为OK，刷新窗体
            if (dialogresult == DialogResult.OK)
            {
                bindData();
            }

        }
    }
}
