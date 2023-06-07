using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    /// 生产记录报告模板
    /// </summary>
    public partial class RepTemplateModel
    {
        public int ID { get; set; }
        public int PModelID { get; set; }
        public string PModel { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public byte[] FileValue { get; set; }
        public bool Enabled { get; set; }
        public bool havFile { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Remark { get; set; }
        public int HavSource { get; set; }
        //public int HavPartsReplacement { get; set; }
    }
}
