using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace RW.PMS.Utils
{
    public static class SystemHelper
    {
        public static void KillProcess(string processName)
        {
            try
            {
                Process[] ps = Process.GetProcessesByName("Excel");
                foreach (Process p in ps)
                {
                    p.Kill();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("关闭进程报错：");
                Debug.WriteLine(ex);
            }
            return;
        }

        /// <summary>
        /// 对于.NET4.5以下的版本，设置默认区域信息
        /// 主要作用于多线程时的语言环境修改。
        /// </summary>
        /// <param name="culture"></param>
        public static void SetDefaultCulture(CultureInfo culture)
        {
            Type type = typeof(CultureInfo);

            //4.0版本设置
            try
            {
                type.InvokeMember("s_userDefaultCulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });

                type.InvokeMember("s_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }
            //4.0以下版本设置
            try
            {
                type.InvokeMember("m_userDefaultCulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });

                type.InvokeMember("m_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }
        }

        /// <summary>
        /// 修改系统语言，包含线程当前语言。系统默认语言，支持多线程。
        /// </summary>
        /// <param name="culture"></param>
        public static void ChangeLanguage(CultureInfo culture)
        {
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            SetDefaultCulture(culture);
        }
    }
}
