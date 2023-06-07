using RW.PMS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model.Home;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using MySql.Data.MySqlClient;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;

namespace RW.PMS.DAL
{
    internal class DAL_HomePage : IDAL_HomePage
    {
        /// <summary>
        /// 获取设备数量
        /// </summary>
        /// <returns></returns>
        public int GetDeviceCount()
        {
            //using (var context = new RWPMS_DBDataContext())
            //{
            //    if (context.DBType == Common.EDAEnums.DataBaseType.MySql)
            //        return new RW.PMS.Common.MySqlHelper().GetCount("base_Device");
            //    return context.base_Device.Where(x => true).Count();
            //}
            return new RW.PMS.Common.MySqlHelper().GetCount("base_gongwei", "1=1");
        }

        /// <summary>
        /// 获取用户数量
        /// </summary>
        /// <returns></returns>
        public int GetUsersCount()
        {
            //using (var context = new RWPMS_DBDataContext())
            //{
            //    if (context.DBType == Common.EDAEnums.DataBaseType.MySql)
            //        return new RW.PMS.Common.MySqlHelper().GetCount("sys_User");
            //    return context.sys_User.Where(x => true && x.deleted == 0).Count();
            //}

            return new RW.PMS.Common.MySqlHelper().GetCount("sys_user", "inStatus = 1 and deleted = 0");
        }

        /// <summary>
        /// 获取完成数 
        /// 查询productInfo 2020-06-09
        /// </summary>
        /// <returns></returns>
        public int GetCompleteCount()
        {
            return new RW.PMS.Common.MySqlHelper().GetCount("productInfo", "DATE_FORMAT(pf_finishTime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and pf_finishStatus = 1");
        }

        /// <summary>
        /// 获取合格数 
        /// 查询productInfo 2020-06-09
        /// </summary>
        /// <returns></returns>
        public int GetQualifiedCount()
        {
            return new RW.PMS.Common.MySqlHelper().GetCount("productInfo", "DATE_FORMAT(pf_finishTime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and pf_finishStatus = 1");
        }



        /// <summary>
        /// 获取异常情况
        /// </summary>
        /// <returns></returns>
        public List<ProductCompleteModel> GetAnomalyMessage()
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"select errType.bdname AnomalyType,count(err.ErrorTypeID) AnomalyCount from 
                                (select * from assembly_errorInfo where DATE_FORMAT(errDate,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and ErrorTypeID<>21 and ErrorTypeID<>0) err 
                                left join sys_baseData errType on err.ErrorTypeID=errType.ID
                                group by err.ErrorTypeID";
            //group by err.err_oper" ,err.err_oper;
            return db.ExecuteList<ProductCompleteModel>(sql, pList.ToArray());
        }


        /// <summary>
        /// 获取 异常反馈处理 Follow_Feedback 2020-11-28 用于大屏显示
        /// </summary>
        /// <param name="TimeStr">参数（日【%Y-%m-%d】周【%Y-%u】月【%Y-%m】</param>
        /// <returns></returns>
        public List<FollowAbnormalModel> GetFollowAbnormal(string TimeStr)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @" select * from follow_abnormal where DATE_FORMAT(fa_createtime, '" + TimeStr + "') = DATE_FORMAT(NOW(), '" + TimeStr + "') order by fa_isok ";
            return db.ExecuteList<FollowAbnormalModel>(sql, pList.ToArray());
        }


