namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class device_upKeepPlan
    {
        public int id { get; set; }

        public int? devID { get; set; }

        public int? upKeepTypeID { get; set; }

        [StringLength(255)]
        public string planMemo { get; set; }

        public DateTime? planDate { get; set; }

        public DateTime? execDate { get; set; }

        public int? execStatus { get; set; }

        public int? execEmp { get; set; }

        [StringLength(50)]
        public string execEmpName { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
