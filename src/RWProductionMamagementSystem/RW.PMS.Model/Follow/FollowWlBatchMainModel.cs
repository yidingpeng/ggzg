using System;
using System.Collections.Generic;

namespace RW.PMS.Model.Follow
{
    /// <summary>
    /// 行迹物料盒配盘
    /// </summary>
    public class FollowWlBatchMainModel : BaseModel
    {
        #region 数据库原字段
        /// <summary>
        /// 配盘主表GUID
        /// </summary>
        public Guid fw_guid { get; set; }

        /// <summary>
        /// 追溯主表GUID
        /// </summary>
        public Guid? fm_guid { get; set; }

        /// <summary>
        /// 生产主表GUID
        /// </summary>
        public Guid? fp_guid { get; set; }

        /// <summary>
        /// 产品信息表ID
        /// </summary>
        public int? pInfo_ID { get; set; }

        /// <summary>
        /// 部件ID
        /// </summary>
        public int? fw_partId { get; set; }

        /// <summary>
        /// 部件名称
        /// </summary>
        public string fw_partName { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int? fw_gwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string fw_gwName { get; set; }

        /// <summary>
        /// 条码卡号，行迹物料盒卡号； 新的部件二维码
        /// </summary>
        public string fw_barcode { get; set; }

        /// <summary>
        /// 配料结果 0:未配盘;1:已配盘;2:部分配盘
        /// </summary>
        public int? fw_batchResult { get; set; }

        /// <summary>
        /// 配料完成时间
        /// </summary>
        public DateTime? fw_finishtime { get; set; }

        /// <summary>
        /// 状态 1:配盘;2:接收;
        /// </summary>
        public int? fw_status { get; set; }

        /// <summary>
        /// 配盘员
        /// </summary>
        public int? fw_operID { get; set; }

        /// <summary>
        /// 配盘时间
        /// </summary>
        public DateTime? fw_batchtime { get; set; }

        /// <summary>
        /// 配送时间
        /// </summary>
        public DateTime? fw_dispatchTime { get; set; }

        /// <summary>
        /// 接收员
        /// </summary>
        public int? fw_receiveID { get; set; }

        /// <summary>
        /// 接收时间
        /// </summary>
        public DateTime? fw_createtime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string fw_remark { get; set; }
        #endregion

        #region 显示字段

        /// <summary>
        /// 配盘结果显示文本
        /// </summary>
        public string fw_batchResultText
        {
            get
            {
                if (fw_batchResult == 1)
                    return "已配盘";
                if (fw_batchResult == 2)
                    return "部分配盘";
                return "未配盘";
            }
        }

        /// <summary>
        /// 计划主表GUID
        /// </summary>
        public Guid? pp_guid { get; set; }

        /// <summary>
        /// 计划编码
        /// </summary>
        public string pp_planCode { get; set; }

        /// <summary>
        /// 产品型号
        /// </summary>
        public int? pp_prodModelID { get; set; }

        /// <summary>
        /// 计划开始时间
        /// </summary>
        public DateTime? pp_startDate { get; set; }

        /// <summary>
        /// 计划完成日期
        /// </summary>
        public DateTime? pp_finishDate { get; set; }

        /// <summary>
        /// 计划开始时间显示文本
        /// </summary>
        public string pp_startDateText
        {
            get
            {
                if (pp_startDate == null)
                    return string.Empty;
                return pp_startDate.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 计划结束时间显示文本
        /// </summary>
        public string pp_finishDateText
        {
            get
            {
                if (pp_finishDate == null)
                    return string.Empty;
                return pp_finishDate.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public string bsbNo { get; set; }

        /// <summary>
        /// 地铁线路
        /// </summary>
        public string bsbLine { get; set; }

        /// <summary>
        /// 车型ID
        /// </summary>
        public int? bsbTypeID { get; set; }

        /// <summary>
        /// 车型名称
        /// </summary>
        public string bsbTypeName { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string pf_prodNo { get; set; }

        #endregion

        public string BatchResult { get; set; }

        /// <summary>
        /// 接收 Main 页面传入的 产品型号条件
        /// </summary>
        public int prodModelID { get; set; }

        public int pmid { get; set; }

        #region 搜索条件

        //产品型号
        public int Where_prodModelID { get; set; }

        //车型
        public int Where_subwayType { get; set; }

        //车厢号
        public string Where_compartNo { get; set; }

        //地铁线路
        public int Where_subwayNo { get; set; }

        //车号
        public string Where_carNo { get; set; }

        //转向架号
        public string Where_bogieNo { get; set; }

        //配料状态
        public int Where_batchResult { get; set; }

        //产品编号
        public string Where_prodNo { get; set; }

        //计划开始时间1
        public string Where_startDate { get; set; }

        //计划开始时间2
        public string Where_finishDate { get; set; }

        /// <summary>
        /// 模糊查询 车号
        /// </summary>
        public string LIKECarNo { get; set; }

        /// <summary>
        /// 模糊查询 地铁线路
        /// </summary>
        public string LIKELine { get; set; }

        /// <summary>
        /// 模糊查询 车厢号
        /// </summary>
        public string LIKECompartNo { get; set; }

        /// <summary>
        /// 模糊查询 转向架号
        /// </summary>
        public string LIKEBogieNo { get; set; }

        /// <summary>
        /// 模糊查询 产品编号
        /// </summary>
        public string LIKEProdNo { get; set; }

        /// <summary>
        /// 范围查询 计划开始日期 Start
        /// </summary>
        public string STARTPPStartDate { get; set; }
        /// <summary>
        /// 范围查询 计划开始日期 End
        /// </summary>
        public string ENDPPStartDate { get; set; }

        #endregion

        /// <summary>
        /// 配盘明细数据 用于接收json数据 配盘保存
        /// </summary>
        public string JSONDetailList { get; set; }
        public List<FollowWlBatchDetailModel> detailList { get; set; }
    }
}
