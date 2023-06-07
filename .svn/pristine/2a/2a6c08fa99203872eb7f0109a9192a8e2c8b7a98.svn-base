using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketHelper;
using RW.PMS.Common;
using RW.PMS.Common.Logger;

namespace RW.PMS.WinForm.Utils.Torque
{
    /// <summary>
    /// 英格索兰 Socket TCP通讯
    /// </summary>
    public class Torque_Ingersoll : BaseTorque, IDisposable
    {

        public override bool ConnectionIsOK
        {
            get { return true; }
        }

        //请求连接
        private const string _strRequstConnInput = "00200001000000000000\0";//请求连接——发送字符串

        //选择装配过程
        private string _sCheckPInput = "0023001800000000000000";//切换装配过程——发送字符串
        private const string _sCheckInput = "0023001800000000000000";//切换装配过程——发送字符串

        //private string _sCheckPInput = "00230018000000000000";//切换装配过程——发送字符串
        //private const string _sCheckInput = "00230018000000000000";//切换装配过程——发送字符串

        //发送结果请求
        private const string _strReqResultsInput = "00200060001000000000\0";//发送订阅请求——发送字符串 

        //结果接收， 接收成功后再发送结果确认
        private const string _strRevResultsInput = "00200062001000000000\0";//发送结果确认——发送字符串

        //发送保持连接
        private const string _strKeepInput = "00200043000000000000\0";//发送使能保持——发送字符串

        private AxTcpClient _axTcpClient = null;

        private Timer _timer = null;
        public string ErrorMsg { get; private set; }
        public string StateMsg { get; private set; }
        public string SendDataMsg { get; private set; }
        public string RevDataMsg { get; private set; }

        public Torque_Ingersoll()
        {
            _timer = new Timer();
            _timer.Interval = 30000;
            _timer.Tick += _timer_Tick;

            _axTcpClient = new AxTcpClient();
            _axTcpClient.OnStateInfo += _axTcpClient_OnStateInfo;
            _axTcpClient.OnErrorMsg += _axTcpClient_OnErrorMsg;
            _axTcpClient.OnReceviceByte += axTcpClient1_OnReceviceByte;
        }

        /// <summary>
        /// 计时器 保持连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            SendKeep();
        }

        /// <summary>
        /// 状态消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="state"></param>
        private void _axTcpClient_OnStateInfo(string msg, SocketState state)
        {
            if (_axTcpClient.Isclosed)
            {
                StartConn();
            }
        }

        /// <summary>
        /// 触发错误消息
        /// </summary>
        /// <param name="msg"></param>         
        private void _axTcpClient_OnErrorMsg(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                if (_axTcpClient.Isclosed)
                {
                    StartConn();
                }
                Logger.Default.Error(DateTime.Now.ToString()+Environment.NewLine+ msg);
                ActionError(msg);
            }
        }

        /// <summary>
        /// 初始化并连接TCPClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartConn()
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
        }

        private bool ResultIsOK(string result, string strCheck1)
        {
            bool isOK = false;

            if (!string.IsNullOrEmpty(result) && result.Length >= strCheck1.Length && result.Substring(0, strCheck1.Length) == strCheck1)
            {
                isOK = true;
            }

            ActionOnline(isOK);

            return isOK;
        }

        /// <summary>
        /// 发送Socket数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendData(string strsenddata)
        {
            try
            {
                //以ASCIIEncoding转码形式发送
                byte[] sendByte = Encoding.ASCII.GetBytes(strsenddata);
                _axTcpClient.SendCommand(sendByte);
            }
            catch (Exception ex)
            {
                SendDataMsg = ex.Message;
                ActionError(ex.Message);
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="date"></param>
        private void axTcpClient1_OnReceviceByte(byte[] data)
        {
            try
            {
                string receiveResult = string.Empty;
                //以文本转ASCIIEncoding转码形式显示数据
                receiveResult = Encoding.ASCII.GetString(data);
                var strResult = receiveResult.Substring(4, 4);//截取区间代码

                if (strResult.Equals("0004"))
                {
                    //异常
                    string strItem = receiveResult.Substring(receiveResult.Length - 7, 4);
                    string strError = receiveResult.Substring(receiveResult.Length - 3, 2);
                    RevDataMsg = "异常项：[" + strItem + "]异常原因：[" + strError + "]";
                }
                else if (strResult.Equals("0005"))
                {
                    //成功
                    string strItem = receiveResult.Substring(receiveResult.Length - 5, 4);
                    switch (strItem)
                    {
                        case "0003":
                            RevDataMsg = "断开连接成功.";
                            break;
                        case "0018":
                            RevDataMsg = "程序切换成功.";
                            break;
                        case "0042":
                            RevDataMsg = "使能禁用成功.";
                            break;
                        case "0043":
                            //txtTip.Text = "使能启用成功.";
                            break;
                        case "0060":
                            RevDataMsg = "拧紧结果值订阅成功.";
                            break;
                        case "0063":
                            RevDataMsg = "取消订阅成功.";
                            break;
                        default:
                            receiveResult = receiveResult.Replace("\0", "");
                            RevDataMsg = "接收字符串[" + receiveResult + "].";
                            break;
                    }
                }
                else
                {
                    if (receiveResult.StartsWith("00570002"))
                    {
                        //连接成功
                        RevDataMsg = "控制器连接成功.";
                        SendData(_strReqResultsInput);//若收到连接成功响应则发送订阅请求
                        //SendData(_strKeepInput);//使能
                    }
                    else if (receiveResult.StartsWith("0231006100"))
                    {
                        SendData(_strRevResultsInput);//0062：确认收到，不会有反应
                        var torque = Convert.ToDecimal(receiveResult.Substring(140, 4) + "." + receiveResult.Substring(144, 2)).ToString();
                        decimal decTorque = torque.ToDecimal();//扭力值 

                        ActionDataReceived(new TorqueData(decTorque));

                        //CloseConnection();

                        //Connection();
                    }
                }
                ActionError(RevDataMsg);
                ActionOnline(true);  
            }
            catch (Exception ex)
            {
                RevDataMsg = ex.Message;
                MessageBox.Show(RevDataMsg);
                ActionError(ex.Message);
            }
        }

        /// <summary>
        /// 关闭连接 
        /// </summary>
        private void StopConn()
        {
            if (!_axTcpClient.Isclosed)
                return;
            _axTcpClient.StopConnection();
            _timer.Stop();
        }

        /// <summary>
        /// 开启连接
        /// </summary>
        /// <param name="processID"></param>
        private void StartTorque(int processID)
        {
            //请求连接
            this.SendData(_strRequstConnInput);
            System.Threading.Thread.Sleep(500);//睡半秒等通讯连接完成 
            _sCheckPInput = _sCheckInput + processID + "\0";//切换装配过程——发送字符串
            this.SendData(_sCheckPInput);//发送配方
            System.Threading.Thread.Sleep(500);//睡半秒等通讯连接完成
        }

        /// <summary>
        /// 发送保持连接
        /// </summary>
        private void SendKeep()
        {
            SendData(_strKeepInput);
        }

        public override void Connection()
        {
            StartConn();
        }

        public override void CloseConnection()
        {
            StopConn();
        }

        public override void StartTorque(object param)
        {
            StartTorque(int.Parse(param.ToString()));
        }

        public void Dispose()
        {
            StopConn();
        }

    }
}
