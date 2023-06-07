using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Plan;
using RW.PMS.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace RW.PMS.DAL
{
    internal class DAL_Plan : IDAL_Plan
    {
        #region 出勤模式表

        /// <summary>
        /// 出勤模式分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseWorkModeModel> GetPagingWorkMode(BaseWorkModeModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.wmName))
            {
                para += " and wmName like CONCAT('%',@wmName,'%') ";
                pList.Add(new MySqlParameter("@wmName", model.wmName));
            }

            string sql = "select count(*) from base_workmode where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = "select * from base_workmode where 1=1 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseWorkModeModel> list = db.ExecuteList<BaseWorkModeModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">出勤模式表Id</param>
        /// <returns></returns>
        public BaseWorkModeModel GetWorkModetId(int Id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,wmName,wmCode,wmColor from base_workmode where ID = @ID";
            pList.Add(new MySqlParameter("@ID", Id));
            List<BaseWorkModeModel> list = db.ExecuteList<BaseWorkModeModel>(sql, pList.ToArray());
            if (list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 根据出勤模式名称查询是否有相同名称
        /// </summary>
        /// <param name="wmName"></param>
        /// <returns></returns>
        public bool GetWorkModetWmName(string wmName)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select count(*) from base_workmode where wmName = @wmName";
            pList.Add(new MySqlParameter("@wmName", wmName));
            int list = int.Parse(db.ExecuteScalar(sql, pList.ToArray()).ToString());
            if (list > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">出勤模式表</param>
        public void AddWorkMode(BaseWorkModeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into base_workmode(wmName,wmCode,wmColor) values(@wmName,@wmCode,@wmColor)";
            pList.Add(new MySqlParameter("@wmName", model.wmName));
            pList.Add(new MySqlParameter("@wmCode", model.wmCode));
            pList.Add(new MySqlParameter("@wmColor", model.wmColor.ToUpper()));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditWorkMode(BaseWorkModeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update base_workmode set wmName=@wmName,wmCode=@wmCode,wmColor=@wmColor where ID = @ID";
            pList.Add(new MySqlParameter("@wmName", model.wmName));
            pList.Add(new MySqlParameter("@wmCode", model.wmCode));
            pList.Add(new MySqlParameter("@wmColor", model.wmColor.ToUpper()));
            pList.Add(new MySqlParameter("@ID", model.ID));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteWorkMode(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from base_workmode where ID in(" + id + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 生产日历

        /// <summary>
        /// 生产日历分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductionCalendarModel> GetPagingProductionCalendar(BaseProductionCalendarModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.pcWorkModeID != 0)
            {
                para += " and pcWorkModeID = @pcWorkModeID ";
                pList.Add(new MySqlParameter("@pcWorkModeID", model.pcWorkModeID));
            }

            string sql = "select count(*) from base_productioncalendar where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            sql = @"select  pc.ID,pcAllFlag ,pcDeviceID ,dv.devName as pcDeviceName,pcPersonID ,ey.empName as pcPersonName,pcWorkPositionID ,gw.gwname as pcWorkPositionName,
                            pcResourceID , pcCode , case when pcDate='0000-00-00 00:00:00' then ('1999-01-01') else(pcDate) end as pcDate,pcWorkModeID , wm.wmName as pcWorkModeName,pcRemark 
                            from base_productioncalendar pc
                            left join base_workmode wm on pc.pcWorkModeID = wm.ID
                            left join base_device dv on pc.pcDeviceID = dv.id
                            left join sys_user ey on pc.pcPersonID = ey.userID
                            left join base_gongwei gw on pc.pcWorkPositionID = gw.ID
                            where 1=1 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseProductionCalendarModel> list = db.ExecuteList<BaseProductionCalendarModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">出勤模式表</param>
        public void AddProductionCalendar(BaseProductionCalendarModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into base_productioncalendar(pcAllFlag,pcDeviceID,pcPersonID,pcWorkPositionID,pcResourceID,pcCode,pcDate,pcWorkModeID,pcRemark) 
                                    values(@pcAllFlag,@pcDeviceID,@pcPersonID,@pcWorkPositionID,@pcResourceID,@pcCode,@pcDate,@pcWorkModeID,@pcRemark)";
            pList.Add(new MySqlParameter("@pcAllFlag", model.pcAllFlag));
            pList.Add(new MySqlParameter("@pcDeviceID", model.pcDeviceID));
            pList.Add(new MySqlParameter("@pcPersonID", model.pcPersonID));
            pList.Add(new MySqlParameter("@pcWorkPositionID", model.pcWorkPositionID));
            pList.Add(new MySqlParameter("@pcResourceID", model.pcResourceID));
            pList.Add(new MySqlParameter("@pcCode", model.pcCode));
            pList.Add(new MySqlParameter("@pcDate", model.pcDate));
            pList.Add(new MySqlParameter("@pcWorkModeID", model.pcWorkModeID));
            pList.Add(new MySqlParameter("@pcRemark", model.pcRemark));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditProductionCalendar(BaseProductionCalendarModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update base_productioncalendar set pcAllFlag=@pcAllFlag,pcDeviceID=@pcDeviceID,pcPersonID=@pcPersonID,pcWorkPositionID=@pcWorkPositionID,pcResourceID=@pcResourceID
                                    ,pcCode=@pcCode,pcDate=@pcDate,pcWorkModeID=@pcWorkModeID,pcRemark=@pcRemark where ID = @ID";
            pList.Add(new MySqlParameter("@pcAllFlag", model.pcAllFlag));
            pList.Add(new MySqlParameter("@pcDeviceID", model.pcDeviceID));
            pList.Add(new MySqlParameter("@pcPersonID", model.pcPersonID));
            pList.Add(new MySqlParameter("@pcWorkPositionID", model.pcWorkPositionID));
            pList.Add(new MySqlParameter("@pcResourceID", model.pcResourceID));
            pList.Add(new MySqlParameter("@pcCode", model.pcCode));
            pList.Add(new MySqlParameter("@pcDate", model.pcDate));
            pList.Add(new MySqlParameter("@pcWorkModeID", model.pcWorkModeID));
            pList.Add(new MySqlParameter("@pcRemark", model.pcRemark));
            pList.Add(new MySqlParameter("@ID", model.ID));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProductionCalendar(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from base_productioncalendar where ID in(" + id + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 查询所有出勤模式数据
        /// </summary>
        /// <returns></returns>
        public List<BaseWorkModeModel> GetWorkModeAll()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select ID,wmName from base_workmode";
            List<BaseWorkModeModel> list = db.ExecuteList<BaseWorkModeModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 根据传入进来的表名进行下拉绑定
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        public List<TableBindModel> GetTableBind(string tablename)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            if (tablename == "sys_user") { sql = "select UserID as ID,empName as Name from sys_user"; }
            else if (tablename == "base_gongwei") { sql = "select ID as ID,gwname as Name from base_gongwei"; }
            else if (tablename == "base_device") { sql = "select ID as ID,devName as Name from base_device"; }
            List<TableBindModel> list = db.ExecuteList<TableBindModel>(sql, pList.ToArray());
            return list;
        }

        #endregion

        #region 计划管理

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PlanProdModel> GetPlanProdList(PlanProdModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.LIKEPlanCode))
            {
                para += " and pp.pp_planCode like CONCAT('%',@LIKEPlanCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEPlanCode", model.LIKEPlanCode));
            }
            if (!string.IsNullOrEmpty(model.LIKECarNo))
            {
                para += " and sub.carNo_sys like CONCAT('%',@LIKECarNo,'%') ";
                pList.Add(new MySqlParameter("@LIKECarNo", model.LIKECarNo));
            }
            if (model.pp_prodModelID.HasValue && model.pp_prodModelID.Value != 0)
            {
                para += " and pp.pp_prodModelID=@pp_prodModelID ";
                pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
            }
            if (model.pp_startDate.HasValue)
            {
                para += " and pp.pp_startDate>=@pp_startDate ";
                pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
            }
            if (model.pp_finishDate.HasValue)
            {
                para += " and pp.pp_finishDate<@pp_finishDate ";
                pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate.Value.AddDays(1)));
            }
            //pp_prodModelID

            string sql = @"select count(1) from plan_prod pp 
left join subwayinfo sub on pp.pp_subwayInfoID=sub.ID 
left join base_productmodel pm on pp.pp_prodModelID=pm.ID where pp.pp_deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select pp.*,sub.carNo,sub.carNo_sys,pm.Pmodel from plan_prod pp 
left join subwayinfo sub on pp.pp_subwayInfoID=sub.ID 
left join base_productmodel pm on pp.pp_prodModelID=pm.ID where pp.pp_deleteFlag=0 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<PlanProdModel> list = db.ExecuteList<PlanProdModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 查询计划主表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PlanProdModel> GetPlanProdList(PlanProdModel model = null)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.LIKEPlanCode))
            {
                para += " and pp.pp_planCode like CONCAT('%',@pp_planCode,'%') ";
                pList.Add(new MySqlParameter("@pp_planCode", model.LIKEPlanCode));
            }
            if (!string.IsNullOrEmpty(model.LIKECarNo))
            {
                para += " and sub.carNo_sys like CONCAT('%',@carNo_sys,'%') ";
                pList.Add(new MySqlParameter("@carNo_sys", model.LIKECarNo));
            }
            if (model.pp_prodModelID.HasValue && model.pp_prodModelID.Value != 0)
            {
                para += " and pp.pp_prodModelID=@pp_prodModelID ";
                pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
            }
            if (model.pp_startDate.HasValue)
            {
                para += " and pp.pp_startDate>=@pp_startDate ";
                pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
            }
            if (model.pp_finishDate.HasValue)
            {
                para += " and pp.pp_finishDate<@pp_finishDate ";
                pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate.Value.AddDays(1)));
            }
            if (model.pp_status.HasValue)
            {
                para += " and pp.pp_status=@pp_status ";
                pList.Add(new MySqlParameter("@pp_status", model.pp_status));
            }
            if (model.UNStatus.HasValue)
            {
                para += " and pp.pp_status<>@UNStatus ";
                pList.Add(new MySqlParameter("@UNStatus", model.UNStatus));
            }
            if (model.pp_guid != Guid.Empty)
            {
                para += " and pp.pp_guid=@pp_guid ";
                pList.Add(new MySqlParameter("@pp_guid", model.pp_guid));
            }
            if (!string.IsNullOrEmpty(model.LIKEPlanCode))
            {
                para += " and pp.pp_planCode like CONCAT('%',@LIKEPlanCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEPlanCode", model.LIKEPlanCode));
            }
            if (!string.IsNullOrEmpty(model.LIKECarNo))
            {
                para += " and sub.carNo_sys like CONCAT('%',@LIKECarNo,'%') ";
                pList.Add(new MySqlParameter("@LIKECarNo", model.LIKECarNo));
            }

            string sql = @"select pp.*,sub.carNo,sub.carNo_sys,pm.Pmodel,pm.PID pf_prodID from plan_prod pp 
                            left join subwayinfo sub on pp.pp_subwayInfoID=sub.ID 
                            left join base_productmodel pm on pp.pp_prodModelID=pm.ID 
                            where pp.pp_deleteFlag=0 " + para + " order by pp_updateTime desc ";
            List<PlanProdModel> list = db.ExecuteList<PlanProdModel>(sql, pList.ToArray());
            //计划明细
            foreach (var item in list)
            {
                sql = @"select *,GetbdNameBybdID(ta.ta_areaID) ta_areaName from plan_detail pd
                        left join base_temparea ta on ta.ta_ID=pd.pdTAID
                        where pd.ppGuid=@ppGuid";
                pList.Clear();
                pList.Add(new MySqlParameter("@ppGuid", item.pp_guid));
                item.DetailList = db.ExecuteList<PlanDetailModel>(sql, pList.ToArray());
            }
            return list;
        }

        /// <summary>
        /// 获取计划明细表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PlanDetailModel> GetPlanDetailList(PlanDetailModel model = null)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model.ppGuid.HasValue)
            {
                para += " and ppGuid=@ppGuid ";
                pList.Add(new MySqlParameter("@ppGuid", model.ppGuid));
            }

            string sql = @"select * from plan_detail where 1=1 " + para;
            List<PlanDetailModel> list = db.ExecuteList<PlanDetailModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePlan(PlanProdModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    //是否需要新增车辆信息
                    //if (model.pp_subwayInfoID == null && !string.IsNullOrEmpty(model.pf_carNo))
                    //{
                    //    sql = @"insert into subwayInfo(carNo,carNo_sys,prodModelID,motorCnt,subwayNo,subwayType,groups) values(@carNo,@carNo_sys,@prodModelID,@motorCnt,@subwayNo,@subwayType,@groups)";
                    //    string carNo_sys = model.pf_carNo + "001";
                    //    pList.Add(new MySqlParameter("@carNo", model.pf_carNo));
                    //    pList.Add(new MySqlParameter("@carNo_sys", carNo_sys));
                    //    pList.Add(new MySqlParameter("@prodModelID", model.pp_prodModelID));
                    //    pList.Add(new MySqlParameter("@motorCnt", model.pp_planQty));
                    //    pList.Add(new MySqlParameter("@subwayNo", 0));
                    //    pList.Add(new MySqlParameter("@subwayType", 0));
                    //    pList.Add(new MySqlParameter("@groups", 0));
                    //    int i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    //    sql = "select ID from subwayInfo where carNo_sys='" + carNo_sys + "'";
                    //    int subwayID = 0;
                    //    var obj = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text, sql, null);
                    //    int.TryParse(obj + "", out subwayID);
                    //    model.pp_subwayInfoID = subwayID;
                    //}

                    if (model.pp_guid == Guid.Empty)
                    {
                        #region 新增
                        model.pp_guid = Guid.NewGuid();
                        string strPlanCode = "";
                        string prefix = "PP" + DateTime.Now.ToString("yyyyMMdd");
                        string lastID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text
                            , "select pp_planCode from plan_prod where pp_planCode like '" + prefix + "%' order by pp_updateTime desc", null) + "";
                        if (lastID == "")
                            strPlanCode = prefix + 1.ToString("0000");
                        else
                            strPlanCode = prefix + (Convert.ToInt32(lastID.Substring(lastID.Length - 3)) + 1).ToString("0000");

                        model.pp_status = 0;
                        model.pp_deleteFlag = 0;

                        sql = @"insert into plan_prod(pp_guid,pp_planCode,pp_subwayInfoID,pp_prodModelID,pp_status,pp_planQty,pp_startDate,pp_finishDate,pp_remark,pp_deleteFlag
,pp_createTime,pp_createMan,pp_updateTime,pp_updateMan) values(@pp_guid,@pp_planCode,@pp_subwayInfoID,@pp_prodModelID,@pp_status,@pp_planQty,@pp_startDate,@pp_finishDate,@pp_remark
,@pp_deleteFlag,@pp_createTime,@pp_createMan,@pp_updateTime,@pp_updateMan) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_guid", model.pp_guid));
                        pList.Add(new MySqlParameter("@pp_planCode", strPlanCode));
                        pList.Add(new MySqlParameter("@pp_subwayInfoID", model.pp_subwayInfoID));
                        pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
                        pList.Add(new MySqlParameter("@pp_status", model.pp_status));
                        pList.Add(new MySqlParameter("@pp_planQty", model.pp_planQty));
                        pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
                        pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate));
                        pList.Add(new MySqlParameter("@pp_remark", model.pp_remark));
                        pList.Add(new MySqlParameter("@pp_deleteFlag", model.pp_deleteFlag));
                        pList.Add(new MySqlParameter("@pp_createTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_createMan", model.pp_updateMan));
                        pList.Add(new MySqlParameter("@pp_updateTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_updateMan", model.pp_updateMan));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }
                    else
                    {
                        #region 编辑
                        sql = @"update plan_prod set pp_subwayInfoID=@pp_subwayInfoID,pp_prodModelID=@pp_prodModelID,pp_planQty=@pp_planQty,pp_startDate=@pp_startDate
,pp_finishDate=@pp_finishDate,pp_remark=@pp_remark,pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan where pp_guid=@pp_guid ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_guid", model.pp_guid));
                        pList.Add(new MySqlParameter("@pp_subwayInfoID", model.pp_subwayInfoID));
                        pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
                        pList.Add(new MySqlParameter("@pp_planQty", model.pp_planQty));
                        pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
                        pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate));
                        pList.Add(new MySqlParameter("@pp_remark", model.pp_remark));
                        pList.Add(new MySqlParameter("@pp_updateTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_updateMan", model.pp_updateMan));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }

                    //计划明细表 全删全插 
                    if (model.pp_planQty.HasValue && model.pp_guid != Guid.Empty)
                    {
                        sql = "delete from plan_detail where ppGuid=@ppGuid";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ppGuid", model.pp_guid));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        for (int i = 0; i < model.pp_planQty.Value; i++)
                        {
                            sql = "insert plan_detail(ppGuid,pdStatus) values(@ppGuid,@pdStatus)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ppGuid", model.pp_guid));
                            pList.Add(new MySqlParameter("@pdStatus", (int)EDAEnums.PlanDetailStatus.New));
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }
                    }

                    myTrans.Commit();
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }

        /// <summary>
        /// 修改计划明细表车厢号
        /// </summary>
        /// <param name="ID">计划明细ID</param>
        /// <param name="strNewValue">新车厢号</param>
        /// <returns>受影响行数</returns>
        public int EditPlanDetailCompartNo(int ID, string strNewValue)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update plan_detail set pdCompartNo=@pdCompartNo where ID=@ID";
            pList.Add(new MySqlParameter("@pdCompartNo", strNewValue));
            pList.Add(new MySqlParameter("@ID", ID));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i;
        }

        /// <summary>
        /// 修改计划明细表转向架号
        /// </summary>
        /// <param name="ID">计划明细ID</param>
        /// <param name="strNewValue">新转向架号</param>
        /// <returns>受影响行数</returns>
        public int EditPlanDetailBogieNo(int ID, string strNewValue)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update plan_detail set pdBogieNo=@pdBogieNo where ID=@ID";
            pList.Add(new MySqlParameter("@pdBogieNo", strNewValue));
            pList.Add(new MySqlParameter("@ID", ID));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i;
        }

        /// <summary>
        /// 保存电机编号
        /// </summary>
        /// <param name="model">计划明细实体类</param>
        /// <returns>返回消息</returns>
        public string SaveProdNo(PlanDetailModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                string ret = "";
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";
                    int i = 0;
                    DateTime NowTime = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, "select now()", null).ToDateTime();//获取服务器时间
                    if (NowTime == DateTime.MinValue) NowTime = DateTime.Now;

                    //判断老电机编号,无则表示新增,需要存放
                    //产品数据-无则新增,有则获取 
                    if (string.IsNullOrEmpty(model.oldProdNo))
                    {
                        #region 首次录入电机信息 新增
                        //如果是存放,代表首次录入电机编号,则新增电机信息

                        #region 车辆信息 获取车辆ID
                        int? CarID = null;
                        if (!string.IsNullOrEmpty(model.carNo))
                        {
                            //如果车号不为空,获取车辆信息,若无则新增再获取车辆ID,有则直接获取车辆ID
                            sql = @"select * from subwayinfo where carNo=@carNo";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@carNo", model.carNo));
                            var dtCarInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());

                            if (dtCarInfo == null || dtCarInfo.Rows.Count == 0)
                            {
                                sql = @"insert into subwayInfo(carNo,carNo_sys,prodModelID,motorCnt) values(@carNo,@carNo_sys,@prodModelID,@motorCnt)";
                                string carNo_sys = model.carNo + "001";
                                pList.Add(new MySqlParameter("@carNo", model.carNo));
                                pList.Add(new MySqlParameter("@carNo_sys", carNo_sys));
                                pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
                                pList.Add(new MySqlParameter("@motorCnt", model.planQty));
                                i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                                sql = @"select @@IDENTITY";
                                pList.Clear();
                                CarID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                            }
                            else
                            {
                                CarID = dtCarInfo.Rows[0]["ID"].ToInt();
                            }
                        }
                        #endregion

                        #region 添加电机信息
                        int? ProdID = null;
                        if (!string.IsNullOrEmpty(model.pdProdNo))
                        {
                            sql = @"select * from productInfo where pf_prodNo=@pf_prodNo";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pf_prodNo", model.pdProdNo));
                            var dtProdInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());

                            if (dtProdInfo == null || dtProdInfo.Rows.Count == 0)
                            {
                                sql = @"insert into productInfo(pf_prodNo,pf_prodID,pf_prodModelID,pf_subwayInfoID,pf_compartNo,pf_bogieNo,pf_DeleteFlag,pf_CreateTime,pf_UpdateTime
,pf_CreateMan,pf_UpdateMan) values(@pf_prodNo,@pf_prodID,@pf_prodModelID,@pf_subwayInfoID,@pf_compartNo,@pf_bogieNo,0,@pf_CreateTime,@pf_UpdateTime,@pf_CreateMan,@pf_UpdateMan)";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@pf_prodNo", model.pdProdNo));
                                pList.Add(new MySqlParameter("@pf_prodID", model.prodID));
                                pList.Add(new MySqlParameter("@pf_prodModelID", model.prodModelID));
                                pList.Add(new MySqlParameter("@pf_subwayInfoID", CarID));
                                pList.Add(new MySqlParameter("@pf_compartNo", model.pdCompartNo));
                                pList.Add(new MySqlParameter("@pf_bogieNo", model.pdBogieNo));
                                pList.Add(new MySqlParameter("@pf_CreateTime", NowTime));
                                pList.Add(new MySqlParameter("@pf_UpdateTime", NowTime));
                                pList.Add(new MySqlParameter("@pf_CreateMan", model.curUserID));
                                pList.Add(new MySqlParameter("@pf_UpdateMan", model.curUserID));
                                i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                                #region 获取电机ID
                                sql = @"select @@IDENTITY";
                                pList.Clear();
                                ProdID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                                #endregion
                            }
                            else
                            {
                                ProdID = dtProdInfo.Rows[0]["pf_ID"].ToInt();
                            }
                        }
                        if (ProdID == 0) throw new Exception("[" + model.pdProdNo + "]电机编号为0");
                        #endregion

                        if (model.isCache)
                        {
                            #region 缓存区
                            //1.存放至存放区域表 存放区域 新增
                            sql = "insert into base_tempArea(ta_areaID,ta_planGuid,ta_curSysProdNo,ta_status) values(@ta_areaID,@ta_planGuid,@ta_curSysProdNo,194) ";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ta_areaID", (int)EDAEnums.TempArea.Cache));
                            pList.Add(new MySqlParameter("@ta_planGuid", model.ppGuid));
                            pList.Add(new MySqlParameter("@ta_curSysProdNo", model.pdProdNo));
                            i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                            #region 存放记录 新增
                            sql = @"select @@IDENTITY";
                            pList.Clear();
                            model.pdTAID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();

                            sql = @"insert into TempAreaPut_log(tempAreaID,pInfo_ID,inTime,inOper) values(@tempAreaID,@pInfo_ID,@inTime,@inOper)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@tempAreaID", model.pdTAID));
                            pList.Add(new MySqlParameter("@pInfo_ID", ProdID));
                            pList.Add(new MySqlParameter("@inTime", NowTime));
                            pList.Add(new MySqlParameter("@inOper", model.curUserID));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 修改计划明细表信息
                            sql = "update plan_detail set pdProdNo=@pdProdNo,pdStatus=2,pdTAID=@pdTAID where ID=@ID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pdProdNo", model.pdProdNo));
                            pList.Add(new MySqlParameter("@pdTAID", model.pdTAID));
                            pList.Add(new MySqlParameter("@ID", model.ID));
                            i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #endregion
                        }
                        else
                        {
                            #region 入场存放区

                            #region 生产主表 新增
                            sql = @"select count(1) from follow_production fp
left join productInfo pf on pf.pf_ID= fp.fp_pInfo_ID where pf.pf_prodNo=@pf_prodNo";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pf_prodNo", model.pdProdNo));
                            int count = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                            string SerialNo = (count + 1).ToString().PadLeft(3, '0');//流水号
                            var pf_prodNo_sys = model.pdProdNo + SerialNo;//系统产品编号
                            sql = @"insert into follow_production(fp_guid,pp_guid,fp_pInfo_ID,fp_prodNo_sys,fp_repairTypeID,fp_finishStatus) 
