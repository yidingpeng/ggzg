using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Sys;
using RW.PMS.Web.Filter;
using RW.PMS.Web.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace RW.PMS.Web.Controllers
{
    /// <summary>
    /// 账户
    /// </summary>
    public class AccountController : BaseController
    {
        IBLL_Account bll = DIService.GetService<IBLL_Account>();
        IBLL_System bllSys = DIService.GetService<IBLL_System>();

        #region 登录 登出

        /// <summary>
        /// 登录界面加载事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //如果已登录则跳转至首页
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            //获取系统标题
            IBLL_System bll = DIService.GetService<IBLL_System>();
            SysconfigModel model = bll.GetConfigByCode("HomePageTitle");
            ViewBag.Title = model == null ? "润伟产线管理信息系统" : model.cfg_value;
            return View();
        }


        /// <summary>
        /// 新版登录界面 改WebConfig中loginUrl="/Account/Logins"
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logins()
        {
            //如果已登录则跳转至首页
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            //获取系统标题
            IBLL_System bll = DIService.GetService<IBLL_System>();
            SysconfigModel model = bll.GetConfigByCode("HomePageTitle");
            ViewBag.Title = model == null ? "润伟产线管理信息系统" : model.cfg_value;
            return View();
        }


        /// <summary>
        /// 注册页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            //获取系统标题
            IBLL_System bll = DIService.GetService<IBLL_System>();
            SysconfigModel model = bll.GetConfigByCode("HomePageTitle");
            ViewBag.Title = model == null ? "润伟产线管理信息系统" : model.cfg_value;
            return View();
        }


        /// <summary>
        /// 验证账户是否正确
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult VerifyUser(string user)
        {
            UserModel users = bllSys.GetUser(new UserModel() { userName = user, deleted = 0 });
            bool b = false;
            var msg = "";
            if (users != null)
            {
                msg = "该用户名已注册，请更换用户名或<a href='/Account/Logins'>登陆</a>！";
            }
            else
            {
                b = true;
            }
            return Json(new { Result = b, Message = msg });

        }


        //登录按钮点击事件
        [HttpPost]
        [AllowAnonymous]
        public JsonResult Login(LoginModel login)
        {
            UserModel model = bllSys.GetUser(new UserModel() { userName = login.Username });
            if (model == null)
                return Json(new { Result = false, Message = "该用户不存在！" });
            if (model.deleted == (int)EDAEnums.YesOrNo.Yes)
                return Json(new { Result = false, Message = "用户已被禁用，请联系管理员。" });
            string pwd = TDMHelper.GetMD5(login.Password);
            if (pwd != model.pwd)
                return Json(new { Result = false, Message = "用户名或密码错误！" });

            FormsAuthentication.SetAuthCookie(login.Username, false);
            string Url = "/Home/Index";

            return Json(new { Result = true, Message = "登录成功！", ReturnUrl = Url });
        }

        //登出
        [AllowAnonymous]
        [Permission(true)]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region 验证密码
        /// <summary>
        /// 用户基本信息
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult Profiles()
        {
            ViewBag.UserInfo = bllSys.GetUser(new UserModel() { userName = this.HttpContext.User.Identity.Name, deleted = 0 });
            return View();
        }
        [Permission]
        public ActionResult EditPwd()
        {
            ViewBag.UserName = this.HttpContext.User.Identity.Name;
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改密码")]
        public JsonResult EditPwd(string yPwd, string newPwd1, string newPwd)
        {
            bll.qrPwd(newPwd1, newPwd);
            yPwd = TDMHelper.GetMD5(yPwd);
            newPwd = TDMHelper.GetMD5(newPwd);
            bll.EditPwd(yPwd, newPwd, this.HttpContext.User.Identity.Name);
            return Json(new { Result = true, Message = "修改成功！" });
        }

        /// <summary>
        /// 验证密码
        /// </summary>
        /// <param name="Ypwd"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult VerifyPwd(string Ypwd)
        {
            Ypwd = TDMHelper.GetMD5(Ypwd);
            UserModel user = bllSys.GetUser(new UserModel() { userName = this.HttpContext.User.Identity.Name, deleted = 0 });
            bool b = false;
            if (user != null && user.pwd == Ypwd) b = true;
            return Json(new { Result = b, Message = "密码正确！" });
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        /// LHR
        /// </summary>
        /// <param name="id"></param>
        public void GetHeadPortrait(int id)
        {
            if (id == 0) return;
            var entity = bllSys.GetUser(new UserModel() { userID = id });
            if (entity != null && entity.headPortrait != null)
            {
                byte[] HeadPortrait = entity.headPortrait;
                Response.BinaryWrite(HeadPortrait);
            }
        }
        #endregion

        #region 菜单栏搜索框
        public ActionResult SearchPage(string menuName)
        {
            var Url = bll.GetMenuNameByUrl(menuName);
            return Redirect(Url);
        }
        #endregion
    }
}
