using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model.Follow;
using RW.PMS.Model;
using RW.PMS.Model.Sys;
using System.Data.SqlClient;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Common;
using System.Data;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Log;
using RW.PMS.Model.Plan;

namespace RW.PMS.BLL
{
    internal class BLL_BaseInfo : IBLL_BaseInfo
    {
        private IDAL_BaseInfo _DAL = null;

        public BLL_BaseInfo()
        {
            _DAL = DIService.GetService<IDAL_BaseInfo>();
        }
        /// <summary>
        /// 通用判断名称是否存在
        /// </summary>
        /// <param name="TabName">表名</param>
        /// <param name="FiledName">字段名称</param>
        /// <param name="Name">查询字段名称值</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public bool IsExistName(string TabName, string FiledName, string Name, int ID = 0)
        {
            return _DAL.IsExistName(TabName, FiledName, Name, ID);
        }


        #region 产品信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductModel> GetPagingBaseProduct(BaseProductModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseProduct(model, out totalCount);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">产品信息实体类</param>
        public void AddBaseProduct(BaseProductModel model)
        {
            _DAL.AddBaseProduct(model);
        }


        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">产品信息表Id</param>
        /// <returns></returns>
        public BaseProductModel GetBaseProductId(int Id)
        {
            return _DAL.GetBaseProductId(Id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProduct(BaseProductModel model)
        {
            _DAL.EditBaseProduct(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProduct(string id)
        {
            _DAL.DeleteBaseProduct(id);
        }

        public List<ProductInfoModel> GetProductInfoList(ProductInfoModel model)
        {
            return _DAL.GetProductInfoList(model);
        }

        #endregion

        #region 产品型号信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetPagingBaseProductModel(BaseProductModelModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseProductModel(model, out totalCount);
        }

        /// <summary>
        /// 获取所有产品型号信息
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetBaseProductModel()
        {
            return _DAL.GetBaseProductModel();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseOPCProductModel> GetOPCProductModelList(BaseOPCProductModel model, out int totalCount)
        {
            return _DAL.GetOPCProductModelList(model, out totalCount);
        }

        /// <summary>
        /// 获取未禁用的所有产品型号(用于下拉框)
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductModelAll()
        {
            return _DAL.GetProductModelAll();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">产品型号实体类</param>
        public void AddBaseProductModel(BaseProductModelModel model)
        {
            _DAL.AddBaseProductModel(model);
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">产品型号信息表Id</param>
        /// <returns></returns>
        public BaseProductModelModel GetBaseProductModelId(int Id)
        {
            return _DAL.GetBaseProductModelId(Id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProductModel(BaseProductModelModel model)
        {
            _DAL.EditBaseProductModel(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProductModel(string id)
        {
            _DAL.DeleteBaseProductModel(id);
        }

        #endregion

        #region 维保信息设置

        /// <summary>
        /// 获取所有维保信息
        /// </summary>
        /// <returns></returns>
        public List<MaintenanceSettingModel> GetMaintenanceSettingAll()
        {
            return _DAL.GetMaintenanceSettingAll();
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="model">维保信息实体类</param>
        public bool AddMaintenanceSetting(MaintenanceSettingModel model)
        {
            return _DAL.AddMaintenanceSetting(model);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id">维保信息表Id</param>
        /// <returns></returns>
        public MaintenanceSettingModel GetMaintenanceSettingId(int Id)
        {
            return _DAL.GetMaintenanceSettingId(Id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public bool EditMaintenanceSetting(MaintenanceSettingModel model)
        {
            return _DAL.EditMaintenanceSetting(model);
        }

        public bool EditmaintainUsedTime(int Id)
        {
            return _DAL.EditmaintainUsedTime(Id);
        }

        public void AddUsedTimes()
        {
            _DAL.AddUsedTimes();
        }

        /// <summary>
        /// 删除  
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteMaintenanceSetting(string id)
        {
            return _DAL.DeleteMaintenanceSetting(id);
        }

        #endregion

        #region 拧紧数据管理

        /// <summary>
        /// 获取拧紧数据
        /// </summary>
        /// <returns></returns>
        public List<TighteningRecordModel> GetTighteningRecord(TighteningRecordModel model)
        {
            return _DAL.GetTighteningRecord(model);
        }

        public List<TighteningRecordModel> GetTighteningRecord(TighteningRecordModel model, out int totalCount)
        {
            return _DAL.GetTighteningRecord(model,out totalCount);
        }

        public List<TighteningRecordExcelModel> GetTighteningRecordExcel(TighteningRecordModel model)
        {
            return _DAL.GetTighteningRecordExcel(model);
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="model">拧紧数据实体类</param>
        public int AddTighteningRecordModel(TighteningRecordModel model)
        {
            return _DAL.AddTighteningRecordModel(model);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditTighteningRecordModel(TighteningRecordModel model)
        {
            return _DAL.EditTighteningRecordModel(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteTighteningRecord(string id)
        {
            return _DAL.DeleteTighteningRecord(id);
        }

        #endregion

        #region 工位信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseGongweiModel> GetWorkPositionList(BaseGongweiModel model, out int totalCount)
        {
            return _DAL.GetWorkPositionList(model, out totalCount);
        }

        public List<BaseGongweiModel> GetWorkPositionList(BaseGongweiModel model)
        {
            return _DAL.GetWorkPositionList(model);
        }

        /// <summary>
        /// 获取所有工位
        /// </summary>
        /// <returns></returns>
        public List<BaseGongweiModel> GetAllBaseGongWei(int areaID = 0)
        {
            return _DAL.GetAllBaseGongWei(areaID);
        }

        /// <summary>
        /// 获取产品型号信息2019-05-15
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetAllBaseProModel()
        {
            return _DAL.GetAllBaseProModel();
        }


        /// <summary>
        /// 查询所有工位opc点位信息
        /// </summary>
        /// <returns></returns>
        public List<BaseGongweiOpcModel> GetGongWeiOPC(BaseGongweiOpcModel model = null)
        {
            return _DAL.GetGongWeiOPC(model);
        }

        /// <summary>
        /// 工位OPC点位信息表【添加、修改】调用同一个方法
        /// 添加工位表 循环添加工位OPC点表
        /// </summary>
        /// <param name="models">实体</param>
        /// <param name="gwid">工位ID</param>
        public int EditBaseGongWeiOpc(List<BaseGongweiModel> models, int gwid)
        {
            return _DAL.EditBaseGongWeiOpc(models, gwid);
        }
        /// <summary>
        /// 判断工位名称是否有相同的
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public bool GetGongWeiNameCount(string GwName, int ID = 0)
        {
            return _DAL.GetGongWeiNameCount(GwName, ID);
        }
        /// <summary>
        /// 判断IP地址是否有相同的
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        public bool GetGongWeiIPCount(string IP, int ID)
        {
            return _DAL.GetGongWeiIPCount(IP, ID);
        }
        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">工位信息表Id</param>
        /// <returns></returns>
        public BaseGongweiModel GetBaseGongWeiId(int Id)
        {
            return _DAL.GetBaseGongWeiId(Id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        //public void EditBaseGongWei(BaseGongweiModel model)
        //{
        //    _DAL.EditBaseGongWei(model);
        //}

        /// <summary>
        /// 根据工位ID删除【工位信息表】>【工位OPC点位表】
        /// 删除：如果删除主表下面的子表也会被同时删除
        /// </summary>
        /// <param name="id"></param>
        public void GwDel(string id)
        {
            _DAL.GwDel(id);
        }


        /// <summary>
        /// 根据IP地址获取 是否需要启动OPC驱动
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public bool GetGwByIP(string ip)
        {
            return _DAL.GetGwByIP(ip);
        }


        #endregion

        #region 工位权限信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseGongweiRightModel> GetPagingBaseGongweiRight(BaseGongweiRightModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseGongweiRight(model, out totalCount);
        }

        /// <summary>
        /// 查询下拉工位信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseGongweiModel> GetGongWei()
        {
            return _DAL.GetGongWei();
        }


        /// <summary>
        /// 查询下拉用户信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<UserModel> GetUserlist()
        {
            return _DAL.GetUserlist();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工位权限信息实体类</param>
        public void AddBaseGongweiRight(BaseGongweiRightModel model)
        {
            _DAL.AddBaseGongweiRight(model);
        }

        /// <summary>
        /// 工位权限信息修改绑定
        /// </summary>
        /// <param name="Id">信息表Id</param>
        /// <returns></returns>
        public BaseGongweiRightModel GetBaseGongweiRightId(int Id)
        {
            return _DAL.GetBaseGongweiRightId(Id);
        }

        /// <summary>
        /// 工位权限信息修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseGongweiRight(BaseGongweiRightModel model)
        {
            _DAL.EditBaseGongweiRight(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        //public void DeleteBaseGongweiRight(string id)
        //{
        //    _DAL.DeleteBaseGongweiRight(id);
        //}

        /// <summary>
        /// 获取员工工位权限
        /// </summary>
        /// <param name="empID"></param>
        /// <returns></returns>
        //public List<BaseGongweiRightModel> GetBaseGongweiRightModelByEmpID(int empID, int gwID)
        //{
        //    return _DAL.GetBaseGongweiRightModelByEmpID(empID, gwID);
        //}

        public List<BaseGongweiRightModel> GetRightList(BaseGongweiRightModel model)
        {
            return _DAL.GetRightList(model);
        }
        #endregion

        #region 工具信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<GongjuModel> GetPagingBaseGongJu(GongjuModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseGongJu(model, out totalCount);
        }

        /// <summary>
        /// 保存工具信息
        /// </summary>
        /// <param name="model">工具实体类</param>
        /// <returns></returns>
        public bool SaveBaseGongju(GongjuModel model)
        {
            return _DAL.SaveBaseGongju(model);
        }
        /// <summary>
        /// 获取所有工具信息
        /// </summary>
        /// <returns></returns>
        public List<GongjuModel> GetAllBaseGongJu()
        {
            return _DAL.GetAllBaseGongJu();
        }

        /// <summary>
        /// 获取所有工具信息
        /// </summary>
        /// <returns></returns>
        public List<GongjuModel> GetGongju()
        {
            return _DAL.GetGongju();
        }

        /// <summary>
        /// 工具类型下拉
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetGjType()
        {
            return _DAL.GetGjType();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">工具信息实体类</param>
        public void AddBaseGongju(GongjuModel model)
        {
            _DAL.AddBaseGongju(model);
        }

        /// <summary>
        /// 工具信息修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseGongJu(GongjuModel model)
        {
            _DAL.EditBaseGongJu(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseGongJu(string id)
        {
            _DAL.DeleteBaseGongJu(id);
        }

        #endregion

        #region 物料/零件信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<WuliaoModel> GetPagingBaseWuliao(WuliaoModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseWuliao(model, out totalCount);
        }
        /// <summary>
        /// 获取所有物料信息
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetAllBaseWuliao()
        {
            return _DAL.GetAllBaseWuliao();
        }

        /// <summary>
        /// 获取所有物料/零件信息
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetWuliao()
        {
            return _DAL.GetWuliao();
        }
        /// <summary>
        /// 物料/零件类型下拉
        /// </summary>
        /// <returns></returns>
        public List<BaseDataModel> GetWlType()
        {
            return _DAL.GetWlType();
        }

        /// <summary>
        /// 判断物料名称和规格是否存在
        /// </summary>
        /// <param name="wlname">物料名称</param>
        /// <param name="wlcode">物料规格</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public bool IsExistWuliaoNameANDCode(string wlname, string wlcode, int ID = 0)
        {
            return _DAL.IsExistWuliaoNameANDCode(wlname, wlcode, ID);
        }

        /// <summary>
        /// 批量添加物料
        /// </summary>
        /// <param name="model">物料实体类</param>
        /// <returns></returns>
        public void SaveWuliaoList(List<WuliaoModel> model)
        {
            _DAL.SaveWuliaoList(model);
        }
        /// <summary>
        /// 添加物料/零件信息
        /// </summary>
        /// <param name="model">物料/零件信息实体类</param>
        public void AddBaseWuliao(WuliaoModel model)
        {
            _DAL.AddBaseWuliao(model);
        }

        /// <summary>
        ///物料/零件信息修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public WuliaoModel GetBaseWuliaoId(int Id)
        {
            return _DAL.GetBaseWuliaoId(Id);
        }

        /// <summary>
        /// 修改物料/零件信息
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseWuliao(WuliaoModel model)
        {
            _DAL.EditBaseWuliao(model);
        }

        /// <summary>
        /// 删除物料/零件信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseWuliao(string id)
        {
            _DAL.DeleteBaseWuliao(id);
        }

        #endregion

        #region 物料/零件编码规格 LHR

        public List<WuliaoModelModel> GetPagingWuliaoCode(WuliaoModelModel model, out int totalCount) { return _DAL.GetPagingWuliaoCode(model, out totalCount); }
        public void AddWuliaoCode(WuliaoModelModel model) { _DAL.AddWuliaoCode(model); }
        public void EditWuliaoCode(WuliaoModelModel model) { _DAL.EditWuliaoCode(model); }
        public void DeleteWuliaoCode(string id) { _DAL.DeleteWuliaoCode(id); }

        /// <summary>
        /// 获取所有物料规格信息下拉
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModelModel> GetAllBaseWuliaoCode()
        {
            return _DAL.GetAllBaseWuliaoCode();
        }


        #endregion

        #region 工位&产品型号关联配置 WZQ
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseGwProdDefModel> GetPagingBaseGwProdDef(BaseGwProdDefModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseGwProdDef(model, out totalCount);
        }

        public List<BaseGwProdDefModel> GetGWProdDefList(BaseGwProdDefModel model)
        {
            return _DAL.GetGWProdDefList(model);
        }

        public List<BaseProductBomModel> GetBomList(BaseProductBomModel model)
        {
            return _DAL.GetBomList(model);
        }

        /// <summary>
        /// 获取产品型号下拉信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductModel()
        {
            return _DAL.GetProductModel();
        }

        /// <summary>
        /// 获取物料组件下拉信息
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModel> GetWuliaoType()
        {
            return _DAL.GetWuliaoType();
        }

        /// <summary>
        /// 获取程序下拉信息
        /// </summary>
        /// <returns></returns>
        public List<BaseProgram> GetBaseProgram()
        {
            return _DAL.GetBaseProgram();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseGwProdDef(BaseGwProdDefModel model)
        {
            _DAL.AddBaseGwProdDef(model);
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseGwProdDefModel GetBaseGwProdDefId(int Id)
        {
            return _DAL.GetBaseGwProdDefId(Id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseGwProdDef(BaseGwProdDefModel model)
        {
            _DAL.EditBaseGwProdDef(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseGwProdDef(string id)
        {
            _DAL.DeleteBaseGwProdDef(id);
        }

        #endregion

        #region 产品bom信息
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseBomModel> GetPagingBaseBOM(BaseBomModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseBOM(model, out totalCount);
        }

        /// <summary> 
        /// 添加 
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseBom(BaseBomModel model)
        {
            _DAL.AddBaseBom(model);
        }

        /// <summary>
        /// 修改 
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseBom(BaseBomModel model)
        {
            _DAL.EditBaseBom(model);
        }

        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseBom(string id)
        {
            _DAL.DeleteBaseBom(id);
        }

        #endregion
        #region 产品关键零部件信息

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetPagingBaseProductLingJian(BaseProductBomModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseProductLingJian(model, out totalCount);
        }

        /// <summary>
        /// 获取物料编码下拉
        /// </summary>
        /// <returns></returns>
        public List<WuliaoModelModel> GetWuliaoCode(int wlID)
        {
            return _DAL.GetWuliaoCode(wlID);
        }

        /// <summary>
        /// 获取工位区域
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<GongweiModel> GetGongWeiArea(int Id)
        {
            return _DAL.GetGongWeiArea(Id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseProductLingJian(BaseProductBomModel model)
        {
            _DAL.AddBaseProductLingJian(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProductLingJian(BaseProductBomModel model)
        {
            _DAL.EditBaseProductLingJian(model);
        }
        /// <summary>
        ///  删除：如果删除主表下面的子表也会被同时删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProductLingJian(string id)
        {
            _DAL.DeleteBaseProductLingJian(id);
        }

        #endregion

        #region 组件质检提示说明

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BasePartCheckTipModel> GetPagingProdLjCheckTip(BasePartCheckTipModel model, out int totalCount)
        {
            return _DAL.GetPagingProdLjCheckTip(model, out totalCount);
        }

        /// <summary>
        /// 获取所有质检提示说明
        /// </summary>
        /// <returns></returns>
        public List<BasePartCheckTipModel> GetProdLjCheckTip()
        {
            return _DAL.GetProdLjCheckTip();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public void AddBaseProdLjCheckTip(BasePartCheckTipModel model)
        {
            _DAL.AddBaseProdLjCheckTip(model);
        }

        /// <summary>
        /// 修改绑定
        /// </summary>
        /// <param name="Id">质检提示说明Id</param>
        /// <returns></returns>
        public BasePartCheckTipModel GetBaseProdLjCheckTipId(int Id)
        {
            return _DAL.GetBaseProdLjCheckTipId(Id);
        }

        /// <summary>
        /// 根据当前 产品关键零部件设置表ID 查询返回排序
        /// </summary>
        /// <param name="prodLjDefId"></param>
        /// <returns></returns>
        public int GetStepNo(int prodLjDefId)
        {
            return _DAL.GetStepNo(prodLjDefId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseProdLjCheckTip(BasePartCheckTipModel model)
        {
            _DAL.EditBaseProdLjCheckTip(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseProdLjCheckTip(string id)
        {
            _DAL.DeleteBaseProdLjCheckTip(id);
        }

        #endregion

        #region 器具、量具基础信息表 Ad WZQ

        /// <summary>
        /// 器具基础信息分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<BaseToolsModel> GetPagingBaseTools(BaseToolsModel model, out int totalCount)
        {
            return _DAL.GetPagingBaseTools(model, out totalCount);
        }

        /// 添加器具基础信息
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public void AddBaseTools(BaseToolsModel model)
        {
            _DAL.AddBaseTools(model);
        }

        /// <summary>
        /// 自动更新每天的状态
        /// </summary>
        public void LoadToolsStatus()
        {
            _DAL.LoadToolsStatus();
        }
        /// <summary>
        /// 器具基础信息修改绑定
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseToolsModel GetBaseToolsId(int Id)
        {
            return _DAL.GetBaseToolsId(Id);
        }

        /// <summary>
        /// 修改器具基础信息
        /// </summary>
        /// <param name="model"></param>
        public void EditBaseTools(BaseToolsModel model)
        {
            _DAL.EditBaseTools(model);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBaseTools(string id)
        {
            _DAL.DeleteBaseTools(id);
        }

        /// <summary>
        /// 获取到期状态
        /// </summary>
        /// <param name="ExpreDate"></param>
        /// <param name="ExpireDay"></param>
        /// <returns></returns>
        public int GetExpireStatus(DateTime ExpreDate)
        {
            return _DAL.GetExpireStatus(ExpreDate);
        }

        #endregion

        #region CS端
        /// <summary>
        /// 根据IP获取工位信息，包括工位ID，名称，区域
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public BaseGongweiModel getGwByIP(string ip)
        {
            return _DAL.getGwByIP(ip);
        }

        /// <summary>
        /// 获取总装工位最大排序号
        /// </summary>
        /// <returns></returns>
        public int getGwMaxOrder()
        {
            return _DAL.getGwMaxOrder();
        }


        /// <summary>
        /// 根据ID获取工位实体信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public BaseGongweiModel getEntyGwByID(int Id)
        {
            return _DAL.getEntyGwByID(Id);
        }

        /// <summary>
        /// 获取检验区的偶换件列表 LHR
        /// </summary>
        /// <param name="fm_guid">生产编号GUID</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <param name="componentId"></param>
        /// <param name="curAreaID"></param>
        /// <param name="replaceTypeID"></param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetWlLjBatch(Guid fm_guid, int pModelID, int componentId, int curAreaID, params int[] replaceTypeID)
        {
            return _DAL.GetWlLjBatch(fm_guid, pModelID, componentId, curAreaID, replaceTypeID);
        }

        /// <summary>
        /// 获取检验区的偶换件列表(偶换件+其他）非必换件 （获取检验区的偶换件列表 LHR）
        /// </summary>
        /// <param name="fm_guid">生产编号GUID</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <param name="componentId">组件ID</param>
        /// <param name="curAreaID">当前区域</param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetCheckCoupleChangeWlBatch(Guid fm_guid, int pModelID, int componentId, int curAreaID)
        {
            return _DAL.GetWlLjBatch(fm_guid, pModelID, componentId, curAreaID, 0, 2);
        }


        /// <summary>
        /// 获取物料盒信息
        /// </summary>
        /// <param name="wlBoxHasRFID">已有的物料编号，用逗号隔开的字符串</param>
        /// <returns></returns>
        public List<WuliaoModel> GetWlBox(params int[] wlBoxHasRFID)
        {
            return _DAL.GetWlBox(wlBoxHasRFID);
        }


        /// <summary>
        /// 获取产品型号+组件的质检提示
        /// </summary>
        /// <param name="pModelID"></param>
        /// <param name="gwID"></param>
        /// <returns></returns>
        public List<BaseProductBomModel> GetCheckTip(int pModelID, int componentId, int wlId)
        {
            return _DAL.GetCheckTip(pModelID, componentId, wlId);
        }

        /// <summary>
        /// 物料是否为来料区悬挂部件
        /// </summary>
        /// <param name="fm_guid">生产编号GUID</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <returns></returns>
        public bool WuliaoIsComingHang(int pModelID, int wuliaoID)
        {
            return _DAL.WuliaoIsComingHang(pModelID, wuliaoID);
        }


        /// <summary>
        /// 获取工具备注信息（主要用于扭力扳手） 2020-07-04
        /// </summary>
        /// <param name="gjNames"></param>
        /// <returns></returns>
        public List<KeyValuePair<string, string>> GetGjRemarks(List<string> gjNames)
        {
            return _DAL.GetGjRemarks(gjNames);
        }

        #endregion

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServerDateTime()
        {
            return _DAL.GetServerDateTime();
        }

        #region 车辆信息

        public List<SubwayInfoModel> GetSubwayInfoList(SubwayInfoModel model)
        {
            return _DAL.GetSubwayInfoList(model);
        }
        #endregion


        #region 存放区信息管理


        public List<BaseTempAreaModel> GetTempAreaList(BaseTempAreaModel model, out int totalCount)
        {
            return _DAL.GetTempAreaList(model, out totalCount);
        }
        public void AddTempArea(BaseTempAreaModel model) { _DAL.AddTempArea(model); }
        public int EditTempArea(BaseTempAreaModel model) { return _DAL.EditTempArea(model); }
        public int SaveSmallFan(BaseTempAreaModel model) { return _DAL.SaveSmallFan(model); }
        public void DeleteTempArea(string id) { _DAL.DeleteTempArea(id); }
        public string LeaveInComming(Guid pfGuid) { return _DAL.LeaveInComming(pfGuid); }
        public List<BaseTempAreaModel> GetTempAreaList(BaseTempAreaModel model)
        {
            return _DAL.GetTempAreaList(model);
        }


        #endregion

        #region 部件质量检测项标准范围值

        public List<BasePartCheckValueModel> GetPartCheckValue(BasePartCheckValueModel model, out int totalCount) { return _DAL.GetPartCheckValue(model, out totalCount); }
        public List<BasePartCheckValueModel> GetPartCheckValueList(BasePartCheckValueModel model) { return _DAL.GetPartCheckValueList(model); }
        public void AddPartCheckValue(BasePartCheckValueModel model) { _DAL.AddPartCheckValue(model); }
        public void EditPartCheckValue(BasePartCheckValueModel model) { _DAL.EditPartCheckValue(model); }
        public void DeletePartCheckValue(string id) { _DAL.DeletePartCheckValue(id); }

        #endregion

        #region 条码卡 Leon
        public List<BaseBarcodeModel> GetBarCodeList(BaseBarcodeModel model)
        {
            return _DAL.GetBarCodeList(model);
        }
        #endregion

        #region 库存信息 WZQ

        /// <summary>
        /// 库存分页信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseInventoryModel> GetInventoryPage(BaseInventoryModel model, out int totalCount)
        {
            return _DAL.GetInventoryPage(model, out totalCount);
        }

        /// <summary>
        /// 判断该规格和仓库是否存在
        /// </summary>
        /// <param name="wlcodeID">物料规格ID</param>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        public bool IsExistInventory(int UNID, int wlID, int warehouseID)
        {
            return _DAL.IsExistInventory(UNID, wlID, warehouseID);
        }

        /// <summary>
        /// 添加/修改库存信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        public int SaveInventory(BaseInventoryModel model)
        {
            return _DAL.SaveInventory(model);
        }

        /// <summary>
        /// Excel导入仓库信息 全删全插
        /// </summary>
        /// <param name="InventoryList"></param>
        /// <returns></returns>
        public ResponseResult<string> ImportInventory(List<BaseInventoryModel> InventoryList, bool isDeleted)
        {
            return _DAL.ImportInventory(InventoryList, isDeleted);
        }

        /// <summary>
        /// 将导入的Excel文件合并数量后进行保存
        /// </summary>
        /// <param name="InventoryList"></param>
        /// <returns></returns>
        public ResponseResult<string> ImportUniqInventory(List<BaseInventoryModel> InventoryList)
        {
            return _DAL.ImportUniqInventory(InventoryList);
        }

        /// <summary>
        /// 获取库存操作最后时间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseInventoryLogModel> GetInventoryLogTime(BaseInventoryLogModel model)
        {
            return _DAL.GetInventoryLogTime(model);
        }

        #endregion

        #region 物料 Add By Leon 20191014

        /// <summary>
        /// 物料管理分页 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialList(BaseMaterialModel model, out int totalCount)
        {
            return _DAL.GetMaterialList(model, out totalCount);
        }


        public List<BaseMaterialModel> GetMaterialList(BaseMaterialModel model)
        {
            return _DAL.GetMaterialList(model);
        }


        public List<BaseMaterialModel> GetMaterialList()
        {
            return _DAL.GetMaterialList();
        }

        /// <summary>
        /// 获取物料字典数据
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialDict()
        {
            return _DAL.GetMaterialDict();
        }

        /// <summary>
        /// 获取物料数据
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialList(int progbID)
        {
            return _DAL.GetMaterialList(progbID);
        }

        /// <summary>
        /// 获取物料条码标字典数据 2020-06-01
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialBarCodeModel> GetMaterialBarCodeDict()
        {
            return _DAL.GetMaterialBarCodeDict();
        }

        /// <summary>
        /// 用于条码生成器 获取下拉列表值
        /// </summary>
        /// <returns></returns>
        public List<BaseMaterialBarCodeModel> GetMaterialBarCode()
        {
            return _DAL.GetMaterialBarCode();
        }


        /// <summary>
        /// 获取条码卡信息
        /// </summary>
        /// <returns></returns>
        public BaseMaterialBarCodeModel GetMaterialBarCodeByModel(BaseMaterialBarCodeModel model)
        {
            return _DAL.GetMaterialBarCodeByModel(model);
        }

        /// <summary>
        /// 验证ID与图号是否属于同一物料
        /// </summary>
        /// <param name="mDrawingNo"></param>
        /// <returns></returns>
        public bool VerifyMaterial(int id, string mDrawingNo)
        {
            return _DAL.VerifyMaterial(id, mDrawingNo);
        }


        /// <summary>
        /// 验证条码ID 与条码卡号 是否关联的同一物料 2020-06-01
        /// </summary>
        /// <param name="id">条码管理ID</param>
        /// <param name="m_cradNo">条码卡号</param>
        /// <returns></returns>
        public BaseMaterialBarCodeModel VerifyMaterialBarcode(string mDrawingNo, string m_specificationmodels)
        {
            return _DAL.VerifyMaterialBarcode(mDrawingNo, m_specificationmodels);
        }


        public bool SaveMaterial(BaseMaterialModel model)
        {
            return _DAL.SaveMaterial(model);
        }

        public bool DeleteMaterial(BaseMaterialModel model)
        {
            return _DAL.DeleteMaterial(model);
        }
        #endregion

        #region 物料类型 Add By Leon 20191014
        public List<BaseMaterialTypeModel> GetMaterialTypeList(BaseMaterialTypeModel model)
        {
            return _DAL.GetMaterialTypeList(model);
        }
        public bool SaveMaterialType(BaseMaterialTypeModel model)
        {
            return _DAL.SaveMaterialType(model);
        }
        public bool DeleteMaterialType(BaseMaterialTypeModel model)
        {
            return _DAL.DeleteMaterialType(model);
        }
        #endregion

        #region 供应商 Add By Leon 20191026
        public List<BaseSupplierModel> GetSupplierList(BaseSupplierModel model)
        {
            return _DAL.GetSupplierList(model);
        }
        public int SaveSupplier(BaseSupplierModel model)
        {
            return _DAL.SaveSupplier(model);
        }

        #endregion

        #region EBOM Add By Leon 20191016
        public List<BaseEBOMModel> GetEBOMList(BaseEBOMModel model)
        {
            return _DAL.GetEBOMList(model);
        }
        public List<BaseEBOMModel> GetEBOMTreeList(BaseEBOMModel model)
        {
            var list = _DAL.GetEBOMList(model);
            var pList = list.Where(_ => _.ebParentID == null || _.ebParentID == 0).ToList();
            EBOMRecursive(list, pList);
            return pList;
        }

        /// <summary>
        /// 递归EBOM
        /// </summary>
        /// <param name="alllist">所有</param>
        /// <param name="selflist">父级ebParentID==0</param>
        void EBOMRecursive(List<BaseEBOMModel> alllist, List<BaseEBOMModel> selflist)
        {
            if (selflist == null)
                selflist = alllist;
            foreach (var item in selflist)
            {
                var pID = item.ebChildID;
                item.children = alllist.Where(_ => _.ebParentID == pID).ToList();
                if (item.children.Count > 0)
                    EBOMRecursive(alllist, item.children);
            }
        }



        /// <summary>
        /// 保存EBOM
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        public int SaveEBOM(BaseEBOMModel model, out string Message)
        {
            return _DAL.SaveEBOM(model, out Message);
        }


        public bool DeleteEBOM(BaseEBOMModel model)
        {
            return _DAL.DeleteEBOM(model);
        }

        /// <summary>
        /// 获取物料拼接图号 零件名称-零件号（图号）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseMaterialModel> GetMaterialDrawingNoList(BaseMaterialModel model)
        {
            return _DAL.GetMaterialDrawingNoList(model);
        }

        #endregion

        #region 领料单 LHR
        /// <summary>
        /// 分页查询领料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsRequisitionMainModel> GetWmsRequisitionMainList(WmsRequisitionMainModel model, out int totalCount) { return _DAL.GetWmsRequisitionMainList(model, out totalCount); }

        /// <summary>
        /// 根据条件查询领料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsRequisitionMainModel> GetWmsRequisitionMainList(WmsRequisitionMainModel model) { return _DAL.GetWmsRequisitionMainList(model); }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteWmsRequisitionMain(string Iv_guid) { return _DAL.DeleteWmsRequisitionMain(Iv_guid); }


        /// <summary>
        /// 根据 Iv_guid获取 领料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsRequisitionDetailModel> GetWmsRequisitionDetail(WmsRequisitionDetailModel model) { return _DAL.GetWmsRequisitionDetail(model); }


        /// <summary>
        /// 保存 领料单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveWmsRequisitionMainDetail(WmsRequisitionMainModel model) { return _DAL.SaveWmsRequisitionMainDetail(model); }

        /// <summary>
        /// 根据 申请单号 条件查询领料单主表最大申请单号
        /// </summary>
        /// <param name="Iv_applyNo"></param>
        /// <returns></returns>
        public List<WmsRequisitionMainModel> GetWmsRequisitionByapplyNo(string Iv_applyNo) { return _DAL.GetWmsRequisitionByapplyNo(Iv_applyNo); }

        #endregion

        #region 配料单 LHR

        /// <summary>
        /// 根据条件查询配料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsBatchingMainModel> GetWmsBatchingMainList(WmsBatchingMainModel model) { return _DAL.GetWmsBatchingMainList(model); }

        /// <summary>
        /// 根据 申请单号 条件查询配料单主表最大申请单号
        /// </summary>
        /// <param name="wb_code"></param>
        /// <returns></returns>
        public List<WmsBatchingMainModel> GetBatchingmainByCode(string wb_code) { return _DAL.GetBatchingmainByCode(wb_code); }

        /// <summary>
        /// 根据 wb_guid 获取配料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<WmsBatchingDetailModel> GetWmsDatchingDetail(WmsBatchingDetailModel model) { return _DAL.GetWmsDatchingDetail(model); }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteWmsBatchingMain(string wb_guid) { return _DAL.DeleteWmsBatchingMain(wb_guid); }

        /// <summary>
        /// 保存 配料单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveWmsBatchingMainDetail(WmsBatchingMainModel model) { return _DAL.SaveWmsBatchingMainDetail(model); }


        /// <summary>
        /// 根据 条码卡类型ID 获取所有条码卡号
        /// </summary>
        /// <param name="barcodeTypeID"></param>
        /// <param name="Status">传入布尔判断条码状态</param>
        /// <returns></returns>
        public List<BaseBarcodeModel> GetBarCodeByBarcodeTypeID(int barcodeTypeID, bool Status) { return _DAL.GetBarCodeByBarcodeTypeID(barcodeTypeID, Status); }


        /// <summary>
        /// 根据 计划获取产品型号下所有必换件配料明细
        /// </summary>
        /// <returns></returns>
        public List<WmsBatchingDetailModel> GetPlanProdBatchingDetail(string pp_guid) { return _DAL.GetPlanProdBatchingDetail(pp_guid); }


        /// <summary>
        /// 根据 领料单获取所有配料明细
        /// </summary>
        /// <returns></returns>
        public List<WmsBatchingDetailModel> GetRequisitionBatchingDetail(string iv_guid) { return _DAL.GetRequisitionBatchingDetail(iv_guid); }

        #endregion

        #region 用户组 WZQ

        /// <summary>
        /// 根据条件查询用户组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseUserGroupModel> GetUserGroupPaging(BaseUserGroupModel model, out int totalCount)
        {
            return _DAL.GetUserGroupPaging(model, out totalCount);
        }

        /// <summary>
        /// 获取用户组信息
        /// </summary>
        /// <returns></returns>
        public List<BaseUserGroupModel> GetUserGroupList()
        {
            return _DAL.GetUserGroupList();
        }

        /// <summary>
        /// 根据角色分类的用户菜单
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TreeviewModel> GetUserTreeView()
        {
            return _DAL.GetUserTreeView();
        }

        // <summary>
        /// 获取默认选中用户
        /// </summary>
        /// <param name="ID">用户组ID</param>
        /// <returns></returns>
        public List<string> DefaultChecked(int ID)
        {
            return _DAL.DefaultChecked(ID);
        }

        /// <summary>
        /// 保存用户组名信息
        /// </summary>
        /// <param name="model">用户组名实体类</param>
        /// <returns></returns>
        public bool SaveBaseUserGroup(BaseUserGroupModel model)
        {
            return _DAL.SaveBaseUserGroup(model);
        }

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="id">ID</param>
        public void DelBaseUserGroup(string id)
        {
            _DAL.DelBaseUserGroup(id);
        }

        #endregion

        #region 消息类型-用户组关联表 WZQ

        /// <summary>
        /// 根据条件查询消息类型-用户组关联信息
        /// </summary>
        /// <param name="model">消息类型-用户组实体类</param>
        /// <returns></returns>
        public List<BaseRelMsgUserModel> GetRelMsgUserPaging(BaseRelMsgUserModel model, out int totalCount)
        {
            return _DAL.GetRelMsgUserPaging(model, out totalCount);
        }

        /// <summary>
        /// 保存消息类型-用户组关联信息
        /// </summary>
        /// <param name="model">消息类型-用户组关联信息实体</param>
        /// <returns></returns>
        public bool SaveBaseRelMsgUser(BaseRelMsgUserModel model)
        {
            return _DAL.SaveBaseRelMsgUser(model);
        }

        /// <summary>
        /// 判断消息类型-用户组关联信息是否存在
        /// </summary>
        /// <param name="MsgTypeId">消息类型ID</param>
        /// <param name="UGroupId">用户组ID</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public bool IsExistRelMsgUser(int MsgTypeId, int UGroupId, int ID = 0)
        {
            return _DAL.IsExistRelMsgUser(MsgTypeId, UGroupId, ID);
        }

        /// <summary>
        /// 删除消息类型-用户组关联信息
        /// </summary>
        /// <param name="id">ID</param>
        public void DelRelMsgUser(string id)
        {
            _DAL.DelRelMsgUser(id);
        }

        #endregion

        #region 消息内容通知信息 WZQ

        /// <summary>
        /// 消息内容通知
        /// </summary>
        /// <param name="model">消息内容实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseMsgContentModel> GetMsgContentPaging(BaseMsgContentModel model, out int totalCount)
        {
            return _DAL.GetMsgContentPaging(model, out totalCount);
        }

        /// <summary>
        /// 保存消息内容
        /// </summary>
        /// <param name="model">消息内容实体</param>
        /// <returns></returns>
        public bool SaveBaseMsgContent(BaseMsgContentModel model)
        {
            return _DAL.SaveBaseMsgContent(model);
        }

        /// <summary>
        /// 删除消息内容通知
        /// </summary>
        /// <param name="id">ID</param>
        public void DelMsgContent(string id)
        {
            _DAL.DelMsgContent(id);
        }
        /// <summary>
        /// 根据人员获取消息通知
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="mcTypeID">消息类型ID</param>
        /// <returns></returns>
        public List<BaseMsgContentModel> GetBaseMsgContent(int userID)
        {
            return _DAL.GetBaseMsgContent(userID);
        }

        /// <summary>
        /// 消息已读
        /// </summary>
        /// <param name="ID">消息通知ID</param>
        public void MsgContentRead(int ID, int userID)
        {
            _DAL.MsgContentRead(ID, userID);
        }

        #endregion

        #region 工具参数配方表 WZQ

        /// <summary>
        /// 工具参数配方信息
        /// </summary>
        /// <param name="model">工具参数配实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseToolforMulaModel> GetToolforMulaPaging(BaseToolforMulaModel model, out int totalCount)
        {
            return _DAL.GetToolforMulaPaging(model, out totalCount);
        }

        /// <summary>
        /// 获取所有工具配方信息
        /// </summary>
        /// <returns></returns>
        public List<BaseToolforMulaModel> GetToolForMulaAll()
        {
            return _DAL.GetToolForMulaAll();
        }

        /// <summary>
        /// 保存工具参数配方信息
        /// </summary>
        /// <param name="model">工具参数配方信息实体</param>
        /// <returns></returns>
        public bool SaveBaseToolforMula(BaseToolforMulaModel model)
        {
            return _DAL.SaveBaseToolforMula(model);
        }

        /// <summary>
        /// 删除工具参数配方信息
        /// </summary>
        /// <param name="id">ID</param>
        public void DelBaseToolforMula(string id)
        {
            _DAL.DelBaseToolforMula(id);
        }

        #endregion

        #region 工具参数配方明细表 WZQ

        /// <summary>
        /// 工具参数配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseToolforMulaDetailModel> GetToolforMulaDetailPaging(BaseToolforMulaDetailModel model, out int totalCount)
        {
            return _DAL.GetToolforMulaDetailPaging(model, out totalCount);
        }

        /// <summary>
        /// 获取所有工具配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细实体</param>
        /// <returns></returns>
        public List<BaseToolforMulaDetailModel> GetToolForMulaDetailAll(BaseToolforMulaDetailModel model)
        {
            return _DAL.GetToolForMulaDetailAll(model);
        }

        /// <summary>
        /// 保存工具参数配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细信息实体</param>
        /// <returns></returns>
        public bool SaveBaseToolforMulaDetail(BaseToolforMulaDetailModel model)
        {
            return _DAL.SaveBaseToolforMulaDetail(model);
        }

        /// <summary>
        /// 删除工具参数配方明细信息
        /// </summary>
        /// <param name="id">ID</param>
        public void DelBaseToolforMulaDetail(string id)
        {
            _DAL.DelBaseToolforMulaDetail(id);
        }

        #endregion

        #region 探伤检测 WZQ

        public bool SaveFlawDetectionResult(LogFlawDetectionModel model)
        {
            return _DAL.SaveFlawDetectionResult(model);
        }

        /// <summary>
        /// 获取探伤检验数据
        /// </summary>
        /// <param name="model">探伤检验实体</param>
        /// <returns></returns>
        public List<LogFlawDetectionModel> GetFlawDetectionList(LogFlawDetectionModel model)
        {
            return _DAL.GetFlawDetectionList(model);
        }
        #endregion

        #region 计划工序维护 LHR 2020-03-06


        /// <summary>
        /// 计划工序维护分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Base_PartGongxuModel> GetPartGongxu(Base_PartGongxuModel model, out int totalCount)
        {
            return _DAL.GetPartGongxu(model, out totalCount);
        }

        public List<Base_PartGongxuModel> GetPartGongxu(Base_PartGongxuModel model)
        {
            return _DAL.GetPartGongxu(model);
        }


        /// <summary>
        /// 添加 工序维护
        /// </summary>
        /// <param name="model"></param>
        public void AddPartGongxu(Base_PartGongxuModel model)
        {
            _DAL.AddPartGongxu(model);
        }

        /// <summary>
        /// 修改 工序维护
        /// </summary>
        /// <param name="model"></param>
        public void EditPartGongxu(Base_PartGongxuModel model)
        {
            _DAL.EditPartGongxu(model);
        }


        /// <summary>
        /// 逻辑删除 工序维护
        /// </summary>
        /// <param name="id"></param>
        public void DelPartGongxu(string id)
        {
            _DAL.DelPartGongxu(id);
        }


        /// <summary>
        /// 获取 产品型号-图号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductDrawingNoModel()
        {
            return _DAL.GetProductDrawingNoModel();
        }

        /// <summary>
        /// 根据产品型号 查询当前产品型号下所有 工序名称
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Base_PartGongxuModel> GetPartGongxu(int PID)
        {
            return _DAL.GetPartGongxu(PID);
        }

        #endregion

        #region 备料申请主表 LHR 2020-03-18

        /// <summary>
        /// 查询备料申请单记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PmsRequisitionMainModel> GetPmsRequisitionMainList(PmsRequisitionMainModel model)
        {
            return _DAL.GetPmsRequisitionMainList(model);
        }

        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="mainModel">pms_requisitionmain 主表 状态 0.未备料 1.已备料 2.已确认 3.已驳回</param>
        /// <param name="detailModel">pms_requisitiondetail 子表 状态 0.未备料 1.已备料 2.已确认 3.已驳回 4.少料 5.缺料</param>
        /// <param name="pp_status">计划状态 0：未开始；1：已下发任务；2：已开始任务；3：已完成 4：已驳回</param>
        /// <returns></returns>
        public int Reject(List<PmsRequisitionMainModel> mainModel, List<PmsRequisitionDetailModel> detailModel, int pp_status)
        {
            return _DAL.Reject(mainModel, detailModel, pp_status);
        }


        #endregion

        #region 备料申请从表 LHR 2020-03-18

        /// <summary>
        /// 根据备料申请单据编码 查询备料明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PmsRequisitionDetailModel> GetPmsRequisitionDetailList(PmsRequisitionDetailModel model)
        {
            return _DAL.GetPmsRequisitionDetailList(model);
        }


        /// <summary>
        /// 通过产品编号获取备料申请物料明细
        /// </summary>
        /// <param name="prodNo"></param>
        /// <returns></returns>
        public List<PmsRequisitionDetailModel> GetPmsRequisitionDetailList(string prodNo)
        {
            return _DAL.GetPmsRequisitionDetailList(prodNo);
        }

        /// <summary>
        /// 根据计划单据编码查询 配件计划备料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model)
        {
            return _DAL.GetPartPlanStockList(model);
        }



        /// <summary>
        /// 通用修改备料申请单状态
        /// </summary>
        /// <param name="model">pms_requisitiondetail 子表明细</param>
        /// <param name="pm_status">pms_requisitionmain 主表状态</param>
        /// <returns></returns>
        public int SavePmsRequisitionDetail(List<PmsRequisitionDetailModel> model, int pm_status)
        {
            return _DAL.SavePmsRequisitionDetail(model, pm_status);
        }



        /// <summary>
        /// 绑定产品编码
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RequisitionMainmodel"></param>
        /// <returns></returns>
        public int SaveBindProdNo(ProductInfoModel model, PmsRequisitionMainModel RequisitionMainmodel)
        {
            return _DAL.SaveBindProdNo(model, RequisitionMainmodel);
        }

        #endregion

        #region 物料条码卡管理 LHR 2020-05-07

        /// <summary>
        /// 物料条码卡管理分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseMaterialBarCodeModel> GetMaterialBarCodePage(BaseMaterialBarCodeModel model, out int totalCount)
        {
            return _DAL.GetMaterialBarCodePage(model, out totalCount);
        }


        /// <summary>
        /// 判断条码卡和物料ID是否存在
        /// </summary>
        /// <param name="UNID"></param>
        /// <param name="m_cardNo"></param>
        /// <param name="m_MaterialID"></param>
        /// <returns></returns>
        public bool IsExistMaterialBarCode(int UNID, string m_cardNo, int m_MaterialID)
        {
            return _DAL.IsExistMaterialBarCode(UNID, m_cardNo, m_MaterialID);
        }


        /// <summary>
        /// 添加/修改物料条码卡信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveMaterialBarCode(BaseMaterialBarCodeModel model)
        {
            return _DAL.SaveMaterialBarCode(model);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteMaterialBarCode(string id)
        {
            return _DAL.DeleteMaterialBarCode(id);
        }



        #endregion

        #region 图片轮播配置


        /// <summary>
        /// 图片轮播配置 分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BaseImgCarousel> GetImgCarouselPage(BaseImgCarousel model, out int totalCount)
        {
            return _DAL.GetImgCarouselPage(model, out totalCount);
        }


        /// <summary>
        /// 添加/修改 图片轮播配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SaveImgCarousel(BaseImgCarousel model)
        {
            return _DAL.SaveImgCarousel(model);
        }

        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DelImgCarousel(string id)
        {
            return _DAL.DelImgCarousel(id);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteImgCarousel(string id)
        {
            return _DAL.DeleteImgCarousel(id);
        }

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateSort(List<BaseImgCarousel> model)
        {
            return _DAL.UpdateSort(model);
        }

        #endregion

        #region PPT 轮播

        /// <summary>
        /// PPT 轮播配置 分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<BasePPTCarousel> GetPptCarouselPage(BasePPTCarousel model, out int totalCount)
        {
            return _DAL.GetPptCarouselPage(model, out totalCount);
        }

        /// <summary>
        /// 添加/修改 PPT 轮播配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SavePptCarousel(BasePPTCarousel model)
        {
            return _DAL.SavePptCarousel(model);
        }

        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DelPptCarousel(string id)
        {
            return _DAL.DelPptCarousel(id);
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeletePptCarousel(string id)
        {
            return _DAL.DeletePptCarousel(id);
        }

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdatePptSort(List<BasePPTCarousel> model)
        {
            return _DAL.UpdatePptSort(model);
        }


        /// <summary>
        /// 根据相应的cfg_code 修改大屏、ppt轮播 切换时间
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int UpdateConfig(string code, string value)
        {
            return _DAL.UpdateConfig(code, value);
        }


        #endregion

        #region 配料管理

        /// <summary>
        /// 分页查询
        /// </summary>
        public List<BatchingRecordModel> BatchingRecordForPage(BatchingRecordModel model, out int totalCount)
        {
            return _DAL.BatchingRecordForPage(model, out totalCount);
        }

        /// <summary>
        /// 新增
        /// </summary>
        public void AddBatchingRecord(BatchingRecordModel model)
        {
            _DAL.AddBatchingRecord(model);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public void EditBatchingRecordState(BatchingRecordModel model)
        {
            _DAL.EditBatchingRecordState(model);
        }

        /// <summary>
        /// 条件查询 
        /// </summary>
        public BatchingRecordModel GetBatchingRecord(BatchingRecordModel model)
        {
            return _DAL.GetBatchingRecord(model);
        }
        #endregion

        #region 配方管理

        public List<BaseFormulaModel> GetFormula(string formulaCode, int id)
        {
            return _DAL.GetFormula(formulaCode, id);
        }

        public List<BaseFormulaModel> GetFormulaByFCode(string formulaCode)
        {
            return _DAL.GetFormulaByFCode(formulaCode);
        }

        public List<BaseFormulaModel> GetFormulaByPmodel(int pModelId)
        {
            return _DAL.GetFormulaByPmodel(pModelId);
        }

        public int EditFormula(BaseFormulaModel model)
        {
            return _DAL.EditFormula(model);
        }

        public int DeleteFormula(int ID)
        {
            return _DAL.DeleteFormula(ID);
        }
        #endregion
    }
}
