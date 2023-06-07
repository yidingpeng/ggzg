using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public class WlBatchResultModel
    {

        /// <summary>
        /// 成功与否 布尔
        /// </summary>
        public bool IsOK { get; set; }

        /// <summary>
        /// 如果返回0代表库存中不存在该物料
        /// </summary>
        public string wlNameStr { get; set; }

        /// <summary>
        /// 如果返回-1代表当前物料在库存中存在但是实际数量<=0需提醒用户
        /// </summary>
        public string UnwlNameStr { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string Message { get; set; }


    }
}
