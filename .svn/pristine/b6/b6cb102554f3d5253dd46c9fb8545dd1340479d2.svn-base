using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    /// 异常下线记录
    /// </summary>
    public class AbnormalOfflineModel
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
        /// 当前工位记录Guid
        /// </summary>
        public Guid? agw_guid { get; set; }

        /// <summary>
        /// 当前工序记录Guid
        /// </summary>
        public Guid? agx_guid { get; set; }

        /// <summary>
        /// 当前工步记录Guid
        /// </summary>
        public Guid? agb_guid { get; set; }

        /// <summary>
        /// 当前工序索引号
        /// </summary>
        public int CurrentGXIndex { get; set; }

        /// <summary>
        /// 当前工步索引号
        /// </summary>
        public int CurrentGBIndex { get; set; }

        /// <summary>
        /// 当前工步下的工具物料索引号
        /// </summary>
        public int CurrentGJWLIndex { get; set; }

        /// <summary>
        /// 操作员Id
        /// </summary>
        public int? operID { get; set; }

        /// <summary>
        /// 下线时间
        /// </summary>
        public DateTime? saveTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int offlineState { get; set; }
 
        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string operName { get; set; }
    }
}
