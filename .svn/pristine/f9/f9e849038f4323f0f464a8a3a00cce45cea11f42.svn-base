using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Data
{
    /// <summary>
    /// 产品合格率
    /// </summary>
    public class PercentPassModels : BaseModel
    {
        /// <summary>
        /// 产品id
        /// </summary>
        public int? prodID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string prodName { get; set; }

        /// <summary>
        /// 产品型号id
        /// </summary>
        public int? prodModelID { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string prodModelName { get; set; }

        /// <summary>
        /// 车型id
        /// </summary>
        public int? carModelID { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string carModelName { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string carNo { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }

        public int? fm_resultIsOK { get; set; }

        /// <summary>
        /// 质量结果
        /// </summary>

        public string fm_resultIsOKText
        {
            get
            {
                if (fm_resultIsOK == 0)
                    return "不合格";
                if (fm_resultIsOK == 1)
                    return "合格";
                return "";
            }
        }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? fm_finishtime { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Starttime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? Endtime { get; set; }
    }
}
