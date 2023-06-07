using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 故障统计
    /// </summary>
    public class HitchModel : BaseModel
    {
        /// <summary>
        /// 生产编号
        /// </summary>
        public string prodNo { get; set; }

        /// <summary>
        /// 产品id
        /// </summary>
        public int? prodID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string prodName { get; set; }

        /// <summary>
        /// 产品型号id
        /// </summary>
        public int? prodModelID { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string prodModelName { get; set; }

        /// <summary>
        /// 车型id
        /// </summary>
        public int? carModelID { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string carModelName { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string carNo { get; set; }

        /// <summary>
        /// 设备id
        /// </summary>
        public int? devID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string devName { get; set; }

        /// <summary>
        /// 故障代码
        /// </summary>
        public string faultCode { get; set; }

        /// <summary>
        /// 故障级别
        /// </summary>
        public string faultLevel { get; set; }

        /// <summary>
        /// 故障类别
        /// </summary>
        public string faultClass { get; set; }

        /// <summary>
        /// 故障类别数
        /// </summary>
        public int? count { get; set; }
        /// <summary>
        /// 故障代码id
        /// </summary>
        public int? faultCodeId { get; set; }

        /// <summary>
        /// 故障级别id
        /// </summary>
        public int? faultLevelId { get; set; }

        /// <summary>
        /// 故障类别id
        /// </summary>
        public int? faultClassId { get; set; }

        /// <summary>
        /// 故障时间
        /// </summary>
        public DateTime? createtime { get; set; }

        /// <summary>
        /// 折线图分组时间
        /// </summary>
        public string ZDate { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string Starttime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string Endtime { get; set; }
    }
}
