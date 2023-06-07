using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Follow;
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
    public partial class FrmCreateProd : Form
    {
        private IBLL_ProductInfo _prodInfoBll = DIService.GetService<IBLL_ProductInfo>();
        private int ProdModelId;
        public int prodId;

        public FrmCreateProd(int prodModelId)
        {
            InitializeComponent();
            this.ProdModelId = prodModelId;
            this.txtProdNo.SelectAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //表单验证数据
            if (!FrmValidation())
            {
                return;
            }

            //保存产品信息
            ProductInfoModel prodInfo = new ProductInfoModel() { pf_ID = 0, pf_prodNo = txtProdNo.Text.Trim(), pf_prodModelID = ProdModelId };

            int newProdId = _prodInfoBll.SaveProductInfo(prodInfo, PublicVariable.CurEmpID);
            prodId = newProdId;

            DialogResult = DialogResult.OK;
            this.Close();
        }

        public bool FrmValidation()
        {
            this.labTip.Text = "";
            this.labTip.Visible = true;

            if (string.IsNullOrWhiteSpace(txtProdNo.Text))
            {
                this.labTip.Text = "提示：请输入产品编码";
                this.txtProdNo.SelectAll();
                return false;
            }

            var prod = _prodInfoBll.GetProductInfoByProdNo(txtProdNo.Text);
            if (prod != null)
            {
                this.labTip.Text = "当前产品编号已存在";
                return false;
            }

            return true;
        }
    }
}
