using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Common;
using RW.PMS.Model.InComming;
using MySql.Data.MySqlClient;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;

namespace RW.PMS.MYSQL.DAL
{
    public class DAL_InComming
    {
        RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();


        #region 入库信息

        /// <summary>
        /// 获取区域的追溯信息
        /// </summary>
        /// <param name="models"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<InCommingModel> GetInComming(InCommingModel models, out int totalCount)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();

            string sql = @"select Count(*) from follow_main main
                           left join productinfo pf on main.pInfo_ID = pf.pf_ID
                           left join follow_production fp on main.fp_guid = fp.fp_guid
                           left join v_productmodel vpm on pf.pf_prodModelID = vpm.ID
                           left join sys_user users on main.fm_sender = users.userID
                           where main.fm_finishStatus <1";
            totalCount = (int)db.ExecuteScalar(sql, List.ToArray());

            sql = @"select * from follow_main main
                    left join productinfo pf on main.pInfo_ID = pf.pf_ID
                    left join follow_production fp on main.fp_guid = fp.fp_guid
                    left join v_productmodel vpm on pf.pf_prodModelID = vpm.ID
                    left join sys_user users on main.fm_sender = users.userID
                    where main.fm_finishStatus <1";

            List.Clear();
            if (!string.IsNullOrEmpty(models.pf_prodNo))
            {
                sql += "and pf_prodNo like '%@pf_prodNo%' ";
                List.Add(new MySqlParameter("@pf_prodNo", models.pf_prodNo));
            }
            if (models.pf_prodModelID != 0)
            {
                sql += "and pf_prodModelID = @pf_prodModelID ";
                List.Add(new MySqlParameter("@pf_prodModelID", models.pf_prodModelID));
            }
            if (!string.IsNullOrEmpty(models.pf_carNo))
            {
                sql += "and pf_carNo like '%@pf_carNo%' ";
                List.Add(new MySqlParameter("@pf_carNo", models.pf_carNo));
            }
            if (models.fm_finishStatus != 0)
            {
                sql += "and fm_finishStatus = @fm_finishStatus ";
                List.Add(new MySqlParameter("@fm_finishStatus", models.fm_finishStatus));
            }

            sql += "limit " + models.PageSize * (models.PageIndex - 1) + "," + models.PageSize;
            List<InCommingModel> list = db.ExecuteList<InCommingModel>(sql, List.ToArray());
            return list;
        }


        /// <summary>
        /// 根据产品型号ID获取悬挂的关键部件List
        /// </summary>
        /// <param name="pModelID">产品型号ID</param>
        /// <returns>悬挂的关键部件List</returns>
        public List<WuliaoModel> GetPatsByProductModelID(int pModelID)
        {
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = @"select DISTINCT wl.ID,wl.wlname,pj.prodModelId  
                            from base_productlingjian as pj
                            left join base_wuliao wl on pj.wuliaoLJid = wl.ID
                            where pj.isComingHang =1";
            if (pModelID != 0)
            {
                sql += " and prodModelId = @prodModelId ";
                List.Add(new MySqlParameter("@prodModelId", pModelID));
            }

            List<WuliaoModel> list = db.ExecuteList<WuliaoModel>(sql, List.ToArray());
            return list;

        }


        //public int AddFollow(BaseProductModel piModel, FollowProductionModel fpModel, FollowMainModel fmModel, FollowGwModel fgModel, FollowDetailModel fdModel, Guid? pp_guid)
        //{

        //}


        //public ProductInfoModel GetproductInfoByProdNo(string pf_prodNo)
        //{
        //    List<MySqlParameter> List = new List<MySqlParameter>();
        //    string sql = @"";
        //}

        #endregion

    }
}
