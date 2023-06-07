using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.InComming;
using RW.PMS.Model.Sys;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    /// <summary>
    /// 来料
    /// </summary>
    public class InCommingController : BaseController
    {
        IBLL_Account Accountbll = DIService.GetService<IBLL_Account>();
        IBLL_InComming bll = DIService.GetService<IBLL_InComming>();
        IBLL_ProductInfo Productbll = DIService.GetService<IBLL_ProductInfo>();
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_System Systembll = DIService.GetService<IBLL_System>();

        // followProductInfoCol 字段参数配置
        public string followProductInfoCol = "";
        // followProductInfoName Lable参数配置
        public string followProductInfoName = "";
        // followProductInfoCombox Combox参数配置
        public string followProductInfoCombox = "";
        /// <summary>
        /// 存储实体类数据类型
        /// </summary>
        Dictionary<string, object> dic = new Dictionary<string, object>();
        Dictionary<string, string> dics = new Dictionary<string, string>();
        // 接收参数并分割
        //string[] ProductInfoName = null;
        // 接收参数并分割字段
        //string[] ProductInfoCol = null;
        // 接收参数并分割字段
        //string[] ProductInfoCombox = null;
        // 接收动态生成页面样式
        //string[] ProductInfoCssStyle = null;

        /// <summary>
        /// 来料主页面
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        //[Permission]
        //public ActionResult InComming(InCommingModel models)
        //{
        //    int totalCount = 100;
        //    ViewBag.InCommingList = bll.GetFollowMain_Finished(models, out totalCount);
        //    ViewBag.TotalCount = totalCount;
        //    ViewBag.AuthVal = GetAuth();
        //    UserModel model = Systembll.GetUser(new UserModel() { userName = this.HttpContext.User.Identity.Name });
        //    ViewBag.UserInfo = model;
        //    ViewBag.ProductModelInfo = Basebll.GetProductModel();//产品-型号
        //    return View();
        //}

        /// <summary>
        /// 添加页面
        /// </summary>
        /// <returns></returns>
        //public ActionResult AddInComming()
        //{
        //    AddControls();
        //    ViewBag.RepairType = Systembll.GetBaseDataTypeValue("repairType");//检修类型
        //    ViewBag.CarModel = Systembll.GetBaseDataTypeValue("subwayType");//车型
        //    ViewBag.ProductModelInfo = Basebll.GetProductModel();//产品-型号
        //    ViewBag.KeyWlLj = bll.GetProductComingHangWuliao(0);//悬挂条码卡关键部件
        //    ViewBag.PlanProdList = bll.GetPlanProdList();//获取所有计划信息
        //    return View("EditInComming");
        //}

        /// <summary>
        /// 来料区产品录入
        /// </summary>
        /// <param name="models"></param>
        /// <param name="pp_guid"></param>
        /// <returns></returns>
        [HttpPost]
        //public JsonResult AddInComming(List<InCommingModel> models, string pp_guid)
        //{
        //    string barcodemsg = "";
        //    var userName = this.HttpContext.User.Identity.Name;
        //    var result = AddFollowMain_Gw_Detail(models, pp_guid, out barcodemsg, userName);
        //    var message = "添加成功！";
        //    if (result == 1)
        //    {
        //        message = "该产品编码已存在！";
        //    }
        //    else if (result == 2)
        //    {
        //        message = barcodemsg;
        //    }
        //    var returnUrl = result == 0 ? "/InComming/InComming" : "";
        //    return Json(new { Result = result, Message = message, ReturnUrl = returnUrl });
        //}

        /// <summary>
        /// 添加值初始化操作 产品录入用
        /// </summary>
        /// <param name="models"></param>
        /// <param name="pp_guid"></param>
        /// <param name="msg"></param>
        /// <param name="userName"></param>
        /// <returns>返回状态 0：为保存成功 1：为产品编号已存在 2：动态放回卡号状态</returns>
        //public int AddFollowMain_Gw_Detail(List<InCommingModel> models, string pp_guid, out string msg, string userName = "")
        //{
           
            //var status = 0;
            //var barcode = true;
            //string prodmsg = "";
            //string barcodemsg = "";
            ////检测产品编号是否存在 1
            //var check = bll.ExistsProdNoByMsg(models[0].pf_prodNo, out  prodmsg);
            ////判断添加时是否输入了 条码卡如何没有不进判断
            //if (models[0].fd_barcode != null && models[0].fd_barcode != "")
            //{
            //    //如果有条码卡直接点击保存需要检测条码卡状态是否可用 2
            //    BaseBarcodeModel fbEnty = null;
            //    barcode = bll.CheckCardType(models[0].fd_barcode, "0", out fbEnty, out barcodemsg);
            //}

            //if (check == true)
            //{
            //    if (barcode == true)
            //    {
            //        //处理 产品计划GUID 如果为空给默认值
            //        //var ppguid = new Guid();
            //        var ppguid = pp_guid == "" ? "00000000-0000-0000-0000-000000000000" : pp_guid;
            //        SysconfigModel config = Systembll.GetConfigByCode("InCommingGW");//获取参数配置中配置的Code
            //        string gwcode = config.cfg_value;
            //        var GongWei = bll.GetGongWeiByCode(gwcode);//根据Code获取来料区工位ID
            //        BaseDataModel basedata = Systembll.GetTypeById(GongWei.AreaID);//根据工位中区域ID查询区域实体
            //        ProductModelModel product = bll.GetProdModelByID(models[0].pf_prodModelID.Value);//根据型号ID查询  产品型号所有信息
            //        ProductInfoModel pf = new ProductInfoModel();
            //        pf.pf_prodNo = models[0].pf_prodNo;
            //        pf.pf_prodID = product.prodID ?? 0;//models[0].pf_prodID;
            //        pf.pf_prodModelID = models[0].pf_prodModelID.Value;
            //        pf.pf_carModelID = models[0].pf_carModelID.Value;
            //        pf.pf_carNo = models[0].pf_carNo;
            //        pf.pf_orderNo = models[0].pf_orderNo;
            //        pf.pf_groupNo = models[0].pf_groupNo;
            //        pf.pf_factoryID = models[0].pf_factoryID.Value;
            //        pf.pf_stampNo = models[0].pf_stampNo;
            //        pf.pf_date = models[0].pf_date;
            //        pf.pf_weight = models[0].pf_weight;
            //        pf.pf_compressor = models[0].pf_compressor;
            //        pf.pf_remark = models[0].pf_remark;
            //        FollowProductionModel fpModel = new FollowProductionModel();
            //        fpModel.fp_guid = Guid.NewGuid();
            //        fpModel.pp_guid = new Guid(ppguid);//计划表GUID 需要获取表单中PP_GUID
            //        //fp.fp_prodNo_sys = models[0].fp_prodNo_sys;
            //        fpModel.fp_repairTypeID = models[0].fp_repairTypeID.Value;
            //        fpModel.fp_finishStatus = 0;
            //        fpModel.fp_resultIsOK = -1;
            //        fpModel.fp_resultMemo = "";
            //        fpModel.fp_report = new byte[0];
            //        fpModel.fp_remark = "";
            //        fpModel.fp_uploadFlag = 0;
            //        FollowMainModel fmModel = new FollowMainModel();
            //        fmModel.fm_guid = Guid.NewGuid();
            //        //fm.Fm_starttime =
            //        //fm.Fm_finishtime =
            //        fmModel.fm_finishStatus = 0;
            //        fmModel.fm_warehouse = "";
            //        fmModel.fm_isSend = 0;
            //        //fm.Fm_sendTime = 
            //        //fm.Fm_sender =
            //        fmModel.fm_curAreaID = GongWei.AreaID;
            //        fmModel.fm_curGwID = GongWei.ID;
            //        fmModel.fm_curGw = GongWei.Gwname;
            //        fmModel.fm_creatorID = Accountbll.GetUserIDByName(userName);
            //        fmModel.fm_creator = Accountbll.GetEmpName(userName);
            //        fmModel.fm_resultIsOK = 0;
            //        fmModel.fm_resultMemo = "";
            //        fmModel.fm_remark = "";
            //        fmModel.fm_uploadFlag = 0;
            //        FollowGwModel fgModel = new FollowGwModel();
            //        fgModel.fgw_guid = Guid.NewGuid();
            //        fgModel.fgw_gwID = GongWei.ID;
            //        fgModel.fgw_gwName = GongWei.Gwname;
            //        fgModel.fgw_areaID = GongWei.AreaID;
            //        fgModel.fgw_areaName = basedata.bdname;
            //        fgModel.fgw_operID = Accountbll.GetUserIDByName(userName);
            //        fgModel.fgw_oper = Accountbll.GetEmpName(userName);

            //        //如果添加时扫入条码卡该工位状态赋值
            //        var FgwfollowStatus = 0;
            //        var FgwcheckResult = -1;
            //        var FgwresultMemo = "";
            //        if (models[0].fd_barcode != null && models[0].fd_barcode != "")
            //        {
            //            FgwfollowStatus = 1;
            //            FgwcheckResult = 1;
            //            FgwresultMemo = "合格";
            //        }
            //        fgModel.fgw_followStatus = FgwfollowStatus;
            //        fgModel.fgw_checkResult = FgwcheckResult;
            //        fgModel.fgw_resultMemo = FgwresultMemo;

            //        fgModel.fgw_remark = "";
            //        fgModel.fgw_uploadFlag = 0;
            //        FollowDetailModel fdModel = new FollowDetailModel();
            //        fdModel.fd_guid = Guid.NewGuid();
            //        fdModel.fd_componentId = 0;
            //        fdModel.fd_componentName = "";
            //        fdModel.fd_gwID = GongWei.ID;
            //        fdModel.fd_gwName = GongWei.Gwname;
            //        fdModel.fd_areaID = GongWei.AreaID;
            //        fdModel.fd_areaName = basedata.bdname;
            //        fdModel.fd_barcode = models[0].fd_barcode;
            //        fdModel.fd_wuliaoLJid = models[0].fd_wuliaoLJid;
            //        fdModel.fd_wuliaoLJName = models[0].fd_wuliaoLJName;
            //        fdModel.fd_isWuliaoBox = 0;
            //        fdModel.fd_stampNo = "";
            //        fdModel.fd_operID = Accountbll.GetUserIDByName(userName);
            //        fdModel.fd_oper = Accountbll.GetEmpName(userName);
            //        //如果添加时扫入条码卡进行状态修改赋值
            //        var Fd_followStatus = 0;//追溯状态
            //        var Fd_checkResult = 1;//检验状态
            //        if (models[0].fd_barcode != null && models[0].fd_barcode != "")
            //        {
            //            Fd_followStatus = 1;
            //            Fd_checkResult = 1;
            //        }
            //        fdModel.fd_followStatus = Fd_followStatus;
            //        fdModel.fd_checkResult = Fd_checkResult;
            //        fdModel.fd_resultQty = 0;
            //        fdModel.fd_resultMemo = "";
            //        fdModel.fd_isNextScan = 0;//下一区域扫码状态：0未扫；1已扫
            //        fdModel.fd_isCancel = 0;
            //        fdModel.fd_remark = "";
            //        fdModel.fd_uploadFlag = 0;
            //        //将初始化的实体类传入添加方法
            //        bll.AddFollow(pf, fpModel, fmModel, fgModel, fdModel, new Guid(ppguid));
            //        msg = "";
            //        return status;
            //    }
            //    msg = barcodemsg;
            //    status = 2;
            //    return status;
            //}
            //msg = barcodemsg;
            //status = 1;
            //return status;
            
        //}


        /// <summary>
        /// 根据产品编号 判断是否存在产品生产基础信息
        /// </summary>
        /// <param name="pf_prodNo">产品编号,二次生产时可重复</param>
        /// <returns>返回自定义实体类</returns>
        //[HttpPost]
        //public JsonResult GetProductByProdNo(string pf_ProdNo)
        //{
        //    var data = bll.GetProductByProdNo(pf_ProdNo);
        //    var result = data == null ? false : true;
        //    var field = Productbll.GetConfigByCodeValue("InCommingProductInfoCol");

        //    //productInfo EntityInfo = new productInfo();
        //    //ControlsTypes(EntityInfo);//获取 产品生产基础信息表类型
        //    var DickeyValue = dics;
        //    return Json(new { Data = data, Result = result, Filed = field, dickeyValue = DickeyValue });

        //}


        /// <summary>
        /// 根据 pp_guid 获取产品生产计划表中关联的产品基础信息
        /// </summary>
        /// <param name="guid">生产计划pp_guid</param>
        /// <returns>返回自定义实体类</returns>
        //[HttpPost]
        //public JsonResult GetPlanProdByGuid(string guid)
        //{
        //    var data = bll.GetPlanProdByPfGuid(guid);
        //    var result = data == null ? false : true;
        //    var field = Productbll.GetConfigByCodeValue("InCommingProductInfoCol");

        //    //productInfo EntityInfo = new productInfo();
        //    //ControlsTypes(EntityInfo);//获取 产品生产基础信息表类型
        //    var DickeyValue = dics;

        //    return Json(new { Data = data, Result = result, Filed = field, dickeyValue = DickeyValue });
        //}


        //编辑页面
        //public ActionResult EditInComming(string fm_guid)
        //{
        //    AddControls();
        //    ViewBag.RepairType = Systembll.GetBaseDataTypeValue("repairType");//检修类型
        //    ViewBag.CarModel = Systembll.GetBaseDataTypeValue("subwayType");//车型
        //    ViewBag.ProductModelInfo = Basebll.GetProductModel();//产品-型号
        //    ViewBag.KeyWlLj = bll.GetProductComingHangWuliao(0);//悬挂条码卡关键部件
        //    ViewBag.PlanProdList = bll.GetPlanProdList();//获取所有计划信息
        //    //根据 fm_guid 查询追溯主表关联信息
        //    var incomming = bll.GetInCommingByFmGuid(fm_guid);
        //    ViewBag.InComming = incomming;
        //    if (incomming != null)
        //    {
        //        ViewBag.InCommingDic = ToMap(incomming);
        //    }

        //    return View();
        //}


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="fm_guid"></param>
        /// <returns></returns>
        //[HttpPost]
        //public JsonResult EditInComming(List<InCommingModel> models)
        //{
        //    var msg = "";
        //    //调用 更新初始化操作
        //    var result = UpdateFollowMain(models, out msg);
        //    var message = "修改成功！";
        //    if (result == 1)
        //    {

        //    }
        //    else if (result == 2)
        //    {
        //        message = msg;
        //    }
        //    var returnUrl = result == 0 ? "/InComming/InComming" : "";
        //    return Json(new { Result = result, Message = message, ReturnUrl = returnUrl });
        //}

        /// <summary>
        /// 修改初始化操作
        /// </summary>
        /// <param name="models"></param>
        /// <param name="msg"></param>
        /// <param name="userName"></param>
        /// <returns>返回更新状态 0：更新成功</returns>
        //public int UpdateFollowMain(List<InCommingModel> models, out string msg, string userName="")
        //{
        //    int status = 0;//更新状态
        //    //string barcodemsg = "";
        //    //var barcode = true;
        //    //if (models[0].fd_barcode != null && models[0].fd_barcode != "")
        //    //{
        //    //    //如果有条码卡直接点击保存需要检测条码卡状态是否可用 2
        //    //    BaseBarcodeModel fbEnty = null;
        //    //    barcode = bll.CheckCardType(models[0].fd_barcode, "0", out fbEnty, out barcodemsg);
        //    //}

        //    //if (barcode == true)
        //    //{
        //    //根据 追溯主表Guid 获取其他表主键
        //    var incomming = bll.GetInCommingByFmGuid(models[0].fm_guid.ToString());
        //    SysconfigModel config = Systembll.GetConfigByCode("InCommingGW");//获取参数配置中配置的Code
        //    string gwcode = config.cfg_value;
        //    var GongWei = bll.GetGongWeiByCode(gwcode);//根据Code获取来料区工位ID
        //    BaseDataModel basedata = Systembll.GetTypeById(GongWei.AreaID);//根据工位中区域ID查询区域实体
        //    ProductModelModel product = bll.GetProdModelByID(models[0].pf_prodModelID.Value);//根据型号ID查询  产品型号所有信息

        //    ProductInfoModel pf = new ProductInfoModel();
        //    pf.pf_ID = incomming.pf_ID;
        //    pf.pf_prodNo = models[0].pf_prodNo;
        //    pf.pf_prodID = product.prodID ?? 0;//models[0].pf_prodID;
        //    pf.pf_prodModelID = models[0].pf_prodModelID.Value;
        //    pf.pf_carModelID = models[0].pf_carModelID.Value;
        //    pf.pf_carNo = models[0].pf_carNo;
        //    pf.pf_orderNo = models[0].pf_orderNo;
        //    pf.pf_groupNo = models[0].pf_groupNo;
        //    pf.pf_factoryID = models[0].pf_factoryID.Value;
        //    pf.pf_stampNo = models[0].pf_stampNo;
        //    pf.pf_date = models[0].pf_date;
        //    pf.pf_weight = models[0].pf_weight;
        //    pf.pf_compressor = models[0].pf_compressor;
        //    pf.pf_remark = models[0].pf_remark;
        //    FollowProductionModel fp = new FollowProductionModel();
        //    fp.fp_guid = incomming.fp_guid.Value;
        //    fp.fp_prodNo_sys = models[0].fp_prodNo_sys;
        //    fp.fp_repairTypeID = models[0].fp_repairTypeID.Value;
        //    fp.fp_finishStatus = 0;
        //    fp.fp_resultIsOK = -1;
        //    fp.fp_resultMemo = "";
        //    fp.fp_report = new byte[0];
        //    fp.fp_remark = "";
        //    fp.fp_uploadFlag = 0;
        //    FollowDetailModel fd = new FollowDetailModel();
        //    fd.fd_guid = incomming.fd_guid;
        //    fd.fgw_guid = incomming.fgw_guid;
        //    fd.fm_guid = incomming.fm_guid;
        //    fd.fp_guid = incomming.fp_guid;
        //    fd.fd_componentId = 0;
        //    fd.fd_componentName = "";
        //    fd.fd_gwID = GongWei.ID;
        //    fd.fd_gwName = GongWei.Gwname;
        //    fd.fd_areaID = GongWei.AreaID;
        //    fd.fd_areaName = basedata.bdname;
        //    fd.fd_barcode = models[0].fd_barcode;
        //    fd.fd_wuliaoLJid = models[0].fd_wuliaoLJid;
        //    fd.fd_wuliaoLJName = models[0].fd_wuliaoLJName;
        //    fd.fd_isWuliaoBox = 0;
        //    fd.fd_stampNo = incomming.fd_stampNo;
        //    fd.fd_operID = Accountbll.GetUserIDByName(userName);
        //    fd.fd_oper = Accountbll.GetEmpName(userName);
        //    fd.fd_followStatus = 0;
        //    fd.fd_checkResult = -1;
        //    fd.fd_resultQty = 0;
        //    fd.fd_resultMemo = "";
        //    fd.fd_isNextScan = 0;
        //    fd.fd_isCancel = 0;
        //    fd.fd_remark = "";
        //    fd.fd_uploadFlag = 0;
        //    //修改基础信息
        //    bll.UpadteFollowMain(pf, fp, fd);
        //    msg = "";
        //    return status;
        //    //}
        //    //msg = barcodemsg;
        //    //status = 2;
        //    //return status;
        //}

        //动态获取参数配置中名称
        //public JsonResult GetControls()
        //{
        //    var field = Productbll.GetConfigByCodeValue("InCommingProductInfoCol");
        //    return Json(new { Filed = field });
        //}

        /// <summary>
        /// 判断条形码号是否可用
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        //[HttpPost]
        //public JsonResult CheckCardType(string CardNo)
        //{
        //    BaseBarcodeModel fbEnty = null;
        //    string msg = "";
        //    var check = bll.CheckCardType(CardNo, "0", out fbEnty, out  msg);
        //    return Json(new { Result = check, Message = msg });
        //}


        /// <summary>
        /// 动态添加控件
        /// </summary>
        //public void AddControls()
        //{
        //    ProductInfoCol = Productbll.GetConfigByCodeValue("InCommingProductInfoCol");
        //    ProductInfoName = Productbll.GetConfigByCodeValue("InCommingProductInfoName");
        //    ProductInfoCombox = Productbll.GetConfigByCodeValue("InCommingProductInfoCombox");
        //    ProductInfoCssStyle = Productbll.GetConfigByCodeValue("InCommingProductInfoCssStyle");

        //    //productInfo EntityInfo = new productInfo();
        //    //ControlsType(EntityInfo);//获取 产品生产基础信息表类型

        //    ViewBag.ProductInfoCol = ProductInfoCol;
        //    ViewBag.ProductInfoName = ProductInfoName;
        //    ViewBag.ProductInfoCombox = ProductInfoCombox;
        //    ViewBag.ProductInfoCssStyle = ProductInfoCssStyle;
        //    ViewBag.ProdtctData = dic;

        //}


        /// <summary>
        /// 获取实体类类型
        /// </summary>
        /// <param name="EntityInfo"></param>
        //private void ControlsType(productInfo EntityInfo)
        //{
        //    PropertyInfo[] propertys = EntityInfo.GetType().GetProperties();
        //    foreach (PropertyInfo property in propertys)
        //    {
        //        Type columnType = property.PropertyType;
        //        //因为有些字段设置了可为空，需要转换才能得到它的数据类型
        //        if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            columnType = property.PropertyType.GetGenericArguments()[0];
        //        }
        //        string key = property.Name;
        //        if (!dic.ContainsKey(key))
        //            dic.Add(key, columnType.Name);
        //    }
        //}



        /// <summary>
        /// 获取实体类类型
        /// </summary>
        /// <param name="EntityInfo"></param>
        //private void ControlsTypes(productInfo EntityInfo)
        //{
        //    PropertyInfo[] propertys = EntityInfo.GetType().GetProperties();
        //    foreach (PropertyInfo property in propertys)
        //    {
        //        Type columnType = property.PropertyType;
        //        //因为有些字段设置了可为空，需要转换才能得到它的数据类型
        //        if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
        //        {
        //            columnType = property.PropertyType.GetGenericArguments()[0];
        //        }
        //        string key = property.Name;
        //        if (!dics.ContainsKey(key))
        //            dics.Add(key, columnType.Name);
        //    }
        //}


        /// <summary>
        /// 判断 产品编号 以及 系统产品编号是否同时存在 
        /// </summary>
        /// <param name="prodNo"></param>
        /// <returns></returns>
        //[HttpPost]
        //public JsonResult ExistsProdNoByMsg(string prodNo)
        //{
        //    string msg = "";
        //    var check = bll.ExistsProdNoByMsg(prodNo, out  msg);
        //    return Json(new { Result = check, Message = msg });
        //}


        /// <summary>  
        ///   
        /// 将对象属性转换为key-value对  
        /// </summary>  
        /// <param name="o"></param>  
        /// <returns></returns>  
        public static Dictionary<String, Object> ToMap(Object o)
        {
            Dictionary<String, Object> map = new Dictionary<string, object>();

            Type t = o.GetType();

            PropertyInfo[] pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in pi)
            {
                MethodInfo mi = p.GetGetMethod();

                if (mi != null && mi.IsPublic)
                {
                    map.Add(p.Name, mi.Invoke(o, new Object[] { }));
                }
            }

            return map;

        }


    }
}
