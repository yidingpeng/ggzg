using MySql.Data.MySqlClient;
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

namespace RW.PMS.DAL
{
    internal class DAL_BigScreen : IDAL_BigScreen
    {


        /// <summary>
        /// 生产计划 完成情况
        /// </summary>
        /// <param name="para">条件 日周月</param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfo(string Where)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            //sql = @"select *,concat(ROUND(FinishQty/TotalQty*100),'%') FinishRate from 
            //        (select CONCAT_WS(' ',pp.pp_projectName, CONCAT('T',pp.pp_wagonNo)) as pp_projectName ,pp.pp_project,pp.pp_trackNumber,pp.pp_orderCode,CONCAT_WS(' ',pm.Pmodel,pm.DrawingNo) as Pmodel,
            //        CONCAT_WS('～',DATE_FORMAT(pp.pp_startDate,'%Y-%m-%d'),DATE_FORMAT(pp.pp_finishDate,'%Y-%m-%d')) as Date,
            //        sum(case when pf.pf_finishStatus=1 then 1 else 0 end) FinishQty,
            //        sum(case when pf.pf_finishStatus=0 then 1 else 0 end) UnFinishedQty,
            //        pp.pp_planQty TotalQty
            //        from productinfo pf
            //        left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
            //        left join base_productModel pm on pf.pf_prodModelID=pm.ID 
            //        where 1=1 ";


            sql = @"select *,concat(ROUND(FinishQty / TotalQty * 100), '%') FinishRate from
                        (
                         select 
                         CONCAT_WS(' ', pp.pp_projectName, CONCAT('T', pp.pp_wagonNo)) as pp_projectName
                         , pp.pp_project, pp.pp_trackNumber, pp.pp_orderCode, CONCAT_WS(' ', pm.Pmodel, pm.DrawingNo) as Pmodel,
                         CONCAT_WS('～', DATE_FORMAT(pp.pp_startDate, '%Y-%m-%d'), DATE_FORMAT(pp.pp_finishDate, '%Y-%m-%d')) as Date,
                         sum(case when pf.pf_finishStatus = 1 then 1 else 0 end) FinishQty,
                         sum(case when pf.pf_finishStatus = 0 then 1 else 0 end) UnFinishedQty,
                         pp.pp_planQty TotalQty
                         from part_plan pp
                         left join productinfo pf on pf.pp_orderCode = pp.pp_orderCode
                         left join base_productModel pm on pp.pp_prodModelID = pm.ID
                         where 1 = 1 ";
            if (!string.IsNullOrEmpty(Where) && Where.Equals("月"))
            {
                //sql += " and DATE_FORMAT(pf.pf_finishTime, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m')";
                sql += " and DATE_FORMAT(pp.pp_startDate, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m')";
            }
            if (!string.IsNullOrEmpty(Where) && Where.Equals("日"))
            {
                //sql += " and DATE_FORMAT(pf.pf_finishTime,'%Y-%m-%d') = DATE_FORMAT(NOW(),'%Y-%m-%d')";
                sql += " and DATE_FORMAT(pp.pp_startDate,'%Y-%m-%d') = DATE_FORMAT(NOW(),'%Y-%m-%d')";
            }
            if (!string.IsNullOrEmpty(Where) && Where.Equals("周"))
            {
                var datetime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                int dayOfWeek1 = Convert.ToInt32(datetime.DayOfWeek.ToString("d"));
                DateTime startWeek = datetime.AddDays(1 - ((dayOfWeek1 == 0) ? 7 : dayOfWeek1));   //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日
                //sql += " and pf.pf_finishTime  >= @startDate and pf.pf_finishTime <= @endDate ";
                sql += " and pp.pp_startDate  >= @startDate and pp.pp_finishDate <= @endDate ";
                pList.Clear();
                pList.Add(new MySqlParameter("@startDate", startWeek));
                pList.Add(new MySqlParameter("@endDate", endWeek.AddDays(1).AddSeconds(-1)));
            }

            //sql = @"select *,concat(ROUND(FinishQty/TotalQty*100,2),'%') FinishRate from 
            //        (select CONCAT_WS(' ',pp.pp_projectName, CONCAT('T',pp.pp_wagonNo)) as pp_projectName ,pp.pp_project,pp.pp_trackNumber,pp.pp_orderCode,CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as Pmodel,
            //        CONCAT_WS('～',DATE_FORMAT(pp.pp_startDate,'%Y-%m-%d'),DATE_FORMAT(pp.pp_finishDate,'%Y-%m-%d')) as Date,
            //        sum(case when pf.pf_finishStatus=1 then 1 else 0 end) FinishQty,
            //        sum(case when pf.pf_finishStatus=0 then 1 else 0 end) UnFinishedQty,
            //        pp.pp_planQty TotalQty
            //        from productinfo pf
            //        left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
            //        left join base_productModel pm on pf.pf_prodModelID=pm.ID 
            //        where 1=1 " + para;
            sql += " group by pp.pp_orderCode order  by pp.pp_finishDate desc ) prod order by FinishRate desc ";

            return db.ExecuteList<ProductInfoModel>(sql, new List<MySqlParameter>().ToArray());
        }

