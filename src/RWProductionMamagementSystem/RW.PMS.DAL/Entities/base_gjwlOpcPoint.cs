namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_gjwlOpcPoint
    {
        public int ID { get; set; }

        public int? gwID { get; set; }

        public int? gjID { get; set; }

        public int? wlID { get; set; }

        [StringLength(150)]
        public string opcDeviceName { get; set; }

        public int? opcTypeID { get; set; }

        [StringLength(150)]
        public string opcTypeCode { get; set; }

        [StringLength(150)]
        public string opcValue { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
