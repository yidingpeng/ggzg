using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public class ResponseResult<T>
    {

        /// <summary>
        /// 返回不存在的物料字符串
        /// </summary>
        public string[] inexistenceMsg { get; set; }

        /// <summary>
        /// 重复的物料字符串
        /// </summary>
        public string[] repetitionMsg { get; set; }

        public bool Success { get; set; }

        /// <summary>
        /// 返回数量
        /// </summary>
        public int ret { get; set; }

        public T Body { get; set; }

        public string Message { get; set; }

    }

}
