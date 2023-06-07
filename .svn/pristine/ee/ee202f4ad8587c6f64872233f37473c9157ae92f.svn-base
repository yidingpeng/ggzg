namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_tempArea
    {

        public int ta_ID { get; set; }

        [StringLength(50)]
        public string ta_areaCode { get; set; }

        public int? ta_areaID { get; set; }

        public int? ta_groupIndex { get; set; }

        public int? ta_rowIndex { get; set; }

        public int? ta_colIndex { get; set; }

        [StringLength(50)]
        public string ta_defaultColor { get; set; }

        [StringLength(50)]
        public string ta_stayPutColor { get; set; }

        [StringLength(50)]
        public string ta_inPutColor { get; set; }

        public Guid ta_curFmGuid { get; set; }

        public string ta_curSysProdNo { get; set; }

        public int? ta_status { get; set; }

        [StringLength(255)]
        public string remark { get; set; }


    }
}
