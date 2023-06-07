using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Plan
{
    /// <summary>
    /// 齐套分析配置模型
    /// </summary>
    public class BundleAnalysisConfigModel
    {

        public BundleAnalysisConfigModel()
        {
            MaterialModels = new List<BundleAnalysisMaterialConfigModel>();
        }
        public decimal ThresholdValue { get; set; } = 0.5m;

        public List<BundleAnalysisMaterialConfigModel> MaterialModels { get; set; }


    }

    /// <summary>
    /// 齐套分析物料配置模型
    /// </summary>
    public class BundleAnalysisMaterialConfigModel : BaseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? ProdModelID { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string PModel { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public int? MID { get; set; }
        /// <summary>
        /// 物料编号
        /// </summary>
        public string MCode { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public int? wlID { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string mName { get; set; }

        public string LIKEWlName { get; set; }

        /// <summary>
        /// 百分比
        /// </summary>
        public decimal? percentValue { get; set; }

        public decimal? percentValueSum { get; set; }

        /// <summary>
        /// 是否必须
        /// </summary>
        public int? Must { get; set; }


        public string MustText
        {
            get
            {
                if (Must == 1)
                {
                    return "是";
                }
                return "否";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }



        public int? UNID { get; set; }

    }
}
