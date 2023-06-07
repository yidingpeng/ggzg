using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{

    /// <summary>
    /// 物料条码卡表
    /// </summary>
    public class BaseMaterialBarCodeModel : BaseModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public int? m_prodID { get; set; }

        public string prodName { get; set; }


        /// <summary>
        /// 条码卡号
        /// </summary>
        public string m_cardNo { get; set; }

        /// <summary>
        /// 卡类型
        /// </summary>
        public int? m_cardType { get; set; }

        /// <summary>
        /// 物资编码
        /// </summary>
        public string m_code { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string m_batchNo { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public int? m_MaterialID { get; set; }

        /// <summary>
        ///物料名称
        /// </summary>
        public string m_MaterialText { get; set; }

        /// <summary>
        /// 物资编号
        /// </summary>
        public string mCode { get; set; }

        /// <summary>
        /// 图号
        /// </summary>
        public string mDrawingNo { get; set; }

        /// <summary>
        /// 零件号+物料名称
        /// </summary>
        public string mNameDrawingNo { get; set; }

        /// <summary>
        /// 供应商
        /// </summary>
        public int? m_supplierID { get; set; }


        public string m_supplierText { get; set; }

        /// <summary>
        /// 状态
        /// 0:启用
        /// 1:禁用
        /// </summary>
        public int? m_status { get; set; }

        public string m_statusText
        {
            get
            {
                if (m_status == 0) {
                    return "启用";
                }
                return "禁用";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string m_remark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? m_deleteFlag { get; set; }

        /// <summary>
        /// 规格或型号
        /// </summary>
        public string m_specificationmodels { get; set; }

        /// <summary>
        /// 制造商名称
        /// </summary>
        public string m_manufacturer { get; set; }



        /// <summary>
        /// 用于条码生成器使用
        /// </summary>
        public string barcode { get; set; }


    }
}
