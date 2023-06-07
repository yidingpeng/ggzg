namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class follow_barcode_Log
    {
        public int id { get; set; }

        public Guid? fgw_guid { get; set; }

        public Guid? fm_guid { get; set; }

        public Guid? fd_guid { get; set; }

        public Guid? fp_guid { get; set; }

        public int? pInfo_ID { get; set; }

        [StringLength(50)]
        public string fm_StampNo { get; set; }

        public int? fd_gwID { get; set; }

        [StringLength(50)]
        public string fd_gwName { get; set; }

        public int? fd_areaID { get; set; }

        [StringLength(50)]
        public string fd_areaName { get; set; }

        public int? fd_wuliaoLJid { get; set; }

        [StringLength(50)]
        public string fd_wuliaoLJName { get; set; }

        public int? fd_isWuliaoBox { get; set; }

        public int? fd_operID { get; set; }

        [StringLength(50)]
        public string fd_oper { get; set; }

        public DateTime? fd_createtime { get; set; }

        [StringLength(50)]
        public string c_cardNo { get; set; }

        public int? c_cardType { get; set; }

        public int? c_AmsGwID { get; set; }

        public int? c_status { get; set; }

        [StringLength(255)]
        public string c_remark { get; set; }
    }
}
