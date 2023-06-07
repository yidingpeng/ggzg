using Newtonsoft.Json;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Plan;
using RW.PMS.Model.Sys;
using RW.PMS.Utils;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    public class BaseInfoController : BaseController
    {
        IBLL_BaseInfo bll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Device devicebll = DIService.GetService<IBLL_Device>();
        IBLL_Plan planbll = DIService.GetService<IBLL_Plan>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();

        private static byte[] Photo;

        #region 产品信息
        /// <summary>
        /// 产品信息分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseProduct(BaseProductModel model)
        {
            int totalCount = 100;
            ViewBag.BaseProductlist = bll.GetPagingBaseProduct(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult AddBaseProduct()
        {
            ViewData.Model = new BaseProductModel();
            return View("EditBaseProduct");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加产品信息")]
        public JsonResult AddBaseProduct(BaseProductModel model)
        {
            bll.AddBaseProduct(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpGet]
        [Permission]
        public ActionResult EditBaseProduct(int id)
        {
            BaseProductModel entity = bll.GetBaseProductId(id);
            ViewData.Model = entity;
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改产品信息")]
        public JsonResult EditBaseProduct(BaseProductModel model)
        {
            bll.EditBaseProduct(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除产品信息")]
        [HttpPost]
        public JsonResult DelBaseProduct(string id)
        {
            bll.DeleteBaseProduct(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }
        #endregion

        #region 产品型号
        /// <summary>
        /// 产品型号信息分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseProductModel(BaseProductModelModel model)
        {
            ViewBag.PID = model.PID;
            int totalCount = 0;
            ViewBag.BaseProductModellist = bll.GetPagingBaseProductModel(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
        [HttpGet]
        [Permission]
        public ActionResult AddBaseProductModel(int PID)
        {
            BaseProductModelModel model = new BaseProductModelModel();
            model.PID = PID;
            ViewData.Model = model;
            return View("EditBaseProductModel");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加产品型号信息")]
        public JsonResult AddBaseProductModel(BaseProductModelModel model)
        {
            bll.AddBaseProductModel(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpGet]
        [Permission]
        public ActionResult EditBaseProductModel(int id)
        {
            BaseProductModelModel entity = bll.GetBaseProductModelId(id);
            ViewData.Model = entity;
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改产品型号信息")]
        public JsonResult EditBaseProductModel(BaseProductModelModel model)
        {
            bll.EditBaseProductModel(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除产品型号信息")]
        [HttpPost]
        public JsonResult DelBaseProductModel(string id)
        {
            bll.DeleteBaseProductModel(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }
         
        [HttpPost]
        [Log(LogType = 2, Action = "添加/修改产品型号信息")]
        public JsonResult SaveBaseProductModel(BaseProductModelModel model)
        {
            if (model.ID == 0)
            {
                bll.AddBaseProductModel(model);
            }
            else
            {
                bll.EditBaseProductModel(model);
            }
            return Json(new { Result = true, Message = "操作成功！" });
        }
         
        #endregion

        #region 齐套分析配置

        /// <summary>
        /// 齐套分析配置
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseBundleAnalysisCfg(BundleAnalysisMaterialConfigModel model)
        {
            ViewBag.ProdModelID = model.ProdModelID == null ? 0 : model.ProdModelID;
            ViewBag.PID = 4;
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 齐套分析配置分页方法
        /// </summary>
        /// <param name="model">model实体</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult BaseBundleAnalysisCfgs(BundleAnalysisMaterialConfigModel model, int PageIndex = 1, int PageSize = 10)
        {
            model.PageIndex = PageIndex;
            model.PageSize = PageSize;
            int TotalCount = 0;
            List<BundleAnalysisMaterialConfigModel> List = planbll.GetBundleAnalysisMaterialConfigList(model, out TotalCount);
            return Json(new { page = PageIndex, rows = List, total = TotalCount }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveBundleAnalysisCfg(BundleAnalysisMaterialConfigModel model)
        {
            string Message = string.Empty;
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            //排重判断
            var list = planbll.GetBundleAnalysisMaterialConfigList(new BundleAnalysisMaterialConfigModel()
            {
                ProdModelID = model.ProdModelID,
                wlID = model.wlID,
                UNID = model.ID
            });
            if (list.Count > 0) return Json(new { Result = false, Message = "数据重复,请确认后操作！" });
            int ret = planbll.SaveBundleAnalysisMaterialConfig(model, out Message);
            bool result = ret > 0 ? true : false;
            string msg = string.Empty;
            if (result == false && Message.Length > 0)
            {
                return Json(new { Result = result, Message = Message });
            }
            else
            {
                msg = result == true ? "保存成功！" : "保存失败！";
            }

            return Json(new { Result = result, Message = msg });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelBundleAnalysisCfg(int id)
        {
            planbll.DeleteBundleAnalysisMaterialConfig(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }


        /// <summary>
        /// 根据产品型号ID获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetBaseProductModel(int id)
        {
            BaseProductModelModel entity = bll.GetBaseProductModelId(id);
            return Json(new { data = entity }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 修改阀值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="threshold">阀值</param>
        /// <returns></returns>
        public JsonResult UpdateThreshold(int id, int threshold)
        {
            planbll.UpdateThreshold(id, threshold);
            return Json(new { Result = true }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 工位信息管理

        /// <summary>
        /// 工位信息分页
        /// </summary>
        /// <param name="model">工位信息实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseGongWei(BaseGongweiModel model)
        {
            int totalCount = 100;
            ViewBag.BaseGongWeiList = bll.GetWorkPositionList(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            ViewBag.gwOPCType = SysBLL.GetBaseDataTypeValue("gwOPCType");//获取数据字典中【gwOPCType】编码的所有数据
            ViewBag.gwOPC = bll.GetGongWeiOPC();//获取工位OPC点位信息
            ViewBag.AreaInfo = SysBLL.GetBaseDataTypeValue("gwArea");//获取所有区域下拉
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult AddBaseGongWei()
        {
            ViewData.Model = new BaseGongweiModel();
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            ViewBag.AreaInfo = SysBLL.GetBaseDataTypeValue("gwArea");//获取所有区域下拉
            ViewBag.gwOPCType = SysBLL.GetBaseDataTypeValue("gwOPCType");//获取数据字典中【gwOPCType】编码的所有数据
            ViewBag.gwOPC = bll.GetGongWeiOPC();//获取工位OPC点位信息
            return View("EditBaseGongWei");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加工位信息")]
        public JsonResult AddBaseGongWei(List<BaseGongweiModel> models, int gwID)
        {
            int ID = models[0].ID;
            string GwName = models[0].gwname;
            bool isExistName = bll.GetGongWeiNameCount(GwName, ID);
            if (isExistName)
            {
                return Json(new { Result = false, Message = "已存在相同工位名称！" });
            }

            bool isExistIP = bll.GetGongWeiIPCount(models[0].IP, ID);
            if (isExistIP)
            {
                return Json(new { Result = false, Message = "已存在相同IP地址！" });
            }
            else
            {
                int result = bll.EditBaseGongWeiOpc(models, gwID);
                if (result > 0)
                    return Json(new { Result = true, Message = "保存成功！", ReturnUrl = "/BaseInfo/BaseGongWei" });
                else
                    return Json(new { Result = false, Message = "保存失败！", ReturnUrl = "/BaseInfo/BaseGongWei" });
            }
        }

        [HttpGet]
        [Permission]
        public ActionResult EditBaseGongWei(int id)
        {
            BaseGongweiModel entity = new BaseGongweiModel();
            var list = bll.GetWorkPositionList(new BaseGongweiModel() { ID = id });
            if (list.Count > 0)
                entity = list[0];
            ViewData.Model = entity;
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            ViewBag.AreaInfo = SysBLL.GetBaseDataTypeValue("gwArea");
            ViewBag.gwOPCType = SysBLL.GetBaseDataTypeValue("gwOPCType");//获取数据字典中【gwOPCType】编码的所有数据
            ViewBag.gwOPC = entity.OPC;//获取工位OPC点位信息
            return View();
        }
        

        [Log(LogType = 3, Action = "删除工位信息")]
        [HttpPost]
        public JsonResult DelBaseGongWei(string id)
        {
            bll.GwDel(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 工位权限信息

        /// <summary>
        /// 工位权限信息分页
        /// </summary>
        /// <param name="model">工位权限信息实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseGongweiRight(BaseGongweiRightModel model)
        {
            ViewBag.GwID = model.gwID;
            int totalCount = 0;
            ViewBag.BaseGongWeiRightList = bll.GetPagingBaseGongweiRight(model, out totalCount);
            ViewBag.GongWeiInfo = bll.GetGongWei();//绑定工位下拉
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult AddBaseGongweiRight(int GwID)
        {
            BaseGongweiRightModel model = new BaseGongweiRightModel();
            model.gwID = GwID;
            ViewData.Model = model;
            ViewBag.GongWeiInfo = bll.GetGongWei();
            ViewBag.UserInfo = bll.GetUserlist();
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            ViewBag.GwRightlist = SysBLL.GetGwRightType();//工位权限类型
            return View("EditBaseGongweiRight");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加工位权限信息")]
        public JsonResult AddBaseGongweiRight(BaseGongweiRightModel model)
        {
            bll.AddBaseGongweiRight(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        /// <summary>
        /// 工位权限编辑界面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Permission]
        public ActionResult EditBaseGongweiRight(int id)
        {
            BaseGongweiRightModel entity = bll.GetBaseGongweiRightId(id);
            ViewData.Model = entity;
            ViewBag.GongWeiInfo = bll.GetGongWei();//工位
            ViewBag.UserInfo = bll.GetUserlist();//人员
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            ViewBag.GwRightlist = SysBLL.GetGwRightType();//工位权限类型
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改工位权限信息")]
        public JsonResult EditBaseGongweiRight(BaseGongweiRightModel model)
        {
            bll.EditBaseGongweiRight(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }
        #endregion

        #region 工具信息
        /// <summary>
        /// 工具信息分页
        /// </summary>
        /// <param name="model">工具信息实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseGongJu(GongjuModel model)
        {
            int totalCount = 0;
            ViewBag.BaseGongJulist = bll.GetPagingBaseGongJu(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.GjTypeInfo = bll.GetGjType();
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "保存工具信息")]
        public JsonResult SaveGongju(GongjuModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            var result = bll.IsExistName("base_gongju", "gjname", model.Gjname, model.ID);
            if (!result)
            {
                model.GjImg = model.DelPhoto == true ? new byte[0] : model.GjImg;
                model.GjIsHasCode = model.BoolIsHasCode == true ? 1 : 0;
                var b = bll.SaveBaseGongju(model);
                if (b)
                {
                    return Json(new { Result = b, Message = "保存成功！" });
                }
                else
                {
                    return Json(new { Result = b, Message = "保存失败！" });
                }
            }
            else
            {
                return Json(new { Result = false, Message = "已存在相同工具" });
            }

        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        /// </summary>
        /// <param name="id"></param>
        public void GetGongJuImg(int id)
        {
            var entity = bll.GetGongju().Where(p => p.ID == id).FirstOrDefault();
            if (entity != null && entity.GjImg != null)
            {
                byte[] HeadPortrait = entity.GjImg;
                Response.BinaryWrite(HeadPortrait);
            }
        }
        [HttpGet]
        [Permission]
        public ActionResult AddBaseGongJu()
        {
            ViewData.Model = new GongjuModel();
            ViewBag.GjTypeInfo = bll.GetGjType();
            return View("EditBaseGongJu");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加工具信息")]
        public JsonResult AddBaseGongJu(GongjuModel model)
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

                model.GjImg = fileContent;
            }
            model.GjIsHasCode = model.BoolIsHasCode == true ? 1 : 0;
            bll.AddBaseGongju(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改工具信息")]
        public JsonResult EditBaseGongJu(GongjuModel model)
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
            if (model.DelPhoto == true)
            {
                model.GjImg = new byte[0];
            }
            else
            {
                model.GjImg = isUpdateHeadPortrait == true ? fileContent : Photo;
            }
            model.GjIsHasCode = model.BoolIsHasCode == true ? 1 : 0;
            bll.EditBaseGongJu(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除工具信息")]
        [HttpPost]
        public JsonResult DelBaseGongJu(string id)
        {
            bll.DeleteBaseGongJu(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 物料/零件信息

        /// <summary>
        /// 物料/零件信息分页
        /// </summary>
        /// <param name="model">物料/零件实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseWuliao(WuliaoModel model)
        {
            int totalCount = 0;
            ViewBag.BaseGongWuliaolist = bll.GetPagingBaseWuliao(model, out totalCount);
            ViewBag.WlTypeInfo = bll.GetWlType();
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        /// </summary>
        /// <param name="id"></param>
        public void GetWuliaoImg(int id)
        {
            var entity = bll.GetWuliao().Where(p => p.ID == id).FirstOrDefault();
            if (entity != null && entity.wlImg != null)
            {
                byte[] HeadPortrait = entity.wlImg;
                Response.BinaryWrite(HeadPortrait);
            }
        }

        /// <summary>
        /// 上传Excel
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadExcelFile()
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["FileUploadExcel"];
            string SavePath = "/Upload/Excel/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//存放相对路径
            string FullPath = Server.MapPath(SavePath);//完整路径
            string fileName = "";
            if (File != null)
            {
                fileName = File.FileName;//文件名
                if (!System.IO.Directory.Exists(FullPath))
                {
                    System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                    Dir.Refresh();
                }
                SavePath += fileName;
                if (System.IO.File.Exists(FullPath + fileName))
                {
                    System.IO.File.Delete(FullPath + fileName);
                }
                File.SaveAs(FullPath + fileName);

                string ExcelPath = FullPath + fileName;

                DataTable excelTable = new DataTable();
                excelTable = ExcelHelper.GetExcelDataTable(ExcelPath);

                //移除空行
                ExcelHelper.RemoveEmpty(excelTable);


                List<WuliaoModel> Wllist = new List<WuliaoModel>();


                for (int i = 0; i < excelTable.Rows.Count; i++)
                {
                    DataRow dr = excelTable.Rows[i];
                    WuliaoModel model = new WuliaoModel();
                    model.wlname = dr["零件名称"].ToString();
                    model.wlcode = dr["物资编码"].ToString();
                    model.wlTypeID = 0;
                    model.wlIsHasCode = 0;
                    model.wlStatus = 0;
                    //物料规格
                    List<WuliaoModelModel> dd = new List<WuliaoModelModel>();
                    WuliaoModelModel wlModel = new WuliaoModelModel();
                    wlModel.wlModels = dr["规格型号/订单号"].ToString();
                    wlModel.wlUnit = dr["单位"].ToString().Trim();
                    wlModel.isSetSafeInventory = 0;
                    wlModel.safeInventory = 0;
                    wlModel.wlModelStatus = 1;
                    dd.Add(wlModel);
                    model.WuliaoSpecification = dd;
                    Wllist.Add(model);

                }

                bll.SaveWuliaoList(Wllist);
            }
            return Json(new { Result = true, Message = "上传成功！", Path = SavePath });
        }

        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadWuliaoExcel()
        {
            //获取报表名称
            string fileName = "物料模板.xlsx";

            string WholePath = "/物料模板/" + fileName;
            //完整路径
            string path = Server.MapPath(WholePath);
            //判断文件是否存在
            if (System.IO.File.Exists(path))
            {
                FileInfo fileinfo = new FileInfo(path);
                Response.Clear();         //清除缓冲区流中的所有内容输出
                Response.ClearContent();  //清除缓冲区流中的所有内容输出
                Response.ClearHeaders();  //清除缓冲区流中的所有头
                Response.Buffer = true;   //该值指示是否缓冲输出，并在完成处理整个响应之后将其发送
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                Response.AddHeader("Content-Length", fileinfo.Length.ToString());
                Response.AddHeader("Content-Transfer-Encoding", "binary");
                Response.ContentType = "application/unknow";  //获取或设置输出流的 HTTP MIME 类型
                Response.ContentEncoding = System.Text.Encoding.UTF8; //获取或设置输出流的 HTTP 字符集
                Response.TransmitFile(path);
                Response.End();
            }
            else
            {
                Response.Redirect("/BaseInfo/BaseWuliao");
            }
            return File(new byte[0], "text/plain", fileName);
        }

        [HttpGet]
        [Permission]
        public ActionResult AddBaseWuliao()
        {
            ViewData.Model = new WuliaoModel();
            ViewBag.WlTypeInfo = bll.GetWlType();
            return View("EditBaseWuliao");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加物料信息")]
        public JsonResult AddBaseWuliao(WuliaoModel model)
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

                model.wlImg = fileContent;
                model.wlClass = null;
            }
            model.wlIsHasCode = model.IsHasCode == true ? 1 : 0;
            var ret = bll.IsExistWuliaoNameANDCode(model.wlname, model.wlcode, 0);
            if (!ret)
            {
                bll.AddBaseWuliao(model);
                return Json(new { Result = true, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = false, Message = "保存失败！该物料名称和规格已存在" });
            }

        }

        [HttpGet]
        [Permission]
        public ActionResult EditBaseWuliao(int id)
        {
            WuliaoModel entity = bll.GetBaseWuliaoId(id);
            ViewData.Model = entity;
            Photo = entity.wlImg;
            ViewBag.WlTypeInfo = bll.GetWlType();
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改物料信息")]
        public JsonResult EditBaseWuliao(WuliaoModel model)
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
            if (model.DelPhoto == true)
            {
                model.wlImg = new byte[0];
            }
            else
            {
                model.wlImg = isUpdateHeadPortrait == true ? fileContent : Photo;
            }
            model.wlIsHasCode = model.IsHasCode == true ? 1 : 0;
            model.wlClass = null;
            var ret = bll.IsExistWuliaoNameANDCode(model.wlname, model.wlcode, model.ID);
            if (!ret)
            {
                bll.EditBaseWuliao(model);
                return Json(new { Result = true, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = false, Message = "保存失败！该物料名称和规格已存在" });
            }

        }

        [Log(LogType = 3, Action = "删除物料信息")]
        [HttpPost]
        public JsonResult DelBaseWuliao(string id)
        {
            bll.DeleteBaseWuliao(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 物料/零件编码规格

        [Permission]
        public ActionResult BaseWuliaoCode(WuliaoModelModel model)
        {
            int totalCount = 0;
            ViewBag.wlID = model.wlID;
            ViewBag.WuliaoCodeList = bll.GetPagingWuliaoCode(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加物料/零件编码规格信息")]
        public JsonResult SaveWuliaoCode(WuliaoModelModel model)
        {
            if (model.wlmodelID == 0)
            {
                bll.AddWuliaoCode(model);
            }
            else
            {
                bll.EditWuliaoCode(model);
            }
            return Json(new { Result = true, Message = "操作成功！" });
        }

        [Log(LogType = 3, Action = "删除物料/零件编码规格信息")]
        [HttpPost]
        public JsonResult DelWuliaoCode(string id)
        {
            bll.DeleteWuliaoCode(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 工序信息 LHR

        /// <summary>
        /// 上传视频
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase file)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["FileUploadVedio"];
            string SavePath = "/Upload/video/gongxu/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//存放相对路径
            string FullPath = Server.MapPath(SavePath);//完整路径
            string fileName = "";
            if (File != null)
            {
                fileName = Path.GetFileName(File.FileName);//文件名
                if (!System.IO.Directory.Exists(FullPath))
                {
                    System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                    Dir.Refresh();
                }
                SavePath += fileName;
                if (System.IO.File.Exists(FullPath + fileName))
                {
                    System.IO.File.Delete(FullPath + fileName);
                }
                File.SaveAs(FullPath + fileName);
            }
            return Json(new { Result = true, Message = "上传成功！", Path = SavePath });
        }

        /// <summary>
        /// 上传工步视频
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadGongbuFile(HttpPostedFileBase file)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["FileUploadVedio"];
            string SavePath = "/Upload/video/gongbu/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//存放相对路径
            string FullPath = Server.MapPath(SavePath);//完整路径
            string fileName = "";
            if (File != null)
            {
                fileName = File.FileName;//文件名
                if (!System.IO.Directory.Exists(FullPath))
                {
                    System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                    Dir.Refresh();
                }
                SavePath += fileName;
                if (System.IO.File.Exists(FullPath + fileName))
                {
                    System.IO.File.Delete(FullPath + fileName);
                }
                File.SaveAs(FullPath + fileName);
            }
            return Json(new { Result = true, Message = "上传成功！", Path = SavePath });
        }

        #endregion

        #region 存放区信息管理

        /// <summary>
        /// 存放区查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult TempArea(BaseTempAreaModel model)
        {
            int totalCount = 0;
            ViewBag.TempAreaList = bll.GetTempAreaList(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            ViewBag.Area = SysBLL.GetBaseDataTypeValue("tempArea");
            ViewBag.Status = SysBLL.GetBaseDataTypeValue("tempAreaStatus");
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加存放信息")]
        public JsonResult SaveTempArea(BaseTempAreaModel model)
        {
            if (model.ta_ID == 0)
            {
                bll.AddTempArea(model);
            }
            else
            {
                bll.EditTempArea(model);
            }
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除存放信息")]
        [HttpPost]
        public JsonResult DelTempArea(string id)
        {
            bll.DeleteTempArea(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 用户组 WZQ

        /// <summary>
        /// 用户组信息分页
        /// </summary>
        /// <param name="model">用户组实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseUserGroup(BaseUserGroupModel model)
        {
            int totalCount = 0;
            ViewBag.BaseUserGroupList = bll.GetUserGroupPaging(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
        /// <summary>
        /// 获取用户树形菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetUserTreeView()
        {
            var query = bll.GetUserTreeView();
            return Json(query, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取默认选中用户
        /// </summary>
        /// <param name="id">用户组ID</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult DefaultChecked(int id)
        {
            var query = bll.DefaultChecked(id);

            return Json(query, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存用户组信息
        /// </summary>
        /// <param name="model">用户组实体类 </param>
        /// <returns>返回true和false</returns>
        public JsonResult SaveUserGroup(BaseUserGroupModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            var result = bll.IsExistName("base_usergroup", "ugGroupName", model.ugGroupName, model.ID);
            if (!result)
            {
                List<BaseUserGroupDetailModel> modelList = JsonConvert.DeserializeObject<List<BaseUserGroupDetailModel>>(model.JSONDetailList);

                IBLL_System SysBLL = DIService.GetService<IBLL_System>();
                UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
                model.ugCreaterID = user.userID;
                model.ugUpdaterID = user.userID;
                model.ugDetail = modelList;

                var b = bll.SaveBaseUserGroup(model);
                if (b)
                {
                    return Json(new { Result = b, Message = "保存成功！" });
                }
                else
                {
                    return Json(new { Result = b, Message = "保存失败！" });
                }
            }
            else
            {
                return Json(new { Result = false, Message = "已存在相同用户组名" });
            }
        }

        [Log(LogType = 3, Action = "删除用户组信息")]
        [HttpPost]
        public JsonResult DelBaseUserGroup(string id)
        {
            bll.DelBaseUserGroup(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }
        #endregion

        #region 消息类型-用户组关联 WZQ

        /// <summary>
        /// 消息类型-用户组关联
        /// </summary>
        /// <param name="model">消息类型-用户组关联实体</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseRelMsgUser(BaseRelMsgUserModel model)
        {
            int totalCount = 0;
            ViewBag.RelMsgUserList = bll.GetRelMsgUserPaging(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            ViewBag.MsgTypeInfo = SysBLL.GetBaseDataTypeValue("MsgType");
            ViewBag.UserGroupInfo = bll.GetUserGroupList();
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存消息类型-用户组关联
        /// </summary>
        /// <param name="model">消息类型-用户组关联实体 </param>
        /// <returns>返回true和false</returns>
        public JsonResult SaveRelMsgUser(BaseRelMsgUserModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            var result = bll.IsExistRelMsgUser(model.rmuMsgTypeId ?? 0, model.rmuUGroupId ?? 0, model.ID);
            if (!result)
            {
                IBLL_System SysBLL = DIService.GetService<IBLL_System>();
                UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
                model.rmuCreaterID = user.userID;
                model.rmuUpdaterID = user.userID;

                var b = bll.SaveBaseRelMsgUser(model);
                if (b)
                {
                    return Json(new { Result = b, Message = "保存成功！" });
                }
                else
                {
                    return Json(new { Result = b, Message = "保存失败！" });
                }
            }
            else
            {
                return Json(new { Result = false, Message = "已存在相同[消息类型-用户组]信息" });
            }
        }

        [Log(LogType = 3, Action = "删除消息类型-用户组关联信息")]
        [HttpPost]
        public JsonResult DelBaseRelMsgUser(string id)
        {
            bll.DelRelMsgUser(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 消息内容 WZQ

        /// <summary>
        /// 消息内容信息
        /// </summary>
        /// <param name="model">消息内容</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseMsgContent(BaseMsgContentModel model)
        {
            //默认获取当前用户 如果为admin，则可以查看所有人的消息通知，否则只能查看当前登录人的消息通知
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
            model.msResponderID = user.userID;
            model.msResponderName = user.userName;

            int totalCount = 0;
            ViewBag.MsgContentList = bll.GetMsgContentPaging(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.MsgTypeInfo = SysBLL.GetBaseDataTypeValue("MsgType");
            ViewBag.UserName = user.empName;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存消息内容信息
        /// </summary>
        /// <param name="model">消息内容信息实体 </param>
        /// <returns>返回true和false</returns>
        public JsonResult SaveMsgContent(BaseMsgContentModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });

            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
            model.mcCreaterID = user.userID;
            model.mcUpdaterID = user.userID;

            var b = bll.SaveBaseMsgContent(model);
            if (b)
            {
                return Json(new { Result = b, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = b, Message = "保存失败！" });
            }

        }

        [Log(LogType = 3, Action = "删除消息内容")]
        [HttpPost]
        public JsonResult DelBaseMsgContent(string id)
        {
            bll.DelMsgContent(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        /// <summary>
        /// 获取消息通知
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult RefreshInform()
        {
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
            var list = bll.GetBaseMsgContent(user.userID);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 消息已读
        /// </summary>
        /// <param name="ID">消息通知ID</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult OneMesRead(int ID)
        {
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
            bll.MsgContentRead(ID, user.userID);
            return Json(new { Result = true, Message = "OK！" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        ///  全部已读
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult AllMesRead()
        {
            IBLL_System SysBLL = DIService.GetService<IBLL_System>();
            UserModel user = SysBLL.GetUser(new UserModel() { userName = HttpContext.User.Identity.Name });
            var list = bll.GetBaseMsgContent(user.userID);
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    bll.MsgContentRead(item.ID, user.userID);
                }
            }
            else
            {
                return Json(new { Result = false, Message = "全部阅读失败！" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Result = true, Message = "已全部阅读！" }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region 计划工序维护 LHR 2020-03-06

        /// <summary>
        /// 计划工序维护页面
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult BasePartGongxu(Base_PartGongxuModel model)
        {
            ViewBag.prodModelID = model.prodModelID == null ? 0 : model.prodModelID;
            ViewBag.PID = model.PID == null ? 4 : model.PID;
            int totalCount = 100;
            //ViewBag.PartGongxuList = bll.GetPartGongxu(model, out totalCount);
            //产品型号（图号）信息数据
            ViewBag.ProductDrawingNoModelList = bll.GetProductDrawingNoModel();
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 计划工序维护查询方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetPartGongxuList(Base_PartGongxuModel model)
        {
            if (model == null) model = new Base_PartGongxuModel();
            var list = bll.GetPartGongxu(model);
            return Json(list);
        }

        /// <summary>
        /// 获取 产品型号-图号信息List
        /// </summary>
        /// <returns></returns>
        public JsonResult GetProductDrawingNoModel()
        {
            return Json(bll.GetProductDrawingNoModel());
        }


        [HttpPost]
        [Log(LogType = 2, Action = "添加/修改计划工序维护信息")]
        public JsonResult SavePartGongxu(Base_PartGongxuModel model)
        {
            DateTime NowTime = DateTime.Now;
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });

            //排重判断
            var list = bll.GetPartGongxu(new Base_PartGongxuModel()
            {
                prodModelID = model.prodModelID,
                operationName = model.operationName,
                operationCode = model.operationCode,
                UNID = model.ID
            });
            if (list.Count > 0) return Json(new { Result = false, Message = "数据重复,请确认后操作！" });
            if (model.ID == 0)
            {
                model.deleteFlag = 0;
                model.createTime = NowTime;
                model.createMan = ((UserModel)ViewBag.User).userID;
                bll.AddPartGongxu(model);
                return Json(new { Result = true, Message = "保存成功！" });
            }
            else
            {
                model.deleteFlag = 0;
                model.updateTime = NowTime;
                model.updateMan = ((UserModel)ViewBag.User).userID;
                bll.EditPartGongxu(model);
                return Json(new { Result = true, Message = "修改成功！" });
            }
        }


        [HttpPost]
        [Log(LogType = 3, Action = "删除计划工序维护信息")]
        public JsonResult DelPartGongxu(string id)
        {
            bll.DelPartGongxu(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 图片轮播配置

        public ActionResult ImgCarousel()
        {
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 图片轮播配置 bootstrap-table 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult ImgCarouselQuery(BaseImgCarousel model)
        {
            int totalCount = 0;
            List<BaseImgCarousel> List = bll.GetImgCarouselPage(model, out totalCount);
            return Json(new { page = model.PageIndex, rows = List, total = totalCount }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 保存轮播信息并上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadImgCarousel()
        {
            UserModel user = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name });
            //HttpFileCollectionBase files = Request.Files;
            HttpFileCollection upload = System.Web.HttpContext.Current.Request.Files;
            //var File = files["UploadImgFile"];
            var File = upload["imgurl"];//接收的文件
            var title = Request["title"];//标题
            var remark = Request["remark"];//备注（描述）
            int ID = ConvertHelper.ToInt32(Request["hidID"], 0);//ID
            //string SavePath = "/Upload/Image/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//存放相对路径
            string SavePath = "/Upload/Image/";//存放相对路径
            string FullPath = Server.MapPath(SavePath);//服务器完整路径
            string fileName = "";//文件名
            try
            {
                if (File != null)
                {
                    string extension = System.IO.Path.GetExtension(FullPath);//扩展名 “.aspx”   
                    fileName = File.FileName;//文件名赋值 + "_" + DateTime.Now.ToString("yyyyMMdd")
                    if (!System.IO.Directory.Exists(FullPath))
                    {
                        //确保服务器上有当前文件夹，如果没有创建一个
                        System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                        Dir.Refresh();
                    }
                    SavePath += fileName;//路径拼接+文件名 , Path = SavePath
                    if (System.IO.File.Exists(FullPath + fileName))
                    {
                        //判断是否存在相同文件，存在就先进行删除操作
                        System.IO.File.Delete(FullPath + fileName);
                    }
                    File.SaveAs(FullPath + fileName);//将文件保存在服务器相对路径中

                    //赋值图片轮播实体类
                    BaseImgCarousel model = new BaseImgCarousel();
                    model.ID = ID;
                    model.imgUrl = SavePath;//保存服务器图片存放的相对路径
                    model.fullPath = (FullPath + fileName).Replace(@"\", "/");
                    model.title = title;
                    model.remark = remark;
                    model.deleteFlag = 0;
                    model.createMan = user.userID;
                    model.updateMan = user.userID;

                    var responseResult = bll.SaveImgCarousel(model);//执行数据库保存操作
                    if (responseResult > 0)
                    {
                        return Json(new { Result = true, Message = "<span style='color:green;'>上传成功！</span>" });
                    }
                    else
                    {
                        //如果文件上传失败就删除该文件
                        System.IO.File.Delete(FullPath + fileName);
                        return Json(new { Result = false, Message = "上传失败！" });
                    }
                }
                return Json(new { Result = false, Message = "请选择要上传的Image图片！" });
            }
            catch (Exception)
            {
                //如果发生异常删除该文件
                System.IO.File.Delete(FullPath + fileName);
                return Json(new { Result = false, Message = "<span style='color:red;'>上传的Image图片格式错误！</span>" });
            }

        }


        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelImgCarousel(string id, string fullPath)
        {
            var responseResult = bll.DelImgCarousel(id);
            if (responseResult == true)
            {
                System.IO.File.Delete(fullPath);
                return Json(new { Result = true, Message = "<span style='color:green;'>成功！</span>" });
            }
            else
            {
                return Json(new { Result = false, Message = "失败！" });
            }
        }

        /// <summary>
        ///  获取图片文件大小
        /// </summary>
        /// <param name="aPhotoUrl"></param>
        /// <returns></returns>
        public JsonResult GetPhotoInfo(string aPhotoUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(aPhotoUrl))
                {
                    FileInfo fileInfo = new FileInfo(aPhotoUrl);
                    double length = Convert.ToDouble(fileInfo.Length);
                    //var Size = length;// / 1024 / 1024 Convert.ToDouble(Size).ToString("0.0"), })
                    return Json(new { Result = true, data = (new { imgSize = length.ToInt() }) });
                }
                return Json(new { Result = true, data = (new { imgSize = 0 }) });
            }
            catch (Exception e)
            {
                return Json(new { Result = false, data = (new { }) });
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeleteImgCarousel(string id)
        {
            var responseResult = bll.DeleteImgCarousel(id);
            if (responseResult == true)
            {
                return Json(new { Result = true, Message = "删除成功！" });
            }
            else
            {
                return Json(new { Result = false, Message = "删除失败！" });
            }
        }



        /// <summary>
        /// 拖动改变排序
        /// </summary>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public JsonResult UpdateSort(string jsondata)
        {
            if (!string.IsNullOrEmpty(jsondata))
            {
                var userModel = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
                //将json序列化为List<T>
                List<BaseImgCarousel> modelList = JsonConvert.DeserializeObject<List<BaseImgCarousel>>(jsondata);
                for (int i = 0; i < modelList.Count; i++)
                {
                    modelList[i].sort = i + 1;
                }
                int results = bll.UpdateSort(modelList);
                if (results > 0)
                {
                    return Json(new { result = true, message = "成功！" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { result = false, message = "失败！" }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new { result = false, message = "获取数据失败！" }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region PPT轮播

        public ActionResult PptCarousel()
        {
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// PPT轮播配置 bootstrap-table 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult PptCarouselQuery(BasePPTCarousel model)
        {
            int totalCount = 0;
            List<BasePPTCarousel> List = bll.GetPptCarouselPage(model, out totalCount);
            return Json(new { page = model.PageIndex, rows = List, total = totalCount }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 保存PPT轮播信息并上传图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadPptCarousel()
        {
            //HttpFileCollectionBase files = Request.Files;
            HttpFileCollection upload = System.Web.HttpContext.Current.Request.Files;
            //var File = files["UploadImgFile"];
            var File = upload["imgurl"];//接收的文件
            int ID = ConvertHelper.ToInt32(Request["hidID"], 0);//ID
            //string SavePath = "/Upload/Image/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//存放相对路径
            string SavePath = "/Upload/PPTImage/";//存放相对路径
            string FullPath = Server.MapPath(SavePath);//服务器完整路径
            string fileName = "";//文件名
            var remark = Request["remark"];//备注（描述）

            try
            {
                if (File != null)
                {
                    string extension = System.IO.Path.GetExtension(FullPath);//扩展名 “.aspx”   
                    fileName = File.FileName;//文件名赋值 + "_" + DateTime.Now.ToString("yyyyMMdd")
                    if (!System.IO.Directory.Exists(FullPath))
                    {
                        //确保服务器上有当前文件夹，如果没有创建一个
                        System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                        Dir.Refresh();
                    }
                    SavePath += fileName;//路径拼接+文件名 , Path = SavePath
                    if (System.IO.File.Exists(FullPath + fileName))
                    {
                        //判断是否存在相同文件，存在就先进行删除操作
                        System.IO.File.Delete(FullPath + fileName);
                    }
                    File.SaveAs(FullPath + fileName);//将文件保存在服务器相对路径中

                    //赋值图片轮播实体类
                    BasePPTCarousel model = new BasePPTCarousel();
                    model.ID = ID;
                    model.imgUrl = SavePath;//保存服务器图片存放的相对路径
                    model.fullPath = (FullPath + fileName).Replace(@"\", "/");
                    model.remark = remark;

                    var responseResult = bll.SavePptCarousel(model);//执行数据库保存操作
                    if (responseResult > 0)
                    {
                        return Json(new { Result = true, Message = "<span style='color:green;'>上传成功！</span>" });
                    }
                    else
                    {
                        //如果文件上传失败就删除该文件
                        System.IO.File.Delete(FullPath + fileName);
                        return Json(new { Result = false, Message = "上传失败！" });
                    }
                }
                return Json(new { Result = false, Message = "请选择要上传的Image图片！" });
            }
            catch (Exception)
            {
                //如果发生异常删除该文件
                System.IO.File.Delete(FullPath + fileName);
                return Json(new { Result = false, Message = "<span style='color:red;'>上传的Image图片格式错误！</span>" });
            }

        }

        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DelPptCarousel(string id, string fullPath)
        {
            var responseResult = bll.DelPptCarousel(id);
            if (responseResult == true)
            {
                System.IO.File.Delete(fullPath);
                return Json(new { Result = true, Message = "<span style='color:green;'>成功！</span>" });
            }
            else
            {
                return Json(new { Result = false, Message = "失败！" });
            }
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeletePptCarousel(string id)
        {
            var responseResult = bll.DeletePptCarousel(id);
            if (responseResult == true)
                return Json(new { Result = true, Message = "删除成功！" });
            else
                return Json(new { Result = false, Message = "删除失败！" });
        }


        /// <summary>
        /// 拖动改变排序
        /// </summary>
        /// <param name="jsondata"></param>
        /// <returns></returns>
        public JsonResult UpdatePptSort(string jsondata)
        {
            if (!string.IsNullOrEmpty(jsondata))
            {
                //将json序列化为List<T>
                List<BasePPTCarousel> modelList = JsonConvert.DeserializeObject<List<BasePPTCarousel>>(jsondata);
                for (int i = 0; i < modelList.Count; i++)
                {
                    modelList[i].sort = i + 1;
                }
                int results = bll.UpdatePptSort(modelList);
                if (results > 0)
                    return Json(new { result = true, message = "成功！" }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { result = false, message = "失败！" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false, message = "获取数据失败！" }, JsonRequestBehavior.AllowGet);
        }




        /// <summary>
        /// 修改 对应sys_config 时间
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateConfig(string code, string value)
        {
            var responseResult = bll.UpdateConfig(code, value);
            if (responseResult > 0)
                return Json(new { Result = true, Message = "修改成功！" });
            else
                return Json(new { Result = false, Message = "修改成功！" });
        }

        #endregion

    }
}