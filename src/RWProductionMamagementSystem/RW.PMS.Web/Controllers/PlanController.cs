using Newtonsoft.Json;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Plan;
using RW.PMS.Model.Sys;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RW.PMS.Web.Controllers
{
    //计划
    public class PlanController : BaseController
    {
        IBLL_Plan bll = DIService.GetService<IBLL_Plan>();
        IBLL_System bllSys = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo bllBI = DIService.GetService<IBLL_BaseInfo>();
        IBLL_BundleAnalysis BundleAnalysisbll = DIService.GetService<IBLL_BundleAnalysis>();

        #region 配件计划管理


        /// <summary>
        /// 配件计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult PartPlanList(PartPlanModel model)
        {
            int totalCount = 0;
            //计划数据
            model.sort = "pp_startDate";
            model.sortOrder = "desc";
            ViewBag.PartPlanList = bll.GetPartPlanList(model, out totalCount);
            //产品型号数据
            ViewBag.ProdModelList = bllBI.GetProductModelAll();
            //产品型号（图号）信息数据
            ViewBag.ProductDrawingNoModelList = bllBI.GetProductDrawingNoModel();
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 返回 产品型号-图号 下拉List
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProductDrawingNoList()
        {
            return Json(bllBI.GetProductDrawingNoModel());
        }


        /// <summary>
        /// 保存配件计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SavePartPlan(PartPlanModel model)
        {
            if (model == null) model = new PartPlanModel();
            var userModel = bllSys.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            if (string.IsNullOrEmpty(model.pp_orderCode))
            {
                model.pp_createMan = userModel.userID;
            }
            else
            {
                model.pp_updateMan = userModel.userID;
            }
            int i = bll.SavePartPlan(model);
            if (i > 0)
                return Json(new { Result = true, Message = "保存成功！" });
            return Json(new { Result = false, Message = "保存失败！" });
        }


        /// <summary>
        /// 保存配件计划、工序、备料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveCopyPlan(PartPlanModel model)
        {
            if (model == null) model = new PartPlanModel();
            var userModel = bllSys.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            if (string.IsNullOrEmpty(model.pp_orderCode))
            {
                model.pp_createMan = userModel.userID;
            }
            else
            {
                model.pp_updateMan = userModel.userID;
            }
            int i = bll.SaveCopyPlan(model);
            if (i > 0)
                return Json(new { Result = true, Message = "保存成功！" });
            return Json(new { Result = false, Message = "保存失败！" });
        }

        /// <summary>
        /// 配件计划下发
        /// </summary>
        /// <param name="pp_orderCode">计划订单编码</param>
        /// <returns></returns>
        public JsonResult IssuedPartPlan(string pp_orderCode)
        {
            if (!string.IsNullOrEmpty(pp_orderCode))
            {
                UserModel userModel = bllSys.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
                int count = bll.IssuedPartPlan(pp_orderCode, userModel.userID);
                return Json(new { Result = true, Message = "下发成功！" });
            }
            else
            {
                return Json(new { Result = false, Message = "下发失败！" });
            }
        }


        /// <summary>
        /// 计划状态修改（计划下达）（反下达）操作
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public JsonResult UpdatePartPlanByStatus(string pp_orderCode, int status)
        {
            string Message = "";
            if (!string.IsNullOrEmpty(pp_orderCode))
            {
                UserModel userModel = bllSys.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
                int count = bll.IssuedPartPlan(pp_orderCode, userModel.userID, status, out Message);
                if (count > 0 && string.IsNullOrEmpty(Message))
                {
                    return Json(new { Result = true, Message = "下发成功！" });
                }
                else
                {
                    return Json(new { Result = false, Message = Message });
                }
            }
            else
            {
                return Json(new { Result = false, Message = "获取计划单据号失败！" });
            }
        }

        /// <summary>
        /// 逻辑删除 计划、计划工序、计划备料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeletePartPlan(string ids)
        {
            string[] ptCodeStr = ids.Split(',');
            int result = bll.DeletePartPlan(ptCodeStr);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        //获取产品型号
        public JsonResult GetProdModel()
        {
            return Json(bllBI.GetProductModelAll());
        }

        #endregion

        #region 配件计划工序管理


        /// <summary>
        /// 配件计划工序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult PartPlanTechnicsList(PartPlanTechnicsModel model)
        {
            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                ViewBag.PpOrderCode = model.pp_orderCode;
                model.LIKEpporderCode = model.pp_orderCode;
            }
            int totalCount = 0;
            ViewBag.EntrustTypeList = bllSys.GetBaseDataTypeValue("EntrustType");
            ViewBag.PartPlanTechnicsList = bll.GetPartPlanTechnicsList(model, out totalCount);//配件计划工序
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存配件计划工序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SavePartPlanTechnics(PartPlanTechnicsModel model)
        {
            if (model == null) model = new PartPlanTechnicsModel();
            var userModel = bllSys.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            if (string.IsNullOrEmpty(model.pt_orderCode))
            {
                model.pt_createMan = userModel.userID;
            }
            else
            {
                model.pt_updateMan = userModel.userID;
            }
            int i = bll.SavePartPlanTechnics(model);
            if (i > 0)
                return Json(new { Result = true, Message = "保存成功！" });
            return Json(new { Result = false, Message = "保存失败！" });
        }


        /// <summary>
        /// 获取数据字典维护
        /// </summary>
        /// <param name="TypeCode">传入TypeCode字符串</param>
        /// <returns></returns>
        public JsonResult GetBaseDataTypeValue(string TypeCode)
        {
            return Json(bllSys.GetBaseDataTypeValue(TypeCode));
        }
        

        /// <summary>
        /// 根据 查询条件填充计划单模态窗
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetPartPlanList(PartPlanModel model)
        {
            return Json(bll.GetPartPlanList(model));
        }

        /// <summary>
        /// 根据计划编码 查询所有工序编码、名称、序号
        /// </summary>
        /// <param name="PpOrderCode"></param>
        /// <returns></returns>
        public JsonResult GetPartGongxuByProdModelID(string PpOrderCode)
        {
            int PID = bll.GetPartPlanList(new PartPlanModel() { pp_orderCode = PpOrderCode })[0].pp_prodModelID.ToInt();
            return Json(bllBI.GetPartGongxu(PID));
        }

        /// <summary>
        /// 删除 计划工序以及计划备料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeletePlanTechnics(string ids)
        {
            string[] ptCodeStr = ids.Split(',');
            int result = bll.DeletePlanTechnics(ptCodeStr);
            return Json(new { Result = true, Message = "删除成功！" });
        }
        #endregion

        #region 配件计划备料管理

        /// <summary>
        /// 配件计划备料页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PartPlanStockList(PartPlanStockModel model)
        {
            //配件计划单据编号
            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                ViewBag.PpOrderCode = model.pp_orderCode;
                model.LIKEpporderCode = model.pp_orderCode;
            }
            if (model.ps_operationID.HasValue && model.ps_operationID != 0)
            {
                ViewBag.operationID = model.ps_operationID;
            }
            int totalCount = 0;
            ViewBag.PartPlanStockList = bll.GetPartPlanStockList(model, out totalCount);//配件计划备料
            ViewBag.PartGongxuList = bllBI.GetPartGongxu(new Base_PartGongxuModel());//工序下拉
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
        
        /// <summary>
        /// 保存配件计划备料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SavePartPlanStock(PartPlanStockModel model)
        {
            if (model == null) model = new PartPlanStockModel();
            var userModel = bllSys.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            if (string.IsNullOrEmpty(model.ps_orderCode))
            {
                model.ps_createMan = userModel.userID;
            }
            else
            {
                model.ps_updateMan = userModel.userID;
            }
            int i = bll.SavePartPlanStock(model);
            if (i > 0)
                return Json(new { Result = true, Message = "保存成功！" });
            return Json(new { Result = false, Message = "保存失败！" });
        }
        

        /// <summary>
        /// 传入计划编码 查询所有EBOM数据
        /// </summary>
        /// <param name="ebProdModelID"></param>
        /// <returns></returns>
        public JsonResult GetEBOMList(string PpOrderCode)
        {
            if (!string.IsNullOrEmpty(PpOrderCode))
            {
                int PID = bll.GetPartPlanList(new PartPlanModel() { pp_orderCode = PpOrderCode })[0].pp_prodModelID.ToInt();
                return Json(bllBI.GetEBOMList(new BaseEBOMModel() { ebProdModelID = PID }));
            }
            return Json(new BaseEBOMModel());
        }


        /// <summary>
        /// 删除计划备料
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeletePlanstock(string ids)
        {
            string[] psCodeStr = ids.Split(',');
            bll.DeletePlanstock(psCodeStr);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        #endregion

        #region 配件计划排程管理

        /// <summary>
        /// 计划排程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult PartPlanScheduling()
        {
            //计划数据
            //ViewBag.PartPlanSchedulingList = bll.GetPartPlanList(model);PartPlanModel model
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 计划排程分页查询
        /// </summary>
        /// <param name="model">计划model实体</param>
        /// <param name="offset">页码</param>
        /// <param name="limit">页数</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult PartPlanSchedulings(PartPlanModel model)
        {
            int TotalCount = 0;
            List<PartPlanModel> List = bll.GetPartPlanScheduleList(model, out TotalCount);
            //|| _.pp_status == 2 
            List<PartPlanModel> QueryList = List.Where(_ => _.pp_status == 0 || _.pp_status == 1 || _.pp_status == 4).ToList();
            return Json(new { page = model.PageIndex, rows = QueryList, total = QueryList.Count() }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 拖动后改为手动排序
        /// </summary>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public JsonResult Sort(string jsondata, string pp_orderCode)
        {
            if (!string.IsNullOrEmpty(jsondata))
            {
                var userModel = bllSys.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
                //将json序列化为List<T>
                List<PartPlanModel> modelList = JsonConvert.DeserializeObject<List<PartPlanModel>>(jsondata);
                for (int i = 0; i < modelList.Count; i++)
                {
                    modelList[i].pp_sort = i + 1;
                    modelList[i].pp_updateMan = userModel.userID;
                }
                int results = bll.SortPartPlan(modelList, pp_orderCode);
                if (results > 0)
                {
                    return Json(new { result = true, message = "成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, message = "失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result = false, message = "获取数据失败！" }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 齐套分析
        /// </summary>
        /// <param name="ppCode"></param>
        /// <returns></returns>
        public JsonResult BundleAnalysis(string ppCode)
        {
            string[] ppCodeStr = ppCode.Split(',');
            //获得齐套分析结果集合 "PP202004170007"
            List<BundleAnalysisPlanModel> BundleAnalysisList = BundleAnalysisbll.BundleAnalysis(ppCodeStr);
            //将分析结果进行保存
            int retCount = BundleAnalysisbll.SaveBundleAnalysisResults(BundleAnalysisList);
            bool result = retCount > 0 ? true : false;
            return Json(new { Result = result, Message = result == true ? "齐套分析成功！" : "齐套分析失败！" }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 工序明细详情
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult TechnicsSelectList(string LIKEpporderCode)
        {
            ViewBag.LIKEpporderCode = LIKEpporderCode;
            //ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 配件计划工序详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model">计划工序model实体</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetPartPlanTechnicsSelctList(PartPlanTechnicsModel model, int PageIndex = 0, int PageSize = 500)
        {
            model.PageIndex = PageIndex;
            model.PageSize = PageSize;
            int TotalCount = 0;
            List<PartPlanTechnicsModel> List = bll.GetPartPlanTechnicsSelctList(model, out TotalCount);
            return Json(new { page = model.PageIndex, rows = List, total = TotalCount }, JsonRequestBehavior.AllowGet);
        }
        
        /// <summary>
        /// 备料明细详情
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult StockSelectList(string LIKEpporderCode, int ps_operationID, string operationName)
        {
            ViewBag.LIKEpporderCode = LIKEpporderCode;
            ViewBag.ps_operationID = ps_operationID;
            ViewBag.operationName = operationName;
            //ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 配件计划备料详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model">计划工序model实体</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetPartPlanStockSelctList(PartPlanStockModel model, int PageIndex = 0, int PageSize = 500)
        {
            model.PageIndex = PageIndex;
            model.PageSize = PageSize;
            int TotalCount = 0;
            List<PartPlanStockModel> List = bll.GetPartPlanStockSelctList(model, out TotalCount);
            return Json(new { page = PageIndex, rows = List, total = TotalCount }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 计划执行情况

        public ActionResult PLanExecutiveCondition()
        {
            return View();
        }

        /// <summary>
        /// bootstrap-table 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetProductExecutiveCondition(ProductInfoModel model)
        {
            int totalCount = 0;
            var QueryList = bll.GetProductExecutiveCondition(model, out totalCount);
            return Json(new { page = model.PageIndex, rows = QueryList, total = totalCount }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// bootstrap-table 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetProductinfo(ProductInfoModel model)
        {
            var QueryList = bll.GetProductinfo(model);
            return Json(new { rows = QueryList }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region MO
        [Permission]
        public ActionResult MOList(MOModel model)
        {
            ViewBag.AuthVal = GetAuth();
            int totalCount = 100;
            ViewBag.MOList = bll.GetPagingMOList(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.ProductList = bllBI.GetProductModelAll();//产品型号下拉框
            return View();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetMOList(MOModel model)
        {
            if (model == null) model = new MOModel();
            var bll = DIService.GetService<IBLL_Plan>();
            var list = bll.GetMOList(model);
           
            return Json(list);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveMO(MOModel model)
        {
            if (model == null)
                return Json(new { Result = false, Message = "传入参数为空！" });
            //if (string.IsNullOrEmpty(model.moSubwayCode) && !model.moMotorModelID.HasValue)
            //    return Json(new { Result = false, Message = "错误：车辆编号及电机型号均无值！" });
            model.moUpdaterID = GetCurUserID();
            model.moUpdateTime = DateTime.Now;
            var bll = DIService.GetService<IBLL_Plan>();
            int i = bll.SaveMO(model);
            if (i > 0)
                return Json(new { Result = true, Message = "保存成功！" });
            return Json(new { Result = false, Message = "保存失败！" });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="moCode"></param>
        /// <returns></returns>
        public JsonResult DeleteMO(string moCode)
        {
            var bll = DIService.GetService<IBLL_Plan>();
            int i = bll.DeleteMO(new MOModel { moCode = moCode, moUpdaterID = GetCurUserID(), moUpdateTime = DateTime.Now });
            if (i > 0)
                return Json(new { Result = true, Message = "删除成功！" });
            return Json(new { Result = false, Message = "删除失败！" });
        }

        #endregion

        #region 排产
        /// <summary>
        /// 排产保存
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public JsonResult ScheduleSave(string json)
        {
            var result = false;
            if (string.IsNullOrEmpty(json)) return Json(new { Result = result, Message = "参数为空！" });
            var modelList = JsonConvert.DeserializeObject<List<PlanProdModel>>(json);
            var curUserID = GetCurUserID();
            var nowTime = DateTime.Now;
            foreach (var item in modelList)
            {
                item.pp_updateMan = curUserID;
                item.pp_updateTime = nowTime;
            }
            var bll = DIService.GetService<IBLL_Plan>();
            var msg = bll.ScheduleSave(modelList);
            if (string.IsNullOrEmpty(msg))
            {
                result = true;
                msg = "操作成功!";
            }
            return Json(new { Result = result, Message = msg });
        }
        #endregion

        #region 计划管理

        /// <summary>
        /// 计划管理页面 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult PlanList(PlanProdModel model)
        {
            int totalCount = 100;
            ViewBag.PlanProdList = bll.GetPlanProdList(model,out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.ProductList = bllBI.GetProductModelAll();//产品型号下拉框
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SavePlan(PlanProdModel model)
        {
            if (model == null) model = new PlanProdModel();
            var msg = NewCheck(model.pp_guid);
            if (!string.IsNullOrEmpty(msg)) return Json(new { Result = true, Message = msg });

            model.pp_updateMan = GetCurUserID();
            model.pp_updateTime = DateTime.Now;
            int i = bll.SavePlan(model);
            if (i > 0)
                return Json(new { Result = true, Message = "保存成功！" });
            return Json(new { Result = false, Message = "保存失败！" });
        }

        /// <summary>
        /// 非新建提醒 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string NewCheck(Guid id)
        {
            if (id == Guid.Empty) return string.Empty;
            //1.根据生产计划主表ID查询明细信息,若有一条为非新建状态,则不允许编辑
            var detailList = bll.GetPlanDetailList(new PlanDetailModel() { ppGuid = id });
            foreach (var item in detailList)
            {
                if (item.pdStatus != (int)EDAEnums.PlanDetailStatus.New)
                {
                    return "操作失败!此计划已开始生产!";
                }
            }
            return string.Empty;
        }
        #endregion
    }
}
