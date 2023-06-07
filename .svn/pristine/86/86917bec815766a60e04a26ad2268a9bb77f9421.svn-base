namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_baseData
    {
        public int ID { get; set; }

        public int? bdtypeID { get; set; }

        [StringLength(150)]
        public string bdtypeCode { get; set; }

        [StringLength(150)]
        public string bdcode { get; set; }

        [StringLength(150)]
        public string bdname { get; set; }

        [StringLength(255)]
        public string bdvalue { get; set; }

        public int? bdParentID { get; set; }

        public int? isDeleted { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
