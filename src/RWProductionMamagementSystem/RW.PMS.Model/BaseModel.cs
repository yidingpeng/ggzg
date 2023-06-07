using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public class BaseModel
    {
        public BaseModel()
        {
            PageIndex = 1;
            PageSize = 10;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
