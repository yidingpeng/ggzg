using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;
using RW.PMS.Utils;
using RW.PMS.IBLL;
using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.Follow;
using RW.PMS.Utils.UI;
using System.Configuration;
using RW.PMS.WinForm.UI;
using RW.PMS.Model.Sys;
using RW.PMS.Model.BaseInfo;
using RW.PMS.WinForm.UI.Follow;
using RW.PMS.WinForm.UI.Assembly;
using RW.PMS.WinForm.UI.Device;
using RW.PMS.WinForm.OPC;
using RW.PMS.Common.Logger;
using System.Threading.Tasks;
using System.Diagnostics;
using RW.PMS.WinForm.Common;
using RW.PMS.WinForm.Utils.Torque;
using RW.PMS.Model.Log;
//using System.Web.Script.Serialization;
using RW.PMS.WinForm.Module;
using System.Drawing.Drawing2D;

namespace RW.PMS.WinForm
{
    public partial class FrmMain : FormSkin
    {

        #region 全局变量
        private object _objLock = new object();

        private object _objOPCTagLock = new object();

        private object _objCameraLock = new object();

        private static IBLL_Follow BLL = DIService.GetService<IBLL_Follow>();

        //OPC点位控制
        private OPC_Function _opcFunc = null;
        //装配管理数据操作
        private AssemblyDataControl _asseDataControl = null;
        //装配程序控制
        private AssemblyProgramControl _assProgControl = null;
        //扭力扳手 
        private TorqueFactory _torqueFactory = null;
        //当前扭力扳手类型
        private TorqueParam _currTorque = null;
        //点位控制
        private OpcControl _opcControl = null;
        //视频保存路径
        private string _videoDir = Path.Combine(Application.StartupPath, "gxVideo");
        //工位的所有工具物料点位，用于异常报警
        private string[] _arrayGJWlTags = null;
        //状态栏
        private SysStatusBar _sysStatusBar = null;
        //是否为工序返回
        private bool _isGxReturn = false;
        //是否为例外转序
        private bool _isGbConvert = false;
        //工步参数模型
        private GbParam _gbParam = null;
        //工具物料编码
        private string _gjwlCode = string.Empty;
        //拍照操作
        //private bool _isCameraOper = false;
        //电动扳手数据采集窗体
        FrmTorque _frmTorque = null;
        //当前扳手工具
        BaseTorque _currToolTorque = null;
        //异常下线重新装配标识
        public bool offlineState = false;
        private BaseGwProdDefModel beatMinite = null;

        //OPCTagValueCharge 控件
        private OPCTagValueCharge _opcTagValueCharge1 = null;

        //产品型号
        List<BaseProductModelModel> _productModels = null;

        private int TorqueNum = 0;

        #endregion

        #region 通用方法

        //扭力扳手参数模型
        private class TorqueParam
        {
            public string Type { get; set; }

            public decimal StandardValue { get; set; }

            public decimal MaxValue { get; set; }

            public decimal MinValue { get; set; }

            public decimal Value { get; set; }

            public decimal Angle { get; set; }

            public string Other { get; set; }

            //public BaseTorque Torque { get; set; }

            /// <summary>
            /// 验证扭力值
            /// </summary>
            /// <returns></returns>
            public bool? VerifyTorque()
            {
                if (MaxValue <= 0 || MinValue <= 0)
                {
                    return null;
                }
                if (Value >= MinValue && Value <= MaxValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 点位管控类型
        /// </summary>
        private enum OPCControlType
        {
            /// <summary>
            /// 拿起放回
            /// </summary>
            GetPut,
            /// <summary>
            /// 扭力扳手
            /// </summary>
            Torque,
            /// <summary>
            /// 图像比对
            /// </summary>
            Camera,
            /// <summary>
            /// 注油枪
            /// </summary>
            InjectionOilGun,
            /// <summary>
            /// 人工自检
            /// </summary>
            EmpCheck,
            /// <summary>
            /// 压装机
            /// </summary>
            Pressure,
            None,

        }

        //工步参数模型 
        private class GbParam
        {
            public int FinishStatus { get; set; }

            public int Result { get; set; }

            public string ResultMemo { get; set; }
        }

        private void ActionInvoke(Delegate del)
        {
            if (!this.IsDisposed)
            {
                this.Invoke(del);
            }

        }

        //显示图片
        private void ShowImage(byte[] img = null)
        {
            if (img != null && img.Length > 0)
            {
                using (var myStream = new MemoryStream(img))
                {
                    var myImage = Image.FromStream(myStream);
                    this.GxpictureBox.Image = myImage;
                    this.GxpictureBox.Refresh();
                }
            }
            else
            {
                this.GxpictureBox.Image = null;
                this.GxpictureBox.Refresh();
            }
        }

        //下载视频
        private void DownLoadVideo()
        {
            var port = "80";
            if (!string.IsNullOrWhiteSpace(SysConfig.ServerPort))
            {
                port = SysConfig.ServerPort;
            }
            var videoPath = string.Format("http://{0}:{1}", SysConfig.ServerIP, port);
            backgroundWorker.DoWork += (sender, e) =>
            {
                var videoModels = _asseDataControl.GetGXVideo(SysConfig.LocalIP);

                var errorMsg = string.Empty;

                foreach (var item in videoModels.Where(f => !string.IsNullOrWhiteSpace(f.Name)))
                {
                    var fileName = Path.Combine(_videoDir, item.Name);

                    if (!File.Exists(fileName))
                    {
                        if (videoPath.Last() == '\\')
                        {
                            videoPath = item.Address.Remove(videoPath.Length - 1, 1);
                        }
                        if (item.Address.Last() == '\\')
                        {
                            item.Address = item.Address.Remove(item.Address.Length - 1, 1);
                        }
                        var httpPath = (videoPath + item.Address).Replace(@"\", "/");
                        var msg = NetworkHelper.DownLoadFiles(fileName, httpPath);
                        if (!string.IsNullOrEmpty(msg))
                        {
                            errorMsg += string.Format("视频'{0}'下载失败！", httpPath) + msg + Environment.NewLine;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(errorMsg))
                {
                    MessageBox.Show(errorMsg);
                }
                backgroundWorker.Dispose();
            };
            backgroundWorker.RunWorkerAsync();
        }

        // 显示视频
        private void ShowVideo(string path)
        {
            if (File.Exists(path))
            {
                this.axWindowsMediaPlayer1.Visible = true;
                this.axWindowsMediaPlayer1.URL = path;
                this.axWindowsMediaPlayer1.settings.mute = false;//静音播放
                this.axWindowsMediaPlayer1.uiMode = "None";//UI界面显示模式
                this.axWindowsMediaPlayer1.Ctlcontrols.play();
                this.axWindowsMediaPlayer1.settings.setMode("loop", true);//循环播放
            }
            else
            {
                this.axWindowsMediaPlayer1.URL = string.Empty;
                this.axWindowsMediaPlayer1.Visible = false;
            }
        }

        //清理状态信息 
        private void Clear()
        {
            //文本
            this.richTxtGbName.Text = string.Empty;//工步名称
            this.richTxtGjValue.Text = string.Empty;//工步描述
            this.txt_gbDesc.Text = string.Empty;//中间下方提示
            //图片
            this.GxpictureBox.Image = null;
            this.GxpictureBox.Refresh();
            //播放视频
            ShowVideo(string.Empty);

            //列表
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                dataGridView1.Rows[i].ReadOnly = true;
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                dataGridView1.Rows[i].Cells[0].Value = Properties.Resources.beijing;
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = 0; //滚动条动态滚动
            }

        }

        //绑定产品型号 
        private void BingDDL()
        {
            try
            {
                //产品型号
                var ddlList = _asseDataControl.GetProdModelForDDL(SysConfig.CurGwID);
                cmbProdModel.DataSource = ddlList;
                cmbProdModel.DisplayMember = "Value";
                cmbProdModel.ValueMember = "Key";

                _productModels = _asseDataControl.GetProductModelAll();
            }
            catch (Exception ex)
            {
                Logger.Default.Error("产品型号绑定失败！", ex);

                MessageBox.Show("产品型号绑定失败！" + ex.Message);
            }
        }

        //点位还原
        private void ClearOPCtags()
        {
            var allOPCTag = _asseDataControl.GetAllOPCTag(SysConfig.LocalIP, true);

            _opcFunc.ClearOPCtag(allOPCTag, _opcTagValueCharge1);

        }

        //组装异常记录
        internal void AddError(int errorID, string errDesp)
        {
            _asseDataControl.AddErrorInfo(errorID, errDesp);

            //亮红灯
            RedLight();
        }

        //要亮报警红灯，并鸣警
        private void RedLight()
        {
            Task.Run(() =>
            {
                _opcFunc.RedLight(_opcTagValueCharge1);

                System.Threading.Thread.Sleep(SysConfig.ErrorTimer);

                if (!this.IsDisposed)
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        if (this.richTxtGjValue.Text == "工具拿错或放错" || this.richTxtGjValue.Text == "物料拿错或放错")
                        {
                            this.richTxtGjValue.Text = string.Empty;
                        }
                    }));
                    _opcFunc.GreenLight(_opcTagValueCharge1);
                }

            });
        }

        /// <summary>
        /// 亮黄灯 （程序打开）
        /// </summary>
        private void YellowLight()
        {
            Task.Run(() =>
            {
                _opcFunc.YellowLight(_opcTagValueCharge1);
            });
        }

        /// <summary>
        /// 亮绿灯 （装配过程）
        /// </summary>
        private void GreenLight()
        {
            Task.Run(() =>
            {
                _opcFunc.GreenLight(_opcTagValueCharge1);
            });
        }

        //跳转显示控制
        private void EnableSetupControl(bool Enabled)
        {
            this.toolbtnReturn.Enabled = Enabled;
            this.toolbtnConvert.Enabled = Enabled;
            this.toolbtnError.Enabled = Enabled;
            //this.txtSetupNum.Text = string.Empty;
            //this.txtSetupNum.Enabled = Enabled;
            //this.btnStepTest.Enabled = Enabled;
            //this.btnGjWlSubmit.Enabled = Enabled;
            this.toolbtnStart.Enabled = !Enabled;
        }

