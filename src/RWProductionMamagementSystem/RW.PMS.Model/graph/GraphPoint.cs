using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.graph
{
  public  class GraphPoint
    {
        public GraphPoint(double qTorque, double qAngle)
        {
            this.qTorque = qTorque;
            this.qAngle = qAngle;
        }

        public int bwcount { get; set; }
        public double qTorque { get; set; }
        public double qAngle { get; set; }


    }
}
