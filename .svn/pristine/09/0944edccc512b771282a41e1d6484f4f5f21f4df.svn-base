using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Plan
{
    /// <summary>
    /// 计划明细Model
    /// </summary>
    public class PlanDetailModel
    {
        public int ID { get; set; }
        public Guid? ppGuid { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pdCompartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pdBogieNo { get; set; }

        /// <summary>
        /// 电机编号
        /// </summary>
        public string pdProdNo { get; set; }
        public int? pdStatus { get; set; }
        public string pdStatusText
        {
            get
            {
                if (pdStatus == 1)
                    return "未存放";
                if (pdStatus == 2)
                    return "已存放";
                if (pdStatus == 3)
                    return "待存";
                if (pdStatus == 4)
                    return "已存放";
                if (pdStatus == 5)
                    return "已离场";
                return "";
            }
        }
        /// <summary>
        /// 存放区域表ID
        /// </summary>
        public int? pdTAID { get; set; }
        public int? ta_areaID { get; set; }
        public string ta_areaName { get; set; }

        /// <summary>
        /// 当前生产主表ID
        /// </summary>
        public Guid? ta_curFmGuid { get; set; }

        #region API参数

        /// <summary>
        /// 产品ID
        /// </summary>
        public int? prodID { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? prodModelID { get; set; }

        /// <summary>
        /// 存至缓存区还是入场存放区
        /// </summary>
        public bool isCache { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string carNo { get; set; }

        /// <summary>
        /// 计划数量
        /// </summary>
        public int? planQty { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? curUserID { get; set; }

        /// <summary>
        /// 老电机编号
        /// </summary>
        public string oldProdNo { get; set; }

        /// <summary>
        /// 当前区域ID
        /// </summary>
        public int? curAreaID { get; set; }

        /// <summary>
        /// 当前区域名称
        /// </summary>
        public string curAreaName { get; set; }

        /// <summary>
        /// 当前工位ID
        /// </summary>
        public int? curGwID { get; set; }

        /// <summary>
        /// 当前工位名称
        /// </summary>
        public string curGwName { get; set; }

        /// <summary>
        /// 当前用户名称
        /// </summary>
        public string curUserName { get; set; }

        /// <summary>
        /// 自定义编码 保存用
        /// </summary>
        public int? pdUserCode { get; set; }
        #endregion
    }
}
