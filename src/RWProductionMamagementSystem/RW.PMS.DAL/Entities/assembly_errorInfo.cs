namespace RW.PMS.DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class assembly_errorInfo
    {
        public int ID { get; set; }

        public int? ErrorTypeID { get; set; }

        public int? pInfo_ID { get; set; }
        public Guid? fp_guid { get; set; }

        //[StringLength(150)]
        //public string fp_QRcode { get; set; }

        public Guid? agw_guid { get; set; }

        public Guid? agx_guid { get; set; }

        public Guid? agb_guid { get; set; }

        public Guid? agj_guid { get; set; }

        public int? err_operID { get; set; }

        [StringLength(150)]
        public string err_oper { get; set; }

        public int? err_gwID { get; set; }

        [StringLength(150)]
        public string err_gw { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? errDate { get; set; }

        [StringLength(255)]
        public string errorDesp { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
