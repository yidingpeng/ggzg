namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_main
    {
        [Key]
        public Guid fm_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int? pInfo_ID { get; set; }

        public DateTime? fm_inHouseTime { get; set; }

        public DateTime? fm_starttime { get; set; }

        public DateTime? fm_finishtime { get; set; }

        public int? fm_finishStatus { get; set; }

        [StringLength(50)]
        public string fm_warehouse { get; set; }

        public int? fm_isSend { get; set; }

        public DateTime? fm_sendTime { get; set; }

        public int? fm_sender { get; set; }

        public int? fm_curAreaID { get; set; }

        public int? fm_curGwID { get; set; }

        [StringLength(50)]
        public string fm_curGw { get; set; }

        public int? fm_creatorID { get; set; }

        [StringLength(50)]
        public string fm_creator { get; set; }

        public int? fm_resultIsOK { get; set; }

        [StringLength(255)]
        public string fm_resultMemo { get; set; }

        [StringLength(255)]
        public string fm_remark { get; set; }

        public int? fm_uploadFlag { get; set; }
    }
}
