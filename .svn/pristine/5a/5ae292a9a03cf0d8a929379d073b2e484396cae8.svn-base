using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// opc产品型号
    /// </summary>
    public class BaseOPCProductModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public int? PID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Pname { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string PmodelNo { get; set; }

        /// <summary>
        /// 产品图号 2020-03-05 LHR
        /// </summary>
        public string DrawingNo { get; set; }

        /// <summary>
        /// 产品型号——图号
        /// </summary>
        public string PmodelDrawingNo { get; set; }

        /// <summary>
        /// 产品型号名称与编号
        /// </summary>
        public string PmodelPmodelNo
        {
            get
            {
                return Pmodel + "_" + PmodelNo;
            }
        }

        /// <summary>
        /// 生产节拍
        /// </summary>
        public int? beatMinite { get; set; }

        /// <summary>
        /// 产品型号总物料阀值（%）百分比
        /// </summary>
        public int? threshold { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? Pstatus { get; set; }

        public string status
        {
            get
            {
                if (Pstatus != 0)
                {
                    return "禁用";
                }
                return "启用";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        public List<GjWlOpcPointModel> opclist { get; set; }
    }
}
