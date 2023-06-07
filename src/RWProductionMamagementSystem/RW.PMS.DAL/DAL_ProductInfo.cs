using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RW.PMS.DAL
{
    internal class DAL_ProductInfo : IDAL_ProductInfo
    {

        #region 生产计划

        /// <summary>
        /// 根据ID获取(产品表)表实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseProductModel GetBaseProductById(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT * from base_product where ID=@ID ORDER BY ID ";
            pList.Add(new MySqlParameter("@ID", id));
            List<BaseProductModel> query = db.ExecuteList<BaseProductModel>(sql, pList.ToArray());
            return query[0];
        }
        /// <summary>
        /// 根据ID获取(产品型号)表实体类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseProductModelModel GetBaseProductModelById(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "SELECT * from base_productModel where ID=@ID ORDER BY ID";
            pList.Add(new MySqlParameter("@ID", id));
            var BaseProductModelModel = db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());
            return BaseProductModelModel[0];
        }

        #endregion

        /// <summary>
        /// 查询生产记录列表
        /// </summary>
        /// <param name="prodNo">生产编号</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <param name="finishStatus">完成状态</param>
        /// <param name="begDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductList(string prodNo = "", int? pModelID = null, int? finishStatus = null, DateTime? begDate = null, DateTime? endDate = null)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sql = @"SELECT 
                         pf_prodNo,
                         pf_ID,
                         v.pName,
                         v.PModel,
                         pf_prodModelID,
                         pp_orderCode,
                         pf_startTime,
                         pf_finishTime,
                         pf_finishStatus,
                         pf_resultIsOK,
                         pf_resultMemo
                        FROM
	                        productInfo p
                        JOIN v_productmodel v ON p.pf_prodModelID = v.ID WHERE 1=1 ";
            if (!string.IsNullOrWhiteSpace(prodNo))
            {
                sql += " AND pf_prodNo=@pf_prodNo";
                pList.Add(new MySqlParameter("@pf_prodNo", prodNo));
            }
            if (pModelID.HasValue && pModelID != 0)
            {
                sql += " AND pf_prodModelID=@pf_prodModelID";
                pList.Add(new MySqlParameter("@pf_prodModelID", pModelID));
            }
            if (finishStatus.HasValue)
            {
                sql += " AND pf_finishStatus=@pf_finishStatus";
                pList.Add(new MySqlParameter("@pf_finishStatus", finishStatus));
            }
            if (begDate.HasValue)
            {
                sql += " AND pf_startTime>=@begDate";
                pList.Add(new MySqlParameter("@begDate", begDate.Value.ToString("yyyy-MM-dd")));
            }
            if (endDate.HasValue)
            {
                sql += " AND pf_startTime=@endDate";
                pList.Add(new MySqlParameter("@endDate", endDate.Value.ToString("yyyy-MM-dd")));
            }
            var list = db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());
            return list;

        }


        /// <summary>
        /// 查询生产记录列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductList(ProductInfoModel model)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sql = @"SELECT 
                         pf_prodNo,
                         pf_ID,
                         v.pName,
                         v.PModel,
                         pf_prodModelID,
                         pp_orderCode,
                         pf_startTime,
                         pf_finishTime,
                         pf_finishStatus,
                         pf_resultIsOK,
                         pf_resultMemo
                        FROM
	                        productInfo p
                        JOIN v_productmodel v ON p.pf_prodModelID = v.ID WHERE 1=1 ";
            if (!string.IsNullOrWhiteSpace(model.pf_prodNo))
            {
                sql += " AND pf_prodNo=@pf_prodNo";
                pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            }
            if (model.pf_prodModelID.HasValue && model.pf_prodModelID != 0)
            {
                sql += " AND pf_prodModelID=@pf_prodModelID";
                pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
            }
            if (!string.IsNullOrEmpty(model.pp_orderCode))
            {
                sql += " AND pp_orderCode=@pp_orderCode";
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
            }
            var list = db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());
            return list;

        }


        #region 获取生产记录明细
        /// <summary>
        /// 根据生产ID获取信息
        /// </summary>
        /// <param name="prodID"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfoByProdID(int prodID)
        {
            var info = GetProductInfoDetail(prodID);
            return info;
        }

        /// <summary>
        /// 根据生产编号获取信息
        /// </summary>
        /// <param name="ProdNo"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfoByProdNo(string ProdNo)
        {
            var info = GetProductInfoDetail(null, ProdNo);
            return info;
        }

        private ProductInfoModel GetProductInfoDetail(int? prodID, string prodNo = "")
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var strSQL = @"SELECT *
                             FROM productInfo WHERE ";

            var mysqlParams = new List<MySqlParameter>();

            if (prodID.HasValue)
            {
                strSQL += " pf_ID=@pf_ID";
                mysqlParams.Add(new MySqlParameter("@pf_ID", prodID));
            }
            else
            {
                strSQL += " pf_prodNo=@pf_prodNo";
                mysqlParams.Add(new MySqlParameter("@pf_prodNo", prodNo));
            }

            var list = db.ExecuteList<ProductInfoModel>(strSQL, mysqlParams.ToArray());
            var info = list.Count > 0 ? list[0] : null;
            return info;

        }

        private ProductInfoModel GetTheLastProductInfo()
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var strSQL = @"SELECT * FROM productinfo ORDER BY pf_ID desc";

            var mysqlParams = new List<MySqlParameter>();

            var list = db.ExecuteList<ProductInfoModel>(strSQL, mysqlParams.ToArray());
            var info = list.Count > 0 ? list[0] : null;
            return info;

        }

        #endregion


        /// <summary>
        /// 用于总装工位装配时操作产品信息表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveProductInfo(ProductInfoModel model,int OperatorId)
        {
            var pList = new List<MySqlParameter>();
            var sql = string.Empty;
            var productInfoId = 0;
            using (var myConnection = new MySqlConnection(Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                using (var myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    // 修改
                    if (model.pf_ID > 0)
                    {
                        sql = "update productInfo set pf_finishStatus=1,pf_finishTime=@pf_finishTime where pf_ID=@pf_ID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pf_ID", model.pf_ID));
                        pList.Add(new MySqlParameter("@pf_finishTime", DateTime.Now));
                        Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray());
                    }
                    // 新增
                    else
                    {
                        sql = @"insert into productInfo(pf_prodNo,pf_prodModelID,deleteFlag,createTime,updateTime,createMan,updateMan,pf_startTime) 
                                        values(@pf_prodNo,@pf_prodModelID,0,@createTime,@updateTime,@pf_CreateMan,@pf_UpdateMan,@pf_startTime);";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
                        pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
                        pList.Add(new MySqlParameter("@createTime", DateTime.Now));
                        pList.Add(new MySqlParameter("@updateTime", DateTime.Now));
                        pList.Add(new MySqlParameter("@pf_CreateMan", OperatorId));
                        pList.Add(new MySqlParameter("@pf_UpdateMan", OperatorId));
                        pList.Add(new MySqlParameter("@pf_startTime", DateTime.Now));
                        pList.Add(new MySqlParameter("@pp_guid", null));
                        Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray());
                        productInfoId = Convert.ToInt32(GetTheLastProductInfo().pf_ID);

                    }
                    myTrans.Commit();
                    return productInfoId;
                }
            }

            //RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            //var pList = new List<MySqlParameter>();
            //int i = 0;
            //var sql = @"select * from productInfo where pf_prodNo=@pf_prodNo";
            //pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            //List<ProductInfoModel> ProductInfoList = db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());
            ////表示该产品型号是没有组装过
            //if (ProductInfoList.Count == 0)
            //{
            //    sql = @"INSERT into productInfo (pf_prodNo,pf_prodModelID,pp_orderCode,pf_startTime,pf_finishStatus,pf_remark,currGwID,
            //            deleteFlag,createTime,updateTime,createMan,pf_alias,pf_finishTime) 
            //            VALUES(@pf_prodNo,@pf_prodModelID,@pp_orderCode,@pf_startTime,@pf_finishStatus,@pf_remark,@currGwID,
            //            @deleteFlag,@createTime,@updateTime,@createMan,@pf_alias,@pf_finishTime)";
            //    pList.Clear();
            //    pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            //    pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
            //    pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
            //    pList.Add(new MySqlParameter("@pf_startTime", model.pf_startTime));
            //    pList.Add(new MySqlParameter("@pf_finishStatus", model.pf_finishStatus));
            //    pList.Add(new MySqlParameter("@pf_remark", model.pf_remark));
            //    pList.Add(new MySqlParameter("@currGwID", model.currGwID));
            //    pList.Add(new MySqlParameter("@deleteFlag", model.deleteFlag));
            //    pList.Add(new MySqlParameter("@createTime", model.createTime));
            //    pList.Add(new MySqlParameter("@updateTime", model.updateTime));
            //    pList.Add(new MySqlParameter("@createMan", model.createMan));
            //    pList.Add(new MySqlParameter("@pf_alias", model.pf_alias));
            //    pList.Add(new MySqlParameter("@pf_finishTime", model.pf_finishTime));
            //    i = db.ExecuteNonQuery(sql, pList.ToArray());
            //}
            //else
            //{
            //    sql = @"UPDATE productInfo SET
            //                                     pf_prodNo=@pf_prodNo,
            //                                     pf_prodModelID=@pf_prodModelID,
            //                                     pp_orderCode=@pp_orderCode,
            //                                     pf_finishTime=@pf_finishTime,
            //                                     pf_finishStatus=@pf_finishStatus,
            //                                     pf_resultIsOK=@pf_resultIsOK,
            //                                     pf_resultMemo=@pf_resultMemo,
            //                                     pf_remark=@pf_remark,
            //                                     currGwID=@currGwID,
            //                                     updateTime=@updateTime,
            //                                     updateMan=@updateMan
            //             WHERE pf_ID=@pf_ID";
            //    pList.Clear();
            //    pList.Add(new MySqlParameter("@pf_ID", ProductInfoList[0].pf_ID));
            //    pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            //    pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
            //    pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
            //    pList.Add(new MySqlParameter("@pf_finishTime", model.pf_finishTime));
            //    pList.Add(new MySqlParameter("@pf_finishStatus", model.pf_finishStatus));
            //    pList.Add(new MySqlParameter("@pf_resultIsOK", model.pf_resultIsOK));
            //    pList.Add(new MySqlParameter("@pf_resultMemo", model.pf_resultMemo));
            //    pList.Add(new MySqlParameter("@currGwID", model.currGwID));
            //    pList.Add(new MySqlParameter("@pf_remark", model.pf_remark));
            //    pList.Add(new MySqlParameter("@updateTime", model.updateTime));
            //    pList.Add(new MySqlParameter("@updateMan", model.updateMan));

            //    i = db.ExecuteNonQuery(sql, pList.ToArray());

            //}

            //sql = "select LAST_INSERT_ID() ";

            //return db.ExecuteScalar<int>(sql, pList.ToArray());
        }

        /// <summary>
        /// 用于计划列表提交验证
        /// </summary>
        /// <param name="pf_prodNo">产品编号</param>
        /// <param name="pp_orderCode">计划单据号</param>
        /// <param name="Message">返回消息</param>
        /// <returns>返回类型: 1:未装配  2：已装配，是否重复装配  -1：当前产品编号选择了错误的计划</returns>
        public int GetProductInfoSaveStatus(string pf_prodNo, string pp_orderCode, out string Message)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            int i = 0;
            string msg = "";
            var sql = @"select * from productInfo where pf_prodNo=@pf_prodNo";
            pList.Add(new MySqlParameter("@pf_prodNo", pf_prodNo));
            List<ProductInfoModel> ProductInfoList = db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());
            //表示该产品型号是没有绑定过计划订单号
            if (ProductInfoList.Count == 0)
            {
                i = 1;
            }
            else if (ProductInfoList.Count != 0 && !string.IsNullOrEmpty(ProductInfoList.FirstOrDefault().pp_orderCode))
            {
                i = 1;
                //判断修改的产品编号是否绑定同一计划订单号
                if (pp_orderCode != ProductInfoList.FirstOrDefault().pp_orderCode)
                {
                    //表示该产品型号想绑定另外的计划订单号上 ,返回错误码
                    i = -1;
                    msg = ProductInfoList.FirstOrDefault().pp_orderCode;
                }
                else
                {
                    //已装配过，是否继续装配
                    i = 2;
                }
            }
            Message = msg;
            return i;
        }

        /// <summary>
        /// 根据计划单号 获取当前计划下的产品数量
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductInfo(string pp_orderCode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var sql = @"select * from productInfo where pp_orderCode=@pp_orderCode";
            pList.Add(new MySqlParameter("@pp_orderCode", pp_orderCode));
            return db.ExecuteList<ProductInfoModel>(sql, pList.ToArray());
        }


        /// <summary>
        /// 添加生产记录信息
        /// </summary>
        /// <param name="model"></param>
        public void AddProductInfo(ProductInfoModel model)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var serverTime = db.GetServerTime();
            var pList = new List<MySqlParameter>();
            var sql = @"select count(1) from productInfo where pf_prodNo=@pf_prodNo";
            pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            int count = db.ExecuteScalar(sql, pList.ToArray()).ToInt();
            if (count == 0)
            {
                sql = @"INSERT into productInfo (pf_prodNo,pf_prodModelID,pp_orderCode,pf_startTime,pf_finishTime,pf_finishStatus,pf_resultIsOK,pf_resultMemo,pf_remark,
                        deleteFlag,createTime,updateTime,createMan,updateMan) 
                        VALUES(@pf_prodNo,@pf_prodModelID,@pp_orderCode,@pf_startTime,@pf_finishTime,@pf_finishStatus,@pf_resultIsOK,@pf_resultMemo,@pf_remark,
                        @deleteFlag,@createTime,@updateTime,@createMan,@updateMan)";
                pList.Clear();
                pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
                pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
                pList.Add(new MySqlParameter("@pf_startTime", model.pf_startTime));
                pList.Add(new MySqlParameter("@pf_finishTime", model.pf_finishTime));
                pList.Add(new MySqlParameter("@pf_finishStatus", model.pf_finishStatus));
                pList.Add(new MySqlParameter("@pf_resultIsOK", model.pf_resultIsOK));
                pList.Add(new MySqlParameter("@pf_resultMemo", model.pf_resultMemo));
                pList.Add(new MySqlParameter("@pf_remark", model.pf_remark));
                pList.Add(new MySqlParameter("@deleteFlag", model.deleteFlag));
                pList.Add(new MySqlParameter("@createTime", model.createTime));
                pList.Add(new MySqlParameter("@updateTime", model.updateTime));
                pList.Add(new MySqlParameter("@createMan", model.createMan));
                pList.Add(new MySqlParameter("@updateMan", model.updateMan));

                db.ExecuteNonQuery(sql, pList.ToArray());
            }
        }


        /// <summary>
        /// 添加生产记录信息
        /// </summary>
        /// <param name="model"></param>
        public void AddProductInfo(ProductInfoModel model, MySqlTransaction myTrans, out int identity)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var serverTime = db.GetServerTime();
            var pList = new List<MySqlParameter>();
            var sql = @"select count(1) from productInfo where pf_prodNo=@pf_prodNo";
            pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
            int count = RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()).ToInt();
            if (count == 0)
            {
                sql = @"INSERT into productInfo (pf_prodNo,pf_prodModelID,pp_orderCode,pf_startTime,pf_finishTime,pf_finishStatus,pf_resultIsOK,pf_resultMemo,pf_remark,
                        deleteFlag,createTime,updateTime,createMan,updateMan) 
                        VALUES(@pf_prodNo,@pf_prodModelID,@pp_orderCode,@pf_startTime,@pf_finishTime,@pf_finishStatus,@pf_resultIsOK,@pf_resultMemo,@pf_remark,
                        @deleteFlag,@createTime,@updateTime,@createMan,@updateMan)";
                pList.Clear();
                pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
                pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
                pList.Add(new MySqlParameter("@pf_startTime", model.pf_startTime));
                pList.Add(new MySqlParameter("@pf_finishTime", model.pf_finishTime));
                pList.Add(new MySqlParameter("@pf_finishStatus", model.pf_finishStatus));
                pList.Add(new MySqlParameter("@pf_resultIsOK", model.pf_resultIsOK));
                pList.Add(new MySqlParameter("@pf_resultMemo", model.pf_resultMemo));
                pList.Add(new MySqlParameter("@pf_remark", model.pf_remark));
                pList.Add(new MySqlParameter("@deleteFlag", model.deleteFlag));
                pList.Add(new MySqlParameter("@createTime", model.createTime));
                pList.Add(new MySqlParameter("@updateTime", model.updateTime));
                pList.Add(new MySqlParameter("@createMan", model.createMan));
                pList.Add(new MySqlParameter("@updateMan", model.updateMan));

                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
            }
            //获取自增长ID 
            sql = "select @@identity";
            int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out identity);
        }


        /// <summary>
        /// 修改生产记录信息
        /// </summary>
        /// <param name="model"></param>
        public void UpdateProductInfo(ProductInfoModel model)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var serverTime = db.GetServerTime();
            var pList = new List<MySqlParameter>();
            var sql = @"select count(1) from productInfo where pf_ID=@pf_ID";
            pList.Add(new MySqlParameter("@pf_ID", model.pf_ID));
            int count = db.ExecuteScalar(sql, pList.ToArray()).ToInt();
            if (count == 0)
            {
                sql = @"UPDATE productInfo SET
                                                 pf_prodNo=@pf_prodNo,
                                                 pf_prodModelID=@pf_prodModelID,
                                                 pp_orderCode=@pp_orderCode,
                                                 pf_finishTime=@pf_finishTime,
                                                 pf_finishStatus=@pf_finishStatus,
                                                 pf_resultIsOK=@pf_resultIsOK,
                                                 pf_resultMemo=@pf_resultMemo,
                                                 pf_remark=@pf_remark,
                                                 updateTime=@updateTime,
                                                 updateMan=@updateMan
                         WHERE pf_ID=@pf_ID";

                //sql = @"UPDATE productInfo SET
                //                                 pf_prodNo=@pf_prodNo,
                //                                 pf_prodModelID=@pf_prodModelID,
                //                                 pp_orderCode=@pp_orderCode,
                //                                 pf_startTime=@pf_startTime,
                //                                 pf_finishTime=@pf_finishTime,
                //                                 pf_finishStatus=@pf_finishStatus,
                //                                 pf_resultIsOK=@pf_resultIsOK,
                //                                 pf_resultMemo=@pf_resultMemo,
                //                                 pf_remark=@pf_remark,
                //                                 updateTime=@updateTime,
                //                                 updateMan=@updateMan
                //         WHERE pf_ID=@pf_ID";

                pList.Add(new MySqlParameter("@pf_ID", model.pf_ID));
                pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo));
                pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
                pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode));
                pList.Add(new MySqlParameter("@pf_finishTime", model.pf_finishTime));
                pList.Add(new MySqlParameter("@pf_finishStatus", model.pf_finishStatus));
                pList.Add(new MySqlParameter("@pf_resultIsOK", model.pf_resultIsOK));
                pList.Add(new MySqlParameter("@pf_resultMemo", model.pf_resultMemo));
                pList.Add(new MySqlParameter("@pf_remark", model.pf_remark));
                pList.Add(new MySqlParameter("@updateTime", model.updateTime));
                pList.Add(new MySqlParameter("@updateMan", model.updateMan));

                db.ExecuteNonQuery(sql, pList.ToArray());
            }
        }

        /// <summary>
        /// 删除生产记录信息
        /// </summary>
        /// <param name="prodID"></param>
        public void DeleteProductInfo(int prodID)
        {
            var db = new RW.PMS.Common.MySqlHelper();
            var serverTime = db.GetServerTime();
            var pList = new List<MySqlParameter>();
            var sql = @"DELETE FROM productInfo where pf_ID=@pf_ID ";
            pList.Add(new MySqlParameter("@pf_ID", prodID));
            db.ExecuteNonQuery(sql, pList.ToArray()).ToInt();
        }

        #region 产品装配完成情况 LHR

        /// <summary>
        /// 查询 产品装配完成情况 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<AssemblyProdModel> AssemblyProdForPage(AssemblyProdModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.pp_orderCode))//计划订单号
                {
                    para += " and pf.pp_orderCode like concat('%',@pp_orderCode,'%') ";
                    pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
                }

                if (!string.IsNullOrEmpty(model.Prod_no))//产品编号
                {
                    para += " and pf.pf_prodNo like concat('%',@pf_prodNo,'%') ";
                    pList.Add(new MySqlParameter("@pf_prodNo", model.Prod_no.Trim()));
                }

                if (model.ProdModel_id.HasValue && model.ProdModel_id != 0)//产品ID
                {
                    para += " and pf.pf_prodModelID=@pf_prodModelID";
                    pList.Add(new MySqlParameter("@pf_prodModelID", model.ProdModel_id));
                }

                if (!string.IsNullOrEmpty(model.starttime))//开始时间
                {
                    var starttime = DateTime.Parse(model.starttime);
                    para += " and pf.pf_startTime>=@pf_startTime";
                    pList.Add(new MySqlParameter("@fp_startTime", starttime));

                }
                if (!string.IsNullOrEmpty(model.endtime))//完成时间
                {
                    var endtime = DateTime.Parse(model.endtime).AddDays(+1).AddSeconds(-1);
                    //var endtime = DateTime.Parse(model.endtime);
                    para += " and pf.pf_finishTime < @pf_finishTime";
                    pList.Add(new MySqlParameter("@pf_finishTime", endtime));
                }
            }
            string sql = @"select count(*) from productInfo pf 
                        left join v_productmodel vpm on pf.pf_prodModelID=vpm.ID where 1=1" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT
                        pf.pf_ID as Prod_id,
	                    pf.pf_prodNo Prod_no,
	                    pf.pf_prodModelID ProdModel_id,
	                    CONCAT_WS('-', vpm.Pmodel, vpm.DrawingNo) ProdModel_name,
	                    pf.pf_startTime Fp_startTime,
	                    pf.pf_finishTime Fp_finishTime,
	                    pf.pf_finishStatus Fp_finishStatus,
	                    pf.pf_resultMemo Fp_resultMemo,
						pf.pp_orderCode
                    FROM
	                    productInfo pf
                    LEFT JOIN v_productmodel vpm ON pf.pf_prodModelID = vpm.ID
                    WHERE
	                    1 = 1 " + para;
            sql += " order by pf.pf_startTime desc limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<AssemblyProdModel> list = db.ExecuteList<AssemblyProdModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 获取(产品表)表实体类 下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BaseProductModel> GetBaseProduct()
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = @"SELECT * from base_product ORDER BY ID";
            List<BaseProductModel> query = db.ExecuteList<BaseProductModel>(sql, plist.ToArray());
            //using (var context = new RWPMS_DBDataContext())
            //{
            //    var query = QueryBaseProductInfo(context);
            //    query = query.Where(x => true);
            //    var result = query.ToList();
            //    return result;
            //}
            return query;
        }

        /// <summary>
        /// 获取(产品型号)表实体类 下拉
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetBaseProductModel()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "SELECT * from base_productModel ORDER BY ID";

            List<BaseProductModelModel> BaseProductModelModellist = db.ExecuteList<BaseProductModelModel>(sql, pList.ToArray());
            return BaseProductModelModellist;
        }

        //private IQueryable<BaseProductModelModel> QueryBaseProductModelInfo(RWPMS_DBDataContext context)
        //{

        //    var query = context.base_productModel.
        //        OrderBy(order => order.ID).
        //        Select(entity => new BaseProductModelModel
        //        {
        //            ID = entity.ID,
        //            PID = entity.PID,
        //            Pmodel = entity.Pmodel,
        //            beatMinite = entity.beatMinite,
        //            Pstatus = entity.Pstatus,
        //            //status = entity.Pstatus == 0 ? "启用" : "禁用",
        //            remark = entity.remark
        //        });
        //    return query;
        //}

        //private BaseProductModel QueryBaseProductInfo(RWPMS_DBDataContext context)
        //{
        //    RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
        //    List<MySqlParameter> plist = new List<MySqlParameter>();
        //    string sql = @"SELECT * from base_product ORDER BY ID";
        //    List<BaseProductModel> query = db.ExecuteList<BaseProductModel>(sql, plist.ToArray());
        //    //var query = context.base_product.
        //    //    OrderBy(order => order.ID).
        //    //    Select(entity => new BaseProductModel
        //    //    {
        //    //        ID = entity.ID,
        //    //        Pname = entity.Pname,
        //    //        Pstatus = entity.Pstatus,
        //    //        //status = entity.Pstatus == 0 ? "启用" : "禁用",
        //    //        remark = entity.remark
        //    //    });

        //    return query[0];
        //}

        /// <summary>
        /// 获取产品下拉框
        /// </summary>
        /// <returns></returns>
        //public List<BaseProductModel> GetBaseProductALL()
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var query = context.base_product.Where(_ => _.Pstatus != 1).Select(_ => new BaseProductModel
        //        {
        //            ID = _.ID,
        //            Pname = _.Pname,
        //            Pstatus = _.Pstatus,
        //            //status = _.Pstatus == 0 ? "启用" : "禁用",
        //            remark = _.remark
        //        }).ToList();
        //        return query;
        //    }
        //}

        #endregion

        #region 工位装配完成情况 LHR

        public List<AssemblyGwModel> AssemblyGwForPage(AssemblyGwModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {

                if (!string.IsNullOrEmpty(model.pp_orderCode))//计划订单号
                {
                    para += " and pf.pp_orderCode like concat('%',@pp_orderCode,'%') ";
                    pList.Add(new MySqlParameter("@pp_orderCode", model.pp_orderCode.Trim()));
                }
                if (!string.IsNullOrEmpty(model.prod_no))//产品编号
                {
                    para += " and pf.pf_prodNo like concat('%',@pf_prodNo,'%') ";
                    pList.Add(new MySqlParameter("@pf_prodNo", model.prod_no.Trim()));
                }
                if (model.ProdModel_id.HasValue && model.ProdModel_id != 0)//型号
                {
                    para += " and pf.pf_prodModelID=@pf_prodModelID";
                    pList.Add(new MySqlParameter("@pf_prodModelID", model.ProdModel_id));
                }
                if (model.agw_gwID.HasValue && model.agw_gwID != 0)//工位 
                {
                    para += " and agw.agw_gwID=@agw_gwID";
                    pList.Add(new MySqlParameter("@agw_gwID", model.agw_gwID));
                }
                if (!string.IsNullOrEmpty(model.starttime))//开始时间 
                {
                    var starttime = DateTime.Parse(model.starttime);
                    para += " and agw.agw_starttime>=@agw_starttime";
                    pList.Add(new MySqlParameter("@agw_starttime", starttime));
                }
                if (!string.IsNullOrEmpty(model.starttime1))//开始截止时间1
                {
                    var starttime1 = DateTime.Parse(model.starttime1).AddDays(+1).AddSeconds(-1);
                    para += " and agw.agw_starttime<=@agw_startEndtime";
                    pList.Add(new MySqlParameter("@agw_startEndtime", starttime1));
                }
                if (!string.IsNullOrEmpty(model.endtime))//完成时间
                {
                    var endtime = DateTime.Parse(model.endtime);
                    para += " and agw.agw_finishtime>=@agw_finishtime";
                    pList.Add(new MySqlParameter("@agw_finishtime", endtime));
                }
                if (!string.IsNullOrEmpty(model.endtime1))//完成截止时间 
                {
                    var endtime1 = DateTime.Parse(model.endtime1).AddDays(+1).AddSeconds(-1);
                    para += " and agw.agw_finishtime<=@agw_finishEndtime ";
                    pList.Add(new MySqlParameter("@agw_finishEndtime", endtime1));
                }
            }

            string sql = @"SELECT  count(*) 
                                   FROM assembly_gw agw
                                   LEFT JOIN productInfo pf ON agw.agw_QRcode = pf.pf_prodNo
                                   LEFT JOIN base_productmodel pm on pm.ID = pf.pf_prodModelID
                                   LEFT JOIN assembly_main am on am.am_QRcode = pf.pf_prodNo
                                   LEFT JOIN gw_prod_def gpf on gpf.prodModelID = pm.ID and gpf.gwID = agw.agw_gwID
                                   LEFT JOIN base_program bp on gpf.progID = bp.ID
                                   WHERE
	                               pf.pf_prodModelID > 0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT
	                    pf.pf_prodNo prod_no,
	                    pf.pf_prodModelID ProdModel_id,
	                    pm.Pmodel ProdModel_name,
	                    agw.agw_QRcode,
	                    agw.agw_gwID,
	                    GetGwNameByID (agw.agw_gwID) agw_gwName,
	                    agw.agw_starttime,
	                    agw.agw_finishtime,
	                    agw.agw_operID,
	                    GetEmpNameByuID (agw.agw_operID) agw_oper,
	                    agw.agw_resultMemo,
	                    agw.agw_finishStatus,
	                    agw.agw_resultMemo,
						pf.pp_orderCode,
                        am.am_guid,
                        bp.fileNo as duration
                    FROM assembly_gw agw
                    LEFT JOIN productInfo pf ON agw.agw_QRcode = pf.pf_prodNo
                    LEFT JOIN base_productmodel pm on pm.ID = pf.pf_prodModelID
                    LEFT JOIN assembly_main am on am.am_QRcode = pf.pf_prodNo
                    LEFT JOIN gw_prod_def gpf on gpf.prodModelID =  pm.ID and gpf.gwID = agw.agw_gwID
                    LEFT JOIN base_program bp on gpf.progID = bp.ID
                    WHERE
	                     pf.pf_prodModelID > 0 " + para;

            sql += " order by agw.agw_starttime desc limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<AssemblyGwModel> list = db.ExecuteList<AssemblyGwModel>(sql, pList.ToArray());

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];

                    sql = "select * from assembly_mainRecord where am_guid=@am_guid";

                    pList.Clear();
                    pList.Add(new MySqlParameter("@am_guid", item.am_guid));

                    item.Details = db.ExecuteList<AssemblyMainRecordModel>(sql, pList.ToArray());
                }
            }

            return list;

        }

        public List<AssemblyInfoModel> GetAssemblyGwList(DateTime? startDate, DateTime? endDate, string prodCode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";

            if (startDate.HasValue)
            {
                para += " and agw.agw_starttime>=@agw_starttime ";
                pList.Add(new MySqlParameter("@agw_starttime", startDate));
            }
            if (endDate.HasValue)
            {
                para += " and agw.agw_finishtime<=@agw_finishtime ";
                pList.Add(new MySqlParameter("@agw_finishtime", endDate));
            }
            if (!string.IsNullOrEmpty(prodCode))
            {
                para += " and agw.pf_prodNo like concat('%',@pf_prodNo,'%') ";
                pList.Add(new MySqlParameter("@pf_prodNo", prodCode));
            }

            string sql = @"SELECT
	                    pf.pf_prodNo ProductNumber,
	                    pm.Pmodel ProductTypeName,
	                    gw.gwname WorkingPositionName,
                        su.empName OperatorName,
	                    agw.agw_starttime StartTime,
	                    agw.agw_finishtime EndTime,
	                    agw.agw_finishStatus CompletionStatus
                    FROM assembly_gw agw 
                    LEFT JOIN productInfo pf ON agw.agw_QRcode = pf.pf_prodNo
                    LEFT JOIN base_productmodel pm on pm.ID = pf.pf_prodModelID
                    LEFT JOIN assembly_main am on am.am_QRcode = pf.pf_prodNo
                    LEFT JOIN base_gongwei gw on agw.agw_gwID = gw.ID 
                    LEFT JOIN sys_user su on agw.agw_operID = su.userID
                    WHERE pf.pf_prodModelID > 0 " + para;

            sql += " order by agw.agw_starttime desc ";
            List<AssemblyInfoModel> list = db.ExecuteList<AssemblyInfoModel>(sql, pList.ToArray());
         
            //if (list.Count > 0)
            //{
            //    for (int i = 0; i < list.Count; i++)
            //    {
            //        var item = list[i];

            //        sql = "select * from assembly_mainRecord where am_guid=@am_guid";

            //        pList.Clear();
            //        pList.Add(new MySqlParameter("@am_guid", item.am_guid));

            //        item.Details = db.ExecuteList<AssemblyMainRecordModel>(sql, pList.ToArray());
            //    }
            //}

            return list;

        }
        #endregion

        #region 装配明细情况 LHR

        public List<AssemblyFllowInfoModel> AssemblyFllowInfoForPage(AssemblyFllowInfoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.pf_prodNo))//产品编号
                {
                    para += " and pf.pf_prodNo like concat('%',@pf_prodNo,'%') ";
                    pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo.Trim()));
                }
                if (model.pf_prodModelID.HasValue && model.pf_prodModelID != 0)//型号
                {
                    para += " and pf.pf_prodModelID=@pf_prodModelID";
                    pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
                }
                if (model.agw_gwID.HasValue && model.agw_gwID != 0)//工位
                {
                    para += " and agw.agw_gwID=@agw_gwID";
                    pList.Add(new MySqlParameter("@agw_gwID", model.agw_gwID));
                }
                if (!string.IsNullOrEmpty(model.starttime))//开始时间
                {
                    var starttime = DateTime.Parse(model.starttime);
                    para += " and agw.agw_starttime>=@agw_starttime";
                    pList.Add(new MySqlParameter("@agw_starttime", starttime));
                }
                if (!string.IsNullOrEmpty(model.endtime))//开始截止时间1
                {
                    var endtime = DateTime.Parse(model.endtime).AddDays(+1).AddSeconds(-1);
                    para += " and agw.agw_starttime<=@agw_startEndtime";
                    pList.Add(new MySqlParameter("@agw_startEndtime", endtime));
                }
            }

            string sql = @"SELECT
	                        pf.pf_prodNo,
	                        pf.pf_prodModelID,
	                        pm.Pmodel prodModeName,
	                        agw.agw_QRcode,
	                        agw.agw_gwID,
	                        GetGwNameByID (agw.agw_gwID) agw_gwName,
	                        agw.agw_starttime,
	                        agw.agw_finishtime,
	                        agw.agw_operID,
	                        GetEmpNameByuID (agw.agw_operID) agw_oper,
	                        agw.agw_resultMemo,
	                        agw.agw_finishStatus,
	                        agx_gxID,
	                        agx_gxName,
	                        agx_starttime,
	                        agx_finishtime,
	                        agx_finishStatus,
	                        agx_resultMemo,
	                        agb_gbID,
	                        agb_gbName,
	                        agb_starttime,
	                        agb_finishtime,
	                        agb_finishStatus,
	                        agb_resultMemo,
	                        agj_gjID,
	                        agj_gjName,
	                        agj_wlID,
	                        agj_wlName,
	                        agj_gjwlCode,
	                        agj_starttime,
	                        agj_finishtime,
	                        agj_finishStatus,
	                        agj_resultMemo,
	                        agj_value,
	                        agj_value2
                        FROM
	                        assembly_gw agw
                        LEFT JOIN productInfo pf ON agw.agw_QRcode = pf.pf_prodNo
                        LEFT JOIN assembly_gx agx ON agw.agw_guid = agx.agw_guid
                        LEFT JOIN assembly_gb agb ON agx.agx_guid = agb.agx_guid
                        LEFT JOIN assembly_gj agj ON agb.agb_guid = agj.agb_guid
                        LEFT JOIN base_productmodel pm on pm.ID = pf.pf_prodModelID
                        WHERE
	                        pf.pf_prodModelID > 0
                         " + para + " order by agx_starttime";

            List<AssemblyFllowInfoModel> list = db.ExecuteList<AssemblyFllowInfoModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 装配明细情况查询 分页
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<AssemblyFllowInfoModel> AssemblyFllowInfoForPage(AssemblyFllowInfoModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.pf_prodNo))//产品编号
                {
                    para += " and pf.pf_prodNo like concat('%',@pf_prodNo,'%') ";
                    pList.Add(new MySqlParameter("@pf_prodNo", model.pf_prodNo.Trim()));
                }
                if (model.pf_prodModelID.HasValue && model.pf_prodModelID != 0)//型号
                {
                    para += " and pf.pf_prodModelID=@pf_prodModelID";
                    pList.Add(new MySqlParameter("@pf_prodModelID", model.pf_prodModelID));
                }
                if (model.agw_gwID.HasValue && model.agw_gwID != 0)//工位
                {
                    para += " and agw.agw_gwID=@agw_gwID";
                    pList.Add(new MySqlParameter("@agw_gwID", model.agw_gwID));
                }
                if (!string.IsNullOrEmpty(model.starttime))//开始时间
                {
                    var starttime = DateTime.Parse(model.starttime);
                    para += " and agw.agw_starttime>=@agw_starttime";
                    pList.Add(new MySqlParameter("@agw_starttime", starttime));
                }
                if (!string.IsNullOrEmpty(model.endtime))//开始截止时间1
                {
                    var endtime = DateTime.Parse(model.endtime).AddDays(+1).AddSeconds(-1);
                    para += " and agw.agw_starttime<=@agw_startEndtime";
                    pList.Add(new MySqlParameter("@agw_startEndtime", endtime));
                }
            }


            string sql = @"SELECT count(*) FROM assembly_gw agw
                           LEFT JOIN productInfo pf ON agw.agw_QRcode = pf.pf_prodNo
                        LEFT JOIN assembly_gx agx ON agw.agw_guid = agx.agw_guid
                        LEFT JOIN assembly_gb agb ON agx.agx_guid = agb.agx_guid
                        LEFT JOIN assembly_gj agj ON agb.agb_guid = agj.agb_guid
                        LEFT JOIN base_productmodel pm on pm.ID = pf.pf_prodModelID
                           WHERE 1 = 1" + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT
	                        pf.pf_prodNo,
	                        pf.pf_prodModelID,
	                        pm.Pmodel prodModeName,
	                        agw.agw_QRcode,
	                        agw.agw_gwID,
	                        GetGwNameByID (agw.agw_gwID) agw_gwName,
	                        agw.agw_starttime,
	                        agw.agw_finishtime,
	                        agw.agw_operID,
	                        GetEmpNameByuID (agw.agw_operID) agw_oper,
	                        agw.agw_resultMemo,
	                        agw.agw_finishStatus,
	                        agx_gxID,
	                        agx_gxName,
	                        agx_starttime,
	                        agx_finishtime,
	                        agx_finishStatus,
	                        agx_resultMemo,
	                        agb_gbID,
	                        agb_gbName,
	                        agb_starttime,
	                        agb_finishtime,
	                        agb_finishStatus,
	                        agb_resultMemo,
	                        agj_gjID,
	                        agj_gjName,
	                        agj_wlID,
	                        agj_wlName,
	                        agj_gjwlCode,
	                        agj_starttime,
	                        agj_finishtime,
	                        agj_finishStatus,
	                        agj_resultMemo,
	                        agj_value,
	                        agj_value2
                        FROM
	                        assembly_gw agw
                        LEFT JOIN productInfo pf ON agw.agw_QRcode = pf.pf_prodNo
                        LEFT JOIN assembly_gx agx ON agw.agw_guid = agx.agw_guid
                        LEFT JOIN assembly_gb agb ON agx.agx_guid = agb.agx_guid
                        LEFT JOIN assembly_gj agj ON agb.agb_guid = agj.agb_guid
                        LEFT JOIN base_productmodel pm on pm.ID = pf.pf_prodModelID
                        WHERE
	                       pf.pf_prodModelID > 0
                         " + para;
            sql += " order by agw.agw_starttime desc limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<AssemblyFllowInfoModel> list = db.ExecuteList<AssemblyFllowInfoModel>(sql, pList.ToArray());
            return list;
        }


        #endregion

    }
}
