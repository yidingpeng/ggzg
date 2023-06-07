using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.BigScreen;
using RW.PMS.Model.Follow;
using RW.PMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    [AllowAnonymous]
    public class BigScreenController : Controller
    {
        IBLL_BigScreen BigScreenBLL = DIService.GetService<IBLL_BigScreen>();
        IBLL_HomePage HomePageBLL = DIService.GetService<IBLL_HomePage>();
        IBLL_Follow FollowBLL = DIService.GetService<IBLL_Follow>();
        IBLL_System SysBLL = DIService.GetService<IBLL_System>();
        private bool IsTest = false;

        public BigScreenController()
        {
            IsTest = GetBigScreenIsTest();
        }

        /// <summary>
        /// RWPMS 信息管理系统电子看板 页面
        /// </summary>
        /// <returns></returns>
        public ActionResult RWPMSBigScreen()
        {
            return View();
        }

        /// <summary>
        /// 获取config
        /// </summary>
        /// <param name="Where"></param>
        /// <returns></returns>
        public JsonResult GetConfig(string cfgcode)
        {
            return Json(SysBLL.GetConfigByCode(cfgcode), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 生产计划完成情况
        /// </summary>
        /// <param name="para">条件 日周月</param>
        /// <returns></returns>
        public JsonResult GetProductInfo(string para)
        {
            return Json(BigScreenBLL.GetProductInfo(para), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 生产计划 质量情况
        /// </summary>
        /// <param name="para">条件 日周月</param>
        /// <param name="IsOrderCodeorProdModel">是否按照 计划（true）或者 产品型号（false）查询质量情况</param>
        /// <returns></returns>
        public JsonResult GetProductInfoQuality(string para, bool IsOrderCodeorProdModel)
        {
            return Json(BigScreenBLL.GetProductInfoQuality(para, IsOrderCodeorProdModel), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取生产记录信息
        /// </summary>
        /// <param name="isFinish">是否为总装工位</param>
        /// <returns></returns>
        public JsonResult GetAssemblyMainList(bool isFinish)
        {
            string begDT = DateTime.Now.ToString("yyyy-MM-dd");
            string endDT = DateTime.Now.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd");
            List<AssemblyMainModel> list = null;
            if (IsTest)
            {
                list = GetAssemblyMainListByTest(isFinish); 
            }
            else
            {
                list = BigScreenBLL.GetAssemblyMainList(isFinish, DateTime.Parse(begDT), DateTime.Parse(endDT));
            }
            return Json(list,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取装配错误记录
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAssemlbyErrorList()
        {
            var list = GetAssemblyErrorList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取统计信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAssemlbyErrorTotal()
        {
            var list = GetAssemblyErrorList();
            var total = list.GroupBy(f => f.errorDesp).Select(ff => new { value = ff.Count(), name = ff.Key }).ToArray();
            return Json(total, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取装配错误记录
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private List<AssemblyErrorInfoModel> GetAssemblyErrorList()
        {
            string begDT = DateTime.Now.ToString("yyyy-MM-dd");
            string endDT = DateTime.Now.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd");
            List<AssemblyErrorInfoModel> list = null;
            if (IsTest)
            {
                list = GetAssemblyErrorListTest();
            }
            else
            {
                list = BigScreenBLL.GetAssemblyErrorList(DateTime.Parse(begDT), DateTime.Parse(endDT));
            }
            return list;
        }

        #region 测试数据
        [NonAction]
        private List<AssemblyMainModel> GetAssemblyMainListByTest(bool isFinish)
        {
            var list = new List<AssemblyMainModel>();
            var gwTotal = new string[] { "总组装工位", "橡胶关节压装工位" };
            var gwSplit = new string[] { "端盖预组装", "端盖密封件组装及阀系预调工位", "活塞及底阀组装工位", "活塞杆组装工位" };
            var random = new Random();
            for (int index = 0; index < 20; index++)
            {
                var model = new AssemblyMainModel
                {
                    PModel = "二系垂向减振器",
                    am_createDate = DateTime.Now,
                    am_updateDate = DateTime.Now,
                    am_createUser = "管理员",
                    am_updateUser = "管理员",
                };
                model.am_QRcode = random.Next(10000).ToString();
                model.am_gwName = isFinish ? gwTotal[random.Next(gwTotal.Length - 1)] : gwSplit[random.Next(gwSplit.Length - 1)];
                list.Add(model);
            }
            return list;
        }

        [NonAction]
        private List<AssemblyErrorInfoModel> GetAssemblyErrorListTest()
        {
            var errorTypes = new string[] { "拿错放错物料", "拿错放错工具","扭力值不正确" };
            var gwItems = new string[] { "总组装工位", "橡胶关节压装工位","端盖预组装", "端盖密封件组装及阀系预调工位", "活塞及底阀组装工位", "活塞杆组装工位" };
            var list = new List<AssemblyErrorInfoModel>();
            var random = new Random();
            for (int index = 0; index < 20; index++)
            {
                var model = new AssemblyErrorInfoModel
                {
                    errDate = DateTime.Now,
                    err_oper = "管理员"
                };
                model.errorDesp = errorTypes[random.Next(errorTypes.Length - 1)];
                model.err_gw = gwItems[random.Next(gwItems.Length - 1)];
                list.Add(model);
            }
            return list;
        }

        [NonAction]
        private bool GetBigScreenIsTest()
        {
            bool retVal = false;
            var val = System.Configuration.ConfigurationManager.AppSettings["BigScreenIsTest"];
            bool.TryParse(val, out retVal);

            return retVal;
        }
        #endregion
    }
}