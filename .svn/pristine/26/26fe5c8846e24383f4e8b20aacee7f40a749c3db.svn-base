using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.IDAL;
using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.Follow;
using MySql.Data.MySqlClient;
using System.Data;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Device;

namespace RW.PMS.DAL
{
    internal class DAL_Assembly : IDAL_Assembly
    {
        #region 产品线组装工位信息

        /// <summary>
        /// 获取产品线组装工位明细
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public AssemblyGwModel GetAssemblyGwDetail(Guid guid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select * from assembly_gw where agw_guid=@agw_guid";

            pList.Add(new MySqlParameter("@agw_guid", guid));

            var list = db.ExecuteList<AssemblyGwModel>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }

        /// <summary>
        /// 添加产品线组装工位信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGw(AssemblyGwModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into assembly_gw(agw_guid,agw_prog_id,agw_prog_name,agw_gwName,agw_gwID,agw_finishStatus,agw_finishtime,agw_oper,agw_operID,agw_QRcode,agw_resultIsOK,agw_resultMemo
,agw_starttime,agw_uploadFlag,pInfo_ID,agw_remark) values(@agw_guid,@agw_prog_id,@agw_prog_name,@agw_gwName,@agw_gwID,@agw_finishStatus,@agw_finishtime,@agw_oper,@agw_operID,@agw_QRcode,@agw_resultIsOK
,@agw_resultMemo,@agw_starttime,@agw_uploadFlag,@pInfo_ID,@agw_remar)";

