using System.Collections.Generic;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 工位信息表
    /// </summary>
    public class BaseGongweiModel : BaseModel
    {
        /// <summary>
        /// 工位 构造函数
        /// </summary>
        public BaseGongweiModel()
        {
            OPC = new List<BaseGongweiOpcModel>();
        }

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 工位编码
        /// </summary>
        public string gwcode { get; set; }
        /// <summary>
        /// 工位名称
        /// </summary>
        public string gwname { get; set; }
        /// <summary>
        /// 工位状态
        /// </summary>
        public int? gwStatus { get; set; }
        /// <summary>
        /// 工位状态文本值
        /// </summary>
        public string Status
        {
            get
            {
                if (gwStatus == 1)
                    return "禁用";
                return "启用";
            }
        }
        /// <summary>
        /// 终端IP
        /// </summary>
        public string IP { get; set; }
        /// <summary>
        /// 工位区域
        /// </summary>
        public int? areaID { get; set; }
        /// <summary>
        /// 工位区域编码
        /// </summary>
        public string areaCode { get; set; }
        /// <summary>
        /// 工位区域名称
        /// </summary>
        public string areaName { get; set; }
        /// <summary>
        /// 工位排序
        /// </summary>
        public int? gwOrder { get; set; }
        /// <summary>
        /// 是否是组装总装工位
        /// </summary>
        public int? isFinishGW { get; set; }
        /// <summary>
        /// 是否是组装总装工位文本值
        /// </summary>
        public string isFinishGWText
        {
            get
            {
                if (isFinishGW == 1)
                    return "是";
                return "否";
            }
        }
        /// <summary>
        /// 是否是组装总装工位bool值
        /// </summary>
        public bool BFinishGWS { get; set; }
        /// <summary>
        /// 当前工位是否有追溯系统
        /// </summary>
        public int? isHasFollow { get; set; }
        /// <summary>
        /// 是否有追溯系统文本值
        /// </summary>
        public string isHasFollowText
        {
            get
            {
                if (isHasFollow == 1)
                    return "是";
                return "否";
            }
        }

        /// <summary>
        /// 是否有追溯系统bool值
        /// </summary>
        public bool bHasFollowS { get; set; }

        /// <summary>
        /// 是否有装配管理系统
        /// </summary>
        public int? isHasAms { get; set; }

        /// <summary>
        /// 是否有装配管理系统文本值
        /// </summary>
        public string isHasAmsText
        {
            get
            {
                if (isHasAms == 1)
                    return "是";
                return "否";
            }
        }


        /// <summary>
        /// 是否需启动OPC驱动
        /// </summary>
        public int? isOPC { get; set; }

        /// <summary>
        /// 是否需启动OPC驱动文本值
        /// </summary>
        public string isOPCText
        {
            get
            {
                if (isOPC == 1)
                    return "是";
                return "否";
            }
        }


        /// <summary>
        /// 是否需启动OPC驱动bool值
        /// </summary>
        public bool bIsOPCS { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// AGV地址
        /// </summary>
        public string agvAddress { get; set; }

        /// <summary>
        /// OPC点位集合
        /// </summary>
        public IEnumerable<BaseGongweiOpcModel> OPC { get; set; }

    }
}
