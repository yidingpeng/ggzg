using System.Collections.Generic;

namespace RW.PMS.Model
{
    /// <summary>
    /// 工具实体类
    /// </summary>
    public partial class ProGJValModel
    {
        public ProGJValModel()
        {
            GJOPCTypes = new List<GJOPCType>();
        }
        public int ID { get; set; }
        public int? ProgGBID { get; set; }
        public int? ProgGXID { get; set; }
        public int? GJID { get; set; }
        public int? GJOrder { get; set; }
        public string GJName { get; set; }
        public int? WLID { get; set; }
        public int? WLOrder { get; set; }
        public string WLName { get; set; }
        public int? GJInfoStatus { get; set; }
        public string Remark { get; set; }

        /// <summary>
        /// 工具备注 （暂时用于扭力扳手）
        /// </summary>
        public string GJRemark { get; set; }

        /// <summary>
        /// 工具值类型名称
        /// </summary>
        public string ValueTypeName { get; set; }
        /// <summary>
        /// 值比较类型ID
        /// </summary>
        public int? EqualTypeID { get; set; }
        /// <summary>
        /// 值比较类型名称
        /// </summary>
        public string EqualTypeName { get; set; }
        /// <summary>
        /// 工具或零件类型编码
        /// </summary>
        public string GJTypeCode { get; set; }
        public int? ValID { get; set; }
        public int? ProgGjInfoID { get; set; }
        public int? ValueTypeID { get; set; }
        /// <summary>
        /// 目标值 标准值
        /// </summary>
        public string StandardValue { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public string MinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public string MaxValue { get; set; }
        /// <summary>
        /// 备注 相机长度角度点名称
        /// </summary>
        public string ValueRemark { get; set; }
        public decimal? PixelPoint { get; set; }
        public int? PVInfoStatus { get; set; }

        /// <summary>
        /// 是否可手输值
        /// </summary>
        public int? IsWriteVal { get; set; }

        /// <summary>
        /// 装配时是否要录工具编码
        /// </summary>
        public int? GJIsHasCode { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string TorqueLocalIP { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public string TorqueLocalPort { get; set; }

        public int? WLIsHasCode { get; set; }
        public byte[] GJImg { get; set; }
        public byte[] WLImg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<GJOPCType> GJOPCTypes { get; set; }
    }
}
