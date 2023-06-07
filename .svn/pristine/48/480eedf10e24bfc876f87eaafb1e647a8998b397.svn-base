using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
//using sysBll = CSRW.PAMS.BLL.sys;
using SocketHelper;


namespace RW.PMS.WinForm.Sockets
{

    public partial class socketTest_bk : Form
    {



        private string receiveResult = "";


        //请求连接
        string strRequstConnInput = "00200001000         ";//请求连接——发送字符串
        string strRequstConn8_OK = "00570002";//请求连接——校验字符串
        string strRequestExist = "00260004";//请求已经连接——校验字符串
        bool isRequstConn = false;//是否请求连接
        bool isRequstConnExist = false;//是否已经连接


        //选择装配过程
        //string sCheckPInput = "00220038000         02";//切换装配过程——发送字符串
        string sCheckPInput = "00220038000         ";//切换装配过程——发送字符串
        string strCheckProcess_OK = "00240005001         0038";//切换装配过程——校验字符串
        bool isCheckProcess = false;//是否切换程序


        //发送结果请求
        string strReqResultsInput = "002000600010        ";//发送结果请求——发送字符串
        string strReqResults_OK = "00240005001         0060";//结果请求——校验字符串
        bool isReqResults = false;//是否发送结果请求


        //结果接收， 接收成功后再发送结果确认
        string strRevResultsInput = "00200062001         ";//发送结果确认——发送字符串
        string strRevResults_OK = "02310061001";//结果请求——校验字符串
        bool isRevResults = false;//是否发送结果请求


        //发送保持连接
        string strKeepInput = "00209999000         ";//发送保持——发送字符串
        string strKeep_OK = "00209999";//保持连接——校验字符串
        bool isKeep = false;//是否保持连接


        public socketTest_bk()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

        }

        /// <summary>
        /// 初始化并连接TCPClient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConnectServer()
        {

            //获取扭力扳手服务机的IP及端口
            //sysBll.BLL_SysConfig.Config.getConfigByCode("");
            string niuliServer = "192.168.0.7";
            string niuliPort = "4545";
            int procsId = 4;
            string ProcessID = "00".Substring(0, procsId.ToString().Length) + procsId.ToString();//装配过程ID
            sCheckPInput = sCheckPInput + ProcessID;//切换装配过程——发送字符串

            axTcpClient1.ServerIp = niuliServer;
            axTcpClient1.ServerPort = int.Parse(niuliPort);
            axTcpClient1.StartConnection();

        }


        private void socketTest_Load(object sender, EventArgs e)
        {

            ConnectServer();
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
                System.Buffer.BlockCopy(sendByte, 0, tempByte, 0, sendByte.Length);
                System.Buffer.BlockCopy(byte00, 0, tempByte, sendByte.Length, byte00.Length);

                axTcpClient1.SendCommand(tempByte);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                textBox1.Text += receiveResult + "\r\n";


                ////以文本转ASCIIEncoding转码形式显示数据
                receiveResult = Encoding.Default.GetString(data);


                //接收的数据验证 发送请求连接反馈
                isRequstConn = resultIsOK(receiveResult, strRequstConn8_OK);
                isRequstConnExist = resultIsOK(receiveResult, strRequestExist);
                //连接成功后，发送结果请求
                if (isRequstConn || isRequstConnExist)
                {
                    //发送结果请求
                    SendData(strReqResultsInput);
                    isRequstConn = false;
                    isRequstConnExist = false;
                }


                //接收的数据验证 接收请求结果反馈
                isReqResults = resultIsOK(receiveResult, strReqResults_OK);
                if (isReqResults)
                {
                    //发送选择装配过程
                    SendData(sCheckPInput);
                    isReqResults = false;
                }


                //接收的数据验证  选择装配过程
                isCheckProcess = resultIsOK(receiveResult, strCheckProcess_OK);
                //装配过程选择成功后，发送请求结果
                if (isCheckProcess)
                {
                    isCheckProcess = false;
                }


                isRevResults = resultIsOK(receiveResult, strRevResults_OK);
                if (isRevResults)//截取扭力值，角度
                {
                    //"02310061001         010000020103	CVI3 Vision             04                         050206011070004080001091101111120000001301050014000000150001161600100170020018001501900150202018-05-21:09:16:32212018-05-18:14:59:12220230000000491"

                    //label3.Text = "扭力值：" + receiveResult.Substring(140, 6);//15
                    decimal Torque = Convert.ToDecimal(receiveResult.Substring(140, 4) + "." + receiveResult.Substring(144, 2));
                    decimal Angle = Convert.ToDecimal(receiveResult.Substring(169, 5));

                    label3.Text = "扭力值：" + Torque.ToString();
                    label3.Text += "\r\n角度：" + Angle.ToString();//19

                    //结果接收确认
                    SendData(strRevResultsInput);
                    isRevResults = false;

                }


                isKeep = resultIsOK(receiveResult, strKeep_OK);
                if (isKeep == false)
                    label5.Text = "保持连接失败！";
                else
                    label5.Text = "保持连接失败！";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// 接收错误数据
        /// </summary>
        /// <param name="msg"></param>
        private void ErrorMsgCallBack(string msg)
        {
            //try
            //{
            //if (ErrorMsgList.Items.Count > 50)
            //    ErrorMsgList.Items.Clear();
            //自定义处理错误数据
            //ErrorMsgList.Items.Add(msg);
            txtError.Text = msg + "  " + axTcpClient1.Isclosed.ToString();

            if (axTcpClient1.Isclosed)
                ConnectServer();
            //}
            //catch
            //{
            //}
        }


        /// <summary>
        /// 接收状态数据
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="state">状态码</param>
        private void StateInfoCallBack(string msg, SocketState state)
        {
            //try
            //{
            //if (StateInfoList.Items.Count > 50)
            //    StateInfoList.Items.Clear();
            ////自定义处理状态数据
            //StateInfoList.Items.Add(msg);
            txtStatus.Text = msg;
            //}
            //catch
            //{

            //}
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            SendData(strKeepInput);
        }



        private void btnConnect_Click(object sender, EventArgs e)
        {



            //请求连接

            SendData(strRequstConnInput);

        }



        private bool resultIsOK(string result, string strCheck1)
        {
            bool isOK = false;

            if (result == "")
            {
                label6.Text = "请求连接失败！";
            }
            else
            {

                if (result.Length >= strCheck1.Length && result.Substring(0, strCheck1.Length) == strCheck1)
                {
                    label6.Text = "请求连接成功!";
                    isOK = true;
                }
                else
                {
                    label6.Text = "请求连接失败！";
                }

            }

            return isOK;
        }


        private void btn_Click(object sender, EventArgs e)
        {
            axTcpClient1.StopConnection();
        }
    }
}
