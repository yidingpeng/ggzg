namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class assembly_gw
    {
        [Key]
        public Guid agw_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int? agw_prog_id { get; set; }

        public int? pInfo_ID { get; set; }

        [StringLength(150)]
        public string agw_prog_name { get; set; }

        public int? agw_gwID { get; set; }

        [StringLength(150)]
        public string agw_gwName { get; set; }

        [StringLength(150)]
        public string agw_QRcode { get; set; }

        public int? agw_operID { get; set; }

        [StringLength(150)]
        public string agw_oper { get; set; }

        public DateTime? agw_starttime { get; set; }

        public DateTime? agw_finishtime { get; set; }

        public int? agw_finishStatus { get; set; }

        public int? agw_resultIsOK { get; set; }

        [StringLength(255)]
        public string agw_resultMemo { get; set; }

        [StringLength(255)]
        public string agw_remark { get; set; }

        public int? agw_uploadFlag { get; set; }
    }
}
