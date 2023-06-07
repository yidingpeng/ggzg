namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_Device
    {
        public int id { get; set; }

        [StringLength(150)]
        public string devName { get; set; }

        [StringLength(150)]
        public string devNo { get; set; }

        [StringLength(50)]
        public string devIP { get; set; }

        public DateTime? createDate { get; set; }

        public int? devStatus { get; set; }

        [StringLength(50)]
        public string devCardno { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
