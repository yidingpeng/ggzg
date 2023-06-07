using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using NPOI.HPSF;
using System.Web;
using NPOI.SS.Util;
using NPOI.OpenXml4Net.OPC;

namespace RW.PMS.WinForm
{
    public class ExcelHelper
    {

        /// <summary>      
        /// DataTable导出到Excel文件      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">保存位置</param>   
        /// <param name="strSheetName">工作表名称</param>   
        /// <Author>CallmeYhz 2015-11-26 10:13:09</Author>      
        public static void Export(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            if (strSheetName == "")
            {
                strSheetName = "Sheet";
            }
            using (MemoryStream ms = Export(dtSource, strHeaderText, strSheetName, oldColumnNames, newColumnNames))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>      
        /// DataTable导出到Excel文件（无表头）另外的是有表头的
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">保存位置</param>   
        /// <param name="strSheetName">工作表名称</param>   
        /// <Author>CallmeYhz 2015-11-26 10:13:09</Author>      
        public static void MyExport(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            if (strSheetName == "")
            {
                strSheetName = "Sheet";
            }
            MemoryStream getms = new MemoryStream();

            #region 为getms赋值
            if (oldColumnNames.Length != newColumnNames.Length)
            {
                getms = new MemoryStream();
            }
            HSSFWorkbook workbook = new HSSFWorkbook();
            //HSSFSheet sheet = workbook.CreateSheet();// workbook.CreateSheet();   
            ISheet sheet = workbook.CreateSheet(strSheetName);

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://....../";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                if (HttpContext.Current.Session["realname"] != null)
                {
                    si.Author = HttpContext.Current.Session["realname"].ToString();
                }
                else
                {
                    //if (HttpContext.Current.Session["username"] != null)
                    //{
                    //    si.Author = HttpContext.Current.Session["username"].ToString();
                    //}
                }                                       //填加xls文件作者信息      
                si.ApplicationName = "NPOI";            //填加xls文件创建程序信息      
                si.LastAuthor = "OA系统";           //填加xls文件最后保存者信息      
                si.Comments = "OA系统自动创建文件";      //填加xls文件作者信息      
                si.Title = strHeaderText;               //填加xls文件标题信息      
                si.Subject = strHeaderText;              //填加文件主题信息      
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            #region 取得列宽
            int[] arrColWidth = new int[oldColumnNames.Length];
            for (int i = 0; i < oldColumnNames.Length; i++)
            {
                arrColWidth[i] = Encoding.GetEncoding(936).GetBytes(newColumnNames[i]).Length;
            }
            /* 
            foreach (DataColumn item in dtSource.Columns) 
            { 
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length; 
            } 
             * */

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < oldColumnNames.Length; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][oldColumnNames[j]].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
                /* 
                for (int j = 0; j < dtSource.Columns.Count; j++) 
                { 
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length; 
                    if (intTemp > arrColWidth[j]) 
                    { 
                        arrColWidth[j] = intTemp; 
                    } 
                } 
                 * */
            }
            #endregion
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet(strSheetName + ((int)rowIndex / 65535).ToString());
                    }


