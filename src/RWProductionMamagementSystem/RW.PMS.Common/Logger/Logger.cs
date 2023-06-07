using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace RW.PMS.Common.Logger
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class Logger
    {
        #region 初始化
        /// <summary>
        /// 日事件间类
        /// </summary>
        private LogEventInfo _logEventInfo = new LogEventInfo();
        /// <summary>
        /// 数据错误无法获取用户时使用
        /// </summary>
        public static string UserName = string.Empty;
        /// <summary>
        /// 默认IP地址
        /// </summary>
        public static string IPAddress = "127.0.0.1";

        /// <summary>
        /// 应用名称
        /// </summary>
        public static string AppName = string.Empty;
        /// <summary>
        /// 提供日志接口和实用程序功能
        /// </summary>
        private  NLog.Logger _logger = null;
        /// <summary>
        /// 自定义日志对象供外部使用
        /// </summary>
        public static Logger Default { get; private set; }
         
        private Logger(NLog.Logger logger)
        {

             DBConfig(logger);

            _logger = logger;
        }

        public Logger(string name) : this(LogManager.GetLogger(name))
        { }
       
        static Logger()
        {
            //获取具有当前类名称的日志程序。
            Default = new Logger("Logger");
        }

        private void DBConfig(NLog.Logger logger) 
        {
            var dbTarget = logger.Factory.Configuration.AllTargets.Where(f => f.Name == "logDB_wrapped").FirstOrDefault() as DatabaseTarget;
            if (dbTarget != null)
            {
                var connectionString = dbTarget.ConnectionString.ToString();
                var decryptAndEncryptHelper = new DecryptAndEncryptHelper();
                connectionString = decryptAndEncryptHelper.Decrypto(connectionString.Replace("'",""));
                dbTarget.ConnectionString = connectionString;
            }
        }

        #endregion 

        public void Debug(string msg, params object[] args)
        {
            var message = string.Empty;
            if (args != null)
            {
                message = string.Format(msg, args);
            }
            InsLog(LogLevel.Debug, message);
        }

        public void Info(string msg, params object[] args)
        {
            var message = string.Empty;
            if (args != null)
            {
                message = string.Format(msg, args);
            }
            InsLog(LogLevel.Info, message);
        }

        /// <summary>
        ///警告
        /// </summary>
        /// <param name="msg">警告信息</param>
        /// <param name="args">动态参数</param>
        public void Warn(string msg, params object[] args)
        {
            var message = string.Empty;
            if (args != null)
            {
                message = string.Format(msg, args);
            }
            InsLog(LogLevel.Warn, message);
        }

        /// <summary>
        /// 使用指定的参数在跟踪级别写入诊断消息
        /// </summary>
        /// <param name="msg">跟踪信息</param>
        /// <param name="args">动态参数</param>
        public void Trace(string msg, params object[] args)
        {
            var message = string.Empty;
            if (args != null)
            {
                message = string.Format(msg, args);
            }
            InsLog(LogLevel.Trace, message);
        }

        #region Error
        /// <summary>
        /// 使用指定的参数在错误级别写入诊断消息。
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <param name="args">动态参数</param>
        public void Error(string msg, params object[] args)
        {
            var message = string.Empty;
            if (args != null)
            {
                message = string.Format(msg, args);
            }
            InsLog(LogLevel.Error, message);
        }
        /// <summary>
        /// 使用指定的参数在错误级别写入诊断消息。
        /// </summary>
        /// <param name="msg">错误信息</param>
        /// <param name="args">异常信息</param>
        public void Error(string msg, Exception err)
        {
            InsLog(LogLevel.Error, msg, err);
        }
        #endregion

        //#region Fatal
        ///// <summary>
        ///// 使用指定的参数在致命级别写入诊断消息。
        ///// </summary>
        ///// <param name="msg">致命错误</param>
        ///// <param name="args">动态参数</param>
        //public void Fatal(string msg, params object[] args)
        //{
        //    var message = string.Empty;
        //    if (args != null)
        //    {
        //        message = string.Format(msg, args);
        //    }
        //    InsLog(LogLevel.Fatal, message);
        //}
        ///// <summary>
        ///// 使用指定的参数在致命级别写入诊断消息。
        ///// </summary>
        ///// <param name="msg">致命错误</param>
        ///// <param name="args">异常信息</param>
        //public void Fatal(string msg, Exception err)
        //{
        //    InsLog(LogLevel.Fatal, msg, err);
        //}
        ///// <summary>
        ///// 刷新所有挂起的日志消息(在异步目标的情况下)。
        ///// </summary>
        ///// <param name="timeoutMilliseconds">最大的时间允许冲洗。此后的任何消息都将被丢弃。</param>
        //public void Flush(int? timeoutMilliseconds = null)
        //{
        //    if (timeoutMilliseconds != null)
        //    {
        //        NLog.LogManager.Flush(timeoutMilliseconds.Value);
        //    }

        //    NLog.LogManager.Flush();
        //}
        //#endregion

        #region 日志写入

        /// <summary>
        /// 写入日志信息
        /// </summary>
        private void InsLog(LogLevel level, string msg, Exception ex = null)
        {
            var stackTrace = string.Empty;
            if (ex != null)
            {
                stackTrace = string.Format("StackTrace:{0},Message:", ex.StackTrace);
                var exception = ex;
                do
                {
                    stackTrace += exception.Message;
                    exception = exception.InnerException;

                } while (exception != null);
            }

            _logEventInfo.Properties["AppName"] = AppName;
            _logEventInfo.Properties["IP"] = IPAddress;
            _logEventInfo.Properties["UserName"] = UserName;
            _logEventInfo.Level = level;
            _logEventInfo.Message = stackTrace + msg;
            _logEventInfo.Exception = ex;

            _logger.Log(_logEventInfo);
        }

        #endregion 
    }

}
