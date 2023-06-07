using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime;
using System.Net;
using System.Drawing;

namespace RW.PMS.Utils.Driver
{
    class TCP
    {
        #region TCP通讯参数
        TcpClient myTcp;
        NetworkStream netStream;
        //Socket s;

        //public static bool b;
        #endregion

        #region TCP通讯方法
        //private static bool IsConnectionSuccessful = false;
        private static Exception socketexception;
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            try
            {
                //IsConnectionSuccessful = false;
                TcpClient tcpclient = asyncresult.AsyncState as TcpClient;

                if (tcpclient.Client != null)
                {
                    tcpclient.EndConnect(asyncresult);
                    //IsConnectionSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                //IsConnectionSuccessful = false;
                socketexception = ex;
            }
            finally
            {
                TimeoutObject.Set();
            }
        }


        public void TcpOpen(string ip, int Port)     //打开连接
        {
            //创建Socket连接
            TimeoutObject.Reset();
            socketexception = null;
            try
            {
                IPAddress myIPA = IPAddress.Parse(ip);
                //IPEndPoint ipend = new IPEndPoint(myIPA, Port);
                //s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //s.Connect(ipend);
                try
                {
                    myTcp = new TcpClient();
                    myTcp.Connect(myIPA, Port);

                    //myTcp.BeginConnect(myIPA, Port, new AsyncCallback(CallBackMethod), myTcp);
                    // bool c= myTcp.Connected;
                }
                catch (System.Exception)
                {
                    //MessageBox.Show("TCP连接失败！！！", "连接提示。。。");
                }

            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void TcpClose()      //关闭连接
        {

            //关闭Socket连接
            try
            {
                myTcp.Close();
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void WriteData(byte[] myByte)
        {
            try
            {
                byte[] writeBytes = myByte;
                netStream = myTcp.GetStream();
                netStream.Write(writeBytes, 0, writeBytes.Length);
            }
            catch (System.Exception)
            {

            }

        }
        public int TcpAdrr(int adr, int bitF, out string ip)        //换算TCP地址和ip
        {
            int bitT;
            if (adr < 19)
            {
                ip = "192.168.0.185";
                //ip = "192.168.0.40";
                if (adr == 10)
                {
                    bitT = bitF;
                }
                else
                {
                    switch (adr)
                    {
                        case 16:
                        case 17:
                        case 18:
                            bitT = bitF + (adr - 12) * 32;
                            break;
                        case 13:
                        case 14:
                        case 15:
                            bitT = bitF + (adr - 13) * 32;
                            break;
                        case 12:
                            bitT = bitF + (adr + 3 - 12) * 32;
                            break;
                        default:
                            bitT = 1000;
                            break;
                    }
                }
            }
            else
            {
                ip = "192.168.0.185";
                //ip = "192.168.0.30";
                if (adr < 29)
                {
                    if (adr == 25)
                    {
                        bitT = bitF + 9 * 32;
                    }
                    else
                    {
                        bitT = bitF + (adr - 20) * 32;
                    }
                }
                else
                {
                    bitT = bitF + (adr - 30) * 32;
                }
            }
            return bitT;
        }
        public int[] Tobit(int i)       //转化为2进制数组
        {
            int[] b = new int[32];
            string a = Convert.ToString(i, 2);
            string aa = a.PadLeft(32, '0');
            if (aa.Length == 32)
            {
                b[0] = Convert.ToInt32(aa.Substring(31, 1));
                b[1] = Convert.ToInt32(aa.Substring(30, 1));
                b[2] = Convert.ToInt32(aa.Substring(29, 1));
                b[3] = Convert.ToInt32(aa.Substring(28, 1));
                b[4] = Convert.ToInt32(aa.Substring(27, 1));
                b[5] = Convert.ToInt32(aa.Substring(26, 1));
                b[6] = Convert.ToInt32(aa.Substring(25, 1));
                b[7] = Convert.ToInt32(aa.Substring(24, 1));
                b[8] = Convert.ToInt32(aa.Substring(23, 1));
                b[9] = Convert.ToInt32(aa.Substring(22, 1));
                b[10] = Convert.ToInt32(aa.Substring(21, 1));
                b[11] = Convert.ToInt32(aa.Substring(20, 1));
                b[12] = Convert.ToInt32(aa.Substring(19, 1));
                b[13] = Convert.ToInt32(aa.Substring(18, 1));
                b[14] = Convert.ToInt32(aa.Substring(17, 1));
                b[15] = Convert.ToInt32(aa.Substring(16, 1));
                b[16] = Convert.ToInt32(aa.Substring(15, 1));
                b[17] = Convert.ToInt32(aa.Substring(14, 1));
                b[18] = Convert.ToInt32(aa.Substring(13, 1));
                b[19] = Convert.ToInt32(aa.Substring(12, 1));
                b[20] = Convert.ToInt32(aa.Substring(11, 1));
                b[21] = Convert.ToInt32(aa.Substring(10, 1));
                b[22] = Convert.ToInt32(aa.Substring(9, 1));
                b[23] = Convert.ToInt32(aa.Substring(8, 1));
                b[24] = Convert.ToInt32(aa.Substring(7, 1));
                b[25] = Convert.ToInt32(aa.Substring(6, 1));
                b[26] = Convert.ToInt32(aa.Substring(5, 1));
                b[27] = Convert.ToInt32(aa.Substring(4, 1));
                b[28] = Convert.ToInt32(aa.Substring(3, 1));
                b[29] = Convert.ToInt32(aa.Substring(2, 1));
                b[30] = Convert.ToInt32(aa.Substring(1, 1));
                b[31] = Convert.ToInt32(aa.Substring(0, 1));

            }
            return b;
        }
        public void intTby(int i, out byte a, out byte b)     //转化数据和地址为2个byte字节
        {
            if (i < 256)
            {
                a = 0;
                b = Convert.ToByte(i);
            }
            else
            {
                a = Convert.ToByte(i / 256);
                b = Convert.ToByte(i % 256);
            }
        }
        public int[] ReadDataCoil(string ip, int addr, int offset)     //读数据
        {
            System.Threading.Thread.Sleep(80);
            TcpOpen(ip, 502);
            byte[] Tsend = new byte[12];
            byte ad1, ad2, offs1, offs2;
            intTby(addr, out ad1, out ad2);
            intTby(offset, out offs1, out offs2);
            Tsend[0] = 0x00;
            Tsend[1] = 0x00;
            Tsend[2] = 0x00;
            Tsend[3] = 0x00;
            Tsend[4] = 0x00;
            Tsend[5] = 0x06;
            Tsend[6] = 0x01;
            Tsend[7] = 0x02;
            Tsend[8] = ad1;
            Tsend[9] = ad2;
            Tsend[10] = offs1;
            Tsend[11] = offs2;
            WriteData(Tsend);
            // s.Send(Tsend, Tsend.Length, 0);
            Thread.Sleep(80);
            int a = myTcp.Available;
            byte[] bb = new byte[a];
            //byte[] bb = new byte[100];
            // netStream.Read(bb, 0, bb.Length);
            // netStream.Close();
            //s.Receive(bb, bb.Length, 0);
            if (bb.Length >= 13)
            {
                int b = bb[12] * 256 * 256 * 256 + bb[11] * 256 * 256 + bb[10] * 256 + bb[9];
                return Tobit(b);
            }
            else
                return Tobit(0);
            //System.Threading.Thread.Sleep(80);
            //TcpClose();
        }

        public void set(string ip, int i, int sign)
        {
            System.Threading.Thread.Sleep(80);
            TcpOpen(ip, 502);
            byte[] Tsend = new byte[12];
            byte k, j;
            intTby(i, out k, out j);
            Tsend[0] = 0x00;
            Tsend[1] = 0x00;
            Tsend[2] = 0x00;
            Tsend[3] = 0x00;
            Tsend[4] = 0x00;
            Tsend[5] = 0x06;
            Tsend[6] = 0x09;
            Tsend[7] = 0x05;
            Tsend[8] = k;
            Tsend[9] = j;
            // sign=sign.ToLower();
            if (sign == 1)
            {
                Tsend[10] = 0xFF;
                Tsend[11] = 0x00;
            }
            else
            {
                Tsend[10] = 0x00;
                Tsend[11] = 0x00;
            }
            this.WriteData(Tsend);
            // s.Send(Tsend, Tsend.Length, 0);
            Thread.Sleep(80);
            int a = myTcp.Available;
            //netStream.Read(new byte[a], 0, a);
            System.Threading.Thread.Sleep(80);
            TcpClose();
        }
        //  del ddd = new del(zw);
        public delegate void rd(int i);
        #endregion
    }

}
