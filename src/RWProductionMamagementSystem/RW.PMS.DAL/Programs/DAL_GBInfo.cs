using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using MySql.Data.MySqlClient;
using System.Data;

namespace RW.PMS.DAL
{
    internal class DAL_GBInfo : IDAL_GBInfo
    {

        #region 查询

        /// <summary>
        /// 根据工序配置ID获取工步配置信息列表
        /// </summary>
        /// <param name="gxID"></param>
        /// <returns></returns>
        public List<GBInfo> GetGBInfoList(int gxID)
        {

            var query = QueryGBInfo();

            query = query.Where(q => q.ProgGxID == gxID);

            var result = query.ToList();

            return result;
        }

        /// <summary>
        /// 根据工序配置ID获取工步配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GBInfo GetGBInfoDetail(int id)
        {
            var query = QueryGBInfo();

            var detail = query.FirstOrDefault(q => q.ID == id);

            return detail;
        }

        /// <summary>
        /// 获取工步关联
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private IQueryable<GBInfo> QueryGBInfo()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"SELECT
	                        progGb.ID,
	                        progGb.progGxID AS ProgGxID,
	                        progGb.gbname AS GBName,
	                        progGb.gbDelayTime AS GBDelayTime,
	                        progGb.gbOrder AS GBOrder,
                            progGb.gbDesc,
                            progGb.gbImg,
	                        progGb.ifzhuanxu AS IfZhuanXu,
	                        progGb.isScan AS IsScan,
	                        progGb.isInputPInfo AS IsInputPInfo,
	                        progGb.isScanOrderNo AS IsScanOrderNo,
	                        progGb.isEmpCheck AS IsEmpCheck,
	                        progGb.ErrTypeID,
	                        GetbdNameBybdID (progGb.ErrTypeID) AS ErrTypeName,
	                        progGb.controlTypeID AS ControlTypeID,
	                        GetbdNameBybdID (progGb.controlTypeID) AS ControlTypeName,
	                        progGb.pgbInfoStatus AS PGBInfoStatus,
	                        progGb.remark AS Remark
                        FROM
	                        program_gbinfo progGb
                        ORDER BY
	                        progGb.gbOrder";

            IQueryable<GBInfo> GBlist = db.ExecuteList<GBInfo>(sql, pList.ToArray()).AsQueryable();

            return GetProgramGjInfoHavSubTable(GBlist);
        }

        IQueryable<GBInfo> GetProgramGjInfoHavSubTable(IQueryable<GBInfo> list)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            var ID = list.Count() > 0 ? string.Join(",", list.Select(_ => _.ID)) : "0";

            string sql = "select progGbInfoID as ProgGbInfoID,count(*) rowcount from program_gjinfo where progGbInfoID in(" + ID + ") group by progGbInfoID";

            List<GJInfo> GjInfoList = db.ExecuteList<GJInfo>(sql, pList.ToArray());

            if (GjInfoList.Count > 0)
            {
                foreach (var pg in list)
                {
                    foreach (var item in GjInfoList)
                    {
                        if (item.ProgGbInfoID == pg.ID)
                        {
                            pg.HavSubTable = item.rowcount > 0 ? true : false;
                        }
                    }
                }
            }

