using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 条形码卡使用记录表
    /// </summary>
    public class FollowBarcodeLogModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 追溯主表GUID
        /// </summary>
        public Guid? Fm_guid { get; set; }
        /// <summary>
        /// 追溯工位GUID
        /// </summary>
        public Guid? Fgw_guid { get; set; }
        /// <summary>
        /// 追溯明细GUID
        /// </summary>
        public Guid? Fd_guid { get; set; }
        /// <summary>
        /// 产品生产（组装、检修）主表GUID，production.fp_guid
        /// </summary>
        public Guid? Fp_guid { get; set; }
        /// <summary>
        /// 当前大部件钢印号/阀编码
        /// </summary>
        public string Fm_StampNo { get; set; }

        public int? Fm_prodModelID { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? Fd_gwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string Fd_gwName { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? Fd_areaID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Fd_areaName { get; set; }
        /// <summary>
        /// 物料/零件ID
        /// </summary>
        public int? Fd_wuliaoLJid { get; set; }
        /// <summary>
        /// 物料/零件名称
        /// </summary>
        public string Fd_wuliaoLJName { get; set; }
        /// <summary>
        /// 是否为物料盒
        /// </summary>
        public int? Fd_isWuliaoBox { get; set; }
        /// <summary>
        /// 操作员ID
        /// </summary>
        public int? Fd_operID { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string Fd_oper { get; set; }
        /// <summary>
        /// 保存时间
        /// </summary>
        public DateTime? Fd_createtime { get; set; }
        /// <summary>
        /// 条形码,编码唯一
        /// </summary>
        public string C_cardNo { get; set; }
        /// <summary>
        /// 卡类型
        /// </summary>
        public int? C_cardType { get; set; }
        /// <summary>
        ///卡状态：0启用；1禁用
        /// </summary>
        public int? C_status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string C_remark { get; set; }

        public int? c_partId { get; set; }

        public string c_partName { get; set; }

        #region 文本值和所需要的字段
        /// <summary>
        /// 产品型号文本值
        /// </summary>
        public string ProdModel { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public string Starttime { get; set; }
        /// <summary>
        /// 结束日期
        /// </summary>
        public string Endtime { get; set; }

        #endregion
    }
}
