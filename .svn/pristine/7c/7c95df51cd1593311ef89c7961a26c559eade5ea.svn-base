using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Common;
using RW.PMS.Model.Data;
using RW.PMS.Model.Home;

namespace RW.PMS.BLL
{
    internal class BLL_Data : IBLL_Data
    {
        private IDAL_Data _DAL = null;

        public BLL_Data()
        {
            _DAL = DIService.GetService<IDAL_Data>();
        }

        #region 产品合格率报表
        /// <summary>
        /// 产品合格率报表分页查询
        /// </summary>
        /// <param name="model">操作异常实体</param>
        /// <param name="totalCount">总条数</param>
        /// <returns></returns>
        public List<PercentPassModels> GetPercentPassModelPage(PercentPassModels model, out int totalCount)
        {
            return _DAL.GetPercentPassModelPage(model,out totalCount);
        }

            /// <summary>
        /// 产品完成质量情况报表
        /// </summary>
        /// <returns></returns>
        public List<ProductCompleteModel> GetPercentPass(bool IsCarModelOrCarNo, string Starttime, string Endtime)
        {
            return _DAL.GetPercentPass(IsCarModelOrCarNo, Starttime, Endtime);
        }
        #endregion

    }
}
