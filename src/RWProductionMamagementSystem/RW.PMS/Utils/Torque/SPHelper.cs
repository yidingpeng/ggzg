using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;


namespace RW.PMS.WinForm.Utils.Torque
{

    /// <summary>
    /// 宁波手动扳手
    /// </summary>
    public class SPHelper : BaseTorque, IDisposable
    {

        public override bool ConnectionIsOK
        {
            get { return true; }
        }
        /// <summary>
        /// 设备ID
        /// </summary>
        public string DevID { get; private set; }
        /// <summary>
        /// 板手ID
        /// </summary>
        public string BoardID { get; private set; }
        /// <summary>
        /// 螺栓序號
        /// </summary>
        public string BoltID { get; private set; }
        /// <summary>
        /// 目標扭力
        /// </summary>
        public string TargetTorsion { get; private set; }
        /// <summary>
        /// 目標值小數點
        /// </summary>
        public string TargetDecimal { get; private set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string Unit { get; private set; }
        /// <summary>
        /// 量測扭力值
        /// </summary>
        public string Torsion { get; private set; }
        /// <summary>
        /// 量測值小數點
        /// </summary>
        public string TorsionDecimal { get; private set; }
        /// <summary>
        /// 合格判定
        /// </summary>
        public string IsOk { get; private set; }

        /// <summary>
        /// 新数据标记
        /// </summary>
        public bool ReadExisting { get; private set; }


        /// <summary>
        /// 设备在线
        /// </summary>
        public bool IsOnLine { get; private set; }

        private string[] units = { "N.m", "in.lb", "ft.lb", "kg.cm" };

        private byte[] cmddata = { 0xA5, 0xA5, 0x20, 0x01, 0x00, 0x00, 0x80, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}; //檢查接收器是否存在

        private byte[] retData = { 0xA5, 0xA5, 0x20, 0x01, 0x01, 0x01, 0x80 };    //回應封包，通知PC連線成功

        public SerialPort mySerialPort;

        public SPHelper()
        {

        }

        public void init(string portName)
        {

            try
            {
                mySerialPort = new SerialPort(portName);

                mySerialPort.BaudRate = 76800;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                //mySerialPort.Handshake = Handshake.None;
                mySerialPort.RtsEnable = false;
                mySerialPort.DtrEnable = false;

                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                if (!mySerialPort.IsOpen)
                    mySerialPort.Open();

                IsOnLine = false;
            }
            catch (Exception ex)
            {
                ErrorMsg(ex.Message);
            }
        }
        public void close()
        {
            mySerialPort.Close();
        }
        public int onlinecmd()
        {
            write(cmddata, 48);
            return 0;
        }
        public int write(byte[] data, int len)
        {
            try
            {
                mySerialPort.Write(data, 0, len);
                return 0;
            }
            catch (Exception ex)
            {
                ErrorMsg(ex.Message);
                return 0;
            }
        }

        private void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
        {

            try
            {

                int num = 0;//循环执行次数
                //SerialPort sp = (SerialPort)sender;
                //mySerialPort.ReadLine

                byte[] byteArray = new byte[48];
                //{0xA5, 0xA5, 0x10, 0x01, 0x64, 0x01, 0x02, 0x1F, 0x00, 0x0D, 0x12, 
                //0x01, 0x02, 0x02, 0x03, 
                //0x26, 0xB8, 0x0B, 0x02, 0x01, 0x87, 0x00, 0x02, 0x07, 
                //0x7C, 0xDC, 0x5C, 0x00, 0xFA, 0x00, 0xFB, 0x00, 0xFC, 0x00, 0xFD, 0x00, 0xFE, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x11, 0x02, 0x00} ;

                int indata = mySerialPort.Read(byteArray, 0, 48);//ReadExisting();
                if (indata == 48)
                {
                    //5A 5A 02 01 1F 
                    //string类型转成byte[]：
                    //byte [] byteArray =  System.Text.Encoding.Default.GetBytes(indata);//indata.ToCharArray();//
                    if (retData[0] == byteArray[0] && retData[1] == byteArray[1] && retData[2] == byteArray[2] &&
                       retData[3] == byteArray[3] && retData[4] == byteArray[4] && retData[5] == byteArray[5] &&
                       retData[6] == byteArray[6])
                    {
                        IsOnLine = true;

                        ActionOnline(IsOnLine);

                        return;
                    }

                    byte id = byteArray[12]; //扳手ID
                    byte xh = byteArray[13]; //封包序號
                    byte wz = byteArray[7];  //記錄位置
                    byte[] data = { 0x5A, 0x5A, 0x02, 0x01, 0x1F };
                    data[2] = (byte)id;
                    data[3] = (byte)xh;
                    data[4] = (byte)wz;
                    write(data, 5);

                    //testdata = (byte[])byteArray.Clone();

                    ReadExisting = true;
                    DevID = byteArray[11].ToString();
                    BoardID = byteArray[12].ToString();
                    BoltID = byteArray[15].ToString();
                    TargetDecimal = byteArray[18].ToString();
                    int tmp1 = byteArray[17] * 256;
                    int tmp2 = byteArray[16];
                    double tmp3 = Math.Pow(10, byteArray[18]);
                    TargetTorsion = ((tmp1 + tmp2) / tmp3).ToString();// (byteArray[16] + byteArray[17] * 256).ToString();

                    switch (byteArray[19])
                    {
                        case 1:
                            Unit = units[0];
                            break;
                        case 2:
                            Unit = units[1];
                            break;
                        case 4:
                            Unit = units[2];
                            break;
                        case 8:
                            Unit = units[3];
                            break;
                        default:
                            Unit = units[0];
                            break;

                    }

                    TorsionDecimal = byteArray[22].ToString();
                    tmp1 = byteArray[21] * 256;
                    tmp2 = byteArray[20];
                    tmp3 = Math.Pow(10, byteArray[22]);
                    Torsion = ((tmp1 + tmp2) / tmp3).ToString();
                    IsOk = byteArray[23].ToString();

                    ReadExisting = true;

                    ActionDataReceived(new TorqueData(decimal.Parse(Torsion), 0));
                }
                mySerialPort.DiscardInBuffer();

            }
            catch (Exception ex)
            {
                ErrorMsg(ex.Message);
            }


        }

        private void ErrorMsg(string msg)
        {
            ActionError(msg);
        }

        public override void Connection()
        {
            if (string.IsNullOrEmpty(PortName))
            {
                throw new Exception("PortName 不能为空！");
            }
            init(PortName);
            onlinecmd();
        }

        public override void CloseConnection()
        {
            close();
        }

        public void Dispose()
        {
            close();
        }
    }
}
