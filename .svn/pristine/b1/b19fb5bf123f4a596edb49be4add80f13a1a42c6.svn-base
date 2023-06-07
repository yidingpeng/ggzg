using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPRFC.Models.ZFM_PP_CONF_CREATE_RFC//生产订单报工接口
{
    #region 输入参数
    public class IV_SYSID
    {
        /// <summary>
        ///  调用接口系统编号    CHAR	3		001为BPM，002为KDE（金蝶K3），003为PLM，004为CAPP
        /// </summary>
        public string SYSID { get; set; }
    }
    
    public class IV_SEQNO
    {
        /// <summary>
        /// 系统调用单流水号    CHAR	220		
        /// </summary>
        public string SEQNO { get; set; }
    }
    public class IT_CONF
    {
        /// <summary>
        /// 生产订单号 CHAR	12	Y
        /// </summary>
        public string ORDERID { get; set; }
        /// <summary>
        /// 工序号 CHAR	4	Y
        /// </summary>
        public string OPERATION { get; set; }
        /// <summary>
        /// 过账日期 CHAR	8	Y
        /// </summary>
        public string POSTG_DATE { get; set; }
        /// <summary>
        /// 完工数量 QUAN	13	Y
        /// </summary> 
        public string YIELD { get; set; }
        /// <summary>
        /// 报废数量 QUAN	13
        /// </summary>
        public string SCRAP { get; set; }
        /// <summary>
        /// 人工工时 QUAN	13	Y
        /// </summary>
        public string CONF_ACTIVITY1 { get; set; }
        /// <summary>
        /// 人工工时单位 CHAR	3	Y
        /// </summary>
        public string CONF_ACTI_UNIT1 { get; set; }
        /// <summary>
        /// 机器工时 QUAN	13	Y
        /// </summary>
        public string CONF_ACTIVITY2 { get; set; }
        /// <summary>
        /// 机器工时单位 CHAR	3	Y
        /// </summary>
        public string CONF_ACTI_UNIT2 { get; set; }
        /// <summary>
        /// 机器工时 QUAN	13
        /// </summary>
        public string CONF_ACTIVITY3 { get; set; }
        /// <summary>
        /// 机器工时单位 CHAR	3
        /// </summary>
        public string CONF_ACTI_UNIT3 { get; set; }
        /// <summary>
        /// 机器工时 QUAN	13
        /// </summary>
        public string CONF_ACTIVITY4 { get; set; }
        /// <summary>
        /// 机器工时单位 CHAR	3
        /// </summary>
        public string CONF_ACTI_UNIT4 { get; set; }
        /// <summary>
        /// 机器工时 QUAN	13
        /// </summary>
        public string CONF_ACTIVITY5 { get; set; }
        /// <summary>
        /// 机器工时单位 CHAR	3
        /// </summary>
        public string CONF_ACTI_UNIT5 { get; set; }
        /// <summary>
        /// 机器工时 QUAN	13	
        /// </summary>
        public string CONF_ACTIVITY6 { get; set; }
        /// <summary>
        /// 机器工时单位 CHAR	3
        /// </summary>
        public string CONF_ACTI_UNIT6 { get; set; }
        /// <summary>
        /// 报工确认号 CHAR	10
        /// </summary>
        public string CONF_NO { get; set; }
        /// <summary>
        /// 报工确认号行号 CHAR	8
        /// </summary>
        public string CONF_CNT { get; set; }
        /// <summary>
        /// 报工标识符 CHAR	1	
        /// </summary>
        public string ZIND { get; set; }
        /// <summary>
        /// 报工标识符 CHAR	1
        /// </summary>
        public string ZQS { get; set; }
    }
    #endregion

    #region 返回参数
    public class EV_SYMBOL
    {
        /// <summary>
        /// 调用结果 CHAR    1		S为成功，E为失败
        /// </summary>
        public string SYMBOL { get; set; } 
    }

    public class ET_RETURN
    {
        /// <summary>
        /// 报工确认号   CHAR	10	
        /// </summary>
        public string CONF_NO { get; set; }
        /// <summary>
        ///  报工确认号行号 CHAR	8	
        /// </summary>
        public string CONF_CNT { get; set; }
        /// <summary>
        ///  生产订单号   CHAR	12	
        /// </summary>
        public string ORDERID { get; set; }
        /// <summary>
        /// 工序  CHAR	4	
        /// </summary>
        public string OPERATION { get; set; }
        /// <summary>
        ///  消息类型: S 成功, E 错误 CHAR	1	
        /// </summary>
        public string TYPE { get; set; }
        /// <summary>
        /// 消息文本    CHAR 	220	
        /// </summary>
        public string MESSAGE { get; set; }
    }

    #endregion
}
