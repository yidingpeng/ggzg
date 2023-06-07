using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{

    /// <summary>
    /// 物料/零件配料明细表，必换件、偶换件配料业务明细表（线边库）
    /// </summary>
    public class FollowWlBatchDetailModel : BaseModel
    {

        /// <summary>
        /// ID主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 配料库房：0线边库：fw_guid； 1库房：mb_guid
        /// </summary>
        public int? warehouse { get; set; }

        /// <summary>
        /// 必换件、偶换件、部件配料业务主表GUID， follow_WlBatchMain.FW_GUID
        /// </summary>
        public Guid? fw_guid { get; set; }

        /// <summary>
        /// 库房批量配必换件主表GUID
        /// </summary>
        public Guid? mb_guid { get; set; }

        /// <summary>
        /// 物料/零件ID，取物料/零件表 base_wuliao
        /// </summary>
        public int? fwd_wlLJid { get; set; }

        /// <summary>
        /// 物料/零件名称
        /// </summary>
        public string fwd_wlLJName { get; set; }

        /// <summary>
        /// 物料/零件规格ID，取物料/零件规格表 base_wuliaoModel
        /// </summary>
        public int? fwd_wlModelID { get; set; }

        /// <summary>
        /// 物料/零件规格
        /// </summary>
        public string fwd_wlLJModel { get; set; }

        /// <summary>
        /// 物料序列号，没有可不填
        /// </summary>
        public string fwd_wlCodeNo { get; set; }

        /// <summary>
        /// 零部件类型（必换件、偶换件），0:其他；1：必换件; 2：偶换件；3：组件 
        /// </summary>
        public int? fwd_replaceType { get; set; }

        /// <summary>
        /// 是否为关键零件部件,0:否；1:是
        /// </summary>
        public int? fwd_isKeyLJ { get; set; }

        /// <summary>
        /// 配料结果:-1:空；0:未配；1：已配；2：缺料
        /// </summary>
        public int? fwd_batchResult { get; set; }

        /// <summary>
        /// 需配数量
        /// </summary>
        public int? fwd_replaceQty { get; set; }

        /// <summary>
        /// 已配数量
        /// </summary>
        public int? fwd_batchQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string fwd_remark { get; set; }


        #region follow_WlBatchMain 表

        /// <summary>
        /// 部件ID
        /// </summary>
        public int? fw_partId { get; set; }

        /// <summary>
        /// 条码卡号
        /// 需要带出 follow_WlBatchMain 表中 条码卡号进行判断是否为空 选择工位后需要清空条码卡信息
        /// </summary>
        public string fw_barcode { get; set; }

        #endregion



    }
}
