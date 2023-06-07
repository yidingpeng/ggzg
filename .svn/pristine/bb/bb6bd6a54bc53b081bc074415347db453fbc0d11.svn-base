using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Device;
using RW.PMS.Model.Sys;
using RW.PMS.IDAL;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.BLL
{
    internal class BLL_Device : IBLL_Device
    {
        private IDAL_Device _DAL = null;

        public BLL_Device()
        {
            _DAL = DIService.GetService<IDAL_Device>();
        }

        #region 设备管理 LHR 2019-3-5

        /// <summary>
        /// 查询设备管理信息 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceModel> DeviceForPage(DeviceModel model, out int totalCount)
        {
            return _DAL.DeviceForPage(model, out totalCount);
        }

        public List<DeviceModel> GetAllDevice()
        {
            return _DAL.GetAllDevice();
        }
        public DeviceModel getDevice(int id)
        {
            return _DAL.getDevice(id);
        }

        /// <summary>
        /// 添加 设备管理信息
        /// </summary>
        /// <param name="model"></param>
        public void AddDevice(DeviceModel model)
        {
            _DAL.AddDevice(model);
        }

        /// <summary>
        /// 修改 设备管理信息
        /// </summary>
        /// <param name="model"></param>
        public void EditDevice(DeviceModel model)
        {
            _DAL.EditDevice(model);
        }

        /// <summary>
        /// 删除 设备管理信息
        /// </summary>
        /// <param name="id"></param>
        public void DelDevice(string id)
        {
            _DAL.DelDevice(id);
        }


        #endregion

        #region 设备保养/点检项目
        /// <summary>
        /// 设备保养/点检项点
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceSpotCheckModel> DeviceSpotCheckPage(DeviceSpotCheckModel model, out int totalCount)
        {
            return _DAL.DeviceSpotCheckPage(model, out totalCount);
        }
        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceSpotCheckModel> GetDeviceSpotCheck()
        {
            return _DAL.GetDeviceSpotCheck();
        }
        /// <summary>
        /// 修改绑定 保养/点检项点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DeviceSpotCheckModel GetDeviceSpotCheckbyId(int id)
        {
            return _DAL.GetDeviceSpotCheckbyId(id);
        }

        /// <summary>
        /// 添加 保养/点检项点
        /// </summary>
        /// <param name="model"></param>
        public void AddDeviceSpotCheck(DeviceSpotCheckModel model)
        {
            _DAL.AddDeviceSpotCheck(model);
        }

        /// <summary>
        /// 修改 保养/点检项点
        /// </summary>
        /// <param name="model"></param>
        public void EditDeviceSpotCheck(DeviceSpotCheckModel model)
        {
            _DAL.EditDeviceSpotCheck(model);
        }


        /// <summary>保养/点检项点设备保养维护计划
        /// </summary>
        /// <param name="id"></param>
        public void DelDeviceSpotCheck(string id)
        {
            _DAL.DelDeviceSpotCheck(id);
        }

        #endregion

        #region 设备计划管理 LHR 2019-3-5

        /// <summary>
        /// 设备保养维护计划 分页数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Device_upKeepPlanModel> DevicePlanForPage(Device_upKeepPlanModel model, out int totalCount)
        {
            return _DAL.DevicePlanForPage(model, out totalCount);
        }

        /// <summary>
        /// 获取所有 设备信息
        /// </summary>
        /// <returns></returns>
        public List<DeviceModel> GetDevice()
        {
            return _DAL.GetDevice();
        }


        /// <summary>
        /// 修改绑定 设备保养维护计划
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Device_upKeepPlanModel GetDevicePlanbyId(int id)
        {
            return _DAL.GetDevicePlanbyId(id);
        }

        /// <summary>
        /// 添加 设备保养维护计划
        /// </summary>
        /// <param name="model"></param>
        public void AddDevicePlan(Device_upKeepPlanModel model)
        {
            _DAL.AddDevicePlan(model);
        }

        /// <summary>
        /// 修改 设备保养维护计划
        /// </summary>
        /// <param name="model"></param>
        public void EditDevicePlan(Device_upKeepPlanModel model)
        {
            _DAL.EditDevicePlan(model);
        }

        /// <summary>
        /// 删除 设备保养维护计划
        /// </summary>
        /// <param name="id"></param>
        public void DelDevicePlan(string id)
        {
            _DAL.DelDevicePlan(id);
        }


        #endregion

        #region 设备保养计划子表维护 LHR 2020-03-03

        public List<Device_upkeepPlanDetailModel> DevicePlanDetailForPage(Device_upkeepPlanDetailModel model, out int totalCount)
        {
            return _DAL.DevicePlanDetailForPage(model, out totalCount);
        }

        public List<Device_upkeepPlanDetailModel> GetDevicePlanDetail()
        {
            return _DAL.GetDevicePlanDetail();
        }

        public void AddDevicePlanDetail(Device_upkeepPlanDetailModel model)
        {
            _DAL.AddDevicePlanDetail(model);
        }

        public void EditDevicePlanDetail(Device_upkeepPlanDetailModel model)
        {
            _DAL.EditDevicePlanDetail(model);
        }

        public void DelDevicePlanDetail(string id)
        {
            _DAL.DelDevicePlanDetail(id);
        }

        #endregion

        #region 设备提醒管理 LHR 2019-3-5
        /// <summary>
        /// 设备提醒明细信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceRemindModel> GetDeviceRemindForPage(DeviceRemindModel model, out int totalCount)
        {
            return _DAL.GetDeviceRemindForPage(model, out totalCount);
        }

        #endregion

        #region 设备运行情况 WZQ
        /// <summary>
        /// 设备运行情况
        /// </summary>
        /// <param name="model">设备运行情况实体类</param>
        /// <param name="totalCount">总数量</param>
        /// <returns></returns>
        public List<DeviceRunModel> GetDeviceRunForPage(DeviceRunModel model, out int totalCount)
        {
            return _DAL.GetDeviceRunForPage(model, out totalCount);
        }


        /// <summary>
        /// 获取时长
        /// </summary>
        /// <param name="StartDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
        public int getHour(DateTime StartDate, DateTime EndDate)
        {
            return _DAL.getHour(StartDate, EndDate);
        }

        #endregion


        #region CS端

        #region 设备点检
        /// <summary>
        /// 获取设备点检数据
        /// </summary>
        /// <returns></returns>
        public List<DeviceCheckingDetailsModel> GetCheckingDetailsDate()
        {
            return _DAL.GetCheckingDetailsDate();
        }
        /// <summary>
        /// 保存设备点检主表和明细表
        /// </summary>
        /// <param name="mainModel"></param>
        /// <param name="checkEntyList"></param>
        /// <returns></returns>
        public bool SaveDeviceCheck(DeviceCheckingModel mainModel, List<DeviceCheckingDetailsModel> checkEntyList)
        {
            return _DAL.SaveDeviceCheck(mainModel, checkEntyList);
        }

        /// <summary>
        /// 保存设备保养主表和明细表
        /// </summary>
        /// <param name="mainModel"></param>
        /// <param name="checkEntyList"></param>
        /// <returns></returns>
        public bool SaveDevicePlan(Device_upKeepPlanModel mainModel, List<Device_upkeepPlanDetailModel> checkEntyList)
        {
            return _DAL.SaveDevicePlan(mainModel, checkEntyList);
        }
        #endregion

        #region 设备提醒

        /// <summary>
        /// 获取设备到期提醒的数据
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public List<BaseToolsModel> GetToolsRemindCount(string IP = "")
        {
            return _DAL.GetToolsRemindCount(IP);
        }

        /// <summary>
        /// 保存送检
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool SaveInspection(List<DeviceRemindModel> list)
        {
            return _DAL.SaveInspection(list);
        }

        #endregion

        #region 设备保养计划
        /// <summary>
        /// 根据IP获取设备保养计划
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        public Device_upKeepPlanModel GetUpKeepPlanIP(string IP)
        {
            return _DAL.GetUpKeepPlanIP(IP);
        }


        public List<DeviceSpotCheckModel> GetUpKeepPlanByIP(string IP)
        {
            return _DAL.GetUpKeepPlanByIP(IP);
        }

        /// <summary>
        /// 执行设备保养计划
        /// </summary>
        /// <param name="devID"></param>
        /// <param name="UserID"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        public bool UpdateDevExecTime(int devID, int UserID, string EmpName)
        {
            return _DAL.UpdateDevExecTime(devID, UserID, EmpName);
        }

        public List<DeviceCheckingModel> DevicePlandainjian(DeviceCheckingModel model, out int totalCount) 
        {
            return _DAL.DevicePlandainjian(model, out totalCount);
        }

        /// <summary>
        /// 点检明细表 肖玉新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<DeviceCheckingDetailsModel> DeviceCheckingDEtailsancheng(DeviceCheckingDetailsModel model, out int totalCount) {
            return _DAL.DeviceCheckingDEtailsancheng(model, out totalCount);
        }

        /// <summary>
        /// 保养首页 肖玉新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<Device_upKeepPlanModel> DeviceCheckincektishouye(Device_upKeepPlanModel model, out int totalCount) {
            return _DAL.DeviceCheckincektishouye(model, out totalCount);
        }

        public List<Device_upkeepPlanDetailModel> DeviceCheckincektiminxin(Device_upkeepPlanDetailModel model, out int totalCount) {
            return _DAL.DeviceCheckincektiminxin(model, out totalCount);
        }
        public List<Device_upkeepPlanDetailModel> DeviceCheckincektitupia(int id) {

            return _DAL.DeviceCheckincektitupia(id);
        }
        #endregion

        #endregion
    }
}
