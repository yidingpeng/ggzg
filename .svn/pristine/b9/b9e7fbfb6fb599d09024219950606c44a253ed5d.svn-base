using System;

namespace RW.PMS.Model.Plan
{
    /// <summary>
    /// MO
    /// </summary>
    public class MOModel : BaseModel
    {
        #region 数据库原字段
        /// <summary>
        /// 订单编号
        /// </summary>
        public string moCode { get; set; }
        /// <summary>
        /// 项目类型ID
        /// </summary>
        public int? moProjectTypeID { get; set; }
        /// <summary>
        /// 交货期
        /// </summary>
        public DateTime? moDeliveryDate { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string moSubwayCode { get; set; }
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? moMotorModelID { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int? moQty { get; set; }
        public string moRemark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? moStatus { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int? moDeleteFlag { get; set; }
        public DateTime? moCreateTime { get; set; }
        public int? moCreaterID { get; set; }
        public DateTime? moUpdateTime { get; set; }
        public int? moUpdaterID { get; set; }
        #endregion

        #region 查询条件

        /// <summary>
        /// 模糊查询-订单编码
        /// </summary>
        public string LIKECode { get; set; }

        /// <summary>
        /// 模糊查询-车号
        /// </summary>
        public string LIKESubwayNo { get; set; }

        /// <summary>
        /// 模糊查询-地铁线路
        /// </summary>
        public string LIKELine { get; set; }

        /// <summary>
        /// 区间查询-开始-交货期
        /// </summary>
        public DateTime? DeliveryDateStart { get; set; }

        /// <summary>
        /// 区间查询-结束-交货期
        /// </summary>
        public DateTime? DeliveryDateEnd { get; set; }

        #endregion

        #region 显示用字段

        /// <summary>
        /// 状态-显示文本
        /// </summary>
        public string moStatusText
        {
            get
            {
                if (moStatus == 0)
                    return "新建";
                if (moStatus == 1)
                    return "排产完成";
                if (moStatus == 2)
                    return "已入场";
                if (moStatus == 3)
                    return "生产中";
                if (moStatus == 4)
                    return "生产完成";
                if (moStatus == 5)
                    return "已发货";
                return string.Empty;
            }
        }
        /// <summary>
        /// 交货期-显示文本
        /// </summary>
        public string moDeliveryDateText
        {
            get
            {
                if (moDeliveryDate == null)
                    return string.Empty;
                return moDeliveryDate.Value.ToString("yyyy-MM-dd");
            }
        }
        /// <summary>
        /// 车号
        /// </summary>
        public string bsbNo { get; set; }
        /// <summary>
        /// 地铁线路
        /// </summary>
        public string bsbLine { get; set; }
        /// <summary>
        /// 电机型号名称
        /// </summary>
        public string moMotorModelName { get; set; }
        /// <summary>
        /// 项目类型
        /// </summary>
        public string moProjectTypeName { get; set; }
        /// <summary>
        /// 完成数
        /// </summary>
        public int moCompleteQty { get; set; }
        /// <summary>
        /// 完成情况
        /// </summary>
        public string moCompleteInfo { get; set; }

        #endregion
    }
}