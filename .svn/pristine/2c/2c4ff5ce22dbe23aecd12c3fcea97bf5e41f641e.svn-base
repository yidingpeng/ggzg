using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.ComponentModel;

namespace RW.PMS.Utils.Driver
{
    /// <summary>
    /// 支持modbus协议
    /// 目前实现了01,05,15线圈读写以及03,06,16寄存器读写
    /// </summary>
    public class ModbusDriver : ModbusSerialPort, IDriver
    {
        public ModbusDriver()
        {
            //modbus.DataReceived += new SerialDataReceivedEventHandler(modbus_DataReceived);
        }

        void modbus_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        //ModbusSerialPort modbus = new ModbusSerialPort();

        //public ModbusSerialPort Port
        //{
        //    get { return modbus; }
        //}

        #region IDriver 成员

        public object this[string key]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object Read(string key)
        {
            throw new NotImplementedException();
        }

        public void Write(string key, object value)
        {
            throw new NotImplementedException();

            //modbus.write
        }

        public void Connect()
        {
            this.Open();
        }

        public void Connect(string serverName)
        {
            throw new NotImplementedException();
        }

        public event EventHandler Connected;

        public event ValueChangeHandler ValueChanged;

        #endregion
    }
}
