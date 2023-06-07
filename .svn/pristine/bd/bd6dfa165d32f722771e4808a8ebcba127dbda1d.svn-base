using Newtonsoft.Json;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Sys;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    //检测区
    public class CheckController : BaseController
    {
        IBLL_Check CheckBLL = DIService.GetService<IBLL_Check>();
        IBLL_Follow FollowBLL = DIService.GetService<IBLL_Follow>();
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Plan Planbll = DIService.GetService<IBLL_Plan>();

        #region 偶换件检验

        /// <summary>
        /// 偶换件检验主页面
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult EvenCheckList()
        {
            ViewBag.ProductModelInfo = Basebll.GetProductModel();//产品型号
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 根据条件查询偶换件检验主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetEvenCheckList(FollowEvenCheckModel model)
        {
            if (model == null) model = new FollowEvenCheckModel();
            var list = FollowBLL.GetEvenCheckMain(model);
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 偶换件检验明细页
        /// </summary>
        /// <returns></returns>
        public ActionResult EvenCheckDetail(string ecGuid, string sta)
        {
            ViewBag.ecGuid = ecGuid;
            ViewBag.ecStatus = sta;
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 根据 ecGuid 获取 偶换件检验主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetEvenCheckDetail(FollowEvenCheckDetailModel model)
        {
            List<FollowEvenCheckDetailModel> detail = FollowBLL.GetEvenCheckDetail(model);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 根据 偶换件单号 条件查询偶换件检验单主表最大检验单号
        /// </summary>
        /// <param name="Iv_applyNo"></param>
        /// <returns></returns>
        public JsonResult GetEvenCheckByCode(string ecCode)
        {
            List<FollowEvenCheckModel> CodeNo = FollowBLL.GetEvenCheckByCode(ecCode);
            return Json(CodeNo, JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public ActionResult WuliaoSelectList()
        {
            return View();
        }


        /// <summary>
        /// 获取物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetWuliaoList(WuliaoModelModel model)
        {
            if (model == null) model = new WuliaoModelModel();
            var list = FollowBLL.GetWuliaoList(model);
            return Json(list);
        }


        /// <summary>
        /// 根据 计划获取产品型号下所有偶换件配料明细
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPlanProdBom(string pp_guid)
        {
            List<WmsBatchingDetailModel> PlanProdBom = FollowBLL.GetPlanProdBom(pp_guid);
            return Json(PlanProdBom, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取所有产品型号信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProductModel()
        {
            List<BaseProductModelModel> ProductModelInfo = Basebll.GetProductModel();//产品型号
            return Json(ProductModelInfo, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 根据物料ID获取所有物料和物料规格信息
        /// </summary>
        /// <param name="wlid"></param>
        /// <returns></returns>
        public JsonResult GetMaterialByID(string wlid)
        {
            List<WuliaoModelModel> wlList = FollowBLL.GetMaterialByID(wlid);
            return Json(wlList, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 获取 产品型号获取 计划列表信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPlanProdList(int pmodelID)
        {
            PlanProdModel model = new PlanProdModel();
            model.UNStatus = 2;
            model.pp_prodModelID = pmodelID;
            List<PlanProdModel> PlanProd = Planbll.GetPlanProdList(model);
            return Json(PlanProd, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveEvenCheckMainDetail(FollowEvenCheckModel model)
        {
            DateTime NowTime = DateTime.Now;
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            List<FollowEvenCheckDetailModel> modelList = JsonConvert.DeserializeObject<List<FollowEvenCheckDetailModel>>(model.JSONDetailList);
            model.detailList = modelList;
            model.ecSenderID = ((UserModel)ViewBag.User).userID;
            model.ecStatus = 1;

            if (model.ecGuid != Guid.Empty)
            {
                model.ecUpdateTime = NowTime;
                model.ecUpdaterID = ((UserModel)ViewBag.User).userID;
            }
            else
            {
                model.ecDate = NowTime;
                model.ecDeleteFlag = 0;
                model.ecCreateTime = NowTime;
                model.ecCreaterID = ((UserModel)ViewBag.User).userID;
            }

            FollowBLL.SaveEvenCheckMainDetail(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }


        /// <summary>
        /// 偶换件检验修改状态为 入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[HttpPost]
        //public JsonResult EvenCheckSend(FollowEvenCheckModel model)
        //{
        //    model.ecSenderID = ((UserModel)ViewBag.User).userID;
        //    model.ecUpdaterID = ((UserModel)ViewBag.User).userID;
        //    bool result = FollowBLL.EvenCheckSend(model);
        //    var message = "入库成功！";
        //    if (!result) message = "入库失败！";
        //    return Json(new { Result = result, Message = message });
        //}



        #endregion





        //偶换件更换率报表页
        public ActionResult EvenCheckreportforms()
        {

            return View();
        }

        //取得折线图数据
        public ActionResult Getlinechart()
        {
            return Json(CheckBLL.Getlinechart(), JsonRequestBehavior.AllowGet);
        }

        //取得饼形图数据
        public ActionResult Getpiechart()
        {
            return Json(CheckBLL.Getpiechart(), JsonRequestBehavior.AllowGet);
        }

        //偶换件明细
        public ActionResult Getfollow_evencheckModellist(int PageSize, int PageIndex)
        {
            int totalCount = 0;
            var list = CheckBLL.Getfollow_evencheckModellist(out totalCount, PageSize, PageIndex);
            bool result = list.Count > 0 ? true : false;
            return Json(new { Result = result, datalist = list, TotalCount = totalCount }, JsonRequestBehavior.AllowGet);

        }

    }
}