                    #region 列头及样式
                    {
                        //HSSFRow headerRow = sheet.CreateRow(1);   
                        IRow headerRow = sheet.CreateRow(0);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        for (int i = 0; i < oldColumnNames.Length; i++)
                        {
                            headerRow.CreateCell(i).SetCellValue(newColumnNames[i]);
                            headerRow.GetCell(i).CellStyle = headStyle;
                            //设置列宽   
                            sheet.SetColumnWidth(i, (arrColWidth[i] + 1) * 256);
                        }
                        /* 
                        foreach (DataColumn column in dtSource.Columns) 
                        { 
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName); 
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle; 
 
                            //设置列宽    
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256); 
                        } 
                         * */
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                //foreach (DataColumn column in dtSource.Columns)   
                for (int i = 0; i < oldColumnNames.Length; i++)
                {
                    ICell newCell = dataRow.CreateCell(i);

                    string drValue = row[oldColumnNames[i]].ToString();

                    switch (dtSource.Columns[oldColumnNames[i]].DataType.ToString())
                    {
                        case "System.String"://字符串类型      
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型      
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示      
                            break;
                        case "System.Boolean"://布尔型      
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型      
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型      
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理      
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();   
                sheet = null;
                workbook = null;
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet      
                getms = ms;
            }



            #endregion

            using (MemoryStream ms = getms)
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }



        /// <summary>
        /// DataTable导出到Excel文件（无表头）另外的是有表头的
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strSheetName">工作表名称</param>
        /// <param name="oldColumnNames">旧行（代表实体类ProGXGBExportModel的所有对象）</param>
        /// <param name="newColumnNames">新行（代表新插入的表头）</param>
        /// <returns></returns>
        public static byte[] MyExport(DataTable dtSource, string strHeaderText, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            try
            {
                //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                if (strSheetName == "") { strSheetName = "Sheet"; }
                //创建系统内存流
                MemoryStream getms = new MemoryStream();

                #region 为getms赋值
                //if (oldColumnNames.Length != newColumnNames.Length) { getms = new MemoryStream(); } 

                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet(strSheetName);

                #region 右击文件 属性信息

                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://www.csrwjd.com/";//添加文件公司网址
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                //if (HttpContext.Current.Session["username"] != null)
                //{
                //    si.Author = HttpContext.Current.Session["username"].ToString();//添加xls文件作者信息    
                //}
                si.ApplicationName = "NPOI";             //添加xls文件创建程序信息      
                si.LastAuthor = "中控系统";              //添加xls文件最后保存者信息      
                si.Comments = "中控系统自动创建文件";    //添加xls文件作者信息      
                si.Title = strHeaderText;                //添加xls文件标题信息      
                si.Subject = strHeaderText;              //添加文件主题信息      
                si.CreateDateTime = DateTime.Now;        //添加文件创建时间
                workbook.SummaryInformation = si;

                #endregion

                #region 定义数据的单元格样式
                // 内容数据格式 -- 字符串（单元格边框、居中处理）
                ICellStyle styleStr = workbook.CreateCellStyle();
                styleStr.BorderBottom = BorderStyle.Thin;
                styleStr.BorderLeft = BorderStyle.Thin;
                styleStr.BorderRight = BorderStyle.Thin;
                styleStr.BorderTop = BorderStyle.Thin;
                styleStr.VerticalAlignment = VerticalAlignment.Center;//垂直对齐方式
                styleStr.Alignment = HorizontalAlignment.Center;//水平对齐方式
                styleStr.WrapText = true;//自动换行

                // 汇总数据格式 -- 数值
                //ICellStyle styleTotalNum = workbook.CreateCellStyle();
                //styleTotalNum.BorderBottom = BorderStyle.Thin;
                //styleTotalNum.BorderLeft = BorderStyle.Thin;
                //styleTotalNum.BorderRight = BorderStyle.Thin;
                //styleTotalNum.BorderTop = BorderStyle.Thin;
                //styleTotalNum.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                //styleTotalNum.FillPattern = FillPattern.SolidForeground;
                //styleTotalNum.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;

                // 设置字体颜色
                HSSFFont ffont0 = (HSSFFont)workbook.CreateFont();
                ffont0.FontHeight = 14 * 14;
                ffont0.FontName = "宋体";
                ffont0.IsBold = true;
                //ffont0.Color = HSSFColor.Red.Index;
                //styleTotalNum.SetFont(ffont0);

                // 设置时间格式
                ICellStyle styleTodate = workbook.CreateCellStyle();
                IDataFormat format = workbook.CreateDataFormat();
                styleTodate.DataFormat = format.GetFormat("yyyy-mm-dd");

                //设置单元格边框
                ICellStyle styleBorder = workbook.CreateCellStyle();
                styleBorder.BorderBottom = BorderStyle.Thin;
                styleBorder.BorderLeft = BorderStyle.Thin;
                styleBorder.BorderRight = BorderStyle.Thin;
                styleBorder.BorderTop = BorderStyle.Thin;
                styleBorder.VerticalAlignment = VerticalAlignment.Center;//垂直对齐方式

                #endregion

                #region 取得列宽
                int[] arrColWidth = new int[oldColumnNames.Length];
                for (int i = 0; i < oldColumnNames.Length; i++)
                {
                    arrColWidth[i] = Encoding.GetEncoding(936).GetBytes(newColumnNames[i]).Length;
                }

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    for (int j = 0; j < oldColumnNames.Length; j++)
                    {
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][oldColumnNames[j]].ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
                #endregion

                int rowIndex = 0;

                foreach (DataRow row in dtSource.Rows)
                {
                    #region 新建表，填充表头，填充列头，样式
                    if (rowIndex == 65535 || rowIndex == 0)
                    {
                        if (rowIndex != 0)
                        {
                            //行数超过65535重新创建一个sheet
                            sheet = workbook.CreateSheet(strSheetName + (rowIndex / 65535).ToString());
                        }

                        #region 列头及样式
                        {
                            //将索引为0的这一行创建表头相应属性、文本
                            IRow headerRow = sheet.CreateRow(0);
                            headerRow.Height = 24 * 20;
                            //在Excel中，每一行的高度是要求一致的，所以设置单元格的高度，其实就是设置行的高度，所以相关的属性也应该在HSSFRow上，它就是HSSFRow.Height和HeightInPoints，
                            //这两个属性的区别在于HeightInPoints的单位是点，而Height的单位是1/20个点，所以Height的值永远是HeightInPoints的20倍。
                            ICellStyle headStyle = workbook.CreateCellStyle();
                            headStyle.Alignment = HorizontalAlignment.Center;//水平对齐方式
                            headStyle.VerticalAlignment = VerticalAlignment.Center;//垂直对齐方式
                            //设置表头单元格背景颜色
                            headStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Turquoise.Index;//单元格的背景色设置
                            headStyle.FillPattern = FillPattern.SolidForeground;//单元格背景色的填充样式
                            //设置表头单元格边框
                            headStyle.BorderBottom = BorderStyle.Thin;
                            headStyle.BorderLeft = BorderStyle.Thin;
                            headStyle.BorderRight = BorderStyle.Thin;
                            headStyle.BorderTop = BorderStyle.Thin;
                            //设置表头字体
                            IFont font = workbook.CreateFont();
                            font.FontHeightInPoints = 11;//设置字体大小
                            font.FontName = "宋体";
                            font.Boldweight = 700;
                            headStyle.SetFont(font);
                            //循环自定义表头文本内容
                            for (int i = 0; i < oldColumnNames.Length; i++)
                            {
                                headerRow.CreateCell(i).SetCellValue(newColumnNames[i]);//表头进行赋值
                                headerRow.GetCell(i).CellStyle = headStyle;//设置表头样式

                                if (arrColWidth[i] > 255)
                                {
                                    arrColWidth[i] = 254;
                                }
                                else
                                {
                                    sheet.SetColumnWidth(i, (arrColWidth[i] + 1) * 256);
                                    //sheet.SetColumnWidth(i, (arrColWidth[i] + 2) * 256);//设置表头列宽
                                    //讲解：SetColumnWidth的第二个参数要乘以256，这个参数的单位是1/256个字符宽度，也就是说，这里是把宽度设置为了相应字符长度*256。
                                }


                            }
                        }
                        #endregion

                        rowIndex = 1;
                    }
                    #endregion

                    #region 填充内容
                    //创建行
                    IRow dataRow = sheet.CreateRow(rowIndex);
                    dataRow.Height = 20 * 20;

                    //foreach (DataColumn column in dtSource.Columns)   
                    for (int i = 0; i < oldColumnNames.Length; i++)
                    {
                        //创建列
                        ICell newCell = dataRow.CreateCell(i);

                        string drValue = row[oldColumnNames[i]].ToString();

                        switch (dtSource.Columns[oldColumnNames[i]].DataType.ToString())
                        {
                            case "System.String"://字符串类型      
                                newCell.SetCellValue(drValue);
                                newCell.CellStyle = styleBorder;
                                //如果创建列的索引等于0和1就将工序样式设置为水平垂直居中
                                if (newCell.ColumnIndex == 0 || newCell.ColumnIndex == 1)
                                    newCell.CellStyle = styleStr;
                                break;
                            case "System.DateTime"://日期类型      
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);
                                newCell.CellStyle = styleTodate;//格式化显示      
                                break;
                            case "System.Boolean"://布尔型      
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型      
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                newCell.CellStyle = styleStr;
                                break;
                            case "System.Decimal"://浮点型      
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理      
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }
                    }
                    #endregion

                    rowIndex++;
                }

                //调用合并方法，第0列开始需要合并
                mergeusers(sheet, 0);

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                    //sheet.Dispose();   
                    sheet = null;
                    workbook = null;
                    //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet      
                    getms = ms;
                }


                //合并单元格：合并单元格实际上是声明一个区域，该区域中的单元格将进行合并，合并后的内容与样式以该区域最左上角的单元格为准。
                //设置一个合并单元格区域，使用上下左右定义CellRangeAddress区域
                //CellRangeAddress四个参数为：起始行，结束行，起始列，结束列
                //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));

                #endregion

                using (MemoryStream ms = getms)
                {
                    byte[] data = ms.ToArray();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// DataTable导出到Excel文件（无表头）另外的是有表头的
        /// </summary>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strSheetName">工作表名称</param>
        /// <param name="oldColumnNames">旧行（代表实体类ProGXGBExportModel的所有对象）</param>
        /// <param name="newColumnNames">新行（代表新插入的表头）</param>
        /// <returns></returns>
        public static byte[] MyExport(string strFileName)
        {
            try
            {
                //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式

                //创建系统内存流
                MemoryStream getms = new MemoryStream();

                #region 为getms赋值


                IWorkbook workbook = null;

                FileStream fs = File.OpenRead(strFileName);
                string extension = System.IO.Path.GetExtension(strFileName);

                if (extension.Equals(".xls"))
                {
                    //把xls文件中的数据写入wk中
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    //把xlsx文件中的数据写入wk中
                    workbook = new XSSFWorkbook(fs);
                }

                fs.Close();

                using (MemoryStream ms = new MemoryStream())
                {
                    workbook.Write(ms);
                    ms.Flush();
                    ms.Position = 0;

                    workbook = null;
                    //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet      
                    getms = ms;
                }


                //合并单元格：合并单元格实际上是声明一个区域，该区域中的单元格将进行合并，合并后的内容与样式以该区域最左上角的单元格为准。
                //设置一个合并单元格区域，使用上下左右定义CellRangeAddress区域
                //CellRangeAddress四个参数为：起始行，结束行，起始列，结束列
                //sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 10));


                #endregion

                using (MemoryStream ms = getms)
                {
                    byte[] data = ms.ToArray();
                    return data;
                }
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }


        /// <summary>
        /// 合并方法 只适用于合并数量大于2时有用（工序需合并数量大于2）
        /// </summary>
        /// <param name="sheet">当前sheet</param>
        /// <param name="columnIndex">合并列索引</param>
        public static void mergeuser(ISheet sheet, int columnIndex)
        {
            //开始 要合并的内容为空
            var previous = "";
            //startRow  是你Excel 数据是 第几行开始的,需过滤表头数据所有索引从1开始
            var startRow = 1;
            for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
            {
                //获取 指定行，指定列的 数据内容
                var current = sheet.GetRow(rowNum).GetCell(columnIndex).StringCellValue;
                // 判断 获取到的内容是否和 上一列 相等，否则跳过循环
                if (current.Equals(previous)) { continue; }
                else
                {
                    // 第一级 合并。
                    //将获取到的 内容 赋值到 previous 
                    previous = current;
                    // 判断开始行，是否小于 循环的行数。
                    if (startRow < rowNum)
                    {
                        //第二级 合并
                        var celltext = "";
                        var startAM = startRow;
                        for (int i = startRow; i <= rowNum; i++)
                        {
                            var endtext = sheet.GetRow(i).GetCell(1).StringCellValue;
                            if (celltext.Equals(endtext))
                            { continue; }
                            else
                            {
                                celltext = endtext;
                                if (startAM < i)
                                {
                                    //CellRangeAddress（起始行号，终止行号， 起始列号，终止列号）
                                    //这里 终止行号 -1  原因是：上面循环判断时 内容不一样的  才进行 合并，
                                    //这时 行数 i 内容 已经不一样，所以 需要减去 1  进行合并

                                    sheet.AddMergedRegion(new CellRangeAddress(startAM, i - 1, columnIndex + 1, columnIndex + 1));
                                }
                                // 将 当前行数，进行赋值给 启始行数。
                                startAM = i;
                            }
                        }
                        sheet.AddMergedRegion(new CellRangeAddress(startRow, rowNum - 1, columnIndex, columnIndex));
                    }
                    startRow = rowNum;
                }

            }
        }



        /// <summary>
        /// 合并方法 能同时满足合并数量大于2 自动判断第二列是否有重复数据合并
        /// </summary>
        /// <param name="sheet">当前sheet</param>
        /// <param name="columnIndex">合并列索引</param>
        public static void mergeusers(ISheet sheet, int columnIndex)
        {
            //开始 要合并的内容为空
            var previous = "";
            //startRow  是你Excel 数据是 第几行开始的,需过滤表头数据所有索引从1开始
            var startRow = 1;
            var endRow = 1;
            for (int rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
            {
                //获取 指定行，指定列的 数据内容
                var current = sheet.GetRow(rowNum).GetCell(columnIndex).StringCellValue;
                // 判断 获取到的内容 是否和上一列相等，否则进入多条合并数据逻辑中
                if (current.Equals(previous))
                {
                    endRow = rowNum;
                    // 如果工序小于合并行2时直接判断是否是最后的数据进行合并
                    if (endRow == sheet.LastRowNum)
                    {
                        // 第一级 合并。
                        sheet.AddMergedRegion(new CellRangeAddress(startRow, endRow, columnIndex, columnIndex));

                        #region  如果工序小于合并行2时，直接进入工序描述合并
                        var cellfirstText = "";
                        var cellfirst = startRow;
                        for (int j = startRow; j <= endRow; j++)
                        {
                            var text = sheet.GetRow(j).GetCell(1).StringCellValue;
                            if (cellfirstText.Equals(text))
                            {
                                cellfirst = j;
                                if (cellfirst == endRow)
                                {
                                    sheet.AddMergedRegion(new CellRangeAddress(startRow, j, columnIndex + 1, columnIndex + 1));
                                }
                            }
                            else
                            {
                                cellfirstText = text;
                                cellfirst = j;
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    //将获取到的 内容 赋值到 previous 
                    previous = current;
                    if (startRow < rowNum)
                    {
                        //第二级 合并。
                        var celltext = "";
                        var startAM = startRow;
                        for (int i = startRow; i <= rowNum; i++)
                        {
                            var endtext = sheet.GetRow(i).GetCell(1).StringCellValue;
                            if (celltext.Equals(endtext))
                            { continue; }
                            else
                            {
                                celltext = endtext;
                                if (startAM < i)
                                {
                                    //CellRangeAddress（起始行号，终止行号， 起始列号，终止列号）
                                    //这里 终止行号 -1  原因是：上面循环判断时 内容不一样的  才进行 合并，
                                    //这时 行数 i 内容 已经不一样，所以 需要减去 1  进行合并
                                    sheet.AddMergedRegion(new CellRangeAddress(startAM, i - 1, columnIndex + 1, columnIndex + 1));
                                }
                                // 将 当前行数，进行赋值给 启始行数。
                                startAM = i;
                            }
                        }
                        // 第一级 合并。
                        sheet.AddMergedRegion(new CellRangeAddress(startRow, rowNum - 1, columnIndex, columnIndex));
                    }
                    startRow = rowNum;
                    endRow = rowNum;
                }
            }
        }



        /// <summary>
        /// 根据模版导出Excel -- 特别处理,每个分组带合计
        /// </summary>
        /// <param name="source">源DataTable</param>
        /// <param name="cellKeys">需要导出的对应的列字段  例：string[] cellKeys = { "Date","Remarks" };</param>
        /// <param name="strFileName">要保存的文件名称（包含后缀）  例："要保存的文件名.xls"</param>
        /// <param name="templateFile">模版文件名（包含路径后缀）  例："模板文件名.xls"</param>
        /// <param name="rowIndex">从第几行开始创建数据行,第一行为0</param>
        /// <param name="mergeColumns">值相同时，可合并的前几列 最多支持2列 1=只合并第一列，2=判断前2列</param>
        /// <param name="isConver">是否覆盖数据，=false，将把原数据下移。=true，将覆盖插入行后面的数据</param>
        /// <returns>是否导出成功</returns>
        public static bool Export2Template2(DataTable source, string[] cellKeys, string strFileName, string templateFile, int rowIndex, int mergeColumns, bool isConver)
        {
            bool bn = false;
            int cellCount = cellKeys.Length; //总列数，第一列为0
                                             // IWorkbook workbook = null;
            HSSFWorkbook workbook = null;
            string temp0 = "", temp1 = "";
            int start0 = 0, start1 = 0;  // 记录1，2列值相同的开始序号
            int end0 = 0, end1 = 0;// 记录1，2列值相同的结束序号

            try
            {
                using (FileStream file = new FileStream(templateFile, FileMode.Open, FileAccess.Read))
                {
                    workbook = new HSSFWorkbook(file);
                }

                #region 定义四类数据的单元格样式
                // 内容数据格式 -- 数值
                ICellStyle styleNum = workbook.CreateCellStyle();
                styleNum.BorderBottom = BorderStyle.Thin;
                styleNum.BorderLeft = BorderStyle.Thin;
                styleNum.BorderRight = BorderStyle.Thin;
                styleNum.BorderTop = BorderStyle.Thin;
                // styleNum.VerticalAlignment = VerticalAlignment.Center;
                // styleNum.Alignment = HorizontalAlignment.Center;

                // 内容数据格式 -- 字符串（做居中处理）
                ICellStyle styleStr = workbook.CreateCellStyle();
                styleStr.BorderBottom = BorderStyle.Thin;
                styleStr.BorderLeft = BorderStyle.Thin;
                styleStr.BorderRight = BorderStyle.Thin;
                styleStr.BorderTop = BorderStyle.Thin;
                styleStr.VerticalAlignment = VerticalAlignment.Center;
                styleStr.Alignment = HorizontalAlignment.Center;

                // 汇总数据格式 -- 数值
                ICellStyle styleTotalNum = workbook.CreateCellStyle();
                styleTotalNum.BorderBottom = BorderStyle.Thin;
                styleTotalNum.BorderLeft = BorderStyle.Thin;
                styleTotalNum.BorderRight = BorderStyle.Thin;
                styleTotalNum.BorderTop = BorderStyle.Thin;
                styleTotalNum.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                styleTotalNum.FillPattern = FillPattern.SolidForeground;
                styleTotalNum.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Red.Index;
                // 设置字体颜色
                HSSFFont ffont0 = (HSSFFont)workbook.CreateFont();
                // ffont0.FontHeight = 14 * 14;
                // ffont0.FontName = "宋体";
                ffont0.IsBold = true;
                //ffont0.Color = HSSFColor.Red.Index;
                styleTotalNum.SetFont(ffont0);

                // 汇总数据格式 -- 字符串（做居中处理）
                ICellStyle styleTotalStr = workbook.CreateCellStyle();
                styleTotalStr.BorderBottom = BorderStyle.Thin;
                styleTotalStr.BorderLeft = BorderStyle.Thin;
                styleTotalStr.BorderRight = BorderStyle.Thin;
                styleTotalStr.BorderTop = BorderStyle.Thin;
                styleTotalStr.VerticalAlignment = VerticalAlignment.Center;
                styleTotalStr.Alignment = HorizontalAlignment.Center;
                styleTotalStr.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
                styleTotalStr.FillPattern = FillPattern.SolidForeground;
                // 设置字体颜色
                HSSFFont ffont1 = (HSSFFont)workbook.CreateFont();
                // ffont1.FontHeight = 14 * 14;
                // ffont1.FontName = "宋体";
                ffont1.IsBold = true;
                //ffont.Color = HSSFColor.Red.Index;
                styleTotalStr.SetFont(ffont1);
                #endregion

                ISheet sheet = workbook.GetSheetAt(0);   // 打开第一个sheet页
                if (sheet != null && source != null && source.Rows.Count > 0)  // 模板内容为空，不做处理
                {
                    IRow row;
                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        if (!isConver) sheet.ShiftRows(rowIndex, sheet.LastRowNum, 1, true, false);   // 不覆盖，数据向下移

                        #region 第一行，写入数据后，对变量赋初值
                        if (i == 0) // 第一行，赋初值
                        {
                            row = sheet.CreateRow(rowIndex);
                            #region  创建列并插入数据
                            //创建列并插入数据
                            for (int index = 0; index < cellCount; index++)
                            {
                                ICell cell = row.CreateCell(index);

                                string strValue = !(source.Rows[i][cellKeys[index]] is DBNull) ? source.Rows[i][cellKeys[index]].ToString() : string.Empty;
                                // 其它列数据，数值进行汇总
                                switch (source.Columns[cellKeys[index]].DataType.ToString())
                                {
                                    case "System.Int16": //整型
                                    case "System.Int32":
                                    case "System.Int64":
                                    case "System.Byte":
                                        int intV = 0;
                                        int.TryParse(strValue, out intV);
                                        cell.CellStyle = styleNum;  // 设置格式
                                        cell.SetCellValue(intV);
                                        break;
                                    case "System.Decimal": //浮点型
                                    case "System.Double":
                                    case "System.Single":
                                        double doubV = 0;
                                        double.TryParse(strValue, out doubV);
                                        cell.CellStyle = styleNum;  // 设置格式
                                        cell.SetCellValue(doubV);
                                        break;
                                    default:
                                        cell.CellStyle = styleStr;  // 设置格式
                                        cell.SetCellValue(strValue);
                                        break;
                                }
                            }
                            #endregion

                            if (mergeColumns > 0)
                            {
                                temp0 = source.Rows[i][cellKeys[0]].ToString();  // 保存第1列值
                                start0 = rowIndex;
                                end0 = rowIndex;
                            }
                            if (mergeColumns > 1)
                            {
                                temp1 = source.Rows[i][cellKeys[1]].ToString();  // 保存第2列值                  
                                start1 = rowIndex;
                                end1 = rowIndex;
                            }

                            rowIndex++;
                            continue;
                        }
                        #endregion

                        // 不是第一行数据的处理
                        // 判断1列值变化没
                        string cellText0 = source.Rows[i][cellKeys[0]].ToString();
                        if (temp0 != cellText0) // 第1列值有变化
                        {
                            #region 第2列要合并
                            if (mergeColumns > 1)  // 第2列要合并
                            {
                                if (start1 != end1) // 开始行和结束行不相同，才进行合并
                                {
                                    CellRangeAddress region1 = new CellRangeAddress(start1, end1, 1, 1); // 合并第二列
                                    sheet.AddMergedRegion(region1);
                                }
                                temp1 = source.Rows[i][cellKeys[1]].ToString();
                                end0++;
                                rowIndex++;
                            }
                            #endregion

                            #region 第1列要合并
                            if (mergeColumns > 0)   // 第1列要合并
                            {
                                if (start0 != end0) // 开始行和结束行不相同，才进行合并
                                {
                                    CellRangeAddress region0 = new CellRangeAddress(start0, end0, 0, 0); // 合并第二列
                                    sheet.AddMergedRegion(region0);
                                }

                                temp0 = cellText0;
                            }
                            #endregion

                            // 重新赋值
                            start0 = rowIndex;
                            end0 = rowIndex;
                            start1 = rowIndex;
                            end1 = rowIndex;
                        }
                        else  // 第1列值没有变化
                        {
                            end0++;
                            // 判断第2列是否有变化
                            string cellText1 = source.Rows[i][cellKeys[1]].ToString();
                            if (cellText1 != temp1)  // 第1列没变，第2列变化
                            {
                                #region 第2列要合并
                                if (mergeColumns > 1)  // 第2列要合并
                                {
                                    if (start1 != end1) // 开始行和结束行不相同，才进行合并
                                    {
                                        CellRangeAddress region1 = new CellRangeAddress(start1, end1, 1, 1); // 合并第二列
                                        sheet.AddMergedRegion(region1);
                                    }

                                }
                                #endregion
                            }
                            else  // 第1列值没变，第2列也没变
                                end1++;
                        }

                        // 插入当前数据
                        row = sheet.CreateRow(rowIndex);
                        #region  创建行并插入当前记录的数据
                        //创建行并插入当前记录的数据
                        for (int index = 0; index < cellCount; index++)
                        {
                            ICell cell = row.CreateCell(index);
                            string strValue = !(source.Rows[i][cellKeys[index]] is DBNull) ? source.Rows[i][cellKeys[index]].ToString() : string.Empty; // 取值
                            switch (source.Columns[cellKeys[index]].DataType.ToString())
                            {
                                case "System.Int16": //整型
                                case "System.Int32":
                                case "System.Int64":
                                case "System.Byte":
                                    int intV = 0;
                                    int.TryParse(strValue, out intV);
                                    cell.CellStyle = styleNum;
                                    cell.SetCellValue(intV);
                                    break;
                                case "System.Decimal": //浮点型
                                case "System.Double":
                                case "System.Single":
                                    double doubV = 0;
                                    double.TryParse(strValue, out doubV);
                                    cell.CellStyle = styleNum;
                                    cell.SetCellValue(doubV);
                                    break;
                                default:
                                    cell.CellStyle = styleStr;
                                    cell.SetCellValue(strValue);
                                    break;
                            }
                        }
                        #endregion
                        // 下移一行
                        rowIndex++;
                    }

                    // 最后一条记录的合计
                    #region 对第2列进行合并
                    if (mergeColumns > 1) // 对第2列合并
                    {
                        if (start1 != end1)  // 开始行和结束行不等，进行合并
                        {
                            CellRangeAddress region1 = new CellRangeAddress(start1, end1, 1, 1); // 合并第二列
                            sheet.AddMergedRegion(region1);
                        }


                    }
                    #endregion

                    #region 对第1列合并
                    if (mergeColumns > 0) // 对第1列合并
                    {
                        if (start0 != end0)  // 开始行和结束行不等，进行合并
                        {
                            CellRangeAddress region1 = new CellRangeAddress(start0, end0, 0, 0); // 合并第二列
                            sheet.AddMergedRegion(region1);
                        }


                    }
                    #endregion

                }
                return Save2Xls(strFileName, workbook);  // 保存为xls文件
            }
            catch (Exception ex)
            {
                // FileHelper.WriteLine(logfile, "处理数据异常：" + ex.Message);
                // msg = ex.Message;
            }
            return bn;
        }

        public static bool Save2Xls(string fileName, IWorkbook workbook)
        {
            bool bn = false;
            try
            {
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);

                MemoryStream ms = new MemoryStream();
                workbook.Write(ms);
                BinaryWriter w = new BinaryWriter(fs);
                w.Write(ms.ToArray());
                fs.Close();
                ms.Close();
                bn = true;
            }
            catch (Exception ex)
            {
                //FileHelper.WriteLine(logfile, "保存文件异常：" + ex.Message);
            }
            return bn;
        }



        /// <summary>      
        /// DataTable导出到Excel的MemoryStream      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strSheetName">工作表名称</param>   
        /// <Author>CallmeYhz 2015-11-26 10:13:09</Author>      
        public static MemoryStream Export(DataTable dtSource, string strHeaderText, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            if (oldColumnNames.Length != newColumnNames.Length)
            {
                return new MemoryStream();
            }
            HSSFWorkbook workbook = new HSSFWorkbook();
            //HSSFSheet sheet = workbook.CreateSheet();// workbook.CreateSheet();   
            ISheet sheet = workbook.CreateSheet(strSheetName);

            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "http://....../";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                if (HttpContext.Current.Session["realname"] != null)
                {
                    si.Author = HttpContext.Current.Session["realname"].ToString();
                }
                else
                {
                    //if (HttpContext.Current.Session["username"] != null)
                    //{
                    //    si.Author = HttpContext.Current.Session["username"].ToString();
                    //}
                }                                       //填加xls文件作者信息      
                si.ApplicationName = "NPOI";            //填加xls文件创建程序信息      
                si.LastAuthor = "OA系统";           //填加xls文件最后保存者信息      
                si.Comments = "OA系统自动创建文件";      //填加xls文件作者信息      
                si.Title = strHeaderText;               //填加xls文件标题信息      
                si.Subject = strHeaderText;              //填加文件主题信息      
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            ICellStyle dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");

            #region 取得列宽
            int[] arrColWidth = new int[oldColumnNames.Length];
            for (int i = 0; i < oldColumnNames.Length; i++)
            {
                arrColWidth[i] = Encoding.GetEncoding(936).GetBytes(newColumnNames[i]).Length;
            }
            /* 
            foreach (DataColumn item in dtSource.Columns) 
            { 
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length; 
            } 
             * */

            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < oldColumnNames.Length; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][oldColumnNames[j]].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
                /* 
                for (int j = 0; j < dtSource.Columns.Count; j++) 
                { 
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length; 
                    if (intTemp > arrColWidth[j]) 
                    { 
                        arrColWidth[j] = intTemp; 
                    } 
                } 
                 * */
            }
            #endregion
            int rowIndex = 0;

            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = workbook.CreateSheet(strSheetName + ((int)rowIndex / 65535).ToString());
                    }

                    #region 表头及样式
                    {
                        IRow headerRow = sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        headerRow.GetCell(0).CellStyle = headStyle;
                        //sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));   
                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, dtSource.Columns.Count - 1));
                    }
                    #endregion


                    #region 列头及样式
                    {
                        //HSSFRow headerRow = sheet.CreateRow(1);   
                        IRow headerRow = sheet.CreateRow(1);

                        ICellStyle headStyle = workbook.CreateCellStyle();
                        headStyle.Alignment = HorizontalAlignment.Center;
                        IFont font = workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);

                        for (int i = 0; i < oldColumnNames.Length; i++)
                        {
                            headerRow.CreateCell(i).SetCellValue(newColumnNames[i]);
                            headerRow.GetCell(i).CellStyle = headStyle;
                            //设置列宽   
                            sheet.SetColumnWidth(i, (arrColWidth[i] + 1) * 256);
                        }
                        /* 
                        foreach (DataColumn column in dtSource.Columns) 
                        { 
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName); 
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle; 
 
                            //设置列宽    
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256); 
                        } 
                         * */
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion


                #region 填充内容
                IRow dataRow = sheet.CreateRow(rowIndex);
                //foreach (DataColumn column in dtSource.Columns)   
                for (int i = 0; i < oldColumnNames.Length; i++)
                {
                    ICell newCell = dataRow.CreateCell(i);

                    string drValue = row[oldColumnNames[i]].ToString();

                    switch (dtSource.Columns[oldColumnNames[i]].DataType.ToString())
                    {
                        case "System.String"://字符串类型      
                            newCell.SetCellValue(drValue);
                            break;
                        case "System.DateTime"://日期类型      
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示      
                            break;
                        case "System.Boolean"://布尔型      
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            break;
                        case "System.Int16"://整型      
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            break;
                        case "System.Decimal"://浮点型      
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            break;
                        case "System.DBNull"://空值处理      
                            newCell.SetCellValue("");
                            break;
                        default:
                            newCell.SetCellValue("");
                            break;
                    }

                }
                #endregion

                rowIndex++;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                //sheet.Dispose();   
                sheet = null;
                workbook = null;
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet      
                return ms;
            }
        }


        /// <summary>      
        /// WEB导出DataTable到Excel      
        /// </summary>      
        /// <param name="dtSource">源DataTable</param>      
        /// <param name="strHeaderText">表头文本</param>      
        /// <param name="strFileName">文件名</param>      
        /// <Author>CallmeYhz 2015-11-26 10:13:09</Author>      
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName)
        {
            ExportByWeb(dtSource, strHeaderText, strFileName, "sheet");
        }

        /// <summary>   
        /// WEB导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        /// <param name="strFileName">输出文件名，包含扩展名</param>   
        /// <param name="oldColumnNames">要导出的DataTable列数组</param>   
        /// <param name="newColumnNames">导出后的对应列名</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string[] oldColumnNames, string[] newColumnNames)
        {
            ExportByWeb(dtSource, strHeaderText, strFileName, "sheet", oldColumnNames, newColumnNames);
        }

        /// <summary>   
        /// WEB导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">源DataTable</param>   
        /// <param name="strHeaderText">表头文本</param>   
        /// <param name="strFileName">输出文件名</param>   
        /// <param name="strSheetName">工作表名称</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式      
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            //生成列   
            string columns = "";
            for (int i = 0; i < dtSource.Columns.Count; i++)
            {
                if (i > 0)
                {
                    columns += ",";
                }
                columns += dtSource.Columns[i].ColumnName;
            }

            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, strSheetName, columns.Split(','), columns.Split(',')).GetBuffer());
            curContext.Response.End();

        }

        /// <summary>   
        /// 导出DataTable到Excel   
        /// </summary>   
        /// <param name="dtSource">要导出的DataTable</param>   
        /// <param name="strHeaderText">标题文字</param>   
        /// <param name="strFileName">文件名，包含扩展名</param>   
        /// <param name="strSheetName">工作表名</param>   
        /// <param name="oldColumnNames">要导出的DataTable列数组</param>   
        /// <param name="newColumnNames">导出后的对应列名</param>   
        public static void ExportByWeb(DataTable dtSource, string strHeaderText, string strFileName, string strSheetName, string[] oldColumnNames, string[] newColumnNames)
        {
            HttpContext curContext = HttpContext.Current;

            // 设置编码和附件格式      
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            curContext.Response.AppendHeader("Content-Disposition",
                "attachment;filename=" + HttpUtility.UrlEncode(strFileName, Encoding.UTF8));

            curContext.Response.BinaryWrite(Export(dtSource, strHeaderText, strSheetName, oldColumnNames, newColumnNames).GetBuffer());
            curContext.Response.End();
        }

        /// <summary>读取excel      
        /// 默认第一行为表头，导入第一个工作表   
        /// </summary>      
        /// <param name="strFileName">excel文档路径</param>      
        /// <returns></returns>      
        public static DataTable Import(string strFileName)
        {
            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                ICell cell = headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString();
                }
                dt.Rows.Add(dataRow);
            }
            return dt;
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="strFileName">Excel文件全路径(服务器路径)</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(string strFileName, string SheetName, int HeaderRowIndex)
        {
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(SheetName);
                return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
            }
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="strFileName">Excel文件全路径(服务器路径)</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcelXSS(string strFileName, string SheetName, int HeaderRowIndex)
        {
            IWorkbook wk = null;
            FileStream fs = File.OpenRead(strFileName);
            string extension = System.IO.Path.GetExtension(strFileName);

            if (extension.Equals(".xls"))
            {
                //把xls文件中的数据写入wk中
                wk = new HSSFWorkbook(fs);
            }
            else
            {
                //把xlsx文件中的数据写入wk中
                wk = new XSSFWorkbook(fs);
            }
            fs.Close();

            //读取当前表数据
            ISheet sheet = wk.GetSheetAt(0);

            DataTable table = new DataTable();
            try
            {
                IRow headerRow = sheet.GetRow(HeaderRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;

                #region 循环各行各列,写入数据到DataTable
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell == null)
                        {
                            dataRow[j] = null;
                        }
                        else
                        {
                            //dataRow[j] = cell.ToString();   
                            switch (cell.CellType)
                            {
                                case CellType.Blank:
                                    dataRow[j] = null;
                                    break;
                                case CellType.Boolean:
                                    dataRow[j] = cell.BooleanCellValue;
                                    break;
                                case CellType.Numeric:
                                    dataRow[j] = cell.ToString();
                                    break;
                                case CellType.String:
                                    dataRow[j] = cell.StringCellValue;
                                    break;
                                case CellType.Error:
                                    dataRow[j] = cell.ErrorCellValue;
                                    break;
                                case CellType.Formula:
                                default:
                                    dataRow[j] = "=" + cell.CellFormula;
                                    break;
                            }
                        }
                    }
                    table.Rows.Add(dataRow);
                    //dataRow[j] = row.GetCell(j).ToString();   
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                table.Clear();
                table.Columns.Clear();
                table.Columns.Add("出错了");
                DataRow dr = table.NewRow();
                dr[0] = ex.Message;
                table.Rows.Add(dr);
                return table;
            }
            finally
            {
                //sheet.Dispose();   
                wk = null;
                sheet = null;
            }
            #region 清除最后的空行
            for (int i = table.Rows.Count - 1; i > 0; i--)
            {
                bool isnull = true;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Rows[i][j] != null)
                    {
                        if (table.Rows[i][j].ToString() != "")
                        {
                            isnull = false;
                            break;
                        }
                    }
                }
                if (isnull)
                {
                    table.Rows[i].Delete();
                }
            }
            #endregion
            return table;
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="strFileName">Excel文件全路径(服务器路径)</param>   
        /// <param name="SheetIndex">要获取数据的工作表序号(从0开始)</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(string strFileName, int SheetIndex, int HeaderRowIndex)
        {
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new HSSFWorkbook(file);
                string SheetName = workbook.GetSheetName(SheetIndex);
                return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
            }
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="ExcelFileStream">Excel文件流</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, string SheetName, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ExcelFileStream.Close();
            return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="ExcelFileStream">Excel文件流</param>   
        /// <param name="SheetIndex">要获取数据的工作表序号(从0开始)</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(Stream ExcelFileStream, int SheetIndex, int HeaderRowIndex)
        {
            IWorkbook workbook = new HSSFWorkbook(ExcelFileStream);
            ExcelFileStream.Close();
            string SheetName = workbook.GetSheetName(SheetIndex);
            return RenderDataTableFromExcel(workbook, SheetName, HeaderRowIndex);
        }

        /// <summary>   
        /// 从Excel中获取数据到DataTable   
        /// </summary>   
        /// <param name="workbook">要处理的工作薄</param>   
        /// <param name="SheetName">要获取数据的工作表名称</param>   
        /// <param name="HeaderRowIndex">工作表标题行所在行号(从0开始)</param>   
        /// <returns></returns>   
        public static DataTable RenderDataTableFromExcel(IWorkbook workbook, string SheetName, int HeaderRowIndex)
        {
            ISheet sheet = workbook.GetSheet(SheetName);
            DataTable table = new DataTable();
            try
            {
                IRow headerRow = sheet.GetRow(HeaderRowIndex);
                int cellCount = headerRow.LastCellNum;

                for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                {
                    DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                    table.Columns.Add(column);
                }

                int rowCount = sheet.LastRowNum;

                #region 循环各行各列,写入数据到DataTable
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    DataRow dataRow = table.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        ICell cell = row.GetCell(j);
                        if (cell == null)
                        {
                            dataRow[j] = null;
                        }
                        else
                        {
                            //dataRow[j] = cell.ToString();   
                            switch (cell.CellType)
                            {
                                case CellType.Blank:
                                    dataRow[j] = null;
                                    break;
                                case CellType.Boolean:
                                    dataRow[j] = cell.BooleanCellValue;
                                    break;
                                case CellType.Numeric:
                                    dataRow[j] = cell.ToString();
                                    break;
                                case CellType.String:
                                    dataRow[j] = cell.StringCellValue;
                                    break;
                                case CellType.Error:
                                    dataRow[j] = cell.ErrorCellValue;
                                    break;
                                case CellType.Formula:
                                default:
                                    dataRow[j] = "=" + cell.CellFormula;
                                    break;
                            }
                        }
                    }
                    table.Rows.Add(dataRow);
                    //dataRow[j] = row.GetCell(j).ToString();   
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                table.Clear();
                table.Columns.Clear();
                table.Columns.Add("出错了");
                DataRow dr = table.NewRow();
                dr[0] = ex.Message;
                table.Rows.Add(dr);
                return table;
            }
            finally
            {
                //sheet.Dispose();   
                workbook = null;
                sheet = null;
            }
            #region 清除最后的空行
            for (int i = table.Rows.Count - 1; i > 0; i--)
            {
                bool isnull = true;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    if (table.Rows[i][j] != null)
                    {
                        if (table.Rows[i][j].ToString() != "")
                        {
                            isnull = false;
                            break;
                        }
                    }
                }
                if (isnull)
                {
                    table.Rows[i].Delete();
                }
            }
            #endregion
            return table;
        }




        #region 旧版 NPOI导入功能


        /// <summary>
        /// 旧版
        /// 获取Excel装换为DataTable
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static DataTable GetExcelDataTable(string filePath)
        {
            IWorkbook Workbook;
            DataTable table = new DataTable();
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                    string fileExt = Path.GetExtension(filePath).ToLower();
                    if (fileExt == ".xls")
                    {
                        Workbook = new HSSFWorkbook(fileStream);
                    }
                    else if (fileExt == ".xlsx")
                    {
                        Workbook = new XSSFWorkbook(fileStream);
                    }
                    else
                    {
                        Workbook = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //定位在第一个sheet
            ISheet sheet = Workbook.GetSheetAt(0);
            //第一行为标题行
            IRow headerRow = sheet.GetRow(0);
            int cellCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;

            //循环添加标题列
            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }

            //数据
            for (int i = (sheet.FirstRowNum + 1); i <= rowCount; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();
                if (row != null)
                {
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                        {
                            dataRow[j] = GetCellValue(row.GetCell(j));
                        }
                    }
                }
                table.Rows.Add(dataRow);
            }
            return table;
        }

        /// <summary>
        /// 旧版
        /// 获取单元格Cell
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static string GetCellValue(ICell cell)
        {
            if (cell == null)
            {
                return string.Empty;
            }

            switch (cell.CellType)
            {
                case CellType.Blank:
                    return string.Empty;
                case CellType.Boolean:
                    return cell.BooleanCellValue.ToString();
                case CellType.Error:
                    return cell.ErrorCellValue.ToString();
                case CellType.Numeric:
                case CellType.Unknown:
                default:
                    return cell.ToString();
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Formula:
                    try
                    {
                        HSSFFormulaEvaluator e = new HSSFFormulaEvaluator(cell.Sheet.Workbook);
                        e.EvaluateInCell(cell);
                        return cell.ToString();
                    }
                    catch
                    {
                        return cell.NumericCellValue.ToString();
                    }
            }
        }


        /// <summary>
        /// 旧版
        /// 移除空行
        /// </summary>
        /// <param name="dt"></param>
        public static void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }


        #endregion

    }
}