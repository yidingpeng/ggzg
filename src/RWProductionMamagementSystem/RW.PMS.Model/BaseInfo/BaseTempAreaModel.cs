using System;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 区域存放区
    /// </summary>
    public class BaseTempAreaModel : BaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ta_ID { get; set; }

        /// <summary>
        /// 区域编码
        /// </summary>
        public string ta_areaCode { get; set; }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int? ta_areaID { get; set; }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string ta_areaName { get; set; }

        /// <summary>
        /// 组号
        /// </summary>
        public int? ta_groupIndex { get; set; }

        /// <summary>
        /// 行号
        /// </summary>
        public int? ta_rowIndex { get; set; }

        /// <summary>
        /// 列号
        /// </summary>
        public int? ta_colIndex { get; set; }

        /// <summary>
        /// 默认颜色
        /// </summary>
        public string ta_defaultColor { get; set; }

        /// <summary>
        /// 待放颜色
        /// </summary>
        public string ta_stayPutColor { get; set; }

        /// <summary>
        /// 存放颜色
        /// </summary>
        public string ta_inPutColor { get; set; }

        /// <summary>
        /// 当前生产主表ID
        /// </summary>
        public Guid? ta_curFmGuid { get; set; }

        /// <summary>
        /// 计划主表ID
        /// </summary>
        public Guid? ta_planGuid { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string pf_prodNo { get; set; }

        /// <summary>
        /// 系统产品编号
        /// </summary>
        public string ta_curSysProdNo { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string prodModelName { get; set; }

        /// <summary>
        /// 存放状态
        /// </summary>
        public int? ta_status { get; set; }

        /// <summary>
        /// 检验状态
        /// </summary>
        public int? ta_InspectionStatus { get; set; }


        public string ta_InspectionStatusText {

            get {
                if (ta_InspectionStatus == 0) {
                    return "不合格";
                }
                if (ta_InspectionStatus == 1) {
                    return "合格";
                }
                return "空";
            }
        }


        /// <summary>
        /// 存放状态（显示）
        /// </summary>
        public string ta_statusText { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ta_remark { get; set; }

        /// <summary>
        /// 部件名称
        /// </summary>
        public string ta_PartName { get; set; }

        /// <summary>
        /// opc存放Q点
        /// </summary>
        public string ta_opcStoreQ { get; set; }

        /// <summary>
        /// opc存放I点
        /// </summary>
        public string ta_opcStoreI { get; set; }

        /// <summary>
        /// 是否有系统产品编号-作查询条件用
        /// </summary>
        public bool hasSysProdNo { get; set; }

        /// <summary>
        /// 车厢号
        /// </summary>
        public string pf_compartNo { get; set; }

        /// <summary>
        /// 转向架号
        /// </summary>
        public string pf_bogieNo { get; set; }

        /// <summary>
        /// 产品信息ID
        /// </summary>
        public int? fp_pInfo_ID { get; set; }

        /// <summary>
        /// 操作者ID
        /// </summary>
        public int? inOper { get; set; }

        /// <summary>
        /// 存放时间
        /// </summary>
        public DateTime? inTime { get; set; }

        public string inTimeText
        {
            get
            {
                if (inTime == null)
                    return "";
                return inTime.Value.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string pModelName { get; set; }

        /// <summary>
        /// 地铁线路
        /// </summary>
        public string subWayNoName { get; set; }



        /// <summary>
        /// ID
        /// </summary>
        public int UNID { get; set; }



    }
}