using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Log;
using RW.PMS.Model.Plan;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;

namespace RW.PMS.IDAL
{
    public interface IDAL_BaseInfo : IDependence
    {
        /// <summary>
        /// 通用判断名称是否存在
        /// </summary>
        /// <param name="TabName">表名</param>
        /// <param name="FiledName">字段名称</param>
        /// <param name="Name">查询字段名称值</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        bool IsExistName(string TabName, string FiledName, string Name, int ID = 0);
        void AddBaseGongju(GongjuModel model);
        void AddBaseGongweiRight(BaseGongweiRightModel model);
        void AddBaseGwProdDef(BaseGwProdDefModel model);
        void AddBaseProdLjCheckTip(BasePartCheckTipModel model);
        void AddBaseProduct(BaseProductModel model);
        void AddBaseProductLingJian(BaseProductBomModel model);
        void AddBaseProductModel(BaseProductModelModel model);
        void AddBaseWuliao(WuliaoModel model);
        void DeleteBaseGongJu(string id);
        void DeleteBaseGwProdDef(string id);
        void DeleteBaseProdLjCheckTip(string id);
        void DeleteBaseProduct(string id);
        void DeleteBaseProductLingJian(string id);
        void DeleteBaseProductModel(string id);
        List<MaintenanceSettingModel> GetMaintenanceSettingAll();
        bool AddMaintenanceSetting(MaintenanceSettingModel model);
        MaintenanceSettingModel GetMaintenanceSettingId(int Id);
        List<TighteningRecordModel> GetTighteningRecord(TighteningRecordModel model);

        List<TighteningRecordExcelModel> GetTighteningRecordExcel(TighteningRecordModel model);
        List<TighteningRecordModel> GetTighteningRecord(TighteningRecordModel model, out int totalCount);
        int AddTighteningRecordModel(TighteningRecordModel model);

        bool EditTighteningRecordModel(TighteningRecordModel model);
        bool DeleteTighteningRecord(string id);
        bool EditMaintenanceSetting(MaintenanceSettingModel model);
        bool EditmaintainUsedTime(int Id);
        void AddUsedTimes();
        bool DeleteMaintenanceSetting(string id);
        void DeleteBaseWuliao(string id);
        void EditBaseGongJu(GongjuModel model);
        void EditBaseGongweiRight(BaseGongweiRightModel model);
        void EditBaseGwProdDef(BaseGwProdDefModel model);
        void EditBaseProdLjCheckTip(BasePartCheckTipModel model);
        void EditBaseProduct(BaseProductModel model);
        void EditBaseProductLingJian(BaseProductBomModel model);
        void EditBaseProductModel(BaseProductModelModel model);
        void EditBaseWuliao(WuliaoModel model);
        List<GongjuModel> GetAllBaseGongJu();
        List<BaseGongweiModel> GetAllBaseGongWei(int areaID = 0);
        /// <summary>
        /// 获取产品型号信息2019-05-15
        /// </summary>
        /// <returns></returns>
        List<BaseProductModelModel> GetAllBaseProModel();
        List<WuliaoModel> GetAllBaseWuliao();
        BaseGongweiModel GetBaseGongWeiId(int Id);
        BaseGongweiRightModel GetBaseGongweiRightId(int Id);
        
        List<BaseGongweiRightModel> GetRightList(BaseGongweiRightModel model);
        BaseGwProdDefModel GetBaseGwProdDefId(int Id);
        /// <summary>
        /// 判断工位名称是否有相同的
        /// </summary>
        /// <param name="CardNo"></param>
        /// <returns></returns>
        bool GetGongWeiNameCount(string GwName, int ID = 0);

