using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Test
{
    /// <summary>
    /// 试验结果表
    /// </summary>
    public class TestResultModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int trID { get; set; }

        /// <summary>
        /// 试验配置明细表ID
        /// </summary>
        public string tcdID { get; set; }

        /// <summary>
        /// fmGUID
        /// </summary>
        public Guid fmGUID { get; set; }

        /// <summary>
        /// 试验结果文本
        /// </summary>
        public string trText { get; set; }

        /// <summary>
        /// 试验结果标识
        /// </summary>
        public int trFlag { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string tcmRemark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? tcmDeleteFlag { get; set; }

        /// <summary>
        /// 创建者时间
        /// </summary>
        public DateTime? tcmCreateTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? tcmCreaterID { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? tcmUpdateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? tcmUpdaterID { get; set; }




        public string prodNo { get; set; }


        /// <summary>
        /// 需要传入的工位ID
        /// </summary>
        public int? GwID { get; set; }

        /// <summary>
        /// 需要传入的工位名称
        /// </summary>
        public string GwName { get; set; }

    }
}
