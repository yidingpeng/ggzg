using RW.PMS.Common;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Device;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using RW.PMS.Model.BaseInfo;
namespace RW.PMS.IDAL
{
    public interface IDAL_Device : IDependence
    {
        void AddDevice(DeviceModel model);
        void AddDevicePlan(Device_upKeepPlanModel model);

        void AddDeviceSpotCheck(DeviceSpotCheckModel model);

        void EditDeviceSpotCheck(DeviceSpotCheckModel model);

        void DelDeviceSpotCheck(string id);
        void DelDevice(string id);
        void DelDevicePlan(string id);

        #region 设备保养计划子表维护

        List<Device_upkeepPlanDetailModel> DevicePlanDetailForPage(Device_upkeepPlanDetailModel model, out int totalCount);

        List<Device_upkeepPlanDetailModel> GetDevicePlanDetail();

        void AddDevicePlanDetail(Device_upkeepPlanDetailModel model);

        void EditDevicePlanDetail(Device_upkeepPlanDetailModel model);

        void DelDevicePlanDetail(string id);

        #endregion
        List<DeviceModel> DeviceForPage(DeviceModel model, out int totalCount);
        List<Device_upKeepPlanModel> DevicePlanForPage(Device_upKeepPlanModel model, out int totalCount);

        List<DeviceSpotCheckModel> DeviceSpotCheckPage(DeviceSpotCheckModel model, out int totalCount);

        List<DeviceSpotCheckModel> GetDeviceSpotCheck();
        void EditDevice(DeviceModel model);
        void EditDevicePlan(Device_upKeepPlanModel model);
        //void EditTestItemValue(TestItemModel model);
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

        bool SaveInspection(List<DeviceRemindModel> list);

         /// <summary>
        /// 设备提醒明细信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<DeviceRemindModel> GetDeviceRemindForPage(DeviceRemindModel model, out int totalCount);
        /// <summary>
        /// s设备点检首页 肖玉新
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<DeviceCheckingModel> DevicePlandainjian(DeviceCheckingModel model, out int totalCount);

        List<DeviceCheckingDetailsModel> DeviceCheckingDEtailsancheng(DeviceCheckingDetailsModel model, out int totalCount);

        List<Device_upKeepPlanModel> DeviceCheckincektishouye(Device_upKeepPlanModel model, out int totalCount);
        /// <summary>
        /// 保养明细 肖玉新
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
