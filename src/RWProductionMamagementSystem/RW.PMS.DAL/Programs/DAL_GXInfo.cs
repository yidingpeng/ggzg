using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.DAL
{
    internal class DAL_GXInfo : IDAL_GXInfo
    {

        #region 查询

        /// <summary>
        /// 根据程序ID获取工序配置信息列表
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public List<GXInfo> GetGXInfoList(int progID)
        {
            var query = QueryGXInfo();

            query = query.Where(q => q.ProgID == progID);

            var result = query.ToList();

            return result;
        }

        /// <summary>
        /// 根据程序ID获取工序配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GXInfo GetGXInfoDetail(int id)
        {
            var query = QueryGXInfo();

            var detail = query.FirstOrDefault(q => q.ID == id);

            return detail;
        }

        private IQueryable<GXInfo> QueryGXInfo()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select 
                                pg.ID,
                                pg.progID,
                                pg.Gxname,
                                pg.gxOrder,
                                pg.pgxInfoStatus,
                                pg.Gxvedio,
                                pg.GxvedioFilename,
                                pg.descript as GXDesc,
                                pg.remark
                            from program_GxInfo pg 
                            ORDER BY pg.gxOrder";

            IQueryable<GXInfo> GXlist = db.ExecuteList<GXInfo>(sql, pList.ToArray()).AsQueryable();

            return GetProgramGbInfoHavSubTable(GXlist);
        }

        /// <summary>
        /// 获取下级程序工步
        /// </summary>
        /// <param name="list">工序list</param>
        /// <returns></returns>
        IQueryable<GXInfo> GetProgramGbInfoHavSubTable(IQueryable<GXInfo> list)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            var ID = list.Count() > 0 ? string.Join(",", list.Select(_ => _.ID)) : "0";

            string sql = "select progGxID ,count(*) rowcount from program_gbinfo where progGxID in(" + ID + ") group by progGxID";

            List<GBInfo> GxInfoList = db.ExecuteList<GBInfo>(sql, pList.ToArray());

            if (GxInfoList.Count > 0)
            {
                foreach (var pg in list)
                {
                    foreach (var item in GxInfoList)
                    {
                        if (item.ProgGxID == pg.ID)
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
        public void AddGXInfo(GXInfo gxInfo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select COUNT(gxOrder) AS GXOrder from program_gxinfo where progID=" + gxInfo.ProgID;

            int gxOrder = 0;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out gxOrder);

            string InsertSql = @"INSERT INTO program_gxinfo (
	                                progID,
	                                gxname,
	                                gxvedio,
	                                GxvedioFilename,
	                                gxOrder,
	                                descript,
	                                pgxInfoStatus,
	                                remark
                                )
                                VALUES
	                                (
		                                @progID,
		                                @gxname,
		                                @gxvedio,
		                                @gxvedioFilename,
                                        @gxOrder,
		                                @descript,
		                                @pgxInfoStatus,
		                                @remark
	                                )";
            pList.Add(new MySqlParameter("@progID", gxInfo.ProgID));
            pList.Add(new MySqlParameter("@gxname", gxInfo.GXName));
            pList.Add(new MySqlParameter("@gxvedio", gxInfo.GXVedio));
            pList.Add(new MySqlParameter("@gxvedioFilename", gxInfo.GXVedioFilename));
            pList.Add(new MySqlParameter("@descript", gxInfo.GXDesc));
            pList.Add(new MySqlParameter("@gxOrder", gxOrder + 1));
            pList.Add(new MySqlParameter("@pgxInfoStatus", gxInfo.PGXInfoStatus));
            pList.Add(new MySqlParameter("@remark", gxInfo.Remark ?? string.Empty));

            db.ExecuteNonQuery(InsertSql, pList.ToArray());

        }
        #endregion

        #region 编辑

        /// <summary>
        /// 修改工序配置信息
        /// </summary>
        /// <param name="gxInfo"></param>
        public void EditGXInfo(GXInfo gxInfo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select COUNT(ID) from program_gxinfo where ID=" + gxInfo.ID;

            var count = db.ExecuteScalar<int>(sql, pList.ToArray());

            if (count == 0)
            {
                throw new Exception(string.Format("没有找打名称为：{0} 的工序配置信息！", gxInfo.GXName));
            }

            sql = @"UPDATE program_gxinfo
                    SET gxname = @gxname,
                     gxvedio = @gxvedio,
                     gxvedioFilename = @gxvedioFilename, descript = @descript,
                     pgxInfoStatus = @pgxInfoStatus,
                     remark = @remark
                    WHERE
                        ID = @ID";

            pList.Clear();
            pList.Add(new MySqlParameter("@gxname", gxInfo.GXName));
            pList.Add(new MySqlParameter("@gxvedio", gxInfo.GXVedio));
            pList.Add(new MySqlParameter("@gxvedioFilename", gxInfo.GXVedioFilename));
            pList.Add(new MySqlParameter("@pgxInfoStatus", gxInfo.PGXInfoStatus ?? 0));
            pList.Add(new MySqlParameter("@descript", gxInfo.GXDesc));
            pList.Add(new MySqlParameter("@remark", gxInfo.Remark));
            pList.Add(new MySqlParameter("@ID", gxInfo.ID));

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
                    string sql = "select ID , progID , gxOrder from program_gxinfo where ID=" + id;
                    List<GXInfo> list = db.ExecuteList<GXInfo>(sql, pList.ToArray());
                    if (list.Count == 0)
                    {
                        throw new Exception(string.Format("没有找到ID为：{0} 工序配置信息！", id));
                    }
                    if (list[0].GXOrder == 1 && isUp)
                    {
                        return;
                    }
                    if (isUp)
                    {
                        //update上一点排序的记录+1
                        string strUpdateLast = string.Format(@"update program_gxinfo a,(select (gxOrder-1) as gxOrder from program_gxinfo where progID={0} and id={1} ) as b
                                                      set a.gxOrder=a.gxOrder+1 where a.progID={0} and a.gxOrder=b.gxOrder", list[0].ProgID, id);
                        int updateLast = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateLast);


                        //update当前ID的序号的排序-1
                        string strUpdateCur = string.Format(@"update program_gxinfo set gxOrder=gxOrder-1 where progID={0} and id={1} ", list[0].ProgID, id);
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
                        string strUpdateLast = string.Format(@"update program_gxinfo a,(select (gxOrder+1) as gxOrder from program_gxinfo where progID={0} and id={1} ) as b
                                                      set a.gxOrder=a.gxOrder-1 where a.progID={0} and a.gxOrder=b.gxOrder", list[0].ProgID, id);
                        int updateLast = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, strUpdateLast);


                        //update当前ID的序号的排序-1
                        string strUpdateCur = string.Format(@"update program_gxinfo set gxOrder=gxOrder+1 where progID={0} and id={1} ", list[0].ProgID, id);
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
                catch (Exception)
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

        #endregion

        #region 删除

        /// <summary>
        /// 删除单个工序配置信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGXInfo(int id)
        {
            program_GxInfo item = GetGxInfoData(id);

            if (item == null)
            {
                throw new Exception(string.Format("没有找到ID为：{0} 的工序配置信息！", id));
            }

            DelGXInfo(item);

            OrderSet(item);

        }

        public program_GxInfo GetGxInfoData(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select 
                                    ID,
                                    progID,
                                    gxname,
                                    gxvedio,
                                    GxvedioFilename,
                                    gxOrder,
                                    descript,
                                    pgxInfoStatus,
                                    remark from program_gxinfo where ID=" + id;

            List<program_GxInfo> list = db.ExecuteList<program_GxInfo>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }

        /// <summary>
        ///  删除多个工序配置信息
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="context"></param>
        public void DeleteGXInfo(int[] ids)
        {
            foreach (var ID in ids)
            {
                program_GxInfo item = GetGxInfoData(ID);
                if (item != null)
                {
                    DelGXInfo(item);
                }
            }
        }

        private void DelGXInfo(program_GxInfo entity)
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "delete from program_gxinfo where ID=" + entity.ID;

            db.ExecuteNonQuery(sql, pList.ToArray());

            sql = "select ID from program_gbinfo where progGxID=" + entity.ID;

            List<program_GxInfo> Gblist = db.ExecuteList<program_GxInfo>(sql, pList.ToArray());

            //获取所有工序ID为string字符串，转换为int数据类型
            var GbInfoId = Gblist.Count() > 0 ? string.Join(",", Gblist.Select(_ => _.ID)) : "0";

            int[] GbIds = Array.ConvertAll(GbInfoId.Split(','), int.Parse);

            DIService.GetService<IDAL_GBInfo>().DeleteGBInfo(GbIds);
            
        }

        private void OrderSet(program_GxInfo entity)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID,progID,gxOrder from program_gxinfo where progID=@progID order by gxOrder";

            pList.Clear();
            pList.Add(new MySqlParameter("@progID", entity.progID));
            List<program_GxInfo> list = db.ExecuteList<program_GxInfo>(sql, pList.ToArray());
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sql = "update program_gxinfo set gxOrder=@gxOrder where ID=@ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@gxOrder", i + 1));
                    pList.Add(new MySqlParameter("@ID", list[i].ID));
                    db.ExecuteNonQuery(sql, pList.ToArray());
                }
            }
        }

        #endregion
    }
}
