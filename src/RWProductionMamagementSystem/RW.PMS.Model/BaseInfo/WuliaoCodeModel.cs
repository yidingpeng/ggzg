using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class WuliaoModelModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int wlmodelID { get; set; }

        /// <summary>
        /// 物料ID  外键ID base_Wuliao表
        /// </summary>
        public int wlID { get; set; }

        public string wlText { get; set; }

        /// <summary>
        /// 物料/零件规格型号	
        /// </summary>
        public string wlModels { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string wlUnit { get; set; }

        /// <summary>
        /// 供货号
        /// </summary>
        public string wlSupplierNo { get; set; }

        /// <summary>
        /// 图号
        /// </summary>
        public string wlFigureNo { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string wlBatchNo { get; set; }

        /// <summary>
        /// 标准
        /// </summary>
        public string wlStandard { get; set; }

        /// <summary>
        /// 是否考虑安全库存， 0不考虑；1考虑
        /// </summary>
        public int isSetSafeInventory { get; set; }

        public string IsSetSafeInventoryText { get; set; }

        /// <summary>
        /// 安全库存预警
        /// </summary>
        public int safeInventory { get; set; }

        /// <summary>
        /// 状态:1:启用；0：禁用
        /// </summary>
        public int wlModelStatus { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }




        /// <summary>
        /// ID
        /// </summary>
        public int? ID { get; set; }


        /// <summary>
        /// 物料编码
        /// </summary>
        public string wlcode { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string wlname { get; set; }

    }
}
