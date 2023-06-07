using System;
using System.ComponentModel.DataAnnotations;

namespace RW.PMS.DAL
{
    public partial class productInfo
    {
        [Key]
        public int pf_ID { get; set; }

        [StringLength(50)]
        public string pf_prodNo { get; set; }

        public int pf_prodID { get; set; }

        public int? pf_prodModelID { get; set; }

        public int? pf_carModelID { get; set; }

        [StringLength(50)]
        public string pf_carNo { get; set; }

        [StringLength(150)]
        public string pf_orderNo { get; set; }

        [StringLength(50)]
        public string pf_groupNo { get; set; }

        public int? pf_factoryID { get; set; }

        [StringLength(50)]
        public string pf_stampNo { get; set; }

        public DateTime? pf_date { get; set; }

        [StringLength(50)]
        public string pf_weight { get; set; }

        [StringLength(50)]
        public string pf_compressor { get; set; }

        [StringLength(50)]
        public string pf_compartNo { get; set; }

        [StringLength(50)]
        public string pf_bogieNo { get; set; }
        public int? pf_cacheFlag { get; set; }
        public int? pf_metroLineID { get; set; }
        [StringLength(50)]
        public string pf_remark { get; set; }
        public int? pf_DeleteFlag { get; set; }
        public DateTime? pf_CreateTime { get; set; }
        public DateTime? pf_UpdateTime { get; set; }
        public int? pf_CreateMan { get; set; }
        public int? pf_UpdateMan { get; set; }
    }
}
