using System.Configuration;

namespace RW.PMS.WebApi
{
    public class TDMHelper
    {
        public static string GetMD5(string pwd)
        {
            return RW.Security.MD5Helper.GetMD5(ConfigurationManager.AppSettings["PwdHash"] + pwd);
        }
    }
}