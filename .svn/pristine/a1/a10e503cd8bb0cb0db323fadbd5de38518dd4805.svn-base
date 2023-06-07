//using RW.PMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class DeviceModel : BaseModel
    {

        // 设备管理 LHR

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public string DevNo { get; set; }

        /// <summary>
        /// 设备执行IC卡号
        /// </summary>
        public string DevCardno { get; set; }

        /// <summary>
        /// 设备IP
        /// </summary>
        public string DevIP { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public int? DevStatus { get; set; }

        /// <summary>
        /// 设备状态
        /// </summary>
        public string DevStatusS
        {
            get
            {
                return DevStatus == 0 ? "启用" : "禁用";
            }
        }

        /// <summary>
        /// 设备备注
        /// </summary>
        public string Remark { get; set; }

    }
}
