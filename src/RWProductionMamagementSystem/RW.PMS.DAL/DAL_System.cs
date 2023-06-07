using MySql.Data.MySqlClient;
using RW.PMS.Common;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace RW.PMS.DAL
{
    /// <summary>
    /// 系统
    /// </summary>
    internal class DAL_System : IDAL_System
    {
        private const string _GJWLOPCType = "gjwlOPCType";

        #region 用户信息

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserModel GetUser(UserModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select u.userID,u.userName,u.pwd,u.empNo,u.empName,u.roleID,r.roleName,u.deptID,u.postTime,u.phone,u.birthday,
                            u.sex,u.registtime,u.inStatus,u.cardNo,u.headPortrait,u.signature,u.remark,u.deleted 
                            from sys_User u left join sys_role r on u.roleID=r.roleID where 1=1 ";
            if (!string.IsNullOrEmpty(model.userName))
            {
                sql += "and userName=@userName ";
                pList.Add(new MySqlParameter("@userName", model.userName.Trim()));
            }
            if (!string.IsNullOrEmpty(model.cardNo))
            {
                sql += "and cardNo=@cardNo ";
                pList.Add(new MySqlParameter("@cardNo", model.cardNo));
            }
            if (0 != model.userID)
            {
                sql += "and userID=@userID ";
                pList.Add(new MySqlParameter("@userID", model.userID));
            }
            if (model.deleted.HasValue)
            {
                sql += "and deleted=@deleted ";
                pList.Add(new MySqlParameter("@deleted", model.deleted));
            }
            if (model.inStatus.HasValue)
            {
                sql += "and inStatus=@inStatus ";
                pList.Add(new MySqlParameter("@inStatus", model.inStatus));
            }

            List<UserModel> list = db.ExecuteList<UserModel>(sql, pList.ToArray());
            if (list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserModel> GetUserList(UserModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select * from sys_User where deleted=0";
            List<UserModel> list = db.ExecuteList<UserModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户信息实体类</param>
        public void AddUsers(UserModel model)
        {
            var datetime = (new DAL_BaseInfo()).GetServerDateTime();
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into sys_user(userName,pwd,empNo,empName,roleID,deptID,SkillLevel,postTime,phone,birthday,sex,registtime,inStatus,cardNo,headPortrait,signature,remark,deleted) 
                                    values(@userName,@pwd,@empNo,@empName,@roleID,@deptID,@SkillLevel,@postTime,@phone,@birthday,@sex,@registtime,@inStatus,@cardNo,@headPortrait,@signature,@remark,@deleted)";
            pList.Add(new MySqlParameter("@userName", model.userName.Trim()));
            pList.Add(new MySqlParameter("@pwd", model.pwd));
            pList.Add(new MySqlParameter("@empNo", model.empNo));
            pList.Add(new MySqlParameter("@empName", model.empName.Trim()));
            pList.Add(new MySqlParameter("@roleID", model.roleID));
            pList.Add(new MySqlParameter("@deptID", model.deptID));
            pList.Add(new MySqlParameter("@SkillLevel", model.SkillLevel));
            pList.Add(new MySqlParameter("@postTime", model.postTime));
            pList.Add(new MySqlParameter("@phone", model.phone));
            pList.Add(new MySqlParameter("@birthday", model.birthday));
            pList.Add(new MySqlParameter("@sex", model.sex));
            pList.Add(new MySqlParameter("@registtime", datetime));
            pList.Add(new MySqlParameter("@inStatus", model.inStatus));
            pList.Add(new MySqlParameter("@cardNo", model.cardNo));
            pList.Add(new MySqlParameter("@headPortrait", model.headPortrait));
            pList.Add(new MySqlParameter("@signature", model.signature));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@deleted", model.deleted));
            db.ExecuteNonQuery(sql, pList.ToArray());
            return;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户信息实体类</param>
        public void EditUsers(UserModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update sys_user set empNo=@empNo,empName=@empName,pwd=@pwd,roleID=@roleID,deptID=@deptID,SkillLevel=@SkillLevel,postTime=@postTime,phone=@phone,birthday=@birthday,sex=@sex,
                                   inStatus=@inStatus,cardNo=@cardNo,headPortrait=@headPortrait,signature=@signature,remark=@remark where userID=@userID";
            pList.Add(new MySqlParameter("@empNo", model.empNo));
            pList.Add(new MySqlParameter("@empName", model.empName.Trim()));
            pList.Add(new MySqlParameter("@pwd", model.pwd));
            pList.Add(new MySqlParameter("@roleID", model.roleID));
            pList.Add(new MySqlParameter("@deptID", model.deptID));
            pList.Add(new MySqlParameter("@SkillLevel", model.SkillLevel));
            pList.Add(new MySqlParameter("@postTime", model.postTime));
            pList.Add(new MySqlParameter("@phone", model.phone));
            pList.Add(new MySqlParameter("@birthday", model.birthday));
            pList.Add(new MySqlParameter("@sex", model.sex));
            pList.Add(new MySqlParameter("@inStatus", model.inStatus));
            pList.Add(new MySqlParameter("@cardNo", model.cardNo));
            pList.Add(new MySqlParameter("@headPortrait", model.headPortrait));
            pList.Add(new MySqlParameter("@signature", model.signature));
            pList.Add(new MySqlParameter("@remark", model.remark));
            pList.Add(new MySqlParameter("@userID", model.userID));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void DeleteUsers(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update sys_user set deleted=1 where userID in(" + id + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }


        #endregion

        #region 角色信息

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="model">角色实体类</param>
        /// <param name="totalCount">数量</param>
        /// <returns></returns>
        public List<RoleModel> GetRoleList(RoleModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.roleName))
            {
                para += "and roleName=@roleName ";
                pList.Add(new MySqlParameter("@roleName", model.roleName));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select count(*) from sys_role where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select * from sys_role where 1=1 ";
            sql += para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            return db.ExecuteList<RoleModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<RoleModel> GetRoleList(RoleModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_role where 1=1 ";
            if (0 != model.roleID)
            {
                sql += "and roleID=@roleID ";
                pList.Add(new MySqlParameter("@roleID", model.roleID));
            }
            if (!string.IsNullOrEmpty(model.roleName))
            {
                sql += "and roleName=@roleName ";
                pList.Add(new MySqlParameter("@roleName", model.roleName));
            }
            return db.ExecuteList<RoleModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        public void AddRole(RoleModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "insert into sys_role(roleName,remark) values(@roleName,@remark)";
            pList.Add(new MySqlParameter("@roleName", model.roleName));
            pList.Add(new MySqlParameter("@remark", model.remark));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        public void EditRole(RoleModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update sys_role set roleName=@roleName,remark=@remark where roleID=@roleID";
            pList.Add(new MySqlParameter("@roleID", model.roleID));
            pList.Add(new MySqlParameter("@roleName", model.roleName));
            pList.Add(new MySqlParameter("@remark", model.remark));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());

        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRole(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from sys_role where roleID in(" + id + ")";
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region  角色权限

        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        public List<MenuModel> GetMenuList(MenuModel model = null)
        {
            if (model == null) model = new MenuModel();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (0 != model.menuID)
            {
                para += "and a.menuID=@menuID ";
                pList.Add(new MySqlParameter("@menuID", model.menuID));
            }
            if (model.parentID.HasValue && 0 != model.parentID)
            {
                para += "and a.parentID=@parentID ";
                pList.Add(new MySqlParameter("@parentID", model.parentID));
            }
            if (!string.IsNullOrEmpty(model.url))
            {
                para += "and a.url=@url ";
                pList.Add(new MySqlParameter("@url", model.url));
            }
            //获取所有界面数据
            string sql = @"select a.menuID,a.menuName,a.parentID,b.menuName parentNameText,a.atWhere,a.sort,a.url
                        ,a.isShow,a.flag,a.createtime,a.createBy,a.updatetime,a.updateBy,a.remark 
                        from sys_menu a LEFT JOIN sys_menu b on a.parentID=b.menuID where 1=1 " + para;
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            var mainList = db.ExecuteList<MenuModel>(sql, pList.ToArray());
            //获取所有界面权限数据
            sql = @"select d.menuID,d.authID ID,a.authName,a.authValue,a.authType from sys_menu_auth d left join sys_auth a on a.ID=d.authID";
            var authList = db.ExecuteList<MenuAuth>(sql, null);

            foreach (var item in mainList)
            {
                item.MenuAuth = authList.Where(_ => _.menuID.HasValue && _.menuID.Value.Equals(item.menuID));
                item.auths = authList.Where(_ => _.menuID.HasValue && _.menuID.Value.Equals(item.menuID));
                //item.Children = mainList.Where(_ => _.parentID.HasValue && _.parentID.Value.Equals(item.menuID)).ToList();
                //mainList.Add(new {menuID=  });

            }
            return mainList.OrderBy(x => x.parentID).ToList();
        }




        /// <summary>
        /// 获取菜单树形权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<TreeEntity> GetMenuTreeList(int roleID)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            //查询所有父级菜单parentID=0
            var mainList1 = db.ExecuteList<TreeEntity>(@"select a.menuID as id,a.menuName as label,a.parentID as pid from sys_menu a 
            LEFT JOIN sys_menu b on a.parentID = b.menuID where 1 = 1 and a.parentID = 0 and a.deleteFlag = 0 ORDER BY a.sort", pList.ToArray());
            var menuList = new List<TreeEntity>();//输出Tree数据集合
            //循环所有父级菜单parentID=0
            foreach (var item in mainList1)
            {
                //父级下子级菜单集合
                var childrenList = new List<TreeEntity>();
                TreeEntity tree = new TreeEntity { id = "y:" + item.id, label = item.label, pid = item.pid, };

                #region 
                //父级parentID=0界面的按钮
                var authList1 = db.ExecuteList<TreeEntity>(@"select a.authName as label,a.authValue as id from sys_menu_auth d 
                left join sys_auth a on a.ID = d.authID where menuID = " + item.id, null);
                if (authList1.Count > 0)
                {
                    //循环添加所属于父级菜单（一级菜单）的按钮权限
                    foreach (var btns in authList1)
                    {
                        childrenList.Add(new TreeEntity { id = "a:" + btns.id + ",y:" + item.id, label = btns.label, @checked = authBool(roleID, item.id, btns.id) });
                    }
                }
                #endregion

                //查询二级菜单
                var mainList2 = db.ExecuteList<TreeEntity>(@"select a.menuID as id,a.menuName as label,a.parentID as pid from sys_menu a 
                LEFT JOIN sys_menu b on a.parentID = b.menuID where 1 = 1 and a.parentID = " + item.id + " and a.deleteFlag = 0 ORDER BY a.sort", null);
                foreach (var item2 in mainList2)
                {
                    var ChindrenTree = new TreeEntity() { id = "e:" + item2.id + ",y:" + item.id, label = item2.label, pid = item2.pid };

                    //获取子级菜单所有界面权限数据
                    var authList = db.ExecuteList<TreeEntity>(@"select d.menuID,d.authID,a.authName as label,a.authValue as id,a.authType from sys_menu_auth d 
                    left join sys_auth a on a.ID = d.authID 
                    where menuID = " + item2.id, null);
                    var childrenButtons = new List<TreeEntity>();//按钮权限集合

                    //循环添加所属于子级菜单（二级菜单）的按钮权限
                    foreach (var btns in authList)
                    {
                        childrenButtons.Add(new TreeEntity { id = "a:" + btns.id + ",y:" + item2.id, label = btns.label, @checked = authBool(roleID, item2.id, btns.id) });
                    }
                    ChindrenTree.children = childrenButtons;
                    childrenList.Add(ChindrenTree);
                    //childrenButtons.Clear();
                }
                tree.children = childrenList;
                menuList.Add(tree);
            }


            return menuList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleID">权限ID</param>
        /// <param name="menuid">页面ID</param>
        /// <param name="authid">权限值ID（2、4、8、16、32、64、128、256、512）</param>
        /// <returns></returns>
        public bool authBool(int roleID, string menuid, string authid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            RoleMenuModel list = db.ExecuteList<RoleMenuModel>("select * from sys_roleMenuDef where roleID=" + roleID + " and menuID = " + menuid, null).FirstOrDefault();
            if (list != null)
            {
                if (list.menuID == menuid.ToInt())
                {
                    return RW.PMS.Common.Auth.SystemAuth.IsHasAuth(authid.ToInt(), list.auth_value ?? 0);
                }
            }
            return false;
        }


        /// <summary>
        /// 获取菜单信息
        /// </summary>
        /// <returns></returns>
        public List<MenuTreeModel> GetMenuAllList(MenuTreeModel model = null)
        {
            List<MenuTreeModel> modelslist = new List<MenuTreeModel>();


            if (model == null) model = new MenuTreeModel();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (0 != model.id)
            {
                para += "and a.menuID=@menuID ";
                pList.Add(new MySqlParameter("@menuID", model.id));
            }
            if (model.pid.HasValue && 0 != model.pid)
            {
                para += "and a.parentID=@parentID ";
                pList.Add(new MySqlParameter("@parentID", model.pid));
            }
            //获取所有界面数据
            string sql = @"select a.menuID as id,a.menuName as name,a.parentID as pid,b.menuName parentNameText,a.atWhere,a.sort,a.url
                        ,a.isShow,a.flag,a.createtime,a.createBy,a.updatetime,a.updateBy,a.remark 
                        from sys_menu a LEFT JOIN sys_menu b on a.parentID=b.menuID where 1=1" + para;
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            var mainList = db.ExecuteList<MenuTreeModel>(sql, pList.ToArray());
            //获取所有界面权限数据
            sql = @"select d.menuID,d.authID ID,a.authName,a.authValue,a.authType from sys_menu_auth d left join sys_auth a on a.ID=d.authID";
            var authList = db.ExecuteList<MenuAuth>(sql, null);


            foreach (var item in mainList)
            {
                List<MenuAuth> auth = authList.Where(_ => _.menuID.HasValue && _.menuID.Value.Equals(item.id)).ToList();
                foreach (var item1 in auth)
                {
                    MenuTreeModel models = new MenuTreeModel();
                    models.id = item1.ID;
                    models.name = item1.authName;
                    models.pid = item1.menuID;
                    modelslist.Add(models);
                }

            }
            mainList.AddRange(modelslist);

            return mainList.OrderBy(x => x.pid).ToList();
        }

        /// <summary>
        /// 根据角色ID获取该角色拥有权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleMenuModel> GetAuthValueByRoleId(int roleId)
        {
            return new RW.PMS.Common.MySqlHelper().ExecuteList<RoleMenuModel>("select * from sys_roleMenuDef where roleID=" + roleId, null);
        }

        /// <summary>
        /// 角色授权
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="RoleId"></param>
        public void EditRoleMenuDef(List<RoleMenuModel> models, int roleId)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    foreach (var item in models)
                    {
                        string sql = "select ID,auth_value from sys_roleMenuDef where roleID=" + roleId + " and menuID=" + item.menuID;
                        var dr = RW.PMS.Common.MySqlHelper.ExecuteDataRow(myTrans, System.Data.CommandType.Text, sql, null);

                        if (dr == null)
                        {
                            sql = "insert sys_roleMenuDef(menuID,roleID,auth_value) values(@menuID,@roleID,@auth_value)";
                            List<MySqlParameter> pList = new List<MySqlParameter>();
                            pList.Add(new MySqlParameter("@menuID", item.menuID));
                            pList.Add(new MySqlParameter("@roleID", roleId));
                            pList.Add(new MySqlParameter("@auth_value", item.auth_value));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }
                        else
                        {
                            long l = 0;
                            long.TryParse(dr["auth_value"] + "", out l);
                            if (item.auth_value != l)
                            {
                                int id = 0;
                                int.TryParse(dr["ID"] + "", out id);
                                sql = "update sys_roleMenuDef set auth_value=@auth_value where ID=" + id;
                                List<MySqlParameter> pList = new List<MySqlParameter>();
                                pList.Add(new MySqlParameter("@auth_value", item.auth_value));
                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                            }
                        }
                    }
                    myTrans.Commit();
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
        }



        /// <summary>
        /// EleTree 角色授权树保存
        /// </summary>
        /// <param name="models">权限实体集合</param>
        /// <param name="roleId">角色ID</param>
        public void SaveRoleMenuDef(List<RoleMenuModel> models, int roleId)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                string sql = "";
                string MenuIdStr = "";//存页面ID
                try
                {
                    #region 处理前端数据
                    //分割权限值和菜单ID
                    List<RoleMenuModel> RoleMenuList = new List<RoleMenuModel>();
                    foreach (var item in models)
                    {
                        var strArray = item.str.Split(',');
                        var menuID = 0;
                        var authVal = 0;
                        foreach (var i in strArray)
                        {
                            //页面权限值
                            if (i.IndexOf('a') != -1)
                            {
                                authVal = i.Substring(2, i.Length - 2).ToInt();
                            }
                            //页面ID
                            if (i.IndexOf('y') != -1)
                            {
                                menuID = i.Substring(2, i.Length - 2).ToInt();
                            }
                        }
                        RoleMenuModel Rolemenu = new RoleMenuModel();
                        Rolemenu.auth_value = authVal;
                        Rolemenu.menuID = menuID;
                        RoleMenuList.Add(Rolemenu);
                    }
                    //重复菜单下按钮值相加
                    var query = from l in RoleMenuList
                                group l by l.menuID into g
                                select new
                                {
                                    g.Key,
                                    Num = g.Sum(l => l.auth_value.ToInt())
                                };

                    #endregion

                    //循环保存
                    foreach (var item in query)
                    {
                        MenuIdStr += item.Key + ",";
                        sql = "select ID,auth_value from sys_roleMenuDef where roleID=" + roleId + " and menuID=" + item.Key;
                        var dr = RW.PMS.Common.MySqlHelper.ExecuteDataRow(myTrans, System.Data.CommandType.Text, sql, null);

                        if (dr == null)
                        {
                            sql = "insert sys_roleMenuDef(menuID,roleID,auth_value) values(@menuID,@roleID,@auth_value)";
                            List<MySqlParameter> pList = new List<MySqlParameter>();
                            pList.Add(new MySqlParameter("@menuID", item.Key));
                            pList.Add(new MySqlParameter("@roleID", roleId));
                            pList.Add(new MySqlParameter("@auth_value", item.Num));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }
                        else
                        {
                            long l = 0;
                            long.TryParse(dr["auth_value"] + "", out l);
                            //判断权限如果没变化不修改
                            if (item.Num != l)
                            {
                                int id = 0;
                                int.TryParse(dr["ID"] + "", out id);
                                sql = "update sys_roleMenuDef set auth_value=@auth_value where ID=" + id;
                                List<MySqlParameter> pList = new List<MySqlParameter>();
                                pList.Add(new MySqlParameter("@auth_value", item.Num));
                                RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                            }
                        }
                    }
                    //将所有不存在于当前权限集合中的页面权限改为0
                    sql = "update sys_roleMenuDef set auth_value=0 where roleID =" + roleId + " and menuID not in (" + MenuIdStr.Substring(0, MenuIdStr.Length - 1) + ")";
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, null);
                    myTrans.Commit();
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
        }



        /// <summary>
        /// 获取菜单权限类型信息
        /// </summary>
        /// <returns></returns>
        public List<MenuAuth> GetMenuAuth()
        {
            return new RW.PMS.Common.MySqlHelper().ExecuteList<MenuAuth>("select * from sys_auth", new List<MySqlParameter>().ToArray());
        }

        #endregion

        #region 菜单管理

        /// <summary>
        /// 查询与分页
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="totalCount">返回 总数</param>
        /// <returns></returns>
        public List<MenuModel> GetMenuForPage(MenuModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.menuName))
            {
                para += "and m1.menuName like concat('%',@menuName,'%') ";
                pList.Add(new MySqlParameter("@menuName", model.menuName));
            }
            if (model.parentID.HasValue && model.parentID != 0)
            {
                para += "and m1.parentID=@parentID ";
                pList.Add(new MySqlParameter("@parentID", model.parentID));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select count(*) from sys_menu m1 where 1=1 and deleteFlag = 0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            //菜单
            sql = @"select m1.menuID,m1.menuName,m1.atWhere,m1.sort,m1.url,m1.isShow,m1.flag,m1.remark,m1.parentID,m2.menuName parentName ,m1.createtime as CreateTime,m1.deleteFlag
                    from sys_menu m1 left join sys_menu m2 on m1.parentID=m2.menuID where 1=1 and m1.deleteFlag = 0 ";
            sql += para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            var list = db.ExecuteList<MenuModel>(sql, pList.ToArray());

            //权限
            sql = @"select d.menuID,d.authID ID,a.authName from sys_menu_auth d left join sys_auth a on a.ID=d.authID";
            var authList = db.ExecuteList<MenuAuth>(sql, new List<MySqlParameter>().ToArray());
            foreach (var item in list)
            {
                //获取菜单权限
                item.authStr = string.Join("|", authList.Where(_ => _.menuID.HasValue && _.menuID.Value.Equals(item.menuID)).Select(_ => _.authName));
            }
            return list;

        }



        /// <summary>
        /// 查询所有菜单页面
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<MenuModel> GetMenuAll(MenuModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.menuName))
            {
                para += "and m1.menuName like concat('%',@menuName,'%') ";
                pList.Add(new MySqlParameter("@menuName", model.menuName));
            }
            if (model.parentID.HasValue && model.parentID != 0)
            {
                para += "and m1.parentID=@parentID ";
                pList.Add(new MySqlParameter("@parentID", model.parentID));
            }

            //菜单
            string sql = @"select m1.menuID,m1.menuName,m1.atWhere,m1.sort,m1.url,m1.isShow,m1.flag,m1.remark,m1.parentID,m2.menuName parentName,m1.createtime as CreateTime,m1.deleteFlag
                    from sys_menu m1 left join sys_menu m2 on m1.parentID=m2.menuID where 1=1 and m1.deleteFlag = 0 ";
            sql += para + " order by m1.sort ";
            var list = db.ExecuteList<MenuModel>(sql, pList.ToArray());

            //权限
            sql = @"select d.menuID,d.authID ID,a.authName from sys_menu_auth d left join sys_auth a on a.ID=d.authID";
            var authList = db.ExecuteList<MenuAuth>(sql, new List<MySqlParameter>().ToArray());
            foreach (var item in list)
            {
                //获取菜单权限
                item.authStr = string.Join("|", authList.Where(_ => _.menuID.HasValue && _.menuID.Value.Equals(item.menuID)).Select(_ => _.authName));
            }
            return list;
        }


        /// <summary>
        /// 获取所有顶父级菜单,下拉框使用
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public IEnumerable<AuthorizeMenu> GetAuthorizeMenu(int i)
        {
            string sql = "select menuID nodeid,menuName text from sys_menu where deleteFlag = 0 and parentID=" + i;
            return new RW.PMS.Common.MySqlHelper().ExecuteList<AuthorizeMenu>(sql, new List<MySqlParameter>().ToArray());
        }

        //private List<AuthorizeMenu> GetSubMenus(int? parentID, List<sys_menu> allMenus)
        //{
        //    var retVal = allMenus.Where(x => x.parentID == parentID).Select(x => new AuthorizeMenu
        //    {
        //        nodeid = x.menuID,
        //        text = x.menuName,
        //        nodes = GetSubMenus(x.menuID, allMenus),
        //    }).ToList();

        //    return retVal;
        //}

        //public List<MenuModel> GetPermissions()
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        return context.sys_menu.Where(p => true).Select(x => new MenuModel
        //        {
        //            menuID = x.menuID,
        //            menuName = x.menuName,
        //            parentID = x.parentID,
        //            atWhere = x.atWhere,
        //            sort = x.sort ?? 0,
        //            url = x.Url,
        //            flag = x.flag,
        //            isShow = x.isShow ?? 0,
        //            createBy = x.createBy,
        //            updateBy = x.updateBy,
        //            remark = x.remark,
        //            auths = x.sys_menu_auth.Select(f => new MenuAuth
        //            {
        //                ID = f.sys_auth.ID,
        //                authName = f.sys_auth.authName,
        //                authType = f.sys_auth.authType,
        //                authValue = f.sys_auth.authValue
        //            }),
        //        }).ToList();
        //    }
        //}

        /// <summary>
        /// 新增菜单
        /// </summary>
        /// <param name="model"></param>
        public void AddMenu(MenuModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    string sql = "insert sys_menu(menuName,atWhere,parentID,sort,createtime,createBy,isShow,url,flag,deleteFlag,remark) values(@menuName,@atWhere,@parentID,@sort,@createtime,@createBy,@isShow,@url,@flag,0,@remark)";
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    pList.Add(new MySqlParameter("@menuName", model.menuName));
                    pList.Add(new MySqlParameter("@atWhere", model.atWhere));
                    pList.Add(new MySqlParameter("@parentID", model.parentID));
                    pList.Add(new MySqlParameter("@sort", model.sort));
                    pList.Add(new MySqlParameter("@createtime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    pList.Add(new MySqlParameter("@createBy", model.createBy));
                    pList.Add(new MySqlParameter("@isShow", model.isShow));
                    pList.Add(new MySqlParameter("@url", model.url));
                    pList.Add(new MySqlParameter("@flag", model.flag));
                    pList.Add(new MySqlParameter("@remark", model.remark));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                    int menuID = 0;
                    pList.Clear();
                    sql = "select @@identity";
                    int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text, sql, pList.ToArray()) + "", out menuID);

                    if (model.auths != null)
                    {
                        foreach (var item in model.auths)
                        {
                            sql = "insert sys_menu_auth(authID,menuID) values(@authID,@menuID)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@authID", item.ID));
                            pList.Add(new MySqlParameter("@menuID", menuID));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();
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
        }


        /// <summary>
        /// 修改  LHR
        /// </summary>
        /// <param name="model"></param>
        public void EditMenu(MenuModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                try
                {
                    string sql = @"update sys_menu set menuName=@menuName,atWhere=@atWhere,parentID=@parentID,sort=@sort,updatetime=@updatetime
                                ,updateBy=@updateBy,isShow=@isShow,url=@url,flag=@flag,remark=@remark where menuID=@menuID";
                    List<MySqlParameter> pList = new List<MySqlParameter>();
                    pList.Add(new MySqlParameter("@menuID", model.menuID));
                    pList.Add(new MySqlParameter("@menuName", model.menuName));
                    pList.Add(new MySqlParameter("@atWhere", model.atWhere));
                    pList.Add(new MySqlParameter("@parentID", model.parentID));
                    pList.Add(new MySqlParameter("@sort", model.sort));
                    pList.Add(new MySqlParameter("@updatetime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                    pList.Add(new MySqlParameter("@updateBy", model.updateBy));
                    pList.Add(new MySqlParameter("@isShow", model.isShow));
                    pList.Add(new MySqlParameter("@url", model.url));
                    pList.Add(new MySqlParameter("@flag", model.flag));
                    pList.Add(new MySqlParameter("@remark", model.remark));
                    RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                    if (model.auths != null)
                    {
                        sql = "delete from sys_menu_auth where menuID=@menuID";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@menuID", model.menuID));
                        RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        foreach (var item in model.auths)
                        {
                            sql = "insert sys_menu_auth(authID,menuID) values(@authID,@menuID)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@authID", item.ID));
                            pList.Add(new MySqlParameter("@menuID", model.menuID));
                            RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();
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
        }

        /// <summary>
        /// 删除 菜单
        /// LHR
        /// </summary>
        /// <param name="id"></param>
        public void DelMenu(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "update sys_menu set deleteFlag=1 where menuID in(" + id + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 数据字典
        /// <summary>
        /// 查询数据字典维护 分页数据
        /// LHR
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataForPage(BaseDataModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.bdtypeCode))
            {
                para += "and bd.bdtypeCode like concat('%',@bdtypeCode,'%') ";
                pList.Add(new MySqlParameter("@bdtypeCode", model.bdtypeCode));
            }
            if (model.bdtypeID.HasValue && model.bdtypeID != 0)
            {
                para += "and bd.bdtypeID = @bdtypeID ";
                pList.Add(new MySqlParameter("@bdtypeID", model.bdtypeID));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select count(1) from sys_baseData bd where bd.isDeleted=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select bd.*,sbd.bdname BdParent,bdtype.typename BdtypeName,bdtype.typecode bdtypeCode from sys_baseData bd 
                                left join sys_baseData sbd on bd.bdParentID=sbd.ID 
                                left join sys_baseDataType bdtype on bd.bdtypeID=bdtype.ID
                                where bd.isDeleted=0 ";
            sql += para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            return db.ExecuteList<BaseDataModel>(sql, pList.ToArray());

        }



        /// <summary>
        /// Layui 查询数据字典维护 分页数据 LHR 2020-05-15
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataForPageLayui(BaseDataModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";


            if (model.bdtypeID.HasValue && model.bdtypeID != 0)
            {
                para += "and bd.bdtypeID = @bdtypeID ";
                pList.Add(new MySqlParameter("@bdtypeID", model.bdtypeID));
            }

            if (!string.IsNullOrEmpty(model.bdname))
            {
                para += "and bd.bdname like concat('%',@bdname,'%') ";
                pList.Add(new MySqlParameter("@bdname", model.bdname));
            }

            if (!string.IsNullOrEmpty(model.bdcode))
            {
                para += "and bd.bdcode like concat('%',@bdcode,'%') ";
                pList.Add(new MySqlParameter("@bdcode", model.bdcode));
            }

            if (!string.IsNullOrEmpty(model.bdtypeCode))
            {
                para += "and bd.bdtypeCode like concat('%',@bdtypeCode,'%') ";
                pList.Add(new MySqlParameter("@bdtypeCode", model.bdtypeCode));
            }


            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select count(*) from sys_baseData bd where bd.isDeleted=0 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select bd.*,sbd.bdname BdParent,bdtype.typename BdtypeName,bdtype.typecode bdtypeCode from sys_baseData bd 
                                left join sys_baseData sbd on bd.bdParentID=sbd.ID 
                                left join sys_baseDataType bdtype on bd.bdtypeID=bdtype.ID
                                where bd.isDeleted=0 ";
            sql += para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            return db.ExecuteList<BaseDataModel>(sql, pList.ToArray());

        }

        /// <summary>
        /// 查询数据字典维护表所有 isDeleted 为0的数据
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetbaseData()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select ID,bdtypeID,bdtypeCode,bdcode,bdname,bdvalue,bdParentID,isDeleted,remark from sys_baseData where isDeleted= 0";
            return db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 根据类型编码获取数据字典
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataTypeValue(string typecode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_baseData where bdtypeCode=@bdtypeCode and isDeleted =0";
            pList.Add(new MySqlParameter("@bdtypeCode", typecode));
            return db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
        }


        /// <summary>
        /// 根据类型编码 以及 类型值 获取数据字典
        /// 用于AGV查询虚拟地址集合
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataTypeValue(string typecode,string bdValueStr)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = $"select * from sys_baseData where bdtypeCode=@bdtypeCode and bdValue in ({bdValueStr}) and isDeleted =0";
            pList.Add(new MySqlParameter("@bdtypeCode", typecode));
            return db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 根据类型编码获取异常类型
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataValue(string typecode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_baseData where bdtypeCode=@bdtypeCode and isDeleted =0 and bdParentID is NULL";
            pList.Add(new MySqlParameter("@bdtypeCode", typecode));
            return db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 根据类型编码获取异常类型子项
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataSubitemValue(string typecode, int typeid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_baseData where bdtypeCode=@bdtypeCode and isDeleted =0 and bdParentID=@bdParentID";
            pList.Add(new MySqlParameter("@bdtypeCode", typecode));
            pList.Add(new MySqlParameter("@bdParentID", typeid));
            return db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 根据异常类型子项获取类型编码
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public int GetBaseDataTypebyID(string typecode, int typeid)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select bdParentID from sys_baseData where ID=@ID";
            pList.Add(new MySqlParameter("@bdtypeCode", typecode));
            pList.Add(new MySqlParameter("@ID", typeid));

            DataSet set = db.ExecuteDataSet(sql, pList.ToArray());

            return Convert.ToInt32(set.Tables[0].Rows[0].ItemArray[0]);
        }


        /// <summary>
        /// 添加 数据字典维护
        /// </summary>
        /// <param name="model">实体类</param>
        public void AddBaseData(BaseDataModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into sys_baseData(bdtypeID,bdtypeCode,bdcode,bdname,bdvalue,bdParentID,isDeleted,remark) 
                            values(@bdtypeID,@bdtypeCode,@bdcode,@bdname,@bdvalue,@bdParentID,@isDeleted,@remark)";
            pList.Add(new MySqlParameter("@bdtypeID", model.bdtypeID));
            pList.Add(new MySqlParameter("@bdtypeCode", model.bdtypeCode));
            pList.Add(new MySqlParameter("@bdcode", model.bdcode));
            pList.Add(new MySqlParameter("@bdname", model.bdname));
            pList.Add(new MySqlParameter("@bdvalue", model.bdvalue));
            pList.Add(new MySqlParameter("@bdParentID", model.bdParentID));
            pList.Add(new MySqlParameter("@isDeleted", model.isDeleted));
            pList.Add(new MySqlParameter("@remark", model.remark));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改 数据字典维护
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseData(BaseDataModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update sys_baseData set bdtypeID=@bdtypeID,bdtypeCode=@bdtypeCode,bdcode=@bdcode,bdname=@bdname,bdvalue=@bdvalue,
bdParentID=@bdParentID,isDeleted=@isDeleted,remark=@remark where ID=@ID";
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@bdtypeID", model.bdtypeID));
            pList.Add(new MySqlParameter("@bdtypeCode", model.bdtypeCode));
            pList.Add(new MySqlParameter("@bdcode", model.bdcode));
            pList.Add(new MySqlParameter("@bdname", model.bdname));
            pList.Add(new MySqlParameter("@bdvalue", model.bdvalue));
            pList.Add(new MySqlParameter("@bdParentID", model.bdParentID));
            pList.Add(new MySqlParameter("@isDeleted", model.isDeleted));
            pList.Add(new MySqlParameter("@remark", model.remark));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除 数据字典维护
        /// </summary>
        /// <param name="id"></param>
        public void DelBaseData(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"update sys_baseData set isDeleted=1 where ID in(" + id + ")";
            int i = db.ExecuteNonQuery(commandText: sql, parms: null);
        }

        #endregion

        #region 工具物料OPC点位配置信息表

        /// <summary>
        /// 查询 工具物料OPC点位配置信息表 分页数据
        /// LHR
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<GjWlOpcPointModel> GetGjWlOpcPointForPage(GjWlOpcPointModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (model.gwID != 0)
                {
                    para += "and A.gwID=@gwID ";
                    pList.Add(new MySqlParameter("@gwID", model.gwID));
                }
                if (model.pmodelID != 0)
                {
                    para += "and A.pmodelID=@pmodelID ";
                    pList.Add(new MySqlParameter("@pmodelID", model.pmodelID));
                }
                if (model.GjID != 0)
                {
                    para += "and A.gjID=@gjID ";
                    pList.Add(new MySqlParameter("@gjID", model.GjID));
                }
                if (model.WlID != 0)
                {
                    para += "and A.wlID=@wlID ";
                    pList.Add(new MySqlParameter("@wlID", model.WlID));
                }
            }
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"select count(*) from ( select gwID,pmodelID,gjID,wlID,opcDeviceName,remark from base_gjwlOpcPoint
                                   group by gwID,pmodelID,gjID,wlID,opcDeviceName
                                   ) A left join base_gongwei gw on a.gwID=gw.ID
                                   left join base_gongju gj on A.gjID=gj.ID
                                   left join base_material wl on A.wlID=wl.ID where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select A.gwID,gw.gwName,A.GjID,gj.GjName,A.WlID,wl.mName as WlName,A.OpcDeviceName,A.Remark,pm.Pmodel as pmodelName, A.pmodelID from 
                            ( select gwID,pmodelID,gjID,wlID,opcDeviceName,remark from base_gjwlOpcPoint group by gwID,pmodelID,gjID,wlID,opcDeviceName) A 
                            left join base_gongwei gw on a.gwID=gw.ID
                            left join base_gongju gj on A.gjID=gj.ID
                            left join base_material wl on A.wlID=wl.ID 
                            left join base_productmodel pm on A.pmodelID=pm.ID  where 1=1 " + para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<GjWlOpcPointModel> list = db.ExecuteList<GjWlOpcPointModel>(sql, pList.ToArray());
            return GetGjWlOpcTypes(list);
        }

        /// <summary>
        /// 查询 工具物料OPC点位配置信息表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<GjWlOpcPointModel> GetGjWlOpcPointList(GjWlOpcPointModel model)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (model.gwID != 0)
                {
                    para += "and A.gwID=@gwID ";
                    pList.Add(new MySqlParameter("@gwID", model.gwID));
                }
                if (model.pmodelID != 0)
                {
                    para += "and A.pmodelID=@pmodelID ";
                    pList.Add(new MySqlParameter("@pmodelID", model.pmodelID));
                }
                if (model.GjID != 0)
                {
                    para += "and A.gjID=@gjID ";
                    pList.Add(new MySqlParameter("@gjID", model.GjID));
                }
                if (model.WlID != 0)
                {
                    para += "and A.wlID=@wlID ";
                    pList.Add(new MySqlParameter("@wlID", model.WlID));
                }
            }
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = @"select A.gwID,gw.gwName,A.GjID,gj.GjName,A.WlID,wl.mName as WlName,A.OpcDeviceName,A.Remark from 
                            ( select gwID,pmodelID,gjID,wlID,opcDeviceName,remark from base_gjwlOpcPoint group by gwID,gjID,wlID,opcDeviceName) A 
                            left join base_gongwei gw on a.gwID=gw.ID
                            left join base_gongju gj on A.gjID=gj.ID
                            left join base_material wl on A.wlID=wl.ID where 1=1 " + para;
           
            List<GjWlOpcPointModel> list = db.ExecuteList<GjWlOpcPointModel>(sql, pList.ToArray());
            return GetGjWlOpcTypes(list);
        }


        /// <summary>
        /// 根据工位、工具、物料、工具物料OPC点位类型获取数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<GjWlOpcPointModel> GetGjWlOpcTypes(List<GjWlOpcPointModel> list)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"SELECT IFNULL(gjwlopc.ID,0) AS gjwlID,IFNULL(gjwlopc.gwid,0) AS gwid,IFNULL(gjwlopc.gjid,0) as gjid,IFNULL(gjwlopc.wlid,0) as wlid,
                           bd.ID,bd.bdcode AS `Code`,gjwlopc.opcValue AS `Value`,gjwlopc.pmodelID
                           FROM sys_baseData bd LEFT JOIN base_gjwlOpcPoint gjwlopc ON bd.ID = gjwlopc.opcTypeID
                           WHERE bd.bdtypeCode = 'gjwlOPCType'";
            List<GjWlOpcType> GjwlOpc = db.ExecuteList<GjWlOpcType>(sql, pList.ToArray());
            foreach (var wp in list)
            {
                List<GjWlOpcType> tempList = wp.GjWlOpcTypes.ToList();
                foreach (var item in GjwlOpc)
                {
                    if (item.gwid == wp.gwID && item.gjid == wp.GjID && item.wlid == wp.WlID && item.pmodelID == wp.pmodelID)
                        tempList.Add(item);
                }
                wp.GjWlOpcTypes = tempList;
            }

            return list;
        }

        /// <summary>
        /// 查询 工具物料OPC点位配置信息表 所有数据
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<GjWlOpcPointModel> GetGjWlOpcPoint()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select ID,IFNULL(gwID,0) as gwID,IFNULL(pmodelID,0) as pmodelID,IFNULL(GjID,0) as GjID,IFNULL(WlID,0) as WlID,OpcDeviceName,OpcTypeID,OpcTypeCode,OpcValue,Remark from base_gjwlOpcPoint";
            List<GjWlOpcPointModel> list = db.ExecuteList<GjWlOpcPointModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 根据工位ID 工具ID 物料ID 查询工具物料OPC点位配置信息表中数据
        /// LHR
        /// </summary>
        /// <param name="gwID"></param>
        /// <param name="gjID"></param>
        /// <param name="wlID"></param>
        /// <returns></returns>
        public List<GjWlOpcPointModel> GetGjWlOpcPointByID(int gwID, int gjID, int wlID, int pmodelID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (gjID != 0)
            {
                para += " and gjID=@gjID ";
                pList.Add(new MySqlParameter("@gjID", gjID));
            }
            if (pmodelID != 0)
            {
                para += " and pmodelID=@pmodelID ";
                pList.Add(new MySqlParameter("@pmodelID", pmodelID));
            }
            if (wlID != 0)
            {
                para += " and wlID=@wlID ";
                pList.Add(new MySqlParameter("@wlID", wlID));
            }
            string sql = @"select ID,IFNULL(gwID,0) as gwID,IFNULL(pmodelID,0) as pmodelID,IFNULL(GjID,0) as GjID,IFNULL(WlID,0) as WlID,OpcDeviceName,
                                  OpcTypeID,OpcTypeCode,OpcValue,Remark from base_gjwlOpcPoint where 1=1 and gwID=" + gwID + para;
            List<GjWlOpcPointModel> list = db.ExecuteList<GjWlOpcPointModel>(sql, pList.ToArray());
            return list;
        }



        /// <summary>
        /// 添加 工具物料OPC点位配置信息表
        /// LHR
        /// </summary>
        /// <param name="model"></param>
        public void AddGjWlOpcPoint(GjWlOpcPointModel model)
        {
            if (!string.IsNullOrEmpty(model.OpcDeviceName))
            {
                model.OpcDeviceName = model.OpcDeviceName.Trim();
            }
            if (!string.IsNullOrEmpty(model.OpcValue))
            {
                model.OpcValue = model.OpcValue.Trim();
            }
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            var bdModel = GetTypeById(model.OpcTypeID ?? 0);
            string sql = @"insert into base_gjwlOpcPoint(gwID,pmodelID,gjID,wlID,opcDeviceName,opcTypeID,opcTypeCode,opcValue,remark)
                                   values(@gwID,@pmodelID,@gjID,@wlID,@opcDeviceName,@opcTypeID,@opcTypeCode,@opcValue,@remark)";
            pList.Add(new MySqlParameter("@gwID", model.gwID));
            pList.Add(new MySqlParameter("@pmodelID", model.pmodelID));
            pList.Add(new MySqlParameter("@gjID", model.GjID));
            pList.Add(new MySqlParameter("@wlID", model.WlID));
            pList.Add(new MySqlParameter("@opcDeviceName", model.OpcDeviceName));
            pList.Add(new MySqlParameter("@opcTypeID", model.OpcTypeID));
            pList.Add(new MySqlParameter("@opcTypeCode", bdModel.bdcode));
            pList.Add(new MySqlParameter("@opcValue", model.OpcValue));
            pList.Add(new MySqlParameter("@remark", model.Remark));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 工具物料点表【添加、修改】调用同一个方法
        /// 循环添加工具物料点表
        /// </summary>
        /// <param name="models">实体</param>
        /// <param name="ID">ID</param>
        public void EditSystemGjWlOpcPoint(List<GjWlOpcPointModel> models, string gjwlOPCID)
        {

            string[] OPCidlist = gjwlOPCID.Split(',');//获取所有工具物料OPC配置ID集合
            List<GjWlOpcType> GjWlOpcTypes = models[0].GjWlOpcTypes.Select(m => new GjWlOpcType
            {
                ID = m.ID,
                Code = m.Code,
                Value = m.Value
            }).ToList();

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";

            sql = @"delete from base_gjwlopcpoint where ID in (" + gjwlOPCID + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());

            for (int i = 0; i < GjWlOpcTypes.Count; i++)
            {
                if (!string.IsNullOrEmpty(GjWlOpcTypes[i].Value))
                {
                    GjWlOpcTypes[i].Value = GjWlOpcTypes[i].Value.Trim();
                }
                sql = @"insert into base_gjwlOpcPoint(gwID,pmodelID,gjID,wlID,opcDeviceName,opcTypeID,opcTypeCode,opcValue,remark)
                                                        values(@gwID,@pmodelID,@gjID,@wlID,@opcDeviceName,@opcTypeID,@opcTypeCode,@opcValue,@remark)";
                pList.Clear();
                pList.Add(new MySqlParameter("@gwID", models[0].gwID));
                pList.Add(new MySqlParameter("@pmodelID", models[0].pmodelID));
                pList.Add(new MySqlParameter("@gjID", models[0].GjID));
                pList.Add(new MySqlParameter("@wlID", models[0].WlID));
                pList.Add(new MySqlParameter("@opcDeviceName", models[0].OpcDeviceName));
                pList.Add(new MySqlParameter("@opcTypeID", GjWlOpcTypes[i].ID));
                pList.Add(new MySqlParameter("@opcTypeCode", GjWlOpcTypes[i].Code));
                pList.Add(new MySqlParameter("@opcValue", GjWlOpcTypes[i].Value));
                pList.Add(new MySqlParameter("@remark", models[0].Remark));
                db.ExecuteNonQuery(sql, pList.ToArray());

            }
        }

        /// <summary>
        /// 删除 工具物料OPC点位配置信息表
        /// LHR
        /// </summary>
        /// <param name="id"></param>
        public void DelGjWlOpcPoint(List<GjWlOpcPointModel> IDlist)
        {
            if (IDlist == null) return;
            List<GjWlist> GjWlist = IDlist[0].IDs.Where(x => x.ID != null).Select(m => new GjWlist
            {
                ID = m.ID,
            }).ToList();
            var IDS = GjWlist.Count() > 0 ? string.Join(",", GjWlist.Select(_ => _.ID)) : "0";

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "delete from base_gjwlOpcPoint where ID in(" + IDS + ")";
            db.ExecuteNonQuery(sql, pList.ToArray());
        }


        /// <summary>
        /// 查询 工位类型下拉
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<GongweiModel> GetgongweiAll()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select ID,Gwcode,Gwname,GwStatus,IP,AreaID,GwOrder,IsFinishGW,IsHasFollow,IsHasAms,Remark from base_gongwei";
            List<GongweiModel> list = db.ExecuteList<GongweiModel>(sql, pList.ToArray());
            return list;
        }


        /// <summary>
        /// 查询 工具类型下拉
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<GongjuModel> GetgongjuAll()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT ID
,gjname as Gjname
,gjImg as GjImg
,gjTypeID as GjTypeID
,gjIsHasCode as GjIsHasCode
,gjStatus  as GjStatus
,remark as Remark
FROM base_gongju
WHERE gjStatus=0
ORDER BY(ID) ";
            List<GongjuModel> gongjus = db.ExecuteList<GongjuModel>(sql, pList.ToArray());
            //using (var context = new RWPMS_DBDataContext())
            //{
            //    var fullgongjus = context.base_gongju.ToList();

            //    List<GongjuModel> gongjus = fullgongjus.Where(x => x.gjStatus != null && x.gjStatus == 0).OrderBy(x => x.ID).Select(gongju => new GongjuModel
            //    {
            //        ID = gongju.ID,
            //        Gjname = gongju.gjname,
            //        GjImg = gongju.gjImg,
            //        GjTypeID = gongju.gjTypeID ?? 0,
            //        GjIsHasCode = gongju.gjIsHasCode ?? 0,
            //        IsHasCodeStatus = gongju.gjIsHasCode.ToString() == "0" ? "否" : "是",
            //        GjStatus = gongju.gjStatus ?? 0,
            //        Status = gongju.gjStatus.ToString() == "0" ? "启用" : "禁用",
            //        Remark = gongju.remark
            //    }).ToList();
            return gongjus;

        }


        /// <summary>
        /// 查询 物料类型下拉
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetwuliaoAll()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "SELECT ID,wlcode,wlname,wlImg,wlTypeID,wlClass,wlStatus,wlIsHasCode,remark FROM base_wuliao";
            List<WuliaoModel> WuliaoModellist = db.ExecuteList<WuliaoModel>(sql, pList.ToArray());
            //using (var context = new RWPMS_DBDataContext())
            //{
            //    var fullwuliaos = context.base_wuliao.ToList();
            //    List<WuliaoModel> wuliaos = fullwuliaos.Where(x => x.wlStatus != null && x.wlStatus == 0).OrderBy(x => x.ID).Select(wuliao => new WuliaoModel
            //    {
            //        ID = wuliao.ID,
            //        wlcode = wuliao.wlcode,
            //        wlname = wuliao.wlname,
            //        wlImg = wuliao.wlImg,
            //        wlTypeID = wuliao.wlTypeID,
            //        wlClass = wuliao.wlClass,
            //        wlStatus = wuliao.wlStatus,
            //        Status = wuliao.wlStatus.ToString() == "0" ? "启用" : "禁用",
            //        wlIsHasCode = wuliao.wlIsHasCode,
            //        IsHasCodeName = wuliao.wlIsHasCode.ToString() == "0" ? "否" : "是",
            //        remark = wuliao.remark
            //    }).ToList();
            //    return wuliaos;
            //}
            return WuliaoModellist;
        }

        /// <summary>
        /// 根据传值入类型查询
        /// </summary>
        /// <returns></returns>
        public BaseDataModel GetTypeById(int id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,IFNULL(bdtypeID,0) AS bdtypeID,bdtypeCode,bdcode,bdname,bdvalue,
                                IFNULL(isDeleted,0) AS isDeleted,remark from sys_baseData where ID=" + id;
            List<BaseDataModel> list = db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
            if (list.Count > 0)
                return list[0];
            else
                return new BaseDataModel();
        }


        #endregion

        #region 部门管理
        public List<DepartmentModel> GetPagingDepartment(DepartmentModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.DeptName))
                {
                    para += " and deptName like @deptName";
                    pList.Add(new MySqlParameter("@deptName", "%" + model.DeptName + "%"));
                }
            }
            string sql = "select Count(*) from sys_department where 1=1" + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);
            sql = "select DeptID,DeptName,DeptNo,DeptLeader,Remark from sys_department where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<DepartmentModel> list = db.ExecuteList<DepartmentModel>(sql, pList.ToArray());
            return list;
        }

        public void AddDepartment(DepartmentModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> Plist = new List<MySqlParameter>();
            string sql = "insert into sys_department(deptNo,deptName,deptLeader,remark)values(@deptNo,@deptName,@deptLeader,@remark)";
            Plist.Add(new MySqlParameter("@deptNo", model.DeptNo));
            Plist.Add(new MySqlParameter("@deptName", model.DeptName));
            Plist.Add(new MySqlParameter("@deptLeader", model.DeptLeader));
            Plist.Add(new MySqlParameter("@remark", model.Remark));
            int i = db.ExecuteNonQuery(sql, Plist.ToArray());
        }

        /// <summary>
        /// 获取部门集合
        /// </summary>
        /// <returns></returns>
        public List<DepartmentModel> GetDepartmentList()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select DeptID,DeptName,DeptNo,DeptLeader,Remark from sys_department";
            List<DepartmentModel> list = db.ExecuteList<DepartmentModel>(sql, pList.ToArray());
            return list;
        }

        //public DepartmentModel GetDepartment(int Id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        return context.sys_department.Where(x => x.deptID == Id).Select(x => new DepartmentModel
        //        {
        //            DeptID = x.deptID,
        //            DeptNo = x.deptNo,
        //            DeptName = x.deptName,
        //            DeptLeader = x.deptLeader,
        //            Remark = x.remark
        //        }).FirstOrDefault();
        //    }
        //}

        public void EditDepartment(DepartmentModel model)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = "update sys_department set deptNo=@deptNo,deptName=@deptName,deptLeader=@deptLeader,remark=@remark where deptID=@deptID";
            plist.Add(new MySqlParameter("@deptNo", model.DeptNo));
            plist.Add(new MySqlParameter("@deptName", model.DeptName));
            plist.Add(new MySqlParameter("@deptLeader", model.DeptLeader));
            plist.Add(new MySqlParameter("@remark", model.Remark));
            plist.Add(new MySqlParameter("@deptID", model.DeptID));
            int i = db.ExecuteNonQuery(sql, plist.ToArray());
        }
        //删除部门
        public void DeleteDepartment(string id)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = "delete from sys_department where deptID in (" + id + ")";
            int i = db.ExecuteNonQuery(sql, plist.ToArray());
        }
        #endregion

        #region 数据字典类型

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<SysbaseDataTypeModel> GetBaseDataTypeList(SysbaseDataTypeModel model, out int totalCount)
        {
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (!string.IsNullOrEmpty(model.typecode))
            {
                para += "and typecode like concat('%',@typecode,'%') ";
                pList.Add(new MySqlParameter("@typecode", model.typecode));
            }

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            string sql = "select count(*) from sys_baseDataType where 1=1 " + para;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select * from sys_baseDataType where 1=1 ";
            sql += para;
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            return db.ExecuteList<SysbaseDataTypeModel>(sql, pList.ToArray());
        }


        /// <summary>
        /// 查询  数据字典类型下拉
        /// </summary>
        /// <returns></returns>
        public List<SysbaseDataTypeModel> GetBaseDataTypeList(SysbaseDataTypeModel model = null)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_baseDataType where 1=1 ";
            if (model != null)
            {
                if (model.ID != 0)
                {
                    sql += " and ID = @ID ";
                    pList.Add(new MySqlParameter("@ID", model.ID));
                }

                if (!string.IsNullOrEmpty(model.typecode))
                {
                    sql += " and typecode = @typecode ";
                    pList.Add(new MySqlParameter("@typecode", model.typecode));
                }

                if (!string.IsNullOrEmpty(model.typename))
                {
                    sql += " and typename like concat('%',@typename,'%') ";
                    pList.Add(new MySqlParameter("@typename", model.typename));
                }

            }
            return db.ExecuteList<SysbaseDataTypeModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseDataType(SysbaseDataTypeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into sys_baseDataType(typecode,typename,typememo,remark) 
                            values(@typecode,@typename,@typememo,@remark)";
            pList.Add(new MySqlParameter("@typecode", model.typecode));
            pList.Add(new MySqlParameter("@typename", model.typename));
            pList.Add(new MySqlParameter("@typememo", model.typememo));
            pList.Add(new MySqlParameter("@remark", model.remark));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseDataType(SysbaseDataTypeModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"update sys_baseDataType set typecode=@typecode,typename=@typename,typememo=@typememo,remark=@remark where ID=@ID";
            pList.Add(new MySqlParameter("@ID", model.ID));
            pList.Add(new MySqlParameter("@typecode", model.typecode));
            pList.Add(new MySqlParameter("@typename", model.typename));
            pList.Add(new MySqlParameter("@typememo", model.typememo));
            pList.Add(new MySqlParameter("@remark", model.remark));
            int i = db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public int DeleteBaseDataType(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select count(1) from sys_baseData where isDeleted = 0 and bdtypeID in(" + id + ")";
            int count = 1;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out count);
            if (count == 0)
            {
                sql = "delete from sys_baseDataType where ID in(" + id + ")";
                int i = db.ExecuteNonQuery(sql, pList.ToArray());
                return i;
            }
            return count;
        }
        #endregion

        #region  参数配置
        /// <summary>
        /// 分页查询 添加isDeleted为0条件 2019-4-19
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<SysconfigModel> GetPagingSysConfig(SysconfigModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string para = "";
            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.cfg_code))
                {
                    para += " and cfg_code like @cfg_code";
                    plist.Add(new MySqlParameter("@cfg_code", "%" + model.cfg_code + "%"));
                }
            }
            string sql = "select Count(*) from sys_config where isDeleted=0 " + para;

            int.TryParse(db.ExecuteScalar(sql, plist.ToArray()) + "", out totalCount);
            sql = "select * from sys_config where isDeleted=0 " + para;

            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<SysconfigModel> list = db.ExecuteList<SysconfigModel>(sql, plist.ToArray());
            return list;
        }
        /// <summary>
        /// 根据Code返回Value
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public string GetValueByCode(string strCode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select cfg_value from sys_config where cfg_code='" + strCode + "'";
            return db.ExecuteScalar(sql, pList.ToArray()) + "";
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddSysConfig(SysconfigModel model)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = "insert into sys_config(cfg_code,cfg_value,desp,isDeleted,remark) values(@cfg_code,@cfg_value,@desp,@isDeleted,@remark)";
            plist.Add(new MySqlParameter("@cfg_code", model.cfg_code));
            plist.Add(new MySqlParameter("@cfg_value", model.cfg_value));
            plist.Add(new MySqlParameter("@desp", model.desp));
            plist.Add(new MySqlParameter("@isDeleted", model.isDeleted));
            plist.Add(new MySqlParameter("@remark", model.remark));
            int i = db.ExecuteNonQuery(sql, plist.ToArray());
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //public SysconfigModel GetSysConfigId(int Id)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        return context.sys_config.Where(x => x.ID == Id && x.isDeleted == 0).Select(x => new SysconfigModel
        //        {
        //            ID = x.ID,
        //            cfg_code = x.cfg_code,
        //            cfg_value = x.cfg_value,
        //            desp = x.desp,
        //            remark = x.remark
        //        }).FirstOrDefault();
        //    }
        //}

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditSysConfig(SysconfigModel model)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = "update sys_config set cfg_code=@cfg_code,cfg_value=@cfg_value,desp=@desp,remark=@remark where ID=@ID";
            plist.Add(new MySqlParameter("@cfg_code", model.cfg_code));
            plist.Add(new MySqlParameter("@cfg_value", model.cfg_value));
            plist.Add(new MySqlParameter("@desp", model.desp));
            plist.Add(new MySqlParameter("@remark", model.remark));
            plist.Add(new MySqlParameter("@ID", model.ID));
            int i = db.ExecuteNonQuery(sql, plist.ToArray());
        }

        /// <summary>
        /// 删除 【调整为逻辑删除 把isDeleted设置为1】
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSysConfig(string id)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> plist = new List<MySqlParameter>();
            string sql = "update sys_config set isDeleted=1 where ID in (" + id + ")";
            int i = db.ExecuteNonQuery(sql, plist.ToArray());
        }
        #endregion

        #region 软件更新上传
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<SysexeFileUpdateModel> GetPagingSysexeFileUpdate(SysexeFileUpdateModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "";

            sql = "select count(*) from sys_exeFileUpdate ";
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = "select * from sys_exeFileUpdate ";
            sql += "limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            return db.ExecuteList<SysexeFileUpdateModel>(sql, pList.ToArray());
        }

        /// <summary>
        /// 保存软件更新上传文件
        /// </summary>
        /// <param name="model"></param>
        public void SaveSysExeFileUpdate(SysexeFileUpdateModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_exeFileUpdate where filesName=@filesName";
            pList.Add(new MySqlParameter("@filesName", model.filesName));
            List<SysexeFileUpdateModel> list = db.ExecuteList<SysexeFileUpdateModel>(sql, pList.ToArray());
            if (list.Count > 0)
            {
                sql = @"update sys_exeFileUpdate set filesName=@filesName,fileType=@fileType,versionNuber=@versionNuber,uploadTime=@uploadTime,
                                filePath=@filePath,remark=@remark where fID=@fID";
                pList.Clear();
                pList.Add(new MySqlParameter("@filesName", model.filesName));
                pList.Add(new MySqlParameter("@fileType", model.fileType));
                pList.Add(new MySqlParameter("@versionNuber", model.versionNuber));
                pList.Add(new MySqlParameter("@uploadTime", model.uploadTime));
                pList.Add(new MySqlParameter("@filePath", model.filePath));
                pList.Add(new MySqlParameter("@remark", model.remark));
                pList.Add(new MySqlParameter("@fID", list[0].fID));
                db.ExecuteNonQuery(sql, pList.ToArray());
                return;
            }
            else
            {
                sql = @"insert into sys_exeFileUpdate(filesName,fileType,versionNuber,uploadTime,filePath,remark)
                                values(@filesName,@fileType,@versionNuber,@uploadTime,@filePath,@remark)";
                pList.Clear();
                pList.Add(new MySqlParameter("@filesName", model.filesName));
                pList.Add(new MySqlParameter("@fileType", model.fileType));
                pList.Add(new MySqlParameter("@versionNuber", model.versionNuber));
                pList.Add(new MySqlParameter("@uploadTime", model.uploadTime));
                pList.Add(new MySqlParameter("@filePath", model.filePath));
                pList.Add(new MySqlParameter("@remark", model.remark));
                db.ExecuteNonQuery(sql, pList.ToArray());
                return;
            }
        }
        /// <summary>
        /// 获取客户端安装包
        /// </summary>
        /// <returns></returns>
        public SysexeFileUpdateModel GetSysUpdateFile()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            SysexeFileUpdateModel model = GetSysUpdateFilesSel().Where(x => x.filesName == "生产过程控制管理系统.msi").FirstOrDefault();
            return model;
        }

        /// <summary>
        /// 获取文件更新所有数据
        /// </summary>
        /// <returns></returns>
        public List<SysexeFileUpdateModel> GetSysUpdateFilesSel()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select * from sys_exeFileUpdate";
            List<SysexeFileUpdateModel> list = db.ExecuteList<SysexeFileUpdateModel>(sql, pList.ToArray());
            return list;
        }
        #endregion

        #region 考勤信息

        /// <summary>
        /// 查询考勤信息 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<LoginInfoModel> LoginInfoForPage(LoginInfoModel model, out int totalCount)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            var serTime = GetDateTime();
            //string sql = @"SELECT empID,empName,
            //                 YEAR (logintime) dateYear,
            //                 MONTH (logintime) dateMonth,
            //                 DAY (logintime) dateDay,
            //                 min(logintime) logintime,
            //                 max(unregisttime) unregisttime,
            //                 TIMESTAMPDIFF(hour,min(logintime),max(unregisttime)) TimeCount 
            //                FROM  sys_loginInfo
            //                GROUP BY empID,empName,YEAR (logintime),MONTH (logintime),DAY (logintime)";
            string sql = @"SELECT su.empNo,slf.empID,slf.empName,
	                            YEAR (slf.logintime) dateYear,
	                            MONTH (slf.logintime) dateMonth,
	                            DAY (slf.logintime) dateDay,
	                            min(slf.logintime) logintime,
	                            max(slf.unregisttime) unregisttime,
	                            TIMESTAMPDIFF(hour,min(slf.logintime),max(slf.unregisttime)) TimeCount 
                            FROM  sys_loginInfo slf
							left join sys_user su on slf.empID = su.userID
                            GROUP BY slf.empID,slf.empName,YEAR (slf.logintime),MONTH (slf.logintime),DAY (slf.logintime)";
            List<LoginInfoModel> list = db.ExecuteList<LoginInfoModel>(sql, pList.ToArray());
            if (list != null)
            {
                if (model.empID != 0 && model.empID != null)
                {
                    list = list.Where(x => x.empID == model.empID).ToList();
                }
                if (model.queryType == "0" && model.queryType != null)
                {
                    if (model.ddldate == "day")
                    {
                        list = list.Where(x => x.logintime.Value.Year == serTime.Year && x.logintime.Value.Month == serTime.Month && x.logintime.Value.Day == serTime.Day).ToList();
                    }
                    else if (model.ddldate == "month")
                    {
                        list = list.Where(x => x.logintime.Value.Year == serTime.Year && x.logintime.Value.Month == serTime.Month).ToList();
                    }
                    else
                    {
                        list = list.Where(x => x.logintime.Value.Year == serTime.Year).ToList();
                    }
                }
                else if (model.queryType == "1" && model.queryType != null)
                {
                    if (!string.IsNullOrEmpty(model.starttime) && !string.IsNullOrEmpty(model.endtime))
                    {
                        var starttime = DateTime.Parse(model.starttime);
                        var endtime = Convert.ToDateTime(model.endtime).AddDays(1).AddSeconds(-1);
                        list = list.Where(x => x.logintime >= starttime && x.unregisttime <= endtime).ToList();
                    }
                }
            }
            totalCount = list.Count();
            List<LoginInfoModel> LoginInfoList = list.OrderByDescending(x => x.logintime).Skip(model.PageSize * (model.PageIndex - 1)).Take(model.PageSize).ToList();
            return LoginInfoList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //public List<UserModel> GetEmployee()
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var query = QueryUserInfo(context);
        //        query = query.Where(x => true);
        //        var result = query.ToList();
        //        return result;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        //private IQueryable<UserModel> QueryUserInfo(RWPMS_DBDataContext context)
        //{
        //    var query = context.sys_User.
        //        OrderBy(order => order.userID).
        //        Select(user => new UserModel
        //        {
        //            userID = user.userID,
        //            userName = user.userName,
        //            pwd = user.pwd,
        //            empNo = user.empNo,
        //            empName = user.empName,
        //            roleID = user.roleID ?? 0,
        //            deptID = user.deptID ?? 0,
        //            phone = user.phone,
        //            sex = user.sex ?? -1,
        //            birthday = user.birthday,
        //            registtime = user.registtime,
        //            inStatus = user.inStatus ?? 0,
        //            cardNo = user.cardNo,
        //            headPortrait = user.headPortrait,
        //            remark = user.remark,
        //            deleted = user.deleted ?? 0
        //        });
        //    return query;
        //}

        /// <summary>
        /// 添加 考勤信息
        /// </summary>
        /// <param name="model"></param>
        public int AddLoginInfo(LoginInfoModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"insert into sys_loginInfo(empID,empName,logintime,unregisttime,hostName,remark) 
                            values(@empID,@empName,@logintime,@unregisttime,@hostName,@remark)";
            pList.Add(new MySqlParameter("@empID", model.empID));
            pList.Add(new MySqlParameter("@empName", model.empName));
            pList.Add(new MySqlParameter("@logintime", model.logintime));
            pList.Add(new MySqlParameter("@unregisttime", model.unregisttime));
            pList.Add(new MySqlParameter("@hostName", model.hostName));
            pList.Add(new MySqlParameter("@remark", model.remark));
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }

        /// <summary>
        /// 保存登出时间.
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>数据库受影响行数</returns>
        public int SaveLogoutTime(int userID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID from sys_logininfo where empID=1 order by logintime desc";
            int ID = 0;
            object obj = db.ExecuteScalar(sql, pList.ToArray());
            int.TryParse(obj + "", out ID);
            if (ID == 0) return 0;
            sql = @"update sys_loginInfo set unregisttime=now() where ID=" + ID;
            return db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion

        #region 用户工位权限设置
        /// <summary>
        /// 获取所有工位权限类型
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetGwRightType()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select ID,bdname from sys_baseData where bdtypeCode='GwRightType'";
            List<BaseDataModel> list = db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
            return list;
        }
        /// <summary>
        /// 根据用户和工位获取工位权限执行类型
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="gwID">工位ID</param>
        /// <param name="rightTypeID">工位权限执行类型ID</param>
        /// <returns></returns>
        public string GetRightType(int UserID, int gwID, int rightTypeID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string para = "";
            if (UserID != 0)
            {
                para += "and  empID=@empID ";
                pList.Add(new MySqlParameter("@empID", UserID));
            }
            if (gwID != 0)
            {
                para += "and  gwID=@gwID ";
                pList.Add(new MySqlParameter("@gwID", gwID));
            }
            if (rightTypeID != 0)
            {
                para += "and  rightTypeID=@rightTypeID ";
                pList.Add(new MySqlParameter("@rightTypeID", rightTypeID));
            }
            string sql = @"select rightTypeID from base_gongweiRight where 1=1 " + para;
            string rightType = db.ExecuteScalar(sql, pList.ToArray()) + "";
            return rightType;
        }
        /// <summary>
        /// 用户工位授权
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="RoleId"></param>
        public void EditUserGwAuthority(Dictionary<string, BaseGongweiRightModel> dic, int UserID)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            //先删除再添加
            List<MySqlParameter> pL = new List<MySqlParameter>();
            string sql = "delete from base_gongweiRight where empID=" + UserID;
            int i = db.ExecuteNonQuery(sql, pL.ToArray());

            foreach (KeyValuePair<string, BaseGongweiRightModel> key in dic)
            {
                BaseGongweiRightModel model = key.Value;

                List<MySqlParameter> pList = new List<MySqlParameter>();
                string innsertsql = @"insert into base_gongweiRight(gwID,empID,rightTypeID,gwrStatus) 
                                                values(@gwID,@empID,@rightTypeID,@gwrStatus)";
                pList.Add(new MySqlParameter("@gwID", model.gwID));
                pList.Add(new MySqlParameter("@empID", model.empID));
                pList.Add(new MySqlParameter("@rightTypeID", model.rightTypeID));
                pList.Add(new MySqlParameter("@gwrStatus", model.gwrStatus));
                db.ExecuteNonQuery(innsertsql, pList.ToArray());
            }
        }

        #endregion

        #region 添加消息提醒数据 WZQ
        /// <summary>
        /// 添加消息提醒数据
        /// <param name="model">消息内容实体</param>
        /// </summary>
        public bool AddMsgContent(BaseMsgContentModel model)
        {
            using (MySqlConnection myConnection = new MySqlConnection(RW.PMS.Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                MySqlTransaction myTrans = myConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                List<MySqlParameter> pList = new List<MySqlParameter>();
                RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
                int i = 0;
                string sql = "";
                try
                {
                    //获取服务器时间
                    var serveTime = db.GetServerTime();
                    string CreateTime = serveTime.ToString("yyyy-MM-dd");
                    //查询当前消息提醒内容当天是否有数据添加
                    sql = "SELECT *,date(mcCreateTime) as CreateTime from base_msgcontent where mcTitle=@mcTitle and mcContent=@mcContent and date(mcCreateTime)=@CreateTime";
                    pList.Add(new MySqlParameter("@mcTitle", model.mcTitle));
                    pList.Add(new MySqlParameter("@mcContent", model.mcContent));
                    pList.Add(new MySqlParameter("@CreateTime", CreateTime));
                    var dtTab = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());

                    if (dtTab.Rows.Count == 0)
                    {
                        sql = @"insert into base_msgcontent(mcTitle,mcContent,mcTypeID,mcLevel,mcUrl,mcRemark,mcDeleteFlag,mcCreateTime,mcCreaterID,
                                        mcUpdateTime,mcUpdaterID)values(@mcTitle,@mcContent,@mcTypeID,@mcLevel,@mcUrl,@mcRemark,@mcDeleteFlag,@mcCreateTime,@mcCreaterID,
                                        @mcUpdateTime,@mcUpdaterID)";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@mcTitle", model.mcTitle));
                        pList.Add(new MySqlParameter("@mcContent", model.mcContent));
                        pList.Add(new MySqlParameter("@mcTypeID", model.mcTypeID));
                        pList.Add(new MySqlParameter("@mcLevel", model.mcLevel));
                        pList.Add(new MySqlParameter("@mcUrl", model.mcUrl));
                        pList.Add(new MySqlParameter("@mcRemark", model.mcRemark));
                        pList.Add(new MySqlParameter("@mcDeleteFlag", model.mcDeleteFlag ?? 0));
                        pList.Add(new MySqlParameter("@mcCreateTime", serveTime));
                        pList.Add(new MySqlParameter("@mcCreaterID", model.mcCreaterID));
                        pList.Add(new MySqlParameter("@mcUpdateTime", serveTime));
                        pList.Add(new MySqlParameter("@mcUpdaterID", model.mcUpdaterID));
                        i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());

                        //获取自增长ID
                        int mcID = 0;
                        pList.Clear();
                        sql = "select @@identity";
                        int.TryParse(RW.PMS.Common.MySqlHelper.ExecuteScalar(myTrans, CommandType.Text, sql, pList.ToArray()) + "", out mcID);

                        //根据消息类型查找用户组
                        sql = "select * from base_rel_msguser where rmuMsgTypeId=@rmuMsgTypeId";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@rmuMsgTypeId", model.mcTypeID));
                        var RelMsgUser = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                        List<BaseRelMsgUserModel> rellist = db.ToList<BaseRelMsgUserModel>(RelMsgUser);
                        var uGroupID = rellist.Count > 0 ? string.Join(",", rellist.Select(x => x.rmuUGroupId)) : "0";
                        if (uGroupID == "0")
                        {
                            myTrans.Rollback();
                            return false;
                        }
                        //根据用户组查找人员用户
                        sql = @"select ugdUserId,GetEmpNameByuID(ugdUserId) EmpName from base_usergroupdetail where ugID in(" + uGroupID + ") GROUP BY ugdUserId";
                        pList.Clear();
                        var usTable = RW.PMS.Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
                        if (usTable.Rows.Count == 0)
                        {
                            myTrans.Rollback();
                            return false;
                        }
                        int? defaultFlag = 0;
                        //循环下发提醒
                        foreach (DataRow item in usTable.Rows)
                        {
                            sql = "insert into base_msg(mcID,msResponderID,msReadFlag,msAutoFlag)values(@mcID,@msResponderID,@msReadFlag,@msAutoFlag)";
                            pList.Clear();
                            pList.Add(new MySqlParameter("@mcID", mcID));
                            pList.Add(new MySqlParameter("@msResponderID", item["ugdUserId"] ?? 0));
                            pList.Add(new MySqlParameter("@msReadFlag", defaultFlag));
                            pList.Add(new MySqlParameter("@msAutoFlag", 1));
                            i = RW.PMS.Common.MySqlHelper.ExecuteNonQuery(myTrans, CommandType.Text, sql, pList.ToArray());
                        }
                    }
                    myTrans.Commit();
                }
                catch (Exception)
                {
                    myTrans.Rollback();
                    return false;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return i > 0;
            }
        }
        #endregion

        #region CS端

        /// <summary>
        /// 根据Code查询 参数配置表中数据
        /// </summary>
        /// <param name="cfgcode"></param>
        /// <returns></returns>
        public SysconfigModel GetConfigByCode(string cfgcode)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "select * from sys_config where isDeleted=0 and cfg_code=@cfg_code";
            pList.Add(new MySqlParameter("@cfg_code", cfgcode));
            List<SysconfigModel> list = db.ExecuteList<SysconfigModel>(sql, pList.ToArray());
            if (list.Count > 0) return list[0];
            return null;
        }

        /// <summary>
        /// 根据字典编码获取ID
        /// </summary>
        /// <param name="bdcode"></param>
        /// <returns></returns>
        public int GetBaseDataId(string bdcode)
        {
            var BDId = GetbaseData().Where(x => x.bdcode == bdcode).FirstOrDefault().ID;
            return BDId;
        }

        /// <summary>
        /// 根据当前区域CODE获取上一区域id
        /// </summary>
        /// <param name="bdcode"></param>
        /// <returns></returns>
        public int GetBeforeAreaIDByCode(string bdcode)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select b.ID from sys_baseData a left join sys_baseData b on a.bdvalue=b.bdcode where a.bdcode='" + bdcode +
                "' and a.bdtypeCode='gwArea'";
            int ret = 0;
            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out ret);
            return ret;
        }

        /// <summary>
        /// 根据ID获取数据字典数据实体类
        /// </summary>
        /// <param name="baseDataID"></param>
        /// <returns></returns>
        public BaseDataModel getBaseDataByID(int baseDataID)
        {
            RW.PMS.Common.MySqlHelper db = new Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"select * from sys_baseData where ID=" + baseDataID;
            var list = db.ExecuteList<BaseDataModel>(sql, pList.ToArray());
            if (list.Count > 0)
                return list[0];
            return null;
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {

            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>();

            string sql = @"select now()";

            string strNow = db.ExecuteScalar(sql, pList.ToArray()) + "";

            DateTime now = DateTime.Now;

            DateTime.TryParse(strNow, out now);

            return now;
        }

        public static DateTime GetServerDateTime()
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();

            List<MySqlParameter> pList = new List<MySqlParameter>(); 

            string sql = @"select now()";

            string strNow = db.ExecuteScalar(sql, pList.ToArray()) + "";

            DateTime now = DateTime.Now;

            DateTime.TryParse(strNow, out now);

            return now;
        }

        /// <summary>
        /// 获取多个系统参数值
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        //public List<KeyValuePair<string, string>> GetConfigs(params string[] codes)
        //{
        //    using (var context = new RWPMS_DBDataContext())
        //    {
        //        var values = context.sys_config.Where(f => codes.Contains(f.cfg_code)).Select(f => new { f.cfg_code, f.cfg_value }).ToList();
        //        var result = values.Select(f => new KeyValuePair<string, string>(f.cfg_code, f.cfg_value)).ToList();
        //        return result;
        //    }
        //}

        #endregion

        #region 流水号

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <param name="strTableName">数据库表名</param>
        /// <param name="strPrefix">流水号前缀</param>
        /// <param name="intNumCount">流水号位数</param>
        /// <returns>字符串流水号</returns>
        public string GetSerialNumber(string strTableName, string strPrefix, int intNumCount)
        {
            Common.MySqlHelper db = new Common.MySqlHelper();
            return db.GetSerialNumber(strTableName, strPrefix, intNumCount);
        }

        #endregion

        #region 库存信息

        /// <summary>
        /// 库存分页信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<InventoryModel> GetInventoryPage(InventoryModel model, out int totalCount)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var para = string.Empty;

            if (model.wlmodelID.HasValue)
            {
                para += " and inve.wlModelID=@wlModelID ";
                pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
            }

            if (model.warehouseID.HasValue)
            {
                para += " and inve.warehouseID=@warehouseID";
                pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            }

            string sql = @"select count(*)  from material_inventory inve
                                   where 1=1" + para;

            int.TryParse(db.ExecuteScalar(sql, pList.ToArray()) + "", out totalCount);

            sql = @"select inve.*,wl.mName as wlcodeModel,(CASE
                            when inve.warehouseID=1 then '线边库' 
                            when inve.warehouseID=2 then '库房' else '其他' end) warehouseName  
                            from material_inventory inve
                            left join base_material wl on inve.wlmodelID = wl.ID
                            where 1=1 " + para;
            sql += " limit " + model.PageSize * (model.PageIndex - 1) + "," + model.PageSize;
            List<InventoryModel> list = db.ExecuteList<InventoryModel>(sql, pList.ToArray());
            return list;
        }

        /// <summary>
        /// 判断该规格和仓库是否存在
        /// </summary>
        /// <param name="wlModelID">物料规格ID</param>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        public bool IsExistInventory(int wlModelID, int warehouseID)
        {
            var db = new Common.MySqlHelper();
            var pList = new List<MySqlParameter>();
            var para = string.Empty;

            if (wlModelID != 0)
            {
                para += " and wlModelID=@wlModelID ";
                pList.Add(new MySqlParameter("@wlModelID", wlModelID));
            }
            if (warehouseID != 0)
            {
                para += " and warehouseID=@warehouseID ";
                pList.Add(new MySqlParameter("@warehouseID", warehouseID));
            }
            string sql = @"select count(*) from material_inventory  where 1=1 " + para;
            var obj = db.ExecuteScalar(sql, pList.ToArray());
            var count = 0;
            int.TryParse(obj + "", out count);
            if (count >= 1)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 添加/修改库存信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        public int SaveInventory(InventoryModel model)
        {
            using (var myConnection = new MySqlConnection(Common.MySqlHelper.ConnectionString))
            {
                myConnection.Open();
                var myTrans = myConnection.BeginTransaction(IsolationLevel.ReadCommitted);
                int ret = 0;
                try
                {
                    var pList = new List<MySqlParameter>();
                    var sql = string.Empty;

                    DateTime serverTime = GetServerDateTime();

                    if (model.ID == 0)
                    {
                        #region 新增

                        sql = @"insert into material_inventory(wlModelID,warehouseID,actualInventory) values(@wlModelID,@warehouseID,@actualInventory) ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
                        pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        pList.Add(new MySqlParameter("@actualInventory", model.actualInventory));
                        ret = Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());


                        //string sql2 = @"insert into base_inventorylog(wlModelID,warehouseID,changeType,changeQty,beforeQty,afterQty,userID,gwID,logTime) 
                        //                    values(@wlModelID,@warehouseID,@changeType,@changeQty,@beforeQty,@afterQty,@userID,@gwID,@logTime)";
                        //pList.Clear();
                        //pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
                        //pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        //pList.Add(new MySqlParameter("@changeType", 1));
                        //pList.Add(new MySqlParameter("@changeQty", model.actualInventory));
                        //pList.Add(new MySqlParameter("@beforeQty", 0));
                        //pList.Add(new MySqlParameter("@afterQty", model.actualInventory));
                        //pList.Add(new MySqlParameter("@userID", model.userID));
                        //pList.Add(new MySqlParameter("@gwID", 0));
                        //pList.Add(new MySqlParameter("@logTime", serverTime));
                        //ret = Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql2, pList.ToArray());

                        #endregion
                    }
                    else
                    {
                        #region 编辑

                        //没修改前原来实际数量
                        int actualInventory = 0;
                        var obj = Common.MySqlHelper.ExecuteScalar(myTrans, System.Data.CommandType.Text
                            , "select actualInventory from material_inventory where ID=" + model.ID, null);

                        int.TryParse(obj + "", out actualInventory);

                        sql = @"update material_inventory set wlModelID=@wlModelID,warehouseID=@warehouseID,actualInventory=@actualInventory  where ID=@ID ";
                        pList.Clear();
                        pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
                        pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        pList.Add(new MySqlParameter("@actualInventory", model.actualInventory));
                        pList.Add(new MySqlParameter("@ID", model.ID));
                        ret = Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

                        //string sql2 = @"insert into base_inventorylog(wlModelID,warehouseID,changeType,changeQty,beforeQty,afterQty,userID,gwID,logTime) 
                        //                        values(@wlModelID,@warehouseID,@changeType,@changeQty,@beforeQty,@afterQty,@userID,@gwID,@logTime)";

                        //int changeQty = 0;

                        //int qty = model.actualInventory ?? 0; //实际数量

                        //if (actualInventory == qty)
                        //{
                        //    actualInventory = qty;
                        //    changeQty = model.actualInventory ?? 0 - actualInventory;
                        //}

                        //if (qty > actualInventory || qty < actualInventory)
                        //{
                        //    changeQty = qty - actualInventory;
                        //}
                         
                        //pList.Clear();
                        //pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
                        //pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
                        //pList.Add(new MySqlParameter("@changeType", 1));
                        //pList.Add(new MySqlParameter("@changeQty", changeQty));
                        //pList.Add(new MySqlParameter("@beforeQty", actualInventory));
                        //pList.Add(new MySqlParameter("@afterQty", model.actualInventory));
                        //pList.Add(new MySqlParameter("@userID", model.userID));
                        //pList.Add(new MySqlParameter("@gwID", 0));
                        //pList.Add(new MySqlParameter("@logTime", serverTime));
                        //ret = Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql2, pList.ToArray());
                        #endregion
                    }
                    myTrans.Commit();
                }
                catch
                {
                    myTrans.Rollback();
                    return 0;
                }
                finally
                {
                    myTrans.Dispose();
                }
                return ret;
            }
        }

        /// <summary>
        /// 通用库存操作方法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="myTrans"></param>
        /// <returns></returns>
        public int EditInventory(InventoryModel model, MySqlTransaction myTrans)
        {
            var pList = new List<MySqlParameter>();
            var sql = string.Empty;
            int i = 0;//受影响的行数

            sql = @"select * from material_inventory where wlmodelID=@wlmodelID and warehouseID=@warehouseID";
            pList.Add(new MySqlParameter("@wlmodelID", model.wlmodelID));
            pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            DataTable dtInv = Common.MySqlHelper.ExecuteDataTable(myTrans, CommandType.Text, sql, pList.ToArray());
            if (dtInv.Rows.Count > 1) return 0;
            if (dtInv.Rows.Count == 0 && model.changeInventory < 0) return 0;
            if (dtInv.Rows.Count == 1 && dtInv.Rows[0]["actualInventory"].ToInt() <= 0) return -1;
            if (dtInv.Rows.Count == 1 && (dtInv.Rows[0]["actualInventory"].ToInt() + model.changeInventory) < 0) return -1;

            int beforeQty = 0; //变化前数量
            if (dtInv.Rows.Count == 1)
                beforeQty = dtInv.Rows[0]["actualInventory"].ToInt();

            InventoryModel logModel = new InventoryModel();
            logModel.wlmodelID = model.wlmodelID;
            logModel.warehouseID = model.warehouseID;
            logModel.changeType = model.changeType;
            logModel.changeQty = model.changeInventory;
            logModel.beforeQty = beforeQty;
            logModel.afterQty = beforeQty + model.changeInventory;
            logModel.userID = model.userID;
            logModel.gwID = model.gwID;

            //若变化数量大于0且数据库内无库存数据
            if (model.changeInventory > 0 && dtInv.Rows.Count == 0)
                sql = @"insert into material_inventory(wlModelID,warehouseID,actualInventory) values(@wlModelID,@warehouseID,@actualInventory) ";
            else
                sql = @"update material_inventory set actualInventory=@actualInventory where wlmodelID=@wlmodelID and warehouseID=@warehouseID";
            pList.Clear();
            pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
            pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            pList.Add(new MySqlParameter("@actualInventory", logModel.afterQty));
            i += Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());

            #region 新增库存变更日志
            i += AddInventoryLog(logModel, myTrans);
            #endregion

            return i;
        }

        /// <summary>
        /// 通用库存记录Log操作方法
        /// </summary>
        /// <param name="model"></param>
        /// <param name="myTrans"></param>
        /// <returns></returns>
        public int AddInventoryLog(InventoryModel model, MySqlTransaction myTrans)
        {
            var pList = new List<MySqlParameter>();
            var sql = string.Empty;
            int ret = 0;//受影响的行数

            sql = @"insert into base_inventorylog(wlModelID,warehouseID,changeType,changeQty,beforeQty,afterQty,userID,gwID,logTime) 
                                            values(@wlModelID,@warehouseID,@changeType,@changeQty,@beforeQty,@afterQty,@userID,@gwID,now())";
            pList.Clear();
            pList.Add(new MySqlParameter("@wlModelID", model.wlmodelID));
            pList.Add(new MySqlParameter("@warehouseID", model.warehouseID));
            pList.Add(new MySqlParameter("@changeType", model.changeType));
            pList.Add(new MySqlParameter("@changeQty", model.changeQty));
            pList.Add(new MySqlParameter("@beforeQty", model.beforeQty));
            pList.Add(new MySqlParameter("@afterQty", model.afterQty));
            pList.Add(new MySqlParameter("@userID", model.userID));
            pList.Add(new MySqlParameter("@gwID", model.gwID));
            ret = Common.MySqlHelper.ExecuteNonQuery(myTrans, System.Data.CommandType.Text, sql, pList.ToArray());
            return ret;
        }



        #endregion

        #region 日志信息
        public List<SysLogModel> GetSysLog(string startTime, string endTime)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = @"SELECT * FROM sys_log WHERE 1=1 ";
            if (!string.IsNullOrEmpty(startTime))
            {
                var starttime = DateTime.Parse(startTime);
                sql += " AND datetime>=@starttime";
                pList.Add(new MySqlParameter("@starttime", starttime));
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                var endtime = DateTime.Parse(endTime).AddDays(+1).AddSeconds(-1);
                sql += " AND datetime<=@Endtime";
                pList.Add(new MySqlParameter("@Endtime", endtime));
            }
            sql += " ORDER BY ID DESC";
            List<SysLogModel> query = db.ExecuteList<SysLogModel>(sql, pList.ToArray());
            return query;
        }

        public void AddSysLog(SysLogModel model)
        {
            RW.PMS.Common.MySqlHelper db = new RW.PMS.Common.MySqlHelper();
            List<MySqlParameter> pList = new List<MySqlParameter>();
            string sql = "INSERT INTO sys_log(empName,excuteResult,description,datetime,formulaCode) VALUES(@empName,@excuteResult,@description,@datetime,@formulaCode)";
            pList.Add(new MySqlParameter("@empName", model.empName));
            pList.Add(new MySqlParameter("@excuteResult", model.excuteResult));
            pList.Add(new MySqlParameter("@description", model.description));
            pList.Add(new MySqlParameter("@datetime", model.datetime));
            pList.Add(new MySqlParameter("@formulaCode", model.formulaCode));
            db.ExecuteNonQuery(sql, pList.ToArray());
        }

        #endregion
    }
}