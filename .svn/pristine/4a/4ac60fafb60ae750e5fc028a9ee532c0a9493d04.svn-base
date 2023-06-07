using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace RW.PMS.BLL
{
    internal class BLL_ProductInfo : IBLL_ProductInfo
    {
        private IDAL_ProductInfo _DAl = null;

        public BLL_ProductInfo()
        {
            _DAl = DIService.GetService<IDAL_ProductInfo>();
        }

        #region 生产计划 LHR

        /// <summary>
        /// 根据生产编号获取信息
        /// </summary>
        /// <param name="ProdNo"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfoProdNo(string ProdNo)
        {
            return _DAl.GetProductInfoByProdNo(ProdNo);
        }


        /// <summary>
        /// 根据ID获取(产品表)表实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseProductModel GetBaseProductById(int id)
        {
            return _DAl.GetBaseProductById(id);
        }


        /// <summary>
        /// 根据ID获取(产品型号)表实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseProductModelModel GetBaseProductModelById(int id)
        {
            return _DAl.GetBaseProductModelById(id);
        }
        #endregion

        /// <summary>
        /// 查询生产记录列表
        /// </summary>
        /// <param name="prodNo">生产编号</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <param name="finishStatus">完成状态</param>
        /// <param name="begDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductList(string prodNo = "", int? pModelID = null, int? finishStatus = null, DateTime? begDate = null, DateTime? endDate = null)
        {
            return _DAl.GetProductList(prodNo, pModelID, finishStatus, begDate, endDate);
        }


        /// <summary>
        /// 查询生产记录列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductList(ProductInfoModel model)
        {
            return _DAl.GetProductList(model);
        }

        /// <summary>
        /// 根据生产ID获取信息
        /// </summary>
        /// <param name="prodID"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfoByProdNo(string prodNo)
        {
            return _DAl.GetProductInfoByProdNo(prodNo);
        }

        /// <summary>
        /// 根据生产编号获取信息
        /// </summary>
        /// <param name="ProdNo"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfoByProdID(int prodID)
        {
            return _DAl.GetProductInfoByProdID(prodID);
        }

        /// <summary>
        /// 用于总装工位装配时操作产品信息表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveProductInfo(ProductInfoModel model,int OperatorId)
        {
            return _DAl.SaveProductInfo(model, OperatorId);
        }

        /// <summary>
        /// 用于计划列表提交验证
        /// </summary>
        /// <param name="pf_prodNo"></param>
        /// <param name="pp_orderCode"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public int GetProductInfoSaveStatus(string pf_prodNo, string pp_orderCode, out string Message)
        {
            return _DAl.GetProductInfoSaveStatus(pf_prodNo, pp_orderCode, out Message);
        }

        /// <summary>
        /// 根据计划单号 获取当前计划下的产品数量
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfo(string pp_orderCode)
        {
            return _DAl.GetProductInfo(pp_orderCode);
        }

        /// <summary>
        /// 添加生产记录信息
        /// </summary>
        /// <param name="model"></param>
        public void AddProductInfo(ProductInfoModel model)
        {
            _DAl.AddProductInfo(model);
        }

        /// <summary>
        /// 添加生产记录信息
        /// </summary>
        /// <param name="model"></param>
        public void AddProductInfo(ProductInfoModel model, MySqlTransaction myTrans, out int identity)
        {
            _DAl.AddProductInfo(model, myTrans, out identity);
        }

        /// <summary>
        /// 修改生产记录信息
        /// </summary>
        /// <param name="model"></param>
        public void UpdateProductInfo(ProductInfoModel model)
        {
            _DAl.UpdateProductInfo(model);
        }

        /// <summary>
        /// 删除生产记录信息
        /// </summary>
        /// <param name="prodID"></param>
        public void DeleteProductInfo(int prodID)
        {
            _DAl.DeleteProductInfo(prodID);
        }

        #region 产品装配完成情况 LHR

        /// <summary>
        /// 查询 产品装配完成情况 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<AssemblyProdModel> AssemblyProdForPage(AssemblyProdModel model, out int totalCount)
        {
            return _DAl.AssemblyProdForPage(model, out totalCount);
        }


        /// <summary>
        /// 获取(产品表)表实体类 下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BaseProductModel> GetBaseProduct()
        {
            return _DAl.GetBaseProduct();
        }

        /// <summary>
        /// 获取(产品型号)表实体类 下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetBaseProductModel()
        {
            return _DAl.GetBaseProductModel();
        }

        #endregion

        #region 工位装配完成情况 LHR

        public List<AssemblyGwModel> AssemblyGwForPage(AssemblyGwModel model, out int totalCount)
        {
            return _DAl.AssemblyGwForPage(model, out totalCount);
        }
        public List<AssemblyInfoModel> GetAssemblyGwList(DateTime? startDate, DateTime? endDate, string prodCode)
        {
            return _DAl.GetAssemblyGwList(startDate, endDate, prodCode);
        }
        #endregion

        #region 装配明细情况 LHR

        public List<AssemblyFllowInfoModel> AssemblyFllowInfoForPage(AssemblyFllowInfoModel model)
        {
            return _DAl.AssemblyFllowInfoForPage(model);
        }

        /// <summary>
        /// 装配明细情况查询 分页
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<AssemblyFllowInfoModel> AssemblyFllowInfoForPage(AssemblyFllowInfoModel model, out int totalCount)
        {
            return _DAl.AssemblyFllowInfoForPage(model, out totalCount);
        }

        #endregion
    }
}
