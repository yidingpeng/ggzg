using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 备料申请从表
    /// </summary>
    public class PmsRequisitionDetailModel : BaseModel
    {
        /// <summary>
        /// 备料申请单明细单号 当前系统自动生成订单号：PD+年月日+四位流水号
        /// </summary>
        public string pd_orderCode { get; set; }

        /// <summary>
        /// 备料申请主表 pms_requisitionmain.pm_orderCode
        /// </summary>
        public string pm_orderCode { get; set; }

        /// <summary>
        /// 关联物料/零件ID
        /// </summary>
        public int? pd_materialID { get; set; }

        /// <summary>
        /// 备料物料编码
        /// </summary>
        public string pd_materialCode { get; set; }

        public string LIKEpd_materialCode { get; set; }

        /// <summary>
        /// 备料物料名称
        /// </summary>
        public string pd_materialName { get; set; }

        public string LIKEpd_materialName { get; set; }

        /// <summary>
        /// 标准用量
        /// </summary>
        public decimal? pd_qty { get; set; }

        /// <summary>
        /// 备料工序ID
        /// </summary>
        public int? pd_operationID { get; set; }

        public string operationName { get; set; }

        /// <summary>
        /// 备料是否必领料  0----false , 1----true
        /// </summary>
        public int? pd_isMustReq { get; set; }

        public string pd_isMustReqText
        {
            get
            {
                if (pd_isMustReq == 0)
                    return "否";
                return "是";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string pd_remark { get; set; }

        /// <summary>
        /// 状态 0.未备料 1.已备料 2.已确认 3.已驳回 4.少料 5.缺料
        /// </summary>
        public int? pd_status { get; set; }

        public string statusText
        {
            get
            {
                if (pd_status == 1)
                {
                    return "已备料";
                }
                else if (pd_status == 2)
                {
                    return "已确认";
                }
                else if (pd_status == 3)
                {
                    return "已驳回";
                }
                else if (pd_status == 4)
                {
                    return "少料";
                }
                else if (pd_status == 5)
                {
                    return "缺料";
                }
                return "未备料";
            }
        }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? pd_deleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? pd_createTime { get; set; }

        public string pm_createTimeText
        {
            get
            {
                if (pd_createTime == null)
                    return "";
                return pd_createTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pd_createTime = dt;
            }
        }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? pd_createMan { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? pd_updateTime { get; set; }

        public string pm_updateTimeText
        {
            get
            {
                if (pd_updateTime == null)
                    return "";
                return pd_updateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pd_updateTime = dt;
            }
        }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? pd_updateMan { get; set; }


        public string paraStr { get; set; }

    }
}
