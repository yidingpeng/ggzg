using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Sys;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Common;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Test;

namespace RW.PMS.BLL
{
    internal class BLL_Follow : IBLL_Follow
    {

        private IDAL_Follow _DAL = null;

        public BLL_Follow()
        {
            _DAL = DIService.GetService<IDAL_Follow>();
        }


        #region 条码卡关联设置

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseBarcodeModel> GetFollowBarcodeForPage(BaseBarcodeModel model, out int totalCount)
        {
            return _DAL.GetFollowBarcodeForPage(model, out totalCount);
        }

        /// <summary>
        /// 获取条形码类型
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetCardType()
        {
            return _DAL.GetCardType();
        }

        /// <summary>
        /// 条形码修改绑定
        /// </summary>
        /// <param name="Id">信息表Id</param>
        /// <returns></returns>
        public BaseBarcodeModel GetFollowBarcodeId(int Id)
        {
            return _DAL.GetFollowBarcodeId(Id);
        }

        /// <summary>
        /// 返回英文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceCharAZ(string str, out string number)
        {
            string old = "";
            number = "0";
            char[] carr = str.ToCharArray();
            for (int i = 0; i < carr.Length; i++)
            {
                if (Regex.IsMatch(carr[i].ToString(), "[A-Z]"))
                {
                    old += carr[i].ToString();
                }
                else
                {
                    number += carr[i];
                }
            }
            return old;
        }

        public void AddFollowBarcodeManyCard(BaseBarcodeModel model)
        {
            _DAL.AddFollowBarcodeManyCard(model);
        }

        /// <summary>
        /// 判断条形码是否存在
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public bool GetSelectCard(string CardNo)
        {
            return _DAL.GetSelectCard(CardNo);
        }

        /// <summary>
        /// 添加条形码信息
        /// </summary>
        /// <param name="model"></param>
        public void AddFollowBarcode(BaseBarcodeModel model)
        {
            _DAL.AddFollowBarcode(model);
        }

        /// <summary>
        /// 条形码信息修改
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowBarcode(BaseBarcodeModel model)
        {
            _DAL.EditFollowBarcode(model);
        }

        /// <summary>
        /// 删除条形码信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFollowBarcode(string id)
        {
            _DAL.DeleteFollowBarcode(id);
        }

        #endregion

        #region 信息反馈管理 WZQ

        /// <summary>
        /// 信息反馈分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<FollowAbnormalModel> GetPagingFollowFeedback(FollowAbnormalModel model, out int totalCount)
        {
            return _DAL.GetPagingFollowFeedback(model, out totalCount);
        }

        /// <summary>
        /// 信息反馈子表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<FeedbackDetailModel> GetFeedbackDetail(FeedbackDetailModel model)
        {
            return _DAL.GetFeedbackDetail(model);
        }

        /// <summary>
        /// 信息反馈管理修改绑定
        /// </summary>
        /// <param name="Id">信息反馈表Id</param>
        /// <returns></returns>
        public FollowFeedbackModel GetFollowFeedbackId(int Id)
        {
            return _DAL.GetFollowFeedbackId(Id);
        }

        public FollowAbnormalModel GetFollowAbnormalId(int Id)
        {
            return _DAL.GetFollowAbnormalId(Id);
        }


        public bool SelectAGVstate(int areaID, int gwID, int operID)
        {
            return _DAL.SelectAGVstate(areaID, gwID, operID);
        }

        /// <summary>
        /// 信息反馈管理修改
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowFeedback(FollowFeedbackModel model)
        {
            _DAL.EditFollowFeedback(model);
        }

        /// <summary>
        /// 异常反馈管理修改
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowAbnormal(FollowAbnormalModel model)
        {
            _DAL.EditFollowAbnormal(model);
        }

        #endregion


        #region 条码卡使用记录查询 WZQ
        /// <summary>
        /// 条码卡使用记录查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<FollowBarcodeLogModel> getFollowBarcodeLogForPage(FollowBarcodeLogModel model, out int totalCount)
        {
            return _DAL.getFollowBarcodeLogForPage(model, out totalCount);
        }

        #endregion

        #region 试验报表信息查看 WZQ
        /// <summary>
        /// 试验报表信息查看
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TestResultMainModel> GetProductTestForPage(TestResultMainModel model, out int totalCount)
        {
            return _DAL.GetProductTestForPage(model, out totalCount);
        }

        public List<TestResultDetailModel> GetTestResultDetailForPage(TestResultDetailModel model, out int totalCount)
        {
            return _DAL.GetTestResultDetailForPage(model, out totalCount);
        }

