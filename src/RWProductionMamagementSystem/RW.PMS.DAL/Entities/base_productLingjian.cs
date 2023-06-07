namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_productLingjian
    {
        public int id { get; set; }

        public int? prodModelId { get; set; }

        public int? partId { get; set; }

        public int? replaceTypeID { get; set; }

        public int? wuliaoLJid { get; set; }

        public int? wuliaoCodeID { get; set; }

        public int? isKeyLJ { get; set; }

        public int? isComingHang { get; set; }

        public int? replaceQty { get; set; }

        [StringLength(50)]
        public string replaceRate { get; set; }

        [StringLength(50)]
        public string supplyNo { get; set; }

        public int? amsGwID { get; set; }

        public int? disGwID { get; set; }

        public int? program_GxInfoID { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
