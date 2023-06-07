namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_menu()
        {
            sys_menu_auth = new HashSet<sys_menu_auth>();
        }

        [Key]
        public int menuID { get; set; }

        [StringLength(150)]
        public string menuName { get; set; }

        public int? parentID { get; set; }

        [StringLength(150)]
        public string atWhere { get; set; }

        public int? sort { get; set; }

        //[StringLength(150)]
        //public string useButton { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        public int? isShow { get; set; }

        [StringLength(50)]
        public string flag { get; set; }

        public DateTime? createtime { get; set; }

        [StringLength(50)]
        public string createBy { get; set; }

        public DateTime? updatetime { get; set; }

        [StringLength(50)]
        public string updateBy { get; set; }

        [StringLength(255)]
        public string remark { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_menu_auth> sys_menu_auth { get; set; }
    }
}
