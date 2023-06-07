using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 条码卡信息实体类
    /// </summary>
    public class BaseBarcodeModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 条形码,编码唯一
        /// </summary>
        public string c_cardNo { get; set; }
        /// <summary>
        /// 卡类型：物料框、关键部件，取基础数据字典表
        /// </summary>
        public int? c_cardType { get; set; }
        /// <summary>
        /// 卡类型文本值
        /// </summary>
        public string c_cardTypeText { get; set; }
        /// <summary>
        /// 物料框的组装工位ID，取自base_gongwei表
        /// </summary>
        public int? c_AmsGwID { get; set; }
        /// <summary>
        /// 物料框的存放位置
        /// </summary>
        public string c_putLocation { get; set; }
        /// <summary>
        /// 物料框的组装工位文本值
        /// </summary>
        public string c_AmsGwText { get; set; }
        /// <summary>
        /// 当前区域ID
        /// </summary>
        public int? c_curAreaID { get; set; }
        /// <summary>
        /// 当前区域文本值
        /// </summary>
        public string c_curAreaText { get; set; }
        /// <summary>
        /// 当前工位ID
        /// </summary>
        public int? c_curGwID { get; set; }
        /// <summary>
        /// 当前工位文本值
        /// </summary>
        public string c_curGwText { get; set; }
        /// <summary>
        /// 当前追溯主表GUID
        /// </summary>
        public Guid? c_curFmGuid { get; set; }
        /// <summary>
        /// 当前产品编号
        /// </summary>
        public string c_curProdNo { get; set; }
        /// <summary>
        /// 当前组件ID
        /// </summary>
        public int? c_curComponentId { get; set; }
        /// <summary>
        /// 当前组件名称
        /// </summary>
        public string c_curComponentName { get; set; }
        /// <summary>
        /// 当前大部件钢印号/阀编码
        /// </summary>
        public string c_curStampNo { get; set; }
        /// <summary>
        /// 卡状态：0启用；1禁用
        /// </summary>
        public int? c_status { get; set; }
        /// <summary>
        /// 状态文本值
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string c_remark { get; set; }
        /// <summary>
        /// 多行条形码卡号
        /// </summary>
        public string ManyC_cardNo { get; set; }
        /// <summary>
        /// 生成数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 计划ID 追溯主表关联生产主表关联到的计划ID
        /// </summary>
        public Guid? pp_guid { get; set; }

        /// <summary>
        /// 系统产品编号 追溯主表关联生产主表关联到的系统产品编号
        /// </summary>
        public string fp_prodNo_sys { get; set; }

        /// <summary>
        /// 根据C_cardType 字段数据字典中名称
        /// </summary>
        public string bdname { get; set; }

        /// <summary>
        /// 根据C_cardType 字段数据字典中值
        /// </summary>
        public string bdvalue { get; set; }

        /// <summary>
        /// 产品信息ID
        /// </summary>
        public int? c_pInfoID { get; set; }

        /// <summary>
        /// 绑码人ID
        /// </summary>
        public int? c_operID { get; set; }

        /// <summary>
        /// 此条码卡存放区域ID
        /// </summary>
        public int? c_TAID { get; set; }

        /// <summary>
        /// 查询条件,不等于此ID
        /// </summary>
        public int UnID { get; set; }

        /// <summary>
        /// 存放部件检验状态
        /// </summary>
        public int? ta_InspectionStatus { get; set; }

        /// <summary>
        /// 1: 存放 0：取出
        /// </summary>
        public int? OperatingState { get; set; }

    }
}
