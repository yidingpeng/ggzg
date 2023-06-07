namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class device_run
    {
        public int id { get; set; }

        public int? devID { get; set; }

        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
