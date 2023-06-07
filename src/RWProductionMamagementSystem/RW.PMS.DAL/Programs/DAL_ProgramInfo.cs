using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Follow;
using RW.PMS.Model.BaseInfo;
using MySql.Data.MySqlClient;
using System.Data;

namespace RW.PMS.DAL
{
    /// <summary>
    /// 工艺程序信息数据库访问类
    /// </summary>
    internal class DAL_ProgramInfo : IDAL_ProgramInfo
    {
        #region 查询

        /// <summary>
        /// 查询程序信息列表
        /// </summary>
        /// <param name="programName">程序名称</param>
        /// <param name="gwID">工位ID</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageModel<List<Program>> GetBaseProgramList(string programName, int gwID, int PmodelId, int pageIndex, int pageSize)
        {
            var query = QueryBaseProgram();

            if (!string.IsNullOrWhiteSpace(programName))
            {
                query = query.Where(q => q.ProgName.Contains(programName));
            }

            if (gwID != 0)
            {
                query = query.Where(q => q.GWID == gwID);
            }

            if (PmodelId != 0)
                query = query.Where(q => q.PmodelId == PmodelId);

            var total = query.Count();

            var results = query.OrderBy(f => f.ID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new PageModel<List<Program>>(total, results);
        }

        /// <summary>
        /// 查询程序信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Program GetBaseProgramDeatil(int id)
        {
            var query = QueryBaseProgram();

            var detail = query.FirstOrDefault(q => q.ID == id);

            return detail;
        }

        public Program GetBaseProgramDeatilByDef(int gw_prod_def_Id)
        {
            var query = QueryBaseProgram();

            var detail = query.FirstOrDefault(q => q.gw_prod_defId == gw_prod_def_Id);

            return detail;
        }
        private IQueryable<Program> QueryBaseProgram() 
        {
            //StringBuilder str = new StringBuilder();
            string str = string.Empty;
            List<BaseProductModelModel> list = GetAllBaseProModel();
            foreach (var item in list)
            {
                //str += item.Pmodel;
                str = str + item.Pmodel + ",";
            }
            str = str.Substring(0, str.Length - 1);

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"SELECT gd.ID AS gw_prod_defId,
	                    vpm.ID AS PmodelId,
	                    CONCAT_WS('-', vpm.Pname, vpm.Pmodel) AS Pmodel,
	                    bp.ID AS ID,
	                    gw.ID AS GWID,
	                    bp.progName AS ProgName,
	                    gw.gwname AS GWName,
	                    bp.fileNo AS FileNo,
	                    bp.startTime AS StartTime,
	                    bp.copyRight AS CopyRight,
	                    bp.Descript AS Descript,
	                    bp.progStatus AS ProgStatus,
	                    bp.remark AS Remark 
                    FROM base_program bp
                    LEFT JOIN gw_prod_def gd ON bp.ID = gd.progID
                    AND bp.gwID = gd.gwID
                    LEFT JOIN base_gongwei gw ON bp.gwID = gw.ID
                    LEFT JOIN v_productmodel vpm ON gd.prodModelID = vpm.ID";

            IQueryable<Program> prglist = db.ExecuteList<Program>(sql, pList.ToArray()).AsQueryable();

            return GetProgramGxInfoHavSubTable(prglist);
        }

        /// <summary>
        /// 获取下级程序工序数量
        /// </summary>
        /// <param name="list">工艺程序</param>
        /// <returns></returns>
        IQueryable<Program> GetProgramGxInfoHavSubTable(IQueryable<Program> list)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            var ID = list.Count() > 0 ? string.Join(",", list.Select(_ => _.ID)) : "0";

            string sql = "select progID as ProgID,count(*) rowcount from program_gxinfo where progID in(" + ID + ") group by progID";

            List<GXInfo> GxInfoList = db.ExecuteList<GXInfo>(sql, pList.ToArray());

            foreach (var pg in list)
            {
                foreach (var item in GxInfoList)
                {
                    if (item.ProgID == pg.ID)
                    {
                        pg.HavSubTable = item.rowcount > 0 ? true : false;
                    }
                }
            }
            return list;
        }

        #endregion

        #region 验证输入
        /// <summary>
        /// 程序名称是否重复
        /// </summary>
        /// <param name="program"></param>
        /// <returns></returns>
        public bool IsProgramNameDouble(string programName, int id = 0)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = string.Format(@"select count(*) from base_program where progName='{0}'", programName);
            if (id != 0)
            {
                sql += " and ID!=@ID ";
                pList.Add(new MySqlParameter("@ID", id));
            }
            var ret = db.ExecuteScalar(sql, pList.ToArray());

            int rowcount = 0;

            int.TryParse(ret + "", out rowcount);

