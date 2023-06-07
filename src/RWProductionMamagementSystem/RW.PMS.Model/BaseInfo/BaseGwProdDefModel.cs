using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 工位产品型号关联配置
    /// </summary>
    public class BaseGwProdDefModel : BaseModel
    {

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int? gwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string GwName { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? prodModelID { get; set; }
        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string ProdModelName { get; set; }

        /// <summary>
        /// 组件ID,base_wuliao.ID 
        /// </summary>
        public int? componentID { get; set; }

        /// <summary>
        /// 组件名称
        /// </summary>
        public string ComponentName { get; set; }

        /// <summary>
        /// 程序ID,base_program.ID
        /// </summary>
        public int? progID { get; set; }

        /// <summary>
        /// 程序名称
        /// </summary>
        public string ProgName { get; set; }

        /// <summary>
        /// 生产节拍分钟数
        /// </summary>
        public int? beatMinite { get; set; }

        /// <summary>
        /// 所属工序
        /// </summary>
        public int? operationID { get; set; }

        /// <summary>
        /// 所属工序名称
        /// </summary>
        public string operationName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 条码卡ID
        /// </summary>
        public int? c_id { get; set; }

        /// <summary>
        /// 条码卡号
        /// </summary>
        public string c_cardNo { get; set; }

        /// <summary>
        /// 部件编码
        /// </summary>
        public string c_curStampNo { get; set; }

        /// <summary>
        /// 当前工位ID
        /// </summary>
        public int? c_curGwID { get; set; }
    }
}
