using System.IO;
using System.Web;

namespace RW.PMS.Common
{
    public static class RequestHelper
    {
        public static string GetUsername()
        {
            return HttpContext.Current.User.Identity.Name;
        }

        public static string GetIP()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        public static string GetUserAgent()
        {
            return HttpContext.Current.Request.UserAgent;
        }

        public static string GetResponse()
        {
            var resp = HttpContext.Current.Response;
            System.IO.TextWriter w = resp.Output;

            Stream stream = resp.OutputStream;

            stream.ReadByte();


            System.IO.StreamReader reader = new System.IO.StreamReader(stream);
            string text = reader.ReadToEnd();

            
            reader.Close();
            return text;
        }
    }
}
