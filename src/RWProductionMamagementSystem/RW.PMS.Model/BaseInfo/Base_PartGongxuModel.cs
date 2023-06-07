using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{

    /// <summary>
    /// 基础计划工序维护表
    /// </summary>
    public class Base_PartGongxuModel : BaseModel
    {

        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 用于判断重复添加 排除当前ID
        /// </summary>
        public int? UNID { get; set; }

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? PID { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? prodModelID { get; set; }


        public string Pmodel { get; set; }

        /// <summary>
        /// 图号
        /// </summary>
        public string DrawingNo { get; set; }


        /// <summary>
        /// 工艺委托类型
        /// </summary>
        public int entrustType { get; set; }

        public string entrustTypeText { get; set; }

        /// <summary>
        /// 工作中心编码
        /// </summary>
        public string workCenterCode { get; set; }

        /// <summary>
        /// 工作中心名称
        /// </summary>
        public string workCenterName { get; set; }



        /// <summary>
        /// 工序号
        /// </summary>
        public string operationNo { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string operationName { get; set; }

        public string LIKEoperationName { get; set; }

        /// <summary>
        /// 工序编码
        /// </summary>
        public string operationCode { get; set; }

        /// <summary>
        /// 检验点	0----false , 1----true
        /// </summary>
        public int isCheckPoint { get; set; }

        public string IsCheckPointText
        {
            get
            {
                if (isCheckPoint == 0)
                {
                    return "否";
                }
                return "是";
            }
        }

        /// <summary>
        /// 汇报点	0----false , 1----true
        /// </summary>
        public int isReportPoint { get; set; }

        public string IsReportPointText
        {
            get
            {
                if (isReportPoint == 0)
                {
                    return "否";
                }
                return "是";
            }
        }

        /// <summary>
        /// 入库点	0----false , 1----true
        /// </summary>
        public int isPickingPoint { get; set; }

        public string IsPickingPointText
        {
            get
            {
                if (isPickingPoint == 0)
                {
                    return "否";
                }
                return "是";
            }
        }

        /// <summary>
        /// 委外厂商编码
        /// </summary>
        public string entrustSupplierCode { get; set; }

        /// <summary>
        /// 开工台位编码
        /// </summary>
        public string taiweiCode { get; set; }

        /// <summary>
        /// 生产工序别号
        /// </summary>
        public string opertionAlias { get; set; }

        /// <summary>
        /// 生产加工说明
        /// </summary>
        public string proInstruction { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public int? status { get; set; }

        public string statusText
        {
            get
            {
                if (status == 0)
                    return "启用";
                return "禁用";
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? deleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createTime { get; set; }

        public string createTimeText
        {
            get
            {
                if (createTime == null)
                    return "";
                return createTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) createTime = dt;
            }
        }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? createMan { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? updateTime { get; set; }


        public string updateTimeText
        {
            get
            {
                if (updateTime == null)
                    return "";
                return updateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) updateTime = dt;
            }
        }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? updateMan { get; set; }
    }
}
