using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.InComming;
using RW.PMS.Model.Plan;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RW.PMS.DAL
{
    /// <summary>
    /// 来料
    /// </summary>
    internal class DAL_InComming : IDAL_InComming
    {

        #region 入场存放区 存放记录表 Add By Leon 20190918

        /// <summary>
        /// 获取存放情况（型号-数量）
        /// Add By Leon 20190918
        /// </summary>
        /// <returns></returns>
        public List<PutInfo> GetPutInfo()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            sql = @"select pp.pp_prodModelID prodModelID,count(1) Qty from base_temparea bt
                    left join plan_prod pp on pp.pp_guid=bt.ta_planGuid
                    where pp.pp_prodModelID is not null and bt.ta_areaID=190 group by pp.pp_prodModelID";
            return db.ExecuteList<PutInfo>(sql, pList.ToArray());
        }


        #endregion
    }
}
