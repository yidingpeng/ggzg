using System;
using System.Collections.Generic;
using System.Text;
using RW.PMS.Utils.Configuration;
using System.Windows.Forms;
using System.IO.Ports;

namespace RW.PMS.Utils.Driver
{
    public class SerialPortConfig : IniConfig
    {
        public SerialPortConfig()
        {
            this.PortName = "COM1";
            this.BaudRate = 9600;
            this.DataBits = 8;
            this.Parity = Parity.Even;
            this.StopBits = StopBits.One;
        }

        public SerialPortConfig(string filename)
            : base(filename)
        {

        }

        private string portName;
        public string PortName { get { return portName; } set { portName = value; } }

        private int baudRate;
        public int BaudRate { get { return baudRate; } set { baudRate = value; } }

        private int dataBits;
        public int DataBits { get { return dataBits; } set { dataBits = value; } }

        private Parity parity;
        public Parity Parity { get { return parity; } set { parity = value; } }

        private StopBits stopBits;
        public StopBits StopBits { get { return stopBits; } set { stopBits = value; } }
    }
}
