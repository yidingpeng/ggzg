using System;
using RW.PMS.IBLL;
using RW.PMS.Model.Follow;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RW.PMS.Common;
using RW.PMS.Web.Filter;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using Newtonsoft.Json;
using RW.PMS.Model;
using System.IO;
using System.Data;
using RW.PMS.Utils;

namespace RW.PMS.Web.Controllers
{
    /// <summary>
    /// 物料
    /// </summary>
    public class MaterialController : BaseController
    {
        IBLL_Follow bll = DIService.GetService<IBLL_Follow>();
        IBLL_BaseInfo Basebll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Device Devbll = DIService.GetService<IBLL_Device>();
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        IBLL_Plan Planbll = DIService.GetService<IBLL_Plan>();
        IBLL_ProgramInfo Probll = DIService.GetService<IBLL_ProgramInfo>();

        #region 库存信息

        /// <summary>
        /// 库存信息分页
        /// </summary>
        /// <param name="model">库存实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult MaterialInventory(InventoryModel model)
        {
            int totalCount = 0;
            var Basebll = DIService.GetService<IBLL_BaseInfo>();
            ViewBag.InventoryList = Sysbll.GetInventoryPage(model, out totalCount);
            ViewBag.totalCount = totalCount;
            ViewBag.WlcodeInfo = Basebll.GetMaterialList();//物料规格下拉
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加/修改库存信息")]
        public JsonResult SaveMaterialInventory(InventoryModel model)
        {
            var Basebll = DIService.GetService<IBLL_BaseInfo>();
            if (model.ID == 0)
            {
                bool result = Sysbll.IsExistInventory(model.wlmodelID ?? 0, model.warehouseID ?? 0);
                if (!result)
                {
                    model.userID = GetCurUserID();
                    Sysbll.SaveInventory(model);
                    return Json(new { Result = true, Message = "保存成功！" });
                }
                else
                {
                    return Json(new { Result = false, Message = "已存在物料规格和仓库相同的数据!" });
                }
            }
            else
            {
                model.userID = GetCurUserID();
                Sysbll.SaveInventory(model);
                return Json(new { Result = true, Message = "保存成功！" });
            }
        }

        #endregion

        #region 库存信息

        /// <summary>
        /// 库存信息分页
        /// </summary>
        /// <param name="model">库存实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult Inventory(BaseInventoryModel model)
        {
            int totalCount = 0;
            ViewBag.InventoryList = Basebll.GetInventoryPage(model, out totalCount);
            ViewBag.totalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
         
        /// <summary>
        ///库存信息分页方法 
        /// </summary>
        /// <param name="model">model实体</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="PageSize">页数</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Inventorys(BaseInventoryModel model, int PageIndex = 0, int PageSize = 10)
        {
            model.PageIndex = PageIndex;
            model.PageSize = PageSize;
            int TotalCount = 0;
            List<BaseInventoryModel> List = Basebll.GetInventoryPage(model, out TotalCount);
            return Json(new { page = PageIndex, rows = List, total = TotalCount }, JsonRequestBehavior.AllowGet);
        }
         
        //[Log(LogType = 2, Action = "添加/修改库存信息")]
        public JsonResult SaveInventory(BaseInventoryModel model)
        {
            UserModel user = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name });
            //库存去重
            bool result = Basebll.IsExistInventory(model.ID, model.wlID ?? 0, model.warehouseID ?? 0);
            if (!result)
            {
                if (model.ID == 0)
                {
                    model.createMan = user.userID;
                    model.updateMan = user.userID;
                }
                else
                {
                    model.updateMan = user.userID;
                }
                int ret = Basebll.SaveInventory(model);
                if (ret > 0)
                {
                    return Json(new { Result = true, Message = "保存成功！" });
                }
                return Json(new { Result = false, Message = "保存失败！" });
            }
            return Json(new { Result = false, Message = "该仓库已存在相同物料!" });
        }
         
        /// <summary>
        /// 获取所有物料信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMaterialLists()
        {
            return LargeJson(Basebll.GetMaterialList());
        }
         
        /// <summary>
        /// 下载Excel模板
        /// </summary>
        /// <returns></returns>
        public FileResult DownloadWuliaoExcel()
        {
            //获取报表名称
            string fileName = "即时库存.xlsx";

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
                Response.Redirect("/Material/Inventory");
            }
            return File(new byte[0], "text/plain", fileName);
        }
         
