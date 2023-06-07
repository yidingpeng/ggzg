using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Plan;
using RW.PMS.Utils;
using RW.PMS.WinForm.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Assembly
{
    public partial class FrmPmsRequisitionDetail : FormSkin
    {
        string PtOrderCodeStr;
        string PpOrderCodeStr;
        string PtStatusStr;//用于判断按钮是否禁用
        string PtOperationIDstr;

        private string frm_empID = PublicVariable.CurEmpID.ToString();
        private string frm_empName = PublicVariable.CurEmpName.ToString();
        private string frm_gwID = PublicVariable.CurGwID.ToString();
        private string frm_gwname = PublicVariable.CurGwName.ToString();
        private string frm_areaID = PublicVariable.CurAreaID.ToString();
        private string frm_areaName = PublicVariable.CurAreaName.ToString();
        IBLL_BaseInfo BLL = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Plan PlanBLL = DIService.GetService<IBLL_Plan>();

        public FrmPmsRequisitionDetail(string PtOrderCode, string PpOrderCode, string PtStatus, string PtOperationID)
        {
            InitializeComponent();
            //关闭自动绑定列
            this.dgvRequisitionDetail.AutoGenerateColumns = false;
            PtOrderCodeStr = PtOrderCode;
            PpOrderCodeStr = PpOrderCode;
            PtStatusStr = PtStatus;
            PtOperationIDstr = PtOperationID;

            this.txtPmorderCode.Text = PtOrderCode;
            this.txtPporderCode.Text = PpOrderCode;

        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPmsRequisitionDetail_Load(object sender, EventArgs e)
        {
            BindData();
        }


        /// <summary>
        /// 绑定
        /// </summary>
        public void BindData()
        {
            try
            {
                //List<PmsRequisitionDetailModel> RequisitionDetail = BLL.GetPmsRequisitionDetailList(
                //    new PmsRequisitionDetailModel()
                //    {
                //        LIKEpd_materialCode = txtmaterialCode.Text.Trim(),
                //        LIKEpd_materialName = txtmaterialName.Text.Trim(),
                //        pm_orderCode = PmOrderCodeStr
                //    });

                List<PartPlanStockModel> RequisitionDetail = PlanBLL.GetPartPlanStockList(
                           new PartPlanStockModel()
                           {
                               pp_orderCode = PpOrderCodeStr,
                               ps_operationID = PtOperationIDstr.ToInt(),
                               LIKEps_materialCode = txtmaterialCode.Text.Trim(),
                               LIKEps_materialName = txtmaterialName.Text.Trim()
                           });
                this.dgvRequisitionDetail.DataSource = RequisitionDetail;
                for (int i = 0; i < RequisitionDetail.Count; i++)
                {
                    if (RequisitionDetail[i].ps_status.HasValue)
                    {
                        string status = RequisitionDetail[i].ps_status.ToString();
                        //物料状态：状态 0.未备料（白色） 1.已备料（绿色） 2.缺料（红色） 3.其他（灰色）
                        if (status.Equals("1"))
                            dgvRequisitionDetail.Rows[i].DefaultCellStyle.BackColor = Color.Lime;//已备料（绿色） 
                        //dgvRequisitionDetail.Rows[i].Cells["col_wlCheck"].Value = "1";//选中checkbox
                        //dgvRequisitionDetail.Rows[i].ReadOnly = true;

                        if (status.Equals("2"))
                            dgvRequisitionDetail.Rows[i].DefaultCellStyle.BackColor = Color.Tomato;//缺料（红色）Tomato
                        //dgvRequisitionDetail.Rows[i].DefaultCellStyle.BackColor = Color.CornflowerBlue;//已确认（蓝色）CornflowerBlue、DodgerBlue

                        if (status.Equals("3"))
                            dgvRequisitionDetail.Rows[i].DefaultCellStyle.BackColor = Color.DarkGray;//其他（灰色）Gray
                    }
                }

                if (!string.IsNullOrEmpty(PtStatusStr))
                {
                    //状态 0:未配料 1:已配料 2:缺/少配料
                    if (PtStatusStr == "1")
                    {
                        //隐藏保存按钮状态
                        this.btnSave.Visible = false;
                        this.btnCancel.Location = new System.Drawing.Point(723, 28);
                        //this.button1.Visible = true;
                        //取消已备料勾选
                        this.rdoIsMaterial.Checked = false;
                    }
                    if (PtStatusStr == "0" || PtStatusStr == "2")
                    {
                        //取消隐藏保存按钮状态
                        this.btnSave.Visible = true;
                        //隐藏查看绑定产品编码按钮
                        //this.button1.Visible = false;
                        //取消已备料勾选
                        this.rdoIsMaterial.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 双击勾选checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRequisitionDetail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvRequisitionDetail.CurrentRow.ReadOnly == false && dgvRequisitionDetail.CurrentRow.Cells["col_wlCheck"].ReadOnly == false)
                {
                    if (dgvRequisitionDetail.CurrentRow.Cells["col_wlCheck"].Value == null || dgvRequisitionDetail.CurrentRow.Cells["col_wlCheck"].Value.ToString() == "0")
                        dgvRequisitionDetail.CurrentRow.Cells["col_wlCheck"].Value = "1";
                    else
                        dgvRequisitionDetail.CurrentRow.Cells["col_wlCheck"].Value = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 全选按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCheckAll.Checked)
            {
                foreach (DataGridViewRow dgvr in this.dgvRequisitionDetail.Rows)
                {
                    if (dgvr.Cells["col_wlCheck"].ReadOnly == false)
                    {
                        dgvr.Cells["col_wlCheck"].Value = "1";
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow dgvr in this.dgvRequisitionDetail.Rows)
                {
                    if (dgvr.Cells["col_wlCheck"].ReadOnly == false)
                    {
                        dgvr.Cells["col_wlCheck"].Value = "0";
                    }
                }
            }

        }


        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
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
                //物料状态：状态 0.未备料（白色） 1.已备料（绿色） 2.缺料（红色） 3.其他（灰色）
                int MaterialStatus = 0;
                if (rdoIsMaterial.Checked == true)//已备料
                    MaterialStatus = 1;
                if (rdoLackMaterial.Checked == true)//缺料
                    MaterialStatus = 2;
                if (rdoQtMaterial.Checked == true)//其他
                    MaterialStatus = 3;

                List<PartPlanStockModel> detaillist = new List<PartPlanStockModel>();
                int checkcout = 0;
                int checkIscout = 0;
                foreach (DataGridViewRow dgvr in dgvRequisitionDetail.Rows)
                {
                    if (dgvr.Cells["col_wlCheck"].Value != null && dgvr.Cells["col_wlCheck"].Value.ToString() == "1")
                    {
                        PartPlanStockModel detail = new PartPlanStockModel();
                        detail.ps_orderCode = dgvr.Cells["ps_orderCode"].Value.ToString();
                        detail.ps_remark = (dgvr.Cells["ps_remark"].Value == null ? "" : dgvr.Cells["ps_remark"].Value.ToString());
                        detail.ps_updateMan = ConvertHelper.ToInt32(frm_empID, 0);
                        detail.ps_status = MaterialStatus;
                        detaillist.Add(detail);
                        if (MaterialStatus == 1) 
                            checkIscout++;
                        checkcout++;
                    }
                }

                if (detaillist.Count <= 0 && checkcout <= 0)
                {
                    RWMessageBox.Show("请至少选择一项再操作保存！");
                    return;
                }

                if (rdoIsMaterial.Checked == false && rdoLackMaterial.Checked == false && rdoQtMaterial.Checked == false)
                {
                    RWMessageBox.Show("请选择一种物料状态再操作保存！");
                    return;
                }

                if (MessageBox.Show("是否提交配料明细信息？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                int status = 0;
                //如果当前备料子表中还能查询到状态为 0.未备料 2.缺/少料 3.其他 用于判断物料是否已全部备齐 , paraStr = "0,2,3"
                List<PartPlanStockModel> Lists = PlanBLL.GetPartPlanStockList(new PartPlanStockModel() { pp_orderCode = PpOrderCodeStr, ps_operationID = PtOperationIDstr.ToInt() });
                if (Lists.Count > checkIscout)
                    status = 2;
                if (Lists.Count == checkIscout)
                    status = 1;

                //Part_PlanTechnics 主表状态改为 已备料
                int ret = PlanBLL.SaveTechnicsStockDetail(detaillist, PtOrderCodeStr, status);
                if (ret > 0)
                {
                    BindData();
                    MessageBox.Show("保存成功！");
                    //if (status == 0)
                    //{
                    //    if (MessageBox.Show("备料还未齐套是否需要进行产品编码关联设置？", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    //    {
                    //        BindProdNo();
                    //    }
                    //}
                    //else
                    //{
                    //    BindProdNo();
                    //}
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void FrmPmsRequisitionDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Dispose(true);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            //列强制转换
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[i].Name.ToString());
                dt.Columns.Add(dc);
            }
            //循环行
            for (int j = 0; j < dgv.Rows.Count; j++)
            {
                DataRow dr = dt.NewRow();
                for (int o = 0; o < dgv.Columns.Count; o++)
                {
                    dr[j] = Convert.ToString(dgv.Rows[o].Cells[j].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 编码回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtmaterialCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BindData();
            }
        }

        /// <summary>
        /// 名称回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtmaterialName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                BindData();
            }
        }
    }
}
