using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Plan
{
    /// <summary>
    /// 配件计划备料表 LHR 2020-03-12
    /// </summary>
    public class PartPlanStockModel : BaseModel
    {
        /// <summary>
        /// 系统订单编码 当前系统自动生成订单号：PS+年月日+四位流水号
        /// </summary>
        public string ps_orderCode { get; set; }

        public string LIKEpsorderCode { get; set; }

        /// <summary>
        /// 配件计划 订单编码 Part_Plan.pp_orderCode
        /// </summary>
        public string pp_orderCode { get; set; }

        public string LIKEpporderCode { get; set; }

        /// <summary>
        /// 第三方系统关联订单编码（预留）订单编号：DQ+年月日+四位流水号
        /// </summary>
        public string ps_orderCodeRel { get; set; }

        public string LIKEpsorderCodeRel { get; set; }


        /// <summary>
        /// 物料ID
        /// </summary>
        public int? ps_materialID { get; set; }

        /// <summary>
        /// 备料物料编码
        /// </summary>
        public string ps_materialCode { get; set; }

        public string LIKEps_materialCode { get; set; }

        /// <summary>
        /// 备料物料名称
        /// </summary>
        public string ps_materialName { get; set; }

        public string LIKEps_materialName { get; set; }

        /// <summary>
        /// 备料计量单位编码
        /// </summary>
        public string ps_unitCode { get; set; }

        /// <summary>
        /// 标准用量
        /// </summary>
        public decimal? ps_qty { get; set; }

        /// <summary>
        /// 备料领送料方式
        /// 生产领料	11010
        /// 普通领料	11020
        /// 看板	    11030
        /// 不领料	    11040
        /// 直送	    11050
        /// </summary>
        public int ps_issueMode { get; set; }

        public string issueModeText { get; set; }

        /// <summary>
        /// 备料工序ID
        /// </summary>
        public int? ps_operationID { get; set; }

        /// <summary>
        /// 备料工序号
        /// </summary>
        public string ps_operationNo { get; set; }

        public string operationName { get; set; }

        /// <summary>
        /// 备料供货库存组织编码
        /// </summary>
        public string ps_storageOrgUnitCode { get; set; }

        /// <summary>
        /// 备料单位用量
        /// </summary>
        public decimal? ps_unitQty { get; set; }

        /// <summary>
        /// 备料供应类型
        /// 无	            0
        /// 本库存组织领料	10910
        /// 跨库存组织调拨	10920
        /// 跨库存组织领料	10930
        /// 跨库存组织直送	10940
        /// </summary>
        public int? ps_provideType { get; set; }

        public string provideTypeText { get; set; }

        /// <summary>
        /// 备料是否必领料  0----false , 1----true
        /// </summary>
        public int? ps_isMustReq { get; set; }


        public string IsMustReqText
        {
            get
            {
                if (ps_isMustReq == 0)
                {
                    return "否";
                }
                return "是";
            }
        }

        /// <summary>
        /// 备料计划被用量
        /// </summary>
        public decimal? ps_plannedQty { get; set; }

        /// <summary>
        /// 备料流程
        /// </summary>
        public string ps_flow { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ps_remark { get; set; }

        /// <summary>
        /// 状态
        /// 0:未配料
        /// 1:已配料
        /// 2:缺料
        /// 3:其他
        /// </summary>
        public int? ps_status { get; set; }

        public string ps_statusText
        {
            get
            {
                if (ps_status == 0)
                    return "未备料";
                else if (ps_status == 1)
                    return "备料完成";
                else if (ps_status == 2)
                    return "缺/少料、不足";
                else if (ps_status == 3)
                    return "无料";
                return "";
            }
        }

        public string paraStr { get; set; }

        /// <summary>
        /// 齐套物料百分比（%）
        /// </summary>
        public decimal? ps_materialPercent { get; set; }

        /// <summary>
        /// 齐套结果（检验结果:-1:空；0:不合格；1：合格）
        /// </summary>
        public int? ps_checkResult { get; set; }

        public string pt_checkResultText
        {
            get
            {
                if (ps_checkResult == 0)
                {
                    return "不合格";
                }
                else if (ps_checkResult == 1)
                {
                    return "合格";
                }
                return "空";
            }
        }

        /// <summary>
        /// 齐套分析时间
        /// </summary>
        public DateTime? ps_BundleAnalysisTime { get; set; }

        public string ps_BundleAnalysisTimeText
        {
            get
            {
                if (ps_BundleAnalysisTime == null)
                    return "";
                return ps_BundleAnalysisTime.Value.ToString("yyyy-MM-dd");

            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) ps_BundleAnalysisTime = dt;
            }
        }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? ps_deleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? ps_createTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? ps_createMan { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? ps_updateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? ps_updateMan { get; set; }

        /// <summary>
        /// 获取计划状态用于判断选择框启用或禁用
        /// </summary>
        public int? pp_status { get; set; }


    }
}
