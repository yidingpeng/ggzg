using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Test
{

    /// <summary>
    /// 试验结果主表
    /// </summary>
    public class TestResultMainModel : BaseModel
    {
        #region 数据库原始字段
        /// <summary>
        /// GUID
        /// </summary>
        public Guid trmGUID { get; set; }
        /// <summary>
        /// 试验配置主表GUID
        /// </summary>
        public Guid? tcmGUID { get; set; }
        /// <summary>
        /// 追溯主表GUID
        /// </summary>
        public Guid? pfGUID { get; set; }


        /// <summary>
        /// 追溯主表ID
        /// </summary>
        public int? pfID { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string trmProdNo { get; set; }
        /// <summary>
        /// 试验总结果文本
        /// </summary>
        public string trmText { get; set; }
        /// <summary>
        /// 试验总结果标识
        /// </summary>
        public int? trmFlag { get; set; }
        /// <summary>
        /// 试验开始时间
        /// </summary>
        public DateTime? trmStartTime { get; set; }
        /// <summary>
        /// 试验结束时间
        /// </summary>
        public DateTime? trmEndTime { get; set; }
        /// <summary>
        /// 试验报告上传时间
        /// </summary>
        public DateTime? trmUpLoadTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string trmRemark { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? trmDeleteFlag { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? trmCreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        public int? trmCreaterID { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? trmUpdateTime { get; set; }
        /// <summary>
        /// 最后结束时间
        /// </summary>
        public int? trmUpdaterID { get; set; }
        #endregion

        /// <summary>
        /// 试验结果明细集合 用于接口上传试验结果数据
        /// </summary>
        public List<TestResultDetailModel> trmDetailList { get; set; }

        /// <summary>
        /// 试验结果总表示 显示值+
        /// </summary>
        public string trmFlagText
        {
            get
            {
                if (trmFlag == null)
                    return "";
                if (trmFlag == 1)
                    return "合格";
                return "不合格";
            }
        }

        /// <summary>
        /// 试验开始时间显示值
        /// </summary>
        public string trmStartTimeText
        {
            get
            {
                if (trmStartTime == null)
                    return "";
                return trmStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 试验结束时间显示值
        /// </summary>
        public string trmEndTimeText
        {
            get
            {
                if (trmEndTime == null)
                    return "";
                return trmEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 试验结果上传时间显示值
        /// </summary>
        public string trmUpLoadTimeText
        {
            get
            {
                if (trmUpLoadTime == null)
                    return "";
                return trmUpLoadTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 试验结果主表产品编号 模糊搜索条件
        /// </summary>
        public string LIKETrmProdNo { get; set; }

        /// <summary>
        /// ID字符串 删除用
        /// </summary>
        public string DELIDs { get; set; }



        public string PmodelDrawingNo { get; set; }

        public string pp_orderCode { get; set; }

        public string DateTimeStr { get; set; }

        public string pp_projectName { get; set; }



    }
}
