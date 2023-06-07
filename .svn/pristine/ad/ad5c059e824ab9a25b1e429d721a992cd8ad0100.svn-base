using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace RW.PMS.Utils.Driver
{
    /// <summary>
    /// 暂时未完成实现
    /// </summary>
    public class SerialPortDriver : SerialPort, IDriver, IDisposable
    {
        public SerialPortDriver()
        {
            this.port = new SerialPort();
            this.port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);

        }
        SerialPort port = null;
        AutoResetEvent auto = new AutoResetEvent(false);

        byte[] rBuffer = null;

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(20);//准备接收数据的时间

            int buffLen = port.BytesToRead;

            byte[] rBuffer = new byte[buffLen];
            port.Read(rBuffer, 0, rBuffer.Length);
            this.rBuffer = rBuffer;
            auto.Set();
        }


        #region IDriver 成员

        public object Read(string key)
        {
            port.Write(key);
            //byte[] bts = new byte[key.Length];

            throw new Exception("The method or operation is not implemented.");
        }

        public object Read()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Write(string key, object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Connect()
        {
            Connect(PortName, BaudRate, this.StopBits);
        }

        public void Connect(string portName)
        {
            Connect(portName, this.BaudRate, this.StopBits);
        }

        public void Connect(string portName, int baudRate)
        {
            Connect(portName, baudRate, this.StopBits);
        }

        public void WriteString(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);
            this.Write(data, 0, data.Length);
        }

        public void Write(byte d)
        {
            this.Write(new byte[] { (byte)d });
        }

        public void Write(byte[] data)
        {
            this.Write(data, 0, data.Length);
        }

        public void WriteLine()
        {
            this.Write(13);
        }

        public void Connect(string portName, int baudRate, StopBits stopbits)
        {
            port.PortName = portName;
            port.BaudRate = baudRate;
            port.StopBits = stopbits;
            //TODO：还有其他的属性需要设置
            port.Open();
            OnConnected();
        }

        protected virtual void OnConnected()
        {
            if (Connected != null) Connected(this, EventArgs.Empty);
        }

        public event EventHandler Connected;

        public event ValueChangeHandler ValueChanged;


        public object this[string key]
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion
    }
}
