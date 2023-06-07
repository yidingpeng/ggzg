using RW.PMS.Common;
using RW.PMS.IBLL;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IBLL_HomePage BLL = DIService.GetService<IBLL_HomePage>();
            ViewBag.DeviceCount = BLL.GetDeviceCount();//获取设备数量
            ViewBag.UsersCount = BLL.GetUsersCount();//获取用户数量
            ViewBag.CompleteCount = BLL.GetCompleteCount();//获取完成数
            ViewBag.QualifiedCount = BLL.GetQualifiedCount();//获取合格数
            return View();
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AnomalyMessage()
        {
            IBLL_HomePage BLL = DIService.GetService<IBLL_HomePage>();
            return Json(BLL.GetAnomalyMessage(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Bootstrap-table 异常明细
        /// </summary>
        /// <param name="PageSize">分页数量</param>
        /// <param name="PageIndex">页数</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AnomalyDetail(int PageSize, int PageIndex)
        {
            IBLL_HomePage BLL = DIService.GetService<IBLL_HomePage>();
            int totalCount = 0;
            var list = BLL.GetAnomalyDetail(out totalCount, PageSize, PageIndex);
            bool result = list.Count > 0 ? true : false;
            //return Json(new { Result = result, datalist = list, TotalCount = totalCount }, JsonRequestBehavior.AllowGet);
            return Json(new { page = PageIndex, rows = list, total = totalCount }, JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// 异常人员信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult PeopleAnomaly()
        {
            IBLL_HomePage BLL = DIService.GetService<IBLL_HomePage>();
            return Json(BLL.GetPeopleAnomaly(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Bootstrap-table 人员工时
        /// </summary>
        /// <param name="PageSize">分页数量</param>
        /// <param name="PageIndex">页数</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult PeopleHour(int PageSize, int PageIndex)
        {
            IBLL_HomePage BLL = DIService.GetService<IBLL_HomePage>();
            int totalCount = 0;
            var list = BLL.GetPeopleHourData(out totalCount, PageSize, PageIndex);
            bool result = list.Count > 0 ? true : false;
            return Json(new { page = PageIndex, rows = list, total = totalCount }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取首页轮播图片描述数据
        /// </summary>
        /// <returns></returns>
        public JsonResult GetImgCarousel()
        {
            IBLL_HomePage BLL = DIService.GetService<IBLL_HomePage>();
            var list = BLL.GetImgCarousel();
            return Json(new { Result = true, Data = list, Length = list.Count }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 404
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            Response.Status = "404 Not Found";
            Response.StatusCode = 404;
            return View("Error");
        }

        /// <summary>
        /// 500
        /// </summary>
        /// <returns></returns>
        public ActionResult Error()
        {
            Response.Status = "500 System Error";
            Response.StatusCode = 500;
            return View("Error");
        }
    }
}