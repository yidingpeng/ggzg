using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Utils;
using RW.PMS.Model.Plan;

namespace RW.PMS.WinForm.UI.Assembly
{
    public partial class FrmPmsRequisitionMain : FormSkin
    {

        IBLL_BaseInfo BLL = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Plan PlanBLL = DIService.GetService<IBLL_Plan>();


        public FrmPmsRequisitionMain(string PpOrderCode)
        {
            InitializeComponent();
            //关闭自动绑定列
            this.dgvRequisitionMain.AutoGenerateColumns = false;
            this.txtPporderCode.Text = PpOrderCode;
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPmsRequisitionMain_Load(object sender, EventArgs e)
        {
            BindData();
        }


        private void BindData()
        {
            try
            {

                int status = -1;
                if (rdbNoStart.Checked)
                    status = 0;//未配料
                if (rdbMaterials.Checked)
                    status = 1;//已配料
                else if (rdbConfirm.Checked)
                    status = 2;//缺/少配料

                List<PartPlanTechnicsModel> item = PlanBLL.GetPartPlanTechnicsList(new PartPlanTechnicsModel { pp_orderCode = this.txtPporderCode.Text.Trim(), pt_status = status });
                this.dgvRequisitionMain.DataSource = item;

                for (int i = 0; i < item.Count; i++)
                {
                    if (item[i].pt_status.HasValue)
                    {
                        string ptstatus = item[i].pt_status.ToString();
                        //物料状态：状态 0.未备料（白色） 1.已备料（绿色） 2.缺料（红色） 3.其他（灰色）
                        if (ptstatus.Equals("1"))
                            dgvRequisitionMain.Rows[i].DefaultCellStyle.BackColor = Color.Lime;//已备料（绿色） 
                        if (ptstatus.Equals("2"))
                            dgvRequisitionMain.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;//缺/少料（红色）Tomato
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //双击单元格触发
        private void dgvRequisitionMain_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ////获取当前选中单元格中 
                //string PmOrderCode = dgvRequisitionMain.SelectedRows[0].Cells["pm_orderCode"].Value.ToString();
                //string PpOrderCode = dgvRequisitionMain.SelectedRows[0].Cells["pp_orderCode"].Value.ToString();
                //string PmStatus = dgvRequisitionMain.SelectedRows[0].Cells["pm_status"].Value.ToString();
                //if (string.IsNullOrEmpty(PmOrderCode))
                //    throw new Exception("获取当前行信息失败！");
                ////MessageBox.Show(PmOrderCode);

                //FrmPmsRequisitionDetail f = new FrmPmsRequisitionDetail(PmOrderCode, PpOrderCode, PmStatus);//打开备料明细界面
                //f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// 单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRequisitionMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    //说明点击的列是DataGridViewButtonColumn列
                    DataGridViewColumn column = dgvRequisitionMain.Columns[e.ColumnIndex];
                    if (column is DataGridViewButtonColumn)
                    {
                        if (column.Name == "btnRequisitionDetail")
                        {
                            if (dgvRequisitionMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "配料明细")
                            {
                                string PtOrderCode = dgvRequisitionMain.SelectedRows[0].Cells["pt_orderCode"].Value.ToString();
                                string PpOrderCode = dgvRequisitionMain.SelectedRows[0].Cells["pp_orderCode"].Value.ToString();
                                string PtStatus = dgvRequisitionMain.SelectedRows[0].Cells["pt_status"].Value.ToString();
                                string PtOperationID = dgvRequisitionMain.SelectedRows[0].Cells["pt_operationID"].Value.ToString();
                                if (string.IsNullOrEmpty(PtOrderCode))
                                    MessageBox.Show("获取当前行信息失败！");

                                using (var f = new FrmPmsRequisitionDetail(PtOrderCode, PpOrderCode, PtStatus, PtOperationID))//打开备料明细界面
                                {
                                    f.ShowDialog();
                                    if (f.DialogResult == DialogResult.OK)
                                    {
                                        //重新绑定
                                        BindData();
                                    }
                                    f.Dispose();
                                }


                            }
                        }

                        //if (column.Name == "btnreject")
                        //{
                        //    if (dgvRequisitionMain.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "驳回")
                        //    {
                        //        string PmOrderCode = dgvRequisitionMain.SelectedRows[0].Cells["pm_orderCode"].Value.ToString();
                        //        string PpOrderCode = dgvRequisitionMain.SelectedRows[0].Cells["pp_orderCode"].Value.ToString();
                        //        if (string.IsNullOrEmpty(PmOrderCode))
                        //            throw new Exception("获取当前行信息失败！");
                        //        FrmReject f = new FrmReject(PmOrderCode, PpOrderCode);//打开驳回界面
                        //        f.ShowDialog();
                        //        if (f.DialogResult == DialogResult.OK)
                        //        {
                        //            //重新绑定
                        //            BindData();
                        //        }
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        //查询事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void txtPmorderCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BindData();
            }
        }


        void Query(object sender, EventArgs e)
        {
            BindData();
        }


        private void FrmPmsRequisitionMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
