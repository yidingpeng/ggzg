using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Follow
{
    public partial class FrmProModelEdit : Form
    {
        private string frm_actionType = "";
        private int frm_ID = 0;
        private static IBLL_BaseInfo BLL = DIService.GetService<IBLL_BaseInfo>();
        private static IBLL_BaseInfo BLLBseInfo = DIService.GetService<IBLL_BaseInfo>();

        public FrmProModelEdit(string _actionType, int ID)
        {
            InitializeComponent();
            BingDDLformula();
            frm_actionType = _actionType;
            frm_ID = ID;
        }


        private void FrmProModelEdit_Load(object sender, EventArgs e)
        {
            if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                BaseProductModelModel model = BLL.GetBaseProductModelId(frm_ID);
                txtProMode.Text = model.Pmodel;
                txtTorque.Text = model.tighteningTorque;
                txtRemark.Text = model.remark;
                cmbFormula.SelectedValue = model.formulaCode.ToInt();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtProMode.Text.Trim()) && !string.IsNullOrEmpty(this.txtTorque.Text.Trim()) && cmbFormula.SelectedValue == null || ConvertHelper.ToInt32(cmbFormula.SelectedValue, 0) == 0)
            {
                MessageBox.Show("产品型号、配方编号和拧紧力矩不能为空！");
                return;
            }
            if (frm_actionType == EDAEnums.ActionType.Add.ToString())
            {
                BaseProductModelModel model = new BaseProductModelModel()
                {
                    Pmodel = txtProMode.Text.Trim(),
                    tighteningTorque = txtTorque.Text.Trim(),
                    remark = txtRemark.Text.Trim(),
                    Pstatus = 0,
                    formulaCode = cmbFormula.SelectedValue.ToString()
                };
                BLL.AddBaseProductModel(model);

                MessageBox.Show("保存成功！");
                this.DialogResult = DialogResult.OK;
            }
            else if (frm_actionType == EDAEnums.ActionType.Edit.ToString())
            {
                BaseProductModelModel model = new BaseProductModelModel()
                {
                    ID = Convert.ToInt32(frm_ID),
                    Pmodel = txtProMode.Text.Trim(),
                    tighteningTorque = txtTorque.Text.Trim(),
                    remark = txtRemark.Text.Trim(),
                    Pstatus = 0,
                    formulaCode = cmbFormula.SelectedValue.ToString()
                };

                BLL.EditBaseProductModel(model);

                MessageBox.Show("修改成功！");
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BingDDLformula()
        {
            try
            {
                var data = BLLBseInfo.GetFormula(null, 0);
                cmbFormula.DataSource = data;
                cmbFormula.DisplayMember = "formulaCode";
                cmbFormula.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("配方编号绑定失败！" + ex.Message);
            }
        }
    }
}
