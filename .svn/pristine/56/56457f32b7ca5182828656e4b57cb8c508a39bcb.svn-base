namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_check
    {
        [Key]
        public Guid fc_guid { get; set; }

        public Guid? fm_guid { get; set; }

        [StringLength(50)]
        public string fm_prodNo { get; set; }

        [StringLength(50)]
        public string fc_gwID { get; set; }

        [StringLength(150)]
        public string fc_gwName { get; set; }

        public int? fc_areaID { get; set; }

        [StringLength(150)]
        public string fc_areaName { get; set; }

        [StringLength(50)]
        public string fc_operID { get; set; }

        [StringLength(150)]
        public string fc_oper { get; set; }

        public DateTime? fc_starttime { get; set; }

        public DateTime? fc_finishtime { get; set; }

        public int? fc_followStatus { get; set; }

        public int? fc_selfCheckerID { get; set; }

        [StringLength(50)]
        public string fc_selfChecker { get; set; }

        public DateTime? fc_selfCheckTime { get; set; }

        public int? fc_selfCheckResult { get; set; }

        [StringLength(255)]
        public string fc_selfResultMemo { get; set; }

        public int? fc_mutualCheckerID { get; set; }

        [StringLength(50)]
        public string fc_mutualChecker { get; set; }

        public DateTime? fc_mutualCheckTime { get; set; }

        public int? fc_mutualCheckResult { get; set; }

        [StringLength(255)]
        public string fc_mutualResultMemo { get; set; }

        public int? fc_specialCheckerID { get; set; }

        [StringLength(50)]
        public string fc_specialChecker { get; set; }

        public DateTime? fc_specialCheckTime { get; set; }

        public int? fc_specialCheckResult { get; set; }

        [StringLength(255)]
        public string fc_specialResultMemo { get; set; }

        [StringLength(255)]
        public string fc_remark { get; set; }

        public int? fc_uploadFlag { get; set; }
    }
}
