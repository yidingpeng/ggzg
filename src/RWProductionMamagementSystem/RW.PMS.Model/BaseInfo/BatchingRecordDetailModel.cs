using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 领料子表信息实体类
    /// </summary>
    public class BatchingRecordDetailModel : BaseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 配料单号
        /// </summary>
        public string BatchCode { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public int MaterialID { get; set; }

        /// <summary>
        /// 领取数量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
    }
}
