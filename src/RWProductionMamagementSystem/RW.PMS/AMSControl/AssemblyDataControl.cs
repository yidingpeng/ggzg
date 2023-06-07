using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IBLL.Programs;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Programs;
using RW.PMS.Model.Sys;
using RW.PMS.Utils;
using RW.PMS.WinForm.Common;

namespace RW.PMS.WinForm
{
    internal class AssemblyDataControl
    {

        //基础信息业务层
        private IBLL_BaseInfo _baseInfoBLL = DIService.GetService<IBLL_BaseInfo>();
        //系统信息业务层
        private IBLL_System _systemBLL = DIService.GetService<IBLL_System>();
        //工艺程序配置业务层
        private IBLL_ProgramInfo _programBLL = DIService.GetService<IBLL_ProgramInfo>();
        //装配信息业务层
        private IBLL_Assembly _assemblyBLL = DIService.GetService<IBLL_Assembly>();
        //追溯信息业务层
        private IBLL_Follow _followBLL = DIService.GetService<IBLL_Follow>();
        //添加产品信息
        private IBLL_ProductInfo _productionBLL = DIService.GetService<IBLL_ProductInfo>();
        //计划信息业务层
        private IBLL_Plan _planBLL = DIService.GetService<IBLL_Plan>();
        //点位信息业务层
        private IBLL_PointInfo _pointBLL = DIService.GetService<IBLL_PointInfo>();

        //质检信息业务层
        //private IBLL_Check _checkBLL = DIService.GetService<IBLL_Check>();

        public ProductInfoModel _assembpRro;

        public AssemblyGwModel _assembGw;

        public AssemblyGxModel _assembGx;

        public AssemblyGbModel _assembGb;

        public AssemblyGJModel _assembGjwl;

        /// <summary>
        /// 工具拿错异常ID
        /// </summary>
        public int ToolsErrorID { get; private set; }

        /// <summary>
        /// 物料拿错异常ID
        /// </summary>
        public int WuliaoErrorID { get; private set; }

        /// <summary>
        /// 异常下线异常ID
        /// </summary>
        public int ErrOfflineErrID { get; private set; }

        /// <summary>
        /// 返回工步异常ID
        /// </summary>
        public int ReturnFirstGbErrID { get; private set; }

        /// <summary>
        /// 当前组装工具Guid
        /// </summary>
        public Guid? CurAssbmGjGuid { get; set; }

        /// <summary>
        /// 当前组装工步Guid
        /// </summary>
        public Guid? CurAssbmGbGuid { get; set; }

        /// <summary>
        /// 当前组装工步Guid
        /// </summary>
        public Guid? CurAssbmGxGuid { get; set; }

        /// <summary>
        /// 当前组装工位Guid
        /// </summary>
        public Guid? CurAssbmGwGuid { get; set; }

        /// <summary>
        /// 产品信息ID
        /// </summary>
        public int? ProductInfoID { get; set; }

        /// <summary>
        /// 分装部件编号 2020-05-27
        /// </summary>
        public string QR_Code { get; set; }

        /// <summary>
        /// 总装 产品系列号 2020-12-11 质检模块用
        /// </summary>
        public string serialNumber { get; set; }

        /// <summary>
        /// 管控方式
        /// </summary>
        public List<BaseDataModel> ControlTypes { get; private set; }

        /// <summary>
        /// 是否为总装工位
        /// </summary>
        public bool IsFinishGw { get; private set; }

        /// <summary>
        /// 关键信息主表ID
        /// </summary>
        public Guid? AssemblyMainGuid { get; set; }

        /// <summary>
        /// 扭力扳手列表
        /// </summary>
        public List<KeyValuePair<string, string>> TorqueItems { get; set; }

        public AssemblyDataControl()
        {
            Init();
        }

        /// <summary>
        /// 获取系统时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime()
        {
            return _systemBLL.GetDateTime();
        }

        public void Init()
        {
            GetErrorType();

            ControlTypes = _systemBLL.GetBaseDataTypeValue("ControlType");

            CurAssbmGjGuid = null;
            CurAssbmGbGuid = null;
            CurAssbmGxGuid = null;
            CurAssbmGwGuid = null;

            //ProductInfoID = null;
            QR_Code = null;// 分装部件编号 2020-05-27
            IsFinishGw = false;

        }

