namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_role
    {
        [Key]
        public int roleID { get; set; }

        [StringLength(150)]
        public string roleName { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
