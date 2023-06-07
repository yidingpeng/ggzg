using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    ///  follow_evencheck
    /// </summary>
    public class follow_evencheckModel
    {
       
        public Guid ecGuid { get; set; }

        /// <summary>
        /// 偶换件检验编码
        /// </summary>
        public string ecCode { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? ecProdModelID { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public string pmodel { get; set; }


        /// <summary>
        /// 根据计划生成的明细计划ID
        /// </summary>
        public Guid? ecGePlanGuid { get; set; }

        /// <summary>
        /// 自定义明细关联的计划ID
        /// </summary>
        public Guid? ceRelPlanGuid { get; set; }

        /// <summary>
        /// 送检状态
        /// </summary>
        public int? ecStatus { get; set; }

        public string ecStatusstring
        {
            get
            {
                if (ecStatus == 1)
                    return "新建";
                if (ecStatus == 2)
                    return "已入库";
                return "";
            }
        }
        public string ecDate { get; set; }
        public int? ecSenderID { get; set; }
        public string ecRemark { get; set; }
        public int? ecDeleteFlag { get; set; }
        public string ecCreateTime { get; set; }
        public int? ecCreaterID { get; set; }
        public string ecUpdateTime { get; set; }
        public int? ecUpdaterID { get; set; }

        //follow_evencheckdetail
        public int ID { get; set; }
        public int? ecdwlID { get; set; }
        public int? ecwlmodelID { get; set; }
        public int? ecInspectionQty { get; set; }
        public int? ecUnQty { get; set; }
        public int? ecQuQty { get; set; }
        public int? beforeQty { get; set; }
        public int? afterQty { get; set; }
        //合计合格数量
        public int? sumecQuQty { get; set; }
        //合计不合格数量
        public int? sumecUnQty { get; set; }
        //送检总数
        public int? sumecInspectionQty { get; set; }
        //总合格率
        public double? yield { get; set; }

    }
}
