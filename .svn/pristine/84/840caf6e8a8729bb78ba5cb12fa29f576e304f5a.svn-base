using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Assembly
{
    public class AssemblyRecordModel
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public string pf_prodNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string prod_name { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string prodModel_name { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? agw_gwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string agw_gwName { get; set; }
        /// <summary>
        /// 工位操作员
        /// </summary>
        public string agw_oper { get; set; }
        /// <summary>
        /// 工位开始时间
        /// </summary>
        public DateTime? agw_starttime { get; set; }
        /// <summary>
        /// 工位完成时间
        /// </summary>
        public DateTime? agw_finishtime { get; set; }
        /// <summary>
        /// 工位完成状态
        /// </summary>
        public int? agw_finishStatus { get; set; }

        public string agw_finishStatusText { get {
            if (agw_finishStatus==1)
            {
                return "完成";
            }
            return "未完成";
        } }
        /// <summary>
        /// 工位质量结果
        /// </summary>
        public string agw_resultMemo { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string agx_gxName { get; set; }
        /// <summary>
        /// 工序开始时间
        /// </summary>
        public DateTime? agx_starttime { get; set; }
        /// <summary>
        /// 工序完成时间
        /// </summary>
        public DateTime? agx_finishtime { get; set; }
        /// <summary>
        /// 工序完成状态
        /// </summary>
        public int? agx_finishStatus { get; set; }
        public string agx_finishStatusText
        {
            get
            {
                if (agx_finishStatus == 1)
                {
                    return "完成";
                }
                return "未完成";
            }
        }
        /// <summary>
        /// 工序质量结果
        /// </summary>
        public string agx_resultMemo { get; set; }
        /// <summary>
        /// 工步名称
        /// </summary>
        public string agb_gbName { get; set; }
        /// <summary>
        /// 工步开始时间
        /// </summary>
        public DateTime? agb_starttime { get; set; }
        /// <summary>
        /// 工步完成时间
        /// </summary>
        public DateTime? agb_finishtime { get; set; }
        /// <summary>
        /// 工步完成状态
        /// </summary>
        public int? agb_finishStatus { get; set; }
        public string agb_finishStatusText
        {
            get
            {
                if (agb_finishStatus == 1)
                {
                    return "完成";
                }
                return "未完成";
            }
        }
        /// <summary>
        /// 工步质量结果
        /// </summary>
        public string agb_resultMemo { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string agj_gjName { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string agj_wlName { get; set; }
        /// <summary>
        /// 工具物料开始时间
        /// </summary>
        public DateTime? agj_starttime { get; set; }
        /// <summary>
        /// 工具物料完成时间
        /// </summary>
        public DateTime? agj_finishtime { get; set; }
        /// <summary>
        /// 工具物料完成状态
        /// </summary>
        public int? agj_finishStatus { get; set; }
        public string agj_finishStatusText
        {
            get
            {
                if (agj_finishStatus == 1)
                {
                    return "完成";
                }
                return "未完成";
            }
        }
        /// <summary>
        /// 工具物料质量结果
        /// </summary>
        public string agj_resultMemo { get; set; }
        /// <summary>
        /// 工具结果值
        /// </summary>
        public string agj_value { get; set; }
        /// <summary>
        /// 工装编码
        /// </summary>
        public string agj_gjwlCode { get; set; }
    }
}
