namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class assembly_gj
    {
        [Key]
        public Guid agj_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int? pInfo_ID { get; set; }

        public Guid? agb_guid { get; set; }

        public int? agj_gjID { get; set; }

        [StringLength(150)]
        public string agj_gjName { get; set; }

        public int? agj_wlID { get; set; }

        [StringLength(150)]
        public string agj_wlName { get; set; }

        [StringLength(150)]
        public string agj_gjwlCode { get; set; }

        public int? agj_operID { get; set; }

        [StringLength(150)]
        public string agj_oper { get; set; }

        public DateTime? agj_starttime { get; set; }

        public DateTime? agj_finishtime { get; set; }

        public int? agj_finishStatus { get; set; }

        public int? agj_resultIsOK { get; set; }

        [StringLength(255)]
        public string agj_resultMemo { get; set; }

        [StringLength(255)]
        public string agj_value { get; set; }

        [StringLength(255)]
        public string agj_value2 { get; set; }

        [Column(TypeName = "image")]
        public byte[] agj_valueImg { get; set; }

        [StringLength(255)]
        public string agj_remark { get; set; }

        public int? agj_uploadFlag { get; set; }
    }
}
