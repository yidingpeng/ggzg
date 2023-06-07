using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Assembly
{
    /// <summary>
    /// 生产关键信息记录表
    /// </summary>
    public partial class AssemblyMainRecordModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid? amr_guid { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public Guid? am_guid { get; set; }

        /// <summary>
        /// 信息类型
        /// </summary>
        public string amr_type { get; set; }

        /// <summary>
        /// 信息名称
        /// </summary>
        public string amr_name { get; set; }

        /// <summary>
        /// 信息内容
        /// </summary>
        public string amr_value { get; set;}

        /// <summary>
        /// 信息标记(如单位)
        /// </summary>
        public string amr_mark { get; set; }

        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime amr_createDate { get; set; }

        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime amr_updateDate { get; set; }

        public string amr_typeStr
        {
            get
            {
                return amr_type == "MaterialCode" ? "物料编码" : "设备";
            }
        }
    }
}
