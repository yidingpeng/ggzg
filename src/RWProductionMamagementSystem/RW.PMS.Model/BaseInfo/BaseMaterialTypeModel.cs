using System;

namespace RW.PMS.Model.BaseInfo
{
    /// <summary>
    /// 物料类型
    /// </summary>
    public class BaseMaterialTypeModel : BaseModel
    {
        public int ID { get; set; }
        public string mtName { get; set; }
        public string mtRemark { get; set; }
        public int? mtDisableFlag { get; set; }
        public int? mtDeleteFlag { get; set; }
        public DateTime? mtCreateTime { get; set; }
        public int? mtCreaterID { get; set; }
        public DateTime? mtUpdateTime { get; set; }
        public int? mtUpdaterID { get; set; }
    }
}
