using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Data
{
    public class MainModel
    {
        /// <summary>
        /// 生产编号
        /// </summary>
        public string ProdNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Prod_name { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string Prod_ModelName { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public int? CarModelID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string CarModelName { get; set; }
        /// <summary>
        /// 检修类型ID
        /// </summary>
        public int? RepairTypeID { get; set; }
        /// <summary>
        /// 检修类型名称
        /// </summary>
        public string RepairTypeName { get; set; }
        /// <summary>
        /// 质量结果
        /// </summary>
        public string ResultMemo { get; set; }
        /// <summary>
        /// 检修开始时间
        /// </summary>
        public DateTime? Fm_starttime { get; set; }

        public string Fm_starttimeText
        {
            get
            {
                if (!Fm_starttime.HasValue)
                    return " ";
                return Fm_starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }


        /// <summary>
        /// 检修完成时间
        /// </summary>
        public DateTime? Fm_finishtime { get; set; }


        public string Fm_finishtimeText
        {
            get
            {
                if (!Fm_finishtime.HasValue)
                    return " ";
                return Fm_finishtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            //set
            //{
            //    DateTime dt = DateTime.MinValue;
            //    DateTime.TryParse(value, out dt);
            //    if (dt != DateTime.MinValue) Fm_finishtime = dt;
            //}
        }


        /// <summary>
        /// 计划单据号
        /// </summary>
        public string OrderCode { get; set; }
    }
}