            return list;
        }

        #endregion

        #region 添加
        public void AddGBInfo(GBInfo gbInfo)
        {
            var db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            //获取最大的工步序号
            string sql = "select max(gbOrder) AS gbOrder from program_gbinfo where progGxID=" + gbInfo.ProgGxID;
            int gbOrder = 0;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out gbOrder);

            sql = @"INSERT INTO program_gbinfo (
	            progGxID,
	            gbname,
	            gbimg,
	            gbdesc,
	            gbOrder,
	            controlTypeID,
	            gbDelayTime,
	            isScan,
	            isEmpCheck,
	            isInputPInfo,
	            isScanOrderNo,
	            ifzhuanxu,
	            ErrTypeID,
	            pgbInfoStatus,
	            remark
            )
            VALUES
	            (
		            @progGxID ,@gbname ,@gbimg, @gbdesc ,@gbOrder,
		            @controlTypeID ,@gbDelayTime ,@isScan ,@isEmpCheck ,@isInputPInfo ,@isScanOrderNo ,@ifzhuanxu ,@ErrTypeID ,@pgbInfoStatus ,@remark
	            )";
            pList.Clear();
            pList.Add(new MySqlParameter("@progGxID", gbInfo.ProgGxID));
            pList.Add(new MySqlParameter("@gbname", gbInfo.GBName));
            pList.Add(new MySqlParameter("@gbimg", gbInfo.GBImg));
            pList.Add(new MySqlParameter("@gbdesc", gbInfo.GBDesc));
            pList.Add(new MySqlParameter("@gbOrder", gbOrder + 1));
            pList.Add(new MySqlParameter("@controlTypeID", gbInfo.ControlTypeID ?? 0));
            pList.Add(new MySqlParameter("@gbDelayTime", gbInfo.GBDelayTime));
            pList.Add(new MySqlParameter("@isScan", gbInfo.IsScan ?? 0));
            pList.Add(new MySqlParameter("@isEmpCheck", gbInfo.IsEmpCheck ?? 0));
            pList.Add(new MySqlParameter("@isInputPInfo", gbInfo.IsInputPInfo ?? 0));
            pList.Add(new MySqlParameter("@isScanOrderNo", gbInfo.IsScanOrderNo ?? 0));
            pList.Add(new MySqlParameter("@ifzhuanxu", gbInfo.IfZhuanXu ?? 0));
            pList.Add(new MySqlParameter("@ErrTypeID", gbInfo.ErrTypeID ?? 0));
            pList.Add(new MySqlParameter("@pgbInfoStatus", gbInfo.PGBInfoStatus ?? 0));
            pList.Add(new MySqlParameter("@remark", gbInfo.Remark ?? string.Empty));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }
        #endregion

        #region 编辑

        /// <summary>
        /// 编辑工步配置信息
        /// </summary>
        /// <param name="gbInfo"></param>
        public void EditGBInfo(GBInfo gbInfo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,progGxID,gbOrder from program_gbinfo where ID=" + gbInfo.ID;

            List<program_GbInfo> list = db.ExecuteList<program_GbInfo>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                throw new Exception(string.Format("没有找到名称为：{0} 工步配置信息！", gbInfo.GBName));
            }

            sql = @"UPDATE program_gbinfo
                    SET gbname =@gbname,
                     gbimg=@gbimg,
                     gbdesc=@gbdesc,
                     ErrTypeID =@ErrTypeID,
                     gbDelayTime =@gbDelayTime,
                     isEmpCheck =@isEmpCheck,
                     isInputPInfo =@isInputPInfo,
                     isScan =@isScan,
                     isScanOrderNo =@isScanOrderNo,
                     pgbInfoStatus =@pgbInfoStatus,
                     controlTypeID =@controlTypeID,
                     remark =@remark
                    WHERE
	                    ID =@ID";
            pList.Clear();
            pList.Add(new MySqlParameter("@gbname", gbInfo.GBName));
            pList.Add(new MySqlParameter("@gbimg", gbInfo.GBImg));
            pList.Add(new MySqlParameter("@gbdesc", gbInfo.GBDesc));
            pList.Add(new MySqlParameter("@ErrTypeID", gbInfo.ErrTypeID ?? 0));
            pList.Add(new MySqlParameter("@gbDelayTime", gbInfo.GBDelayTime));
            pList.Add(new MySqlParameter("@isEmpCheck", gbInfo.IsEmpCheck ?? 0));
            pList.Add(new MySqlParameter("@isInputPInfo", gbInfo.IsInputPInfo ?? 0));
            pList.Add(new MySqlParameter("@isScan", gbInfo.IsScan ?? 0));
            pList.Add(new MySqlParameter("@isScanOrderNo", gbInfo.IsScanOrderNo ?? 0));
            pList.Add(new MySqlParameter("@pgbInfoStatus", gbInfo.PGBInfoStatus ?? 0));
            pList.Add(new MySqlParameter("@controlTypeID", gbInfo.ControlTypeID ?? 0));
            pList.Add(new MySqlParameter("@remark", gbInfo.Remark ?? string.Empty));
            pList.Add(new MySqlParameter("@ID", gbInfo.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 排序设置
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isUp">是否为向上排序</param>
        public void OrderSet(int id, bool isUp)
        {

            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();

                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

                List<MySqlParameter> pList = new List<MySqlParameter>();

                try
                {
                    string sql = "select ID,progGxID,gbOrder from program_gbinfo where ID=" + id;
                    List<program_GbInfo> list = db.ExecuteList<program_GbInfo>(sql, pList.ToArray());
                    if (list.Count == 0)
                    {
                        throw new Exception(string.Format("没有找到ID为：{0} 工步配置信息！", id));
                    }
                    if (list[0].gbOrder == 1 && isUp)
                    {
                        return;
                    }
                    if (isUp)
                    {
                        //update上一点排序的记录+1
                        string strUpdateLast = string.Format(@"update program_gbinfo a,(select (gbOrder-1) as gbOrder from program_gbinfo where progGxID={0} and id={1} ) as b
                                                      set a.gbOrder=a.gbOrder+1 where a.progGxID={0} and a.gbOrder=b.gbOrder", list[0].progGxID, id);
                        int updateLast = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateLast);


                        //update当前ID的序号的排序-1
                        string strUpdateCur = string.Format(@"update program_gbinfo set gbOrder=gbOrder-1 where progGxID={0} and id={1} ", list[0].progGxID, id);
                        int updateCur = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateCur);

                        if (updateLast >= 1 && updateCur >= 1)
                        {
                            myTrans.Commit();
                            return;
                        }
                        else
                        {
                            myTrans.Rollback();
                            return;
                        }
                    }
                    else
                    {
                        //update上一点排序的记录+1
                        string strUpdateLast = string.Format(@"update program_gbinfo a,(select (gbOrder+1) as gbOrder from program_gbinfo where progGxID={0} and id={1} ) as b
                                                      set a.gbOrder=a.gbOrder-1 where a.progGxID={0} and a.gbOrder=b.gbOrder", list[0].progGxID, id);
                        int updateLast = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateLast);


                        //update当前ID的序号的排序-1
                        string strUpdateCur = string.Format(@"update program_gbinfo set gbOrder=gbOrder+1 where progGxID={0} and id={1} ", list[0].progGxID, id);
                        int updateCur = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateCur);

                        if (updateLast >= 1 && updateCur >= 1)
                        {
                            myTrans.Commit();
                            return;
                        }
                        else
                        {
                            myTrans.Rollback();
                            return;
                        }
                    }
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
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除一个工步配置信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGBInfo(int id)
        {
            program_GbInfo item = GetGbInfoData(id);

            if (item == null)
            {
                throw new Exception(string.Format("没有找到ID为：{0} 工步配置信息！", id));
            }

            DelGBInfo(item);

            OrderSet(item.progGxID.Value);
        }
        public program_GbInfo GetGbInfoData(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,progGxID,gbOrder from program_gbinfo where ID=" + id;

            List<program_GbInfo> list = db.ExecuteList<program_GbInfo>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                program_GbInfo gbInfo = null;
                return gbInfo;
            }

            return list[0];
        }
        /// <summary>
        /// 删除多个工步配置信息
        /// </summary>
        /// <param name="ids"></param>
        public void DeleteGBInfo(int[] ids)
        {
            foreach (var ID in ids)
            {
                program_GbInfo item = GetGbInfoData(ID);
                if (item != null)
                {
                    DelGBInfo(item);
                }
            }
        }

        private int DelGBInfo(program_GbInfo entity)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from program_gbinfo where ID=" + entity.ID;

            db.ExecuteNonQuery(sql, pList.ToArray());

            sql = "select ID from program_gjinfo where progGbInfoID=" + entity.ID;

            List<program_GjInfo> Gjlist = db.ExecuteList<program_GjInfo>(sql, pList.ToArray());

            //获取所有工序ID为string字符串，转换为int数据类型
            var GjInfoId = Gjlist.Count() > 0 ? string.Join(",", Gjlist.Select(_ => _.ID)) : "0";

            int[] GjIds = Array.ConvertAll(GjInfoId.Split(','), int.Parse);

            DIService.GetService<IDAL_GJInfo>().DeleteGJInfo(GjIds);

            return entity.progGxID.Value;

        }

        private void OrderSet(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,progGxID,gbOrder from program_gbinfo where progGxID=@progGxID order by gbOrder";

            pList.Clear();

            pList.Add(new MySqlParameter("@progGxID", id));

            List<program_GbInfo> list = db.ExecuteList<program_GbInfo>(sql, pList.ToArray());

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sql = "update program_gbinfo set gbOrder=@gbOrder where ID=@ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@gbOrder", i + 1));
                    pList.Add(new MySqlParameter("@ID", list[i].ID));
                    db.ExecuteNonQuery(sql, pList.ToArray());
                }
            }
        }

        #endregion
    }
}
