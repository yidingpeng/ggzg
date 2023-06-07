namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class base_workmode
    {

        public int ID { get; set; }

        [StringLength(50)]
        public string wmName { get; set; }

        public string wmCode { get; set; }

        [StringLength(50)]
        public string wmColor { get; set; }

    }
}
