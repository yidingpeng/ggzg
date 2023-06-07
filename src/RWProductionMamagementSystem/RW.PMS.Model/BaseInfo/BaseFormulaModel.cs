using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseFormulaModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 配方编号
        /// </summary>
        public string formulaCode { get; set; }

        /// <summary>
        /// 配方名称
        /// </summary>
        public string formulaName { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public int prodmodelID { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string prodmodelName { get; set; }

        /// <summary>
        /// 点位信息
        /// </summary>
        public string pointInfoDes { get; set; }

        /// <summary>
        /// 拧紧力矩
        /// </summary>
        public string tighteningTorque { get; set; }


    }
}