        //记录提示错误信息
        private void ShowErrorMessage(string mes, Exception ex = null)
        {
            Logger.Default.Error(mes, ex);
            MessageBox.Show(mes + (ex == null ? "" : ex.Message));
        }

        //OPC点位控制
        private class OpcControl
        {
            /// <summary>
            /// 当前OPC点
            /// </summary>
            public string OPCTagName { get; set; }
            /// <summary>
            /// opc需要还原点位
            /// </summary>
            public string OPCTagRestName { get; set; }
            /// <summary>
            /// opc点位管控方式
            /// </summary>
            public OPCControlType ControlType { get; set; }

            public string Other { get; set; }
        }

        #endregion

        #region 点位控制
        private void opcTagValueCharge1_NameValueChanged(object sender, string tagKey, object tagValue)
        {

            if (_opcControl == null)
                return;

            lock (_objOPCTagLock)
            {

                if (_opcFunc != null && (tagKey == _opcFunc.CurGwErrRangOPC ||
              tagKey == _opcFunc.CurGwGreenOPC ||
              tagKey == _opcFunc.CurGwRedOPC ||
              tagKey == _opcFunc.CurGwYellowOPC))
                {
                    return;
                }

                switch (_opcControl.ControlType)
                {

                    case OPCControlType.GetPut:

                        #region 拿起放下工具物料点位操作

                        if (!string.IsNullOrEmpty(tagKey) && !string.IsNullOrEmpty(_opcControl.OPCTagName) && _arrayGJWlTags.Contains(tagKey))
                        {

                            //拿工具
                            if (_assProgControl.ControlMode == ControlMode.GJ)
                            {
                                if (tagKey == _opcControl.OPCTagName)
                                {

                                    //if (ConvertHelper.ToInt32(tagValue, 1) == 1)
                                    //{

                                    //}  

                                    //工具操作完成后，把发送拿工具的指令复位
                                    if (!string.IsNullOrEmpty(_opcControl.OPCTagRestName))
                                    {
                                        ShowGJMsg(string.Empty);
                                        _opcFunc.OpcTagWriteValue(_opcControl.OPCTagRestName, false, _opcTagValueCharge1);
                                    }

                                    _opcControl.ControlType = OPCControlType.None;
                                    _assProgControl.Set();

                                }
                                else
                                {
                                    if (_opcTagValueCharge1.Read(tagKey).ToBool())
                                    {
                                        this.ActionInvoke(new MethodInvoker(delegate ()
                                        {
                                            //保存异常，发送红灯指令，鸣警
                                            AddError(_asseDataControl.WuliaoErrorID, "工具拿错或放错");

                                            ShowGJMsg("工具拿错或放错", true);

                                        }));
                                    }
                                }
                            }

                            //拿物料
                            if (_assProgControl.ControlMode == ControlMode.WL)
                            {
                                if (tagKey == _opcControl.OPCTagName)
                                {

                                    if (ConvertHelper.ToInt32(tagValue, 0) == 0)
                                    {
                                        _opcControl.ControlType = OPCControlType.None;
                                        _assProgControl.Set();
                                    }
                                    //工具操作完成后，把发送拿物料的指令复位
                                    if (!string.IsNullOrEmpty(_opcControl.OPCTagRestName) && tagValue.ToBool())
                                    {
                                        _opcFunc.OpcTagWriteValue(_opcControl.OPCTagRestName, false, _opcTagValueCharge1);
                                    }
                                }
                                else
                                {
                                    this.ActionInvoke(new MethodInvoker(delegate ()
                                    {
                                        //保存异常，发送红灯指令，鸣警
                                        AddError(_asseDataControl.WuliaoErrorID, "物料拿错或放错");

                                        ShowGJMsg("物料拿错或放错", true);

                                    }));
                                }
                            }
                        }
                        #endregion

                        break;
                    case OPCControlType.None:

                        break;
                    default:
                        break;
                }
            }
            //System.Diagnostics.Debug.WriteLine(string.Format("================ time:{0} OPC ControlType:{1} Key:{2}  Value:{3} ========================",
            //    DateTime.Now, _opcControl == null ? OPCControlType.None : _opcControl.ControlType, tagKey, tagValue));
        }
        #endregion

        #region 窗体控件事件

        #region 初始化

        public FrmMain()
        {
            InitializeComponent();

            Application.ApplicationExit += Application_ApplicationExit;

            Logger.AppName = this.Text;

            //不启用自动添加数据列
            this.dataGridView1.AutoGenerateColumns = false;

            this.cmbProdModel.SelectedIndexChanged += cmbProdModel_SelectedIndexChanged;

            //当前工位是否需要启动OPC驱动 
            var isOPC = DIService.GetService<IBLL_BaseInfo>().GetGwByIP(PublicVariable.LocalIP);
            if (isOPC)
            {
                //启动OPC 
                _opcTagValueCharge1 = new OPCTagValueCharge();

                _opcTagValueCharge1.NameValueChanged += opcTagValueCharge1_NameValueChanged;

                _opcTagValueCharge1.Init();
            }

        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            try
            {
                _opcFunc = new OPC_Function();

                _opcFunc.Init();

                _asseDataControl = new AssemblyDataControl();

                _torqueFactory = new TorqueFactory(this);

                this.axWindowsMediaPlayer1.Visible = false;
                this.axWindowsMediaPlayer1.uiMode = "none"; //视频属性配置：去掉菜单控制栏 
                this.axWindowsMediaPlayer1.enableContextMenu = false; //屏蔽右键
                this.axWindowsMediaPlayer1.stretchToFit = true; //视频属性配置：铺满屏幕

                //初始化延迟时间
                lblTime.Text = string.Empty;
                //手动管控
                btnSteup.Visible = false;
                //下载视频
                DownLoadVideo();
                //用户权限
                SetEmpGongweiRight();
                //产品列表
                BingDDL();

                if (PublicVariable.IsAdmin)
                {
                    //txtSetupNum.Visible = true;
                    //btnStepTest.Visible = true;
                    //btnGjWlSubmit.Visible = true;
                    EnableSetupControl(false);
                }

                //获取系统配置信息
                //_sysStatusBar = new SysStatusBar(this, _opcTagValueCharge1); 

                if (string.IsNullOrEmpty(SysConfig.ServerIP))
                {
                    ShowErrorMessage("获取服务器地址失败！请检查网络");
                    return;
                }
                if (string.IsNullOrEmpty(SysConfig.PLCTag))
                {
                    ShowErrorMessage("获取PLC点位失败！请检查OPC");
                    return;
                }

                Task.Run(() =>
                {
                    this.ActionInvoke(new MethodInvoker(delegate ()
                    {
                        this.toolbtnStart.Enabled = false;
                    }));

                    //点位还原
                    ClearOPCtags();

                }).ContinueWith(task =>
                {
                    this.ActionInvoke(new MethodInvoker(delegate ()
                    {
                        this.toolbtnStart.Enabled = true;
                    }));

                    GreenLight();
                });

                //显示状态栏
                ToolStripStatus();

                cmbProdModel_SelectedIndexChanged();

                //自动运行装配系统
                //AutoRunSetup();

            }
            catch (Exception ex)
            {
                Logger.Default.Error("初始化失败！", ex);

                MessageBox.Show("初始化失败！" + ex.Message);
            }
        }

        #endregion

        //状态栏显示 
        private void ToolStripStatus()
        {
            this.toolStripStatusLabel1.Text = "当前登陆用户：" + PublicVariable.CurEmpName + " - 工位：" + SysConfig.CurGwName + " - IP地址：(" + SysConfig.LocalIP + ")";
            this.toolStripStatusLabel2.Text = "当前系统时间：" + PublicVariable.GetSystemDateTime();
            //this.toolStripStatusLabel3.Text = "网络通讯状态：";

            var plcIsConnect = false;
            if (!string.IsNullOrEmpty(SysConfig.PLCTag))
            {
                if (_opcTagValueCharge1 != null)
                {
                    var readPLCstatus = _opcTagValueCharge1.Read(SysConfig.PLCTag);
                    if (readPLCstatus != null)
                    {
                        bool.TryParse(readPLCstatus.ToString(), out plcIsConnect);
                    }
                }

            }

            //if (plcIsConnect)
            //{
            //    this.toolStripStatusLabel4.Text = "设备通讯状态：" + "连接正常"; 
            //    this.toolStripStatusLabel4.ForeColor = Color.Green;
            //}
            //else
            //{
            //    this.toolStripStatusLabel4.Text = "设备通讯状态：" + "连接异常";
            //    this.toolStripStatusLabel4.ForeColor = Color.Red;
            //}

            //_sysStatusBar.PingNetworkStatus += (sender, e) =>
            //{
            //    if (e)
            //    {
            //        //this.toolStripStatusLabel3.Text = "网络通讯状态：连接正常";
            //        //this.toolStripStatusLabel3.ForeColor = Color.Green;
            //    }
            //    else
            //    {
            //        //this.toolStripStatusLabel3.Text = "网络通讯状态：连接异常";
            //        //this.toolStripStatusLabel3.ForeColor = Color.Red;
            //    }
            //};
            //_sysStatusBar.OPCDeviceStatus += (sender, e) =>
            //{
            //    if (e) 
            //    {
            //        //this.toolStripStatusLabel4.Text = "设备通讯状态：连接正常";
            //        //this.toolStripStatusLabel4.ForeColor = Color.Green;
            //    }
            //    else
            //    {
            //        //this.toolStripStatusLabel4.Text = "设备通讯状态：连接异常";
            //        //this.toolStripStatusLabel4.ForeColor = Color.Red;
            //    }
            //};
        }

        //选择工艺程序 
        private void cmbProdModel_SelectedIndexChanged(object sender = null, EventArgs e = null)
        {
            if (ConvertHelper.ToInt32(this.cmbProdModel.SelectedValue, 0) > 0)
            {
                var dtprog = _asseDataControl.GetProgramForDLL(SysConfig.CurGwID, ConvertHelper.ToInt32(this.cmbProdModel.SelectedValue, 0));

                this.cmbProgram.DataSource = dtprog;
                this.cmbProgram.DisplayMember = "Value";
                this.cmbProgram.ValueMember = "Key";
            }
        }

