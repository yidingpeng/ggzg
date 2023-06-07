using RW.PMS.Web.Filter;
using System.Web.Mvc;

namespace RW.PMS.Web
{
    /// <summary>
    /// 筛选器配置
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// 注册筛选器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthorizeAttribute(), -1);
            filters.Add(new UserFilterAttrubite(), -1);
        }
    }
}