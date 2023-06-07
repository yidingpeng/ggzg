using System;
using System.Collections.Generic;
using System.Text;
using RW.Configuration;
using System.Windows.Forms;

namespace RW.Driver
{
    public class ModbusConfig : BaseConfig
    {
        public ModbusConfig()
            : base(Application.StartupPath + "\\modbus.ini")
        {
            this.PortName = "COM1";
            this.Load();
        }

        public string PortName { get; set; }
    }
}
