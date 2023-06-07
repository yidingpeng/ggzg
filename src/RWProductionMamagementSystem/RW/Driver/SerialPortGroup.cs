using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Collections;
using System.Threading;

namespace RW.PMS.Utils.Driver
{
    public class SerialPortGroup
    {
        Dictionary<string, SerialPort> Ports = new Dictionary<string, SerialPort>();
        Dictionary<int, string> portMap = new Dictionary<int, string>();

        public event EventHandler Opened;
        //public event EventHandler Opening;
        public event EventHandler OpenBefore;
        public event EventHandler OpenError;

        //public event EventHandler Close;
        //public event EventHandler Closing;
        //public event EventHandler CloseBefore;
        //public event EventHandler CloseError;

        private int _readTimeout = 2000;

        public int ReadTimeout
        {
            get { return _readTimeout; }
            set { _readTimeout = value; }
        }


        public SerialPort this[string portName]
        {
            get { return Ports[portName]; }
            private set
            {
                Ports[portName] = value;
                portMap[portMap.Count] = portName;
                Ports[portName].DataReceived += new SerialDataReceivedEventHandler(SerialPortGroup_DataReceived);
            }
        }

        void SerialPortGroup_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
        }

        public SerialPort this[int index]
        {
            get { return Ports[portMap[index]]; }
        }

        public void Add(string portName)//使用默认构造，最好使用配置文件
        {
            SerialPort p = new SerialPort(portName);
            p.BaudRate = 39600;
            p.DataBits = 8;
            p.Parity = Parity.None;
            p.ReadTimeout = ReadTimeout;
            p.StopBits = StopBits.One;
            this[portName] = p;
        }

        public void Add(SerialPort port)
        {
            if (port == null)
            {
                throw new NullReferenceException();
            }
            this[port.PortName] = port;
        }

        public void Add(string portName, SerialPort port)
        {
            this[port.PortName] = port;
        }

        public void Open(SerialPort port)
        {
            try
            {
                if (OpenBefore != null) OpenBefore(port, null);
                port.Open();
                if (Opened != null) Opened.Invoke(port, null);
            }
            catch (Exception)
            {
                if (OpenError != null) OpenError(port, null);
            }
        }
        public void Open(string key)
        {
            Open(this[key]);
        }
        public void Open(int index)
        {
            Open(this[index]);
        }
        public void OpenAll()
        {
            foreach (SerialPort port in Ports.Values)
            {
                Open(port);
            }
        }

        public object locker = new object();

        public void Write(SerialPort port, byte[] cmd)
        {
            lock (locker)//写锁，保证读写时，不会同时操作。
            {
                port.Write(cmd, 0, cmd.Length);
            }
        }
        public void Write(string key, byte[] cmd)
        {
            Write(this[key], cmd);
        }
        public void Write(int index, byte[] cmd)
        {
            Write(this[index], cmd);
        }

        public void Read(SerialPort port, byte[] cmd, ref byte[] buffer)
        {
            lock (locker)//读写锁，保证在读取的时，不会进入写
            {
                port.Write(cmd, 0, cmd.Length);
                for (int i = 0; i < _readTimeout; i++)
                {
                    if (port.BytesToRead >= cmd.Length) break;
                    Thread.Sleep(1);
                }
                port.Read(buffer, 0, buffer.Length);
            }
        }

        public void Read(string key, byte[] cmd, ref byte[] buffer)
        {
            Read(this[key], cmd, ref buffer);
        }

        public void Read(int index, byte[] cmd, ref byte[] buffer)
        {
            Read(this[index], cmd, ref buffer);
        }
    }
}
