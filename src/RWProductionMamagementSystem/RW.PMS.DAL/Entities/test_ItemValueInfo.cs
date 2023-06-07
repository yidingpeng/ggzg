namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class test_ItemValueInfo
    {
        public int ID { get; set; }

        public int? prodID { get; set; }

        public int? itemTypeID { get; set; }

        public int? itemID { get; set; }

        [StringLength(150)]
        public string standardValue { get; set; }

        [StringLength(150)]
        public string minValue { get; set; }

        [StringLength(150)]
        public string maxValue { get; set; }

        public int? ptItemStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
