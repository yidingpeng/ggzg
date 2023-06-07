using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Plan;
using System;
using System.Collections.Generic;

namespace RW.PMS.IBLL
{
    public interface IBLL_Plan : IDependence
    {

        #region 出勤模式表


        void AddWorkMode(BaseWorkModeModel model);
        void DeleteWorkMode(string id);
        bool GetWorkModetWmName(string wmName);
        void EditWorkMode(BaseWorkModeModel model);
        List<BaseWorkModeModel> GetPagingWorkMode(BaseWorkModeModel model, out int totalCount);
        BaseWorkModeModel GetWorkModetId(int Id);


        #endregion

        #region 生产日历

        List<BaseProductionCalendarModel> GetPagingProductionCalendar(BaseProductionCalendarModel model, out int totalCount);

        void AddProductionCalendar(BaseProductionCalendarModel model);

        void EditProductionCalendar(BaseProductionCalendarModel model);

        void DeleteProductionCalendar(string id);

        List<BaseWorkModeModel> GetWorkModeAll();

        List<TableBindModel> GetTableBind(string tablename);

        #endregion

        #region 计划管理
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PlanProdModel> GetPlanProdList(PlanProdModel model, out int totalCount);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<PlanProdModel> GetPlanProdList(PlanProdModel model = null);

        /// <summary>
        /// 获取计划明细集合
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<PlanDetailModel> GetPlanDetailList(PlanDetailModel model = null);

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SavePlan(PlanProdModel model);

        /// <summary>
        /// 修改计划明细表车厢号
        /// </summary>
        /// <param name="ID">计划明细ID</param>
        /// <param name="strNewValue">新车厢号</param>
        /// <returns>受影响行数</returns>
        int EditPlanDetailCompartNo(int ID, string strNewValue);

        /// <summary>
        /// 修改计划明细表转向架号
        /// </summary>
        /// <param name="ID">计划明细ID</param>
        /// <param name="strNewValue">新转向架号</param>
        /// <returns>受影响行数</returns>
        int EditPlanDetailBogieNo(int ID, string strNewValue);