        BasePartCheckTipModel GetBaseProdLjCheckTipId(int Id);
        int GetStepNo(int prodLjDefId);
        BaseProductModel GetBaseProductId(int Id);
        BaseProductModelModel GetBaseProductModelId(int Id);
        List<BaseProgram> GetBaseProgram();
        WuliaoModel GetBaseWuliaoId(int Id);
        List<BaseDataModel> GetGjType();
        List<GongjuModel> GetGongju();
        List<BaseGongweiModel> GetGongWei();
        bool GetGongWeiIPCount(string IP, int ID);
        List<GongweiModel> GetGongWeiArea(int Id);
        List<GongjuModel> GetPagingBaseGongJu(GongjuModel model, out int totalCount);
        bool SaveBaseGongju(GongjuModel model);
        List<BaseGongweiModel> GetWorkPositionList(BaseGongweiModel model, out int totalCount);
        List<BaseGongweiModel> GetWorkPositionList(BaseGongweiModel model);
        List<BaseGongweiRightModel> GetPagingBaseGongweiRight(BaseGongweiRightModel model, out int totalCount);
        List<BaseGwProdDefModel> GetPagingBaseGwProdDef(BaseGwProdDefModel model, out int totalCount);
        List<BaseProductModel> GetPagingBaseProduct(BaseProductModel model, out int totalCount);
        List<BaseProductBomModel> GetPagingBaseProductLingJian(BaseProductBomModel model, out int totalCount);
        List<BaseBomModel> GetPagingBaseBOM(BaseBomModel model, out int totalCount);
        void AddBaseBom(BaseBomModel model);
        void EditBaseBom(BaseBomModel model);
        void DeleteBaseBom(string id);
        List<BaseProductBomModel> GetBomList(BaseProductBomModel model);
        List<WuliaoModelModel> GetWuliaoCode(int wlID);
        List<BaseProductModelModel> GetPagingBaseProductModel(BaseProductModelModel model, out int totalCount);

        List<BaseProductModelModel> GetBaseProductModel();

        List<BaseOPCProductModel> GetOPCProductModelList(BaseOPCProductModel model, out int totalCount);
        List<BaseProductModelModel> GetProductModelAll();
        List<WuliaoModel> GetPagingBaseWuliao(WuliaoModel model, out int totalCount);
        List<BasePartCheckTipModel> GetPagingProdLjCheckTip(BasePartCheckTipModel model, out int totalCount);
        List<BasePartCheckTipModel> GetProdLjCheckTip();
        List<BaseProductModelModel> GetProductModel();
        List<UserModel> GetUserlist();
        List<BaseDataModel> GetWlType();
        List<WuliaoModel> GetWuliao();
        List<WuliaoModel> GetWuliaoType();
        /// <summary>
        /// 判断物料名称和规格是否存在
        /// </summary>
        /// <param name="wlname">物料名称</param>
        /// <param name="wlcode">物料规格</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        bool IsExistWuliaoNameANDCode(string wlname, string wlcode, int ID = 0);

        /// <summary>
        /// 批量添加物料
        /// </summary>
        /// <param name="model">物料实体类</param>
        /// <returns></returns>
        void SaveWuliaoList(List<WuliaoModel> model);

        /// <summary>
        /// 获取所有物料规格信息下拉
        /// </summary>
        /// <returns></returns>
        List<WuliaoModelModel> GetAllBaseWuliaoCode();

        List<BaseGongweiOpcModel> GetGongWeiOPC(BaseGongweiOpcModel model = null);
        int EditBaseGongWeiOpc(List<BaseGongweiModel> models, int gwid);
        void GwDel(string id);

        bool GetGwByIP(string ip);

        List<BaseToolsModel> GetPagingBaseTools(BaseToolsModel model, out int totalCount);
        void AddBaseTools(BaseToolsModel model);
        /// <summary>
        /// 自动更新每天的状态
        /// </summary>
        void LoadToolsStatus();
        BaseToolsModel GetBaseToolsId(int Id);
        void EditBaseTools(BaseToolsModel model);
        void DeleteBaseTools(string id);
        int GetExpireStatus(DateTime ExpreDate);

