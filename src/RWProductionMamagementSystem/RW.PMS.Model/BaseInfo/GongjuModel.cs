using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.BaseInfo
{
    public class GongjuModel : BaseModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string Gjname { get; set; }
        /// <summary>
        /// 工具图片
        /// </summary>
        public byte[] GjImg { get; set; }
        /// <summary>
        /// 是否删除图片
        /// </summary>
        public bool DelPhoto { get; set; }
        /// <summary>
        /// 工具类型
        /// </summary>
        public int? GjTypeID { get; set; }
        /// <summary>
        /// 工具类型名称
        /// </summary>
        public string GjTypeName { get; set; }
        /// <summary>
        /// 装配时是否要录工具编码
        /// </summary>
        public int? GjIsHasCode { get; set; }
        /// <summary>
        /// 装配时是否要录工具编码的bool值
        /// </summary>
        public bool BoolIsHasCode { get; set; }
        /// <summary>
        /// 装配时是否要录工具编码文本值
        /// </summary>
        public string IsHasCodeStatus { get {
            if (GjIsHasCode == 0)
                return "否";
            return "是";
        
        } }

        /// <summary>
        /// IP地址
        /// </summary>
        public string TorqueLocalIP { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public string TorqueLocalPort { get; set; }

        /// <summary>
        /// 使用状态
        /// </summary>
        public int? GjStatus { get; set; }
        /// <summary>
        /// 使用状态文本值
        /// </summary>
        public string Status { get; set; }
        //备注
        public string Remark { get; set; }

    }
}
