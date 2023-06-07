using RW.PMS.Common;
using RW.PMS.Model.graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.IBLL
{
    public interface IBLL_Graph: IDependence
    {
        int AddGraphData(GraphModel model);
    }
}
