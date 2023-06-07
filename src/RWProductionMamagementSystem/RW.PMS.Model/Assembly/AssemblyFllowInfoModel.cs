using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Assembly
{
    public class AssemblyFllowInfoModel : BaseModel
    {

        /// <summary>
        /// 产品编号
        /// </summary>
        public string pf_prodNo { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? pf_prodModelID { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string prodModeName { get; set; }
        /// <summary>
        /// 工位二维码
        /// </summary>
        public string agw_QRcode { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? agw_gwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string agw_gwName { get; set; }
        /// <summary>
        /// 工位开始时间
        /// </summary>
        public DateTime? agw_starttime { get; set; }

        public string agw_starttimeText
        {
            get
            {
                if (agw_starttime == null)
                    return "";
                return agw_starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) agw_starttime = dt;
            }
        }


        /// <summary>
        /// 工位结束时间
        /// </summary>
        public DateTime? agw_finishtime { get; set; }


        public string agw_finishtimeText
        {
            get
            {
                if (agw_finishtime == null)
                    return "";
                return agw_finishtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) agw_finishtime = dt;
            }
        }


        /// <summary>
        /// 工位操作人员
        /// </summary>
        public int? agw_operID { get; set; }
        /// <summary>
        /// 工位操作人员
        /// </summary>
        public string agw_oper { get; set; }
        /// <summary>
        /// 工位结果
        /// </summary>
        public string agw_resultMemo { get; set; }
        /// <summary>
        /// 工位装配状态
        /// </summary>
        public int? agw_finishStatus { get; set; }
        /// <summary>
        /// 装配状态文本
        /// </summary>
        public string agw_finishStatusText
        {
            get
            {
                if (agw_finishStatus == 0)
                    return "未完成";
                if (agw_finishStatus == 1)
                    return "已完成";
                if (agw_finishStatus == 2)
                    return "异常下线";
                if (agw_finishStatus == 3)
                    return "重新装配";
                if (agw_finishStatus == 4)
                    return "返回上一步";
                if (agw_finishStatus == 5)
                    return "例外转序";
                return "";
            }
        }

        /// <summary>
        /// 工序状态
        /// </summary>
        public int? agx_gxID { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string agx_gxName { get; set; }
        /// <summary>
        /// 工序开始时间
        /// </summary>
        public DateTime? agx_starttime { get; set; }
        /// <summary>
        /// 工序结束时间
        /// </summary>
        public DateTime? agx_finishtime { get; set; }
        /// <summary>
        /// 工序装配状态
        /// </summary>
        public int? agx_finishStatus { get; set; }

        /// <summary>
        /// 工序装配状态文本
        /// </summary>
        public string agx_finishStatusText
        {
            get
            {
                if (agx_finishStatus == 0)
                    return "未完成";
                if (agx_finishStatus == 1)
                    return "已完成";
                if (agx_finishStatus == 2)
                    return "异常下线";
                if (agx_finishStatus == 3)
                    return "重新装配";
                if (agx_finishStatus == 4)
                    return "返回上一步";
                if (agx_finishStatus == 5)
                    return "例外转序";
                return "";
            }
        }
        /// <summary>
        /// 工序结果
        /// </summary>
        public string agx_resultMemo { get; set; }
        /// <summary>
        /// 工步ID
        /// </summary>
        public int? agb_gbID { get; set; }

        /// <summary>
        /// 工步名称
        /// </summary>
        public string agb_gbName { get; set; }

        /// <summary>
        /// 工步开始时间
        /// </summary>
        public DateTime? agb_starttime { get; set; }
        /// <summary>
        /// 工步结束时间
        /// </summary>
        public DateTime? agb_finishtime { get; set; }
        /// <summary>
        /// 工步状态
        /// </summary>
        public int? agb_finishStatus { get; set; }
        /// <summary>
        /// 工步状态文本
        /// </summary>
        public string agb_finishStatusText
        {
            get
            {
                if (agb_finishStatus == 0)
                    return "未完成";
                if (agb_finishStatus == 1)
                    return "已完成";
                if (agb_finishStatus == 2)
                    return "异常下线";
                if (agb_finishStatus == 3)
                    return "重新装配";
                if (agb_finishStatus == 4)
                    return "返回上一步";
                if (agb_finishStatus == 5)
                    return "例外转序";
                return "";
            }
        }
        /// <summary>
        /// 工步结果值
        /// </summary>
        public string agb_resultMemo { get; set; }
        /// <summary>
        /// 工具ID
        /// </summary>
        public int? agj_gjID { get; set; }
        /// <summary>
        ///工具名称
        /// </summary>
        public string agj_gjName { get; set; }
        /// <summary>
        /// 物料ID
        /// </summary>
        public int? agj_wlID { get; set; }
        /// <summary>
        ///物料名称
        /// </summary>
        public string agj_wlName { get; set; }
        /// <summary>
        /// 工位二维码
        /// </summary>
        public string agj_gjwlCode { get; set; }
        /// <summary>
        /// 工具开始时间
        /// </summary>
        public DateTime? agj_starttime { get; set; }
        /// <summary>
        /// 工具结束时间
        /// </summary>
        public DateTime? agj_finishtime { get; set; }
        /// <summary>
        /// 工具状态
        /// </summary>
        public int? agj_finishStatus { get; set; }
        /// <summary>
        /// 工步状态文本
        /// </summary>
        public string agj_finishStatusText
        {
            get
            {
                if (agj_finishStatus == 0)
                    return "未完成";
                if (agj_finishStatus == 1)
                    return "已完成";
                if (agj_finishStatus == 2)
                    return "异常下线";
                if (agj_finishStatus == 3)
                    return "重新装配";
                if (agj_finishStatus == 4)
                    return "返回上一步";
                if (agj_finishStatus == 5)
                    return "例外转序";
                return "";
            }
        }
        /// <summary>
        /// 工具结果
        /// </summary>
        public string agj_resultMemo { get; set; }
        /// <summary>
        /// 工具结果值
        /// </summary>
        public string agj_value { get; set; }
        /// <summary>
        /// 工具结果值2
        /// </summary>
        public string agj_value2 { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string starttime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endtime { get; set; }

    }
}
