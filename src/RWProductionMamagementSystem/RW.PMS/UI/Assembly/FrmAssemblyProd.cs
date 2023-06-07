using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.InComming;
using RW.PMS.Model.Sys;

namespace RW.PMS.WinForm.UI.Assembly
{
    /// <summary>
    /// 产品录入窗体-装配管理系统用
    /// </summary>
    public partial class FrmAssemblyProd : Form
    {
        private IBLL_BaseInfo _baseBLL = DIService.GetService<IBLL_BaseInfo>();
        private IBLL_System _systemBLL = DIService.GetService<IBLL_System>();
        private IBLL_Follow _followBLL = DIService.GetService<IBLL_Follow>();
        private IBLL_InComming _inCommingBLL = DIService.GetService<IBLL_InComming>();
        private bool _isEdit = false;
        private InCommingModel _inCommingModel = null;
        public int? ProductInfo_ID
        {
            get;
            private set;
        }

        /// <summary>
        /// 生产主表Guid
        /// </summary>
        public Guid? Follow_production_guid
        {
            get;
            private set;
        }
        public FrmAssemblyProd()
        {
            InitializeComponent();
        }
        private void FrmAssemblyProd_Load(object sender, EventArgs e)
        {
            var prodModels = _baseBLL.GetProductModel();
            prodModels.Insert(0, new Model.BaseInfo.BaseProductModelModel
            {
                ID = 0,
                Pmodel = "请选择"
            });
            cmbProdModel.DataSource = prodModels;
            cmbProdModel.DisplayMember = "Pmodel";
            cmbProdModel.ValueMember = "ID";

            var carNoModels = _systemBLL.GetBaseDataTypeValue("subwayType");
            carNoModels.Insert(0, new Model.Sys.BaseDataModel
            {
                ID = 0,
                bdname = "请选择"
            });
            cmbCarModel.DataSource = carNoModels;
            cmbCarModel.DisplayMember = "Bdname";
            cmbCarModel.ValueMember = "ID";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCarModel.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("选选择【车型】！");
                    cmbCarModel.Focus();
                    return;
                }
                if (cmbProdModel.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("选选择【产品型号】！");
                    cmbProdModel.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtProdNo.Text.Trim()))
                {
                    MessageBox.Show("【产品编号】不能为空！");
                    txtProdNo.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtBarcode.Text.Trim()))
                {
                    MessageBox.Show("【条码卡号】不能为空！");
                    return;
                }


                var cardModel = cmbCarModel.SelectedItem as BaseDataModel;
                var prodModel = cmbProdModel.SelectedItem as BaseProductModelModel;

                if (_isEdit)
                {
                    #region 编辑
                    var productInfoModel = new ProductInfoModel
                    {
                        pf_ID = _inCommingModel.pf_ID,
                        pf_prodNo = txtProdNo.Text.Trim(),
                        pf_prodID = prodModel.PID.Value,
                        pf_prodModelID = prodModel.ID,
                        pf_carModelID = cardModel.ID,
                        pf_date = dtpDate.Value,
                        pf_remark = txtRemark.Text.Trim(),
                        //pf_weight = txtWeight.Text.Trim(),
                        pf_carNo = txtCardNo.Text.Trim(),
                        pf_factoryID = 0,
                        pf_compressor = "0",
                        pf_groupNo = "0",
                        pf_orderNo = "0",
                        pf_stampNo = "0",
                    };

                    var followProductionModel = new FollowProductionModel
                    {
                        fp_guid = _inCommingModel.fp_guid ?? Guid.Empty,
                        fp_prodNo_sys = _inCommingModel.fp_prodNo_sys,
                        fp_repairTypeID = _inCommingModel.fp_repairTypeID ?? 0,
                        fp_finishStatus = 0,
                        fp_resultIsOK = -1,
                        fp_resultMemo = "",
                        fp_report = new byte[0],
                        fp_remark = "",
                        fp_uploadFlag = 0,
                    };
                    var followDetailModel = new FollowDetailModel
                    {
                        fd_guid = _inCommingModel.fd_guid,
                        fgw_guid = _inCommingModel.fgw_guid,
                        fm_guid = _inCommingModel.fm_guid,
                        fp_guid = _inCommingModel.fp_guid,
                        fd_componentId = 0,
                        fd_componentName = "",
                        fd_gwID = PublicVariable.CurGwID,
                        fd_gwName = PublicVariable.CurGwName,
                        fd_areaID = PublicVariable.CurAreaID,
                        fd_areaName = PublicVariable.CurAreaName,
                        fd_barcode = _inCommingModel.fd_barcode,
                        fd_wuliaoLJid = _inCommingModel.fd_wuliaoLJid,
                        fd_wuliaoLJName = _inCommingModel.fd_wuliaoLJName,
                        fd_isWuliaoBox = 0,
                        fd_stampNo = _inCommingModel.fd_stampNo,
                        fd_operID = PublicVariable.CurEmpID,
                        fd_oper = PublicVariable.CurEmpName,
                        fd_followStatus = 0,
                        fd_checkResult = -1,
                        fd_resultQty = 0,
                        fd_resultMemo = "",
                        fd_isNextScan = 0,
                        fd_isCancel = 0,
                        fd_remark = "",
                        fd_uploadFlag = 0,
                    };
                    _inCommingBLL.UpadteFollowMain(productInfoModel, followProductionModel, followDetailModel);
                    ProductInfo_ID = productInfoModel.pf_ID;
                    Follow_production_guid = followProductionModel.fp_guid;
                    #endregion
                }
                else
                {
                    var msg = string.Empty;
                    var barcodeModel = default(BaseBarcodeModel);
                    var check = _inCommingBLL.CheckCardType(txtBarcode.Text.Trim(), "0", out barcodeModel, out msg);
                    if (!check)
                    {
                        MessageBox.Show(msg);
                        return;
                    }
                    msg = string.Empty;
                    check = _inCommingBLL.ExistsProdNoByMsg(txtProdNo.Text.Trim(), out  msg);
                    if (!check)
                    {
                        MessageBox.Show(msg);
                        return;
                    }
                    #region 添加
                    var productionInfo = new ProductInfoModel
                    {
                        pf_prodNo = txtProdNo.Text.Trim(),
                        pf_prodID = prodModel.PID.Value,
                        pf_prodModelID = prodModel.ID,
                        pf_carModelID = cardModel.ID,
                        pf_date = dtpDate.Value,
                        pf_remark = txtRemark.Text.Trim(),
                        //pf_weight = txtWeight.Text.Trim(),
                        pf_carNo = txtCardNo.Text.Trim(),
                        pf_factoryID = 0,
                        pf_compressor = "0",
                        pf_groupNo = "0",
                        pf_orderNo = "0",
                        pf_stampNo = "0",
                    };
                    var dateTime = PublicVariable.GetServerTime();
                    var followProduction = new FollowProductionModel
                    {
                        fp_guid = Guid.NewGuid(),
                        pp_guid = Guid.Empty,
                        fp_prodNo_sys = txtProdNo.Text.Trim() + dateTime.ToString("yyyyMM"),
                        fp_repairTypeID = 0,
                        fp_report = new byte[] { },
                        fp_resultIsOK = -1,
                        fp_resultMemo = string.Empty,
                        fp_startTime = PublicVariable.GetServerTime(),
                        fp_uploadFlag = 0,
                        fp_finishStatus = 0,
                        fp_remark = string.Empty
                    };
                    var followMain = new FollowMainModel
                    {
                        fm_guid = Guid.NewGuid(),
                        fm_finishStatus = 0,
                        fm_warehouse = "",
                        fm_isSend = 0,
                        fm_curAreaID = PublicVariable.CurAreaID,
                        fm_curGwID = PublicVariable.CurGwID,
                        fm_curGw = PublicVariable.CurGwName,
                        fm_creatorID = PublicVariable.CurEmpID,
                        fm_creator = PublicVariable.CurEmpName,
                        fm_resultIsOK = 0,
                        fm_resultMemo = string.Empty,
                        fm_remark = string.Empty,
                        fm_uploadFlag = 0
                    };
                    var followGw = new FollowGwModel
                    {
                        fgw_guid = Guid.NewGuid(),
                        fgw_gwID = PublicVariable.CurGwID,
                        fgw_gwName = PublicVariable.CurGwName,
                        fgw_areaID = PublicVariable.CurAreaID,
                        fgw_areaName = PublicVariable.CurAreaName,
                        fgw_operID = PublicVariable.CurEmpID,
                        fgw_oper = PublicVariable.CurEmpName,
                        fgw_followStatus = 1,
                        fgw_checkResult = 1,
                        fgw_resultMemo = "合格"
                    };

                    var followDetail = new FollowDetailModel
                    {
                        fd_guid = Guid.NewGuid(),
                        fd_componentId = 0,
                        fd_componentName = "",
                        fd_gwID = PublicVariable.CurGwID,
                        fd_gwName = PublicVariable.CurGwName,
                        fd_areaID = PublicVariable.CurAreaID,
                        fd_areaName = PublicVariable.CurAreaName,
                        fd_barcode = txtBarcode.Text.Trim(),
                        fd_wuliaoLJid = barcodeModel.id,
                        fd_wuliaoLJName = barcodeModel.c_cardTypeText,
                        fd_isWuliaoBox = 0,
                        fd_stampNo = "",
                        fd_operID = PublicVariable.CurEmpID,
                        fd_oper = PublicVariable.CurEmpName,
                        fd_followStatus = 1,
                        fd_checkResult = 1,
                        fd_resultQty = 0,
                        fd_resultMemo = "",
                        fd_isNextScan = 0,//下一区域扫码状态：0未扫；1已扫
                        fd_isCancel = 0,
                        fd_remark = "",
                        fd_uploadFlag = 0,
                    };
                    ProductInfo_ID = _inCommingBLL.AddFollow(productionInfo, followProduction, followMain, followGw, followDetail, followProduction.pp_guid);
                    Follow_production_guid = followProduction.fp_guid;
                    #endregion
                }

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetProd()
        {
            _isEdit = false;
            _inCommingModel = _inCommingBLL.GetInCommingByFmGuid(string.Empty, txtProdNo.Text.Trim(), txtBarcode.Text.Trim());
            if (_inCommingModel != null && _inCommingModel.fm_finishStatus == 0 && _inCommingModel.fd_areaID == PublicVariable.CurAreaID)
            {
                _isEdit = true;
                txtBarcode.Text = _inCommingModel.fd_barcode;
                txtCardNo.Text = _inCommingModel.pf_carNo;
                txtProdNo.Text = _inCommingModel.pf_prodNo;
                cmbCarModel.SelectedValue = _inCommingModel.pf_carModelID;
                cmbProdModel.SelectedValue = _inCommingModel.pf_prodModelID;
                dtpDate.Value = _inCommingModel.pf_date.Value;
                txtRemark.Text = _inCommingModel.pf_remark;
            }
        }
        private void txtProdNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetProd();
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                GetProd();
            }
        }
    }
}
