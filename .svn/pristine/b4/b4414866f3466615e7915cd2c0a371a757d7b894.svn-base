using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using RW.PMS.IBLL;
using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Sys;
using RW.PMS.Model.BaseInfo;
using RW.PMS.WinForm.Utils;
using RW.PMS.WinForm.Common;
using RW.PMS.Utils.Security;
using System.Configuration;

namespace RW.PMS.WinForm
{
    /// <summary>
    /// 登录窗体
    /// </summary>
    public partial class FrmLogin : FormSkin
    {

        IBLL_Account _accountBLL = DIService.GetService<IBLL_Account>();
        IBLL_System sysbll = DIService.GetService<IBLL_System>();
        IBLL_BaseInfo basebll = DIService.GetService<IBLL_BaseInfo>();
        UserModel LoginUser = null;

        public int EmpID { get; private set; }
        public string EmpName { get; private set; }
        public bool IsAdmin { get; private set; }

        /// <summary>
        /// 登陆时是否可以用刷卡登陆
        /// </summary>
        string _loginIsUseCard = "0";

        CardOperation _cardOpertion = null;

        /// <summary>
        /// 登录窗体构造函数
        /// </summary>
        public FrmLogin()
        {
            InitializeComponent();
 
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                lblMsg.Text = string.Empty;
                //获取服务器地址
                _loginIsUseCard = sysbll.GetConfigByCode("LoginIsUseCard").cfg_value;
                if (string.IsNullOrEmpty(_loginIsUseCard))
                {
                    lblMsg.Text = "未获取到参数LoginIsUseCard,是否启用员工ID卡登陆， 请检查网络或配置！";
                    return;
                }

                //if (_loginIsUseCard == "1")
                //{
                //    txtcard.Visible = true;

                //    //打开读卡器 读取扫卡信息
                //    _cardOpertion = new CardOperation(this);
                //    _cardOpertion.IsConnBeep = true;
                //    _cardOpertion.SimpleModel = true;
                //    _cardOpertion.Open();
                //    _cardOpertion.CardReader += _cardOpertion_CardReader;
                //    _cardOpertion.ReadStart();
                //}
                //else
                //{
                  txtcard.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                //lblMsg.Text = "刷卡器初始化失败，" + ex.Message;
            }
        }

        void _cardOpertion_CardReader(object sender, string e)
        {
            txtcard.Text = e.Substring(0, 8);//只取前8位字符串结果。
                                             //if (e.ToUpper().StartsWith("E"))
                                             //{
                                             //卡号登录
            UserModel userModel = new UserModel();
            userModel.userName = txtName.Text.Trim();
            userModel.cardNo = txtcard.Text.Trim();
            userModel.deleted = 0;
            userModel.inStatus = 1;
            var empInfo = sysbll.GetUser(userModel);
            if (empInfo == null)
            {
                //RWMessageBox.Show("没有找到卡号对应的员工信息！");
                lblMsg.Text = "没有找到卡号对应的员工信息！";
                return;
            }

            BaseGongweiRightModel model = new BaseGongweiRightModel();
            model.empID = empInfo.userID;
            model.IP = PublicVariable.LocalIP;
            if (string.IsNullOrEmpty(model.IP))
            {
                lblMsg.Text = "未获取到本机的IP地址，请检查！";
                return;
            }
            //需要在修改完basebll后取消注释
            List<BaseGongweiRightModel> list = basebll.GetRightList(model);
            if (list.Count == 0)
            {
                lblMsg.Text = "没有权限！";
                return;
            }

            EmpID = empInfo.userID;
            EmpName = empInfo.empName;
            IsAdmin = empInfo.roleName == "管理员";

            DialogResult = DialogResult.OK;
            //}
            //else
            //{
            //    MessageBox.Show("员工卡号有错误，请换成正确的卡，卡号须以E开头");
            //}
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //判断权限 2019-4-9
            if (string.IsNullOrEmpty(PublicVariable.LocalIP))
            {
                lblMsg.Text = "未获取到本机的IP地址，请检查！";
                return;
            }

            //登录身份验证
            if (!UserVerify()) { return; }

            //需要在修改完basebll后取消注释
            List<BaseGongweiRightModel> list = basebll.GetRightList(new BaseGongweiRightModel { empID = LoginUser.userID, IP = PublicVariable.LocalIP });
            if (list.Count == 0)
            {
                lblMsg.Text = "当前用户没有权限登录！IP：[" + PublicVariable.LocalIP + "]";
                return;
            }

            //if (LoginUser.postTime.HasValue)
            //{
            //    if (LoginUser.postTime < PublicVariable.GetSystemDateTime().ToDateTime())
            //    {
            //        RWMessageBox.ShowExclamation("当前人员资质已到期！");
            //        return;
            //    }
            //}

            EmpID = LoginUser.userID;
            EmpName = LoginUser.empName;
            IsAdmin = LoginUser.roleName == "管理员";
            FrmLogin_FormClosing(null, null);

            this.DialogResult = DialogResult.OK;
        }

