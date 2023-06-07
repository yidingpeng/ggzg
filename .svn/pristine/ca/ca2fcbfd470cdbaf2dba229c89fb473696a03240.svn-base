using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
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

namespace RW.PMS.WinForm.UI
{
    /// <summary>
    /// 部件条码绑定
    /// </summary>
    public partial class FrmPartBarCodeInput : Form
    {
        /// <summary>
        /// 产品信息ID
        /// </summary>
        int? productInfoID;

        /// <summary>
        /// 生产主表ID
        /// </summary>
        Guid? productionID;

        /// <summary>
        /// 产品型号ID
        /// </summary>
        int productModelID;

        /// <summary>
        /// 当前追溯主表实体
        /// </summary>
        FollowMainModel followMain = new FollowMainModel();

        /// <summary>
        /// 部件条码绑定窗体构造函数
        /// </summary>
        /// <param name="productInfoID"></param>
        /// <param name="productionID"></param>
        public FrmPartBarCodeInput(int? productInfoID = null, Guid? productionID = null)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            this.productInfoID = productInfoID;
            this.productionID = productionID;
        }

        #region 加载函数
        private void FrmPartBarCodeInput_Load(object sender, EventArgs e)
        {
            try
            {
                if (productInfoID == null || productionID == null) return;
                //根据产品信息ID获取产品信息
                IBLL_BaseInfo bll = DIService.GetService<IBLL_BaseInfo>();
                var pfList = bll.GetProductInfoList(new ProductInfoModel() { pf_ID = productInfoID.Value });
                if (pfList.Count == 0) return;
                txtProdNo.Text = pfList[0].pf_prodNo;
                txtProdModel.Text = pfList[0].Pmodel;
                txtBogieNo.Text = pfList[0].pf_bogieNo;
                txtCarModel.Text = pfList[0].carModel;
                this.productModelID = pfList[0].pf_prodModelID;

                //获取追溯主表ID
                IBLL_Follow bllF = DIService.GetService<IBLL_Follow>();
                var fmList = bllF.GetFMList(new FollowMainModel() { fp_guid = productionID.Value });
                if (fmList.Count == 0)
                {
                    RWMessageBox.Show("此生产主表未包含追溯信息!");
                    return;
                }
                this.followMain = fmList[0];

                BindData();//绑定数据
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            IBLL_BaseInfo bll = DIService.GetService<IBLL_BaseInfo>();
            //根据产品信息ID及当前工位ID,获取所有部件信息.
            int gwID = PublicVariable.CurGwID;
            if (gwID == 0) gwID = 90;
            var defList = bll.GetGWProdDefList(new BaseGwProdDefModel() { gwID = gwID, prodModelID = this.productModelID }).Where(_ => _.componentID.HasValue).ToList();
            if (defList.Count == 0)
                RWMessageBox.Show("此工位未找到此产品的关联部件,请检查系统配置信息!");
            //根据部件ID及追溯主表ID从条码卡表获取已绑条码卡信息并赋值已绑条码
            foreach (var item in defList)
            {
                int c_curComponentId = item.componentID.Value.ToInt();//部件ID
                var barCodelist = bll.GetBarCodeList(new BaseBarcodeModel() { c_curComponentId = c_curComponentId, c_curFmGuid = followMain.fm_guid });
                if (barCodelist.Count == 0) continue;
                item.c_id = barCodelist[0].id;//条码卡ID
                item.c_cardNo = barCodelist[0].c_cardNo;//条码卡号
                item.c_curStampNo = barCodelist[0].c_curStampNo;//部件编码
            }
            //绑定数据
            dgvData.DataSource = defList;
        }
        #endregion

        #region 关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 提交
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //检查是否条码都已绑定
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    int c_id = row.Cells["c_id"].Value.ToInt();//条码卡表ID
                    if (c_id == 0)
                        throw new Exception("有部件未绑定条码卡,请扫码进行绑定!");
                }

                #region 添加追溯信息
                //这里绑码和添加追溯记录非同一事务,可能会存在隐患
                IBLL_Follow bllFollow = DIService.GetService<IBLL_Follow>();
                DateTime NowTime = PublicVariable.GetServerTime();

