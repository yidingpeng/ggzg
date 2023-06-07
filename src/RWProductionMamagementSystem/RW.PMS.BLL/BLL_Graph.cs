using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model.graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.BLL
{
    public class BLL_Graph : IBLL_Graph
    {
        private IDAL_Graph _DAl = null;
        public BLL_Graph()
        {
            _DAl = DIService.GetService<IDAL_Graph>();
        }
        public int AddGraphData(GraphModel model)
        {
            return _DAl.AddGraphData(model);
        }
    }
}
