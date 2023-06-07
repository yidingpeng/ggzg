using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 故障报修表
    /// </summary>
    public class FollowFaultRepairModel : BaseModel
    {
        /// <summary>
        /// 编号，ID自增
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public int? Fr_devID { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        public string Fr_devName { get; set; }
        /// <summary>
        /// 报修员ID
        /// </summary>
        public int? Fr_operID { get; set; }
        /// <summary>
        /// 报修员
        /// </summary>
        public string Fr_oper { get; set; }
        /// <summary>
        /// 报修时间
        /// </summary>
        public DateTime? Fr_createtime { get; set; }
        /// <summary>
        /// 故障代码
        /// </summary>
        public int? Fr_faultCode { get; set; }
        /// <summary>
        /// 故障代码名称
        /// </summary>
        public string FaultCodeName { get; set; }
        /// <summary>
        /// 故障级别
        /// </summary>
        public int? Fr_faultLevel { get; set; }
        /// <summary>
        /// 故障级别名称
        /// </summary>
        public string FaultLevelName { get; set; }
        /// <summary>
        /// 故障类别
        /// </summary>
        public int? Fr_faultClass { get; set; }
        /// <summary>
        /// 故障类别名称
        /// </summary>
        public string FaultClassName { get; set; }
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? Pf_prodModelID { get; set; }
        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string ProdModel { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public int? Pf_carModelID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string CarModel { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string Pf_carNo { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string Pf_prodNo { get; set; }
        /// <summary>
        /// 故障情况
        /// </summary>
        public string Fr_faultMemo { get; set; }
        /// <summary>
        /// 报修内容
        /// </summary>
        public string Fr_repairMemo { get; set; }
        /// <summary>
        /// 紧急程度
        /// </summary>
        public int? Fr_emergency { get; set; }
        /// <summary>
        /// 紧急程度名称
        /// </summary>
        public string Emergency { get; set; }
        /// <summary>
        /// 解决时间
        /// </summary>
        public DateTime? Fr_solve_time { get; set; }
        /// <summary>
        /// 解除人员ID
        /// </summary>
        public int? Fr_solve_operID { get; set; }
        /// <summary>
        /// 解除人员
        /// </summary>
        public string Fr_solve_oper { get; set; }
        /// <summary>
        /// 故障原因
        /// </summary>
        public string Fr_solve_reason { get; set; }
        /// <summary>
        /// 解决方法
        /// </summary>
        public string Fr_solve_method { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        public int? Fr_status { get; set; }
        /// <summary>
        /// 处理结果
        /// </summary>
        public string Status
        {
            get
            {
                if (Fr_status == 0)
                {
                    return "待处理";
                }
                if (Fr_status == 1)
                {
                    return "已解决";
                }
                return "";
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Fr_remark { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 数据字典值
        /// </summary>
        public string BdValue { get; set; }
    }
}