        /// <summary>
        /// 获取生产记录信息
        /// </summary>
        /// <param name="prodNo"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfo(string prodNo)
        {
            var prodInfo = _productionBLL.GetProductInfoByProdNo(prodNo);
            return prodInfo;
        }

        /// <summary>
        /// 获取物料配送信息
        /// </summary>
        /// <returns></returns>
        public BatchingRecordModel GetBatchingRecord(BatchingRecordModel model)
        {
            var prodInfo = _baseInfoBLL.GetBatchingRecord(model);
            return prodInfo;
        }
         
        /// <summary>
        /// 获取生产记录信息
        /// </summary>
        /// <param name="prodID"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfo(int prodID)
        {
            var prodInfo = _productionBLL.GetProductInfoByProdID(prodID);
            return prodInfo;
        }

        /// <summary>
        /// 获取产品型号
        /// </summary>
        /// <returns></returns>
        public List<BaseProductModelModel> GetProductModelAll()
        {
            List<BaseProductModelModel> list = _baseInfoBLL.GetProductModelAll();

            return list;
        }

        /// <summary>
        /// 获取错误类型 
        /// </summary>
        /// <returns></returns>
        private bool GetErrorType()
        {
            var errors = new string[] { "ToolsError", "WuliaoError", "ErrorOffline", "returnFirstGb" };
            var gbErrorData = DIService.GetService<IBLL_System>().GetBaseDataTypeValue("GbErrorType");
            if (gbErrorData == null || gbErrorData.Count == 0 || gbErrorData.Where(f => errors.Contains(f.bdcode)).Count() != errors.Length)
            {
                return false;
            }
            ToolsErrorID = gbErrorData.FirstOrDefault(f => f.bdcode == "ToolsError").ID;
            WuliaoErrorID = gbErrorData.FirstOrDefault(f => f.bdcode == "WuliaoError").ID;
            ErrOfflineErrID = gbErrorData.FirstOrDefault(f => f.bdcode == "ErrorOffline").ID;
            ReturnFirstGbErrID = gbErrorData.FirstOrDefault(f => f.bdcode == "returnFirstGb").ID;

            return true;
        }

        /// <summary>
        /// 保存设备运行时间
        /// </summary>
        public string SaveDeviceFunTime()
        {
            string msg = string.Empty;

            if (SysConfig.IsUseGwDevice)
            {
                msg = _assemblyBLL.DeviceRun(PublicVariable.LocalIP);
            }

            return msg;
        }

        /// <summary>
        /// 获取工序视频
        /// </summary>
        /// <returns></returns>
        public List<VideoModel> GetGXVideo(string localIP)
        {
            var videoModels = _programBLL.GetVideoByIP(localIP);

            return videoModels;
        }

        /// <summary>
        /// 获取工位下所有程序的下拉选项
        /// </summary>
        /// <returns></returns>
        public List<KeyValuePair<int, string>> GetProdModelForDDL(int gwID)
        {
            var list = _assemblyBLL.GetProdModelForDDL(gwID);

            return list;
        }

        /// <summary>
        /// 获取产品型号信息 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseProductModelModel GetBaseProductModelId(int id)
        {
            var model = _baseInfoBLL.GetBaseProductModelId(id);

            return model;
        }

        /// <summary>
        /// 获取opc点位信息
        /// </summary>
        /// <returns></returns>
        public List<GwGJWLOPCPointModel> GetAllOPCTag(string localIP, bool isClear)
        {
            var opcTags = _assemblyBLL.GetAllOPCTag(localIP, isClear);

            return opcTags;
        }

        /// <summary>
        /// 获取程序下拉列表,查询 工位、产品、程序、组件关联信息表gw_prod_def
        /// </summary>
        /// <param name="prodModelID"></param>
        /// <returns></returns>
        public List<KeyValuePair<int, string>> GetProgramForDLL(int gwID, int prodModelID)
        {
            var list = _assemblyBLL.GetProgramForDLL(gwID, prodModelID, 0);

            return list;
        }

        /// <summary>
        /// 获取工步图片
        /// </summary>
        /// <param name="proGBID"></param>
        /// <returns></returns>
        public byte[] GetGBImage(int proGBID)
        {
            var image = _programBLL.GetGBImage(proGBID);

            return image;
        }

