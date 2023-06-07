using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public class GBInfo
    {
        public int ID { get; set; }

        public int? ProgGxID { get; set; }

        /// <summary>
        /// 工步名称
        /// </summary>
        public string GBName { get; set; }

        /// <summary>
        /// 工步描述
        /// </summary>
        public string GBDesc { get; set; }

        /// <summary>
        /// 工步图片
        /// </summary>
        public byte[] GBImg { get; set; }

        public int? GBOrder { get; set; }

        public int? GBDelayTime { get; set; }

        public int? IsScan { get; set; }

        public int? IsInputPInfo { get; set; }

        public int? IsScanOrderNo { get; set; }

        public int? IsEmpCheck { get; set; }

        public int? ErrTypeID { get; set; }

        public string ErrTypeName { get; set; }

        public int? PGBInfoStatus { get; set; }

        public int? IfZhuanXu { get; set; }

        public string Remark { get; set; }

        public bool HavSubTable { get; set; }

        public string GBImage { get; set; }

        public int? ControlTypeID { get; set; }

        public string ControlTypeName { get; set; }

        public int? rowcount { get; set; }

    }
}
