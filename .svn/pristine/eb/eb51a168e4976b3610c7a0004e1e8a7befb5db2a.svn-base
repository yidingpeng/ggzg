using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.IDAL
{
    public interface IDAL_Assembly : IDependence
    {


        #region 产品线组装工位信息

        /// <summary>
        /// 获取产品线组装工位明细
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        AssemblyGwModel GetAssemblyGwDetail(Guid guid);

        /// <summary>
        /// 添加产品线组装工位信息
        /// </summary>
        /// <param name="model"></param>
        void AddAssemblyGw(AssemblyGwModel model);

        /// <summary>
        ///编辑产品线组装工位信息 
        /// </summary>
        /// <param name="model"></param>
        void EditAssemblyGw(AssemblyGwModel model);


        /// <summary>
        /// 根据分装部件编号 获取产品线组装工位明细
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        AssemblyGwModel GetAssemblyGwByQRcode(string QRcode);


        /// <summary>
        /// 分装部件编号_关联_产品编号
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        int AssociatedQRcodeOrProdNo(string QRcode, int pInfo_ID, string AssbmGwGuid);


        /// <summary>
        /// 修改 assembly_gw 、 gx 、 gb 、 gj 装配状态
        /// </summary>
        /// <param name="isZZGW">是否总装</param>
        /// <param name="QRcode">产品序列号 或者 部件编号</param>
        /// <param name="status">装配状态 //0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配</param>
        /// <returns></returns>
        int UpdateGWXBJSatus(bool isZZGW, string QRcode, int status);

        #endregion

        #region 产品线组装工序信息

        /// <summary>
        /// 获取产品线组装工序信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        AssemblyGxModel GetAssemblyGxDetail(Guid guid);

        /// <summary>
        /// 添加产品线组装工序信息
        /// </summary>
        /// <param name="model"></param>
        void AddAssemblyGx(AssemblyGxModel model);

        /// <summary>
        /// 编辑产品线组装工序信息
        /// </summary>
        /// <param name="model"></param>
        void EditAssemblyGx(AssemblyGxModel model);

        #endregion

        #region 产品线组装工步信息

        /// <summary>
        /// 获取产品线组装工步信息明细
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        AssemblyGbModel GetAssemblyGbDetail(Guid guid);

        /// <summary>
        /// 添加产品线组装工步信息
        /// </summary>
        /// <param name="model"></param>
        void AddAssemblyGb(AssemblyGbModel model);

        /// <summary>
        /// 编辑产品线组装工步信息
        /// </summary>
        /// <param name="model"></param>
        void EditAssemblyGb(AssemblyGbModel model);

        #endregion

        #region 生产线组装工具信息

        List<AssemblyGJModel> GetAssemblyToolList(AssemblyGJModel model);

        /// <summary>
        /// 添加生产线组装工具信息
        /// </summary>
        /// <param name="model"></param>
        void AddAssemblyGJ(AssemblyGJModel model);

        /// <summary>
        /// 修改生产线组装工具信息
        /// </summary>
        /// <param name="model"></param>
        void EditAssemblyGJ(AssemblyGJModel model);

        #endregion

        #region 生产关键信息记录

        /// <summary>
        /// 获取生产记录关键信息
        /// </summary>
        /// <param name="prodCode">产品编号</param>
        /// <param name="pModelID">产品型号</param>
        /// <param name="keyType">关键信息类型</param>
        /// <param name="keyValue">关键值</param>
        /// <returns></returns>
        PageModel<List<AssemblyMainModel>> GetAssemblyMainList(string prodCode = "", int? pInfoID = null, int? pModelID = null, int? gwID = null, string keyType = "", string keyValue = "", DateTime? begDate = null, DateTime? endDate = null, int pageIndex = 0, int pageSize = 0);
        List<TightenMachineModel> GetTightenMachineList(string prodCode);
        /// <summary>
        /// 获取生产关键信息主表明细
        /// </summary>
        /// <param name="pInfoID">产品ID</param>
        /// <param name="rqCode">二维码</param>
        /// <returns></returns>
        AssemblyMainModel GetAssemblyMainDetail(int? pInfoID = null, string rqCode = "", int? gwID = null);

        /// <summary>
        /// 更新生产关键信息列表
        /// </summary>
        /// <param name="model"></param>
        Guid UpdateAssemblyMain(AssemblyMainModel model, bool isFinishGW = false);

        /// <summary>
        /// 获取生产关键信息记录表
        /// </summary>
        /// <param name="amGuid"></param>
        /// <param name="keyType"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        List<AssemblyMainRecordModel> GetAssemblyMainRecordList(string[] amGuids = null, string keyType = "", string keyValue = "");
        /// <summary>
        /// 获取生产关键信息记录明细
        /// </summary>
        /// <param name="amGuid">主表ID</param>
        /// <param name="keyType">关键信息类型</param>
        /// <param name="keyName">关键信息名称</param>
        /// <returns></returns>
        AssemblyMainRecordModel GetAssemblyMainRecordDetail(string amGuid, string keyType, string keyName);
        /// <summary>
        /// 更新生产关键信息记录
        /// </summary>
        /// <param name="model"></param>
        void UpdateAssemblyMainRecord(AssemblyMainRecordModel model);

        #endregion

        /// <summary>
        /// 用于启动装配后显示 制造BOM 2020-10-22
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        List<BaseEBOMModel> GetAssemblyMBOM(int progID);

        /// <summary>
        /// 用于启动装配后获取分钟节拍 2020-10-23
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        BaseGwProdDefModel GetGwProdDefByBeatMinite(int progID);

        /// <summary>
        /// 更新产线组装工位二维码
        /// </summary>
        /// <param name="QRcode">二维码</param>
        /// <param name="fgw_guid">工位组装GUID</param>
        /// <returns></returns>
        void UpdateGwQRcode(string QRcode, Guid gw_guid);

        /// <summary>
        /// 根据产线组装工位二维码，修改工位的产品GUID
        /// </summary>
        /// <param name="gwQRcode"></param>
        /// <param name="prod_guid"></param>
        /// <returns></returns>
        void UpdateGWfp_guid(string gwQRcode, Guid prod_guid);

        void AddErrorInfo(AssemblyErrorInfoModel model);


        /// <summary>
        /// 添加拧紧机装配记录
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        bool AddTightenMachineInfo(TightenMachineModel model);

        /// <summary>
        /// 添加拧紧机装配值记录
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        bool AddAssemblyDataInfo(AssemblyDataModel model);

        /// <summary>
        /// 查找工位条形码是否存在
        /// </summary>
        /// <returns>true:存在；false:不存在</returns>
        bool IsExistGwBarcode(string agw_QRcode);

        /// <summary>
        /// 保存工控机设备运行时间
        /// </summary>
        /// <param name="devIP">设备IP</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        string DeviceRun(string devIP);

        /// <summary>
        /// 获取工位下所有程序的下拉选项
        /// </summary>
        /// <param name="gwID"></param>
        /// <returns></returns>
        List<KeyValuePair<int, string>> GetProdModelForDDL(int gwID);

        /// <summary>
        /// 获取程序下拉列表,查询 工位、产品、程序、组件关联信息表gw_prod_def
        /// </summary>
        /// <param name="gwID">工位ID</param>
        /// <param name="prodModelID">产品型号ID</param>
        /// <param name="componentID">组件ID</param>
        /// <returns></returns>
        List<KeyValuePair<int, string>> GetProgramForDLL(int gwID, int prodModelID, int componentID);

        List<GwGJWLOPCPointModel> GetAllOPCTag(string ip, bool isClear);

        /// <summary>
        /// 返回工序第一工步时，修改工序下已组装的工序、工步、工具的完成状态为4
        /// </summary>
        /// <param name="returnCode">装配的工序返回状态编码</param>
        /// <param name="agx_guid">装配工序GUID</param>
        /// <param name="ErrorTypeID">装配异常类型ID</param>
        /// <param name="errorDesp">异常描述</param>
        /// <returns></returns>
        void GongxuReturnUpdateGbGj(int returnCode, Guid agx_guid, int ErrorTypeID, string errorDesp);

        /// <summary>
        /// 装配记录
        /// </summary>
        /// <param name="gwID">工位ID</param>
        /// <param name="prodNo">产品编号</param>
        /// <param name="begingDate">工位开始时间</param>
        /// <param name="endDate">工位完成时间</param>
        /// <returns></returns>
        List<AssemblyRecordModel> GetGongweiAssembly(int gwID, string prodNo, string begingDate, string endDate);

        /// <summary>
        /// 新增异常下线信息
        /// </summary>
        void AddOfflineInfo(AbnormalOfflineModel model);

        /// <summary>
        /// 查询异常下线信息
        /// </summary>
        AbnormalOfflineModel GetOfflineInfo(string code);

        /// <summary>
        /// 修改异常下线信息
        /// </summary>
        void UpdateOffline(string code);

        /// <summary>
        /// 装配的异常下线处理
        /// </summary>
        /// <param name="prodID">系统产品编号ID</param>
        /// <param name="errDownCode_follow">追溯异常下线状态编码</param>
        /// <param name="errDownCode_ams">装配异常下线状态编码</param>
        /// <param name="ErrorTypeID">装配异常类型ID</param>
        /// <param name="fp_QRcode">装配工位二维码</param>
        /// <param name="fgw_guid">装配工位GUID</param>
        /// <param name="fgx_guid">装配工序GUID</param>
        /// <param name="fgb_guid">装配工步GUID</param>
        /// <param name="fgj_guid">装配工具GUID</param>
        /// <param name="errorDesp">异常描述</param>
        /// <param name="errOperID">操作人员ID</param>
        /// <param name="ErrOper">操作人员</param>
        /// <param name="ErrGwID">操作工位ID</param>
        /// <param name="ErrGw">操作工位</param>
        /// <returns></returns>
        void ProdErrorOffLine(int prodID, int errDownCode_ams, int errorTypeID, Guid fgw_guid, Guid fgx_guid, Guid fgb_guid, Guid? fgj_guid, string errorDesp, int errOperID, string errOper, int errGwID, string errGw);
    }
}
