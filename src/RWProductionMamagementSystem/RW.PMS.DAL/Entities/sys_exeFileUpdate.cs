namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_exeFileUpdate
    {
        [Key]
        public int fID { get; set; }

        [StringLength(100)]
        public string filesName { get; set; }

        [StringLength(100)]
        public string fileType { get; set; }

        [StringLength(100)]
        public string versionNuber { get; set; }

        public DateTime? uploadTime { get; set; }

        [StringLength(255)]
        public string filePath { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
