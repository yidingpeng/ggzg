using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseToolsModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public int? DevID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// 隶属设备IP
        /// </summary>
        public string DevSubjectionIP { get; set; }

        /// <summary>
        /// 器具ID 取基础数据，类型编码为ToolsType
        /// </summary>
        public int? ToolId { get; set; }

        /// <summary>
        /// 器具名称
        /// </summary>
        public string ToolName { get; set; }

        /// <summary>
        /// 规格型号
        /// </summary>
        public string ToolModels { get; set; }

        /// <summary>
        /// 器具编码
        /// </summary>
        public string ToolCode { get; set; }

        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? DevPurchaseDate { get; set; }

        /// <summary>
        /// 到期提醒日期
        /// </summary>
        public DateTime? DevExpireDate { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? DevStatus { get; set; }

        /// <summary>
        /// 送检次数
        /// </summary>
        public int? DevInspectionCount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string DevRemark { get; set; }

        /// <summary>
        /// 到期天数
        /// </summary>
        public int? ExpireDay { get; set; }

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
    }
}