        #region CS端代码

        BaseGongweiModel getGwByIP(string ip);

        /// <summary>
        /// 获取总装工位最大排序号
        /// </summary>
        /// <returns></returns>
        int getGwMaxOrder();


        BaseGongweiModel getEntyGwByID(int Id);

        List<BaseProductBomModel> GetWlLjBatch(Guid fm_guid, int pModelID, int componentId, int curAreaID, params int[] replaceTypeID);

        /// <summary>
        /// 获取物料盒信息
        /// </summary>
        /// <param name="wlBoxHasRFID">已有的物料编号，用逗号隔开的字符串</param>
        /// <returns></returns>
        List<WuliaoModel> GetWlBox(params int[] wlBoxHasRFID);


        /// <summary>
        /// 获取产品型号+组件的质检提示
        /// </summary>
        /// <param name="pModelID"></param>
        /// <param name="gwID"></param>
        /// <returns></returns>
        List<BaseProductBomModel> GetCheckTip(int pModelID, int componentId, int wlId);


        /// <summary>
        /// 物料是否为来料区悬挂部件
        /// </summary>
        /// <param name="fm_guid">生产编号GUID</param>
        /// <param name="pModelID">产品型号ID</param>
        /// <returns></returns>
        bool WuliaoIsComingHang(int pModelID, int wuliaoID);


        /// <summary>
        /// 获取工具备注信息（主要用于扭力扳手） 2020-07-04
        /// </summary>
        /// <param name="gjNames"></param>
        /// <returns></returns>
        List<KeyValuePair<string, string>> GetGjRemarks(List<string> gjNames);

        #endregion
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        DateTime GetServerDateTime();

        #region 车辆信息

        List<SubwayInfoModel> GetSubwayInfoList(SubwayInfoModel model);

        #endregion

        #region 存放区信息管理

        List<BaseTempAreaModel> GetTempAreaList(BaseTempAreaModel model, out int totalCount);
        void AddTempArea(BaseTempAreaModel model);
        int EditTempArea(BaseTempAreaModel model);
        int SaveSmallFan(BaseTempAreaModel model);
        void DeleteTempArea(string id);
        string LeaveInComming(Guid pfGuid);
        List<BaseTempAreaModel> GetTempAreaList(BaseTempAreaModel model);

        #endregion

        #region 物料/零件编码规格 LHR

        List<WuliaoModelModel> GetPagingWuliaoCode(WuliaoModelModel model, out int totalCount);
        void AddWuliaoCode(WuliaoModelModel model);
        void EditWuliaoCode(WuliaoModelModel model);
        void DeleteWuliaoCode(string id);

        #endregion

        #region 部件质量检测项标准范围值

        List<BasePartCheckValueModel> GetPartCheckValue(BasePartCheckValueModel model, out int totalCount);
        List<BasePartCheckValueModel> GetPartCheckValueList(BasePartCheckValueModel model);
        void AddPartCheckValue(BasePartCheckValueModel model);
        void EditPartCheckValue(BasePartCheckValueModel model);
        void DeletePartCheckValue(string id);

        #endregion

        #region 产品信息
        List<ProductInfoModel> GetProductInfoList(ProductInfoModel model);
        #endregion

        #region 工位&产品型号关联配置
        List<BaseGwProdDefModel> GetGWProdDefList(BaseGwProdDefModel model);
        #endregion

        #region 条码卡 Leon
        List<BaseBarcodeModel> GetBarCodeList(BaseBarcodeModel model);
        //int BindBarCode(BaseBarcodeModel model);
        #endregion

        #region 库存信息 WZQ

        /// <summary>
        /// 库存分页信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        List<BaseInventoryModel> GetInventoryPage(BaseInventoryModel model, out int totalCount);

        /// <summary>
        /// 获取仓库信息（用于齐套分析）
        /// </summary>
        /// <returns></returns>
        List<BundleAnalysisInventoryModel> GetInventoryList();

