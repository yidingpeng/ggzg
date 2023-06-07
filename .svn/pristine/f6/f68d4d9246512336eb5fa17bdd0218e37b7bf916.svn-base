using System.Collections.Generic;
using RW.PMS.Model.Barcode;
using RW.PMS.Common;

namespace RW.PMS.IDAL
{
    public interface IDAL_Barcode: IDependence
    {
        /// <summary>
        /// 添加条码信息
        /// </summary>
        /// <param name="main"></param>
        void AddBarcode(BarcodeMain main);

        /// <summary>
        /// 获取条形码主表明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BarcodeMain GetDetail(string id);

        /// <summary>
        /// 获取最大的模组流水号
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="pModelDrawingNo"></param>
        /// <returns></returns>
        int GetModelNoMax(string type,string year, string month, string pModelNo);

        /// <summary>
        /// 查询条码信息
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="modelCode">模组编号</param>
        /// <param name="batteriesCode">电芯编号</param>
        /// <returns></returns>
        List<BarcodeMain> QueryBarcode(string type,string year, string month, string pModelNo);
    }
}