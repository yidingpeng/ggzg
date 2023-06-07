using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.DAL.Entities
{
    public partial class torque_tool
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 扭矩编码
        /// </summary>
        public string TorqueCode { get; set; }
        /// <summary>
        /// 扭矩名称
        /// </summary>
        public string TorqueName { get; set; }
        /// <summary>
        /// 量程
        /// </summary>
        public decimal Range { get; set; }
        /// <summary>
        /// 所属班组
        /// </summary>
        public string SSBZ { get; set; }
        /// <summary>
        /// 保管人
        /// </summary>
        public string BGR { get; set; }
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string SCCJ { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public decimal LengthS { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        public int IsDelete { get; set; }
    }
}
