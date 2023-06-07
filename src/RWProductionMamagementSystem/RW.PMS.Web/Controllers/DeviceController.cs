using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Device;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RW.PMS.Web.Controllers
{
    public class DeviceController : BaseController
    {

        private static byte[] Photo;
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        //
        // GET: /Device/
        IBLL_Device bll = DIService.GetService<IBLL_Device>();
        IBLL_ProductInfo ProductInfobll = DIService.GetService<IBLL_ProductInfo>();
        IBLL_System SysBLL = DIService.GetService<IBLL_System>();

        #region 设备管理
        [Permission]
        public ActionResult Device(DeviceModel model)
        {
            int totalCount = 100;
            ViewBag.Device = bll.DeviceForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [Permission]
        public ActionResult AddDevice()
        {
            return View("EditDevice");
        }

        [Permission]
        public ActionResult EditDevice(int id)
        {
            DeviceModel device = bll.getDevice(id);
            ViewBag.Device = device;
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加设备管理")]
        public JsonResult AddDevice(DeviceModel model)
        {
            bll.AddDevice(model);
            return Json(new { Result = true, Message = "添加成功！" });
        }

        [HttpPost]
        [Log(LogType = 2, Action = "修改设备管理")]
        public JsonResult EditDevice(DeviceModel model)
        {
            bll.EditDevice(model);
            return Json(new { Result = true, Message = "修改成功！" });
        }

        [HttpPost]
        [Log(LogType = 3, Action = "删除设备管理")]
        public ActionResult DelDevice(string id)
        {
            bll.DelDevice(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }



        #endregion

        #region 设备保养/点检项点维护
        [Permission]
        public ActionResult DeviceSpotCheck(DeviceSpotCheckModel model)
        {
            int totalCount = 100;
            ViewBag.DeviceSpotCheck = bll.DeviceSpotCheckPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            ViewBag.Devicelist = bll.GetDevice();
            ViewBag.faultlist = Sysbll.GetBaseDataValue("deviceCheckType");
            return View();
        }

        [Permission]
        public ActionResult AddDeviceSpotCheck()
        {
            ViewBag.UpKeepTypeInfo = SysBLL.GetBaseDataTypeValue("DeviceUpkeepType");
            ViewBag.Devicelist = bll.GetDevice();
            ViewBag.faultlist = Sysbll.GetBaseDataValue("deviceCheckType");
            return View("EditDeviceSpotCheck");
        }
        
        [Permission]
        public ActionResult EditDeviceSpotCheck(int id)
        {
            DeviceSpotCheckModel dm = bll.GetDeviceSpotCheckbyId(id);
            
            ViewBag.DeviceSpotCheckbyid = dm;
            ViewBag.UpKeepTypeInfo = SysBLL.GetBaseDataTypeValue("DeviceUpkeepType");
            Photo = dm.dsc_img;
            ViewBag.Devicelist = bll.GetDevice();
            ViewBag.faultlist =  Sysbll.GetBaseDataValue("deviceCheckType");
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加设备保养/点检项点维护数据")]
        public JsonResult AddDeviceSpotCheck(DeviceSpotCheckModel model)
        {
            HttpPostedFileBase hpf = Request.Files["CheckImage"];
            Stream fileInStream = hpf.InputStream;
            var fileContent = new byte[hpf.ContentLength];
            int iStatus = fileInStream.Read(fileContent, 0, hpf.ContentLength);
            fileInStream.Flush();
            fileInStream.Close();

            model.dsc_img = fileContent;
            bll.AddDeviceSpotCheck(model);
            return Json(new { Result = true, Message = "添加成功！" });
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        /// </summary>
        /// <param name="id"></param>
        public void GetDeviceSpotCheckImg(int id)
        {
            var entity = bll.GetDeviceSpotCheck().Where(p => p.id == id).FirstOrDefault();
            if (entity != null && entity.dsc_img != null)
            {
                byte[] HeadPortrait = entity.dsc_img;
                Response.BinaryWrite(HeadPortrait);
            }
        }

        [HttpPost]
        [Log(LogType = 2, Action = "修改设备保养/点检项点维护数据")]
        public JsonResult EditDeviceSpotCheck(DeviceSpotCheckModel model)
        {
            var fileContent = new byte[0];
            HttpPostedFileBase hpf = Request.Files["CheckImage"];

            if (hpf != null)
            {
                Stream fileInStream = hpf.InputStream;
                fileContent = new byte[hpf.ContentLength];
                int iStatus = fileInStream.Read(fileContent, 0, hpf.ContentLength);
                fileInStream.Flush();
                fileInStream.Close();

                model.dsc_img = fileContent;
            }
            else {
                model.dsc_img = Photo;
            }
 
            bll.EditDeviceSpotCheck(model);
            return Json(new { Result = true, Message = "修改成功！" });
        }

        [HttpPost]
        [Log(LogType = 3, Action = "删除设备保养/点检项点维护数据")]
        public JsonResult DelDeviceSpotCheck(string id)
        {
            bll.DelDeviceSpotCheck(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 设备保养计划管理
        [Permission]
        public ActionResult DevicePlan(Device_upKeepPlanModel model)
        {
            int totalCount = 100;
            ViewBag.DevicePlan = bll.DevicePlanForPage(model, out totalCount);
            ViewBag.Device = bll.GetDevice();
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
        [Permission]
        public ActionResult AddDevicePlan()
        {
            ViewBag.Device = bll.GetDevice();
            ViewBag.UpKeepTypeInfo = SysBLL.GetBaseDataTypeValue("DeviceUpkeepType");
            return View("EditDevicePlan");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加设备保养计划管理")]
        public JsonResult AddDevicePlan(Device_upKeepPlanModel model)
        {
            bll.AddDevicePlan(model);
            return Json(new { Result = true, Message = "添加成功！" });
        }

        [Permission]
        public ActionResult EditDevicePlan(int id)
        {
            ViewBag.DevicePlan = bll.GetDevicePlanbyId(id);
            ViewBag.UpKeepTypeInfo = SysBLL.GetBaseDataTypeValue("DeviceUpkeepType");
        
            ViewBag.Device = bll.GetDevice();
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "修改设备保养计划管理")]
        public JsonResult EditDevicePlan(Device_upKeepPlanModel model)
        {
            bll.EditDevicePlan(model);
            return Json(new { Result = true, Message = "修改成功！" });
        }

        [HttpPost]
        [Log(LogType = 3, Action = "删除设备保养计划管理")]
        public JsonResult DelDevicePlan(string id)
        {
            bll.DelDevicePlan(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        #endregion

        #region

        /// <summary>
        /// 查询设备保养维护计划明细 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult DevicePlanDetail(Device_upkeepPlanDetailModel model)
        {
            ViewBag.udID = model.udID;
            int totalCount = 0;
            ViewBag.DevicePlanDetaillist = bll.DevicePlanDetailForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 返回二进制图片，展示图片在页面上 
        /// </summary>
        /// <param name="id"></param>
        public void GetudPicture(int id)
        {
            var entity = bll.GetDevicePlanDetail().Where(p => p.id == id).FirstOrDefault();
            if (entity != null && entity.udimg != null)
            {
                byte[] HeadPortrait = entity.udimg;
                Response.BinaryWrite(HeadPortrait);
            }
        }


        [HttpPost]
        [Log(LogType = 2, Action = "添加设备保养计划明细")]
        public JsonResult SaveDevicePlanDetail(Device_upkeepPlanDetailModel model)
        {
            if (model.id != 0) { Device_upkeepPlanDetailModel models = bll.GetDevicePlanDetail().Where(p => p.id == model.id).FirstOrDefault(); }

            //if (model.isDelimg == 1) { model.udimg = new byte[0]; }

            if (model.id == 0) { bll.AddDevicePlanDetail(model); }
            else { bll.EditDevicePlanDetail(model); }
            return Json(new { Result = true, Message = "保存成功！" });
        }



        [Log(LogType = 3, Action = "删除设备保养计划明细")]
        [HttpPost]
        public JsonResult DelDevicePlanDetail(string id)
        {
            bll.DelDevicePlanDetail(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }




        #endregion

        #region 设备提醒管理
        [Permission]
        public ActionResult DeviceRemind(DeviceRemindModel model)
        {
            int totalCount = 100;
            ViewBag.DeviceRemindlist = bll.GetDeviceRemindForPage(model, out totalCount);
            ViewBag.DeviceInfo = bll.GetDevice();
            ViewBag.ToolsTypeInfo = SysBLL.GetBaseDataTypeValue("ToolsType");
            ViewBag.AuthVal = GetAuth();
            ViewBag.TotalCount = totalCount;
            return View();
        }
        #endregion

        #region 试验项目标准范围表
        //[Permission]
        //public ActionResult TestItemValue(TestItemModel model)
        //{
        //    int totalCount = 100;
        //    ViewBag.TestItemValue = bll.TestItemValueForPage(model, out totalCount);
        //    ViewBag.TotalCount = totalCount;
        //    ViewBag.BaseProduct = ProductInfobll.GetBaseProduct();//产品
        //    ViewBag.ItemType = SysBLL.GetBaseDataTypeValue("TestItemType");//试验项类型
        //    ViewBag.Item = SysBLL.GetBaseDataTypeValue("TestItem");//试验项名称
        //    ViewBag.AuthVal = GetAuth();
        //    return View();
        //}

        [Permission]
        public ActionResult AddTestItemValue()
        {
            ViewBag.BaseProduct = ProductInfobll.GetBaseProduct();//产品
            ViewBag.ItemType = SysBLL.GetBaseDataTypeValue("TestItemType");//试验项类型
            ViewBag.Item = SysBLL.GetBaseDataTypeValue("TestItem");//试验项名称
            return View("EditTestItemValue");
        }
        //[Permission]
        //public ActionResult EditTestItemValue(int id)
        //{
        //    ViewBag.TestItemValue = bll.getTestItemValue(id);
        //    ViewBag.BaseProduct = ProductInfobll.GetBaseProduct();//产品
        //    ViewBag.ItemType = SysBLL.GetBaseDataTypeValue("TestItemType");//试验项类型
        //    ViewBag.Item = SysBLL.GetBaseDataTypeValue("TestItem");//试验项名称
        //    return View();
        //}

        //[HttpPost]
        //[Log(LogType = 2, Action = "添加试验项目标准范围表")]
        //public JsonResult AddTestItemValue(TestItemModel model)
        //{
        //    bll.AddTestItemValue(model);
        //    return Json(new { Result = true, Message = "添加成功！" });
        //}

        //[HttpPost]
        //[Log(LogType = 2, Action = "修改试验项目标准范围表")]
        //public JsonResult EditTestItemValue(TestItemModel model)
        //{
        //    bll.EditTestItemValue(model);
        //    return Json(new { Result = true, Message = "修改成功！" });
        //}

        //[HttpPost]
        //[Log(LogType = 3, Action = "删除试验项目标准范围表")]
        //public JsonResult DelTestItemValue(string id)
        //{
        //    bll.DelTestItemValue(id);
        //    return Json(new { Result = true, Message = "删除成功！" });
        //}

        #endregion

        #region 设备运行情况 WZQ
        /// <summary>
        /// 设备运行情况
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult DeviceRun(DeviceRunModel model)
        {
            int totalCount = 100;
            ViewBag.DeviceRunlist = bll.GetDeviceRunForPage(model, out totalCount);
            ViewBag.DeviceInfo = bll.GetDevice();
            ViewBag.TotalCount = totalCount;
            return View();
        }
        #endregion

        /// <summary>
        /// 点检首页 肖玉新
        /// </summary>
        /// <returns></returns>
        public ActionResult DeviceChecking(DeviceCheckingModel model) {
            int totalCount = 100;
            ViewBag.DevicePlansw = bll.DevicePlandainjian(model, out totalCount);
            ViewBag.Device = bll.GetDevice();
            ViewBag.TotalCount = totalCount;
            //ViewBag.AuthVal = GetAuth();
            return View();
          
        }

        /// <summary>
        /// 点检明细表 肖玉新
        /// </summary>
        /// <returns></returns>
        public ActionResult DeviceCheckingDEtail(DeviceCheckingDetailsModel model) {
            int totalCount = 100;
            ViewBag.faultlist = Sysbll.GetBaseDataValue("deviceCheckType");
            ViewBag.ckid = model.DevCheckID;
            ViewBag.DevicePlanswminnxin = bll.DeviceCheckingDEtailsancheng(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            return View();
        }
        /// <summary>
        /// 保养记录首页 肖玉新
        /// </summary>
        /// <returns></returns>
        public ActionResult DeviceUpkeepplan(Device_upKeepPlanModel model) {
            int totalCount = 100;
            ViewBag.DevicePlanswbaoya = bll.DeviceCheckincektishouye(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.Device = bll.GetDevice();
            return View();
        }
        /// <summary>
        /// 保养记录明细表
        /// </summary>
        /// <returns></returns>
        public ActionResult DeviceUpkeepplanminxi(Device_upkeepPlanDetailModel model) {
            int totalCount = 100;
            ViewBag.udID = model.udID;
            ViewBag.DevicePlanswbaoyaminx = bll.DeviceCheckincektiminxin(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            return View();
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上 
        /// </summary>
        /// <param name="id"></param>
        public void GetudPictursswse(int id)
        {
            var entity = bll.DeviceCheckincektitupia(id);
            if (entity != null && entity[0].udimg != null)
            {
                byte[] HeadPortrait = entity[0].udimg;
                Response.BinaryWrite(HeadPortrait);
            }
        }

    }
}
