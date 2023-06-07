using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RW.PMS.Model.BaseInfo
{
    public class WuliaoModel : BaseModel
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 物料/零件编码
        /// </summary>
        public string wlcode { get; set; }
        /// <summary>
        /// 物料/零件名称
        /// </summary>
        public string wlname { get; set; }
        /// <summary>
        /// 物料/零件图片	
        /// </summary>
        public byte[] wlImg { get; set; }
        /// <summary>
        /// 是否删除图片
        /// </summary>
        public bool DelPhoto { get; set; }
        /// <summary>
        /// 物料/零件类型	
        /// </summary>
        public int? wlTypeID { get; set; }


        /// <summary>
        /// 物料类别
        /// </summary>
        public string wlClass { get; set; }

        /// <summary>
        /// 物料/零件类型名称
        /// </summary>
        public string wlTypeName { get; set; }
        /// <summary>
        /// 是否为必换件bool值
        /// </summary>
        public bool IsReplace { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int? wlStatus { get; set; }
        /// <summary>
        /// 状态文本值
        /// </summary>
        public string Status { get {
            if (wlStatus == 0)
            return "启用";
            return "禁用";
        } }
        /// <summary>
        /// 装配时是否要录物料编码：0：没有；1：有编码
        /// </summary>
        public int? wlIsHasCode { get; set; }
        /// <summary>
        /// 装配时是否要录物料编码文本值
        /// </summary>
        public string IsHasCodeName { get { 
         if (wlIsHasCode == 0)
                return "否";
            return "是";
        
        
        } }
        /// <summary>
        /// 装配时是否要录物料编码bool值
        /// </summary>
        public bool IsHasCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }


        /// <summary>
        /// 【参数】 0:所有产品型号关联的物料/零件ID；非0:查询指定产品型号
        /// </summary>
        public int prodModelId { get; set; }

        /// <summary>
        /// 物料规格
        /// </summary>
        public IEnumerable<WuliaoModelModel> WuliaoSpecification { get; set; }

    }
}
