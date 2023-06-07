using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Sys
{
    public class SysexeFileUpdateModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int fID{ get; set;}

        /// <summary>
        /// 上传文件名
        /// </summary>
        public string filesName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string fileType { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string versionNuber { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime? uploadTime { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string filePath { get; set; }

        // <summary>
        /// 版本号
        /// </summary>
        public string remark { get; set; }

    }
}
