using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RW.PMS.WinForm
{
    /// <summary>
    /// 公共变量
    /// </summary>
    public static class PublicVariable
    {
        public static IBLL_System SystemBll = DIService.GetService<IBLL_System>();
        public static IBLL_BaseInfo BaseBLL = DIService.GetService<IBLL_BaseInfo>();

        /// <summary>
        /// 工位信息实体类
        /// </summary>
        public static BaseGongweiModel GWModel { get; set; }


        /// <summary>
        /// 总装工位最大排序号
        /// </summary>
        public static int GWMaxSort { get; set; }

        /// <summary>
        /// 当前登陆人ID
        /// </summary>
        public static int CurEmpID { get; set; }

        /// <summary>
        /// 当前登陆人
        /// </summary>
        public static string CurEmpName { get; set; }

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
        /// 是否为管理员
        /// </summary>
        public static bool IsAdmin { get; set; }

        /// <summary>
        /// 当前区域编码
        /// </summary>
        public static string CurAreaBDCode { get; private set; }

        /// <summary>
        /// 上一区域ID
        /// </summary>
        public static int BeforeAreaID { get; set; }

        /// <summary>
        /// 上上一区域ID
        /// </summary>
        public static int BeBeforeAreaID { get; set; }

        static string localIP;
        /// <summary>
        /// 设备到期提醒
        /// </summary>
        public static bool IsDevExpire { get; set; }

        /// <summary>
        /// 设备到期是否允许进入装配
        /// </summary>
        public static bool DevExpireIsAssembly { get; set; }

        /// <summary>
        /// 本地IP地址
        /// </summary>
        public static string LocalIP
        {
            get
            {
                if (string.IsNullOrEmpty(localIP))
                    localIP = NetworkHelper.GetLocalIP();
                return localIP;
                //return "192.168.0.20";
            }
            private set { localIP = value; }
        }

        private static string serverIP;
        /// <summary>
        /// 服务器IP地址
        /// </summary>
        public static string ServerIP
        {
            get
            {
                if (string.IsNullOrEmpty(serverIP))
                {
                    //serverIP = GetSysConfig("ServerIP");
                    serverIP = ConfigurationManager.AppSettings["ServerIPAddress"];
                }
                return serverIP;
            }
            set { serverIP = value; }
        }

        private static int? isOriginalDismantling = null;

        /// <summary>
        /// 原拆原配标识 是否要求原拆原配，若是，则物料条码、组件条码要判断产品编号
        /// </summary>
        public static int IsOriginalDismantling
        {
            get
            {
                if (!isOriginalDismantling.HasValue)
                    isOriginalDismantling = GetSysConfig("isOriginalDismantling").ToInt();
                return isOriginalDismantling.Value;
            }
        }
        private static int? staticTestTime = null;
        /// <summary>
        /// 获取静制时间（小时）
        /// </summary>
        public static int StaticTestTime
        {
            get
            {
                if (!staticTestTime.HasValue)
                    staticTestTime = GetSysConfig("StaticTestTime").ToInt();
                return staticTestTime.Value;
            }
        }

        /// <summary>
        /// 获取初始窗体-初始化
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string GetInitForm()
        {
            try
            {
                //根据IP获取工位及区域
                BaseGongweiModel gw = BaseBLL.getGwByIP(LocalIP);
                //工位
                CurGwID = gw.ID;
                CurGwName = gw.gwname;
                GWModel = gw;
                //GWMaxSort = BaseBLL.getGwMaxOrder();
                //区域
                CurAreaID = gw.areaID.ToInt();
                CurAreaName = gw.areaName;
                CurAreaBDCode = gw.areaCode.Trim();
                //上一区域
                BeforeAreaID = SystemBll.GetBeforeAreaIDByCode(CurAreaBDCode);
                BaseDataModel beforeBDEnty = SystemBll.getBaseDataByID(BeforeAreaID);//上1区域实体
                //上上区域
                BeBeforeAreaID = SystemBll.GetBeforeAreaIDByCode(beforeBDEnty.bdcode);
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 获取服务器系统时间，如未获取到服务器时间使用系统时间
        /// yyyy-MM-dd HH:mm:ss 格式转时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetServerTime()
        {
            try
            {
                DateTime sysTime = SystemBll.GetDateTime();
                return sysTime;
            }
            catch
            {
                return Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        /// <summary>
        /// 获取服务器系统时间，如未获取到服务器时间使用系统时间
        /// </summary>
        /// <returns>yyyy年MM月dd日 星期几 问候语 HH:mm:ss 格式转时间</returns>
        public static string GetSystemDateTime()
        {
            try
            {
                DateTime sysTime = SystemBll.GetDateTime();
                return DateTimeSwitch(sysTime);
            }
            catch
            {
                return DateTimeSwitch(DateTime.Now);
            }
        }

        /// <summary>
        /// 时间日期 转换
        /// </summary>
        /// <param name="datatime"></param>
        /// <returns></returns>
        public static string DateTimeSwitch(DateTime datatime)
        {
            var year = datatime.Year;
            var month = datatime.Month;
            var day = datatime.Day;
            var hour = datatime.Hour;
            var minute = datatime.Minute;
            var second = datatime.Second;
            var week = datatime.DayOfWeek.ToString("d");
            var hourgreetings = "凌晨";//问候语
            var weekgreetings = "星期一";//周几
            switch (week)//转换星期格式
            {
                case "0": weekgreetings = "星期日"; break;
                case "1": weekgreetings = "星期一"; break;
                case "2": weekgreetings = "星期二"; break;
                case "3": weekgreetings = "星期三"; break;
                case "4": weekgreetings = "星期四"; break;
                case "5": weekgreetings = "星期五"; break;
                case "6": weekgreetings = "星期六"; break;
            }
            //转换问候语
            if (hour < 6) { hourgreetings = "凌晨"; }
            else if (hour < 9) { hourgreetings = "早上"; }
            else if (hour < 12) { hourgreetings = "上午"; }
            else if (hour < 14) { hourgreetings = "中午"; }
            else if (hour < 17) { hourgreetings = "下午"; }
            else if (hour < 19) { hourgreetings = "傍晚"; }
            else if (hour < 22) { hourgreetings = "晚上"; }
            else { hourgreetings = "夜里"; }
            //小时,分钟,秒如果小于10加上前导零
            return $"{year}年{ZeroFill(month)}月{ZeroFill(day)}日 {weekgreetings} {hourgreetings} {ZeroFill(hour)}:{ZeroFill(minute)}:{ZeroFill(second)}";
        }

        /// <summary>
        /// 个位 缺少补零
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static string ZeroFill(int Num)
        {
            if (Num < 10)
            {
                return $"0{Num}";
            }
            return Num.ToString();
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
                return model.cfg_value;
            return "";
        }

        /// <summary>
        /// 添加考勤信息
        /// </summary>
        /// <param name="loginModel"></param>
        internal static void AddLoginInfo(LoginInfoModel loginModel)
        {
            DIService.GetService<IBLL_System>().AddLoginInfo(loginModel);
        }

        /// <summary>
        /// 保存登出时间
        /// </summary>
        internal static void SaveLogoutTime()
        {
            //考勤记录录入登出时间
            int i = DIService.GetService<IBLL_System>().SaveLogoutTime(CurEmpID);
        }
    }
}