        //设备保养
        private void toolbtnDevice_Click(object sender, EventArgs e)
        {
            //var devexec = new FrmDeviceExec();
            //devexec.ShowDialog();

            //设备保养明细窗体打开 
            UI.Device.FrmDeviceExecDetail devexec = new UI.Device.FrmDeviceExecDetail();
            devexec.ShowDialog(this);
            devexec.Dispose();
        }

        //模拟装配
        private void toolbtnDemo_Click(object sender, EventArgs e)
        {
            var demoAms = new FrmDemoAms();
            demoAms.ShowDialog(this);
            demoAms.Dispose();
        }

        //解除报警
        private void toolbtnUnError_Click(object sender, EventArgs e)
        {
            if (_opcTagValueCharge1 != null)
            {
                _opcFunc.GreenLight(_opcTagValueCharge1);
            }
        }

        //装配记录
        private void toolbtnRecord_Click(object sender, EventArgs e)
        {
            UI.Assembly.FrmAssemblyFollow af = new UI.Assembly.FrmAssemblyFollow();
            af.ShowDialog(this);
            af.Dispose();
        }

        //信息反馈
        private void toolbtnFeedBack_Click(object sender, EventArgs e)
        {
            FrmFollowFeedback f = new FrmFollowFeedback();
            f.ShowDialog(this);
            f.Dispose();
        }

        //设备点检
        private void toolbtnChecking_Click(object sender, EventArgs e)
        {
            FrmDeviceChecking f = new FrmDeviceChecking();
            f.ShowDialog(this);
            f.Dispose();
        }

        //添加快捷键操作
        private void Form_main_KeyDown(object sender, KeyEventArgs e)
        {
            //单键
            switch (e.KeyCode)
            {
                case Keys.F10:
                    if (toolbtnReturn.Enabled)
                    {
                        toolbtnReturn_Click(this, EventArgs.Empty);
                    }
                    break;

                case Keys.F11:
                    if (toolbtnConvert.Enabled)
                    {
                        toolbtnConvert_Click(this, EventArgs.Empty);
                    }
                    break;
            }
            // 组合键
            if (e.KeyCode == Keys.F4 && e.Modifiers == Keys.LWin)
            {
                toolbtnShutdown_Click(this, EventArgs.Empty);
            }
        }

        //退出
        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            Clear();

            //点位还原
            ClearOPCtags();

            Application.DoEvents();

            Application.Exit();
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _assProgControl?.Stop();

            _sysStatusBar?.Dispose();

            _currToolTorque?.CloseConnection();

            #region 完成考勤信息

            PublicVariable.SaveLogoutTime();

            #endregion

            //设备运行
            SysConfig.DeviceRun();
            //点位还原
            ClearOPCtags();

        }


        /// <summary>
        /// 程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Application_ApplicationExit(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }


        /// <summary>
        /// 系统时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [System.Diagnostics.DebuggerStepThrough]
        private void timer3_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = "当前系统时间：" + PublicVariable.GetSystemDateTime();
        }


