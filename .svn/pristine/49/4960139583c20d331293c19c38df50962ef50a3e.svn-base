using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.Device;
using RW.PMS.Utils;
using RW.PMS.WinForm.Utils;
using System;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Device
{
    /// <summary>
    /// 设备保养窗体
    /// </summary>
    public partial class FrmDeviceExec : Form
    {
        //变量
        private IntPtr icdev = IntPtr.Zero;
        private Int16 st;
        private byte[] snr = new byte[5];  //卡片序列号
        private Int16 port = 0;  //端口号
        private Int32 baud = 9600;  //波特率
        private byte sector = 1;  //扇区号
        private string devID = "";
        private string localIP = "";

        private int EmpId;
        private string Empname;
        /// <summary>
        /// 是否连接读卡器标识
        /// </summary>
        private bool hasCardInterop;

        IBLL_Device BLL = DIService.GetService<IBLL_Device>();

        /// <summary>
        /// 设备保养窗体构造函数
        /// </summary>
        public FrmDeviceExec()
        {
            InitializeComponent();

            this.EmpId = PublicVariable.CurEmpID;
            this.Empname = PublicVariable.CurEmpName;
            this.localIP = PublicVariable.LocalIP;
        }

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_DeviceExec_Load(object sender, EventArgs e)
        {
            try
            {
                if (localIP == "")
                {
                    MessageBox.Show("获取本机IP出错，请检查");
                    this.btnExec.Enabled = false;
                    return;
                }

                //加载数据
                BindData();

                #region 读卡器初始化

                //加载程序，就通讯连接！！！！！！！
                icdev = CardInterop.rf_init(port, baud);  //连接设备
                if (icdev.ToInt32() > 0)
                {
                    hasCardInterop = true;
                    byte[] status = new byte[30];
                    st = CardInterop.rf_get_status(icdev, status);  //读取硬件版本号
                    //lbHardVer.Text=System.Text.Encoding.ASCII.GetString(status);
                    CardInterop.rf_beep(icdev, 25);
                }
                //else
                //{
                //    MessageBox.Show("刷卡机通讯失败!请检查刷卡机是否通电并重新尝试打开软件");
                //    this.Close();
                //}

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <returns></returns>
        private bool BindData()
        {
            try
            {
                bool isget = false;

                Device_upKeepPlanModel item = BLL.GetUpKeepPlanIP(localIP);
                if (item != null)
                {
                    this.devID = item.DevID.ToString();
                    this.txtDevCardno.Text = item.DevCardno;
                    this.txtDevName.Text = item.DevName;
                    this.txtDevNo.Text = item.DevNo;
                    this.txtDevIP.Text = item.IP;
                    //this.txtplanMemo.Text = item.PlanMemo;
                    //this.txtPlanTime.Text = item.PlanDate.Value.ToString();
                    //this.txtStatus.Text = item.ExecStatusS;
                    this.txtExecTime.Text = item.ExecDate.Value.ToString();

                    isget = true;
                }

                return isget;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExec_Click(object sender, EventArgs e)
        {
            try
            {
                if (devID != "0" && devID != "" && localIP != "")
                {
                    bool update = BLL.UpdateDevExecTime(ConvertHelper.ToInt32(devID, 0), this.EmpId, this.Empname);
                    if (update)
                    {
                        MessageBox.Show("执行成功");
                        BindData();

                        //屏蔽执行成功后提示 “外部组件发生异常。”问题无法正常关闭窗体
                        //System.Threading.Thread.Sleep(2000);
                        //st = CardInterop.rf_exit(icdev);


                        this.Close();

                    }
                    else
                        MessageBox.Show("执行失败");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_DeviceExec_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (hasCardInterop)
                    st = CardInterop.rf_exit(icdev);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (hasCardInterop)
                    st = CardInterop.rf_exit(icdev);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int rf_cardCount = 0;//寻卡次数达到3次 暂时不进行寻卡操作

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                st = CardInterop.rf_card(icdev, (byte)0, snr);//寻卡

                if (rf_cardCount < 3)
                {
                    if (st == 0)
                    {
                        //byte[] snr1 = new byte[8];
                        //Program.hex_a(snr, snr1, 4); //将卡号转换为16进制字符串
                        //label1.Text = "寻卡成功，IC卡出厂编号为：" + System.Text.Encoding.Default.GetString(snr1);
                        //label1.ForeColor = Color.Green;

                        //读取卡号
                        byte[] databuffer = new byte[32];
                        byte block = Convert.ToByte(sector * 4);
                        st = CardInterop.rf_read_hex(icdev, block, databuffer);  //读数据,此函数读出来的是16进制字符串，也就是把每个字节数据的16进制A​S​C​Ⅱ码以字符串形式输出
                        //st = Program.rf_read(icdev, block, databuffer);
                        if (st != 0)
                        {
                            //label2.Text = "未能成功读卡，请将IC卡置放在刷卡机上，并确保通讯已连接";
                        }
                        else
                        {
                            txtReadCard.Text = System.Text.Encoding.Default.GetString(databuffer).Substring(0, 8);//只取前8位字符串结果。
                            if (txtReadCard.Text.Trim().ToUpper().StartsWith("D"))
                            {
                                if (txtDevCardno.Text.Trim().ToUpper() == txtReadCard.Text.Trim().ToUpper())
                                {
                                    btnExec_Click(null, null);
                                }
                                else
                                {
                                    MessageBox.Show("执行的卡号与设定的设备卡号不一致");
                                }
                            }
                            else
                            {
                                MessageBox.Show("设备卡号有错误，请换成正确的卡，卡号须以D开头");
                            }
                        }
                    }
                    else
                    {
                        rf_cardCount++;
                    }
                }
                else
                {
                    return;
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
