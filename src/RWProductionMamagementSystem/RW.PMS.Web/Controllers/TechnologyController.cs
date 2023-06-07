using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Sys;
using RW.PMS.Web.Filter;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    /// <summary>
    /// 工艺
    /// </summary>
    public class TechnologyController : BaseController
    {
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_System SysBLL = DIService.GetService<IBLL_System>();
        IBLL_Follow bll = DIService.GetService<IBLL_Follow>();
        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();

        private static byte[] Photo;

        #region 工位&产品型号关联配置

        [Permission]
        public ActionResult BaseGwProdDef(BaseGwProdDefModel model)
        {
            ViewBag.prodModelID = model.prodModelID == null ? 0 : model.prodModelID;
            ViewBag.operationID = model.operationID == null ? 0 : model.operationID;
            int totalCount = 100;
            ViewBag.BaseGwProdDeflist = Basebll.GetPagingBaseGwProdDef(model, out totalCount);
            ViewBag.GongWeiInfo = Basebll.GetGongWei();
            ViewBag.ProductModelInfo = Basebll.GetProductDrawingNoModel();//Basebll.GetProductModel();
            ViewBag.WuliaoInfo = Basebll.GetWuliaoType();
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult AddBaseGwProdDef()
        {
            ViewData.Model = new BaseGwProdDefModel();
            ViewBag.GongWeiInfo = Basebll.GetGongWei();
            ViewBag.ProductModelInfo = Basebll.GetProductDrawingNoModel();
            ViewBag.WuliaoInfo = Basebll.GetWuliaoType();
            ViewBag.ProgramInfo = Basebll.GetBaseProgram();
            return View("EditBaseGwProdDef");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加工位&产品型号关联配置信息")]
        public JsonResult AddBaseGwProdDef(BaseGwProdDefModel model)
        {
            Basebll.AddBaseGwProdDef(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpGet]
        [Permission]
        public ActionResult EditBaseGwProdDef(int id)
        {
            BaseGwProdDefModel entity = Basebll.GetBaseGwProdDefId(id);
            ViewBag.GongWeiInfo = Basebll.GetGongWei();
            ViewBag.ProductModelInfo = Basebll.GetProductDrawingNoModel();
            ViewBag.WuliaoInfo = Basebll.GetWuliaoType();
            ViewBag.ProgramInfo = Basebll.GetBaseProgram();
            ViewData.Model = entity;
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改工位&产品型号关联配置信息")]
        public JsonResult EditBaseGwProdDef(BaseGwProdDefModel model)
        {
            Basebll.EditBaseGwProdDef(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除工位&产品型号关联配置信息")]
        [HttpPost]
        public JsonResult DelBaseGwProdDef(string id)
        {
            Basebll.DeleteBaseGwProdDef(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        /// <summary>
        /// 根据产品型号 查询所有工序编码、名称、序号
        /// </summary>
        /// <param name="PID"></param>
        /// <returns></returns>
        public JsonResult GetPartGongxuByPID(int PID)
        {
            return Json(Basebll.GetPartGongxu(PID));
        }

        /// <summary>
        /// 获取工位下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetGongWei()
        {
            return Json(Basebll.GetGongWei());
        }

        /// <summary>
        /// 获取产品型号下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProductModel()
        {
            return Json(Basebll.GetProductModel());
        }

        /// <summary>
        /// 获取程序下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBaseProgram()
        {
            return Json(Basebll.GetBaseProgram());
        }


        /// <summary>
        /// 保存修改方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Log(LogType = 2, Action = "添加/修改工位&产品型号关联配置")]
        public JsonResult SaveBaseGwProdDef(BaseGwProdDefModel model)
        {
            if (model.ID == 0)
            {
                Basebll.AddBaseGwProdDef(model);
            }
            else
            {
                Basebll.EditBaseGwProdDef(model);
            }
            return Json(new { Result = true, Message = "操作成功！" });
        }


        #endregion

        #region 产品关键零部件
        [Permission]
        public ActionResult BaseProductLingJian(BaseProductBomModel model)
        {
            int totalCount = 100;
            ViewBag.ProductModelInfo = Basebll.GetProductModel();
            ViewBag.ReplaceTypeInfo = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="其他"},
                new SelectListItem(){Value="1",Text="必换件"},
                new SelectListItem(){Value="2",Text="偶换件"},
                new SelectListItem(){Value="3",Text="组件"}
            };
            ViewBag.WuliaoInfo = Basebll.GetWuliao();
            ViewBag.WuliaoTypeInfo = Basebll.GetWuliaoType();
            ViewBag.BaseProductLingJianlist = Basebll.GetPagingBaseProductLingJian(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            int AmsGwId = 131, DisGwID = 34;
            ViewBag.GongweiAmsInfo = Basebll.GetGongWeiArea(AmsGwId);
            ViewBag.GongweiDisInfo = Basebll.GetGongWeiArea(DisGwID);
            // ViewBag.Gongxu = Basebll.GetAllBaseGongxu();

            ViewBag.WuliaoCode = Basebll.GetWuliaoCode(0);
            return View();
        }

        [HttpPost]
        public JsonResult GetWuliaoModelbywlID(int wlID)
        {
            List<WuliaoModelModel> Model = Basebll.GetWuliaoCode(wlID);
            return Json(Model, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult SaveBaseProductBom(BaseProductBomModel model)
        {
            if (model.ID == 0)
            {
                Basebll.AddBaseProductLingJian(model);
            }
            else
            {
                Basebll.EditBaseProductLingJian(model);
            }
            return Json(new { Result = true, Message = "保存成功！" });
        }


        [HttpGet]
        [Permission]
        public ActionResult AddBaseProductLingJian()
        {
            ViewData.Model = new BaseProductBomModel();
            ViewBag.ProductModelInfo = Basebll.GetProductModel();
            ViewBag.ReplaceTypeInfo = new List<SelectListItem>() {
                new SelectListItem(){Value="0",Text="其他"},
                new SelectListItem(){Value="1",Text="必换件"},
                new SelectListItem(){Value="2",Text="偶换件"},
                new SelectListItem(){Value="3",Text="组件"}
            };
            ViewBag.WuliaoInfo = Basebll.GetWuliao();
            ViewBag.WuliaoTypeInfo = Basebll.GetWuliaoType();
            //33	来料区
            //34    拆卸区
            //35	检验区/探伤区
            //37	配料区
            //38	组装区
            //39	试验区 
            int AmsGwId = 131, DisGwID = 34;
            ViewBag.GongweiAmsInfo = Basebll.GetGongWeiArea(AmsGwId);
            ViewBag.GongweiDisInfo = Basebll.GetGongWeiArea(DisGwID);
            return View("EditBaseProductLingJian");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加产品关键零部件信息")]
        public JsonResult AddBaseProductLingJian(BaseProductBomModel model)
        {
            Basebll.AddBaseProductLingJian(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改产品关键零部件信息")]
        public JsonResult EditBaseProductLingJian(BaseProductBomModel model)
        {
            Basebll.EditBaseProductLingJian(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除产品关键零部件信息")]
        [HttpPost]
        public JsonResult DelBaseProductLingJian(string id)
        {
            Basebll.DeleteBaseProductLingJian(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 组件质检提示说明
        /// <summary>
        /// 组件质检提示说明分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseProdLjCheckTip(BasePartCheckTipModel model)
        {
            ViewBag.prodLjDefId = model.prodLjDefId;
            int totalCount = 0;
            ViewBag.BaseProdLjCheckTiplist = Basebll.GetPagingProdLjCheckTip(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上 测量标注位置示意图
        /// </summary>
        /// <param name="id"></param>
        public void GetSamplePicture(int id)
        {
            var entity = Basebll.GetProdLjCheckTip().Where(p => p.ID == id).FirstOrDefault();
            if (entity != null && entity.samplePicture != null)
            {
                byte[] HeadPortrait = entity.samplePicture;
                Response.BinaryWrite(HeadPortrait);
            }
        }


        /// <summary> 
        /// 返回二进制图片，展示图片在页面上 测量工具图片
        /// </summary>
        /// <param name="id"></param>
        public void GetToolPicture(int id)
        {
            var entity = Basebll.GetProdLjCheckTip().Where(p => p.ID == id).FirstOrDefault();
            if (entity != null && entity.toolPicture != null)
            {
                byte[] HeadPortrait = entity.toolPicture;
                Response.BinaryWrite(HeadPortrait);
            }
        }



        [HttpPost]
        [Log(LogType = 2, Action = "添加质检提示说明")]
        public JsonResult SavePartCheckTip(BasePartCheckTipModel model)
        {
            if (model.ID != 0) { BasePartCheckTipModel models = Basebll.GetBaseProdLjCheckTipId(model.ID); }

            if (model.isDelsamplePicture == 1) { model.samplePicture = new byte[0]; }
            if (model.isDeltoolPicture == 1) { model.toolPicture = new byte[0]; }

            if (model.ID == 0) { Basebll.AddBaseProdLjCheckTip(model); }
            else { Basebll.EditBaseProdLjCheckTip(model); }
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpGet]
        [Permission]
        public ActionResult AddProdLjCheckTip(int prodLjDefId)
        {
            BasePartCheckTipModel model = new BasePartCheckTipModel();
            model.prodLjDefId = prodLjDefId;
            ViewData.Model = model;
            return View("EditProdLjCheckTip");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加质检提示说明")]
        public JsonResult AddProdLjCheckTip(BasePartCheckTipModel model)
        {
            HttpPostedFileBase hpf = Request.Files["CheckImage"];
            if (hpf != null)
            {
                //fileContent 这个byte[]就是保存的值了, 可以直接保存到数据库        
                Stream fileInStream = hpf.InputStream;
                var fileContent = new byte[hpf.ContentLength];
                int iStatus = fileInStream.Read(fileContent, 0, hpf.ContentLength);
                fileInStream.Flush();
                fileInStream.Close();

                model.samplePicture = fileContent;
            }
            Basebll.AddBaseProdLjCheckTip(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpGet]
        [Permission]
        public ActionResult EditProdLjCheckTip(int id)
        {
            BasePartCheckTipModel entity = Basebll.GetBaseProdLjCheckTipId(id);
            ViewData.Model = entity;
            Photo = entity.samplePicture;
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改质检提示说明")]
        public JsonResult EditProdLjCheckTip(BasePartCheckTipModel model)
        {
            bool isUpdateHeadPortrait = false;
            var fileContent = new byte[0];
            HttpPostedFileBase hpf = Request.Files["CheckImage"];
            if (hpf != null)
            {
                Stream fileInStream = hpf.InputStream;
                fileContent = new byte[hpf.ContentLength];
                int iStatus = fileInStream.Read(fileContent, 0, hpf.ContentLength);
                fileInStream.Flush();
                fileInStream.Close();
                isUpdateHeadPortrait = fileContent.Length > 0 ? true : false;
            }
            if (model.IsDelPhoto == true)
            {
                model.samplePicture = new byte[0];
            }
            else
            {
                model.samplePicture = isUpdateHeadPortrait == true ? fileContent : Photo;
            }
            Basebll.EditBaseProdLjCheckTip(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除质检提示说明")]
        [HttpPost]
        public JsonResult DelPartCheckTip(string id)
        {
            Basebll.DeleteBaseProdLjCheckTip(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        public JsonResult StepNoMaxOrder(int prodLjDefId)
        {
            int stepNo = Basebll.GetStepNo(prodLjDefId);
            return Json(stepNo, JsonRequestBehavior.AllowGet);
        }



        #endregion

        #region 条码卡关联设置
        /// <summary>
        /// 条码关联设置
        /// </summary>
        /// <param name="model">工位权限信息实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult FollowBarcode(BaseBarcodeModel model)
        {

            int totalCount = 0;
            ViewBag.FollowBarcodeList = bll.GetFollowBarcodeForPage(model, out totalCount);
            ViewBag.CardTypeInfo = bll.GetCardType();//获取条码卡类型下拉
            ViewBag.GongWeiInfo = Basebll.GetGongWei();//绑定工位下拉
            int AmsGwId = 131;
            ViewBag.GongweiAmsInfo = Basebll.GetGongWeiArea(AmsGwId);//组装工位
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult AddFollowBarcode()
        {
            ViewData.Model = new BaseBarcodeModel();
            ViewBag.CardTypeInfo = bll.GetCardType();//获取条码卡类型下拉
            ViewBag.GongWeiInfo = Basebll.GetGongWei();//绑定工位下拉
            ViewBag.AreaInfo = SysBLL.GetBaseDataTypeValue("gwArea");//区域
            int AmsGwId = 131;
            ViewBag.GongweiAmsInfo = Basebll.GetGongWeiArea(AmsGwId);//组装工位
            return View("EditFollowBarcode");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加条码卡关联信息")]
        public JsonResult AddFollowBarcode(BaseBarcodeModel model)
        {
            if (model.Num != 0)
            {
                bll.AddFollowBarcodeManyCard(model);
                return Json(new { Result = true, Message = "保存成功！" });
            }
            else
            {
                bool isExist = bll.GetSelectCard(model.c_cardNo);
                if (!isExist)
                {
                    bll.AddFollowBarcode(model);
                    return Json(new { Result = true, Message = "保存成功！" });
                }
                else
                {
                    return Json(new { Result = false, Message = "已经存在相同的条码卡号！" });
                }
            }
        }

        [HttpGet]
        [Permission]
        public ActionResult EditFollowBarcode(int id)
        {
            BaseBarcodeModel entity = bll.GetFollowBarcodeId(id);
            ViewData.Model = entity;
            ViewBag.CardTypeInfo = bll.GetCardType();//获取条码卡类型下拉
            ViewBag.GongWeiInfo = Basebll.GetGongWei();//绑定工位下拉
            int AmsGwId = 131;
            ViewBag.GongweiAmsInfo = Basebll.GetGongWeiArea(AmsGwId);//组装工位
            ViewBag.AreaInfo = SysBLL.GetBaseDataTypeValue("gwArea");//区域
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改条码卡关联信息")]
        public JsonResult EditFollowBarcode(BaseBarcodeModel model)
        {
            bll.EditFollowBarcode(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除条码卡关联信息")]
        [HttpPost]
        public JsonResult DeleteFollowBarcode(string id)
        {
            bll.DeleteFollowBarcode(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 部件质量检测项标准范围值

        /// <summary>
        /// 部件质量检测项标准范围值 分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult BasePartCheckValue(BasePartCheckValueModel model)
        {
            ViewBag.partCheck_ID = model.partCheck_ID;
            ViewBag.prodLjDefId = model.prodLjDefId;
            int totalCount = 0;
            ViewBag.BasePartCheckValuelist = Basebll.GetPartCheckValue(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            ViewBag.programValueType = SysBLL.GetBaseDataTypeValue("programValueType");//获取数据字典中【programValueType】编码的所有数据
            ViewBag.programEqualType = SysBLL.GetBaseDataTypeValue("programEqualType");//获取数据字典中【programEqualType】编码的所有数据
            return View();
        }

        [HttpPost]
        public JsonResult SavePartCheckValue(BasePartCheckValueModel model)
        {
            if (model.id == 0) { Basebll.AddPartCheckValue(model); }
            else { Basebll.EditPartCheckValue(model); }
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpPost]
        public JsonResult DelPartCheckValue(string id)
        {
            Basebll.DeletePartCheckValue(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region  工具参数配方 WZQ
        /// <summary>
        /// 工具参数配方管理
        /// </summary>
        /// <param name="model">工具参数配方实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult ToolforMula(BaseToolforMulaModel model)
        {
            int totalCount = 0;
            ViewBag.ToolforMulaList = Basebll.GetToolforMulaPaging(model, out totalCount);
            ViewBag.GongjuTypeInfo = SysBLL.GetBaseDataTypeValue("GongjuType");
            ViewBag.InstrumentTestType = SysBLL.GetBaseDataTypeValue("InstrumentTestType");
            ViewBag.InstrumentTestItem = SysBLL.GetBaseDataTypeValue("InstrumentTestItem");
            ViewBag.GongjuInfo = Basebll.GetAllBaseGongJu();
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存工具参数配方管理
        /// </summary>
        /// <param name="model">工具参数配方管理实体类 </param>
        /// <returns>返回true和false</returns>
        public JsonResult SaveBaseToolforMula(BaseToolforMulaModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
            model.tfmCreaterID = user.userID;
            model.tfmUpdaterID = user.userID;

            var b = Basebll.SaveBaseToolforMula(model);
            if (b)
            {
                return Json(new { Result = b, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = b, Message = "保存失败！" });
            }
        }

        [Log(LogType = 3, Action = "删除工具参数配方管理")]
        [HttpPost]
        public JsonResult DelBaseToolforMula(string id)
        {
            Basebll.DelBaseToolforMula(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        /// <summary>
        /// 根据设备ID带出设备IP
        /// </summary>
        /// <param name="DevID">设备ID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetToolTypeID(int ToolID)
        {
            var ToolTypeID = Basebll.GetAllBaseGongJu().Where(x => x.ID == ToolID).FirstOrDefault().GjTypeID;
            return Json(new { ToolTypeID = ToolTypeID });
        }

        #endregion

        #region  工具参数配方明细 WZQ
        /// <summary>
        /// 工具参数配方明细管理
        /// </summary>
        /// <param name="model">工具参数配方明细实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult ToolforMulaDetail(BaseToolforMulaDetailModel model)
        {
            int totalCount = 0;
            ViewBag.TfmID = model.tfmID;
            ViewBag.ToolforMulaDetailList = Basebll.GetToolforMulaDetailPaging(model, out totalCount);
            ViewBag.SomeTestItemsInfo = SysBLL.GetBaseDataTypeValue("SomeTestItems");//测试项点
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存工具参数配方管理明细
        /// </summary>
        /// <param name="model">工具参数配方管理明细实体类 </param>
        /// <returns>返回true和false</returns>
        public JsonResult SaveBaseToolforMulaDetail(BaseToolforMulaDetailModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });

            var b = Basebll.SaveBaseToolforMulaDetail(model);
            if (b)
            {
                return Json(new { Result = b, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = b, Message = "保存失败！" });
            }
        }

        [Log(LogType = 3, Action = "删除工具参数配方管理明细")]
        [HttpPost]
        public JsonResult DelBaseToolforMulaDetail(string id)
        {
            Basebll.DelBaseToolforMulaDetail(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion
    }
}
