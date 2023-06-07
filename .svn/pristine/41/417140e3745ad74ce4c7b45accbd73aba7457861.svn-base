using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Follow;
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
    public partial class FromPlanInput : FormSkin
    {
        /// <summary>
        /// 赋值产品编号
        /// </summary>
        public string ReturnValue1 { get; set; }

        /// <summary>
        /// 赋值选中的计划订单号
        /// </summary>
        public string ReturnValue2 { get; set; }

        /// <summary>
        /// 台车号
        /// </summary>
        public string wagonNo { get; set; }

        /// <summary>
        /// 提交验证码
        /// </summary>
        public int ReturnValue3 { get; set; }

        internal Func<string,string> CommitBtn = null;

        IBLL_Plan BLL = DIService.GetService<IBLL_Plan>();
        IBLL_ProductInfo ProductInfoBLL = DIService.GetService<IBLL_ProductInfo>();

        public FromPlanInput()
        {
            InitializeComponent();
            //关闭自动绑定列
            this.dgvPartPlanList.AutoGenerateColumns = false;
            this.dgvProductInfoList.AutoGenerateColumns = false;
        }

        private void FromPlanInput_Load(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定已下发的计划清单
        /// </summary>
        private void BindData()
        {
            try
            {
                List<PartPlanModel> PartPlanList = new List<PartPlanModel>();
                //List<PartPlanModel> item = BLL.GetPartPlanList(new PartPlanModel { }).OrderBy(x => x.pp_sort).Where(x => x.pp_status == 1 || x.pp_status == 2).ToList();
                List<PartPlanModel> PartPlan = BLL.GetPartPlanList(new PartPlanModel { }).OrderByDescending(x => x.pp_materialPercent).Where(x => x.pp_status == 2 || x.pp_status == 1).ToList();
                foreach (var item in PartPlan)
                {
                    item.pp_sort = PartPlan.IndexOf(item) + 1;
                    item.pp_materialPercentText = item.pp_materialPercent1 + "%";
                    PartPlanList.Add(item);
                }
                this.dgvPartPlanList.DataSource = PartPlanList;
                //默认选中优先级最高计划
                this.dgvPartPlanList.Rows[0].Cells["col_ppCheck"].Value = true;
                //获取默认第一行的计划
                string pp_orderCodeStr = dgvPartPlanList.Rows[0].Cells["pp_orderCode"].Value.ToString();
                //加载生产记录列表
                if (!string.IsNullOrEmpty(pp_orderCodeStr))
                {
                    List<ProductInfoModel> ProductInfoList = ProductInfoBLL.GetProductList(new ProductInfoModel { pp_orderCode = pp_orderCodeStr });
                    this.dgvProductInfoList.DataSource = ProductInfoList;
                    this.groupBox2.Text = ($"产品信息列表 数量：【{this.dgvPartPlanList.Rows[0].Cells["pp_planQty"].Value.ToString()}/{ProductInfoList.Count()}】");
                }

            }
            catch (Exception)
            {

            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        /// <summary>
        /// 启用单选CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPartPlanList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            for (int i = 0; i < dgvPartPlanList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkcell = (DataGridViewCheckBoxCell)dgvPartPlanList.Rows[i].Cells[0];
                checkcell.Value = false;
            }
            DataGridViewCheckBoxCell ifcheck = (DataGridViewCheckBoxCell)dgvPartPlanList.Rows[e.RowIndex].Cells[0];
            ifcheck.Value = true;

            //加载生产记录列表
            string pp_orderCodeStr = dgvPartPlanList.Rows[e.RowIndex].Cells["pp_orderCode"].Value.ToString();
            if (!string.IsNullOrEmpty(pp_orderCodeStr))
            {
                List<ProductInfoModel> ProductInfoList = ProductInfoBLL.GetProductList(new ProductInfoModel { pp_orderCode = pp_orderCodeStr });
                this.dgvProductInfoList.DataSource = ProductInfoList;
                this.groupBox2.Text = ($"产品信息列表 数量：【{this.dgvPartPlanList.Rows[e.RowIndex].Cells["pp_planQty"].Value.ToString()}/{ProductInfoList.Count()}】");
            }

        }
        
        private void txtprodNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        private string wagonNostr = string.Empty;

        /// <summary>
        /// 绑定提交事件
        /// </summary>
        public void Save()
        {

            if (string.IsNullOrEmpty(this.txtprodNo.Text.Trim()))
            {
                RWMessageBox.Show("产品序列号不能为空!");
                return;
            }

            if (CommitBtn != null)
            {
                var val = CommitBtn.Invoke(this.txtprodNo.Text.Trim());
                if (!string.IsNullOrEmpty(val))
                {
                    RWMessageBox.Show(val);
                    this.txtprodNo.Text = string.Empty;
                    return;
                }
            }

            //赋值产品编号
            this.ReturnValue1 = this.txtprodNo.Text.Trim();

            foreach (DataGridViewRow dgvr in dgvPartPlanList.Rows)
            {
                if (dgvr.Cells["col_ppCheck"].Value != null && Convert.ToBoolean(dgvr.Cells["col_ppCheck"].Value) == true)
                {
                    //赋值选中的计划订单号
                    this.ReturnValue2 = dgvr.Cells["pp_orderCode"].Value.ToString(); //example
                    wagonNostr = dgvr.Cells["pp_wagonNo"].Value.ToString();
                }
            }
            string Message = "";
            //返回类型: 1:未装配  2：已装配，是否重复装配  -1：当前产品编号选择了错误的计划
            int Result = ProductInfoBLL.GetProductInfoSaveStatus(ReturnValue1, ReturnValue2, out Message);
            if (Result == -1)
            {
                RWMessageBox.Show("该产品序列号已绑定了计划！订单号为：" + Message + "，请确认后重新选择计划！");
                return;
            }
            this.ReturnValue3 = Result;
            wagonNo = InitWagonNo(wagonNostr, ReturnValue2);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 计算 当前产品台车号
        /// </summary>
        /// <param name="str">计划台车号</param>
        /// <param name="pp_orderCode">计划流水号</param>
        /// <returns></returns>
        public string InitWagonNo(string str, string pp_orderCode)
        {
            var WagonNo = str.Split('-');
            var pfInfoCnt = ProductInfoBLL.GetProductInfo(pp_orderCode).Count();//获取
            int pfCnt = (int)Math.Floor(ConvertHelper.ToDecimal(pfInfoCnt / 2, 0));//计算已生产的受电弓整数
            return $"T{(ConvertHelper.ToInt32(WagonNo[0], 0) + pfCnt).ToString() + ((pfInfoCnt + 1) % 2 == 0 ? "-2" : "-1")}";
        }
        
        /// <summary>
        /// 绘图 生产记录列表序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProductInfoList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            foreach (DataGridViewRow row in dgvProductInfoList.Rows)
            {
                row.Cells[0].Value = row.Index + 1;
            }
            //SolidBrush b = new SolidBrush(this.dgvProductInfoList.RowHeadersDefaultCellStyle.ForeColor);
            //e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvProductInfoList.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
