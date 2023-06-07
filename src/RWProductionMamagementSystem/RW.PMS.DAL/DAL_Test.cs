using MySql.Data.MySqlClient;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Test;
using RW.PMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RW.PMS.DAL
{
    public class DAL_Test : IDAL_Test
    {

        #region 试验配置主表


        /// <summary>
        /// 试验配置主表 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TestConfigMainModel> GetTestConfigMain(TestConfigMainModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (!string.IsNullOrEmpty(model.LIKETcmName))
            {
                para += " and tcmName like CONCAT('%',@tcmName,'%') ";
                pList.Add(new MySqlParameter("@tcmName", model.LIKETcmName));
            }
            string sql = @"select * from test_configmain where 1=1 and tcmDeleteFlag = 0 " + para;
            List<TestConfigMainModel> list = db.ExecuteList<TestConfigMainModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 添加试验配置主表
        /// </summary>
        /// <param name="model"></param>
        public void AddTestConfigMain(TestConfigMainModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into test_configmain(tcmGUID,tcmName,tcmRemark,tcmDeleteFlag,tcmCreateTime,tcmCreaterID,tcmUpdateTime,tcmUpdaterID) 
                                   values(@tcmGUID,@tcmName,@tcmRemark,@tcmDeleteFlag,@tcmCreateTime,@tcmCreaterID,@tcmUpdateTime,@tcmUpdaterID)";
            pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
            pList.Add(new MySqlParameter("@tcmName", model.tcmName));
            pList.Add(new MySqlParameter("@tcmRemark", model.tcmRemark));
            pList.Add(new MySqlParameter("@tcmDeleteFlag", model.tcmDeleteFlag));
            pList.Add(new MySqlParameter("@tcmCreateTime", model.tcmCreateTime));
            pList.Add(new MySqlParameter("@tcmCreaterID", model.tcmCreaterID));
            pList.Add(new MySqlParameter("@tcmUpdateTime", model.tcmUpdateTime));
            pList.Add(new MySqlParameter("@tcmUpdaterID", model.tcmUpdaterID));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改试验配置主表
        /// </summary>
        /// <param name="model"></param>
        public void UpdateTestConfigMain(TestConfigMainModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update test_configmain set tcmName=@tcmName,tcmRemark=@tcmRemark,tcmDeleteFlag=@tcmDeleteFlag,tcmCreateTime=@tcmCreateTime,tcmCreaterID=@tcmCreaterID,
                                    tcmUpdateTime=@tcmUpdateTime,tcmUpdaterID=@tcmUpdaterID where tcmGUID = @tcmGUID";
            pList.Add(new MySqlParameter("@tcmName", model.tcmName));
            pList.Add(new MySqlParameter("@tcmRemark", model.tcmRemark));
            pList.Add(new MySqlParameter("@tcmDeleteFlag", model.tcmDeleteFlag));
            pList.Add(new MySqlParameter("@tcmCreateTime", model.tcmCreateTime));
            pList.Add(new MySqlParameter("@tcmCreaterID", model.tcmCreaterID));
            pList.Add(new MySqlParameter("@tcmUpdateTime", model.tcmUpdateTime));
            pList.Add(new MySqlParameter("@tcmUpdaterID", model.tcmUpdaterID));
            pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 保存 试验配置主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTestConfigMain(TestConfigMainModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                bool ret = false;

                try
                {
                    var tcmguid = Guid.Empty;

                    #region test_configmain 数据操作

                    if (model.tcmGUID == Guid.Empty)
                    {
                        #region 添加主表

                        tcmguid = Guid.NewGuid();

                        string sqlmainadd = @"insert into test_configmain(tcmGUID,tcmName,tcmRemark,tcmDeleteFlag,tcmCreateTime,tcmCreaterID) 
                                   values(@tcmGUID,@tcmName,@tcmRemark,@tcmDeleteFlag,@tcmCreateTime,@tcmCreaterID)";
                        List<MySqlParameter> mainaddList = new List<MySqlParameter>();
                        mainaddList.Add(new MySqlParameter("@tcmGUID", tcmguid));
                        mainaddList.Add(new MySqlParameter("@tcmName", model.tcmName));
                        mainaddList.Add(new MySqlParameter("@tcmRemark", model.tcmRemark));
                        mainaddList.Add(new MySqlParameter("@tcmDeleteFlag", model.tcmDeleteFlag));
                        mainaddList.Add(new MySqlParameter("@tcmCreateTime", model.tcmCreateTime));
                        mainaddList.Add(new MySqlParameter("@tcmCreaterID", model.tcmCreaterID));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlmainadd, mainaddList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 修改主表

                        tcmguid = model.tcmGUID;

                        string sqlmainupdate = @"update test_configmain set tcmName=@tcmName,tcmRemark=@tcmRemark,tcmDeleteFlag=@tcmDeleteFlag,tcmUpdateTime=@tcmUpdateTime,
                                                            tcmUpdaterID=@tcmUpdaterID where tcmGUID = @tcmGUID";
                        List<MySqlParameter> mainupdateList = new List<MySqlParameter>();
                        mainupdateList.Add(new MySqlParameter("@tcmName", model.tcmName));
                        mainupdateList.Add(new MySqlParameter("@tcmRemark", model.tcmRemark));
                        mainupdateList.Add(new MySqlParameter("@tcmDeleteFlag", model.tcmDeleteFlag));
                        mainupdateList.Add(new MySqlParameter("@tcmUpdaterID", model.tcmUpdaterID));
                        mainupdateList.Add(new MySqlParameter("@tcmUpdateTime", model.tcmUpdateTime));
                        mainupdateList.Add(new MySqlParameter("@tcmGUID", tcmguid));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlmainupdate, mainupdateList.ToArray());

                        #endregion
                    }

                    #endregion

                    myTrans.Commit();
                    ret = true;
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
                return ret;
            }
        }


        /// <summary>
        /// 根据配置主表GUID 删除主从表所有信息
        /// 删除：如果删除主表下面的子表也会被同时删除
        /// </summary>
        /// <param name="gwid"></param>
        public bool DelTestConfigMain(string id)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                bool ret = false;

                try
                {
                    RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                    List<MySqlParameter> pList = new List<MySqlParameter>();

                    string[] list = id.Split(',');
                    for (int i = 0; i < list.Length; i++)
                    {
                        var tcmguid = list[i].ToString();
                        string sql = "delete from test_configdetail where tcmGUID = '" + tcmguid + "'";
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    for (int i = 0; i < list.Length; i++)
                    {
                        var tcmguid = list[i].ToString();
                        //主表采用逻辑删除
                        string sql = "update test_configmain set tcmDeleteFlag=1 where tcmGUID = '" + tcmguid + "'";
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    }

                    myTrans.Commit();
                    ret = true;
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
                return ret;

            }
        }


        #endregion

        #region 试验配置明细表


        /// <summary>
        /// 试验配置明细表 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TestConfigDetailModel> GetTestConfigDetail(TestConfigDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model.tcmGUID != Guid.Empty)
            {
                para += " and tcmGUID = @tcmGUID ";
                pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
            }
            if (!string.IsNullOrEmpty(model.LIKETcdText))
            {
                para += " and tcdText like CONCAT('%',@tcdText,'%')  ";
                pList.Add(new MySqlParameter("@tcdText", model.LIKETcdText));
            }
            if (model.tcdEditFlag != -1)
            {
                para += " and tcdEditFlag = @tcdEditFlag ";
                pList.Add(new MySqlParameter("@tcdEditFlag", model.tcdEditFlag));
            }
            string sql = @"select * from test_configdetail where 1=1 " + para;
            List<TestConfigDetailModel> list = db.ExecuteList<TestConfigDetailModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 添加试验配置明细表
        /// </summary>
        /// <param name="model"></param>
        public void AddTestConfigDetail(TestConfigDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into test_configdetail(tcmGUID,tcdRowNo,tcdColNo,tcdRowSpan,tcdColSpan,tcdFontSize,tcdAlign,tcdBorderTop,tcdBorderRight,tcdBorderBottom,
                        tcdBorderLeft,tcdWidth,tcdHeight,tcdText,tcdEditFlag,tcdRemark) 
                      values(@tcmGUID,@tcdRowNo,@tcdColNo,@tcdRowSpan,@tcdColSpan,@tcdFontSize,@tcdAlign,@tcdBorderTop,@tcdBorderRight,@tcdBorderBottom,@tcdBorderLeft,@tcdWidth,
                      @tcdHeight,@tcdText,@tcdEditFlag,@tcdRemark)";
            pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
            pList.Add(new MySqlParameter("@tcdRowNo", model.tcdRowNo));
            pList.Add(new MySqlParameter("@tcdColNo", model.tcdColNo));
            pList.Add(new MySqlParameter("@tcdRowSpan", model.tcdRowSpan));
            pList.Add(new MySqlParameter("@tcdColSpan", model.tcdColSpan));
            pList.Add(new MySqlParameter("@tcdFontSize", model.tcdFontSize));
            pList.Add(new MySqlParameter("@tcdAlign", model.tcdAlign));
            pList.Add(new MySqlParameter("@tcdBorderTop", model.tcdBorderTop));
            pList.Add(new MySqlParameter("@tcdBorderRight", model.tcdBorderRight));
            pList.Add(new MySqlParameter("@tcdBorderBottom", model.tcdBorderBottom));
            pList.Add(new MySqlParameter("@tcdBorderLeft", model.tcdBorderLeft));
            pList.Add(new MySqlParameter("@tcdWidth", model.tcdWidth));
            pList.Add(new MySqlParameter("@tcdHeight", model.tcdHeight));
            pList.Add(new MySqlParameter("@tcdText", model.tcdText));
            pList.Add(new MySqlParameter("@tcdEditFlag", model.tcdEditFlag));
            pList.Add(new MySqlParameter("@tcdRemark", model.tcdRemark));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 修改试验配置明细表
        /// </summary>
        /// <param name="model"></param>
        public void UpdateTestConfigDetail(TestConfigDetailModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update test_configdetail set tcmGUID=@tcmGUID,tcdRowNo=@tcdRowNo,tcdColNo=@tcdColNo,tcdRowSpan=@tcdRowSpan,tcdColSpan=@tcdColSpan,
                                   tcdFontSize=@tcdFontSize,tcdAlign=@tcdAlign,tcdBorderTop=@tcdBorderTop,tcdBorderRight=@tcdBorderRight,tcdBorderBottom=@tcdBorderBottom,
                                   tcdBorderLeft=@tcdBorderLeft,tcdWidth=@tcdWidth,tcdHeight=@tcdHeight,tcdText=@tcdText,tcdEditFlag=@tcdEditFlag,tcdRemark=@tcdRemark
                                   where tcdID = @tcdID";
            pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
            pList.Add(new MySqlParameter("@tcdRowNo", model.tcdRowNo));
            pList.Add(new MySqlParameter("@tcdColNo", model.tcdColNo));
            pList.Add(new MySqlParameter("@tcdRowSpan", model.tcdRowSpan));
            pList.Add(new MySqlParameter("@tcdColSpan", model.tcdColSpan));
            pList.Add(new MySqlParameter("@tcdFontSize", model.tcdFontSize));
            pList.Add(new MySqlParameter("@tcdAlign", model.tcdAlign));
            pList.Add(new MySqlParameter("@tcdBorderTop", model.tcdBorderTop));
            pList.Add(new MySqlParameter("@tcdBorderRight", model.tcdBorderRight));
            pList.Add(new MySqlParameter("@tcdBorderBottom", model.tcdBorderBottom));
            pList.Add(new MySqlParameter("@tcdBorderLeft", model.tcdBorderLeft));
            pList.Add(new MySqlParameter("@tcdWidth", model.tcdWidth));
            pList.Add(new MySqlParameter("@tcdHeight", model.tcdHeight));
            pList.Add(new MySqlParameter("@tcdText", model.tcdText));
            pList.Add(new MySqlParameter("@tcdEditFlag", model.tcdEditFlag));
            pList.Add(new MySqlParameter("@tcdRemark", model.tcdRemark));
            pList.Add(new MySqlParameter("@tcdID", model.tcdID));
            var Result = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 保存 试验配置从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTestConfigDetail(TestConfigDetailModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                bool ret = false;

                try
                {
                    #region test_configdetail 数据操作

                    if (model.tcdID == 0)
                    {
                        #region 添加主表

                        string sqlupdateadd = @"insert into test_configdetail(tcmGUID,tcdRowNo,tcdColNo,tcdRowSpan,tcdColSpan,tcdFontSize,tcdAlign,tcdBorderTop,tcdBorderRight,tcdBorderBottom,tcdBorderLeft,tcdWidth,tcdHeight,tcdText,tcdEditFlag,tcdRemark) 
                                   values(@tcmGUID,@tcdRowNo,@tcdColNo,@tcdRowSpan,@tcdColSpan,@tcdFontSize,@tcdAlign,@tcdBorderTop,@tcdBorderRight,@tcdBorderBottom,@tcdBorderLeft,@tcdWidth,
                                    @tcdHeight,@tcdText,@tcdEditFlag,@tcdRemark)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
                        pList.Add(new MySqlParameter("@tcdRowNo", model.tcdRowNo));
                        pList.Add(new MySqlParameter("@tcdColNo", model.tcdColNo));
                        pList.Add(new MySqlParameter("@tcdRowSpan", model.tcdRowSpan));
                        pList.Add(new MySqlParameter("@tcdColSpan", model.tcdColSpan));
                        pList.Add(new MySqlParameter("@tcdFontSize", model.tcdFontSize));
                        pList.Add(new MySqlParameter("@tcdAlign", model.tcdAlign));
                        pList.Add(new MySqlParameter("@tcdBorderTop", model.tcdBorderTop));
                        pList.Add(new MySqlParameter("@tcdBorderRight", model.tcdBorderRight));
                        pList.Add(new MySqlParameter("@tcdBorderBottom", model.tcdBorderBottom));
                        pList.Add(new MySqlParameter("@tcdBorderLeft", model.tcdBorderLeft));
                        pList.Add(new MySqlParameter("@tcdWidth", model.tcdWidth));
                        pList.Add(new MySqlParameter("@tcdHeight", model.tcdHeight));
                        pList.Add(new MySqlParameter("@tcdText", model.tcdText));
                        pList.Add(new MySqlParameter("@tcdEditFlag", model.tcdEditFlag));
                        pList.Add(new MySqlParameter("@tcdRemark", model.tcdRemark));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqlupdateadd, pList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 修改主表

                        string sqldetailupdate = @"update test_configdetail set tcmGUID=@tcmGUID,tcdRowNo=@tcdRowNo,tcdColNo=@tcdColNo,tcdRowSpan=@tcdRowSpan,tcdColSpan=@tcdColSpan,
                                   tcdFontSize=@tcdFontSize,tcdAlign=@tcdAlign,tcdBorderTop=@tcdBorderTop,tcdBorderRight=@tcdBorderRight,tcdBorderBottom=@tcdBorderBottom,tcdBorderLeft=@tcdBorderLeft,
                                    tcdWidth=@tcdWidth,tcdHeight=@tcdHeight,tcdText=@tcdText,tcdEditFlag=@tcdEditFlag,tcdRemark=@tcdRemark where tcdID = @tcdID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
                        pList.Add(new MySqlParameter("@tcdRowNo", model.tcdRowNo));
                        pList.Add(new MySqlParameter("@tcdColNo", model.tcdColNo));
                        pList.Add(new MySqlParameter("@tcdRowSpan", model.tcdRowSpan));
                        pList.Add(new MySqlParameter("@tcdColSpan", model.tcdColSpan));
                        pList.Add(new MySqlParameter("@tcdFontSize", model.tcdFontSize));
                        pList.Add(new MySqlParameter("@tcdAlign", model.tcdAlign));
                        pList.Add(new MySqlParameter("@tcdBorderTop", model.tcdBorderTop));
                        pList.Add(new MySqlParameter("@tcdBorderRight", model.tcdBorderRight));
                        pList.Add(new MySqlParameter("@tcdBorderBottom", model.tcdBorderBottom));
                        pList.Add(new MySqlParameter("@tcdBorderLeft", model.tcdBorderLeft));
                        pList.Add(new MySqlParameter("@tcdWidth", model.tcdWidth));
                        pList.Add(new MySqlParameter("@tcdHeight", model.tcdHeight));
                        pList.Add(new MySqlParameter("@tcdText", model.tcdText));
                        pList.Add(new MySqlParameter("@tcdEditFlag", model.tcdEditFlag));
                        pList.Add(new MySqlParameter("@tcdRemark", model.tcdRemark));
                        pList.Add(new MySqlParameter("@tcdID", model.tcdID));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sqldetailupdate, pList.ToArray());

                        #endregion
                    }

                    #endregion

                    myTrans.Commit();
                    ret = true;
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
                return ret;
            }
        }



        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tcdID"></param>
        public void DeleteTestConfigDetail(string tcdID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from test_configdetail where tcdID in(" + tcdID + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 试验结果表

        /// <summary>
        /// 查询试验结果数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<TestResultMainModel> GetTestResultMainList(TestResultMainModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            var para = "";
            if (!string.IsNullOrEmpty(model.LIKETrmProdNo))
            {
                para += " and trmProdNo like CONCAT('%',@trmProdNo,'%') ";
                pList.Add(new MySqlParameter("@trmProdNo", model.LIKETrmProdNo));
            }
            var sql = @"select * from test_resultmain where trmDeleteFlag=0 " + para + " order by trmCreateTime desc";
            var list = db.ExecuteList<TestResultMainModel>(sql, pList.ToArray());
            return list;

        }

        /// <summary>
        /// 保存试验结果
        /// </summary>
        /// <param name="model">试验结果主表实体类</param>
        /// <returns>错误代码或改变行数</returns>
        public int SaveTestResult(TestResultMainModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    Common.MySqlHelper db = new Common.MySqlHelper();
                    model.trmUpdateTime = db.GetServerTime();
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = string.Empty;
                    int flag = 0;
                    int updateflag = 0;
                    int i = 0;

                    DataTable rmdt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from test_resultmain where trmProdNo=" + model.trmProdNo, null);
                    List<TestResultMainModel> rmList = db.ToList<TestResultMainModel>(rmdt);

                    if (rmList.Count <= 0)
                    {

                        #region 查询出试验配置主表ID
                        if (model.tcmGUID == null || model.tcmGUID == Guid.Empty)
                        {
                            sql = @"select tcd.tcmGUID from test_configdetail tcd where tcd.tcdID=@tcdID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@tcdID", model.trmDetailList[0].tcdID));
                            model.tcmGUID = Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToGuid();
                            if (model.tcmGUID == Guid.Empty) return -1;
                        }
                        #endregion

                        #region 查询追溯主表ID
                        if (model.pfID == null || model.pfID == 0)
                        {
                            sql = @"select pf_ID from productinfo where deleteFlag=0 and pf_prodNo=@pf_prodNo order by pf_startTime desc";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@pf_prodNo", model.trmProdNo));
                            model.pfID = Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
                            if (model.pfID == 0) return -2;
                        }
                        #endregion

                        #region 添加试验主数据
                        if (model.trmGUID == Guid.Empty)
                            model.trmGUID = Guid.NewGuid();

                        sql = @"insert into test_resultmain(trmGUID,tcmGUID,pfID,trmProdNo,trmText,trmFlag,trmStartTime,trmEndTime,trmUpLoadTime,trmRemark,trmDeleteFlag,
                                trmCreateTime,trmCreaterID) 
                                values(@trmGUID,@tcmGUID,@pfID,@trmProdNo,@trmText,0,@trmStartTime,@trmEndTime,@trmUpLoadTime,@trmRemark,0,@trmCreateTime,@trmCreaterID)";

                        pList.Clear();
                        pList.Add(new MySqlParameter("@trmGUID", model.trmGUID));
                        pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
                        pList.Add(new MySqlParameter("@pfID", model.pfID));
                        pList.Add(new MySqlParameter("@trmProdNo", model.trmProdNo));
                        pList.Add(new MySqlParameter("@trmText", model.trmText));
                        //pList.Add(new MySqlParameter("@trmFlag", model.trmFlag));
                        pList.Add(new MySqlParameter("@trmStartTime", model.trmStartTime));
                        pList.Add(new MySqlParameter("@trmEndTime", model.trmEndTime));
                        pList.Add(new MySqlParameter("@trmUpLoadTime", model.trmUpLoadTime));
                        pList.Add(new MySqlParameter("@trmRemark", model.trmRemark));
                        pList.Add(new MySqlParameter("@trmCreateTime", model.trmCreateTime));
                        pList.Add(new MySqlParameter("@trmCreaterID", model.trmCreaterID));
                        i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        #endregion

                        #region 循环添加试验明细数据
                        foreach (var item in model.trmDetailList)
                        {
                            if (item.trdFlag == 1)
                            {
                                flag++;
                            }
                            sql = @"insert into test_resultdetail(trmGUID,tcdID,trdText,trdFlag,trdRemark,trdDeleteFlag,trdCreateTime,trdCreaterID) 
                                   values(@trmGUID,@tcdID,@trdText,@trdFlag,@trdRemark,0,@trdCreateTime,@trdCreaterID)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@trmGUID", model.trmGUID));
                            pList.Add(new MySqlParameter("@tcdID", item.tcdID));
                            pList.Add(new MySqlParameter("@trdText", item.trdText));
                            pList.Add(new MySqlParameter("@trdFlag", item.trdFlag));
                            pList.Add(new MySqlParameter("@trdRemark", item.trdRemark));
                            pList.Add(new MySqlParameter("@trdCreateTime", new DateTime()));
                            pList.Add(new MySqlParameter("@trdCreaterID", 1));
                            i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                        #endregion

                        #region 更新主表合格状态
                        if (model.trmDetailList.Count == flag)
                        {
                            sql = @"update test_resultmain set trmText='合格',trmFlag =1 where tcmGUID = @tcmGUID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@tcmGUID", model.tcmGUID));
                            i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                        #endregion

                    }
                    else
                    {
                        DataTable rddt = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, System.Data.CommandType.Text, "select * from test_resultdetail where trmGUID='" + rmList[0].trmGUID + "'", null);
                        List<TestResultDetailModel> rdList = db.ToList<TestResultDetailModel>(rddt);

                        #region 循环修改试验明细数据
                        foreach (var item in rdList)
                        {
                            for (int j = 0; j < model.trmDetailList.Count; j++)
                            {
                                if (item.tcdID == model.trmDetailList[j].tcdID)
                                {
                                    if (model.trmDetailList[j].trdFlag == 1)
                                    {
                                        updateflag++;
                                    }
                                    sql = @"update test_resultdetail set trmGUID=@trmGUID,tcdID=@tcdID,trdText=@trdText,trdFlag=@trdFlag,trdRemark=@trdRemark,
                                    trdUpdateTime=@trdUpdateTime,trdUpdaterID=@trdUpdaterID where trdID=@trdID";
                                    pList.Clear();
                                    pList.Add(new MySqlParameter("@trmGUID", rmList[0].trmGUID));
                                    pList.Add(new MySqlParameter("@tcdID", model.trmDetailList[j].tcdID));
                                    pList.Add(new MySqlParameter("@trdText", model.trmDetailList[j].trdText));
                                    pList.Add(new MySqlParameter("@trdFlag", model.trmDetailList[j].trdFlag));
                                    pList.Add(new MySqlParameter("@trdRemark", model.trmDetailList[j].trdRemark));
                                    pList.Add(new MySqlParameter("@trdUpdateTime", DateTime.Now));
                                    pList.Add(new MySqlParameter("@trdUpdaterID", 1));
                                    pList.Add(new MySqlParameter("@trdID", item.trdID));
                                    i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                                }
                            }
                        }
                        #endregion


                        #region 修改试验主数据

                        sql = @"update test_resultmain set trmStartTime=@trmStartTime,trmEndTime=@trmEndTime,trmUpLoadTime=@trmUpLoadTime,
                                trmUpdateTime=@trmUpdateTime,trmUpdaterID=@trmUpdaterID where trmGUID=@trmGUID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@trmStartTime", model.trmStartTime));
                        pList.Add(new MySqlParameter("@trmEndTime", model.trmEndTime));
                        pList.Add(new MySqlParameter("@trmUpLoadTime", model.trmUpLoadTime));
                        pList.Add(new MySqlParameter("@trmUpdateTime", DateTime.Now));
                        pList.Add(new MySqlParameter("@trmUpdaterID", 1));
                        pList.Add(new MySqlParameter("@trmGUID", rmList[0].trmGUID));
                        i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        #endregion

                        #region 更新主表合格状态
                        if (rdList.Count == updateflag)
                        {
                            sql = @"update test_resultmain set trmText='合格',trmFlag=1 where tcmGUID=@tcmGUID";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@tcmGUID", rmList[0].trmGUID));
                            i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                        #endregion
                    }

                    myTrans.Commit();
                    return i;
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
            return 0;
        }


        /// <summary>
        /// 删除试验主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteTestResultMain(TestResultMainModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);

                try
                {
                    Common.MySqlHelper db = new Common.MySqlHelper();
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    int i = 0;

                    string[] list = model.DELIDs.Split(',');
                    foreach (var item in list)
                    {
                        string sql = "update test_resultmain set trmDeleteFlag=1,trmUpdaterID=" + (model.trmUpdaterID ?? 0) + ",trmUpdateTime=now() where trmGUID = '" + item + "' and trmDeleteFlag=0";
                        i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    }

                    myTrans.Commit();
                    return i;
                }
                catch
                {
                    myTrans.Rollback();
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
            return 0;
        }


        /// <summary>
        /// 获取试验结果明细集合
        /// </summary>
        /// <param name="model">查询条件实体类</param>
        /// <returns></returns>
        public List<TestResultDetailModel> GetTestResultDetailList(TestResultDetailModel model)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var para = "";

            if (model.trmGUID.HasValue)
            {
                para += " and rd.trmGUID=@trmGUID ";
                pList.Add(new MySqlParameter("@trmGUID", model.trmGUID));
            }
            var sql = @"select * from test_resultdetail rd left join test_configdetail cd on cd.tcdID=rd.tcdID where rd.trdDeleteFlag=0 " + para;
            var list = db.ExecuteList<TestResultDetailModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 删除试验从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int DeleteTestResultDetail(TestResultDetailModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    Common.MySqlHelper db = new Common.MySqlHelper();
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    string sql = string.Empty;
                    int i = 0;
                    string[] list = model.DELIDs.Split(',');
                    foreach (var item in list)
                    {
                        sql = "update test_resultdetail set trdDeleteFlag=1,trdUpdaterID=" + (model.trdUpdaterID ?? 0) + ",trdUpdateTime=now() where trdID = " + item + " and trdDeleteFlag=0";
                        i += Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                    }
                    myTrans.Commit();
                    return i;
                }
                catch
                {
                    myTrans.Rollback();
                }
                finally
                {
                    myTrans.Dispose();
                }
            }
            return 0;
        }

        #endregion

        #region 根据产品编号


        /// <summary>
        /// 根据当前产品编号获取试验数据
        /// </summary>
        /// <param name="strProdNo">产品编号</param>
        /// <returns>试验数据</returns>
        public TestConfigMainModel GetTestDataByProdNo(string strProdNo)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            string para = "";

            //查询条件
            pList.Clear();
            if (!string.IsNullOrEmpty(strProdNo))
            {
                para += " and trmProdNo=@trmProdNo ";
                pList.Add(new MySqlParameter("@trmProdNo", strProdNo));
            }

            //获取结果主表
            sql = "select * from test_resultmain where 1=1 " + para + " order by trmCreateTime desc";
            var rmList = db.ExecuteList<TestResultMainModel>(sql, pList.ToArray());
            if (rmList.Count == 0) return new TestConfigMainModel();

            //获取配置明细
            sql = @"select * from test_configdetail detail 
                            left join test_configmain main on detail.tcmGUID = main.tcmGUID 
                            where 1=1 and detail.tcmGUID=@tcmGUID";
            pList.Clear();
            pList.Add(new MySqlParameter("@tcmGUID", rmList[0].tcmGUID));
            var cdList = db.ExecuteList<TestConfigDetailModel>(sql, pList.ToArray());
            if (cdList.Count == 0) return new TestConfigMainModel();

            //获取结果明细
            sql = "select * from test_resultdetail where trdDeleteFlag=0 and trmGUID=@trmGUID";
            pList.Clear();
            pList.Add(new MySqlParameter("@trmGUID", rmList[0].trmGUID));
            var rdList = db.ExecuteList<TestResultDetailModel>(sql, pList.ToArray());

            TestConfigMainModel main = new TestConfigMainModel();
            main.tcmName = cdList[0].tcmName; //主表信息
            main.DetailList = cdList;
            main.ResultList = rdList;
            return main;
        }


        /// <summary>
        /// 根据当前产品编号查询 fmGuid
        /// </summary>
        /// <param name="prodNo"></param>
        /// <returns></returns>
        //public string GetProdNoIsExist(string prodNo)
        //{
        //    RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
        //    List<MySqlParameter> pList = new List<MySqlParameter>();
        //    //string sql = @"select fm.fm_guid as fmGUID,pf.pf_prodNo,fp.fp_prodNo_sys from productInfo pf
        //    //                        left join follow_production fp on pf.pf_ID = fp.fp_pInfo_ID
        //    //                        left join follow_main fm on pf.pf_ID = fm.pInfo_ID
        //    //                        where 1=1 and pf.pf_prodNo like CONCAT('%',@prodNo,'%') ";

        //    //sql += " and (fm.fm_finishStatus = 0 or fm.fm_finishStatus = 1 or fm.fm_finishStatus = 5) order by fm.fm_starttime desc ";
        //    string sql = @"select* from productInfo pf
        //                    left join part_plan pp on pp.pp_orderCode = pf.pp_orderCode
        //                    where pp.deleteFlag = 0 and pf.pf_prodNo like CONCAT('%',@prodNo,'%') ";
        //    pList.Add(new MySqlParameter("@prodNo", prodNo));
        //    List<TestConfigMainModel> list = db.ExecuteList<TestConfigMainModel>(sql, pList.ToArray());
        //    if (list.Count > 0) { return list[0].fmGUID.ToString(); } else { return Guid.Empty.ToString(); }
        //}

        #endregion



    }
}
