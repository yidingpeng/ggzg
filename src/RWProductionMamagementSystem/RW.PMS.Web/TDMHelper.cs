using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace RW.PMS.Web
{
    /// <summary>
    /// 上传文件的帮助类
    /// </summary>
    public static class TDMHelper
    {
        static string root = ConfigurationManager.AppSettings["UploadPath"];

        /// <summary>
        /// 获取上传文件的路径，可指定类型文件夹和文件可选
        /// </summary>
        /// <param name="section">类型文件夹，自动创建文件夹</param>
        /// <param name="filename">可选的文件名</param>
        /// <returns></returns>
        public static string GetUploadPath(string section, string filename = null)
        {
            string path = HttpContext.Current.Server.MapPath(root + "\\" + section + "\\");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path + filename;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static string GetMD5(string pwd)
        {
            return RW.Security.MD5Helper.GetMD5(ConfigurationManager.AppSettings["PwdHash"] + pwd);
        }
    }
}