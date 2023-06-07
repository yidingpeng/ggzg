namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 工位权限
    /// </summary>
    public class BaseGongweiRightModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? gwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string GwName { get; set; }
        /// <summary>
        /// 工位IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 人员ID
        /// </summary>
        public int? empID { get; set; }
        /// <summary>
        /// 人员名称
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? gwrStatus { get; set; }
        /// <summary>
        /// 状态文本值
        /// </summary>
        public string Status { get {
            if (gwrStatus == 0)
                return "启用";
            return "禁用";
        } }
        /// <summary>
        /// 工位权限执行类型：例外转序 作业指导 异常下线
        /// </summary>
        public int? rightTypeID { get; set; }
        /// <summary>
        /// 工位权限执行类型文本值
        /// </summary>
        public string rightTypeName { get; set; }
        /// <summary>
        /// 工位权限执行类型文本编号
        /// </summary>
        public string rightTypeCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
