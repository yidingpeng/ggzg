namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 部件质量检测项标准范围值
    /// </summary>
    public class BasePartCheckValueModel : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 部件之间标准主表ID  base_partCheckTip.id
        /// </summary>
        public int partCheck_ID { get; set; }

        /// <summary>
        /// 值类型ID:扭力/角度/喷油量	programValueType
        /// </summary>
        public int valueTypeID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string valueTypeText { get; set; }

        /// <summary>
        /// 值比较类型B,asedata.ID等于：和标准值对比范围：和最大值、最小值比较,programEqualType
        /// </summary>
        public int EqualTypeID { get; set; }

        /// <summary>
        /// 比较类型文本
        /// </summary>
        public string EqualTypeText { get; set; }

        /// <summary>
        /// 目标值，尺寸/探伤	
        /// </summary>
        public string standardValue { get; set; }

        /// <summary>
        /// 最小值，尺寸/探伤
        /// </summary>
        public string minValue { get; set; }

        /// <summary>
        /// 最大值，尺寸/探伤
        /// </summary>
        public string maxValue { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string stepName { get; set; }

        /// <summary>
        /// BomID
        /// </summary>
        public int? prodLjDefId { get; set; }

        /// <summary>
        /// 检验方法说明
        /// </summary>
        public string checkTipMemo { get; set; }

        /// <summary>
        /// 位置示意图
        /// </summary>
        public byte[] samplePicture { get; set; }

        /// <summary>
        /// 工具示意图
        /// </summary>
        public byte[] toolPicture { get; set; }

        /// <summary>
        /// 检验标准
        /// </summary>
        public string checkStandard { get; set; }

        /// <summary>
        /// 手动标识
        /// </summary>
        public int? manuaFlag { get; set; }

        /// <summary>
        /// 检查结果 真为成功
        /// </summary>
        public bool checkResult { get; set; }

        /// <summary>
        /// 检查值
        /// </summary>
        public string checkValue { get; set; }
    }
}