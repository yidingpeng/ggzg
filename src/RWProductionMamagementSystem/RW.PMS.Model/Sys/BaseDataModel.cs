using System;

namespace RW.PMS.Model.Sys
{
    public class BaseDataModel : BaseModel
    {
        public int ID { get; set; }

        /// <summary>
        /// 数据字典类型ID (sys_baseDataType)
        /// </summary>
        public int? bdtypeID { get; set; }

        public string BdtypeName { get; set; }

        /// <summary>
        /// 数据字典编码 (sys_baseDataType)
        /// </summary>
        public string bdtypeCode { get; set; }

        /// <summary>
        /// 字典编码
        /// </summary>
        public string bdcode { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        public string bdname { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        public string bdvalue { get; set; }

        /// <summary>
        /// 父级ID 本表
        /// </summary>
        public int? bdParentID { get; set; }

        /// <summary>
        /// 父级名称 本表
        /// </summary>
        public string BdParent { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int isDeleted { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }


        #region 质检报告总装关联分装

        public Guid? cp_ID { get; set; }
        public string cp_serialNumber { get; set; }
        public string cp_partsNo { get; set; }


        #endregion

    }
}
