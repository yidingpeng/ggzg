using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public partial class torque_jianding:BaseModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 器具名称
        /// </summary>
        public string QJMC { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public string GGXH { get; set; }
        /// <summary>
        /// 工具表ID
        /// </summary>
        public string JLBH { get; set; }
        /// <summary>
        /// 检测值1
        /// </summary>
        public string JDYJ { get; set; }
        /// <summary>
        /// 标准扭矩值
        /// </summary>
        public string ZSBH { get; set; }
        /// <summary>
        /// 检定结论
        /// </summary>
        public string JDJL { get; set; }
        /// <summary>
        /// 检测值2
        /// </summary>
        public string TYJSYQ { get; set; }
        /// <summary>
        /// 检定日期
        /// </summary>
        public string JDRQ { get; set; }
        /// <summary>
        /// 检定员
        /// </summary>
        public string JDY { get; set; }

        public int deleted { get; set; }
        /// <summary>
        /// 检测值3
        /// </summary>
        public string JCZ3 { get; set; }
        /// <summary>
        /// 检测值4
        /// </summary>
        public string JCZ4 { get; set; }
        /// <summary>
        /// 检测值5
        /// </summary>
        public string JCZ5 { get; set; }

    }
}
