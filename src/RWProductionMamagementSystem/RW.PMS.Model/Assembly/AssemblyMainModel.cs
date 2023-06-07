using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Assembly
{
    /// <summary>
    /// 生产关键信息主表
    /// </summary>
    public partial class AssemblyMainModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public Guid? am_guid { get; set; }

        /// <summary>
        /// 所属分装条码
        /// </summary>
        public string am_parentQRCode { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string pName { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int pInfo_ID { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string pf_prodNo { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int pModelID { get; set; }

        /// <summary>
        ///产品型号型号
        /// </summary>
        public string PModel { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int am_gwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string am_gwName { get; set; }

        /// <summary>
        /// 工位编码
        /// </summary>
        public string am_gwCode { get; set; }

        /// <summary>
        /// 关联二维码
        /// </summary>
        public string am_QRcode { get; set;}

        /// <summary>
        /// 关联产品时间
        /// </summary>
        public DateTime? am_pInfoDate { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime am_createDate { get; set;}

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime am_updateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string am_createUser { get; set;}

        /// <summary>
        /// 更新人
        /// </summary>
        public string am_updateUser { get; set; }

        /// <summary>
        /// 创建时间 格式化显示
        /// </summary>
        public string am_createDateStr
        {
            get
            {
                return am_createDate.ToString("yyyy-MM-dd HH:mm");
            }
        }

        // <summary>
        /// 更新时间 格式化显示
        /// </summary>
        public string am_updateDateStr
        {
            get
            {
                return am_updateDate.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public List<AssemblyMainRecordModel> Details { get; set; }
    }
}
