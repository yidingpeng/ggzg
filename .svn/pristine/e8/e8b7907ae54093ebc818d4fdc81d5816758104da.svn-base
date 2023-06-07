using MySql.Data.MySqlClient;
using RW.PMS.IDAL;
using RW.PMS.Model.Barcode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.DAL
{
    internal class DAL_Barcode : IDAL_Barcode
    {
        /// <summary>
        /// 添加条码信息
        /// </summary>
        /// <param name="main"></param>
        public void AddBarcode(BarcodeMain main)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                var myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    var pList = new List<MySqlParameter>();
                    main.GUID = Guid.NewGuid().ToString("D");
                    pList.Add(new MySqlParameter("@GUID", main.GUID));
                    pList.Add(new MySqlParameter("@BType", main.BType));
                    pList.Add(new MySqlParameter("@Year", main.Year));
                    pList.Add(new MySqlParameter("@Month", main.Month));
                    pList.Add(new MySqlParameter("@PModelNo", main.PModelNo));
                    pList.Add(new MySqlParameter("@BeginNo", main.BeginNo));
                    pList.Add(new MySqlParameter("@EndNo", main.EndNo));
                    pList.Add(new MySqlParameter("@TotalNo", main.TotalNo));
                    pList.Add(new MySqlParameter("@CDateTime", DateTime.Now));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, "INSERT INTO `barcode_main` VALUES (@GUID,@BType,@Year, @Month, @PModelNo, @BeginNo, @EndNo, @TotalNo, @CDateTime);", pList.ToArray());
                    if (main.Records != null)
                    {
                        foreach (var item in main.Records)
                        {
                            pList.Clear();
                            item.GUID = Guid.NewGuid().ToString("D");
                            pList.Add(new MySqlParameter("@GUID", item.GUID));
                            pList.Add(new MySqlParameter("@MainID", main.GUID));
                            pList.Add(new MySqlParameter("@BarcodeVal", item.BarcodeVal));
                            pList.Add(new MySqlParameter("@CDateTime", DateTime.Now));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, "INSERT INTO `barcode_record` VALUES (@GUID,@MainID, @BarcodeVal, @CDateTime);", pList.ToArray());
                        }
                    }
                    myTrans.Commit();
                }
                catch (Exception ex)
                {
                    myTrans.Rollback();
                    throw ex;
                }
                finally
                {
                    myTrans.Dispose();
                }

            }
        }

        /// <summary>
        /// 查询条码信息
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="modelCode">模组编号</param>
        /// <param name="batteriesCode">电芯编号</param>
        /// <returns></returns>
        public List<BarcodeMain> QueryBarcode(string type,string year, string month, string pModelNo)
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var sqlStr = "select * from barcode_main  where 1=1 ";
            if (!string.IsNullOrEmpty(year))
            {
                sqlStr += $" AND `Year`='{year}' ";
            }
            if (!string.IsNullOrEmpty(month))
            {
                sqlStr += $" AND `Month`='{month}' ";
            }
            if (!string.IsNullOrEmpty(pModelNo))
            {
                sqlStr += $" AND PModelNo='{pModelNo}' ";
            }
            if (!string.IsNullOrEmpty(type))
            {
                sqlStr += $" AND BType='{type}' ";
            }
            sqlStr += $" ORDER BY CDateTime ";

            var list = db.ExecuteList<BarcodeMain>(sqlStr);

            return list;
        }

        /// <summary>
        /// 获取条形码主表明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BarcodeMain GetDetail(string id)
        {
            var db = new RW.PMS.Common.MySqlHelper();

            var sqlStr = $"select * from barcode_main  where GUID='{id}'";

            var list = db.ExecuteList<BarcodeMain>(sqlStr);
            var result = default(BarcodeMain);
            if (list != null && list.Count > 0)
            {
                result = list[0];
            }
            return result;
        }

        /// <summary>
        /// 获取最大的模组流水号
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="pModelNo"></param>
        /// <returns></returns>
        public int GetModelNoMax(string type,string year, string month, string pModelNo)
        {
            var sqlstr = $"SELECT MAX(EndNo) FROM barcode_main  WHERE `Year`='{year}' AND `Month`='{month}'  AND PModelNo='{pModelNo}' AND BType='{type}'";
            var db = new RW.PMS.Common.MySqlHelper();
            var val = db.ExecuteScalar<string>(sqlstr);

            var ret = 0;
            int.TryParse(val, out ret);
            return ret + 1;

        }
    }
}
