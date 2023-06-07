using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseToolforMulaModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 工具ID
        /// </summary>
        public int? tfmToolID { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string ToolName { get; set; }
        /// <summary>
        /// 工具类型ID 取数据字典
        /// </summary>
        public int? tfmToolTypeID { get; set; }
        /// <summary>
        /// 工具类型名称
        /// </summary>
        public string ToolTypeName { get; set; }
        /// <summary>
        /// 仪器试验类型
        /// </summary>
        public int? tfmTestTypeID { get; set; }
        /// <summary>
        /// 仪器试验类型名称
        /// </summary>
        public string TestTypeName { get; set; }
        /// <summary>
        /// 仪器试验项点
        /// </summary>
        public int? tfmTestItemID { get; set; }
        /// <summary>
        /// 仪器试验项点名称
        /// </summary>
        public string TestItemName { get; set; }
        /// <summary>
        /// 配方编码
        /// </summary>
        public string tfmCode { get; set; }
        /// <summary>
        /// 配方名称
        /// </summary>
        public string tfmName { get; set; }
        /// <summary>
        /// 禁用标识
        /// </summary>
        public int? tfmDisableFlag { get; set; }
        /// <summary>
        /// 禁用标识文本值
        /// </summary>
        public string DisableFlagText
        {
            get
            {
                if (tfmDisableFlag == 0)
                    return "启用";
                else if (tfmDisableFlag == 1)
                    return "禁用";
                else
                    return "";
            }
        }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? tfmDeleteFlag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? tfmCreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public int? tfmCreaterID { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? tfmUpdateTime { get; set; }
        /// <summary>
        /// 最后修改者
        /// </summary>
        public int? tfmUpdaterID { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string tfmRemark { get; set; }

    }
}
