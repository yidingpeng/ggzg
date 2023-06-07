using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Home
{
    /// <summary>
    /// 产品完成情况
    /// </summary>
    public class ProductCompleteModel
    {
        /// <summary>
        /// 产品名称
        /// </summary>
        public string Pname { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string Pmodel { get; set; }
        /// <summary>
        /// 产品名称+产品型号
        /// </summary>
        public string Prodmodel { get; set; }

        string _carModel;
        /// <summary>
        /// 车型
        /// </summary>
        public string CarModel
        {
            get
            {
                if (_carModel == null)
                    return "";
                return _carModel;
            }
            set { _carModel = value; }
        }
        /// <summary>
        /// 车号
        /// </summary>
        public string CarNo { get; set; }
        /// <summary>
        /// 合格数
        /// </summary>
        public int? Okqty { get; set; }
        /// <summary>
        /// 不合格数
        /// </summary>
        public int? Errorqty { get; set; }
        /// <summary>
        /// 合格率
        /// </summary>
        public string OkRate { get; set; }

        /// <summary>
        /// 异常类型：工具拿错、物料拿错、扭力参数有误
        /// </summary>
        public string AnomalyType { get; set; }
        /// <summary>
        /// 异常数量
        /// </summary>
        public int? AnomalyCount { get; set; }

        /// <summary>
        /// 完成数
        /// </summary>
        public int? FinishQty { get; set; }
        /// <summary>
        /// 总完成数
        /// </summary>
        public int? TotalQty { get; set; }
        /// <summary>
        /// 完成率
        /// </summary>
        public string FinishRate { get; set; }


        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }




        #region RWPMS牵引电机检修信息管理系统电子看板 异常信息字段


        public string bdname { get; set; }

        public string err_oper { get; set; }

        public string err_gw { get; set; }

        public DateTime? errDate { get; set; }

        public string errDateText
        {
            get
            {
                if (errDate == null)
                    return "";
                return errDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        #endregion



    }
}
