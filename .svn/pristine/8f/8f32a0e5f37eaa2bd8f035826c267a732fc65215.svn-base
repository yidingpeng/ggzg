//using RW.PMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Assembly
{
    public class AssemblyProdModel : BaseModel
    {
        /// <summary>
        /// 生产GUID
        /// </summary>
        public Guid Fp_guid { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? Prod_id { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string Prod_name { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? ProdModel_id { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string ProdModel_name { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string Prod_no { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string CarModel { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }

        /// <summary>
        /// 产品订单号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? Fp_startTime { get; set; }



        public string Fp_startTimeText
        {
            get
            {
                if (Fp_startTime == null)
                    return "";
                return Fp_startTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) Fp_startTime = dt;
            }
        }

        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? Fp_finishTime { get; set; }


        public string Fp_finishTimeText
        {
            get
            {
                if (Fp_finishTime == null)
                    return "";
                return Fp_finishTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) Fp_finishTime = dt;
            }
        }

        /// <summary>
        /// 产品完成状态：0：未完成，1：已完成，2：异常下线，3：重新装配 4：返回上一步; 5:例外转序
        /// </summary>
        public int? Fp_finishStatus { get; set; }

        /// <summary>
        /// 产品完成状态名称：0：未完成，1：已完成，2：异常下线，3：重新装配 4：返回上一步; 5:例外转序
        /// </summary>
        public string Fp_finishStatusS
        {
            get
            {
                if (Fp_finishStatus == 0)
                    return "未完成";
                if (Fp_finishStatus == 1)
                    return "已完成";
                if (Fp_finishStatus == 2)
                    return "异常下线";
                if (Fp_finishStatus == 3)
                    return "重新装配";
                if (Fp_finishStatus == 4)
                    return "返回上一步";
                if (Fp_finishStatus == 5)
                    return "列外转序";
                return "";
            }
        }

        /// <summary>
        /// 质量结果
        /// </summary>
        public int? Fp_resultIsOK { get; set; }

        /// <summary>
        /// 结果说明
        /// </summary>
        public string Fp_resultMemo { get; set; }

        /// <summary>
        /// 产品结果值(扭力值/喷油量/角度)
        /// </summary>
        public string Fp_value { get; set; }

        /// <summary>
        /// 产品生产线完成情况报表存放路径
        /// </summary>
        public byte[] Fp_report { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Fp_remark { get; set; }

        /// <summary>
        /// 上传标志
        /// </summary>
        public int? Fp_uploadFlag { get; set; }

        /// <summary>
        /// 重新组装的原二维码
        /// </summary>
        public string Fp_QRcode_old { get; set; }



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



    }
}
