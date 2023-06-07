using RW.PMS.Common;
using RW.PMS.Common.Auth;
using RW.PMS.IBLL;
using System;
using System.Web.Mvc;

namespace RW.PMS.Web.Filter
{
    /// <summary>
    /// 权限属性过滤器
    /// </summary>
    public class PermissionAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 是否不验证，验证为false，不验证为true。默认为false
        /// </summary>
        public bool NoValidation { get; set; }

        /// <summary>
        /// 指定特定的Path
        /// </summary>
        public string ActionPath { get; set; }

        public AuthType AuthType { get; set; }

        public PermissionAttribute(string path = "", AuthType authType = AuthType.Query)
        {
            this.ActionPath = path;
            AuthType = authType;
        }

        public PermissionAttribute(bool noValidation)
        {
            this.NoValidation = noValidation;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!NoValidation)
            {
                var user = filterContext.HttpContext.User.Identity.Name;
                string path = string.Empty;
                if (string.IsNullOrEmpty(ActionPath))
                {
                    path = "/" + filterContext.RouteData.Values["controller"] + "/" + filterContext.RouteData.Values["action"];
                }
                var ctrller = filterContext.RouteData.Values["controller"].ToString();
                var action = filterContext.RouteData.Values["action"].ToString();
                if (!ValidUserPermission(user, path, AuthType))
                {
                    if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        filterContext.Result = new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new
                            {
                                Result = false,
                                Message = "您无权限访问"
                            }
                        };
                    }
                    else
                    {
                        var model = new HandleErrorInfo(new UnauthorizedAccessException("您无权限访问"), ctrller, action);
                        filterContext.Result = new ViewResult()
                        {
                            ViewName = "NoPermission",
                            MasterName = "_Layout",
                            ViewData = new ViewDataDictionary(model),
                            TempData = filterContext.Controller.TempData
                        };
                        filterContext.HttpContext.Response.Clear();
                    }
                    filterContext.HttpContext.Response.StatusCode = 403;
                }
            }
            base.OnActionExecuting(filterContext);
        }

        bool ValidUserPermission(string username, string path,AuthType authType)
        {
            //TODO:验证当前用户是否拥有Path的权限。
            var bll = DIService.GetService<IBLL_Account>();
            var authVal = bll.GetAuthorize(username, path);
            var retVal = false;
            if (authVal.HasValue)
            {
               retVal =  SystemAuth.IsHasAuth(authType, authVal.Value);
            }
            return retVal;
        }
    }
}