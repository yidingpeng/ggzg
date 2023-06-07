namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_gongwei
    {
        public int ID { get; set; }

        [StringLength(150)]
        public string gwcode { get; set; }

        [StringLength(150)]
        public string gwname { get; set; }

        public int? gwStatus { get; set; }

        [StringLength(150)]
        public string IP { get; set; }

        public int? areaID { get; set; }

        public int? gwOrder { get; set; }

        public int? isFinishGW { get; set; }

        public int? isHasFollow { get; set; }

        public int? isHasAms { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
