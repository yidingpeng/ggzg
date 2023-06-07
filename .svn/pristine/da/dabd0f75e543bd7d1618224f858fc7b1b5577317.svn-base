using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Plan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    /// 齐套分析计划信息
    /// </summary>
    [Serializable]
    public class BundleAnalysisPlanModel : PartPlanModel
    {
        public BundleAnalysisPlanModel()
        {
            TechModels = new List<BundleAnalysisPlanTechnicsModel>();
            Config = new BundleAnalysisConfigModel();
        }
        /// <summary>
        /// 实际所占总体物料百分比
        /// </summary>
        public decimal ActualPercent { get; set; }

        /// <summary>
        /// 齐套分析结果 -1：空 0：不合格 1：合格  
        /// </summary>
        public int CheckRestult { get; set; }

        /// <summary>
        /// 计划所属工序信息
        /// </summary>
        public List<BundleAnalysisPlanTechnicsModel> TechModels { get; set; }

        /// <summary>
        /// 齐套分析配置信息
        /// </summary>
        public BundleAnalysisConfigModel Config { get; set; }
    }

    /// <summary>
    /// 齐套分析计划工序信息
    /// </summary>
    [Serializable]
    public class BundleAnalysisPlanTechnicsModel : PartPlanTechnicsModel
    {
        public BundleAnalysisPlanTechnicsModel()
        {
            StockModels = new List<BundleAnalysisPlanStockModel>();
        }

        /// <summary>
        /// 所占总体物料百分比
        /// </summary>
        public decimal Percent { get; set; }
       
        /// <summary>
        /// 实际所占总体物料百分比
        /// </summary>
        public decimal ActualPercent { get; set; }

        /// <summary>
        /// 工序所属备料信息
        /// </summary>
        public List<BundleAnalysisPlanStockModel> StockModels { get; set; }

    }

    /// <summary>
    /// 齐套分析计划备料信息
    /// </summary>
    [Serializable]
    public class BundleAnalysisPlanStockModel : PartPlanStockModel
    {
        /// <summary>
        /// 所占总体物料百分比
        /// </summary>
        public decimal Percent { get; set; }

        /// <summary>
        /// 当前物料是否必须存在（关键物料）
        /// </summary>
        public int Must { get; set; }

        /// <summary>
        /// 实际数量
        /// </summary>
        public decimal ActualQty { get; set; }

        /// <summary>
        /// 实际所占总体物料百分比
        /// </summary>
        public decimal ActualPercent
        {
            get
            {
                return ActualQty / ps_qty.Value * Percent;
            }
        }

    }

    /// <summary>
    /// 齐套分析库存信息
    /// </summary>
    public class BundleAnalysisInventoryModel : BaseInventoryModel
    {
        /// <summary>
        /// 预扣库存数量
        /// </summary>
        public decimal? PlanQty { get; set; }

    }
}