        /// <summary>
        /// 获取程序工序工步列表
        /// </summary>
        /// <param name="programID"></param>
        /// <returns></returns>
        public List<ProGXGBModel> ProgGXGBList(int programID)
        {
            var progGXGBList = _programBLL.ProgGXGBList(programID);

            var progGJList = _programBLL.ProgGJValList(programID);

            foreach (var item in progGXGBList)
            {
                item.GJWLModels = progGJList.Where(f => f.ProgGBID == item.progGBID).ToList();
            }

            ////是否是总装工位
            //if (progGXGBList.Count > 0)
            //{
            //    IsFinishGw = progGXGBList.FirstOrDefault().IsFinishGW == 1;
            //}

            //扭力扳手列表 2020-07-04
            TorqueItems = GetTorque(progGXGBList);

            return progGXGBList;
        }

        /// <summary>
        /// 添加异常信息
        /// </summary>
        /// <param name="errorTypeID"></param>
        /// <param name="errDesp"></param>
        public void AddErrorInfo(int errorTypeID, string errDesp)
        {

            var assembErr = new AssemblyErrorInfoModel
            {
                ErrorTypeID = errorTypeID,
                pInfo_ID = ProductInfoID,
                agw_guid = CurAssbmGwGuid,//2020-05-18添加异常信息工位GUID 
                agx_guid = CurAssbmGxGuid,//2020-05-18添加异常信息工序GUID 
                agb_guid = CurAssbmGbGuid,//2020-05-18添加异常信息工步GUID 
                agj_guid = CurAssbmGjGuid,//2020-05-18添加异常信息工具GUID 
                err_gwID = SysConfig.CurGwID,
                err_gw = SysConfig.CurGwName,
                err_operID = PublicVariable.CurEmpID,
                err_oper = PublicVariable.CurEmpName,
                errDate = DateTime.Now,
                errorDesp = errDesp,
                remark = string.Empty,
            };
            _assemblyBLL.AddErrorInfo(assembErr);
        }

        /// <summary>
        /// 添加组装工位信息
        /// </summary>
        /// <param name="gwID">工位ID</param>
        /// <param name="gwName">工位名称</param>
        /// <param name="progID">程序ID</param>
        /// <param name="progName">程序名称</param>
        /// <param name="empID">用户ID</param>
        /// <param name="empName">用户名称</param>
        public void AddAssbGw(int gwID, string gwName, int progID, string progName, int empID, string empName)
        {
            _assembGw = new AssemblyGwModel
            {
                agw_guid = Guid.NewGuid(),
                agw_gwID = gwID,
                agw_gwName = gwName,
                //fp_guid = FollowProductionGuid,
                pInfo_ID = ProductInfoID,
                agw_prog_id = progID,
                agw_prog_name = progName,
                agw_operID = empID,
                agw_oper = empName,
                agw_starttime = DateTime.Now,
                agw_finishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.notFinish.ToString(), 0),
                agw_resultIsOK = ConvertHelper.ToInt32(EDAEnums.CheckResult.Non.ToString(), 0),
                agw_resultMemo = string.Empty,
                Fgw_value = string.Empty,//结果值
                agw_QRcode = QR_Code,//用于存放分装部件编号 2020-05-27
                agw_remark = string.Empty
            };
            _assemblyBLL.AddAssemblyGw(_assembGw);

            CurAssbmGwGuid = _assembGw.agw_guid;
        }

        public void GetAssemblyGwDetail(Guid gwguid, Guid gxguid)
        {
            _assembGw = _assemblyBLL.GetAssemblyGwDetail(gwguid);
            _assembGx = _assemblyBLL.GetAssemblyGxDetail(gxguid);
        }

