using RW.PMS.Common;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Test;

namespace RW.PMS.IBLL
{
    public interface IBLL_Follow : IDependence
    {
        void AddFollowBarcode(BaseBarcodeModel model);
        void AddFollowBarcodeManyCard(BaseBarcodeModel model);
        void DeleteFollowBarcode(string id);
        void EditFollowBarcode(BaseBarcodeModel model);
        void EditFollowFeedback(FollowFeedbackModel model);
        void EditFollowAbnormal(FollowAbnormalModel model);
        List<BaseDataModel> GetCardType();
        List<BaseBarcodeModel> GetFollowBarcodeForPage(BaseBarcodeModel model, out int totalCount);
        BaseBarcodeModel GetFollowBarcodeId(int Id);
        List<FollowBarcodeLogModel> getFollowBarcodeLogForPage(FollowBarcodeLogModel model, out int totalCount);
        FollowFeedbackModel GetFollowFeedbackId(int Id);

        FollowAbnormalModel GetFollowAbnormalId(int Id);
        List<FollowAbnormalModel> GetPagingFollowFeedback(FollowAbnormalModel model, out int totalCount);

        /// <summary>
        /// 信息反馈子表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<FeedbackDetailModel> GetFeedbackDetail(FeedbackDetailModel model);

        List<TestResultMainModel> GetProductTestForPage(TestResultMainModel model, out int totalCount);

        List<TestResultDetailModel> GetTestResultDetailForPage(TestResultDetailModel model, out int totalCount);

        bool GetSelectCard(string CardNo);
        List<FollowFeedbackModel> GetFollowfeedback(int fbareaID, int fbgwID, int fboperID);

        List<FollowAbnormalModel> GetFollowAbnormal(int fbareaID, int fbgwID, int fboperID);

        /// <summary>
        /// APP保存信息反馈
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool InsertFeeback(FollowFeedbackModel model);

        bool SelectAGVstate(int areaID, int gwID, int operID);


        bool AddFollow_Feedback(FollowFeedbackModel model);
        bool AddFollow_Abnormal(FollowAbnormalModel model);
        bool UpdateFollow_Feedback(FollowFeedbackModel model);
        bool UpdateFollow_Abnormal(FollowAbnormalModel model);
        bool DeleteFollow_Feedback(int id);

        bool SelectAGVstateId(int id);

        bool DeleteFollow_Abnormal(int id);

        /// <summary>
        /// 故障报修分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<FollowFaultRepairModel> GetFollowFaultRepairForPage(FollowFaultRepairModel model, out int totalCount);

        /// <summary>
        /// 故障异常查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<OperateErrorModel> GetOperateErrorModelPage(OperateErrorModel model, out int totalCount);

        #region 故障统计报表
        List<HitchModel> GetHitchModelPage(HitchModel model, out int totalCount);
        /// <summary>
        /// 获取故障情况（饼图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        List<HitchModel> GetHitchCircle(string Starttime, string Endtime);
        /// <summary>
        /// 获取故障情况（折线图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        List<HitchModel> GetHitchLine(string Starttime, string Endtime);

        /// 获取故障情况（柱状图）
        /// </summary>
        /// /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        List<HitchModel> GetHitchPillar(string Starttime, string Endtime);
        #endregion

        /// <summary>
        /// 操作异常查询(饼图)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<OperateErrorModel> GetOperateErrorCircle(string Starttime, string Endtime);

        /// <summary>
        /// 获取异常情况（折线图）
        /// </summary>
        /// <returns></returns>
        List<OperateErrorModel> GetOperateErrorLine(string Starttime, string Endtime);

        /// 获取异常情况（柱状图）
        /// </summary>
        /// <param name="Starttime">开始时间</param>
        /// <param name="Endtime">结束时间</param>
        /// <returns></returns>
        List<OperateErrorModel> GetOperateErrorPillar(string Starttime, string Endtime);


        /// <summary>
        /// 修改故障报修信息
        /// </summary>
        /// <param name="model"></param>
        void EditFollowFaultRepair(FollowFaultRepairModel model);

        /// <summary>
        /// 故障报修根据ID获取数据
        /// </summary>
        /// <param name="Id">故障报修表Id</param>
        /// <returns></returns>
        FollowFaultRepairModel GetFollowFaultRepairId(int Id);

        /// <summary>
        /// 故障报修绑定数据
        /// </summary>
        /// <param name="IP">IP</param>
        /// <returns></returns>
        List<FollowFaultRepairModel> GetFollowFaultRepair(string IP);

        /// <summary>
        /// 新增故障报修
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        bool AddFollow_FaultRepair(FollowFaultRepairModel model);

        /// <summary>
        /// 修改故障报修信息
        /// </summary>
        /// <param name="program"></param>
        bool UpdateFollow_FaultRepair(FollowFaultRepairModel model);

        /// <summary>
        /// 删除故障报修信息
        /// </summary>
        /// <param name="id">主表ID</param>
        bool DeleteFollow_FaultRepair(int id);
       
        /// <summary>
        /// 根据卡号获取卡表信息
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        BaseBarcodeModel GetBarcodeByCardNo(string cardNo);

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
        List<FollowProductSendModel> GetFollowProductSendData(string pf_prodNo, int ProdModelID, int pf_carModelID, int fp_repairTypeID, int fm_curAreaID, int fm_finishStatus, int fm_isSend);

        /// <summary>
        /// 修改发货信息
        /// </summary>
        /// <param name="fm_guid"></param>
        /// <param name="EmpId"></param>
        /// <returns></returns>
        bool UpdateSend(FollowProductSendModel model);

        /// <summary>
        /// 检验卡类型及
        /// </summary>
        /// <param name="cardNo">条码卡号</param>
        /// <param name="isWlBox">是否物料框</param>
        /// <param name="fbEnty">出参：条码卡实体</param>
        /// <param name="msg">返回消息</param>
        /// <returns></returns>
        bool CheckCardType(string cardNo, string isWlBox, out BaseBarcodeModel fbEnty, out string msg);

        /// <summary>
        /// 更换条码卡信息
        /// </summary>
        /// <param name="oldModel">老卡实体</param>
        /// <param name="newModel">新卡实体</param>
        /// <returns>msg</returns>
        string ReplacementBarCode(BaseBarcodeModel oldModel, BaseBarcodeModel newModel);

        #region 电机产品信息查询

        /// <summary>
        /// 生产产品信息 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ProductInfoModel> GetProductInfoList(ProductInfoModel model);

        #endregion

      

    }
}
