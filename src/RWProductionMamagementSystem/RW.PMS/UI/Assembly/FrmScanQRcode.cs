using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using System;
using System.Windows.Forms;

namespace RW.PMS.WinForm
{
    /// <summary>
    /// 扫码窗体
    /// </summary>
    public partial class FrmScanQRcode : Form
    {
        #region 变量
        IBLL_Assembly dal = DIService.GetService<IBLL_Assembly>();
        IBLL_Follow _followBLL = DIService.GetService<IBLL_Follow>();

        /// <summary>
        /// 窗体类型：0:组装工位扫码; 1:总装工位扫产品编码；2：扫订单号；3：扫工具编码；4：扫物料编码
        /// 5:总装工位扫物料编码,要判断物料编码是否存在，存在才能继续, 不存在不能继续
        /// 6:总装工位扫大部件组件条形码，要判断工位条形码是否存在，存在才能继续
        /// 7:Mitutoyo内径检测仪结果数值
        /// 8:扭力扳手手写结果数值
        /// </summary>
        string formType = "";

        /// <summary>
        /// 值比较类型
        /// </summary>
        string EqualTypeName = "";

        /// <summary>
        /// 最小值
        /// </summary>
        string minvalue = "";

        /// <summary>
        /// 最大值
        /// </summary>
        string maxvalue = "";

        /// <summary>
        /// 目标值 标准值
        /// </summary>
        string standardValue = "";

        /// <summary>
        /// 是否要求原拆原配，若是，则物料条码、组件条码要判断产品编号
        /// </summary>
        int isOriginalDismantling = 0;

        /// <summary>
        /// 产品编号，用来判断物料盒、大部件的条码绑定的prodno是否一致，保证追溯系统的原拆原配
        /// 窗体返回值，每扫一次物料框都查出来并返回
        /// </summary>
        public FollowMainModel frm_fmEnty = null;

        /// <summary>
        /// 扫到的二维码
        /// </summary>
        public string gwScanRQcode = string.Empty;

        /// <summary>
        /// 扫入值
        /// </summary>
        public string strValue = string.Empty;
        #endregion

        #region 构造函数