                FollowGwModel followGw = new FollowGwModel();
                followGw.fgw_guid = Guid.NewGuid();
                followGw.fm_guid = followMain.fm_guid;
                followGw.fp_guid = followMain.fp_guid;
                followGw.pInfo_ID = followMain.pInfo_ID;
                followGw.fgw_gwID = PublicVariable.CurGwID;
                followGw.fgw_gwName = PublicVariable.CurGwName;
                followGw.fgw_areaID = PublicVariable.CurAreaID;
                followGw.fgw_areaName = PublicVariable.CurAreaName;
                followGw.fgw_operID = PublicVariable.CurEmpID;
                followGw.fgw_oper = PublicVariable.CurEmpName;
                followGw.fgw_starttime = NowTime;
                followGw.fgw_finishtime = null;
                followGw.fgw_followStatus = (int)EDAEnums.FollowStatus.notFinish;
                followGw.fgw_checkResult = (int)EDAEnums.FollowStatus.Non;
                followGw.fgw_resultMemo = "";
                followGw.fgw_remark = "";
                followGw.fgw_uploadFlag = 0;
                followGw.fgw_finishtime = NowTime;
                followGw.fgw_followStatus = (int)EDAEnums.FollowStatus.finished;
                followGw.fgw_checkResult = (int)EDAEnums.CheckResult.OK;
                followGw.fgw_resultMemo = EDAEnums.CheckResultMemo.Qualified.ToString();

