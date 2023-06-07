using RW.PMS.Common;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Device;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using RW.PMS.Model.BaseInfo;

namespace RW.PMS.IBLL
{
    public interface IBLL_Device : IDependence
    {
        void AddDevice(DeviceModel model);
        void AddDevicePlan(Device_upKeepPlanModel model);

        void AddDeviceSpotCheck(DeviceSpotCheckModel model);
        void DelDevice(string id);
        void DelDevicePlan(string id);
        void DelDeviceSpotCheck(string id);
        List<DeviceModel> DeviceForPage(DeviceModel model, out int totalCount);
        List<Device_upKeepPlanModel> DevicePlanForPage(Device_upKeepPlanModel model, out int totalCount);

        List<DeviceSpotCheckModel> DeviceSpotCheckPage(DeviceSpotCheckModel model, out int totalCount);

        List<DeviceSpotCheckModel> GetDeviceSpotCheck();
        void EditDevice(DeviceModel model);
        void EditDevicePlan(Device_upKeepPlanModel model);

        void EditDeviceSpotCheck(DeviceSpotCheckModel model);
        List<DeviceModel> GetDevice();

        List<DeviceModel> GetAllDevice();
        DeviceModel getDevice(int id);
        Device_upKeepPlanModel GetDevicePlanbyId(int id);
        DeviceSpotCheckModel GetDeviceSpotCheckbyId(int id);
        List<DeviceRunModel> GetDeviceRunForPage(DeviceRunModel model, out int totalCount);
        int getHour(DateTime StartDate, DateTime EndDate);
        List<DeviceCheckingDetailsModel> GetCheckingDetailsDate();
        bool SaveDeviceCheck(DeviceCheckingModel mainModel, List<DeviceCheckingDetailsModel> checkEntyList);

        bool SaveDevicePlan(Device_upKeepPlanModel mainModel, List<Device_upkeepPlanDetailModel> checkEntyList);
        /// <summary>
        /// 根据IP获取设备保养计划
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        Device_upKeepPlanModel GetUpKeepPlanIP(string IP);


        List<DeviceSpotCheckModel> GetUpKeepPlanByIP(string IP);

        /// <summary>
        /// 执行设备保养计划
        /// </summary>
        /// <param name="devID"></param>
        /// <param name="UserID"></param>
        /// <param name="EmpName"></param>
        /// <returns></returns>
        bool UpdateDevExecTime(int devID, int UserID, string EmpName);

        /// <summary>
        /// 获取设备到期提醒的数据
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        List<BaseToolsModel> GetToolsRemindCount(string IP = "");

        /// <summary>
        /// 保存送检
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        bool SaveInspection(List<DeviceRemindModel> list);

        /// <summary>
        /// 设备提醒明细信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<DeviceRemindModel> GetDeviceRemindForPage(DeviceRemindModel model, out int totalCount);


        #region 设备保养计划子表维护 LHR 2020-03-03

        List<Device_upkeepPlanDetailModel> DevicePlanDetailForPage(Device_upkeepPlanDetailModel model, out int totalCount);

        List<Device_upkeepPlanDetailModel> GetDevicePlanDetail();

        void AddDevicePlanDetail(Device_upkeepPlanDetailModel model);

        void EditDevicePlanDetail(Device_upkeepPlanDetailModel model);

        void DelDevicePlanDetail(string id);
        /// <summary>
        /// 设备点检表首页 name: 肖玉新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<DeviceCheckingModel> DevicePlandainjian(DeviceCheckingModel model, out int totalCount);
        /// <summary>
        /// 设备点检明细表 肖玉新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<DeviceCheckingDetailsModel> DeviceCheckingDEtailsancheng(DeviceCheckingDetailsModel model, out int totalCount);
        #endregion
        /// <summary>
        /// 保养首页
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<Device_upKeepPlanModel> DeviceCheckincektishouye(Device_upKeepPlanModel model, out int totalCount);
        /// <summary>
        /// 保养明细
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<Device_upkeepPlanDetailModel> DeviceCheckincektiminxin(Device_upkeepPlanDetailModel model, out int totalCount);
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Device_upkeepPlanDetailModel> DeviceCheckincektitupia(int id);
    }
}