        /// <summary>
        /// 保存电机编号
        /// </summary>
        /// <param name="model">计划明细实体类</param>
        /// <returns>返回消息</returns>
        string SaveProdNo(PlanDetailModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeletePlan(Guid id);
        #endregion

        #region 配件计划管理

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanModel> GetPartPlanList(PartPlanModel model, out int totalCount);

        /// <summary>
        /// 保存配件计划主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SavePartPlan(PartPlanModel model);



        List<PartPlanModel> GetPartPlanList(PartPlanModel model);


        /// <summary>
        /// 配件计划下发操作
        /// </summary>
        /// <param name="pp_orderCode">计划订单编码</param>
        int IssuedPartPlan(string pp_orderCode, int UserID);


        /// <summary>
        /// 更改计划状态 ，用于计划装配 开始 和 结束
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <param name="UserID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        int UpdatePartPlan(string pp_orderCode, int UserID, int status);


        /// <summary>
        /// 计划状态修改（计划下达）（反下达）操作
        /// </summary>
        /// <param name="pp_orderCode">计划订单号</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="status">修改状态  0: 未开始  1:已下发 2: 已开始 3：已完成 4：已驳回</param>
        /// <param name="Message">返回消息</param>
        /// <returns></returns>
        int IssuedPartPlan(string pp_orderCode, int UserID, int status, out string Message);

        /// <summary>
        /// 保存配件计划主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SaveCopyPlan(PartPlanModel model);

        /// <summary>
        ///逻辑删除 计划、计划工序、计划备料
        /// </summary>
        /// <param name="ids"></param>
        int DeletePartPlan(string[] ids);

        #endregion

        #region 配件计划工序管理

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanTechnicsModel> GetPartPlanTechnicsList(PartPlanTechnicsModel model, out int totalCount);


        /// <summary>
        /// 保存配件计划工序表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SavePartPlanTechnics(PartPlanTechnicsModel model);

        /// <summary>
        /// 配件计划工序管理查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanTechnicsModel> GetPartPlanTechnicsList(PartPlanTechnicsModel model);


        /// <summary>
        /// 配件计划工序详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanTechnicsModel> GetPartPlanTechnicsSelctList(PartPlanTechnicsModel model, out int totalCount);

        /// <summary>
        ///逻辑删除 计划工序以及工序下所有计划备料
        /// </summary>
        /// <param name="ids"></param>
        int DeletePlanTechnics(string[] ids);

        #endregion

        #region 配件计划备料管理

        /// <summary>
        /// 配件计划备料管理 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model, out int totalCount);

        /// <summary>
        /// 配件计划备料管理 查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model);

        /// <summary>
        /// 保存配件计划备料表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SavePartPlanStock(PartPlanStockModel model);


        /// <summary>
        /// 配件计划备料详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanStockModel> GetPartPlanStockSelctList(PartPlanStockModel model, out int totalCount);

        /// <summary>
        /// 逻辑删除 计划备料
        /// </summary>
        /// <param name="ids">计划备料单据编号</param>
        void DeletePlanstock(string[] ids);

        /// <summary>
        /// 通用修改备料 申请单状态
        /// </summary>
        /// <param name="model">part_planstock 子表明细</param>
        /// <param name="pt_status">part_planTechnics 主表状态</param>
        /// <returns></returns>
        int SaveTechnicsStockDetail(List<PartPlanStockModel> model, string pt_orderCode, int pt_status);

        #endregion

        #region 计划排程管理 2020-04-07

        /// <summary>
        /// 计划排程分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<PartPlanModel> GetPartPlanScheduleList(PartPlanModel model, out int totalCount);

        /// <summary>
        /// 手动排程计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SortPartPlan(List<PartPlanModel> model, string pp_orderCode);

        #endregion

        #region 齐套分析配置

        /// <summary>
        /// 获取齐套物料配置信息列表
        /// </summary>
        /// <param name="prodModelID"></param>
        /// <param name="mCode"></param>
        /// <returns></returns>
        List<BundleAnalysisMaterialConfigModel> GetBundleAnalysisMaterialConfigList(BundleAnalysisMaterialConfigModel model);

        /// <summary>
        /// 获取齐套物料配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BundleAnalysisMaterialConfigModel GetBundleAnalysisMaterialConfigList(int id);

        /// <summary>
        /// 保存齐套物料配置
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        int SaveBundleAnalysisMaterialConfig(BundleAnalysisMaterialConfigModel model, out string Message);

        /// <summary>
        /// 删除齐套物料配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteBundleAnalysisMaterialConfig(int id);

        /// <summary>
        /// 获取齐套物料配置信息列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<BundleAnalysisMaterialConfigModel> GetBundleAnalysisMaterialConfigList(BundleAnalysisMaterialConfigModel model, out int totalCount);

        /// <summary>
        /// 修改阀值
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="threshold">阀值</param>
        void UpdateThreshold(int ID, int threshold);

        #endregion

        #region 计划执行情况


        /// <summary>
        /// 产品完成情况按车型车号汇总
        /// </summary>
        /// <returns></returns>
        List<ProductInfoModel> GetProductExecutiveCondition(ProductInfoModel model, out int totalCount);

        /// <summary>
        /// 父子表
        /// </summary>
        /// <returns></returns>
        List<ProductInfoModel> GetProductinfo(ProductInfoModel model);


        #endregion

        #region MO
        List<MOModel> GetPagingMOList(MOModel model, out int totalCount);
        List<MOModel> GetMOList(MOModel model);
        int SaveMO(MOModel model);
        int DeleteMO(MOModel model);
        #endregion
        #region 排产
        string ScheduleSave(List<PlanProdModel> modelList);
        #endregion
    }
}
