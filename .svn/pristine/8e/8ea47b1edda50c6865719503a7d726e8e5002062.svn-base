using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 领料主表信息实体类
    /// </summary>
    public class CollectRecordModel : BaseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 条形码,编码唯一
        /// </summary>
        public string BarCode { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int PModelID { get; set; }

        /// <summary>
        /// 工艺ID 
        /// </summary>
        public int ProgID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WarehouseID { get; set; }

        /// <summary>
        /// 申请人ID
        /// </summary>
        public int? ApplierID { get; set; }

        /// <summary>
        /// 申请人名称
        /// </summary>
        public string AplierName { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? ApplyDate { get; set; }

        public string applyDateText
        {
            get
            {
                if (ApplyDate == null)
                    return string.Empty;
                return ApplyDate.Value.ToString("yyyy-MM-dd");
            }
        }
    }
}
