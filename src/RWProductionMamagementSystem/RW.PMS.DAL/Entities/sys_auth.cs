namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_auth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_auth()
        {
            sys_menu_auth = new HashSet<sys_menu_auth>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string authName { get; set; }

        public long authValue { get; set; }

        [StringLength(50)]
        public string authType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_menu_auth> sys_menu_auth { get; set; }
    }
}
