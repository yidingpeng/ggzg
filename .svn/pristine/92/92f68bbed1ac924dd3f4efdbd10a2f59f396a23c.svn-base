using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RW.PMS.BLL;
using RW.PMS.Model;
using RW.PMS.Web.Models;
using RW.PMS.Web.Controllers.Program;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Web.Filter;
using RW.PMS.Model.BaseInfo;
using System.Data;
using System.IO;
using System.Reflection;

namespace RW.PMS.Web.Controllers
{
    public class ProgramController : BaseController
    {
        private const string _path = "/Program/Index";

        #region 获取基础信息
        //[HttpPost]
        //public JsonResult GetBaseGongxu()
        //{
        //    var result = _BaseInfoBLL.GetAllBaseGongxu().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.Gxname)).ToList();
        //    InsertSelectItem(result);

        //    return LargeJson(result);
        //}

        [HttpPost]
        public JsonResult GetBaseGongwei()
        {
            var result = GetGWInfo().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.gwname)).ToList(); ;
            InsertSelectItem(result);
            return LargeJson(result);
        }

        #region 获取产品型号信息
        /// <summary>
        /// 产品型号集合选项中加入 全部型号(或者请选择)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetProModel()
        {
            var result = GetPr().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.Pname + " " + f.Pmodel)).ToList();
            InsertSelectItem(result);
            return LargeJson(result);
        }
        /// <summary>
        /// 获取产品型号集合2019-05-15
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private List<BaseProductModelModel> GetPr()
        {
            var list = _BaseInfoBLL.GetAllBaseProModel();
            return list;
        }

        #endregion

        //[HttpPost]
        //public JsonResult GetBaseGongbu()
        //{
        //    var result = _BaseInfoBLL.GetAllBaseGongbu().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.Gbname)).ToList(); ;
        //    InsertSelectItem(result);
        //    return LargeJson(result);
        //}

        [HttpPost]
        public JsonResult GetBaseData(string type)
        {
            var result = _SystemBLL.GetBaseDataTypeValue(type).Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.bdname)).ToList(); ;
            if (!type.Equals("ControlType", StringComparison.CurrentCultureIgnoreCase))
            {
                InsertSelectItem(result);
            }
            return LargeJson(result);
        }

        [HttpPost]
        public JsonResult GetGongju()
        {
            var result = _BaseInfoBLL.GetAllBaseGongJu().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.Gjname)).ToList();
            InsertSelectItem(result);
            return LargeJson(result);
        }

        [HttpPost]
        public JsonResult GetWuliao()
        {
            var result = _BaseInfoBLL.GetAllBaseWuliao().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.wlname)).ToList();
            InsertSelectItem(result);
            return LargeJson(result);
        }

        /// <summary>
        /// 获取物料列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMaterialList(int progbID)
        {
            var result = _BaseInfoBLL.GetMaterialList(progbID).Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.mDrawingNo + " " + f.mName)).ToList();
            InsertSelectItem(result);
            return LargeJson(result);
        }

        /// <summary>
        /// 获取物料列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMaterialDict()
        {
            var result = _BaseInfoBLL.GetMaterialDict().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.mDrawingNo + " " + f.mName)).ToList();
            InsertSelectItem(result);
            return LargeJson(result);
        }

        /// <summary>
        /// 获取物料列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetMaterialBarCodeDict()
        {
            var result = _BaseInfoBLL.GetMaterialBarCodeDict().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.m_MaterialText + " - " + f.mDrawingNo)).ToList();
            InsertSelectItem(result);
            return LargeJson(result);
        }



        [HttpPost]
        public JsonResult GetGJGWOPCPointInfo(int progbID, int? gjID, int? wlID)
        {
            var result = DIService.GetService<IBLL_GJInfo>().GetGJGWOPCPointInfo(progbID, gjID, wlID);
            return LargeJson(result);
        }
        #endregion

        #region 查询
        [Permission]
        // GET: /Index/
        public ActionResult Index()
        {
            //get page index/size
            var pageInfo = GetPageInfo();

            //get gowei
            var list = GetGWInfo();
            ViewBag.GWList = list;

            ViewBag.ProductModelInfo = _BaseInfoBLL.GetProductDrawingNoModel();
            //get progem
            var programName = Request["programName"] ?? "";
            int pmodelId = 0;
            int.TryParse(Request["PmodelId"], out pmodelId);
            int gwID = 0;
            int.TryParse(Request["GWID"], out gwID);

            var result = DIService.GetService<IBLL_ProgramInfo>().GetBaseProgramList(programName.Trim(), gwID, pmodelId, pageInfo.Item1, pageInfo.Item2);

            ViewBag.ProgramList = result.Val;
            ViewBag.TotalCount = result.Total;
            ViewBag.AuthVal = GetAuth(_path) ?? 0;

            return View();
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        /// </summary>
        /// <param name="id"></param>
        public void GetGbimg(int? id)
        {
            if (id.HasValue)
            {
                var entity = DIService.GetService<IBLL_GBInfo>().GetGBInfoDetail(id.Value);
                if (entity != null && entity.GBImg != null)
                {
                    byte[] HeadPortrait = entity.GBImg;
                    Response.BinaryWrite(HeadPortrait);
                }
            }
        }

        /// <summary>
        /// 获取层级数据
        /// </summary>
        /// <param name="subLevel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetSubTable(TableLevel subLevel, int id)
        {
            //get result
            var result = CreateTable(subLevel, id);
            return LargeJson(result);
        }

        #endregion

        #region  输入验证

        /// <summary>
        /// 程序名称是否重复
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public JsonResult IsProgramNameDouble(string programName, int id = 0)
        {
            var retVal = DIService.GetService<IBLL_ProgramInfo>().IsProgramNameDouble(programName, id);
            return LargeJson(retVal);
        }

        #endregion

        #region 添加
        [HttpPost]
        public JsonResult GetEmptyTableModel(TableLevel level, int? id)
        {
            var authVal = GetAuth(_path);
            var proItems = new ProgramTables(authVal ?? 0);
            var result = default(object);

            switch (level)
            {
                case TableLevel.Pro:

                    var proTable = proItems.GetProTable();
                    proTable.ID = 0;
                    proTable.Level = level;

                    BaseProgram baseProgram;
                    if (id == null)
                    {
                        baseProgram = new BaseProgram
                        {
                            StartTime = DateTime.Now,

                            ProgStatus = 0,
                        };
                    }
                    else
                    {
                        var proDetail = DIService.GetService<IBLL_ProgramInfo>().GetBaseProgramDeatilByDef(id.Value);
                        baseProgram = new BaseProgram
                        {
                            Remark = proDetail.Remark,
                            GWID = proDetail.GWID,
                            CopyRight = proDetail.CopyRight,
                            Descript = proDetail.Descript,
                            FileNo = proDetail.FileNo,
                            ProgStatus = proDetail.ProgStatus,
                            StartTime = DateTime.Now,
                        };
                    }
                    proTable.Body = new List<BaseProgram>();
                    proTable.Body.Add(baseProgram);

                    result = proTable;

                    break;

                case TableLevel.GX:
                    var gxInfo = new GXInfo
                    {
                        PGXInfoStatus = 0,
                    };

                    var pro = DIService.GetService<IBLL_ProgramInfo>().GetBaseProgramDeatil(id.Value);
                    if (pro != null)
                    {
                        gxInfo.ProgID = pro.ID;
                        //gxInfo.ProgName = pro.ProgName;
                        //gxInfo.GWName = pro.GWName;
                    }
                    var proGXTable = proItems.GetProGXTable();
                    proGXTable.ID = 0;
                    proGXTable.Level = level;
                    proGXTable.Body = new List<GXInfo>();
                    proGXTable.Body.Add(gxInfo);

                    result = proGXTable;

                    break;

                case TableLevel.GB:

                    var proGBTable = proItems.GetProGBTable();
                    proGBTable.ID = 0;
                    proGBTable.Level = level;
                    proGBTable.Body = new List<GBInfo>
                    {
                        new GBInfo
                        {
                            IsEmpCheck=0,
                            IsInputPInfo=0,
                            IsScan=0,
                            IsScanOrderNo=0,
                            PGBInfoStatus=0,
                        }
                    };

                    result = proGBTable;

                    break;

                case TableLevel.GJ:

                    var proGJTable = proItems.GetProGJTable();
                    proGJTable.ID = 0;
                    proGJTable.Level = level;
                    proGJTable.Body = new List<GJInfo>
                    {
                        new GJInfo
                        {
                            PGJInfoStatus=0,
                        }
                    };

                    result = proGJTable;

                    break;

                case TableLevel.Val:

                    var valInfo = new ValueInfo
                    {
                        PVInfoStatus = 0,
                        PixelPoint = 0,
                    };
                    var gj = DIService.GetService<IBLL_GJInfo>().GetGJInfoDetail(id.Value);
                    if (gj != null)
                    {
                        valInfo.ProgGjInfoID = gj.ProgGbInfoID;
                    }

                    var proValTable = proItems.GetProValTable();
                    proValTable.ID = 0;
                    proValTable.Level = level;
                    proValTable.Body = new List<ValueInfo>();
                    proValTable.Body.Add(valInfo);

                    result = proValTable;

                    break;
            }

            return LargeJson(result);
        }

        [HttpPost]
        public void AddPro(BaseProgram model)
        {
            DIService.GetService<IBLL_ProgramInfo>().AddBaseProgram(model);
        }

        [HttpPost]
        public void AddProGX(GXInfo model)
        {
            DIService.GetService<IBLL_GXInfo>().AddGXInfo(model);
        }

        [HttpPost]
        public void AddProGB(GBInfoModel model)
        {
            var imgBase64 = model.GBImageBase64;
            if (!string.IsNullOrEmpty(imgBase64))
            {
                model.GBImg = Convert.FromBase64String(imgBase64);
            }
            DIService.GetService<IBLL_GBInfo>().AddGBInfo(model);
        }

        [HttpPost]
        public void AddProGJ(GJInfo model)
        {
            DIService.GetService<IBLL_GJInfo>().AddGJInfo(model);
        }

        [HttpPost]
        public void AddProVal(ValueInfo model)
        {
            DIService.GetService<IBLL_ValueInfo>().AddValueInfo(model);
        }

        #endregion

        #region 复制
        public void CopyPro(int id, BaseProgram model)
        {
            DIService.GetService<IBLL_ProgramInfo>().CopyBaseProgram(id, model);
        }
        #endregion

        #region 编辑

        /// <summary>
        /// 获取明细
        /// </summary>
        /// <param name="subLevel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetDetail(TableLevel subLevel, int id)
        {
            //get result
            var result = default(object);

            switch (subLevel)
            {
                case TableLevel.Pro:
                    result = DIService.GetService<IBLL_ProgramInfo>().GetBaseProgramDeatilByDef(id);
                    break;
                case TableLevel.GX:
                    result = DIService.GetService<IBLL_GXInfo>().GetGXInfoDetail(id);
                    break;
                case TableLevel.GB:
                    result = DIService.GetService<IBLL_GBInfo>().GetGBInfoDetail(id);
                    break;
                case TableLevel.GJ:
                    result = DIService.GetService<IBLL_GJInfo>().GetGJInfoDetail(id);
                    break;
                case TableLevel.Val:
                    result = DIService.GetService<IBLL_ValueInfo>().GetValueInfoDetail(id);
                    break;
                default:
                    break;
            }

            return LargeJson(result);

        }

        /// <summary>
        /// 获取工序明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public JsonResult GetGongxuDetail(int id)
        //{
        //    var detial = _BaseInfoBLL.GetBaseGongxu(id);

        //    return LargeJson(detial);
        //}

        /// <summary>
        /// 获取工步明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public JsonResult GetGongbuDetail(int id)
        //{
        //    var detail = _BaseInfoBLL.GetBaseGongbuId(id);

        //    return LargeJson(detail);
        //}

        /// <summary>
        /// 程序配置
        /// </summary>
        /// <param name="subLevel"></param>
        [HttpPost]
        public void EditPro(BaseProgram model)
        {
            DIService.GetService<IBLL_ProgramInfo>().EditBaseProgram(model);
        }

        /// <summary>
        /// 程序配置
        /// </summary>
        /// <param name="subLevel"></param>
        [HttpPost]
        public void EditProGX(GXInfo model)
        {
            DIService.GetService<IBLL_GXInfo>().EditGXInfo(model);
        }

        /// <summary>
        /// 程序配置
        /// </summary>
        /// <param name="subLevel"></param>
        [HttpPost]
        public void EditProGB(GBInfoModel model)
        {
            var imgBase64 = model.GBImageBase64;
            if (!string.IsNullOrEmpty(imgBase64))
            {
                model.GBImg = Convert.FromBase64String(imgBase64);
            }
            DIService.GetService<IBLL_GBInfo>().EditGBInfo(model);
        }

        /// <summary>
        /// 程序配置
        /// </summary>
        /// <param name="subLevel"></param>
        [HttpPost]
        public void EditProGJ(GJInfo model)
        {
            DIService.GetService<IBLL_GJInfo>().EditGJInfo(model);
        }

        /// <summary>
        /// 程序配置
        /// </summary>
        /// <param name="subLevel"></param>
        [HttpPost]
        public void EditProVal(ValueInfo model)
        {
            DIService.GetService<IBLL_ValueInfo>().EditValueInfo(model);
        }

        #endregion

        #region 排序
        public void OrderSet(TableLevel level, int id, bool isUp)
        {

            switch (level)
            {
                case TableLevel.GX:
                    DIService.GetService<IBLL_GXInfo>().OrderSet(id, isUp);
                    break;
                case TableLevel.GB:
                    DIService.GetService<IBLL_GBInfo>().OrderSet(id, isUp);
                    break;
                case TableLevel.GJ:
                    DIService.GetService<IBLL_GJInfo>().OrderSet(id, isUp);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="subLevel"></param>
        /// <param name="id"></param>
        [HttpPost]
        public void Delete(TableLevel level, int id)
        {
            switch (level)
            {
                case TableLevel.Pro:
                    DIService.GetService<IBLL_ProgramInfo>().DeleteBaseProgram(id);//加一个参数关联表id
                    break;
                case TableLevel.GX:
                    DIService.GetService<IBLL_GXInfo>().DeleteGXInfo(id);
                    break;
                case TableLevel.GB:
                    DIService.GetService<IBLL_GBInfo>().DeleteGBInfo(id);
                    break;
                case TableLevel.GJ:
                    DIService.GetService<IBLL_GJInfo>().DeleteGJInfo(id);
                    break;
                case TableLevel.Val:
                    DIService.GetService<IBLL_ValueInfo>().DeleteValueInfo(id);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 导出



        /// <summary>
        /// 获得一个对象的所有属性
        /// </summary>
        /// <returns></returns>
        private string[] GetPropertyNameArray()
        {
            PropertyInfo[] props = null;
            try
            {
                Type type = typeof(ProGXGBExportModel);
                object obj = Activator.CreateInstance(type);
                props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                string[] array = props.Select(t => t.Name).ToArray();
                return array;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 导出Excel FileStreamResult
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult ExportExcel(int ID, int type, string ProgName)
        {
            HttpContext.Session["username"] = this.HttpContext.User.Identity.Name;
            List<ProGXGBExportModel> list = DIService.GetService<IBLL_ProgramInfo>().ProgGXGBExportList(ID);
            DataTable ExportDt = MySqlHelper.ListToTable(list);

            string[] oldColumn = GetPropertyNameArray();
            string[] newColumn = new string[] { "工序名称", "工序描述", "工步名称", "工步描述", "装配总时间", "工序排序", "工步排序" };//, "工序ID", "工步ID"

            //调用改写的NPOI方法   
            var data = ExcelHelper.MyExport(ExportDt, "工艺程序导出文件", ProgName + "_工艺程序", oldColumn, newColumn);

            if (type == 1)
            {
                return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", ProgName + "_工艺程序.xlsx");
            }
            else
            {
                return File(data, "application/vnd.ms-excel", ProgName + "_工艺程序.xls");
            }
        }


        #endregion

        #region nonAction

        /// <summary>
        /// 获取工位信息
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private List<BaseGongweiModel> GetGWInfo()
        {
            var list = _BaseInfoBLL.GetAllBaseGongWei();
            return list;
        }

        /// <summary>
        /// 创建各层级结构
        /// </summary>
        /// <param name="level"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [NonAction]
        private object CreateTable(TableLevel level, int id)
        {
            var authVal = GetAuth(_path);
            var proItems = new ProgramTables(authVal ?? 0);
            switch (level)
            {
                case TableLevel.GX:

                    var gxInfo = DIService.GetService<IBLL_GXInfo>().GetGXInfoList(id);

                    var proGXTable = proItems.GetProGXTable();
                    proGXTable.ID = id;
                    proGXTable.Level = level;
                    proGXTable.Body = gxInfo;

                    return proGXTable;

                case TableLevel.GB:

                    var gbInfo = DIService.GetService<IBLL_GBInfo>().GetGBInfoList(id);

                    var proGBTable = proItems.GetProGBTable();
                    proGBTable.ID = id;
                    proGBTable.Level = level;
                    proGBTable.Body = gbInfo;

                    return proGBTable;

                case TableLevel.GJ:

                    var gjInfo = DIService.GetService<IBLL_GJInfo>().GetGJInfoList(id);

                    var proGJTable = proItems.GetProGJTable();
                    proGJTable.ID = id;
                    proGJTable.Level = level;
                    proGJTable.Body = gjInfo;

                    return proGJTable;

                case TableLevel.Val:

                    var valInfo = DIService.GetService<IBLL_ValueInfo>().GetValueInfoList(id);

                    var proValTable = proItems.GetProValTable();
                    proValTable.ID = id;
                    proValTable.Level = level;
                    proValTable.Body = valInfo;

                    return proValTable;

                default:
                    return null;

            }
        }

        [NonAction]
        private void InsertSelectItem(List<KeyValuePair<string, string>> result)
        {
            result.Insert(0, new KeyValuePair<string, string>("", "请选择"));
        }
        public class GBInfoModel : GBInfo
        {
            public string GBImageBase64 { get; set; }
        }
        #endregion

    }
}
