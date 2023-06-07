using RW.PMS.Common;
using RW.PMS.Common.Auth;
using RW.PMS.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RW.PMS.Model.Sys;

namespace RW.PMS.Web.Controllers
{

    /// <summary>
    /// 控制器基类
    /// </summary>
    public abstract class BaseController : Controller
    {
        public IBLL_HomePage _HomeBLL = DIService.GetService<IBLL_HomePage>();
        public IBLL_System _SystemBLL = DIService.GetService<IBLL_System>();
        public IBLL_BaseInfo _BaseInfoBLL = DIService.GetService<IBLL_BaseInfo>();
        public IBLL_Device _DeviceBLL = DIService.GetService<IBLL_Device>();
        public IBLL_Account _AccountBLL = DIService.GetService<IBLL_Account>();
        public IBLL_Data _DataBLL = DIService.GetService<IBLL_Data>();
        public IBLL_ProductInfo _ProductInfoBLL = DIService.GetService<IBLL_ProductInfo>();
        public IBLL_Follow _FollowBLL = DIService.GetService<IBLL_Follow>();
        public IBLL_Assembly _assemblyBLL = DIService.GetService<IBLL_Assembly>();

        /// <summary>
        /// 获取分页信息
        /// </summary>
        /// <returns></returns>
        public Tuple<int, int> GetPageInfo()
        {
            var pageIndex = 1;
            var pageSize = 10;

            if (Request["pageIndex"] != null)
            {
                int.TryParse(Request["pageIndex"], out pageIndex);
            }

            if (Request["pageSize"] != null)
            {
                int.TryParse(Request["pageSize"], out pageSize);
            }

            var pageInfo = new Tuple<int, int>(pageIndex, pageSize);
            return pageInfo;
        }

        /// <summary>
        /// 功能权限验证
        /// </summary>
        /// <param name="authType"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool IsAuth(AuthType authType, string path = "")
        {
            var authVal = GetAuth(path);

            var retVal = false;
            if (authVal.HasValue)
            {
                retVal = SystemAuth.IsHasAuth(authType, authVal.Value);
            }
            return retVal;
        }

        /// <summary>
        /// 获取权限值
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public long? GetAuth(string path = "")
        {
            var bll = DIService.GetService<IBLL_Account>();
            var userName = this.HttpContext.User.Identity.Name;

            if (string.IsNullOrEmpty(path))
            {
                path = this.Request.Url.LocalPath;
            }
           var authVal = bll.GetAuthorize(userName, path);

           return authVal;
        }


        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <returns></returns>
        public int GetCurUserID()
        {
            var bllSys = DIService.GetService<IBLL_System>();
            var userModel = bllSys.GetUser(new UserModel() { userName = User.Identity.Name, deleted = 0 });
            return userModel?.userID ?? 0;
        }


        public JsonResult LargeJson(object data)
        {
            return new System.Web.Mvc.JsonResult()
            {
                Data = data,
                MaxJsonLength = Int32.MaxValue,
            };
        }

        public JsonResult LargeJson(object data, JsonRequestBehavior behavior)
        {
            return new System.Web.Mvc.JsonResult()
            {
                Data = data,
                JsonRequestBehavior = behavior,
                MaxJsonLength = Int32.MaxValue
            };
        }

    }
}