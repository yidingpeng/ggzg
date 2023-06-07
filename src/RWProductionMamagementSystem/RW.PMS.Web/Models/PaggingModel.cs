using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RW.PMS.Web.Models
{
    public class PaggingModel
    {
        public PaggingModel()
        {
            PageSize = 10;
            ShowPages = 5;
        }
        /// <summary>
        /// 分页查询关键字
        /// </summary>
        public string key { get; set; }

        public string Url { get; set; }
        /// <summary>
        /// 分页总数量
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 分页控件显示的页数
        /// </summary>
        public int ShowPages { get; set; }
        /// <summary>
        /// 每页的默认数量
        /// </summary>
        public int PageSize { get; set; }
    }
}