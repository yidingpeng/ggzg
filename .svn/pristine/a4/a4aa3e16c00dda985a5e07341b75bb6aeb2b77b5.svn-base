using System;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 物料
    /// </summary>
    public class BaseMaterialModel : BaseModel
    {

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string mCode { get; set; }

        /// <summary>
        /// 外部物料编码
        /// </summary>
        public string mECode { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string mName { get; set; }

        /// <summary>
        /// 物料简称
        /// </summary>
        public string mAbbr { get; set; }

        /// <summary>
        /// 成品类型
        /// </summary>
        public int? mPTypeID { get; set; }

        /// <summary>
        /// 产品类型（显示文本）
        /// </summary>
        public string mPTypeText
        {
            get
            {
                switch (mPTypeID)
                {
                    case 1:
                        return "部件";
                    case 2:
                        return "零件";
                    case 3:
                        return "原料";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// 物料类型
        /// </summary>
        public int? mTypeID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string mtName { get; set; }

        /// <summary>
        /// 更换类型
        /// </summary>
        public int? mRTypeID { get; set; }


        /// <summary>
        /// 更换类型(显示文本)
        /// </summary>
        public string mRTypeText
        {
            get
            {
                if (mRTypeID == 0) return "偶换件";
                else if (mRTypeID == 1) return "必换件";
                return "";
            }
        }

        /// <summary>
        /// 默认单位
        /// </summary>
        public string mUnit { get; set; }

        /// <summary>
        /// 物料图片
        /// </summary>
        public byte[] mImg { get; set; }


        ///// <summary>
        ///// 是否删除图片
        ///// </summary>
        public bool Delimg { get; set; }

        /// <summary>
        /// 装配匹配标识 	装配时是否要录物料编码
        /// </summary>
        public int? mAMatchFlag { get; set; }

        /// <summary>
        /// 装配匹配标识（显示文本） 	装配时是否要录物料编码
        /// </summary>
        public string mAMatchFlagText
        {
            get
            {
                if (mAMatchFlag == 0) return "否";
                else if (mAMatchFlag == 1) return "是";
                return "";
            }
        }

        /// <summary>
        /// 规格参数
        /// </summary>
        public string mSpec { get; set; }

        /// <summary>
        /// 供应商ID
        /// </summary>
        public int? mSupplierID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string suName { get; set; }

        /// <summary>
        /// 供货号
        /// </summary>
        public string mSupplyNo { get; set; }

        /// <summary>
        /// 图号
        /// </summary>
        public string mDrawingNo { get; set; }

        public string LIKEmDrawingNo { get; set; }

        /// <summary>
        /// 批次号
        /// </summary>
        public string mBatchNo { get; set; }

        /// <summary>
        /// 标准
        /// </summary>
        public string mStandard { get; set; }

        /// <summary>
        /// 安全库存标识
        /// </summary>
        public int? mSInvFlag { get; set; }
        
        /// <summary>
        /// 安全库存数量
        /// </summary>
        public decimal? mSInvQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string mRemark { get; set; }

        /// <summary>
        /// 禁用标识
        /// </summary>
        public int? mDisableFlag { get; set; }

        /// <summary>
        /// 禁用标识（显示文本）
        /// </summary>
        public string mDisableFlagText
        {
            get
            {
                if (mAMatchFlag == 0) return "启用";
                else if (mAMatchFlag == 1) return "禁用";
                return "";
            }
        }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? mDeleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? mCreateTime { get; set; }
        
        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? mCreaterID { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? mUpdateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? mUpdaterID { get; set; }

        /// <summary>
        /// 物料编码（模糊搜索）
        /// </summary>
        public string LIKECode { get; set; }

        /// <summary>
        /// 物料名称（模糊搜索）
        /// </summary>
        public string LIKEName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? UNID { get; set; }


        public string mNameDrawingNo { get; set; }


        
    }
}
