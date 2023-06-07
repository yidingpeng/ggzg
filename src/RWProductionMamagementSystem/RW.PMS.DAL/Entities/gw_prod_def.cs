namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class gw_prod_def
    {
        public int ID { get; set; }

        public int? gwID { get; set; }

        public int? prodModelID { get; set; }

        public int? componentID { get; set; }

        public int? progID { get; set; }

        public int? beatMinite { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
