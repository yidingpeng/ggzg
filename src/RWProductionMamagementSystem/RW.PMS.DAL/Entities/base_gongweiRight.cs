namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_gongweiRight
    {
        public int ID { get; set; }

        public int? gwID { get; set; }

        public int? empID { get; set; }

        public int? gwrStatus { get; set; }

        public int? rightTypeID { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