values(@fp_guid,@pp_guid,@fp_pInfo_ID,@fp_prodNo_sys,@fp_repairTypeID,@fp_finishStatus)";
                            var fp_guid = Guid.NewGuid();
                            pList.Clear();
                            pList.Add(new MySqlParameter("@fp_guid", fp_guid));
                            pList.Add(new MySqlParameter("@pp_guid", model.ppGuid));
                            pList.Add(new MySqlParameter("@fp_pInfo_ID", ProdID));
                            pList.Add(new MySqlParameter("@fp_prodNo_sys", pf_prodNo_sys));
                            pList.Add(new MySqlParameter("@fp_repairTypeID", 0));
                            pList.Add(new MySqlParameter("@fp_finishStatus", 0));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 追溯主表 新增
                            sql = @"insert into follow_main(fm_guid,fp_guid,pInfo_ID,fm_finishStatus,fm_isSend,fm_curAreaID,fm_curGwID,fm_curGw,fm_creatorID,fm_creator,fm_resultIsOK) 
values(@fm_guid,@fp_guid,@pInfo_ID,0,0,@fm_curAreaID,@fm_curGwID,@fm_curGw,@fm_creatorID,@fm_creator,0)";
                            var fm_guid = Guid.NewGuid();
                            pList.Clear();
                            pList.Add(new MySqlParameter("@fm_guid", fm_guid));
                            pList.Add(new MySqlParameter("@fp_guid", fp_guid));
                            pList.Add(new MySqlParameter("@pInfo_ID", ProdID));
                            pList.Add(new MySqlParameter("@fm_curAreaID", model.curAreaID));
                            pList.Add(new MySqlParameter("@fm_curGwID", model.curGwID));
                            pList.Add(new MySqlParameter("@fm_curGw", model.curGwName));
                            pList.Add(new MySqlParameter("@fm_creatorID", model.curUserID));
                            pList.Add(new MySqlParameter("@fm_creator", model.curUserName));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 追溯工位表 新增
                            sql = @"insert into follow_gw(fgw_guid,fm_guid,fp_guid,pInfo_ID,fgw_areaID,fgw_areaName,fgw_gwID,fgw_gwName,fgw_operID,fgw_oper,fgw_starttime
,fgw_followStatus) 
values(@fgw_guid,@fm_guid,@fp_guid,@pInfo_ID,@fgw_areaID,@fgw_areaName,@fgw_gwID,@fgw_gwName,@fgw_operID,@fgw_oper,@fgw_starttime,0)";
                            var fgw_guid = Guid.NewGuid();
                            pList.Clear();
                            pList.Add(new MySqlParameter("@fgw_guid", fgw_guid));
                            pList.Add(new MySqlParameter("@fm_guid", fm_guid));
                            pList.Add(new MySqlParameter("@fp_guid", fp_guid));
                            pList.Add(new MySqlParameter("@pInfo_ID", ProdID));
                            pList.Add(new MySqlParameter("@fgw_areaID", model.curAreaID));
                            pList.Add(new MySqlParameter("@fgw_areaName", model.curAreaName));
                            pList.Add(new MySqlParameter("@fgw_gwID", model.curGwID));
                            pList.Add(new MySqlParameter("@fgw_gwName", model.curGwName));
                            pList.Add(new MySqlParameter("@fgw_operID", model.curUserID));
                            pList.Add(new MySqlParameter("@fgw_oper", model.curUserName));
                            pList.Add(new MySqlParameter("@fgw_starttime", NowTime));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 追溯明细表 新增
                            sql = @"insert into follow_detail(fd_guid,fgw_guid,fm_guid,fp_guid,pInfo_ID
