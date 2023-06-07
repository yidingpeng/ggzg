namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_loginInfo
    {
        public int ID { get; set; }

        public int? empID { get; set; }

        [StringLength(150)]
        public string empName { get; set; }

        public DateTime? logintime { get; set; }

        public DateTime? unregisttime { get; set; }

        [StringLength(100)]
        public string hostName { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
