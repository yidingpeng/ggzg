using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Home
{
    public class ErrorModel
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public string ProdNo { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProdName { get; set; }
        /// <summary>
        /// 产品型号
        /// </summary>
        public string ProdModel { get; set; }

        public string PmodelDrawingNo { get; set; }


        /// <summary>
        /// 异常类型
        /// </summary>
        public string ErrorName { get; set; }
        /// <summary>
        /// 异常时间
        /// </summary>
        public DateTime? ErrorDate { get; set; }


        public string ErrorDateText
        {
            get
            {
                if (ErrorDate == null)
                    return "";
                return ErrorDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            set
            {
                DateTime dt = DateTime.MinValue;
                DateTime.TryParse(value, out dt);
                if (dt != DateTime.MinValue) ErrorDate = dt;
            }
        }



        /// <summary>
        ///异常描述
        /// </summary>
        public string ErrorDesp { get; set; }
        /// <summary>
        /// 异常工位
        /// </summary>
        public string ErrGw { get; set; }
        /// <summary>
        /// 异常操作人员
        /// </summary>
        public string ErrOpen { get; set; }
        /// <summary>
        /// 异常数量
        /// </summary>
        public int? ErrCount { get; set; }
    }
}
