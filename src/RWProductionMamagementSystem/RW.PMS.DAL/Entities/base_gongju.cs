namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_gongju
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string gjname { get; set; }

        [Column(TypeName = "image")]
        public byte[] gjImg { get; set; }

        public int? gjTypeID { get; set; }

        public int? gjIsHasCode { get; set; }

        public int? gjStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
