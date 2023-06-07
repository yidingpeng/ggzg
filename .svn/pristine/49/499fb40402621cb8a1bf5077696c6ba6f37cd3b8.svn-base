using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 产品Bom表
    /// </summary>
    public class BaseBomModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? prodModelId { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string ProdModelName { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int? GwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string GwName { get; set; }

        /// <summary>
        /// 工艺ID
        /// </summary>
        public int? progID { get; set; }

        /// <summary>
        /// 工艺名称
        /// </summary>
        public string progName { get; set; }

        /// <summary>
        /// 物料/零件ID 
        /// </summary>
        public int? wuliaoLJid { get; set; }

        /// <summary>
        /// 物料/零件名称
        /// </summary>
        public string wuliaoLJName { get; set; }

        /// <summary>
        /// 更换类型（必换件、偶换件），0:其他；1：必换件; 2：偶换件；3：组件
        /// </summary>
        public int? replaceTypeID { get; set; }

        /// <summary>
        /// 更换类型名称
        /// </summary>
        public string ReplaceType
        {
            get
            {
                switch (replaceTypeID.Value)
                {
                    case 0:
                        return "其他";
                    case 1:
                        return "必换件";
                    case 2:
                        return "偶换件";
                    case 3:
                        return "组件";
                    default:
                        return "其他";
                }
            }
        }

        /// <summary>
        /// 更换数量
        /// </summary>
        public int? replaceQty { get; set; }

    }
}
