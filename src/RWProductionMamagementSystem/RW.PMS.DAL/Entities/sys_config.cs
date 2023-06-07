namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_config
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string cfg_code { get; set; }

        [StringLength(255)]
        public string cfg_value { get; set; }

        [StringLength(255)]
        public string desp { get; set; }

        public int isDeleted { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
