using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 配料主表信息实体类
    /// </summary>
    public class BatchingRecordModel : BaseModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }
         
        /// <summary>
        /// 配料单号
        /// </summary>
        public string BatchCode { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? PModelID { get; set; }

        /// <summary>
        /// 工艺ID 
        /// </summary>
        public int ProgID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WarehouseID { get; set; }
         
        /// <summary>
        /// 配料类型. 1:计划配料 2:领料配料 3.其他配料
        /// </summary>
        public int? TypeID { get; set; }

        /// <summary>
        /// 操作人ID
        /// </summary>
        public int? ApplierID { get; set; }

        /// <summary>
        /// 操作人名称
        /// </summary>
        public string AplierName { get; set; }

        /// <summary>
        /// 配料日期
        /// </summary>
        public DateTime? BatchDate { get; set; }

        public string BatchDateText
        {
            get
            {
                if (BatchDate == null)
                    return string.Empty;
                return BatchDate.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 状态：1.已配料 2.已配送 3.已接收 //4.已退回
        /// </summary>
        public int? BatchStatus { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string PModelName { get; set; }

        /// <summary>
        /// 工艺名称
        /// </summary>
        public string ProgName { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string WarehouseName { get; set; }

        /// <summary>
        /// 配料类型
        /// </summary>
        public string TypeName
        {
            get
            {
                if (BatchStatus == 1) return "计划配料";
                if (BatchStatus == 2) return "领料配料";
                if (BatchStatus == 3) return "其他配料";
                return string.Empty;
            }
        }

        /// <summary>
        /// 状态值
        /// </summary>
        public string BatchStatusName
        {
            get
            {
                if (BatchStatus == 1) return "已配料";
                if (BatchStatus == 2) return "已配送";
                if (BatchStatus == 3) return "已接收";
                return string.Empty;
            }
        }

        /// <summary>
        /// 接收员，employee.ID
        /// </summary>
        public int? ReceiveID { get; set; }

        public string ReceiveName { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime? Createtime { get; set; }

        public string CreatetimeText
        {
            get
            {
                if (Createtime == null)
                    return string.Empty;
                return Createtime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
         
        /// <summary>
        /// 用于接收json数据
        /// </summary>
        public string JSONDetailList { get; set; }

        public List<BatchingRecordDetailModel> Details { get; set; }
    }
}
