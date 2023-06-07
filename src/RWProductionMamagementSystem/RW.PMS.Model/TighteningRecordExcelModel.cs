using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    /// 拧紧记录表
    /// </summary>
    public class TighteningRecordExcelModel {  
        /// <summary>
        /// 产品编号
        /// </summary>
        public string prodNo { get; set; }

        /// <summary>
        /// 螺栓号
        /// </summary>
        public int BoltNo { get; set; }

        /// <summary>
        /// 拧紧值
        /// </summary>
        public decimal TorqueValue { get; set; }

        /// <summary>
        /// 角度值
        /// </summary>
        public decimal AngleValue { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperatorValue { get; set; }

        /// <summary>
        /// 拧紧时间
        /// </summary>
        public DateTime TighteningDate { get; set; }
    }
}
