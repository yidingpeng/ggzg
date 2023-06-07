using System;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseInventoryModel : BaseModel
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 物料ID
        /// </summary>
        public int? wlID { get; set; }

        /// <summary>
        /// 物料编号
        /// </summary>
        public string wlCode { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string wlName { get; set; }

        /// <summary>
        /// 物料/零件规格型号
        /// </summary>
        public string wlModel { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string unit { get; set; }
         
        /// <summary>
        ///  批号
        /// </summary>
        public string batch { get; set; }

        /// <summary>
        /// 项目号
        /// </summary>
        public string projectNo { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal? qty { get; set; }

        /// <summary>
        /// 锁库数量
        /// </summary>
        public decimal? lockqty { get; set; }

        /// <summary>
        /// 库存组织ID(来自字典表）
        /// </summary>
        public int? InvOrgID { get; set; }

        /// <summary>
        /// 库存组织名称(来自字典表）
        /// </summary>
        public string InvOrgText
        {
            get
            {
                if (InvOrgID == 1)
                {
                    return "电气设备分公司";
                }
                return "";
            }
        }

        /// <summary>
        /// 库存类型ID（来自数据字典）
        /// </summary>
        public int? inventoryTypeID { get; set; }

        /// <summary>
        /// 库存类型名称（来自数据字典）
        /// </summary>
        public string inventoryTypeText
        {
            get
            {
                if (inventoryTypeID == 1)
                {
                    return "普通";
                }
                return "";
            }
        }

        /// <summary>
        /// 仓库ID 
        /// </summary>
        public int? warehouseID { get; set; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public string warehouseText
        {
            get
            {
                if (warehouseID == 1)
                {
                    return "DQ08段飞燕";
                }
                return "";
            }
        }
         
        /// <summary>
        /// 用户判断导入数据是否存在
        /// 0：存在
        /// 1：不存在
        /// </summary>
        public int? isExists { get; set; }

        public string isExistsText
        {
            get
            {
                if (isExists == 0) { return "存在"; }
                return "不存在";
            }
        }
         
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
         
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        public int? createMan { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? updateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        public int? updateMan { get; set; }

    }
}
