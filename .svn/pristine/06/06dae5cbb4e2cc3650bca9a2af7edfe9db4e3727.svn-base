using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using sysEntity = RW.PMS.Model.Sys;
using RW.PMS.Common;
using RW.PMS.IBLL;
using baseEnty = RW.PMS.Model.BaseInfo;
using System.Reflection;
using RW.PMS.Utils;
using RW.PMS.Model.Sys;

namespace RW.PMS.WinForm
{

    public static class SysConfig
    {
        public static IBLL_System SystemBll = DIService.GetService<IBLL_System>();
        public static IBLL_BaseInfo BaseBLL = DIService.GetService<IBLL_BaseInfo>();
        public static IBLL_Device DevBLL = DIService.GetService<IBLL_Device>();
        public static baseEnty.BaseGongweiModel GWModel = new baseEnty.BaseGongweiModel();

        /// <summary>
        /// 登录ID
        /// </summary>
        public static int LoginId { get; private set; }
        /// <summary>
        /// 当前登陆人ID
        /// </summary>
       // public static int CurEmpID { get; set; }

        /// <summary>
        /// 当前区域ID
        /// </summary>
        public static int CurAreaID { get; private set; }

        /// <summary>
        /// 当前区域名称
        /// </summary>
        public static string CurAreaName { get; private set; }
        /// <summary>
        /// 当前工位ID
        /// </summary>
        public static int CurGwID { get; private set; }

        /// <summary>
        /// 当前工位名称
        /// </summary>
        public static string CurGwName { get; private set; }

        /// <summary>
        /// 当前登陆人
        /// </summary>
        //public static string CurEmpName { get; set; }
        /// <summary>
        /// 是否为管理员
        /// </summary>
        //public static bool IsAdmin { get; set; }

        /// <summary>
        /// 当前区域编码
        /// </summary>
        public static string CurAreaBDCode { get; private set; }

        /// <summary>
        /// 本地IP地址
        /// </summary>
        public static string LocalIP { get; private set; }

        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public static string ServerIP { get; private set; }
        /// <summary>
        /// 服务器端口号
        /// </summary>
        public static string ServerPort { get; private set; }

        /// <summary>
        /// 获取ping服务器的时间间隔
        /// </summary>
        public static int PingServerTimer { get; private set; }

        /// <summary>
        /// 获取PLC状态地址
        /// </summary>
        public static string PLCTag { get; private set; }

        /// <summary>
        /// 获取工步跳转时间
        /// </summary>
        public static int GBStepTimer { get; private set; }


        /// <summary>
        ///装配系统的工位机是否有三色灯 
        /// </summary>
        public static bool IsGwHasThreeLight { get; private set; }

        /// <summary>
        /// 获取峰鸣器鸣响时间
        /// </summary>
        public static int ErrorTimer { get; private set; }

        /// <summary>
        /// 管控方式
        /// </summary>
        public static List<BaseDataModel> ControlTypes { get; private set; }

        /// <summary>
        /// 保存设备运行信息, 是否启用工控机设备功能，0：不启用；1：启用
        /// </summary>
        public static bool IsUseGwDevice { get; private set; }


        /// <summary>
        /// 是否为自动运行
        /// </summary>

        public static bool IsAutoRunSetup { get; private set; }

        /// <summary>
        /// 表示托盘编号在opc点位上的4位编码 ，用于常州铁马项目
        /// </summary>
        //public static string[] SalverOPCTags { get; private set; }

        /// <summary>
        /// 获取设备到期提醒天数
        /// </summary>
        public static int RemindDayCount()
        {
            try
            {
                string DevIP = NetworkHelper.GetLocalIP();
                return DevBLL.GetToolsRemindCount(DevIP).Count();
            }
            catch (Exception ex)
            {
                RW.PMS.Common.Logger.Logger.Default.Error("获取设备到期提醒天数出错！", ex.Message);
            }
            return 0;
        }

        public static bool GtInitForm(out string msg)
        {
            LocalIP = NetworkHelper.GetLocalIP();
            //LocalIP = "192.168.0.208";
            if (string.IsNullOrEmpty(LocalIP))
            {
                msg = "未获取本机IP";
                return false;
            }
            else
            {
                baseEnty.BaseGongweiModel gw = BaseBLL.getGwByIP(LocalIP);

                if (gw == null)
                {
                    msg = "未获取到IP的工位信息，请检查工位信息设置！";
                    return false;
                }
                if (!gw.areaID.HasValue)
                {
                    msg = "未获取到区域信息，请检查工位信息设置！";
                    return false;
                }
                CurAreaID = ConvertHelper.ToInt32(gw.areaID, 0);

                CurGwID = ConvertHelper.ToInt32(gw.ID, 0);

                CurGwName = gw.gwname;

                CurAreaName = gw.areaName;

                CurAreaBDCode = gw.areaCode;

                GWModel = BaseBLL.getEntyGwByID(CurGwID);

                DateTime dt = DateTime.Now;

                if (SysConfig.CurAreaID == 0 ||
                    SysConfig.CurGwID == 0 ||
                    string.IsNullOrEmpty(SysConfig.CurAreaName) ||
                    string.IsNullOrEmpty(SysConfig.CurGwName) ||
                    string.IsNullOrEmpty(SysConfig.CurAreaBDCode))
                {

                    msg = "本工位信息设置错误，未设置区域或工位名称";
                    return false;
                }

                
            }
            msg = string.Empty;
            return true;
        }

        /// <summary>
        /// 获取服务器系统时间，如未获取到服务器时间使用系统时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            try 
            {
                var systime = SystemBll.GetDateTime();

                string nowtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                return ConvertHelper.ToDateTime(systime.ToString(), Convert.ToDateTime(nowtime));
            }
            catch (Exception ex)
            {
                return Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSysConfig(string code)
        {

            var model = SystemBll.GetConfigByCode(code);
            if (model != null)
            {
                return model.cfg_value;
            }

            return string.Empty;
        }

        static SysConfig()
        {
            ControlTypes = SystemBll.GetBaseDataTypeValue("ControlType");

            ServerIP = GetSysConfig("ServerIP");

            ServerPort = GetSysConfig("ServerPort");

            PingServerTimer = ConvertHelper.ToInt32(int.Parse(GetSysConfig("pingServerTimer")), 10);

            PLCTag = GetSysConfig("PLCTag");

            IsUseGwDevice = ConvertHelper.ToInt32(GetSysConfig("isUseGwDevice"), 0) == 1;

            GBStepTimer = ConvertHelper.ToInt32(GetSysConfig("gbStepTimer"), 2);

            //var tags = SysConfig.GetSysConfig("SalverOPCTags");

            //SalverOPCTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var isSalverBarcodeProductNo = GetSysConfig("isSalverBarcodeProductNo");

            var salverWaitTimeVal = 5;

            var salverWaitTime = GetSysConfig("SalverWaitTime").Trim();

            int.TryParse(salverWaitTime, out salverWaitTimeVal);

            var isAutoRunSetup = 0;

            ErrorTimer = ConvertHelper.ToInt32(ConvertHelper.ToDecimal(GetSysConfig("cfg_errorTimer"), 0.1m) * 1000, 1000);

            if (int.TryParse(GetSysConfig("AutoRunSetup"), out isAutoRunSetup))
            {
                IsAutoRunSetup = isAutoRunSetup == 0 ? false : true;
            }
        }

        internal static void DeviceRun()
        {
            if (IsUseGwDevice)
            {
                DIService.GetService<IBLL_Assembly>().DeviceRun(LocalIP);
            }
        }

      
    }
}
