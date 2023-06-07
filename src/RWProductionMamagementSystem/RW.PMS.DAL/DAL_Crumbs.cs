using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using System.Collections.Generic;
using System.Linq;

namespace RW.PMS.DAL
{
    internal class DAL_Crumbs : IDAL_Crumbs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public List<CrumbsModel> GetCrumbs(string Path)
        {
            List<CrumbsModel> list = new List<CrumbsModel>();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_menu where url='" + Path + "'";
            List<CrumbsModel> tempList = db.ExecuteList<CrumbsModel>(sql, pList.ToArray());
            if (tempList.Count == 0) return null;
            list.Add(new CrumbsModel(tempList[0].menuName, string.Empty, 0, tempList[0].flag));
            if (tempList[0].parentID != 0)
            {
                sql = "select * from sys_menu where menuID=" + tempList[0].parentID;
                tempList = db.ExecuteList<CrumbsModel>(sql, pList.ToArray());
                if (tempList.Count == 0) return null;
                CrumbsModel parent = tempList[0];
                if (parent.parentID != 0)
                {
                    list.Add(new CrumbsModel(parent.menuName, parent.Url, 0, parent.flag));
                    sql = "select * from sys_menu where menuID=" + parent.parentID;
                    var query = db.ExecuteList<CrumbsModel>(sql, pList.ToArray());
                    if (query.Count == 0)
                        return null;
                    list.Add(new CrumbsModel(query[0].menuName, string.Empty, 0, query[0].flag));
                }
                else
                    list.Add(new CrumbsModel(parent.menuName, string.Empty,0, parent.flag));
            }
            return list;
        }

        /// <summary>
        /// 根据地址获取菜单名称
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public string GetViewTitle(string Path)
        {
            return new RW.PMS.Common.MySqlHelper().ExecuteScalar("select menuName from sys_menu where url='" + Path + "'", new List<MySqlParameter>().ToArray()) + "";
        }
    }
}
