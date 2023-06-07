namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class device_checkingDetails
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 主表ID
        /// </summary>
        public int? DevCheckID { get; set; }
        /// <summary>
        /// 点检类别ID
        /// </summary>
        public int? DevTypeID { get; set; }
        /// <summary>
        /// 点检类别名称
        /// </summary>
        public string DevType { get; set; }
        /// <summary>
        /// 点检序号
        /// </summary>
        public string spotID { get; set; }
        /// <summary>
        /// 点检项目
        /// </summary>
        public string CheckItem { get; set; }
        /// <summary>
        /// 点检结果
        /// </summary>
        public string ItemCheckResult { get; set; }
        /// <summary>
        /// 班组员工id
        /// </summary>
        public int? ItemCheckerID { get; set; }

        /// <summary>
        /// 班长id
        /// </summary>
        public int? MonitorID { get; set; }

        /// <summary>
        /// 点检时间
        /// </summary>
        public DateTime? CheckerTime { get; set; }

        /// <summary>
        /// 检查时段
        /// </summary>
        public int? SpotTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}