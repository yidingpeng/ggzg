namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_gongbu
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string gbname { get; set; }

        [StringLength(500)]
        public string gbdesc { get; set; }

        [Column(TypeName = "image")]
        public byte[] gbimg { get; set; }

        [StringLength(255)]
        public string gbvedio { get; set; }

        public int? gbStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
