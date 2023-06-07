namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_menu_auth
    {
        public int ID { get; set; }

        public int menuID { get; set; }

        public int authID { get; set; }

        public virtual sys_auth sys_auth { get; set; }

        public virtual sys_menu sys_menu { get; set; }
    }
}
