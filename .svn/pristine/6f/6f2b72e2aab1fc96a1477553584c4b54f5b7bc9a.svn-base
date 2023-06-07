using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class WmsRequisitionMainModel : BaseModel
    {

        /// <summary>
        /// 备品申请主表GUID
        /// </summary>
        public Guid Iv_guid { get; set; }

        /// <summary>
        /// 申请单号，系统自动生成，规则为日期yyyyMMdd_编号(2位）
        /// </summary>
        public string Iv_applyNo { get; set; }

        /// <summary>
        /// 领料类型ID（1、备品 2、其他 ）
        /// </summary>
        public int? Iv_RTypeID { get; set; }

        /// <summary>
        /// 领料类型名称
        /// </summary>
        public string Iv_RTypeName
        {
            get
            {
                if (Iv_RTypeID == 1) return "备品";
                if (Iv_RTypeID == 2) return "其他";
                return "";
            }
        }

        /// <summary>
        /// 来源仓库ID（1 线边库；2 库房） 
        /// </summary>
        public int? Iv_SWID { get; set; }

        /// <summary>
        /// 来源仓库名称
        /// </summary>
        public string Iv_SWName
        {
            get
            {
                if (Iv_SWID == 1) return "线边库";
                if (Iv_SWID == 2) return "库房";
                return "";
            }
        }

        /// <summary>
        /// 目标仓库ID（1 线边库；2 库房） 
        /// </summary>
        public int? Iv_TWID { get; set; }


        /// <summary>
        /// 目标仓库名称
        /// </summary>
        public string Iv_TWName
        {
            get
            {
                if (Iv_TWID == 1) return "线边库";
                if (Iv_TWID == 2) return "库房";
                return "";
            }
        }

        /// <summary>
        /// 申请人
        /// </summary>
        public int? Iv_applierID { get; set; }

        /// <summary>
        /// 申请人名称
        /// </summary>
        public string Iv_applierName { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? Iv_applyDate { get; set; }

        //public string Iv_applyDateText
        //{
        //    get
        //    {
        //        if (Iv_applyDate == null)
        //            return "";
        //        return Iv_applyDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
        //    }
        //}


        public string Iv_applyDateText
        {
            get
            {
                if (Iv_applyDate == null)
                    return "";
                return Iv_applyDate.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 状态: 1.已申领 2.已配料 3.已驳回 
        /// </summary>
        public int? Iv_applyStatus { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Iv_applyStatusName
        {
            get
            {
                if (Iv_applyStatus == 1) return "已申领";
                if (Iv_applyStatus == 2) return "已配料";
                if (Iv_applyStatus == 3) return "已驳回";
                return "";
            }
        }

        /// <summary>
        /// //备注
        /// </summary>
        public string Iv_remark { get; set; }


        /// <summary>
        /// 用于接收json数据
        /// </summary>
        public string JSONDetailList { get; set; }

        public List<WmsRequisitionDetailModel> detailList { get; set; }
    }
}
