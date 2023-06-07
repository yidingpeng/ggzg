using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Follow;
using RW.PMS.Web.Filter;
using System.Web.Mvc;
using RW.PMS.Model.Torque;
using RW.PMS.Model;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using NPOI.SS.Util;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Spire.Xls;
using System.Drawing;
using System.Web;
using Spire.Xls.Charts;

namespace RW.PMS.Web.Controllers
{
    public class TorqueController : BaseController
    {
        IBLL_System Sysbll = DIService.GetService<IBLL_System>();
        IBLL_Torque bll = DIService.GetService<IBLL_Torque>();
        IBLL_BaseInfo BaseInfobll = DIService.GetService<IBLL_BaseInfo>();
        HttpServerUtility _HttpServerUtility;

        #region 扭矩基础信息

        /// <summary>
        /// 扭矩基础信息
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns></returns>
        [Permission]
        public ActionResult Tool(TorqueTool model)
        {
            int totalCount = 0;
            ViewBag.TorqueToolList = bll.GetTorquePageList(model, out totalCount);
            ViewBag.Team = Sysbll.GetBaseDataTypeValue("Team"); //班组
            ViewBag.Manufacturer = Sysbll.GetBaseDataTypeValue("Manufacturer");//生产厂家 
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// 保存基础信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Log(LogType = 2, Action = "保存工具基础信息")]
        public JsonResult SaveToolInfo(TorqueTool model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            var result = BaseInfobll.IsExistName("torque_tool", "TorqueCode", model.TorqueCode);
            if (result) return Json(new { Result = false, Message = "工具编码已存在！" });
            //var result2 = BaseInfobll.IsExistName("torque_tool", "TorqueName", model.TorqueName);
            //if (result2) return Json(new { Result = false, Message = "工具名称已存在！" });
            var state = bll.SaveTorqueTool(model);
            if (state)
            {
                return Json(new { Result = state, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = state, Message = "保存失败！" });
            }
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Log(LogType = 3, Action = "删除基础信息")]
        [HttpPost]
        public JsonResult TorqueToolDelete(string id)
        {
            bll.TorqueToolDelete(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }
        #endregion

        /// <summary>
        /// 工具每日检定信息分页
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult ToolJD(torque_jianding model)
        {
            int totalCount = 0;
            ViewBag.BaseToolVerificationlist = bll.GetPagingBaseJD(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
        /// <summary>
        /// 导出试验台数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ExportData(string id)
        {
            bll.TorqueToolDelete(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        /// <summary>
        /// 导出试验台数据
        /// </summary>
        /// <returns></returns>
        public FileResult ExportData2(string id)
        {
            try
            {
                string TempletFileName = @"D:\GH试验台实测数据.xlsx";//模板文件  
                FileStream file = new FileStream(TempletFileName, FileMode.Open, FileAccess.Read);
                //创建Excel文件的对象
                XSSFWorkbook book = new XSSFWorkbook(file);

                torque_jianding tool = bll.JDListTo_DaysByCode(id);

                //添加一个sheet 
                //XSSFSheet workSheet = book.GetSheetAt(0) as XSSFSheet;
                ISheet workSheet = book.GetSheet("实验报告");
                //获取list数据 
                //将数据逐步写入workSheet各个行
                workSheet.GetRow(3).GetCell(0).SetCellValue(tool.ID);
                workSheet.GetRow(3).GetCell(3).SetCellValue(tool.ZSBH);
                workSheet.GetRow(3).GetCell(6).SetCellValue(tool.GGXH);

                int num = 0;
                workSheet.GetRow(7).GetCell(0).SetCellValue(1);//次数
                workSheet.GetRow(7).GetCell(1).SetCellValue(tool.ZSBH);//设定值
                workSheet.GetRow(7).GetCell(2).SetCellValue(tool.JDYJ);//测量值1
                workSheet.GetRow(7).GetCell(3).SetCellValue("-4.00～4.00");//正常误差
                double JCZ1 = Convert.ToDouble(tool.JDYJ);
                double BZZ = Convert.ToDouble(tool.ZSBH);
                double calculation = Math.Round((JCZ1 - BZZ) / JCZ1, 4);//计算出相对误差百分比
                if (calculation >= -0.04 && calculation <= 0.04)
                {
                    workSheet.GetRow(7).GetCell(5).SetCellValue("√");//单次结果
                    num++;
                }
                else
                {
                    workSheet.GetRow(7).GetCell(5).SetCellValue("×");//单次结果
                }
                workSheet.GetRow(7).GetCell(6).SetCellValue(calculation * 100);//误差

                workSheet.GetRow(8).GetCell(0).SetCellValue(2);//次数
                workSheet.GetRow(8).GetCell(1).SetCellValue(tool.ZSBH);//设定值
                workSheet.GetRow(8).GetCell(2).SetCellValue(tool.TYJSYQ);//测量值2
                workSheet.GetRow(8).GetCell(3).SetCellValue("-4.00～4.00");//正常误差
                double JCZ2 = Convert.ToDouble(tool.TYJSYQ);
                double calculation2 = Math.Round((JCZ2 - BZZ) / JCZ2, 4);//计算出相对误差百分比
                if (calculation2 >= -0.04 && calculation2 <= 0.04)
                {
                    workSheet.GetRow(8).GetCell(5).SetCellValue("√");//单次结果
                    num++;
                }
                else
                {
                    workSheet.GetRow(8).GetCell(5).SetCellValue("×");//单次结果
                }
                workSheet.GetRow(8).GetCell(6).SetCellValue(calculation2 * 100);//误差

                workSheet.GetRow(9).GetCell(0).SetCellValue(3);//次数
                workSheet.GetRow(9).GetCell(1).SetCellValue(tool.ZSBH);//设定值
                workSheet.GetRow(9).GetCell(2).SetCellValue(tool.JCZ3);//测量值3
                workSheet.GetRow(9).GetCell(3).SetCellValue("-4.00～4.00");//正常误差
                double JCZ3 = Convert.ToDouble(tool.JCZ3);
                double calculation3 = Math.Round((JCZ3 - BZZ) / JCZ3, 4);//计算出相对误差百分比
                if (calculation3 >= -0.04 && calculation3 <= 0.04)
                {
                    workSheet.GetRow(9).GetCell(5).SetCellValue("√");//单次结果
                    num++;
                }
                else
                {
                    workSheet.GetRow(9).GetCell(5).SetCellValue("×");//单次结果
                }
                workSheet.GetRow(9).GetCell(6).SetCellValue(calculation3 * 100);//误差

                workSheet.GetRow(10).GetCell(0).SetCellValue(4);//次数
                workSheet.GetRow(10).GetCell(1).SetCellValue(tool.ZSBH);//设定值
                workSheet.GetRow(10).GetCell(2).SetCellValue(tool.JCZ4);//测量值3
                workSheet.GetRow(10).GetCell(3).SetCellValue("-4.00～4.00");//正常误差
                double JCZ4 = Convert.ToDouble(tool.JCZ4);
                double calculation4 = Math.Round((JCZ4 - BZZ) / JCZ4, 4);//计算出相对误差百分比
                if (calculation4 >= -0.04 && calculation4 <= 0.04)
                {
                    workSheet.GetRow(10).GetCell(5).SetCellValue("√");//单次结果
                    num++;
                }
                else
                {
                    workSheet.GetRow(10).GetCell(5).SetCellValue("×");//单次结果
                }
                workSheet.GetRow(10).GetCell(6).SetCellValue(calculation4 * 100);//误差


                workSheet.GetRow(11).GetCell(0).SetCellValue(5);//次数
                workSheet.GetRow(11).GetCell(1).SetCellValue(tool.ZSBH);//设定值
                workSheet.GetRow(11).GetCell(2).SetCellValue(tool.JCZ5);//测量值3
                workSheet.GetRow(11).GetCell(3).SetCellValue("-4.00～4.00");//正常误差
                double JCZ5 = Convert.ToDouble(tool.JCZ5);
                double calculation5 = Math.Round((JCZ5 - BZZ) / JCZ5, 4);//计算出相对误差百分比
                if (calculation5 >= -0.04 && calculation5 <= 0.04)
                {
                    workSheet.GetRow(11).GetCell(5).SetCellValue("√");//单次结果
                    num++;
                }
                else
                {
                    workSheet.GetRow(11).GetCell(5).SetCellValue("×");//单次结果 
                }
                workSheet.GetRow(11).GetCell(6).SetCellValue(calculation5 * 100);//误差

                //测试结果
                if (num >= 3)
                {
                    workSheet.GetRow(7).GetCell(7).SetCellValue("合格");
                }
                else
                {
                    workSheet.GetRow(7).GetCell(7).SetCellValue("不合格");
                }
                workSheet.GetRow(15).GetCell(1).SetCellValue(tool.JDY);
                workSheet.GetRow(15).GetCell(2).SetCellValue(tool.JDRQ);

                string fileName = "试验台实测数据" + Guid.NewGuid() + ".xlsx";
                // 写入到客户端 
                MemoryStream ms = new MemoryStream();
                book.Write(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms, "application/vnd.ms-excel", fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }


        #region 拧紧记录
        [Permission]
        public ActionResult TighteningRecord(TighteningRecordModel model)
        {
            int totalCount = 0;
            ViewBag.TighteningRecord = BaseInfobll.GetTighteningRecord(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            return View();
        }

        /// <summary>
        /// 获得一个对象的所有属性
        /// </summary>
        /// <returns></returns>
        private string[] GetPropertyNameArray()
        {
            PropertyInfo[] props = null;
            try
            {
                Type type = typeof(TighteningRecordExcelModel);
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
        /// <returns></returns>
        public ActionResult ExportExcel(string pmodel,string starttime,string endtime)
        {
            HttpContext.Session["username"] = this.HttpContext.User.Identity.Name;
            List<TighteningRecordExcelModel> list = DIService.GetService<IBLL_BaseInfo>().GetTighteningRecordExcel(new TighteningRecordModel() { Pmodel = pmodel, starttime = starttime, endtime = endtime });
            DataTable ExportDt = MySqlHelper.ListToTable(list);

            string[] oldColumn = GetPropertyNameArray();
            string[] newColumn = new string[] { "产品型号", "标准值", "拧紧值1", "拧紧值2", "操作人员", "拧紧时间" };

            //调用改写的NPOI方法   
            var data = ExcelHelper.MyExport(ExportDt, "拧紧信息导出文件", DateTime.Now.ToLongDateString() +"_拧紧信息", oldColumn, newColumn);

            string path = Server.MapPath("~\\App_Data\\images\\") + "拧紧信息导出文件" + DateTime.Now.ToLongDateString() + ".xlsx";
            FileStream fs = new FileStream(path, FileMode.Create);
            fs.Write(data, 0, data.Length);
            fs.Dispose();

            createChart(path,list.Count);

            //return File(data, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", DateTime.Now.ToLongDateString() + "_拧紧信息.xlsx");
            return File(path, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", DateTime.Now.ToLongDateString() + "_拧紧信息.xlsx");
        }

        /// <summary>
        /// 创建图表
        /// </summary>
        /// <param name="path"></param>
        public void createChart(string path, int dataCount)
        {
            //加载Excel文档
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(path);
            //获取工作表
            Worksheet sheet = workbook.Worksheets[0];

            //根据示例数据创建柱形图
            Chart chart = sheet.Charts.Add();
            chart.DataRange = sheet.Range["A1:D"+dataCount+1];
            chart.SeriesDataFromRange = false;

            //设置图表的位置
            chart.LeftColumn = 8;
            chart.TopRow = 1;
            chart.RightColumn = 20;
            chart.BottomRow = 28;

            //将图表类型设置为柱形图表
            var cs1 = (ChartSerie)chart.Series[1];
            cs1.Name = "拧紧值1";
            cs1.SerieType = ExcelChartType.ColumnClustered;
            var cs2 = (ChartSerie)chart.Series[2];
            cs2.Name = "拧紧值2";
            cs2.SerieType = ExcelChartType.ColumnClustered;

            //将图表类型设置为折线图表
            var cs3 = (ChartSerie)chart.Series[0];
            cs3.Name = "标准值";
            cs3.SerieType = ExcelChartType.LineMarkers;

            //设置图表标题为空
            chart.ChartTitle = string.Empty;

            //保存生成的excel文档
            workbook.SaveToFile(path, ExcelVersion.Version2010);
            //System.Diagnostics.Process.Start(path);
        }

        #endregion
    }
}
