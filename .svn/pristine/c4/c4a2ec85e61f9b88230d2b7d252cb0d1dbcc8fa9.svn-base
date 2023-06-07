using RW.PMS.Common;
using RW.PMS.Utils;
using RW.PMS.Utils.UI;
using RW.PMS.WinForm.Common;
using RW.PMS.WinForm.Utils.Torque;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RW.PMS.WinForm.Sockets
{
    /// <summary>
    /// Socket测试
    /// </summary>
    public partial class FrmSocketTest : FormSkin
    {
        #region 构造函数
        public FrmSocketTest()
        {
            InitializeComponent();
        }
        #endregion

        #region 加载函数
        private void socketTest_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region 接收数据触发事件
        private void axTcpClient_OnReceviceByte(byte[] data)
        {
            try
            {
                string strReceiveData = Encoding.ASCII.GetString(data);//接收数据转字符串

                if (!strReceiveData.Contains(","))
                {
                    #region 开放协议
                    string strResult = strReceiveData.Substring(4, 4);
                    //if (strReceiveData.StartsWith("041900610031"))
                    //{   
                    //    string Torque = Convert.ToDecimal(strReceiveData.Substring(186, 4) + "." + strReceiveData.Substring(190, 2)).ToString();
                    //    ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 扭力值[" + Torque + "]...\r\n" + txtLog.Text; });

                    //}
                    //else 
                    if (strResult.Equals("0004"))
                    {
                        //异常
                        string strItem = strReceiveData.Substring(strReceiveData.Length - 7, 4);
                        string strError = strReceiveData.Substring(strReceiveData.Length - 3, 2);
                        ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 异常项：[" + strItem + "]异常原因：[" + strError + "]\r\n" + txtLog.Text; });
                    }
                    else if (strResult.Equals("0005"))
                    {
                        //成功
                        string strItem = strReceiveData.Substring(strReceiveData.Length - 5, 4);
                        switch (strItem)
                        {
                            case "0003":
                                ControlHelper.Invoke(this, delegate
                                {
                                    txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 断开连接成功...\r\n" + txtLog.Text;
                                    tmrTorque.Enabled = false;
                                    btnStopSocket.Enabled = true;
                                    btnCannect.Enabled = true;
                                    btnStop.Enabled = false;
                                    btnSubscribe.Enabled = false;
                                    btnPSet.Enabled = false;
                                    btnEnable.Enabled = false;
                                });
                                break;
                            case "0018":
                                ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 程序切换成功...\r\n" + txtLog.Text; });
                                break;
                            case "0042":
                                ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 使能禁用成功...\r\n" + txtLog.Text; });
                                break;
                            case "0043":
                                ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 使能启用成功...\r\n" + txtLog.Text; });
                                break;
                            case "0060":
                                ControlHelper.Invoke(this, delegate
                                {
                                    txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 上次拧紧结果值订阅成功...\r\n" + txtLog.Text;
                                    btnCancel.Enabled = true;
                                });
                                break;
                            case "0063":
                                ControlHelper.Invoke(this, delegate
                                {
                                    txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 取消订阅成功...\r\n" + txtLog.Text;
                                    btnCancel.Enabled = false;
                                });
                                break;
                            default:

                                strReceiveData = strReceiveData.Replace("\0", "");
                                ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收字符串[" + strReceiveData + "]\r\n" + txtLog.Text; });
                                break;
                        }
                    }
                    else
                    {
                        if (strReceiveData.StartsWith("00570002"))
                        {
                            //连接成功
                            ControlHelper.Invoke(this, delegate
                            {
                                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 控制器连接成功...\r\n" + txtLog.Text;
                                btnStopSocket.Enabled = false;
                                btnCannect.Enabled = false;
                                btnStop.Enabled = true;
                                btnSubscribe.Enabled = true;
                                btnPSet.Enabled = true;
                                btnEnable.Enabled = true;
                                tmrTorque.Enabled = true;
                            });
                        }
                        else if (strReceiveData.StartsWith("0231006100"))
                        {
                            //02310061001000000000010006020003IC-PCM-2                 04No BCode                 050006001070000080000090101112120000011300000514000000150000041600180170022018002001900239202004-08-13:09:33:0921Last Change Unknown222230000000890
                            string strTorque = Convert.ToDecimal(strReceiveData.Substring(141, 4) + "." + strReceiveData.Substring(145, 2)).ToString();
                            string strAngle = Convert.ToDecimal(strReceiveData.Substring(169, 5)).ToString();
                            ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 扭力值[" + strTorque + "]角度[" + strAngle + "]...\r\n" + txtLog.Text; });
                            SendData("00200062001000000000\0");//0062：确认收到，不会有反应
                        }
                        else
                        {
                            strReceiveData = strReceiveData.Replace("\0", "");
                            ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收字符串[" + strReceiveData + "]\r\n" + txtLog.Text; });

                        }
                    }
                    #endregion
                }
                else
                {
                    #region 以太网
                    //000015,000042,01,001,02,11/21/2019,10-34-33,P,0000.74,P,0,00360,P,0,6.62,1.09,2,2.00,0.00,396,324,360,                                No BCode
                    //此数据是按照设置的输出顺序进行有序输出的
                    //P代表合格,关机代码一般是0,偶尔用于查故障
                    //周期时间单位:秒
                    //策略类型 1:扭矩 2:角度 
                    #endregion
                }
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 发送数据
        private void SendData(string strSendData)
        {
            try
            {
                byte[] senddata = Encoding.ASCII.GetBytes(strSendData);
                axTcpClient.SendCommand(senddata);
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 切换
        private void btnPSet_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = "";
                ControlHelper.Invoke(this, delegate { temp = cmbPsetNo.SelectedItem + ""; });
                SendData("00230018000000000000" + temp + "\0");
                ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 发送程序切换为[" + temp + "]的请求...\r\n" + txtLog.Text; });
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 异常事件
        private void axTcpClient_OnErrorMsg(string msg)
        {
            ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " Error:" + msg + "\r\n" + txtLog.Text; });
        }
        #endregion

        #region 状态信息
        private void axTcpClient_OnStateInfo(string msg, SocketHelper.SocketState state)
        {
            ControlHelper.Invoke(this, delegate { txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 状态[" + state.ToString() + "]消息[" + msg + "]\r\n" + txtLog.Text; });
        }
        #endregion

        #region 请求连接Socket
        private void btnCannectSocket_Click(object sender, EventArgs e)
        {
            try
            {
                axTcpClient.ServerIp = txtIP.Text;
                axTcpClient.ServerPort = Convert.ToInt32(txtPort.Text);
           
                axTcpClient.StartConnection();
                cmbPsetNo.SelectedIndex = 0;
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " IP[" + axTcpClient.ServerIp + "]端口[" + axTcpClient.ServerPort + "]\r\n" + txtLog.Text;
                txtIP.Enabled = false;
                btnCannectSocket.Enabled = false;
                btnStopSocket.Enabled = true;
                btnCannect.Enabled = true;
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 断开Socket连接
        private void btnStopSocket_Click(object sender, EventArgs e)
        {
            try
            {
                if (!axTcpClient.Isclosed)
                {
                    axTcpClient.StopConnection();//断开
                    txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 断开Socket连接 \r\n" + txtLog.Text;
                    txtIP.Enabled = true;
                    btnCannectSocket.Enabled = true;
                    btnStopSocket.Enabled = false;
                    btnCannect.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 请求连接控制器
        private void btnCannect_Click(object sender, EventArgs e)
        {
            try
            {
                SendData("00200001003         011");//请求连接
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 请求连接控制器...\r\n" + txtLog.Text;
                //SendData("00200060003000000000\0");//上次拧紧结果值订阅

                btnStopSocket.Enabled = false;
                btnCannect.Enabled = false;
                btnStop.Enabled = true;
                btnSubscribe.Enabled = true;
                btnPSet.Enabled = true;
                btnEnable.Enabled = true;
                tmrTorque.Enabled = true;
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 请求断开控制器
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                SendData("00200003003000000000\0");//请求断开
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 请求断开控制器...\r\n" + txtLog.Text;
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 订阅
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            try
            {
                         
                SendData("00200060001000000000000");//上次拧紧结果值订阅
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 发起上次拧紧结果值订阅请求...\r\n" + txtLog.Text;
                btnCancel.Enabled = true;
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 取消订阅
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                SendData("00200063000000000000\0");//取消订阅
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 请求取消订阅...\r\n" + txtLog.Text;
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 保持通讯
        private void tm_Tick(object sender, EventArgs e)
        {
            try
            {
                SendData("00209999000000000000\0");//保持通讯
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 发起保持...\r\n" + txtLog.Text;
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 窗体关闭事件
        private void FrmSocketTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!axTcpClient.Isclosed)
                    axTcpClient.StopConnection();
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 使能
        private void btnEnable_Click(object sender, EventArgs e)
        {
            try
            {
                SendData("00200043000000000000\0");//请求连接
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 发送使能请求...\r\n" + txtLog.Text;
                tmrTorque.Enabled = true;
            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}