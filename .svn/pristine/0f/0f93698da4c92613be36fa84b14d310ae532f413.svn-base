namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class assembly_gb
    {
        [Key]
        public Guid agb_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int? pInfo_ID { get; set; }

        public Guid? agx_guid { get; set; }

        public int? agb_gbID { get; set; }

        [StringLength(150)]
        public string agb_gbName { get; set; }

        public int? agb_operID { get; set; }

        [StringLength(150)]
        public string agb_oper { get; set; }

        public DateTime? agb_starttime { get; set; }

        public DateTime? agb_finishtime { get; set; }

        public int? agb_finishStatus { get; set; }

        public int? agb_resultIsOK { get; set; }

        [StringLength(255)]
        public string agb_resultMemo { get; set; }

        [Column(TypeName = "image")]
        public byte[] agb_finishImg { get; set; }

        [StringLength(255)]
        public string agb_value { get; set; }

        [StringLength(255)]
        public string agb_remark { get; set; }

        public int? agb_uploadFlag { get; set; }
    }
}
