using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Plan
{

    /// <summary>
    /// 配件计划主表 2020-03-03 LHR
    /// </summary>
    public class PartPlanModel : BaseModel
    {

        /// <summary>
        /// 订单编码（预留） 当前系统自动生成订单号：PP+年月日+四位流水号
        /// </summary>
        public string pp_orderCode { get; set; }

        public string LIKEorderCode { get; set; }

        /// <summary>
        /// 第三方系统关联订单编码（预留）订单编号：DQ+年月日+四位流水号
        /// </summary>
        public string pp_orderCodeRel { get; set; }

        public string LIKEorderCodeRel { get; set; }

        /// <summary>
        /// 库存组织编码
        /// </summary>
        public string pp_storageOrgUnit { get; set; }

        /// <summary>
        /// 事务类型编码（MTR-0004）
        /// </summary>
        public string pp_transactionType { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime? pp_bizDate { get; set; }

        public string pp_bizDateText
        {
            get
            {
                if (pp_bizDate == null)
                    return "";
                return pp_bizDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pp_bizDate = dt;
            }
        }

        /// <summary>
        /// 物料_编码(产品型号编码)
        /// </summary>
        public string pp_material { get; set; }

        public string LIKEPpmaterial { get; set; }

        /// <summary>
        /// 项目号_编码
        /// </summary>
        public string pp_project { get; set; }

        public string LIKEproject { get; set; }


        /// <summary>
        /// 项目名称
        /// </summary>
        public string pp_projectName { get; set; }

        /// <summary>
        /// 台车号
        /// </summary>
        public string pp_wagonNo { get; set; }


        /// <summary>
        /// 跟踪号_编码
        /// </summary>
        public string pp_trackNumber { get; set; }

        public string LIKEtrackNumber { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? pp_prodModelID { get; set; }

        public string Pmodel { get; set; }

        /// <summary>
        /// 0：未开始；1：已下发任务；2：已开始任务；3：已完成 4：已驳回
        /// </summary>
        public int? pp_status { get; set; }


        /// <summary>
        ///  0: 未开始  1:已下发 2: 已开始 3：已完成 4：已驳回
        /// </summary>
        public string pp_statusText
        {
            get
            {
                if (pp_status == 0)
                    return "未开始";
                else if (pp_status == 1)
                    return "已下发";
                else if (pp_status == 2)
                    return "已开始";
                else if (pp_status == 3)
                    return "已完成";
                else if (pp_status == 4)
                    return "已驳回";
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
        /// 计划完成日期
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

        public string pp_resultStartTimeText
        {
            get
            {
                if (pp_resultStartTime == null)
                    return "";
                return pp_resultStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pp_resultStartTime = dt;
            }
        }

        /// <summary>
        /// 实际结束时间
        /// </summary>
        public DateTime? pp_resultEndTime { get; set; }

        public string pp_resultEndTimeText
        {
            get
            {
                if (pp_resultEndTime == null)
                    return "";
                return pp_resultEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pp_resultEndTime = dt;
            }
        }

        /// <summary>
        /// 参考信息
        /// </summary>
        public string pp_description { get; set; }

        /// <summary>
        /// 主制部门
        /// </summary>
        public string pp_adminOrgUnitID { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string pp_remark { get; set; }


        /// <summary>
        /// 排序
        /// </summary>
        public int? pp_sort { get; set; }


        /// <summary>
        /// 总物料百分比 齐套率
        /// </summary>
        public decimal? pp_materialPercent { get; set; }

        /// <summary>
        /// 保留两位小数
        /// </summary>
        public string pp_materialPercent1 { get; set; }

        public string pp_materialPercentText { get; set; }

        /// <summary>
        /// 齐套结果（检验结果:-1:空；0:不合格；1：合格）
        /// </summary>
        public int? pp_checkResult { get; set; }

        public string pp_checkResultText
        {
            get
            {
                if (pp_checkResult == 0)
                {
                    return "不合格";
                }
                else if (pp_checkResult == 1)
                {
                    return "合 格";
                }
                return "空";
            }
        }

        /// <summary>
        /// 齐套分析时间
        /// </summary>
        public DateTime? pp_BundleAnalysisTime { get; set; }

        public string pp_BundleAnalysisTimeText {
            get
            {
                if (pp_BundleAnalysisTime == null)
                    return "";
                return pp_BundleAnalysisTime.Value.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pp_BundleAnalysisTime = dt;
            }
        }

        /// <summary>
        /// 齐套分析类型（自动1/手动0）
        /// </summary>
        public int? pp_BundleAnalysisType { get; set; }

        public string pp_BundleAnalysisTypeText
        {
            get
            {
                if (pp_BundleAnalysisType == 1)
                {
                    return "自 动";
                }
                return "手 动";
            }
        }


        /// <summary>
        /// 删除标识
        /// </summary>
        public int? pp_deleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? pp_createTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? pp_createMan { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? pp_updateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? pp_updateMan { get; set; }


        /// <summary>
        /// 产品型号 + 图号
        /// </summary>
        public string PmodelDrawingNo { get; set; }




        /// <summary>
        /// 排序字段名
        /// </summary>
        public string sort { get; set; }


        /// <summary>
        /// 排序方法（desc,asc）
        /// </summary>
        public string sortOrder { get; set; }


        /// <summary>
        /// 时间条件
        /// </summary>
        public string TimeConditions { get; set; }


    }
}
