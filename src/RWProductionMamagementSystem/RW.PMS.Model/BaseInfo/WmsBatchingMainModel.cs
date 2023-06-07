using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{

    /// <summary>
    /// 配料单主表
    /// </summary>
    public class WmsBatchingMainModel : BaseModel
    {

        /// <summary>
        /// 主表GUID
        /// </summary>
        public Guid wb_guid { get; set; }

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
        /// 配料类型
        /// </summary>
        public string wb_typeIDName
        {
            get
            {
                if (wb_typeID == 1) return "计划配料";
                if (wb_typeID == 2) return "领料配料";
                if (wb_typeID == 3) return "其他配料";
                return "";
            }
        }

        /// <summary>
        /// 来源仓库ID（1 线边库；2 库房）
        /// </summary>
        public int? wb_SWID { get; set; }

        /// <summary>
        /// 来源仓库
        /// </summary>
        public string wb_SWIDName
        {
            get
            {
                if (wb_SWID == 1) return "线边库";
                if (wb_SWID == 2) return "库房";
                return "";
            }
        }

        /// <summary>
        /// 目标仓库ID（1 线边库；3 工位） 
        /// </summary>
        public int? wb_TWID { get; set; }

        /// <summary>
        /// 目标仓库
        /// </summary>
        public string wb_TWIDName
        {
            get
            {
                if (wb_TWID == 1) return "线边库";
                if (wb_TWID == 3) return "工位";
                return "";
            }
        }

        /// <summary>
        /// 物料盒条码卡ID
        /// </summary>
        public int? wb_BarCodeID { get; set; }

        public string wb_barcode { get; set; }

        /// <summary>
        /// 配料员，employee.ID
        /// </summary>
        public int? wb_operID { get; set; }

        public string wb_operName { get; set; }

        /// <summary>
        /// 配料时间
        /// </summary>
        public DateTime? wb_batchtime { get; set; }

        public string wb_batchtimeText
        {
            get
            {
                if (wb_batchtime == null)
                    return "";
                return wb_batchtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 配送时间
        /// </summary>
        public DateTime? wb_dispatchTime { get; set; }

        public string wb_dispatchTimeText
        {
            get
            {
                if (wb_dispatchTime == null)
                    return "";
                return wb_dispatchTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 接收员，employee.ID
        /// </summary>
        public int? wb_receiveID { get; set; }

        public string wb_receiveName { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime? wb_createtime { get; set; }

        public string wb_createtimeText
        {
            get
            {
                if (wb_createtime == null)
                    return "";
                return wb_createtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 状态：1.已配料 2.已配送 3.已接收 //4.已退回
        /// </summary>
        public int? wb_status { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string wb_statusName
        {
            get
            {
                if (wb_status == 1) return "已配料";
                if (wb_status == 2) return "已配送";
                if (wb_status == 3) return "已接收";
                return "";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string wb_remark { get; set; }


        /// <summary>
        /// 用于接收json数据
        /// </summary>
        public string JSONDetailList { get; set; }


        public List<WmsBatchingDetailModel> detailList { get; set; }

    }
}
