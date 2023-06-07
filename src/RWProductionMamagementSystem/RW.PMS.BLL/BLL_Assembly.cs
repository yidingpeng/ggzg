using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.IDAL;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.BLL
{
    internal class BLL_Assembly : IBLL_Assembly
    {
        private IDAL_Assembly _Assembly;

        public BLL_Assembly()
        {
            _Assembly = DIService.GetService<IDAL_Assembly>();
        }

        #region 产品线组装工位信息

        /// <summary>
        /// 获取产品线组装工位明细
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public AssemblyGwModel GetAssemblyGwDetail(Guid guid)
        {
            return _Assembly.GetAssemblyGwDetail(guid);
        }

        /// <summary>
        /// 添加产品线组装工位信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGw(AssemblyGwModel model)
        {
            _Assembly.AddAssemblyGw(model);
        }

        /// <summary>
        ///编辑产品线组装工位信息 
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGw(AssemblyGwModel model)
        {
            _Assembly.EditAssemblyGw(model);
        }


        /// <summary>
        /// 根据分装部件编号 获取产品线组装工位明细
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        public AssemblyGwModel GetAssemblyGwByQRcode(string QRcode)
        {
            return _Assembly.GetAssemblyGwByQRcode(QRcode);
        }


        /// <summary>
        /// 分装部件编号_关联_产品编号
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        public int AssociatedQRcodeOrProdNo(string QRcode, int pInfo_ID, string AssbmGwGuid)
        {
            return _Assembly.AssociatedQRcodeOrProdNo(QRcode, pInfo_ID, AssbmGwGuid);
        }

        /// <summary>
        /// 修改 assembly_gw 、 gx 、 gb 、 gj 装配状态
        /// </summary>
        /// <param name="isZZGW">是否总装</param>
        /// <param name="QRcode">产品序列号 或者 部件编号</param>
        /// <param name="status">装配状态 //0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配</param>
        /// <returns></returns>
        public int UpdateGWXBJSatus(bool isZZGW, string QRcode, int status)
        {
            return _Assembly.UpdateGWXBJSatus(isZZGW, QRcode, status);
        }

        #endregion

        #region 产品线组装工序信息

        /// <summary>
        /// 获取产品线组装工序信息
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public AssemblyGxModel GetAssemblyGxDetail(Guid guid)
        {
            return _Assembly.GetAssemblyGxDetail(guid);
        }

        /// <summary>
        /// 添加产品线组装工序信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGx(AssemblyGxModel model)
        {
            _Assembly.AddAssemblyGx(model);
        }

        /// <summary>
        /// 编辑产品线组装工序信息
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGx(AssemblyGxModel model)
        {
            _Assembly.EditAssemblyGx(model);
        }

        #endregion

        #region 产品线组装工步信息

        /// <summary>
        /// 获取产品线组装工步信息明细
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public AssemblyGbModel GetAssemblyGbDetail(Guid guid)
        {
            return _Assembly.GetAssemblyGbDetail(guid);
        }

        /// <summary>
        /// 添加产品线组装工步信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGb(AssemblyGbModel model)
        {
            _Assembly.AddAssemblyGb(model);
        }

        /// <summary>
        /// 编辑产品线组装工步信息
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGb(AssemblyGbModel model)
        {
            _Assembly.EditAssemblyGb(model);
        }

        #endregion

        #region 生产线组装工具信息

        public List<AssemblyGJModel> GetAssemblyToolList(AssemblyGJModel model)
        {
            return _Assembly.GetAssemblyToolList(model);
        }

        /// <summary>
        /// 添加生产线组装工具信息
        /// </summary>
        /// <param name="model"></param>
        public void AddAssemblyGJ(AssemblyGJModel model)
        {
            _Assembly.AddAssemblyGJ(model);
        }

        /// <summary>
        /// 修改生产线组装工具信息
        /// </summary>
        /// <param name="model"></param>
        public void EditAssemblyGJ(AssemblyGJModel model)
        {
            _Assembly.EditAssemblyGJ(model);
        }

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
        public PageModel<List<AssemblyMainModel>> GetAssemblyMainList(string prodCode, int? pInfoID = null, int? pModelID = null, int? gwID = null, string keyType = "", string keyValue = "", DateTime? begDate = null, DateTime? endDate = null, int pageIndex = 0, int pageSize = 0)
        {
            return _Assembly.GetAssemblyMainList(prodCode, pInfoID, pModelID, gwID, keyType, keyValue, begDate, endDate, pageIndex, pageSize);
        }
        public List<TightenMachineModel> GetTightenMachineList(string prodCode)
        { return _Assembly.GetTightenMachineList(prodCode); }
        /// <summary>
        /// 获取生产关键信息主表明细
        /// </summary>
        /// <param name="pInfoID">产品ID</param>
        /// <param name="rqCode">二维码</param>
        /// <returns></returns>
        public AssemblyMainModel GetAssemblyMainDetail(int? pInfoID = null, string rqCode = "", int? gwID = null)
        {
            return _Assembly.GetAssemblyMainDetail(pInfoID, rqCode, gwID);
        }

        /// <summary>
        /// 更新生产关键信息列表
        /// </summary>
        /// <param name="model"></param>
        public Guid UpdateAssemblyMain(AssemblyMainModel model, bool isFinishGW = false)
        {
            return _Assembly.UpdateAssemblyMain(model, isFinishGW);
        }

        /// <summary>
        /// 获取生产关键信息记录表
        /// </summary>
        /// <param name="amGuid"></param>
        /// <param name="keyType"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public List<AssemblyMainRecordModel> GetAssemblyMainRecordList(string[] amGuids = null, string keyType = "", string keyValue = "")
        {
            return _Assembly.GetAssemblyMainRecordList(amGuids, keyType, keyValue);
        }

        /// <summary>
        /// 获取生产关键信息记录明细
        /// </summary>
        /// <param name="amGuid">主表ID</param>
        /// <param name="keyType">关键信息类型</param>
        /// <param name="keyName">关键信息名称</param>
        /// <returns></returns>
        public AssemblyMainRecordModel GetAssemblyMainRecordDetail(string amGuid, string keyType, string keyName)
        {
            return _Assembly.GetAssemblyMainRecordDetail(amGuid, keyType, keyName);
        }

        /// <summary>
        /// 更新生产关键信息记录
        /// </summary>
        /// <param name="model"></param>
        public void UpdateAssemblyMainRecord(AssemblyMainRecordModel model)
        {
            _Assembly.UpdateAssemblyMainRecord(model);
        }

        #endregion

        /// <summary>
        /// 用于启动装配后显示 制造BOM 2020-10-22
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public List<BaseEBOMModel> GetAssemblyMBOM(int progID)
        {
            return _Assembly.GetAssemblyMBOM(progID);
        }

        /// <summary>
        /// 用于启动装配后获取分钟节拍 2020-10-23
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public BaseGwProdDefModel GetGwProdDefByBeatMinite(int progID)
        {
            return _Assembly.GetGwProdDefByBeatMinite(progID);
        }

        /// <summary>
        /// 更新产线组装工位二维码
        /// </summary>
        /// <param name="QRcode">二维码</param>
        /// <param name="fgw_guid">工位组装GUID</param>
        /// <returns></returns>
        public void UpdateGwQRcode(string QRcode, Guid gw_guid)
        {
            _Assembly.UpdateGwQRcode(QRcode, gw_guid);
        }

        /// <summary>
        /// 根据产线组装工位二维码，修改工位的产品GUID
        /// </summary>
        /// <param name="gwQRcode"></param>
        /// <param name="prod_guid"></param>
        /// <returns></returns>
        public void UpdateGWfp_guid(string gwQRcode, Guid prod_guid)
        {
            _Assembly.UpdateGWfp_guid(gwQRcode, prod_guid);
        }

        /// <summary>
        /// 根据程序获取产品型号、产品ID
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>

        /// <summary>
        /// 获取产品编码
        /// </summary>
        /// <param name="prodNo"></param>
        /// <param name="curAssbmProdGuid"></param>
        /// <returns></returns>
        public void AddErrorInfo(AssemblyErrorInfoModel model)
        {
            _Assembly.AddErrorInfo(model);
        }

        /// <summary>
        /// 添加拧紧机装配记录
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddTightenMachineInfo(TightenMachineModel model)
        {
            return _Assembly.AddTightenMachineInfo(model);
        }

        /// <summary>
        /// 添加拧紧机装配值记录
        /// </summary>
        /// <param name="Assembly_errorInfo"></param>
        /// <returns></returns>
        public bool AddAssemblyDataInfo(AssemblyDataModel model)
        {
            return _Assembly.AddAssemblyDataInfo(model);
        }

        /// <summary>
        /// 查找工位条形码是否存在
        /// </summary>
        /// <returns>true:存在；false:不存在</returns>
        public bool IsExistGwBarcode(string agw_QRcode)
        {
            return _Assembly.IsExistGwBarcode(agw_QRcode);
        }

        /// <summary>
        /// 保存工控机设备运行时间
        /// </summary>
        /// <param name="devIP">设备IP</param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public string DeviceRun(string devIP)
        {
            return _Assembly.DeviceRun(devIP);
        }

        /// <summary>
        /// 获取工位下所有程序的下拉选项
        /// </summary>
        /// <param name="gwID"></param>
        /// <returns></returns>
        public List<KeyValuePair<int, string>> GetProdModelForDDL(int gwID)
        {
            return _Assembly.GetProdModelForDDL(gwID);
        }

        /// <summary>
        /// 获取程序下拉列表,查询 工位、产品、程序、组件关联信息表
        /// </summary>
        /// <param name="gwID">工位ID</param>
        /// <param name="prodModelID">产品型号ID</param>
        /// <param name="componentID">组件ID</param>
        /// <returns></returns>
        public List<KeyValuePair<int, string>> GetProgramForDLL(int gwID, int prodModelID, int componentID)
        {
            return _Assembly.GetProgramForDLL(gwID, prodModelID, componentID);
        }

        public List<GwGJWLOPCPointModel> GetAllOPCTag(string ip, bool isClear)
        {
            return _Assembly.GetAllOPCTag(ip, isClear);
        }

        /// <summary>
        /// 返回工序第一工步时，修改工序下已组装的工序、工步、工具的完成状态为4
        /// </summary>
        /// <param name="returnCode">装配的工序返回状态编码</param>
        /// <param name="agx_guid">装配工序GUID</param>
        /// <param name="ErrorTypeID">装配异常类型ID</param>
        /// <param name="errorDesp">异常描述</param>
        /// <returns></returns>
        public void GongxuReturnUpdateGbGj(int returnCode, Guid agx_guid, int ErrorTypeID, string errorDesp)
        {
            _Assembly.GongxuReturnUpdateGbGj(returnCode, agx_guid, ErrorTypeID, errorDesp);
        }

        /// <summary>
        /// 装配记录
        /// </summary>
        /// <param name="gwID">工位ID</param>
        /// <param name="prodNo">产品编号</param>
        /// <param name="begingDate">工位开始时间</param>
        /// <param name="endDate">工位完成时间</param>
        /// <returns></returns>
        public List<AssemblyRecordModel> GetGongweiAssembly(int gwID, string prodNo, string begingDate, string endDate)
        {
            return _Assembly.GetGongweiAssembly(gwID, prodNo, begingDate, endDate);
        }

        /// <summary>
        /// 新增异常下线信息
        /// </summary>
        public void AddOfflineInfo(AbnormalOfflineModel model)
        {
            _Assembly.AddOfflineInfo(model);
        }

        /// <summary>
        /// 查询异常下线信息
        /// </summary>
        public AbnormalOfflineModel GetOfflineInfo(string code)
        {
            return _Assembly.GetOfflineInfo(code);
        }

        /// <summary>
        /// 修改异常下线信息
        /// </summary>
        public void UpdateOffline(string code)
        {
            _Assembly.UpdateOffline(code);
        }

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
        public void ProdErrorOffLine(int prodID, int errDownCode_ams, int errorTypeID, Guid fgw_guid,
            Guid fgx_guid, Guid fgb_guid, Guid? fgj_guid, string errorDesp, int errOperID, string errOper, int errGwID, string errGw)
        {
            _Assembly.ProdErrorOffLine(prodID, errDownCode_ams, errorTypeID, fgw_guid, fgx_guid, fgb_guid, fgj_guid, errorDesp, errOperID, errOper, errGwID, errGw);
        }
    }
}
