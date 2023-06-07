using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;

namespace RW.PMS.Utils.Driver
{

    /// <summary>
    /// 支持modbus协议
    /// 目前实现了01,05,15线圈读写以及03,06,16寄存器读写
    /// </summary>
    public class ModbusSerialPort : SerialPort
    {
        public ModbusSerialPort()
        {
            port = this;

            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        int[] buffer = new int[1024];//用于存储寄存器地址对应的数据
        int timeout = 1000;//超时时间，毫秒

        SerialPort port = null;


        AutoResetEvent auto = new AutoResetEvent(false);

        byte[] rBuffer = new byte[0];

        public void InitConfig(SerialPortConfig config)
        {
            this.PortName = config.PortName;
            this.Parity = config.Parity;
            this.StopBits = config.StopBits;
            this.BaudRate = config.BaudRate;
            this.DataBits = config.DataBits;
        }

        void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(20);//准备接收数据的时间

            int buffLen = port.BytesToRead;

            byte[] rBuffer = new byte[buffLen];
            port.Read(rBuffer, 0, rBuffer.Length);
            this.rBuffer = rBuffer;
            auto.Set();
        }

        public bool CRCValid(byte[] data)
        {
            if (data.Length < 5) return false;

            byte[] temp = new byte[data.Length - 2];
            byte[] crc16 = new byte[2];
            Array.Copy(data, 0, temp, 0, temp.Length);
            Array.Copy(data, temp.Length, crc16, 0, 2);

            string hexSource = BitConverter.ToString(crc_16(temp));
            string hex = BitConverter.ToString(crc16);
            return hexSource == hex;
        }

        static object locker = new object();

        static byte[] crc_16(byte[] data)
        {
            uint IX, IY;
            ushort crc = 0xFFFF;//set all 1

            int len = data.Length;
            if (len <= 0)
                crc = 0;
            else
            {
                len--;
                for (IX = 0; IX <= len; IX++)
                {
                    crc = (ushort)(crc ^ (data[IX]));
                    for (IY = 0; IY <= 7; IY++)
                    {
                        if ((crc & 1) != 0)
                            crc = (ushort)((crc >> 1) ^ 0xA001);
                        else
                            crc = (ushort)(crc >> 1); //
                    }
                }
            }

            byte buf1 = (byte)((crc & 0xff00) >> 8);//高位置
            byte buf2 = (byte)(crc & 0x00ff); //低位置

            crc = (ushort)(buf1 << 8);
            crc += buf2;
            return BitConverter.GetBytes(crc);
        }

        /// <summary>
        /// 发送modbus指令 其中datas是不包含crc校验的数据
        /// </summary>
        /// <param name="address"></param>
        /// <param name="function"></param>
        /// <param name="datas"></param>
        /// <returns></returns>
        public byte[] Send(int address, int function, byte[] datas)
        {
            //ChangeHighAndLow(datas);
            byte[] sendData = new byte[datas.Length + 4];
            sendData[0] = (byte)address;
            sendData[1] = (byte)function;
            Array.Copy(datas, 0, sendData, 2, datas.Length);

            byte[] temp = new byte[sendData.Length - 2];
            Array.Copy(sendData, temp, temp.Length);

            byte[] c2 = crc_16(temp);

            //string code = CRC.GetCRC16Code(CRC.ByteArrayToHexString(sendData));
            //string crcString = CRC.GetCRC16Code(BitConverter.ToString(sendData, 0, sendData.Length - 2).Replace("-", ""));
            //byte[] crcBytes = CRC.HexString2Bytes(crcString);
            Array.Copy(c2, 0, sendData, sendData.Length - 2, 2);

            //读写锁，保证同时只发送读取一条指令
            lock (locker)
            {
                //Debug.WriteLine("Send data:" + Convert.ToString(BitConverter.ToInt64(sendData, 0), 16));
                string _t = "";
                for (int i = 0; i < sendData.Length; i++)
                {
                    _t += Convert.ToString(sendData[i], 16).PadLeft(2, '0') + " ";
                }
                Debug.WriteLine(_t);
                port.Write(sendData, 0, sendData.Length);

                bool isRight = auto.WaitOne(timeout);
                auto.Reset();
                if (!isRight)
                {
                    throw new TimeoutException("发送数据超时");
                }
                Debug.WriteLine("RX:" + BitConverter.ToString(rBuffer));
                byte[] readed = new byte[rBuffer.Length];
                rBuffer.CopyTo(readed, 0);
                rBuffer = new byte[0];
                if (CRCValid(readed))
                    return readed;

                throw new Exception("返回数据验证失败！");
            }
        }

