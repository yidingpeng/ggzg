using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPRFC.Models.ZFM_PP_BOM_READ_RFC//BOM信息读取
{
    #region 输入参数表
    public class IV_ANDAT
    {
        /// <summary>
        /// 修改开始日期 CHAR    8		YYYYMMDD
        /// </summary>
        public string ANDAT { get; set; }
    }

    public class IV_ENDAT
    {
        /// <summary>
        /// 修改截止日期	CHAR	8		非必填，不填则取9999.12.31
        /// </summary>
        public string ENDAT { get; set; }
    }

    public class IT_MATNR
    {
        /// <summary>
        ///  物料号 CHAR	18
        /// </summary>
        public string MATNR { get; set; }
    }

    public class IT_WERKS
    {
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string WERKS { get; set; } 
    }

    #endregion

    #region 返回参数：表

    public class ET_BOM
    {
        /// <summary>
        /// 物料编号    CHAR	18
        /// </summary>
        public string MATERIAL { get; set; }
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string PLANT { get; set; }
        /// <summary>
        ///  BOM 用途 CHAR	1
        /// </summary>
        public string BOM_USAGE { get; set; }
        /// <summary>
        /// 可选的 BOM CHAR	2
        /// </summary>
        public string ALTERNATIVE { get; set; }
        /// <summary>
        /// 有效起始日期  DATS	8
        /// </summary>
        public string VALID_FROM { get; set; }
        /// <summary>
        /// 基本数量    QUAN	13
        /// </summary>
        public string BASE_QUAN { get; set; }
        /// <summary>
        ///  BOM 基本单位 UNIT	3
        /// </summary>
        public string BASE_UNIT { get; set; }
        /// <summary>
        /// BOM 项目号 CHAR	4
        /// </summary>
        public string ITEM_NO { get; set; }
        /// <summary>
        ///  BOM 组件 CHAR	18
        /// </summary>
        public string COMPONENT { get; set; }
        /// <summary>
        /// 组件数量    QUAN	13
        /// </summary>
        public string COMP_QTY { get; set; } 
        /// <summary>
        /// 组件计量单位  UNIT	3
        /// </summary>
        public string COMP_UNIT { get; set; }
        /// <summary>
        ///  替代项目：组 CHAR	2
        /// </summary>
        public string AI_GROUP { get; set; }
        /// <summary>
        /// 使用可能性按 % (BTCI)	CHAR	3
        /// </summary>
        public string USAGE_PROB { get; set; }
        /// <summary>
        /// 日期记录创建于     DATS	8
        /// </summary>
        public string CREATE_ON { get; set; }
        /// <summary>
        /// 最后更改的日期 DATS	8
        /// </summary>
        public string CHANGE_ON { get; set; }
    }

    #endregion
}
