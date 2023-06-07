using log4net.Config;
using System.ServiceProcess;

namespace RW.PMS.WebSocketWinService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            XmlConfigurator.Configure();//初始化日志文件

            #region 服务
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new WebSocketService() 
            };
            ServiceBase.Run(ServicesToRun);
            #endregion
        }
    }
}
