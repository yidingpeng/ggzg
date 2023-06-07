using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class BaseGongweiOpcModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 工位ID
        /// </summary>
        public int? gwID { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string gwname { get; set; }

        /// <summary>
        /// Opc点位类型ID,取数据字典ID, sys_basedata.ID，下拉
        /// </summary>
        public int? opcTypeID { get; set; }

        /// <summary>
        ///Opc点位类型ID,取数据字典编码，编码同原来字段保持一致.  数据字典类型编码：gwOPCType(工位OPC点位类型)	
        /// </summary>
        public string opcTypeCode { get; set; }

        /// <summary>
        /// Opc点位信息名称,手录，例如值为Channel1.Device1.GwRedQ
        /// </summary>
        public string opcValue { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

    }
}
