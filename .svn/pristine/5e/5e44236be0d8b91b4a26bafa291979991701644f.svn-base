using System;
using System.Collections.Generic;

namespace RW.PMS.Model.Assembly
{
    /// <summary>
    /// 工位装配记录表
    /// </summary>
    public class AssemblyGwModel : BaseModel
    {
        /// <summary>
        /// 主键GUID
        /// </summary>
        public Guid agw_guid { get; set; }

        /// <summary>
        /// 生产GUID
        /// </summary>
        //public Guid? fp_guid { get; set; }

        /// <summary>
        /// 产品ID,用于异常下线时方便查询追溯
        /// </summary>
        public int? Prod_id { get; set; }

        /// <summary>
        /// 产品名称,用于异常下线时方便查询追溯
        /// </summary>
        public string Prod_name { get; set; }

        /// <summary>
        /// 产品型号ID,用于异常下线时方便查询追溯
        /// </summary>
        public int? ProdModel_id { get; set; }

        /// <summary>
        /// 产品型号名称,用于异常下线时方便查询追溯
        /// </summary>
        public string ProdModel_name { get; set; }

        /// <summary>
        /// 程序ID,用于异常下线时方便查询追溯
        /// </summary>
        public int? agw_prog_id { get; set; }

        /// <summary>
        /// 程序名称,用于异常下线时方便查询追溯
        /// </summary>
        public string agw_prog_name { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int? agw_gwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string agw_gwName { get; set; }

        /// <summary>
        /// 工位二维码
        /// </summary>
        public string agw_QRcode { get; set; }

        /// <summary>
        /// 操作员Id
        /// </summary>
        public int? agw_operID { get; set; }

        /// <summary>
        /// 操作员姓名
        /// </summary>
        public string agw_oper { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? agw_starttime { get; set; }

        /// <summary>
        /// 规定时长
        /// </summary>
        public int? duration { get; set; }

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
        /// 完成时间
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
        /// 工位完成状态：0：未完成，1：已完成，2：异常下线，3：重新装配 4：返回上一步; 5:例外转序
        /// </summary>
        public int? agw_finishStatus { get; set; }

        /// <summary>
        /// 工位完成状态：0：未完成，1：已完成，2：异常下线，3：重新装配 4：返回上一步; 5:例外转序
        /// </summary>
        public string Fgw_finishStatusS { get {
            if (agw_finishStatus==0)
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
                return "列外转序";
            return "";
        } }


        /// <summary>
        /// 质量结果
        /// </summary>
        public int? agw_resultIsOK { get; set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string agw_resultMemo { get; set; }

        /// <summary>
        /// 工位结果值(扭力值/喷油量/角度)
        /// </summary>
        public string Fgw_value { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string agw_remark { get; set; }

        /// <summary>
        /// 产品信息ID
        /// </summary>
        public int? pInfo_ID { get; set; }

        /// <summary>
        /// 上传标志
        /// </summary>
        public int? agw_uploadFlag { get; set; }


        /// <summary>
        /// 参数:产品编号
        /// </summary>
        public string prod_no { get; set; }

        /// <summary>
        /// 参数:订单号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string starttime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string endtime { get; set; }


        /// <summary>
        /// 开始时间1
        /// </summary>
        public string starttime1 { get; set; }

        /// <summary>
        /// 结束时间2
        /// </summary>
        public string endtime1 { get; set; }


        public string pp_orderCode { get; set; }


        /// <summary>
        /// 压装数据
        /// </summary>
        public string agb_value { get; set; }

        /// <summary>
        /// 工步GUID
        /// </summary>
        public Guid agb_guid { get; set; }

        /// <summary>
        ///  产品GUID
        /// </summary>
        public Guid am_guid { get; set; }

        public List<AssemblyMainRecordModel> Details { get; set; }
    }
}