        /// <summary>
        /// 判断该规格和仓库是否存在
        /// </summary>
        /// <param name="wlID">物料规格ID</param>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        bool IsExistInventory(int UNID, int wlID, int warehouseID);


        /// <summary>
        /// 添加/修改库存信息
        /// </summary>
        /// <param name="model">库存实体类信息</param>
        int SaveInventory(BaseInventoryModel model);


        /// <summary>
        /// Excel导入仓库信息 全删全插
        /// </summary>
        /// <param name="InventoryList"></param>
        /// <param name="isDeleted">判断是否全删</param>
        /// <returns></returns>
        ResponseResult<string> ImportInventory(List<BaseInventoryModel> InventoryList, bool isDeleted);


        /// <summary>
        /// 将导入的Excel文件合并数量后进行保存
        /// </summary>
        /// <param name="InventoryList"></param>
        /// <returns></returns>
        ResponseResult<string> ImportUniqInventory(List<BaseInventoryModel> InventoryList);


        /// <summary>
        /// 获取库存操作最后时间
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<BaseInventoryLogModel> GetInventoryLogTime(BaseInventoryLogModel model);

        #endregion

        #region 物料 Add By Leon 20191014

        /// <summary>
        /// 物料管理分页 条件查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<BaseMaterialModel> GetMaterialList(BaseMaterialModel model, out int totalCount);
        List<BaseMaterialModel> GetMaterialList(BaseMaterialModel model);

        List<BaseMaterialModel> GetMaterialList();

        /// <summary>
        /// 获取物料字典数据
        /// </summary>
        /// <returns></returns>
        List<BaseMaterialModel> GetMaterialDict();

        List<BaseMaterialModel> GetMaterialList(int progbID);
        /// <summary>
        /// 获取物料条码标字典数据 2020-06-01
        /// </summary>
        /// <returns></returns>
        List<BaseMaterialBarCodeModel> GetMaterialBarCodeDict();

        /// <summary>
        /// 用于条码生成器 获取下拉列表值
        /// </summary>
        /// <returns></returns>
        List<BaseMaterialBarCodeModel> GetMaterialBarCode();


        /// <summary>
        /// 获取条码卡信息
        /// </summary>
        /// <returns></returns>
        BaseMaterialBarCodeModel GetMaterialBarCodeByModel(BaseMaterialBarCodeModel model);

        /// <summary>
        /// 验证ID与图号是否属于同一物料
        /// </summary>
        /// <param name="mDrawingNo"></param>
        /// <returns></returns>
        bool VerifyMaterial(int id, string mDrawingNo);


        /// <summary>
        /// 验证条码ID 与条码卡号 是否关联的同一物料 2020-06-01
        /// </summary>
        /// <param name="id">条码管理ID</param>
        /// <param name="m_cradNo">条码卡号</param>
        /// <returns></returns>
        BaseMaterialBarCodeModel VerifyMaterialBarcode(string mDrawingNo, string m_specificationmodels);


        bool SaveMaterial(BaseMaterialModel model);
        bool DeleteMaterial(BaseMaterialModel model);
        #endregion

        #region 物料类型 Add By Leon 20191014
        List<BaseMaterialTypeModel> GetMaterialTypeList(BaseMaterialTypeModel model);
        bool SaveMaterialType(BaseMaterialTypeModel model);
        bool DeleteMaterialType(BaseMaterialTypeModel model);
        #endregion

        #region 供应商 Add By Leon 20191026
        List<BaseSupplierModel> GetSupplierList(BaseSupplierModel model);
        int SaveSupplier(BaseSupplierModel model);

        #endregion

        #region EBOM Add By Leon 20191016
        List<BaseEBOMModel> GetEBOMList(BaseEBOMModel model);

