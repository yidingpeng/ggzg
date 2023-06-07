using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using System;
using System.Collections.Generic;

namespace RW.PMS.IBLL
{
    public interface IBLL_ProductInfo : IDependence
    {

        List<AssemblyFllowInfoModel> AssemblyFllowInfoForPage(AssemblyFllowInfoModel model);

        /// <summary>
        /// 装配明细情况查询 分页
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<AssemblyFllowInfoModel> AssemblyFllowInfoForPage(AssemblyFllowInfoModel model, out int totalCount);

        List<AssemblyGwModel> AssemblyGwForPage(AssemblyGwModel model, out int totalCount);

        List<AssemblyInfoModel> GetAssemblyGwList(DateTime? startDate, DateTime? endDate, string prodCode);
        List<AssemblyProdModel> AssemblyProdForPage(AssemblyProdModel model, out int totalCount);
        List<BaseProductModel> GetBaseProduct();
        BaseProductModel GetBaseProductById(int id);
        List<BaseProductModelModel> GetBaseProductModel();
        BaseProductModelModel GetBaseProductModelById(int id);

        /// <summary>
        /// 查询生产记录列表
        /// </summary>
        /// <param name="prodNo">生产编号</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <param name="finishStatus">完成状态</param>
        /// <param name="begDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        List<ProductInfoModel> GetProductList(string prodNo = "", int? pModelID = null, int? finishStatus = null, DateTime? begDate = null, DateTime? endDate = null);

        /// <summary>
        /// 查询生产记录列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ProductInfoModel> GetProductList(ProductInfoModel model);



        /// <summary>
        /// 根据生产ID获取信息
        /// </summary>
        /// <param name="prodID"></param>
        /// <returns></returns>
        ProductInfoModel GetProductInfoByProdNo(string prodNo);

        /// <summary>
        /// 根据生产编号获取信息
        /// </summary>
        /// <param name="ProdNo"></param>
        /// <returns></returns>
        ProductInfoModel GetProductInfoByProdID(int prodID);


        /// <summary>
        /// 用于总装工位装配时操作产品信息表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SaveProductInfo(ProductInfoModel model,int OperatorId);


        /// <summary>
        /// 用于计划列表提交验证
        /// </summary>
        /// <param name="pf_prodNo">产品编号</param>
        /// <param name="pp_orderCode">计划单据号</param>
        /// <param name="Message">返回消息</param>
        /// <returns>返回类型: 1:未装配  2：已装配，是否重复装配  -1：当前产品编号选择了错误的计划</returns>
        int GetProductInfoSaveStatus(string pf_prodNo, string pp_orderCode, out string Message);


        /// <summary>
        /// 根据计划单号 获取当前计划下的产品数量
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <returns></returns>
        List<ProductInfoModel> GetProductInfo(string pp_orderCode);


        /// <summary>
        /// 添加生产记录信息
        /// </summary>
        /// <param name="model"></param>
        void AddProductInfo(ProductInfoModel model);

        /// <summary>
        /// 添加生产记录信息
        /// </summary>
        /// <param name="model"></param>
        void AddProductInfo(ProductInfoModel model, MySqlTransaction myTrans, out int identity);

        /// <summary>
        /// 修改生产记录信息
        /// </summary>
        /// <param name="model"></param>
        void UpdateProductInfo(ProductInfoModel model);

        /// <summary>
        /// 删除生产记录信息
        /// </summary>
        /// <param name="prodID"></param>
        void DeleteProductInfo(int prodID);


    }
}
