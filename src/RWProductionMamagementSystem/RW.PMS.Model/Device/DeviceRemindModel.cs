using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Device
{
    /// <summary>
    /// 工具到期送检提醒表Model
    /// </summary>
    public class DeviceRemindModel : BaseModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public int? TId { get; set; }

        /// <summary>
        /// 器具ID
        /// </summary>
        public int? ToolId { get; set; }

        /// <summary>
        /// 器具名称
        /// </summary>
        public string ToolName { get; set; }

        /// <summary>
        /// 证书编号
        /// </summary>
        public string DevCertificateNo { get; set; }
      
        /// <summary>
        /// 采购时间
        /// </summary>
        public DateTime? DevPurchaseDate { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? DevExpireDate { get; set; }

        /// <summary>
        /// 状态：0:未到期;1:将到期;2:已到期;3:已送检;
        /// </summary>
        public int? DevStatus { get; set; }

        /// <summary>
        /// 送检人员
        /// </summary>
        public int? EmpID { get; set; }

        public string EmpName { get; set; }

        /// <summary>
        /// 送检时间
        /// </summary>
        public DateTime? Inspectiontime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Devremark { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status
        {
            get
            {
                return DevStatus == 0 ? "未到期" : DevStatus == 1 ? "将到期" : DevStatus == 2 ? "已到期" : DevStatus == 3 ? "已送检" : "";
            }
        }

        /// <summary>
        /// 设备ID
        /// </summary>
        public int? DevID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string ToolModels { get; set; }

        /// <summary>
        /// 器具编码
        /// </summary>
        public string ToolCode { get; set; }
        /// <summary>
        /// 送检次数
        /// </summary>
        public int? DevInspectionCount { get; set; }

    }
}
