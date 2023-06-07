using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace RW.PMS.Utils.EventLog
{
    /// <summary>
    /// 事件日志记录帮助类
    /// </summary>
    public class EventLogHelper
    {
        static IEventLog instance = null;
        static EventLogHelper()
        {
            instance = new FileEventLog();
        }

        public static void Log(string message)
        {
            Log(EventLogType.Normal, "System", message);
        }

        public static void Log(EventLogType type, string message)
        {
            Log(type, "System", message);
        }

        public static void Log(EventLogType type, string username, string message)
        {
            EventLog log = new EventLog();
            log.ErrorLogType = type;
            log.Message = message;
            log.Username = username;
            log.EventDateTime = DateTime.Now;
            Log(log);
        }

        public static void Log(EventLog log)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    instance.Write(log);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            });
        }

        /// <summary>
        /// 清空所有的事件日志
        /// </summary>
        public static void Clear()
        {
            instance.ClearAll();
        }

        /// <summary>
        /// 获取所有的事件日志
        /// </summary>
        /// <returns></returns>
        public static List<EventLog> GetAll()
        {
            return instance.GetAll();
        }

    }
}
