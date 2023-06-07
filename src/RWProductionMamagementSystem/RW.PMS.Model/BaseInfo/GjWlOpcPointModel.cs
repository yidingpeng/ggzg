using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using RW.PMS.DAL;

namespace RW.PMS.Model.BaseInfo
{
    public class GjWlOpcPointModel : BaseModel
    {
        // 工具物料OPC点位配置信息表
        public GjWlOpcPointModel()
        {
            GjWlOpcTypes = new List<GjWlOpcType>();
            IDs = new List<GjWlist>();
        }

        //ID主键
        public int ID { get; set; }

        //工位ID
        public int gwID { get; set; }
 
        //工位名称
        public string gwName { get; set; }

        //产品型号ID
        public int pmodelID { get; set; }

        //产品型号名称
        public string pmodelName { get; set; }

        //工具ID
        public int GjID { get; set; }

        //工具名称
        public string GjName { get; set; }

        //物料ID
        public int WlID { get; set; }

        //物料名称
        public string WlName { get; set; }

        //OPC设备名称
        public string OpcDeviceName { get; set; }

        //Opc点位类型ID
        public int? OpcTypeID { get; set; }

        //Opc点位类型
        public string OpcTypeCode { get; set; }

        //Opc点位信息名称
        public string OpcValue { get; set; }

        //备注
        public string Remark { get; set; }

        //Opc点位类型 名称
        public string OpcTypeName { get; set; }


        public IEnumerable<GjWlOpcType> GjWlOpcTypes { get; set; }

        public IEnumerable<GjWlist> IDs { get; set; }

    }
    public class GjWlOpcType
    {
        public int gjwlID { get; set; }

        public int gwid { get; set; }
        public int gjid { get; set; }
        public int wlid { get; set; }
        public int pmodelID { get; set; }
        public int ID { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }

    public class GjWlist
    {
        public string ID { get; set; }
    }
}
