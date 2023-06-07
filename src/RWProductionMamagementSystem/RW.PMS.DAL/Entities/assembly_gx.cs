namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class assembly_gx
    {
        [Key]
        public Guid agx_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int? pInfo_ID { get; set; }

        public Guid? agw_guid { get; set; }

        public int? agx_gxID { get; set; }

        [StringLength(150)]
        public string agx_gxName { get; set; }

        public int? agx_operID { get; set; }

        [StringLength(150)]
        public string agx_oper { get; set; }

        public DateTime? agx_starttime { get; set; }

        public DateTime? agx_finishtime { get; set; }

        public int? agx_finishStatus { get; set; }

        public int? agx_resultIsOK { get; set; }

        [StringLength(255)]
        public string agx_resultMemo { get; set; }

        [StringLength(255)]
        public string agx_remark { get; set; }

        public int? agx_uploadFlag { get; set; }
    }
}
