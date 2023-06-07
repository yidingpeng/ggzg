using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RW.PMS.DAL
{
    public partial class base_wuliao
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string wlcode { get; set; }

        [StringLength(150)]
        public string wlname { get; set; }

        public int? wlTypeID { get; set; }

        [StringLength(50)]
        public string wlClass { get; set; }

        [Column(TypeName = "image")]
        public byte[] wlImg { get; set; }

        public int? wlIsHasCode { get; set; }

        public int? wlStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
