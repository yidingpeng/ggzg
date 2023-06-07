using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Device
{

    /// <summary>
    /// 设备保养维护计划子表
    /// </summary>
    public class Device_upkeepPlanDetailModel : BaseModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 子表id
        /// </summary>
        public int id1 { get; set; }
        /// <summary>
        /// 设备主表ID Device_upkeepPlan
        /// </summary>
        public int? udID { get; set; }


        /// <summary>
        /// 点检序号
        /// </summary>
        public string spotid { get; set; }

        /// <summary>
        /// 部位
        /// </summary>
        public string dsc_position { get; set; }
        /// <summary>
        /// 活动项目
        /// </summary>
        public string dsc_project { get; set; }
 
 
 
        /// <summary>
        /// 保养图片
        /// </summary>
        public byte[] udimg { get; set; }
 
        /// <summary>
        /// 备注
        /// </summary>
        public string udremark { get; set; }


        /// <summary>
        /// 设备ID
        /// </summary>
        public int? dsc_device { get; set; }

        /// <summary>
        /// 设备名称 外键
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// 设备卡号
        /// </summary>
        public string DevCardno { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public string DevNo { get; set; }

    }
}
