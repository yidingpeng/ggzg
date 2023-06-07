using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    /// 维保设置表
    /// </summary>
    public class MaintenanceSettingModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
          
        /// <summary>
        /// 维保项目
        /// </summary>
        public string MaintenanceItem { get; set; }

        /// <summary>
        /// 维保项目名称
        /// </summary>
        public string devName { get; set; }

        /// <summary>
        /// 保养内容
        /// </summary>
        public string MaintenanceContent { get; set; }

        /// <summary>
        /// 相关图片
        /// </summary>
        public string RelatedPicture { get; set; }

        /// <summary>
        /// 保养频率
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 最后修改人员
        /// </summary>
        public int Personnel { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 最后修改人员
        /// </summary>
        public string PersonnelValue { get; set; }

        /// <summary>
        /// 设备已使用次数
        /// </summary>
        public int usedTimes { get; set; }

    }
}
