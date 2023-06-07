using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{

    /// <summary>
    /// 备料申请主表
    /// </summary>
    public class PmsRequisitionMainModel : BaseModel
    {
        /// <summary>
        /// 备料申请订单编码
        /// </summary>
        public string pm_orderCode { get; set; }

        public string LIKEpm_orderCode { get; set; }

        /// <summary>
        /// 配件计划 part_plan.pp_orderCode
        /// </summary>
        public string pp_orderCode { get; set; }

        public string LIKEpp_orderCode { get; set; }

        /// <summary>
        /// 产品信息表 productInfo.pf_ID
        /// </summary>
        public int? pf_ID { get; set; }

        public string  pf_prodNo { get; set; }

        /// <summary>
        /// 申请人ID
        /// </summary>
        public int? pm_applierID { get; set; }

        public string pm_applierText { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? pm_applyDate { get; set; }

        public string pm_applyDateText
        {
            get
            {
                if (pm_applyDate == null)
                    return "";
                return pm_applyDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pm_applyDate = dt;
            }
        }

        /// <summary>
        /// 驳回人ID
        /// </summary>
        public int? pm_rejectID { get; set; }



        /// <summary>
        /// 驳回人员
        /// </summary>
        public string pm_rejectText { get; set; }


        /// <summary>
        /// 驳回日期
        /// </summary>
        public DateTime? pm_rejectDate { get; set; }

        public string pm_rejectDateText
        {
            get
            {
                if (pm_rejectDate == null)
                    return "";
                return pm_rejectDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pm_rejectDate = dt;
            }
        }


        /// <summary>
        /// 驳回类型 取数据字典
        /// </summary>
        public int pm_rejectType { get; set; }


        public string pm_rejectTypeText { get; set; }

        /// <summary>
        /// 驳回原因
        /// </summary>
        public string pm_rejectMemo { get; set; }

        /// <summary>
        /// 状态 0.未备料 1.已备料 2.已确认 3.已驳回
        /// </summary>
        public int? pm_status { get; set; }

        public string statusText
        {
            get
            {
                if (pm_status == 1)
                {
                    return "已备料";
                }
                else if (pm_status == 2)
                {
                    return "已确认";
                }
                else if (pm_status == 3)
                {
                    return "已驳回";
                }
                return "未备料";
            }
        }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? pm_deleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? pm_createTime { get; set; }


        public string pm_createTimeText
        {
            get
            {
                if (pm_createTime == null)
                    return "";
                return pm_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pm_createTime = dt;
            }
        }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? pm_createMan { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? pm_updateTime { get; set; }

        public string pm_updateTimeText
        {
            get
            {
                if (pm_updateTime == null)
                    return "";
                return pm_updateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pm_updateTime = dt;
            }
        }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? pm_updateMan { get; set; }




        /// <summary>
        /// 产品型号 - 图号
        /// </summary>
        public string PmodelDrawingNo { get; set; }






    }
}
