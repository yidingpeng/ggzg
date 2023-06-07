using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.Log;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RW.PMS.Web.Controllers
{
    public class ProductInfoController : BaseController
    {
        IBLL_ProductInfo bll = DIService.GetService<IBLL_ProductInfo>();
        IBLL_BaseInfo BaseInfobll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_System Systembll = DIService.GetService<IBLL_System>();
        IBLL_Data databll = DIService.GetService<IBLL_Data>();
        /// <summary>
        /// 存储实体类数据类型
        /// </summary>
        Dictionary<string, object> dic = new Dictionary<string, object>();

        #region 产品装配完成情况 LHR
        [Permission]
        public ActionResult AssemblyProd(AssemblyProdModel model)
        {
            int totalCount = 100;
            ViewBag.AssemblyProd = bll.AssemblyProdForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.ProductModelInfo = BaseInfobll.GetProductModel();
            return View();
        }
         
        #endregion

        #region 工位装配完成情况 LHR 
        [Permission]
        public ActionResult AssemblyGw(AssemblyGwModel model)
        {
            int totalCount = 100;
            ViewBag.AssemblyGw = bll.AssemblyGwForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.ProductModelInfo = BaseInfobll.GetProductModel();
            ViewBag.GongWei = BaseInfobll.GetGongWei();//工位
            return View();
        }

        #endregion

        #region 装配明细情况 LHR
        [Permission]
        public ActionResult AssemblyZp(AssemblyFllowInfoModel model)
        {
            int totalCount = 100;
            ViewBag.AssemblyZp = bll.AssemblyFllowInfoForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.BaseProduct = BaseInfobll.GetProductDrawingNoModel();//产品型号
            ViewBag.GongWei = BaseInfobll.GetGongWei();//工位
            //ViewBag.Gongju = Systembll.GetgongjuAll();//工具
            //ViewBag.Wuliao = Systembll.GetwuliaoAll();//物料
            return View();
        }

        /// <summary>
        /// 获取装配明细信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetAssemblyDetailInfo(AssemblyFllowInfoModel model)
        {
            if (model == null) model = new AssemblyFllowInfoModel();

            var list = bll.AssemblyFllowInfoForPage(model);
            return new JsonResult()
            {
                Data = list,
                MaxJsonLength = int.MaxValue,
                ContentType = "application/json"
            };
        }

        /// <summary>
        /// 产品型号
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGongWeiList()
        {
            var list = BaseInfobll.GetGongWei();//工位
            return Json(list);
        }

        #endregion

        #region 生产关键信息记录
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prodCode">产品编号</param>
        /// <param name="pModelID">产品型号</param>
        /// <param name="keyType">关键信息类型</param>
        /// <param name="keyValue">关键值</param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult AssemblyMain(string prodCode = "", int? pModelID = null, int? gwID = null, string keyType = "MaterialCode", string keyValue = "", string startTime = null, string endTime = null, int pageIndex = 0, int pageSize = 0)
        {
            DateTime bDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            DateTime eDate = bDate;
            if (!string.IsNullOrEmpty(startTime))
            {
                bDate = DateTime.Parse(startTime);
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                eDate = DateTime.Parse(endTime);
            }
            var result = _assemblyBLL.GetAssemblyMainList(prodCode,null, pModelID, gwID, keyType, keyValue, bDate, eDate, pageIndex, pageSize);
            ViewBag.List = result.Val;
            ViewBag.TotalCount = result.Total;
            ViewBag.GongWei = BaseInfobll.GetGongWei();//工位
            ViewBag.BaseProduct = BaseInfobll.GetProductDrawingNoModel();//产品型号+图号
            return View();
        }
        #endregion

    }
}
