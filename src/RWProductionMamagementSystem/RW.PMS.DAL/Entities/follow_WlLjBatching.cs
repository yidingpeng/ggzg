namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_WlLjBatching
    {
        [Key]
        public Guid fw_guid { get; set; }

        public Guid? fgw_guid { get; set; }

        public Guid? fd_guid { get; set; }

        public Guid? fm_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int pInfo_ID { get; set; }

        public int? fw_gwID { get; set; }

        [StringLength(50)]
        public string fw_gwName { get; set; }

        public int? fw_areaID { get; set; }

        [StringLength(50)]
        public string fw_areaName { get; set; }

        public int? fw_componentId { get; set; }

        [StringLength(50)]
        public string fw_componentName { get; set; }

        public int? fw_wuliaoLJid { get; set; }

        [StringLength(50)]
        public string fw_wuliaoLJCode { get; set; }

        [StringLength(50)]
        public string fw_wuliaoLJName { get; set; }

        [StringLength(50)]
        public string fw_stampNo { get; set; }

        [StringLength(50)]
        public string fw_barcode { get; set; }

        public int? fw_replaceType { get; set; }

        public int? fw_isKeyLJ { get; set; }

        public int? fw_operID { get; set; }

        [StringLength(50)]
        public string fw_oper { get; set; }

        public DateTime? fw_createtime { get; set; }

        public DateTime? fw_finishtime { get; set; }

        public int? fw_batchResult { get; set; }

        public int? fw_followStatus { get; set; }

        public int? fw_batchQty { get; set; }

        public int? fw_batchFinishQty { get; set; }

        [StringLength(255)]
        public string fw_resultMemo { get; set; }

        [StringLength(255)]
        public string fw_remark { get; set; }

        public int? fw_uploadFlag { get; set; }
    }
}
