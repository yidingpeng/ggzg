using RW.PMS.IDAL;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Device;
using RW.PMS.Model.Sys;
using RW.PMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using RW.PMS.Model.BaseInfo;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.Configuration;

namespace RW.PMS.DAL
{
    internal class DAL_Device : IDAL_Device
    {


        #region 设备管理 LHR 2019-3-5

        /// <summary>
        /// 查询设备管理信息 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceModel> DeviceForPage(DeviceModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.DevName))
            {
                para += " and DevName=@DevName ";
                pList.Add(new MySqlParameter("@DevName", model.DevName));
            }
            string sql = "select count(*) from  base_Device where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select ID,DevName,DevNo,DevCardno,DevIP,CreateDate,DevStatus,Remark from base_Device where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<DeviceModel> list = db.ExecuteList<DeviceModel>(sql, pList.ToArray());
            return list;
        }

        public List<DeviceModel> GetAllDevice()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,DevName,DevNo,DevCardno,DevIP,CreateDate,DevStatus,Remark from base_Device";
            List<DeviceModel> list = db.ExecuteList<DeviceModel>(sql, pList.ToArray());
            return list;
        }

        public DeviceModel getDevice(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,DevName,DevNo,DevCardno,DevIP,CreateDate,DevStatus,Remark from base_Device where ID=" + id;
            List<DeviceModel> list = db.ExecuteList<DeviceModel>(sql, pList.ToArray());
            if (list.Count > 0) return list[0];
            return new DeviceModel();
        }

        /// <summary>
        /// 添加 设备管理信息
        /// </summary>
        /// <param name="model"></param>
        public void AddDevice(DeviceModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into base_Device(devName,devNo,devIP,createDate,devStatus,devCardno,remark)
                                   values(@devName,@devNo,@devIP,@createDate,@devStatus,@devCardno,@remark)";
            pList.Add(new MySqlParameter("@devName", model.DevName));
            pList.Add(new MySqlParameter("@devNo", model.DevNo));
            pList.Add(new MySqlParameter("@devIP", model.DevIP));
            pList.Add(new MySqlParameter("@createDate", model.CreateDate));
            pList.Add(new MySqlParameter("@devStatus", model.DevStatus));
            pList.Add(new MySqlParameter("@devCardno", model.DevCardno));
            pList.Add(new MySqlParameter("@remark", model.Remark));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改 设备管理信息
        /// </summary>
        /// <param name="model"></param>
        public void EditDevice(DeviceModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = @"update base_Device set devName=@devName,devNo=@devNo,devIP=@devIP,createDate=@createDate,
                                   devStatus=@devStatus,devCardno=@devCardno,remark=@remark where ID=@ID";
                    pList.Add(new MySqlParameter("@devName", model.DevName));
                    pList.Add(new MySqlParameter("@devNo", model.DevNo));
                    pList.Add(new MySqlParameter("@devIP", model.DevIP));
                    pList.Add(new MySqlParameter("@createDate", model.CreateDate));
                    pList.Add(new MySqlParameter("@devStatus", model.DevStatus));
                    pList.Add(new MySqlParameter("@devCardno", model.DevCardno));
                    pList.Add(new MySqlParameter("@remark", model.Remark));
                    pList.Add(new MySqlParameter("@ID", model.ID));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //如果修改了设备名称和IP，器具表也需要更改名称和IP，进行同步操作
                    sql = @"select * from base_tools where devID=@devID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@devID", model.ID));
                    DataTable dt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                    if (dt.Rows.Count > 0)
                    {
                        sql = @"update base_tools set devName=@devName,devSubjectionIP=@devSubjectionIP where devID=@devID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@devName", model.DevName));
                        pList.Add(new MySqlParameter("@devSubjectionIP", model.DevIP));
                        pList.Add(new MySqlParameter("@devID", model.ID));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    }
                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                    return;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return;
            }
        }

        /// <summary>
        /// 删除 设备管理信息
        /// </summary>
        /// <param name="id"></param>
        public void DelDevice(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from base_Device where ID in(" + id + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        #endregion


        #region 设备保养/点检项目
        /// <summary>
        /// 查询 设备保养/点检项目 数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceSpotCheckModel> DeviceSpotCheckPage(DeviceSpotCheckModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model.dsc_device != null && model.dsc_device != 0)
            {
                para += " and dsc_device=@dsc_device ";
                pList.Add(new MySqlParameter("@dsc_device", model.dsc_device));
            }

            string sql = "select count(*) from device_spotcheck where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select * from device_spotcheck where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<DeviceSpotCheckModel> list = db.ExecuteList<DeviceSpotCheckModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 查询 设备保养/点检项目 数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceSpotCheckModel> GetDeviceSpotCheck()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select * from device_spotcheck";

            List<DeviceSpotCheckModel> list = db.ExecuteList<DeviceSpotCheckModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 修改绑定 设备保养/点检项目 数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeviceSpotCheckModel GetDeviceSpotCheckbyId(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select * from device_spotcheck where ID=" + id;
            List<DeviceSpotCheckModel> list = db.ExecuteList<DeviceSpotCheckModel>(sql, pList.ToArray());
            if (list.Count == 0) return new DeviceSpotCheckModel();
            return list[0];
        }

        /// <summary>
        /// 添加 设备保养/点检项目 数据
        /// </summary>
        /// <param name="model"></param>
        public void AddDeviceSpotCheck(DeviceSpotCheckModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into device_spotcheck(spotid,dsc_category,dsc_position,dsc_project,dsc_method,dsc_criteria,dsc_solving,dsc_status,dsc_cycle,dsc_liable,dsc_class,dsc_img,dsc_device)
                                   values(@spotid,@dsc_category,@dsc_position,@dsc_project,@dsc_method,@dsc_criteria,@dsc_solving,@dsc_status,@dsc_cycle,@dsc_liable,@dsc_class,@dsc_img,@dsc_device)";
            pList.Add(new MySqlParameter("@spotid", model.spotid));
            pList.Add(new MySqlParameter("@dsc_category", model.dsc_category));
            pList.Add(new MySqlParameter("@dsc_position", model.dsc_position));
            pList.Add(new MySqlParameter("@dsc_project", model.dsc_project));
            pList.Add(new MySqlParameter("@dsc_method", model.dsc_method));
            pList.Add(new MySqlParameter("@dsc_criteria", model.dsc_criteria));
            pList.Add(new MySqlParameter("@dsc_status", model.dsc_status));
            pList.Add(new MySqlParameter("@dsc_cycle", model.dsc_cycle));
            pList.Add(new MySqlParameter("@dsc_liable", model.dsc_liable));
            pList.Add(new MySqlParameter("@dsc_solving", model.dsc_solving));
            pList.Add(new MySqlParameter("@dsc_img", model.dsc_img));
            pList.Add(new MySqlParameter("@dsc_class", model.dsc_class));
            pList.Add(new MySqlParameter("@dsc_device", model.dsc_device));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改 设备保养/点检项目 数据
        /// </summary>
        /// <param name="model"></param>
        public void EditDeviceSpotCheck(DeviceSpotCheckModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update device_spotcheck set spotid=@spotid,dsc_category=@dsc_category,dsc_position=@dsc_position,dsc_project=@dsc_project,dsc_method=@dsc_method,
                                   dsc_criteria=@dsc_criteria,dsc_status=@dsc_status,dsc_cycle=@dsc_cycle,dsc_liable=@dsc_liable,dsc_solving=@dsc_solving,dsc_class=@dsc_class,dsc_img=@dsc_img,dsc_device=@dsc_device where id=@id";
            pList.Add(new MySqlParameter("@spotid", model.spotid));
            pList.Add(new MySqlParameter("@dsc_category", model.dsc_category));
            pList.Add(new MySqlParameter("@dsc_position", model.dsc_position));
            pList.Add(new MySqlParameter("@dsc_project", model.dsc_project));
            pList.Add(new MySqlParameter("@dsc_method", model.dsc_method));
            pList.Add(new MySqlParameter("@dsc_criteria", model.dsc_criteria));
            pList.Add(new MySqlParameter("@dsc_status", model.dsc_status));
            pList.Add(new MySqlParameter("@dsc_cycle", model.dsc_cycle));
            pList.Add(new MySqlParameter("@dsc_liable", model.dsc_liable));
            pList.Add(new MySqlParameter("@dsc_solving", model.dsc_solving));
            pList.Add(new MySqlParameter("@dsc_class", model.dsc_class));
            pList.Add(new MySqlParameter("@dsc_img", model.dsc_img));
            pList.Add(new MySqlParameter("@id", model.id));
            pList.Add(new MySqlParameter("@dsc_device", model.dsc_device));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除 设备保养/点检项目 数据
        /// </summary>
        /// <param name="id"></param>
        public void DelDeviceSpotCheck(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"delete from device_spotcheck where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        #endregion

        #region 设备保养维护计划 LHR 2019-3-5

        /// <summary>
        /// 查询设备保养维护计划 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Device_upKeepPlanModel> DevicePlanForPage(Device_upKeepPlanModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model.DevID != 0 && model.DevID != null)
            {
                para += " and pl.devID=@devID ";
                pList.Add(new MySqlParameter("@devID", model.DevID));
            }
            string sql = "select count(*) from device_upKeepPlan pl left join base_Device dev on pl.devID=dev.id where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select pl.ID,pl.DevID,dev.DevName,pl.UpKeepTypeID,IFNULL(GetbdNameBybdID(pl.UpKeepTypeID),'') UpKeepType,
                            pl.PlanMemo,pl.PlanDate,pl.ExecDate,pl.ExecStatus,pl.ExecEmp,pl.ExecEmpName,pl.Remark
                            from device_upKeepPlan pl left join base_Device dev on pl.devID=dev.id where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<Device_upKeepPlanModel> list = db.ExecuteList<Device_upKeepPlanModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取所有 设备信息
        /// </summary>
        /// <returns></returns>
        public List<DeviceModel> GetDevice()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,DevName,DevNo,DevCardno,DevIP,CreateDate,DevStatus,Remark from base_Device";
            List<DeviceModel> list = db.ExecuteList<DeviceModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 修改绑定 设备保养维护计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Device_upKeepPlanModel GetDevicePlanbyId(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,DevID,UpKeepTypeID,PlanMemo,PlanDate,ExecDate,ExecStatus,ExecEmp,ExecEmpName,Remark from device_upKeepPlan where ID=" + id;
            List<Device_upKeepPlanModel> list = db.ExecuteList<Device_upKeepPlanModel>(sql, pList.ToArray());
            if (list.Count == 0) return new Device_upKeepPlanModel();
            return list[0];
        }

        /// <summary>
        /// 添加 设备保养维护计划
        /// </summary>
        /// <param name="model"></param>
        public void AddDevicePlan(Device_upKeepPlanModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into device_upKeepPlan(devID,ExecDate,ExecEmp,ExecEmpName,Remark)
                                   values(@devID,@ExecDate,@ExecEmp,@ExecEmpName,@Remark)";
            pList.Add(new MySqlParameter("@devID", model.DevID));
            pList.Add(new MySqlParameter("@ExecDate", model.ExecDate));
            pList.Add(new MySqlParameter("@ExecEmp", model.ExecEmp));
            pList.Add(new MySqlParameter("@ExecEmpName", model.ExecEmpName));
            pList.Add(new MySqlParameter("@Remark", model.Remark));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改 设备保养维护计划
        /// </summary>
        /// <param name="model"></param>
        public void EditDevicePlan(Device_upKeepPlanModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update device_upKeepPlan set devID=@devID,ExecDate=@ExecDate,ExecEmp=@ExecEmp,ExecEmpName=@ExecEmpName,Remark=@Remark
                                    where ID=@ID";
            pList.Add(new MySqlParameter("@devID", model.DevID));
            pList.Add(new MySqlParameter("@ExecDate", model.ExecDate));
            pList.Add(new MySqlParameter("@ExecEmp", model.ExecEmp));
            pList.Add(new MySqlParameter("@ExecEmpName", model.ExecEmpName));
            pList.Add(new MySqlParameter("@Remark", model.Remark));
            pList.Add(new MySqlParameter("@ID", model.ID));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除 设备保养维护计划
        /// </summary>
        /// <param name="id"></param>
        public void DelDevicePlan(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"delete from device_upKeepPlan where ID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 保存设备保养主表和明细表
        /// </summary>
        /// <param name="mainModel"></param>
        /// <param name="checkEntyList"></param>
        /// <returns></returns>
        public bool SaveDevicePlan(Device_upKeepPlanModel mainModel, List<Device_upkeepPlanDetailModel> checkEntyList)
        {

            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                int i = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();

                    string sql = @"insert into device_upKeepPlan(devID,ExecDate,ExecEmp,ExecEmpName,Remark)
                                   values(@devID,@ExecDate,@ExecEmp,@ExecEmpName,@Remark)";
                    pList.Clear();

                    pList.Add(new MySqlParameter("@devID", mainModel.DevID));
                    pList.Add(new MySqlParameter("@ExecDate", mainModel.ExecDate));
                    pList.Add(new MySqlParameter("@ExecEmp", mainModel.ExecEmp));
                    pList.Add(new MySqlParameter("@ExecEmpName", mainModel.ExecEmpName));
                    pList.Add(new MySqlParameter("@Remark", mainModel.Remark));
                    i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //获取自增长ID
                    int mainID = 0;
                    pList.Clear();
                    sql = "select @@identity";
                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out mainID);

                    if (checkEntyList.Count > 0)
                    {
                        foreach (Device_upkeepPlanDetailModel item in checkEntyList)
                        {
                            sql = @"insert into device_upkeepPlanDetail(udID,spotid,dsc_position,dsc_project,udimg,udremark)
                                   values(@udID,@spotid,@dsc_position,@dsc_project,@udimg,@udremark)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@udID", mainID));
                            pList.Add(new MySqlParameter("@spotid", item.spotid));
                            pList.Add(new MySqlParameter("@dsc_position", item.dsc_position));
                            pList.Add(new MySqlParameter("@dsc_project", item.dsc_project));
                            pList.Add(new MySqlParameter("@udimg", item.udimg));
                            pList.Add(new MySqlParameter("@udremark", item.udremark));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return i > 0;
            }
        }

        #endregion


        #region 设备保养计划子表维护 2020-03-03 LHR

        /// <summary>
        /// 查询设备保养维护计划子表 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Device_upkeepPlanDetailModel> DevicePlanDetailForPage(Device_upkeepPlanDetailModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "  and p1.id = @udid ";
            pList.Add(new MySqlParameter("@udid", model.udID));

            //if (model.DevID != 0 && model.DevID != null)
            //{
            //    para += " and pl.devID=@devID ";
            //    pList.Add(new MySqlParameter("@devID", model.DevID));
            //}

            string sql = @"select count(*) from device_upkeepPlanDetail ud 
                                    left join device_upKeepPlan p1 on p1.id = ud.udid 
                                    left join base_Device dev on p1.devID = dev.id where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select ud.id,ud.udID,dev.DevName,ud.uddesc,ud.udimg,ud.udStatus,ud.udremark from device_upkeepPlanDetail ud 
                            left join device_upKeepPlan p1 on p1.id = ud.udid 
                            left join base_Device dev on p1.devID = dev.id where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<Device_upkeepPlanDetailModel> list = db.ExecuteList<Device_upkeepPlanDetailModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 获取所有设备保养计划明细
        /// </summary>
        /// <returns></returns>
        public List<Device_upkeepPlanDetailModel> GetDevicePlanDetail()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select id,udID,uddesc,udimg,udStatus,udremark from device_upkeepPlanDetail ";
            List<Device_upkeepPlanDetailModel> list = db.ExecuteList<Device_upkeepPlanDetailModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 添加 设备保养维护计划子表
        /// </summary>
        /// <param name="model"></param>
        public void AddDevicePlanDetail(Device_upkeepPlanDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into device_upkeepPlanDetail(udID,spotid,dsc_position,dsc_project,udimg,udremark)
                                   values(@udID,@spotid,@dsc_position,@dsc_project,@udimg,@udremark)";
            pList.Add(new MySqlParameter("@udID", model.udID));
            pList.Add(new MySqlParameter("@uddesc", model.spotid));
            pList.Add(new MySqlParameter("@udimg", model.dsc_position));
            pList.Add(new MySqlParameter("@udStatus", model.dsc_project));
            pList.Add(new MySqlParameter("@udremark", model.udimg));
            pList.Add(new MySqlParameter("@udremark", model.udremark));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改 设备保养维护计划子表
        /// </summary>
        /// <param name="model"></param>
        public void EditDevicePlanDetail(Device_upkeepPlanDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update device_upkeepPlanDetail set udID=@udID,spotid=@spotid,dsc_position=@dsc_position,dsc_project=@dsc_project,udimg=@udimg,udremark@udremark where id=@id";
            pList.Add(new MySqlParameter("@udID", model.udID));
            pList.Add(new MySqlParameter("@uddesc", model.spotid));
            pList.Add(new MySqlParameter("@udimg", model.dsc_position));
            pList.Add(new MySqlParameter("@udStatus", model.dsc_project));
            pList.Add(new MySqlParameter("@udremark", model.udimg));
            pList.Add(new MySqlParameter("@udremark", model.udremark));
            pList.Add(new MySqlParameter("@id", model.id));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 删除 设备保养维护计划子表
        /// </summary>
        /// <param name="id"></param>
        public void DelDevicePlanDetail(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"delete from device_upkeepPlanDetail where id in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        #endregion


        #region 设备提醒明细管理

        /// <summary>
        /// 设备提醒明细信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceRemindModel> GetDeviceRemindForPage(DeviceRemindModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT dr.ID,devID as DevID,devName as DevName
                                ,toolModels as ToolModels,toolCode as ToolCode,dr.toolId as ToolId,GetbdNameBybdID(dr.toolId) as ToolName
                                ,devCertificateNo as DevCertificateNo,dr.devPurchaseDate as DevPurchaseDate,dr.devExpireDate as DevExpireDate
                                ,dr.devStatus as DevStatus,empID as EmpID,empName as EmpName,inspectiontime as Inspectiontime
                                ,devInspectionCount as DevInspectionCount,dr.devremark as Devremark
                                from device_Remind as dr LEFT JOIN base_Tools as bt
                                ON dr.TId=bt.id LEFT JOIN sys_User as us on dr.empID=us.userID WHERE 0=0";
            if (model != null)
            {
                if (model.DevID != null && model.DevID != -1)
                {
                    sql += " and bt.devID=@DevID";
                    pList.Add(new MySqlParameter("@DevID", model.DevID));
                }
                if (model.ToolId != null && model.ToolId != -1)
                {
                    sql += " and dr.toolId=@ToolId";
                    pList.Add(new MySqlParameter("@ToolId", model.ToolId));
                }
            }
            List<DeviceRemindModel> list = db.ExecuteList<DeviceRemindModel>(sql, pList.ToArray());
            totalCount = list.Count();
            list = list.OrderBy(o => o.ID).Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize).ToList();
            return list;
        }


        #endregion


        #region 试验项目标准范围表 LHR

        /// <summary>
        /// 查询 试验项目标准范围表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        //public List<TestItemModel> TestItemValueForPage(TestItemModel model, out int totalCount)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var query = from str1 in context.test_ItemValueInfo
        //                    join bp in context.base_product on str1.prodID equals bp.ID into dpt
        //                    from baseproduct in dpt.DefaultIfEmpty()
        //                    select new TestItemModel
        //                    {
        //                        ID = str1.ID,
        //                        ProdID = str1.prodID,
        //                        ItemTypeID = str1.itemTypeID,
        //                        ItemID = str1.itemID,
        //                        StandardValue = str1.standardValue,
        //                        MinValue = str1.minValue,
        //                        MaxValue = str1.maxValue,
        //                        PtItemStatusS = str1.ptItemStatus == 0 ? "启用" : "禁用",
        //                        Remark = str1.remark,
        //                        Pname = baseproduct.Pname,
        //                        itemTypeName = Functions.getBaseName(str1.itemTypeID.Value),
        //                        itemName = Functions.getBaseName(str1.itemID.Value),
        //                        PtItemStatus = str1.ptItemStatus
        //                    };
        //        if (model != null)
        //        {
        //            if (model.ProdID != null && model.ProdID != 0)
        //            {
        //                query = query.Where(x => x.ProdID == model.ProdID);
        //            }
        //            if (model.ItemTypeID != null && model.ItemTypeID != 0)
        //            {
        //                query = query.Where(x => x.ItemTypeID == model.ItemTypeID);
        //            }
        //            if (model.ItemID != null && model.ItemID != 0)
        //            {
        //                query = query.Where(x => x.ItemID == model.ItemID);
        //            }
        //        }
        //        List<TestItemModel> list = query.OrderBy(o => o.ID).Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize).ToList();
        //        totalCount = query.Count();
        //        return list;
        //    }
        //}


        //public TestItemModel getTestItemValue(int id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        return context.test_ItemValueInfo.Where(x => x.ID == id).Select(model => new TestItemModel
        //        {
        //            ID = model.ID,
        //            ProdID = model.prodID,
        //            ItemTypeID = model.itemTypeID,
        //            ItemID = model.itemID,
        //            StandardValue = model.standardValue,
        //            MinValue = model.minValue,
        //            MaxValue = model.maxValue,
        //            PtItemStatus = model.ptItemStatus,
        //            Remark = model.remark
        //        }).FirstOrDefault();
        //    }
        //}


        /// <summary>
        /// 添加 试验项目标准范围表
        /// </summary>
        /// <param name="model"></param>
        //public void AddTestItemValue(TestItemModel model)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        test_ItemValueInfo test = new test_ItemValueInfo();
        //        test.prodID = model.ProdID;
        //        test.itemTypeID = model.ItemTypeID;
        //        test.itemID = model.ItemID;
        //        test.standardValue = model.StandardValue;
        //        test.minValue = model.MinValue;
        //        test.maxValue = model.MaxValue;
        //        test.ptItemStatus = model.PtItemStatus;
        //        test.remark = model.Remark;
        //        context.test_ItemValueInfo.Add(test);
        //        context.SaveChanges(); ;
        //    }
        //}


        /// <summary>
        /// 修改 试验项目标准范围表
        /// </summary>
        /// <param name="model"></param>
        //public void EditTestItemValue(TestItemModel model)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var query = context.test_ItemValueInfo.SingleOrDefault<test_ItemValueInfo>(x => x.ID == model.ID);
        //        if (query == null)
        //            return;
        //        query.prodID = model.ProdID;
        //        query.itemTypeID = model.ItemTypeID;
        //        query.itemID = model.ItemID;
        //        query.standardValue = model.StandardValue;
        //        query.minValue = model.MinValue;
        //        query.maxValue = model.MaxValue;
        //        query.ptItemStatus = model.PtItemStatus;
        //        query.remark = model.Remark;
        //        context.SaveChanges(); ;

        //    }
        //}


        /// <summary>
        /// 删除 试验项目标准范围表
        /// </summary>
        /// <param name="id"></param>
        //public void DelTestItemValue(string id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        string[] list = id.Split(',');
        //        for (int i = 0; i < list.Length; i++)
        //        {
        //            var num = Convert.ToInt32(list[i]);
        //            var items = context.test_ItemValueInfo.SingleOrDefault<test_ItemValueInfo>(x => x.ID == num);
        //            if (items == null)
        //            {
        //                throw new Exception("未找到该试验项目信息！");
        //            }
        //            context.test_ItemValueInfo.Remove(items);
        //        }
        //        context.SaveChanges(); ;
        //    }
        //}

        #endregion


        #region 设备运行情况 WZQ
        /// <summary>
        /// 设备运行情况
        /// </summary>
        /// <param name="model">设备运行情况实体类</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<DeviceRunModel> GetDeviceRunForPage(DeviceRunModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (model.DevID.HasValue && model.DevID != -1)
                {
                    para += " and run.devID=@DevID";
                    pList.Add(new MySqlParameter("@DevID", model.DevID));
                }
            }
            string sql = @"SELECT count(*) FROM device_run as run LEFT JOIN base_Device as dev on run.devID=dev.id  where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT devID as DevID,devName as DevName,
                            startDate as StartDate,endDate as EndDate,run.remark,
                            TIMESTAMPDIFF(HOUR,startDate,endDate) as RunHour FROM device_run as run 
                            LEFT JOIN base_Device as dev on run.devID=dev.id  where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<DeviceRunModel> DeviceRunlist = db.ExecuteList<DeviceRunModel>(sql, pList.ToArray());
            return DeviceRunlist;

        }

        /// <summary>
        /// 获取时长
        /// </summary>
        /// <param name="StartDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
        public int getHour(DateTime StartDate, DateTime EndDate)
        {
            TimeSpan ts = Convert.ToDateTime(EndDate) - Convert.ToDateTime(StartDate);
            int hour = ts.Hours;
            return hour;
        }
        #endregion


        #region CS端

        #region 设备点检

        /// <summary>
        /// 获取设备点检数据
        /// </summary>
        /// <returns></returns>
        public List<DeviceCheckingDetailsModel> GetCheckingDetailsDate()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select sbd.ID DevTypeID,sbd.bdname DevType,bd.ID CheckItemID,bd.bdname CheckItem 
                            from  sys_baseData as bd 
                            left join  sys_baseData as sbd on bd.bdParentID=sbd.ID
                            where sbd.bdtypeCode='deviceCheckType'";
            List<DeviceCheckingDetailsModel> list = db.ExecuteList<DeviceCheckingDetailsModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 保存设备点检主表和明细表
        /// </summary>
        /// <param name="mainModel"></param>
        /// <param name="checkEntyList"></param>
        /// <returns></returns>
        public bool SaveDeviceCheck(DeviceCheckingModel mainModel, List<DeviceCheckingDetailsModel> checkEntyList)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList1 = new List<MySqlParameter>();

            string sql2 = @"select Count(*) 
                            from  device_checking  
                            where CheckTime=@CheckTime and DevID=@DevID";

            pList1.Add(new MySqlParameter("@CheckTime", mainModel.CheckTime));
            pList1.Add(new MySqlParameter("@DevID", mainModel.DevID));


            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                int i = 0;
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();

                    string sql;

                    //获取主表ID
                    int mainID = 0;

                    if (!(Convert.ToInt32(db.ExecuteScalar(sql2, pList1.ToArray())) > 0))
                    {
                        sql = @"insert into device_checking(devID,checkTime,checkerID,remark)
                                           values(@devID,@checkTime,@checkerID,@remark)";
                        pList.Add(new MySqlParameter("@devID", mainModel.DevID));
                        pList.Add(new MySqlParameter("@checkTime", mainModel.CheckTime));
                        pList.Add(new MySqlParameter("@checkerID", mainModel.CheckerID));
                        pList.Add(new MySqlParameter("@remark", mainModel.Remark));
                        i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                        pList.Clear();
                        sql = "select @@identity";
                        int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out mainID);
                    }
                    else
                    {
                        mainID = Convert.ToInt32(db.ExecuteScalar(@"select id
                            from device_checking
                            where CheckTime=@CheckTime and DevID=@DevID", pList1.ToArray()));
                    };




                    if (checkEntyList.Count > 0)
                    {
                        foreach (DeviceCheckingDetailsModel item in checkEntyList)
                        {
                            sql = @"insert into device_checkingDetails(devCheckID,devTypeID,spotID,checkItem,itemCheckResult,
                                            itemCheckerID,MonitorID,CheckerTime,SpotTime,remark)values(@devCheckID,@devTypeID,@spotID,@checkItem,@itemCheckResult,
                                            @itemCheckerID,@MonitorID,@CheckerTime,@SpotTime,@remark)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@devCheckID", mainID));
                            pList.Add(new MySqlParameter("@devTypeID", item.DevTypeID));
                            pList.Add(new MySqlParameter("@checkItem", item.CheckItem));
                            pList.Add(new MySqlParameter("@itemCheckResult", item.ItemCheckResult));
                            pList.Add(new MySqlParameter("@itemCheckerID", item.ItemCheckerID));
                            pList.Add(new MySqlParameter("@spotID", item.spotID));
                            pList.Add(new MySqlParameter("@MonitorID", item.MonitorID));
                            pList.Add(new MySqlParameter("@SpotTime", item.SpotTime));
                            pList.Add(new MySqlParameter("@CheckerTime", item.CheckerTime));
                            pList.Add(new MySqlParameter("@remark", item.Remark));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return i > 0;
            }
        }

        #endregion

        #region 设备提醒
        /// <summary>
        /// 获取需提醒的器具集合
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public List<BaseToolsModel> GetToolsRemindCount(string IP = "")
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(IP))
            {
                para += " and dv.devIP=@devIP";
                pList.Add(new MySqlParameter("@devIP", IP));
            }
            //提前提醒天数
            int AdvanceDayQty = db.ExecuteScalar("select cfg_value from sys_config where cfg_code='ExpireReminderDay'", parms: null).ToInt();

            string sql = @"select bt.id ID,bt.devID DevID,bt.devName DevName,bt.toolId ToolId,tool.bdname ToolName,
                                   bt.toolModels ToolModels,bt.toolCode ToolCode ,dv.devIP DevSubjectionIP,bt.devPurchaseDate DevPurchaseDate,
                                   bt.devExpireDate DevExpireDate,bt.devStatus DevStatus,datediff(now(),bt.devExpireDate) ExpireDay 
                                   from base_Tools bt 
                                   left join base_Device dv on dv.id=bt.devID 
                                   left join sys_basedata tool on tool.ID=bt.toolId 
                                   where datediff(now(),bt.devExpireDate)+" + AdvanceDayQty + ">=0 " + para;
            sql += " order by bt.id";
            List<BaseToolsModel> list = db.ExecuteList<BaseToolsModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 保存设备到期提醒业务表并返回自增长ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public string SaveDeviceRemind(List<DeviceRemindModel> model)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        string DId = "";
        //        foreach (DeviceRemindModel item in model)
        //        {
        //            device_Remind entity = new device_Remind();
        //            entity.TId = item.TId ?? 0;
        //            entity.toolId = item.ToolId ?? 0;
        //            entity.toolName = item.ToolName ?? "";
        //            entity.devCertificateNo = item.DevCertificateNo ?? "";
        //            entity.devPurchaseDate = item.DevPurchaseDate ?? DateTime.MinValue;
        //            entity.devExpireDate = item.DevExpireDate ?? DateTime.MinValue;
        //            entity.devStatus = item.DevStatus ?? 0;
        //            entity.empID = 0;
        //            entity.devremark = item.Devremark ?? "";
        //            context.device_Remind.Add(entity);
        //            context.SaveChanges();
        //            DId += entity.ID + ",";
        //        }
        //        DId = DId.Length > 0 ? DId.Substring(0, DId.Length - 1) : "";
        //        return DId;
        //    }
        //}

        /// <summary>
        /// 修改到期提醒业务表和基础数据表
        /// </summary>
        /// <param name="MainId">主表ID</param>
        /// <param name="DId">明细表ID</param>
        /// <param name="EmpID">送检人员</param>
        /// <param name="Inspectiontime">送检时间</param>
        /// <param name="DevExpireDate">下次到期提醒日期</param>
        /// <returns></returns>
        //public bool UpdateDeviceRemind(string MainId, string DId, int EmpID, DateTime Inspectiontime, DateTime DevExpireDate)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        bool result = false;
        //        if (MainId != "")
        //        {
        //            string[] Mainlist = MainId.Split(',');
        //            for (int i = 0; i < Mainlist.Length; i++)
        //            {
        //                int status = GetExpireStatus(DevExpireDate);
        //                var ID = Convert.ToInt32(Mainlist[i]);
        //                var updateEnty = context.base_Tools.FirstOrDefault(x => x.id == ID);
        //                if (updateEnty != null)
        //                {
        //                    updateEnty.devExpireDate = DevExpireDate;
        //                    updateEnty.devStatus = status;
        //                    updateEnty.devInspectionCount = updateEnty.devInspectionCount + 1;
        //                    result = context.SaveChanges() > 0;
        //                }
        //            }
        //        }
        //        if (DId != "")
        //        {
        //            string[] detailList = DId.Split(',');
        //            for (int i = 0; i < detailList.Length; i++)
        //            {
        //                var RemindId = Convert.ToInt32(detailList[i]);

        //                var entity = context.device_Remind.FirstOrDefault(x => x.ID == RemindId);
        //                if (entity != null)
        //                {
        //                    entity.empID = EmpID;
        //                    entity.inspectiontime = Inspectiontime;
        //                    result = context.SaveChanges() > 0;
        //                }
        //            }
        //        }
        //        return result;
        //    }
        //}

        /// <summary>
        /// 保存送检
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveInspection(List<DeviceRemindModel> list)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = "";
                    int i;//受影响的行数

                    //经过前台判断,必然为数量>0,且到期时间有值
                    DateTime ExpireDate = list[0].DevExpireDate.Value;
                    var status = GetExpireStatus(ExpireDate);
                    string strMainID = string.Join(",", list.Select(_ => _.TId).Distinct());

                    //修改器具表
                    sql = "update base_tools set devExpireDate=@devExpireDate,devStatus=@devStatus,devInspectionCount=devInspectionCount+1 where id in(" + strMainID + ")";
                    pList.Add(new MySqlParameter("@devExpireDate", ExpireDate));
                    pList.Add(new MySqlParameter("@devStatus", status));
                    i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //添加提醒表（日志表）
                    foreach (var item in list)
                    {
                        sql = @"insert device_remind(TId,toolId,toolName,devCertificateNo,devPurchaseDate,devExpireDate,devStatus,empID,inspectiontime,devremark) 
                                values(@TId,@toolId,@toolName,@devCertificateNo,@devPurchaseDate,@devExpireDate,@devStatus,@empID,now(),@devremark)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@TId", item.TId));
                        pList.Add(new MySqlParameter("@toolId", item.ToolId));
                        pList.Add(new MySqlParameter("@toolName", item.ToolName));
                        pList.Add(new MySqlParameter("@devCertificateNo", item.DevCertificateNo));
                        pList.Add(new MySqlParameter("@devPurchaseDate", item.DevPurchaseDate));
                        pList.Add(new MySqlParameter("@DevExpireDate", item.DevExpireDate));
                        pList.Add(new MySqlParameter("@DevStatus", status));
                        pList.Add(new MySqlParameter("@empID", item.EmpID));
                        pList.Add(new MySqlParameter("@Devremark", item.Devremark));
                        i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    }
                    myTrans.Commit();
                }
                catch
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
            return true;
        }

        /// <summary>
        /// 获取到期状态 0:未到期 1:将到期 2:已到期
        /// </summary>
        /// <param name="ExpreDate">过期日期</param>
        /// <returns></returns>
        public int GetExpireStatus(DateTime ExpreDate)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            //过期天数
            string sql = @"select datediff(now(),@ExpreDate) ";
            pList.Add(new MySqlParameter("@ExpreDate", ExpreDate));
            int ExpireDayQty = db.ExecuteScalar(sql, pList.ToArray()).ToInt();
            //提前提醒天数
            int AdvanceDayQty = db.ExecuteScalar("select cfg_value from sys_config where cfg_code='ExpireReminderDay'", parms: null).ToInt();

            if (ExpireDayQty >= 0)
                return 2;//已到期
            else if (ExpireDayQty + AdvanceDayQty >= 0)
                return 1;//将到期
            return 0;//未到期
        }


        #endregion

        #region  设备保养计划

        /// <summary>
        /// 根据IP获取当月设备保养计划
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public Device_upKeepPlanModel GetUpKeepPlanIP(string IP)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select pl.id ID,dev.id DevID,dev.devName DevName,dev.devNo DevNo,dev.devIP IP,dev.devCardno DevCardno,pl.upKeepTypeID UpKeepTypeID 
                            ,type.bdname UpKeepType,pl.planMemo PlanMemo,pl.planDate PlanDate,pl.execDate ExecDate,pl.execStatus ExecStatus,pl.execEmp ExecEmp,pl.execEmpName ExecEmpName,pl.remark Remark 
                            from base_Device dev 
                            left join device_upKeepPlan pl on dev.id=pl.devID 
                            left join sys_baseData type on pl.upKeepTypeID=type.ID 
                            where DATE_FORMAT(pl.planDate,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and dev.devIP=@devIP";
            pList.Add(new MySqlParameter("@devIP", IP));
            List<Device_upKeepPlanModel> list = db.ExecuteList<Device_upKeepPlanModel>(sql, pList.ToArray());
            if (list.Count > 0) return list[0];
            return new Device_upKeepPlanModel();
        }

        /// <summary>
        /// 根据IP获取当月设备保养计划
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public List<DeviceSpotCheckModel> GetUpKeepPlanByIP(string IP)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            //string sql = @"select pl.id ID,dev.id DevID,dev.devName DevName,dev.devNo DevNo,dev.devIP IP,dev.devCardno DevCardno,pl.upKeepTypeID UpKeepTypeID 
            //        ,type.bdname UpKeepType,pl.planMemo PlanMemo,pl.planDate PlanDate,pl.execDate ExecDate,pl.execStatus ExecStatus,
            //        pl.execEmp ExecEmp,pl.execEmpName ExecEmpName,pl.remark Remark,p2.id as detailid,p2.uddesc,p2.udimg
            //        from base_Device dev 
            //        left join device_upKeepPlan pl on dev.id=pl.devID 
            //        left join sys_baseData type on pl.upKeepTypeID=type.ID 
            //        left join device_upkeepplandetail p2 on pl.id = p2.udid
            //        where DATE_FORMAT(pl.planDate,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and dev.devIP=@devIP and p2.udStatus = 0";
            string sql = @"select  pl.spotid,pl.dsc_category,pl.dsc_position,pl.dsc_project,pl.dsc_method,pl.dsc_criteria,pl.dsc_solving,pl.dsc_status,pl.dsc_cycle,pl.dsc_liable,pl.dsc_class,pl.dsc_img,pl.dsc_device
                    ,dev.id DevID,dev.devName DevName,dev.devNo DevNo,dev.devIP IP,dev.devCardno DevCardno
                    from base_Device dev 
                    left join device_spotcheck pl on dev.id=pl.dsc_device 
                    where dev.devIP=@devIP and pl.dsc_class = 0";
            pList.Add(new MySqlParameter("@devIP", IP));
            List<DeviceSpotCheckModel> list = db.ExecuteList<DeviceSpotCheckModel>(sql, pList.ToArray());
            if (list.Count > 0)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].dsc_status == 0)
                    {
                        list[i].dsc_statusname = "运行";
                    }
                    else
                    {
                        list[i].dsc_statusname = "停止";
                    }

                    if (list[i].dsc_cycle == 0)
                    {
                        list[i].dsc_cyclename = "日";
                    }
                    else if (list[i].dsc_cycle == 1)
                    {
                        list[i].dsc_cyclename = "周";
                    }
                    else
                    {
                        list[i].dsc_cyclename = "月";
                    }
                }

                return list;
            }

            return new List<DeviceSpotCheckModel>();
        }




        /// <summary>
        /// 执行设备保养计划
        /// </summary>
        /// <param name="devID"></param>
        /// <param name="UserID"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public bool UpdateDevExecTime(int devID, int UserID, string EmpName)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select count(1) from device_upKeepPlan where DATE_FORMAT(planDate,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and devID=@devID";
            pList.Add(new MySqlParameter("@devID", devID));
            int count = -1;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out count);
            if (count == -1) return false;
            pList.Add(new MySqlParameter("@execEmp", UserID));
            pList.Add(new MySqlParameter("@execEmpName", EmpName));
            if (count > 0)
                sql = @"update device_upKeepPlan set execDate=now(),execStatus=1,execEmp=@execEmp,execEmpName=@execEmpName 
                        where DATE_FORMAT(planDate,'%Y-%m')=DATE_FORMAT(NOW(),'%Y-%m') and devID=@devID";
            else
                sql = @"insert device_upKeepPlan(devID,upKeepTypeID,planDate,execDate,execStatus,execEmp,execEmpName) 
                        values(@devID,0,now(),now(),1,@execEmp,@execEmpName) ";
            return db.ExecuteNonQuery(sql, pList.ToArray()) > 0;
        }
        /// <summary>
        ///  点检首页 肖玉新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceCheckingModel> DevicePlandainjian(DeviceCheckingModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = " ";
           
            if (model.DevID > 0)
            {
                para += " and b.devID=@devID ";
                pList.Add(new MySqlParameter("@devID", model.DevID));
            }

            if (!string.IsNullOrEmpty(model.Checker))
            {
                para += "and s.empName like CONCAT('%',@Checker,'%') ";
                pList.Add(new MySqlParameter("@Checker", model.Checker));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"select COUNT(*) from base_device a   
                         left join device_checking b on a.id=b.devID 
                         left join sys_user s on b.CheckerID = s.userID
                         where a.id=b.devID" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select b.*,a.devName as DevName,s.empName as Checker from base_device a 
                    left join device_checking b on a.id=b.devID
                    left join sys_user s on b.CheckerID = s.userID
                    where a.id=b.devID" + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<DeviceCheckingModel> list = db.ExecuteList<DeviceCheckingModel>(sql, pList.ToArray());


            return list;

        }
        /// <summary>
        /// 点检明细表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceCheckingDetailsModel> DeviceCheckingDEtailsancheng(DeviceCheckingDetailsModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = " ";
            //if (!string.IsNullOrEmpty(model.gwname))
            //{
            //    para += "and a.gwname=@gwname ";
            //    pList.Add(new MySqlParameter("@gwname", model.gwname));
            //}
            //if (!string.IsNullOrEmpty(model.IP))
            //{
            //    para += "and a.IP like CONCAT('%',@IP,'%') ";
            //    pList.Add(new MySqlParameter("@IP", model.IP));
            //}
            //if (model.areaID != null && model.areaID != 0)
            //{
            //    para += "and a.areaID=@areaID ";
            //    pList.Add(new MySqlParameter("@areaID", model.areaID));
            //}
            if (model.DevCheckID > 0)
            {
                para += " and devCheckID=@devCheckID ";
                pList.Add(new MySqlParameter("@devCheckID", model.DevCheckID));
            }
            if (model.DevTypeID > 0)
            {
                para += " and devTypeID=@devTypeID ";
                pList.Add(new MySqlParameter("@devTypeID", model.DevTypeID));
            }


            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select COUNT(*) from device_checkingdetails  where 1=1" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select * from device_checkingdetails where 1=1" + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<DeviceCheckingDetailsModel> list = db.ExecuteList<DeviceCheckingDetailsModel>(sql, pList.ToArray());


            return list;


        }
        /// <summary>
        /// 保养首页 肖玉新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Device_upKeepPlanModel> DeviceCheckincektishouye(Device_upKeepPlanModel model, out int totalCount)
        {

            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = " ";

            if (model.DevID > 0)
            {
                para += " and b.devID=@devID ";
                pList.Add(new MySqlParameter("@devID", model.DevID));
            }
            if (!string.IsNullOrEmpty(model.ExecEmpName))
            {
                para += " and s.empName like CONCAT('%',@ExecEmpName,'%')";
                pList.Add(new MySqlParameter("@ExecEmpName", model.ExecEmpName));
            }


            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"select COUNT(*) from base_device a 
                          left join device_upkeepplan b on a.id=b.devID 
                          left join sys_user s on b.ExecEmp = s.userID
                          where b.devID=a.id" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select a.devName as DevName,b.*,s.empName as ExecEmpName from base_device a 
                    left join device_upkeepplan b on a.id=b.devID 
                    left join sys_user s on b.ExecEmp = s.userID
                    where b.devID=a.id" + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<Device_upKeepPlanModel> list = db.ExecuteList<Device_upKeepPlanModel>(sql, pList.ToArray());
 
            return list;

        }
        /// <summary>
        /// 保养明细
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Device_upkeepPlanDetailModel> DeviceCheckincektiminxin(Device_upkeepPlanDetailModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = " ";
            if (model.udID > 0)
            {
                para += " and b.udid=@udid ";
                pList.Add(new MySqlParameter("@udid", model.udID));
            }

            if (!string.IsNullOrEmpty(model.dsc_position))
            {
                para += " and dsc_position like CONCAT('%',@dsc_position,'%')";
                pList.Add(new MySqlParameter("@dsc_position", model.dsc_position));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select a.*,b.* from device_upkeepplan a left join device_upkeepplandetail b on a.id=b.udid where 1=1" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select a.*,b.* from device_upkeepplan a left join device_upkeepplandetail b on a.id=b.udid where 1=1" + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<Device_upkeepPlanDetailModel> list = db.ExecuteList<Device_upkeepPlanDetailModel>(sql, pList.ToArray());


            return list;
        }
        /// <summary>
        /// 保养明细显示图片
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Device_upkeepPlanDetailModel> DeviceCheckincektitupia(int id)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select * from device_upkeepplandetail where id = " + id + "";
            List<Device_upkeepPlanDetailModel> list = db.ExecuteList<Device_upkeepPlanDetailModel>(sql, pList.ToArray());
            return list;
        }
        #endregion

        #endregion


    }
}
