using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Follow;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;


namespace RW.PMS.Web.Controllers
{
    public class AbnormalController : BaseController
    {

        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_System SysBLL = DIService.GetService<IBLL_System>();
        IBLL_Follow bll = DIService.GetService<IBLL_Follow>();

        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();

        #region 信息反馈管理 WZQ

        /// <summary>
        /// 信息反馈管理
        /// </summary>
        /// <param name="model">信息反馈管理实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowFeedback(FollowAbnormalModel model)
        {
            int totalCount = 0;
            ViewBag.FollowAbnormalList = bll.GetPagingFollowFeedback(model, out totalCount);
            ViewBag.AreaInfo = SysBLL.GetBaseDataTypeValue("gwArea");
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult EditFollowFeedback(int id)
        {
            FollowAbnormalModel entity = bll.GetFollowAbnormalId(id);
            ViewData.Model = entity;
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改异常反馈管理")]
        public JsonResult EditFollowFeedback(FollowAbnormalModel model)
        {
            bll.EditFollowAbnormal(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        #endregion



    }
}
