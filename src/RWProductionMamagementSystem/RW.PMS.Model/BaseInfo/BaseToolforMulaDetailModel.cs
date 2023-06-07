using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseToolforMulaDetailModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 工具参数配方主表ID
        /// </summary>
        public int tfmID { get; set; }
        /// <summary>
        /// 仪器试验类型
        /// </summary>
        public string TestTypeName { get; set; }
        /// <summary>
        /// 仪器试验项点
        /// </summary>
        public string TestItemName { get; set; }
        /// <summary>
        /// 项点类型 比如：电流、电压、电阻、电阻温度
        /// </summary>
        public int? tfmdItemType { get; set; }
        /// <summary>
        /// 项点类型名称
        /// </summary>
        public string ItemTypeName { get; set; }
        /// <summary>
        /// 项点名称
        /// </summary>
        public string tfmdName { get; set; }
        /// <summary>
        /// 项点值
        /// </summary>
        public string tfmdItemValue { get; set; }
        /// <summary>
        /// 最小值
        /// </summary>
        public string tfmdMinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        public string tfmdMaxValue { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string tfmdRemark { get; set; }


    }
}
