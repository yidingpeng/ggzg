namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_barcode
    {
        public int id { get; set; }

        [StringLength(50)]
        public string c_cardNo { get; set; }

        public int? c_cardType { get; set; }

        public int? c_AmsGwID { get; set; }

        [StringLength(50)]
        public string c_putLocation { get; set; }

        public int? c_curAreaID { get; set; }

        public int? c_curGwID { get; set; }

        public Guid? c_curFmGuid { get; set; }

        [StringLength(50)]
        public string c_curProdNo { get; set; }

        public int? c_curComponentId { get; set; }

        [StringLength(50)]
        public string c_curStampNo { get; set; }

        public int? c_status { get; set; }

        [StringLength(255)]
        public string c_remark { get; set; }
    }
}
