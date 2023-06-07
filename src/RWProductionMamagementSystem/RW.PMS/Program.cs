using FSLib.App.SimpleUpdater;
using Newtonsoft.Json;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Sys;
using RW.PMS.WinForm.Common;
using RW.PMS.WinForm.Sockets;
using RW.PMS.WinForm.UI;
using RW.PMS.WinForm.UI.Assembly;
using RW.PMS.WinForm.UI.Device;
using RW.PMS.WinForm.UI.Follow;
using RW.PMS.WinForm.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Threading;  
using System.Windows.Forms;
using System.Xml;

namespace RW.PMS.WinForm
{ 
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 扭力扳手测试窗体
            //FrmSocketTest f = new FrmSocketTest();
            //f.ShowDialog();
            //System.Environment.Exit(0);
            #endregion
            

            #region 重复启动判断
            bool createdNew;
            Mutex instance = new Mutex(true, "MutexName", out createdNew);
            if (!createdNew)
            {
                RWMessageBox.Show("程序已启动,请不要重复打开程序！！！");
                GC.Collect();
                Environment.Exit(0);
            }
            #endregion

            #region 服务器连接测试
            //string ServerIPAddress = ConfigurationManager.AppSettings["ServerIPAddress"];
            //bool bPing = true;
            //if (ServerIPAddress != null)
            //    bPing = NetworkHelper.Ping(ServerIPAddress);
            //if (!bPing)
            //{
            //    RWMessageBox.Show("服务器连接失败,请检查您的网络连接是否正常！！！");
            //    GC.Collect();
            //    Environment.Exit(0);
            //}
            #endregion

            #region 自动更新

            //var updateAddress = ConfigurationManager.AppSettings["SysUpdate"];
            //if (!string.IsNullOrWhiteSpace(updateAddress))
            //{
            //    var updater = Updater.CreateUpdaterInstance(updateAddress, "update_c.xml");

            //    updater.Error += (sender, args) =>
            //    {
            //        MessageBox.Show("自动更新错误提醒：" + updater.Context.Exception.Message);
            //    };
            //    updater.MinmumVersionRequired += (sender, args) =>
            //    {
            //        MessageBox.Show("自动更新版本提醒：" + updater.Context.Exception?.Message);
            //    };

            //    updater.BeginCheckUpdateInProcess();
            //}

            #endregion

            #region 设备提醒
            //获取过期工具数量,若数量>0打开设备提醒窗体
            //PublicVariable.DevExpireIsAssembly = true;
            //IBLL_Device devBLL = DIService.GetService<IBLL_Device>();
            //int ExpireCount = devBLL.GetToolsRemindCount(PublicVariable.LocalIP).Count;
            //if (ExpireCount > 0)
            //    new FrmDeviceRemind().ShowDialog();
            #endregion

            #region 设备保养提醒

            //int DevicePlanCount = devBLL.GetToolsRemindCount(PublicVariable.LocalIP).Count;
            //if (ExpireCount > 0)
            //    new FrmDeviceRemind().ShowDialog();

            #endregion

            #region 打开登录窗体

            FrmLogin frmLogin = new FrmLogin();//登录
            DialogResult result = frmLogin.ShowDialog();
            if (result != DialogResult.OK)
            {
                GC.Collect();
                Environment.Exit(0);
            }
            string msg = PublicVariable.GetInitForm();//初始化公共变量
            if (!string.IsNullOrEmpty(msg))
            {
                RWMessageBox.Show(msg);
                GC.Collect();
                Environment.Exit(0);
            }
            PublicVariable.CurEmpID = frmLogin.EmpID;
            PublicVariable.CurEmpName = frmLogin.EmpName;
            PublicVariable.IsAdmin = frmLogin.IsAdmin;

            #endregion

            bool getForm = SysConfig.GtInitForm(out msg);

            #region 添加考勤记录
            //PublicVariable.AddLoginInfo(new LoginInfoModel
            //{
            //    empID = frmLogin.EmpID,
            //    empName = frmLogin.EmpName,
            //    logintime = PublicVariable.GetServerTime(),
            //    hostName = PublicVariable.CurGwName
            //});
            #endregion

            #region 打开追溯及装配系统

            //如果为组装区、总装区，则有装配系统打开装配系统，无装配系统打开追溯系统
            //if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.assemblyArea.ToString() || PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.ZassemblyArea.ToString())
            //{
            //    //否则在启动装配系统
            //    Application.Run(new FrmMain());
            //}
            //else
            //{
            //    Application.Run(new FrmPartPlan());
            //}

            //否则在启动装配系统
            Application.Run(new Main());
            instance.ReleaseMutex();

            System.Environment.Exit(0);

            //Application.Run(new Main());
            //instance.ReleaseMutex();

            //System.Environment.Exit(0);

            //Application.Run(new FrmSocket());
            //instance.ReleaseMutex();

            //System.Environment.Exit(0);
            #endregion
        }
    }
}