using MySql.Data.MySqlClient;
using RW.PMS.Model.Sys;
using System.Collections.Generic;

namespace RW.PMS.MYSQL.DAL
{
    public class DAL_System
    {
        RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
        

        #region 角色权限


        /// <summary>
        /// 获取角色菜单关联信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<RoleMenuModel> GetRoleMenuList(RoleMenuModel model)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select d.*,r.roleName,m.menuName from sys_rolemenudef d
left JOIN sys_role r on d.roleID=r.roleID
LEFT JOIN sys_menu m on d.menuID=m.menuID where 1=1 ";
            if (0 != model.roleID)
            {
                sql += "and d.roleID=@roleID ";
                pList.Add(new MySqlParameter("@roleID", model.roleID));
            }
            if (0 != model.menuID)
            {
                sql += "and d.menuID=@menuID ";
                pList.Add(new MySqlParameter("@menuID", model.menuID));
            }
            List<RoleMenuModel> list = db.ExecuteList<RoleMenuModel>(sql, pList.ToArray());
            return list;
        }

        #endregion

        #region 数据字典

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataList(BaseDataModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select count(*) from sys_basedata where 1=1 ";
            if (!string.IsNullOrEmpty(model.bdtypeCode))
            {
                sql += "and bdtypeCode=@bdtypeCode ";
                pList.Add(new MySqlParameter("@bdtypeCode", model.bdtypeCode));
            }
            if (model.bdtypeID.HasValue)
            {
                sql += "and bdtypeID=@bdtypeID ";
                pList.Add(new MySqlParameter("@bdtypeID", model.bdtypeID));
            }
            totalCount = (int)db.ExecuteScalar(sql, pList.ToArray());

            pList.Clear();
            sql = "select * from sys_basedata where 1=1 ";
            if (!string.IsNullOrEmpty(model.bdtypeCode))
            {
                sql += "and bdtypeCode=@bdtypeCode ";
                pList.Add(new MySqlParameter("@bdtypeCode", model.bdtypeCode));
            }
            if (model.bdtypeID.HasValue)
            {
                sql += "and bdtypeID=@bdtypeID ";
                pList.Add(new MySqlParameter("@bdtypeID", model.bdtypeID));
            }
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<BaseDataModel> list = db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
            return list;
        }


        #endregion
    }
}