            pList.Add(new MySqlParameter("@agw_guid", model.agw_guid));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@agw_prog_id", model.agw_prog_id));
            pList.Add(new MySqlParameter("@agw_prog_name", model.agw_prog_name));
            pList.Add(new MySqlParameter("@agw_gwName", model.agw_gwName));
            pList.Add(new MySqlParameter("@agw_gwID", model.agw_gwID));
            pList.Add(new MySqlParameter("@agw_finishStatus", model.agw_finishStatus));
            pList.Add(new MySqlParameter("@agw_finishtime", model.agw_finishtime));
            pList.Add(new MySqlParameter("@agw_oper", model.agw_oper));
            pList.Add(new MySqlParameter("@agw_operID", model.agw_operID));
            pList.Add(new MySqlParameter("@agw_QRcode", model.agw_QRcode));
            pList.Add(new MySqlParameter("@agw_resultIsOK", model.agw_resultIsOK));
            pList.Add(new MySqlParameter("@agw_resultMemo", model.agw_resultMemo));
            pList.Add(new MySqlParameter("@agw_starttime", model.agw_starttime));
            pList.Add(new MySqlParameter("@agw_uploadFlag", model.agw_uploadFlag));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@agw_remar", model.agw_remark));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        ///编辑产品线组装工位信息
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGw(AssemblyGwModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update assembly_gw set agw_prog_id=@agw_prog_id,agw_prog_name=@agw_prog_name,agw_gwName=@agw_gwName,agw_gwID=@agw_gwID
,agw_finishStatus=@agw_finishStatus,agw_finishtime=@agw_finishtime,agw_oper=@agw_oper,agw_operID=@agw_operID,agw_QRcode=@agw_QRcode,agw_resultIsOK=@agw_resultIsOK
,agw_resultMemo=@agw_resultMemo,agw_starttime=@agw_starttime,agw_uploadFlag=@agw_uploadFlag,pInfo_ID=@pInfo_ID,agw_remark=@agw_remark 
where agw_guid=@agw_guid";

            pList.Add(new MySqlParameter("@agw_guid", model.agw_guid));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@agw_prog_id", model.agw_prog_id));
            pList.Add(new MySqlParameter("@agw_prog_name", model.agw_prog_name));
            pList.Add(new MySqlParameter("@agw_gwName", model.agw_gwName));
            pList.Add(new MySqlParameter("@agw_gwID", model.agw_gwID));
            pList.Add(new MySqlParameter("@agw_finishStatus", model.agw_finishStatus));
            pList.Add(new MySqlParameter("@agw_finishtime", model.agw_finishtime));
            pList.Add(new MySqlParameter("@agw_oper", model.agw_oper));
            pList.Add(new MySqlParameter("@agw_operID", model.agw_operID));
            pList.Add(new MySqlParameter("@agw_QRcode", model.agw_QRcode));
            pList.Add(new MySqlParameter("@agw_resultIsOK", model.agw_resultIsOK));
            pList.Add(new MySqlParameter("@agw_resultMemo", model.agw_resultMemo));
            pList.Add(new MySqlParameter("@agw_starttime", model.agw_starttime));
            pList.Add(new MySqlParameter("@agw_uploadFlag", model.agw_uploadFlag));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@agw_remark", model.agw_remark));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }



        /// <summary>
        /// 根据分装部件编号 获取产品线组装工位明细
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        public AssemblyGwModel GetAssemblyGwByQRcode(string QRcode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select * from assembly_gw where agw_QRcode=@QRcode order by agw_starttime desc";

            pList.Add(new MySqlParameter("@QRcode", QRcode));

            var list = db.ExecuteList<AssemblyGwModel>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }


        /// <summary>
        /// 分装部件编号_关联_产品编号
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        public int AssociatedQRcodeOrProdNo(string QRcode, int pInfo_ID, string AssbmGwGuid)
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

                    //根据分装部件编号 查询装配工位信息
                    DataTable dtAssemblyGw = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from assembly_gw where agw_QRcode='" + QRcode + "' order by agw_starttime desc", null);
                    List<AssemblyGwModel> AssemblyGwList = db.ToList<AssemblyGwModel>(dtAssemblyGw);


                    #region 判断是否有工序信息，如果有补全产品信息
                    if (AssemblyGwList != null && AssemblyGwList.Count > 0)
                    {
                        sql = "update assembly_gw set pInfo_ID = @pInfo_ID where agw_QRcode = @agw_QRcode ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pInfo_ID", pInfo_ID));
                        pList.Add(new MySqlParameter("@agw_QRcode", QRcode));
                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }
                    #endregion
                    //此次数据量大了的话性能会很差 xiaoguo 2021-4-7
                    //if (AssemblyGwList != null && AssemblyGwList.Count > 0)
                    //{
                    //    foreach (var Gwitem in AssemblyGwList)
                    //    {
                    //        //根据工位Guid 查询装配工序信息
                    //        DataTable dtAssemblyGx = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select* from assembly_gx where agw_guid = '" + Gwitem.agw_guid + "' ", null);
                    //        List<AssemblyGxModel> AssemblyGxList = db.ToList<AssemblyGxModel>(dtAssemblyGx);

                    //        #region 判断是否有工序信息，如果有补全产品信息
                    //        if (AssemblyGxList != null && AssemblyGxList.Count > 0)
                    //        {
                    //            sql = "update assembly_gx set pInfo_ID = @pInfo_ID where agw_guid = @agw_guid ";
                    //            pList.Clear();
                    //            pList.Add(new MySqlParameter("@pInfo_ID", pInfo_ID));
                    //            pList.Add(new MySqlParameter("@agw_guid", Gwitem.agw_guid));
                    //            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    //        }
                    //        #endregion

                    //        foreach (var Gxitem in AssemblyGxList)
                    //        {
                    //            //根据工序Guid 查询装配工步信息
                    //            DataTable dtAssemblyGb = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select* from assembly_gb where agx_guid = '" + Gxitem.agx_guid + "' ", null);
                    //            List<AssemblyGbModel> AssemblyGbList = db.ToList<AssemblyGbModel>(dtAssemblyGb);

                    //            #region 判断是否有工步信息，如果有补全产品信息
                    //            if (AssemblyGbList != null && AssemblyGbList.Count > 0)
                    //            {
                    //                sql = "update assembly_gb set pInfo_ID = @pInfo_ID where agx_guid = @agx_guid ";
                    //                pList.Clear();
                    //                pList.Add(new MySqlParameter("@pInfo_ID", pInfo_ID));
                    //                pList.Add(new MySqlParameter("@agx_guid", Gxitem.agx_guid));
                    //                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    //            }
                    //            #endregion

                    //            foreach (var Gbitem in AssemblyGbList)
                    //            {
                    //                //根据工步Guid 查询装配工具信息
                    //                DataTable dtAssemblyGj = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select* from assembly_gj where agb_guid = '" + Gbitem.agb_guid + "' ", null);
                    //                List<AssemblyGbModel> AssemblyGjList = db.ToList<AssemblyGbModel>(dtAssemblyGj);

                    //                #region 判断是否有使用工具物料，如果有同时补全产品信息
                    //                if (AssemblyGjList != null && AssemblyGjList.Count > 0)
                    //                {
                    //                    sql = "update assembly_gj set pInfo_ID = @pInfo_ID where agb_guid = @agb_guid ";
                    //                    pList.Clear();
                    //                    pList.Add(new MySqlParameter("@pInfo_ID", pInfo_ID));
                    //                    pList.Add(new MySqlParameter("@agb_guid", Gbitem.agb_guid));
                    //                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    //                }
                    //                #endregion

                    //            }
                    //        }
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
        /// 修改 assembly_gw 、 gx 、 gb 、 gj 装配状态
        /// </summary>
        /// <param name="isZZGW">是否总装</param>
        /// <param name="QRcode">产品序列号 或者 部件编号</param>
        /// <param name="status">装配状态 //0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配</param>
        /// <returns></returns>
        public int UpdateGWXBJSatus(bool isZZGW, string QRcode, int status)
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
                    //根据分装部件编号 查询装配工位信息
                    DataTable dtAssemblyGw = null;
                    List<AssemblyGwModel> AssemblyGwList = null;
                    if (isZZGW)
                    {
                        //总装
                        var sqlzz = "select * from assembly_gw gw left join productinfo pf on gw.pInfo_ID = pf.pf_ID where pf_prodNo = '" + QRcode + "' and agw_finishStatus in(0, 1) order by agw_starttime desc";
                        dtAssemblyGw = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, sqlzz, null);
                        AssemblyGwList = db.ToList<AssemblyGwModel>(dtAssemblyGw);
                    }
                    else
                    {
                        //分装
                        dtAssemblyGw = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from assembly_gw where agw_QRcode='" + QRcode + "' where agw_finishStatus in(0,1) order by agw_starttime desc", null);
                        AssemblyGwList = db.ToList<AssemblyGwModel>(dtAssemblyGw);
                    }

                    #region 判断是否有工序信息，如果有补全产品信息
                    if (AssemblyGwList != null && AssemblyGwList.Count > 0)
                    {
                        foreach (var Gwitem in AssemblyGwList)
                        {
                            sql = "update assembly_gw set agw_finishStatus = @agw_finishStatus where agw_guid = @agw_guid ";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@agw_finishStatus", status));
                            pList.Add(new MySqlParameter("@agw_guid", Gwitem.agw_guid));
                            ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    #endregion

                    if (AssemblyGwList != null && AssemblyGwList.Count > 0)
                    {
                        foreach (var Gwitem in AssemblyGwList)
                        {
                            //根据工位Guid 查询装配工序信息
                            DataTable dtAssemblyGx = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select* from assembly_gx where agw_guid = '" + Gwitem.agw_guid + "' ", null);
                            List<AssemblyGxModel> AssemblyGxList = db.ToList<AssemblyGxModel>(dtAssemblyGx);

                            #region 判断是否有工序信息，如果有补全产品信息
                            if (AssemblyGxList != null && AssemblyGxList.Count > 0)
                            {
                                sql = "update assembly_gx set agx_finishStatus = @agx_finishStatus where agw_guid = @agw_guid ";
                                pList.Clear();
                                pList.Add(new MySqlParameter("@agx_finishStatus", status));
                                pList.Add(new MySqlParameter("@agw_guid", Gwitem.agw_guid));
                                ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                            }
                            #endregion

                            foreach (var Gxitem in AssemblyGxList)
                            {
                                //根据工序Guid 查询装配工步信息
                                DataTable dtAssemblyGb = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select* from assembly_gb where agx_guid = '" + Gxitem.agx_guid + "' ", null);
                                List<AssemblyGbModel> AssemblyGbList = db.ToList<AssemblyGbModel>(dtAssemblyGb);

                                #region 判断是否有工步信息，如果有补全产品信息
                                if (AssemblyGbList != null && AssemblyGbList.Count > 0)
                                {
                                    sql = "update assembly_gb set agb_finishStatus = @agb_finishStatus where agx_guid = @agx_guid ";
                                    pList.Clear();
                                    pList.Add(new MySqlParameter("@agb_finishStatus", status));
                                    pList.Add(new MySqlParameter("@agx_guid", Gxitem.agx_guid));
                                    ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                                }
                                #endregion

                                foreach (var Gbitem in AssemblyGbList)
                                {
                                    //根据工步Guid 查询装配工具信息 
                                    DataTable dtAssemblyGj = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select* from assembly_gj where agb_guid = '" + Gbitem.agb_guid + "' ", null);
                                    List<AssemblyGbModel> AssemblyGjList = db.ToList<AssemblyGbModel>(dtAssemblyGj);

                                    #region 判断是否有使用工具物料，如果有同时补全产品信息
                                    if (AssemblyGjList != null && AssemblyGjList.Count > 0)
                                    {
                                        sql = "update assembly_gj set agj_finishStatus = @agj_finishStatus where agb_guid = @agb_guid ";
                                        pList.Clear();
                                        pList.Add(new MySqlParameter("@agj_finishStatus", status));
                                        pList.Add(new MySqlParameter("@agb_guid", Gbitem.agb_guid));
                                        ret += RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                                    }
                                    #endregion

                                }
                            }
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



        #endregion

        #region 产品线组装工序信息

        /// <summary>
        /// 获取产品线组装工序信息 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public AssemblyGxModel GetAssemblyGxDetail(Guid guid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select * from assembly_gx where agx_guid=@agx_guid";

            pList.Add(new MySqlParameter("@agx_guid", guid));

            var list = db.ExecuteList<AssemblyGxModel>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }

        /// <summary>
        /// 添加产品线组装工序信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGx(AssemblyGxModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into assembly_gx(agx_guid,agw_guid,agx_gxID,pInfo_ID,agx_resultIsOK,agx_resultMemo,agx_starttime,agx_uploadFlag,agx_gxName,agx_finishStatus
,agx_finishtime,agx_oper,agx_operID,agx_remark) values(@agx_guid,@agw_guid,@agx_gxID,@pInfo_ID,@agx_resultIsOK,@agx_resultMemo,@agx_starttime,@agx_uploadFlag,@agx_gxName
,@agx_finishStatus,@agx_finishtime,@agx_oper,@agx_operID,@agx_remark)";

            pList.Add(new MySqlParameter("@agx_guid", model.agx_guid));
            pList.Add(new MySqlParameter("@agw_guid", model.agw_guid));
            pList.Add(new MySqlParameter("@agx_gxID", model.agx_gxID));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@agx_resultIsOK", model.agx_resultIsOK));
            pList.Add(new MySqlParameter("@agx_resultMemo", model.agx_resultMemo));
            pList.Add(new MySqlParameter("@agx_starttime", model.agx_starttime));
            pList.Add(new MySqlParameter("@agx_uploadFlag", model.agx_uploadFlag));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@agx_gxName", model.agx_gxName));
            pList.Add(new MySqlParameter("@agx_finishStatus", model.agx_finishStatus));
            pList.Add(new MySqlParameter("@agx_finishtime", model.agx_finishtime));
            pList.Add(new MySqlParameter("@agx_oper", model.agx_oper));
            pList.Add(new MySqlParameter("@agx_operID", model.agx_operID));
            pList.Add(new MySqlParameter("@agx_remark", model.agx_remark));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 编辑产品线组装工序信息
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGx(AssemblyGxModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update assembly_gx set agw_guid=@agw_guid,agx_gxID=@agx_gxID,pInfo_ID=@pInfo_ID,agx_resultIsOK=@agx_resultIsOK,agx_resultMemo=@agx_resultMemo
,agx_starttime=@agx_starttime,agx_uploadFlag=@agx_uploadFlag,agx_gxName=@agx_gxName,agx_finishStatus=@agx_finishStatus,agx_finishtime=@agx_finishtime
,agx_oper=@agx_oper,agx_operID=@agx_operID,agx_remark=@agx_remark where agx_guid=@agx_guid";

            pList.Add(new MySqlParameter("@agx_guid", model.agx_guid));
            pList.Add(new MySqlParameter("@agw_guid", model.agw_guid));
            pList.Add(new MySqlParameter("@agx_gxID", model.agx_gxID));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@agx_resultIsOK", model.agx_resultIsOK));
            pList.Add(new MySqlParameter("@agx_resultMemo", model.agx_resultMemo));
            pList.Add(new MySqlParameter("@agx_starttime", model.agx_starttime));
            pList.Add(new MySqlParameter("@agx_uploadFlag", model.agx_uploadFlag));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@agx_gxName", model.agx_gxName));
            pList.Add(new MySqlParameter("@agx_finishStatus", model.agx_finishStatus));
            pList.Add(new MySqlParameter("@agx_finishtime", model.agx_finishtime));
            pList.Add(new MySqlParameter("@agx_oper", model.agx_oper));
            pList.Add(new MySqlParameter("@agx_operID", model.agx_operID));
            pList.Add(new MySqlParameter("@agx_remark", model.agx_remark));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 产品线组装工步信息

        /// <summary>
        /// 获取产品线组装工步信息明细
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public AssemblyGbModel GetAssemblyGbDetail(Guid guid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select * from assembly_gb where agb_guid=@agb_guid";

            pList.Add(new MySqlParameter("@agb_guid", guid));

            var list = db.ExecuteList<AssemblyGbModel>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                return null;
            }

            return list[0];
        }

        /// <summary>
        /// 添加产品线组装工步信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGb(AssemblyGbModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into assembly_gb(agb_guid,agb_gbID,agb_gbName,agb_oper,agb_operID,agb_remark,agb_resultIsOK,agb_resultMemo,agb_starttime,agb_uploadFlag,agb_value
,agx_guid,pInfo_ID,agb_finishImg,agb_finishStatus,agb_finishtime) values(@agb_guid,@agb_gbID,@agb_gbName,@agb_oper,@agb_operID,@agb_remark,@agb_resultIsOK,@agb_resultMemo
,@agb_starttime,@agb_uploadFlag,@agb_value,@agx_guid,@pInfo_ID,@agb_finishImg,@agb_finishStatus,@agb_finishtime)";

            pList.Add(new MySqlParameter("@agb_guid", model.agb_guid));
            pList.Add(new MySqlParameter("@agb_gbID", model.agb_gbID));
            pList.Add(new MySqlParameter("@agb_gbName", model.agb_gbName));
            pList.Add(new MySqlParameter("@agb_oper", model.agb_oper));
            pList.Add(new MySqlParameter("@agb_operID", model.agb_operID));
            pList.Add(new MySqlParameter("@agb_remark", model.agb_remark));
            pList.Add(new MySqlParameter("@agb_resultIsOK", model.agb_resultIsOK));
            pList.Add(new MySqlParameter("@agb_resultMemo", model.agb_resultMemo));
            pList.Add(new MySqlParameter("@agb_starttime", model.agb_starttime));
            pList.Add(new MySqlParameter("@agb_uploadFlag", model.agb_uploadFlag));
            pList.Add(new MySqlParameter("@agb_value", model.agb_value));
            pList.Add(new MySqlParameter("@agx_guid", model.agx_guid));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@agb_finishImg", model.agb_finishImg));
            pList.Add(new MySqlParameter("@agb_finishStatus", model.agb_finishStatus));
            pList.Add(new MySqlParameter("@agb_finishtime", model.agb_finishtime));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 编辑产品线组装工步信息
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGb(AssemblyGbModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"update assembly_gb set agb_gbID=@agb_gbID,agb_gbName=@agb_gbName,agb_oper=@agb_oper,agb_operID=@agb_operID,agb_remark=@agb_remark
,agb_resultIsOK=@agb_resultIsOK,agb_resultMemo=@agb_resultMemo,agb_starttime=@agb_starttime,agb_uploadFlag=@agb_uploadFlag,agb_value=@agb_value,agx_guid=@agx_guid
,pInfo_ID=@pInfo_ID,agb_finishImg=@agb_finishImg,agb_finishStatus=@agb_finishStatus,agb_finishtime=@agb_finishtime where agb_guid=@agb_guid";

            pList.Add(new MySqlParameter("@agb_guid", model.agb_guid));
            pList.Add(new MySqlParameter("@agb_gbID", model.agb_gbID));
            pList.Add(new MySqlParameter("@agb_gbName", model.agb_gbName));
            pList.Add(new MySqlParameter("@agb_oper", model.agb_oper));
            pList.Add(new MySqlParameter("@agb_operID", model.agb_operID));
            pList.Add(new MySqlParameter("@agb_remark", model.agb_remark));
            pList.Add(new MySqlParameter("@agb_resultIsOK", model.agb_resultIsOK));
            pList.Add(new MySqlParameter("@agb_resultMemo", model.agb_resultMemo));
            pList.Add(new MySqlParameter("@agb_starttime", model.agb_starttime));
            pList.Add(new MySqlParameter("@agb_uploadFlag", model.agb_uploadFlag));
            pList.Add(new MySqlParameter("@agb_value", model.agb_value));
            pList.Add(new MySqlParameter("@agx_guid", model.agx_guid));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@agb_finishImg", model.agb_finishImg));
            pList.Add(new MySqlParameter("@agb_finishStatus", model.agb_finishStatus));
            pList.Add(new MySqlParameter("@agb_finishtime", model.agb_finishtime));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 生产线组装工具信息

        public List<AssemblyGJModel> GetAssemblyToolList(AssemblyGJModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "";
            string para = "";

            if (model.agj_guid != Guid.Empty)
            {
                para += " and agj_guid=@agj_guid ";

                pList.Add(new MySqlParameter("@agj_guid", model.agj_guid));
            }

            sql = "select * from assembly_gj where 1=1 " + para;

            List<AssemblyGJModel> list = db.ExecuteList<AssemblyGJModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 添加生产线组装工具信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGJ(AssemblyGJModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into assembly_gj(agb_guid,agj_finishStatus,agj_finishtime,agj_gjID,agj_gjName,agj_gjwlCode,agj_guid,agj_oper,agj_operID,agj_remark,agj_resultIsOK
,agj_resultMemo,agj_starttime,agj_uploadFlag,agj_value,agj_value2,agj_valueImg,agj_wlID,agj_wlName,pInfo_ID) values(@agb_guid,@agj_finishStatus,@agj_finishtime,@agj_gjID,@agj_gjName
,@agj_gjwlCode,@agj_guid,@agj_oper,@agj_operID,@agj_remark,@agj_resultIsOK,@agj_resultMemo,@agj_starttime,@agj_uploadFlag,@agj_value,@agj_value2,@agj_valueImg,@agj_wlID,@agj_wlName
,@pInfo_ID)";

            pList.Add(new MySqlParameter("@agb_guid", model.agb_guid));
            pList.Add(new MySqlParameter("@agj_finishStatus", model.agj_finishStatus));
            pList.Add(new MySqlParameter("@agj_finishtime", model.agj_finishtime));
            pList.Add(new MySqlParameter("@agj_gjID", model.agj_gjID));
            pList.Add(new MySqlParameter("@agj_gjName", model.agj_gjName));
            pList.Add(new MySqlParameter("@agj_gjwlCode", model.agj_gjwlCode));
            pList.Add(new MySqlParameter("@agj_guid", model.agj_guid));
            pList.Add(new MySqlParameter("@agj_oper", model.agj_oper));
            pList.Add(new MySqlParameter("@agj_operID", model.agj_operID));
            pList.Add(new MySqlParameter("@agj_remark", model.agj_remark));
            pList.Add(new MySqlParameter("@agj_resultIsOK", model.agj_resultIsOK));
            pList.Add(new MySqlParameter("@agj_resultMemo", model.agj_resultMemo));
            pList.Add(new MySqlParameter("@agj_starttime", model.agj_starttime));
            pList.Add(new MySqlParameter("@agj_uploadFlag", model.agj_uploadFlag));
            pList.Add(new MySqlParameter("@agj_value", model.agj_value));
            pList.Add(new MySqlParameter("@agj_value2", model.agj_value2));
            pList.Add(new MySqlParameter("@agj_valueImg", model.agj_valueImg));
            pList.Add(new MySqlParameter("@agj_wlID", model.agj_wlID));
            pList.Add(new MySqlParameter("@agj_wlName", model.agj_wlName));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改生产线组装工具信息
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGJ(AssemblyGJModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "";
            sql = @"update assembly_gj set agj_finishStatus=@agj_finishStatus,agj_finishtime=@agj_finishtime,agj_gjID=@agj_gjID,agj_gjName=@agj_gjName
,agj_gjwlCode=@agj_gjwlCode,agj_oper=@agj_oper,agj_operID=@agj_operID,agj_remark=@agj_remark,agj_resultIsOK=@agj_resultIsOK,agj_resultMemo=@agj_resultMemo
,agj_starttime=@agj_starttime,agj_uploadFlag=@agj_uploadFlag,agj_value=@agj_value,agj_value2=@agj_value2,agj_valueImg=@agj_valueImg,agj_wlID=@agj_wlID
,agj_wlName=@agj_wlName,pInfo_ID=@pInfo_ID where agj_guid=@agj_guid";
            pList.Add(new MySqlParameter("@agj_guid", model.agj_guid));
            pList.Add(new MySqlParameter("@agj_finishStatus", model.agj_finishStatus));
            pList.Add(new MySqlParameter("@agj_finishtime", model.agj_finishtime));
            pList.Add(new MySqlParameter("@agj_gjID", model.agj_gjID));
            pList.Add(new MySqlParameter("@agj_gjName", model.agj_gjName));
            pList.Add(new MySqlParameter("@agj_gjwlCode", model.agj_gjwlCode));
            pList.Add(new MySqlParameter("@agj_oper", model.agj_oper));
            pList.Add(new MySqlParameter("@agj_operID", model.agj_operID));
            pList.Add(new MySqlParameter("@agj_remark", model.agj_remark));
            pList.Add(new MySqlParameter("@agj_resultIsOK", model.agj_resultIsOK));
            pList.Add(new MySqlParameter("@agj_resultMemo", model.agj_resultMemo));
            pList.Add(new MySqlParameter("@agj_starttime", model.agj_starttime));
            pList.Add(new MySqlParameter("@agj_uploadFlag", model.agj_uploadFlag));
            pList.Add(new MySqlParameter("@agj_value", model.agj_value));
            pList.Add(new MySqlParameter("@agj_value2", model.agj_value2));
            pList.Add(new MySqlParameter("@agj_valueImg", model.agj_valueImg));
            pList.Add(new MySqlParameter("@agj_wlID", model.agj_wlID));
            pList.Add(new MySqlParameter("@agj_wlName", model.agj_wlName));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 生产关键信息记录

        /// <summary>
        /// 获取生产记录关键信息
        /// </summary>
        /// <param name="prodCode">产品编号</param>
        /// <param name="pModelID">产品型号</param>
        /// <param name="keyType">关键信息类型</param>
        /// <param name="keyValue">关键值</param>
        /// <returns></returns>
        public PageModel<List<AssemblyMainModel>> GetAssemblyMainList(string prodCode, int? pInfoID = null, int? pModelID = null, int? gwID = null, string keyType = "", string keyValue = "", DateTime? begDate = null, DateTime? endDate = null, int pageIndex = 0, int pageSize = 0)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sqlStr = @"SELECT 
                            {0}
                            FROM assembly_main main 
                            LEFT JOIN productInfo p ON p.pf_ID=main.pInfo_ID
                            LEFT JOIN v_productmodel v ON p.pf_prodModelID = v.ID 
                            LEFT JOIN base_gongwei gw ON gw.ID = main.am_gwID
                        WHERE 1=1 ";
            var sqlCount = "COUNT(*)";
            var sqlQuery = @"am_guid, 
                            pf_prodNo,
                            v.pName,
                            v.PModel,
                            pModelID,
                            pInfo_ID,
                            am_gwID,
                            gw.gwName AS am_gwName,
                            gw.gwCode as am_gwCode,
                            am_QRcode,
                            am_pInfoDate,
                            am_createDate,
                            am_updateDate,
                            am_createUser,
                            am_updateUser";
            if (!string.IsNullOrEmpty(prodCode))
            {
                pList.Add(new MySqlParameter("@pf_prodNo", prodCode));
                sqlStr += " AND am_QRcode like concat('%',@pf_prodNo,'%') ";
            }
            if (pInfoID.HasValue)
            {
                pList.Add(new MySqlParameter("@pInfoID", pInfoID));
                sqlStr += " AND pInfo_ID =@pInfoID ";
            }
            if (pModelID.HasValue && pModelID != 0)
            {
                pList.Add(new MySqlParameter("@pModelID", pModelID));
                sqlStr += " AND pModelID =@pModelID ";
            }
            if (gwID.HasValue && gwID != 0)
            {
                pList.Add(new MySqlParameter("@gwID", gwID));
                sqlStr += " AND am_gwID =@gwID ";
            }
            if (begDate.HasValue)//开始时间
            {
                pList.Add(new MySqlParameter("@begDate", begDate));
                sqlStr += " AND am_createDate>=@begDate";
            }
            if (endDate.HasValue)//完成时间
            {
                var endtime = endDate.Value.AddDays(+1).AddSeconds(-1);
                pList.Add(new MySqlParameter("@endDate", endtime));
                sqlStr += " AND am_createDate <= @endDate";
            }
            if (!string.IsNullOrWhiteSpace(keyValue))
            {
                var subStr = "SELECT  am_guid FROM assembly_mainRecord WHERE 1=1 ";
                if (!string.IsNullOrWhiteSpace(keyType))
                {
                    pList.Add(new MySqlParameter("@keyType", keyType));
                    subStr += " AND amr_Type=@keyType ";
                }
                if (!string.IsNullOrWhiteSpace(keyValue))
                {
                    pList.Add(new MySqlParameter("@keyValue", keyValue));
                    subStr += " AND amr_Value LIKE  concat('%',@keyValue,'%')  ";
                }

                if (begDate.HasValue)//开始时间
                {
                    subStr += " AND amr_createDate>=@begDate";
                }
                if (endDate.HasValue)//完成时间
                {
                    subStr += " AND amr_createDate <= @endDate";
                }

                sqlStr += string.Format(" AND am_guid IN({0})", subStr);
            }
            var totalCount = 0;
            int.TryParse(db.ExecuteScalar(string.Format(sqlStr, sqlCount), pList.ToArray()) + "", out totalCount);

            var list = new List<AssemblyMainModel>();
            if (totalCount > 0)
            {
                sqlStr += " order by am_createDate desc ";
                if (pageSize != 0 && pageIndex != 0)
                {
                    sqlStr += " limit " + pageSize * (pageIndex - 1) + "," + pageSize;
                }
                list = db.ExecuteList<AssemblyMainModel>(string.Format(sqlStr, sqlQuery), pList.ToArray());
                var vals = list.Select(f => f.am_guid.ToString()).ToArray();
                var details = GetAssemblyMainRecordList(vals, keyType, keyValue);
                foreach (var item in list)
                {
                    item.Details = details.Where(f => f.am_guid == item.am_guid).OrderBy(f => f.amr_createDate).ToList();
                }
            }

            var pageModel = new PageModel<List<AssemblyMainModel>>(totalCount, list);
            return pageModel;
        }

        public List<TightenMachineModel> GetTightenMachineList(string prodCode)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sqlStr = @"SELECT * FROM tightenmachine WHERE 1=1 ";

            pList.Add(new MySqlParameter("@prodCode", prodCode));
            sqlStr += " AND prodCode like concat('%',@prodCode,'%') ";
            var list = new List<TightenMachineModel>();

            list = db.ExecuteList<TightenMachineModel>(sqlStr, pList.ToArray());

            sqlStr = @"SELECT * FROM assemblydata WHERE 1=1 ";
            pList.Clear();
            pList.Add(new MySqlParameter("@prodCode", prodCode));
            sqlStr += " AND prodCode like concat('%',@prodCode,'%') ";

            foreach (TightenMachineModel item in list)
            {
                item.assemblyList = db.ExecuteList<AssemblyDataModel>(sqlStr, pList.ToArray());
            }

            return list;
        }

        /// <summary>
        /// 获取生产关键信息主表明细
        /// </summary>
        /// <param name="pInfoID">产品ID</param>
        /// <param name="rqCode">二维码</param>
        /// <returns></returns>
        public AssemblyMainModel GetAssemblyMainDetail(int? pInfoID = null, string rqCode = "", int? gwID = null)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            if ((pInfoID == null || pInfoID == 0) && string.IsNullOrWhiteSpace(rqCode))
            {
                throw new ArgumentNullException($"{nameof(pInfoID)},{nameof(rqCode)} 不能都为空！");
            }
            var sqlStr = @"SELECT am_guid, am_parentQRCode, pModelID, pInfo_ID, am_gwID, am_QRcode, am_pInfoDate, am_createDate, am_updateDate, am_createUser, am_updateUser
	FROM assembly_main WHERE 1=1 ";
            if (pInfoID.HasValue && pInfoID != 0)
            {
                pList.Add(new MySqlParameter("@pInfoID", pInfoID));
                sqlStr += " AND pInfo_ID=@pInfo_ID";
            }
            if (!string.IsNullOrWhiteSpace(rqCode))
            {
                pList.Add(new MySqlParameter("@am_QRcode", rqCode));
                sqlStr += " AND am_QRcode=@am_QRcode";
            }
            if (gwID.HasValue && gwID > 0)
            {
                pList.Add(new MySqlParameter("@am_gwID", gwID));
                sqlStr += " AND am_gwID=@am_gwID ";
            }
            var list = db.ExecuteList<AssemblyMainModel>(sqlStr, pList.ToArray());
            if (list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

        /// <summary>
        /// 更新生产关键信息列表
        /// </summary>
        /// <param name="model"></param>
        public Guid UpdateAssemblyMain(AssemblyMainModel model, bool isFinishGW = false)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sqlStr = string.Empty;
            var retID = model.am_guid;
            var nowDateTime = DateTime.Now;
            pList.Add(new MySqlParameter("@am_parentQRCode", model.am_parentQRCode));
            pList.Add(new MySqlParameter("@pModelID", model.pModelID));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@am_gwID", model.am_gwID));
            pList.Add(new MySqlParameter("@am_QRcode", model.am_QRcode));
            pList.Add(new MySqlParameter("@am_pInfoDate", model.am_pInfoDate));
            pList.Add(new MySqlParameter("@am_updateDate", nowDateTime));
            pList.Add(new MySqlParameter("@am_updateUser", model.am_updateUser));
            if (!model.am_guid.HasValue || model.am_guid.Value == Guid.Empty)//添加
            {
                retID = Guid.NewGuid();
                pList.Add(new MySqlParameter("@am_guid", retID));
                pList.Add(new MySqlParameter("@am_createDate", nowDateTime));
                pList.Add(new MySqlParameter("@am_createUser", model.am_createUser));
                sqlStr = @"INSERT INTO assembly_main
    (am_guid, pModelID, pInfo_ID, am_gwID, am_QRcode, am_pInfoDate, am_createDate, am_updateDate, am_createUser, am_updateUser)
    VALUES(@am_guid, @pModelID, @pInfo_ID, @am_gwID, @am_QRcode, @am_pInfoDate, @am_createDate, @am_updateDate, @am_createUser, @am_updateUser)";
            }
            else//修改
            {
                pList.Add(new MySqlParameter("@am_guid", model.am_guid));
                if (isFinishGW)
                {
                    sqlStr = @"UPDATE assembly_main
	SET
		pInfo_ID=@pInfo_ID,
		am_pInfoDate=@am_pInfoDate,
		am_updateDate=@am_updateDate,
		am_UpdateUser=@am_UpdateUser
	WHERE am_guid=@am_guid || (am_parentQRCode=@am_QRcode && am_parentQRCode is not null)";
                }
                else
                {
                    sqlStr = @"UPDATE assembly_main
	SET
        am_parentQRCode=@am_parentQRCode,
		pModelID=@pModelID,
		pInfo_ID=@pInfo_ID,
		am_gwID=@am_gwID,
		am_QRcode=@am_QRcode,
		am_pInfoDate=@am_pInfoDate,
		am_updateDate=@am_updateDate,
		am_UpdateUser=@am_UpdateUser
	WHERE am_guid=@am_guid";
                }
            }

            int i = db.ExecuteNonQuery(sqlStr, pList.ToArray());

            return retID.Value;
        }

        public void UpdateAssemblyMainByFinishGW(AssemblyMainModel model)
        {

        }

        /// <summary>
        /// 获取生产关键信息记录表
        /// </summary>
        /// <param name="amGuids"></param>
        /// <param name="keyType"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public List<AssemblyMainRecordModel> GetAssemblyMainRecordList(string[] amGuids = null, string keyType = "", string keyValue = "")
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sqlStr = @"SELECT amr_guid, am_guid, amr_type, amr_name, amr_value, amr_mark, amr_createDate, amr_updateDate
    FROM assembly_mainrecord WHERE 1=1 ";
            if (amGuids.Length > 0)
            {
                //pList.Add(new MySqlParameter("@am_guid",amGuids));
                var values = string.Join("','", amGuids);
                sqlStr += $" AND am_guid IN ('{values}') ";
            }

            if (!string.IsNullOrEmpty(keyValue))
            {
                if (!string.IsNullOrEmpty(keyType))
                {
                    pList.Add(new MySqlParameter("@amr_type", keyType));
                    sqlStr += " AND amr_type=@amr_type ";
                }

                pList.Add(new MySqlParameter("@amr_value", keyValue));
                sqlStr += " AND amr_value LIKE  concat('%',@amr_value,'%')  ";


            }
            sqlStr += "  ORDER BY amr_createDate ";
            var list = db.ExecuteList<AssemblyMainRecordModel>(sqlStr, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 获取生产关键信息记录明细
        /// </summary>
        /// <param name="amGuid">主表ID</param>
        /// <param name="keyType">关键信息类型</param>
        /// <param name="keyName">关键信息名称</param>
        /// <returns></returns>
        public AssemblyMainRecordModel GetAssemblyMainRecordDetail(string amGuid, string keyType, string keyName)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sqlStr = @"SELECT amr_guid, am_guid, amr_type, amr_name, amr_value, amr_mark, amr_createDate, amr_updateDate
    FROM assembly_mainrecord WHERE 1=1 ";
            if (!string.IsNullOrEmpty(amGuid))
            {
                pList.Add(new MySqlParameter("@am_guid", amGuid));
                sqlStr += " AND am_guid=@am_guid ";
            }
            if (!string.IsNullOrEmpty(keyType))
            {
                pList.Add(new MySqlParameter("@amr_type", keyType));
                sqlStr += " AND amr_type=@amr_type ";
            }
            if (!string.IsNullOrEmpty(keyName))
            {
                pList.Add(new MySqlParameter("@amr_name", keyName));
                sqlStr += " AND amr_name LIKE  concat('%',@amr_name,'%')  ";
            }
            var list = db.ExecuteList<AssemblyMainRecordModel>(sqlStr, pList.ToArray());
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        /// <summary>
        /// 更新生产关键信息记录
        /// </summary>
        /// <param name="model"></param>
        public void UpdateAssemblyMainRecord(AssemblyMainRecordModel model)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sqlStr = string.Empty;
            var nowDateTime = DateTime.Now;
            pList.Add(new MySqlParameter("@am_guid", model.am_guid));
            pList.Add(new MySqlParameter("@amr_type", model.amr_type));
            pList.Add(new MySqlParameter("@amr_name", model.amr_name));
            pList.Add(new MySqlParameter("@amr_value", model.amr_value));
            pList.Add(new MySqlParameter("@amr_mark", model.amr_mark));
            pList.Add(new MySqlParameter("@amr_updateDate", nowDateTime));
            if (!model.amr_guid.HasValue || model.amr_guid == Guid.Empty)
            {
                pList.Add(new MySqlParameter("@amr_guid", Guid.NewGuid()));
                pList.Add(new MySqlParameter("@amr_createDate", nowDateTime));
                sqlStr = @"INSERT INTO assembly_mainrecord
	(amr_guid, am_guid, amr_type, amr_name, amr_value, amr_mark, amr_createDate, amr_updateDate)
	VALUES (@amr_guid, @am_guid, @amr_type, @amr_name, @amr_value, @amr_mark, @amr_createDate, @amr_updateDate)";
            }
            else
            {
                pList.Add(new MySqlParameter("@amr_guid", model.amr_guid));
                sqlStr = @"UPDATE assembly_mainrecord
	SET
		amr_type=amr_type,
		amr_name=amr_name,
		amr_value=@amr_value,
		amr_mark=@amr_mark,
		amr_updateDate=@amr_updateDate
	WHERE amr_guid=@amr_guid";
            }
            int i = db.ExecuteNonQuery(sqlStr, pList.ToArray());
        }

        #endregion


        /// <summary>
        /// 用于启动装配后显示 制造BOM 2020-10-22
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public List<BaseEBOMModel> GetAssemblyMBOM(int progID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            string para = "";

            if (progID != 0)
            {
                para += " and bp.ID = @progID ";
                pList.Add(new MySqlParameter("@progID", progID));
            }

            sql = @"select m.mName,m.mDrawingNo,TRUNCATE(eb.ebQty,3) as Qty,eb.ebRemark from base_program bp
                    left join gw_prod_def gpf on bp.ID = gpf.progID
                    left join base_ebom eb on gpf.operationID = eb.ebOperationID and(ebParentID <> NULL || ebParentID <> 0)
                    left join base_material m on eb.ebChildID = m.ID
                    where 1=1 " + para;
            sql += "ORDER BY m.mDrawingNo desc";
            List<BaseEBOMModel> list = db.ExecuteList<BaseEBOMModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 用于启动装配后获取分钟节拍 2020-10-23
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public BaseGwProdDefModel GetGwProdDefByBeatMinite(int progID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            string para = "";

            if (progID != 0)
            {
                para += " and bp.ID = @progID ";
                pList.Add(new MySqlParameter("@progID", progID));
            }

            sql = @"select * from base_program bp
                    left join gw_prod_def gpf on bp.ID = gpf.progID
                    where 1=1 " + para;
            List<BaseGwProdDefModel> list = db.ExecuteList<BaseGwProdDefModel>(sql, pList.ToArray());
            return list.Count > 0 ? list[0] : null;
        }

        /// <summary>
        /// 更新产线组装工位二维码
        /// </summary>
        /// <param name="QRcode">二维码</param>
        /// <param name="fgw_guid">工位组装GUID</param>
        /// <returns></returns>
        public void UpdateGwQRcode(string QRcode, Guid gw_guid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            AssemblyGwModel GwModel = GetAssemblyGwDetail(gw_guid);

            if (GwModel == null)
            {
                throw new Exception("没有找到产线组装工位！");
            }
            string sql = "update assembly_gw set agw_QRcode=@agw_QRcode where agw_guid=@agw_guid";

            pList.Add(new MySqlParameter("@agw_QRcode", QRcode));
            pList.Add(new MySqlParameter("@agw_guid", gw_guid));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 根据产线组装工位二维码，修改工位的产品GUID
        /// </summary>
        /// <param name="gwQRcode"></param>
        /// <param name="prod_guid"></param>
        /// <returns></returns>
        public void UpdateGWfp_guid(string gwQRcode, Guid prod_guid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select * from assembly_gw where agw_QRcode=@agw_QRcode";

            pList.Add(new MySqlParameter("@agw_QRcode", gwQRcode));

            List<AssemblyGwModel> Gwlist = db.ExecuteList<AssemblyGwModel>(sql, pList.ToArray());

            if (Gwlist.Count == 0)
            {
                throw new Exception("没有找到产线组装工位！");
            }

            sql = "update assembly_gw set fp_guid=@fp_guid where agw_QRcode=@agw_QRcode";
            pList.Clear();
            pList.Add(new MySqlParameter("@fp_guid", prod_guid));
            pList.Add(new MySqlParameter("@agw_QRcode", gwQRcode));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 添加错误记录
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public void AddErrorInfo(AssemblyErrorInfoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into assembly_errorInfo(ErrorTypeID,pInfo_ID,agw_guid,agx_guid,agb_guid,agj_guid,err_operID,err_oper,err_gwID,err_gw
,errDate,errorDesp) values(@ErrorTypeID,@pInfo_ID,@agw_guid,@agx_guid,@agb_guid,@agj_guid,@err_operID,@err_oper,@err_gwID,@err_gw,@errDate,@errorDesp)";
            pList.Add(new MySqlParameter("@ErrorTypeID", model.ErrorTypeID));
            //pList.Add(new MySqlParameter("@fp_guid", model.fp_guid));
            pList.Add(new MySqlParameter("@pInfo_ID", model.pInfo_ID));
            pList.Add(new MySqlParameter("@agw_guid", model.agw_guid));
            pList.Add(new MySqlParameter("@agx_guid", model.agx_guid));
            pList.Add(new MySqlParameter("@agb_guid", model.agb_guid));
            pList.Add(new MySqlParameter("@agj_guid", model.agj_guid));
            pList.Add(new MySqlParameter("@err_operID", model.err_operID));
            pList.Add(new MySqlParameter("@err_oper", model.err_oper));
            pList.Add(new MySqlParameter("@err_gwID", model.err_gwID));
            pList.Add(new MySqlParameter("@err_gw", model.err_gw));
            pList.Add(new MySqlParameter("@errDate", model.errDate));
            pList.Add(new MySqlParameter("@errorDesp", model.errorDesp));

            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 添加拧紧机装配记录
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddTightenMachineInfo(TightenMachineModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into TightenMachine(prodCode,workerName,startTime,endTime) values(@prodCode,@workerName,@startTime,@endTime)";
            pList.Add(new MySqlParameter("@prodCode", model.prodCode));
            pList.Add(new MySqlParameter("@workerName", model.workerName));
            pList.Add(new MySqlParameter("@startTime", model.startTime));
            pList.Add(new MySqlParameter("@endTime", model.endTime));

            return db.ExecuteNonQuery(sql, pList.ToArray()) > 0;
        }

        /// <summary>
        /// 添加拧紧机装配值记录
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddAssemblyDataInfo(AssemblyDataModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into AssemblyData(prodCode,amdName,amdValue) values(@prodCode,@amdName,@amdValue)";
            pList.Add(new MySqlParameter("@prodCode", model.prodCode));
            pList.Add(new MySqlParameter("@amdName", model.amdName));
            pList.Add(new MySqlParameter("@amdValue", model.amdValue));

            return db.ExecuteNonQuery(sql, pList.ToArray()) > 0;
        }

        /// <summary>
        /// 查找工位条形码是否存在
        /// </summary>
        /// <returns>true:存在；false:不存在</returns>
        public bool IsExistGwBarcode(string agw_QRcode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select count(*) from assembly_gw where agw_QRcode=@agw_QRcode";

            int count = 0;

            pList.Add(new MySqlParameter("@agw_QRcode", agw_QRcode));

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out count);

            return count > 0;
        }

        /// <summary>
        /// 保存工控机设备运行时间
        /// </summary>
        /// <param name="devIP">设备IP</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string DeviceRun(string devIP)
        {
            var getDate = (new DAL_System()).GetDateTime();

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            DeviceModel dev = (new DAL_Device()).GetDevice().Where(f => f.DevIP == devIP && f.DevStatus == 0).FirstOrDefault();

            if (dev == null)
            {
                return "工控机设备不存在";
            }

            string sql = @"select devID as DevID,startDate as StartDate,endDate as EndDate,remark from device_run where devID=@devID and date(startDate)='" + getDate.ToString("yyyy-MM-dd") + "' order by startDate desc";

            pList.Add(new MySqlParameter("@devID", dev.ID));

            List<DeviceRunModel> devRun = db.ExecuteList<DeviceRunModel>(sql, pList.ToArray());

            if (devRun.Count > 0 && devRun[0].StartDate.Value.ToString("yyyy-MM-dd") == getDate.ToString("yyyy-MM-dd"))
            {
                sql = "update device_run set endDate=@endDate where devID=@devID and date(startDate)=@startDate";
                pList.Clear();
                pList.Add(new MySqlParameter("@endDate", getDate));
                pList.Add(new MySqlParameter("@devID", dev.ID));
                pList.Add(new MySqlParameter("@startDate", devRun[0].StartDate.Value.ToString("yyyy-MM-dd")));
                db.ExecuteNonQuery(sql, pList.ToArray());
                return string.Empty;
            }
            else
            {
                sql = @"insert into device_run(devID,startDate,endDate)values(@devID,@startDate,@endDate)";
                pList.Clear();
                pList.Add(new MySqlParameter("@devID", dev.ID));
                pList.Add(new MySqlParameter("@startDate", getDate));
                pList.Add(new MySqlParameter("@endDate", getDate));
                db.ExecuteNonQuery(sql, pList.ToArray());
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取工位下所有程序的下拉选项
        /// </summary>
        /// <param name="gwID"></param>
        /// <returns></returns>
        public List<KeyValuePair<int, string>> GetProdModelForDDL(int gwID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select distinct pm.ID,pm.Pmodel,p.Pname from gw_prod_def def 
                    left join base_productModel pm on def.prodModelID=pm.ID 
                    left join base_product p on p.ID=pm.PID 
                    left join base_program pg on pg.ID=def.progID 
                    where p.Pstatus=0 and pg.gwID=@gwID ";

            pList.Add(new MySqlParameter("@gwID", gwID));

            DataTable dt = db.ExecuteDataTable(sql, pList.ToArray());

            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();

            foreach (DataRow row in dt.Rows)
            {
                int ID = 0;
                int.TryParse(row["ID"] + "", out ID);
                KeyValuePair<int, string> hash = new KeyValuePair<int, string>(ID, row["Pmodel"] + "-" + row["Pname"]);
                list.Add(hash);
            }

            return list;
        }

        /// <summary>
        /// 获取程序下拉列表,查询 工位、产品、程序、组件关联信息表gw_prod_def
        /// </summary>
        /// <param name="gwID">工位ID</param>
        /// <param name="prodModelID">产品型号ID</param>
        /// <param name="componentID">组件ID</param>
        /// <returns></returns>
        public List<KeyValuePair<int, string>> GetProgramForDLL(int gwID, int prodModelID, int componentID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (prodModelID != 0)
            {
                para += " and def.prodModelID = @prodModelID ";
                pList.Add(new MySqlParameter("@prodModelID", prodModelID));
            }
            if (componentID != 0)
            {
                para += " and def.componentID = @componentID ";
                pList.Add(new MySqlParameter("@componentID", componentID));
            }

            string sql = @"select distinct prog.ID,prog.progName from gw_prod_def def
                            left join base_program prog on def.progID=prog.ID
                            where prog.progStatus=0 and prog.gwID=@gwID " + para;
            pList.Add(new MySqlParameter("@gwID", gwID));
            DataTable dt = db.ExecuteDataTable(sql, pList.ToArray());
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            foreach (DataRow row in dt.Rows)
            {
                int ID = 0;
                int.TryParse(row["ID"] + "", out ID);
                KeyValuePair<int, string> hash = new KeyValuePair<int, string>(ID, row["progName"] + "");
                list.Add(hash);
            }
            return list;
        }

        /// <summary>
        /// 获取所有OPC点位
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="isClear"></param>
        /// <returns></returns>
        public List<GwGJWLOPCPointModel> GetAllOPCTag(string ip, bool isClear)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select distinct opc.opcTypeCode OPCTypeCode,'' OPCDeviceName,opc.opcValue OPCValue from base_gongwei gw 
            left join base_gongweiOPC opc on gw.ID=opc.gwID where ifnull(opc.opcValue,'')<>'' and gw.IP=@IP";

            pList.Add(new MySqlParameter("@IP", ip));

            List<GwGJWLOPCPointModel> list1 = db.ExecuteList<GwGJWLOPCPointModel>(sql, pList.ToArray());

            sql = @"select distinct opc.opcTypeCode OPCTypeCode,opc.opcDeviceName OPCDeviceName,opc.opcValue OPCValue from base_gongwei gw 
            left join base_gjwlOpcPoint opc on gw.ID=opc.gwID where ifnull(opc.opcValue,'')<>'' and (opc.opcTypeCode='gjwlGet' or opc.opcTypeCode='gjwlPut') and gw.IP=@IP";
            List<GwGJWLOPCPointModel> list2 = db.ExecuteList<GwGJWLOPCPointModel>(sql, pList.ToArray());

            if (!isClear)
            {
                sql = @"select distinct 'PLCTag' OPCTypeCode,'' OPCDeviceName,cfg_value OPCValue from sys_config 
                where ifnull(cfg_code,'')<>'' and cfg_code='PLCTag'";

                pList.Clear();

                List<GwGJWLOPCPointModel> list3 = db.ExecuteList<GwGJWLOPCPointModel>(sql, pList.ToArray());

                list2 = list2.Union(list3).Distinct().ToList();
            }
            list2 = list2.Union(list1).Distinct().ToList();

            return list2;
        }

        /// <summary>
        /// 返回工序第一工步时，修改工序下已组装的工序、工步、工具的完成状态为4
        /// </summary>
        /// <param name="returnCode">装配的工序返回状态编码</param>
        /// <param name="agx_guid">装配工序GUID</param>
        /// <param name="ErrorTypeID">装配异常类型ID</param>
        /// <param name="errorDesp">异常描述</param>
        /// <returns></returns>
        public void GongxuReturnUpdateGbGj(int returnCode, Guid agx_guid, int ErrorTypeID, string errorDesp)
        {
            var dateTime = (new DAL_System()).GetDateTime();

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "";

            AssemblyGxModel AssemblyGx = GetAssemblyGxDetail(agx_guid);
            //修改工序
            if (AssemblyGx != null)
            {
                sql = "update assembly_gx set agx_finishStatus=@agx_finishStatus,agx_finishtime=@agx_finishtime where agx_guid=@agx_guid";
                pList.Add(new MySqlParameter("@agx_finishStatus", returnCode));
                pList.Add(new MySqlParameter("@agx_finishtime", dateTime));
                pList.Add(new MySqlParameter("@agx_guid", agx_guid));
                db.ExecuteNonQuery(sql, pList.ToArray());
            }

            //获取产品线组装工步信息
            sql = "select * from assembly_gb where agx_guid=@agx_guid";
            pList.Clear();
            pList.Add(new MySqlParameter("@agx_guid", agx_guid));
            var Gblist = db.ExecuteList<AssemblyGbModel>(sql, pList.ToArray()).ToArray();
            //修改工步
            foreach (var item in Gblist)
            {
                sql = "update assembly_gb set agb_finishStatus=@agb_finishStatus,agb_finishtime=@agb_finishtime where agb_guid=@agb_guid";
                pList.Clear();
                pList.Add(new MySqlParameter("@agb_finishStatus", returnCode));
                pList.Add(new MySqlParameter("@agb_finishtime", dateTime));
                pList.Add(new MySqlParameter("@agb_guid", item.agb_guid));
                db.ExecuteNonQuery(sql, pList.ToArray());
            }
            //获取工步的GUID
            var gbGuidArray = string.Join(",", Gblist.Select(f => (Guid?)f.agb_guid));
            string gbGuidArrayReplace = gbGuidArray.Replace(",", "','"); //返回结果数据为：1','2','3','4','5','6的形式
            string gbGuid = string.Format("'{0}'", gbGuidArrayReplace);
            sql = "select * from assembly_gj where agb_guid in(" + gbGuid + ")";
            pList.Clear();
            var Gjlist = db.ExecuteList<AssemblyGJModel>(sql, pList.ToArray()).ToArray();
            //修改工具
            foreach (var item in Gjlist)
            {
                sql = "update assembly_gj set agj_finishStatus=@agj_finishStatus,agj_finishtime=@agj_finishtime where agj_guid=@agj_guid";
                pList.Clear();
                pList.Add(new MySqlParameter("@agj_finishStatus", returnCode));
                pList.Add(new MySqlParameter("@agj_finishtime", dateTime));
                pList.Add(new MySqlParameter("@agj_guid", item.agj_guid));
                db.ExecuteNonQuery(sql, pList.ToArray());
            }
            //添加组装异常记录表
            sql = "insert into assembly_errorinfo(ErrorTypeID,agx_guid,errDate,errorDesp)values(@ErrorTypeID,@agx_guid,@errDate,@errorDesp)";
            pList.Clear();
            pList.Add(new MySqlParameter("@ErrorTypeID", ErrorTypeID));
            pList.Add(new MySqlParameter("@agx_guid", agx_guid));
            pList.Add(new MySqlParameter("@errDate", dateTime));
            pList.Add(new MySqlParameter("@errorDesp", errorDesp));
            db.ExecuteNonQuery(sql, pList.ToArray());

        }

        /// <summary>
        /// 获取装配记录
        /// </summary>
        /// <param name="gwID">工位ID</param>
        /// <param name="prodNo">产品编号</param>
        /// <param name="begingDate">工位开始时间</param>
        /// <param name="endDate">工位完成时间</param>
        /// <returns></returns>
        public List<AssemblyRecordModel> GetGongweiAssembly(int gwID, string prodNo, string begingDate, string endDate)
        {

            //MySql
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"SELECT pd.pf_prodNo as pf_prodNo,vpm.Pname as prod_name,vpm.Pmodel as prodModel_name
                            ,gw.agw_gwID as agw_gwID,gw.agw_gwName as agw_gwName,gw.agw_oper as agw_oper,gw.agw_starttime as agw_starttime
                            ,gw.agw_finishtime as agw_finishtime,gw.agw_finishStatus as agw_finishStatus,gw.agw_resultMemo as agw_resultMemo,gx.agx_gxName as agx_gxName,gx.agx_starttime as agx_starttime
                            ,gx.agx_finishtime as agx_finishtime,gx.agx_finishStatus as agx_finishStatus
                            ,gx.agx_resultMemo as agx_resultMemo
                            ,gb.agb_gbName as agb_gbName,gb.agb_starttime as agb_starttime
                            ,gb.agb_finishtime as agb_finishtime,gb.agb_finishStatus as agb_finishStatus
                            ,gb.agb_resultMemo as agb_resultMemo,gj.agj_gjName as agj_gjName,gj.agj_wlName as agj_wlName
                            ,gj.agj_starttime as agj_starttime,gj.agj_finishtime as agj_finishtime,gj.agj_finishStatus as agj_finishStatus
                            ,gj.agj_value as agj_value,gj.agj_gjwlCode as agj_gjwlCode,agj_resultMemo as agj_resultMemo
                            from assembly_gw as gw LEFT JOIN
                assembly_gx as gx on gw.agw_guid=gx.agw_guid LEFT JOIN
                assembly_gb as gb on gx.agx_guid=gb.agx_guid LEFT JOIN 
                assembly_gj as gj on gb.agb_guid=gj.agb_guid LEFT JOIN
                productInfo as pd on gw.pInfo_ID=pd.pf_ID LEFT JOIN
                v_productModel as vpm on pd.pf_prodModelID=vpm.ID where 0=0";

            if (gwID != 0)
            {
                sql += " and gw.agw_gwID=@gwID";
                pList.Add(new MySqlParameter("@gwID", gwID));
            }
            if (!string.IsNullOrEmpty(prodNo))
            {
                sql += " and pd.pf_prodNo=@pf_prodNo";
                pList.Add(new MySqlParameter("@pf_prodNo", prodNo));
            }
            if (!string.IsNullOrEmpty(begingDate))
            {
                var startime = DateTime.Parse(begingDate);
                sql += " and gw.agw_starttime>=@startime";
                pList.Add(new MySqlParameter("@startime", startime));

            }
            if (!string.IsNullOrEmpty(endDate))
            {

                var finishtime = DateTime.Parse(endDate).AddDays(+1).AddSeconds(-1);
                sql += " and gw.agw_finishtime<=@finishtime";
                pList.Add(new MySqlParameter("@finishtime", finishtime));
            }

            List<AssemblyRecordModel> Assemblylist = db.ExecuteList<AssemblyRecordModel>(sql, pList.ToArray());
            return Assemblylist;
        }

        /// <summary>
        /// 新增异常下线信息
        /// </summary>
        public void AddOfflineInfo(AbnormalOfflineModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into AbnormalOfflineInfo(prodCode,agw_guid,agx_guid,agb_guid,CurrentGXIndex,CurrentGBIndex,CurrentGJWLIndex,operID,offlineState,saveTime) 
                           values(@prodCode,@agw_guid,@agx_guid,@agb_guid,@CurrentGXIndex,@CurrentGBIndex,@CurrentGJWLIndex,@operID,@offlineState,@saveTime)";

            pList.Add(new MySqlParameter("@prodCode", model.prodCode));
            pList.Add(new MySqlParameter("@agw_guid", model.agw_guid));
            pList.Add(new MySqlParameter("@agx_guid", model.agx_guid));
            pList.Add(new MySqlParameter("@agb_guid", model.agb_guid));
            pList.Add(new MySqlParameter("@CurrentGXIndex", model.CurrentGXIndex));
            pList.Add(new MySqlParameter("@CurrentGBIndex", model.CurrentGBIndex));
            pList.Add(new MySqlParameter("@CurrentGJWLIndex", model.CurrentGJWLIndex));
            pList.Add(new MySqlParameter("@operID", model.operID));
            pList.Add(new MySqlParameter("@offlineState", model.offlineState));
            pList.Add(new MySqlParameter("@saveTime", model.saveTime));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 查询异常下线信息
        /// </summary>
        public AbnormalOfflineModel GetOfflineInfo(string code)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select * from AbnormalOfflineInfo where prodCode=@prodCode and offlineState=0 ";

            pList.Add(new MySqlParameter("@prodCode", code));

            return db.ExecuteList<AbnormalOfflineModel>(sql, pList.ToArray()).FirstOrDefault();
        }

        /// <summary>
        /// 修改异常下线信息
        /// </summary>
        public void UpdateOffline(string code)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "update AbnormalOfflineInfo set offlineState=1 where prodCode=@prodCode and offlineState=0 ";

            pList.Add(new MySqlParameter("@prodCode", code));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 装配的异常下线处理
        /// </summary>
        /// <param name="prodID">系统产品编号ID</param>
        /// <param name="errDownCode_follow">追溯异常下线状态编码</param>
        /// <param name="errDownCode_ams">装配异常下线状态编码</param>
        /// <param name="ErrorTypeID">装配异常类型ID</param>
        /// <param name="fp_QRcode">装配工位二维码</param>
        /// <param name="fgw_guid">装配工位GUID</param>
        /// <param name="fgx_guid">装配工序GUID</param>
        /// <param name="fgb_guid">装配工步GUID</param>
        /// <param name="fgj_guid">装配工具GUID</param>
        /// <param name="errorDesp">异常描述</param>
        /// <param name="errOperID">操作人员ID</param>
        /// <param name="errOper">操作人员</param>
        /// <param name="errGwID">操作工位ID</param>
        /// <param name="errGw">操作工位</param>
        /// <returns></returns>
        public void ProdErrorOffLine(int prodID, int errDownCode_ams, int errorTypeID, Guid fgw_guid, Guid fgx_guid, Guid fgb_guid, Guid? fgj_guid, string errorDesp, int errOperID, string errOper, int errGwID, string errGw)
        {
            using (MySqlConnection myConnection = new MySqlConnection(Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                var myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    var pList = new List<MySqlParameter>();
                    var db = new Common.MySqlHelper();
                    var serverTime = db.GetServerTime();

                    //修改生产记录表
                    var prodSQL = "select * from productinfo where pf_ID=@pf_ID";
                    var prodIDParam = new MySqlParameter("@pf_ID", prodID);
                    var prodInfo = db.ExecuteScalar<ProductInfoModel>(prodSQL, prodIDParam);
                    if (prodInfo == null)
                    {
                        throw new Exception("没有找到产品记录信息！");
                    }
                    prodSQL = @"UPDATE  productInfo SET
                                                 pf_finishStatus=@finishStatus,
                                                 pf_resultIsOK=@pf_resultIsOK,
                                                 pf_UpdateTime=@pf_UpdateTime,
                                                 pf_UpdateMan=@pf_UpdateMan
                                WHERE pf_ID=@pf_ID";

                    pList.Add(new MySqlParameter("@pf_ID", prodID));
                    pList.Add(new MySqlParameter("@finishStatus", errDownCode_ams));
                    pList.Add(new MySqlParameter("@pf_resultIsOK", false));
                    pList.Add(new MySqlParameter("@pf_UpdateTime", serverTime));
                    pList.Add(new MySqlParameter("@pf_UpdateMan", errOperID));
                    Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, prodSQL, pList.ToArray());

                    //修改装配工位表
                    var assGWSQL = "UPDATE  assembly_gw SET agw_finishStatus=@finishStatus  WHERE pInfo_ID=@pf_ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pf_ID", prodID));
                    pList.Add(new MySqlParameter("@finishStatus", errDownCode_ams));
                    Common.MySqlHelper.ExecuteNonQuery(assGWSQL, CommandType.Text, prodSQL, pList.ToArray());

                    //修改装配工序表
                    var assGXSQL = "UPDATE  assembly_gx SET agx_finishStatus=@finishStatus  WHERE pInfo_ID=@pf_ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pf_ID", prodID));
                    pList.Add(new MySqlParameter("@finishStatus", errDownCode_ams));
                    Common.MySqlHelper.ExecuteNonQuery(assGXSQL, CommandType.Text, prodSQL, pList.ToArray());

                    //修改装配工步表

                    var assGBSQL = "UPDATE  assembly_gb SET agb_finishStatus=@finishStatus  WHERE pInfo_ID=@pf_ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pf_ID", prodID));
                    pList.Add(new MySqlParameter("@finishStatus", errDownCode_ams));
                    Common.MySqlHelper.ExecuteNonQuery(assGBSQL, CommandType.Text, prodSQL, pList.ToArray());

                    //修改装配工具表
                    var assGJSQL = "UPDATE  assembly_gj SET agj_finishStatus=@finishStatus  WHERE pInfo_ID=@pf_ID";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@pf_ID", prodID));
                    pList.Add(new MySqlParameter("@finishStatus", errDownCode_ams));
                    Common.MySqlHelper.ExecuteNonQuery(assGJSQL, CommandType.Text, prodSQL, pList.ToArray());

                    //添加装配错误记录
                    var assErrSQL = @"insert into assembly_errorInfo(ErrorTypeID,pInfo_ID,agw_guid,agx_guid,agb_guid,agj_guid,err_operID,err_oper,
                                        err_gwID,err_gw,errorDesp,errDate)values(@ErrorTypeID,@pInfo_ID,@agw_guid,@agx_guid,@agb_guid,@agj_guid,
                                        @err_operID,@err_oper,@err_gwID,@err_gw,@errorDesp,@errDate)";
                    pList.Clear();
                    pList.Add(new MySqlParameter("@ErrorTypeID", errorTypeID));
                    pList.Add(new MySqlParameter("@pInfo_ID", prodID));
                    pList.Add(new MySqlParameter("@agw_guid", fgw_guid));
                    pList.Add(new MySqlParameter("@agx_guid", fgx_guid));
                    pList.Add(new MySqlParameter("@agb_guid", fgb_guid));
                    pList.Add(new MySqlParameter("@agj_guid", fgj_guid));
                    pList.Add(new MySqlParameter("@err_operID", errOperID));
                    pList.Add(new MySqlParameter("@err_oper", errOper));
                    pList.Add(new MySqlParameter("@err_gwID", errGwID));
                    pList.Add(new MySqlParameter("@err_gw", errGw));
                    pList.Add(new MySqlParameter("@errorDesp", errorDesp));
                    pList.Add(new MySqlParameter("@errDate", serverTime));
                    Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, assErrSQL, pList.ToArray());

                    //提交事务
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
    }
}
