namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_Tools
    {
        [Key]
        public int id { get; set; }

        public int? devID { get; set; }

        [StringLength(50)]
        public string devName { get; set; }

        [StringLength(150)]
        public string devSubjectionIP { get; set; }

        public int? toolId { get; set; }

        public string toolName { get; set; }

        [StringLength(50)]
        public string toolModels { get; set; }

        [StringLength(255)]
        public string toolCode { get; set; }

        public DateTime? devPurchaseDate { get; set; }

        public DateTime? devExpireDate { get; set; }

        public int? devStatus { get; set; }

        public int? devInspectionCount { get; set; }

        [StringLength(255)]
        public string devremark { get; set; }
    }
}
