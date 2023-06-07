using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseUserGroupModel : BaseModel
    {
     
        public BaseUserGroupModel()
        {
            ugDetail = new List<BaseUserGroupDetailModel>();
        }
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 用户组名
        /// </summary>
        public string ugGroupName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ugRemark { get; set; }
        /// <summary>
        /// 禁用标识
        /// </summary>
        public int? ugDisableFlag { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? ugDeleteFlag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? ugCreateTime { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? ugCreaterID { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? ugUpdateTime { get; set; }
        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? ugUpdaterID { get; set; }

        /// <summary>
        /// 禁用标识文本值
        /// </summary>
        public string IsDisableFlag { get; set; }

        /// <summary>
        /// 用来接收明细表的json
        /// </summary>
        public string JSONDetailList { get; set; }

        /// <summary>
        /// 用户组明细
        /// </summary>
        public List<BaseUserGroupDetailModel> ugDetail { get; set; }

    }
}