,fd_areaID,fd_areaName,fd_gwID,fd_gwName,fd_operID,fd_oper,fd_starttime,fd_followStatus,fd_isNextScan,fd_isCancel) 
values(@fd_guid,@fgw_guid,@fm_guid,@fp_guid,@pInfo_ID,@fd_areaID,@fd_areaName,@fd_gwID,@fd_gwName,@fd_operID,@fd_oper,@fd_starttime,0,0,0)";
                            var fd_guid = Guid.NewGuid();
                            pList.Clear();
                            pList.Add(new MySqlParameter("@fd_guid", fgw_guid));
                            pList.Add(new MySqlParameter("@fgw_guid", fgw_guid));
                            pList.Add(new MySqlParameter("@fm_guid", fm_guid));
                            pList.Add(new MySqlParameter("@fp_guid", fp_guid));
                            pList.Add(new MySqlParameter("@pInfo_ID", ProdID));
                            pList.Add(new MySqlParameter("@fd_areaID", model.curAreaID));
                            pList.Add(new MySqlParameter("@fd_areaName", model.curAreaName));
                            pList.Add(new MySqlParameter("@fd_gwID", model.curGwID));
                            pList.Add(new MySqlParameter("@fd_gwName", model.curGwName));
                            pList.Add(new MySqlParameter("@fd_operID", model.curUserID));
                            pList.Add(new MySqlParameter("@fd_oper", model.curUserName));
                            pList.Add(new MySqlParameter("@fd_starttime", NowTime));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 存放区域 修改
                            //获取该型号存放区域Code
                            sql = @"select bt.ta_areaCode from base_tempArea bt left join plan_prod pp on pp.pp_guid=bt.ta_planGuid where pp.pp_prodModelID=@pp_prodModelID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pp_prodModelID", model.prodModelID));
                            string strAreaCode = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "";
                            //获取一个空的存放区域
                            sql = @"select ta_ID from base_tempArea where (ta_curSysProdNo is null or ta_curSysProdNo='') and ta_areaID=" + (int)EDAEnums.TempArea.InComming;
                            if (!string.IsNullOrEmpty(strAreaCode))
                            {
                                sql += " and ta_areaCode='" + strAreaCode + "'";
                            }
                            model.pdTAID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, null).ToInt();

                            //不存在入场区满了的情况,会在前台判断,最终体现于是否存放于入场区.
                            //修改存放区域表为待存
                            sql = @"update base_tempArea set ta_curSysProdNo=@ta_curSysProdNo,ta_status=" + (int)EDAEnums.PutStatus.StayPut + ",ta_curFmGuid=@ta_curFmGuid,ta_planGuid=@ta_planGuid where ta_ID=@ID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ta_curSysProdNo", pf_prodNo_sys));
                            pList.Add(new MySqlParameter("@ID", model.pdTAID));
                            pList.Add(new MySqlParameter("@ta_curFmGuid", fp_guid));
                            pList.Add(new MySqlParameter("@ta_planGuid", model.ppGuid));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 存放记录 新增
                            sql = @"insert into TempAreaPut_log(tempAreaID,pInfo_ID,inTime,inOper) values(@tempAreaID,@pInfo_ID,@inTime,@inOper)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@tempAreaID", model.pdTAID));
                            pList.Add(new MySqlParameter("@pInfo_ID", ProdID));
                            pList.Add(new MySqlParameter("@inTime", NowTime));
                            pList.Add(new MySqlParameter("@inOper", model.curUserID));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 修改计划明细表信息
                            sql = "update plan_detail set pdProdNo=@pdProdNo,pdStatus=3,pdTAID=@pdTAID where ID=@ID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pdProdNo", model.pdProdNo));
                            pList.Add(new MySqlParameter("@pdTAID", model.pdTAID));
                            pList.Add(new MySqlParameter("@ID", model.ID));
                            i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #endregion
                        }

                        #endregion
                    }
                    else
                    {
                        #region 编辑 电机编号

                        #region 获取计划明细状态
                        sql = "select pdStatus from plan_detail where ID=@ID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        int pdStatus = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                        if (pdStatus <= 0 || pdStatus > (int)EDAEnums.PlanDetailStatus.Write)
                            throw new Exception("计划明细状态异常!");
                        #endregion

                        if (string.IsNullOrEmpty(model.pdProdNo))
                        {
                            #region 取消 删除

                            if (pdStatus == (int)EDAEnums.PlanDetailStatus.Write)
                            {
                                #region 追溯明细表 删除
                                sql = "delete from follow_detail where fp_guid=@fp_guid";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@fp_guid", model.ta_curFmGuid));
                                i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                #endregion

                                #region 追溯工位表 删除
                                sql = "delete from follow_gw where fp_guid=@fp_guid";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@fp_guid", model.ta_curFmGuid));
                                i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                #endregion

                                #region 追溯主表 删除
                                sql = "delete from follow_main where fp_guid=@fp_guid";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@fp_guid", model.ta_curFmGuid));
                                i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                #endregion

                                #region 生产主表 删除
                                sql = "delete from follow_production where fp_guid=@fp_guid";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@fp_guid", model.ta_curFmGuid));
                                i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                #endregion
                            }

                            #region 存放区域 修改
                            sql = "update base_tempArea set ta_curSysProdNo=null,ta_status=" + (int)EDAEnums.PutStatus.Null + ",ta_curFmGuid=null,ta_planGuid=null where ta_ID=@ID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ID", model.pdTAID));
                            i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #region 修改计划明细表信息
                            sql = "update plan_detail set pdProdNo=null,pdTAID=null,pdStatus=1 where ID=@ID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ID", model.ID));
                            i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #endregion
                        }
                        else
                        {
                            #region 编辑 根据状态判断是否需要修改业务表,还是只需要修改计划明细表

                            if (pdStatus == (int)EDAEnums.PlanDetailStatus.Write)//状态为待存表示已经录入过业务数据,则需要修改业务数据,否则则不需要
                            {
                                #region 编辑业务信息表(产品信息表,生产主表)
                                //判断新电机编号在产品信息表是否有数据
                                sql = "select * from productInfo where pf_prodNo=@pf_prodNo";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@pf_prodNo", model.pdProdNo));
                                var dtProdInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                                if (dtProdInfo == null || dtProdInfo.Rows.Count == 0)
                                {
                                    #region 如果没有数据,修改原本产品信息表数据
                                    sql = @"update productInfo set pf_prodNo=@pf_prodNo where pf_prodNo=@oldProdNo";
                                    pList.Clear();
                                    pList.Add(new MySqlParameter("@pf_prodNo", model.pdProdNo));
                                    pList.Add(new MySqlParameter("@oldProdNo", model.oldProdNo));
                                    var updateQty = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                    i += updateQty;
                                    #endregion

                                    #region 产品信息表修改成功情况下,修改生产主表数据
                                    if (updateQty > 0)
                                    {
                                        #region 查询生产主表中对于新电机编号已有多少条数据 用于计算系统产品编号
                                        sql = "select * from follow_production where fp_prodNo_sys like concat('',@fp_prodNo_sys,'%') ";
                                        pList.Clear();
                                        pList.Add(new MySqlParameter("@fp_prodNo_sys", model.pdProdNo));
                                        var dtProduction = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                                        if (dtProduction == null)
                                            dtProduction = new DataTable();
                                        string SerialNo = (dtProduction.Rows.Count + 1).ToString().PadLeft(3, '0');//流水号
                                        var pf_prodNo_sys = model.pdProdNo + SerialNo;//系统产品编号
                                        #endregion

                                        #region 修改生产主表 系统电机编号
                                        if (!model.ta_curFmGuid.HasValue || model.ta_curFmGuid.Value == Guid.Empty)
                                            throw new Exception("传入生产主表GUID为空!");

                                        sql = @"update follow_production set fp_prodNo_sys=@fp_prodNo_sys where fp_guid=@fp_guid";
                                        pList.Clear();
                                        pList.Add(new MySqlParameter("@fp_prodNo_sys", pf_prodNo_sys));
                                        pList.Add(new MySqlParameter("@fp_guid", model.ta_curFmGuid));
                                        i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                        #endregion

                                        #region 修改存放区域表 系统电机编号
                                        if (!model.pdTAID.HasValue || model.pdTAID == 0)
                                            throw new Exception("传入存放区域表ID为空!");

                                        sql = "update base_tempArea set ta_curSysProdNo=@ta_curSysProdNo where ta_ID=@ID";
                                        pList.Clear();
                                        pList.Add(new MySqlParameter("@ta_curSysProdNo", pf_prodNo_sys));
                                        pList.Add(new MySqlParameter("@ID", model.pdTAID));
                                        i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                        #endregion
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region 如果有数据,判断生产是否已完成 全部已完成则可修改否则不可

                                    var isOK = true;//是否全部已完成
                                    foreach (DataRow row in dtProdInfo.Rows)
                                    {
                                        var fp_finishStatus = row["fp_finishStatus"].ToInt();
                                        if (fp_finishStatus == 0)
                                        {
                                            isOK = false;
                                            break;
                                        }
                                    }

                                    //如果全部已完成,则可以修改,
                                    if (isOK)
                                    {
                                        int pfID = dtProdInfo.Rows[0]["pf_ID"].ToInt();

                                        #region 查询生产主表中对于新电机编号已有多少条数据 用于计算系统产品编号
                                        sql = "select * from follow_production where fp_prodNo_sys like concat('',@fp_prodNo_sys,'%') ";
                                        pList.Clear();
                                        pList.Add(new MySqlParameter("@fp_prodNo_sys", model.pdProdNo));
                                        var dtProduction = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                                        if (dtProduction == null)
                                            dtProduction = new DataTable();
                                        string SerialNo = (dtProduction.Rows.Count + 1).ToString().PadLeft(3, '0');//流水号
                                        var pf_prodNo_sys = model.pdProdNo + SerialNo;//系统产品编号
                                        #endregion

                                        #region 修改生产主表 产品信息ID 系统电机编号
                                        if (!model.ta_curFmGuid.HasValue || model.ta_curFmGuid.Value == Guid.Empty)
                                            throw new Exception("传入生产主表GUID为空!");

                                        sql = @"update follow_production set fp_pInfo_ID=@fp_pInfo_ID,fp_prodNo_sys=@fp_prodNo_sys where fp_guid=@fp_guid";
                                        pList.Clear();
                                        pList.Add(new MySqlParameter("@fp_pInfo_ID", pfID));
                                        pList.Add(new MySqlParameter("@fp_prodNo_sys", pf_prodNo_sys));
                                        pList.Add(new MySqlParameter("@fp_guid", model.ta_curFmGuid));
                                        i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                        #endregion

                                        #region 修改存放区域表 系统电机编号
                                        if (!model.pdTAID.HasValue || model.pdTAID == 0)
                                            throw new Exception("传入存放区域表ID为空!");

                                        sql = "update base_tempArea set ta_curSysProdNo=@ta_curSysProdNo where ta_ID=@ID";
                                        pList.Clear();
                                        pList.Add(new MySqlParameter("@ta_curSysProdNo", pf_prodNo_sys));
                                        pList.Add(new MySqlParameter("@ID", model.pdTAID));
                                        i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                        #endregion
                                    }
                                    else
                                    {
                                        throw new Exception("产品编号重复,操作失败!");
                                    }

                                    #endregion
                                }
                                #endregion
                            }

                            #region 修改计划明细表信息
                            sql = "update plan_detail set pdProdNo=@pdProdNo where ID=@ID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pdProdNo", model.pdProdNo));
                            pList.Add(new MySqlParameter("@ID", model.ID));
                            i += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            #endregion

                            #endregion
                        }

                        #region 电机编号编辑逻辑说明
                        //电机编号A ,已生产过一次, 此次系统电机编号为A002
                        //欲修改电机编号由A为B 

                        //判断新电机编号在产品信息表是否有数据.
                        //若没有,可修改
                        //若有,获取产品信息ID,查询生产主表中未完成信息
                        //若此电机编号的生产均已完成(未查到未完成生产),则可修改
                        //否则不可修改

                        //若电机编号B,已经有过1次生产,且已完成.
                        //电机编号A亦有过1次生产,且已完成.
                        //若电机编号A需要改为B,则可以过判断,产品信息表是否修改? 如果修改,则产生2条相同电机编号的产品信息数据,所以不能修改产品信息表.
                        //生产主表已有数据:
                        //电机编号B的产品信息ID,电机编号B的系统电机编号B001
                        //电机编号A的产品信息ID,电机编号A的系统电机编号A001
                        //电机编号A的产品信息ID,电机编号A的系统电机编号A002
                        //则需要根据生产主表ID将第三条数据改为电机编号B的产品信息ID,电机编号B的系统电机编号B002
                        #endregion
                        #endregion
                    }

                    myTrans.Commit();
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    return ex.Message;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }

        /// <summary>
        /// 根据guid删除计划
        /// </summary>
        /// <param name="guid">guid</param>
        /// <returns>受影响行数</returns>
        public int DeletePlan(Guid guid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "update plan_prod set pp_deleteFlag=1 where pp_guid=@pp_guid";
            pList.Add(new MySqlParameter("@pp_guid", guid));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i;
        }
        #endregion

        #region 配件计划管理 2020-03-09


        /// <summary>
        /// 配件计划管理 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanModel> GetPartPlanList(PartPlanModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKEorderCode))
            {
                para += " and pp.pp_orderCode like CONCAT('%',@LIKEorderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEorderCode", model.LIKEorderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEorderCodeRel))
            {
                para += " and pp.pp_orderCodeRel like CONCAT('%',@LIKEorderCodeRel,'%') ";
                pList.Add(new MySqlParameter("@LIKEorderCodeRel", model.LIKEorderCodeRel.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEproject))
            {
                para += " and pp.pp_project like CONCAT('%',@LIKEproject,'%') ";
                pList.Add(new MySqlParameter("@LIKEproject", model.LIKEproject.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEtrackNumber))
            {
                para += " and pp.pp_trackNumber like CONCAT('%',@LIKEtrackNumber,'%') ";
                pList.Add(new MySqlParameter("@LIKEtrackNumber", model.LIKEtrackNumber.Trim()));
            }
            if (model.pp_prodModelID.HasValue && model.pp_prodModelID.Value != 0)
            {
                para += " and pp.pp_prodModelID=@pp_prodModelID ";
                pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
            }
            if (model.pp_startDate.HasValue)
            {
                para += " and pp.pp_startDate>=@pp_startDate ";
                pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
            }
            if (model.pp_finishDate.HasValue)
            {
                para += " and pp.pp_finishDate<@pp_finishDate ";
                pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate.Value.AddDays(1)));
            }
            if (model.pp_status.HasValue && model.pp_status != -1)
            {
                para += " and pp.pp_status=@pp_status ";
                pList.Add(new MySqlParameter("@pp_status", model.pp_status));
            }

            string sql = @"select count(1) from Part_Plan pp 
                                   left join base_productmodel pm on pp.pp_prodModelID=pm.ID where pp.pp_deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            //sql = @"select pp.*,pm.Pmodel,CONCAT_WS('-',pm.Pmodel,pp.pp_material) as PmodelDrawingNo,
            //        GetEmpNameByuID(pm_rejectID) pm_rejectText,pm_rejectDate,
            //        GetbdNameBybdID(prm.pm_rejectType) pm_rejectTypeText,pm_rejectMemo
            //        from Part_Plan pp 
            //        left join pms_requisitionmain prm on prm.pp_orderCode = pp.pp_orderCode
            //        left join base_productmodel pm on pp.pp_prodModelID=pm.ID where pp.pp_deleteFlag=0 " + para;
            sql = @"select pp.*,TRUNCATE(pp.pp_materialPercent,2) as pp_materialPercent1,pm.Pmodel,CONCAT_WS('-',pm.Pmodel,pp.pp_material) as PmodelDrawingNo
                    from Part_Plan pp 
                    left join base_productmodel pm on pp.pp_prodModelID=pm.ID where pp.pp_deleteFlag=0 " + para;
            if (!string.IsNullOrEmpty(model.sort))
            {
                sql += " order by " + model.sort + " " + model.sortOrder;
            }
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<PartPlanModel> list = db.ExecuteList<PartPlanModel>(sql, pList.ToArray());
            return list;
        }






        /// <summary>
        /// 保存配件计划主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePartPlan(PartPlanModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";


                    #region 查询排序号

                    DataTable ppdt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from Part_Plan where pp_status <> 2 and pp_status <> 3 order by pp_sort DESC", null);
                    List<PartPlanModel> dtppList = db.ToList<PartPlanModel>(ppdt);

                    #endregion

                    if (string.IsNullOrEmpty(model.pp_orderCode))
                    {
                        #region 新增
                        string strPlanCode = "";
                        strPlanCode = db.GetSerialNumber("Part_Plan", "PP", 4);//调用存储过程获取流水号

                        model.pp_bizDate = DateTime.Now;
                        model.pp_status = 0;
                        model.pp_deleteFlag = 0;
                        model.pp_createTime = DateTime.Now;

                        sql = @"insert into Part_Plan(pp_orderCode,pp_orderCodeRel,pp_storageOrgUnit,pp_transactionType,pp_bizDate,pp_material,pp_project,pp_trackNumber,pp_prodModelID,pp_status,
                                        pp_planQty,pp_startDate,pp_finishDate,pp_description,pp_adminOrgUnitID,pp_remark,pp_sort,pp_deleteFlag,pp_createTime,pp_createMan,pp_updateTime,pp_updateMan,
                                        pp_projectName,pp_wagonNo) 
                                        values(@pp_orderCode,@pp_orderCodeRel,@pp_storageOrgUnit,@pp_transactionType,@pp_bizDate,@pp_material,@pp_project,@pp_trackNumber,@pp_prodModelID,@pp_status,
                                        @pp_planQty,@pp_startDate,@pp_finishDate,@pp_description,@pp_adminOrgUnitID,@pp_remark,@pp_sort,@pp_deleteFlag,@pp_createTime,@pp_createMan,@pp_updateTime,@pp_updateMan,
                                        @pp_projectName,@pp_wagonNo) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCode", strPlanCode));
                        pList.Add(new MySqlParameter("@pp_orderCodeRel", model.pp_orderCodeRel));//第三方系统关联订单编码
                        pList.Add(new MySqlParameter("@pp_storageOrgUnit", model.pp_storageOrgUnit));
                        pList.Add(new MySqlParameter("@pp_transactionType", model.pp_transactionType));
                        pList.Add(new MySqlParameter("@pp_bizDate", model.pp_bizDate));//业务日期
                        pList.Add(new MySqlParameter("@pp_material", model.pp_material));
                        pList.Add(new MySqlParameter("@pp_project", model.pp_project));
                        pList.Add(new MySqlParameter("@pp_trackNumber", model.pp_trackNumber));
                        pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
                        pList.Add(new MySqlParameter("@pp_status", model.pp_status));
                        pList.Add(new MySqlParameter("@pp_planQty", model.pp_planQty));
                        pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
                        pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate));
                        pList.Add(new MySqlParameter("@pp_description", model.pp_description));
                        pList.Add(new MySqlParameter("@pp_adminOrgUnitID", model.pp_adminOrgUnitID));
                        pList.Add(new MySqlParameter("@pp_remark", model.pp_remark));
                        pList.Add(new MySqlParameter("@pp_sort", dtppList.FirstOrDefault().pp_sort + 1));
                        pList.Add(new MySqlParameter("@pp_deleteFlag", model.pp_deleteFlag));
                        pList.Add(new MySqlParameter("@pp_createTime", model.pp_createTime));
                        pList.Add(new MySqlParameter("@pp_createMan", model.pp_createMan));
                        pList.Add(new MySqlParameter("@pp_updateTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_updateMan", model.pp_updateMan));
                        pList.Add(new MySqlParameter("@pp_projectName", model.pp_projectName));
                        pList.Add(new MySqlParameter("@pp_wagonNo", model.pp_wagonNo));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }
                    else
                    {
                        #region 编辑
                        model.pp_status = 0;
                        model.pp_updateTime = DateTime.Now;

                        sql = @"update Part_Plan set pp_orderCodeRel=@pp_orderCodeRel,pp_storageOrgUnit=@pp_storageOrgUnit,pp_transactionType=@pp_transactionType,
                                        pp_bizDate=@pp_bizDate,pp_material=@pp_material,pp_project=@pp_project,pp_trackNumber=@pp_trackNumber,pp_prodModelID=@pp_prodModelID,pp_status=@pp_status,
                                        pp_planQty=@pp_planQty,pp_startDate=@pp_startDate,pp_finishDate=@pp_finishDate,pp_description=@pp_description,pp_adminOrgUnitID=@pp_adminOrgUnitID,pp_remark=@pp_remark,
                                        pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan,pp_projectName=@pp_projectName,pp_wagonNo=@pp_wagonNo where pp_orderCode=@pp_orderCode ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCodeRel", model.pp_orderCodeRel));//第三方系统关联订单编码
                        pList.Add(new MySqlParameter("@pp_storageOrgUnit", model.pp_storageOrgUnit));
                        pList.Add(new MySqlParameter("@pp_transactionType", model.pp_transactionType));
                        pList.Add(new MySqlParameter("@pp_bizDate", model.pp_bizDate));//业务日期
                        pList.Add(new MySqlParameter("@pp_material", model.pp_material));
                        pList.Add(new MySqlParameter("@pp_project", model.pp_project));
                        pList.Add(new MySqlParameter("@pp_trackNumber", model.pp_trackNumber));
                        pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
                        pList.Add(new MySqlParameter("@pp_status", model.pp_status));
                        pList.Add(new MySqlParameter("@pp_planQty", model.pp_planQty));
                        pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
                        pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate));
                        pList.Add(new MySqlParameter("@pp_description", model.pp_description));
                        pList.Add(new MySqlParameter("@pp_adminOrgUnitID", model.pp_adminOrgUnitID));
                        pList.Add(new MySqlParameter("@pp_remark", model.pp_remark));
                        pList.Add(new MySqlParameter("@pp_updateTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_updateMan", model.pp_updateMan));
                        pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
                        pList.Add(new MySqlParameter("@pp_projectName", model.pp_projectName));
                        pList.Add(new MySqlParameter("@pp_wagonNo", model.pp_wagonNo));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion


                        #region 修改计划数量时更新 备料计划数量

                        DataTable dt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from part_planstock where pp_orderCode = '" + model.pp_orderCode + "' ", null);
                        List<PartPlanStockModel> StockList = db.ToList<PartPlanStockModel>(dt);
                        if (StockList != null && StockList.Count > 0)
                        {
                            for (int i = 0; i < StockList.Count; i++)
                            {
                                //计划数量 * 物料标准数量
                                int NewSum = (int)model.pp_planQty * (int)StockList[i].ps_qty;
                                sql = @"update part_planstock set ps_plannedQty=@ps_plannedQty where ps_orderCode=@ps_orderCode ";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@ps_plannedQty", NewSum));//调整后的计划数量
                                pList.Add(new MySqlParameter("@ps_orderCode", StockList[i].ps_orderCode));
                                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                            }
                        }

                        #endregion


                    }

                    ////计划明细表 全删全插
                    //if (model.pp_planQty.HasValue && model.pp_guid != Guid.Empty)
                    //{
                    //    sql = "delete from plan_detail where ppGuid=@ppGuid";
                    //    pList.Clear();
                    //    pList.Add(new MySqlParameter("@ppGuid", model.pp_guid));
                    //    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    //    for (int i = 0; i < model.pp_planQty.Value; i++)
                    //    {
                    //        sql = "insert plan_detail(ppGuid,pdStatus) values(@ppGuid,@pdStatus)";
                    //        pList.Clear();
                    //        pList.Add(new MySqlParameter("@ppGuid", model.pp_guid));
                    //        pList.Add(new MySqlParameter("@pdStatus", (int)EDAEnums.PlanDetailStatus.New));
                    //        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    //    }
                    //}

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }

        /// <summary>
        /// 配件计划管理 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanModel> GetPartPlanList(PartPlanModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                para += " and pp.pp_orderCode = @pp_orderCode ";
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEorderCode))
            {
                para += " and pp.pp_orderCode like CONCAT('%',@LIKEorderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEorderCode", model.LIKEorderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEorderCodeRel))
            {
                para += " and pp.pp_orderCodeRel like CONCAT('%',@LIKEorderCodeRel,'%') ";
                pList.Add(new MySqlParameter("@LIKEorderCodeRel", model.LIKEorderCodeRel.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEproject))
            {
                para += " and pp.pp_project like CONCAT('%',@LIKEproject,'%') ";
                pList.Add(new MySqlParameter("@LIKEproject", model.LIKEproject.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEtrackNumber))
            {
                para += " and pp.pp_trackNumber like CONCAT('%',@LIKEtrackNumber,'%') ";
                pList.Add(new MySqlParameter("@LIKEtrackNumber", model.LIKEtrackNumber.Trim()));
            }
            if (model.pp_prodModelID.HasValue && model.pp_prodModelID.Value != 0)
            {
                para += " and pp.pp_prodModelID=@pp_prodModelID ";
                pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
            }
            if (model.pp_startDate.HasValue)
            {
                para += " and pp.pp_startDate>=@pp_startDate ";
                pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
            }
            if (model.pp_finishDate.HasValue)
            {
                para += " and pp.pp_finishDate<@pp_finishDate ";
                pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate.Value.AddDays(1)));
            }
            if (model.pp_status.HasValue && model.pp_status != -1)
            {
                para += " and pp.pp_status=@pp_status ";
                pList.Add(new MySqlParameter("@pp_status", model.pp_status));
            }


            if (!string.IsNullOrEmpty(model.TimeConditions))
            {
                if (model.TimeConditions.Equals("本月"))
                {
                    para += " and DATE_FORMAT(pp.pp_startDate, '%Y%m')= DATE_FORMAT(CURDATE(), '%Y%m') ";
                }
                else if (model.TimeConditions.Equals("上月"))
                {
                    para += " and PERIOD_DIFF(date_format(now(),'%Y%m'),date_format(pp.pp_startDate,'%Y%m')) =1 ";
                }
            }

            string sql = @"select pp.*,TRUNCATE(pp.pp_materialPercent,2) as pp_materialPercent1,pm.Pmodel,CONCAT_WS('-',pm.Pmodel,pp.pp_material) as PmodelDrawingNo
                            from Part_Plan pp 
                            left join base_productmodel pm on pp.pp_prodModelID=pm.ID
                            where pp.pp_deleteFlag=0 " + para;
            //sql += " order by pp.pp_startDate desc ";

            if (!string.IsNullOrEmpty(model.sort))
            {
                sql += " order by " + model.sort + " " + model.sortOrder;
            }

            List<PartPlanModel> list = db.ExecuteList<PartPlanModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 配件计划下发操作
        /// </summary>
        /// <param name="pp_orderCode">计划订单编码</param>
        public int IssuedPartPlan(string pp_orderCode, int UserID)
        {

            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                string sql = "";
                int pp_planQty = 0;

                try
                {

                    if (!string.IsNullOrEmpty(pp_orderCode))
                    {

                        #region 全删全查 确保数据唯一性
                        //如果驳回 全删全插
                        DataTable dtRequisitionmain = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from pms_requisitionmain where pp_orderCode = '" + pp_orderCode + "' ", null);
                        List<PmsRequisitionMainModel> RequisitionMainList = db.ToList<PmsRequisitionMainModel>(dtRequisitionmain);

                        for (int i = 0; i < RequisitionMainList.Count; i++)
                        {
                            sql = "delete from pms_requisitiondetail where pm_orderCode=@pm_orderCode";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pm_orderCode", RequisitionMainList[i].pm_orderCode));
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }

                        sql = "delete from pms_requisitionmain where pp_orderCode=@pp_orderCode";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        #endregion

                        #region 计划下发后修改状态并新增备料申请主、从表信息

                        //获取当前计划的订单编码 计划数量
                        DataTable dtPartPlan = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from part_plan where pp_orderCode = '" + pp_orderCode + "' ", null);
                        List<PartPlanModel> PartPlanList = db.ToList<PartPlanModel>(dtPartPlan);
                        if (PartPlanList != null && PartPlanList.Count > 0)
                        {
                            pp_planQty = Convert.ToInt32(PartPlanList[0].pp_planQty);
                        }
                        else
                        {
                            myTrans.Rollback();
                            return 0;
                        }

                        //获取当前订单下的备料计划数据
                        DataTable dtPartPlanStock = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from part_planstock where pp_orderCode = '" + pp_orderCode + "' ", null);
                        List<PartPlanStockModel> PartPlanStockList = db.ToList<PartPlanStockModel>(dtPartPlanStock);

                        //循环添加备料申请单
                        for (int i = 0; i < pp_planQty; i++)
                        {
                            #region 添加备料主表
                            string strPrmCode = "";
                            string prefix = "PM" + DateTime.Now.ToString("yyyyMMdd");
                            string lastID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text, "select pm_orderCode from pms_requisitionmain where pm_orderCode like '" + prefix + "%' order by pm_createTime desc", null) + "";
                            if (lastID == "")
                                strPrmCode = prefix + 1.ToString("0000");
                            else
                                strPrmCode = prefix + (Convert.ToInt32(lastID.Substring(lastID.Length - 4)) + 1).ToString("0000");

                            sql = @"insert into pms_requisitionmain (pm_orderCode,pp_orderCode,pm_status,pm_deleteFlag,pm_createTime,pm_createMan,pm_updateTime,pm_updateMan)
                                    values(@pm_orderCode,@pp_orderCode,0,0,@pm_createTime,@pm_createMan,@pm_updateTime,@pm_updateMan)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pm_orderCode", strPrmCode));
                            pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));
                            pList.Add(new MySqlParameter("@pm_createTime", DateTime.Now));
                            pList.Add(new MySqlParameter("@pm_createMan", UserID));
                            pList.Add(new MySqlParameter("@pm_updateTime", DateTime.Now));
                            pList.Add(new MySqlParameter("@pm_updateMan", UserID));
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                            #endregion

                            for (int j = 0; j < PartPlanStockList.Count; j++)
                            {
                                #region 添加备料从表
                                string strPrdCode = "";
                                string prefixPD = "PD" + DateTime.Now.ToString("yyyyMMdd");
                                string lastPDID = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text, "select pd_orderCode from pms_requisitiondetail where pd_orderCode like '" + prefixPD + "%' order by pd_createTime desc", null) + "";
                                if (lastPDID == "")
                                    strPrdCode = prefixPD + 1.ToString("0000");
                                else
                                    strPrdCode = prefixPD + (Convert.ToInt32(lastPDID.Substring(lastPDID.Length - 4)) + 1).ToString("0000");

                                sql = @"insert into pms_requisitiondetail (pd_orderCode,pm_orderCode,pd_materialID,pd_materialCode,pd_materialName,pd_qty,pd_operationID,pd_isMustReq,pd_remark,
                                        pd_status,pd_deleteFlag,pd_createTime,pd_createMan,pd_updateTime,pd_updateMan)
                                        values(@pd_orderCode,@pm_orderCode,@pd_materialID,@pd_materialCode,@pd_materialName,@pd_qty,@pd_operationID,@pd_isMustReq,@pd_remark,0,0,@pd_createTime,
                                        @pd_createMan,@pd_updateTime,@pd_updateMan)";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@pd_orderCode", strPrdCode));//备料从表单据号
                                pList.Add(new MySqlParameter("@pm_orderCode", strPrmCode));//备料主表单据号
                                pList.Add(new MySqlParameter("@pd_materialID", PartPlanStockList[j].ps_materialID));
                                pList.Add(new MySqlParameter("@pd_materialCode", PartPlanStockList[j].ps_materialCode));
                                pList.Add(new MySqlParameter("@pd_materialName", PartPlanStockList[j].ps_materialName));
                                pList.Add(new MySqlParameter("@pd_qty", PartPlanStockList[j].ps_qty));
                                pList.Add(new MySqlParameter("@pd_operationID", PartPlanStockList[j].ps_operationID));
                                pList.Add(new MySqlParameter("@pd_isMustReq", PartPlanStockList[j].ps_isMustReq));
                                pList.Add(new MySqlParameter("@pd_remark", PartPlanStockList[j].ps_remark));
                                pList.Add(new MySqlParameter("@pd_createTime", DateTime.Now));
                                pList.Add(new MySqlParameter("@pd_createMan", UserID));
                                pList.Add(new MySqlParameter("@pd_updateTime", DateTime.Now));
                                pList.Add(new MySqlParameter("@pd_updateMan", UserID));
                                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                                #endregion
                            }
                        }

                        sql = @"update Part_Plan set pp_status=1 where pp_orderCode=@pp_orderCode ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));//计划订单编码
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        #endregion
                    }
                    else
                    {
                        myTrans.Rollback();
                        return 0;
                    }

                    myTrans.Commit();
                    return ret;

                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }




        /// <summary>
        /// 更改计划状态 ，用于计划装配 开始 和 结束
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <param name="UserID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdatePartPlan(string pp_orderCode, int UserID, int status)
        {

            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                string sql = "";
                try
                {

                    //查询当前计划下产品信息表已完成的数量
                    DataTable dtProductInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from productinfo where pp_orderCode = '" + pp_orderCode + "' and pf_finishStatus = 1 ", null);
                    List<ProductInfoModel> ProductInfoList = db.ToList<ProductInfoModel>(dtProductInfo);

                    //状态等于3 将计划改为已完成状态，并且填写实际结束时间
                    if (status == 3)
                    {
                        //获取当前计划的订单编码 计划数量
                        DataTable dtPartPlan = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from part_plan where pp_orderCode = '" + pp_orderCode + "' ", null);
                        List<PartPlanModel> PartPlanList = db.ToList<PartPlanModel>(dtPartPlan);

                        if (ProductInfoList.Count == PartPlanList[0].pp_planQty)
                        {
                            if (!string.IsNullOrEmpty(pp_orderCode))
                            {
                                #region 修改计划状态

                                sql = @"update Part_Plan set pp_status=@pp_status,pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan,pp_resultEndTime=@pp_resultEndTime where pp_orderCode = @pp_orderCode ";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@pp_status", status));//计划状态
                                pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));//计划订单编码
                                pList.Add(new MySqlParameter("@pp_resultEndTime", DateTime.Now));//实际结束时间
                                pList.Add(new MySqlParameter("@pp_updateTime", DateTime.Now));//计划修改人时间
                                pList.Add(new MySqlParameter("@pp_updateMan", UserID));//计划修改人
                                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                                #endregion
                            }
                        }
                    }

                    //状态等于2 并且添加第一条产品信息时 将计划改为已开始状态，并且填写实际开始时间
                    if (status == 2 && ProductInfoList.Count == 0)
                    {
                        if (!string.IsNullOrEmpty(pp_orderCode))
                        {
                            #region 修改计划状态

                            sql = @"update Part_Plan set pp_status=@pp_status,pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan,pp_resultStartTime=@pp_resultStartTime where pp_orderCode = @pp_orderCode ";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pp_status", status));//计划状态
                            pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));//计划订单编码
                            pList.Add(new MySqlParameter("@pp_resultStartTime", DateTime.Now));//实际开始时间
                            pList.Add(new MySqlParameter("@pp_updateTime", DateTime.Now));//计划修改人时间
                            pList.Add(new MySqlParameter("@pp_updateMan", UserID));//计划修改人
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());


                            #endregion
                        }
                    }
                    myTrans.Commit();
                    return ret;

                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }

        }



        /// <summary>
        /// 计划状态修改（计划下达）（反下达）操作
        /// </summary>
        /// <param name="pp_orderCode">计划订单号</param>
        /// <param name="UserID">用户ID</param>
        /// <param name="status">修改状态  0: 未开始  1:已下发 2: 已开始 3：已完成 4：已驳回</param>
        /// <param name="Message">返回消息</param>
        /// <returns></returns>
        public int IssuedPartPlan(string pp_orderCode, int UserID, int status, out string Message)
        {

            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                string sql = "";
                string msg = "";

                try
                {

                    if (!string.IsNullOrEmpty(pp_orderCode))
                    {
                        //计划下达
                        if (status == 1)
                        {
                            //获取
                            DataTable dtPartPlan = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from Part_Plan where pp_orderCode = '" + pp_orderCode + "' ", null);
                            List<PartPlanModel> PartPlanList = db.ToList<PartPlanModel>(dtPartPlan);

                            if (PartPlanList != null)
                            {
                                if (PartPlanList.Count > 0 && PartPlanList[0].pp_materialPercent.HasValue)
                                {
                                    #region 计划下达后修改状态

                                    sql = @"update Part_Plan set pp_status=@pp_status,pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan where pp_orderCode = @pp_orderCode ";
                                    pList.Clear();
                                    pList.Add(new MySqlParameter("@pp_status", status));//计划状态
                                    pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));//计划订单编码
                                    pList.Add(new MySqlParameter("@pp_updateTime", DateTime.Now));//计划修改人时间
                                    pList.Add(new MySqlParameter("@pp_updateMan", UserID));//计划修改人
                                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                                    #endregion
                                }
                                else
                                {
                                    msg = "请齐套分析后，再下发计划！";
                                }
                            }
                            else
                            {
                                msg = "请齐套分析后，再下发计划！";
                            }
                        }
                        //反下达
                        if (status == 4)
                        {
                            #region 计划反下达后修改状态

                            sql = @"update Part_Plan set pp_status=@pp_status,pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan where pp_orderCode = @pp_orderCode ";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pp_status", status));//计划状态
                            pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));//计划订单编码
                            pList.Add(new MySqlParameter("@pp_updateTime", DateTime.Now));//计划修改人时间
                            pList.Add(new MySqlParameter("@pp_updateMan", UserID));//计划修改人
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                            #endregion
                        }



                    }

                    myTrans.Commit();
                    Message = msg;
                    return ret;

                }
                catch
                {
                    myTrans.Rollback();
                    Message = msg;
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }

        //object locks = new object();

        /// <summary>
        /// 保存配件计划主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveCopyPlan(PartPlanModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    //根据当前产品型号（图号）获取所有工序信息
                    List<Base_PartGongxuModel> PartGongxuList = db.ExecuteList<Base_PartGongxuModel>("select * from base_partGongxu where prodModelID = '" + model.pp_prodModelID + "' and deleteFlag = 0 ", null);

                    if (string.IsNullOrEmpty(model.pp_orderCode))
                    {
                        #region 新增配件计划

                        string strPlanCode = "";
                        strPlanCode = db.GetSerialNumber("Part_Plan", "PP", 4);//调用存储过程获取流水号

                        model.pp_bizDate = DateTime.Now;
                        model.pp_status = 0;
                        model.pp_deleteFlag = 0;
                        model.pp_createTime = DateTime.Now;

                        sql = @"insert into Part_Plan(pp_orderCode,pp_orderCodeRel,pp_storageOrgUnit,pp_transactionType,pp_bizDate,pp_material,pp_project,pp_trackNumber,pp_prodModelID,pp_status,
                                        pp_planQty,pp_startDate,pp_finishDate,pp_description,pp_adminOrgUnitID,pp_remark,pp_deleteFlag,pp_createTime,pp_createMan,pp_updateTime,pp_updateMan,
                                        pp_projectName,pp_wagonNo) 
                                        values(@pp_orderCode,@pp_orderCodeRel,@pp_storageOrgUnit,@pp_transactionType,@pp_bizDate,@pp_material,@pp_project,@pp_trackNumber,@pp_prodModelID,@pp_status,
                                        @pp_planQty,@pp_startDate,@pp_finishDate,@pp_description,@pp_adminOrgUnitID,@pp_remark,@pp_deleteFlag,@pp_createTime,@pp_createMan,@pp_updateTime,@pp_updateMan,
                                        @pp_projectName,@pp_wagonNo) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCode", strPlanCode));
                        pList.Add(new MySqlParameter("@pp_orderCodeRel", model.pp_orderCodeRel));//第三方系统关联订单编码
                        pList.Add(new MySqlParameter("@pp_storageOrgUnit", model.pp_storageOrgUnit));
                        pList.Add(new MySqlParameter("@pp_transactionType", model.pp_transactionType));
                        pList.Add(new MySqlParameter("@pp_bizDate", model.pp_bizDate));//业务日期
                        pList.Add(new MySqlParameter("@pp_material", model.pp_material));
                        pList.Add(new MySqlParameter("@pp_project", model.pp_project));
                        pList.Add(new MySqlParameter("@pp_trackNumber", model.pp_trackNumber));
                        pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
                        pList.Add(new MySqlParameter("@pp_status", model.pp_status));
                        pList.Add(new MySqlParameter("@pp_planQty", model.pp_planQty));
                        pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
                        pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate));
                        pList.Add(new MySqlParameter("@pp_description", model.pp_description));
                        pList.Add(new MySqlParameter("@pp_adminOrgUnitID", model.pp_adminOrgUnitID));
                        pList.Add(new MySqlParameter("@pp_remark", model.pp_remark));
                        pList.Add(new MySqlParameter("@pp_deleteFlag", model.pp_deleteFlag));
                        pList.Add(new MySqlParameter("@pp_createTime", model.pp_createTime));
                        pList.Add(new MySqlParameter("@pp_createMan", model.pp_createMan));
                        pList.Add(new MySqlParameter("@pp_updateTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_updateMan", model.pp_updateMan));
                        pList.Add(new MySqlParameter("@pp_projectName", model.pp_projectName));
                        pList.Add(new MySqlParameter("@pp_wagonNo", model.pp_wagonNo));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion

                        #region 根据配置工序维护表中数据循环保存 配件计划工序表

                        for (int i = 0; i < PartGongxuList.Count; i++)
                        {
                            //根据当前产品型号（图号）获取所有工序信息
                            List<BaseEBOMModel> BOMList = db.ExecuteList<BaseEBOMModel>("select ebom.*,m.mName ebChildName,m.mDrawingNo ChildDrawingNo from base_EBOM ebom left join base_material m on ebom.ebChildID = m.ID where ebOperationID = '" + PartGongxuList[i].ID + "' and (ebParentID <> NULL || ebParentID <> 0)", null);

                            string strTechnicsCode = "";
                            strTechnicsCode = db.GetSerialNumber("Part_PlanTechnics", "PT", 4);//调用存储过程获取流水号

                            sql = @"insert into Part_PlanTechnics(pt_orderCode,pp_orderCode,pt_orderCodeRel,pt_entrustType,pt_workCenterCode,pt_workCenterName,pt_operationID,pt_isCheckPoint,pt_isReportPoint,
                                pt_isPickingPoint,pt_entrustSupplierCode,pt_taiweiCode,pt_opertionAlias,pt_proInstruction,pt_remark,pt_status,pt_deleteFlag,pt_createTime,pt_createMan,pt_updateTime,pt_updateMan) 
                                values(@pt_orderCode,@pp_orderCode,@pt_orderCodeRel,@pt_entrustType,@pt_workCenterCode,@pt_workCenterName,@pt_operationID,@pt_isCheckPoint,@pt_isReportPoint,@pt_isPickingPoint,
                                @pt_entrustSupplierCode,@pt_taiweiCode,@pt_opertionAlias,@pt_proInstruction,@pt_remark,@pt_status,@pt_deleteFlag,@pt_createTime,@pt_createMan,@pt_updateTime,@pt_updateMan) ";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pt_orderCode", strTechnicsCode));
                            pList.Add(new MySqlParameter("@pp_orderCode", strPlanCode));
                            pList.Add(new MySqlParameter("@pt_orderCodeRel", model.pp_orderCodeRel));//第三方系统关联订单编码
                            pList.Add(new MySqlParameter("@pt_entrustType", PartGongxuList[i].entrustType));
                            pList.Add(new MySqlParameter("@pt_workCenterCode", PartGongxuList[i].workCenterCode));
                            pList.Add(new MySqlParameter("@pt_workCenterName", PartGongxuList[i].workCenterName));
                            pList.Add(new MySqlParameter("@pt_operationID", PartGongxuList[i].ID));
                            pList.Add(new MySqlParameter("@pt_isCheckPoint", PartGongxuList[i].isCheckPoint));
                            pList.Add(new MySqlParameter("@pt_isReportPoint", PartGongxuList[i].isReportPoint));
                            pList.Add(new MySqlParameter("@pt_isPickingPoint", PartGongxuList[i].isPickingPoint));
                            pList.Add(new MySqlParameter("@pt_entrustSupplierCode", PartGongxuList[i].entrustSupplierCode));
                            pList.Add(new MySqlParameter("@pt_taiweiCode", PartGongxuList[i].taiweiCode));
                            pList.Add(new MySqlParameter("@pt_opertionAlias", PartGongxuList[i].opertionAlias));
                            pList.Add(new MySqlParameter("@pt_proInstruction", PartGongxuList[i].proInstruction));
                            pList.Add(new MySqlParameter("@pt_remark", ""));
                            pList.Add(new MySqlParameter("@pt_status", 0));
                            pList.Add(new MySqlParameter("@pt_deleteFlag", model.pp_deleteFlag));
                            pList.Add(new MySqlParameter("@pt_createTime", DateTime.Now));
                            pList.Add(new MySqlParameter("@pt_createMan", model.pp_createMan));
                            pList.Add(new MySqlParameter("@pt_updateTime", DateTime.Now));
                            pList.Add(new MySqlParameter("@pt_updateMan", model.pp_updateMan));
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                            for (int j = 0; j < BOMList.Count; j++)
                            {
                                string strStockCode = "";
                                strStockCode = db.GetSerialNumber("part_planstock", "PS", 4);//调用存储过程获取流水号

                                sql = @"insert into part_planstock(ps_orderCode,pp_orderCode,ps_orderCodeRel,ps_materialID,ps_materialCode,ps_materialName,ps_unitCode,ps_qty,
                                ps_issueMode,ps_operationID,ps_operationNo,ps_storageOrgUnitCode,ps_unitQty,ps_provideType,ps_isMustReq,ps_plannedQty,ps_flow,
                                ps_remark,ps_status,ps_deleteFlag,ps_createTime,ps_createMan,ps_updateTime,ps_updateMan) 
                                values(@ps_orderCode,@pp_orderCode,@ps_orderCodeRel,@ps_materialID,@ps_materialCode,@ps_materialName,@ps_unitCode,@ps_qty,
                                @ps_issueMode,@ps_operationID,@ps_operationNo,@ps_storageOrgUnitCode,@ps_unitQty,@ps_provideType,@ps_isMustReq,@ps_plannedQty,@ps_flow,
                                @ps_remark,@ps_status,@ps_deleteFlag,@ps_createTime,@ps_createMan,@ps_updateTime,@ps_updateMan) ";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@ps_orderCode", strStockCode));
                                pList.Add(new MySqlParameter("@pp_orderCode", strPlanCode));
                                pList.Add(new MySqlParameter("@ps_orderCodeRel", model.pp_orderCodeRel));//第三方系统关联订单编码
                                pList.Add(new MySqlParameter("@ps_materialID", BOMList[j].ebChildID));
                                pList.Add(new MySqlParameter("@ps_materialCode", BOMList[j].ChildDrawingNo));
                                pList.Add(new MySqlParameter("@ps_materialName", BOMList[j].ebChildName));
                                pList.Add(new MySqlParameter("@ps_unitCode", ""));//计量单位_编码
                                pList.Add(new MySqlParameter("@ps_qty", BOMList[j].ebQty));
                                pList.Add(new MySqlParameter("@ps_issueMode", 11010));//领送料方式
                                pList.Add(new MySqlParameter("@ps_operationID", PartGongxuList[i].ID));
                                pList.Add(new MySqlParameter("@ps_operationNo", PartGongxuList[i].operationNo));//工序号
                                pList.Add(new MySqlParameter("@ps_storageOrgUnitCode", "1.41.01"));//备料供货库存组织编码
                                pList.Add(new MySqlParameter("@ps_unitQty", BOMList[j].ebQty));//备料单位用量
                                pList.Add(new MySqlParameter("@ps_provideType", 10930));//备料供应类型
                                pList.Add(new MySqlParameter("@ps_isMustReq", 1));//备料是否必领料 目前都为必领料，后期改为获取BOM表信息
                                pList.Add(new MySqlParameter("@ps_plannedQty", (ConvertHelper.ToInt32(model.pp_planQty, 0) * BOMList[j].ebQty)));//备料计划被用量
                                pList.Add(new MySqlParameter("@ps_flow", ""));// model.ps_flow备料流程
                                pList.Add(new MySqlParameter("@ps_remark", ""));
                                pList.Add(new MySqlParameter("@ps_status", 0));
                                pList.Add(new MySqlParameter("@ps_deleteFlag", model.pp_deleteFlag));
                                pList.Add(new MySqlParameter("@ps_createTime", DateTime.Now));
                                pList.Add(new MySqlParameter("@ps_createMan", model.pp_createMan));
                                pList.Add(new MySqlParameter("@ps_updateTime", DateTime.Now));
                                pList.Add(new MySqlParameter("@ps_updateMan", model.pp_updateMan));
                                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                            }


                        }

                        #endregion

                    }

                    myTrans.Commit();
                    return ret;
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }





        /// <summary>
        ///逻辑删除 计划、计划工序、计划备料
        /// </summary>
        /// <param name="ids"></param>
        public int DeletePartPlan(string[] ids)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                var time = DateTime.Now;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";
                    var pp_orderCode = string.Join(",", ids.Select(f => $"'{f}'"));

                    #region 删除计划备料
                    sql = @"update Part_PlanStock set ps_deleteFlag=1 where pp_orderCode in(" + pp_orderCode + ")";
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, null);
                    #endregion

                    #region 删除计划工序
                    sql = @"update Part_PlanTechnics set pt_deleteFlag=1 where pp_orderCode in(" + pp_orderCode + ")";
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, null);
                    #endregion

                    #region 删除计划
                    sql = @"update part_plan set pp_deleteFlag=1 where pp_orderCode in(" + pp_orderCode + ")";
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, null);
                    #endregion

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }


        #endregion

        #region 配件计划工序管理 LHR 2020-03-12

        /// <summary>
        /// 配件计划工序管理 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanTechnicsModel> GetPartPlanTechnicsList(PartPlanTechnicsModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKEptorderCode))
            {
                para += " and pt.pt_orderCode like CONCAT('%',@LIKEptorderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEptorderCode", model.LIKEptorderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEpporderCode))
            {
                para += " and pt.pp_orderCode like CONCAT('%',@LIKEpporderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpporderCode", model.LIKEpporderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEptorderCodeRel))
            {
                para += " and pt.pt_orderCodeRel like CONCAT('%',@LIKEptorderCodeRel,'%') ";
                pList.Add(new MySqlParameter("@LIKEptorderCodeRel", model.LIKEptorderCodeRel.Trim()));
            }

            if (model.pt_entrustType.HasValue && model.pt_entrustType.Value != 0)
            {
                para += " and pt.pt_entrustType=@pt_entrustType ";
                pList.Add(new MySqlParameter("@pt_entrustType", model.pt_entrustType));
            }

            string sql = @"select Count(*) from Part_PlanTechnics pt
                    left join base_partgongxu bpgx on pt.pt_operationID = bpgx.ID
                    left join part_plan pp on pt.pp_orderCode = pp.pp_orderCode
                    left join base_productmodel pm on pp.pp_prodModelID=pm.ID 
                    where pt.pt_deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select pt.*,GetbdNameBybdID(pt.pt_entrustType) as entrustTypeName,bpgx.operationNo,bpgx.operationName,bpgx.operationCode,pp.pp_status from Part_PlanTechnics pt
                    left join base_partgongxu bpgx on pt.pt_operationID = bpgx.ID
                    left join part_plan pp on pt.pp_orderCode = pp.pp_orderCode
                    left join base_productmodel pm on pp.pp_prodModelID=pm.ID 
                    where pt.pt_deleteFlag=0 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<PartPlanTechnicsModel> list = db.ExecuteList<PartPlanTechnicsModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 保存配件计划工序表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePartPlanTechnics(PartPlanTechnicsModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    if (string.IsNullOrEmpty(model.pt_orderCode))
                    {
                        #region 新增
                        string strTechnicsCode = "";
                        strTechnicsCode = db.GetSerialNumber("Part_PlanTechnics", "PT", 4);//调用存储过程获取流水号

                        model.pt_deleteFlag = 0;
                        model.pt_createTime = DateTime.Now;

                        sql = @"insert into Part_PlanTechnics(pt_orderCode,pp_orderCode,pt_orderCodeRel,pt_entrustType,pt_workCenterCode,pt_workCenterName,pt_operationID,pt_isCheckPoint,pt_isReportPoint,
                                pt_isPickingPoint,pt_entrustSupplierCode,pt_taiweiCode,pt_opertionAlias,pt_proInstruction,pt_remark,pt_status,pt_deleteFlag,pt_createTime,pt_createMan,pt_updateTime,pt_updateMan) 
                                values(@pt_orderCode,@pp_orderCode,@pt_orderCodeRel,@pt_entrustType,@pt_workCenterCode,@pt_workCenterName,@pt_operationID,@pt_isCheckPoint,@pt_isReportPoint,@pt_isPickingPoint,
                                @pt_entrustSupplierCode,@pt_taiweiCode,@pt_opertionAlias,@pt_proInstruction,@pt_remark,@pt_status,@pt_deleteFlag,@pt_createTime,@pt_createMan,@pt_updateTime,@pt_updateMan) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pt_orderCode", strTechnicsCode));
                        pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));//第三方系统关联订单编码
                        pList.Add(new MySqlParameter("@pt_orderCodeRel", model.pt_orderCodeRel));
                        pList.Add(new MySqlParameter("@pt_entrustType", model.pt_entrustType));
                        pList.Add(new MySqlParameter("@pt_workCenterCode", model.pt_workCenterCode));
                        pList.Add(new MySqlParameter("@pt_workCenterName", model.pt_workCenterName));
                        pList.Add(new MySqlParameter("@pt_operationID", model.pt_operationID));
                        pList.Add(new MySqlParameter("@pt_isCheckPoint", model.pt_isCheckPoint));
                        pList.Add(new MySqlParameter("@pt_isReportPoint", model.pt_isReportPoint));
                        pList.Add(new MySqlParameter("@pt_isPickingPoint", model.pt_isPickingPoint));
                        pList.Add(new MySqlParameter("@pt_entrustSupplierCode", model.pt_entrustSupplierCode));
                        pList.Add(new MySqlParameter("@pt_taiweiCode", model.pt_taiweiCode));
                        pList.Add(new MySqlParameter("@pt_opertionAlias", model.pt_opertionAlias));
                        pList.Add(new MySqlParameter("@pt_proInstruction", model.pt_proInstruction));
                        pList.Add(new MySqlParameter("@pt_remark", model.pt_remark));
                        pList.Add(new MySqlParameter("@pt_status", 0));
                        pList.Add(new MySqlParameter("@pt_deleteFlag", model.pt_deleteFlag));
                        pList.Add(new MySqlParameter("@pt_createTime", model.pt_createTime));
                        pList.Add(new MySqlParameter("@pt_createMan", model.pt_createMan));
                        pList.Add(new MySqlParameter("@pt_updateTime", model.pt_updateTime));
                        pList.Add(new MySqlParameter("@pt_updateMan", model.pt_updateMan));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }
                    else
                    {

                        model.pt_updateTime = DateTime.Now;
                        #region 编辑
                        sql = @"update Part_PlanTechnics set pp_orderCode=@pp_orderCode,pt_orderCodeRel=@pt_orderCodeRel,pt_entrustType=@pt_entrustType,pt_workCenterCode=@pt_workCenterCode,
                                pt_workCenterName=@pt_workCenterName,pt_operationID=@pt_operationID,pt_isCheckPoint=@pt_isCheckPoint,pt_isReportPoint=@pt_isReportPoint,
                                pt_isPickingPoint=@pt_isPickingPoint,pt_entrustSupplierCode=@pt_entrustSupplierCode,pt_taiweiCode=@pt_taiweiCode,pt_opertionAlias=@pt_opertionAlias,
                                pt_proInstruction=@pt_proInstruction,pt_remark=@pt_remark.pt_status=@pt_status,pt_updateTime=@pt_updateTime,pt_updateMan=@pt_updateMan where pt_orderCode=@pt_orderCode ";

                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));//第三方系统关联订单编码
                        pList.Add(new MySqlParameter("@pt_orderCodeRel", model.pt_orderCodeRel));
                        pList.Add(new MySqlParameter("@pt_entrustType", model.pt_entrustType));
                        pList.Add(new MySqlParameter("@pt_workCenterCode", model.pt_workCenterCode));
                        pList.Add(new MySqlParameter("@pt_workCenterName", model.pt_workCenterName));
                        pList.Add(new MySqlParameter("@pt_operationID", model.pt_operationID));
                        pList.Add(new MySqlParameter("@pt_isCheckPoint", model.pt_isCheckPoint));
                        pList.Add(new MySqlParameter("@pt_isReportPoint", model.pt_isReportPoint));
                        pList.Add(new MySqlParameter("@pt_isPickingPoint", model.pt_isPickingPoint));
                        pList.Add(new MySqlParameter("@pt_entrustSupplierCode", model.pt_entrustSupplierCode));
                        pList.Add(new MySqlParameter("@pt_taiweiCode", model.pt_taiweiCode));
                        pList.Add(new MySqlParameter("@pt_opertionAlias", model.pt_opertionAlias));
                        pList.Add(new MySqlParameter("@pt_proInstruction", model.pt_proInstruction));
                        pList.Add(new MySqlParameter("@pt_remark", model.pt_remark));
                        pList.Add(new MySqlParameter("@pt_status", model.pt_status));
                        pList.Add(new MySqlParameter("@pt_updateTime", model.pt_updateTime));
                        pList.Add(new MySqlParameter("@pt_updateMan", model.pt_updateMan));
                        pList.Add(new MySqlParameter("@pt_orderCode", model.pt_orderCode));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }


        /// <summary>
        /// 配件计划工序管理查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanTechnicsModel> GetPartPlanTechnicsList(PartPlanTechnicsModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                para += " and pt.pp_orderCode like CONCAT('%',@pp_orderCode,'%') ";
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
            }
            if (model.pt_status.HasValue && model.pt_status != -1)
            {
                para += " and pt.pt_status = @pt_status ";
                pList.Add(new MySqlParameter("@pt_status", model.pt_status));
            }
            string sql = @"select pt.*,GetbdNameBybdID(pt.pt_entrustType) as entrustTypeName,bpgx.operationNo,bpgx.operationName,bpgx.operationCode from Part_PlanTechnics pt
                    left join base_partgongxu bpgx on pt.pt_operationID = bpgx.ID
                    left join part_plan pp on pt.pp_orderCode = pp.pp_orderCode
                    left join base_productmodel pm on pp.pp_prodModelID=pm.ID 
                    where pt.pt_deleteFlag = 0 " + para;
            sql += " order by CONVERT(bpgx.operationNo,SIGNED) asc ";
            //CAST(pgx.operationNo as SIGNED) 解决Mysql数据库varchar排序数值问题
            List<PartPlanTechnicsModel> list = db.ExecuteList<PartPlanTechnicsModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 配件计划工序详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanTechnicsModel> GetPartPlanTechnicsSelctList(PartPlanTechnicsModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKEptorderCode))
            {
                para += " and pt.pt_orderCode like CONCAT('%',@LIKEptorderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEptorderCode", model.LIKEptorderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEpporderCode))
            {
                para += " and pt.pp_orderCode like CONCAT('%',@LIKEpporderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpporderCode", model.LIKEpporderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEptorderCodeRel))
            {
                para += " and pt.pt_orderCodeRel like CONCAT('%',@LIKEptorderCodeRel,'%') ";
                pList.Add(new MySqlParameter("@LIKEptorderCodeRel", model.LIKEptorderCodeRel.Trim()));
            }

            if (model.pt_entrustType.HasValue && model.pt_entrustType.Value != 0)
            {
                para += " and pt.pt_entrustType=@pt_entrustType ";
                pList.Add(new MySqlParameter("@pt_entrustType", model.pt_entrustType));
            }

            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                para += " and pt.pp_orderCode like CONCAT('%',@pp_orderCode,'%') ";
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
            }

            string sql = @"select Count(*) from Part_PlanTechnics pt
                    left join base_partgongxu bpgx on pt.pt_operationID = bpgx.ID
                    left join part_plan pp on pt.pp_orderCode = pp.pp_orderCode
                    left join base_productmodel pm on pp.pp_prodModelID=pm.ID 
                    where pt.pt_deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select pt.*,GetbdNameBybdID(pt.pt_entrustType) as entrustTypeName,bpgx.operationNo,bpgx.operationName,bpgx.operationCode from Part_PlanTechnics pt
                    left join base_partgongxu bpgx on pt.pt_operationID = bpgx.ID
                    left join part_plan pp on pt.pp_orderCode = pp.pp_orderCode
                    left join base_productmodel pm on pp.pp_prodModelID=pm.ID 
                    where pt.pt_deleteFlag=0 " + para;
            sql += " order by CONVERT(bpgx.operationNo,SIGNED) asc limit " + model.PageIndex + "," + model.PageSize;
            //CAST(pgx.operationNo as SIGNED) 解决Mysql数据库varchar排序数值问题
            List<PartPlanTechnicsModel> list = db.ExecuteList<PartPlanTechnicsModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        ///逻辑删除 计划工序以及工序下所有计划备料
        /// </summary>
        /// <param name="ids"></param>
        public int DeletePlanTechnics(string[] ids)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                var time = DateTime.Now;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    #region 循环删除计划备料
                    foreach (string item in ids)
                    {
                        DataTable ptdt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from Part_PlanTechnics where pt_orderCode= '" + item + "' ", null);
                        List<PartPlanTechnicsModel> dtptList = db.ToList<PartPlanTechnicsModel>(ptdt);

                        sql = @"update Part_PlanStock set ps_deleteFlag=1 where pp_orderCode=@pp_orderCode and ps_operationID=@ps_operationID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCode", dtptList[0].pp_orderCode));
                        pList.Add(new MySqlParameter("@ps_operationID", dtptList[0].pt_operationID));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    }
                    #endregion

                    var pt_orderCode = string.Join(",", ids.Select(f => $"'{f}'"));
                    sql = @"update Part_PlanTechnics set pt_deleteFlag=1 where pt_orderCode in(" + pt_orderCode + ")";
                    pList.Clear();
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }


        #endregion

        #region 配件计划备料 管理 LHR 2020-03-16


        /// <summary>
        /// 配件计划备料管理 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKEpporderCode))
            {
                para += " and ps.pp_orderCode like CONCAT('%',@LIKEpporderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpporderCode", model.LIKEpporderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEpsorderCode))
            {
                para += " and ps.ps_orderCode like CONCAT('%',@LIKEpsorderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpsorderCode", model.LIKEpsorderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEpsorderCodeRel))
            {
                para += " and ps.ps_orderCodeRel like CONCAT('%',@LIKEpsorderCodeRel,'%') ";
                pList.Add(new MySqlParameter("@LIKEpsorderCodeRel", model.LIKEpsorderCodeRel.Trim()));
            }

            //if (model.pt_entrustType.HasValue && model.pt_entrustType.Value != 0)
            //{
            //    para += " and ps.pt_entrustType=@pt_entrustType ";
            //    pList.Add(new MySqlParameter("@pt_entrustType", model.pt_entrustType));
            //}
            if (model.ps_operationID.HasValue && model.ps_operationID != 0)
            {
                para += " and ps.ps_operationID = @ps_operationID ";
                pList.Add(new MySqlParameter("@ps_operationID", model.ps_operationID));
            }

            string sql = @"select Count(*) from part_planstock ps
                    left join part_plan pp on ps.pp_orderCode = pp.pp_orderCode
				    left join base_ebom ebom on ps.ps_materialID = ebom.ebChildID and ebom.ebOperationID = 1 and (ebParentID <> NULL || ebParentID <> 0 )
                    where ps.ps_deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select ps.*,GetIssueModeBybdvalue(ps.ps_issueMode) as issueModeText,GetProvideTypeBybdvalue(ps.ps_provideType) provideTypeText,pp.pp_status  from part_planstock ps
                    left join part_plan pp on ps.pp_orderCode = pp.pp_orderCode
					left join base_ebom ebom on ps.ps_materialID = ebom.ebChildID and ebom.ebOperationID = 1 and (ebParentID <> NULL || ebParentID <> 0 )
                    where ps.ps_deleteFlag=0 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<PartPlanStockModel> list = db.ExecuteList<PartPlanStockModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 配件计划备料管理 查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                para += " and ps.pp_orderCode like CONCAT('%',@pp_orderCode,'%') ";
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
            }
            if (model.ps_operationID.HasValue && model.ps_operationID != 0)
            {
                para += " and ps.ps_operationID = @ps_operationID ";
                pList.Add(new MySqlParameter("@ps_operationID", model.ps_operationID));
            }
            if (model.ps_status.HasValue && model.ps_status != -1)
            {
                para += " and ps.ps_status = @ps_status ";
                pList.Add(new MySqlParameter("@ps_status", model.ps_status));
            }

            if (!string.IsNullOrEmpty(model.LIKEps_materialCode))
            {
                para += " and ps.ps_materialCode like CONCAT('%',@LIKEps_materialCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEps_materialCode", model.LIKEps_materialCode.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEps_materialName))
            {
                para += " and ps.ps_materialName like CONCAT('%',@LIKEps_materialName,'%') ";
                pList.Add(new MySqlParameter("@LIKEps_materialName", model.LIKEps_materialName.Trim()));
            }

            if (!string.IsNullOrEmpty(model.paraStr))
            {
                para += " and ps.ps_status in (" + model.paraStr + ") ";
            }

            string sql = @"select ps.*,GetIssueModeBybdvalue(ps.ps_issueMode) as issueModeText,GetProvideTypeBybdvalue(ps.ps_provideType) provideTypeText  from part_planstock ps
                    left join part_plan pp on ps.pp_orderCode = pp.pp_orderCode
					left join base_ebom ebom on ps.ps_materialID = ebom.ebChildID and ebom.ebOperationID = 1 and (ebParentID <> NULL || ebParentID <> 0 )
                    where ps.ps_deleteFlag=0 " + para;
            //CAST(pgx.operationNo as SIGNED) 解决Mysql数据库varchar排序数值问题
            List<PartPlanStockModel> list = db.ExecuteList<PartPlanStockModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 保存配件计划备料表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePartPlanStock(PartPlanStockModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    if (string.IsNullOrEmpty(model.ps_orderCode))
                    {
                        #region 新增
                        string strStockCode = "";
                        strStockCode = db.GetSerialNumber("part_planstock", "PS", 4);//调用存储过程获取流水号

                        model.ps_deleteFlag = 0;
                        model.ps_createTime = DateTime.Now;

                        sql = @"insert into part_planstock(ps_orderCode,pp_orderCode,ps_orderCodeRel,ps_materialID,ps_materialCode,ps_materialName,ps_unitCode,ps_qty,
                                ps_issueMode,ps_operationID,ps_operationNo,ps_storageOrgUnitCode,ps_unitQty,ps_provideType,ps_isMustReq,ps_plannedQty,ps_flow,
                                ps_remark,ps_deleteFlag,ps_createTime,ps_createMan,ps_updateTime,ps_updateMan) 
                                values(@ps_orderCode,@pp_orderCode,@ps_orderCodeRel,@ps_materialID,@ps_materialCode,@ps_materialName,@ps_unitCode,@ps_qty,
                                @ps_issueMode,@ps_operationID,@ps_operationNo,@ps_storageOrgUnitCode,@ps_unitQty,@ps_provideType,@ps_isMustReq,@ps_plannedQty,@ps_flow,
                                @ps_remark,@ps_deleteFlag,@ps_createTime,@ps_createMan,@ps_updateTime,@ps_updateMan) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ps_orderCode", strStockCode));
                        pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
                        pList.Add(new MySqlParameter("@ps_orderCodeRel", model.ps_orderCodeRel));
                        pList.Add(new MySqlParameter("@ps_materialID", model.ps_materialID));
                        pList.Add(new MySqlParameter("@ps_materialCode", model.ps_materialCode));
                        pList.Add(new MySqlParameter("@ps_materialName", model.ps_materialName));
                        pList.Add(new MySqlParameter("@ps_unitCode", model.ps_unitCode));
                        pList.Add(new MySqlParameter("@ps_qty", model.ps_qty));
                        pList.Add(new MySqlParameter("@ps_issueMode", model.ps_issueMode));
                        pList.Add(new MySqlParameter("@ps_operationID", model.ps_operationID));
                        pList.Add(new MySqlParameter("@ps_operationNo", model.ps_operationNo));
                        pList.Add(new MySqlParameter("@ps_storageOrgUnitCode", model.ps_storageOrgUnitCode));
                        pList.Add(new MySqlParameter("@ps_unitQty", model.ps_unitQty));
                        pList.Add(new MySqlParameter("@ps_provideType", model.ps_provideType));
                        pList.Add(new MySqlParameter("@ps_isMustReq", model.ps_isMustReq));
                        pList.Add(new MySqlParameter("@ps_plannedQty", model.ps_plannedQty));
                        pList.Add(new MySqlParameter("@ps_flow", model.ps_flow));
                        pList.Add(new MySqlParameter("@ps_remark", model.ps_remark));
                        pList.Add(new MySqlParameter("@ps_deleteFlag", model.ps_deleteFlag));
                        pList.Add(new MySqlParameter("@ps_createTime", model.ps_createTime));
                        pList.Add(new MySqlParameter("@ps_createMan", model.ps_createMan));
                        pList.Add(new MySqlParameter("@ps_updateTime", model.ps_updateTime));
                        pList.Add(new MySqlParameter("@ps_updateMan", model.ps_updateMan));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }
                    else
                    {

                        model.ps_updateTime = DateTime.Now;
                        #region 编辑
                        sql = @"update part_planstock set pp_orderCode=@pp_orderCode,ps_orderCodeRel=@ps_orderCodeRel,ps_materialID=@ps_materialID,
                                ps_materialCode=@ps_materialCode,ps_materialName=@ps_materialName,ps_unitCode=@ps_unitCode,ps_qty=@ps_qty,ps_issueMode=@ps_issueMode,ps_operationID=@ps_operationID,
                                ps_operationNo=@ps_operationNo,ps_storageOrgUnitCode=@ps_storageOrgUnitCode,ps_unitQty=@ps_unitQty,ps_provideType=@ps_provideType,ps_isMustReq=@ps_isMustReq,
                                ps_plannedQty=@ps_plannedQty,ps_flow=@ps_flow,ps_remark=@ps_remark,ps_updateTime=@ps_updateTime,ps_updateMan=@ps_updateMan where ps_orderCode=@ps_orderCode ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
                        pList.Add(new MySqlParameter("@ps_orderCodeRel", model.ps_orderCodeRel));
                        pList.Add(new MySqlParameter("@ps_materialID", model.ps_materialID));
                        pList.Add(new MySqlParameter("@ps_materialCode", model.ps_materialCode));
                        pList.Add(new MySqlParameter("@ps_materialName", model.ps_materialName));
                        pList.Add(new MySqlParameter("@ps_unitCode", model.ps_unitCode));
                        pList.Add(new MySqlParameter("@ps_qty", model.ps_qty));
                        pList.Add(new MySqlParameter("@ps_issueMode", model.ps_issueMode));
                        pList.Add(new MySqlParameter("@ps_operationID", model.ps_operationID));
                        pList.Add(new MySqlParameter("@ps_operationNo", model.ps_operationNo));
                        pList.Add(new MySqlParameter("@ps_storageOrgUnitCode", model.ps_storageOrgUnitCode));
                        pList.Add(new MySqlParameter("@ps_unitQty", model.ps_unitQty));
                        pList.Add(new MySqlParameter("@ps_provideType", model.ps_provideType));
                        pList.Add(new MySqlParameter("@ps_isMustReq", model.ps_isMustReq));
                        pList.Add(new MySqlParameter("@ps_plannedQty", model.ps_plannedQty));
                        pList.Add(new MySqlParameter("@ps_flow", model.ps_flow));
                        pList.Add(new MySqlParameter("@ps_remark", model.ps_remark));
                        pList.Add(new MySqlParameter("@ps_updateTime", model.ps_updateTime));
                        pList.Add(new MySqlParameter("@ps_updateMan", model.ps_updateMan));
                        pList.Add(new MySqlParameter("@ps_orderCode", model.ps_orderCode));
                        ret = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        #endregion
                    }

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }







        /// <summary>
        /// 配件计划备料详情查询 用于bootstrap-table加载
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockSelctList(PartPlanStockModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKEpporderCode))
            {
                para += " and ps.pp_orderCode like CONCAT('%',@LIKEpporderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpporderCode", model.LIKEpporderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEpsorderCode))
            {
                para += " and ps.ps_orderCode like CONCAT('%',@LIKEpsorderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEpsorderCode", model.LIKEpsorderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEpsorderCodeRel))
            {
                para += " and ps.ps_orderCodeRel like CONCAT('%',@LIKEpsorderCodeRel,'%') ";
                pList.Add(new MySqlParameter("@LIKEpsorderCodeRel", model.LIKEpsorderCodeRel.Trim()));
            }

            if (model.ps_operationID.HasValue && model.ps_operationID != 0)
            {
                para += " and ps.ps_operationID = @ps_operationID ";
                pList.Add(new MySqlParameter("@ps_operationID", model.ps_operationID));
            }

            string sql = @"select Count(*) from part_planstock ps
                    left join part_plan pp on ps.pp_orderCode = pp.pp_orderCode
				    left join base_ebom ebom on ps.ps_materialID = ebom.ebChildID and ebom.ebOperationID = 1 and (ebParentID <> NULL || ebParentID <> 0 )
                    where ps.ps_deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select ps.*,GetIssueModeBybdvalue(ps.ps_issueMode) as issueModeText,GetProvideTypeBybdvalue(ps.ps_provideType) provideTypeText  from part_planstock ps
                    left join part_plan pp on ps.pp_orderCode = pp.pp_orderCode
					left join base_ebom ebom on ps.ps_materialID = ebom.ebChildID and ebom.ebOperationID = 1 and (ebParentID <> NULL || ebParentID <> 0 )
                    where ps.ps_deleteFlag=0 " + para;
            sql += "limit " + model.PageIndex + "," + model.PageSize;
            List<PartPlanStockModel> list = db.ExecuteList<PartPlanStockModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 逻辑删除 计划备料
        /// </summary>
        /// <param name="ids">计划备料单据编号</param>
        public void DeletePlanstock(string[] ids)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            var ps_orderCode = string.Join(",", ids.Select(f => $"'{f}'"));
            string sql = "update part_planstock set ps_deleteFlag=1 where ps_orderCode in(" + ps_orderCode + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }



        /// <summary>
        /// 通用修改备料 申请单状态
        /// </summary>
        /// <param name="model">part_planstock 子表明细</param>
        /// <param name="pt_status">part_planTechnics 主表状态</param>
        /// <returns></returns>
        public int SaveTechnicsStockDetail(List<PartPlanStockModel> model, string pt_orderCode, int pt_status)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                List<MySqlParameter> pList = new List<MySqlParameter>();
                string sql = "";
                int ret = 0;

                try
                {
                    sql = @"Update part_planTechnics set pt_status=@pt_status,pt_updateTime=@pt_updateTime,pt_updateMan=@pt_updateMan where pt_orderCode=@pt_orderCode";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pt_status", pt_status));
                    pList.Add(new MySqlParameter("@pt_updateTime", DateTime.Now));
                    pList.Add(new MySqlParameter("@pt_updateMan", model[0].ps_updateMan));
                    pList.Add(new MySqlParameter("@pt_orderCode", pt_orderCode));
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    //循环修改备料从表 修改状态
                    for (int i = 0; i < model.Count; i++)
                    {
                        sql = @"Update part_planStock set ps_status=@ps_status,ps_remark=@ps_remark,ps_updateTime=@ps_updateTime,ps_updateMan=@ps_updateMan where ps_orderCode=@ps_orderCode";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@ps_status", model[i].ps_status));
                        pList.Add(new MySqlParameter("@ps_remark", model[i].ps_remark));
                        pList.Add(new MySqlParameter("@ps_orderCode", model[i].ps_orderCode));
                        pList.Add(new MySqlParameter("@ps_updateTime", DateTime.Now));
                        pList.Add(new MySqlParameter("@ps_updateMan", model[i].ps_updateMan));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }
                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }

            }
        }




        #endregion

        #region 计划排程管理 2020-04-07

        /// <summary>
        /// 计划排程分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<PartPlanModel> GetPartPlanScheduleList(PartPlanModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKEorderCode))
            {
                para += " and pp.pp_orderCode like CONCAT('%',@LIKEorderCode,'%') ";
                pList.Add(new MySqlParameter("@LIKEorderCode", model.LIKEorderCode.Trim()));
            }
            if (!string.IsNullOrEmpty(model.LIKEorderCodeRel))
            {
                para += " and pp.pp_orderCodeRel like CONCAT('%',@LIKEorderCodeRel,'%') ";
                pList.Add(new MySqlParameter("@LIKEorderCodeRel", model.LIKEorderCodeRel.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEproject))
            {
                para += " and pp.pp_project like CONCAT('%',@LIKEproject,'%') ";
                pList.Add(new MySqlParameter("@LIKEproject", model.LIKEproject.Trim()));
            }

            if (!string.IsNullOrEmpty(model.LIKEtrackNumber))
            {
                para += " and pp.pp_trackNumber like CONCAT('%',@LIKEtrackNumber,'%') ";
                pList.Add(new MySqlParameter("@LIKEtrackNumber", model.LIKEtrackNumber.Trim()));
            }
            if (model.pp_prodModelID.HasValue && model.pp_prodModelID.Value != 0)
            {
                para += " and pp.pp_prodModelID=@pp_prodModelID ";
                pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
            }
            if (model.pp_startDate.HasValue)
            {
                para += " and pp.pp_startDate>=@pp_startDate ";
                pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
            }
            if (model.pp_finishDate.HasValue)
            {
                para += " and pp.pp_finishDate<@pp_finishDate ";
                pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate.Value.AddDays(1)));
            }
            if (model.pp_status.HasValue && model.pp_status != -1)
            {
                para += " and pp.pp_status=@pp_status ";
                pList.Add(new MySqlParameter("@pp_status", model.pp_status));
            }
            string sql = @"select count(1) from Part_Plan pp 
                                   left join base_productmodel pm on pp.pp_prodModelID=pm.ID where pp.pp_deleteFlag=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);
            sql = @"select pp.*,pm.Pmodel,CONCAT_WS('-',pm.Pmodel,pp.pp_material) as PmodelDrawingNo
                    from Part_Plan pp 
                    left join base_productmodel pm on pp.pp_prodModelID=pm.ID where pp.pp_deleteFlag=0 " + para;
            if (!string.IsNullOrEmpty(model.sort))
            {
                sql += " order by " + model.sort + " is null ," + model.sort + " " + model.sortOrder;
            }
            sql += " limit " + model.PageIndex + "," + model.PageSize;
            List<PartPlanModel> list = db.ExecuteList<PartPlanModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 手动排程计划
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SortPartPlan(List<PartPlanModel> model, string pp_orderCode)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    #region 修改排序

                    for (int i = 0; i < model.Count; i++)
                    {
                        sql = @"update Part_Plan set pp_sort=@pp_sort,pp_updateTime=@pp_updateTime,pp_updateMan=@pp_updateMan where pp_orderCode=@pp_orderCode ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_sort", model[i].pp_sort));//排序号
                        pList.Add(new MySqlParameter("@pp_updateTime", DateTime.Now));
                        pList.Add(new MySqlParameter("@pp_updateMan", model[i].pp_updateMan));
                        pList.Add(new MySqlParameter("@pp_orderCode", model[i].pp_orderCode));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    #endregion


                    //将当前操作的计划改为手动排程
                    sql = @"update Part_Plan set pp_BundleAnalysisType=@pp_BundleAnalysisType where pp_orderCode=@pp_orderCode ";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pp_BundleAnalysisType", 0));//改为手动排序
                    pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));
                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }

        #endregion

        #region 齐套分析配置 2020-04-11
        /// <summary>
        /// 获取齐套物料配置信息列表
        /// </summary>
        /// <param name="prodModelID"></param>
        /// <param name="wlID"></param>
        /// <returns></returns>
        public List<BundleAnalysisMaterialConfigModel> GetBundleAnalysisMaterialConfigList(BundleAnalysisMaterialConfigModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = string.Empty;

            if (model.ProdModelID.HasValue && model.ProdModelID != 0)
            {
                para += " and a.prodModelID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", model.ProdModelID));
            }
            if (model.wlID.HasValue && model.wlID != 0)
            {
                para += " and a.wlID = @wlID";
                //sql += " AND a.mCode like CONCAT('%',@mCode,'%')";
                pList.Add(new MySqlParameter("@wlID", model.wlID));
            }

            if (model.UNID.HasValue && model.UNID > 0)
            {
                para += " and a.ID <> @UNID";
                pList.Add(new MySqlParameter("@UNID", model.UNID));
            }

            string sql = @"SELECT a.ID,a.prodModelID,CONCAT_WS('-',p.Pmodel,p.DrawingNo) as PModel,
                        a.wlID,CONCAT_WS(' - ',m.mName,m.mDrawingNo) as mName,a.percentValue,a.Must,a.remark
                        FROM base_bundleanalysiscfg a 
                        LEFT JOIN base_material m on a.wlID = m.ID 
                        LEFT JOIN base_productmodel p on a.prodModelID = p.ID WHERE 1=1 " + para;

            //if (model.PageIndex != 0 && model.PageSize != 0)
            //{
            //    sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            //}
            List<BundleAnalysisMaterialConfigModel> list = db.ExecuteList<BundleAnalysisMaterialConfigModel>(sql, pList.ToArray());
            return list;


        }

        /// <summary>
        /// 获取齐套物料配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BundleAnalysisMaterialConfigModel GetBundleAnalysisMaterialConfigList(int id)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            string para = string.Empty;
            var sql = @"SELECT * FROM base_bundleanalysiscfg  WHERE ID=@ID";
            pList.Add(new MySqlParameter("@ID", id));
            var list = db.ExecuteList<BundleAnalysisMaterialConfigModel>(sql, pList.ToArray());
            if (list.Count > 0)
            {
                return list[0];
            }

            return null;
        }

        /// <summary>
        /// 保存齐套物料配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveBundleAnalysisMaterialConfig(BundleAnalysisMaterialConfigModel model, out string Message)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = string.Empty;
            string msg = string.Empty;
            int ret = 0;
            decimal Count = 0;

            //判断当前添加齐套物料所占比是否大于100
            string sql1 = "select * from base_bundleanalysiscfg where prodModelID = " + model.ProdModelID;
            if (model.ID.HasValue)//如何有ID代表修改，需要排除当前数据库的老数据
            {
                sql1 += " and ID <> " + model.ID;
            }
            List<BundleAnalysisMaterialConfigModel> list = db.ExecuteList<BundleAnalysisMaterialConfigModel>(sql1, null);
            for (int i = 0; i < list.Count; i++)
            {
                Count += list[i].percentValue ?? 0;
            }
            Count += model.percentValue ?? 0;

            if (Count < 100)
            {
                //修改
                if (model.ID.HasValue)
                {
                    sql = @"Update  base_bundleanalysiscfg SET prodModelID=@prodModelID,wlID=@wlID,PercentValue=@PercentValue,must=@must,remark=@remark WHERE ID=@ID";
                    pList.Add(new MySqlParameter("@ID", model.ID));
                    pList.Add(new MySqlParameter("@prodModelID", model.ProdModelID));
                    pList.Add(new MySqlParameter("@wlID", model.wlID));
                    pList.Add(new MySqlParameter("@PercentValue", model.percentValue));
                    pList.Add(new MySqlParameter("@must", model.Must));
                    pList.Add(new MySqlParameter("@remark", model.Remark));
                }
                //添加
                else
                {
                    sql = @"INSERT INTO base_bundleanalysiscfg(prodModelID,wlID,PercentValue,must,remark) Values(@prodModelID,@wlID,@PercentValue,@must,@remark)";
                    pList.Add(new MySqlParameter("@prodModelID", model.ProdModelID));
                    pList.Add(new MySqlParameter("@wlID", model.wlID));
                    pList.Add(new MySqlParameter("@PercentValue", model.percentValue));
                    pList.Add(new MySqlParameter("@must", model.Must));
                    pList.Add(new MySqlParameter("@remark", model.Remark));

                }
                ret = db.ExecuteNonQuery(sql, pList.ToArray());
                Message = msg;
                return ret;
            }
            msg = "该产品型号下所添加的物料总占比不能大于100%";
            Message = msg;
            return ret;
        }


        /// <summary>
        /// 删除齐套物料配置
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteBundleAnalysisMaterialConfig(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from base_bundleanalysiscfg where ID in(" + id + ")";
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }




        /// <summary>
        /// 获取齐套物料配置信息列表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BundleAnalysisMaterialConfigModel> GetBundleAnalysisMaterialConfigList(BundleAnalysisMaterialConfigModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = string.Empty;

            if (model.ProdModelID.HasValue && model.ProdModelID > 0)
            {
                para += " AND a.prodModelID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", model.ProdModelID));
            }
            if (model.wlID.HasValue && model.wlID != 0)
            {
                para += " AND a.wlID = wlID";
                //sql += " AND a.mCode like CONCAT('%',@mCode,'%')";
                pList.Add(new MySqlParameter("@wlID", model.wlID));
            }

            if (!string.IsNullOrEmpty(model.LIKEWlName))
            {
                para += " AND m.mName like CONCAT('%',@LIKEWlName,'%')";
                pList.Add(new MySqlParameter("@LIKEWlName", model.LIKEWlName));
            }

            string sql = @"SELECT Count(*) FROM base_bundleanalysiscfg a 
                            LEFT JOIN base_material m on a.wlID = m.ID 
                            LEFT JOIN base_productmodel p on a.prodModelID = p.ID WHERE 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);


            sql = @"SELECT a.ID,a.prodModelID,CONCAT_WS('-',p.Pmodel,p.DrawingNo) as PModel,
                    a.wlID,CONCAT_WS(' - ',m.mName,m.mDrawingNo) as mName,a.percentValue,a.Must,a.remark
                    FROM base_bundleanalysiscfg a 
                    LEFT JOIN base_material m on a.wlID = m.ID 
                    LEFT JOIN base_productmodel p on a.prodModelID = p.ID WHERE 1=1 " + para;

            sql += "limit " + model.PageIndex + "," + model.PageSize;
            List<BundleAnalysisMaterialConfigModel> list = db.ExecuteList<BundleAnalysisMaterialConfigModel>(sql, pList.ToArray());
            var Sum = db.ExecuteList<BundleAnalysisMaterialConfigModel>("select SUM(percentValue) as percentValueSum from base_bundleanalysiscfg where prodModelID = " + model.ProdModelID, pList.ToArray()).FirstOrDefault().percentValueSum;
            //循环赋值
            list.ForEach(t =>
            {
                t.percentValueSum = Sum;
            });
            return list;
        }



        /// <summary>
        /// 修改阀值
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="threshold">阀值</param>
        public void UpdateThreshold(int ID, int threshold)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> List = new List<MySqlParameter>();
            string sql = "UPDATE base_productModel SET threshold=@threshold WHERE ID=@ID";
            List.Add(new MySqlParameter("@threshold", threshold));
            List.Add(new MySqlParameter("@ID", ID));
            db.ExecuteNonQuery(sql, List.ToArray());
        }





        /// <summary>
        /// 齐套分析获取生产计划信息
        /// </summary>
        /// <param name="ppCode"></param>
        /// <returns></returns>
        public List<BundleAnalysisPlanModel> GetPlanInfoByBundleAnalysis(string[] ppCode)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            string para = string.Empty;
            if (ppCode == null)
            {
                throw new ArgumentException($"{ppCode} is null ！");
            }
            para = string.Join(",", ppCode.Select(f => $"'{f}'"));
            //生产计划的基础
            var planList = db.ExecuteList<BundleAnalysisPlanModel>($"SELECT * FROM part_plan WHERE pp_deleteFlag=0 AND pp_ordercode in({para}) ORDER BY pp_sort ");
            //生产计划工序信息
            var planTechnicsList = db.ExecuteList<BundleAnalysisPlanTechnicsModel>($@"SELECT p.* FROM part_plantechnics p LEFT JOIN base_partgongxu gx ON p.pt_operationID = gx.ID 
                                                                                      WHERE p.pt_deleteFlag=0 AND gx.deleteFlag=0 AND p.pp_ordercode in({para}) ORDER BY gx.operationNo  ");
            //生产计划备料信息
            var planStock = db.ExecuteList<BundleAnalysisPlanStockModel>($"SELECT * FROM part_planstock WHERE ps_deleteFlag=0 AND pp_ordercode in({para})");

            if (planList != null && planTechnicsList != null)
            {
                if (planStock != null)
                {
                    foreach (var tech in planTechnicsList)
                    {
                        tech.StockModels = planStock.Where(f => f.pp_orderCode == tech.pp_orderCode && f.ps_operationID == tech.pt_operationID).ToList();
                    }
                }

                foreach (var plan in planList)
                {
                    plan.TechModels = planTechnicsList.Where(f => f.pp_orderCode == plan.pp_orderCode).ToList();
                }
            }

            return planList;

        }


        /// <summary>
        /// 齐套分析结果保存
        /// </summary>
        /// <param name="BundleAnalysisPlanModel"></param>
        /// <returns></returns>
        public int SaveBundleAnalysisResults(List<BundleAnalysisPlanModel> BundleAnalysisPlanModel)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int ret = 0;
                var time = DateTime.Now;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";

                    #region 修改排序

                    //计划
                    for (int i = 0; i < BundleAnalysisPlanModel.Count; i++)
                    {

                        var pp_materialPercent = string.Format("{0:0.0000%}", BundleAnalysisPlanModel[i].ActualPercent).Substring(0, string.Format("{0:0.0000%}", BundleAnalysisPlanModel[i].ActualPercent).Length - 1);
                        sql = @"update Part_Plan set pp_sort=@pp_sort,pp_materialPercent=@pp_materialPercent,pp_checkResult=@pp_checkResult,pp_BundleAnalysisTime=@pp_BundleAnalysisTime,pp_BundleAnalysisType=@pp_BundleAnalysisType where pp_orderCode=@pp_orderCode ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_sort", i + 1));//排序号
                        //BundleAnalysisPlanModel[i].ActualPercent.ToString("0.###0"))
                        pList.Add(new MySqlParameter("@pp_materialPercent", pp_materialPercent.ToDecimal()));
                        pList.Add(new MySqlParameter("@pp_checkResult", BundleAnalysisPlanModel[i].CheckRestult));
                        pList.Add(new MySqlParameter("@pp_BundleAnalysisTime", time));
                        pList.Add(new MySqlParameter("@pp_BundleAnalysisType", 1));
                        pList.Add(new MySqlParameter("@pp_orderCode", BundleAnalysisPlanModel[i].pp_orderCode));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        //工序
                        for (int j = 0; j < BundleAnalysisPlanModel[i].TechModels.Count; j++)
                        {
                            var tech = BundleAnalysisPlanModel[i].TechModels[j];
                            var pt_TechnicsPercent = string.Format("{0:0.0000%}", tech.ActualPercent).Substring(0, string.Format("{0:0.0000%}", tech.ActualPercent).Length - 1);
                            sql = @"update Part_PlanTechnics set pt_TechnicsPercent=@pt_TechnicsPercent,pt_checkResult=@pt_checkResult,pt_BundleAnalysisTime=@pt_BundleAnalysisTime where pt_orderCode=@pt_orderCode ";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pt_TechnicsPercent", pt_TechnicsPercent.ToDecimal()));
                            pList.Add(new MySqlParameter("@pt_checkResult", tech.ActualPercent >= tech.Percent ? 1 : 0));
                            pList.Add(new MySqlParameter("@pt_BundleAnalysisTime", time));
                            pList.Add(new MySqlParameter("@pt_orderCode", tech.pt_orderCode));
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                            //备料
                            for (int k = 0; k < BundleAnalysisPlanModel[i].TechModels[j].StockModels.Count; k++)
                            {
                                var stock = BundleAnalysisPlanModel[i].TechModels[j].StockModels[k];
                                var ps_materialPercent = string.Format("{0:0.0000%}", stock.ActualPercent).Substring(0, string.Format("{0:0.0000%}", stock.ActualPercent).Length - 1);
                                sql = @"update Part_PlanStock set ps_materialPercent=@ps_materialPercent,ps_checkResult=@ps_checkResult,ps_BundleAnalysisTime=@ps_BundleAnalysisTime where ps_orderCode=@ps_orderCode ";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@ps_materialPercent", ps_materialPercent.ToDecimal()));
                                pList.Add(new MySqlParameter("@ps_checkResult", stock.ActualPercent >= stock.Percent ? 1 : 0));
                                pList.Add(new MySqlParameter("@ps_BundleAnalysisTime", time));
                                pList.Add(new MySqlParameter("@ps_orderCode", stock.ps_orderCode));
                                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                            }

                        }

                    }

                    #endregion

                    myTrans.Commit();
                    return ret;
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }

        #endregion

        #region 计划执行情况


        /// <summary>
        /// 产品完成情况按车型车号汇总
        /// </summary>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductExecutiveCondition(ProductInfoModel model, out int totalCount)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.pp_project))
            {
                para += " and pp_project like CONCAT('%',@pp_project,'%') ";
                pList.Add(new MySqlParameter("@pp_project", model.pp_project.Trim()));
            }
            if (!string.IsNullOrEmpty(model.pp_trackNumber))
            {
                para += " and pp_trackNumber like CONCAT('%',@pp_trackNumber,'%') ";
                pList.Add(new MySqlParameter("@pp_project", model.pp_trackNumber.Trim()));
            }

            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                para += " and pp_orderCode like CONCAT('%',@pp_orderCode,'%') ";
                pList.Add(new MySqlParameter("@pp_project", model.pp_orderCode.Trim()));
            }

            if (model.pp_startDate.HasValue)
            {
                para += " and pp.pp_startDate >= @pp_startDate ";
                pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
            }
            if (model.pp_finishDate.HasValue)
            {
                para += " and pp.pp_finishDate < @pp_finishDate ";
                pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate.Value.AddDays(1).AddSeconds(-1)));
            }

            //DATE_FORMAT(pf.pf_finishTime, '%Y-%m') = DATE_FORMAT(NOW(), '%Y-%m')
            string sql = @" select Count(*) from
                            (select pp.pp_project, pp.pp_trackNumber, pp.pp_projectName, pp.pp_orderCode, CONCAT_WS('-', pm.Pmodel, pm.DrawingNo) as Pmodel,
                            CONCAT_WS('～',DATE_FORMAT(pp.pp_startDate,'%Y-%m-%d'),DATE_FORMAT(pp.pp_finishDate,'%Y-%m-%d')) as Date,
                            sum(case when pf.pf_finishStatus = 1 then 1 else 0 end) FinishQty,
                            sum(case when pf.pf_finishStatus = 0 then 1 else 0 end) UnFinishedQty,
                            pp.pp_planQty TotalQty
                            from productinfo pf
                            left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                            left join base_productModel pm on pf.pf_prodModelID = pm.ID
                            where 1=1 " + para;
            sql += " group by pp_orderCode order by pp.pp_finishDate desc ) prod ";

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()).ToString(), out totalCount);

            //当月 DATE_FORMAT(pf.pf_finishTime,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') 
            sql = @"select *,concat(ROUND(FinishQty/TotalQty*100,2),'%') FinishRate from 
                    (select pp.pp_project,pp.pp_trackNumber,pp.pp_projectName,pp.pp_orderCode,CONCAT_WS('-',pm.Pmodel,pm.DrawingNo) as Pmodel,
                    CONCAT_WS('～',DATE_FORMAT(pp.pp_startDate,'%Y-%m-%d'),DATE_FORMAT(pp.pp_finishDate,'%Y-%m-%d')) as Date,
                    sum(case when pf.pf_finishStatus=1 then 1 else 0 end) FinishQty,
                    sum(case when pf.pf_finishStatus=0 then 1 else 0 end) UnFinishedQty,
                    pp.pp_planQty TotalQty
                    from productinfo pf
                    left join part_plan pp on pf.pp_orderCode = pp.pp_orderCode
                    left join base_productModel pm on pf.pf_prodModelID=pm.ID 
                    where 1=1 " + para;

            sql += " group by pp_orderCode order  by pp.pp_finishDate desc ) prod LIMIT " + model.PageIndex + "," + model.PageSize;
            List<ProductInfoModel> list = db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 父子表
        /// </summary>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductinfo(ProductInfoModel model)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                para += " and pp_orderCode = @pp_orderCode ";
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
            }
            string sql = @"select * from productinfo where 1=1 " + para;
            List<ProductInfoModel> list = db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());
            return list;
        }


        #endregion

        #region MO

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<MOModel> GetPagingMOList(MOModel model, out int totalCount)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var para = string.Empty;
            if (!string.IsNullOrEmpty(model.LIKECode))
            {
                para += " and mo.moCode like CONCAT('%',@LIKECode,'%') ";
                pList.Add(new MySqlParameter("@LIKECode", model.LIKECode));
            }
            if (!string.IsNullOrEmpty(model.LIKESubwayNo))
            {
                para += " and bsb.bsbNo like CONCAT('%',@LIKESubwayNo,'%') ";
                pList.Add(new MySqlParameter("@LIKESubwayNo", model.LIKESubwayNo));
            }
            if (!string.IsNullOrEmpty(model.LIKELine))
            {
                para += " and bsb.bsbLine like CONCAT('%',@LIKELine,'%') ";
                pList.Add(new MySqlParameter("@LIKELine", model.LIKELine));
            }
            if (model.moProjectTypeID.HasValue)
            {
                para += " and mo.moProjectTypeID=@moProjectTypeID ";
                pList.Add(new MySqlParameter("@moProjectTypeID", model.moProjectTypeID.Value));
            }
            if (model.moMotorModelID.HasValue)
            {
                para += " and mo.moMotorModelID=@moMotorModelID ";
                pList.Add(new MySqlParameter("@moMotorModelID", model.moMotorModelID.Value));
            }
            if (model.moStatus.HasValue)
            {
                para += " and mo.moStatus=@moStatus ";
                pList.Add(new MySqlParameter("@moStatus", model.moStatus.Value));
            }
            if (model.DeliveryDateStart.HasValue)
            {
                para += " and mo.moDeliveryDate>=@DeliveryDateStart ";
                pList.Add(new MySqlParameter("@DeliveryDateStart", model.DeliveryDateStart.Value));
            }
            if (model.DeliveryDateEnd.HasValue)
            {
                para += " and pp.moDeliveryDate<@DeliveryDateEnd ";
                pList.Add(new MySqlParameter("@DeliveryDateEnd", model.DeliveryDateEnd.Value.AddDays(1)));
            }
            if (model.moDeliveryDate.HasValue)
            {
                para += " and mo.moDeliveryDate=@moDeliveryDate ";
                pList.Add(new MySqlParameter("@moDeliveryDate", model.moDeliveryDate.Value));
            }
            string sql = @"select count(*) from p_mo mo left join base_productModel pr on mo.moProjectTypeID = pr.ID
                    where mo.moDeleteFlag = 0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select mo.*,pr.Pmodel as moMotorModelName from p_mo mo left join base_productModel pr on mo.moProjectTypeID = pr.ID
                    where mo.moDeleteFlag=0 " + para;
            sql += " order by mo.moCreateTime desc ";
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<MOModel> list = db.ExecuteList<MOModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 通用查询
        /// </summary>
        /// <param name="model">实体类</param>
        /// <returns>集合</returns>
        public List<MOModel> GetMOList(MOModel model)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sql = string.Empty;
            var para = string.Empty;
            if (!string.IsNullOrEmpty(model.LIKECode))
            {
                para += " and mo.moCode like CONCAT('%',@LIKECode,'%') ";
                pList.Add(new MySqlParameter("@LIKECode", model.LIKECode));
            }
            if (!string.IsNullOrEmpty(model.LIKESubwayNo))
            {
                para += " and bsb.bsbNo like CONCAT('%',@LIKESubwayNo,'%') ";
                pList.Add(new MySqlParameter("@LIKESubwayNo", model.LIKESubwayNo));
            }
            if (!string.IsNullOrEmpty(model.LIKELine))
            {
                para += " and bsb.bsbLine like CONCAT('%',@LIKELine,'%') ";
                pList.Add(new MySqlParameter("@LIKELine", model.LIKELine));
            }
            if (model.moProjectTypeID.HasValue)
            {
                para += " and mo.moProjectTypeID=@moProjectTypeID ";
                pList.Add(new MySqlParameter("@moProjectTypeID", model.moProjectTypeID.Value));
            }
            if (model.moMotorModelID.HasValue)
            {
                para += " and mo.moMotorModelID=@moMotorModelID ";
                pList.Add(new MySqlParameter("@moMotorModelID", model.moMotorModelID.Value));
            }
            if (model.moStatus.HasValue)
            {
                para += " and mo.moStatus=@moStatus ";
                pList.Add(new MySqlParameter("@moStatus", model.moStatus.Value));
            }
            if (model.DeliveryDateStart.HasValue)
            {
                para += " and mo.moDeliveryDate>=@DeliveryDateStart ";
                pList.Add(new MySqlParameter("@DeliveryDateStart", model.DeliveryDateStart.Value));
            }
            if (model.DeliveryDateEnd.HasValue)
            {
                para += " and pp.moDeliveryDate<@DeliveryDateEnd ";
                pList.Add(new MySqlParameter("@DeliveryDateEnd", model.DeliveryDateEnd.Value.AddDays(1)));
            }

            sql = @"select mo.*,pr.Pmodel as moMotorModelName from p_mo mo left join base_productModel pr on mo.moProjectTypeID = pr.ID
                    where mo.moDeleteFlag=0 " + para;
            sql += " order by mo.moCreateTime desc ";
            var list = db.ExecuteList<MOModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveMO(MOModel model)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sql = string.Empty;
            if (string.IsNullOrEmpty(model.moCode))
            {
                #region 新增 
                //判断为常规订单还是紧急插单
                //if (!string.IsNullOrEmpty(model.moSubwayCode))
                //{
                //    #region 常规订单需去车辆信息表获取产品型号以及计算电机数量
                //    sql = "select * from base_subway where bsbCode=@bsbCode";
                //    pList.Add(new MySqlParameter("@bsbCode", model.moSubwayCode));
                //    var subwayList = db.ExecuteList<BaseSubwayModel>(sql, pList.ToArray()).ToList();
                //    pList.Clear();
                //    if (subwayList.Count == 0)
                //        return 0; 
                //    var subwayModel = subwayList[0];
                //    model.moMotorModelID = subwayModel.bsbProdModelID; 
                //    model.moQty = subwayModel.bsbMotorQty.ToInt() * model.moQty.ToInt();
                //    #endregion 
                //}
                model.moCode = db.GetSerialNumber("p_mo", "MO", 3);
                sql = @"insert into p_mo(moCode,moProjectTypeID,moDeliveryDate,moSubwayCode,moMotorModelID,moQty,moRemark,moStatus,moDeleteFlag,moCreateTime,moCreaterID,moUpdateTime,moUpdaterID) 
                values(@moCode,@moProjectTypeID,@moDeliveryDate,@moSubwayCode,@moMotorModelID,@moQty,@moRemark,0,0,@moCreateTime,@moCreaterID,@moUpdateTime,@moUpdaterID)";
                pList.Add(new MySqlParameter("@moCreateTime", model.moUpdateTime));
                pList.Add(new MySqlParameter("@moCreaterID", model.moUpdaterID));
                #endregion
            }
            else
            {
                #region 修改 
                //Update By Leon 20200302 新建状态才允许编辑 
                sql = @"update p_mo set 
                        moProjectTypeID=@moProjectTypeID,moDeliveryDate=@moDeliveryDate,moSubwayCode=@moSubwayCode,moMotorModelID=@moMotorModelID,moQty=@moQty,moRemark=@moRemark,moUpdateTime=@moUpdateTime,moUpdaterID=@moUpdaterID 
                        where moCode=@moCode and moStatus=0";
                #endregion
            }
            pList.Add(new MySqlParameter("@moCode", model.moCode));
            pList.Add(new MySqlParameter("@moProjectTypeID", model.moProjectTypeID));
            pList.Add(new MySqlParameter("@moDeliveryDate", model.moDeliveryDate));
            pList.Add(new MySqlParameter("@moSubwayCode", model.moSubwayCode));
            pList.Add(new MySqlParameter("@moMotorModelID", model.moMotorModelID));
            pList.Add(new MySqlParameter("@moQty", model.moQty));
            pList.Add(new MySqlParameter("@moRemark", model.moRemark));
            pList.Add(new MySqlParameter("@moUpdateTime", model.moUpdateTime));
            pList.Add(new MySqlParameter("@moUpdaterID", model.moUpdaterID));
            var i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteMO(MOModel model)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sql = string.Empty;
            #region 修改
            sql = @"update p_mo set moDeleteFlag=1,moUpdateTime=@moUpdateTime,moUpdaterID=@moUpdaterID where moCode=@moCode and moDeleteFlag=0";
            #endregion
            pList.Add(new MySqlParameter("@moCode", model.moCode));
            pList.Add(new MySqlParameter("@moUpdateTime", model.moUpdateTime));
            pList.Add(new MySqlParameter("@moUpdaterID", model.moUpdaterID));
            var i = db.ExecuteNonQuery(sql, pList.ToArray());
            return i;
        }

        /// <summary>
        /// 根据计划Guid更新MO状态
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="ppGuid">计划Guid</param>
        /// <param name="iStatus">MO状态</param>
        /// <returns>受影响行数</returns>
        public int UpdateMOStatus(MySqlTransaction transaction, Guid ppGuid, int iStatus)
        {
            //获取生产订单编码
            var sql = "select pp_moCode from plan_prod where pp_guid=@pp_guid";
            var pList = new List<MySqlParameter>();
            pList.Add(new MySqlParameter("@pp_guid", ppGuid));
            var moCode = Common.MySqlHelper.ExecuteScalar(transaction, CommandType.Text, sql, pList.ToArray()).ToString();
            //修改生产订单表状态为已入场
            sql = "update p_mo set moStatus=@uMOStatus where moStatus=@wMOStatus and moCode=@moCode";
            pList.Clear();
            pList.Add(new MySqlParameter("@moCode", moCode));
            pList.Add(new MySqlParameter("@uMOStatus", iStatus));
            pList.Add(new MySqlParameter("@wMOStatus", iStatus - 1));
            var i = Common.MySqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sql, pList.ToArray());
            return i;
        }

        #endregion

        #region 排产
        /// <summary>
        /// 排产保存
        /// </summary>
        /// <param name="modelList">计划主表集合</param>
        /// <returns>错误消息</returns>
        public string ScheduleSave(List<PlanProdModel> modelList)
        {
            using (var myConnection = new MySqlConnection(Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                var myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    var db = new Common.MySqlHelper();
                    var pList = new List<MySqlParameter>();
                    var sql = string.Empty;
                    var i = 0;
                    
                    if (modelList == null || modelList.Count == 0)
                        throw new Exception("参数为空!");
                    //保险起见查询是否有此订单计划 
                    sql = "select count(1) from plan_prod where pp_deleteFlag=0 and pp_moCode=@pp_moCode";
                    pList.Add(new MySqlParameter("@pp_moCode", modelList[0].pp_moCode));
                    var obj = Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray());
                    if (obj.ToInt() > 0)
                        throw new Exception("请勿重复排产!");
                    //新增计划  
                    foreach (var model in modelList)
                    {
                        model.pp_guid = Guid.NewGuid();
                        model.pp_planCode = db.GetSerialNumber("plan_prod", "PP", 4);
                        sql = @"insert into plan_prod(pp_guid,pp_planCode,pp_moCode,pp_prodModelID,pp_status,pp_planQty,pp_startDate,pp_finishDate,pp_deleteFlag
                                ,pp_createTime,pp_createMan,pp_updateTime,pp_updateMan) values(@pp_guid,@pp_planCode,@pp_moCode,@pp_prodModelID,0,@pp_planQty,@pp_startDate,@pp_finishDate,0,@pp_createTime,@pp_createMan,@pp_updateTime,@pp_updateMan) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pp_guid", model.pp_guid));
                        pList.Add(new MySqlParameter("@pp_planCode", model.pp_planCode));
                        pList.Add(new MySqlParameter("@pp_moCode", model.pp_moCode));
                        pList.Add(new MySqlParameter("@pp_prodModelID", model.pp_prodModelID));
                        pList.Add(new MySqlParameter("@pp_planQty", model.pp_planQty));
                        pList.Add(new MySqlParameter("@pp_startDate", model.pp_startDate));
                        pList.Add(new MySqlParameter("@pp_finishDate", model.pp_finishDate));
                        pList.Add(new MySqlParameter("@pp_createTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_createMan", model.pp_updateMan));
                        pList.Add(new MySqlParameter("@pp_updateTime", model.pp_updateTime));
                        pList.Add(new MySqlParameter("@pp_updateMan", model.pp_updateMan));
                        i = Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        if (i == 0)
                            throw new Exception("计划信息添加失败!计划开始时间:[" + model.pp_startDate + "]");
                        for (int j = 0; j < model.pp_planQty.Value; j++)
                        {
                            sql = "insert into plan_detail(ppGuid,pdStatus) values(@ppGuid,@pdStatus)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@ppGuid", model.pp_guid));
                            pList.Add(new MySqlParameter("@pdStatus", (int)EDAEnums.PlanDetailStatus.New));
                            i = Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            if (i == 0)
                                throw new Exception("计划明细添加失败!主表ID[" + model.pp_guid + "]序号:[" + (j + 1) + "]");
                        }
                    }
                    //修改订单状态 
                    sql = "update p_mo set moStatus=1,moUpdateTime=@moUpdateTime,moUpdaterID=@moUpdaterID where moCode=@moCode and moStatus=0";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@moCode", modelList[0].pp_moCode));
                    pList.Add(new MySqlParameter("@moUpdateTime", modelList[0].pp_updateTime));
                    pList.Add(new MySqlParameter("@moUpdaterID", modelList[0].pp_updateMan));
                    i = Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    if (i == 0)
                        throw new Exception("修改订单状态失败!订单编码:[" + modelList[0].pp_moCode + "]");

                    myTrans.Commit();
                    return string.Empty;
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    return ex.Message;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }
        #endregion
      
    }
}