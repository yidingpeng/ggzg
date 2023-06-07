using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.WinForm.Utils.Torque
{

    /// <summary>
    /// 蓝牙扳手
    /// TOHNICHI  FH256MC
    /// </summary>
    public class BluetoothTorque : BaseTorque,IDisposable
    {

        public SerialPort mySerialPort;

        public BluetoothTorque()
        {
        }
        public override bool ConnectionIsOK
        {
            get { return true; }
        }
        public override void Connection()
        {
            if (string.IsNullOrEmpty(PortName))
            {
                throw new ArgumentNullException("PortName 不能为空！");
            }

            mySerialPort = new SerialPort(PortName);

            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            //mySerialPort.Handshake = Handshake.None;
            mySerialPort.RtsEnable = true;
            mySerialPort.DtrEnable = true;

            mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            if (!mySerialPort.IsOpen)
            {
                mySerialPort.Open();
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //RE,001,123456ACRLF

            var result= new char[18];

            mySerialPort.Read(result, 0, result.Length);

            var str = string.Join("", result);

            ActionDataReceived(new TorqueData(str));
        }

        public override void CloseConnection()
        {
            mySerialPort.Close();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
