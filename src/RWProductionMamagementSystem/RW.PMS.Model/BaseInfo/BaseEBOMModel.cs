using System;
using System.Collections.Generic;

namespace RW.PMS.Model.BaseInfo
{

    /// <summary>
    /// Ebom 清单
    /// </summary>
    public class BaseEBOMModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? ebProdModelID { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 工序ID
        /// </summary>
        public int? ebOperationID { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string operationName { get; set; }

        /// <summary>
        /// 父级零件ID
        /// </summary>
        public int? ebParentID { get; set; }

        /// <summary>
        /// 父级零件名称
        /// </summary>
        public string ebParentName { get; set; }

        /// <summary>
        /// 子级零件ID
        /// </summary>
        public int? ebChildID { get; set; }

        /// <summary>
        /// 子级零件名称
        /// </summary>
        public string ebChildName { get; set; }

        /// <summary>
        /// 物料类型（器、 物器、物装器、备装器、其他）
        /// </summary>
        public string mtName { get; set; }

        /// <summary>
        /// 物料来源
        /// </summary>
        public int ebMsource { get; set; }


        public string ebMsourceText { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        public decimal? ebQty { get; set; }

        /// <summary>
        /// 级数  --当前级数 下一级累加父级级数
        /// </summary>
        public int ebLevel { get; set; }

        /// <summary>
        /// 路径  --/父级ID/子级ID
        /// </summary>
        public string ebPath { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ebRemark { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int? ebDisableFlag { get; set; }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        public int? ebDeleteFlag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? ebCreateTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? ebCreaterID { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? ebUpdateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? ebUpdaterID { get; set; }

        /// <summary>
        /// 子级List集合
        /// </summary>
        public List<BaseEBOMModel> children { get; set; }


        public int? UNID { get; set; }


        /// <summary>
        /// 所属零件零件号（图号）
        /// </summary>
        public string ParentDrawingNo { get; set; }

        /// <summary>
        /// *拼接 所属零件名称 - 零件号（图号）
        /// </summary>
        public string ParentName { get; set; }

        /// <summary>
        /// 零件零件号（图号）
        /// </summary>
        public string ChildDrawingNo { get; set; }

        /// <summary>
        /// *拼接 零件名称 - 零件号（图号）
        /// </summary>
        public string ChildName { get; set; }



        #region 装配显示制造BOM

        public string mName { get; set; }
        public string mDrawingNo { get; set; }

        public string Qty { get; set; }

        #endregion


    }
}
