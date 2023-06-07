using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Sys;
using System.Web.Mvc;

namespace RW.PMS.Web.Filter
{
    /// <summary>
    /// 用户过滤器，自动注入到所有的Action中， 自动将用户信息写入到ViewBag.User中  请注意需要在FilterConfig中进行注入
    /// </summary>
    public class UserFilterAttrubite : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //若通过身份验证，则根据用户名将用户信息存于每个Controller的ViewBag.User中
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                var bll = DIService.GetService<IBLL_System>();
                var user = bll.GetUser(new UserModel() { userName = filterContext.HttpContext.User.Identity.Name });
                filterContext.Controller.ViewBag.User = user;
            }
        }
    }
}