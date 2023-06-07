using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPRFC.Models.ZFM_PP_WORK_CENTER_READ_RFC //工作中心信息读取
{
    #region 输入参数
    public class IT_WERKS
    {
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string WERKS { get; set; } 
    }

    public class IT_ARBPL
    {
        /// <summary>
        /// ARBPL	工作中心	CHAR
        /// </summary>
        public string ARBPL { get; set; }
    }
    
    public class IT_ANDAT
    {
        /// <summary>
        ///修改开始日期	CHAR	8		YYYYMMDD
        /// </summary>
        public string ANDAT { get; set; }

        /// <summary>
        /// ENDAT 修改截止日期  CHAR	8		非必填，不填则取9999.12.31
        /// </summary>
        public string ENDAT { get; set; }
    }
    #endregion

    #region  返回参数：表
    public class ET_WORKCENTER
    {
        /// <summary>
        /// 工厂  CHAR	4		
        /// </summary>
        public string WERKS { get; set; }
        /// <summary>
        /// 工作中心    CHAR	8		
        /// </summary>
        public string ARBPL { get; set; }
        /// <summary>
        /// 工作中心短描述     CHAR	40		
        /// </summary>
        public string KTEXT { get; set; }
        /// <summary>
        ///  工作中心类别 CHAR	4		
        /// </summary>
        public string VERWE { get; set; }
        /// <summary>
        /// 工作中心删除标志 CHAR	1	X为删除；空为正常
        /// </summary>
        public string LVORM { get; set; }
        /// <summary>
        /// 标准值码 CHAR	4		
        /// </summary>
        public string VGWTS { get; set; }
        /// <summary>
        /// 控制码 CHAR	4		
        /// </summary>
        public string STEUS { get; set; }
        /// <summary>
        /// 创建日期    DATS	8	YYYYMMDD
        /// </summary>
        public string AEDAT_GRND { get; set; }
        /// <summary>
        ///  更改日期    DATS	8	YYYYMMDD
        /// </summary>
        public string AEDAT_VORA { get; set; }
    
    }
    #endregion
}
