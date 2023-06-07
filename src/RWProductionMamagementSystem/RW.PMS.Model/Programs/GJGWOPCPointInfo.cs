using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public partial class GJGWOPCPointInfo
    {
        public int? gjID { get; set; }

        public int? wlID { get; set; }

        public string opcDeviceName { get; set; }

        public int? opcTypeID { get; set; }

        public string opcTypeCode { get; set; }

        public string opcValue { get; set; }
    }
}
