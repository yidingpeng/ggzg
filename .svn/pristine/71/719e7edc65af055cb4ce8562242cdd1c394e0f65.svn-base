using System;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseMsgContentModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string mcTitle { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string mcContent { get; set; }
        /// <summary>
        /// 消息类型 取数据字典
        /// </summary>
        public int? mcTypeID { get; set; }
        /// <summary>
        /// 消息类型名称
        /// </summary>
        public string mcTypeName { get; set; }
        /// <summary>
        /// 等级 1.普通 2.中级 3.紧急
        /// </summary>
        public int? mcLevel { get; set; }
        /// <summary>
        /// 等级文本值
        /// </summary>
        public string mcLeveText
        {
            get
            {
                if (mcLevel == 1)
                    return "普通";
                else if (mcLevel == 2)
                    return "中等";
                else if (mcLevel == 3)
                    return "紧急";
                else
                    return "";
            }
        }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string mcUrl { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string mcRemark { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? mcDeleteFlag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? mcCreateTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public int? mcCreaterID { get; set; }
        /// <summary>
        ///更新时间
        /// </summary>
        public DateTime? mcUpdateTime { get; set; }
        /// <summary>
        /// 更新者
        /// </summary>
        public int? mcUpdaterID { get; set; }

        #region 消息表
        /// <summary>
        /// 接受者ID
        /// </summary>
        public int? msResponderID { get; set; }
        /// <summary>
        /// 接受者名称
        /// </summary>
        public string msResponderName { get; set; }
        /// <summary>
        /// 已读标识
        /// </summary>
        public int? msReadFlag { get; set; }
        /// <summary>
        /// 已读标识(显示文本)
        /// </summary>
        public string ReadFlagText
        {
            get
            {
                if (msReadFlag == 0)
                    return "未读";
                else if (msReadFlag == 1)
                    return "已读";
                else
                    return "";
            }
        }
        /// <summary>
        /// 已读时间
        /// </summary>
        public DateTime? msReadTime { get; set; }
        #endregion
    }
}
