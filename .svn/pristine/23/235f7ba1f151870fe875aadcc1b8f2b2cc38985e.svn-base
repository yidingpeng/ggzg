
using System;
namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 产品关键零部件
    /// </summary>
    public class BaseProductBomModel : BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int ID { get; set; }
         
        /// <summary>
        /// 产品型号ID
        /// </summary>
        public int? prodModelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Pmodel { get; set; }

        /// <summary>
        /// 产品型号名称
        /// </summary>
        public string ProdModelName { get; set; }

        /// <summary>
        /// 部件ID,取物料表的组件类型
        /// </summary>
        public int? partId { get; set; }

        /// <summary>
        /// 部件名称
        /// </summary>
        public string partName { get; set; }

        /// <summary>
        /// 更换类型（必换件、偶换件），0:其他；1：必换件; 2：偶换件；3：组件
        /// </summary>
        public int? replaceTypeID { get; set; }

        /// <summary>
        /// 更换类型名称
        /// </summary>
        public string ReplaceType { get; set; }

        /// <summary>
        /// 物料/零件ID，取物料/零件表 base_wuliao
        /// </summary>
        public int? wuliaoLJid { get; set; }

        /// <summary>
        /// 物料/零件名称
        /// </summary>
        public string wuliaoLJName { get; set; }

        /// <summary>
        /// 物料/零件编码ID，取物料/零件表 base_wuliaoCode
        /// </summary>
        public int wuliaoModelID { get; set; }

        public string Wlmodel { get; set; }

        /// <summary>
        /// 是否为关键零件部件,0:否；1:是
        /// </summary>
        public int? isKeyLJ { get; set; }

        /// <summary>
        /// 是否为关键零件部件文本值
        /// </summary>
        public string IsKeyLJName { get; set; }

        /// <summary>
        /// 是否为来料区的悬挂部件,0:否；1:是
        /// </summary>
        public int? isComingHang { get; set; }

        /// <summary>
        /// 是否为来料区的悬挂部件文本值
        /// </summary>
        public string IsComingHangName { get; set; }

        /// <summary>
        /// 更换数量
        /// </summary>
        public int? replaceQty { get; set; }

        /// <summary>
        /// 更换率
        /// </summary>
        public string replaceRate { get; set; }

        /// <summary>
        /// 关键大部件的主要组装工位ID，取自base_gongwei表
        /// </summary>
        public int? amsGwID { get; set; }

        /// <summary>
        /// 关键大部件的主要组装工位名称
        /// </summary>
        public string AmsGwName { get; set; }

        /// <summary>
        /// 关键大部件的主要拆卸工位ID，取自base_gongwei表
        /// </summary>
        public int? disGwID { get; set; }

        /// <summary>
        /// 关键大部件的主要拆卸工位名称
        /// </summary>
        public string DisGwName { get; set; }

        /// <summary>
        /// 必换件关联拆解工位的工序，用来装配时显示必换件信息
        /// </summary>
        public int program_GxInfoID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Gxname { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        #region CS端 关键零部件列表

        /// <summary>
        /// 物料名称
        /// </summary>
        public string wlname { get; set; }

        /// <summary>
        /// 物料图片
        /// </summary>
        public byte[] wlImg { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public int isChecked { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int batchQty { get; set; }

        #endregion

        #region CS端 检验说明（组件的质检提示）列表

        /// <summary>
        /// 质检提示
        /// </summary>
        public string TipMemo { get; set; }

        /// <summary>
        /// 质检图片
        /// </summary>
        public byte[] Picture { get; set; }

        #endregion

        #region 物料/零件表 base_wuliao

        /// <summary>
        /// 物料编码
        /// </summary>
        public string wlcode { get; set; }


        #endregion

        #region 物料/零件   规格表 base_wuliaoModel

        /// <summary>
        /// 物料规格ID
        /// </summary>
        public int wlmodelID { get; set; }

        //物料/零件规格型号	
        public string wlModels { get; set; }

        //单位			
        public string wlUnit { get; set; }

        //供货号		
        public string wlSupplierNo { get; set; }

        //图号			
        public string wlFigureNo { get; set; }

        //批次号	
        public string wlBatchNo { get; set; }

        //标准	
        public string wlStandard { get; set; }

        /// <summary>
        /// 状态
        /// </summary>

        public int wlModelStatus { get; set; }

        #endregion

        #region 用带出follow_WlBatchDetail明细表ID

        public int? fwDetailID { get; set; }

        public Guid? fw_guid { get; set; }

        public Guid? fm_guid { get; set; }

        public int? fwd_batchQty { get; set; }

        #endregion

        #region 需要带出 follow_WlBatchMain 表中 条码卡号进行判断是否为空 选择工位后需要清空条码卡信息

        /// <summary>
        /// 条码卡号
        /// </summary>
        public string fw_barcode { get; set; }


        /// <summary>
        /// 部件ID
        /// </summary>
        public int? fw_partId { get; set; }

        #endregion

    }
}
