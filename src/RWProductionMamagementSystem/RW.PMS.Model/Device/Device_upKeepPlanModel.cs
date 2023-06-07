using System;

namespace RW.PMS.Model.Device
{
    public class Device_upKeepPlanModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// ID
        /// </summary>
        public int ID1 { get; set; }
        /// <summary>
        /// 设备ID
        /// </summary>
        public int? DevID { get; set; }

        /// <summary>
        /// 设备名称 外键
        /// </summary>
        public string DevName { get; set; }

        /// <summary>
        /// 保养时间
        /// </summary>
        public DateTime? ExecDate { get; set; }

        public string ExecDateText
        {
            get
            {
                if (ExecDate.HasValue)
                    return ExecDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                return "";
            }
        }

        /// <summary>
        /// 保养执行人
        /// </summary>
        public int? ExecEmp { get; set; }

        /// <summary>
        /// 保养执行人名称
        /// </summary>
        public string ExecEmpName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 设备卡号
        /// </summary>
        public string DevCardno { get; set; }

        /// <summary>
        /// 设备编码
        /// </summary>
        public string DevNo { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        public int detailid { get; set; }


        /// <summary>
        /// 保养描述
        /// </summary>
        public string uddesc { get; set; }

        /// <summary>
        /// 保养图片
        /// </summary>
        public byte[] udimg { get; set; }


    }
}
