using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Data;
using RW.PMS.Model.Test;
using RW.PMS.Web.Filter;
using RW.PMS.Model.Follow;
using System.IO;
using RW.PMS.Model.Sys;

namespace RW.PMS.Web.Controllers
{
    public class DataController : BaseController
    {

        IBLL_Data bll = DIService.GetService<IBLL_Data>();
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        IBLL_Test Testbll = DIService.GetService<IBLL_Test>();
        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();
        IBLL_Follow Followbll = DIService.GetService<IBLL_Follow>();

        #region 试验报表信息查看 WZQ
        /// <summary>
        /// 试验报表信息查看
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult ProductTestManage(TestResultMainModel model)
        {
            //int totalCount = 0;
            //ViewBag.ProductTestlist = Followbll.GetProductTestForPage(model, out totalCount);
            //ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 试验主表分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetTestResultMain(TestResultMainModel model)
        {
            if (!string.IsNullOrEmpty(model.DateTimeStr))
            {
                string[] Date = model.DateTimeStr.Split('至');
                model.trmStartTime = Date[0].Trim().ToDateTime();
                model.trmEndTime = Date[1].Trim().ToDateTime();
            }
            int totalCount = 0;
            List<TestResultMainModel> TestResultMainList = Followbll.GetProductTestForPage(model, out totalCount);
            return Json(new { page = model.PageIndex, rows = TestResultMainList, total = totalCount }, JsonRequestBehavior.AllowGet);
        }


        [Permission]
        public ActionResult TestDetailResult(string trmGUID)
        {
            ViewBag.trmGUID = trmGUID;
            return View();
        }


        /// <summary>
        /// 试验明细分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetTestResultDetail(TestResultDetailModel model)
        {
            int totalCount = 0;
            List<TestResultDetailModel> TestResultDetailList = Followbll.GetTestResultDetailForPage(model, out totalCount);
            return Json(new { page = model.PageIndex, rows = TestResultDetailList, total = totalCount }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 故障报修 WZQ

        /// <summary>
        /// 故障报修
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowFaultRepair(FollowFaultRepairModel model)
        {
            int totalCount = 0;
            ViewBag.FollowFaultRepairList = Followbll.GetFollowFaultRepairForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.DeviceInfo = Devbll.GetDevice();//设备下拉
            ViewBag.FaultLevelInfo = Sysbll.GetBaseDataTypeValue("faultLevel");//故障级别下拉
            ViewBag.EmergencyInfo = Sysbll.GetBaseDataTypeValue("repariEmergency");//故障紧急程度
            ViewBag.FaultTypeInfo = Sysbll.GetBaseDataTypeValue("faultType");//故障类别下拉
            ViewBag.EmergencyInfo = Sysbll.GetBaseDataTypeValue("repariEmergency");//故障紧急程度
            ViewBag.ProdModelInfo = Basebll.GetProductModel();//产品型号下拉
            ViewBag.CarModelInfo = Sysbll.GetBaseDataTypeValue("subwayType");//车型
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult EditFollowFaultRepair(int id)
        {
            FollowFaultRepairModel entity = Followbll.GetFollowFaultRepairId(id);
            ViewData.Model = entity;
            ViewBag.DeviceInfo = Devbll.GetDevice();//设备下拉
            ViewBag.UserInfo = Basebll.GetUserlist();//用户下拉
            ViewBag.FaultCodeInfo = Sysbll.GetBaseDataTypeValue("faultCode");//故障代码下拉
            ViewBag.FaultLevelInfo = Sysbll.GetBaseDataTypeValue("faultLevel");//故障级别下拉
            ViewBag.FaultTypeInfo = Sysbll.GetBaseDataTypeValue("faultType");//故障类别下拉
            ViewBag.EmergencyInfo = Sysbll.GetBaseDataTypeValue("repariEmergency");//故障紧急程度
            ViewBag.ProdModelInfo = Basebll.GetProductModel();//产品型号下拉
            ViewBag.CarModelInfo = Sysbll.GetBaseDataTypeValue("subwayType");//车型
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改故障报修")]
        public JsonResult EditFollowFaultRepair(FollowFaultRepairModel model)
        {
            Followbll.EditFollowFaultRepair(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        #endregion

        #region 试验配置主表

        [Permission]
        public ActionResult TestConfigMain()
        {
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 查询 试验主表列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetTestConfigMainList(TestConfigMainModel model)
        {
            if (model == null) model = new TestConfigMainModel();
            var list = Testbll.GetTestConfigMain(model);
            return Json(list);
        }


        /// <summary>
        /// 保存 试验主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveTestConfigMain(TestConfigMainModel model)
        {
            bool result = false;
            string message = "保存失败！";
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            DateTime NowTime = DateTime.Now;
            if (model.tcmGUID != Guid.Empty)
            {
                model.tcmUpdaterID = ((UserModel)ViewBag.User).userID;
                model.tcmUpdateTime = NowTime;
                model.tcmDeleteFlag = 0;
            }
            else
            {
                model.tcmCreaterID = ((UserModel)ViewBag.User).userID;
                model.tcmCreateTime = NowTime;
                model.tcmDeleteFlag = 0;
            }
            result = Testbll.SaveTestConfigMain(model);
            message = result == true ? "保存成功！" : message;
            return Json(new { Result = result, Message = message });
        }


        /// <summary>
        /// 删除 试验主表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelTestConfigMain(string id)
        {
            Testbll.DelTestConfigMain(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 试验配置从表

        [Permission]
        public ActionResult TestConfigDetail(string tcmGUID)
        {
            ViewBag.tcmGUID = tcmGUID;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 查询 试验从表列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetTestConfigDetailList(TestConfigDetailModel model)
        {
            if (model == null) model = new TestConfigDetailModel();
            var list = Testbll.GetTestConfigDetail(model);
            return Json(list);
        }


        /// <summary>
        /// 保存 试验从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveTestConfigDetail(TestConfigDetailModel model)
        {
            bool result = false;
            string message = "保存失败！";
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            result = Testbll.SaveTestConfigDetail(model);
            message = result == true ? "保存成功！" : message;
            return Json(new { Result = result, Message = message });
        }


        /// <summary>
        /// 删除 试验从表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelTestConfigDetail(string id)
        {
            Testbll.DeleteTestConfigDetail(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 试验报表



        /// <summary>
        /// 试验结果查看
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult TestResult()
        {
            return View();
        }

        /// <summary>
        /// 试验结果查看
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult TestResultExcel(string ProdNo)
        {
            ViewBag.ProdNo = ProdNo;
            return View();
        }



        /// <summary>
        /// 根据产品编号查询试验报表
        /// </summary>
        /// <param name="prodNo"></param>
        /// <returns></returns>
        public JsonResult GetAllTest(string prodNo)
        {
            var bll = DIService.GetService<IBLL_Test>();
            TestConfigMainModel model = bll.GetTestDataByProdNo(prodNo);
            if (model.DetailList == null || model.DetailList.Count == 0)
                return Json(new { Result = "", Message = "未能查找到该产品编号！" }, JsonRequestBehavior.AllowGet);

            string tr = "";
            int curRowIndex = 0;
            int curColIndex = 0;

            foreach (var item in model.DetailList)
            {
                if (curRowIndex < item.tcdRowNo)
                {
                    if (curRowIndex > 0)
                    {
                        tr += "</tr>";
                    }
                    tr += "<tr>";
                    curRowIndex = item.tcdRowNo.ToInt();
                    curColIndex = 0;
                }
                if (curColIndex < item.tcdColNo)
                {
                    tr += "<td";
                    if (item.tcdRowSpan > 1)
                        tr += " rowspan='" + item.tcdRowSpan + "' ";
                    if (item.tcdColSpan > 1)
                        tr += " colspan='" + item.tcdColSpan + "' ";
                    tr += " style='";
                    if (item.tcdFontSize > 14) { tr += "font-size:" + item.tcdFontSize + "px;"; } else { tr += "font-size:14px;"; }
                    if (item.tcdHeight != null && item.tcdHeight > 0) { tr += "height:" + item.tcdHeight + "px;"; }
                    if (item.tcdWidth != null && item.tcdWidth > 0) { tr += "width:" + item.tcdWidth + "px;"; }
                    if (item.tcdAlign != null && item.tcdAlign > 0)
                    {
                        tr += "text-align:";
                        if (item.tcdAlign == 1)
                            tr += "left;padding-left:0px;";
                        if (item.tcdAlign == 2)
                            tr += "center;";
                        if (item.tcdAlign == 3)
                            tr += "right;padding-right:0px;";
                    }

                    if (item.tcdBorderTop == 1) { tr += "border-top:0.5px solid black;"; } else { tr += "border-top:none;"; }
                    if (item.tcdBorderRight == 1) { tr += "border-right:0.5px solid black;"; } else { tr += "border-right:none;"; }
                    if (item.tcdBorderBottom == 1) { tr += "border-bottom:0.5px solid black;"; } else { tr += "border-bottom:none;"; }
                    if (item.tcdBorderLeft == 1) { tr += "border-left:0.5px solid black;"; } else { tr += "border-left:none;"; }
                    //border: 0.5px solid black;

                    //样式
                    tr += "display:table-cell;vertical-align:middle;' class='tdcss' >";
                    var resultModel = model.ResultList.Where(_ => _.tcdID.ToInt() == item.tcdID).FirstOrDefault();
                    //赋值试验结果
                    if (resultModel != null && item.tcdEditFlag == 1)
                        tr += resultModel.trdText;
                    else
                        tr += item.tcdText;
                    tr += "</td>";
                    curColIndex = item.tcdColNo.ToInt();
                }
                tr += "";
            }
            tr += "</tr>";

            return Json(new { Result = tr }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 试验记录维护
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult TestResultMain()
        {
            return View();
        }


        /// <summary>
        /// 获取试验结果主表数据
        /// </summary>
        /// <param name="model">查询条件实体类</param>
        /// <returns></returns>
        public JsonResult GetTestResultMainList(TestResultMainModel model)
        {
            if (model == null) model = new TestResultMainModel();
            var Testbll = DIService.GetService<IBLL_Test>();
            var list = Testbll.GetTestResultMainList(model);
            return Json(list);
        }


        /// <summary>
        /// 删除试验结果主表数据
        /// </summary>
        /// <param name="id">试验结果主表ID</param>
        /// <returns></returns>
        public JsonResult DeleteTestResultMain(string id)
        {
            var model = new TestResultMainModel();
            model.trmUpdaterID = GetCurUserID();
            model.DELIDs = id;
            var Testbll = DIService.GetService<IBLL_Test>();
            Testbll.DeleteTestResultMain(model);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        /// <summary>
        /// 试验结果明细页面
        /// </summary>
        /// <param name="trmGUID">试验结果主表GUID</param>
        /// <returns></returns>

        public ActionResult TestResultDetail(string trmGUID)
        {
            ViewBag.MainGUID = trmGUID;
            return View();
        }

        /// <summary>
        /// 获取试验结果明细表数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetTestResultDetailList(TestResultDetailModel model)
        {
            if (model == null) model = new TestResultDetailModel();
            var Testbll = DIService.GetService<IBLL_Test>();
            var list = Testbll.GetTestResultDetailList(model);
            return Json(list);
        }

        /// <summary>
        /// 删除试验结果明细
        /// </summary>
        /// <param name="id">试验结果明细ID</param>
        /// <returns></returns>
        public JsonResult DeleteTestResultDetail(string id)
        {
            var model = new TestResultDetailModel();
            model.trdUpdaterID = GetCurUserID();
            model.DELIDs = id;
            var Testbll = DIService.GetService<IBLL_Test>();
            Testbll.DeleteTestResultDetail(model);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        #endregion

        #region 故障统计
        [Permission]
        public ActionResult FaultStatistics(HitchModel model)
        {
            int totalCount = 0;
            ViewBag.FollowHitchList = Followbll.GetHitchModelPage(model, out totalCount);
            ViewBag.ProductModelInfo = Basebll.GetProductModel();//产品型号
            ViewBag.CarModelInfo = Sysbll.GetBaseDataTypeValue("subwayType");//车型下拉
            ViewBag.DeviceInfo = Devbll.GetDevice();//设备下拉
            ViewBag.FaultCodeInfo = Sysbll.GetBaseDataTypeValue("faultCode");//故障代码下拉
            ViewBag.FaultLevelInfo = Sysbll.GetBaseDataTypeValue("faultLevel");//故障级别下拉
            ViewBag.FaultTypeInfo = Sysbll.GetBaseDataTypeValue("faultType");//故障类别下拉
            ViewBag.TotalCount = totalCount;
            return View();
        }

        /// <summary>
        /// 故障信息（饼图）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetHitchCircle(string Starttime, string Endtime)
        {
            return Json(Followbll.GetHitchCircle(Starttime, Endtime), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 故障信息（折线图）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetHitchLine(string Starttime, string Endtime)
        {
            return Json(Followbll.GetHitchLine(Starttime, Endtime), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 故障信息（柱状图）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetHitchPillar(string Starttime, string Endtime)
        {
            var Data = Followbll.GetHitchPillar(Starttime, Endtime);
            int sumCount = Data.Sum(x => x.count).Value;
            var a = Json(new { datalist = Data, Total = sumCount }, JsonRequestBehavior.AllowGet);
            return a;
        }
        #endregion
    }
}
