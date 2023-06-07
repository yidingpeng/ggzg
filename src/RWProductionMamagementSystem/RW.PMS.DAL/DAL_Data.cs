using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model.Data;
using RW.PMS.Model.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RW.PMS.DAL
{
    internal class DAL_Data : IDAL_Data
    {

        #region 产品合格率报表
        /// <summary>
        /// 产品合格率报表分页查询（产品合格率报表用）
        /// </summary>
        /// <param name="model">操作异常实体</param>
        /// <param name="totalCount">总条数</param>
        /// <returns></returns>
        public List<PercentPassModels> GetPercentPassModelPage(PercentPassModels model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (model.prodModelID.HasValue && model.prodModelID > 0)
                {
                    para += " and pr.pf_prodModelID=@prodModelID";
                    pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
                }
                //用开始时间和结束时间
                if (model.Starttime != null)
                {
                    var starttime = DateTime.Parse(model.Starttime.ToString());  //开始时间
                    para += " and fm.fm_starttime>=@Starttime";
                    pList.Add(new MySqlParameter("@Starttime", starttime));
                }
                if (model.Endtime != null)
                {
                    var endtime = DateTime.Parse(model.Endtime.ToString()).AddDays(+1).AddSeconds(-1); //结束时间
                    para += " and fm.fm_sendTime<=@Endtime";
                    pList.Add(new MySqlParameter("@Endtime", endtime));
                }
                if (!string.IsNullOrEmpty(model.pf_compartNo))
                {
                    para += " and pr.pf_compartNo=@pf_compartNo";
                    pList.Add(new MySqlParameter("@pf_compartNo", model.pf_compartNo));
                }
                if (!string.IsNullOrEmpty(model.pf_bogieNo))
                {
                    para += " and pr.pf_bogieNo=@pf_bogieNo";
                    pList.Add(new MySqlParameter("@pf_bogieNo", model.pf_bogieNo));
                }
            }
            string sql = @"SELECT count(*)  FROM follow_main AS fm
                                   LEFT JOIN productInfo AS pr ON fm.pInfo_ID = pr.pf_ID
                                   LEFT JOIN v_productModel AS vp ON pr.pf_prodModelID = vp.ID WHERE 1 = 1 " + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);
            sql = @"SELECT
	                        pr.pf_prodModelID AS prodModelID,
	                        CONCAT(vp.Pname, '-', vp.Pmodel) AS prodModelName,
	                        pr.pf_compartNo,
	                        pr.pf_bogieNo,
	                        fm.fm_resultIsOK,
	                        fm.fm_starttime Starttime,
	                        fm.fm_finishtime fm_finishtime,
	                        fm.fm_sendTime Endtime
                            FROM follow_main AS fm
                            LEFT JOIN productInfo AS pr ON fm.pInfo_ID = pr.pf_ID
                            LEFT JOIN v_productModel AS vp ON pr.pf_prodModelID = vp.ID
                            WHERE 1 = 1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<PercentPassModels> Percentlist = db.ExecuteList<PercentPassModels>(sql, pList.ToArray());
            return Percentlist;
        }

        /// <summary>
        /// 产品完成质量情况报表
        /// </summary>
        /// <returns></returns>
        public List<ProductCompleteModel> GetPercentPass(bool IsCarModelOrCarNo, string Starttime, string Endtime)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(Starttime))
            {
                var starttime = DateTime.Parse(Starttime);                      //开始时间
                para += " and fm.fm_starttime>=@fm_starttime";
                pList.Add(new MySqlParameter("@fm_starttime", starttime));
            }
            if (!string.IsNullOrEmpty(Endtime))
            {
                var endtime = DateTime.Parse(Endtime.ToString()).AddDays(+1).AddSeconds(-1); //结束时间
                para += " and fm.fm_sendTime>=@endtime";
                pList.Add(new MySqlParameter("@endtime", endtime));
            }

            if (IsCarModelOrCarNo)
            {
                //转向架号
                string sql = @"select *,round(Okqty/ (Okqty+Errorqty)*100,2) OkRate
                                        from (select Pname as Pname,Pmodel as Pmodel,Pname+Pmodel as Prodmodel,pf.pf_bogieNo,
                                        sum(case when ifnull(fm_resultIsOK,0)=1 then 1 else 0 end) as Okqty,
                                        sum(case when ifnull(fm_resultIsOK,0)=0 then 1 else 0 end) as Errorqty
                                        FROM follow_main fm LEFT JOIN productInfo pf  on fm.pInfo_ID=pf.pf_ID
                                        LEFT JOIN v_productModel vpm  ON pf.pf_prodModelID=vpm.ID
                                        where ifnull(fm_finishStatus,0)>=1 " + para;
                sql += " group by Pname,Pmodel,Pname+Pmodel,pf_bogieNo) as prod";
                List<ProductCompleteModel> bogieNolist = db.ExecuteList<ProductCompleteModel>(sql, pList.ToArray());
                return bogieNolist;
            }
            else
            {
                //车厢号
                string sql = @"select *,round(Okqty/ (Okqty+Errorqty)*100,2) OkRate
                                        from (select Pname as Pname,Pmodel as Pmodel,Pname+Pmodel as Prodmodel,pf.pf_compartNo,
                                        sum(case when ifnull(fm_resultIsOK,0)=1 then 1 else 0 end) as Okqty,
                                        sum(case when ifnull(fm_resultIsOK,0)=0 then 1 else 0 end) as Errorqty
                                        FROM follow_main fm LEFT JOIN productInfo pf  on fm.pInfo_ID=pf.pf_ID
                                        LEFT JOIN v_productModel vpm  ON pf.pf_prodModelID=vpm.ID
                                        where ifnull(fm_finishStatus,0)>=1 " + para;
                sql += " group by Pname,Pmodel,Pname+Pmodel,pf_compartNo) as prod";
                List<ProductCompleteModel> compartNolist = db.ExecuteList<ProductCompleteModel>(sql, pList.ToArray());
                return compartNolist;
            }
        }

        #endregion
    }
}
