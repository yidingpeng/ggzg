using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using RW.PMS.Web.Filter;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace RW.PMS.Web.Controllers
{
    public class SystemController : BaseController
    {
        IBLL_System bll = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo baseInfoBll = DIService.GetService<IBLL_BaseInfo>();
        IBLL_Device devicebll = DIService.GetService<IBLL_Device>();
        IBLL_Account Acctbll = DIService.GetService<IBLL_Account>();

        private static byte[] Photo;
        private static string oldPwd;
        //
        // GET: /System/

        #region 用户信息管理

        //用户信息管理
        //LHR
        //[Permission]
        public ActionResult Users(UserModel model)
        {
            int totalCount = 100;
            ViewBag.UserList = Acctbll.GetPagingUsers(model, out totalCount);
            ViewBag.TotalCount = totalCount;

            ViewBag.RolesInfo = Acctbll.GetRoles();//获取角色下拉
            ViewBag.DepInfo = Acctbll.GetDepartment();//获取部门下拉
            ViewBag.LevelTypeInfo = bll.GetBaseDataTypeValue("SkillLevelType");//人员技能等级
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加用户信息")]
        public JsonResult SaveUsers(UserModel model)
        {
            if (model.userID == 0)
            {
                UserModel umodel = bll.GetUserList(new UserModel()).Where(x => x.userName == model.userName).FirstOrDefault();
                if (umodel != null)
                {
                    return Json(new { Result = false, Message = "保存失败，已存在相同用户账号！" });
                }
                model.pwd = TDMHelper.GetMD5(model.pwd);
                model.registtime = DateTime.Now.Date;
                model.deleted = 0;
                bll.AddUsers(model);
            }
            else
            {
                UserModel umodel = bll.GetUserList(new UserModel()).Where(x => x.userName == model.userName && x.userID != model.userID).FirstOrDefault();
                if (umodel != null)
                {
                    return Json(new { Result = false, Message = "保存失败，已存在相同用户！" });
                }
                string newpwd = TDMHelper.GetMD5("123456");

                if (model.userID != 0)
                {
                    UserModel user = bll.GetUser(new UserModel() { userID = model.userID });
                    oldPwd = user.pwd;
                    Photo = user.headPortrait;
                }
                //勾选重置密码则用新密码
                model.pwd = model.ResultPwd == true ? newpwd : oldPwd;
                bll.EditUsers(model);
            }
            return Json(new { Result = true, Message = "保存成功！" });
        }

        //LHR
        [Log(LogType = 3, Action = "删除用户")]
        //[Permission]
        public JsonResult DelUser(string id)
        {
            bll.DeleteUsers(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        //LHR
        //图片转换成二进制
        public byte[] ImageToBytes(System.Drawing.Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        //LHR
        //二进制转换成图片
        public System.Drawing.Image ByteToImage(byte[] imgData)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imgData);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            return img;
        }

        /// <summary>
        /// 返回二进制图片，展示图片在页面上
        ///
        /// </summary>
        /// <param name="id"></param>
        public void GetHeadPortrait(int id)
        {
            if (id == 0) return;
            var entity = bll.GetUser(new UserModel() { userID = id });
            if (entity != null && entity.headPortrait != null)
            {
                byte[] HeadPortrait = entity.headPortrait;
                Response.BinaryWrite(HeadPortrait);
            }
        }

        public void GetSignature(int id)
        {
            if (id == 0) return;
            var entity = bll.GetUser(new UserModel() { userID = id });
            if (entity != null && entity.signature != null)
            {
                byte[] Signature = entity.signature;
                Response.BinaryWrite(Signature);
            }
        }

        //往项目文件夹里添加图片
        [Permission("/Account/EditUser")]
        public string AddHead(string headImgPath)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["Profile"];
            if (File == null)
                return headImgPath;
            string FileName = File.FileName; //上传的原文件名    
            string itemPath = "/static/TDM/profile/default/";
            string guid = "";
            if (FileName != null && FileName != "")
            {
                string FileType = FileName.Substring(FileName.LastIndexOf(".") + 1); //得到文件的后缀名          
                guid = System.Guid.NewGuid().ToString() + "." + FileType; //得到重命名的文件名               
                File.SaveAs(Server.MapPath(itemPath) + guid); //保存操作     
                DelProperHead(headImgPath);
                return itemPath + guid;
            }
            else
            {
                return File.FileName;
            }
        }
        //删除原来的图片
        public void DelProperHead(string headImgPath)
        {
            string FilePath = Server.MapPath(headImgPath);//转换物理路径
            if (System.IO.File.Exists(FilePath))//判断文件是否存在
            {
                System.IO.File.Delete(FilePath);//执行IO文件删除,需引入命名空间System.IO;
            }
        }
        #endregion

        #region 角色管理

        [Permission]
        public ActionResult Role(RoleModel model)
        {
            int totalCount = 100;
            ViewBag.Rolelist = bll.GetRoleList(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }
        [Permission]
        public ActionResult AddRole()
        {
            ViewData.Model = new RoleModel();
            return View("EditRole");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加角色")]
        public JsonResult AddRole(RoleModel model)
        {
            bll.AddRole(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }
        [HttpGet]
        [Permission]
        public ActionResult EditRole(int id)
        {
            List<RoleModel> list = bll.GetRoleList(new RoleModel() { roleID = id });
            ViewData.Model = list.Count > 0 ? list[0] : new RoleModel();
            return View();
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改角色")]
        public JsonResult EditRole(RoleModel model)
        {
            bll.EditRole(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除角色")]
        [HttpPost]
        public JsonResult DelRole(string id)
        {
            bll.DeleteRole(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 角色权限管理

        /// <summary>
        /// 角色授权界面加载
        /// </summary>
        /// <param name="RoleId"></param>
        /// <param name="RoleName"></param>
        /// <returns></returns>
        [HttpGet]
        [Permission]
        public ActionResult RoleMenuDef(int RoleId, string RoleName)
        {
            ViewBag.RoleId = RoleId;
            ViewBag.RoleName = RoleName;
            ViewBag.Menulist = bll.GetMenuList();
            ViewBag.Auths = bll.GetAuthValueByRoleId(RoleId);
            return View();
        }


        /// <summary>
        /// 权限树形菜单页面 2020-05-20
        /// </summary>
        /// <param name="RoleId">权限ID</param>
        /// <param name="RoleName">权限名称</param>
        /// <returns></returns>
        public ActionResult RoleMenuTree(int RoleId, string RoleName)
        {
            ViewBag.RoleId = RoleId;
            ViewBag.RoleName = RoleName;
            return View();
        }


        public JsonResult GetRoleMenuDef(int roleID)
        {
            List<TreeEntity> list = bll.GetMenuTreeList(roleID);
            return Json(new { code = 0, data = list }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 授权保存
        /// </summary>
        /// <param name="models"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpPost]
        [Log(LogType = 4, Action = "角色授权")]
        public JsonResult RoleMenuDef(List<RoleMenuModel> models, int roleId)
        {
            DIService.GetService<IBLL_System>().EditRoleMenuDef(models, roleId);

            return Json(new { Result = true, Message = "保存成功！", ReturnUrl = "/System/Role" });
        }

        /// <summary>
        /// EleTree 授权树保存
        /// </summary>
        /// <param name="models">权限实体集合</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveRoleMenuDef(List<RoleMenuModel> models, int roleId)
        {
            DIService.GetService<IBLL_System>().SaveRoleMenuDef(models, roleId);
            return Json(new { Result = true, Message = "保存成功！", ReturnUrl = "/System/Role" });
        }

        #endregion

        #region 菜单管理
        /// <summary>
        /// 菜单页面加载
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult menu(MenuModel model)
        {
            int totalCount = 0;
            ViewBag.MenuList = bll.GetMenuForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.MenuInfos = bll.GetAuthorizeMenu(0);//父级ID下拉菜单
            ViewBag.AuthVal = GetAuth();//获取权限
            return View();
        }


        /// <summary>
        /// Layui Treetable-lay
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetMenuPage(MenuModel model)
        {
            List<MenuModel> menulist = bll.GetMenuAll(model);
            return Json(new { code = 0, msg = "ok", data = menulist, count = menulist.Count() }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加窗体加载事件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permission]
        public ActionResult AddMenu()
        {
            //隐藏显示状态下拉框
            ViewBag.isShow = new List<SelectListItem>() {
                new SelectListItem(){Value="1",Text="显示"},
                new SelectListItem(){Value="0",Text="隐藏"}
            };
            //权限复选框
            ViewBag.Auths = bll.GetMenuAuth();
            //父级菜单下拉框
            ViewBag.MenuInfos = bll.GetAuthorizeMenu(0);
            return View("MenuEdit");
        }

        /// <summary>
        /// 添加保存功能
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        [Permission]
        [Log(LogType = 2, Action = "添加菜单")]
        public JsonResult AddMenu(MenuModel menu)
        {
            MenuAction(menu);
            menu.createBy = this.HttpContext.User.Identity.Name;
            bll.AddMenu(menu);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        /// <summary>
        /// 菜单功能按钮
        /// </summary>
        /// <param name="menu"></param>
        private void MenuAction(MenuModel menu)
        {
            var keys = this.Request.Form.Keys.Cast<string>().Where(f => f.StartsWith("ck_"));
            var auths = new List<MenuAuth>();
            foreach (var key in keys)
            {
                if (Request.Form[key].Contains("true"))
                {
                    auths.Add(new MenuAuth
                    {
                        ID = int.Parse(key.Remove(0, 3))
                    });
                }
            }
            menu.auths = auths;

        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permission]
        public ActionResult MenuEdit(int id)
        {
            ViewBag.isShow = new List<SelectListItem>() {
                new SelectListItem(){Value="1",Text="显示"},
                new SelectListItem(){Value="0",Text="隐藏"}
            };
            //父级ID下拉菜单
            ViewBag.MenuInfos = bll.GetAuthorizeMenu(0);
            ViewBag.Auths = bll.GetMenuAuth();
            if (id == 0) return View();
            var list = bll.GetMenuList(new MenuModel() { menuID = id });
            if (list.Count > 0) ViewBag.MenuInfo = list[0];
            return View();
        }

        //LHR
        [HttpPost]
        [Permission]
        [Log(LogType = 4, Action = "修改菜单")]
        public JsonResult MenuEdit(MenuModel menu)
        {
            MenuAction(menu);
            menu.updateBy = this.HttpContext.User.Identity.Name;
            bll.EditMenu(menu);
            return Json(new { Result = true, Message = "修改成功！" });
        }
        //LHR
        [HttpPost]
        [Log(LogType = 3, Action = "删除菜单")]
        public JsonResult DelMenu(string id)
        {
            bll.DelMenu(id);
            return Json(new { code = 200, Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 数据字典维护

        /// <summary>
        /// 数据字典维护
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult baseData(BaseDataModel model)
        {
            int totalCount = 0;
            ViewBag.baseDataList = bll.GetBaseDataForPage(model, out totalCount);
            ViewBag.totalCount = totalCount;
            ViewBag.baseDataTypeInfos = bll.GetBaseDataTypeList();//获取数据类型下拉
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        /// <summary>
        /// Layui 分页加载
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetbaseData(BaseDataModel model, int page, int limit)
        {
            model.PageIndex = page;
            model.PageSize = limit;
            int totalCount = 0;
            List<BaseDataModel> BaseDataList = bll.GetBaseDataForPageLayui(model, out totalCount);
            //List<BaseDataTypeModel> = bll.GetBaseDataTypeList();//获取数据类型下拉
            return Json(new { code = 0, msg = "ok", data = BaseDataList, count = totalCount }, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// 加载数据字典类型下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetbaseDataTypeInfo()
        {
            return Json(new { data = bll.GetBaseDataTypeList() }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 加载数据字典下拉
        /// </summary>
        /// <returns></returns>
        public JsonResult GetBaseDataInfo()
        {
            //获取基础数据下拉
            return Json(new { data = bll.GetbaseData() }, JsonRequestBehavior.AllowGet);
        }


        //添加 数据字典维护页面
        //LHR
        [Permission]
        public ActionResult AddbaseData()
        {
            ViewBag.baseDataTypeInfos = bll.GetBaseDataTypeList();//获取数据类型下拉
            ViewBag.BaseDataInfo = bll.GetbaseData();//获取基础数据下拉
            return View("EditbaseData");
        }

        //编辑 数据字典维护页面
        //LHR
        [Permission]
        public ActionResult EditbaseData(int id)
        {
            ViewBag.baseDataModel = bll.GetbaseData().Where(x => x.ID == id).FirstOrDefault();
            ViewBag.baseDataTypeInfos = bll.GetBaseDataTypeList();//获取数据类型下拉
            ViewBag.BaseDataInfo = bll.GetbaseData();//获取基础数据下拉
            return View();
        }
        /// <summary>
        /// 根据 参数编码下拉获取 类型名称文本框中的值
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult getBdTypeName(int id)
        {
            var baseDataType = bll.GetBaseDataTypeList().Where(x => x.ID == id).FirstOrDefault();
            return Json(baseDataType);
        }

        //LHR
        [HttpPost]
        [Log(LogType = 2, Action = "添加数据字典维护")]
        public JsonResult AddbaseData(BaseDataModel model)
        {
            bll.AddBaseData(model);
            return Json(new { code = 200, Result = true, Message = "添加成功！" });
        }

        //LHR
        [HttpPost]
        [Log(LogType = 2, Action = "修改数据字典维护")]
        public JsonResult EditbaseData(BaseDataModel model)
        {
            bll.EditBaseData(model);
            return Json(new { code = 200, Result = true, Message = "修改成功！" });
        }

        //LHR
        [HttpPost]
        [Log(LogType = 2, Action = "删除数据字典")]
        public JsonResult DelbaseData(string id, string ids)
        {
            if (!string.IsNullOrEmpty(id))
                bll.DelBaseData(id);

            if (!string.IsNullOrEmpty(ids))
                bll.DelBaseData(ids);

            return Json(new { code = 200, Message = "删除成功！" });
        }

        #endregion

        #region 工具/物料OPC点位设置

        /// <summary>
        /// 工具/物料OPC点位设置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult GjWlOpcPoint(GjWlOpcPointModel model)
        {
            int totalCount = 0;
            //List<BaseOPCProductModel> lsit = baseInfoBll.GetOPCProductModelList(model, out totalCount);

            //foreach (BaseOPCProductModel item in lsit)
            //{
            //    item.opclist = bll.GetGjWlOpcPointList(new GjWlOpcPointModel() { pmodelID = item.ID });
            //}

            //ViewBag.GwopcPointList = lsit;
            ViewBag.GwopcPointList = bll.GetGjWlOpcPointForPage(model, out totalCount);
            ViewBag.totalCount = totalCount;
            ViewBag.gongwei = bll.GetgongweiAll();//绑定工位下拉
            ViewBag.gongju = baseInfoBll.GetAllBaseGongJu();//绑定工具下拉
            ViewBag.wuliao = baseInfoBll.GetAllBaseWuliao();//绑定物料下拉
            ViewBag.pmodel = baseInfoBll.GetAllBaseProModel();//绑定产品型号下拉
            ViewBag.Opc = bll.GetBaseDataTypeValue("gjwlOPCType");//获取OPC类型下拉
            ViewBag.AuthVal = GetAuth();

            return View();
        }

        /// <summary>
        /// OPC点位设置 添加页面
        ///
        /// </summary>
        /// <returns></returns>
        [Permission]
        public ActionResult AddGjWlOpcPoint()
        {
            ViewBag.gongwei = bll.GetgongweiAll();//绑定工位下拉
            ViewBag.gongju = baseInfoBll.GetAllBaseGongJu();//绑定工具下拉
            ViewBag.pmodel = baseInfoBll.GetAllBaseProModel();//绑定产品型号下拉
            //ViewBag.wuliao = baseInfoBll.GetAllBaseWuliao();//绑定物料下拉
            ViewBag.wuliao = _BaseInfoBLL.GetMaterialDict().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.mDrawingNo + " " + f.mName)).ToList();
            ViewBag.Opc = bll.GetBaseDataTypeValue("gjwlOPCType");//获取OPC类型下拉
            return View("EditGjWlOpcPoint");
        }

        /// <summary>
        /// OPC点位设置 修改页面
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Permission]
        public ActionResult EditGjWlOpcPoint(string id, int gwID, int gjID, int wlID,int pmodelID)
        {
            string[] list = id.Split(',');
            var listid = Convert.ToInt32(list[0]);
            ViewBag.GwopcPointInfo = bll.GetGjWlOpcPoint().Where(x => x.ID == listid).FirstOrDefault();
            ViewBag.gongwei = bll.GetgongweiAll();//绑定工位下拉
            ViewBag.gongju = baseInfoBll.GetAllBaseGongJu();//绑定工具下拉
            ViewBag.pmodel = baseInfoBll.GetAllBaseProModel();//绑定产品型号下拉
            //ViewBag.wuliao = baseInfoBll.GetAllBaseWuliao();//绑定物料下拉
            ViewBag.wuliao = _BaseInfoBLL.GetMaterialDict().Select(f => new KeyValuePair<string, string>(f.ID.ToString(), f.mDrawingNo + " " + f.mName)).ToList();
            ViewBag.Opc = bll.GetBaseDataTypeValue("gjwlOPCType");//获取OPC类型下拉
            ViewBag.GjWlOpcPoint = bll.GetGjWlOpcPointByID(gwID, gjID, wlID, pmodelID);//获取相同工位下 不同工具、物料的OPC点位信息
            return View();
        }

        //LHR
        [HttpPost]
        [Log(LogType = 2, Action = "添加OPC点位")]
        public JsonResult AddGjWlOpcPoint(GjWlOpcPointModel model)
        {
            bll.AddGjWlOpcPoint(model);
            return Json(new { Result = true, Message = "添加成功" });
        }


        /// <summary>
        /// 工具/物料OPC点位设置 通用添加修改方法
        /// </summary>
        /// <param name="models"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        [Log(LogType = 2, Action = "修改OPC点位")]
        public JsonResult EditGjWlOpcPoint(List<GjWlOpcPointModel> models, string ID)
        {
            bll.EditSystemGjWlOpcPoint(models, ID);
            return Json(new { Result = true, Message = "保存成功！", ReturnUrl = "/System/GjWlOpcPoint" });
        }

        //LHR
        [HttpPost]
        [Log(LogType = 2, Action = "删除OPC点位")]
        public JsonResult DelGjWlOpcPoint(List<GjWlOpcPointModel> IDlist)
        {
            bll.DelGjWlOpcPoint(IDlist);
            return Json(new { Result = true, Message = "删除成功！" });
        }

        #endregion

        #region 部门管理

        [Permission]
        public ActionResult Department(DepartmentModel model)
        {
            int totalCount = 10;
            ViewBag.DepartmentList = bll.GetPagingDepartment(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpPost]
        [Log(LogType = 2, Action = "保存部门信息")]
        public JsonResult SaveDepartment(DepartmentModel model)
        {
            if (model == null) return Json(new { Result = false, Message = "参数为空！" });
            DepartmentModel list = null;
            if (model.DeptID != 0)
                list = bll.GetDepartmentList().Where(x => x.DeptName == model.DeptName && x.DeptID != model.DeptID).FirstOrDefault();
            else
                list = bll.GetDepartmentList().Where(x => x.DeptName == model.DeptName).FirstOrDefault();

            if (list == null)
            {
                if (model.DeptID != 0)
                    bll.EditDepartment(model);
                else
                    bll.AddDepartment(model);

                return Json(new { Result = true, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = false, Message = "已存在相同部门名称" });
            }

        }

        [Permission]
        public ActionResult AddDepartment()
        {
            ViewData.Model = new DepartmentModel();
            return View("EditDepartment");
        }


        [HttpPost]
        [Log(LogType = 2, Action = "添加部门")]
        public JsonResult AddDepartment(DepartmentModel model)
        {
            bll.AddDepartment(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改部门")]
        public JsonResult EditDepartment(DepartmentModel model)
        {
            bll.EditDepartment(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除部门")]
        [HttpPost]
        public JsonResult DelDepartment(string id)
        {
            bll.DeleteDepartment(id);
            return Json(new { Result = true, Message = "删除成功！" });

        }
        #endregion

        #region 数据字典类型

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="model">数据字典类型</param>
        /// <returns></returns>
        [Permission]
        public ActionResult BaseDataType(SysbaseDataTypeModel model)
        {
            int totalCount = 100;
            ViewBag.BaseDataTypelist = bll.GetBaseDataTypeList(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult GetBaseDataType(SysbaseDataTypeModel model)
        {
            List<SysbaseDataTypeModel> SysbaseDataType = bll.GetBaseDataTypeList(model);
            return Json(new { code = 0, msg = "ok", data = SysbaseDataType }, JsonRequestBehavior.AllowGet);
        }



        [Permission]
        public ActionResult AddBaseDataType()
        {
            ViewData.Model = new SysbaseDataTypeModel();
            return View("EditBaseDataType");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加数据字典类型")]
        public JsonResult AddBaseDataType(SysbaseDataTypeModel model)
        {
            bll.AddBaseDataType(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        /// <summary>
        /// 打开编辑窗体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Permission]
        public ActionResult EditBaseDataType(int id)
        {
            if (id == 0) return View();
            var list = bll.GetBaseDataTypeList(new SysbaseDataTypeModel() { ID = id });
            if (list.Count == 0) return View();
            ViewData.Model = list[0];
            return View();
        }


        [HttpPost]
        [Log(LogType = 4, Action = "修改数据字典类型")]
        public JsonResult EditBaseDataType(SysbaseDataTypeModel model)
        {
            bll.EditBaseDataType(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Log(LogType = 3, Action = "删除数据字典类型")]
        [HttpPost]
        public JsonResult DelBaseDataType(string id)
        {
            int i = bll.DeleteBaseDataType(id);
            if (i > 0)
                return Json(new { Result = true, Message = "删除成功！" });
            return Json(new { Result = false, Message = "此数据字典类型已被使用，删除失败！" });
        }
        #endregion

        #region 参数配置

        /// <summary>
        /// 查看
        /// </summary>
        /// <param name="model">参数配置</param>
        /// <returns></returns>
        [Permission]
        public ActionResult SysConfig(SysconfigModel model)
        {
            int totalCount = 10;
            ViewBag.SysConfiglist = bll.GetPagingSysConfig(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.AuthVal = GetAuth();
            return View();
        }

        [HttpGet]
        [Permission]
        public ActionResult AddSysConfig()
        {
            ViewData.Model = new SysconfigModel();
            return View("EditSysConfig");
        }

        [HttpPost]
        [Log(LogType = 2, Action = "添加参数配置")]
        public JsonResult AddSysConfig(SysconfigModel model)
        {

            //【逻辑删除】默认值设置为0
            model.isDeleted = 0;
            bll.AddSysConfig(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [HttpPost]
        [Log(LogType = 4, Action = "修改参数配置")]
        public JsonResult EditSysConfig(SysconfigModel model)
        {
            bll.EditSysConfig(model);
            return Json(new { Result = true, Message = "保存成功！" });
        }

        [Log(LogType = 3, Action = "删除参数配置")]
        [HttpPost]
        public JsonResult DelSysConfig(string id)
        {
            bll.DeleteSysConfig(id);
            return Json(new { Result = true, Message = "删除成功！" });
        }
        #endregion

        #region 软件更新上传

        /// <summary>
        /// 软件更新查看
        /// </summary>
        /// <param name="model">参数配置</param>
        /// <returns></returns>
        [Permission]
        public ActionResult SysexeFileUpdate(SysexeFileUpdateModel model)
        {
            int totalCount = 100;
            ViewBag.fileUpdatelist = bll.GetPagingSysexeFileUpdate(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            return View();
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateFile(HttpPostedFileBase file)
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase File = files["txtfile"];
            string SavaPath = "/Upload/sysExeFileUpload/" + DateTime.Now.ToString("yyyy-MM-dd") + "/"; //存储的相对路径
            string FullPath = Server.MapPath(SavaPath);//完整路径
            string fileName = "";
            if (File != null)
            {
                fileName = File.FileName;//文件名

                if (!System.IO.Directory.Exists(FullPath))
                {
                    System.IO.DirectoryInfo Dir = System.IO.Directory.CreateDirectory(FullPath);
                    Dir.Refresh();
                }
                SavaPath += fileName;
                if (System.IO.File.Exists(FullPath + fileName))
                {
                    System.IO.File.Delete(FullPath + fileName);
                }
                File.SaveAs(FullPath + fileName);
                return Json(new { Result = true, Message = "上传成功！", Path = SavaPath });
            }
            else
            {
                return Json(new { Result = false, Message = "上传失败！" });
            }

        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="file"></param>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveUpdateFile(string FileName, string FileType, string FilePath)
        {
            SysexeFileUpdateModel fileEnty = new SysexeFileUpdateModel();
            if (FileType == "")
                FileType = "application/x-msdownload";
            if (FileName != "" && FileType != "" && FilePath != "")
            {
                fileEnty.filesName = FileName;
                fileEnty.fileType = FileType;
                fileEnty.versionNuber = DateTime.Now.ToString("yyyyMMddHHmm");
                fileEnty.uploadTime = DateTime.Now;
                fileEnty.filePath = FilePath;
                fileEnty.remark = "1.0.0.1";

            }
            if (fileEnty != null)
            {
                bll.SaveSysExeFileUpdate(fileEnty);
                return Json(new { Result = true, Message = "保存成功！" });
            }
            else
            {
                return Json(new { Result = false, Message = "保存失败！" });
            }
        }

        public FileResult DownloadClient()
        {
            SysexeFileUpdateModel model = bll.GetSysUpdateFile();
            //获取报表名称
            string fileName = string.Empty;
            if (model != null)
            {
                fileName = model.filesName;
                string SavaPath = model.filePath;
                //完整路径
                string path = Server.MapPath(SavaPath);
                //判断文件是否存在
                if (System.IO.File.Exists(path))
                {
                    FileInfo fileinfo = new FileInfo(path);
                    Response.Clear();         //清除缓冲区流中的所有内容输出
                    Response.ClearContent();  //清除缓冲区流中的所有内容输出
                    Response.ClearHeaders();  //清除缓冲区流中的所有头
                    Response.Buffer = true;   //该值指示是否缓冲输出，并在完成处理整个响应之后将其发送
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                    Response.AddHeader("Content-Length", fileinfo.Length.ToString());
                    Response.AddHeader("Content-Transfer-Encoding", "binary");
                    Response.ContentType = "application/unknow";  //获取或设置输出流的 HTTP MIME 类型
                    Response.ContentEncoding = System.Text.Encoding.UTF8; //获取或设置输出流的 HTTP 字符集
                    Response.TransmitFile(path);
                    Response.End();
                }
                else
                {
                    Response.Redirect("/System/SysexeFileUpdate");
                }

            }
            else
            {
                Response.Redirect("/System/SysexeFileUpdate");
            }
            return File(new byte[0], "text/plain", fileName);
        }

        #endregion

        #region 用户工位权限设置 WZQ

        [HttpGet]
        [Permission]
        public ActionResult UserGwAuthority(int UserID, string UserName)
        {
            ViewBag.UserID = UserID;
            ViewBag.UserName = UserName;
            ViewBag.GongWeilist = baseInfoBll.GetGongWei();
            ViewBag.GwRightlist = bll.GetGwRightType();
            return View();
        }
        [HttpPost]
        [Log(LogType = 4, Action = "用户工位权限授权")]
        public JsonResult UserGwAuthority(string RightTypeName, int UserID)
        {
            if (RightTypeName == null || RightTypeName.ToString() == "")
            {
                return Json(new { Result = false, Message = "保存失败！", ReturnUrl = "/System/Users" });
            }
            else
            {
                #region 处理前台传过来的值
                //把前台传过来的值进行分割用Dictionary进行分组
                Dictionary<string, BaseGongweiRightModel> dic = new Dictionary<string, BaseGongweiRightModel>();
                RightTypeName = RightTypeName.Length > 0 ? RightTypeName.Substring(0, RightTypeName.Length - 1) : "";
                string[] List = RightTypeName.Split(',');
                for (int i = 0; i < List.Length; i++)
                {
                    if (List[i].Contains("-"))
                    {
                        string[] Item = List[i].Split('-');
                        if (Item.Length == 4)
                        {
                            string key = string.Format("{0}/{1}", Item[0], Item[2]);
                            if (!dic.ContainsKey(key))
                            {
                                BaseGongweiRightModel model = new BaseGongweiRightModel();
                                model.gwID = Convert.ToInt32(Item[1].ToString());
                                model.empID = UserID;
                                model.rightTypeID = Convert.ToInt32(Item[3].ToString());
                                model.gwrStatus = 0;
                                dic.Add(key, model);
                            }
                        }
                    }
                }
                bll.EditUserGwAuthority(dic, UserID);
                return Json(new { Result = true, Message = "保存成功！", ReturnUrl = "/System/Users" });
                #endregion
            }
        }
        #endregion

        #region 考勤信息
        [Permission]
        public ActionResult LoginInfo(LoginInfoModel model)
        {
            int totalCount = 100;
            ViewBag.LoginInfoList = bll.LoginInfoForPage(model, out totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.Employee = bll.GetUserList();
            return View();
        }

        #endregion

        /// <summary>
        /// Fontaweson 图标5.3.0
        /// </summary>
        /// <returns></returns>
        public ActionResult Fontaweson()
        {
            return View();
        }
    }
}
