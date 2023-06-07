using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Common.Logger;
using SocketHelper;
using System.Net.Sockets;
using System.Net;
using System.Timers;
using System.Threading;

namespace RW.PMS.WinForm.Utils.Torque
{
    public class Torque_AtlasPF600_2 : BaseTorque, IDisposable
    {

        private AxTcpClient _axTcpClient = null;

        private System.Timers.Timer _timer = null;

        private System.Timers.Timer _safeTimer = null;

        private DateTime _connectionIsOKTime = DateTime.Now;

        public override bool ConnectionIsOK
        {
            get
            {
                if (DateTime.Now - _connectionIsOKTime <= TimeSpan.FromSeconds(10))
                {
                    return true;
                }

                return false;
            }
        }

        public Torque_AtlasPF600_2()
        {
            _axTcpClient = new AxTcpClient();
            _axTcpClient.OnStateInfo += _axTcpClient_OnStateInfo;
            _axTcpClient.OnErrorMsg += _axTcpClient_OnErrorMsg;
            _axTcpClient.OnReceviceByte += ReceviceByteEventHandler;
            _timer = new System.Timers.Timer();
            _timer.AutoReset = true;
            _timer.Interval = 1000;
            _timer.Elapsed += _timer_Elapsed;

            _safeTimer = new System.Timers.Timer();
            _safeTimer.AutoReset = true;
            _safeTimer.Interval = 8000;
            _safeTimer.Elapsed += _safeTimer_Elapsed;
        }

        private void ReceviceByteEventHandler(byte[] data)
        {
            _connectionIsOKTime = DateTime.Now; 
            /*
             * F3 68 BC 00 13 03 30 30 30 37 38 30 30 30 32 32 33 41 30 30 30 30 2A EE
             * 
             *  F3 68 BC[数据头]
                00 13[数据长度]
                03[16进制,Pset,01-0F分别对应P1-P15]
                30 30 30[16进制,拧紧扭力整数位数据]
                37 38 30 30[16进制,拧紧扭力小数位数据,4位小数]
                30 32 32 33 [16进制,角度数据]
                41[16进制,拧紧结果,42为合格,其他为不合格]
                30 30 30 30 [空数据]
                2A[16进制,条码数据]
                EE[数据尾]

             *  PSET=3
                扭力=0.78
                角度=223
                结果=不合格
             */

            //var str = string.Empty;
            //foreach (var b in data)
            //{
            //    str = str + b.ToString("X2") + " ";
            //}

            if (data.Length <= 2)
            {
                return;
            }

            if (data[0] != 0xF3 && data[1] != 0x68)
            {
                return;
            }
            
            switch (data[2])
            {
                case 0xBC://扭力数据
                     var val1 = Encoding.ASCII.GetString(new byte[] { data[6], data[7], data[8] });   //整数3位
                     var val2 = Encoding.ASCII.GetString(new byte[] { data[9], data[10], data[11], data[12] });  //小数2位
                     var val3 = Encoding.ASCII.GetString(new byte[] { data[13], data[14], data[15], data[16] });  //角度4位
                     //var val4 = str[17];  //结果1位，42合格，41或其他是不合格
                     decimal torque = 0;
                     decimal angle = 0;
                     decimal.TryParse(val1 + "." + val2, out torque);
                     torque = Math.Round(torque, 2);
                     decimal.TryParse(val3, out angle);
                     int intStatus = data[17] == 0x42 ? 0 : 1;
                     ActionDataReceived(new TorqueData(torque, angle, intStatus));
                     Logger.Default.Info(string.Format("{0}，torque：{1}angle：{2}", DateTime.Now, torque, angle));
                break;
                case 0xFC://连接状态
                if (data[5] == 0x00) //与电动扳手连接断开,软重启
                {
                    //工具软重启 F3 68 EF 00 01 EE
                    this._axTcpClient.SendCommand(new byte[] { 0xF3, 0x68, 0xEF, 0x00, 0x01, 0xEE });
                }
                else if (data[5] == 0x01)
                {
                   
                }
                break;
                case 0xEF://软重启
                if (data[11] == 0x0F)//失败重新启动
                {
                    //防止堵塞住线程
                    Task.Run(() => 
                    {
                        //工具连接状态 F3 68 EF 00 01 EE
                        Thread.Sleep(1000);
                        this._axTcpClient.SendCommand(new byte[] { 0xF3, 0x68, 0xEF, 0x00, 0x01, 0xEE });
                    });
                }
                break;
                default:
                    break;
            }

            // System.Diagnostics.Debug.WriteLine(string.Format("{0} ReceviceByteEventHandler : {1}",DateTime.Now,  string.Join(" ",data)));
        }

        //心跳事件 确认与扭力扳手通讯是否正常
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //工具连接状态 F3 68 FC 00 0E EE
            this._axTcpClient.SendCommand( new byte[] { 0xF3, 0x68, 0xFC, 0x00, 0x0E, 0xEE });

           //  System.Diagnostics.Debug.WriteLine(string.Format("{0} _timer_Elapsed : {1}",DateTime.Now,  " 0xF3, 0x68, 0xFC, 0x00, 0x0E, 0xEE"));
            
        }


        private void _axTcpClient_OnErrorMsg(string msg)
        {
            Logger.Default.Error(msg);

           // System.Diagnostics.Debug.WriteLine(string.Format("{0} _axTcpClient_OnErrorMsg : {1}",DateTime.Now,  msg));
            
        }

        private void _axTcpClient_OnStateInfo(string msg, SocketState state)
        {
           // System.Diagnostics.Debug.WriteLine(string.Format("{0} _axTcpClient_OnStateInfo : {1}",DateTime.Now,  state));
        }

        void _safeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!ConnectionIsOK)
            {
                this._axTcpClient.StopConnection();

                _safeTimer.Stop();

             //   System.Diagnostics.Debug.WriteLine(string.Format("{0} _safeTimer_Elapsed - StopConnection", DateTime.Now)); 

                Task.Run(() => 
                {

                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    this._axTcpClient.StartConnection();

                    _safeTimer.Start();

               //     System.Diagnostics.Debug.WriteLine(string.Format("{0} _safeTimer_Elapsed - StartConnection", DateTime.Now));
                });
              
            }
        }

        public override void Connection()
        {
            if (string.IsNullOrEmpty(TorqueIP))
            {
                throw new Exception("TorqueIP 不能为空！");
            }
            if (Port == 0)
            {
                throw new Exception("Port 不能为0！");
            }
            _axTcpClient.ServerIp = TorqueIP;
            _axTcpClient.ServerPort = Port;
            _axTcpClient.StartConnection();
            _timer.Start();
            _safeTimer.Start();
        }

        public override void CloseConnection()
        {
            _axTcpClient.StopConnection();
            _timer.Stop();
            _safeTimer.Stop();
            //_axTcpClient.Dispose();
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
