namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class base_productioncalendar
    {
        public int ID { get; set; }

        public int? pcAllFlag { get; set; }

        public int? pcDeviceID { get; set; }

        public int? pcPersonID { get; set; }

        public int? pcWorkPositionID { get; set; }

        public int? pcResourceID { get; set; }

        [StringLength(50)]
        public string pcCode { get; set; }

        public DateTime? pcDate { get; set; }

        public int? pcWorkModeID { get; set; }

        [StringLength(255)]
        public string pcRemark { get; set; }
    }
}
