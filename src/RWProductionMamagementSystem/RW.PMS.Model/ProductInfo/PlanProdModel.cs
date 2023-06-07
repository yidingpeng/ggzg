using RW.PMS.Model.Plan;
using System;
using System.Collections.Generic;

namespace RW.PMS.Model
{
    /// <summary>
    /// 生产计划主表
    /// </summary>
    public class PlanProdModel : BaseModel
    {
        /// <summary>
        /// 生产计划表GUID
        /// </summary>
        public Guid pp_guid { get; set; }

        /// <summary>
        /// 计划编码
        /// </summary>
        public string pp_planCode { get; set; }
         
        /// <summary>
        /// 生产订单编码
        /// </summary>
        public string pp_moCode { get; set; }

        /// <summary>
        /// 车辆ID
        /// </summary>
        public int? pp_subwayInfoID { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string carNo { get; set; }

        /// <summary>
        /// 系统车号
        /// </summary>
        public string carNo_sys { get; set; }

        /// <summary>
        /// 电机型号ID
        /// </summary>
        public int? pp_prodModelID { get; set; }

        /// <summary>
        /// 状态 0：未执行；1：执行中；2：已完成
        /// </summary>
        public int? pp_status { get; set; }

        public string pp_statusText
        {
            get
            {
                if (pp_status == 0)
                    return "未执行";
                else if (pp_status == 1)
                    return "执行中";
                else if (pp_status == 2)
                    return "已完成";
                return "";
            }
        }

        /// <summary>
        /// 计划数量
        /// </summary>
        public int? pp_planQty { get; set; }

        /// <summary>
        /// 实际数量
        /// </summary>
        public int? pp_resultQty { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? pp_startDate { get; set; }

        public string pp_startDateText
        {
            get
            {
                if (pp_startDate == null)
                    return "";
                return pp_startDate.Value.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pp_startDate = dt;
            }
        }

        /// <summary>
        /// 计划完成时间
        /// </summary>
        public DateTime? pp_finishDate { get; set; }


        public string pp_finishDateText
        {
            get
            {
                if (pp_finishDate == null)
                    return "";
                return pp_finishDate.Value.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pp_finishDate = dt;
            }
        }

        /// <summary>
        /// 实际开始时间
        /// </summary>
        public DateTime? pp_resultStartTime { get; set; }

        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? pp_resultEndTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string pp_remark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? pp_deleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? pp_createTime { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        public int? pp_createMan { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? pp_updateTime { get; set; }

        /// <summary>
        /// 更新人ID
        /// </summary>
        public int? pp_updateMan { get; set; }

        /// <summary>
        /// 产品生产（组装、检修）主表GUID
        /// </summary>
        public Guid Pp_fp_guid { get; set; }

        /// <summary>
        /// 产品信息ID
        /// </summary>
        public int? Pp_pInfo_ID { get; set; }

        /// <summary>
        /// 是否已开始检修或生产,0：未开始；1：已开始；如已开始就不显示在来料区的计划列表中
        /// </summary>
        public int? Pp_isStart { get; set; }

        public List<PlanDetailModel> DetailList { get; set; }

        #region 产品信息

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Pname { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string Prod_no { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 计划完成数量
        /// </summary>
        public int? Pp_finishcnt { get; set; }


        #endregion

        #region 生产产品基础表

        public int pf_ID { get; set; }
        public string pf_prodNo { get; set; }
        public int pf_prodID { get; set; }
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? pf_prodModelID { get; set; }
        /// <summary>
        /// 车型ID
        /// </summary>
        public int? pf_carModelID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string pf_carModelName { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string pf_carNo { get; set; }
        public string pf_orderNo { get; set; }
        /// <summary>
        /// 编组
        /// </summary>
        public string pf_groupNo { get; set; }
        /// <summary>
        /// 厂商ID
        /// </summary>
        public int? pf_factoryID { get; set; }
        /// <summary>
        /// 厂商
        /// </summary>
        public string pf_factoryName { get; set; }
        /// <summary>
        /// 主部件钢印号
        /// </summary>
        public string pf_stampNo { get; set; }
        public DateTime? pf_date { get; set; }
        public string pf_weight { get; set; }
        public string pf_compressor { get; set; }
        public string pf_remark { get; set; }

        #endregion

        #region 追溯信息
        /// <summary>
        /// 追溯主表ID
        /// </summary>
        public Guid? fm_guid { get; set; }
        #endregion

        #region 查询条件
        public string LIKEPlanCode { get; set; }
        public string LIKECarNo { get; set; }
        /// <summary>
        /// 非此状态
        /// </summary>
        public int? UNStatus { get; set; }
        #endregion
    }
}









