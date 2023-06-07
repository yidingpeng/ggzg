using System.Collections.Generic;
using RW.PMS.Model;
using RW.PMS.Common;

namespace RW.PMS.IBLL
{
    public interface IBLL_BundleAnalysis : IDependence
    {
        List<BundleAnalysisPlanModel> BundleAnalysis(params string[] ppCodes);


        /// <summary>
        /// 保存齐套分析结果
        /// </summary>
        /// <param name="BundleAnalysisPlanModel"></param>
        /// <returns></returns>
        int SaveBundleAnalysisResults(List<BundleAnalysisPlanModel> BundleAnalysisList);

    }
}