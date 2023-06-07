using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RW.PMS.WinForm.Utils.Torque
{
   public class PCM
    {
        public PCM()
        {

        }

        public string IP { get; set; }
        public string Port { get; set; }

        public PCM(string ip,string port)
        {
            this.IP = ip;
            this.Port = port;
        }

        public bool Istesing { get; set; }

        /// <summary>
        /// 创建客户端
        /// </summary>
        Socket client;

        public void Init()
        {
            try
            {
                ///创建客户端    
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                ///IP地址 
                IPAddress ip = IPAddress.Parse(IP);
                ///端口号
                IPEndPoint endPoint = new IPEndPoint(ip, int.Parse(Port));
                ///建立与服务器的远程连接
                client.Connect(endPoint);

                Istesing = true;

                Thread thread = new Thread(ReciveMsg);
                thread.IsBackground = true;
                thread.Start(client);

                Thread threadAlive = new Thread(KeepAliveSend);
                threadAlive.Start();

            }
            catch (Exception ex)
            {

                string err = "初始化连接失败：" + ex.Message;
              
            }

        }


        
        /// <summary>
        /// 发送保持连接命令
        /// </summary>
        private void KeepAliveSend()
        {
           
            while (Istesing)
            {
                KeepAlive();
                Thread.Sleep(5 * 1000);
            }
        }

      

        /// <summary>
        /// 建立连接
        /// </summary>
        public void CommunicationStart()
        {
            //工具《OpenProtocolInterfaceTester》  建立连接时，发了3次；
//"002000100050        \0";
//            30 30 32 30  30 30 30 31  30 30 35 30  20 20 20 20  20 20 20 20  00

//"002000100040        \0";
//            30 30 32 30  30 30 30 31  30 30 34 30  20 20 20 20  20 20 20 20  00

//"002000100030        \0";
//            30 30 32 30  30 30 30 31  30 30 33 30  20 20 20 20  20 20 20 20  00


            string cmd = "30 30 32 30 30 30 30 31 30 30 33 30 20 20 20 20 20 20 20 20 00";
            string str = "";
            str = "002000010050        \0";
            SendMsg(str);
            Thread.Sleep(200);

            str = "002000010040        \0";
            SendMsg(str);
            Thread.Sleep(200);

            str = "002000010030        \0";//8个空格 
            SendMsg(str);
            Thread.Sleep(200);
        }


        /// <summary>
        /// 建立连接
        /// </summary>
        public void CommunicationStop()
        {
            string cmd = "30 30 32 30 30 30 30 33 30 30 31 30 20 20 20 20 20 20 20 20 00";
            string str = "002000030010        \0";//8个空格 
            SendMsg(str);
        }


        /// <summary>
        /// 发送生命信号。保持连接。
        /// </summary>
        public void KeepAlive()
        {
            string cmd = "30 30 32 30 39 39 39 39  30 30 31 30 20 20 20 20 20 20 20 20 00 ";
            string str = "002099990010        \0";  //8个空格 
            SendMsg(str);
        }

        /// <summary>
        /// 允许切换配方
        /// </summary>
        public void PsetID()
        {
            string cmd = "30 30 32 30 30 30 31 30 30 30 31 30 20 20 20 20 20 20 20 20 00";
            string str = "002000100010        \0";//8个空格 
            SendMsg(str);
        }


        /// <summary>
        /// 选择配方ID
        /// </summary>
        /// <param name="configID"></param>
        public void SelectPID(int configID)
        {
            //            Config ID 1   "002300180010        001\0"
            //30 30 32 33 30 30 31 38  30 30 31 30 20 20 20 20  20 20 20 20 30 30 31 00

            //Config ID 2               "002300180010        002\0"
            //30 30 32 33 30 30 31 38  30 30 31 30 20 20 20 20  20 20 20 20 30 30 32 00

            string cmd = "30 30 32 33 30 30 31 38  30 30 31 30 20 20 20 20  20 20 20 20 30 30 31 00";
            string str = $"002300180010        00{configID}\0";
            SendMsg(str);
        }

        /// <summary>
        /// 订阅最后的结果
        /// </summary>
        public void SubscribeLastResut(int MID)
        {
            // 002000600010        \0
            // 002000600020        \0
            // 002000609990        \0
            // 002000609980        \0
            string strMID = MID.ToString().PadLeft(3, '0');
            string cmd = "30 30 32 30 30 30 36 30  30 30 31 30 20 20 20 20 20 20 20 20 00";
            string str = $"00200060{strMID}0        \0";
            SendMsg(str);
        }

        /// <summary>
        /// 取消订阅最后的结果
        /// </summary>
        public void UnSubscribeLastResut()
        {
            string cmd = "30 30 32 30 30 30 36 33  30 30 31 30 20 20 20 20  20 20 20 20 00";
            string str = $"002000630010        \0";
            SendMsg(str);
        }

        /// <summary>
        /// 告知已收到结果
        /// </summary>
        public void AcknowledgeResult()
        {
            string cmd = "30 30 32 30 30 30 36 32 30 30 31 30 20 20 20 20  20 20 20 20 00";
            string str = $"002000620010        \0";
            SendMsg(str);
        }


        /// <summary>
        /// 客户端发送消息，服务端接收到
        /// </summary>
        void SendMsg(string str)
        {
            try
            {
                byte[] arrMsg = Encoding.UTF8.GetBytes(str);
                client.Send(arrMsg);
            }
            catch (Exception ex)
            {

                string err = "发送错误：" + ex.Message;

                // MessageBox.Show(err);
            }
        }


        /// <summary>
        /// 客户端接收到服务器发送的消息
        /// </summary>
        /// <param name="o">客户端</param>
        void ReciveMsg(object o)
        {
            Socket client = o as Socket;
            while (Istesing)
            {
                try
                {
                    ///定义客户端接收到的信息大小
                    byte[] arrList = new byte[1024 * 1024];
                    ///接收到的信息大小(所占字节数)
                    int length = client.Receive(arrList);

                    string msg = Encoding.ASCII.GetString(arrList, 0, length);
                    //string msg = Encoding.UTF8.GetString(arrList, 0, length);
            

                    if (MsgRece != null)
                        MsgRece(msg);

                    Thread.Sleep(100);
                }
                catch (Exception ex)
                {
                  
                }
            }
        }

        public delegate void MsgReceHander(string msg);
        public event MsgReceHander MsgRece;
    }
}