            return rowcount > 0 ? true : false;

        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加程序信息 
        /// </summary>
        /// <param name="program"></param>
        public void AddBaseProgram(BaseProgram program)
        {
            #region 验证输入
            if (string.IsNullOrEmpty(program.ProgName))
            {
                throw new Exception("'程序名称'不能为空！");
            }
            if (program.GWID == null)
            {
                throw new Exception("'工位'不能为空！");
            }
            #endregion

            if (IsProgramNameDouble(program.ProgName))
            {
                throw new Exception("'程序名称'不能重复！");
            }
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                try
                {
                    string sql = @"insert into base_program(progName,gwID,fileNo,startTime,copyRight,Descript,progVideo,progVideoFilename,progStatus,remark)
                                   values(@progName,@gwID,@fileNo,@startTime,@copyRight,@Descript,@progVideo,@progVideoFilename,@progStatus,@remark)";
                    pList.Add(new MySqlParameter("@progName", program.ProgName));
                    pList.Add(new MySqlParameter("@gwID", program.GWID));
                    pList.Add(new MySqlParameter("@fileNo", program.FileNo));
                    pList.Add(new MySqlParameter("@startTime", program.StartTime));
                    pList.Add(new MySqlParameter("@copyRight", program.CopyRight));
                    pList.Add(new MySqlParameter("@Descript", program.Descript));
                    pList.Add(new MySqlParameter("@progVideo", program.ProgVideo));
                    pList.Add(new MySqlParameter("@progVideoFilename", program.ProgVideoFilename));
                    pList.Add(new MySqlParameter("@progStatus", program.ProgStatus));
                    pList.Add(new MySqlParameter("@remark", program.Remark));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //获取自增长ID
                    int progID = 0;
                    pList.Clear();
                    sql = "select @@identity";
                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out progID);

                    if (program.Pmodel == 0)//如果产品型号传过来的值为0，就循环添加产品型号id
                    {
                        //foreach (var item in GetAllBaseProModel())
                        //{
                        //    sql = "insert into gw_prod_def(gwID,prodModelID,progID)value(@gwID,@prodModelID,@progID)";
                        //    pList.Clear();
                        //    pList.Add(new MySqlParameter("@gwID", program.GWID));
                        //    pList.Add(new MySqlParameter("@prodModelID", item.ID));
                        //    pList.Add(new MySqlParameter("@progID", progID));
                        //    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        //}
                    }
                    else
                    {
                        sql = "insert into gw_prod_def(gwID,prodModelID,progID)value(@gwID,@prodModelID,@progID)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@gwID", program.GWID));
                        pList.Add(new MySqlParameter("@prodModelID", program.Pmodel));
                        pList.Add(new MySqlParameter("@progID", progID));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    }

                    myTrans.Commit();
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

        /// <summary>
        /// 工位,产品型号,程序关联
        /// </summary>
        /// <param name="program"></param>
        /// <param name="progID"></param>
        private void AddGwProdDef(BaseProgram program, int progID)
        {
            if (program.Pmodel == 0)//如果产品型号传过来的值为0，就循环添加产品型号id
            {

            }
            else
            {
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                List<MySqlParameter> pList = new List<MySqlParameter>();
                string sql = @"insert into gw_prod_def(gwID,prodModelID,progID)values(@gwID,@prodModelID,@progID)";
                pList.Clear();
                pList.Add(new MySqlParameter("@gwID", program.GWID));
                pList.Add(new MySqlParameter("@prodModelID", program.Pmodel));
                pList.Add(new MySqlParameter("@progID", progID));
                db.ExecuteNonQuery(sql, pList.ToArray());
            }
        }

        #endregion

        #region 获取产品型号信息2019-05-15


        /// <summary>
        /// 获取产品型号信息2019-05-15
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetAllBaseProModel()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            var list = db.ExecuteListByTableName<BaseProductModelModel>("base_productmodel");

