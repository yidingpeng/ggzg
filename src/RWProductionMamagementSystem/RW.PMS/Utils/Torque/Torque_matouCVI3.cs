using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketHelper;

namespace RW.PMS.WinForm.Utils.Torque
{

    //上海九亭——马头CVI3
    //socket tcp 通讯

    public class Torque_matouCVI3 : BaseTorque, IDisposable
    {
        public override bool ConnectionIsOK
        {
            get { return true; }
        }
        //请求连接
        private const string _strRequstConnInput = "00200001000         ";//请求连接——发送字符串
        private const string _strRequstConn8_OK = "00570002";//请求连接——校验字符串
        private const string _strRequestExist = "00260004";//请求已经连接——校验字符串
        private bool _isRequstConn = false;//是否请求连接
        private bool _isRequstConnExist = false;//是否已经连接

        //选择装配过程
        //string sCheckPInput = "00220038000         02";//切换装配过程——发送字符串
        private string _sCheckPInput = "00220038000         ";//切换装配过程——发送字符串
        private const string _sCheckInput = "00220038000         ";//切换装配过程——发送字符串
        private const string _strCheckProcess_OK = "00240005001         0038";//切换装配过程——校验字符串
        private bool _isCheckProcess = false;//是否切换程序

        //发送结果请求
        private const string _strReqResultsInput = "002000600010        ";//发送结果请求——发送字符串
        private const string _strReqResults_OK = "00240005001         0060";//结果请求——校验字符串
        private bool _isReqResults = false;//是否发送结果请求

        //结果接收， 接收成功后再发送结果确认
        private const string _strRevResultsInput = "00200062001         ";//发送结果确认——发送字符串
        private const string _strRevResults_OK = "02310061001";//结果请求——校验字符串
        private bool _isRevResults = false;//是否发送结果请求

        //发送保持连接
        private const string _strKeepInput = "00209999000         ";//发送保持——发送字符串
        private const string _strKeep_OK = "00209999";//保持连接——校验字符串
        private bool _isKeep = false;//是否保持连接

        private AxTcpClient _axTcpClient = null;

        private Timer _timer = null;
        public string ErrorMsg { get; private set; }
        public string StateMsg { get; private set; }
        public string SendDataMsg { get; private set; }
        public string RevDataMsg { get; private set; }

        public Torque_matouCVI3()
        {
            _timer = new Timer();
            _timer.Interval = 3000;
            _timer.Tick += _timer_Tick;

            _axTcpClient = new AxTcpClient();
            _axTcpClient.OnStateInfo += _axTcpClient_OnStateInfo;
            _axTcpClient.OnErrorMsg += _axTcpClient_OnErrorMsg;
            _axTcpClient.OnReceviceByte += axTcpClient1_OnReceviceByte;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            SendKeep();
        }

        private void _axTcpClient_OnStateInfo(string msg, SocketState state)
        {
            if (_axTcpClient.Isclosed)
            {
                StartConn();
            }
        }

        private void _axTcpClient_OnErrorMsg(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                if (_axTcpClient.Isclosed)
                {
                    StartConn();
                }

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
            if (Port==0)
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
                string sendmsg = strsenddata;

                //    //以ASCIIEncoding转码形式发送
                byte[] sendByte = Encoding.Default.GetBytes(sendmsg);

                //在每个发送的byte[]最后一个数组指定发00
                byte[] byte00 = new byte[] { 0x00 };

                byte[] tempByte = new byte[sendByte.Length + byte00.Length];
                Buffer.BlockCopy(sendByte, 0, tempByte, 0, sendByte.Length);
                Buffer.BlockCopy(byte00, 0, tempByte, sendByte.Length, byte00.Length);

                _axTcpClient.SendCommand(tempByte);

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

                ////以文本转ASCIIEncoding转码形式显示数据
                receiveResult = Encoding.Default.GetString(data);

                //接收的数据验证 发送请求连接反馈
                _isRequstConn = ResultIsOK(receiveResult, _strRequstConn8_OK);
                _isRequstConnExist = ResultIsOK(receiveResult, _strRequestExist);

                //连接成功后，发送结果请求
                if (_isRequstConn || _isRequstConnExist)
                {
                    //发送结果请求
                    SendData(_strReqResultsInput);
                    _isRequstConn = false;
                    _isRequstConnExist = false;
                }


                //接收的数据验证 接收请求结果反馈
                _isReqResults = ResultIsOK(receiveResult, _strReqResults_OK);
                if (_isReqResults)
                {
                    //发送选择装配过程
                    SendData(_sCheckPInput);
                    _isReqResults = false;
                }


                //接收的数据验证  选择装配过程
                _isCheckProcess = ResultIsOK(receiveResult, _strCheckProcess_OK);
                //装配过程选择成功后，发送请求结果
                if (_isCheckProcess)
                {
                    _isCheckProcess = false;
                }


                _isRevResults = ResultIsOK(receiveResult, _strRevResults_OK);

                if (_isRevResults)//截取扭力值，角度
                {
                    //"02310061001         010000020103	CVI3 Vision             04                         050206011070004080001091101111120000001301050014000000150001161600100170020018001501900150202018-05-21:09:16:32212018-05-18:14:59:12220230000000491"

                   var torque = Convert.ToDecimal(receiveResult.Substring(140, 4) + "." + receiveResult.Substring(144, 2));
                    var angle = Convert.ToDecimal(receiveResult.Substring(169, 5));

                    //结果接收确认
                    SendData(_strRevResultsInput);

                    ActionDataReceived(new TorqueData(torque, angle));

                    CloseConnection();

                    Connection();

                    _isRevResults = false;
                }

                _isKeep = ResultIsOK(receiveResult, _strKeep_OK);
                if (_isKeep)
                {
                    RevDataMsg = "保持连接成功！";
                }
                else
                {
                    RevDataMsg = "保持连接失败！";
                }

                ActionOnline(true);
            }
            catch (Exception ex)
            {
                RevDataMsg = ex.Message;

                ActionError(ex.Message);
            }
        }

        private void StopConn()
        {
            _axTcpClient.StopConnection();
            _timer.Stop();
        }

        private void StartTorque(int processID)
        {
            string ProcessID = "00".Substring(0, processID.ToString().Length) + processID.ToString();//装配过程ID
            _sCheckPInput = _sCheckInput + ProcessID;//切换装配过程——发送字符串
            //请求连接
            this.SendData(_strRequstConnInput);
        }

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