        /// <summary>
        /// 修改组装工位信息
        /// </summary>
        /// <param name="Fgw_finishStatus"></param>
        /// <param name="Fgw_resultIsOK"></param>
        /// <param name="Fgw_resultMemo"></param>
        public void UpdateAssbGw(int Fgw_finishStatus, int Fgw_resultIsOK, string Fgw_resultMemo)
        {
            if (!CurAssbmGwGuid.HasValue || CurAssbmGwGuid == Guid.Empty)
            {
                MessageBox.Show("出错！当前工位GUID为空");
                return;
            }

            if (ProductInfoID.HasValue)
            {
                _assembGw.pInfo_ID = ProductInfoID;
            }
            //用于分装部件编号 2020-05-27
            if (!string.IsNullOrEmpty(QR_Code))
            {
                _assembGw.agw_QRcode = QR_Code;
            }
            _assembGw.agw_finishtime = DateTime.Now;
            _assembGw.agw_finishStatus = Fgw_finishStatus;// 1;//0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
            _assembGw.agw_resultIsOK = Fgw_resultIsOK;// 1;//合格
            _assembGw.agw_resultMemo = Fgw_resultMemo;// "合格";
            _assembGw.Fgw_value = string.Empty;//结果值

            _assemblyBLL.EditAssemblyGw(_assembGw);

            CurAssbmGwGuid = Guid.Empty;
        }

