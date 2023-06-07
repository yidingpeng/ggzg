using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.IDAL;
using RW.PMS.Model;
using MySql.Data.MySqlClient;

namespace RW.PMS.DAL
{
    internal class DAL_ValueInfo : IDAL_ValueInfo
    {
        #region 查询

        /// <summary>
        /// 根据工步配置ID获取配置检测项标准范信息列表
        /// </summary>
        /// <param name="gjID"></param>
        /// <returns></returns>
        public List<ValueInfo> GetValueInfoList(int gjID)
        {
            var query = QueryValueInfo();

            var result = query.Where(q => q.ProgGjInfoID == gjID).ToList();

            return result;
        }

        /// <summary>
        /// 根据工步配置ID获取配置检测项标准范信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ValueInfo GetValueInfoDetail(int id)
        {
            var query = QueryValueInfo();

            var detail = query.FirstOrDefault(q => q.ID == id);

            return detail;
        }


        private IQueryable<ValueInfo> QueryValueInfo()
        {
            //MySql
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select 
                                ID,
                                progGjInfoID as ProgGjInfoID,
                                valueTypeID as ValueTypeID,
                                EqualTypeID,
                                GetbdNameBybdID (valueTypeID) AS ValueTypeName,
                                GetbdNameBybdID (EqualTypeID) AS EqualTypeName,
                                standardValue as StandardValue,
                                minValue as MinValue, 
                                `maxValue` as `MaxValue`,
                                pixelPoint as PixelPoint,
                                pVInfoStatus as PVInfoStatus,
                                remark as Remark,
                                IsWriteVal
                                from program_valueinfo ORDER BY ID ;";

            IQueryable<ValueInfo> ValueInfo = db.ExecuteList<ValueInfo>(sql, pList.ToArray()).AsQueryable();

            return ValueInfo;
        }

        #endregion

        #region 添加
        public void AddValueInfo(ValueInfo valueInfo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"insert into program_valueinfo
                            (progGjInfoID,
                            valueTypeID,
                            EqualTypeID,
                            standardValue,
                            minValue,
                            `maxValue`,
                            pVInfoStatus,
                            remark,
                            pixelPoint,
                            IsWriteVal)
                            values(@progGjInfoID,@valueTypeID,@EqualTypeID,@standardValue,@minValue,@maxValue,@pVInfoStatus,@remark,@pixelPoint,@IsWriteVal)";

            pList.Add(new MySqlParameter("@progGjInfoID", valueInfo.ProgGjInfoID));
            pList.Add(new MySqlParameter("@valueTypeID", valueInfo.ValueTypeID));
            pList.Add(new MySqlParameter("@EqualTypeID", valueInfo.EqualTypeID));
            pList.Add(new MySqlParameter("@standardValue", valueInfo.StandardValue));
            pList.Add(new MySqlParameter("@minValue", valueInfo.MinValue));
            pList.Add(new MySqlParameter("@maxValue", valueInfo.MaxValue));
            pList.Add(new MySqlParameter("@pVInfoStatus", valueInfo.PVInfoStatus));
            pList.Add(new MySqlParameter("@remark", valueInfo.Remark));
            pList.Add(new MySqlParameter("@pixelPoint", valueInfo.PixelPoint));
            pList.Add(new MySqlParameter("@IsWriteVal", valueInfo.IsWriteVal));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 编辑

        /// <summary>
        /// 修改检测项标准范围
        /// </summary>
        /// <param name="valueInfo"></param>
        public void EditValueInfo(ValueInfo valueInfo)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select * from program_valueinfo where ID=" + valueInfo.ID;

            List<program_ValueInfo> list = db.ExecuteList<program_ValueInfo>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                throw new Exception(string.Format("没有找到检测项范围名称为： {0} 信息！", valueInfo.ValueTypeName));
            }

            sql = @"update program_valueinfo set standardValue=@standardValue,valueTypeID=@valueTypeID,EqualTypeID=@EqualTypeID,`maxValue`=@maxValue,`minValue`=@minValue,
                            pixelPoint=@pixelPoint,pVInfoStatus=@pVInfoStatus,remark=@remark,IsWriteVal=@IsWriteVal where ID=@ID";

            pList.Add(new MySqlParameter("@standardValue", valueInfo.StandardValue));
            pList.Add(new MySqlParameter("@valueTypeID", valueInfo.ValueTypeID));
            pList.Add(new MySqlParameter("@EqualTypeID", valueInfo.EqualTypeID));
            pList.Add(new MySqlParameter("@maxValue", valueInfo.MaxValue));
            pList.Add(new MySqlParameter("@minValue", valueInfo.MinValue));
            pList.Add(new MySqlParameter("@pixelPoint", valueInfo.PixelPoint));
            pList.Add(new MySqlParameter("@pVInfoStatus", valueInfo.PVInfoStatus));
            pList.Add(new MySqlParameter("@remark", valueInfo.Remark));
            pList.Add(new MySqlParameter("@IsWriteVal", valueInfo.IsWriteVal));
            pList.Add(new MySqlParameter("@ID", valueInfo.ID));

            db.ExecuteNonQuery(sql, pList.ToArray());

        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除检测项标准范围
        /// </summary>
        /// <param name="id"></param>
        public void DeleteValueInfo(int id)
        {
            DelValueInfo(id);
            
        }

        public program_ValueInfo GetValueInfoData(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID from program_valueinfo where ID=" + id;

            List<program_ValueInfo> list = db.ExecuteList<program_ValueInfo>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                program_ValueInfo valueInfo = null;
                return valueInfo;
            }

            return list[0];
        }
        /// <summary>
        /// 删除多个检测项标准范围
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="context"></param>
        public void DeleteValueInfo(int[] ids)
        {
            foreach (var ID in ids)
            {
                program_ValueInfo item = GetValueInfoData(ID);
                if (item != null)
                {
                    DelValueInfo(item.ID);
                }
            }
        }

        private void DelValueInfo(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select ID from program_valueinfo where ID=" + id;

            List<program_ValueInfo> list = db.ExecuteList<program_ValueInfo>(sql, pList.ToArray());

            if (list.Count == 0)
            {
                throw new Exception(string.Format("没有找到检测项范围ID为： {0} 信息！", id));
            }

            //删除检测项范围信息
            string delSql = "delete from program_valueinfo where ID=" + id;

            db.ExecuteNonQuery(delSql, pList.ToArray());
            
        }

        #endregion
    }
}
