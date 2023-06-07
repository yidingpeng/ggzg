using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.graph
{
    public class GraphModel: BaseModel
    {
        public GraphModel(DateTime dateTime, double torque, double angle ,string graphName)
        {
            this.dateTime = dateTime;
            this.torque = torque;
            this.angle = angle;
            this.graphName = graphName;
        }

        public int id { get; set; }
        public DateTime dateTime { get; set; }
        public Double torque { get; set; }
        public Double angle { get; set; }
        public string graphName { get; set; }
    }
}
