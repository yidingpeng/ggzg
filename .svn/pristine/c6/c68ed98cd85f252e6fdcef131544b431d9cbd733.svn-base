using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 产品信息表
    /// </summary>
    public class BaseProductModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Pname { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? Pstatus { get; set; }

        public string status
        {
            get
            {
                if (Pstatus != 0)
                {
                    return "禁用";
                }
                return "启用";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
