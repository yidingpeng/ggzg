namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_faultRepair
    {
        [Key]
        public int id { get; set; }

        public int? fr_devID { get; set; }

        [StringLength(50)]
        public string fr_devName { get; set; }

        public int? fr_operID { get; set; }

        [StringLength(50)]
        public string fr_oper { get; set; }

        public DateTime? fr_createtime { get; set; }

        public int? fr_faultCode { get; set; }

        public int? fr_faultLevel { get; set; }

        public int? fr_faultClass { get; set; }

        public int? pf_prodModelID { get; set; }

        public int? pf_carModelID { get; set; }

        [StringLength(50)]
        public string pf_carNo { get; set; }

        [StringLength(150)]
        public string pf_prodNo { get; set; }

        [StringLength(255)]
        public string fr_faultMemo { get; set; }

        [StringLength(255)]
        public string fr_repairMemo { get; set; }

        public int? fr_emergency { get; set; }

        public DateTime? fr_solve_time { get; set; }

        public int? fr_solve_operID { get; set; }

        [StringLength(50)]
        public string fr_solve_oper { get; set; }

        [StringLength(150)]
        public string fr_solve_reason { get; set; }

        [StringLength(255)]
        public string fr_solve_method { get; set; }

        public int? fr_status { get; set; }

        [StringLength(255)]
        public string fr_remark { get; set; }
    }
}