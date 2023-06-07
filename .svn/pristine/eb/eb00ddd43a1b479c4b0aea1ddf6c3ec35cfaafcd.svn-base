using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;

namespace RW.PMS.IBLL
{
    public interface IBLL_System : IDependence
    {
        #region 用户
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        UserModel GetUser(UserModel model);

        /// <summary>
        /// 获取用户集合
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<UserModel> GetUserList(UserModel model = null);

        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <param name="model">用户信息实体类</param>
        void AddUsers(UserModel model);

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="model">用户信息实体类</param>
        void EditUsers(UserModel model);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id">用户ID</param>
        void DeleteUsers(string id);

        #endregion
        void AddBaseData(BaseDataModel model);
        void AddBaseDataType(SysbaseDataTypeModel model);
        void AddDepartment(DepartmentModel model);
        void AddGjWlOpcPoint(GjWlOpcPointModel model);
        int AddLoginInfo(LoginInfoModel model);
        void AddMenu(MenuModel menu);
        void AddRole(RoleModel model);
        void AddSysConfig(SysconfigModel model);
        void DelBaseData(string id);
        int DeleteBaseDataType(string id);
        void DeleteDepartment(string id);
        List<DepartmentModel> GetDepartmentList();
        void DeleteRole(string id);
        void DeleteSysConfig(string id);
        void DelGjWlOpcPoint(List<GjWlOpcPointModel> id);
        void DelMenu(string id);
        void EditBaseData(BaseDataModel model);
        void EditBaseDataType(SysbaseDataTypeModel model);
        void EditDepartment(DepartmentModel model);
        /// <summary>
        /// 保存登出时间.
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns>数据库受影响行数</returns>
        int SaveLogoutTime(int userID);
        void EditMenu(MenuModel menu);
        void EditRole(RoleModel model);
        void EditRoleMenuDef(List<RoleMenuModel> models, int roleId);

        /// <summary>
        /// EleTree 角色授权树保存
        /// </summary>
        /// <param name="models">权限实体集合</param>
        /// <param name="roleId">角色ID</param>
        void SaveRoleMenuDef(List<RoleMenuModel> models, int roleId);

        void EditSysConfig(SysconfigModel model);
        void EditUserGwAuthority(Dictionary<string, BaseGongweiRightModel> dic, int UserID);
        /// <summary>
        /// 获取菜单权限类型信息
        /// </summary>
        /// <returns></returns>
        List<MenuAuth> GetMenuAuth();
        List<RoleMenuModel> GetAuthValueByRoleId(int roleId);
        IEnumerable<AuthorizeMenu> GetAuthorizeMenu(int i);
        List<BaseDataModel> GetbaseData();
        List<BaseDataModel> GetBaseDataForPage(BaseDataModel model, out int totalCount);

        /// <summary>
        /// Layui 查询数据字典维护 分页数据 LHR 2020-05-15
        /// </summary>
        /// <param name="model">实体类</param>
        /// <param name="totalCount">总页数</param>
        /// <returns></returns>
        List<BaseDataModel> GetBaseDataForPageLayui(BaseDataModel model, out int totalCount);


        /// <summary>
        /// 根据配置类型获取配置数据
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        List<BaseDataModel> GetBaseDataTypeValue(string typecode);

        /// <summary>
        /// 根据类型编码 以及 类型值 获取数据字典
        /// 用于AGV查询虚拟地址集合
        /// </summary>
        /// <param name="typecode"></param>
        /// <returns></returns>
        List<BaseDataModel> GetBaseDataTypeValue(string typecode, string bdValueStr);

        List<BaseDataModel> GetBaseDataValue(string typecode);

        List<BaseDataModel> GetBaseDataSubitemValue(string typecode, int typeid);

        int GetBaseDataTypebyID(string typecode, int typeid);
        List<GongjuModel> GetgongjuAll();
        List<GongweiModel> GetgongweiAll();
        List<GjWlOpcPointModel> GetGjWlOpcPoint();
        List<GjWlOpcPointModel> GetGjWlOpcPointForPage(GjWlOpcPointModel model, out int totalCount);
        List<GjWlOpcPointModel> GetGjWlOpcPointList(GjWlOpcPointModel model);
        List<BaseDataModel> GetGwRightType();
        List<MenuModel> GetMenuForPage(MenuModel model, out int totalCount);

