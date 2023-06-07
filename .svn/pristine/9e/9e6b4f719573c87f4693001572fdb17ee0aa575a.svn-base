using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Test
{
    /// <summary>
    /// 试验配置明细表
    /// </summary>
    public class TestConfigDetailModel : BaseModel
    {
        #region 数据库原始字段

        /// <summary>
        /// ID
        /// </summary>
        public int tcdID { get; set; }

        /// <summary>
        /// 主表ID
        /// </summary>
        public Guid? tcmGUID { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int? tcdRowNo { get; set; }

        /// <summary>
        /// 列号
        /// </summary>
        public int? tcdColNo { get; set; }

        /// <summary>
        /// 合并行数
        /// </summary>
        public int? tcdRowSpan { get; set; }

        /// <summary>
        /// 合并列数
        /// </summary>
        public int? tcdColSpan { get; set; }

        /// <summary>
        /// 字体大小
        /// </summary>
        public int? tcdFontSize { get; set; }

        /// <summary>
        /// 对齐方式：1左、2居中、3右
        /// </summary>
        public int? tcdAlign { get; set; }

        public string tcdAlignText
        {
            get
            {
                if (tcdAlign == 1)
                {
                    return "左";
                }
                if (tcdAlign == 3)
                {
                    return "右";
                }
                return "居中";
            }
        }

        /// <summary>
        /// 上边框
        /// </summary>
        public int tcdBorderTop { get; set; }

        /// <summary>
        /// 右边框
        /// </summary>
        public int tcdBorderRight { get; set; }

        /// <summary>
        /// 下边框
        /// </summary>
        public int tcdBorderBottom { get; set; }

        /// <summary>
        /// 左边框
        /// </summary>
        public int tcdBorderLeft { get; set; }

        /// <summary>
        /// 宽
        /// </summary>
        public int? tcdWidth { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        public int? tcdHeight { get; set; }

        /// <summary>
        /// 文本值
        /// </summary>
        public string tcdText { get; set; }

        /// <summary>
        /// 编辑标识
        /// </summary>
        public int? tcdEditFlag { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string tcdRemark { get; set; }

        #endregion

        /// <summary>
        /// 编辑标识显示值
        /// </summary>
        public string tcdEditFlagText
        {
            get
            {
                if (tcdEditFlag == 0)
                {
                    return "不可编辑";
                }
                else
                {
                    return "可编辑";
                }
            }
        }


        /// <summary>
        /// 配置明细文本模糊查询字段
        /// </summary>
        public string LIKETcdText { get; set; }

        /// <summary>
        /// 试验标题 查询用
        /// </summary>
        public string tcmName { get; set; }

    }
}
