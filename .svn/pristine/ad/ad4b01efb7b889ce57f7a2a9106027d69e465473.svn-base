using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Test
{

    /// <summary>
    /// 试验结果明细表
    /// </summary>
    public class TestResultDetailModel : BaseModel
    {

        #region 数据库表原始字段
        /// <summary>
        /// ID
        /// </summary>
        public int trdID { get; set; }
        /// <summary>
        /// 试验结果主表ID
        /// </summary>
        public Guid? trmGUID { get; set; }
        /// <summary>
        /// 试验配置明细ID
        /// </summary>
        public string tcdID { get; set; }
        /// <summary>
        /// 试验结果 文本
        /// </summary>
        public string trdText { get; set; }
        /// <summary>
        /// 试验结果 标识
        /// </summary>
        public int? trdFlag { get; set; }
        /// <summary>
        /// 试验结果备注
        /// </summary>
        public string trdRemark { get; set; }

        /// <summary>
        /// 试验名称
        /// </summary>
        public string TestName { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? trdDeleteFlag { get; set; }
        public DateTime? trdCreateTime { get; set; }
        public int? trdCreaterID { get; set; }
        public DateTime? trdUpdateTime { get; set; }
        public int? trdUpdaterID { get; set; }
        #endregion

        /// <summary>
        /// 行号
        /// </summary>
        public int? tcdRowNo { get; set; }

        /// <summary>
        /// 列号
        /// </summary>
        public int? tcdColNo { get; set; }

        /// <summary>
        /// 行号 显示文本
        /// </summary>
        public string tcdRowText
        {
            get
            {
                if (tcdRowNo.HasValue && tcdRowNo > 0)
                    return "第" + tcdRowNo + "行";
                return "";
            }
        }

        /// <summary>
        /// 列号 显示文本
        /// </summary>
        public string tcdColText
        {
            get
            {
                if (tcdColNo.HasValue && tcdColNo > 0)
                    return "第" + tcdColNo + "列";
                return "";
            }
        }

        /// <summary>
        /// 实绩合格标识 显示文本
        /// </summary>
        public string trdFlagText
        {
            get
            {
                if (!trdFlag.HasValue)
                    return "";
                if (trdFlag == 1)
                    return "合格";
                return "不合格";
            }
        }

        /// <summary>
        /// 试验配置明细表 备注
        /// </summary>
        public string tcdRemark { get; set; }

        /// <summary>
        /// ID字符串 删除用
        /// </summary>
        public string DELIDs { get; set; }




        public string PmodelDrawingNo { get; set; }

        public string pp_orderCode { get; set; }

        public string trmProdNo { get; set; }
        public string pp_projectName { get; set; }



    }
}
