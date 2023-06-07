namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class device_checking
    {
        [Key]
        public int ID { get; set; }

        public int? devID { get; set; }

        public int? devCheckAreaID { get; set; }

        public int? checkLeveID { get; set; }

        public DateTime? checkTime { get; set; }

        public int? assignedToID { get; set; }

        public int? checkerID { get; set; }

        [StringLength(50)]
        public string checkResult { get; set; }

        [StringLength(255)]
        public string checkProblem { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}