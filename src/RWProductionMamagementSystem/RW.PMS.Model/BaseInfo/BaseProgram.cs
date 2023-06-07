using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 程序表
    /// </summary>
    public class BaseProgram : BaseModel
    {

        /// <summary>
        /// gw_prod_def表id   2019/05/17
        /// </summary>
        public int? gw_prod_defId { get; set; }
        /// <summary>
        /// 产品型号id
        /// </summary>
        public int Pmodel { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 程序名
        /// </summary>
        public string ProgName { get; set; }
        /// <summary>
        /// 工位
        /// </summary>
        public int? GWID { get; set; }
        /// <summary>
        /// 文件编号
        /// </summary>
        public string FileNo { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string CopyRight { get; set; }
        /// <summary>
        /// 程序描述
        /// </summary>
        public string Descript { get; set; }
        /// <summary>
        /// 程序视频
        /// </summary>
        public string ProgVideo { get; set; }
        /// <summary>
        /// 程序视频名称
        /// </summary>
        public string ProgVideoFilename { get; set; }
        /// <summary>
        /// 状态0:正常；1：禁用
        /// </summary>
        public int? ProgStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