            return list;
        }
        #endregion

        #region 复制

        //由于工艺配置信息表之间没有外键关联所有EF做不到一次性提交操作 只能单独提交 

        public void CopyBaseProgram(int copyID, BaseProgram program)
        {
            #region 验证输入
            if (string.IsNullOrEmpty(program.ProgName))
            {
                throw new Exception("'程序名称'不能为空！");
            }
            if (program.GWID == null)
            {
                throw new Exception("'工位'不能为空！");
            }
            #endregion

            if (IsProgramNameDouble(program.ProgName))
            {
                throw new Exception("'程序名称'不能重复！");
            }
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();

                MySqlTransaction myTrans = myConnection.BeginTransaction();

                List<MySqlParameter> pList = new List<MySqlParameter>();

                var db = new RW.PMS.Common.MySqlHelper();
                var def = db.ExecuteList<gw_prod_def>("select *from gw_prod_def where id=@id", new MySqlParameter("@id", copyID));
                if (def.Count == 0)
                {
                    throw new Exception(string.Format("没有找到程序与工位绑定ID：{0}的信息！", copyID));
                }

                try
                {
                    string sql = "select * from base_program where ID=" + def[0].progID;

                    DataTable proDt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());

                    if (proDt.Rows.Count == 0)
                    {
                        throw new Exception(string.Format("没有找到程序ID：{0}的信息！", program.ID));
                    }

                    sql = @"insert into base_program
                                                    (progName,
                                                    gwID,
                                                    fileNo,
                                                    startTime,
                                                    copyRight,
                                                    Descript,
                                                    progVideo,
                                                    progVideoFilename,
                                                    progStatus,
                                                    remark)
                                   values(@progName,@gwID,@fileNo,@startTime,@copyRight,@Descript,@progVideo,@progVideoFilename,@progStatus,@remark)";

                    pList.Add(new MySqlParameter("@progName", program.ProgName));
                    pList.Add(new MySqlParameter("@gwID", program.GWID));
                    pList.Add(new MySqlParameter("@fileNo", program.FileNo));
                    pList.Add(new MySqlParameter("@startTime", program.StartTime));
                    pList.Add(new MySqlParameter("@copyRight", program.CopyRight));
                    pList.Add(new MySqlParameter("@Descript", program.Descript));
                    pList.Add(new MySqlParameter("@progVideo", program.ProgVideo));
                    pList.Add(new MySqlParameter("@progVideoFilename", program.ProgVideoFilename));
                    pList.Add(new MySqlParameter("@progStatus", program.ProgStatus));
                    pList.Add(new MySqlParameter("@remark", program.Remark));

                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //获取自增长ID
                    int programID = 0;
                    pList.Clear();
                    sql = "select @@identity";
                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out programID);

                    sql = @"insert into gw_prod_def(gwID,prodModelID,progID)values(@gwID,@prodModelID,@progID)";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@gwID", program.GWID));
                    pList.Add(new MySqlParameter("@prodModelID", program.Pmodel));
                    pList.Add(new MySqlParameter("@progID", programID));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                    //获取工序信息
                    sql = "select * from program_gxinfo where progID=" + def[0].progID;
                    pList.Clear();
                    var proGXInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myConnection, CommandType.Text, sql, pList.ToArray());
                    if (proGXInfo.Rows.Count > 0)
                    {
                        foreach (DataRow item in proGXInfo.Rows)
                        {
                            sql = @"INSERT INTO program_gxinfo (
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
                            pList.Add(new MySqlParameter("@progID", programID));
                            pList.Add(new MySqlParameter("@gxname", item["gxname"]));
                            pList.Add(new MySqlParameter("@gxvedio", item["gxvedio"]));
                            pList.Add(new MySqlParameter("@gxvedioFilename", item["GxvedioFilename"]));
                            pList.Add(new MySqlParameter("@descript", item["descript"]));
                            pList.Add(new MySqlParameter("@gxOrder", item["gxOrder"]));
                            pList.Add(new MySqlParameter("@pgxInfoStatus", item["pgxInfoStatus"]));
                            pList.Add(new MySqlParameter("@remark", item["remark"]));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                            //获取工序自增长ID
                            int proGXInfoID = 0;
                            pList.Clear();
                            sql = "select @@identity";
                            int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out proGXInfoID);

                            sql = "select * from program_gbinfo where progGxID=" + item["ID"];
                            pList.Clear();
                            var proGBInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myConnection, CommandType.Text, sql, pList.ToArray());
                            if (proGBInfo.Rows.Count > 0)
                            {
                                foreach (DataRow itemGB in proGBInfo.Rows)
                                {
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
                                    pList.Add(new MySqlParameter("@progGxID", proGXInfoID));
                                    pList.Add(new MySqlParameter("@gbname", itemGB["gbname"]));
                                    pList.Add(new MySqlParameter("@gbimg", itemGB["gbimg"]));
                                    pList.Add(new MySqlParameter("@gbdesc", itemGB["gbdesc"]));
                                    pList.Add(new MySqlParameter("@gbOrder", itemGB["gbOrder"]));
                                    pList.Add(new MySqlParameter("@controlTypeID", itemGB["controlTypeID"]));
                                    pList.Add(new MySqlParameter("@gbDelayTime", itemGB["gbDelayTime"]));
                                    pList.Add(new MySqlParameter("@isScan", itemGB["isScan"]));
                                    pList.Add(new MySqlParameter("@isEmpCheck", itemGB["isEmpCheck"]));
                                    pList.Add(new MySqlParameter("@isInputPInfo", itemGB["isInputPInfo"]));
                                    pList.Add(new MySqlParameter("@isScanOrderNo", itemGB["isScanOrderNo"]));
                                    pList.Add(new MySqlParameter("@ifzhuanxu", itemGB["ifzhuanxu"]));
                                    pList.Add(new MySqlParameter("@ErrTypeID", itemGB["ErrTypeID"]));
                                    pList.Add(new MySqlParameter("@pgbInfoStatus", itemGB["pgbInfoStatus"]));
                                    pList.Add(new MySqlParameter("@remark", itemGB["remark"]));

                                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());


                                    //获取工步自增长ID
                                    int proGBInfoID = 0;
                                    pList.Clear();
                                    sql = "select @@identity";
                                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out proGBInfoID);

                                    //获取工具信息
                                    sql = "select * from program_gjinfo where progGbInfoID=" + itemGB["ID"];
                                    pList.Clear();
                                    var proGJInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myConnection, CommandType.Text, sql, pList.ToArray());
                                    if (proGJInfo.Rows.Count > 0)
                                    {
                                        foreach (DataRow itemGJ in proGJInfo.Rows)
                                        {
                                            sql = @"insert into program_gjinfo(progGbInfoID,gjID,gjOrder,wlID,wlOrder,pgjInfoStatus,remark)
                                                    values(@progGbInfoID,@gjID,@gjOrder,@wlID,@wlOrder,@pgjInfoStatus,@remark)";
                                            pList.Clear();
                                            pList.Add(new MySqlParameter("progGbInfoID", proGBInfoID));
                                            pList.Add(new MySqlParameter("gjID", itemGJ["gjID"]));
                                            pList.Add(new MySqlParameter("gjOrder", itemGJ["gjOrder"]));
                                            pList.Add(new MySqlParameter("wlID", itemGJ["wlID"]));
                                            pList.Add(new MySqlParameter("wlOrder", itemGJ["wlOrder"]));
                                            pList.Add(new MySqlParameter("pgjInfoStatus", itemGJ["pgjInfoStatus"]));
                                            pList.Add(new MySqlParameter("remark", itemGJ["remark"]));

                                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                                            //获取工具自增长ID
                                            int proGjInfoID = 0;
                                            pList.Clear();
                                            sql = "select @@identity";
                                            int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out proGjInfoID);

                                            //获取工具信息
                                            sql = "select * from program_gjwlopcinfo where progGjInfoID=" + itemGJ["ID"];
                                            pList.Clear();
                                            var proGjwlOpcInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myConnection, CommandType.Text, sql, pList.ToArray());

                                            foreach (DataRow itemGjWlOpc in proGjwlOpcInfo.Rows)
                                            {
                                                sql = @"insert into program_gjwlopcinfo(progGjInfoID,opcTypeID,opcDeviceName,opcTypeCode,opcValue)
                                                                values(@progGjInfoID,@opcTypeID,@opcDeviceName,@opcTypeCode,@opcValue)";
                                                pList.Clear();
                                                pList.Add(new MySqlParameter("@progGjInfoID", proGjInfoID));
                                                pList.Add(new MySqlParameter("@opcTypeID", itemGjWlOpc["opcTypeID"]));
                                                pList.Add(new MySqlParameter("@opcDeviceName", itemGjWlOpc["opcDeviceName"]));
                                                pList.Add(new MySqlParameter("@opcTypeCode", itemGjWlOpc["opcTypeCode"]));
                                                pList.Add(new MySqlParameter("@opcValue", itemGjWlOpc["opcValue"]));
                                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                            }

                                            sql = "select * from program_valueinfo where progGjInfoID=" + itemGJ["ID"];
                                            pList.Clear();
                                            //获取程序检测项
                                            var proValInfo = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myConnection, CommandType.Text, sql, pList.ToArray());
                                            if (proValInfo.Rows.Count > 0)
                                            {
                                                foreach (DataRow itemValue in proValInfo.Rows)
                                                {
                                                    sql = @"insert into program_valueinfo(progGjInfoID,valueTypeID,EqualTypeID,standardValue,minValue,
                                                                    `maxValue`,pVInfoStatus,remark,pixelPoint)values(@progGjInfoID,@valueTypeID,@EqualTypeID,
                                                                    @standardValue,@minValue,@'maxValue',@pVInfoStatus,@remark,@pixelPoint)";

                                                    pList.Add(new MySqlParameter("@progGjInfoID", proGjInfoID));
                                                    pList.Add(new MySqlParameter("@valueTypeID", itemValue["valueTypeID"]));
                                                    pList.Add(new MySqlParameter("@EqualTypeID", itemValue["EqualTypeID"]));
                                                    pList.Add(new MySqlParameter("@standardValue", itemValue["standardValue"]));
                                                    pList.Add(new MySqlParameter("@minValue", itemValue["minValue"]));
                                                    pList.Add(new MySqlParameter("@maxValue", itemValue["maxValue"]));
                                                    pList.Add(new MySqlParameter("@pVInfoStatus", itemValue["pVInfoStatus"]));
                                                    pList.Add(new MySqlParameter("@remark", itemValue["remark"]));
                                                    pList.Add(new MySqlParameter("@pixelPoint", itemValue["pixelPoint"]));
                                                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        myTrans.Commit();
                    }
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                    throw;
                }
                finally
                {
                    //  myTrans.Dispose();
                }
            }
        }


        #endregion

        #region 编辑

        /// <summary>
        /// 修改程序信息
        /// </summary>
        /// <param name="program"></param>
        public void EditBaseProgram(BaseProgram program)
        {
            #region 验证输入
            if (string.IsNullOrEmpty(program.ProgName))
            {
                throw new Exception("'程序名称'不能为空！");
            }
            if (program.GWID == null)
            {
                throw new Exception("'工位'不能为空！");
            }
            #endregion
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select ID,progName as ProgName,gwID as GWID,fileNo as FileNo,startTime as StartTime,
                                   copyRight as CopyRight,Descript,progVideo as ProgVideo,progVideoFilename as ProgVideoFilename,
                                   progStatus as ProgStatus,remark as Remark from base_program where ID = @ID";
            pList.Add(new MySqlParameter("@ID", program.ID));
            var list = db.ExecuteList<BaseProgram>(sql, pList.ToArray());
            if (list.Count == 0 || list == null)
            {
                throw new Exception(string.Format("没有找到程序名称：{0}的信息！", program.ProgName));
            }
            pList.Clear();
            string updateSql = @"update base_program set progName=@progName,gwID=@gwID,fileNo=@fileNo,startTime=@startTime,copyRight=@copyRight,
                                         Descript=@Descript,progStatus=@progStatus,remark=@remark where ID=@ID";
            pList.Add(new MySqlParameter("@progName", program.ProgName));
            pList.Add(new MySqlParameter("@gwID", program.GWID));
            pList.Add(new MySqlParameter("@fileNo", program.FileNo));
            pList.Add(new MySqlParameter("@startTime", program.StartTime));
            pList.Add(new MySqlParameter("@copyRight", program.CopyRight));
            pList.Add(new MySqlParameter("@Descript", program.Descript));
            pList.Add(new MySqlParameter("@progStatus", program.ProgStatus));
            pList.Add(new MySqlParameter("@remark", program.Remark));
            pList.Add(new MySqlParameter("@ID", program.ID));
            db.ExecuteNonQuery(updateSql, pList.ToArray());

            sql = "select * from gw_prod_def where ID=@ID";
            pList.Clear();
            pList.Add(new MySqlParameter("@ID", program.gw_prod_defId));
            List<BaseGwProdDefModel> Model_Gw_ProdDef = db.ExecuteList<BaseGwProdDefModel>(sql, pList.ToArray());
            if (Model_Gw_ProdDef.Count > 0)
            {
                updateSql = @"update gw_prod_def set gwID=@gwID,progID=@progID,prodModelID=@prodModelID where ID=@ID";
                pList.Clear();
                pList.Add(new MySqlParameter("@gwID", program.GWID));
                pList.Add(new MySqlParameter("@progID", program.ID));
                pList.Add(new MySqlParameter("@prodModelID", program.Pmodel));
                pList.Add(new MySqlParameter("@ID", Model_Gw_ProdDef[0].ID));
                db.ExecuteNonQuery(updateSql, pList.ToArray());
            }
            else
            {
                string innsertSql = "insert into gw_prod_def(gwID,progID,prodModelID)value(@gwID,@progID,@prodModelID)";
                pList.Clear();
                pList.Add(new MySqlParameter("@gwID", program.GWID));
                pList.Add(new MySqlParameter("@progID", program.ID));
                pList.Add(new MySqlParameter("@prodModelID", program.Pmodel));
                db.ExecuteNonQuery(innsertSql, pList.ToArray());
            }
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除程序信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProgram(int gw_prod_defid)
        {

            var db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            var sql = "select id, progid from gw_prod_def where ID=" + gw_prod_defid;

            var gwProdDef = db.ExecuteList<BaseGwProdDefModel>(sql, pList.ToArray());

            if (gwProdDef.Count == 0)
            {
                throw new Exception($"没有找到工艺程序关联信息！{gw_prod_defid}");
            }
            var progID = gwProdDef[0].progID;
            sql = "delete from gw_prod_def where ID=@gw_prod_defid;";
            db.ExecuteNonQuery(sql, new MySqlParameter("@progid", progID));

            sql = "select COUNT(id) from gw_prod_def where ID=@progid";
            var count = db.ExecuteScalar<int>(sql, new MySqlParameter("@progid", progID));
            if (count == 0)
            {
                sql = "delete from base_program where ID=" + progID;

                db.ExecuteNonQuery(sql, pList.ToArray());

                sql = "select ID from program_gxinfo where  progID=" + progID;

                List<program_GxInfo> Gxlist = db.ExecuteList<program_GxInfo>(sql, pList.ToArray());

                //获取所有工序ID为string字符串，转换为int数据类型
                var GxInfoId = Gxlist.Count() > 0 ? string.Join(",", Gxlist.Select(_ => _.ID)) : "0";

                int[] GxIds = Array.ConvertAll(GxInfoId.Split(','), int.Parse);

                DIService.GetService<IDAL_GXInfo>().DeleteGXInfo(GxIds);

            }
        }

        #endregion

        #region 工艺程序显示

        /// <summary>
        /// 获取程序工序工步列表
        /// </summary>
        /// <param name="programID"></param>
        public List<ProGXGBModel> ProgGXGBList(int programID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            //主数据
            string sql = @"SELECT
                            IF (
	                            gbInfo.gbOrder IS NULL
	                            OR gbInfo.gbOrder = 1,
	                            gxInfo.Gxname,
	                            gxInfo.Gxname
                            ) GXNameGroup,
                             
                            IF (
	                            gbInfo.gbname IS NULL,
	                            gxInfo.Gxname,
	                            gbInfo.gbname
                            ) gbname,
                             gxInfo.Gxname gxname,
                             gxInfo.Descript,
                             gbInfo.gbdesc,
                             gxInfo.Gxvedio GXVedio,
                             gxInfo.GxvedioFilename GxvedioFilename,
                             gbInfo.isScan IsScan,
                             gbInfo.isInputPInfo,
                             IFNULL(gbInfo.isScanOrderNo, 0) IsScanOrderNo,
                             gbInfo.gbDelayTime GBDelayTime,
                             gbInfo.isEmpCheck IsEmpCheck,
                             gbInfo.ErrTypeID,
                             gbInfo.controlTypeID ControlTypeID,
                             gbInfo.pgbInfoStatus PGBInfoStatus,
                             gbInfo.ifzhuanxu IfZhuanXu,
                             gw.gwname,
                             gbInfo.ID progGbID,
                             gxInfo.ID progGXID,
                             gxInfo.gxOrder,
                             gbInfo.gbOrder,
                             IFNULL(gw.isFinishGW, 0) IsFinishGW,
                             bg.gwID
                            FROM
	                            base_program bg
                            LEFT JOIN program_GxInfo gxInfo ON gxInfo.progID = bg.ID
                            LEFT JOIN program_GbInfo gbInfo ON gbInfo.progGxID = gxInfo.ID
                            LEFT JOIN base_gongwei gw ON gw.ID = bg.gwID
                            WHERE
	                            IFNULL(bg.progStatus, 0) = 0
                            AND IFNULL(gxInfo.pgxInfoStatus, 0) = 0
                            AND IFNULL(gbInfo.pgbInfoStatus, 0) = 0
                            AND IFNULL(gw.gwStatus, 0) = 0
                            AND bg.ID = @ID
                            ORDER BY
	                            gxInfo.gxOrder,
	                            gbInfo.gbOrder";

            //string sql = @"SELECT
            //                IF (
            //                 gbInfo.gbOrder IS NULL
            //                 OR gbInfo.gbOrder = 1,
            //                 gxInfo.Gxname,
            //                 ''
            //                ) GXNameGroup,

            //                IF (
            //                 gbInfo.gbname IS NULL,
            //                 gxInfo.Gxname,
            //                 gbInfo.gbname
            //                ) gbname,
            //                 gxInfo.Gxname gxname,
            //                 gxInfo.Descript,
            //                 gbInfo.gbdesc,
            //                 gxInfo.Gxvedio GXVedio,
            //                 gxInfo.GxvedioFilename GxvedioFilename,
            //                 gbInfo.isScan IsScan,
            //                 gbInfo.isInputPInfo,
            //                 IFNULL(gbInfo.isScanOrderNo, 0) IsScanOrderNo,
            //                 gbInfo.gbDelayTime GBDelayTime,
            //                 gbInfo.isEmpCheck IsEmpCheck,
            //                 gbInfo.ErrTypeID,
            //                 gbInfo.controlTypeID ControlTypeID,
            //                 gbInfo.pgbInfoStatus PGBInfoStatus,
            //                 gbInfo.ifzhuanxu IfZhuanXu,
            //                 gw.gwname,
            //                 gbInfo.ID progGbID,
            //                 gxInfo.ID progGXID,
            //                 gxInfo.gxOrder,
            //                 gbInfo.gbOrder,
            //                 IFNULL(gw.isFinishGW, 0) IsFinishGW,
            //                 bg.gwID
            //                FROM
            //                 base_program bg
            //                LEFT JOIN program_GxInfo gxInfo ON gxInfo.progID = bg.ID
            //                LEFT JOIN program_GbInfo gbInfo ON gbInfo.progGxID = gxInfo.ID
            //                LEFT JOIN base_gongwei gw ON gw.ID = bg.gwID
            //                WHERE
            //                 IFNULL(bg.progStatus, 0) = 0
            //                AND IFNULL(gxInfo.pgxInfoStatus, 0) = 0
            //                AND IFNULL(gbInfo.pgbInfoStatus, 0) = 0
            //                AND IFNULL(gw.gwStatus, 0) = 0
            //                AND bg.ID = @ID
            //                ORDER BY
            //                 gxInfo.gxOrder,
            //                 gbInfo.gbOrder";
            pList.Add(new MySqlParameter("@ID", programID));
            List<ProGXGBModel> list = db.ExecuteList<ProGXGBModel>(sql, pList.ToArray());
            if (list.Count == 0) return list;
            //OPC20190904 1204
            sql = @"select opc.* from base_gongweiOPC opc 
                                        left join base_gongwei gw on gw.ID=opc.gwID 
                                        where opc.gwID in(" + string.Join(",", list.Select(_ => _.gwID ?? 0)) + ")";
            pList.Clear();
            List<BaseGongweiOpcModel> opcList = db.ExecuteList<BaseGongweiOpcModel>(sql, pList.ToArray());
            int RowNo = 0;
            foreach (var wp in list)
            {
                List<BaseGongweiOpcModel> tempList = new List<BaseGongweiOpcModel>();
                foreach (var item in opcList)
                {
                    if (!item.gwID.HasValue) continue;
                    if (item.gwID.Value == wp.gwID)
                        tempList.Add(item);
                }
                wp.OPC = tempList;
                wp.RowID = RowNo++;
            }
            return list;
        }



        /// <summary>
        /// 用于导出工序工步Excel
        /// </summary>
        /// <param name="programID"></param>
        /// <returns></returns>
        public List<ProGXGBExportModel> ProgGXGBExportList(int programID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            //主数据
            string sql = @"SELECT
                            IF (
	                            gbInfo.gbOrder IS NULL
	                            OR gbInfo.gbOrder = 1,
	                            gxInfo.Gxname,
	                            ''
                            ) GXNameGroup,
                            IF (
	                            gbInfo.gbname IS NULL,
	                            gxInfo.Gxname,
	                            gbInfo.gbname
                            ) gbname,
                             gxInfo.Gxname gxname,
                             gxInfo.Descript,
                             gbInfo.gbdesc,
                             gbInfo.gbDelayTime GBDelayTime,
                             gbInfo.isEmpCheck IsEmpCheck,
                             gbInfo.ErrTypeID,
                             gbInfo.controlTypeID ControlTypeID,
                             gbInfo.pgbInfoStatus PGBInfoStatus,
                             gw.gwname,
                             gbInfo.ID progGbID,
                             gxInfo.ID progGXID,
                             gxInfo.gxOrder,
                             gbInfo.gbOrder,
                             IFNULL(gw.isFinishGW, 0) IsFinishGW,
                             bg.gwID
                            FROM
	                            base_program bg
                            LEFT JOIN program_GxInfo gxInfo ON gxInfo.progID = bg.ID
                            LEFT JOIN program_GbInfo gbInfo ON gbInfo.progGxID = gxInfo.ID
                            LEFT JOIN base_gongwei gw ON gw.ID = bg.gwID
                            WHERE
	                            IFNULL(bg.progStatus, 0) = 0
                            AND IFNULL(gxInfo.pgxInfoStatus, 0) = 0
                            AND IFNULL(gbInfo.pgbInfoStatus, 0) = 0
                            AND IFNULL(gw.gwStatus, 0) = 0
                            AND bg.ID = @ID
                            ORDER BY
	                            gxInfo.gxOrder,
	                            gbInfo.gbOrder";
            pList.Add(new MySqlParameter("@ID", programID));
            List<ProGXGBExportModel> list = db.ExecuteList<ProGXGBExportModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取程序工具列表
        /// </summary>
        /// <param name="programID"></param>
        public List<ProGJValModel> ProgGJValList(int programID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            //主数据
            string sql = @"SELECT
	                            gjInfo.ID,
                                gxInfo.ID ProgGXID,
	                            gbInfo.ID ProgGBID,
	                            gjInfo.gjID GJID,
	                            gj.gjname GJName,
                                gj.torqueLocalIP TorqueLocalIP,
                                gj.torqueLocalPort TorqueLocalPort,
	                            gjInfo.gjOrder GJOrder,
	                            gjInfo.wlID WLID,
	                            CONCAT_WS(' - ',wl.mName,wl.mDrawingNo)  WLName,
	                            gjInfo.wlOrder WLOrder,
	                            gjInfo.pgjInfoStatus GJInfoStatus,
	                            gjInfo.remark Remark,
	                            valInfo.remark ValueRemark,
	                            GetbdNameBybdID (valInfo.valueTypeID) ValueTypeName,
	                            GetbdNameBybdID (valInfo.EqualTypeID) EqualTypeName,
	                            bd.bdcode GJTypeCode,
	                            valInfo.ID ValID,
	                            valInfo.progGjInfoID ProgGjInfoID,
	                            valInfo.EqualTypeID EqualTypeID,
	                            valInfo.valueTypeID,
	                            valInfo.standardValue StandardValue,
	                            valInfo.minValue MinValue,
	                            valInfo.`maxValue` `MaxValue`,
	                            valInfo.pixelPoint PixelPoint,
	                            valInfo.pVInfoStatus PVInfoStatus,
	                            valInfo.IsWriteVal,
	                            gj.gjIsHasCode GJIsHasCode,
	                            '0' WLIsHasCode,
	                            gj.gjImg GJImg,
                                wl.mImg WLImg
	                            
                            FROM
	                            program_GjInfo gjInfo
                            LEFT JOIN program_ValueInfo valInfo ON gjInfo.ID = valInfo.progGjInfoID
                            LEFT JOIN base_gongju gj ON gjInfo.gjID = gj.ID
                            LEFT JOIN sys_basedata bd ON gj.gjTypeID = bd.ID
                            LEFT JOIN base_material wl ON wl.ID = gjInfo.wlID
                            
                            LEFT JOIN program_GbInfo gbInfo ON gjInfo.progGbInfoID = gbInfo.ID
                            LEFT JOIN program_GxInfo gxInfo ON gxInfo.ID = gbInfo.progGxID
                            WHERE
	                            ifnull(gjInfo.pgjInfoStatus, 0) = 0
                            AND ifnull(valInfo.pVInfoStatus, 0) = 0
                            AND ifnull(gj.gjStatus, 0) = 0
                            AND ifnull(gbInfo.pgbInfoStatus, 0) = 0
                            AND ifnull(gxInfo.pgxInfoStatus, 0) = 0
                            AND gxInfo.progID = @progID
                            ORDER BY
	                            gbInfo.ID,
	                            gjInfo.gjOrder,
	                            gjInfo.wlOrder ";

            //LEFT JOIN base_materialbarcode mb ON gjInfo.wlID = mb.id
            //LEFT JOIN base_material wl ON wl.ID = mb.m_MaterialID

            pList.Add(new MySqlParameter("@progID", programID));

            List<ProGJValModel> list = db.ExecuteList<ProGJValModel>(sql, pList.ToArray());

            if (list.Count == 0) return list;
            //OPC
            sql = @"select bd.bdcode `Code`,bd.bdname `Name`,opc.opcDeviceName OPCDeviceName,opc.opcValue `Value`,opc.progGjInfoID from sys_baseData bd 
                            left join sys_baseDataType bdt on bd.bdtypeID=bdt.ID 
                            left join program_GjwlOPCInfo opc on bd.bdcode=opc.opcTypeCode 
                            where bdt.typecode='gjwlOPCType' and opc.progGjInfoID in(" + string.Join(",", list.Select(_ => _.ID)) + ")";
            pList.Clear();
            List<GJOPCType> opcList = db.ExecuteList<GJOPCType>(sql, pList.ToArray());
            foreach (var wp in list)
            {
                List<GJOPCType> tempList = wp.GJOPCTypes.ToList();
                foreach (var item in opcList)
                {
                    if (!item.progGjInfoID.HasValue) continue;
                    if (item.progGjInfoID.Value == wp.ID)
                        tempList.Add(item);
                }
                wp.GJOPCTypes = tempList;
            }
            return list;
        }

        /// <summary>
        /// 获取工步图片
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        public Byte[] GetGBImage(int gbID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select gbimg from program_gbinfo where ID=@ID";

            pList.Add(new MySqlParameter("@ID", gbID));

            object obj = db.ExecuteScalar(sql, pList.ToArray());

            if (obj.GetType() == typeof(byte[]))//如果未此类型直接强转
                return (byte[])obj;

            if (obj == DBNull.Value)
                return null;

            return obj.ToBytes();
        }

        /// <summary>
        /// 根据IP获取工序视频
        /// </summary>
        /// <param name="IP">IP</param>
        /// <returns>视频List</returns>
        public List<VideoModel> GetVideoByIP(string IP)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select gxInfo.Gxvedio Address,gxInfo.GxvedioFilename Name 
                    from program_GxInfo gxInfo 
                    left join base_program bp on gxInfo.progID=bp.ID 
                    left join gw_prod_def gwref on bp.ID=gwref.progID 
                    left join base_gongwei gw on bp.gwID=gw.ID 
                    where IFNULL(bp.progStatus,0)=0 and IFNULL(gxInfo.pgxInfoStatus,0)=0 
                    and IFNULL(gw.gwStatus,0)=0  and gxInfo.Gxvedio<>'' 
                    and gxInfo.GxvedioFilename<>'' and gw.IP=@IP ";

            pList.Add(new MySqlParameter("@IP", IP));

            List<VideoModel> list = db.ExecuteList<VideoModel>(sql, pList.ToArray());

            return list;
        }

        //public List<string> GetVerifyControlType(int programID)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        return null;
        //    }
        //}

        /// <summary>
        /// 条件查询工艺(精确到工步)
        /// Add By Leon 20191010
        /// </summary>
        /// <param name="model">包含产品型号ID,部件ID等查询条件</param>
        /// <returns>实体类数据集合</returns>
        public List<ProGXGBModel> GetWorkStepList(ProGXGBModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";
            string sql = "";

            if (model.gwID.HasValue && model.gwID != 0)
            {
                para += " and gw.ID = @gwID ";
                pList.Add(new MySqlParameter("@gwID", model.gwID));
            }
            if (model.prodModelID.HasValue && model.prodModelID != 0)
            {
                para += " and pm.ID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", model.prodModelID));
            }
            if (model.componentID.HasValue && model.componentID != 0)
            {
                para += " and def.componentID = @componentID ";
                pList.Add(new MySqlParameter("@componentID", model.componentID));
            }

            sql = @"select DISTINCT
                        def.prodModelID,pm.Pmodel
                        ,def.componentID,wl.wlname partName
                        ,pg.ID progID,pg.progName
                        ,pg.gwID,gw.gwname
                        ,gxi.gxID,gx.gxname,gxi.gxOrder
                        ,gbi.gbID,gb.gbname,gb.gbdesc,gbi.gbOrder,gb.gbimg 
                        from program_GbInfo gbi
                        left join program_gxinfo gxi on gxi.ID=gbi.progGxID
                        left join base_gongbu gb on gb.ID=gbi.gbID
                        left join base_gongxu gx on gx.ID=gxi.gxID
                        left join base_program pg on pg.ID=gxi.progID
                        left join base_gongwei gw on gw.ID=pg.gwID
                        left join gw_prod_def def on def.progID=pg.ID
                        left join base_productmodel pm on pm.ID=def.prodModelID
                        left join base_wuliao wl on wl.ID=def.componentID
                         where 1=1 " + para;
            sql += " order by gw.ID,gxi.gxOrder,gbi.gbOrder";

            List<ProGXGBModel> lists = db.ExecuteList<ProGXGBModel>(sql, pList.ToArray());

            return lists;
        }

        #endregion

    }
}