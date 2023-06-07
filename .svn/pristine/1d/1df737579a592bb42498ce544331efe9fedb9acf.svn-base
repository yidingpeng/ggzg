using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Web.Controllers.Common;
using RW.PMS.Web.Filter;
using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RW.PMS.Web.Controllers
{
    /// <summary>
    /// 生产记录报告模板
    /// </summary>
    public class RepTemplController : BaseController
    {
        IBLL_BaseInfo _bllbaseInfo = DIService.GetService<IBLL_BaseInfo>();
        IBLL_ReportTemplate _bllReportTemplate = DIService.GetService<IBLL_ReportTemplate>();
        IBLL_System _bllSystem = DIService.GetService<IBLL_System>();

        #region 报告模板

        /// <summary>
        /// 查询报告模板列表
        /// </summary>
        /// <param name="pModelID"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public ActionResult RepTemplateIndex(int? pModelID = null, int pageSize = 10, int pageIndex = 1)
        {
            var result = _bllReportTemplate.GetRepTemplateList(pModelID, pageSize, pageIndex);

            ViewBag.RepTemplateList = result.Val;
            ViewBag.TotalCount = result.Total;
            ViewBag.AuthVal = GetAuth();
            ViewBag.ProductList = _bllbaseInfo.GetProductModelAll();//产品型号下拉框
            return View();
        }

        /// <summary>
        /// 获取报告模板添加修改页面
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult RepTemplateAddEdit(int? ID)
        {
            var model = new RepTemplateModel();
            if (ID.HasValue)
            {
                model = _bllReportTemplate.GetRepTemplateDetail(ID.Value);
            }
            ViewBag.ProductList = _bllbaseInfo.GetProductModelAll();//产品型号下拉框
            return View(model);
        }

        /// <summary>
        /// 保存报告模板用于添加修改 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult RepTemplateSave(RepTemplateModel model)
        {
            try
            {
                //获取上传模板文件
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    model.FileName = file.FileName;
                    model.FileValue = StreamToBytes(file.InputStream);
                    model.havFile = true;
                }
                _bllReportTemplate.UpdateRepTemplate(model);

                return Json(new { Result = true, Message = "保存成功！" });

            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = "保存失败！" + ex.Message });
            }
        }

        /// <summary>
        /// 删除报告模板
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult RepTemplateDelete(int[] ID)
        {
            try
            {
                foreach (var item in ID)
                {
                    _bllReportTemplate.DeleteRepTemplate(item);
                }
                return Json(new { Result = true, Message = "删除成功！" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = "保存失败！" + ex.Message });
            }
        }

        /// <summary>
        /// 下载报告模板
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public FileResult RepTemplateDownLoad(int ID)
        {
            var model = _bllReportTemplate.GetRepTemplateDetail(ID);
            return File(model.FileValue, "text/plain", model.FileName);
        }
        #endregion

        #region 模板数据源
        public ActionResult RepTemplateBind(int? pmodelID = null, int? typeID = null, int pageSize = 10, int pageIndex = 1)
        {
            var result = _bllReportTemplate.GetRepTemplBindSourceList(pmodelID, typeID, pageSize, pageIndex);
            ViewBag.RepTemplBindSource = result.Val;
            ViewBag.TotalCount = result.Total;
            ViewBag.AuthVal = GetAuth();
            //获取模板列表
            ViewBag.ProductList = _bllbaseInfo.GetAllBaseProModel();//产品型号下拉框
            //获取数据源类型
            ViewBag.BaseDataList = _bllSystem.GetBaseDataValue("TemplateBindType");
            //获取绑定类型列表
            //ViewBag.BindTypes = _bllReportTemplate.GetBindTypes();
            return View();
        }

        /// <summary>
        /// 获取绑定类型列表
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult GetBindType(int ID)
        {
            var types = _bllReportTemplate.GetBindTypes(ID);

            return Json(types);
        }

        /// <summary>
        /// 获取模板数据源明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult RepTemplateBindDetail(int ID)
        {
            var model = _bllReportTemplate.GetRepTemplBindSourceDetail(ID);

            return Json(model);
        }

        /// <summary>
        /// 保存绑定模板数据源用于添加修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult RepTemplateBindSave(RepTemplBindSourceModel model)
        {
            try
            {
                _bllReportTemplate.UpdateRepTemplBindSource(model);

                return Json(new { Result = true, Message = "保存成功！" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = "保存失败！" + ex.Message });
            }
        }

        /// <summary>
        /// 删除模板数据源
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult RepTemplateBindDelete(int[] ID)
        {
            try
            {
                foreach (var item in ID)
                {
                    _bllReportTemplate.DeleteRepTemplBindSource(item);
                }
                return Json(new { Result = true, Message = "删除成功！" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = "保存失败！" + ex.Message });
            }
        }

        #endregion

        #region 生产记录报告
        /// <summary>
        /// 获取生产信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult RepProdList(AssemblyProdModel model)
        {
            int totalCount = 100;
            ViewBag.AssemblyProd = _ProductInfoBLL.AssemblyProdForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.ProductModelInfo = _bllbaseInfo.GetProductModel();
            ViewBag.HTTPHOST = Request.ServerVariables["HTTP_HOST"];
            return View();
        }

        /// <summary>
        /// 下载处理好的报告  
        /// </summary>
        /// <param name="pModelID"></param>
        /// <param name="fmGuid"></param>
        /// <returns></returns>
        public FileResult RepTemplateSourceDownLoad(int pModelID, string ProdNo)
        {
            //lock (_lockObj)
            //{
            var item = GetTemplateFile(pModelID, ProdNo);
            return File(item.Item1, "text/plain", item.Item2);
            //}
        }

        /// <summary>
        /// 报告预览
        /// </summary> 
        /// <param name="pModelID"></param>
        /// <param name="fmGuid"></param>
        public void RepTemplateView(int pModelID, string ProdNo)
        {
            //lock (_lockObj)
            //{
            var item = GetTemplateFile(pModelID, ProdNo);
            var document = new Aspose.Words.Document(item.Item1);
            string file = SaveAsPDF(item.Item1, document);
            Response.ContentType = "application/pdf;charset=UTF-8";
            Response.WriteFile(file);
            Response.End();
            //}
        }

        [NonAction]
        private string SaveAsPDF(string filePath, Aspose.Words.Document document)
        {
            var file = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath)) + ".pdf";
            document.Save(file, Aspose.Words.SaveFormat.Pdf);
            return file;
        }

        [NonAction]
        private Tuple<string, string> GetTemplateFile(int pModelID, string ProdNo)
        {
            var tempDir = Server.MapPath(@"..\bin\templateTempFiles");
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            //get reptemplate 
            var model = _bllReportTemplate.GetRepTemplateDetailByProdModelID(pModelID);
            if (model == null || string.IsNullOrEmpty(model.FileName))
            {
                return new Tuple<string, string>(string.Empty, string.Empty);
            }
            var fileName = Path.Combine(tempDir, model.FileName);
            System.IO.File.WriteAllBytes(fileName, model.FileValue);

            //get datasource 
            var pageModel = _assemblyBLL.GetAssemblyMainList(prodCode: ProdNo);
            var tmodel = _assemblyBLL.GetTightenMachineList(ProdNo);
            var reportModel = new ReportModel(pageModel.Val, tmodel);

            //获取签名图片 
            var signatureImgDir = Path.Combine(tempDir, "signatureImg");
            SaveSignatureImages(signatureImgDir);

            //create have Data template 
            var repTemplateDataBind = new RepTemplDataBind();
            repTemplateDataBind.SignatureImgDir = signatureImgDir;
            var documentPath = repTemplateDataBind.CreateBindDataTemplate(fileName, reportModel);

            return new Tuple<string, string>(documentPath, model.FileName);
        }

        [NonAction] 
        private void SaveSignatureImages(string path)
        {
            var _bllSys = DIService.GetService<IBLL_System>();
            var users = _bllSys.GetUserList();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var user in users)
            {
                if (user.signature != null && user.signature.Length != 0)
                {
                    System.IO.File.WriteAllBytes(Path.Combine(path, user.empName) + ".png", user.signature);
                }
            }
        }

        /// <summary>
        /// 将文件流转换成字节数组 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        [NonAction]
        protected byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
        #endregion
    }
}

