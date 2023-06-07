namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class device_Remind
    {
        public int ID { get; set; }

        public int? TId { get; set; }

        public int? toolId { get; set; }

        [StringLength(150)]
        public string toolName { get; set; }

        [StringLength(50)]
        public string devCertificateNo { get; set; }

        public DateTime? devPurchaseDate { get; set; }

        public DateTime? devExpireDate { get; set; }

        public int? devStatus { get; set; }

        public int? empID { get; set; }

        public DateTime? inspectiontime { get; set; }

        [StringLength(255)]
        public string devremark { get; set; }
    }
}
