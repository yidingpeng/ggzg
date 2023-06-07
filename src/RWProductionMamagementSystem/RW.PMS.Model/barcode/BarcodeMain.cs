using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Barcode
{
    /// <summary>
    /// 条码记录主表
    /// </summary>
    public class BarcodeMain
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string GUID { get; set; }

        /// <summary>
        /// 条码类型
        /// </summary>
        public string BType { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        public string Month { get; set; }

        /// <summary>
        /// 模组型号
        /// </summary>
        public string PModelNo { get; set; }

        /// <summary>
        /// 流水号（开始）
        /// </summary>`
        public int BeginNo { get; set; }

        /// <summary>
        /// 流水号（结束）
        /// </summary>
        public int EndNo { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public int TotalNo { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CDateTime { get; set; }

        /// <summary>
        /// 条码记录
        /// </summary>
        public List<BacodeRecord> Records { get; set; } 
    }
}