        /// <summary>
        /// 保存EBOM
        /// </summary>
        /// <param name="model"></param>
        /// <param name="Message"></param>
        /// <returns></returns>
        int SaveEBOM(BaseEBOMModel model, out string Message);

        bool DeleteEBOM(BaseEBOMModel model);

        /// <summary>
        /// 获取物料拼接图号 零件名称-零件号（图号）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<BaseMaterialModel> GetMaterialDrawingNoList(BaseMaterialModel model);

        #endregion

        #region 领料单 LHR
        /// <summary>
        /// 分页查询领料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WmsRequisitionMainModel> GetWmsRequisitionMainList(WmsRequisitionMainModel model, out int totalCount);

        /// <summary>
        /// 根据条件查询领料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WmsRequisitionMainModel> GetWmsRequisitionMainList(WmsRequisitionMainModel model);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeleteWmsRequisitionMain(string Iv_guid);

        /// <summary>
        /// 根据 Iv_guid获取 领料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WmsRequisitionDetailModel> GetWmsRequisitionDetail(WmsRequisitionDetailModel model);

        /// <summary>
        /// 保存 领料单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveWmsRequisitionMainDetail(WmsRequisitionMainModel model);

        /// <summary>
        /// 根据 申请单号 条件查询领料单主表最大申请单号
        /// </summary>
        /// <param name="Iv_applyNo"></param>
        /// <returns></returns>
        List<WmsRequisitionMainModel> GetWmsRequisitionByapplyNo(string Iv_applyNo);

        #endregion

        #region 配料单 LHR

        /// <summary>
        /// 根据条件查询配料单主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WmsBatchingMainModel> GetWmsBatchingMainList(WmsBatchingMainModel model);

        /// <summary>
        /// 根据 申请单号 条件查询配料单主表最大申请单号
        /// </summary>
        /// <param name="wb_code"></param>
        /// <returns></returns>
        List<WmsBatchingMainModel> GetBatchingmainByCode(string wb_code);

        /// <summary>
        /// 根据 wb_guid 获取配料单主从表信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<WmsBatchingDetailModel> GetWmsDatchingDetail(WmsBatchingDetailModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeleteWmsBatchingMain(string wb_guid);

        /// <summary>
        /// 保存 配料单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveWmsBatchingMainDetail(WmsBatchingMainModel model);


        /// <summary>
        /// 根据 条码卡类型ID 获取所有条码卡号
        /// </summary>
        /// <param name="barcodeTypeID"></param>
        /// <param name="Status">传入布尔判断条码状态</param>
        /// <returns></returns>
        List<BaseBarcodeModel> GetBarCodeByBarcodeTypeID(int barcodeTypeID, bool Status);


        /// <summary>
        /// 根据 计划获取产品型号下所有必换件配料明细
        /// </summary>
        /// <returns></returns>
        List<WmsBatchingDetailModel> GetPlanProdBatchingDetail(string pp_guid);


        /// <summary>
        /// 根据 领料单获取所有配料明细
        /// </summary>
        /// <returns></returns>
        List<WmsBatchingDetailModel> GetRequisitionBatchingDetail(string iv_guid);


        #endregion

        #region 用户组 WZQ
        /// <summary>
        /// 根据条件查询用户组
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<BaseUserGroupModel> GetUserGroupPaging(BaseUserGroupModel model, out int totalCount);

        /// <summary>
        /// 获取用户组信息
        /// </summary>
        /// <returns></returns>
        List<BaseUserGroupModel> GetUserGroupList();

        /// <summary>
        /// 根据角色分类的用户菜单
        /// </summary>
        /// <returns></returns>
        IEnumerable<TreeviewModel> GetUserTreeView();

        /// <summary>
        /// 获取默认选中用户
        /// </summary>
        /// <param name="ID">用户组ID</param>
        /// <returns></returns>
        List<string> DefaultChecked(int ID);


