using System.Collections.Generic;
using RW.PMS.Model.Barcode;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;

namespace RW.PMS.BLL
{
    internal class BLL_Barcode : IBLL_Barcode
    {
        private IDAL_Barcode _DAl;
        public BLL_Barcode()
        {
            _DAl = DIService.GetService<IDAL_Barcode>();
        }
        /// <summary>
        /// 添加条码信息
        /// </summary>
        /// <param name="main"></param>
        public void AddBarcode(BarcodeMain main)
        {
            _DAl.AddBarcode(main);
        }

        /// <summary>
        /// 获取条形码主表明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BarcodeMain GetDetail(string id)
        {
            return _DAl.GetDetail(id);
        }

        /// <summary>
        /// 获取最大的模组流水号
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="pModelDrawingNo"></param>
        /// <returns></returns>
        public int GetModelNoMax(string type,string year, string month, string pModelNo)
        {
            return _DAl.GetModelNoMax(type,year, month, pModelNo);
        }

        /// <summary>
        /// 查询条码信息
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="modelCode">模组编号</param>
        /// <param name="batteriesCode">电芯编号</param>
        /// <returns></returns>
        public List<BarcodeMain> QueryBarcode(string type, string year, string month, string pModelNo)
        {
            return _DAl.QueryBarcode(type,year, month, pModelNo);
        }
    }
}