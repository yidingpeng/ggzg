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
    public class TighteningRecordModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int PID { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string prodNo { get; set; }

        /// <summary>
        /// 标准拧紧值
        /// </summary>
        public decimal StandardValue { get; set; }

        /// <summary>
        /// 拧紧值
        /// </summary>
        public decimal TorqueValue { get; set; }

        /// <summary>
        /// 拧紧时间
        /// </summary>
        public DateTime TighteningDate { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public int Operators { get; set; }

        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperatorValue { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string starttime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endtime { get; set; }

        /// <summary>
        /// 角度值
        /// </summary>
        public decimal AngleValue { get; set; }

        /// <summary>
        /// 螺栓号
        /// </summary>
        public int BoltNo { get; set; }

        /// <summary>
        /// 是否合格
        /// </summary>
        public string IsQualified { get; set; }
    }
}