        /// <summary>
        /// 读指定寄存器地址  命令码03
        /// 发送：[address] [function] [start]*2 [count]*2 [crc]*2
        /// 接收：[address] [function] []
        /// </summary>
        /// <param name="address"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public byte[] ReadRegister(int address, int start, int count)
        {
            byte[] buffer = new byte[4];
            byte[] starts = BitConverter.GetBytes((ushort)start);
            Array.Reverse(starts);
            starts.CopyTo(buffer, 0);
            byte[] counts = BitConverter.GetBytes((ushort)count);
            Array.Reverse(counts);
            counts.CopyTo(buffer, 2);
            byte[] ret = this.Send(address, 0x03, buffer);
            byte[] data = new byte[count * 2];
            Array.Copy(ret, 3, data, 0, data.Length);
            return data;
        }

        /// <summary>
        /// 读线圈状态 命令码01 
        /// 发送： [address] [function] [start]*2 [count]*2 [crc]*2
        /// 接收： [address] [function] [count] [data]*count [crc]*2
        /// </summary>
        public byte[] ReadCoil(int address, int start, int count)
        {
            byte[] buffer = new byte[4];
            byte[] starts = BitConverter.GetBytes((ushort)start);
            Array.Reverse(starts);
            starts.CopyTo(buffer, 0);
            byte[] counts = BitConverter.GetBytes((ushort)count);
            Array.Reverse(counts);
            counts.CopyTo(buffer, 2);
            byte[] ret = this.Send(address, 0x01, buffer);

            byte[] data = new byte[count / 8 + (count % 8 == 0 ? 0 : 1)];
            Array.Copy(ret, 3, data, 0, data.Length);

            return data;
        }

        /// <summary>
        /// 读单个线圈 复用读线圈状态指令，默认数量为1，默认返回为bool值。
        /// </summary>
        public bool ReadCoil(int address, int start)
        {
            byte[] data = ReadCoil(address, start, 1);
            int value = BitConverter.ToInt32(data, 0);
            return value > 0;
        }

        public byte[] ReadCoilInput(int address, int start, int count)
        {
            byte[] buffer = new byte[4];
            byte[] starts = BitConverter.GetBytes((ushort)start);
            Array.Reverse(starts);
            starts.CopyTo(buffer, 0);
            byte[] counts = BitConverter.GetBytes((ushort)count);
            Array.Reverse(counts);
            counts.CopyTo(buffer, 2);
            byte[] ret = this.Send(address, 0x02, buffer);

            byte[] data = new byte[count / 8 + (count % 8 == 0 ? 0 : 1)];
            Array.Copy(ret, 3, data, 0, data.Length);

            return data;
        }

        public bool ReadCoilInput(int address, int start)
        {
            byte[] data = this.ReadCoilInput(address, start, 1);
            int value = BitConverter.ToInt32(data, 0);
            return value > 0;
        }

        /// <summary>
        /// 写单个寄存器 命令码06 [address] [function] [start]*2 [data]*2 [crc]*2
        /// </summary>
        public void WriteRegister(int address, int start, byte[] values)
        {
            byte[] data = new byte[values.Length + 2];
            byte[] starts = BitConverter.GetBytes((ushort)start);
            Array.Reverse(starts);
            starts.CopyTo(data, 0);
            //Array.Reverse(values);
            values.CopyTo(data, 2);

            this.Send(address, 0x06, data);
        }

        /// <summary>
        /// 写多个寄存器，命令码16  [address] [function] [start]*2 [count]*2 [ByteCount]*2 [data]*n [crc]*2
        /// </summary>
        public void WriteRegister(int address, int start, int count, byte[] value)
        {
            byte[] data = new byte[6 + value.Length];
            byte[] starts = BitConverter.GetBytes((byte)start);
            Array.Reverse(starts);
            Array.Copy(starts, 0, data, 0, 2);
            byte[] counts = BitConverter.GetBytes((byte)count);
            Array.Reverse(counts);
            Array.Copy(counts, 0, data, 2, 2);
            data[4] = (byte)value.Length;
            Array.Copy(value, 0, data, 6, value.Length);

            this.Send(address, 0x10, data);
        }


        /// <summary>
        /// 对应word类型
        /// </summary>
        public void WriteRegister(int address, int start, ushort value)
        {
            byte[] data = BitConverter.GetBytes(value);
            ChangeHighAndLow(data);
            this.WriteRegister(address, start, data);
        }