        List<MenuModel> GetMenuAll(MenuModel model);
        List<SysbaseDataTypeModel> GetBaseDataTypeList(SysbaseDataTypeModel model, out int totalCount);
        List<SysbaseDataTypeModel> GetBaseDataTypeList(SysbaseDataTypeModel model = null);
        List<DepartmentModel> GetPagingDepartment(DepartmentModel model, out int totalCount);
        List<RoleModel> GetRoleList(RoleModel model, out int totalCount);
        List<RoleModel> GetRoleList(RoleModel model);
        List<SysconfigModel> GetPagingSysConfig(SysconfigModel model, out int totalCount);
        List<SysexeFileUpdateModel> GetPagingSysexeFileUpdate(SysexeFileUpdateModel model, out int totalCount);
        //List<MenuModel> GetPermissions();
        List<MenuModel> GetMenuList(MenuModel model = null);
        //SysconfigModel GetSysConfigId(int Id);

        List<MenuTreeModel> GetMenuAllList(MenuTreeModel model = null);

        /// <summary>
        /// 获取菜单树形权限
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        List<TreeEntity> GetMenuTreeList(int roleID);

        string GetValueByCode(string strCode);
        List<WuliaoModel> GetwuliaoAll();
        List<LoginInfoModel> LoginInfoForPage(LoginInfoModel model, out int totalCount);
        void SaveSysExeFileUpdate(SysexeFileUpdateModel model);
        List<GjWlOpcPointModel> GetGjWlOpcPointByID(int gwID, int gjID, int wlID, int pmodelID);
        void EditSystemGjWlOpcPoint(List<GjWlOpcPointModel> models, string gjwlID);
        BaseDataModel GetTypeById(int id);
        /// <summary>
        /// 获取客户端安装包
        /// </summary>
        /// <returns></returns>
        SysexeFileUpdateModel GetSysUpdateFile();
        /// <summary>
        /// 获取文件更新所有数据
        /// </summary>
        /// <returns></returns>
        List<SysexeFileUpdateModel> GetSysUpdateFilesSel();
        /// <summary>
        /// 根据字典编码获取ID
        /// </summary>
        /// <param name="bdcode"></param>
        /// <returns></returns>
        int GetBaseDataId(string bdcode);

        /// <summary>
        /// 根据用户和工位获取工位权限执行类型
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="gwID">工位ID</param>
        /// <param name="rightTypeID">工位权限执行类型ID</param>
        /// <returns></returns>
        string GetRightType(int UserID, int gwID, int rightTypeID);

        /// <summary>
        /// 添加消息提醒数据
        /// <param name="model">消息内容实体</param>
        /// </summary>
        bool AddMsgContent(BaseMsgContentModel model);

        #region CS端
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfgcode"></param>
        /// <returns></returns>
        SysconfigModel GetConfigByCode(string cfgcode);
        int GetBeforeAreaIDByCode(string bdcode);
        BaseDataModel getBaseDataByID(int baseDataID);
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        DateTime GetDateTime();
        #endregion

        #region 流水号

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <param name="strTableName">数据库表名</param>
        /// <param name="strPrefix">流水号前缀</param>
        /// <param name="intNumCount">流水号位数</param>
        /// <returns>字符串流水号</returns>
        string GetSerialNumber(string strTableName, string strPrefix, int intNumCount);
        #endregion

        #region 库存信息

        /// <summary>
        /// 库存分页信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        List<InventoryModel> GetInventoryPage(InventoryModel model, out int totalCount);

        /// <summary>
        /// 判断该规格和仓库是否存在
        /// </summary>
        /// <param name="wlcodeID">物料规格ID</param>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        bool IsExistInventory(int wlcodeID, int warehouseID);

        /// <summary>
        /// 添加/修改库存信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        int SaveInventory(InventoryModel model);

        #endregion

        #region 系统日志
        /// <summary>
        /// 查询系统日志
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        List<SysLogModel> GetSysLog(string startTime, string endTime);

        /// <summary>
        /// 添加系统日志
        /// </summary>
        /// <param name="model"></param>
        void AddSysLog(SysLogModel model);
        #endregion
    }
}
