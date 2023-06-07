using RW.PMS.Common;
using RW.PMS.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model.Home;

namespace RW.PMS.IDAL
{
    public interface IDAL_Data : IDependence
    {
        #region 产品合格率报表
        /// <summary>
        /// 产品合格率报表分页查询
        /// </summary>
        /// <param name="model">操作异常实体</param>
        /// <param name="totalCount">总条数</param>
        /// <returns></returns>
        List<PercentPassModels> GetPercentPassModelPage(PercentPassModels model, out int totalCount);

         /// <summary>
        /// 产品完成质量情况报表
        /// </summary>
        /// <returns></returns>
        List<ProductCompleteModel> GetPercentPass(bool IsCarModelOrCarNo, string Starttime, string Endtime);
       
        #endregion
    }
}
