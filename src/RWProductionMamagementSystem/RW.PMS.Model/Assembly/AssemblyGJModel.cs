using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public partial class AssemblyGJModel
    {
        public Guid agj_guid { get; set; }

        //public Guid? fp_guid { get; set; }

        public int? pInfo_ID { get; set; }

        public Guid? agb_guid { get; set; }

        public int? agj_gjID { get; set; }

        public string agj_gjName { get; set; }

        public int? agj_wlID { get; set; }

        public string agj_wlName { get; set; }

        public string agj_gjwlCode { get; set; }

        public int? agj_operID { get; set; }

        public string agj_oper { get; set; }

        public DateTime? agj_starttime { get; set; }

        public DateTime? agj_finishtime { get; set; }

        public int? agj_finishStatus { get; set; }

        public int? agj_resultIsOK { get; set; }

        public string agj_resultMemo { get; set; }

        public string agj_value { get; set; }

        public string agj_value2 { get; set; }

        public byte[] agj_valueImg { get; set; }

        public string agj_remark { get; set; }

        public int? agj_uploadFlag { get; set; }
    }
}
