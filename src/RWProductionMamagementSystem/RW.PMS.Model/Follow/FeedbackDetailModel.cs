using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    public class FeedbackDetailModel : BaseModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 反馈类型 0.信息反馈 1.故障报修
        /// </summary>
        public int? fdb_type { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public int? fId { get; set; }

        /// <summary>
        /// 信息反馈图片
        /// </summary>
        public byte[] fdb_img { get; set; }

    }
}
