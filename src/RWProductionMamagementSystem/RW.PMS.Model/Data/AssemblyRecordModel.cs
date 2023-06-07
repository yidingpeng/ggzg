using System;

namespace RW.PMS.Model.Data
{
    /// <summary>
    /// 装配记录报告
    /// </summary>
    public class AssemblyRecordModel
    {
        /// <summary>
        /// 产品信息表ID
        /// </summary>
        public int? pf_ID { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string pf_prodNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Pname { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? AreaId { get; set; }
        /// <summary>
        /// 区域姓名
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? agw_gwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string agw_gwName { get; set; }
        /// <summary>
        /// 二维码
        /// </summary>
        public string agw_QRcode { get; set; }
        /// <summary>
        /// 操作者
        /// </summary>
        public string agw_oper { get; set; }
        /// <summary>
        /// 工位记录开始时间
        /// </summary>
        public DateTime? agw_starttime { get; set; }
        /// <summary>
        /// 工位记录开始时间显示值
        /// </summary>
        public string gwstartDate
        {
            get
            {
                if (!agw_starttime.HasValue)
                    return "";
                return agw_starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 工位记录结束时间
        /// </summary>
        public DateTime? agw_finishtime { get; set; }
        /// <summary>
        /// 工位记录结束时间显示值
        /// </summary>
        public string gwfinishDate
        {
            get
            {
                if (!agw_finishtime.HasValue)
                    return "";
                return agw_finishtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 工序ID
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
        /// 工序开始时间显示值
        /// </summary>
        public string gxstarttime
        {
            get
            {
                if (!agx_starttime.HasValue)
                    return "";
                return agx_starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 工序结束时间
        /// </summary>
        public DateTime? agx_finishtime { get; set; }
        /// <summary>
        /// 工序结束时间显示值
        /// </summary>
        public string gxfinishtime
        {
            get
            {
                if (!agx_finishtime.HasValue)
                    return "";
                return agx_finishtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 工序开始结束时间差（S）
        /// </summary>
        public string gxtimediff
        {
            get
            {
                if (agx_starttime.HasValue && agx_finishtime.HasValue)
                {
                    double db = (agx_finishtime.Value - agx_starttime.Value).TotalSeconds;
                    if (db > 0)
                        return db + "秒";
                }
                return "";
            }
        }
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
        /// 工步开始时间显示值
        /// </summary>
        public string gbstarttime
        {
            get
            {
                if (!agb_starttime.HasValue)
                    return "";
                return agb_starttime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 工步结束时间
        /// </summary>
        public DateTime? agb_finishtime { get; set; }
        /// <summary>
        /// 工步结束时间显示值
        /// </summary>
        public string gbfinishtime
        {
            get
            {
                if (!agb_finishtime.HasValue)
                    return "";
                return agb_finishtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        /// <summary>
        /// 工步开始结束时间差
        /// </summary>
        public string gbtimediff
        {
            get
            {
                if (agb_starttime.HasValue && agb_finishtime.HasValue)
                {
                    double db = (agb_finishtime.Value - agb_starttime.Value).TotalSeconds;
                    if (db > 0)
                        return db + "秒";
                }
                return "";
            }
        }
        /// <summary>
        /// 工具ID
        /// </summary>
        public int? agj_gjID { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string agj_gjName { get; set; }
        /// <summary>
        /// 物料ID
        /// </summary>
        public int? agj_wlID { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string agj_wlName { get; set; }
        /// <summary>
        /// 工具/物料值
        /// </summary>
        public string agj_value { get; set; }



        public string pp_orderCode { get; set; }
    }
}