using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;

namespace RW.PMS.BLL
{
    internal class BLL_System : IBLL_System
    {
        private IDAL_System _DAl = null;
        public BLL_System()
        {
            _DAl = DIService.GetService<IDAL_System>();
        }

        #region 用户信息
        public UserModel GetUser(UserModel model)
        {
            return _DAl.GetUser(model);
        }

        public List<UserModel> GetUserList(UserModel model = null)
        {
            if (model == null) model = new UserModel();
            return _DAl.GetUserList(model);
        }

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户信息实体类</param>
        public void AddUsers(UserModel model)
        {
            _DAl.AddUsers(model);
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户信息实体类</param>
        public void EditUsers(UserModel model)
        {
            _DAl.EditUsers(model);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        public void DeleteUsers(string id)
        {
            _DAl.DeleteUsers(id);
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
            return _DAl.GetRoleList(model, out totalCount);
        }
        public List<RoleModel> GetRoleList(RoleModel model)
        {
            return _DAl.GetRoleList(model);
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="model"></param>
        public void AddRole(RoleModel model)
        {
            _DAl.AddRole(model);
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="model"></param>
        public void EditRole(RoleModel model)
        {
            _DAl.EditRole(model);
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRole(string id)
        {
            _DAl.DeleteRole(id);
        }

        #endregion

        #region 角色权限

        /// <summary>
        /// 获取所有菜单信息
        /// </summary>
        /// <returns></returns>
        public List<MenuModel> GetMenuList(MenuModel model = null)
        {
            return _DAl.GetMenuList(model);
        }

        public List<MenuTreeModel> GetMenuAllList(MenuTreeModel model = null)
        {
            return _DAl.GetMenuAllList(model);
        }

        /// <summary>
        /// 获取菜单树形权限
        /// </summary>
        /// <param name="roleID">权限ID</param>
        /// <returns></returns>
        public List<TreeEntity> GetMenuTreeList(int roleID)
        {
            return _DAl.GetMenuTreeList(roleID);
        }

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleMenuModel> GetAuthValueByRoleId(int roleId)
        {
            return _DAl.GetAuthValueByRoleId(roleId);
        }

        /// <summary>
        /// 角色授权
        /// </summary>
        /// <param name="models"></param>
        /// <param name="roleId"></param>
        public void EditRoleMenuDef(List<RoleMenuModel> models, int roleId)
        {
            _DAl.EditRoleMenuDef(models, roleId);
        }


        /// <summary>
        /// EleTree 角色授权树保存
        /// </summary>
        /// <param name="models">权限实体集合</param>
        /// <param name="roleId">角色ID</param>
        public void SaveRoleMenuDef(List<RoleMenuModel> models, int roleId)
        {
            _DAl.SaveRoleMenuDef(models, roleId);
        }

        /// <summary>
        /// 获取菜单权限类型信息
        /// </summary>
        /// <returns></returns>
        public List<MenuAuth> GetMenuAuth()
        {
            return _DAl.GetMenuAuth();
        }


        #endregion

        #region 菜单管理

        /// <summary>
        /// 查询与分页
        /// LHR 2019-3-6 更新
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="totalCount">返回 总页数</param>
        /// <returns></returns>
        public List<MenuModel> GetMenuForPage(MenuModel model, out int totalCount)
        {
            return _DAl.GetMenuForPage(model, out totalCount);
        }

        /// <summary>
        /// 查询所有菜单页面
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<MenuModel> GetMenuAll(MenuModel model)
        {
            return _DAl.GetMenuAll(model);
        }

        public IEnumerable<AuthorizeMenu> GetAuthorizeMenu(int i)
        {
            return _DAl.GetAuthorizeMenu(i);
        }
        
        /// <summary>
        /// 添加  LHR
        /// </summary>
        /// <param name="menu"></param>
        public void AddMenu(MenuModel menu)
        {
            _DAl.AddMenu(menu);
        }

        /// <summary>
        /// 修改  LHR
        /// </summary>
        /// <param name="menu"></param>
        public void EditMenu(MenuModel menu)
        {
            _DAl.EditMenu(menu);
        }

        /// <summary>
        /// 删除 菜单
        /// LHR
        /// </summary>
        /// <param name="id"></param>
        public void DelMenu(string id)
        {
            _DAl.DelMenu(id);
        }

        #endregion

        #region 查询数据字典维护 LHR
        /// <summary>
        /// 查询数据字典维护 分页数据
        /// LHR
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataForPage(BaseDataModel model, out int totalCount)
        {
            return _DAl.GetBaseDataForPage(model, out totalCount);
        }



        /// <summary>
        /// Layui 查询数据字典维护 分页数据 LHR 2020-05-15
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataForPageLayui(BaseDataModel model, out int totalCount)
        {
            return _DAl.GetBaseDataForPageLayui(model, out totalCount);
        }

        /// <summary>
        /// 查询数据字典维护表所有 isDeleted 为0的数据
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetbaseData()
        {
            return _DAl.GetbaseData();
        }


        /// <summary>
        /// 查询  数据字典类型下拉
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<SysbaseDataTypeModel> GetBaseDataTypeList(SysbaseDataTypeModel model = null)
        {
            return _DAl.GetBaseDataTypeList(model);
        }

        /// <summary>
        /// 添加 数据字典维护
        /// LHR
        /// </summary>
        /// <param name="model">实体类</param>
        public void AddBaseData(BaseDataModel model)
        {
            _DAl.AddBaseData(model);
        }

        /// <summary>
        /// 修改 数据字典维护
        /// LHR
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseData(BaseDataModel model)
        {
            _DAl.EditBaseData(model);
        }

        /// <summary>
        /// 删除 数据字典维护
        /// LHR
        /// </summary>
        /// <param name="id"></param>
        public void DelBaseData(string id)
        {
            _DAl.DelBaseData(id);
        }

        #endregion

        #region 工具物料OPC点位配置信息表 LHR

        /// <summary>
        /// 查询 工具物料OPC点位配置信息表 分页数据
        /// LHR
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<GjWlOpcPointModel> GetGjWlOpcPointForPage(GjWlOpcPointModel model, out int totalCount)
        {
            return _DAl.GetGjWlOpcPointForPage(model, out totalCount);
        }

        /// <summary>
        /// 查询 工具物料OPC点位配置信息表
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<GjWlOpcPointModel> GetGjWlOpcPointList(GjWlOpcPointModel model)
        {
            return _DAl.GetGjWlOpcPointList(model);
        }

        /// <summary>
        /// 查询 工具物料OPC点位配置信息表 所有数据
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<GjWlOpcPointModel> GetGjWlOpcPoint()
        {
            return _DAl.GetGjWlOpcPoint();
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
            return _DAl.GetGjWlOpcPointByID(gwID, gjID, wlID, pmodelID);
        }

        /// <summary>
        /// 添加 工具物料OPC点位配置信息表
        /// LHR
        /// </summary>
        /// <param name="model"></param>
        public void AddGjWlOpcPoint(GjWlOpcPointModel model)
        {
            _DAl.AddGjWlOpcPoint(model);
        }

        /// <summary>
        /// 工具物料点表【添加、修改】调用同一个方法
        /// 循环添加工具物料点表
        /// </summary>
        /// <param name="models">实体</param>
        /// <param name="ID">ID</param>
        public void EditSystemGjWlOpcPoint(List<GjWlOpcPointModel> models, string gjwlID)
        {
            _DAl.EditSystemGjWlOpcPoint(models, gjwlID);
        }

        /// <summary>
        /// 删除 工具物料OPC点位配置信息表
        /// LHR
        /// </summary>
        /// <param name="id"></param>
        public void DelGjWlOpcPoint(List<GjWlOpcPointModel> IDs)
        {
            _DAl.DelGjWlOpcPoint(IDs);
        }

        /// <summary>
        /// 查询 工位类型下拉
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<GongweiModel> GetgongweiAll()
        {
            return _DAl.GetgongweiAll();
        }

        /// <summary>
        /// 查询 工具类型下拉
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<GongjuModel> GetgongjuAll()
        {
            return _DAl.GetgongjuAll();
        }

        /// <summary>
        /// 查询 物料类型下拉
        /// LHR
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetwuliaoAll()
        {
            return _DAl.GetwuliaoAll();
        }

        /// <summary>
        /// 根据传值入类型查询
        /// </summary>
        /// <returns></returns>
        public BaseDataModel GetTypeById(int id)
        {
            return _DAl.GetTypeById(id);
        }

        #endregion

        #region 部门管理

        public List<DepartmentModel> GetPagingDepartment(DepartmentModel model, out int totalCount)
        {
            return _DAl.GetPagingDepartment(model, out totalCount);
        }
        public List<DepartmentModel> GetDepartmentList()
        {
            return _DAl.GetDepartmentList();
        }
        public void AddDepartment(DepartmentModel model)
        {
            _DAl.AddDepartment(model);
        }

        //public DepartmentModel GetDepartment(int Id)
        //{
        //    return _DAl.GetDepartment(Id);
        //}

        public void EditDepartment(DepartmentModel model)
        {
            _DAl.EditDepartment(model);
        }

        public void DeleteDepartment(string id)
        {
            _DAl.DeleteDepartment(id);
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
            return _DAl.GetBaseDataTypeList(model, out totalCount);
        }

        public List<BaseDataModel> GetBaseDataTypeValue(string typecode)
        {
            return _DAl.GetBaseDataTypeValue(typecode);
        }

        /// <summary>
        /// 根据类型编码 以及 类型值 获取数据字典
        /// 用于AGV查询虚拟地址集合
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        public List<BaseDataModel> GetBaseDataTypeValue(string typecode, string bdValueStr)
        {
            return _DAl.GetBaseDataTypeValue(typecode, bdValueStr);
        }

        public List<BaseDataModel> GetBaseDataValue(string typecode)
        {
            return _DAl.GetBaseDataValue(typecode);
        }

        public List<BaseDataModel> GetBaseDataSubitemValue(string typecode, int typeid)
        {
            return _DAl.GetBaseDataSubitemValue(typecode, typeid);
        }

        public int GetBaseDataTypebyID(string typecode, int typeid)
        {
            return _DAl.GetBaseDataTypebyID(typecode, typeid);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseDataType(SysbaseDataTypeModel model)
        {
            _DAl.AddBaseDataType(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseDataType(SysbaseDataTypeModel model)
        {
            _DAl.EditBaseDataType(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public int DeleteBaseDataType(string id)
        {
            return _DAl.DeleteBaseDataType(id);
        }

        #endregion

        #region 参数配置

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<SysconfigModel> GetPagingSysConfig(SysconfigModel model, out int totalCount)
        {
            return _DAl.GetPagingSysConfig(model, out totalCount);
        }

        /// <summary>
        /// 根据Code返回Value
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public string GetValueByCode(string strCode)
        {
            try
            {
                return _DAl.GetValueByCode(strCode);
            }
            catch (Exception)
            {
                return "";
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddSysConfig(SysconfigModel model)
        {
            _DAl.AddSysConfig(model);
        }
        
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditSysConfig(SysconfigModel model)
        {
            _DAl.EditSysConfig(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteSysConfig(string id)
        {
            _DAl.DeleteSysConfig(id);
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
            return _DAl.GetPagingSysexeFileUpdate(model, out totalCount);
        }

        /// <summary>
        /// 保存软件更新上传文件
        /// </summary>
        /// <param name="model"></param>
        public void SaveSysExeFileUpdate(SysexeFileUpdateModel model)
        {
            _DAl.SaveSysExeFileUpdate(model);
        }

        /// <summary>
        /// 获取客户端安装包
        /// </summary>
        /// <returns></returns>
        public SysexeFileUpdateModel GetSysUpdateFile()
        {
            return _DAl.GetSysUpdateFile();
        }

        /// <summary>
        /// 获取文件更新所有数据
        /// </summary>
        /// <returns></returns>
        public List<SysexeFileUpdateModel> GetSysUpdateFilesSel()
        {
            return _DAl.GetSysUpdateFilesSel();
        }

        /// <summary>
        /// 根据字典编码获取ID
        /// </summary>
        /// <param name="bdcode"></param>
        /// <returns></returns>
        public int GetBaseDataId(string bdcode)
        {
            return _DAl.GetBaseDataId(bdcode);
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
            return _DAl.LoginInfoForPage(model, out totalCount);
        }

        //public List<UserModel> GetEmployee()
        //{
        //    return _DAl.GetEmployee();
        //}

        /// <summary>
        /// 添加 考勤信息
        /// </summary>
        /// <param name="model"></param>
        public int AddLoginInfo(LoginInfoModel model)
        {
            return _DAl.AddLoginInfo(model);
        }

        /// <summary>
        /// 保存登出时间.
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>数据库受影响行数</returns>
        public int SaveLogoutTime(int userID)
        {
            return _DAl.SaveLogoutTime(userID);
        }

        #endregion

        #region 用户工位权限设置

        /// <summary>
        /// 获取所有工位权限类型
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetGwRightType()
        {
            return _DAl.GetGwRightType();
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
            return _DAl.GetRightType(UserID, gwID, rightTypeID);
        }

        /// <summary>
        /// 用户工位授权
        /// </summary>
        /// <param name="ActionName"></param>
        /// <param name="RoleId"></param>
        public void EditUserGwAuthority(Dictionary<string, BaseGongweiRightModel> dic, int UserID)
        {
            _DAl.EditUserGwAuthority(dic, UserID);
        }

        #endregion

        #region 人员资质有效期提醒
        /// <summary>
        /// 添加消息提醒数据
        /// <param name="model">消息内容实体</param>
        /// </summary>
        public bool AddMsgContent(BaseMsgContentModel model)
        {
            return _DAl.AddMsgContent(model);
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
            return _DAl.GetConfigByCode(cfgcode);
        }
        /// <summary>
        /// 根据当前区域CODE获取上一区域id
        /// </summary>
        /// <param name="bdcode"></param>
        /// <returns></returns>
        public int GetBeforeAreaIDByCode(string bdcode)
        {
            return _DAl.GetBeforeAreaIDByCode(bdcode);
        }
        /// <summary>
        /// 根据ID获取数据字典数据实体类
        /// </summary>
        /// <param name="baseDataID"></param>
        /// <returns></returns>
        public BaseDataModel getBaseDataByID(int baseDataID)
        {
            return _DAl.getBaseDataByID(baseDataID);
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            return _DAl.GetDateTime();
        }

        /// <summary>
        /// 获取多个系统参数值
        /// </summary>
        /// <param name="codes"></param>
        /// <returns></returns>
        //public List<KeyValuePair<string, string>> GetConfigs(params string[] codes)
        //{
        //    return _DAl.GetConfigs(codes);
        //}
        #endregion

        #region 流水号

        public string GetSerialNumber(string strTableName, string strPrefix, int intNumCount)
        {
            return _DAl.GetSerialNumber(strTableName, strPrefix, intNumCount);
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
            return _DAl.GetInventoryPage(model, out totalCount);
        }

        /// <summary>
        /// 判断该规格和仓库是否存在
        /// </summary>
        /// <param name="wlcodeID">物料规格ID</param>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        public bool IsExistInventory(int wlcodeID, int warehouseID)
        {
            return _DAl.IsExistInventory(wlcodeID, warehouseID);
        }

        /// <summary>
        /// 添加/修改库存信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        public int SaveInventory(InventoryModel model)
        {
            return _DAl.SaveInventory(model);
        }
        #endregion

        #region 系统日志

        public List<SysLogModel> GetSysLog(string startTime, string endTime)
        {
            return _DAl.GetSysLog(startTime, endTime);
        }

        public void AddSysLog(SysLogModel model)
        {
            _DAl.AddSysLog(model);
        }

        #endregion

    }
}