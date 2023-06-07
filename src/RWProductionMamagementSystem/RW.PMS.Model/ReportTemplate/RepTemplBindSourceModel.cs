using System;
using System.Collections.Generic;

namespace RW.PMS.Model
{

    /// <summary>
    /// 报表模板绑定数据源
    /// </summary>
    public partial class RepTemplBindSourceModel
    {
        public int ID { get; set; }
        public int PModelID { get; set; }
        public string Pmodel { get; set; }
        public int ITypeID { get; set; }
        public string ITypeName { get; set; }
        public string ItemName { get; set; }
        public int OrderNo { get; set; }
        public string BindValue { get; set; }
        public string BindType { get; set; }
        public string DefaultValue { get; set; }
        public string Remark { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }

   
}