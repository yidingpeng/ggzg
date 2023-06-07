using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    /// 装配记录
    /// </summary>
    public class AssemblyDataModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string prodCode { get; set; }
        /// <summary>
        /// 数据名称
        /// </summary>
        public string amdName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string amdValue { get; set; }
    }
}
