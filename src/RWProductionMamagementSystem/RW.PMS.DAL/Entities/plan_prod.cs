namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class plan_prod
    {
        [Key]
        public Guid pp_guid { get; set; }

        public Guid pp_fp_guid { get; set; }

        public int? pp_pInfo_ID { get; set; }

        public int? pp_isStart { get; set; }

        public DateTime? pp_startDate { get; set; }

        public DateTime? pp_finishDate { get; set; }

        [StringLength(255)]
        public string pp_remark { get; set; }
    }
}
