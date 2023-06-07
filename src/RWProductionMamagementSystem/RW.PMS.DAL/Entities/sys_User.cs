namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_User
    {
        [Key]
        public int userID { get; set; }

        [StringLength(150)]
        public string userName { get; set; }

        [StringLength(150)]
        public string pwd { get; set; }

        [StringLength(100)]
        public string empNo { get; set; }

        [StringLength(150)]
        public string empName { get; set; }

        public int? roleID { get; set; }

        public int? deptID { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        public int? sex { get; set; }

        public DateTime? registtime { get; set; }

        public int? inStatus { get; set; }

        [StringLength(100)]
        public string cardNo { get; set; }

        [Column(TypeName = "image")]
        public byte[] headPortrait { get; set; }

        [StringLength(255)]
        public string remark { get; set; }

        public int? deleted { get; set; }
    }
}
