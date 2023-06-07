using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.WinForm.Utils.Torque
{
    public class TorqueInfo
    {
        public TorqueInfo()
        {

        }

        public string RstMsg { get; set; }
        public TorqueInfo(string msg)
        {
            RstMsg = msg;
        }

        /// <summary>
        /// 配方编号
        /// </summary>
        public int PsetNum { get { return Convert.ToInt32( RstMsg.Substring(90, 3)); } }


        /// <summary>
        /// 0:NOK;1:OK
        /// </summary>
        public string TighteningStatus { get { return RstMsg.Substring(107, 1); } }

        /// <summary>
        /// 0. Low / 1. OK / 2 .High
        /// </summary>
        public string TorqueStatus { get { return RstMsg.Substring(110, 1); } }

        /// <summary>
        ///  0. Low / 1. OK / 2 .High
        /// </summary>
        public string AngleStatus { get { return RstMsg.Substring(113, 1); } }

        

        public double TorqueMinlimit { get { return Convert.ToInt32(RstMsg.Substring(116, 6)) /100.0 ; } }
        public double TorqueMaxlimit { get { return Convert.ToInt32(RstMsg.Substring(124, 6)) / 100.0; } }
        public double TorqueFinalTarget { get { return Convert.ToInt32(RstMsg.Substring(132, 6)) / 100.0; } }
        public double Torque { get { return Convert.ToInt32(RstMsg.Substring(140, 6)) / 100.0; } }

        public int AngleMin { get { return Convert.ToInt32(RstMsg.Substring(148, 5)) ; } }
        public int AngleMax { get { return Convert.ToInt32(RstMsg.Substring(155, 5)); } }
        public int FinalAngleTarget { get { return Convert.ToInt32(RstMsg.Substring(162, 5)); } }
        public int Angle { get { return Convert.ToInt32(RstMsg.Substring(169, 5)); } }



    }
}