        /// <summary>
        /// 根据ID获取试验报表信息
        /// </summary>
        /// <param name="Id">试验报表ID</param>
        /// <returns></returns>
        //public ProductTestModel GetProductTestId(int Id)
        //{
        //    return _DAL.GetProductTestId(Id);
        //}

        #endregion

        #region 操作异常
        /// <summary>
        /// 操作异常查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorModelPage(OperateErrorModel model, out int totalCount)
        {
            return _DAL.GetOperateErrorModelPage(model, out totalCount);
        }

        #region 故障统计报表
        public List<HitchModel> GetHitchModelPage(HitchModel model, out int totalCount)
        {
            return _DAL.GetHitchModelPage(model, out totalCount);
        }
        /// <summary>
        /// 获取故障情况（饼图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<HitchModel> GetHitchCircle(string Starttime, string Endtime)
        {
            return _DAL.GetHitchCircle(Starttime, Endtime);
        }

        /// <summary>
        /// 获取故障情况（折线图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<HitchModel> GetHitchLine(string Starttime, string Endtime)
        {
            return _DAL.GetHitchLine(Starttime, Endtime);
        }

        /// 获取故障情况（柱状图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<HitchModel> GetHitchPillar(string Starttime, string Endtime)
        {
            return _DAL.GetHitchPillar(Starttime, Endtime);
        }
        #endregion

        /// <summary>
        /// 获取异常情况（饼图）
        /// </summary>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorCircle(string Starttime, string Endtime)
        {
            return _DAL.GetOperateErrorCircle(Starttime, Endtime);
        }
        /// <summary>
        /// 获取异常情况（折线图）
        /// </summary>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorLine(string Starttime, string Endtime)
        {
            return _DAL.GetOperateErrorLine(Starttime, Endtime);
        }

        /// 获取异常情况（柱状图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        public List<OperateErrorModel> GetOperateErrorPillar(string Starttime, string Endtime)
        {
            return _DAL.GetOperateErrorPillar(Starttime, Endtime);
        }

        #endregion

        #region 故障报修 WZQ
        /// <summary>
        /// 故障报修分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<FollowFaultRepairModel> GetFollowFaultRepairForPage(FollowFaultRepairModel model, out int totalCount)
        {
            return _DAL.GetFollowFaultRepairForPage(model, out totalCount);
        }

        /// <summary>
        /// 故障报修根据ID获取数据
        /// </summary>
        /// <param name="Id">故障报修表Id</param>
        /// <returns></returns>
        public FollowFaultRepairModel GetFollowFaultRepairId(int Id)
        {
            return _DAL.GetFollowFaultRepairId(Id);
        }

        /// <summary>
        /// 修改故障报修信息
        /// </summary>
        /// <param name="model"></param>
        public void EditFollowFaultRepair(FollowFaultRepairModel model)
        {
            _DAL.EditFollowFaultRepair(model);
        }
        #endregion

        #region 电机产品信息查询

        /// <summary>
        /// 生产产品信息 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfoList(ProductInfoModel model) { return _DAL.GetProductInfoList(model); }

        #endregion

        #region CS端

        #region 信息反馈
        /// <summary>
        /// 查询反馈
        /// </summary>
        /// <param name="fbareaID">区域</param>
        /// <param name="fbgwID">工位</param>
        /// <param name="fboperID">用户</param>
        /// <returns></returns>
        public List<FollowFeedbackModel> GetFollowfeedback(int fbareaID, int fbgwID, int fboperID)
        {
            return _DAL.GetFollowfeedback(fbareaID, fbgwID, fboperID);
        }

        public List<FollowAbnormalModel> GetFollowAbnormal(int fbareaID, int fbgwID, int fboperID)
        {
            return _DAL.GetFollowAbnormal(fbareaID, fbgwID, fboperID);
        }

        /// <summary>
        /// APP保存信息反馈
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertFeeback(FollowFeedbackModel model)
        {
            return _DAL.InsertFeeback(model);
        }

        /// <summary>
        /// 保存信息反馈
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddFollow_Feedback(FollowFeedbackModel model)
        {
            return _DAL.AddFollow_Feedback(model);
        }

        /// <summary>
        /// 保存异常反馈
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddFollow_Abnormal(FollowAbnormalModel model)
        {
            return _DAL.AddFollow_Abnormal(model);
        }
        /// <summary>
        /// 修改程序信息
        /// </summary>
        /// <param name="program"></param>
        public bool UpdateFollow_Feedback(FollowFeedbackModel model)
        {
            return _DAL.UpdateFollow_Feedback(model);
        }
        /// <summary>
        /// 修改异常反馈信息
        /// </summary>
        /// <param name="program"></param>
        public bool UpdateFollow_Abnormal(FollowAbnormalModel model)
        {
            return _DAL.UpdateFollow_Abnormal(model);
        }
        /// <summary>
        /// 删除信息反馈
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteFollow_Feedback(int id)
        {
            return _DAL.DeleteFollow_Feedback(id);
        }

