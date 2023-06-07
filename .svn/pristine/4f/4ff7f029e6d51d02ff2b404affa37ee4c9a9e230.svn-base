using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.WinForm.Utils
{
    /// <summary>
    /// API帮助类
    /// </summary>
    public static class APIHelper
    {
        /// <summary>
        /// 调用API返回Json字符串
        /// </summary>
        /// <param name="url">API地址</param>
        /// <returns></returns>
        public static string HttpApi(string url)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
            request.Method = "GET";//get或者post
            request.Accept = "text/html,application/xhtml+xml,*/*";
            request.ContentType = "application/json";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
