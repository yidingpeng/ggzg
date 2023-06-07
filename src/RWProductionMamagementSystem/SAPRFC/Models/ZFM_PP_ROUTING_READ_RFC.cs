using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPRFC.Models.ZFM_PP_ROUTING_READ_RFC //工艺路线信息读取
{
    #region 输入参数
    public class IV_ANDAT
    {
        /// <summary>
        /// 关键日期(起始日期) YYYYMMDD，取的输入日期至9999.12.31
        /// </summary>
        public string ANDAT { get; set; }
    }

    public class IV_ENDDAT
    {
        /// <summary>
        /// 关键日期(结束日期) YYYYMMDD，非必填，不填则取9999.12.31
        /// </summary>
        public string ENDDAT { get; set; }
    }

    
    public class IT_WERKS //表
    {
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string WERKS { get; set; }
    }

    public class IT_MATNR //表
    {
        /// <summary>
        /// 物料号 CHAR	18
        /// </summary>
        public string MATNR { get; set; }

    }

    #endregion

    #region 返回参数：表
    public class ET_ROUTING
    {
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string WERKS { get; set; }
        /// <summary>
        /// 物料编号    CHAR	18
        /// </summary>
        public string MATNR { get; set; }
        /// <summary>
        /// 基本计量单位  UNIT	3
        /// </summary>
        public string MEINS { get; set; }
        /// <summary>
        /// 物料描述    CHAR	40
        /// </summary>
        public string MAKTX { get; set; }
        /// <summary>
        ///  组计数器    CHAR	2
        /// </summary>
        public string PLNAL { get; set; }
        /// <summary>
        /// 有效起始日期  DATS	8
        /// </summary>
        public string DATUV { get; set; }
        /// <summary>
        /// 基本数量    QUAN	13
        /// </summary>
        public string BMSCH { get; set; }
        /// <summary>
        ///  活动编号    CHAR	4
        /// </summary>
        public string VORNR { get; set; }
        /// <summary>
        /// 工序短文本   CHAR	40
        /// </summary>
        public string LTXA1 { get; set; }
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string ARWRK { get; set; }
        /// <summary>
        /// 工作中心    CHAR	8
        /// </summary>
        public string ARBPL { get; set; }
        /// <summary>
        /// 短描述     CHAR	40
        /// </summary>
        public string KTEXT { get; set; }
        /// <summary>
        /// 控制码     CHAR	4
        /// </summary>
        public string STEUS { get; set; }
        /// <summary>
        /// 标准值 1	QUAN	9
        /// </summary>
        public string VGW01 { get; set; }
        /// <summary>
        ///  标准值 2	QUAN	9
        /// </summary>
        public string VGW02 { get; set; }
        /// <summary>
        ///  物料组     CHAR	9
        /// </summary>
        public string MATKL { get; set; }
        /// <summary>
        /// 外协加工的采购组    CHAR	3
        /// </summary>
        public string EKGRP { get; set; }
        /// <summary>
        ///  成本要素    CHAR	10
        /// </summary>
        public string SAKTO { get; set; }
        /// <summary>
        /// 价格  CURR	11
        /// </summary>
        public string PREIS { get; set; }
        /// <summary>
        /// 价格单位    DEC	5
        /// </summary>
        public string PEINH { get; set; }
        /// <summary>
        ///  货币码     CUKY	5
        /// </summary>
        public string WAERS { get; set; }
        /// <summary>
        ///  关键工序    CHAR	20
        /// </summary>
        public string USR00 { get; set; }
        /// <summary>
        /// 特殊过程    CHAR	20
        /// </summary>
        public string USR01 { get; set; }
        /// <summary>
        /// 质检标识    CHAR	10
        /// </summary>
        public string USR02 { get; set; }
        /// <summary>
        ///  任务清单组码  CHAR	8
        /// </summary>
        public string PLNNR { get; set; }
        /// <summary>
        ///  内部计数器   NUMC	8
        /// </summary>
        public string ZAEHL { get; set; }
        /// <summary>
        /// 删除标识    CHAR	1
        /// </summary>
        public string LOEKZ { get; set; }
        /// <summary>
        ///  对象标识    NUMC	8
        /// </summary>
        public string ARBID { get; set; }
        /// <summary>
        /// 活动类型1   CHAR	6
        /// </summary>
        public string LAR01 { get; set; }
        /// <summary>
        /// 标准值计量单位1    UNIT	3
        /// </summary>
        public string VGE01 { get; set; }
        /// <summary>
        /// 活动类型2   CHAR	6
        /// </summary>
        public string LAR02 { get; set; }
        /// <summary>
        /// 标准值计量单位 2	UNIT	3
        /// </summary>
        public string VGE02 { get; set; }
        /// <summary>
        /// 活动类型3   CHAR	6
        /// </summary>
        public string LAR03 { get; set; }
        /// <summary>
        /// 标准值计量单位3    UNIT	3
        /// </summary>
        public string VGE03 { get; set; }
        /// <summary>
        /// 活动类型4   CHAR	6
        /// </summary>
        public string LAR04 { get; set; }
        /// <summary>
        /// 标准值计量单位4    UNIT	3
        /// </summary>
        public string VGE04 { get; set; }
        /// <summary>
        /// 活动类型5   CHAR	6
        /// </summary>
        public string LAR05 { get; set; }
        /// <summary>
        /// 标准值计量单位 5	UNIT	3
        /// </summary>
        public string VGE05 { get; set; }
        /// <summary>
        /// 活动类型6   CHAR	6
        /// </summary>
        public string LAR06 { get; set; }
        /// <summary>
        ///  标准值计量单位 6	UNIT	3
        /// </summary>
        public string VGE06 { get; set; }
        /// <summary>
        /// 标准值3    QUAN	9
        /// </summary>
        public string VGW03 { get; set; }
        /// <summary>
        /// 标准值4    QUAN	9
        /// </summary>
        public string VGW04 { get; set; }
        /// <summary>
        /// 标准值5    QUAN	9
        /// </summary>
        public string VGW05 { get; set; }
        /// <summary>
        /// 标准值6    QUAN	9
        /// </summary>
        public string VGW06 { get; set; }
        /// <summary>
        /// 作业的计量单位     UNIT	3
        /// </summary>
        public string MEINH { get; set; }
        /// <summary>
        /// 日期记录创建于     DATS	8
        /// </summary>
        public string ANDAT { get; set; }
        /// <summary>
        /// 最后更改的日期 DATS	8
        /// </summary>
        public string AEDAT { get; set; }
        /// <summary>
        /// 最后更改的日期 DATS	8
        /// </summary>
        public string AEDAT_PLKO { get; set; }
        
    }

    #endregion
}
