namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_feedback
    {
        public int id { get; set; }

        public int? fb_areaID { get; set; }

        [StringLength(50)]
        public string fb_areaName { get; set; }

        public int? fb_gwID { get; set; }

        [StringLength(50)]
        public string fb_gwName { get; set; }

        public int? fb_operID { get; set; }

        [StringLength(50)]
        public string fb_oper { get; set; }

        public DateTime? fb_createtime { get; set; }

        [StringLength(255)]
        public string fb_feedMemo { get; set; }

        [StringLength(255)]
        public string fb_remark { get; set; }

        public int? fb_isok { get; set; }

        [StringLength(255)]
        public string fb_result { get; set; }
    }
}
