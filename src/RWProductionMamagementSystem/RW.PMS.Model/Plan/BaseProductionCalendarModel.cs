using System;

namespace RW.PMS.Model.Plan
{
    /// <summary>
    /// 生产日历表
    /// </summary>
    public class BaseProductionCalendarModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 全部资源标识
        /// </summary>
        public int pcAllFlag { get; set; }

        /// <summary>
        /// 设备ID，取自base_device.id
        /// </summary>
        public int pcDeviceID { get; set; }

        public string pcDeviceName { get; set; }

        /// <summary>
        /// 人员ID，取自sys_User.UserID
        /// </summary>
        public int pcPersonID { get; set; }

        public string pcPersonName { get; set; }

        /// <summary>
        /// 工位ID，取自base_gongwei.ID
        /// </summary>
        public int pcWorkPositionID { get; set; }

        public string pcWorkPositionName { get; set; }

        /// <summary>
        /// 资源ID
        /// </summary>
        public int pcResourceID { get; set; }

        public string pcResourceName { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string pcCode { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime pcDate { get; set; }

        /// <summary>
        /// 出勤模式ID，取自base_workmode.ID
        /// </summary>
        public int pcWorkModeID { get; set; }

        /// <summary>
        /// 出勤模式Name
        /// </summary>
        public string pcWorkModeName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string pcRemark { get; set; }

        /// <summary>
        /// 自定义下拉
        /// <option value="0" title="星期" selected>星期</option>
        /// <option value="1" title="日期">日期</option>
        /// </summary>
        public int ChangeDate { get; set; }

        /// <summary>
        /// 自定义下拉
        /// <option value="1">全部</option>
        /// <option value="base_device">设备</option>
        /// <option value="sys_User">人员</option>
        /// <option value="base_gongwei">工位</option>
        /// </summary>
        public string pcchange { get; set; }
    }
}
