using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Plan;
using System;
using System.Collections.Generic;

namespace RW.PMS.BLL
{
    internal class BLL_Plan : IBLL_Plan
    {
        private IDAL_Plan _DAL = null;

        public BLL_Plan()
        {
            _DAL = DIService.GetService<IDAL_Plan>();
        }


        #region 出勤模式表

        /// <summary>
        /// 出勤模式分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseWorkModeModel> GetPagingWorkMode(BaseWorkModeModel model, out int totalCount)
        {
            return _DAL.GetPagingWorkMode(model, out totalCount);
        }



        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">出勤模式表</param>
        public void AddWorkMode(BaseWorkModeModel model)
        {
            _DAL.AddWorkMode(model);
        }


        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">出勤模式表Id</param>
        /// <returns></returns>
        public BaseWorkModeModel GetWorkModetId(int Id)
        {
            return _DAL.GetWorkModetId(Id);
        }


        /// <summary>
        /// 根据出勤模式名称查询是否有相同名称
        /// </summary>
        /// <param name="wmName"></param>
        /// <returns></returns>
        public bool GetWorkModetWmName(string wmName)
        {
            return _DAL.GetWorkModetWmName(wmName);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditWorkMode(BaseWorkModeModel model)
        {
            _DAL.EditWorkMode(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorkMode(string id)
        {
            _DAL.DeleteWorkMode(id);
        }

        #endregion

        #region 计划管理
        public List<PlanProdModel> GetPlanProdList(PlanProdModel model, out int totalCount)
        {
            return _DAL.GetPlanProdList(model, out totalCount);
        }
        public List<PlanProdModel> GetPlanProdList(PlanProdModel model = null)
        {
            return _DAL.GetPlanProdList(model);
        }
        public List<PlanDetailModel> GetPlanDetailList(PlanDetailModel model = null)
        {
            return _DAL.GetPlanDetailList(model);
        }
        public int SavePlan(PlanProdModel model)
        {
            return _DAL.SavePlan(model);
        }
        public int EditPlanDetailCompartNo(int ID, string strNewValue)
        {
            return _DAL.EditPlanDetailCompartNo(ID, strNewValue);
        }
        public int EditPlanDetailBogieNo(int ID, string strNewValue)
        {
            return _DAL.EditPlanDetailBogieNo(ID, strNewValue);
        }
        public string SaveProdNo(PlanDetailModel model)
        {
            return _DAL.SaveProdNo(model);
        }
        public int DeletePlan(Guid id)
        {
            return _DAL.DeletePlan(id);
        }
        #endregion

        #region 生产日历

        public List<BaseProductionCalendarModel> GetPagingProductionCalendar(BaseProductionCalendarModel model, out int totalCount) { return _DAL.GetPagingProductionCalendar(model, out totalCount); }

        public void AddProductionCalendar(BaseProductionCalendarModel model) { _DAL.AddProductionCalendar(model); }

        public void EditProductionCalendar(BaseProductionCalendarModel model) { _DAL.EditProductionCalendar(model); }

        public void DeleteProductionCalendar(string id) { _DAL.DeleteProductionCalendar(id); }

        public List<BaseWorkModeModel> GetWorkModeAll() { return _DAL.GetWorkModeAll(); }

        public List<TableBindModel> GetTableBind(string tablename) { return _DAL.GetTableBind(tablename); }

        #endregion

        #region 配件计划管理

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanModel> GetPartPlanList(PartPlanModel model, out int totalCount)
        {
            return _DAL.GetPartPlanList(model, out totalCount);
        }


        /// <summary>
        /// 保存配件计划主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePartPlan(PartPlanModel model)
        {
            return _DAL.SavePartPlan(model);
        }

        public List<PartPlanModel> GetPartPlanList(PartPlanModel model)
        {
            return _DAL.GetPartPlanList(model);
        }


        /// <summary>
        /// 配件计划下发操作
        /// </summary>
        /// <param name="pp_orderCode">计划订单编码</param>
        public int IssuedPartPlan(string pp_orderCode, int UserID)
        {
            return _DAL.IssuedPartPlan(pp_orderCode, UserID);
        }


        /// <summary>
        /// 更改计划状态 ，用于计划装配 开始 和 结束
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <param name="UserID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdatePartPlan(string pp_orderCode, int UserID, int status)
        {
            return _DAL.UpdatePartPlan(pp_orderCode, UserID, status);
        }

        /// <summary>
        /// 计划状态修改（计划下达）（反下达）操作
        /// </summary>
        /// <param name="pp_orderCode">计划订单号</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="status">修改状态  0: 未开始  1:已下发 2: 已开始 3：已完成 4：已驳回</param>
        /// <param name="Message">返回消息</param>
        /// <returns></returns>
        public int IssuedPartPlan(string pp_orderCode, int UserID, int status, out string Message)
        {
            return _DAL.IssuedPartPlan(pp_orderCode, UserID, status, out Message);
        }


        /// <summary>
        /// 保存配件计划主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveCopyPlan(PartPlanModel model)
        {
            return _DAL.SaveCopyPlan(model);
        }

        /// <summary>
        /// 逻辑删除 计划、计划工序、计划备料
        /// </summary>
        /// <param name="ids"></param>
        public int DeletePartPlan(string[] ids)
        {
            return _DAL.DeletePartPlan(ids);
        }

        #endregion

        #region 配件计划工序管理

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanTechnicsModel> GetPartPlanTechnicsList(PartPlanTechnicsModel model, out int totalCount)
        {
            return _DAL.GetPartPlanTechnicsList(model, out totalCount);
        }

        /// <summary>
        /// 保存配件计划工序表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePartPlanTechnics(PartPlanTechnicsModel model)
        {
            return _DAL.SavePartPlanTechnics(model);
        }

        /// <summary>
        /// 配件计划工序管理查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanTechnicsModel> GetPartPlanTechnicsList(PartPlanTechnicsModel model)
        {
            return _DAL.GetPartPlanTechnicsList(model);
        }


        /// <summary>
        /// 配件计划工序详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanTechnicsModel> GetPartPlanTechnicsSelctList(PartPlanTechnicsModel model, out int totalCount)
        {
            return _DAL.GetPartPlanTechnicsSelctList(model, out totalCount);
        }


        /// <summary>
        ///逻辑删除 计划工序以及工序下所有计划备料
        /// </summary>
        /// <param name="ids"></param>
        public int DeletePlanTechnics(string[] ids)
        {
            return _DAL.DeletePlanTechnics(ids);
        }


        #endregion

        #region 配件计划备料管理

        /// <summary>
        /// 配件计划备料管理 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model, out int totalCount)
        {
            return _DAL.GetPartPlanStockList(model, out totalCount);
        }

        /// <summary>
        /// 配件计划备料管理 查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model)
        {
            return _DAL.GetPartPlanStockList(model);
        }

        /// <summary>
        /// 保存配件计划备料表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePartPlanStock(PartPlanStockModel model)
        {
            return _DAL.SavePartPlanStock(model);
        }


        /// <summary>
        /// 配件计划备料详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockSelctList(PartPlanStockModel model, out int totalCount)
        {
            return _DAL.GetPartPlanStockSelctList(model, out totalCount);
        }

        /// <summary>
        /// 逻辑删除 计划备料
        /// </summary>
        /// <param name="ids">计划备料单据编号</param>
        public void DeletePlanstock(string[] ids)
        {
            _DAL.DeletePlanstock(ids);
        }

        /// <summary>
        /// 通用修改备料 申请单状态
        /// </summary>
        /// <param name="model">part_planstock 子表明细</param>
        /// <param name="pt_status">part_planTechnics 主表状态</param>
        /// <returns></returns>
        public int SaveTechnicsStockDetail(List<PartPlanStockModel> model, string pt_orderCode, int pt_status)
        {
            return _DAL.SaveTechnicsStockDetail(model, pt_orderCode, pt_status);
        }


        #endregion

        #region 计划排程管理 2020-04-07

        /// <summary>
        /// 计划排程分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanModel> GetPartPlanScheduleList(PartPlanModel model, out int totalCount)
        {
            return _DAL.GetPartPlanScheduleList(model, out totalCount);
        }

        /// <summary>
        /// 手动排程计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SortPartPlan(List<PartPlanModel> model, string pp_orderCode)
        {
            return _DAL.SortPartPlan(model, pp_orderCode);
        }

        #endregion


        #region 齐套分析配置

        /// <summary>
        /// 获取齐套物料配置信息列表
        /// </summary>
        /// <param name="prodModelID"></param>
        /// <param name="mCode"></param>
        /// <returns></returns>
        public List<BundleAnalysisMaterialConfigModel> GetBundleAnalysisMaterialConfigList(BundleAnalysisMaterialConfigModel model)
        {
            return _DAL.GetBundleAnalysisMaterialConfigList(model);
        }

        /// <summary>
        /// 获取齐套物料配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BundleAnalysisMaterialConfigModel GetBundleAnalysisMaterialConfigList(int id)
        {
            return _DAL.GetBundleAnalysisMaterialConfigList(id);
        }

        /// <summary>
        /// 保存齐套物料配置
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public int SaveBundleAnalysisMaterialConfig(BundleAnalysisMaterialConfigModel model, out string Message)
        {
            return _DAL.SaveBundleAnalysisMaterialConfig(model, out Message);
        }

        /// <summary>
        /// 删除齐套物料配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteBundleAnalysisMaterialConfig(int id)
        {
            return _DAL.DeleteBundleAnalysisMaterialConfig(id);
        }


        /// <summary>
        /// 获取齐套物料配置信息列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BundleAnalysisMaterialConfigModel> GetBundleAnalysisMaterialConfigList(BundleAnalysisMaterialConfigModel model, out int totalCount)
        {
            return _DAL.GetBundleAnalysisMaterialConfigList(model, out totalCount);
        }


        /// <summary>
        /// 修改阀值
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="threshold">阀值</param>
        public void UpdateThreshold(int ID, int threshold)
        {
            _DAL.UpdateThreshold(ID, threshold);
        }


        #endregion

        #region 计划执行情况


        /// <summary>
        /// 产品完成情况按车型车号汇总
        /// </summary>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductExecutiveCondition(ProductInfoModel model, out int totalCount)
        {
            return _DAL.GetProductExecutiveCondition(model, out totalCount);
        }


        /// <summary>
        /// 父子表
        /// </summary>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductinfo(ProductInfoModel model)
        {
            return _DAL.GetProductinfo(model);
        }

        #endregion

        #region MO
        public List<MOModel> GetPagingMOList(MOModel model, out int totalCount)
        {
            return _DAL.GetPagingMOList(model, out totalCount);
        }

        public List<MOModel> GetMOList(MOModel model)
        {
            return _DAL.GetMOList(model);
        }

        public int SaveMO(MOModel model)
        {
            return _DAL.SaveMO(model);
        }

        public int DeleteMO(MOModel model)
        {
            return _DAL.DeleteMO(model);
        }
        #endregion
        #region 排产
        public string ScheduleSave(List<PlanProdModel> modelList)
        {
            return _DAL.ScheduleSave(modelList);
        }
        #endregion
    }
}
