using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Assembly
{
    /// <summary>
    /// 装配记录表
    /// </summary>
    public class AssemblyInfoModel
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProductNumber { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductTypeName { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string WorkingPositionName { get; set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string OperatorName { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 工位完成状态：0：未完成，1：已完成
        /// </summary>
        public int CompletionStatus { get; set; }
    }
}
