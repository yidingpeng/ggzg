using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{

    /// <summary>
    /// 配料明细表
    /// </summary>
    public class WmsBatchingDetailModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int wbd_ID { get; set; }

        /// <summary>
        /// 库房批量配必换件主表GUID
        /// </summary>
        public Guid? wb_guid { get; set; }

        /// <summary>
        /// 物料/零件ID，取物料/零件表 base_wuliao
        /// </summary>
        public int? wbd_wlLJid { get; set; }

        public string wbd_wlLJName { get; set; }

        /// <summary>
        /// 物料/零件规格ID，取物料/零件规格表 base_wuliaoModel
        /// </summary>
        public int? wbd_wlModelID { get; set; }

        public string wbd_wlModelName { get; set; }

        /// <summary>
        /// 物料序列号，没有可不填
        /// </summary>
        public string wbd_wlCodeNo { get; set; }

        /// <summary>
        /// 需配数量
        /// </summary>
        public int? wbd_replaceQty { get; set; }

        /// <summary>
        /// 已配数量
        /// </summary>
        public int? wbd_batchQty { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string wbd_remark { get; set; }


        #region WmsBatchingMainModel 配料单主表

        /// <summary>
        /// 申请单号，系统自动生成，规则为日期yyyyMMdd_编号(2位）
        /// </summary>
        public string wb_code { get; set; }

        /// <summary>
        /// 计划主表GUID
        /// </summary>
        public Guid? pp_guid { get; set; }

        /// <summary>
        /// 领料单主表ID wms_requisitionmain.Iv_guid
        /// </summary>
        public Guid? Iv_guid { get; set; }

        /// <summary>
        /// 配料类型. 1:计划配料 2:领料配料 3.其他配料
        /// </summary>
        public int? wb_typeID { get; set; }

        /// <summary>
        /// 物料盒的条码卡的ID
        /// </summary>
        public int? wb_BarCodeID { get; set; }
     
        /// <summary>
        /// 来源仓库ID（1 线边库；2 库房）
        /// </summary>
        public int? wb_SWID { get; set; }

        /// <summary>
        /// 目标仓库ID（1 线边库；3 工位） 
        /// </summary>
        public int? wb_TWID { get; set; }

        /// <summary>
        /// 配料员，employee.ID
        /// </summary>
        public int? wb_operID { get; set; }

        public string wb_operName { get; set; }

        /// <summary>
        /// 配料时间
        /// </summary>
        public DateTime? wb_batchtime { get; set; }

        /// <summary>
        /// 配送时间
        /// </summary>
        public DateTime? wb_dispatchTime { get; set; }

        /// <summary>
        /// 接收员，employee.ID
        /// </summary>
        public int? wb_receiveID { get; set; }

        public string wb_receiveName { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime? wb_createtime { get; set; }

        /// <summary>
        /// 状态：1.已配料 2.已配送 3.已接收 //4.已退回
        /// </summary>
        public int? wb_status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string wb_remark { get; set; }


        #endregion


        /// <summary>
        /// 计划表 计划数量
        /// </summary>
        public int pp_planQty { get; set; }


        /// <summary>
        /// 产品型号
        /// </summary>
        public int? pp_prodModelID { get; set; }

        /// <summary>
        /// 用于显示条码卡号
        /// </summary>
        public string c_cardNo { get; set; }

    }
}
