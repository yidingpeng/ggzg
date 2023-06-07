using RW.PMS.Common;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
namespace RW.PMS.IDAL
{
    public interface IDAL_Account : IDependence
    {

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        UserModel GetUserByUsername(string username);
        long? GetAuthorize(string username, string path);
        void EditPwd(string yPwd, string newPwd, string username = "");
        List<DepartmentModel> GetDepartment();
        List<MenuModel> GetMenus(string userName);
        List<UserModel> GetPagingUsers(UserModel model, out int totalCount);
        List<RoleModel> GetRoles();
        void qrPwd(string newPwd1, string newPwd);
        /// <summary>
        /// 菜单栏搜索框
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        string GetMenuNameByUrl(string menuName);
    }
}
