namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_prodLjCheckTip
    {
        public int id { get; set; }

        public int? prodLjDefId { get; set; }

        public string tipMemo { get; set; }

        [Column(TypeName = "image")]
        public byte[] picture { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