        /// <summary>
        /// 对应short类型
        /// </summary>
        public void WriteRegister(int address, int start, short value)
        {
            byte[] data = BitConverter.GetBytes(value);
            ChangeHighAndLow(data);
            this.WriteRegister(address, start, data);
        }

        /// <summary>
        /// 对应long类型
        /// </summary>
        public void WriteRegister(int address, int start, int value)
        {
            byte[] data = BitConverter.GetBytes(value);
            ChangeHighAndLow(data);
            this.WriteRegister(address, start, data.Length, data);
        }

        /// <summary>
        /// 对应dword类型
        /// </summary>
        public void WriteRegister(int address, int start, uint value)
        {
            byte[] data = BitConverter.GetBytes(value);
            ChangeHighAndLow(data);
            this.WriteRegister(address, start, data.Length, data);
        }

        public void WriteRegister(int address, int start, long value)
        {
            byte[] data = BitConverter.GetBytes(value);
            ChangeHighAndLow(data);
            this.WriteRegister(address, start, data.Length, data);
        }

        /// <summary>
        /// 对应float类型
        /// </summary>
        public void WriteRegister(int address, int start, float value)
        {
            byte[] data = BitConverter.GetBytes(value);
            ChangeHighAndLow(data);
            this.WriteRegister(address, start, 1, data);
        }

        /// <summary>
        /// 对应double类型
        /// </summary>
        public void WriteRegister(int address, int start, double value)
        {
            byte[] data = BitConverter.GetBytes(value);
            ChangeHighAndLow(data);
            this.WriteRegister(address, start, data);
        }

        public void WriteRegister(int address, int start, decimal value)
        {
            WriteRegister(address, start, (float)value);
        }

        //高低字节对调，如高字节在前，则切换成低字节在前，反之同理。
        void ChangeHighAndLow(byte[] data)
        {
            for (int i = 0; i < data.Length / 2; i++)
            {
                byte temp = data[i * 2];
                data[i * 2] = data[i * 2 + 1];
                data[i * 2 + 1] = temp;
            }
        }

        /// <summary>
        /// 写单个线圈 命令码05 0x05 [address] [function] [start]*2 [data]*2 [crc]*2
        /// </summary>
        public void WriteCoil(int address, int start, bool value)
        {
            byte[] data = new byte[4];
            byte[] starts = BitConverter.GetBytes((ushort)start);
            ChangeHighAndLow(starts);
            starts.CopyTo(data, 0);
            data[2] = 0xff;
            data[3] = 0;
            this.Send(address, 0x05, data);
        }

        /// <summary>
        /// 写多个线圈 命令码15 0x0F [address] [function] [start]*2 [count]*2 [byteCount] [data]*2 [crc]*2
        /// </summary>
        public void WriteCoil(int address, int start, bool[] values)
        {
            int value = 0;//将values当做二进制数，转换后的值
            for (int i = 0; i < values.Length; i++)
            {
                value += (values[i] ? 1 : 0) << i;
            }
            byte[] data = BitConverter.GetBytes(value);
            //Array.Reverse(arr);//低字节在前，高字节在后
            ChangeHighAndLow(data);//低字节在前，高字节在后
            data.CopyTo(buffer, 5);

            this.WriteCoil(address, start, values.Length, data);
        }

        public void WriteCoil(int address, int start, int count, byte[] values)
        {
            byte[] data = new byte[5 + values.Length];
            byte[] starts = BitConverter.GetBytes((ushort)start);
            Array.Reverse(starts);
            starts.CopyTo(data, 0);
            byte[] counts = BitConverter.GetBytes((ushort)count);
            Array.Reverse(counts);
            counts.CopyTo(data, 2);
            data[4] = (byte)values.Length;
            values.CopyTo(data, 5);
            this.Send(address, 0x0F, data);
        }

        public void WriteCoil(int address, int start, int count, byte value)
        {
            byte[] data = new byte[1] { value };
            this.WriteCoil(address, start, count, data);

        }

        public void WriteCoil(int address, int start, int count, ushort value)
        {
            byte[] data = BitConverter.GetBytes(value);
            //ChangeHighAndLow(data);
            this.WriteCoil(address, start, count, data);
        }

        public void WriteCoil(int addres, int start, int count, int value)
        {
            byte[] data = BitConverter.GetBytes(value);
            //ChangeHighAndLow(data);
            this.WriteCoil(addres, start, count, data);
        }



    }
}
