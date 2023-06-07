using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPRFC.Models.ZFM_PP_PRODORD_GET_RFC //生产订单订单传递
{
    #region 输入参数表

    /// <summary>
    /// 订单号
    /// </summary>
    public class IT_AUFNR
    {
        /// <summary>
        ///  CHAR 12 订单号-从 
        /// </summary>
        public string LOW { get; set; }
        /// <summary>
        /// CHAR 12 订单号-至 
        /// </summary>
        public string HIGH { get; set; }
    }

    /// <summary>
    /// 工厂
    /// </summary>
    public class IT_WERKS
    {
        /// <summary>
        /// CHAR 4 工厂-从 
        /// </summary>
        public string LOW { get; set; }
        /// <summary>
        /// CHAR 4 工厂-至 
        /// </summary>
        public string HIGH { get; set; }
    }

    /// <summary>
    /// 下达日期
    /// </summary>
    public class IT_RDATE
    {
        /// <summary>
        /// DATA 4 下达日期-从 
        /// </summary>
        public string LOW { get; set; }
        /// <summary>
        /// DATA 4 下达日期-至 
        /// </summary>
        public string HIGH { get; set; }
    }

    /// <summary>
    /// 生产管理员
    /// </summary>
    public class IT_FEVOR
    {
        /// <summary>
        /// CHAR 3 生产管理员-从 
        /// </summary>
        public string LOW { get; set; }
        /// <summary>
        /// CHAR 3 生产管理员-至 
        /// </summary>
        public string HIGH { get; set; }
    }

    #endregion

    #region 返回参数：表
    public class ET_HEADER
    {
        /// <summary>
        /// 订单号     CHAR	12
        /// </summary>
        public string ORDER_NUMBER { get; set; }
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string PRODUCTION_PLANT { get; set; }
        /// <summary>
        ///  MRP控制者  CHAR	1
        /// </summary>
        public string MRP_CONTROLLER { get; set; }
        /// <summary>
        /// 生产管理员   CHAR	3
        /// </summary>
        public string PRODUCTION_SCHEDULER { get; set; }
        /// <summary>
        /// 物料编号    CHAR	18
        /// </summary>
        public string MATERIAL { get; set; }
        /// <summary>
        /// BOM展开/工艺路线转换的日期 CHAR	8
        /// </summary>
        public string EXPL_DATE { get; set; }
        /// <summary>
        /// 订单中工序的工艺路线号     CHAR	10
        /// </summary>
        public string ROUTING_NO { get; set; }
        /// <summary>
        ///  预留/相关需求的编号 DATS	10
        /// </summary>
        public string RESERVATION_NUMBER { get; set; }
        /// <summary>
        ///  计划下达日期  NUMC	8
        /// </summary>
        public string SCHED_RELEASE_DATE { get; set; }
        /// <summary>
        ///  实际下达日期  NUMC	8
        /// </summary>
        public string ACTUAL_RELEASE_DATE { get; set; }
        /// <summary>
        ///  基本完成日期  DATS	8
        /// </summary>
        public string FINISH_DATE { get; set; }
        /// <summary>
        ///    基本开始日期  DATS	8
        /// </summary>
        public string START_DATE { get; set; }
        /// <summary>
        ///  计划完工    DATS	8
        /// </summary>
        public string PRODUCTION_FINISH_DATE { get; set; }
        /// <summary>
        ///  排产开始    DATS	8
        /// </summary>
        public string PRODUCTION_START_DATE { get; set; }
        /// <summary>
        ///  实际开始日期  DATS	8
        /// </summary>
        public string ACTUAL_START_DATE { get; set; }
        /// <summary>
        ///   实际结束日期  DATS	8
        /// </summary>
        public string ACTUAL_FINISH_DATE { get; set; }
        /// <summary>
        ///  订单中总计废品数量   DATS	13
        /// </summary>
        public string SCRAP { get; set; }
        /// <summary>
        ///  订单数量总计  DATS	13
        /// </summary>
        public string TARGET_QUANTITY { get; set; }
        /// <summary>
        /// 全部订单项通用单位   QUAN	3
        /// </summary>
        public string UNIT { get; set; }
        /// <summary>
        ///   计量单位的 ISO 代码    QUAN	3
        /// </summary>
        public string UNIT_ISO { get; set; }
        /// <summary>
        ///  订单优先级   UNIT	1
        /// </summary>
        public string PRIORITY { get; set; }
        /// <summary>
        ///  订单类型    CHAR	4
        /// </summary>
        public string ORDER_TYPE { get; set; }
        /// <summary>
        ///  输入者     CHAR	12
        /// </summary>
        public string ENTERED_BY { get; set; }
        /// <summary>
        /// 创建日期    CHAR	8
        /// </summary>
        public string ENTER_DATE { get; set; }
        /// <summary>
        /// 删除标志    CHAR	1
        /// </summary>
        public string DELETION_FLAG { get; set; }
        /// <summary>
        /// 工作分解结构元素(WBS 元素)   DATS	8
        /// </summary>
        public string WBS_ELEMENT { get; set; }
        /// <summary>
        /// 操作完成的确认编号   CHAR	10
        /// </summary>
        public string CONF_NO { get; set; }
        /// <summary>
        ///  内部计数器   NUMC	8
        /// </summary>
        public string CONF_CNT { get; set; }
        /// <summary>
        /// 配置(内部对象号)   NUMC	18
        /// </summary>
        public string INT_OBJ_NO { get; set; }
        /// <summary>
        ///   计划完成时间  NUMC	6
        /// </summary>
        public string SCHED_FIN_TIME { get; set; }
        /// <summary>
        ///  计划开始（时间） 	NUMC	6
        /// </summary>
        public string SCHED_START_TIME { get; set; }
        /// <summary>
        ///  指示符 : 订单是汇总订单的一部分 TIMS	1
        /// </summary>
        public string COLLECTIVE_ORDER { get; set; }
        /// <summary>
        /// 顺序号订单   TIMS	14
        /// </summary>
        public string ORDER_SEQ_NO { get; set; }
        /// <summary>
        /// 基本完成（时间）	CHAR	6
        /// </summary>
        public string FINISH_TIME { get; set; }
        /// <summary>
        ///  基本的开始时间     NUMC	6
        /// </summary>
        public string START_TIME { get; set; }
        /// <summary>
        ///  实际开始时间  TIMS	6
        /// </summary>
        public string ACTUAL_START_TIME { get; set; }
        /// <summary>
        ///   当前处理的提前订单   TIMS	12
        /// </summary>
        public string LEADING_ORDER { get; set; }
        /// <summary>
        ///   销售订单数   TIMS	10
        /// </summary>
        public string SALES_ORDER { get; set; }
        /// <summary>
        /// 销售订单中的条款数   CHAR	6
        /// </summary>
        public string SALES_ORDER_ITEM { get; set; }
        /// <summary>
        ///  生产计划参数文件    CHAR	6
        /// </summary>
        public string PROD_SCHED_PROFILE { get; set; }
        /// <summary>
        ///  物料描述    NUMC	40
        /// </summary>
        public string MATERIAL_TEXT { get; set; }
        /// <summary>
        /// 系统状态    CHAR	40
        /// </summary>
        public string SYSTEM_STATUS { get; set; }
        /// <summary>
        ///  根据 ATP 核查组件确认的订单数量  CHAR	13
        /// </summary>
        public string CONFIRMED_QUANTITY { get; set; }
        /// <summary>
        /// 计划工厂    CHAR	4
        /// </summary>
        public string PLAN_PLANT { get; set; }
        /// <summary>
        ///  MATERIAL 批号  QUAN	10
        /// </summary>
        public string BATCH { get; set; }
        /// <summary>
        ///   MATERIAL 字段的长物料号 CHAR	40
        /// </summary>
        public string MATERIAL_EXTERNAL { get; set; }
        /// <summary>
        /// 字段的外部 GUID CHAR	32
        /// </summary>
        public string MATERIAL_GUID { get; set; }
        /// <summary>
        /// MATERIAL 字段的版本编号 CHAR	10
        /// </summary>
        public string MATERIAL_VERSION { get; set; }
        /// <summary>
        /// 最佳使用日期(BBD)/ 货架寿命过期日期(SLED)   CHAR	8
        /// </summary>
        public string DATE_OF_EXPIRY { get; set; }
        /// <summary>
        /// 生产日期    CHAR	8
        /// </summary>
        public string DATE_OF_MANUFACTURE { get; set; }
        /// <summary>
        /// 物料编号（40 字符，出于技术原因需要）	DATS	40
        /// </summary>
        public string MATERIAL_LONG { get; set; }
        /// <summary>
        /// 存储位置    CHAR	4
        /// </summary>
        public string LGORT { get; set; }
        /// <summary>
        ///   LONG text CHAR	200
        /// </summary>
        public string TEXT { get; set; }
        /// <summary>
        ///  前段实际班组  CHAR	10
        /// </summary>
        public string R1BZ2 { get; set; }

    }
    public class ET_OPERATION
    {
        /// <summary>
        ///  订单号     DATS	12
        /// </summary>
        public string ORDER_NUMBER { get; set; }
        /// <summary>
        /// 订单中工序的工艺路线号     CHAR	10
        /// </summary>
        public string ROUTING_NO { get; set; }
        /// <summary>
        /// 订单的通用计数器    CHAR	8
        /// </summary>
        public string COUNTER { get; set; }
        /// <summary>
        /// 序列  NUMC	6
        /// </summary>
        public string SEQUENCE_NO { get; set; }
        /// <summary>
        /// 操作完成的确认编号   NUMC	10
        /// </summary>
        public string CONF_NO { get; set; }
        /// <summary>
        ///   确认计数器   CHAR	8
        /// </summary>
        public string CONF_CNT { get; set; }
        /// <summary>
        /// 请购单号    NUMC	10
        /// </summary>
        public string PURCHASE_REQ_NO { get; set; }
        /// <summary>
        /// 订单中请购单的项目号  NUMC	5
        /// </summary>
        public string PURCHASE_REQ_ITEM { get; set; }
        /// <summary>
        /// 组计数器    CHAR	2
        /// </summary>
        public string GROUP_COUNTER { get; set; }
        /// <summary>
        /// 任务清单类型  NUMC	1
        /// </summary>
        public string TASK_LIST_TYPE { get; set; }
        /// <summary>
        /// 任务清单组码  CHAR	8
        /// </summary>
        public string TASK_LIST_GROUP { get; set; }
        /// <summary>
        /// 活动编号    CHAR	4
        /// </summary>
        public string OPERATION_NUMBER { get; set; }
        /// <summary>
        /// 控制码     CHAR	4
        /// </summary>
        public string OPR_CNTRL_KEY { get; set; }
        /// <summary>
        /// 工厂  CHAR	4
        /// </summary>
        public string PROD_PLANT { get; set; }
        /// <summary>
        /// 工序短文本   CHAR	40
        /// </summary>
        public string DESCRIPTION { get; set; }
        /// <summary>
        ///  说明第二行   CHAR	40
        /// </summary>
        public string DESCRIPTION2 { get; set; }
        /// <summary>
        /// 标准值码    CHAR	4
        /// </summary>
        public string STANDARD_VALUE_KEY { get; set; }
        /// <summary>
        /// 活动类型    CHAR	6
        /// </summary>
        public string ACTIVITY_TYPE_1 { get; set; }
        /// <summary>
        /// 活动类型    CHAR	6
        /// </summary>
        public string ACTIVITY_TYPE_2 { get; set; }
        /// <summary>
        /// 活动类型    CHAR	6
        /// </summary>
        public string ACTIVITY_TYPE_3 { get; set; }
        /// <summary>
        /// 活动类型    CHAR	6
        /// </summary>
        public string ACTIVITY_TYPE_4 { get; set; }
        /// <summary>
        /// 活动类型    CHAR	6
        /// </summary>
        public string ACTIVITY_TYPE_5 { get; set; }
        /// <summary>
        /// 活动类型    CHAR	6
        /// </summary>
        public string ACTIVITY_TYPE_6 { get; set; }
        /// <summary>
        /// 作业的计量单位     CHAR	3
        /// </summary>
        public string UNIT { get; set; }
        /// <summary>
        ///  计量单位的 ISO 代码    CHAR	3
        /// </summary>
        public string UNIT_ISO { get; set; }
        /// <summary>
        /// 工序数量    UNIT	13
        /// </summary>
        public string QUANTITY { get; set; }
        /// <summary>
        /// 工序废品    CHAR	13
        /// </summary>
        public string SCRAP { get; set; }
        /// <summary>
        /// 最早计划开始：执行(日期)   QUAN	8
        /// </summary>
        public string EARL_SCHED_START_DATE_EXEC { get; set; }
        /// <summary>
        /// 最早计划开始：执行(时间)   QUAN	6
        /// </summary>
        public string EARL_SCHED_START_TIME_EXEC { get; set; }
        /// <summary>
        /// 最早计划开始：处理(日期)   DATS	8
        /// </summary>
        public string EARL_SCHED_START_DATE_PROC { get; set; }
        /// <summary>
        /// 最早计划开始：处理(时间)   TIMS	6
        /// </summary>
        public string EARL_SCHED_START_TIME_PROC { get; set; }
        /// <summary>
        /// 最早计划开始：拆卸(日期)   DATS	8
        /// </summary>
        public string EARL_SCHED_START_DATE_TEARD { get; set; }
        /// <summary>
        /// 最早计划开始：拆卸(时间)   TIMS	6
        /// </summary>
        public string EARL_SCHED_START_TIME_TEARD { get; set; }
        /// <summary>
        /// 最早计划完工：执行(日期)   DATS	8
        /// </summary>
        public string EARL_SCHED_FIN_DATE_EXEC { get; set; }
        /// <summary>
        /// 最早计划完工：执行(时间)   TIMS	6
        /// </summary>
        public string EARL_SCHED_FIN_TIME_EXEC { get; set; }
        /// <summary>
        /// 最迟计划开始：执行（日期）	DATS	8
        /// </summary>
        public string LATE_SCHED_START_DATE_EXEC { get; set; }
        /// <summary>
        /// 最迟计划开始： 执行（时间）	TIMS	6
        /// </summary>
        public string LATE_SCHED_START_TIME_EXEC { get; set; }
        /// <summary>
        /// 最迟计划开始： 加工（日期）	DATS	8
        /// </summary>
        public string LATE_SCHED_START_DATE_PROC { get; set; }
        /// <summary>
        /// 最迟计划开始： 加工(时间)    TIMS	6
        /// </summary>
        public string LATE_SCHED_START_TIME_PROC { get; set; }
        /// <summary>
        /// 最迟计划开始： 清理（日期）	DATS	8
        /// </summary>
        public string LATE_SCHED_START_DATE_TEARD { get; set; }
        /// <summary>
        ///  最迟计划开始： 清理（时间）	TIMS	6
        /// </summary>
        public string LATE_SCHED_START_TIME_TEARD { get; set; }
        /// <summary>
        /// 最迟计划完成：执行（日期）	DATS	8
        /// </summary>
        public string LATE_SCHED_FIN_DATE_EXEC { get; set; }
        /// <summary>
        /// 最迟计划完成：执行（时间）	TIMS	6
        /// </summary>
        public string LATE_SCHED_FIN_TIME_EXEC { get; set; }
        /// <summary>
        ///  工作中心    DATS	8
        /// </summary>
        public string WORK_CENTER { get; set; }
        /// <summary>
        ///  工作中心描述  TIMS	40
        /// </summary>
        public string WORK_CENTER_TEXT { get; set; }
        /// <summary>
        /// 系统状态    CHAR	40
        /// </summary>
        public string SYSTEM_STATUS { get; set; }
        /// <summary>
        /// 子工序     CHAR	4
        /// </summary>
        public string SUBOPERATION { get; set; }

    }
    public class ET_COMPONENT
    {
        /// <summary>
        /// _NUMBER 预留/相关需求的编号 CHAR	10
        /// </summary>
        public string RESERVATION { get; set; }
        /// <summary>
        ///  预留 / 相关需求的项目编号 CHAR	4
        /// </summary>
        public string RESERVATION_ITEM { get; set; }
        /// <summary>
        ///记录类型    NUMC	1 
        /// </summary>
        public string RESERVATION_TYPE { get; set; }
        /// <summary>
        ///项目已删除   NUMC	1 
        /// </summary>
        public string DELETION_INDICATOR { get; set; }
        /// <summary>
        /// 物料编号    CHAR	18
        /// </summary>
        public string MATERIAL { get; set; }
        /// <summary>
        ///工厂  CHAR	4 
        /// </summary>
        public string PROD_PLANT { get; set; }
        /// <summary>
        /// 存储位置    CHAR	4
        /// </summary>
        public string STORAGE_LOCATION { get; set; }
        /// <summary>
        /// 产品供应范围  CHAR	10
        /// </summary>
        public string SUPPLY_AREA { get; set; }
        /// <summary>
        /// 批号  CHAR	10
        /// </summary>
        public string BATCH { get; set; }
        /// <summary>
        /// 特殊库存标识  CHAR	1
        /// </summary>
        public string SPECIAL_STOCK { get; set; }
        /// <summary>
        /// 组件的需求日期     CHAR	8
        /// </summary>
        public string REQ_DATE { get; set; }
        /// <summary>
        /// 需求量 CHAR	13
        /// </summary>
        public string REQ_QUAN { get; set; }
        /// <summary>
        /// 基本计量单位  DATS	3
        /// </summary>
        public string BASE_UOM { get; set; }
        /// <summary>
        ///  计量单位的 ISO 代码    QUAN	3
        /// </summary>
        public string BASE_UOM_ISO { get; set; }
        /// <summary>
        ///  提货数     UNIT	13
        /// </summary>
        public string WITHDRAWN_QUANTITY { get; set; }
        /// <summary>
        /// 以录入项单位表示的数量     CHAR	13
        /// </summary>
        public string ENTRY_QUANTITY { get; set; }
        /// <summary>
        ///   条目单位    QUAN	3
        /// </summary>
        public string ENTRY_UOM { get; set; }
        /// <summary>
        /// 计量单位的 ISO 代码    QUAN	3
        /// </summary>
        public string ENTRY_UOM_ISO { get; set; }
        /// <summary>
        /// 订单号     UNIT	12
        /// </summary>
        public string ORDER_NUMBER { get; set; }
        /// <summary>
        /// 移动类型(库存管理)  CHAR	3
        /// </summary>
        public string MOVEMENT_TYPE { get; set; }
        /// <summary>
        ///  项目类别（物料单） 	CHAR	1
        /// </summary>
        public string ITEM_CATEGORY { get; set; }
        /// <summary>
        /// BOM 项目号 CHAR	4
        /// </summary>
        public string ITEM_NUMBER { get; set; }
        /// <summary>
        ///  序列  CHAR	6
        /// </summary>
        public string SEQUENCE { get; set; }
        /// <summary>
        ///   活动编号    CHAR	4
        /// </summary>
        public string OPERATION { get; set; }
        /// <summary>
        ///  标识：反冲 CHAR	1
        /// </summary>
        public string BACKFLUSH { get; set; }
        /// <summary>
        ///  特定库存的评估     CHAR	1
        /// </summary>
        public string VALUATION_SPEC_STOCK { get; set; }
        /// <summary>
        /// 编辑状态文本  CHAR	40
        /// </summary>
        public string SYSTEM_STATUS { get; set; }
        /// <summary>
        /// 物料描述    CHAR	40
        /// </summary>
        public string MATERIAL_DESCRIPTION { get; set; }
        /// <summary>
        ///  承诺数量    QUAN	13
        /// </summary>
        public string COMMITED_QUANTITY { get; set; }
        /// <summary>
        ///  短缺  QUAN	13
        /// </summary>
        public string SHORTAGE { get; set; }
        /// <summary>
        /// 采购申请编号  CHAR	10
        /// </summary>
        public string PURCHASE_REQ_NO { get; set; }
        /// <summary>
        /// 采购申请的项目编号   NUMC	5
        /// </summary>
        public string PURCHASE_REQ_ITEM { get; set; }
        /// <summary>
        ///  MATERIAL 字段的长物料号 CHAR	40
        /// </summary>
        public string MATERIAL_EXTERNAL { get; set; }
        /// <summary>
        ///  MATERIAL 字段的外部 GUID CHAR	32
        /// </summary>
        public string MATERIAL_GUID { get; set; }
        /// <summary>
        /// MATERIAL 字段的版本编号 CHAR	10
        /// </summary>
        public string MATERIAL_VERSION { get; set; }
        /// <summary>
        ///  需求段 CHAR	16
        /// </summary>
        public string REQ_SEGMENT { get; set; }
        /// <summary>
        /// 库存细分    CHAR	16
        /// </summary>
        public string STOCK_SEGMENT { get; set; }
        /// <summary>
        /// 物料编号（40 字符，出于技术原因需要）	CHAR	40
        /// </summary>
        public string MATERIAL_LONG { get; set; }
        /// <summary>
        /// 替代项目：组 CHAR	2
        /// </summary>
        public string ALT_ITEM_GROUP { get; set; }
        /// <summary>
        /// 使用可能性按%(可选项目)	DEC	3
        /// </summary>
        public string USAGE_PROB { get; set; }
        /// <summary>
        ///  替代项目：评比订单 NUMC	2
        /// </summary>
        public string ALT_ITEM_PRIO { get; set; }
        /// <summary>
        ///  替代项目：策略 CHAR	1
        /// </summary>
        public string ALT_ITEM_STRATEGY { get; set; }
    }
    public class ET_VGW
    {
        /// <summary>
        ///  订单号 CHAR	12
        /// </summary>
        public string AUFNR { get; set; }
        /// <summary>
        /// 活动编号    CHAR	4
        /// </summary>
        public string VORNR { get; set; }
        /// <summary>
        /// 标准值 QUAN	9
        /// </summary>
        public string VGW01 { get; set; }
        /// <summary>
        /// 标准值计量单位 UNIT	3
        /// </summary>
        public string VGE01 { get; set; }
        /// <summary>
        /// 标准值 QUAN	9
        /// </summary>
        public string VGW02 { get; set; }
        /// <summary>
        /// 标准值计量单位 UNIT	3
        /// </summary>
        public string VGE02 { get; set; }
        /// <summary>
        /// 是否有组件分配 CHAR	1
        /// </summary>
        public string FLG_KMP { get; set; }

    }
    #endregion
}
