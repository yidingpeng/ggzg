using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Plan
{
    public class PartPlanTechnicsModel : BaseModel
    {
        /// <summary>
        /// 订单编码（预留） 当前系统自动生成订单号：PP+年月日+四位流水号
        /// </summary>
        public string pt_orderCode { get; set; }

        public string LIKEptorderCode { get; set; }

        /// <summary>
        /// 配件计划 订单编码 Part_Plan.pp_orderCode
        /// </summary>
        public string pp_orderCode { get; set; }

        public string LIKEpporderCode { get; set; }

        /// <summary>
        /// 第三方系统关联订单编码（预留）订单编号：DQ+年月日+四位流水号
        /// </summary>
        public string pt_orderCodeRel { get; set; }

        public string LIKEptorderCodeRel { get; set; }

        /// <summary>
        /// 工艺委托类型
        /// </summary>
        public int? pt_entrustType { get; set; }


        public string entrustTypeName { get; set; }

        /// <summary>
        /// 工作中心编码
        /// </summary>
        public string pt_workCenterCode { get; set; }

        /// <summary>
        /// 工作中心名称
        /// </summary>
        public string pt_workCenterName { get; set; }

        /// <summary>
        /// 计划工序ID
        /// </summary>
        public int? pt_operationID { get; set; }

        /// <summary>
        /// 工序号
        /// </summary>
        public string operationNo { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string operationName { get; set; }

        /// <summary>
        /// 工序编码
        /// </summary>
        public string operationCode { get; set; }


        /// <summary>
        /// 检验点	0----false , 1----true
        /// </summary>
        public int? pt_isCheckPoint { get; set; }

        public string IsCheckPointText
        {
            get
            {
                if (pt_isCheckPoint == 0)
                {
                    return "否";
                }
                return "是";
            }
        }

        /// <summary>
        /// 汇报点	0----false , 1----true
        /// </summary>
        public int? pt_isReportPoint { get; set; }

        public string IsReportPointText
        {
            get
            {
                if (pt_isReportPoint == 0)
                {
                    return "否";
                }
                return "是";
            }
        }

        /// <summary>
        /// 入库点	0----false , 1----true
        /// </summary>
        public int? pt_isPickingPoint { get; set; }

        public string IsPickingPointText
        {
            get
            {
                if (pt_isPickingPoint == 0)
                {
                    return "否";
                }
                return "是";
            }
        }

        /// <summary>
        /// 委外厂商编码
        /// </summary>
        public string pt_entrustSupplierCode { get; set; }


        ///// <summary>
        /////  0: 未执行  1:执行中 2: 已完成
        ///// </summary>
        //public string pp_statusText
        //{
        //    get
        //    {
        //        if (pp_status == 0)
        //            return "未开始";
        //        else if (pp_status == 1)
        //            return "已下发";
        //        else if (pp_status == 2)
        //            return "已开始";
        //        else if (pp_status == 3)
        //            return "已完成";
        //        return "";
        //    }
        //}

        /// <summary>
        /// 开工台位编码
        /// </summary>
        public string pt_taiweiCode { get; set; }

        /// <summary>
        /// 生产工序别号
        /// </summary>
        public string pt_opertionAlias { get; set; }

        /// <summary>
        /// 生产加工说明
        /// </summary>
        public string pt_proInstruction { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string pt_remark { get; set; }


        /// <summary>
        /// 状态
        /// 0:未配料
        /// 1:已配料
        /// 2:缺/少配料
        /// </summary>
        public int? pt_status { get; set; }


        public string pt_statusText
        {
            get
            {
                if (pt_status == 0)
                    return "未配料";
                else if (pt_status == 1)
                    return "已配料";
                else if (pt_status == 2)
                    return "缺/少配料";
                return "";
            }
        }


        /// <summary>
        /// 齐套物料工序百分比（%）
        /// </summary>
        public decimal? pt_TechnicsPercent { get; set; }


        /// <summary>
        /// 齐套结果（检验结果:-1:空；0:不合格；1：合格）
        /// </summary>
        public int? pt_checkResult { get; set; }

        public string pt_checkResultText
        {
            get
            {
                if (pt_checkResult == 0)
                {
                    return "不合格";
                }
                else if (pt_checkResult == 1)
                {
                    return "合格";
                }
                return "空";
            }
        }

        /// <summary>
        /// 齐套分析时间
        /// </summary>
        public DateTime? pt_BundleAnalysisTime { get; set; }

        public string pt_BundleAnalysisTimeText
        {
            get
            {
                if (pt_BundleAnalysisTime == null)
                    return "";
                return pt_BundleAnalysisTime.Value.ToString("yyyy-MM-dd");

            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pt_BundleAnalysisTime = dt;
            }
        }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? pt_deleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? pt_createTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? pt_createMan { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? pt_updateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? pt_updateMan { get; set; }



        /// <summary>
        /// 获取计划状态用于判断选择框启用或禁用
        /// </summary>
        public int? pp_status { get; set; }


    }
}
