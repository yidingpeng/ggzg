using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 区域追溯辅助类
    /// </summary>
    public class FollowAreaModel : BaseModel
    {
        /// <summary>
        /// GUID
        /// </summary>
        public Guid Fm_Guid { get; set; }
        /// <summary>
        /// 制动柜编号
        /// </summary>
        public string Fm_prodNo { get; set; }
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? Fm_prodModelID { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get; set; }
        /// <summary>
        /// 车型
        /// </summary>
        public string Fp_carModel { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string Fp_carNo { get; set; }
        /// <summary>
        /// 追溯主表开始检修时间
        /// </summary>
        public DateTime? Fm_starttime { get; set; }
        /// <summary>
        /// 追溯主表完成检修时间
        /// </summary>
        public DateTime? Fm_finishtime { get; set; }

        public string Starttime { get; set; }
        public string Endtime { get; set; }

        public string pf_orderNo { get; set; }

        public string pf_compartNo { get; set; }

        public string pf_bogieNo { get; set; }

        public string pf_stampNo { get; set; }

        public DateTime? fm_inHouseTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string FinishStatusText
        {
            //0:未完成；1:已完成,未发货，2:异常下线；3：重新装配; 4:已发货；5：已入场（未开始检修）
            get
            {
                if (fm_finishStatus == 0)
                    return "未完成";
                if (fm_finishStatus == 1)
                    return "已完成";
                if (fm_finishStatus == 2)
                    return "异常下线";
                if (fm_finishStatus == 3)
                    return "重新装配";
                if (fm_finishStatus == 4)
                    return "已发货";
                if (fm_finishStatus == 5)
                    return "已入场";
                return "";
            }
        }
        public int? fm_finishStatus { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public int? Fm_curAreaID { get; set; }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string Fm_curArea { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public int? Fm_curGwID { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string Fm_curGw { get; set; }
        /// <summary>
        /// 信息创建人ID
        /// </summary>
        public int? Fm_creatorID { get; set; }
        /// <summary>
        /// 信息创建人
        /// </summary>
        public string Fm_creator { get; set; }

        public string fm_remark { get; set; }

        

        /// <summary>
        /// 开始时间34
        /// </summary>
        public DateTime? FStarttime_34 { get; set; }
        /// <summary>
        /// 完成时间34
        /// </summary>
        public DateTime? FinishTime_34 { get; set; }
        /// <summary>
        /// 操作员34
        /// </summary>
        public string Opers_34 { get; set; }
        /// <summary>
        /// 质量结果34
        /// </summary>
        public string Results_34 { get; set; }


        /// <summary>
        /// 开始时间131
        /// </summary>
        public DateTime? FStarttime_131 { get; set; }
        /// <summary>
        /// 完成时间131
        /// </summary>
        public DateTime? FinishTime_131 { get; set; }
        /// <summary>
        /// 操作员131
        /// </summary>
        public string Opers_131 { get; set; }
        /// <summary>
        /// 质量结果131
        /// </summary>
        public string Results_131 { get; set; }


        /// <summary>
        /// 开始时间184
        /// </summary>
        public DateTime? FStarttime_184 { get; set; }
        /// <summary>
        /// 完成时间184
        /// </summary>
        public DateTime? FinishTime_184 { get; set; }
        /// <summary>
        /// 操作员184
        /// </summary>
        public string Opers_184 { get; set; }
        /// <summary>
        /// 质量结果184
        /// </summary>
        public string Results_184 { get; set; }

        /// <summary>
        /// 开始时间185
        /// </summary>
        public DateTime? FStarttime_185 { get; set; }
        /// <summary>
        /// 完成时间185
        /// </summary>
        public DateTime? FinishTime_185 { get; set; }
        /// <summary>
        /// 操作员185
        /// </summary>
        public string Opers_185 { get; set; }
        /// <summary>
        /// 质量结果185
        /// </summary>
        public string Results_185 { get; set; }

        //
        public int? Fgw_areaID { get; set; }
        public DateTime? Fgw_starttime { get; set; }
        public DateTime? Fgw_finishtime { get; set; }
        public string Fgw_Oper { get; set; }
        public string Fgw_resultMemo { get; set; }

       
    }
}