        public bool SelectAGVstateId(int id)
        {
            return _DAL.SelectAGVstateId(id);
        }

        /// <summary>
        /// 删除信息反馈
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteFollow_Abnormal(int id)
        {
            return _DAL.DeleteFollow_Abnormal(id);
        }

        #endregion

        #region 故障报修
        /// <summary>
        /// 故障报修绑定数据
        /// </summary>
        /// <param name="IP">IP</param>
        /// <returns></returns>
        public List<FollowFaultRepairModel> GetFollowFaultRepair(string IP)
        {
            return _DAL.GetFollowFaultRepair(IP);
        }

        /// <summary>
        /// 新增故障报修
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddFollow_FaultRepair(FollowFaultRepairModel model)
        {
            return _DAL.AddFollow_FaultRepair(model);
        }
        /// <summary>
        /// 修改故障报修信息
        /// </summary>
        /// <param name="program"></param>
        public bool UpdateFollow_FaultRepair(FollowFaultRepairModel model)
        {
            return _DAL.UpdateFollow_FaultRepair(model);
        }

        /// <summary>
        /// 删除故障报修信息
        /// </summary>
        /// <param name="id">主表ID</param>
        public bool DeleteFollow_FaultRepair(int id)
        {
            return _DAL.DeleteFollow_FaultRepair(id);
        }

        #endregion


        /// <summary>
        /// 根据卡号获取卡表信息
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public BaseBarcodeModel GetBarcodeByCardNo(string cardNo)
        {
            return _DAL.GetBarcodeByCardNo(cardNo);
        }

        /// <summary>
        /// 获取发货区数据
        /// </summary>
        /// <param name="pf_prodNo">生产编号</param>
        /// <param name="ProdModelID">产品型号</param>
        /// <param name="pf_carModelID">车型</param>
        /// <param name="fp_repairTypeID">检修类型</param>
        /// <param name="fm_curAreaID">当前区域</param>
        /// <param name="fm_finishStatus">追溯状态</param>
        /// <param name="isSend">是否发货</param>
        /// <returns></returns>
        public List<FollowProductSendModel> GetFollowProductSendData(string pf_prodNo, int ProdModelID, int pf_carModelID, int fp_repairTypeID, int fm_curAreaID, int fm_finishStatus, int fm_isSend)
        {
            return _DAL.GetFollowProductSendData(pf_prodNo, ProdModelID, pf_carModelID, fp_repairTypeID, fm_curAreaID, fm_finishStatus, fm_isSend);
        }
        /// <summary>
        /// 修改发货信息
        /// </summary>
        /// <param name="fm_guid"></param>
        /// <param name="EmpId"></param>
        /// <returns></returns>
        public bool UpdateSend(FollowProductSendModel model)
        {
            return _DAL.UpdateSend(model);
        }


        /// <summary>
        /// 检验卡类型及
        /// </summary>
        /// <param name="cardNo">条码卡号</param>
        /// <param name="isWlBox">是否物料框</param>
        /// <param name="fbEnty">出参：条码卡实体</param>
        /// <param name="msg">返回消息</param>
        /// <returns></returns>
        public bool CheckCardType(string cardNo, string isWlBox, out BaseBarcodeModel fbEnty, out string msg)
        {
            msg = "";
            //fbEnty = GetCardNoInfo(cardNo);

            fbEnty = null;

            ////验证条形码是否可用
            //if (fbEnty == null || fbEnty.c_status == 1)
            //{
            //    msg = "卡号已经使用，或不存在！";
            //    return false;
            //}
            ////判断卡号类型，如果是物料类型，则要带出物料名称和是否是物料框信息
            ////大部件组件则判断是否是物料框就可以了

            //if (fbEnty.bdvalue == "1")//物料框类型
            //{
            //    if (isWlBox != "0") //不等于大部件类型；
            //    {
            //        return true;
            //    }
            //    //不能是大部件类型；
            //    msg = "请扫入物料框的条形码！";
            //    return false;
            //}
            ////部件条码类型
            //if (fbEnty.bdvalue != isWlBox)
            //{
            //    msg = "该条形码不是部件条码！";
            //    return false;
            //}
            return true;
        }

        public string ReplacementBarCode(BaseBarcodeModel oldModel, BaseBarcodeModel newModel)
        {
            return _DAL.ReplacementBarCode(oldModel, newModel);
        }
        #endregion
 
    }
}
