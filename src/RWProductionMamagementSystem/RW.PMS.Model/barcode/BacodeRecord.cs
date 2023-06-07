using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Barcode
{
    /// <summary>
    /// 条码记录明细表
    /// </summary>
    public  class BacodeRecord
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string GUID { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public string MainID { get; set; }

        /// <summary>
        /// 条码值
        /// </summary>
        public string BarcodeVal { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CDateTime { get; set; }
    }
}