        //退出按钮点击事件
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //关闭事件
        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //if (_loginIsUseCard == "1")
                //    _cardOpertion.Close();
            }
            catch
            {
            }
        }

        private void FrmLogin_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                //if (this.Visible == false && _loginIsUseCard == "1")
                //    _cardOpertion.Close();
            }
            catch
            {
            }
        }

        //账号文本框光标离开事件-获取用户头像
        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 15)
                return;
            //用户名密码登录
            SetHeadPortrait(sysbll.GetUser(new UserModel { userName = txtName.Text.Trim(), deleted = 0, inStatus = 1 }));
        }

        /// <summary>
        /// 用户名验证
        /// </summary>
        private bool UserVerify()
        {
            try
            {
                string loginName = txtName.Text.Trim();
                string pwd = txtPwd.Text.Trim();

                //空返回
                if (string.IsNullOrEmpty(loginName))
                {
                    lblMsg.Text = "用户名不能为空！";
                    return false;
                }

                //用户名密码登录
                var UserNamePwd = sysbll.GetUser(new UserModel { userName = txtName.Text.Trim(), deleted = 0, inStatus = 1 });

                string result = System.Text.RegularExpressions.Regex.Replace(txtName.Text.Trim(), @"[^0-9]+", "");

               
                UserModel UserCardNo = null;
                //表头是提取到 二维码信息 txtName.Text.Length > 10 &&
                if (result.Length >= 5)
                {
                    //二维码登录
                    UserCardNo = sysbll.GetUser(new UserModel { cardNo = result, deleted = 0, inStatus = 1 });
                }

                if (UserNamePwd == null && UserCardNo == null)
                {
                    lblMsg.Text = "请确保用户是否存在！如有问题请与管理员核实后再进行操作！";
                    return false;
                }

                //用户名＋密码登录
                if (UserNamePwd != null)
                {
                    LoginUser = UserNamePwd;
                    //设置头像
                    SetHeadPortrait(LoginUser);

                    //非空判断
                    if (string.IsNullOrEmpty(pwd))
                    {
                        lblMsg.Text = "密码不能为空，请输入密码！";
                        return false;
                    }

                    //进行MD5加密
                    string yPwd = MD5Helper.GetMD5(ConfigurationManager.AppSettings["PwdHash"] + pwd);
                    if (LoginUser.pwd != yPwd)
                    {
                        lblMsg.Text = "密码不正确！";
                        txtPwd.Text = string.Empty;
                        return false;
                    }
                    txtcard.Text = LoginUser.cardNo + "";
                }

                //二维码登录
                if (UserCardNo != null)
                {
                    LoginUser = UserCardNo;
                    //设置头像
                    SetHeadPortrait(LoginUser);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 设置用户头像
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        public bool SetHeadPortrait(UserModel User)
        {
            if (User == null)
            {
                this.pictureBox2.Image = null;
                lblMsg.Text = "请确保用户账户是否存在！如有问题请与管理员核实再进行操作！";
                return false;
            }
            else
            {
                SetImage(User.headPortrait);
                return true;
            }
        }

        /// <summary>
        /// 设置头像图片
        /// </summary>
        /// <param name="image"></param>
        private void SetImage(byte[] image)
        {
            try
            {
                //员工头像显示
                if (image == null || image.Length == 0) return;
                MemoryStream myStream = new MemoryStream();
                foreach (byte a in image)
                {
                    myStream.WriteByte(a);
                }
                Image myImage = Image.FromStream(myStream);
                myStream.Close();
                this.pictureBox2.Image = myImage;
                this.pictureBox2.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
