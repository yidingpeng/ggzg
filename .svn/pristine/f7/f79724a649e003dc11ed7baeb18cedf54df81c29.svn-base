using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseInventoryLogModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 物料规格表ID
        /// </summary>
        public int? wlID { get; set; }

        /// <summary>
        /// 仓库ID 
        /// </summary>
        public int? warehouseID { get; set; }

        /// <summary>
        /// 变更类型:1 数据更新
        /// </summary>
        public int? changeType { get; set; }

        /// <summary>
        /// 变动数量
        /// </summary>
        public int? changeQty { get; set; }

        /// <summary>
        /// 变动前数量
        /// </summary>
        public int? beforeQty { get; set; }

        /// <summary>
        /// 变动后数量
        /// </summary>
        public int? afterQty { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int? userID { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? logTime { get; set; }

        public string logTimeText
        {

            get
            {
                if (logTime == null)
                    return "";
                return logTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) logTime = dt;
            }

        }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

    }
}
