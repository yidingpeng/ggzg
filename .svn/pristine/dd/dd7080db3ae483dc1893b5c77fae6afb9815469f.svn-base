using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.BigScreen;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Home;
using RW.PMS.Model.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.BLL
{
    internal class BLL_BigScreen : IBLL_BigScreen
    {

        private IDAL_BigScreen _DAL = null;

        public BLL_BigScreen()
        {
            _DAL = DIService.GetService<IDAL_BigScreen>();
        }


        /// <summary>
        /// 生产计划完成情况
        /// </summary>
        /// <param name="para">条件 日周月</param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfo(string para) { return _DAL.GetProductInfo(para); }

        /// <summary>
        /// 生产计划 质量情况
        /// </summary>
        /// <param name="para">条件 日周月</param>
        /// <param name="IsOrderCodeorProdModel">是否按照 计划（true）或者 产品型号（false）查询质量情况</param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfoQuality(string para, bool IsOrderCodeorProdModel) { return _DAL.GetProductInfoQuality(para, IsOrderCodeorProdModel); }
        /// <summary>
        /// 获取生产记录信息
        /// </summary>
        /// <param name="isFinishGW">是否为总装工位</param>
        /// <param name="begDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public List<AssemblyMainModel> GetAssemblyMainList(bool isFinishGW, DateTime? begDate = null, DateTime? endDate = null)
        {
            return _DAL.GetAssemblyMainList(isFinishGW, begDate, endDate);
        }

        /// <summary>
        /// 获取生产当天异常信息
        /// </summary>
        /// <param name="begDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public List<AssemblyErrorInfoModel> GetAssemblyErrorList(DateTime? begDate = null, DateTime? endDate = null)
        {
            return _DAL.GetAssemblyErrorList(begDate, endDate);
        }
    }
}