        /// <summary>
        /// 生产计划 质量情况
        /// </summary>
        /// <param name="para">条件 日周月</param>
        /// <param name="IsOrderCodeorProdModel">是否按照 计划（true）或者 产品型号（false）查询质量情况</param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfoQuality(string para, bool IsOrderCodeorProdModel)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "";

            if (IsOrderCodeorProdModel)
            {
                //计划
                sql = @"select *,concat(ROUND(Okqty/TotalQty*100)) OkRate from 
                    (select CONCAT_WS(' ',pp.pp_projectName, CONCAT('T',pp.pp_wagonNo)) as pp_projectName ,pp.pp_project,pp.pp_trackNumber,pp.pp_orderCode,CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as Pmodel,
                    CONCAT_WS('～',DATE_FORMAT(pp.pp_startDate,'%Y-%m-%d'),DATE_FORMAT(pp.pp_finishDate,'%Y-%m-%d')) as Date,
                    sum(case when pf.pf_resultIsOK=1 then 1 else 0 end) Okqty,
                    sum(case when pf.pf_resultIsOK=0 then 1 else 0 end) Errorqty,
                    pp.pp_planQty TotalQty
                    from productinfo pf
                    left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                    left join base_productModel pm on pf.pf_prodModelID=pm.ID 
                    where 1=1 " + para;
                sql += " group by pp.pp_orderCode ) prod ";
            }
            else
            {
                //产品型号
                sql = @"select *,concat(ROUND(Okqty/TotalQty*100)) OkRate from 
                    (select pp.pp_project,pp.pp_trackNumber,pp.pp_orderCode,CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as Pmodel,
                    CONCAT_WS('～',DATE_FORMAT(pp.pp_startDate,'%Y-%m-%d'),DATE_FORMAT(pp.pp_finishDate,'%Y-%m-%d')) as Date,
                    sum(case when pf.pf_resultIsOK=1 then 1 else 0 end) Okqty,
                    sum(case when pf.pf_resultIsOK=0 then 1 else 0 end) Errorqty,
                    sum(case when pf.pf_resultIsOK=1 then 1 else 0 end)+sum(case when pf.pf_resultIsOK=0 then 1 else 0 end) TotalQty
                    from productinfo pf
                    left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                    left join base_productModel pm on pf.pf_prodModelID=pm.ID 
                    where 1=1 " + para;
                sql += " group by pp.pp_prodModelID ) prod ";
            }
            return db.ExecuteList<ProductInfoModel>(sql, new List<MySqlParameter>().ToArray());
        }

        /// <summary>
        /// 获取生产记录信息
        /// </summary>
        /// <param name="isFinishGW">是否为总装工位</param>
        /// <param name="begDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public List<AssemblyMainModel> GetAssemblyMainList(bool isFinishGW, DateTime? begDate = null, DateTime? endDate = null)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sqlStr = @"SELECT 
                    am_guid,
                    pf_prodNo,
                    v.pName,
                    v.PModel,
                    pModelID,
                    pInfo_ID,
                    am_gwID,
                    gwName as am_gwName,
                    am_QRcode,
                    am_pInfoDate,
                    am_createDate,
                    am_createUser
                    FROM
	                assembly_main main
	                LEFT JOIN productInfo p ON p.pf_ID = main.pInfo_ID
	                LEFT JOIN v_productmodel v ON main.pModelID = v.ID 
	                LEFT JOIN base_gongwei gw on gw.ID=main.am_gwID
                WHERE
	                isFinishGW=@isFinishGW ";

            pList.Add(new MySqlParameter("@isFinishGW", isFinishGW));
            if (begDate.HasValue)//开始时间
            {
                pList.Add(new MySqlParameter("@begDate", begDate));
                sqlStr += " AND am_createDate>=@begDate";
            }
            if (endDate.HasValue)//完成时间
            {
                var endtime = endDate.Value.AddDays(+1).AddSeconds(-1);
                //var endtime = DateTime.Parse(model.endtime);
                sqlStr += " AND am_createDate <= @endDate";
                pList.Add(new MySqlParameter("@endDate", endDate));
            }

            var list = db.ExecuteList<AssemblyMainModel>(sqlStr, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取生产当天异常信息
        /// </summary>
        /// <param name="begDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public List<AssemblyErrorInfoModel> GetAssemblyErrorList(DateTime? begDate = null, DateTime? endDate = null)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();

            var sqlStr = " SELECT agx_guid,err_oper,err_gwID, err_gw,errDate,errorDesp FROM assembly_errorinfo WHERE 1=1 ";
            if (begDate.HasValue)//开始时间
            {
                pList.Add(new MySqlParameter("@begDate", begDate));
                sqlStr += " and errDate>=@begDate";
            }
            if (endDate.HasValue)//完成时间
            {
                var endtime = endDate.Value.AddDays(+1).AddSeconds(-1);
                //var endtime = DateTime.Parse(model.endtime);
                sqlStr += " and errDate <= @endDate";
                pList.Add(new MySqlParameter("@endDate", endDate));
            }
            var list = db.ExecuteList<AssemblyErrorInfoModel>(sqlStr, pList.ToArray());
            return list;
        }
    }
}
