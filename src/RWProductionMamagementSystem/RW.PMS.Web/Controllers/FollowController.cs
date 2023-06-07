using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Follow;
using RW.PMS.Web.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    public class FollowController : BaseController
    {
        IBLL_Follow bll = DIService.GetService<IBLL_Follow>();
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();

        #region 产品追溯信息
        /// <summary>
        /// 产品追溯信息
        /// </summary>
        /// <param name="model">检修追溯实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowMainManage(FollowMainModel model)
        {
            int totalCount = 0;
            ViewBag.FollowMainList = bll.GetPagingFollowMain(model, out totalCount);
            ViewBag.GongWeiInfo = Basebll.GetGongWei();//绑定工位下拉
            ViewBag.ProductModelInfo = Basebll.GetProductModel();
            ViewBag.TotalCount = totalCount;
            return View();
        }

        #endregion

        #region 区域追溯信息查询
        /// <summary>
        /// 区域追溯信息查询
        /// </summary>
        /// <param name="model">检修追溯工位实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowGwInfo(FollowAreaModel model)
        {
            int totalCount = 0;
            string[] strAreaArray = null;
            ViewBag.FollowGwlist = bll.getFollowGwForAreaColForPage(model, out totalCount, out strAreaArray);
            ViewBag.TotalCount = totalCount;
            ViewBag.StrAreaArray = strAreaArray;
            ViewBag.ProductModelInfo = Basebll.GetProductModel();
            return View();
        }
        #endregion

        #region 产品追溯明细信息查询
        /// <summary>
        /// 产品追溯明细信息查询
        /// </summary>
        /// <param name="model">检修追溯明细实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowDetailManage(FollowDetailModel model)
        {
            int totalCount = 10;
            ViewBag.FollowDetaillist = bll.getFollowDetailForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.ProductModelInfo = Basebll.GetProductModel();
            ViewBag.GwAreaInfo = Sysbll.GetBaseDataTypeValue("gwArea");
            ViewBag.GongweiInfo = Basebll.GetGongWei();
            ViewBag.UserInfo = Basebll.GetUserlist();
            return View();
        }


        #endregion

        #region 条码卡使用情况
        /// <summary>
        /// 条码卡使用情况
        /// </summary>
        /// <param name="model">条形码卡使用记录实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowBarcodeLogInfo(FollowBarcodeLogModel model)
        {
            int totalCount = 0;
            ViewBag.FollowBarcodeLoglist = bll.getFollowBarcodeLogForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.ProductModelInfo = Basebll.GetProductModel();
            ViewBag.GwAreaInfo = Sysbll.GetBaseDataTypeValue("gwArea");
            ViewBag.GongweiInfo = Basebll.GetGongWei();
            return View();
        }
        #endregion

        #region 检修配件明细查询
        /// <summary>
        /// 配料明细查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowWlLjBatchingManage(FollowWlLjBatchingModel model)
        {
            int totalCount = 0;
            ViewBag.WlLJBatchinglist = bll.getFollowWlLJBatchingForPage(model, out totalCount);
            ViewBag.GongweiInfo = Basebll.GetGongWei();
            ViewBag.ReplaceTypeInfo = new List<SelectListItem>() { 
                new SelectListItem(){Value="0",Text="其他"},
                new SelectListItem(){Value="1",Text="必换件"},
                new SelectListItem(){Value="2",Text="偶换件"},
                new SelectListItem(){Value="3",Text="组件"}
            };
            ViewBag.TotalCount = totalCount;
            return View();
        }
        #endregion

        #region 操作异常统计
        [Permission]
        public ActionResult OperationStatistics(OperateErrorModel model)
        {
            int totalCount = 0;
            ViewBag.OperateErrorList = bll.GetOperateErrorModelPage(model, out totalCount);
            ViewBag.ProductModelInfo = Basebll.GetProductModel();//产品型号
            ViewBag.CarModelInfo = Sysbll.GetBaseDataTypeValue("subwayType");//车型下拉
            ViewBag.DeviceInfo = Devbll.GetDevice();//设备下拉
            ViewBag.GbErrorTypeInfo = Sysbll.GetBaseDataTypeValue("GbErrorType");//工步异常类型下拉
            ViewBag.TotalCount = totalCount;
            return View();
        }

        /// <summary>
        /// 异常信息（饼图）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult OperateErrorCircle(string Starttime, string Endtime)
        {
            return Json(bll.GetOperateErrorCircle(Starttime, Endtime), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 异常信息（折线图）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOperateErrorLine(string Starttime, string Endtime)
        {

            return Json(bll.GetOperateErrorLine(Starttime, Endtime), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 异常信息（柱状图）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetOperateErrorPillar(string Starttime, string Endtime)
        {
            var Data = bll.GetOperateErrorPillar(Starttime, Endtime);
            int sumCount = Data.Sum(x => x.AnomalyCount).Value;
            var a = Json(new { datalist = Data, Total = sumCount }, JsonRequestBehavior.AllowGet);
            return a;
        }

        #endregion

        #region 车辆信息管理

        [Permission]
        public ActionResult FollowSubwayInfo(FollowSubwayInfoModel model)
        {
            int totalCount = 0;
            //ViewBag.SubwayInfo = bll.GetWlBatchMain(model, out totalCount);
            ViewBag.totalCount = totalCount;
            ViewBag.ProductModelInfo = Basebll.GetProductModel();//产品型号
            ViewBag.SubwayType = Sysbll.GetBaseDataTypeValue("subwayType");//车型下拉
            ViewBag.SubwayNo = Sysbll.GetBaseDataTypeValue("subwayNo");//地铁线路下拉
            ViewBag.Groups = Sysbll.GetBaseDataTypeValue("groups");//编组下拉
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改车辆信息")]
        public JsonResult EditSubwayInfo(FollowSubwayInfoModel model)
        {
            bll.EditSubwayInfo(model);
            return Json(new { Result = true, Message = "修改成功！" });
        }


        /// <summary>
        /// 产品型号
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProductList()
        {
            var list = Basebll.GetProductModel();
            return Json(list);
        }

        /// <summary>
        /// 车型下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSubwayTypeList()
        {
            var list = Sysbll.GetBaseDataTypeValue("subwayType");//车型下拉
            return Json(list);
        }

        /// <summary>
        /// 地铁线路下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetSubwayNoList()
        {
            var list = Sysbll.GetBaseDataTypeValue("subwayNo");//地铁线路下拉
            return Json(list);
        }

        /// <summary>
        /// 编组下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGroupsList()
        {
            var list = Sysbll.GetBaseDataTypeValue("groups");//编组下拉
            return Json(list);
        }


        /// <summary>
        /// 获取车号信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetSubwayInfoList(FollowSubwayInfoModel model)
        {
            if (model == null) model = new FollowSubwayInfoModel();
            var list = bll.GetSubwayInfoList(model);
            return Json(list);
        }

        #endregion

        #region 电机产品信息查询

        [Permission]
        public ActionResult FollowProductInfo(ProductInfoModel model)
        {
            return View();
        }

        /// <summary>
        /// 获取车号信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetProductInfoList(ProductInfoModel model)
        {
            if (model == null) model = new ProductInfoModel();
            //var list = bll.GetProductInfoList(model);
            return Json(null);
        }

        #endregion


    }
}