        /// <summary>
        /// 保存用户组名信息
        /// </summary>
        /// <param name="model">用户组名实体类</param>
        /// <returns></returns>
        bool SaveBaseUserGroup(BaseUserGroupModel model);

        /// <summary>
        /// 删除用户组
        /// </summary>
        /// <param name="id">ID</param>
        void DelBaseUserGroup(string id);

        #endregion

        #region 消息类型-用户组关联表 WZQ

        /// <summary>
        /// 根据条件查询消息类型-用户组关联信息
        /// </summary>
        /// <param name="model">消息类型-用户组实体类</param>
        /// <returns></returns>
        List<BaseRelMsgUserModel> GetRelMsgUserPaging(BaseRelMsgUserModel model, out int totalCount);

        /// <summary>
        /// 保存消息类型-用户组关联信息
        /// </summary>
        /// <param name="model">消息类型-用户组关联信息实体</param>
        /// <returns></returns>
        bool SaveBaseRelMsgUser(BaseRelMsgUserModel model);

        /// <summary>
        /// 判断消息类型-用户组关联信息是否存在
        /// </summary>
        /// <param name="MsgTypeId">消息类型ID</param>
        /// <param name="UGroupId">用户组ID</param>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        bool IsExistRelMsgUser(int MsgTypeId, int UGroupId, int ID = 0);

        /// <summary>
        /// 删除消息类型-用户组关联信息
        /// </summary>
        /// <param name="id">ID</param>
        void DelRelMsgUser(string id);

        #endregion

        #region 消息内容通知信息 WZQ

        /// <summary>
        /// 消息内容通知
        /// </summary>
        /// <param name="model">消息内容实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        List<BaseMsgContentModel> GetMsgContentPaging(BaseMsgContentModel model, out int totalCount);

        /// <summary>
        /// 保存消息内容
        /// </summary>
        /// <param name="model">消息内容实体</param>
        /// <returns></returns>
        bool SaveBaseMsgContent(BaseMsgContentModel model);

        /// <summary>
        /// 删除消息内容通知
        /// </summary>
        /// <param name="id">ID</param>
        void DelMsgContent(string id);

        /// <summary>
        /// 根据人员获取消息通知
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <returns></returns>
        List<BaseMsgContentModel> GetBaseMsgContent(int userID);

        /// <summary>
        /// 消息已读
        /// </summary>
        /// <param name="ID">消息通知ID</param>
        void MsgContentRead(int ID, int userID);


        #endregion

        #region 工具参数配方表 WZQ

        /// <summary>
        /// 工具参数配方信息
        /// </summary>
        /// <param name="model">工具参数配实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        List<BaseToolforMulaModel> GetToolforMulaPaging(BaseToolforMulaModel model, out int totalCount);

        /// <summary>
        /// 获取所有工具配方信息
        /// </summary>
        /// <returns></returns>
        List<BaseToolforMulaModel> GetToolForMulaAll();


        /// <summary>
        /// 保存工具参数配方信息
        /// </summary>
        /// <param name="model">工具参数配方信息实体</param>
        /// <returns></returns>
        bool SaveBaseToolforMula(BaseToolforMulaModel model);

        /// <summary>
        /// 删除工具参数配方信息
        /// </summary>
        /// <param name="id">ID</param>
        void DelBaseToolforMula(string id);

        #endregion

        #region 工具参数配方明细表 WZQ
        /// <summary>
        /// 工具参数配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细实体</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        List<BaseToolforMulaDetailModel> GetToolforMulaDetailPaging(BaseToolforMulaDetailModel model, out int totalCount);

        /// <summary>
        /// 获取所有工具配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细实体</param>
        /// <returns></returns>
        List<BaseToolforMulaDetailModel> GetToolForMulaDetailAll(BaseToolforMulaDetailModel model);


        /// <summary>
        /// 保存工具参数配方明细信息
        /// </summary>
        /// <param name="model">工具参数配方明细信息实体</param>
        /// <returns></returns>
        bool SaveBaseToolforMulaDetail(BaseToolforMulaDetailModel model);