        /// <summary>
        /// 上传Excel
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadExcelFile(bool isDeleted)
        {
            UserModel user = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name });
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["FileUploadExcel"];
            string SavePath = "/Upload/Excel/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//存放相对路径
            string FullPath = Server.MapPath(SavePath);//服务器完整路径 
            string fileName = "";//文件名
            try
            {
                if (File != null)
                {
                    fileName = File.FileName;//文件名赋值
                    if (!System.IO.Directory.Exists(FullPath))
                    {
                        //确保服务器上有当前文件夹，如果没有创建一个
                        System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                        Dir.Refresh();
                    }
                    SavePath += fileName;//路径拼接文件名, Path = SavePath
                    if (System.IO.File.Exists(FullPath + fileName))
                    {
                        System.IO.File.Delete(FullPath + fileName);
                    }
                    string ExcelPath = FullPath + fileName;
                    File.SaveAs(FullPath + fileName);//保存文件
                    DataTable excelTable = new DataTable();
                    excelTable = ExcelHelper.GetExcelDataTable(ExcelPath);//将Excel文件通过NPOI装换为DataTable
                    ExcelHelper.RemoveEmpty(excelTable); //移除空行

                    List<BaseInventoryModel> InventoryList = new List<BaseInventoryModel>();
                    for (int i = 0; i < excelTable.Rows.Count; i++)
                    {
                        DataRow dr = excelTable.Rows[i];
                        BaseInventoryModel model = new BaseInventoryModel();
                        model.wlCode = dr["物料编码"].ToString().Trim();
                        model.wlName = dr["物料名称"].ToString().Trim();
                        model.wlModel = dr["规格型号"].ToString().Trim();
                        model.batch = dr["批次"].ToString().Trim();
                        model.projectNo = dr["项目号"].ToString().Trim();
                        model.unit = dr["计量单位"].ToString().Trim();
                        model.qty = ConvertHelper.ToDecimal(dr["数量"], 0);
                        model.lockqty = ConvertHelper.ToDecimal(dr["锁库数量"], 0);
                        model.InvOrgID = 1;
                        model.inventoryTypeID = 1;
                        model.warehouseID = 1;
                        model.createMan = user.userID;
                        model.updateMan = user.userID;
                        InventoryList.Add(model);
                    }
                    ResponseResult<string> responseResult = Basebll.ImportInventory(InventoryList, isDeleted);
                    if (responseResult.ret > 0)
                    {
                        return Json(new { Result = true, Message = "<span style='color:green;'>上传成功！</span>", inexistenceMsg = "", repetitionMsg = "" });
                    }
                    else
                    {
                        return Json(new { Result = false, Message = "上传失败！", inexistenceMsg = responseResult.inexistenceMsg, repetitionMsg = responseResult.repetitionMsg });
                    }
                }
                return Json(new { Result = false, Message = "请选择要上传的Excel文件！", inexistenceMsg = "", repetitionMsg = "" });
            }
            catch (Exception)
            {
                //如果文件上传失败就删除该文件
                System.IO.File.Delete(FullPath + fileName);
                return Json(new { Result = false, Message = "<span style='color:red;'>上传的Excel文件格式错误！<br/>请使用下载的模板进行上传！</span>", inexistenceMsg = "", repetitionMsg = "" });
            }
        }

        [HttpPost]
        public JsonResult ImportUniqInventory()
        {
            UserModel user = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name });
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["FileUploadExcel"];
            string SavePath = "/Upload/Excel/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";//存放相对路径
            string FullPath = Server.MapPath(SavePath);//服务器完整路径
            string fileName = "";//文件名
            try
            {
                if (File != null)
                {
                    fileName = File.FileName;//文件名赋值
                    if (!System.IO.Directory.Exists(FullPath))
                    {
                        //确保服务器上有当前文件夹，如果没有创建一个
                        System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                        Dir.Refresh();
                    }
                    SavePath += fileName;//路径拼接文件名 , Path = SavePath
                    if (System.IO.File.Exists(FullPath + fileName))
                    {
                        System.IO.File.Delete(FullPath + fileName);
                    }
                    string ExcelPath = FullPath + fileName;
                    File.SaveAs(FullPath + fileName);//保存文件
                    DataTable excelTable = new DataTable();
                    excelTable = ExcelHelper.GetExcelDataTable(ExcelPath);//将Excel文件通过NPOI装换为DataTable
                    ExcelHelper.RemoveEmpty(excelTable); //移除空行

                    List<BaseInventoryModel> InventoryList = new List<BaseInventoryModel>();
                    for (int i = 0; i < excelTable.Rows.Count; i++)
                    {
                        DataRow dr = excelTable.Rows[i];
                        BaseInventoryModel model = new BaseInventoryModel();
                        model.wlCode = dr["物料编码"].ToString().Trim();
                        model.wlName = dr["物料名称"].ToString().Trim();
                        model.wlModel = dr["规格型号"].ToString().Trim();
                        model.batch = dr["批次"].ToString().Trim();
                        model.projectNo = dr["项目号"].ToString().Trim();
                        model.unit = dr["计量单位"].ToString().Trim();
                        model.qty = ConvertHelper.ToDecimal(dr["数量"], 0);
                        model.lockqty = ConvertHelper.ToDecimal(dr["锁库数量"], 0);
                        model.InvOrgID = 1;
                        model.inventoryTypeID = 1;
                        model.warehouseID = 1;
                        model.createMan = user.userID;
                        model.updateMan = user.userID;
                        InventoryList.Add(model);
                    }
                    ResponseResult<string> responseResult = Basebll.ImportUniqInventory(InventoryList);
                    if (responseResult.ret > 0)
                    {
                        return Json(new { Result = true, Message = "<span style='color:green;'>上传成功！</span>", inexistenceMsg = "", repetitionMsg = "" });
                    }
                    else
                    {
                        return Json(new { Result = false, Message = "上传失败！", inexistenceMsg = responseResult.inexistenceMsg, repetitionMsg = responseResult.repetitionMsg });
                    }
                }
                return Json(new { Result = false, Message = "请选择要上传的Excel文件！", inexistenceMsg = "", repetitionMsg = "" });
            }
            catch (Exception)
            {
                //如果文件上传失败就删除该文件 
                System.IO.File.Delete(FullPath + fileName);
                return Json(new { Result = false, Message = "<span style='color:red;'>上传的Excel文件格式错误！<br/>请使用下载的模板进行上传！</span>", inexistenceMsg = "", repetitionMsg = "" });

            }
        }
         
        /// <summary>
        /// 获取库存操作最后时间
        /// </summary>
        /// <returns></returns>
        public JsonResult GetInventoryLogTime()
        {
            List<BaseInventoryLogModel> list = Basebll.GetInventoryLogTime(new BaseInventoryLogModel { remark = "Excel导入库存操作" });
            return Json(list);
        }

        #endregion

        #region 物料信息管理

        [Permission]
        public ActionResult MaterialList(BaseMaterialModel model)
        {
            //int totalCount = 0;
            //ViewBag.MaterialList = Basebll.GetMaterialList(model, out totalCount);
            //ViewBag.WlTypeInfo = bll.GetWlType();
            //ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 物料信息管理 bootstrap-table 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult MaterialListQuery(BaseMaterialModel model)
        {
            int totalCount = 0;
            List<BaseMaterialModel> MaterialList = Basebll.GetMaterialList(model, out totalCount);
            return LargeJson(new { page = model.PageIndex, rows = MaterialList, total = totalCount }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult MaterialSelectList()
        {
            return View();
        }

        /// <summary>
        /// 获取物料类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetMaterialTypeList(BaseMaterialTypeModel model)
        {
            if (model == null) model = new BaseMaterialTypeModel();
            var list = Basebll.GetMaterialTypeList(model);
            return Json(list);
        }

        /// <summary>
        /// 保存物料类型
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveMaterialType(BaseMaterialTypeModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            var userModel = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            model.mtUpdaterID = userModel.userID;
            var b = Basebll.SaveMaterialType(model);
            if (b)
            {
                return Json(new { Result = b, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = b, Message = "保存失败！" });
            }
        }

        //保存供应商
        public JsonResult SaveSupplier(BaseSupplierModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            var list = Basebll.GetSupplierList(new BaseSupplierModel() { suName = model.suName });
            if (list.Count > 0) return Json(new { Result = false, Message = "此供应商已存在！" });
            var userModel = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            model.suUpdaterID = userModel.userID;
            var b = Basebll.SaveSupplier(model);
            if (b > 0)
            {
                return Json(new { Result = b, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = b, Message = "保存失败！" });
            }
        }

        /// <summary>
        /// 保存物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public JsonResult SaveMaterial(BaseMaterialModel model)
        {
            BaseMaterialModel BaseMaterialmodel = new BaseMaterialModel();
            string Str = "";
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            if (!string.IsNullOrEmpty(model.mCode))
            {
                BaseMaterialmodel.mCode = model.mCode;
                Str += "  物资编码：【" + model.mCode + "】</br>";
            }
            if (!string.IsNullOrEmpty(model.mDrawingNo) && !string.IsNullOrEmpty(model.mName))
            {
                BaseMaterialmodel.mName = model.mName;
                BaseMaterialmodel.mDrawingNo = model.mDrawingNo;
                BaseMaterialmodel.UNID = model.ID;
                Str += "  零件名称：【" + model.mName + "】</br> 零件号(图号):【" + model.mDrawingNo + "】</br>已存在！";
            }
            var list = Basebll.GetMaterialList(BaseMaterialmodel);
            if (list.Count > 0)
            {
                return Json(new { Result = false, Message = Str });
            }

            var userModel = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            model.mUpdaterID = userModel.userID;
            model.mRTypeID = null;
            var b = Basebll.SaveMaterial(model);
            if (b)
            {
                return Json(new { Result = b, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = b, Message = "保存失败！" });
            }
        }

        /// <summary>
        /// 获取物料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetMaterialList(BaseMaterialModel model)
        {
            if (model == null) model = new BaseMaterialModel();
            var list = Basebll.GetMaterialList(model);
            return LargeJson(list);
        }

        //获取供应商
        public JsonResult GetSupplierList(BaseSupplierModel model)
        {
            if (model == null) model = new BaseSupplierModel();
            var list = Basebll.GetSupplierList(model);
            return Json(list);
        }

        //删除物料
        public JsonResult DeleteMaterial(int ID)
        {
            if (ID == 0) return Json(new { Result = false, Message = "传入ID为空！" });
            BaseMaterialModel model = new BaseMaterialModel();
            model.ID = ID;
            var userModel = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            model.mUpdaterID = userModel.userID;
            var b = Basebll.DeleteMaterial(model);
            if (b)
                return Json(new { Result = b, Message = "删除成功！" });
            else
                return Json(new { Result = b, Message = "删除失败！" });
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        ///
        /// </summary>
        /// <param name="id"></param>
        public void GetMaterialImg(int id)
        {
            if (id == 0) return;
            var entity = Basebll.GetMaterialList(new BaseMaterialModel() { ID = id });
            if (entity != null && entity[0].mImg != null)
            {
                byte[] mImg = entity[0].mImg;
                Response.BinaryWrite(mImg);
            }
        }

        #endregion

        #region EBOM信息管理  

        /// <summary>
        ///  EBOM页面
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult EBOMList(BaseBomModel model)
        {
            int totalCount = 100;
            ViewBag.BOMList = Basebll.GetPagingBaseBOM(model, out totalCount);
            ViewBag.TotalCount = totalCount;

            ViewBag.gongwei = Sysbll.GetgongweiAll();//绑定工位下拉
            ViewBag.wuliao = Basebll.GetMaterialList();//绑定物料下拉
            ViewBag.pmodel = Basebll.GetAllBaseProModel();//绑定产品型号下拉
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetEBOMTreeList(BaseEBOMModel model)
        {
            if (model == null) model = new BaseEBOMModel();
            var list = Basebll.GetEBOMTreeList(model);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存EBOM 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveBOM(BaseBomModel model)
        {
            if (model.ID == 0)
            {
                Basebll.AddBaseBom(model);
            }
            else
            {
                Basebll.EditBaseBom(model);
            }
            return Json(new { Result = true, Message = "操作成功！" });
        }

        /// <summary>
        /// 逻辑删除EBOM 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public JsonResult DeleteBOM(string id)
        {
            Basebll.DeleteBaseBom(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        /// <summary>
        /// 根据产品型号 查询产品型号关联的工序
        /// </summary>
        /// <param name="wlID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetProdModelByGXID(int PID, int gwID)
        {
            PageModel<List<PMS.Model.Program>> programs = Probll.GetBaseProgramList(string.Empty, gwID, PID, 1, 1000);
            List<Base_PartGongxuModel> Model = Basebll.GetPartGongxu(PID);
            return Json(programs, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取物料拼接图号 零件名称-零件号（图号）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetMaterialDrawingNoList(BaseMaterialModel model)
        {
            if (model == null) model = new BaseMaterialModel();
            var list = Basebll.GetMaterialDrawingNoList(model);
            return Json(list);
        }

        #endregion

        #region 领料单 LHR

        /// <summary>
        /// 领料单主表 
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult RequisitionList(WmsRequisitionMainModel model)
        {
            int totalCount = 0;
            ViewBag.InventoryList = Basebll.GetWmsRequisitionMainList(model, out totalCount);
            ViewBag.totalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 根据条件查询领料单主表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetRequisitionList(WmsRequisitionMainModel model)
        {
            if (model == null) model = new WmsRequisitionMainModel();
            var list = Basebll.GetWmsRequisitionMainList(model);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除领料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult DeleteRequisition(string Iv_guid)
        {
            Basebll.DeleteWmsRequisitionMain(Iv_guid);
            return Json(new { Result = true, Message = "删除成功！" }, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 领料单子表
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult RequisitionDetail(string Iv_guid, string sta)
        {
            ViewBag.Iv_guid = Iv_guid;
            ViewBag.Iv_applyStatus = sta;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
         
        /// <summary>
        /// 根据 Iv_guid 获取 领料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetWmsRequisitionDetail(WmsRequisitionDetailModel model)
        {
            List<WmsRequisitionDetailModel> detail = Basebll.GetWmsRequisitionDetail(model);
            return Json(detail, JsonRequestBehavior.AllowGet);
        } 

        /// <summary>
        /// 根据 申请单号 条件查询领料单主表最大申请单号
        /// </summary>
        /// <param name="Iv_applyNo"></param>
        /// <returns></returns>
        public JsonResult GetWmsRequisitionByapplyNo(string Iv_applyNo)
        {
            List<WmsRequisitionMainModel> applyNo = Basebll.GetWmsRequisitionByapplyNo(Iv_applyNo);
            return Json(applyNo, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 获取所有物料绑定下拉
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllWuliao()
        {
            List<BaseMaterialModel> Wuliao = Basebll.GetMaterialList();
            return Json(Wuliao, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 根据 物料ID获取所有物料规格下拉
        /// </summary>
        /// <param name="wlID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetWuliaoModelbywlID(int wlID)
        {
            List<WuliaoModelModel> Model = Basebll.GetWuliaoCode(wlID);
            return Json(Model, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 保存 领料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveWmsRequisitionMainDetail(WmsRequisitionMainModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            List<WmsRequisitionDetailModel> modelList = JsonConvert.DeserializeObject<List<WmsRequisitionDetailModel>>(model.JSONDetailList);
            model.detailList = modelList;
            DateTime NowTime = DateTime.Now;
            model.Iv_applierID = ((UserModel)ViewBag.User).userID;
            model.Iv_applyDate = NowTime;
            model.Iv_applyStatus = 1;
            Basebll.SaveWmsRequisitionMainDetail(model);
            return Json(new { Result = true, Message = "保存成功！" });
        } 

        #endregion

        #region 配料单 LHR

        /// <summary>
        /// 配料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult BatchingList()
        {
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 根据条件查询配料单主表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetBatchingList(WmsBatchingMainModel model)
        {
            if (model == null) model = new WmsBatchingMainModel();
            var list = Basebll.GetWmsBatchingMainList(model);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 配料单子表
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult BatchingDetail(string wb_guid, string sta)
        {
            ViewBag.wb_guid = wb_guid;
            ViewBag.wb_status = sta;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 根据 申请单号 条件查询配料单主表最大申请单号
        /// </summary>
        /// <param name="Iv_applyNo"></param>
        /// <returns></returns>
        public JsonResult GetBatchingmainByCode(string wb_code)
        {
            List<WmsBatchingMainModel> CodeNo = Basebll.GetBatchingmainByCode(wb_code);
            return Json(CodeNo, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 根据 wb_guid 获取 配料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetWmsDatchingDetail(WmsBatchingDetailModel model)
        {
            List<WmsBatchingDetailModel> detail = Basebll.GetWmsDatchingDetail(model);
            return Json(detail, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 删除 配料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult DeleteBatching(string wb_guid)
        {
            Basebll.DeleteWmsBatchingMain(wb_guid);
            return Json(new { Result = true, Message = "删除成功！" }, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 保存 配料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetMaterialBarCodePageSaveBatchingMainDetail(WmsBatchingMainModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            List<WmsBatchingDetailModel> modelList = JsonConvert.DeserializeObject<List<WmsBatchingDetailModel>>(model.JSONDetailList);
            model.detailList = modelList;
            DateTime NowTime = DateTime.Now;
            model.wb_operID = ((UserModel)ViewBag.User).userID;
            model.wb_batchtime = NowTime;
            model.wb_status = 1;
            Basebll.SaveWmsBatchingMainDetail(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }


        /// <summary>
        /// 获取 计划列表信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPlanProdList()
        {
            PlanProdModel model = new PlanProdModel();
            model.UNStatus = 2;
            List<PlanProdModel> PlanProd = Planbll.GetPlanProdList(model);
            return Json(PlanProd, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取 领料单列表信息
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRequisitionListByGuid()
        {
            WmsRequisitionMainModel model = new WmsRequisitionMainModel();
            model.Iv_applyStatus = 1;
            List<WmsRequisitionMainModel> Requisition = Basebll.GetWmsRequisitionMainList(model);
            return Json(Requisition, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 获取所有已被使用的物料盒条码卡
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBarcodeListByFlase()
        {
            List<BaseBarcodeModel> BarcodeList = Basebll.GetBarCodeByBarcodeTypeID(51, false);
            return Json(BarcodeList, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 获取所有未被使用的物料盒条码卡
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBarcodeListByTrue()
        {
            List<BaseBarcodeModel> BarcodeList = Basebll.GetBarCodeByBarcodeTypeID(51, true);
            return Json(BarcodeList, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 根据 计划获取产品型号下所有必换件配料明细
        /// </summary>
        /// <returns></returns>
        public JsonResult GetPlanProdBatchingDetail(string pp_guid)
        {
            List<WmsBatchingDetailModel> PlanProdBatchingDetail = Basebll.GetPlanProdBatchingDetail(pp_guid);
            return Json(PlanProdBatchingDetail, JsonRequestBehavior.AllowGet);
        }
         
        /// <summary>
        /// 根据 领料单获取所有配料明细
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRequisitionBatchingDetail(string iv_guid)
        {
            List<WmsBatchingDetailModel> RequisitionBatchingDetail = Basebll.GetRequisitionBatchingDetail(iv_guid);
            return Json(RequisitionBatchingDetail, JsonRequestBehavior.AllowGet);
        }
         
        #endregion

        #region 物料条码卡管理 LHR 20200507

        /// <summary>
        /// 物料条码卡管理
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult MaterialBarCodeList(BaseMaterialBarCodeModel model)
        {
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 物料条码卡管理 bootstrap-table 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetMaterialBarCodePage(BaseMaterialBarCodeModel model)
        {
            int totalCount = 0;
            List<BaseMaterialBarCodeModel> MaterialBarCodeList = Basebll.GetMaterialBarCodePage(model, out totalCount);
            return Json(new { page = model.PageIndex, rows = MaterialBarCodeList, total = totalCount }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 添加/修改物料条码卡管理信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveMaterialBarCode(BaseMaterialBarCodeModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            //var userModel = Sysbll.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            model.m_cardType = 0;
            model.m_deleteFlag = 0;

            ////排重判断
            //var list = Basebll.IsExistMaterialBarCode(model.ID, model.m_cardNo, model.m_MaterialID ?? 0);
            //if (list) return Json(new { Result = false, Message = "数据重复,请确认后操作！" });

            var b = Basebll.SaveMaterialBarCode(model);
            if (b > 0)
            {
                return Json(new { Result = true, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = false, Message = "保存失败！" });
            }
        }



        [HttpPost]
        [Log(LogType = 3, Action = "删除物料条码卡信息")]
        public JsonResult DeleteMaterialBarCode(string id)
        {
            Basebll.DeleteMaterialBarCode(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 配料管理 20221026

        /// <summary>
        /// 配料信息分页
        /// </summary>
        /// <param name="model">库存实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BatchingRecord(BatchingRecordModel model)
        {
            int totalCount = 0;
            ViewBag.InventoryList = Basebll.BatchingRecordForPage(model, out totalCount);
            ViewBag.totalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存 配料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveBatchingMainDetail(BatchingRecordModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            List<BatchingRecordDetailModel> modelList = JsonConvert.DeserializeObject<List<BatchingRecordDetailModel>>(model.JSONDetailList);
            model.Details = modelList;
            DateTime NowTime = DateTime.Now;
            model.ApplierID = ((UserModel)ViewBag.User).userID;
            model.BatchDate = NowTime;
            model.BatchStatus = 1;
            Basebll.AddBatchingRecord(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }
        #endregion
    }
}
