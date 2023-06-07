using MySql.Data.MySqlClient;
using RW.PMS.IDAL.Programs;
using RW.PMS.Model.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.DAL.Programs
{
    public class DAL_PointInfo: IDAL_PointInfo
    {
        #region 查询
        public List<PointInfoModel> GetPointInfo(string explain,int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT * FROM sys_pointInfo WHERE 1=1";
            if (!string.IsNullOrEmpty(explain))
            {
                sql += " and ExplainInfo like'%"+explain+"%'";
            }
            if (id!=0)
            {
                sql += " and ID=@ID";
                pList.Add(new MySqlParameter("@ID", id));
            }
            sql += " ORDER BY ID DESC";
            List<PointInfoModel> query = db.ExecuteList<PointInfoModel>(sql, pList.ToArray());
            return query;
        }


        public PointInfoModel GetPointInfoByTag(string tagname)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT * FROM sys_pointInfo WHERE 1=1";
            if (!string.IsNullOrEmpty(tagname))
            {
                sql += " and TagName='" + tagname+"'";
            }
            sql += " ORDER BY ID DESC";
            List<PointInfoModel> query = db.ExecuteList<PointInfoModel>(sql, pList.ToArray());
            return query.Count > 0 ? query[0] : null;
        }
        #endregion

        #region 添加、修改
        public int EditPointInfo(PointInfoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";
            if (model.ID!=0)
            {
                var result = GetPointInfoByTag(model.TagName);
                if (result != null)
                {
                    if (result.ID != model.ID)
                        return -1;
                }
                sql = @"UPDATE sys_pointInfo SET TagName=@TagName,Address=@Address,ExplainInfo=@Explain WHERE ID=@ID";
                pList.Add(new MySqlParameter("@ID", model.ID));
            }
            else
            {
                var result = GetPointInfoByTag(model.TagName);
                if (result != null)
                {
                    return -1;
                }
                sql = @"INSERT INTO sys_pointInfo(TagName,Address,ExplainInfo) VALUES(@TagName,@Address,@Explain)";
            }
            pList.Add(new MySqlParameter("@TagName", model.TagName));
            pList.Add(new MySqlParameter("@Address", model.Address));
            pList.Add(new MySqlParameter("@Explain", model.ExplainInfo));
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }
        #endregion

        #region 删除
        public int DeletePointInfo(int ID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "DELETE FROM sys_pointInfo WHERE ID=" + ID;
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion
    }
}
