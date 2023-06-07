namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class program_ValueInfo
    {
        public int ID { get; set; }

        public int? progGjInfoID { get; set; }

        public int? valueTypeID { get; set; }

        public int? EqualTypeID { get; set; }

        [StringLength(150)]
        public string standardValue { get; set; }

        [StringLength(150)]
        public string minValue { get; set; }

        [StringLength(150)]
        public string maxValue { get; set; }

        public int? pVInfoStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }

        public decimal? pixelPoint { get; set; }
    }
}
