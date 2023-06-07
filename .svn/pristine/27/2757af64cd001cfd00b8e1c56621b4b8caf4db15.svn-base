using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.Barcode;
using RW.PMS.Model.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RW.PMS.WebApi.Controllers
{
    public class BarcodeController : ApiController
    {
        private IBLL_Barcode _barcode = DIService.GetService<IBLL_Barcode>();
        private IBLL_BaseInfo _baseInfo = DIService.GetService<IBLL_BaseInfo>();
        private IBLL_Assembly _assembly = DIService.GetService<IBLL_Assembly>();
        IBLL_ProductInfo _productInfo = DIService.GetService<IBLL_ProductInfo>();

        /// <summary>
        /// 产品装配信息查询
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="prodCode"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResponseResult<List<AssemblyInfoModel>> IAssemblyInformationQuery(DateTime startDate, DateTime endDate, string prodCode)
        {
            var list = _productInfo.GetAssemblyGwList(startDate, endDate, prodCode);
            var res = new ResponseResult<List<AssemblyInfoModel>>();
            res.Body = list;
            res.Success = true;
            return res;
        }

        /// <summary>
        /// 获取产品型号
        /// </summary>
        /// <returns></returns>
        public ResponseResult<List<BaseProductModelModel>> GetModelCode()
        {
            var list = _baseInfo.GetProductModelAll();
            var res = new ResponseResult<List<BaseProductModelModel>>();
            res.Body = list;
            res.Success = true;
            return res;
        }

        /// <summary>
        /// 传递工位操作信息
        /// </summary>
        /// <returns></returns>
        public ResponseResult<string> SetTightenMachineModel(TightenMachineModel model)
        {
            try
            {
                bool a = _assembly.AddTightenMachineInfo(model);
                var res = new ResponseResult<string>();
                res.Body = a ? "添加成功；" : "添加失败；";
                res.Success = a;
                return res;
            }
            catch (Exception e)
            {
                var res = new ResponseResult<string>();
                res.Body = e.Message;
                res.Success = false;
                return res;
            }
        
        }

        /// <summary>
        /// 传递工位操作值信息
        /// </summary>
        /// <returns></returns>
        public ResponseResult<string> SetAssemblyDataModel(AssemblyDataModel model)
        {
            try
            {
                bool a = _assembly.AddAssemblyDataInfo(model);
                var res = new ResponseResult<string>();
                res.Body = a ? "添加成功；" : "添加失败；";
                res.Success = a;
                return res;
            }
            catch (Exception e)
            {
                var res = new ResponseResult<string>();
                res.Body = e.Message;
                res.Success = false;
                return res;
            }
         
        }

        /// <summary>
        /// 添加条码
        /// </summary>
        /// <param name="main"></param>
        public ResponseResult<string> AddBarcode(BarcodeMain main)
        {
            _barcode.AddBarcode(main);
            var res = new ResponseResult<string>();
            res.Success = true;
            return res;
        }

        /// <summary>
        /// 查询条码
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="modelCode"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ResponseResult<List<BarcodeMain>> QueryBarcode(string type, string year, string month, string modelCode)
        {
            var list = _barcode.QueryBarcode(type, year, month, modelCode);
            var res = new ResponseResult<List<BarcodeMain>>();
            res.Body = list;
            res.Success = true;
            return res;
        }

        /// <summary>
        /// 获取条形码主表明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseResult<BarcodeMain> GetDetail(string id)
        {
            var result = _barcode.GetDetail(id);
            var res = new ResponseResult<BarcodeMain>();
            res.Body = result;
            res.Success = true;
            return res;
        }

        /// <summary>
        /// 获取最大的模组流水号
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="modelCode"></param>
        /// <returns></returns>
        public ResponseResult<int> GetModelNoMax(string type, string year, string month, string modelCode)
        {
            var result = _barcode.GetModelNoMax(type, year, month, modelCode);
            var res = new ResponseResult<int>();
            res.Body = result;
            res.Success = true;
            return res;
        }
    }
}
