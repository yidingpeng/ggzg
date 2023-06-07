namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_detail
    {
        [Key]
        public Guid fd_guid { get; set; }

        public Guid? fgw_guid { get; set; }

        public Guid? fm_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int pInfo_ID { get; set; }

        public int? fd_componentId { get; set; }

        [StringLength(50)]
        public string fd_componentName { get; set; }

        public int? fd_gwID { get; set; }

        [StringLength(50)]
        public string fd_gwName { get; set; }

        public int? fd_areaID { get; set; }

        [StringLength(50)]
        public string fd_areaName { get; set; }

        [StringLength(50)]
        public string fd_barcode { get; set; }

        public int? fd_wuliaoLJid { get; set; }

        [StringLength(50)]
        public string fd_wuliaoLJName { get; set; }

        public int? fd_isWuliaoBox { get; set; }

        [StringLength(50)]
        public string fd_stampNo { get; set; }

        public int? fd_operID { get; set; }

        [StringLength(50)]
        public string fd_oper { get; set; }

        public DateTime? fd_starttime { get; set; }

        public DateTime? fd_finishtime { get; set; }

        public int? fd_followStatus { get; set; }

        public int? fd_checkResult { get; set; }

        public int? fd_resultQty { get; set; }

        [StringLength(255)]
        public string fd_resultMemo { get; set; }

        public int? fd_isNextScan { get; set; }

        public int? fd_isCancel { get; set; }

        [StringLength(255)]
        public string fd_remark { get; set; }

        public int? fd_uploadFlag { get; set; }
    }
}
