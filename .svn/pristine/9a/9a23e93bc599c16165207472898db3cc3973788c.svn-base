using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
   public class GJInfo
   {
       public GJInfo()
       {
           GJOPCTypes = new List<GJOPCType>();
       }
       public int ID { get; set; }

       public int? ProgGbInfoID { get; set; }

       public int? GJID { get; set; }

       public string GJName { get; set; }

       public int? GJOrder { get; set; }

       public int? WLID { get; set; }

       public string WLName { get; set; }

       public int? WLOrder { get; set; }

       public string OPCDeviceName { get; set; }

       //public string GJWLGet { get; set; }

       //public string GJWLPut { get; set; }

       //public string GJGreen { get; set; }

       //public string GjRed { get; set; }

       //public string GjYellow { get; set; }

       //public string CameraAngelTag { get; set; }

       //public string CameraLongTag { get; set; }

       //public string CameraLongTag2 { get; set; }

       //public string CameraTemplateNo { get; set; }

       //public string CameraTemplateTag_write { get; set; }

       //public string CameraTemplateTag_writeChangeTag { get; set; }

       //public string CameraTemplateTag_read { get; set; }

       public int? PGJInfoStatus { get; set; }

       public string Remark { get; set; }

       public string GJImage { get; set; }

       public bool HavSubTable { get; set; }

       public IEnumerable<GJOPCType> GJOPCTypes { get; set; }

       public int? rowcount { get; set; }

   }

   public class GJOPCType
   {
       public string Code { get; set; }
       public string Name { get; set; }
       public string Value { get; set; }
       public string OPCDeviceName { get; set; }
       public int? progGjInfoID { get; set; }
   }
}
