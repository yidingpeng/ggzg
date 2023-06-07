namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class product_test
    {
        public int ID { get; set; }

        public Guid? fm_guid { get; set; }

        [StringLength(150)]
        public string fm_prodNo { get; set; }

        [StringLength(150)]
        public string stampNo { get; set; }

        [StringLength(150)]
        public string labNo { get; set; }

        [StringLength(150)]
        public string labType { get; set; }

        [StringLength(150)]
        public string testNo { get; set; }

        [StringLength(150)]
        public string test_Qrcode { get; set; }

        public int? gwId { get; set; }

        [StringLength(150)]
        public string gwIP { get; set; }

        public int? prodModel_id { get; set; }

        [StringLength(150)]
        public string prodModel_name { get; set; }

        public int? componentId { get; set; }

        [StringLength(150)]
        public string componentName { get; set; }

        [StringLength(150)]
        public string test_makeNo { get; set; }

        public int? test_operID { get; set; }

        [StringLength(150)]
        public string test_oper { get; set; }

        public int? test_ownerID { get; set; }

        [StringLength(150)]
        public string test_owner { get; set; }

        public int? test_checkID { get; set; }

        [StringLength(150)]
        public string test_checker { get; set; }

        public DateTime? test_starttime { get; set; }

        public DateTime? test_finishtime { get; set; }

        [StringLength(150)]
        public string prod_weight { get; set; }

        public int? test_resultIsOK { get; set; }

        [StringLength(255)]
        public string test_resultMemo { get; set; }

        [Column(TypeName = "image")]
        public byte[] test_reprtImg { get; set; }

        [Column(TypeName = "image")]
        public byte[] test_reprtFile { get; set; }

        [StringLength(100)]
        public string test_reportName { get; set; }

        [StringLength(255)]
        public string test_remark { get; set; }

        public int? test_uploadFlag { get; set; }
    }
}