        /// <summary>
        /// 删除工具参数配方明细信息
        /// </summary>
        /// <param name="id">ID</param>
        void DelBaseToolforMulaDetail(string id);

        #endregion

        #region 探伤检测 WZQ

        bool SaveFlawDetectionResult(LogFlawDetectionModel model);

        /// <summary>
        /// 获取探伤检验数据
        /// </summary>
        /// <param name="model">探伤检验实体</param>
        /// <returns></returns>
        List<LogFlawDetectionModel> GetFlawDetectionList(LogFlawDetectionModel model);


        #endregion

        #region 计划工序维护 LHR 2020-03-06


        /// <summary>
        /// 计划工序维护分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<Base_PartGongxuModel> GetPartGongxu(Base_PartGongxuModel model, out int totalCount);


        List<Base_PartGongxuModel> GetPartGongxu(Base_PartGongxuModel model);

        /// <summary>
        /// 添加 工序维护
        /// </summary>
        /// <param name="model"></param>
        void AddPartGongxu(Base_PartGongxuModel model);

        /// <summary>
        /// 修改 工序维护
        /// </summary>
        /// <param name="model"></param>
        void EditPartGongxu(Base_PartGongxuModel model);


        /// <summary>
        /// 逻辑删除 工序维护
        /// </summary>
        /// <param name="id"></param>
        void DelPartGongxu(string id);


        /// <summary>
        /// 获取 产品型号-图号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<BaseProductModelModel> GetProductDrawingNoModel();


        /// <summary>
        /// 根据产品型号 查询当前产品型号下所有 工序名称
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<Base_PartGongxuModel> GetPartGongxu(int PID);


        #endregion

        #region 备料申请主表 LHR 2020-03-18

        /// <summary>
        /// 查询备料申请单记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<PmsRequisitionMainModel> GetPmsRequisitionMainList(PmsRequisitionMainModel model);

        /// <summary>
        /// 驳回
        /// </summary>
        /// <param name="mainModel">pms_requisitionmain 主表 状态 0.未备料 1.已备料 2.已确认 3.已驳回</param>
        /// <param name="detailModel">pms_requisitiondetail 子表 状态 0.未备料 1.已备料 2.已确认 3.已驳回 4.少料 5.缺料</param>
        /// <param name="pp_status">计划状态 0：未开始；1：已下发任务；2：已开始任务；3：已完成 4：已驳回</param>
        /// <returns></returns>
        int Reject(List<PmsRequisitionMainModel> mainModel, List<PmsRequisitionDetailModel> detailModel, int pp_status);




        #endregion

        #region 备料申请从表 LHR 2020-03-18

        /// <summary>
        /// 根据备料申请单据编码 查询备料明细
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<PmsRequisitionDetailModel> GetPmsRequisitionDetailList(PmsRequisitionDetailModel model);

        /// <summary>
        /// 通过产品编号获取备料申请物料明细
        /// </summary>
        /// <param name="prodNo"></param>
        /// <returns></returns>
        List<PmsRequisitionDetailModel> GetPmsRequisitionDetailList(string prodNo);

        /// <summary>
        /// 根据计划单据编码查询 配件计划备料信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<PartPlanStockModel> GetPartPlanStockList(PartPlanStockModel model);



        /// <summary>
        /// 通用修改备料申请单状态
        /// </summary>
        /// <param name="model">pms_requisitiondetail 子表明细</param>
        /// <param name="pm_status">pms_requisitionmain 主表状态</param>
        /// <returns></returns>
        int SavePmsRequisitionDetail(List<PmsRequisitionDetailModel> model, int pm_status);


        /// <summary>
        /// 绑定产品编码
        /// </summary>
        /// <param name="model"></param>
        /// <param name="RequisitionMainmodel"></param>
        /// <returns></returns>
        int SaveBindProdNo(ProductInfoModel model, PmsRequisitionMainModel RequisitionMainmodel);

