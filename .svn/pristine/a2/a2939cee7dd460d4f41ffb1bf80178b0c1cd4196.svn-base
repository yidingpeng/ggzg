using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Test
{

    /// <summary>
    /// 试验配置主表
    /// </summary>
    public class TestConfigMainModel : BaseModel
    {

        #region 数据库原始字段
        /// <summary>
        /// GUID
        /// </summary>
        public Guid tcmGUID { get; set; }

        /// <summary>
        /// 试验名称
        /// </summary>
        public string tcmName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string tcmRemark { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public int? tcmDeleteFlag { get; set; }

        /// <summary>
        /// 创建者时间
        /// </summary>
        public DateTime? tcmCreateTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? tcmCreaterID { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? tcmUpdateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? tcmUpdaterID { get; set; }

        #endregion


        /// <summary>
        /// 创建时间显示值
        /// </summary>
        public string tcmCreateTimeText
        {
            get
            {
                if (tcmCreateTime == null)
                    return "";
                return tcmCreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        /// <summary>
        /// 最后更新时间显示值
        /// </summary>
        public string tcmUpdateTimeText
        {
            get
            {
                if (tcmUpdateTime == null)
                    return "";
                return tcmUpdateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

       
        /// <summary>
        /// 配置主表名称 模糊搜索条件
        /// </summary>
        public string LIKETcmName { get; set; }


        /// <summary>
        /// 配置明细集合 查询用
        /// </summary>
        public List<TestConfigDetailModel> DetailList { get; set; }

        /// <summary>
        /// 结果明细集合 查询用
        /// </summary>
        public List<TestResultDetailModel> ResultList { get; set; }




        public string JSONDetail { get; set; }

        public string JSONResult { get; set; }


        public Guid? fmGUID { get; set; }
        public string pf_prodNo { get; set; }
        public string fp_prodNo_sys { get; set; }


    }
}
