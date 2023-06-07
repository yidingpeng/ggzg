namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_gw
    {
        [Key]
        public Guid fgw_guid { get; set; }

        public Guid? fm_guid { get; set; }

        public Guid fp_guid { get; set; }

        public int pInfo_ID { get; set; }

        public int? fgw_gwID { get; set; }

        [StringLength(50)]
        public string fgw_gwName { get; set; }

        public int? fgw_areaID { get; set; }

        [StringLength(50)]
        public string fgw_areaName { get; set; }

        public int? fgw_operID { get; set; }

        [StringLength(50)]
        public string fgw_oper { get; set; }

        public DateTime? fgw_starttime { get; set; }

        public DateTime? fgw_finishtime { get; set; }

        public int? fgw_followStatus { get; set; }

        public int? fgw_checkResult { get; set; }

        [StringLength(255)]
        public string fgw_resultMemo { get; set; }

        [StringLength(255)]
        public string fgw_remark { get; set; }

        public int? fgw_uploadFlag { get; set; }
    }
}