        #endregion

        #region 物料条码卡管理 LHR 2020-05-07

        /// <summary>
        /// 物料条码卡管理分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        List<BaseMaterialBarCodeModel> GetMaterialBarCodePage(BaseMaterialBarCodeModel model, out int totalCount);


        /// <summary>
        /// 判断条码卡和物料ID是否存在
        /// </summary>
        /// <param name="UNID"></param>
        /// <param name="m_cardNo"></param>
        /// <param name="m_MaterialID"></param>
        /// <returns></returns>
        bool IsExistMaterialBarCode(int UNID, string m_cardNo, int m_MaterialID);


        /// <summary>
        /// 添加/修改物料条码卡信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SaveMaterialBarCode(BaseMaterialBarCodeModel model);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeleteMaterialBarCode(string id);



        #endregion

        #region 图片轮播配置


        /// <summary>
        /// 图片轮播配置 分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        List<BaseImgCarousel> GetImgCarouselPage(BaseImgCarousel model, out int totalCount);


        /// <summary>
        /// 添加/修改 图片轮播配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int SaveImgCarousel(BaseImgCarousel model);

        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DelImgCarousel(string id);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool DeleteImgCarousel(string id);


        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdateSort(List<BaseImgCarousel> model);


        #endregion

        #region PPT 轮播

        /// <summary>
        /// PPT 轮播配置 分页信息
        /// </summary>
        /// <param name="model">实体类信息</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
         List<BasePPTCarousel> GetPptCarouselPage(BasePPTCarousel model, out int totalCount);

        /// <summary>
        /// 添加/修改 PPT 轮播配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         int SavePptCarousel(BasePPTCarousel model);

        /// <summary>
        /// 单个图片删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         bool DelPptCarousel(string id);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         bool DeletePptCarousel(string id);

        /// <summary>
        /// 更新排序
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int UpdatePptSort(List<BasePPTCarousel> model);


        /// <summary>
        /// 根据相应的cfg_code 修改大屏、ppt轮播 切换时间
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        int UpdateConfig(string code, string value);

        #endregion

        #region 配料管理

        /// <summary>
        /// 分页查询
        /// </summary>
        List<BatchingRecordModel> BatchingRecordForPage(BatchingRecordModel model, out int totalCount);

        /// <summary>
        /// 新增
        /// </summary>
        void AddBatchingRecord(BatchingRecordModel model);

        /// <summary>
        /// 修改
        /// </summary>
        void EditBatchingRecordState(BatchingRecordModel model);

        /// <summary>
        /// 条件查询 
        /// </summary>
        BatchingRecordModel GetBatchingRecord(BatchingRecordModel model);

        #endregion


        #region 配方管理

        /// <summary>
        /// 查询配方数据
        /// </summary>
        /// <param name="formulaCode"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        List<BaseFormulaModel> GetFormula(string formulaCode, int id);

        /// <summary>
        /// 通过配方编号获取配方信息
        /// </summary>
        /// <param name="formulaCode"></param>
        /// <returns></returns>
        List<BaseFormulaModel> GetFormulaByFCode(string formulaCode);

        /// <summary>
        /// 通过产品型号获取配方数据
        /// </summary>
        /// <param name="pModelId"></param>
        /// <returns></returns>
        List<BaseFormulaModel> GetFormulaByPmodel(int pModelId);

        /// <summary>
        /// 根据编号获取配方数据
        /// </summary>
        /// <param name="formulaCode"></param>
        /// <returns></returns>
        BaseFormulaModel GetFormulaByCode(string formulaCode);

        /// <summary>
        /// 添加、修改配方
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int EditFormula(BaseFormulaModel model);

        /// <summary>
        /// 删除配方
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int DeleteFormula(int ID);

        #endregion
    }
}
