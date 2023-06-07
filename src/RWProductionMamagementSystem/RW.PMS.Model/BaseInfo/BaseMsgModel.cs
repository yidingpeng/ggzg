using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseMsgModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 消息内容表ID
        /// </summary>
        public int? mcID { get; set; }
        /// <summary>
        /// 被通知人ID
        /// </summary>
        public int? msResponderID { get; set; }
        /// <summary>
        /// 被通知人姓名
        /// </summary>
        public string Responder { get; set; }
        /// <summary>
        /// 已阅标识
        /// </summary>
        public int? msReadFlag { get; set; }
        /// <summary>
        /// 已阅标识文本值
        /// </summary>
        public string msReadFlagText { get; set; }
        /// <summary>
        /// 自动生成标识 0.手动 1.自动	
        /// </summary>
        public int? msAutoFlag { get; set; }
        /// <summary>
        /// 自动生成标识文本值
        /// </summary>
        public string msAutoFlagText { get; set; }
        /// <summary>
        /// 阅读时间
        /// </summary>
        public DateTime? msReadTime { get; set; }

    }
}
