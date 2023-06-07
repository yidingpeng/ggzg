using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model;
using System.Web.UI;
using System.Web;
using System.Data.SqlClient;
using RW.PMS.Model.Sys;
using RW.PMS.Model.Follow;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Common;

namespace RW.PMS.BLL
{
    internal class BLL_Account : IBLL_Account
    {
        private IDAL_Account _DAL = null;

        public BLL_Account()
        {
            _DAL = DIService.GetService<IDAL_Account>();
        }


        #region 用户管理

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public UserModel GetUserByUsername(string username)
        {
            return _DAL.GetUserByUsername(username);
        }

        public List<UserModel> GetPagingUsers(UserModel model, out int totalCount)
        {
            return _DAL.GetPagingUsers(model, out totalCount);
        }

        public void qrPwd(string newPwd1, string newPwd)
        {
            _DAL.qrPwd(newPwd1, newPwd);
        }

        public void EditPwd(string yPwd, string newPwd, string username = "")
        {
            _DAL.EditPwd(yPwd, newPwd, username);
        }
        #endregion

        #region 角色管理

        public List<RoleModel> GetRoles()
        {
            return _DAL.GetRoles();
        }

        public List<DepartmentModel> GetDepartment()
        {
            return _DAL.GetDepartment();
        }

        public long? GetAuthorize(string username, string path)
        {
            return _DAL.GetAuthorize(username, path);
        }

        #endregion

        #region 菜单管理

        public List<MenuModel> GetMenus(string userName)
        {
            return _DAL.GetMenus(userName);
        }

        #endregion

        /// <summary>
        /// 菜单栏搜索框
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetMenuNameByUrl(string menuName)
        {
            return _DAL.GetMenuNameByUrl(menuName);
        }
    }
}