        /// <summary>
        /// 添加组装工序信息
        /// </summary>
        /// <param name="gxID"></param>
        /// <param name="empID"></param>
        /// <param name="empName"></param>
        /// <param name="gxname"></param>
        public void AddAssbGx(int gxID, string gxname, int empID, string empName)
        {
            if (!CurAssbmGwGuid.HasValue && CurAssbmGwGuid == Guid.Empty)
            {
                MessageBox.Show("出错！当前工位GUID为空");
                return;
            }

            _assembGx = new AssemblyGxModel
            {
                agx_guid = Guid.NewGuid(),
                agw_guid = CurAssbmGwGuid,
                //fp_guid = FollowProductionGuid,
                pInfo_ID = ProductInfoID,
                agx_gxID = gxID,
                agx_gxName = gxname,
                agx_operID = empID,
                agx_oper = empName,
                agx_starttime = DateTime.Now,
                agx_finishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.notFinish.ToString(), 0)
            };
            _assemblyBLL.AddAssemblyGx(_assembGx);
            CurAssbmGxGuid = _assembGx.agx_guid;
        }

        /// <summary>
        /// 修改组装工序信息
        /// </summary>
        /// <param name="Fgx_finishStatus"></param>
        /// <param name="Fgx_resultIsOK"></param>
        /// <param name="Fgx_resultMemo"></param>
        public void UpdateAssbGx(int Fgx_finishStatus, int Fgx_resultIsOK, string Fgx_resultMemo)
        {
            if (!CurAssbmGxGuid.HasValue && CurAssbmGxGuid == Guid.Empty)
            {
                MessageBox.Show("出错！当前工序GUID为空");
                return;
            }

            //_assembGx.fp_guid = FollowProductionGuid;
            _assembGx.pInfo_ID = ProductInfoID;
            _assembGx.agx_finishtime = DateTime.Now;
            _assembGx.agx_finishStatus = Fgx_finishStatus;//1;//0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
            _assembGx.agx_resultIsOK = Fgx_resultIsOK;// 1;//合格
            _assembGx.agx_resultMemo = Fgx_resultMemo;// "合格";
            _assembGx.agx_remark = string.Empty;
            _assemblyBLL.EditAssemblyGx(_assembGx);

            CurAssbmGxGuid = Guid.Empty;
        }

        /// <summary>
        /// 添加组装工步信息
        /// </summary>
        /// <param name="gbID"></param>
        /// <param name="gbname"></param>
        /// <param name="empID"></param>
        /// <param name="empName"></param>
        public void AddAssbGb(int gbID, string gbname, int empID, string empName)
        {
            if (CurAssbmGxGuid.HasValue && CurAssbmGxGuid != Guid.Empty)
            {
                _assembGb = new AssemblyGbModel
                {
                    agb_guid = Guid.NewGuid(),
                    agx_guid = CurAssbmGxGuid,
                    //fp_guid = FollowProductionGuid,
                    pInfo_ID = ProductInfoID,
                    agb_gbID = gbID,
                    agb_gbName = gbname,
                    agb_operID = empID,
                    agb_oper = empName,
                    agb_starttime = DateTime.Now,
                    agb_finishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.notFinish.ToString(), 0),
                };
                CurAssbmGbGuid = _assembGb.agb_guid;
            }
        }

        /// <summary>
        /// 修改组装工步信息
        /// </summary>
        /// <param name="timeInterval"></param>
        /// <param name="fgb_finishStatus"></param>
        /// <param name="Fgb_resultIsOK"></param>
        /// <param name="Fgb_resultMemo"></param>
        public void UpdateAssbGb(int timeInterval, int fgb_finishStatus, int Fgb_resultIsOK, string Fgb_resultMemo, string agb_value, string agb_remark)
        {
            if (!CurAssbmGbGuid.HasValue || CurAssbmGbGuid == Guid.Empty)
            {
                MessageBox.Show("出错！当前工步GUID为空");
                return;
            }
            //_assembGb.fp_guid = FollowProductionGuid;
            _assembGb.pInfo_ID = ProductInfoID;
            _assembGb.agb_finishtime = SysConfig.GetServerTime().AddSeconds(timeInterval);
            _assembGb.agb_finishStatus = fgb_finishStatus;//0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
            _assembGb.agb_resultIsOK = Fgb_resultIsOK;//合格
            _assembGb.agb_resultMemo = Fgb_resultMemo;
            _assembGb.agb_finishImg = null;//工步结果图片
            _assembGb.agb_value = agb_value;//结果值
            _assembGb.agb_remark = agb_remark;

            _assemblyBLL.AddAssemblyGb(_assembGb);
        }
         
        /// <summary>
        /// 添加组装工具信息
        /// </summary>
        /// <param name="isGj"></param>
        /// <param name="gjwlID"></param>
        /// <param name="gjwlName"></param>
        /// <param name="empID"></param>
        /// <param name="empName"></param>
        /// <param name="jgwlCode">物料 二维码信息</param>
        /// <param name="value"></param>
        /// <param name="value2"></param>
        public void AddAssbGjWl(bool isGj, int gjwlID, string gjwlName, int empID, string empName, string jgwlCode = "", string value = "", string value2 = "")
        {

            _assembGjwl = new AssemblyGJModel();
            _assembGjwl.agj_guid = Guid.NewGuid();
            CurAssbmGjGuid = _assembGjwl.agj_guid;
            //给实体类赋值
            if (isGj)
            {
                _assembGjwl.agj_gjID = gjwlID;
                _assembGjwl.agj_gjName = gjwlName;
            }
            else
            {
                _assembGjwl.agj_wlID = gjwlID;
                _assembGjwl.agj_wlName = gjwlName;
            }
            //新增组装工具信息
            _assembGjwl.agb_guid = CurAssbmGbGuid;
            //_assembGjwl.fp_guid = FollowProductionGuid;
            _assembGjwl.pInfo_ID = ProductInfoID;
            _assembGjwl.agj_gjwlCode = jgwlCode;
            _assembGjwl.agj_operID = empID;
            _assembGjwl.agj_oper = empName;
            _assembGjwl.agj_value = value;
            _assembGjwl.agj_value2 = value2;
            _assembGjwl.agj_starttime = DateTime.Now;
            _assembGjwl.agj_finishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.notFinish, 0);
        }

        /// <summary>
        /// 修改组装工具信息
        /// </summary>
        /// <param name="curGjFinishStatus"></param>
        /// <param name="curGjResult"></param>
        /// <param name="curGjResultMemo"></param>
        /// <param name="curGjRemark"></param>
        public void UpdateAssbGjWl(int curGjFinishStatus, int curGjResult, string curGjResultMemo, string curGjRemark = "")
        {
            if (!CurAssbmGjGuid.HasValue || CurAssbmGjGuid == Guid.Empty)
            {
                MessageBox.Show("出错！当前工具GUID为空");
                return;
            }
            if (ProductInfoID.HasValue)
            {
                _assembGjwl.pInfo_ID = ProductInfoID;
            }

            _assembGjwl.pInfo_ID = ProductInfoID;
            _assembGjwl.agj_finishtime = DateTime.Now;
            _assembGjwl.agj_finishStatus = curGjFinishStatus;//0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
            _assembGjwl.agj_resultIsOK = curGjResult;//合格
            _assembGjwl.agj_resultMemo = curGjResultMemo;
            _assembGjwl.agj_gjwlCode = _assembGjwl.agj_gjwlCode;
            //_assembGjwl.agj_value = _assembGjwl.agj_value;//工具结果值,用来放扭力值，视觉比对的尺寸
            //_assembGjwl.agj_value2 = _assembGjwl.agj_value2;//工具结果值,用来放扭力值，视觉比对的尺寸
            //_assembGjwl.agj_valueImg = _assembGjwl.agj_valueImg;//工具结果图片值
            _assembGjwl.agj_remark = curGjRemark;//用来存放视觉比对的角度

            _assemblyBLL.AddAssemblyGJ(_assembGjwl);
        }

        /// <summary>
        /// 异常下线处理
        /// </summary>
        /// <param name="gwID"></param>
        /// <param name="gwName"></param>
        /// <param name="empID"></param>
        /// <param name="empName"></param>

        public void ProdErrorOffLine(int gwID, string gwName, int empID, string empName)
        {
            var errDownCode_follow = ConvertHelper.ToInt32(EDAEnums.FollowStatus.errorDown, 2);
            var errDownCode_ams = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.errorDown, 2);
            int errTypeID = ConvertHelper.ToInt32(ErrOfflineErrID, 0);
            _assemblyBLL.ProdErrorOffLine(ProductInfoID.Value, errDownCode_ams, errTypeID, CurAssbmGwGuid.Value, CurAssbmGxGuid.Value, CurAssbmGbGuid.Value, CurAssbmGjGuid,
                "产品装配信息异常下线", empID, empName, gwID, gwName);
        }

        /// <summary>
        /// 保存异常下线信息
        /// </summary>
        public void AddOfflineInfo(AbnormalOfflineModel model)
        {
            _assemblyBLL.AddOfflineInfo(model);
        }

        /// <summary>
        /// 查询异常下线信息
        /// </summary>
        public AbnormalOfflineModel GetOfflineInfo(string code)
        {
            return _assemblyBLL.GetOfflineInfo(code);
        }


        /// <summary>
        /// 修改异常下线信息
        /// </summary>
        public void UpdateOffline(string code)
        {
            _assemblyBLL.UpdateOffline(code);
        }


        /// <summary>
        /// 返回工序第一工步时，修改工序下已组装的工序、工步、工具的完成状态为4
        /// </summary>
        /// <param name="returnCode">装配的工序返回状态编码</param>
        /// <param name="errorDesp">异常描述</param>
        /// <returns></returns>
        public void GongxuReturnUpdateGbGj(int returnCode, string errorDesp)
        {
            _assemblyBLL.GongxuReturnUpdateGbGj(returnCode, CurAssbmGxGuid.Value, ReturnFirstGbErrID, errorDesp);
        }

        /// <summary>
        /// 更新产线组装工位二维码
        /// </summary>
        /// <param name="rqCode"></param>
        /// <param name="assbmGwGuid"></param>
        public void UpdateGwQRcode(string rqCode, Guid assbmGwGuid)
        {
            _assemblyBLL.UpdateGwQRcode(rqCode, assbmGwGuid);
        }

        /// <summary>
        /// 根据产线组装工位二维码，修改工位的产品GUID
        /// </summary>
        /// <param name="gwQRcode"></param>
        /// <param name="prod_guid"></param>
        /// <returns></returns>
        public void UpdateGWfp_guid(string gwQRcode, Guid prod_guid)
        {
            _assemblyBLL.UpdateGWfp_guid(gwQRcode, prod_guid);
        }

        /// <summary>
        ///根据图号判断物料是否存在
        /// </summary>
        /// <param name="mDrawingNo"></param>
        /// <returns></returns>
        public bool VerifyMaterial(int id, string mDrawingNo)
        {
            return _baseInfoBLL.VerifyMaterial(id, mDrawingNo);
        }


        /// <summary>
        /// 验证 图号 与规格或型号 是否为同一物料 2020-10-31
        /// </summary>
        /// <param name="mDrawingNo">图号</param>
        /// <param name="m_specificationmodels">规格或型号</param>
        /// <returns></returns>
        public BaseMaterialBarCodeModel VerifyMaterialBarcode(string mDrawingNo, string m_specificationmodels)
        {
            return _baseInfoBLL.VerifyMaterialBarcode(mDrawingNo, m_specificationmodels);
        }


        /// <summary>
        /// 添加产品信息
        /// </summary>
        /// <param name="pf_prodNo">产品编号</param>
        /// <param name="pf_prodModelID">产品型号</param>
        /// <param name="pp_orderCode">计划订单号</param>
        /// <param name="pf_finishStatus">状态</param>
        public int AddProductInfo(string pf_prodNo, int pf_prodModelID, string pp_orderCode, int pf_finishStatus, int currGwID, string wagonNo)
        {
            _assembpRro = new ProductInfoModel
            {
                pf_prodNo = pf_prodNo,
                pf_prodModelID = pf_prodModelID,
                pp_orderCode = pp_orderCode,
                pf_startTime = DateTime.Now,
                pf_remark = string.Empty,
                currGwID = currGwID,
                deleteFlag = 0,
                createTime = DateTime.Now,
                updateTime = DateTime.Now,
                createMan = PublicVariable.CurEmpID,
                updateMan = PublicVariable.CurEmpID,
            };

            return _productionBLL.SaveProductInfo(_assembpRro, 0);
        }

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="pf_prodNo">产品编号</param>
        /// <param name="pf_prodModelID">产品型号</param>
        /// <param name="pp_orderCode">计划订单号</param>
        /// <param name="pf_finishStatus">状态</param>
        public int UpdateProductInfo(string pf_prodNo, int pf_prodModelID, string pp_orderCode, int pf_finishStatus, int currGwID, string wagonNo)
        {
            _assembpRro = new ProductInfoModel
            {
                pf_prodNo = pf_prodNo,
                pf_prodModelID = pf_prodModelID,
                pp_orderCode = pp_orderCode,
                pf_remark = string.Empty,
                currGwID = currGwID,
                deleteFlag = 0,
                createTime = DateTime.Now,
                updateTime = DateTime.Now,
                createMan = PublicVariable.CurEmpID,
                updateMan = PublicVariable.CurEmpID,
                pf_finishStatus = pf_finishStatus,
                pf_resultIsOK = pf_finishStatus == 1 ? 1 : 0,
                pf_resultMemo = pf_finishStatus == 1 ? "合格" : string.Empty,
            };

            if (pf_finishStatus == 1)
                _assembpRro.pf_finishTime = DateTime.Now;

            return _productionBLL.SaveProductInfo(_assembpRro, 0);
        }


        /// <summary>
        /// 根据生产ID获取信息
        /// </summary>
        /// <param name="prodID"></param>
        /// <returns></returns>
        public ProductInfoModel GetProductInfoByProdID(int prodID)
        {
            return _productionBLL.GetProductInfoByProdID(prodID);
        }


        /// <summary>
        /// 用于最后总装工位结束计划
        /// </summary>
        /// <param name="pp_orderCode"></param>
        /// <param name="UserID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int UpdatePartPlan(string pp_orderCode, int UserID, int status)
        {

            return _planBLL.UpdatePartPlan(pp_orderCode, UserID, status);
        }


        /// <summary>
        /// 查询生产记录列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ProductInfoModel> GetProductList(ProductInfoModel model)
        {
            return _productionBLL.GetProductList(model);
        }


        /// <summary>
        /// 根据分装部件编号查询工位表QRcode字段是否存在
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        public AssemblyGwModel GetAssemblyGwByQRcode(string QRcode)
        {
            return _assemblyBLL.GetAssemblyGwByQRcode(QRcode);
        }


        /// <summary>
        /// 分装部件编号_关联_产品编号
        /// </summary>
        /// <param name="QRcode"></param>
        /// <returns></returns>
        public int AssociatedQRcodeOrProdNo(string QRcode)
        {
            return _assemblyBLL.AssociatedQRcodeOrProdNo(QRcode, ProductInfoID ?? 0, CurAssbmGwGuid.ToString());
        }


        /// <summary>
        /// 是否有电动扭力扳手
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        private List<KeyValuePair<string, string>> GetTorque(List<ProGXGBModel> models)
        {

            var torqueGjNames = models.SelectMany(f => f.GJWLModels.Where(ff => ff.GJTypeCode == EDAEnums.GjTypeCodeEnum.niulibanshou.ToString() || ff.GJTypeCode == EDAEnums.GjTypeCodeEnum.wuxianbanshou.ToString()).Select(ff => ff.GJName)).Distinct().ToList();

            var result = new List<KeyValuePair<string, string>>();

            if (torqueGjNames.Count > 0)
            {
                result = _baseInfoBLL.GetGjRemarks(torqueGjNames);
            }

            return result;

        }


        /// <summary>
        /// 用于启动装配后显示 制造BOM 2020-10-22
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public List<BaseEBOMModel> GetAssemblyMBOM(int progID)
        {
            return _assemblyBLL.GetAssemblyMBOM(progID);
        }


        /// <summary>
        /// 用于启动装配后获取分钟节拍 2020-10-23
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public BaseGwProdDefModel GetGwProdDefByBeatMinite(int progID)
        {
            return _assemblyBLL.GetGwProdDefByBeatMinite(progID);
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
            return _assemblyBLL.UpdateGWXBJSatus(isZZGW, QRcode, status);
        }

        /// <summary>
        /// 获取生产关键信息主表明细
        /// </summary>
        /// <param name="qrCode">条码信息</param>
        /// <returns></returns>
        public AssemblyMainModel GetAssemblyMainDetail(string qrCode, int? pInfoID = null, int? gwID = null)
        {
            var retModel = _assemblyBLL.GetAssemblyMainDetail(pInfoID, rqCode: qrCode, gwID: gwID);
            return retModel;
        }

        /// <summary>
        /// 更新生产关键信息
        /// </summary>
        /// <param name="qrCode"></param>
        /// <param name="gwID"></param>
        /// <param name="pModelID"></param>
        /// <param name="pInfoID"></param>
        /// <returns></returns>
        public Guid UpdateAssemblyMain(string qrCode, int gwID, int pModelID, string userName, Guid? amGuid = null, int? pInfoID = null, bool isFinishGW = false)
        {

            var model = new AssemblyMainModel
            {
                am_guid = amGuid,
                am_QRcode = qrCode,
                am_gwID = gwID,
                pModelID = pModelID,
                am_createUser = userName,
                am_updateUser = userName,
            };
            if (pInfoID.HasValue && pInfoID != 0)
            {
                model.pInfo_ID = pInfoID.Value;
                model.am_pInfoDate = _systemBLL.GetDateTime();
            }
            else
            {
                model.am_parentQRCode = QR_Code;
            }
            var retVal = _assemblyBLL.UpdateAssemblyMain(model, isFinishGW);
            return retVal;
        }

        /// <summary>
        /// 更新关键记录信息
        /// </summary>
        /// <param name="amGuid"></param>
        /// <param name="keyType"></param>
        /// <param name="keyName"></param>
        /// <param name="keyValue"></param>
        /// <param name="keyMark"></param>
        public void UpdateAssemblyMainRecord(Guid amGuid, string keyType, string keyName, string keyValue, string keyMark = "")
        {
            //var model = _assemblyBLL.GetAssemblyMainRecordDetail(amGuid.ToString(), keyType, keyName);
            //if (model == null)
            //{  
            //    model = new AssemblyMainRecordModel();
            //}
            var model = new AssemblyMainRecordModel();
            model.am_guid = amGuid;
            model.amr_type = keyType;
            model.amr_name = keyName;
            model.amr_value = keyValue;
            model.amr_mark = keyMark;
            _assemblyBLL.UpdateAssemblyMainRecord(model);
        }

        /// <summary>
        /// 获取所有点位信息
        /// </summary>
        /// <returns></returns>
        public List<PointInfoModel> GetPointInfo()
        {
            return _pointBLL.GetPointInfo(null, 0);
        }

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <returns></returns>
        public List<SysLogModel> GetSysLog()
        {
            return _systemBLL.GetSysLog(null, null);
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        public void AddSysLog(SysLogModel model)
        {
            _systemBLL.AddSysLog(model);
        }

        /// <summary>
        /// 获取所有维保信息
        /// </summary>
        /// <returns></returns>
        public List<MaintenanceSettingModel> GetMaintenanceSettingAll()
        {
            return _baseInfoBLL.GetMaintenanceSettingAll();
        }

        /// <summary>
        /// 给拧紧设备已使用次数+1
        /// </summary>
        public void AddUsedTimes()
        {
            _baseInfoBLL.AddUsedTimes();
        }
    }
}

