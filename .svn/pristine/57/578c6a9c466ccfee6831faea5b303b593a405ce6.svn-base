using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 产品信息表
    /// </summary>
    public class ProductInfoModel : BaseModel
    {
        public int ID { get; set; }
        /// <summary>
        /// 产品信息ID
        /// </summary>
        public int pf_ID { get; set; }


        /// <summary>
        /// 台车号
        /// </summary>
        public string pf_alias { get; set; }

        /// <summary>
        /// 产品编号,二次生产时可重复
        /// </summary>
        public string pf_prodNo { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string pf_serialNumber { get; set; }

        /// <summary>
        /// 计划主表ID
        /// </summary>
        public int pp_guid { get; set; }

        //生产计划编号
        public string pp_orderCode { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        // public int pf_prodID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Pname { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? pf_prodModelID { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? pf_startTime { get; set; }

        public string pf_startTimeText
        {
            get
            {
                if (pf_startTime == null)
                    return "";
                return pf_startTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pf_startTime = dt;
            }
        }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? pf_finishTime { get; set; }

        public string pf_finishTimeText
        {
            get
            {
                if (pf_finishTime == null)
                    return "";
                return pf_finishTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) pf_finishTime = dt;
            }
        }

        /// <summary>
        /// 产品完成状态：0：未完成，1：已完成、已发货，2：异常下线，3：重新装配 4：返回上一步; 5:例外转序
        /// </summary>
        public int? pf_finishStatus { get; set; }

        public string pf_finishStatusText
        {
            get
            {
                if (pf_finishStatus == 1)
                    return "已完成";
                if (pf_finishStatus == 2)
                    return "异常下线";
                if (pf_finishStatus == 3)
                    return "重新装配";
                if (pf_finishStatus == 4)
                    return "返回上一步";
                if (pf_finishStatus == 4)
                    return "例外转序";
                return "未完成";
            }
        }

        /// <summary>
        /// 质量结果
        /// </summary>
        public int? pf_resultIsOK { get; set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string pf_resultMemo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string pf_remark { get; set; }


        public int? deleteFlag { get; set; }


        /// <summary>
        /// 当前装配工位
        /// </summary>
        public int? currGwID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? updateTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? createMan { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? updateMan { get; set; }


        #region 质检报告

        public string SerialNumber { get; set; }
        public string ProdNo { get; set; }
        public string Prod_name { get; set; }
        public string Prod_ModelName { get; set; }
        public string DrawingNo { get; set; }
        public DateTime? starttime { get; set; }

        public string starttimeText
        {
            get
            {
                if (!starttime.HasValue)
                    return " ";
                return starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public DateTime? finishtime { get; set; }

        public string finishtimeText
        {
            get
            {
                if (!finishtime.HasValue)
                    return " ";
                return finishtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string ResultMemo { get; set; }
        public string OrderCode { get; set; }



        #endregion



        #region 计划字段

        /// <summary>
        /// 项目号
        /// </summary>
        public string pp_project { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string pp_projectName { get; set; }


        /// <summary>
        /// 计划数量
        /// </summary>
        public int pp_planQty { get; set; }


        /// <summary>
        /// 跟踪号
        /// </summary>
        public string pp_trackNumber { get; set; }

        /// <summary>
        /// 已完成数量（完成情况）
        /// </summary>
        public int? FinishQty { get; set; }

        /// <summary>
        /// 已合格数量（质量情况）
        /// </summary>
        public int? Okqty { get; set; }

        /// <summary>
        /// 未完成数量（完成情况）
        /// </summary>
        public int? UnFinishedQty { get; set; }

        /// <summary>
        /// 未合格数量（质量情况）
        /// </summary>
        public int? Errorqty { get; set; }

        /// <summary>
        /// 计划数量（完成情况、质量情况）
        /// </summary>
        public int? TotalQty { get; set; }

        /// <summary>
        /// 完成率（完成情况）
        /// </summary>
        public string FinishRate { get; set; }

        /// <summary>
        /// 合格率（质量情况）
        /// </summary>
        public string OkRate { get; set; }

        /// <summary>
        /// 计划开始时间-计划结束时间
        /// </summary>
        public string Date { get; set; }


        public DateTime? pp_startDate { get; set; }

        public DateTime? pp_finishDate { get; set; }




        #endregion


        public int? RealityQty { get; set; }

        /// <summary>
        /// 日周月
        /// </summary>
        public List<ProductInfo> ProductInfoList { get; set; }


        public class ProductInfo
        {

            /// <summary>
            /// 产品型号ID
            /// </summary>
            public int? pf_prodModelID { get; set; }

            /// <summary>
            /// 产品型号
            /// </summary>
            public string Pmodel { get; set; }

            /// <summary>
            /// 日计划
            /// </summary>
            public int? DayPlanQty { get; set; }

            /// <summary>
            /// 日实际
            /// </summary>
            public int? DayRealityQty { get; set; }

            /// <summary>
            /// 周计划
            /// </summary>
            public int? WeekPlanQty { get; set; }

            /// <summary>
            /// 周实际
            /// </summary>
            public int? WeekRealityQty { get; set; }

            /// <summary>
            /// 月计划
            /// </summary>
            public int? MonthPlanQty { get; set; }

            /// <summary>
            /// 月实际
            /// </summary>
            public int? MonthRealityQty { get; set; }
        }



        /// <summary>
        /// 上线数
        /// </summary>
        public int Online { get; set; }


        /// <summary>
        /// 下线数
        /// </summary>
        public int Showing { get; set; }


    }
}
