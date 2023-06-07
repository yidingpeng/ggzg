namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class program_GxInfo
    {
        public int ID { get; set; }

        public int? progID { get; set; }

        public int? gxID { get; set; }

        public int? gxOrder { get; set; }

        public int? pgxInfoStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
