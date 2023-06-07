using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace RW.PMS.WebApi.Controllers
{
    public class SysUpdateController : ApiController
    {
        //
        // GET: /SystemUpdate/{fileName}

        /// <summary>
        /// 系统更新
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Update(string fileName)
        {
            var dir = ConfigurationManager.AppSettings["SysUpdateDir"];
            var filePath = Path.Combine(dir,fileName);
            var file = default(FileStream);

            var response = new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.NotFound;
            if (File.Exists(filePath))
            {
                file = File.OpenRead(filePath);
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StreamContent(file);
            }

            return response;
        }

    }
}
