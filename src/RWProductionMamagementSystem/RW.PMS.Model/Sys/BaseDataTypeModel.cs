using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Sys
{
    public class BaseDataTypeModel : BaseModel
    {

       

        //ID主键
        public int ID { get; set; }

        //字典编码
        public string Typecode { get; set; }

        //字典名称
        public string Typename { get; set; }

        //字典说明
        public string Typememo { get; set; }

        //备注
        public string Remark { get; set; }

    }
}
