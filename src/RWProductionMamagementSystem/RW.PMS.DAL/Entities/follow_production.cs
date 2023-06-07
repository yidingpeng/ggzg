namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_production
    {
        [Key]
        public Guid fp_guid { get; set; }

        public Guid? pp_guid { get; set; }

        public int? fp_pInfo_ID { get; set; }

        [StringLength(150)]
        public string fp_prodNo_sys { get; set; }

        public int? fp_repairTypeID { get; set; }

        public DateTime? fp_startTime { get; set; }

        public DateTime? fp_finishTime { get; set; }

        public int? fp_finishStatus { get; set; }

        public int? fp_resultIsOK { get; set; }

        [StringLength(255)]
        public string fp_resultMemo { get; set; }

        [Column(TypeName = "image")]
        public byte[] fp_report { get; set; }

        [StringLength(255)]
        public string fp_remark { get; set; }

        public int? fp_uploadFlag { get; set; }
    }
}
