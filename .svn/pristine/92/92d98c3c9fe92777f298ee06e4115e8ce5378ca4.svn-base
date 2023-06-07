using RW.PMS.Common;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace RW.PMS.WinForm
{
    /// <summary>
    /// 网络帮助类
    /// </summary>
    public static class NetworkHelper
    {
        /// <summary>
        /// 获取本机IP地址（IPv4）
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            try
            {
                //如果设置了IP
                var value = ConfigurationManager.AppSettings["LocalIPAddress"];
                if (!string.IsNullOrEmpty(value))
                {
                    return value;
                }
                string strUnconventional = ConfigurationManager.AppSettings["UnconventionalGetIPLogic"];
                string LANip = PublicVariable.SystemBll.GetConfigByCode("LANIP").cfg_value;//局域网前缀 192.168.0.
                if (string.IsNullOrEmpty(LANip)) return "";
                IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());

                foreach (IPAddress ips in ipe.AddressList)
                {
                    if (ips.AddressFamily != AddressFamily.InterNetwork)
                        continue;
                    string strIP = ips.ToString();
                    if (!strIP.Contains(LANip))
                        continue;
                    if (string.IsNullOrEmpty(strUnconventional))
                    {
                        string[] ipList = strIP.Split('.');
                        int length = ipList.Length;
                        int last = ipList[length - 1].ToInt();
                        if (last >= 20 && last < 100)
                        {
                            return strIP;
                        }
                    }
                    else
                    {
                        return strIP;
                    }
                }
            }
            catch { }
            return "";
        }

        /// <summary>
        /// PING某IP
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="timeout">超时时间(秒)</param>
        /// <returns>是否PING通</returns>
        public static bool Ping(string ipAddress = "192.168.2.11", int timeout = 3)
        {
            try
            {
                using (Ping pingIp = new Ping())
                {
                    timeout = timeout * 1000;//timeout时间单位转毫秒
                    PingReply reply = pingIp.Send(ipAddress, timeout);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 查看是否能PING通服务器地址
        /// </summary>
        /// <param name="pingMsg"></param>
        /// <param name="ipAddress"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool Ping(out string pingMsg, string ipAddress = "192.168.2.11", int timeout = 3)
        {
            try
            {
                using (Ping pingIp = new Ping())
                {
                    timeout = timeout * 1000;//timeout时间单位转毫秒
                    PingReply reply = pingIp.Send(ipAddress, timeout);
                    if (reply.Status == IPStatus.Success)
                    {
                        StringBuilder sbuilder = new StringBuilder();
                        sbuilder.Append("Address: " + reply.Address.ToString() + " \n\r");
                        sbuilder.Append("RoundTrip time: " + reply.RoundtripTime.ToString() + "ms \n\r");
                        sbuilder.Append("Time to live: " + reply.Options.Ttl + " \n\r");
                        sbuilder.Append("Don't fragment: " + reply.Options.DontFragment + " \n\r");
                        sbuilder.Append("Buffer size: " + reply.Buffer.Length + " \n\r");
                        pingMsg = sbuilder.ToString();
                        return true;
                    }
                    else
                    {
                        StringBuilder sbuilder = new StringBuilder();
                        sbuilder.Append("Address: " + ipAddress + " \n\r");
                        sbuilder.Append("Status: " + reply.Status.ToString() + " \n\r");
                        pingMsg = sbuilder.ToString();
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                pingMsg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 下载视频
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static string DownLoadFiles(string fileName, string httpAddress, bool overwrite = false)
        {
            var message = string.Empty;
            try
            {
                var dir = Path.GetDirectoryName(fileName);
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                using (WebClient webClient = new WebClient())
                {
                    if (overwrite && File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                    if (!httpAddress.StartsWith("http://"))
                    {
                        httpAddress = @"http://" + httpAddress;
                    }
                    webClient.DownloadFile(httpAddress, fileName);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
