namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_roleMenuDef
    {
        public int ID { get; set; }

        public int? roleID { get; set; }

        public int? menuID { get; set; }

        //[StringLength(255)]
        //public string action_type { get; set; }

        public long? auth_value { get; set;}
    }
}
