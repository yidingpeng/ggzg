using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Assembly
{
    public partial class ProductModelModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int PmodelID { get; set; }
        /// <summary>
        /// 产品ID
        /// </summary>
        public int? prodID { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string PName { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get; set; }
    }
}