                var detailList = new List<FollowDetailModel>();
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    FollowDetailModel followDetail = new FollowDetailModel();
                    followDetail.fd_guid = Guid.NewGuid();
                    followDetail.Fd_EditType = EDAEnums.ActionType.Add.ToString();
                    followDetail.fgw_guid = followGw.fgw_guid;
                    followDetail.fm_guid = followGw.fm_guid;
                    followDetail.pf_prodNo = followMain.pf_prodNo;
                    followDetail.pInfo_ID = followGw.pInfo_ID;
                    followDetail.fd_gwID = PublicVariable.CurGwID;
                    followDetail.fd_gwName = PublicVariable.CurGwName;
                    followDetail.fp_guid = followMain.fp_guid;
                    followDetail.fd_isWuliaoBox = 0;
                    followDetail.fd_isNextScan = 0;
                    followDetail.fd_areaID = PublicVariable.CurAreaID;
                    followDetail.fd_areaName = PublicVariable.CurAreaName;
                    followDetail.fd_componentId = row.Cells["componentID"].Value.ToInt();//部件ID colPartName
                    followDetail.fd_componentName = row.Cells["colPartName"].Value + "";
                    followDetail.fd_stampNo = row.Cells["colPartCode"].Value + "";
                    followDetail.fd_barcode = (row.Cells["colBarCode"].Value + "").ToUpper();
                    followDetail.fd_operID = PublicVariable.CurEmpID;
                    followDetail.fd_oper = PublicVariable.CurEmpName;
                    followDetail.fd_starttime = NowTime;
                    followDetail.fd_finishtime = NowTime;
                    followDetail.fd_followStatus = (int)EDAEnums.FollowStatus.finished; //完成状态
                    followDetail.fd_checkResult = (int)EDAEnums.CheckResult.OK; //检验结果
                    followDetail.fd_resultQty = 1;//检验数量
                    followDetail.fd_resultMemo = EDAEnums.CheckResultMemo.Qualified.ToString();
                    followDetail.fd_isCancel = 0;
                    followDetail.fd_uploadFlag = 0;
                    detailList.Add(followDetail);
                }

                followMain.fm_starttime = NowTime;
                followMain.fm_finishStatus = (int)EDAEnums.FollowStatus.notFinish;
                followMain.fm_curGwID = PublicVariable.CurGwID;
                followMain.fm_curGw = PublicVariable.CurGwName;
                followMain.fm_curAreaID = PublicVariable.CurAreaID;
                followMain.Fm_curArea = PublicVariable.CurAreaName;

                bool isOK = bllFollow.AddFollowGwAndDetail_UpdateMain(followGw, detailList, null, false, followMain);
                if (!isOK)
                    throw new Exception("添加追溯信息失败");
                #endregion

                //绑码完成
                RWMessageBox.Show("操作成功!");
                this.Close();
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 失去焦点事件

        private void dgvData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //无修改返回
                string curVal = dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "";//当前值
                string afterVal = e.FormattedValue + "";//将要修改值
                curVal = curVal.ToUpper();//转大写
                afterVal = afterVal.ToUpper();//转大写
                if (curVal == afterVal) return;
                string colName = dgvData.Columns[e.ColumnIndex].Name;
                if (colName != "colBarCode" && colName != "colPartCode") return;
                IBLL_BaseInfo bll = DIService.GetService<IBLL_BaseInfo>();
                int c_id = dgvData.Rows[e.RowIndex].Cells["c_id"].Value.ToInt();//条码卡表ID
                int componentID = dgvData.Rows[e.RowIndex].Cells["componentID"].Value.ToInt();//部件ID
                string partCode = dgvData.Rows[e.RowIndex].Cells["colPartCode"].Value + "";//部件ID

                #region 条码卡
                if (colName == "colBarCode")
                {
                    //有编辑判断是新增还是修改
                    if (c_id == 0)
                    {
                        #region 新增
                        //检查数据:条码卡号必须在条码卡表中存在
                        var list = bll.GetBarCodeList(new BaseBarcodeModel() { c_cardNo = afterVal });
                        if (list.Count == 0)
                            throw new Exception("[" + afterVal + "]为未知条码卡号,请重新扫码!");

                        //检查数据:条码卡号必须为未绑条码卡
                        list = list.Where(_ => _.c_curComponentId == null || _.c_curComponentId == 0).ToList();
                        if (list.Count == 0)
                            throw new Exception("[" + afterVal + "]此条码卡已绑定其他部件,请重新扫码!");
                        list[0].c_curAreaID = PublicVariable.CurAreaID;
                        list[0].c_curGwID = PublicVariable.CurGwID;
                        list[0].c_curFmGuid = followMain.fm_guid;
                        list[0].c_curProdNo = txtProdNo.Text;
                        list[0].c_curComponentId = componentID;//部件ID
                        list[0].c_curStampNo = partCode;//部件编码
                        list[0].c_pInfoID = productInfoID; //产品信息ID
                        list[0].c_operID = PublicVariable.CurEmpID; //绑码人ID
                        bll.BindBarCode(list[0]);
                        dgvData.Rows[e.RowIndex].Cells["c_id"].Value = list[0].id;
                        #endregion
                    }
                    else
                    {
                        #region 修改
                        //解绑
                        if (string.IsNullOrEmpty(afterVal))
                        {
                            string partName = dgvData.Rows[e.RowIndex].Cells["colPartName"].Value + "";//部件名称
                            if (MessageBox.Show("确定解绑[" + partName + "]的条码卡吗?", "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                                == System.Windows.Forms.DialogResult.Cancel)
                            {
                                e.Cancel = true;
                                return;
                            }
                            BaseBarcodeModel model = new BaseBarcodeModel();
                            model.id = c_id;
                            bll.BindBarCode(model);
                            dgvData.Rows[e.RowIndex].Cells["c_id"].Value = 0;
                        }
                        else
                        {
                            //检查数据:条码卡号必须在条码卡表中存在
                            var list = bll.GetBarCodeList(new BaseBarcodeModel() { c_cardNo = afterVal });
                            if (list.Count == 0)
                                throw new Exception("[" + afterVal + "]为未知条码卡号,请重新扫码!");
                            //检查数据:条码卡号必须为未绑条码卡
                            list = list.Where(_ => (_.c_curComponentId == null || _.c_curComponentId == 0) && _.id != c_id).ToList();
                            if (list.Count == 0)
                                throw new Exception("[" + afterVal + "]此条码卡已绑定其他部件,请重新扫码!");
                            //解绑
                            BaseBarcodeModel model = new BaseBarcodeModel();
                            model.id = c_id;
                            bll.BindBarCode(model);
                            //绑定
                            list[0].c_curAreaID = PublicVariable.CurAreaID;
                            list[0].c_curGwID = PublicVariable.CurGwID;
                            list[0].c_curFmGuid = followMain.fm_guid;
                            list[0].c_curProdNo = txtProdNo.Text;
                            list[0].c_curComponentId = componentID;//部件ID
                            list[0].c_curStampNo = partCode;//部件编码
                            list[0].c_pInfoID = productInfoID; //产品信息ID
                            list[0].c_operID = PublicVariable.CurEmpID; //绑码人ID
                            bll.BindBarCode(list[0]);
                            dgvData.Rows[e.RowIndex].Cells["c_id"].Value = list[0].id;
                        }
                        #endregion
                    }
                }
                #endregion

                #region 部件编码
                if (colName == "colPartCode")
                {
                    if (c_id == 0)
                        throw new Exception("请先绑定条码再进行部件编码录入!");

                    //检查数据:部件编码不能重复
                    var list = bll.GetBarCodeList(new BaseBarcodeModel() { c_curStampNo = afterVal, UnID = c_id });
                    if (list.Count > 0)
                        throw new Exception("[" + afterVal + "]部件编码已存在,请重新录入!");
                    list = bll.GetBarCodeList(new BaseBarcodeModel() { id = c_id });//根据ID获取条码卡
                    if (list.Count == 0)
                        throw new Exception("[" + c_id + "]条码卡ID查不到条码卡!");//不会出现此情况
                    list[0].c_curStampNo = afterVal;
                    bll.BindBarCode(list[0]);
                }
                #endregion
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
                e.Cancel = true;
                dgvData.CancelEdit();
            }
        }

        #endregion
    }
}
