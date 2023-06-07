namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_abnormal
    {
        public int id { get; set; }

        public int? fa_areaID { get; set; }

        [StringLength(50)]
        public string fa_areaName { get; set; }

        public int? fa_gwID { get; set; }

        [StringLength(50)]
        public string fa_gwName { get; set; }

        public int? fa_operID { get; set; }

        [StringLength(50)]
        public string fa_oper { get; set; }

        public DateTime? fa_createtime { get; set; }

        [StringLength(255)]
        public string fa_feedMemo { get; set; }

        [StringLength(255)]
        public string fa_remark { get; set; }

        public int? fa_isok { get; set; }

        [StringLength(255)]
        public string fa_result { get; set; }

        public int fa_agvstate { get; set; }
    }
}

