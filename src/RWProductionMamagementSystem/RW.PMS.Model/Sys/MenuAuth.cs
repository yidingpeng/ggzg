using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Sys
{
    /// <summary>
    /// 权限表
    /// </summary>
    public partial class MenuAuth
    {
        public int ID { get; set; }

        public string authName { get; set; }

        public long authValue { get; set; }

        public string authType { get; set; }

        public int? menuID { get; set; }
    }
}
