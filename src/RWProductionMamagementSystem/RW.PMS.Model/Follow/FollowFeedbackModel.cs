using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 信息反馈表
    /// </summary>
    public class FollowFeedbackModel : BaseModel
    {


        public FollowFeedbackModel()
        {
            DetailList = new List<FeedbackDetailModel>();
        }

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 消息反馈流水号
        /// </summary>
        public string fb_orderCode { get; set; }


        /// <summary>
        /// 区域编号
        /// </summary>
        public int? fb_areaID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string fb_areaName { get; set; }
        /// <summary>
        /// 工位编号
        /// </summary>
        public int? fb_gwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string fb_gwName { get; set; }
        /// <summary>
        /// 操作员，employee.ID
        /// </summary>
        public int? fb_operID { get; set; }
        /// <summary>
        /// 操作员，employee.Name
        /// </summary>
        public string fb_oper { get; set; }


        /// <summary>
        /// 反馈时间
        /// </summary>
        public DateTime? fb_createtime { get; set; }

        public string fb_createtimeText
        {
            get
            {
                if (fb_createtime == null)
                    return "";
                return fb_createtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) fb_createtime = dt;
            }
        }


        /// <summary>
        /// 反馈内容
        /// </summary>
        public string fb_feedMemo { get; set; }

        /// <summary>
        /// 反馈类型
        /// </summary>
        public int fb_feedType { get; set; }


        public string fb_feedTypeText { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string fb_remark { get; set; }


        /// <summary>
        /// 反馈结果
        /// </summary>
        public int? fb_isok { get; set; }


        /// <summary>
        /// 反馈结果文本值
        /// </summary>
        public string IsokText
        {
            get
            {
                if (fb_isok == 1) { return "已解决"; }
                if (fb_isok == 0) { return "待处理"; }
                return "";
            }
        }


        /// <summary>
        /// 处理方案
        /// </summary>
        public string fb_result { get; set; }




        /// <summary>
        /// 反馈信息明细表
        /// </summary>

        public List<FeedbackDetailModel> DetailList { get; set; }

    }


}