        /// <summary>
        /// 启动装配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                RunSetup();
            }
            catch (Exception ex)
            {
                Logger.Default.Error("启动装配管理出错！", ex);

                ShowErrorMessage("启动装配管理出错！" + ex.Message, ex);
            }
        }

        //监控报警声音是否启动
        private void timer_ErrRang_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_opcFunc.OpcTagReadValue(_opcFunc.CurGwRedOPC, _opcTagValueCharge1))
                {
                    // _opcFunc.OpcTagWriteValue(_opcFunc.CurGwRedOPC, false, _opcTagValueCharge1);
                }
            }
            catch (Exception ex)
            {
                Logger.Default.Error("监控报警声音是否启动出错！", ex);
            }

        }


        /// <summary>
        /// 关机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnShutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否关闭当前计算机！", "关机确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //点位还原 
                ClearOPCtags();
                using (var process = new Process())
                {
                    var startInfo = new ProcessStartInfo();
                    startInfo.FileName = "shutdown ";
                    startInfo.Arguments = " -s -t 0 -f";
                    startInfo.UseShellExecute = false;
                    startInfo.RedirectStandardInput = true;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.CreateNoWindow = true;
                    process.StartInfo = startInfo;
                    startInfo.Verb = "RunAs";
                    process.Start();
                }
            }
        }

        #endregion

        #region 程序装配管理控制
        private void AssemblyProgControl(int programID)
        {
            beatMinite = _asseDataControl.GetGwProdDefByBeatMinite(programID);

            //工艺文件 
            var list = _asseDataControl.ProgGXGBList(programID);
            dataGridView1.DataSource = list;

            _assProgControl = new AssemblyProgramControl(list, _asseDataControl.ControlTypes, this);
            _assProgControl.StartInvoke += assemblyProgramControl_StartInvoke;
            _assProgControl.FinishInvoke += assemblyProgramControl_FinishInvoke;
            _assProgControl.BeginGXInvoke += assemblyProgramControl_BeginGXInvoke;
            _assProgControl.EndGXInvoke += assemblyProgramControl_EndGXInvoke;
            _assProgControl.BeginGBInvoke += assemblyProgramControl_GBBeginInvoke;
            _assProgControl.EndGBInvoke += assemblyProgramControl_GBEndInvoke;
            _assProgControl.GJWLBeginInvoke += assemblyProgramControl_GJWLBeginInvoke;
            _assProgControl.GJWLEndInvoke += assemblyProgramControl_GJWLEndInvoke;
            _assProgControl.OtherBeginInvoke += assemblyProgramControl_OtherBeginInvoke;
            _assProgControl.OtherEndInvoke += assemblyProgramControl_OtherEndInvoke;
            _assProgControl.Start();

        }

        private void assemblyProgramControl_StartInvoke(object sender, EventArgs e)
        {
            try
            {

                //查询异常下线信息 
                AbnormalOfflineModel model = _asseDataControl.GetOfflineInfo(_asseDataControl.QR_Code);

                if (model != null)
                {
                    offlineState = true;
                    _asseDataControl.CurAssbmGxGuid = model.agx_guid;
                    _asseDataControl.CurAssbmGwGuid = model.agw_guid;
                    _assProgControl.CurrentGXIndex = model.CurrentGXIndex;
                    _assProgControl.CurrentGBIndex = model.CurrentGBIndex;
                    _assProgControl.CurrentGJWLIndex = model.CurrentGJWLIndex;

                    _asseDataControl.GetAssemblyGwDetail(model.agw_guid.Value, model.agx_guid.Value);

                }
                else
                {
                    //添加工位信息 开始
                    _asseDataControl.AddAssbGw(SysConfig.CurGwID, SysConfig.CurGwName, Convert.ToInt32(cmbProgram.SelectedValue), cmbProgram.Text, PublicVariable.CurEmpID, PublicVariable.CurEmpName);
                }

                //亮绿灯
                GreenLight();

                EnableSetupControl(true);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("启动装配出错！", ex);
            }
        }

        private void assemblyProgramControl_FinishInvoke(object sender, EventArgs e)
        {
            try
            {
                //关闭扭力扳手连接
                _currToolTorque?.CloseConnection();

                if (offlineState)
                {
                    offlineState = false;

                    _asseDataControl.UpdateOffline(_asseDataControl.QR_Code);
                }

                //修改工位信息 完成
                _asseDataControl.UpdateAssbGw(ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.finished, 1), ConvertHelper.ToInt32(EDAEnums.CheckResult.OK, 1), EDAEnums.CheckResultMemo.Qualified.ToString());

                if (SysConfig.CurGwID == 168)
                {
                    //添加产品编号并与计划关联,将当前产品编号改为已完成
                    _asseDataControl.UpdateProductInfo(_asseDataControl.QR_Code, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), "", 1, PublicVariable.CurGwID, string.Empty);
                }

                FinishStatus();

                this._opcControl = null;
                _asseDataControl.ProductInfoID = null;
                _asseDataControl.QR_Code = null;
                //清除产品序列号
                ShowProdNo(string.Empty);
                //点位还原
                ClearOPCtags();

                //清除工序名称显示
                ShowGxuName(string.Empty);

                richTxtGbName.Text = "装配完成\r\n";

                toolbtnStart.Enabled = true;

                //亮黄灯
                GreenLight();

                //自动运行
                //AutoRunSetup();

            }
            catch (Exception ex)
            {
                ShowErrorMessage("完成装配出错！", ex);
            }
        }

        private void assemblyProgramControl_BeginGXInvoke(object sender, ProGXGBModel e)
        {
            try
            {
                //显示工序名称
                ShowGxuName(e.gxname);

                //播放工步视频
                if (!string.IsNullOrEmpty(e.GxvedioFilename))
                {
                    var fileName = Path.Combine(_videoDir, e.GxvedioFilename);
                    ShowVideo(fileName);
                }
                //添加工序信息 工序开始
                _asseDataControl.AddAssbGx(e.progGXID.Value, e.gxname, PublicVariable.CurEmpID, PublicVariable.CurEmpName);
            }
            catch (Exception ex)
            {
                ShowErrorMessage("开始工序装配出错！", ex);
            }
        }

        private void assemblyProgramControl_EndGXInvoke(object sender, ProGXGBModel e)
        {
            try
            {
                this.axWindowsMediaPlayer1.Visible = false;

                if (_isGxReturn)//如果为工序返工
                {
                    _asseDataControl.GongxuReturnUpdateGbGj(ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.BackReturn, 4), "工序返回上一工步");
                    _isGxReturn = false;

                    return;
                }

                //修改工序信息 工序完成 
                _asseDataControl.UpdateAssbGx(ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.finished, 1), ConvertHelper.ToInt32(EDAEnums.CheckResult.OK, 1), EDAEnums.CheckResultMemo.Qualified.ToString());
            }
            catch (Exception ex)
            {
                ShowErrorMessage("完成工序装配出错！", ex);
            }

        }

        private void assemblyProgramControl_GBBeginInvoke(object sender, ProGXGBModel e)
        {
            try
            {

                _gbParam = null;

                richTxtGjValue.Text = string.Empty;

                lblTime.Text = string.Empty;

                //如果为 例外转序 工序返回
                if (_isGbConvert)
                {
                    _isGbConvert = false;
                }
                if (_isGxReturn)
                {
                    _isGxReturn = false;
                }

                //显示当前工序工步列表所在行
                SelectDataGridViewStyle(_assProgControl.CurrentGBIndex);
                //显示工步
                ShowGbMsg(e.gbname, e.gbdesc);
                if (e.progGBID.HasValue)
                {
                    //图片显示
                    var image = _asseDataControl.GetGBImage(e.progGBID.Value);
                    ShowImage(image);
                    //添加工步信息 工步开始 
                    _asseDataControl.AddAssbGb(e.progGBID.Value, e.gbname, PublicVariable.CurEmpID, PublicVariable.CurEmpName);
                }

            }
            catch (Exception ex)
            {
                ShowErrorMessage("开始工步装配出错！", ex);
            }

        }

        private void assemblyProgramControl_GBEndInvoke(object sender, ProGXGBModel e)
        {
            try
            {
                if (_isGbConvert)
                {
                    _isGbConvert = false;
                }
                if (_isGxReturn)
                {
                    _isGxReturn = false;
                }

                lblTime.Text = string.Empty;

                ShowImage(null);

                if (_gbParam == null)
                {
                    _gbParam = new GbParam
                    {
                        Result = ConvertHelper.ToInt32(EDAEnums.CheckResult.OK, 1),//合格
                        ResultMemo = EDAEnums.CheckResultMemo.Qualified.ToString(),
                    };
                }
                //0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
                _gbParam.FinishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.finished, 1);

                //如果为 例外转序
                if (_isGbConvert)
                {
                    //0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
                    _gbParam.FinishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.Convers, 5);
                    _gbParam.Result = ConvertHelper.ToInt32(EDAEnums.CheckResult.NG, 0);//合格
                    _gbParam.ResultMemo = EDAEnums.CheckResultMemo.DisQualified.ToString();
                    _isGbConvert = false;
                }
                if (e.progGBID.HasValue)
                {
                    //修改工步信息 工步完成
                    _asseDataControl.UpdateAssbGb(0, _gbParam.FinishStatus, _gbParam.Result, _gbParam.ResultMemo, "", string.Empty);
                }

            }
            catch (Exception ex)
            {
                ShowErrorMessage("完成工步装配出错！", ex);
            }
        }

        private void assemblyProgramControl_GJWLBeginInvoke(object sender, ProGJValModel e)
        {

            if (e.GJOPCTypes.Where(f => f.Code == EDAEnums.GJWLOPCType.TorqueFormula).FirstOrDefault() != null)
            {
                InitTorque(e.TorqueLocalIP, e.TorqueLocalPort);

                _currToolTorque?.Connection();
            }

            //try
            //{
            _currTorque = null;
            _gjwlCode = string.Empty;
            richTxtGjValue.Text = string.Empty;
            _opcControl = null;

            //如果为 例外转序 工序返回
            if (_isGbConvert || _isGxReturn)
            {
                return;
            }

            //获取工具点位
            var gjGetTag = _opcFunc.GetGJWLOPCValue(e.GJOPCTypes, EDAEnums.GJWLOPCType.GJWLGet);
            var gjPutTag = _opcFunc.GetGJWLOPCValue(e.GJOPCTypes, EDAEnums.GJWLOPCType.GJWLPut);
            var message = _assProgControl.CurrentGXGBModel.gbname;

            //工具管控
            if (_assProgControl.ControlMode == ControlMode.GJ)
            {
                if (e.GJTypeCode != EDAEnums.GjTypeCodeEnum.camera.ToString())
                {
                    //显示图片
                    if (e.GJImg != null && e.GJImg.Length > 0)
                    {
                        ShowImage(e.GJImg);
                    }

                    if (!string.IsNullOrEmpty(gjPutTag))
                    {
                        if (!string.IsNullOrEmpty(gjGetTag))//如果Q点和I点都有设置,则
                        {
                            message += "\r\n请拿起" + e.GJName;
                        }
                        else
                        {
                            message += "\r\n请放回" + e.GJName;
                        }
                    }
                }
                //添加工具信息 开始
                _asseDataControl.AddAssbGjWl(true, e.GJID.Value, e.GJName, PublicVariable.CurEmpID, PublicVariable.CurEmpName);
            }
            else//物料管控
            {
                //显示图片
                if (e.WLImg != null && e.WLImg.Length > 0)
                {
                    ShowImage(e.WLImg);
                }
                //清理图号为0的部分
                if (e.WLName.EndsWith(" - 0"))
                {
                    e.WLName = e.WLName.Replace(" - 0", "");
                }
                if (!string.IsNullOrEmpty(gjPutTag))
                {
                    if (!string.IsNullOrEmpty(gjGetTag))//如果Q点和I点都有设置,则
                    {
                        message += "\r\n请拿起" + e.WLName;
                    }
                    else
                    {
                        message += "\r\n请放回" + e.WLName;
                    }
                }

                var wlQRCode = string.Empty;
                //物料确认 materialComfrom 标识扫描物料二维码进行验证 
                if (e.GJOPCTypes != null && e.GJOPCTypes.Where(f => f.Code == "materialConfrom" && !string.IsNullOrWhiteSpace(f.Value) && f.Value.Trim() == "1").Count() > 0)
                {
                    var input = new FrmScanInput("物料编号", $"请扫入物料【{e.WLName}】编码：", false);
                    input.ShowMessage("请扫入或输入物料编码");
                    input.EnterOnClick += (sen, val) =>
                    {
                        //分解条码
                        //var QRCode = val.Split(';');
                        //if (QRCode.Count() < 3)
                        //{
                        //    AddError(_asseDataControl.WuliaoErrorID, "扫入的二维码不符合规范，请检查！");
                        //    input.ShowMessage("扫入的二维码不符合规范，请检查！");
                        //    return;
                        //}
                        //var result = _asseDataControl.VerifyMaterialBarcode(QRCode[0], QRCode[1]);
                        //if (result != null)
                        //{
                        //    if (result.m_MaterialID != e.WLID)//对比物料ID是否相同
                        //    {
                        //        AddError(_asseDataControl.WuliaoErrorID, "扫入的二维码与所需物料不一致！");
                        //        input.ShowMessage("扫入的二维码与所需物料不一致！");
                        //        return;
                        //    }

                        //    //TODO:分装、总装 扫入物料添加至配置清单表中
                        //    var ProductInfoID = _asseDataControl.ProductInfoID;//总装 产品序列号ID
                        //    var cp_serialNumber = _asseDataControl.serialNumber;//总装 产品序列号
                        //    var partsNo = _asseDataControl.QR_Code;//分装 部件编号

                        //    wlQRCode = val; 
                        //    input.Close();
                        //}
                        //else
                        //{
                        //    //2020-05-18 添加物料使用有误 异常信息 
                        //    AddError(_asseDataControl.WuliaoErrorID, "扫入的二维码，未找到对应物料！");
                        //    input.ShowMessage("扫入的二维码，未找到对应物料！");
                        //}
                        wlQRCode = val;

                        //记录关键信息-物料编号
                        _asseDataControl.UpdateAssemblyMainRecord(_asseDataControl.AssemblyMainGuid.Value, AssemblyKeyType.MaterialCode.ToString(), e.WLName, wlQRCode);

                        input.Close();
                    };
                    input.ShowDialog(this);
                    input.Dispose();
                }

                //添加物料信息 开始
                _asseDataControl.AddAssbGjWl(false, e.WLID.Value, e.WLName, PublicVariable.CurEmpID, PublicVariable.CurEmpName, wlQRCode);

            }

            ShowGbMsg(message, _assProgControl.CurrentGXGBModel.gbdesc);


            //向OPC发送亮灯的写值命令
            if (!string.IsNullOrEmpty(gjPutTag))
            {
                //向工具点位发送绿灯的指令
                _opcFunc.OpcTagWriteValue(gjGetTag, 1, _opcTagValueCharge1);
                _opcControl = new OpcControl
                {
                    //记录I的点位
                    OPCTagName = gjPutTag,
                    //绿灯点位，以便复位
                    OPCTagRestName = gjGetTag,
                    //控制类型
                    ControlType = OPCControlType.GetPut
                };
                //等待opc点位响应
                _assProgControl.Wait();
            }

            //工业手柄
            if (e.GJTypeCode == EDAEnums.GjTypeCodeEnum.gongyeshoubing.ToString())
            {
                //扭力配方
                int processID = e.GJOPCTypes.Where(f => f.Code == EDAEnums.GJWLOPCType.TorqueFormula).FirstOrDefault().Value.ToInt();
                //标准值
                double StandardValue = e.StandardValue.ToDouble();
                string dw;
                if (processID < 10)
                {
                    dw = "Channel1.Device1.A" + processID.ToString().PadLeft(2, '0');
                }
                else
                {
                    dw = "Channel1.Device1.A" + processID;
                }

                _opcFunc.OpcTagWriteValue(dw, StandardValue, _opcTagValueCharge1);
                _opcFunc.OpcTagWriteValue("Channel1.Device1.VW01", processID, _opcTagValueCharge1);
                _assProgControl.Wait();
                btnSteup.Visible = true;
            }

            if (_asseDataControl.TorqueItems != null && _asseDataControl.TorqueItems.Count > 0 && e.GJTypeCode == EDAEnums.GjTypeCodeEnum.niulibanshou.ToString() || e.GJTypeCode == EDAEnums.GjTypeCodeEnum.wuxianbanshou.ToString())
            {

                decimal standardValue = 0;
                decimal maxValue = 0;
                decimal minValue = 0;
                decimal.TryParse(e.StandardValue, out standardValue);
                decimal.TryParse(e.MaxValue, out maxValue);
                decimal.TryParse(e.MinValue, out minValue);

                _currTorque = new TorqueParam
                {
                    Type = _asseDataControl.TorqueItems.Where(item => item.Key == e.GJName).FirstOrDefault().Value,
                    StandardValue = standardValue,
                    MaxValue = maxValue,
                    MinValue = minValue,
                };

                var processID = e.GJOPCTypes.Where(f => f.Code == EDAEnums.GJWLOPCType.TorqueFormula).FirstOrDefault().Value;

                int TPID = 0;
                if (!string.IsNullOrEmpty(processID) && int.TryParse(processID, out TPID))
                {
                    Thread.Sleep(500);//睡半秒等通讯连接完成 
                    //MessageBox.Show(processID);
                    _currToolTorque.StartTorque(processID);
                }
                else if (string.IsNullOrEmpty(processID))
                {
                    return;
                }
                else
                {
                    ShowGJMsg("扭力扳手程序配方ID不正确！", true, 1000);
                    _opcControl = new OpcControl
                    {
                        ControlType = OPCControlType.None
                    };
                    return;
                }
                _opcControl = new OpcControl
                {
                    ControlType = OPCControlType.Torque,
                };

                _assProgControl.Wait();

                //显示扭力扳手数据采集窗体
                _frmTorque = new FrmTorque(this, _currTorque.MaxValue, _currTorque.MinValue, SaveTorque);
                if (_currToolTorque.ConnectionIsOK)
                {
                    _frmTorque.ShowGJMsg("请使用扭力扳手");
                }
                else
                {
                    _frmTorque.ShowGJMsg("扳手连接失败，请联系管理员，或手动输入扭力值！");
                }
                _frmTorque.ShowDialog(this);

            }


        }



        private void assemblyProgramControl_GJWLEndInvoke(object sender, ProGJValModel e)
        {
            try
            {
                //关闭扭力扳手连接
                _currToolTorque?.CloseConnection();
                _currTorque = null;
                //如果显示图片 就关闭
                if (e.GJImg != null && e.GJImg.Length > 0)
                {
                    ShowImage(null);
                }

                //如果为 例外转序 工序返回
                if (_isGbConvert || _isGxReturn)
                {
                    return;
                }

                var curGjFinishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.finished, 1);//0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
                var curGjResult = ConvertHelper.ToInt32(EDAEnums.CheckResult.OK, 1);//合格
                var curGjResultMemo = EDAEnums.CheckResultMemo.Qualified.ToString();

                //如果为 例外转序
                if (_isGbConvert)
                {
                    curGjFinishStatus = ConvertHelper.ToInt32(EDAEnums.AssemblyStatus.Convers, 5);//0:未更换/未完成；1：已更换/已完成;2：停止下线，3：重新装配
                    curGjResult = ConvertHelper.ToInt32(EDAEnums.CheckResult.OK, 1);//合格
                    curGjResultMemo = EDAEnums.CheckResultMemo.Qualified.ToString();
                    //curGjResult = ConvertHelper.ToInt32(EDAEnums.CheckResult.NG, 0);//合格
                    //curGjResultMemo = EDAEnums.CheckResultMemo.DisQualified.ToString();
                }

                //var value = string.Empty;
                //var value2 = string.Empty;
                //var gjRemark = string.Empty;
                //byte[] ResultValue = null;
                //完成工具/物料信息
                _asseDataControl.UpdateAssbGjWl(curGjFinishStatus, curGjResult, curGjResultMemo);

                _currTorque = null;
                _gjwlCode = string.Empty;
                this.richTxtGjValue.Text = string.Empty;
                _opcControl = null;

            }
            catch (Exception ex)
            {
                ShowErrorMessage("完成工具物料装配出错！", ex);
            }
        }

        private void assemblyProgramControl_OtherBeginInvoke(object sender, ProGXGBModel e)
        {
            try
            {
                _opcControl = null;
                var value = _asseDataControl.ControlTypes.Where(f => f.ID == e.ControlTypeID).FirstOrDefault();


                //时间管控 显示延迟时间
                if (value != null && value.bdcode == EDAEnums.ControlType.SJGK.ToString())
                {
                    DelayTime(e.GBDelayTime ?? 0);
                }

                //手动管控
                if (value != null && value.bdcode == EDAEnums.ControlType.SDGK.ToString())
                {
                    this.btnSteup.Visible = true;
                    //this._assProgControl.Wait();
                }
                else
                {
                    this.btnSteup.Visible = false;
                }
                //产品录入
                if ((e.IsInputPInfo ?? 0) == 1)
                {

                }
                //扫码管控 else if (value != null && value.bdcode == EDAEnums.ControlType.SMGK.ToString()) 分装
                else if ((e.IsScan ?? 0) == 1)
                {
                    //2020-11-24 目前先关闭 总装的分装 部件编号扫码功能
                    var input = new FrmScanInput("分装部件编号输入", "请输入分装部件编号：", false);
                    input.ShowMessage("请扫入或输入分装部件编号，将用于与总装信息关联");
                    input.EnterOnClick += (sen, val) =>
                    {
                        if (!string.IsNullOrEmpty(val.Trim()))
                        {
                            ////如果分装
                            //if (!string.IsNullOrEmpty(val.Trim()))
                            //{
                            //    _asseDataControl.QR_Code = val.Trim();
                            //}
                            //根据分装部件编号 获取装配工位明细信息
                            var AssemblyGw = _asseDataControl.GetAssemblyGwByQRcode(val.Trim());
                            if (AssemblyGw == null)
                            {
                                RWMessageBox.ShowExclamation($"没有找到分装部件编号：【{val}】的生产记录,请确认编号是否正确！");
                                input.clearTxt();
                                return;
                            }
                            if (PublicVariable.GWModel.isFinishGW == 1)
                            {
                                //★分装部件编号_关联_产品编号
                                _asseDataControl.AssociatedQRcodeOrProdNo(val.Trim());
                            }
                            //关联分装装配关键信息
                            var model = _asseDataControl.GetAssemblyMainDetail(val);
                            if (model == null)
                            {
                                RWMessageBox.ShowExclamation($"没有找到分装部件编号：【{val}】的生产记录,请确认编号是否正确！");
                                input.clearTxt();
                                return;
                            }
                            if (PublicVariable.GWModel.isFinishGW == 1 && PublicVariable.StaticTestTime > 0)
                            {
                                var time = _asseDataControl.GetDateTime() - model.am_createDate;
                                if (time.TotalHours < PublicVariable.StaticTestTime)
                                {
                                    var mbox = MessageBox.Show($"当前部件静制时间为：【{Math.Round(time.TotalHours, 2)}】 小时，未达到【{PublicVariable.StaticTestTime}】小时,是否继续？", "静制时间", MessageBoxButtons.YesNo);
                                    if (mbox == DialogResult.No)
                                    {
                                        input.clearTxt();
                                        return;
                                    }
                                }
                            }
                            //关联分装装配关键信息
                            _asseDataControl.UpdateAssemblyMain(val, model.am_gwID, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), PublicVariable.CurEmpName, model.am_guid, _asseDataControl.ProductInfoID, PublicVariable.GWModel.isFinishGW == 1);

                            input.Close();
                        }
                    };
                    input.ShowDialog(this);
                    input.Dispose();
                }
                //人工确认
                else if ((e.IsEmpCheck ?? 0) == 1)
                {
                    _assProgControl.Wait();
                }
                //扫产品订单号,保存在工位组装表的remark字段
                else if ((e.IsScanOrderNo ?? 0) == 1)
                {

                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("开始其他装配出错！", ex);
            }
        }

        private void assemblyProgramControl_OtherEndInvoke(object sender, ProGXGBModel e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                ShowErrorMessage("完成其他装配出错！", ex);
            }
        }

        //完成状态控制
        private void FinishStatus()
        {
            //退出工艺程序流程
            if (_assProgControl != null)
            {
                _assProgControl.Init();
                _assProgControl.Stop();
            }

            EnableSetupControl(false);
            Clear();
            //亮黄灯
            GreenLight();

            this.btnSteup.Visible = false;
        }

        //dataGridView 选择样式
        private void SelectDataGridViewStyle(int stepIndex)
        {
            dataGridView1.Refresh();
            dataGridView1.Rows[stepIndex].ReadOnly = true;
            //标识已完成的工序
            //dataGridView1.Rows[stepIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            dataGridView1.Rows[stepIndex].Cells["NumNo"].Style.BackColor = Color.LightGray;
            dataGridView1.Rows[stepIndex].Cells["gbname"].Style.BackColor = Color.LightGray;
            if (stepIndex > 0)
            {
                for (int index = 0; index < dataGridView1.Rows.Count; index++)
                {
                    if ((string)dataGridView1.Rows[index].Cells[0].Tag != "beijing")
                    {
                        dataGridView1.Rows[index].Cells[0].Value = Properties.Resources.beijing;
                        dataGridView1.Rows[index].Cells[0].Tag = "beijing";
                        //还原字体大小
                        dataGridView1.Rows[index].Cells["NumNo"].Style.Font = new Font("微软雅黑", 12, FontStyle.Regular);
                        dataGridView1.Rows[index].Cells["gbname"].Style.Font = new Font("微软雅黑", 12, FontStyle.Regular);
                    }
                    dataGridView1.Rows[index].Selected = false;
                }
            }
            dataGridView1.Rows[stepIndex].Cells[0].Value = Properties.Resources.trafficlight_green;
            dataGridView1.Rows[stepIndex].Cells[0].Tag = "trafficlight_green";
            dataGridView1.Rows[stepIndex].Selected = true;
            //加粗字体大小 
            dataGridView1.Rows[stepIndex].Cells["NumNo"].Style.Font = new Font("微软雅黑", 15, FontStyle.Bold);
            dataGridView1.Rows[stepIndex].Cells["gbname"].Style.Font = new Font("微软雅黑", 15, FontStyle.Bold);

            //滚动条动态滚动
            if (dataGridView1.SelectedRows[0].Index > 3)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.SelectedRows[0].Index - 3;
            }
        }

        //去掉 dataGridView 选择样式
        private void SelectDataGridViewStyleClear(string BtnType)
        {
            if (BtnType.Equals("gongxufangong"))
            {
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
                dataGridView1.RowsDefaultCellStyle.BackColor = Color.White;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.SelectedRows[0].Cells["NumNo"].Style.Font = new Font("微软雅黑", 12, FontStyle.Regular);
                dataGridView1.SelectedRows[0].Cells["gbname"].Style.Font = new Font("微软雅黑", 12, FontStyle.Regular);
                dataGridView1.SelectedRows[0].Cells[0].Tag = "beijing";
                dataGridView1.SelectedRows[0].Cells[0].Value = Properties.Resources.beijing;
                dataGridView1.SelectedRows[0].Selected = false;
            }
        }

        //显示工步的提示
        private void ShowGbMsg(string gbName = "", string gbDesc = "")
        {
            richTxtGbName.Text = "工步详细:\r\n" + gbName;
            if (string.IsNullOrEmpty(gbDesc))
            {
                txt_gbDesc.Text = gbName;
            }
            else
            {
                txt_gbDesc.Text = gbDesc.Replace("\\r\\n", System.Environment.NewLine);
            }
        }

        //显示工具的提示信息
        private void ShowGJMsg(string msg, bool isRed = false, int sleepTime = 0)
        {
            ActionInvoke(new MethodInvoker(delegate ()
            {
                richTxtGjValue.Text = msg;
                if (isRed)
                {
                    richTxtGjValue.ForeColor = Color.Red;
                }
                else
                {
                    richTxtGjValue.ForeColor = Color.Blue;
                }
                if (sleepTime > 0)
                {
                    Thread.Sleep(sleepTime);
                }
            }));
        }

        //显示倒计时信息
        private void DelayTime(int sec)
        {
            if (sec == 0)
            {
                return;
            }

            Task.Run(() =>
            {
                while (true)
                {
                    if (sec == 0)
                    {
                        return;
                    }
                    if (_isGbConvert || _isGxReturn)
                    {
                        return;
                    }
                    var time = new DateTime();
                    time = time.AddSeconds(sec);

                    ActionInvoke(new MethodInvoker(delegate ()
                    {
                        lblTime.Text = time.ToString("mm:ss");
                    }));

                    sec -= 1;

                    Thread.Sleep(1000);
                }

            });

        }

        #region 工序/工步跳转

        //异常下线 
        private void toolbtnError_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("异常下线后不能恢复！确定要异常下线吗？", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    //MessageBox.Show("请将异常产品搬离输送线，空托盘放置下层回收线！");
                    MessageBox.Show("请将异常产品搬离工作台！");

                    //异常下线处理 
                    //_asseDataControl.ProdErrorOffLine(SysConfig.CurGwID, SysConfig.CurGwName, PublicVariable.CurEmpID, PublicVariable.CurEmpName);

                    //保存异常下线信息
                    addOffLineInfo();

                    //完成状态
                    FinishStatus();
                    //点位还原
                    ClearOPCtags();
                    //清除产品序列号
                    ShowProdNo(string.Empty);
                    //清除工序名称显示
                    ShowGxuName(string.Empty);

                    //亮黄灯
                    //GreenLight();

                    richTxtGbName.Text = "异常下线\r\n";

                }
                catch (Exception ex)
                {
                    Logger.Default.Error("异常下线失败！", ex);
                    ShowErrorMessage("异常下线失败！" + ex.Message);
                }
            }
        }

        private void addOffLineInfo()
        {
            AbnormalOfflineModel abnormal = new AbnormalOfflineModel();
            abnormal.prodCode = _asseDataControl.QR_Code;
            abnormal.agw_guid = _asseDataControl.CurAssbmGwGuid;
            abnormal.agx_guid = _asseDataControl.CurAssbmGxGuid;
            abnormal.agb_guid = _asseDataControl.CurAssbmGbGuid;
            abnormal.CurrentGXIndex = _assProgControl.CurrentGXIndex;
            abnormal.CurrentGBIndex = _assProgControl.CurrentGBIndex;
            abnormal.CurrentGJWLIndex = _assProgControl.CurrentGJWLIndex;
            abnormal.operID = PublicVariable.CurEmpID;
            abnormal.offlineState = 0;
            abnormal.saveTime = DateTime.Now;

            _asseDataControl.AddOfflineInfo(abnormal);
        }

        //手动管控 
        private void toolbtnNext_Click(object sender, EventArgs e)
        {
            JumpNext();
        }

        private DateTime _dtConvert = DateTime.Now;
        //例外转序
        private void toolbtnConvert_Click(object sender, EventArgs e)
        {

            try
            {
                if ((DateTime.Now - _dtConvert).TotalMilliseconds < 500)
                {
                    return;
                }

                _isGbConvert = true;

                JumpNext();

                ClearCurrentJGWLOPC();

            }
            catch (Exception ex)
            {
                Logger.Default.Error("例外转序出错！", ex);
                MessageBox.Show("例外转序出错！" + ex.Message);
            }

            _dtConvert = DateTime.Now;

        }
        private DateTime _dtReturn = DateTime.Now;
        //工序返工
        private void toolbtnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                //触发间隔小于500毫秒
                if ((DateTime.Now - _dtReturn).TotalMilliseconds < 500)
                    return;

                if (_assProgControl.CurrentGBIndex == 0)
                {
                    MessageBox.Show("已经是第一道工序，不能返回！！");
                    toolbtnReturn.Enabled = true;
                    return;
                }

                _isGxReturn = true;

                _assProgControl.GXBack();

                //去掉 dataGridView 选择样式 
                SelectDataGridViewStyleClear("gongxufangong");

                ShowVideo(string.Empty);

                ClearCurrentJGWLOPC();
            }
            catch (Exception ex)
            {
                Logger.Default.Error("例外转序出错！", ex);
                MessageBox.Show("工序返回出错！" + ex.Message);
            }

            _dtReturn = DateTime.Now;

        }

        private void ClearCurrentJGWLOPC()
        {
            //恢复当前工步点位
            var opcTags = _assProgControl.CurrentGJWLModels.
                Where(f => f.ProgGXID == _assProgControl.CurrentGXGBModel.progGXID).
                SelectMany(f => f.GJOPCTypes).Where(f => !string.IsNullOrEmpty(f.OPCDeviceName) && !string.IsNullOrEmpty(f.Value) && f.Value.StartsWith("Q"));
            if (opcTags.Count() > 0)
            {
                //Task.Run(() =>
                //{ 
                foreach (var tag in opcTags)
                {
                    if (_opcFunc.OpcTagReadValue(tag.OPCDeviceName + tag.Value, _opcTagValueCharge1))
                    {
                        _opcFunc.OpcTagWriteValue(tag.OPCDeviceName + tag.Value, false, _opcTagValueCharge1);
                    }
                }
                //});
            }
        }

        //手动管控 跳转到下一步
        private void btnSteup_Click(object sender, EventArgs e)
        {
            this.btnSteup.Visible = false;
            JumpNext();
        }

        //跳转到下一步 
        private void btnGjWlSubmit_Click(object sender, EventArgs e)
        {
            JumpNext();
        }

        //设置工步跳转
        private void btnStepTest_Click(object sender, EventArgs e)
        {
            int index = 0;
            //if (int.TryParse(txtSetupNum.Text.Trim(), out index) && index >= 0)
            //{
            //    if (_assProgControl.GXGBModels.Count > index)
            //    {
            //        SelectDataGridViewStyleClear(string.Empty);

            //        if (_assProgControl.CurrentGXGBModel.progGXID != _assProgControl.GXGBModels[index].progGXID)
            //        {
            //            ShowVideo(string.Empty);
            //        }
            //        _assProgControl.Skip(index);
            //    }
            //}
        }

        //跳转到下一步
        private void JumpNext()
        {
            _assProgControl.Set();
            if (_assProgControl.GXGBModels.Count > _assProgControl.CurrentGBIndex + 1)
            {
                SelectDataGridViewStyleClear(string.Empty);

                if (_assProgControl.CurrentGXGBModel.progGXID != _assProgControl.GXGBModels[_assProgControl.CurrentGBIndex + 1].progGXID)
                {
                    ShowVideo(string.Empty);
                }
                _assProgControl.Skip(_assProgControl.CurrentGBIndex + 1);
            }
        }

        #endregion 工序/工步跳转

        #endregion 程序装配管理控制

        #region 权限管理
        //设置用户工位权限
        private void SetEmpGongweiRight()
        {
            //var rightModels = DIService.GetService<IBLL_BaseInfo>().GetBaseGongweiRightModelByEmpID(SysConfig.CurEmpID, SysConfig.CurGwID);
            ////没有使用作业指导的权限
            //if (rightModels == null ||
            //    rightModels.Count == 0 ||
            //    !rightModels.Exists(f => f.RightTypeCode == "Gw_ZYZD"))
            //{
            //    MessageBox.Show("您没有使用当前功能的权限！");
            //    Application.Exit();
            //    return;
            //}
            //toolbtnConvert.Visible = false;
            //if (rightModels.Exists(f => f.RightTypeCode == "Gw_LWZX"))
            //{
            //    toolbtnConvert.Visible = true;
            //}
            //toolbtnError.Visible = false;
            //if (rightModels.Exists(f => f.RightTypeCode == "Gw_YCXX"))
            //{
            //    toolbtnError.Visible = true;
            //}
            //toolbtnUnbind.Visible = false;
            //if (rightModels.Exists(f => f.RightTypeCode == "Gw_TPJB"))
            //{
            //    toolbtnUnbind.Visible = true;
            //}
            //toolbtnUpdateBarCode.Visible = false;
            //if (rightModels.Exists(f => f.RightTypeCode == "Gw_ZYZD"))
            //{
            //    toolbtnUpdateBarCode.Visible = true;
            //}
        }

        #endregion

        #region 启动装配

        //自动启动
        private void AutoRunSetup()
        {
            try
            {
                lock (_objLock)
                {
                    //如果已经启动不能再次运行
                    if (!toolbtnStart.Enabled)
                    {
                        return;
                    }
                    if (SysConfig.IsAutoRunSetup)
                    {
                        RunSetup(true);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Default.Error("装配管理出错！", ex);
                ShowErrorMessage("装配管理出错！" + ex.Message);
            }
        }

        /// <summary>
        /// 工艺文件 绘制序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[1].Value = row.Index + 1;
            }
        }

        private void RunSetup(bool isAuto = false)
        {
            int isStartAssembly = 0;//是否启动装配
            var prodID = 0;//总装产品信息ID
            var QR_Code = string.Empty;//用于获取分装部件编号，存放至assembly_gw
            var SerialNumber = string.Empty;//用于质检模块 总装产品系列号

            if (!isAuto)
            {
                if (cmbProdModel.SelectedValue == null || ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0) == 0)
                {
                    RWMessageBox.ShowExclamation("请选择产品型号");
                    toolbtnStart.Enabled = true;
                    return;
                }

                if (ConvertHelper.ToInt32(cmbProgram.SelectedValue, 0) == 0)
                {
                    RWMessageBox.ShowExclamation("请选择工艺程序");
                    toolbtnStart.Enabled = true;
                    return;
                }
            }

            //如果为总装工位
            //if (PublicVariable.GWModel.isFinishGW == 1)
            //{
            //    //如果为总装第一个工位，需要创建productinfo 并绑定计划
            //    if (PublicVariable.GWModel.gwOrder == 1)
            //    {

            //        //计划列表绑定弹窗
            //        using (var frmpp = new FromPlanInput())
            //        {
            //            //根据条码获取产品型号信息
            //            frmpp.CommitBtn = new Func<string,string>((val) =>
            //            {
            //                var errMsg = GetProdModel(val); return errMsg;
            //            });

            //            if (frmpp.ShowDialog(this) == DialogResult.Cancel)
            //            {
            //                ShowProdNo(string.Empty);//清除产品序列号
            //                isStartAssembly = 0;//关闭装配标识
            //                return;
            //            }

            //            string vals = frmpp.ReturnValue1;//返回的产品序列号
            //            string pp_orderCode = frmpp.ReturnValue2;//返回绑定的计划订单号
            //            string wagonNo = frmpp.wagonNo;//台车号
            //            ShowProdNo(vals);//绑定显示产品序列号
            //            SerialNumber = vals.Trim(); //总装 产品系列号

            //            string msgStr = $"是否将当前产品序列号：{vals} 绑定至计划单据号：{pp_orderCode} 上！";

            //            if (frmpp.ReturnValue3 == 2)
            //            {
            //                msgStr = $"当前产品序列号：{vals}，已在该工位装配过；是否继续装配！";
            //                //如果发现重新装配，提醒并将之前装配记录改为 重新装配状态 2020-11-14
            //                _asseDataControl.UpdateGWXBJSatus(true, vals, 3);
            //                wagonNo = string.Empty;
            //            }
            //            if (MessageBox.Show(msgStr, "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
            //            {
            //                ShowProdNo(string.Empty);//清除产品序列号
            //                isStartAssembly = 0;//关闭装配标识
            //                return;
            //            }

            //            //添加产品编号并与计划关联
            //            int Result = _asseDataControl.AddProductInfo(vals, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), pp_orderCode, 0, PublicVariable.CurGwID, wagonNo);
            //            //只有第一条产品信息 判断装配计划是否开始 。如果是修改计划状态 并且填写实际开始时间
            //            _asseDataControl.UpdatePartPlan(pp_orderCode, PublicVariable.CurEmpID, 2);
            //            if (Result == -1)
            //            {
            //                // -1：表示该产品型号绑定了另外的计划订单号上 ,返回错误码
            //                RWMessageBox.ShowExclamation("该产品序列号已绑定了 另外的计划单据号！！！");
            //                ShowProdNo(string.Empty); //清除产品产品序列号
            //                isStartAssembly = 0;//关闭装配标识
            //                return;
            //            }
            //            prodID = _asseDataControl.GetProductInfo(vals).pf_ID;

            //            isStartAssembly = 1;//开启装配标识
            //            frmpp.Dispose();
            //        }

            //    }
            //    else if (PublicVariable.GWModel.gwOrder == PublicVariable.GWMaxSort) //判断是否为最后的总装工位
            //    {
            //        var input = new FrmScanInput("产品序列号输入", "请输入产品序列号：", false, true);
            //        //input.ShowMessage("请扫入或输入产品序列号");
            //        input.EnterOnClick += (sen, val) =>
            //        {
            //            if (!string.IsNullOrEmpty(val.Trim()))
            //            {
            //                //根据条码获取产品型号信息
            //                var errMsg = GetProdModel(val);
            //                if (!string.IsNullOrEmpty(errMsg))
            //                {
            //                    input.ShowMessage(errMsg);
            //                    return;
            //                }
            //                //获取生产记录
            //                var prodInfo = _asseDataControl.GetProductInfo(val);
            //                if (prodInfo == null)
            //                {
            //                    RWMessageBox.ShowExclamation($"没有找到产品序列号：{val} 生产记录,请确认扫码是否正确!");
            //                    input.clearTxt();
            //                    return;
            //                }
            //                ShowProdNo(val);//绑定显示产品序列号
            //                SerialNumber = val.Trim(); //总装 产品系列号
            //                //添加产品编号并与计划关联,将当前产品编号改为已完成
            //                _asseDataControl.AddProductInfo(prodInfo.pf_prodNo, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), prodInfo.pp_orderCode, 1, PublicVariable.CurGwID, string.Empty);
            //                //判断装配产品信息数量是否等同于计划数量。如果是修改计划完成状态 并且填写实际结束时间
            //                _asseDataControl.UpdatePartPlan(prodInfo.pp_orderCode, PublicVariable.CurEmpID, 3);
            //                prodID = prodInfo.pf_ID;

            //                isStartAssembly = 1;//开启装配标识
            //                input.Close();
            //            }
            //        };
            //        input.ShowDialog(this);
            //        input.Dispose();
            //    }
            //    else //总装其他工位
            //    {
            //        var input = new FrmScanInput("产品序列号输入", "请输入产品序列号：", false, true);
            //        //input.ShowMessage("请扫入或输入产品序列号");
            //        input.EnterOnClick += (sen, val) =>
            //        {
            //            if (!string.IsNullOrEmpty(val.Trim()))
            //            {
            //                //根据条码获取产品型号信息
            //                var errMsg = GetProdModel(val);
            //                if (!string.IsNullOrEmpty(errMsg))
            //                {
            //                    input.ShowMessage(errMsg);
            //                    return;
            //                }
            //                //获取生产记录
            //                var prodInfo = _asseDataControl.GetProductInfo(val);
            //                if (prodInfo == null)
            //                {
            //                    RWMessageBox.ShowExclamation($"没有找到产品序列号：{val} 的生产记录，请确认扫码是否正确！！！");
            //                    input.clearTxt();
            //                    return;
            //                }
            //                ShowProdNo(val); //绑定显示产品序列号
            //                SerialNumber = val.Trim(); //总装 产品系列号

            //                //添加产品编号并与计划关联,将当前产品编号改为已完成
            //                _asseDataControl.AddProductInfo(prodInfo.pf_prodNo, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), prodInfo.pp_orderCode, 0, PublicVariable.CurGwID, string.Empty);
            //                prodID = prodInfo.pf_ID;

            //                isStartAssembly = 1;//开启装配标识
            //                input.Close();
            //            }
            //        };
            //        input.ShowDialog(this);
            //        input.Dispose();
            //    }

            //    if (isStartAssembly == 1)
            //    {
            //        var model = _asseDataControl.GetAssemblyMainDetail(this.lblProdNo.Text, gwID: PublicVariable.CurGwID);
            //        //添加关键信息主表
            //        _asseDataControl.AssemblyMainGuid = _asseDataControl.UpdateAssemblyMain(this.lblProdNo.Text, PublicVariable.CurGwID, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), PublicVariable.CurEmpName, model?.am_guid, prodID);
            //    }
            //}
            ////分装工位
            //else
            //{
            //    //查询参数设置中是否配置启用分装扫码功能
            //    if (ConvertHelper.ToInt32(PublicVariable.GetSysConfig("IsSplitChargingByCode"), 0) != 0)
            //    {
            //        var input = new FrmScanInput("产品编号输入", "请输入产品编号：", false, true);
            //        //input.ShowMessage("请扫入或输入分装部件编号");
            //        input.EnterOnClick += (sen, val) =>
            //        {
            //            if (string.IsNullOrEmpty(val.Trim()))
            //            {
            //                input.ShowMessage("提示：产品编号 不能为空！！！");
            //                return;
            //            }
            //            //根据条码获取产品型号信息 
            //            var errMsg = GetProdModel(val, true);
            //            if (!string.IsNullOrEmpty(errMsg))
            //            {
            //                input.ShowMessage(errMsg);
            //                return;
            //            }
            //            ShowProdNo(val);//绑定显示部件编号
            //            QR_Code = val.Trim(); //分装部件编号 

            //            var model=_asseDataControl.GetAssemblyMainDetail(QR_Code);
            //            if (model != null)
            //            {
            //               var ret = MessageBox.Show(this, "当前产品编号已使用，是否继续装配！", "编号已使用",MessageBoxButtons.YesNo);
            //                if (ret == DialogResult.No)
            //                {
            //                    return;
            //                }
            //            }

            //            //添加关键信息主表
            //            _asseDataControl.AssemblyMainGuid = _asseDataControl.UpdateAssemblyMain(QR_Code, PublicVariable.CurGwID, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), PublicVariable.CurEmpName, model?.am_guid);

            //            isStartAssembly = 1;//开启装配标识
            //            input.Close();
            //        };
            //        input.ShowDialog(this);
            //        input.Dispose();
            //    }
            //    else
            //    {
            //        isStartAssembly = 1;//开启装配标识
            //    }
            //}

            //查询参数设置中是否配置启用分装扫码功能
            if (ConvertHelper.ToInt32(PublicVariable.GetSysConfig("IsSplitChargingByCode"), 0) != 0)
            {
                var input = new FrmScanInput("产品编号输入", "请输入产品编号：", false, true);
                //input.ShowMessage("请扫入或输入分装部件编号");
                input.EnterOnClick += (sen, val) =>
                {
                    if (string.IsNullOrEmpty(val.Trim()))
                    {
                        input.ShowMessage("提示：产品编号 不能为空！！！");
                        return;
                    }
                    //根据条码获取产品型号信息
                    //var errMsg = GetProdModel(val, true);
                    //if (!string.IsNullOrEmpty(errMsg))
                    //{
                    //    input.ShowMessage(errMsg);
                    //    return;
                    //}
                    ShowProdNo(val);//绑定显示部件编号
                    QR_Code = val.Trim(); //分装部件编号

                    var model = _asseDataControl.GetAssemblyMainDetail(QR_Code);

                    //if (model != null)
                    //{
                    //    var ret = MessageBox.Show(this, "当前产品编号已使用，是否继续装配！", "编号已使用", MessageBoxButtons.YesNo);
                    //    if (ret == DialogResult.No)
                    //    {
                    //        return;
                    //    }
                    //}

                    //添加关键信息主表 
                    _asseDataControl.AssemblyMainGuid = _asseDataControl.UpdateAssemblyMain(QR_Code, PublicVariable.CurGwID, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), PublicVariable.CurEmpName, model?.am_guid);

                    //添加产品编号并与计划关联 
                    _asseDataControl.ProductInfoID = _asseDataControl.AddProductInfo(QR_Code, ConvertHelper.ToInt32(cmbProdModel.SelectedValue, 0), "", 0, PublicVariable.CurGwID, string.Empty);

                    isStartAssembly = 1;//开启装配标识
                    input.Close();
                };

                input.ShowDialog(this);
                input.Dispose();
            }
            else
            {
                isStartAssembly = 1;//开启装配标识
            }

            //是否启动装配
            if (isStartAssembly != 1)
                return;

            toolbtnStart.Enabled = false;//启动装配禁用
            _asseDataControl.Init();//初始化装配参数，开始启动装配
                                    //赋值总装产品序列号

            //赋值分装部件编号
            if (!string.IsNullOrEmpty(QR_Code.Trim()))
                _asseDataControl.QR_Code = QR_Code;
            //赋值总装 产品系列号 
            if (!string.IsNullOrEmpty(SerialNumber))
                _asseDataControl.serialNumber = SerialNumber;

            AssemblyProgControl(ConvertHelper.ToInt32(cmbProgram.SelectedValue, 0));//传入工艺文件ID

            //if (_opcTagValueCharge1.dtallTags.Count > 0)
            //{
            //    var drsGJWlTags = _opcTagValueCharge1.dtallTags.Where(f => f.OPCTypeCode == "gjwlPut");

            //    _arrayGJWlTags = drsGJWlTags.Select(x => x.Value).ToArray();
            //}
        }

        /// <summary>
        /// 通过图号选择产品型号
        /// </summary>
        /// <param name="drawingNo">图号</param>
        /// <returns></returns>
        private string GetProdModel(string barcode, bool isSplit = false)
        {
            var codes = barcode.Split(',');
            if (codes.Length != 4)
            {
                return "条码格式不正确！";
            }
            if (isSplit && codes[3].ToUpper().Trim() != "F")
            {
                return "编码格式不正确，分装工位编码以'F'结尾!";
            }

            if (!isSplit && codes[3].ToUpper().Trim() == "F")
            {
                return "编码格式不正确，非产品编码或总装编码!";
            }
            string pmodelNo = codes[2];
            var source = cmbProdModel.DataSource as List<KeyValuePair<int, string>>;
            if (_productModels == null || source == null)
            {
                return $"没有找到产品型号信息!";
            }
            var model = _productModels.Where(f => f.PmodelNo.ToUpper() == pmodelNo.ToUpper()).FirstOrDefault();
            if (model == null)
            {
                return $"没有找到图号为{pmodelNo}的产品型号!";
            }
            var selectItem = source.FirstOrDefault(f => f.Key == model.ID);
            if (string.IsNullOrEmpty(selectItem.Value))
            {
                return $"没有找到图号为{pmodelNo}的产品型号装配工艺!";
            }
            cmbProdModel.SelectedValue = selectItem.Key;

            return string.Empty;
        }

        /// <summary>
        /// 故障上报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmFollowFeedReport f = new FrmFollowFeedReport();
            f.ShowDialog(this);
            f.Dispose();
        }

        /// <summary>
        /// 绘制 合并系统行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                // 对第1列相同单元格进行合并
                if (e.ColumnIndex > 0 && e.RowIndex != -1)
                {
                    if (dataGridView1.Columns[e.ColumnIndex].Name == "gxname")
                    {
                        using (Brush gridBrush = new SolidBrush(this.dataGridView1.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                        {
                            using (Pen gridLinePen = new Pen(gridBrush))
                            {
                                // 清除单元格
                                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                                // 画 Grid 边线（仅画单元格的底边线和右边线）

                                // 如果下一行和当前行的数据不同，则在当前的单元格画一条底边线
                                if (e.RowIndex < dataGridView1.Rows.Count - 1 && dataGridView1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

                                // 画右边线
                                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                                // 最底边线
                                if (e.RowIndex == dataGridView1.Rows.Count - 1)
                                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

                                // 画（填写）单元格内容，相同的内容的单元格只填写第一个
                                if (e.Value != null)
                                {
                                    if (!(e.RowIndex > 0 && dataGridView1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString()))
                                        e.Graphics.DrawString((String)e.Value, e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                    //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
                                    //e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                    //e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                                    //e.Graphics.DrawString((String)e.Value, e.CellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular),
                                    //  Brushes.Black, e.CellBounds.X + 2,
                                    //  e.CellBounds.Y + 5, StringFormat.GenericDefault);
                                }
                                e.Handled = true;
                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 显示产品序列号 或者 部件编号
        /// </summary>
        /// <param name="prodNo">总装：产品序列号  分装：部件编号</param>
        private void ShowProdNo(string prodNo)
        {
            //if (PublicVariable.GWModel.isFinishGW == 1)
            //    this.lblTitleProdNo.Text = "产品序列号：";
            //else
            //    this.lblTitleProdNo.Text = "部件编号：";

            if (string.IsNullOrEmpty(prodNo.Trim()))
            {
                this.lblTitleProdNo.Visible = false;
                this.lblProdNo.Visible = false;
            }
            else
            {
                this.lblTitleProdNo.Visible = true;
                this.lblProdNo.Visible = true;
            }
            this.lblProdNo.Text = prodNo;
          
        }

        /// <summary>
        /// 显示工序名称信息
        /// </summary>
        /// <param name="gxnName"></param>
        private void ShowGxuName(string gxnName)
        {
            if (string.IsNullOrEmpty(gxnName.Trim()))
            {
                this.lblGxu.Visible = false;
                this.lblGxuName.Visible = false;
            }
            else
            {
                this.lblGxu.Visible = true;
                this.lblGxuName.Visible = true;
            }
            this.lblGxuName.Text = gxnName;
        }

        #endregion

        #region 扭力扳手

        //初始化扭力扳手 
        private void InitTorque(string ip, string prot)
        {
            TorqueNum = 0;
            //var strLocalIP = ConfigurationManager.AppSettings["TorqueLocalIP"];
            //var strLocalPort = ConfigurationManager.AppSettings["TorqueLocalPort"];
            if (!string.IsNullOrEmpty(ip))
            {
                _currToolTorque = _torqueFactory.Create("Ingersoll");
                _currToolTorque.TorqueIP = ip;
                _currToolTorque.Port = ConvertHelper.ToInt32(prot, 4545);
                _currToolTorque.DataReceived += torque_DataReceived;
            }

        }

        private void timerClearAlarmSound_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_opcFunc.OpcTagReadValue(_opcFunc.CurGwRedOPC, _opcTagValueCharge1))
                {
                    _opcFunc.OpcTagWriteValue(_opcFunc.CurGwRedOPC, false, this._opcTagValueCharge1);
                }
            }
            catch (Exception ex)
            {
                Logger.Default.Error("监控报警声音是否启动出错！", ex);
            }
        }

        //获取扭力数据
        void torque_DataReceived(object sender, TorqueData e)
        {
            try
            {

                if (_assProgControl.CurrentGJWLModel.GJTypeCode != EDAEnums.GjTypeCodeEnum.wuxianbanshou.ToString() && _assProgControl.CurrentGJWLModel.GJTypeCode != EDAEnums.GjTypeCodeEnum.niulibanshou.ToString())
                {
                    return;
                }

                if (_currTorque != null)
                {
                    _currTorque.Value = e.Torque;
                    //_currTorque.Angle = e.Angle;
                    if (sender.GetType() == typeof(Torque_Ingersoll))
                    {
                        //设置扭力数据 , _currTorque.Angle
                        _frmTorque.SetTorque(_currTorque.Value);

                        GetTorqueVal();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowGJMsg(ex.Message, true);
                Logger.Default.Error("torque_DataReceived", ex);
            }
        }

        private void GetTorqueVal()
        {
            if (_currTorque != null)
            {
                try
                {
                    //设置扭力数据 , _currTorque.Angle
                    _frmTorque.SetTorque(_currTorque.Value);
                    _frmTorque.OKClick();
                }
                catch (Exception ex)
                {
                    Logger.Default.Error("GetTorqueVal :" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 保存扭力数据
        /// </summary>
        private void SaveTorque()
        {
            TorqueNum++;

            //记录关键信息-扭力值
            _asseDataControl.UpdateAssemblyMainRecord(_asseDataControl.AssemblyMainGuid.Value, AssemblyKeyType.Device.ToString(), "扭力值", _frmTorque.Torque.ToString(), " N.m.");

            _frmTorque.Dispose();

            _opcControl.ControlType = OPCControlType.None;

            _assProgControl.Set();

            _currTorque = null;

        }

        #endregion 扭力扳手

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var input = new FrmScanInput("配料单号输入", "请输入配料单号：", false, true);

            BatchingRecordModel model = null;

            input.EnterOnClick += (sen, val) =>
            {
                if (val.Trim() != "")
                {
                    model = _asseDataControl.GetBatchingRecord(new BatchingRecordModel() { BatchCode = val.Trim() });

                    if (model == null)
                    {
                        MessageBox.Show("未查询到相关配送单信息。");
                    }
                    else
                    {
                        input.Close();
                    }
                }

            };

            input.ShowDialog();
            input.Dispose();

            if (model != null)
            {
                FrmBatchingSign frmBatching = new FrmBatchingSign();

                frmBatching.recordModel = model;

                frmBatching.ShowDialog();
                frmBatching.Dispose();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FrmPointInfo frm = new FrmPointInfo();
            frm.ShowDialog();
        }
    }
}
