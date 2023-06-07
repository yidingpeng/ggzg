namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_gongxu
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string Gxname { get; set; }

        [StringLength(255)]
        public string Gxvedio { get; set; }

        [StringLength(150)]
        public string GxvedioFilename { get; set; }

        [StringLength(500)]
        public string Descript { get; set; }

        public int? gxStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