        /// <summary>
        /// 获取异常情况明细
        /// </summary>
        /// <returns></returns>
        public List<ErrorModel> GetAnomalyDetail(out int totalCount, int PageSize, int PageIndex)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = " where DATE_FORMAT(errDate,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and ErrorTypeID<>21 and ErrorTypeID<>0 ";
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"select count(*) from assembly_errorInfo" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);
            sql = @"select pf.pf_prodNo ProdNo,p.Pname ProdName,pm.Pmodel ProdModel,errType.bdname ErrorName,err.err_gw ErrGw,err.err_oper ErrOpen,err.errDate ErrorDate,err.errorDesp ErrorDesp,CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as PmodelDrawingNo
                                from assembly_errorInfo err 
                                left join assembly_gw agw on agw.agw_guid=err.agw_guid 
                                left join productInfo pf on pf.pf_prodNo=agw.agw_QRcode 
                                left join base_productModel pm on pf.pf_prodModelID=pm.ID 
                                left join base_product p on pm.PID=p.ID 
                                left join sys_baseData errType on err.ErrorTypeID=errType.ID " + para;
            sql += " order by ErrorDate desc limit " + PageIndex + "," + PageSize;
            return db.ExecuteList<ErrorModel>(sql, pList.ToArray());
        }
        /// <summary>
        /// 获取人员异常情况信息
        /// </summary>
        /// <returns></returns>
        public List<ErrorModel> GetPeopleAnomaly()
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"select err.err_oper ErrOpen,count(err.err_oper) ErrCount from 
                                (select * from assembly_errorInfo where DATE_FORMAT(errDate,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and ErrorTypeID<>21 and ErrorTypeID<>0 ) err 
                                group by err.err_oper";
            return db.ExecuteList<ErrorModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 获取人员工时 2020-06-02 改为获取assembly_gw装配工位相同员工时工求和
        /// </summary>
        /// <param name="totalCount"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public List<PeopleHourModel> GetPeopleHourData(out int totalCount, int PageSize, int PageIndex)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            //string para = " where DATE_FORMAT(fgw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and fgw_followStatus=1 ";
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @" select Count(1) from (select * from assembly_gw gw
                            where DATE_FORMAT(agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and agw_finishStatus=1 
                            group by agw_operID) gw";
            //string sql = @"select count(*) from follow_gw " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);
            sql = @"select 
                    u.empName EmpName,r.roleName RoleName, 
                    DATE_FORMAT(date('1970-12-31 23:59:59') + interval sum(TIMESTAMPDIFF(SECOND,gw.agw_starttime,gw.agw_finishtime)) second,'%H小时%i分钟%s秒') as WorkingHours
                    ,gw1.Gw_starttime,gw1.Gw_finishtime
                    from assembly_gw gw
                    left join (
                    select gwmaxmin.agw_operID,min(gwmaxmin.agw_starttime) Gw_starttime,max(gwmaxmin.agw_finishtime) Gw_finishtime from assembly_gw gwmaxmin
                    where DATE_FORMAT(agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and agw_finishStatus=1
                    GROUP BY  gwmaxmin.agw_operID
                    ) gw1 on gw.agw_operID =gw1.agw_operID
                    left join sys_user u on gw.agw_operID=u.userID
                    left join sys_role r on r.roleID=u.roleID
                    where DATE_FORMAT(gw.agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and gw.agw_finishStatus=1 
                    group by gw.agw_operID ";

            //sql = @"select u.empName EmpName,r.roleName RoleName,u.phone Phone,min(gw.fgw_starttime) Gw_starttime,max(gw.fgw_finishtime) Gw_finishtime
            //        ,TIMESTAMPDIFF(HOUR,min(gw.fgw_starttime),max(gw.fgw_finishtime)) EmpHour
            //                    from (select * from follow_gw " + para + @") gw
            //                    left join sys_user u on gw.fgw_operID=u.userID
            //                    left join sys_role r on r.roleID=u.roleID
            //                    group by u.empName,r.roleName,u.phone ";
            sql += " order by Gw_finishtime desc  limit " + PageIndex + "," + PageSize;
            return db.ExecuteList<PeopleHourModel>(sql, pList.ToArray());
        }

        //TODO 员工工时计算思路 2020-06-02
        #region 员工工时计算思路 2020-06-02

        //      -----------------------------------------------------------------员工工时计算----------------------------------------------------------------------------
        //      -- 大意：算出当月员工在每个装配工位所用的时间
        //      select*,TIMEDIFF(agw_finishtime, agw_starttime)  from assembly_gw
        //      where DATE_FORMAT(agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and agw_finishStatus = 1;

        //      ---------------------------------------------------------------------------------------------------------------------------------------------------------
        //      -- 大意：算出当月员工在每个装配工位所用的秒数
        //      select*,TIMESTAMPDIFF(SECOND, agw_starttime, agw_finishtime)  from assembly_gw
        //      where DATE_FORMAT(agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and agw_finishStatus = 1;

        //      ---------------------------------------------------------------------------------------------------------------------------------------------------------
        //      -- 大意：按照分组并统计 相同员工在装配工位所用的总秒数
        //      select*,sum(TIMESTAMPDIFF(SECOND, agw_starttime, agw_finishtime)) from assembly_gw
        //      where DATE_FORMAT(agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and agw_finishStatus = 1
        //      group by agw_operID;

        //      ---------------------------------------------------------------------------------------------------------------------------------------------------------
        //      -- 大意：利用 DATE_FORMAT(date('1970-12-31 23:59:59') + interval 1 second,'%Hh:%im:%ss') 函数将秒转换成小时分秒
        //      SELECT DATE_FORMAT(date('1970-12-31 23:59:59') + interval 190 second,'%Hh:%im:%ss') as result;
        //      select DATE_FORMAT(date('1970-12-31 23:59:59') + interval 1 second,'%Hh:%im:%ss')

        //      ---------------------------------------------------------------------------------------------------------------------------------------------------------
        //      -- 大意： 按照分组并统计 相同员工在装配工位所用的总秒数并（利用函数将总秒数 转换成 具体小时分秒）
        //      select u.empName EmpName, r.roleName RoleName, DATE_FORMAT(date('1970-12-31 23:59:59') + interval sum(TIMESTAMPDIFF(SECOND, agw_starttime, agw_finishtime)) second,'%H小时%i分钟%s秒') as EmpHour
        //         from assembly_gw gw
        //      left join sys_user u on gw.agw_operID=u.userID
        //      left join sys_role r on r.roleID= u.roleID
        //      where DATE_FORMAT(agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and agw_finishStatus = 1
        //      group by agw_operID;

        //      ---------------------------------------------------------------------------------------------------------------------------------------------------------
        //      -- 大意： 
        //      -- 按照分组并统计 相同员工在装配工位所用的总秒数并（利用函数将总秒数 转换成 具体小时分秒）
        //      -- 外联获取相同员工在装配工位的（本月最早开始时间，本月最晚结束时间） 
        //      -- 并将结果按照每5页进行分页显示
        //      select
        //      u.empName EmpName, r.roleName RoleName,
        //       DATE_FORMAT(date('1970-12-31 23:59:59') + interval sum(TIMESTAMPDIFF(SECOND, gw.agw_starttime, gw.agw_finishtime)) second, '%H小时%i分钟%s秒') as EmpHour
        //      ,gw1.Gw_starttime,gw1.Gw_finishtime
        //      from assembly_gw gw
        //      left join(
        //      select gwmaxmin.agw_operID, min(gwmaxmin.agw_starttime) Gw_starttime,max(gwmaxmin.agw_finishtime) Gw_finishtime from assembly_gw gwmaxmin
        //      where DATE_FORMAT(agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and agw_finishStatus = 1
        //      GROUP BY  gwmaxmin.agw_operID
        //      ) gw1 on gw.agw_operID =gw1.agw_operID
        //      left join sys_user u on gw.agw_operID=u.userID
        //      left join sys_role r on r.roleID=u.roleID
        //      where DATE_FORMAT(gw.agw_finishtime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and gw.agw_finishStatus=1 
        //      group by gw.agw_operID
        //      limit 0,5;

        #endregion



        /// <summary>
        /// 获取首页轮播图片描述数据
        /// </summary>
        /// <returns></returns>
        public List<BaseImgCarousel> GetImgCarousel()
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select * from base_ImgCarousel where 1=1 and deleteFlag = 0 order by sort asc";
            return db.ExecuteList<BaseImgCarousel>(sql, pList.ToArray());
        }


    }
}
