using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.WinForm.Common;
using RW.PMS.WinForm.TestInstrument;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Instrument
{
    /// <summary>
    /// 仪器窗体
    /// </summary>
    public partial class FrmInstrument : Form
    {
        const int T = 235;
        int decimalNumber = 2;

        /// <summary>
        /// 基础信息
        /// </summary>
        private IBLL_BaseInfo _baseBLL = DIService.GetService<IBLL_BaseInfo>();

        /// <summary>
        /// 温湿仪温度OPC
        /// </summary>
        private string TemperatureOPC = string.Empty;
        /// <summary>
        /// 温湿仪湿度OPC
        /// </summary>
        private string HumidityOPC = string.Empty;

        object _objOPCTagLock = new object();

        /// <summary>
        /// 试验仪器类型
        /// </summary>
        private string TestType = string.Empty;
        /// <summary>
        /// 最小值
        /// </summary>
        private decimal minvalue = 0;
        /// <summary>
        /// 最大值
        /// </summary>
        private decimal maxValue = 0;
        /// <summary>
        /// 目标值
        /// </summary>
        private decimal standardValue = 0;
        /// <summary>
        /// 是否可以手动输入值
        /// </summary>
        private bool IsWriteVal = true;
        /// <summary>
        /// 模板号触发点位ID为工具参数配方主表ID
        /// </summary>
        private int TFMID = 0;
        /// <summary>
        /// 工具参数配方明细
        /// </summary>
        private List<BaseToolforMulaDetailModel> toolForMulalist = new List<BaseToolforMulaDetailModel>();
        /// <summary>
        /// 返回结果值
        /// </summary>
        public decimal ResultValue = 0;

        #region 试验项点
        /// <summary>
        /// 试验时间(min)
        /// </summary>
        private decimal testTime = 0;
        /// <summary>
        /// 试验电流(mA)
        /// </summary>
        private string testElectricity = string.Empty;
        /// <summary>
        /// 试验电阻(MΩ)
        /// </summary>
        private string testResistance = string.Empty;
        /// <summary>
        /// 试验电压(V)
        /// </summary>
        private string testInsulationVoltage = string.Empty;
        /// <summary>
        /// 温度(℃)
        /// </summary>
        private string testTemperature = string.Empty;

        #endregion

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_TestType">试验仪器</param>
        /// <param name="_minvalue">最小值</param>
        /// <param name="_maxValue">最大值</param>
        /// <param name="_standardValue">目标值</param>
        /// <param name="_tfmID">模板号点位ID为工具参数配方主表ID</param>
        public FrmInstrument(string _TestType, decimal _minvalue, decimal _maxValue, decimal _standardValue, int _tfmID, bool _isWriteVal)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            TestType = _TestType;
            minvalue = _minvalue;
            maxValue = _maxValue;
            standardValue = _standardValue;
            TFMID = _tfmID;
            IsWriteVal = _isWriteVal;



        }

        /// <summary>
        /// 初始化试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmInstrument_Load(object sender, EventArgs e)
        {
            try
            {
                if (PublicVariable.CurAreaBDCode == EDAEnums.AreaBdCodeEnum.checkArea.ToString())
                {
                    TemperatureOPC = PublicVariable.GetSysConfig("TemperatureOPC");
                    HumidityOPC = PublicVariable.GetSysConfig("HumidityOPC");

                    if (string.IsNullOrEmpty(TemperatureOPC))
                        RWMessageBox.Show("获取温湿仪温度点位失败");

                    if (string.IsNullOrEmpty(HumidityOPC))
                        RWMessageBox.Show("获取温湿仪湿度点位失败");

                    TemperatureOPCTagValueCharge1.Init();

                    Task.Run(() =>
                    {
                        undTemperature.Text = Temperature_opcTagReadValue(TemperatureOPC).ToString();
                    });
                    Task.Run(() =>
                    {
                        undHumidity.Text = Temperature_opcTagReadValue(HumidityOPC).ToString();
                    });
                }

            }
            catch (Exception ex)
            {
                RWMessageBox.Show(ex.Message);
            }
            RefreshData();
        }

        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            toolForMulalist = _baseBLL.GetToolForMulaDetailAll(new BaseToolforMulaDetailModel() { ID = TFMID });
            lblVal.Text = standardValue.ToString();
            if (toolForMulalist.Count == 0)
            {
                RWMessageBox.Show("获取试验配方失败");
                this.Close();
                return;
            }

            #region 获取试验参数
            if (toolForMulalist[0].TestTypeName != EDAEnums.InstrumentTestType.ThreePhaseWinding)
            {
                //电流
                var ElectricityModel = toolForMulalist.Where(x => x.ItemTypeName == EDAEnums.SomeTestItems.Electricity).FirstOrDefault();
                testElectricity = ElectricityModel != null ? ElectricityModel.tfmdItemValue.ToString() : string.Empty;

                //时间
                var InsulationTimeModel = toolForMulalist.Where(x => x.ItemTypeName == EDAEnums.SomeTestItems.InsulationTime).FirstOrDefault();
                testTime = InsulationTimeModel != null ? InsulationTimeModel.tfmdItemValue.ToDecimal() : 0;

                //电阻
                var ResistanceModel = toolForMulalist.Where(x => x.ItemTypeName == EDAEnums.SomeTestItems.Resistance).FirstOrDefault();
                testResistance = ResistanceModel != null ? ResistanceModel.tfmdItemValue.ToString() : string.Empty;

                //电压
                var InsulationVoltageModel = toolForMulalist.Where(x => x.ItemTypeName == EDAEnums.SomeTestItems.InsulationVoltage).FirstOrDefault();
                testInsulationVoltage = InsulationVoltageModel != null ? InsulationVoltageModel.tfmdItemValue.ToString() : string.Empty;

                //温度
                var TemperatureModel = toolForMulalist.Where(x => x.ItemTypeName == EDAEnums.SomeTestItems.Temperature).FirstOrDefault();
                testTemperature = TemperatureModel != null ? TemperatureModel.tfmdItemValue.ToString() : string.Empty;
            }
            #endregion

            //只能做相对应的测试
            //三相绕组
            if (toolForMulalist[0].TestTypeName == EDAEnums.InstrumentTestType.ThreePhaseWinding)
            {
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                if (toolForMulalist[0].TestItemName == EDAEnums.InstrumentTestItem.U_V)
                {
                    btnReadVW.Enabled = false;
                    btnReadWU.Enabled = false;
                    txtUV.ReadOnly = IsWriteVal;
                }
                else if (toolForMulalist[0].TestItemName == EDAEnums.InstrumentTestItem.V_W)
                {
                    btnReadUV.Enabled = false;
                    btnReadWU.Enabled = false;
                    txtVW.ReadOnly = IsWriteVal;
                }
                else
                {
                    btnReadUV.Enabled = false;
                    btnReadVW.Enabled = false;
                    txtWU.ReadOnly = IsWriteVal;
                }
            }
            else if (toolForMulalist[0].TestTypeName == EDAEnums.InstrumentTestType.InsulationResistanceTest)
            {
                //绝缘电阻
                groupBox1.Enabled = false;
                groupBox4.Enabled = false;
                if (toolForMulalist[0].TestItemName == EDAEnums.InstrumentTestItem.ColdState)
                {
                    rdoCold.Checked = true;
                    rdoHot.Enabled = false;
                    txtJYDZLtContent.Text = "DC" + testInsulationVoltage + "V电压," + testTime + "秒,冷态时>" + testResistance + "MΩ";
                    txtColdResult.ReadOnly = IsWriteVal;
                }
                else
                {
                    rdoHot.Checked = true;
                    rdoCold.Enabled = false;
                    txtJYDZRtContent.Text = "DC" + testInsulationVoltage + "V电压," + testTime + "秒,热态时>" + testResistance + "MΩ";
                    txtHotResult.ReadOnly = IsWriteVal;
                }
            }
            else
            {
                //绝缘耐压
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                txtJYNYContent.Text = "AC/DC" + testInsulationVoltage + "V电压 耐压" + testTime + "秒，绝缘未破坏，漏电流" + testElectricity + "mA以下";
                txtJYNYResult.ReadOnly = IsWriteVal;
                if (toolForMulalist[0].TestItemName == EDAEnums.InstrumentTestItem.AlternatingCurrent)
                {
                    rdoAC.Checked = true;
                    rdoDC.Enabled = false;
                }
                else
                {
                    rdoDC.Checked = true;
                    rdoAC.Enabled = false;
                }
            }
        }

        #region 三相绕组测量
        /// <summary>
        /// 三相绕组清空数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.txtUV.Text = "0";
            this.txtUV1.Text = "0";
            this.txtVW.Text = "0";
            this.txtVW1.Text = "0";
            this.txtWU.Text = "0";
            this.txtWU1.Text = "0";
            this.txtResultUV.Text = "合格/不合格";
            this.txtResultVW.Text = "合格/不合格";
            this.txtResultWU.Text = "合格/不合格";
        }
        /// <summary>
        /// 读取U-V相电阻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadUV_Click(object sender, EventArgs e)
        {
            //从串口获取电阻值
            var UV = Math.Round(Convert.ToDouble(TH2516B.PortRead_TH2516B()) * Math.Pow(10, 3), 1);
            //当前UV相电阻值
            var UVVal = Math.Round(UV / 1000, 1);
            this.txtUV.Text = UVVal.ToString();

            GetUVData();
        }
        /// <summary>
        /// U-V相电阻回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetUVData();
            }
        }

        /// <summary>
        /// 获取UV数据
        /// </summary>
        private void GetUVData()
        {
            decimal ResultVal = txtUV.Text.ToDecimal(0);

            //当前测量电阻*（235+20）/（235+当前环境温度）
            var undTemperature = this.undTemperature.Text.ToDecimal(0);

            //换算电阻值
            this.txtUV1.Text = Math.Round(ResultVal * (T + 20) / (T + undTemperature), decimalNumber).ToString();

            decimal UV1 = txtUV1.Text.ToDecimal(0);
            ResultValue = UV1;
            if (UV1 >= minvalue && UV1 <= maxValue)
            {
                txtResultUV.Text = "合格";
            }
            else
            {
                txtResultUV.Text = "不合格";
            }
        }
        /// <summary>
        /// 读取V-W相电阻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadVW_Click(object sender, EventArgs e)
        {
            var VW = Math.Round(Convert.ToDouble(TH2516B.PortRead_TH2516B()) * Math.Pow(10, 3), 1);
            var VWVal = Math.Round(VW / 1000, 1);
            this.txtVW.Text = VWVal.ToString();

            GetVWData();
        }

        /// <summary>
        /// V-W相电阻回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtVW_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetVWData();
            }
        }
        /// <summary>
        /// 获取VW相电阻
        /// </summary>
        private void GetVWData()
        {
            decimal ResultVal = txtVW.Text.ToDecimal(0);

            //当前测量电阻*（235+20）/（235+当前环境温度）
            var undTemperature = this.undTemperature.Text.ToDecimal(0);

            //换算电阻值
            this.txtVW1.Text = Math.Round(ResultVal * (T + 20) / (T + undTemperature), decimalNumber).ToString();

            decimal VW1 = txtVW1.Text.ToDecimal(0);
            ResultValue = VW1;
            if (VW1 >= minvalue && VW1 <= maxValue)
            {
                txtResultVW.Text = "合格";
            }
            else
            {
                txtResultVW.Text = "不合格";
            }
        }
        /// <summary>
        /// 读取W-U相电阻
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReadWU_Click(object sender, EventArgs e)
        {
            var WU = Math.Round(Convert.ToDouble(TH2516B.PortRead_TH2516B()) * Math.Pow(10, 3), 1);
            var WUVal = Math.Round(WU / 1000, 1);
            this.txtWU.Text = WUVal.ToString();

            GetWUData();
        }

        /// <summary>
        /// W-U相电阻回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWU_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetWUData();
            }
        }
        /// <summary>
        /// 获取W-U相电阻数据
        /// </summary>
        private void GetWUData()
        {
            decimal ResultVal = txtWU.Text.ToDecimal(0);

            //当前测量电阻*（235+20）/（235+当前环境温度）
            var undTemperature = this.undTemperature.Text.ToDecimal(0);

            //换算电阻值
            this.txtWU1.Text = Math.Round(ResultVal * (T + 20) / (T + undTemperature), decimalNumber).ToString();

            decimal WU1 = txtWU1.Text.ToDecimal(0);
            ResultValue = WU1;
            if (WU1 >= minvalue && WU1 <= maxValue)
            {
                txtResultWU.Text = "合格";
            }
            else
            {
                txtResultWU.Text = "不合格";
            }
        }
        #endregion

        /// <summary>
        /// 计时器
        /// </summary>
        System.Threading.Timer timer = null;

        #region 绝缘电阻试验

        Thread t1;

        /// <summary>
        ///  绝缘电阻试验剩余时间
        /// </summary>
        int jydzTime = 0;

        /// <summary>
        /// 绝缘电阻开始试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJYDZStartTest_Click(object sender, EventArgs e)
        {
            t1 = new Thread(new ThreadStart(delegate
            {
                JYDZTest();

            }));
            t1.Start();
        }


        /// <summary>
        /// 绝缘电阻停止试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJYDZStopTest_Click(object sender, EventArgs e)
        {
            jydzTime = 0;
            if (timer != null)
                timer.Dispose();
            if (t1 != null)
                t1.Suspend();

            if (TestType == EDAEnums.ToolValueType.TH9110A)
                TH9110A.TH9110A_TestStop();
            else
                TH9310.TH9310_TestStop();

            lblJYDZTime.Text = "00:00:00";
            this.btnJYDZStartTest.Enabled = true;
        }

        /// <summary>
        /// 绕组绝缘电阻试验
        /// </summary>
        private void JYDZTest()
        {
            this.btnJYDZStartTest.Enabled = false;
            jydzTime = Convert.ToInt32(testTime);
            timer = new System.Threading.Timer(delegate
            {

                if (jydzTime < 0)
                    return;
                TimeSpan ts = new TimeSpan(0, 0, jydzTime);
                this.lblJYDZTime.Text = ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
                jydzTime--;

            }, null, 0, 1000);

            //测试所用采用最少电压为50V，避免发生意外，真实环境可自行配置
            //TH9110A.TH9320_JueYuanTest("50", jydzTime,"50");

            if (TestType == EDAEnums.ToolValueType.TH9110A)
                TH9110A.TH9110A_JueYuanTest(testInsulationVoltage, jydzTime, testResistance);
            else
                TH9310.TH9310_JueYuanDZTest(testInsulationVoltage, jydzTime, testResistance);


            Thread.Sleep(jydzTime * 1000);


            //延时10秒再进行采值（不然可能采不到值）
            Thread.Sleep(10000);
            if (TestType == EDAEnums.ToolValueType.TH9110A)
                TH9110A.GetJYDZRst();
            else
                TH9310.GetJYDZRst();

            double b = 0;

            if (TestType == EDAEnums.ToolValueType.TH9110A)
            {
                b = Convert.ToDouble(TH9110A.CurRValue) * Math.Pow(10, 6);
                ResultValue = Math.Round(b, 2).ToDecimal();
            }
            else
            {
                b = Convert.ToDouble(TH9310.CurRValue);
                ResultValue =Math.Round(b,2).ToDecimal();
              
            }

            if (rdoCold.Checked)
            {
                txtColdResult.Text = ResultValue.ToString();
                if (ResultValue >= minvalue && ResultValue <= maxValue)
                {
                    txtColdResult1.Text = "合格";
                }
                else
                {
                    txtColdResult1.Text = "不合格";
                }
            }
            if (rdoHot.Checked)
            {
                txtHotResult.Text = ResultValue.ToString();
                if (ResultValue >= minvalue && ResultValue <= maxValue)
                {
                    txtHotResult1.Text = "合格";
                }
                else
                {
                    txtHotResult1.Text = "不合格";
                }
            }

            this.btnJYDZStartTest.Enabled = true;
            Thread.Sleep(1000);
            timer.Dispose();
        }
        /// <summary>
        /// 绝缘电阻冷态结果值回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtColdResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                decimal ResultVal = txtColdResult.Text.ToDecimal();
                ResultValue = ResultVal;
                if (ResultVal >= minvalue && ResultVal <= maxValue)
                {
                    txtColdResult1.Text = "合格";

                }
                else
                {
                    txtColdResult1.Text = "不合格";
                }
            }
        }
        /// <summary>
        /// 绝缘电阻热态结果值回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHotResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                decimal ResultVal = txtHotResult.Text.ToDecimal();
                ResultValue = ResultVal;
                if (ResultValue >= minvalue && ResultValue <= maxValue)
                {
                    txtHotResult1.Text = "合格";
                }
                else
                {
                    txtHotResult1.Text = "不合格";
                }
            }
        }
        #endregion

        #region 绝缘耐压试验
        Thread t2;
        /// <summary>
        ///  绝缘电阻试验剩余时间
        /// </summary>
        int jynyTime = 0;
        /// <summary>
        /// 绝缘耐压开始试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJYNYStartTest_Click(object sender, EventArgs e)
        {
            t2 = new Thread(new ThreadStart(delegate
            {
                JYNYTest();

            }));
            t2.Start();
        }
        /// <summary>
        /// 绝缘耐压停止试验
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJYNYStopTest_Click(object sender, EventArgs e)
        {
            jynyTime = 0;
            if (timer != null)
                timer.Dispose();

            if (t2 != null)
                t2.Suspend();

            if (TestType == EDAEnums.ToolValueType.TH9110A)
                TH9110A.TH9110A_TestStop();
            else
                TH9310.TH9310_TestStop();

            lblJYNYTime.Text = "00:00:00";
            this.btnJYNYStartTest.Enabled = true;
        }
        /// <summary>
        /// 绕组绝缘耐压试验
        /// </summary>
        public void JYNYTest()
        {
            this.btnJYNYStartTest.Enabled = false;//禁用按钮防止暴力点击
            //测试所用
            //jynyTime = Convert.ToInt32(1.00 * 60);

            jynyTime = Convert.ToInt32(testTime);
            timer = new System.Threading.Timer(delegate
            {
                if (jynyTime < 0)
                    return;
                TimeSpan t1 = new TimeSpan(0, 0, jynyTime);
                lblJYNYTime.Text = t1.Hours + ":" + t1.Minutes + ":" + t1.Seconds;
                jynyTime--;

            }, null, 0, 1000);

            bool IsAc = rdoAC.Checked ? true : false;
            //测试所用采用最小电压和电流
            //TH9110A.TH9320_NaiYaTest("50", jynyTime.ToString(), "50", IsAc);
            if (TestType == EDAEnums.ToolValueType.TH9110A)
                TH9110A.TH9110A_NaiYaTest(testInsulationVoltage, jynyTime.ToString(), testElectricity, IsAc);
            else
                TH9310.TH9310_NaiYaTest(testInsulationVoltage, jynyTime.ToString(), testElectricity, IsAc);

            Thread.Sleep(jynyTime * 1000);
            //延时10秒再进行采值（不然可能采不到值）
            Thread.Sleep(10000);

            if (TestType == EDAEnums.ToolValueType.TH9110A)
                TH9110A.GetJYDZRst();
            else
                TH9310.GetJYDZRst();

            double b = 0;
            if (TestType == EDAEnums.ToolValueType.TH9110A)
                b = Convert.ToDouble(TH9110A.CurIValue) * Math.Pow(10, 3);
            else
                b = Convert.ToDouble(TH9310.CurIValue) * Math.Pow(10, 3);

            ResultValue = b.ToDecimal() / 1000;
            txtJYNYResult.Text = ResultValue.ToString();
            if (ResultValue >= minvalue && ResultValue <= maxValue)
            {
                txtJYNYResult1.Text = "合格";
            }
            else
            {
                txtJYNYResult1.Text = "不合格";
            }
            this.btnJYNYStartTest.Enabled = true;
            Thread.Sleep(1000);
            timer.Dispose();

        }
        /// <summary>
        /// 绝缘耐压结果值回车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtJYNYResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                decimal ResultVal = txtJYNYResult.Text.ToDecimal();
                ResultValue = ResultVal;
                if (ResultVal >= minvalue && ResultVal <= maxValue)
                {
                    txtJYNYResult1.Text = "合格";
                }
                else
                {
                    txtJYNYResult1.Text = "不合格";
                }
            }
        }
        #endregion

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ResultValue >= minvalue && ResultValue <= maxValue)
            {
                GC.Collect();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                GC.Collect();
                if (MessageBox.Show(string.Format("试验结果值为[{0}]不合格,无法继续往下执行！", ResultValue), "温馨提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }

        }

        //读取温湿仪OPC的数值
        private object Temperature_opcTagReadValue(string tagKey)
        {
            object tagValue = null;

            if (!string.IsNullOrEmpty(tagKey))
            {
                tagValue = TemperatureOPCTagValueCharge1.Read(tagKey);
            }
            return tagValue;
        }


        /// <summary>
        /// 温湿仪点位发生变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        private void TemperatureOPCTagValueCharge1_NameValueChanged(object sender, string tagKey, object tagValue)
        {
            if (string.IsNullOrEmpty(tagKey))
                return;

            lock (_objOPCTagLock)
            {
                if (tagKey == TemperatureOPC)
                    undTemperature.Text = Temperature_opcTagReadValue(TemperatureOPC).ToString();

                if (tagKey == HumidityOPC)
                    undHumidity.Text = Temperature_opcTagReadValue(HumidityOPC).ToString();
            }

        }

    }
}