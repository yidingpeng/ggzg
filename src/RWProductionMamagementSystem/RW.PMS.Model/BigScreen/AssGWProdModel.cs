using RW.PMS.Model.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BigScreen
{
    /// <summary>
    /// 大屏总装工位生产信息
    /// </summary>
    public partial class AssGWProdModel
    {
       /// <summary>
       /// 生产记录
       /// </summary>
        public List<AssGWProdRecordModel> Records { get; set; }

        /// <summary>
        /// 总装工位信息
        /// </summary>
        public List<BaseGongweiModel> GWModels { get; set; }
    }
}
