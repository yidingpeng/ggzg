using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.WinForm.Common;
using System;
using System.Windows.Forms;
using baseinfoentity = RW.PMS.Model.BaseInfo;

namespace RW.PMS.WinForm.UI.Follow
{
    /// <summary>
    /// 换卡窗体-绑卡窗体
    /// </summary>
    public partial class FrmFollowBarcode : Form
    {
        /// <summary>
        /// 产品信息表ID
        /// </summary>
        private int pf_ID { get; set; }

        /// <summary>
        /// 换卡-绑卡
        /// </summary>
        public FrmFollowBarcode(int pf_ID = 0)
        {
            InitializeComponent();
            this.pf_ID = pf_ID;
            if (pf_ID == 0)
            {
                this.Text = "换卡";//标题赋值
                this.lbOld.Visible = true;//显示旧卡号录入框
                this.txtOld.Visible = true;
                this.btnSave.Text = "更换";
            }
            else
            {
                this.Text = "绑卡";//标题赋值
                this.lbNew.Text = "卡号：";
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
                if (this.pf_ID == 0)
                {
                    #region 换卡
                    string newid = this.txtNew.Text.Trim().ToUpper();
                    string oldid = this.txtOld.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(newid) || string.IsNullOrEmpty(oldid))
                        throw new Exception("请扫描新卡号及旧卡号!");
                    if (newid == oldid)
                        throw new Exception("请勿扫描重复卡号!");
                    KeyPressEventArgs args = new KeyPressEventArgs((char)Keys.Enter);
                    var oldModel = BarCodeCheck(args, txtOld, null);
                    var newModel = BarCodeCheck(args, txtNew, null);
                    if (oldModel.c_cardType != newModel.c_cardType)
                        throw new Exception("卡类型不一致,请扫描相同类型的卡进行更换!");

                    if (MessageBox.Show("确定要将[" + oldid + "]卡更换为[" + newid + "]卡吗？", "温馨提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;

                    oldModel.c_operID = PublicVariable.CurEmpID;
                    newModel.c_operID = PublicVariable.CurEmpID;
                    IBLL_Follow Followbll = DIService.GetService<IBLL_Follow>();
                    string strMsg = Followbll.ReplacementBarCode(oldModel, newModel);
                    if (!string.IsNullOrEmpty(strMsg))
                        throw new Exception(strMsg);
                    RWMessageBox.Show("保存成功！");
                    this.DialogResult = DialogResult.OK;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 旧条码卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOld_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                var oldModel = BarCodeCheck(e, txtOld, txtNew);
                if (oldModel != null && oldModel.c_status == 0)
                    throw new Exception("[" + txtOld.Text.Trim() + "未绑定部件,请扫描正确的条形码");
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 新条码卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                BarCodeCheck(e, txtNew, btnSave);
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 条码检查
        /// </summary>
        /// <param name="e"></param>
        /// <param name="txt"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        private BaseBarcodeModel BarCodeCheck(KeyPressEventArgs e, TextBox txt, Control control = null)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    string strBarCode = txt.Text.Trim();
                    if (string.IsNullOrEmpty(strBarCode))
                        return null;
                    IBLL_BaseInfo bll = DIService.GetService<IBLL_BaseInfo>();
                    var list = bll.GetBarCodeList(new BaseBarcodeModel() { c_cardNo = strBarCode });
                    if (list.Count == 0)
                        throw new Exception("[" + strBarCode + "]为未知条码卡号,请重新扫码!");
                    if (control != null)
                        control.Focus();
                    return list[0];
                }
            }
            catch (Exception ex)
            {
                txt.Text = string.Empty;
                throw ex;
            }
            return null;
        }
    }
}
