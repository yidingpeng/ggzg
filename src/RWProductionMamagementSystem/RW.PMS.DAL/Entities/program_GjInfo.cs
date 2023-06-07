namespace RW.PMS.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class program_GjInfo
    {
        public int ID { get; set; }

        public int? progGbInfoID { get; set; }

        public int? gjID { get; set; }

        public int? gjOrder { get; set; }

        public int? wlID { get; set; }

        public int? wlOrder { get; set; }

        [StringLength(150)]
        public string opcDeviceName { get; set; }

        //[StringLength(150)]
        //public string gjRed { get; set; }

        //[StringLength(150)]
        //public string gjGreen { get; set; }

        //[StringLength(150)]
        //public string gjYellow { get; set; }

        //[StringLength(150)]
        //public string gjwlGet { get; set; }

        //[StringLength(150)]
        //public string gjwlPut { get; set; }

        //[StringLength(150)]
        //public string cameraAngelTag { get; set; }

        //[StringLength(150)]
        //public string cameraLongTag { get; set; }

        //[StringLength(150)]
        //public string cameraLongTag2 { get; set; }

        //[StringLength(150)]
        //public string cameraTemplateNo { get; set; }

        //[StringLength(150)]
        //public string cameraTemplateTag_write { get; set; }

        //[StringLength(150)]
        //public string cameraTemplateTag_writeChangeTag { get; set; }

        //[StringLength(150)]
        //public string cameraTemplateTag_read { get; set; }

        public int? pgjInfoStatus { get; set; }

        [StringLength(255)]
        public string remark { get; set; }
    }
}
