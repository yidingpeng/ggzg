using RW.PMS.Model.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public class Program
    {/// <summary>
        /// gw_prod_def表id   2019/05/17
        /// </summary>
        public int? gw_prod_defId { get; set; }
        /// <summary>
        /// 型号id   2019/05/15
        /// </summary>
        public int? PmodelId { get; set; }
        /// <summary>
        /// 型号   //加一列型号2019/05/14
        /// </summary>
        public string Pmodel { get; set; }
        public int ID { get; set; }

        public int GWID { get; set; }

        public string ProgName { get; set; }

        public string GWName { get; set; }

        public string FileNo { get; set; }

        public DateTime? StartTime { get; set; }

        public string CopyRight { get; set; }

        public string Descript { get; set; }

        public int? ProgStatus { get; set; }

        public string Remark { get; set; }

        public bool HavSubTable { get; set; }

        public IEnumerable<ProdDefModel> GetProdDefModel { get; set; }
    }

    /// <summary>
    /// 产品型号关联配置
    /// </summary>
    public class ProdDefModel 
    {
             
        ///// <summary>
        ///// 编号
        ///// </summary>
        //public int ID { get; set; }
        ///// <summary>
        ///// 产品型号ID
        ///// </summary>
        //public int? ProdModelID { get; set; }
        ///// <summary>
        ///// 产品型号名称
        ///// </summary>
        //public string ProdModelName { get; set; }

        //public int? PID { get; set; }

        //public string PName { get; set; }


        /// <summary>
        /// 编号
        /// </summary>
        public int gw_prod_defId { get; set; }
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? PmodelId { get; set; }
        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string Pmodel { get; set; }

        public int? PID { get; set; }

        public string PName { get; set; }
    }

}
