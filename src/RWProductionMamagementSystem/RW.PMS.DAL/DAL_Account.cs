using MySql.Data.MySqlClient;
using RW.PMS.IDAL;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RW.PMS.DAL
{
    /// <summary>
    /// 账户
    /// </summary>
    internal class DAL_Account : IDAL_Account
    {
        #region 用户管理

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserModel GetUserByUsername(string username)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT 
                            us.userID,
                            us.userName,
                            us.pwd,
                            us.empNo,
                            us.empName,
                            us.roleID,
                            role.roleName, 
                            us.deptID,
                            dp.deptName,
                            us.SkillLevel,
                            GetbdNameBybdID(us.SkillLevel) SkillLevelName,
                            us.postTime,
                            us.phone,
                            us.birthday,
                            us.sex,
                            us.registtime,
                            us.inStatus,
                            us.cardNo,
                            us.headPortrait,
                            us.remark
                            FROM sys_user us
                            LEFT JOIN sys_role role ON us.roleID = role.roleID
                            LEFT JOIN sys_department dp ON us.deptID=dp.deptID
                            where 1=1 and us.deleted=0 and userName = '" + username + "'";
            List<UserModel> list = db.ExecuteList<UserModel>(sql, pList.ToArray());

            if (list != null)
                return list[0];
            else
                return null;
        }
        

        /// <summary>
        /// 用户管理页面 
        /// LHR 2019-1-15修改
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<UserModel> GetPagingUsers(UserModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string para = "";

            if (!string.IsNullOrEmpty(model.empName))
            {
                para += " and us.empName=@empName ";
                pList.Add(new MySqlParameter("@empName", model.empName));
            }
            if (model.roleID != 0 && model.roleID != null)
            {
                para += " and us.roleID=@roleID ";
                pList.Add(new MySqlParameter("@roleID", model.roleID));
            }
            if (model.deptID != 0 && model.deptID != null)
            {
                para += " and us.deptID=@deptID ";
                pList.Add(new MySqlParameter("@deptID", model.deptID));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"SELECT Count(*) FROM sys_user us 
                                   LEFT JOIN sys_role role ON us.roleID = role.roleID
                                   LEFT JOIN sys_department dp ON us.deptID=dp.deptID where 1=1 and us.deleted=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"SELECT 
                            us.userID,
                            us.userName,
                            us.pwd,
                            us.empNo,
                            us.empName,
                            us.roleID,
                            role.roleName, 
                            us.deptID,
                            dp.deptName,
                            us.SkillLevel,
                            GetbdNameBybdID(us.SkillLevel) SkillLevelName,
                            us.postTime,
                            us.phone,
                            us.birthday,
                            us.sex,
                            us.registtime,
                            us.inStatus,
                            us.cardNo,
                            us.headPortrait,
                            us.signature,
                            us.remark
                            FROM sys_user us
                            LEFT JOIN sys_role role ON us.roleID = role.roleID
                            LEFT JOIN sys_department dp ON us.deptID=dp.deptID
                            where 1=1 and us.deleted=0 " + para;

            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;

            List<UserModel> list = db.ExecuteList<UserModel>(sql, pList.ToArray());

            return list;
        }

        public class UsersSerachModel : PagingSerachModel<UserModel>
        {
            public string Username { get; set; }
        }

        public class PagingSerachModel<T>
        {
            public int PageIndex { get; set; }
            public int PageSize { get; set; }
            public int PageCount { get; set; }
            public int RecordCount { get; set; }

            public List<T> MyDataList { get; set; }
        }

        public void qrPwd(string newPwd1, string newPwd)
        {
            if (!newPwd1.Equals(newPwd))
                throw new Exception("两次密码输入不相同");
        }

        public void EditPwd(string yPwd, string newPwd, string username = "")
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            UserModel userModel = (new DAL_System()).GetUser(new UserModel() { userName = username });

            if (userModel == null)

                throw new Exception("找不到该用户！");

            if (yPwd != userModel.pwd)

                throw new Exception("原密码输入错误，请重新输入原密码！");

            string sql = "update sys_User set pwd=@pwd where userName=@userName";

            pList.Add(new MySqlParameter("@pwd", newPwd));

            pList.Add(new MySqlParameter("@userName", username));

            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 角色管理

        public List<RoleModel> GetRoles()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select roleID,roleName from sys_role";

            List<RoleModel> list = db.ExecuteList<RoleModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 查询返回部门
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartment()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select deptID as DeptID,deptNo as DeptNo,deptName as DeptName,deptLeader as DeptLeader,remark as Remark from sys_department";

            List<DepartmentModel> list = db.ExecuteList<DepartmentModel>(sql, pList.ToArray());

            return list;
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="path">页面地址</param>
        /// <returns></returns>
        public long? GetAuthorize(string username, string path)
        {
            string sql = @"select rp.auth_value from sys_roleMenuDef rp 
                                    left join sys_role r on rp.roleID=r.roleID 
                                    left join sys_menu p on rp.menuID=p.menuID 
                                    left join sys_User u on r.roleID=u.roleID 
                                    where p.url='" + path + "' and userName='" + username + "'";
            long ret = 0;

            long.TryParse(new RW.PMS.Common.MySqlHelper().ExecuteScalar(sql, new List<MySqlParameter>().ToArray()) + "", out ret);

            if (ret == 0)
                return null;

            return ret;
        }

        /// <summary>
        /// 根据用户获取此用户权限下拥有的菜单
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<MenuModel> GetMenus(string userName)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();

            string sql = @"select * from sys_roleMenuDef d 
                                    left join sys_role r on r.roleID=d.roleID 
                                    left join sys_User u on u.roleID=r.roleID 
                                    left join sys_menu m on m.menuID=d.menuID 
                                    where u.userName='" + userName + "' and d.auth_value>0 AND m.deleteFlag = 0 order by m.sort";

            var list = db.ExecuteList<MenuModel>(sql, new List<MySqlParameter>().ToArray());

            var mainList = new List<MenuModel>();

            foreach (var item in list)
            {
                if (item.parentID == 0 && item.isShow == 1)
                {
                    mainList.Add(item);
                }
            }

            foreach (var main in mainList)
            {
                foreach (var item in list)
                {
                    if (item.parentID == main.menuID && item.isShow == 1)
                    {
                        main.Children.Add(item);
                    }
                }
            }

            return mainList;
        }

        #endregion

        /// <summary>
        /// 菜单栏搜索框
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetMenuNameByUrl(string menuName)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = "select * from sys_menu where menuName='" + menuName + "' and isShow=1 and parentID<>0";

            List<MenuModel> list = db.ExecuteList<MenuModel>(sql, pList.ToArray());

            if (list.Count > 0)
            {
                return list[0].url;
            }

            return "/Home/Index";
        }

    }
}
