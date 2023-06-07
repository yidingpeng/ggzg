using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
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
    internal class DAL_GJInfo : IDAL_GJInfo
    {

        private const string _GJWLOPCType = "gjwlOPCType";

        #region 查询

        /// <summary>
        /// 根据工步配置ID获取工具配置信息列表
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        public List<GJInfo> GetGJInfoList(int gbID)
        {
            var query = QueryGBInfo();

            query = query.Where(q => q.ProgGbInfoID == gbID);

            var result = query.ToList();

            return result;
        }

        /// <summary>
        /// 根据工步配置ID获取工具配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GJInfo GetGJInfoDetail(int id)
        {
            var query = QueryGBInfo();

            var detail = query.FirstOrDefault(q => q.ID == id);

            return detail;
        }

        /// <summary>
        /// 获取工具/物料opc点位Tilte
        /// </summary>
        /// <returns></returns>
        public List<GJOPCType> GetGJOPCTypes()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select baseData.bdcode as Code,baseData.bdname as Name
                                   from sys_baseData baseData left join sys_baseDataType baseType 
                                   on baseData.bdtypeID=baseType.ID where baseType.typecode='" + _GJWLOPCType + "' and  baseData.isDeleted=0;";

            List<GJOPCType> list = db.ExecuteList<GJOPCType>(sql, pList.ToArray());

            return list;

        }

        /// <summary>
        /// 获取工位绑定的工具/物料 opc point 信息
        /// </summary>
        /// <returns></returns>
        public List<GJGWOPCPointInfo> GetGJGWOPCPointInfo(int progbID, int? gjID, int? wlID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();
             
            string sql = @"select pro.gwID from base_program pro
                                   left join program_gxinfo gx on pro.ID=gx.progID
                                   left join program_gbinfo gb on gx.ID=gb.progGxID
                                   where gb.ID=" + progbID;
            int GWId = 0;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out GWId);

            sql = @"select gpd.prodModelID from base_program pro
                                   left join program_gxinfo gx on pro.ID=gx.progID
                                   left join program_gbinfo gb on gx.ID=gb.progGxID
                                   left join gw_prod_def gpd on gpd.progID = pro.ID
                                   where gb.ID=" + progbID;
            int pmId = 0;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out pmId);

            sql = "select gjID,wlID,opcTypeID,opcDeviceName,opcTypeCode,opcValue from base_gjwlopcpoint where 1=1 ";
            pList.Clear();
            string para = string.Empty;
            if (GWId != 0)
            {
                para += " and gwID=@gwID";
                pList.Add(new MySqlParameter("@gwID", GWId));
            }
            if (pmId != 0)
            {
                para += " and pmodelID=@pmodelID";
                pList.Add(new MySqlParameter("@pmodelID", pmId));
            }
            if (gjID.HasValue)
            {
                para += " and gjID=@gjID";
                pList.Add(new MySqlParameter("@gjID", gjID));
            }
            if (wlID.HasValue)
            {
                para += " and wlID=@wlID";
                pList.Add(new MySqlParameter("@wlID", wlID));
            }

            List<GJGWOPCPointInfo> Opclist = db.ExecuteList<GJGWOPCPointInfo>(sql + para, pList.ToArray());

            return Opclist;
        }

        /// <summary>
        /// 返回工步下工具信息 2020-06-01
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private IQueryable<GJInfo> QueryGBInfo()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            // wl.ID AS WLID, 换成条码卡管理ID mb.ID AS WLID,
            string sql = @"SELECT
	                           prodGj.ID,
	                           prodGj.progGbInfoID AS ProgGbInfoID,
	                           gj.ID AS GJID,
	                           gj.gjname AS GJName,
	                           prodGj.gjOrder AS GJOrder,
	                           wl.ID AS WLID,
	                           CONCAT_WS(' - ',wl.mName,wl.mDrawingNo) AS WLName,
                               prodGj.wlOrder AS WLOrder,
	                           prodGj.pgjInfoStatus AS PGJInfoStatus,
	                           prodGj.remark AS Remark
                            FROM
	                            program_gjinfo prodGj
                            LEFT JOIN base_gongju gj ON prodGj.gjID = gj.ID
                            LEFT JOIN base_material wl ON prodGj.wlID = wl.ID
                            ORDER BY prodGj.progGbInfoID,prodGj.gjOrder,prodGj.wlOrder;";

            //mb.ID AS WLID,
            //LEFT JOIN base_materialbarcode mb ON prodGj.wlID = mb.ID
            //LEFT JOIN base_material wl ON mb.m_MaterialID = wl.ID
            IQueryable<GJInfo> Gjlist = db.ExecuteList<GJInfo>(sql, pList.ToArray()).AsQueryable();

            return GetProgramValueInfoHavSubTable(Gjlist);
        }

        /// <summary>
        /// 获取下级程序检测项标准范围表
        /// </summary>
        /// <param name="list">工具list</param>
        /// <returns></returns>
        IQueryable<GJInfo> GetProgramValueInfoHavSubTable(IQueryable<GJInfo> list)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            var ID = list.Count() > 0 ? string.Join(",", list.Select(_ => _.ID)) : "0";
            string sql = "select progGjInfoID as ProgGjInfoID,count(*) rowcount from program_valueinfo where progGjInfoID in(" + ID + ") group by progGjInfoID";
            List<ValueInfo> ValueInfoList = db.ExecuteList<ValueInfo>(sql, pList.ToArray());
            if (ValueInfoList.Count > 0)
            {
                foreach (var pg in list)
                {
                    foreach (var item in ValueInfoList)
                    {
                        if (item.ProgGjInfoID == pg.ID)
                        {
                            pg.HavSubTable = item.rowcount > 0 ? true : false;
                        }
                    }
                }
            }

            sql = @"select opc.progGjInfoID,baseData.bdcode as Code,baseData.bdname as Name,opc.opcValue as Value from sys_baseData baseData 
                  left join sys_baseDataType baseType
                  on baseType.ID=baseData.bdtypeID
                  left join program_GjwlOPCInfo opc
                  on baseData.bdcode=opc.opcTypeCode
                  where baseType.typecode='" + _GJWLOPCType + "' and opc.progGjInfoID in(" + ID + ")";
            List<GJOPCType> GJOpcList = db.ExecuteList<GJOPCType>(sql, pList.ToArray());
            if (GJOpcList.Count > 0)
            {
                foreach (var wp in list)
                {
                    List<GJOPCType> tempList = wp.GJOPCTypes.ToList();
                    foreach (var item in GJOpcList)
                    {
                        if (!item.progGjInfoID.HasValue) continue;
                        if (item.progGjInfoID.Value == wp.ID)
                            tempList.Add(item);
                    }
                    wp.GJOPCTypes = tempList;
                }
            }
            return list;
        }
        #endregion

        #region 添加
        public void AddGJInfo(GJInfo gjInfo)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();

                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

                List<MySqlParameter> pList = new List<MySqlParameter>();

                try
                {
                    //获取最大的物料序号
                    string sql = @"select max(wlOrder) AS wlOrder from program_gjinfo where progGbInfoID=" + gjInfo.ProgGbInfoID;
                    int wlOrder = 0;
                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out wlOrder);

                    //获取最大的工具序号
                    int gjOrder = 0;
                    sql = @"select max(gjOrder) AS gjOrder from program_gjinfo where progGbInfoID=" + gjInfo.ProgGbInfoID;
                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out gjOrder);

                    pList.Clear();
                    sql = @"insert into program_gjinfo(progGbInfoID,gjID,gjOrder,wlID,wlOrder,pgjInfoStatus,remark)
                            values(@progGbInfoID,@gjID,@gjOrder,@wlID,@wlOrder,@pgjInfoStatus,@remark)";
                    pList.Add(new MySqlParameter("progGbInfoID", gjInfo.ProgGbInfoID));
                    pList.Add(new MySqlParameter("gjID", gjInfo.GJID ?? 0));
                    pList.Add(new MySqlParameter("gjOrder", gjInfo.GJID == null ? 0 : gjOrder + 1));
                    pList.Add(new MySqlParameter("wlID", gjInfo.WLID ?? 0));
                    pList.Add(new MySqlParameter("wlOrder", gjInfo.WLID == null ? 0 : wlOrder + 1));
                    pList.Add(new MySqlParameter("pgjInfoStatus", gjInfo.PGJInfoStatus ?? 0));
                    pList.Add(new MySqlParameter("remark", gjInfo.Remark ?? string.Empty));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //获取自增长ID
                    int prgGjInfoId = 0;
                    pList.Clear();
                    sql = "select @@identity";
                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out prgGjInfoId);

                    //添加 工位/物料 opc point 信息
                    if (gjInfo.GJOPCTypes.Count() > 0)
                    {
                        var gjOpcCode = string.Join(",", gjInfo.GJOPCTypes.Select(_ => _.Code));
                        string s1_1 = gjOpcCode.Replace(",", "','"); //返回结果为：1','2','3','4','5','6
                        string opcTypes = string.Format("'{0}'", s1_1);

                        sql = "select ID,bdcode from sys_baseData where bdtypeCode='" + _GJWLOPCType + "' and bdcode in(" + opcTypes + ")";
                        DataTable dt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        //DataTable 转为数据
                        var baseDataOPC = db.ToList<sys_baseData>(dt).ToArray();

                        //获取工位绑定的opc point 信息
                        var gjwlOpcPoint = GetGJGWOPCPointInfo(gjInfo.ProgGbInfoID.Value, gjInfo.GJID, gjInfo.WLID);

                        foreach (var item in gjInfo.GJOPCTypes)
                        {
                            sql = @"insert into program_gjwlopcinfo(progGjInfoID,opcTypeID,opcDeviceName,opcTypeCode,opcValue)
                                            values(@progGjInfoID,@opcTypeID,@opcDeviceName,@opcTypeCode,@opcValue)";
                            pList.Clear();

                            var opcTypeID = baseDataOPC.Where(f => f.bdcode == item.Code).Select(f => f.ID).FirstOrDefault();
                            var opcDeviceName = gjwlOpcPoint.Where(f => f.opcTypeCode == item.Code).Select(f => f.opcDeviceName).FirstOrDefault();

                            pList.Add(new MySqlParameter("@progGjInfoID", prgGjInfoId));
                            pList.Add(new MySqlParameter("@opcTypeID", opcTypeID));
                            pList.Add(new MySqlParameter("@opcDeviceName", opcDeviceName));
                            pList.Add(new MySqlParameter("@opcTypeCode", item.Code));
                            pList.Add(new MySqlParameter("@opcValue", item.Value));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }

                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
        }

        #endregion

        #region 编辑

        /// <summary>
        /// 编辑工具配置信息
        /// </summary>
        /// <param name="gjInfo"></param>
        public void EditGJInfo(GJInfo gjInfo)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();

                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

                List<MySqlParameter> pList = new List<MySqlParameter>();

                try
                {
                    string sql = "select * from program_gjinfo where ID=" + gjInfo.ID;

                    DataTable dt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    if (dt.Rows.Count == 0)
                    {
                        throw new Exception(string.Format("没有找到名称为：{0} 工具配置信息！", gjInfo.GJName));
                    }
                    sql = @"update program_gjinfo set gjID=@gjID,wlID=@wlID,pgjInfoStatus=@pgjInfoStatus,remark=@remark where ID=@ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@gjID", gjInfo.GJID ?? 0));
                    pList.Add(new MySqlParameter("@wlID", gjInfo.WLID ?? 0));
                    pList.Add(new MySqlParameter("@pgjInfoStatus", gjInfo.PGJInfoStatus ?? 0));
                    pList.Add(new MySqlParameter("@remark", gjInfo.Remark ?? string.Empty));
                    pList.Add(new MySqlParameter("@ID", gjInfo.ID));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    sql = "select *  from program_gjwlopcinfo where progGjInfoID=" + gjInfo.ID;
                    pList.Clear();
                    DataTable _gjwlopcinfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    if (gjInfo.GJOPCTypes.Count() == 0)
                    {
                        if (_gjwlopcinfo.Rows.Count > 0)
                        {
                            sql = "delete from program_gjwlopcinfo where progGjInfoID=" + gjInfo.ID;
                            pList.Clear();
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    else
                    {
                        var gjOpcCode = string.Join(",", gjInfo.GJOPCTypes.Select(_ => _.Code));
                        string s1_1 = gjOpcCode.Replace(",", "','"); //返回结果为：1','2','3','4','5','6
                        string opcTypes = string.Format("'{0}'", s1_1);

                        sql = "select ID,bdcode from sys_baseData where bdtypeCode='" + _GJWLOPCType + "' and bdcode in(" + opcTypes + ")";
                        DataTable Table = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        //DataTable 转为数据
                        var baseDataOPC = db.ToList<sys_baseData>(Table).ToArray();
                  
                        //获取工位绑定的opc point 信息
                        var gjwlOpcPoint = GetGJGWOPCPointInfo(dt.Rows[0]["progGbInfoID"].ToInt(), gjInfo.GJID, gjInfo.WLID);
                        List<program_GjwlOPCInfo> _OpcList = db.ToList<program_GjwlOPCInfo>(_gjwlopcinfo);
                        foreach (var item in gjInfo.GJOPCTypes)
                        {
                            var opcInfo = _OpcList.Where(f => f.opcTypeCode == item.Code).FirstOrDefault();
                            if (opcInfo != null)//修改
                            {
                                pList.Clear();
                                sql = @"update program_gjwlopcinfo set opcTypeCode=@opcTypeCode,opcTypeID=@opcTypeID,opcDeviceName=@opcDeviceName,
                                                opcValue=@opcValue where ID=@ID";

                                var opcTypeID = baseDataOPC.Where(f => f.bdcode == item.Code).Select(f => f.ID).FirstOrDefault();
                                var opcDeviceName = gjwlOpcPoint.Where(f => f.opcTypeCode == item.Code).Select(f => f.opcDeviceName).FirstOrDefault();

                                pList.Add(new MySqlParameter("@opcTypeCode", item.Code));
                                pList.Add(new MySqlParameter("@opcTypeID", opcTypeID));
                                pList.Add(new MySqlParameter("@opcDeviceName", opcDeviceName));
                                pList.Add(new MySqlParameter("@opcValue", item.Value));
                                pList.Add(new MySqlParameter("@ID", opcInfo.ID));
                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            }
                            else
                            {
                                sql = @"insert into program_gjwlopcinfo(progGjInfoID,opcTypeID,opcDeviceName,opcTypeCode,opcValue)
                                            values(@progGjInfoID,@opcTypeID,@opcDeviceName,@opcTypeCode,@opcValue)";
                                pList.Clear();

                                var opcTypeID = baseDataOPC.Where(f => f.bdcode == item.Code).Select(f => f.ID).FirstOrDefault();
                                var opcDeviceName = gjwlOpcPoint.Where(f => f.opcTypeCode == item.Code).Select(f => f.opcDeviceName).FirstOrDefault();

                                pList.Add(new MySqlParameter("@progGjInfoID", gjInfo.ID));
                                pList.Add(new MySqlParameter("@opcTypeID", opcTypeID));
                                pList.Add(new MySqlParameter("@opcDeviceName", opcDeviceName));
                                pList.Add(new MySqlParameter("@opcTypeCode", item.Code));
                                pList.Add(new MySqlParameter("@opcValue", item.Value));
                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            }
                        }

                        //删除不包含这些点位的类型
                        sql = "select *  from program_gjwlopcinfo where progGjInfoID=" + gjInfo.ID + " and opcTypeCode not in(" + opcTypes + ")";
                        pList.Clear();
                        DataTable _delOpcList = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        if (_delOpcList.Rows.Count > 0)
                        {
                            sql = "delete from program_gjwlopcinfo where progGjInfoID=" + gjInfo.ID + " and opcTypeCode not in(" + opcTypes + ")";
                            pList.Clear();
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();

                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    throw;
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
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
                    string sql = "select ID,progGbInfoID,gjID,gjOrder,wlID,wlOrder from program_gjinfo where ID=" + id;
                    List<program_GjInfo> list = db.ExecuteList<program_GjInfo>(sql, pList.ToArray());
                    if (list.Count == 0)
                    {
                        throw new Exception(string.Format("没有找到ID为：{0} 工具配置信息！", id));
                    }
                    if (list[0].gjOrder == 1 && isUp)
                    {
                        return;
                    }
                    string strGetGjwl = string.Format(@"select (case when gjID>0 then 'gjOrder' when wlID>0 then 'wlOrder' else '' end) as gjOrWl 
                                                 from program_gjinfo where progGbInfoID={0} and id={1}", list[0].progGbInfoID, id);
                    string strColName = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, strGetGjwl).ToString();
                    if (strColName != "")
                    {
                        if (isUp)
                        {
                            //update上一点排序的记录+1
                            string strUpdateLast = string.Format(@"update program_gjinfo a,(select ({2}-1) as {2} from program_gjinfo where progGbInfoID={0} 
                                            and id={1}) b set a.{2}=a.{2}+1 where progGbInfoID={0} and a.{2}=b.{2}", list[0].progGbInfoID, id, strColName);
                            int updateLast = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateLast);

                            //update当前ID的序号的排序-1
                            string strUpdateCur = string.Format(@"update program_gjinfo set {2}={2}-1 where progGbInfoID={0} and id={1} ", list[0].progGbInfoID, id, strColName);
                            int updateCur = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateCur);
                            if (updateLast >= 1 && updateCur >= 1)
                            {
                                myTrans.Commit();
                            }
                            else
                            {
                                myTrans.Rollback();
                            }
                        }
                        else
                        {
                            //update上一点排序的记录+1
                            string strUpdateLast = string.Format(@"update program_gjinfo a,(select ({2}+1) as {2} from program_gjinfo where progGbInfoID={0} 
                                            and id={1}) b set a.{2}=a.{2}-1 where progGbInfoID={0} and a.{2}=b.{2}", list[0].progGbInfoID, id, strColName);
                            int updateLast = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateLast);

                            //update当前ID的序号的排序-1
                            string strUpdateCur = string.Format(@"update program_gjinfo set {2}={2}+1 where progGbInfoID={0} and id={1} ", list[0].progGbInfoID, id, strColName);
                            int updateCur = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateCur);
                            if (updateLast >= 1 && updateCur >= 1)
                            {
                                myTrans.Commit();
                            }
                            else
                            {
                                myTrans.Rollback();
                            }
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
        /// 删除工具配置信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGJInfo(int id)
        {
            program_GjInfo item = GetGjInfoData(id);
            if (item == null)
            {
                throw new Exception(string.Format("没有找到ID为：{0} 工具配置信息！", id));
            }
            DelGJInfo(item);

            OrderSet(item);

        }
        public program_GjInfo GetGjInfoData(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,progGbInfoID,gjID,gjOrder,wlID,wlOrder from program_gjinfo where ID=" + id;

            List<program_GjInfo> list = db.ExecuteList<program_GjInfo>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                program_GjInfo gjInfo = null;
                return gjInfo;
            }

            return list[0];
        }

        /// <summary>
        /// 删除多个工具配置信息
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="context"></param>
        public void DeleteGJInfo(int[] ids)
        {
            foreach (var ID in ids)
            {
                program_GjInfo item = GetGjInfoData(ID);
                if (item != null)
                {
                    DelGJInfo(item);
                }
            }
        }

        private void DelGJInfo(program_GjInfo entity)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            //删除工具信息
            string sql = "delete from program_gjinfo where ID=" + entity.ID;
            db.ExecuteNonQuery(sql, pList.ToArray());

            //删除 工具/物料 opc点位信息
            sql = "delete from program_gjwlopcinfo where progGjInfoID=" + entity.ID;
            db.ExecuteNonQuery(sql, pList.ToArray());

            sql = "select ID from program_valueinfo where progGjInfoID=" + entity.ID;
            List<program_ValueInfo> Valuelist = db.ExecuteList<program_ValueInfo>(sql, pList.ToArray());

            //删除对应的检测项标准范围
            var ValueInfoId = Valuelist.Count() > 0 ? string.Join(",", Valuelist.Select(_ => _.ID)) : "0";

            int[] valueIds = Array.ConvertAll(ValueInfoId.Split(','), int.Parse);

            DIService.GetService<IDAL_ValueInfo>().DeleteValueInfo(valueIds);
        }

        private void OrderSet(program_GjInfo entity)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,progGbInfoID,gjID,gjOrder,wlID,wlOrder from program_gjinfo where progGbInfoID=@progGbInfoID order by gjOrder";
            pList.Clear();
            pList.Add(new MySqlParameter("@progGbInfoID", entity.progGbInfoID));
            List<program_GjInfo> list = db.ExecuteList<program_GjInfo>(sql, pList.ToArray());
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sql = "update program_gjinfo set gjOrder=@gjOrder where ID=@ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@gjOrder", i + 1));
                    pList.Add(new MySqlParameter("@ID", list[i].ID));
                    db.ExecuteNonQuery(sql, pList.ToArray());
                }
            }
        }

        #endregion

    }
}