        /// <summary>
        /// 扫码窗体 构造函数
        /// </summary>
        /// <param name="_formType"></param>
        /// <param name="_EqualTypeName"></param>
        /// <param name="_minvalue"></param>
        /// <param name="_maxvalue"></param>
        /// <param name="_standardValue"></param>
        /// <param name="_isOriginalDismantling"></param>
        /// <param name="_fmEntity"></param>
        public FrmScanQRcode(string _formType, string _EqualTypeName, string _minvalue, string _maxvalue, string _standardValue, int _isOriginalDismantling, FollowMainModel _fmEntity)
        {
            InitializeComponent();

            formType = _formType;
            EqualTypeName = _EqualTypeName;
            minvalue = _minvalue;
            maxvalue = _maxvalue;
            standardValue = _standardValue;
            isOriginalDismantling = _isOriginalDismantling;
            frm_fmEnty = _fmEntity;
            this.ControlBox = false;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_formType"></param>
        /// <param name="_toolModel"></param>
        /// <param name="_isOriginalDismantling"></param>
        /// <param name="_fmEntity"></param>
        public FrmScanQRcode(string _formType, ProGJValModel _toolModel, int _isOriginalDismantling, FollowMainModel _fmEntity)
        {
            InitializeComponent();

            formType = _formType;
            EqualTypeName = _toolModel.EqualTypeName;
            minvalue = _toolModel.MinValue;
            maxvalue = _toolModel.MaxValue;
            standardValue = _toolModel.StandardValue;
            isOriginalDismantling = _isOriginalDismantling;
            frm_fmEnty = _fmEntity;
            this.ControlBox = false;
        }
        #endregion

        #region 关闭按钮
        //关闭按钮
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        //文本框键入事件
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    gwScanRQcode = this.txtValue.Text.Trim().ToUpper();
                    if (string.IsNullOrEmpty(gwScanRQcode))
                        return;
                    strValue = this.txtValue.Text.Trim();

                    #region 验证
                    lbTit.Text = string.Empty;
                    lbTit.Visible = false;
                    /*窗体类型：
                     * 0 组装/总装区域工位扫工位条形码; 
                     * 1 总装工位扫产品编码；
                     * 2 扫订单号；
                     * 3 扫工具编码； 
                     * 4 组装工位扫物料编码；
                     * 5 总装工位扫物料编码 
                     * 6 总装工位扫大部件组件条形码，要判断工位条形码是否存在,判断成功后回到主界面上要更新大部件条形码所属的工位表的FP_GUID
                     * 7 Mitutoyo内径检测仪结果数值
                     **/
                    switch (formType)
                    {
                        case "0":
                            #region 组装工位扫码,要判断条形码是否不存在，不能存在
                            if (isOriginalDismantling == 1)//原拆原配，工位条形码规则：产品编号_二维码
                            {
                                BaseBarcodeModel fbar = _followBLL.GetBarcodeByCardNo(gwScanRQcode);
                                if (fbar == null)
                                {
                                    ShowMsg("未知条码卡号!");
                                    return;
                                }
                                if (fbar.c_status == 1)
                                {
                                    ShowMsg("不可重复绑定条码卡号已有绑定!");
                                    return;
                                }

                                if (frm_fmEnty != null)//追溯系统的工位二维码规则：产品编号_条码卡号_工位ID
                                    gwScanRQcode = frm_fmEnty.fp_prodNo_sys + "_" + gwScanRQcode + "_" + PublicVariable.CurGwID.ToString();
                                else
                                {
                                    ShowMsg("未获取到产品编号");
                                    return;
                                }
                            }
                            else//非原拆原配，即纯装配管理系统
                            {
                                //gwScanRQcode;
                            }


                            if (dal.IsExistGwBarcode(gwScanRQcode) == true)//条码已存在
                            {
                                ShowMsg("二维码已存在");
                                return;
                            }
                            this.DialogResult = DialogResult.OK;

                            #endregion
                            break;
                        case "3":
                            #region 比较工具是否包含，即工装比较
                            if (!string.IsNullOrEmpty(EqualTypeName))
                            {
                                //比较工装是否在世包含内
                                if (EqualTypeName == EDAEnums.GjEqualType.Include.ToString())
                                {

                                    if (gwScanRQcode == minvalue || gwScanRQcode == maxvalue || gwScanRQcode == standardValue)
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                    else
                                    {
                                        ShowMsg(lblQRcode.Text + "扫入不合格");
                                        return;
                                    }
                                }
                            }
                            #endregion
                            break;
                        case "4":
                            #region 组装工位扫物料编码,要判断物料编码是否不存在，已存在则不允许继续，不存在才能继续
                            //4:组装工位扫物料编码,要判断物料编码是否不存在，已存在则不允许继续，不存在才能继续
                            if (isOriginalDismantling == 1)//要求原拆原配
                            {
                                bool compare = compareProdNo(gwScanRQcode);
                                if (compare == false)
                                {
                                    MessageBox.Show("产品编码不一致！");
                                    return;
                                }
                                else
                                {
                                    if (frm_fmEnty != null)
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                }
                            }
                            //非原拆原配
                            if (isOriginalDismantling == 0 && dal.IsExistWlCode(gwScanRQcode) == true)//物料编码已存在
                            {
                                ShowMsg("组件物料编码已存在");
                                return;
                            }
                            #endregion
                            break;
                        case "5":
                            #region 总装工位扫物料编码,要判断物料编码是否存在，存在才能继续, 不存在不能继续
                            if (isOriginalDismantling == 1)//要求原拆原配
                            {
                                bool compare = compareProdNo(gwScanRQcode);
                                if (compare == false)
                                {
                                    MessageBox.Show("产品编码不一致！");
                                    return;
                                }
                                else
                                {
                                    if (frm_fmEnty != null)
                                    {
                                        this.DialogResult = DialogResult.OK;
                                    }
                                }
                            }

                            if (isOriginalDismantling == 0 && dal.IsExistWlCode(gwScanRQcode) == false)//物料编码不存在
                            {
                                ShowMsg("组件物料编码不存在");
                                return;
                            }

                            #endregion
                            break;
                        case "6":
                            #region 总装工位扫大部件组件条形码，要判断工位条形码是否存在，存在才能继续
                            if (dal.IsExistGwBarcode(gwScanRQcode) == false)//条码不存在
                            {
                                ShowMsg("二维码不存在");
                                return;
                            }

                            #endregion
                            break;
                        default:
                            break;
                    }
                    #endregion

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private bool compareProdNo(string cardNo)
        {
            try
            {
                #region 验证卡号的当前的产品编号是否与窗体传进来的一致，若不一致则返回false，并且赋值给窗体的prodNo

                bool iscompare = _followBLL.IsCompareProdNo(cardNo, ref frm_fmEnty);

                return iscompare;

                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void ShowMsg(string msg)
        {
            lbTit.Text = msg;
            lbTit.Visible = true;
        }
    }
}
