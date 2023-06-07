using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.Utils.Torque
{
    public class TorqueFactory
    {

        private Control _control;
        public TorqueFactory(Control control)
        {
            _control = control;
        }

        public BaseTorque Create(string torqueModel)
        {
            BaseTorque torque = null;
            //判断扭力扳手类型
            switch (torqueModel)
            {
                case TorqueType.SP:
                    torque = new SPHelper();
                    break;
                case TorqueType.Matou_CVI3:
                    torque = new Torque_matouCVI3();
                    break;
                case TorqueType.Bluetooth_TOHNICHI:
                    torque = new BluetoothTorque();
                    break;
                case TorqueType.AtlasPF600:
                    torque = new Torque_AtlasPF600_2();
                    break;
                case TorqueType.Ingersoll:
                    torque = new Torque_Ingersoll();
                    break;
                default:
                    break;
            }
            if (torque != null)
            {
                torque.Control = _control;
            }
            return torque;
        }
    }
}
