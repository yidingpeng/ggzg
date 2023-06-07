using System.Web.Mvc;

namespace RW.PMS.Web.Filter
{
    /// <summary>
    /// 日志过滤器
    /// </summary>
    public class LogAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 执行的动作
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 记录日志的类型，请查看数据字典
        /// </summary>
        public int LogType { get; set; }

        public LogAttribute()
        {
            Order = 999;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }
    }
}