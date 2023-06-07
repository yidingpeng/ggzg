﻿using HZH_Controls.Controls;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using Prism.Commands;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.graph;
using RW.PMS.Utils.UI;
using RW.PMS.WinForm.Module;
using RW.PMS.WinForm.OPC;
using RW.PMS.WinForm.UI.Assembly;
using RW.PMS.WinForm.UI.Follow;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

using System.Windows.Media.Imaging;

namespace RW.PMS.WinForm.UI
{
    public partial class Main : Form
    {
        IBLL_BaseInfo BLLBseInfo = DIService.GetService<IBLL_BaseInfo>();
        private IBLL_ProductInfo _prodInfoBll = DIService.GetService<IBLL_ProductInfo>();
        IBLL_Graph graphbll = DIService.GetService<IBLL_Graph>();
        public int sendflag = 0;
        //OPCTagValueCharge 控件
        private OPCTagValueCharge _opcTagValueCharge1 = null;
        //OPC点位控制
        private OPC_Function _opcFunc = null;
        private object _objOPCTagLock = new object();
        bool flag = false;
        //装配管理数据操作
        private AssemblyDataControl _asseDataControl = null;
        //是否开始监听点位
        bool _IsMonitor = false;
        //当前所选配方名称
        private string formula = null;
        private string _logTxt = "";
        private bool _IsStart = true;

        private bool _isJS = false;
        private int boltsnum = 0;

        //当前产品拧紧到第几次螺栓
        private int ProTigTimes = 0;
        //拧紧轴1当前拧紧螺栓的下标
        private int TigNO1 = 0;
        //拧紧轴2当前拧紧螺栓的下标
        private int TigNO2 = 0;

        //产品型号设置的拧紧轴
        private decimal tighteningTorque = 0;
        public static Main frm1;
        //当前正在拧紧的记录id
        private int tigRecordId1 = 0;
        private int tigRecordId2 = 0;

        //产品信息id
        private int prodId;
      
        #region 曲线变量
        public class MeasureModel
        {
            public DateTime DateTime { get; set; }
            public double Value { get; set; }
        }
        //判断拧紧轴1/2的扭矩角度值
        public int TightenShaft = 1;
        //判断曲线1/2的报文标志
        public static int graphFlag = 0;
        //曲线报文数量
        public static int bytecount = 0;
        private object _objGraphLock = new object();
        private object _objGraphoneorTowLock = new object();
        public static int to1 = 0;
        public static int to2 = 0;
        object phlock = new object();
        public ChartValues<double> ChartValues { get; set; }
        public ChartValues<double> ChartValues2 { get; set; }
        public ChartValues<double> Chart2Values { get; set; }
        public ChartValues<double> Chart2Values2 { get; set; }
        public System.Windows.Forms.Timer Timer { get; set; }
        public Random R { get; set; }
        int datacountbw = 0;
        #endregion
        //曲线报文队列
        public static List<byte[]> cqsellTickets = new List<byte[]>();

        public static List<GraphPoint> pointList = new List<GraphPoint>();


        public Main()
        {
            InitializeComponent();
            //Load1();
            //启动OPC
            frm1 = this;
            _opcTagValueCharge1 = new OPCTagValueCharge();

            _opcTagValueCharge1.NameValueChanged += opcTagValueCharge1_NameValueChanged;

            _opcTagValueCharge1.Init();
            InitCurve1();
            InitCurve2();
            _IsMonitor = true;
           // Load1();

        }

        public void Load1()
        {
            try
            {


                _opcFunc = new OPC_Function();
                //_opcFunc.Init();
                _asseDataControl = new AssemblyDataControl();
                BindFormulaDLL();

                Thread th = new Thread(new ThreadStart(() =>
                {
                    while (!this.IsDisposed)
                    {
                        if (!string.IsNullOrEmpty(_logTxt))
                        {
                            Action<int> action = (data) =>
                            {
                                this.txtLog.Text = _logTxt;
                            };
                            Invoke(action, new object[] { null });
                        }
                        if (_IsStart)
                        {
                            ControlHelper.Invoke(this, delegate
                            {
                                this.toolbtnStart.Enabled = true;
                            });
                            
                            Action<int> action2 = (data) =>
                            {
                                this.toolbtnStart.Enabled = true;
                            };
                            Invoke(action2, new object[] { null });
                        }
                        Thread.Sleep(500);
                    }
                }));
                th.Start();

                //Read();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    _opcFunc = new OPC_Function();
            //    //_opcFunc.Init();
            //    _asseDataControl = new AssemblyDataControl();
            //    BindFormulaDLL();

            //    Thread th = new Thread(new ThreadStart(() =>
            //    {
            //        while (!this.IsDisposed)
            //        {
            //            if (!string.IsNullOrEmpty(_logTxt))
            //            {
            //                Action<int> action = (data) =>
            //                {
            //                    this.txtLog.Text = _logTxt;
            //                };
            //                Invoke(action, new object[] { null });
            //            }
            //            if (_IsStart)
            //            {
            //                Action<int> action2 = (data) =>
            //                {
            //                    this.toolbtnStart.Enabled = true;
            //                };
            //                Invoke(action2, new object[] { null });
            //            }
            //            Thread.Sleep(500);
            //        }
            //    }));
            //    th.Start();
            //将曲线报文解码添加到曲线图
            //  Task.Run(() =>
            //  {
            //      while (true)
            //      {

            //              if (cqsellTickets.Count > 0)
            //              {
            //              lock (_objGraphLock)
            //              {
            //                  byte[] date = new byte[842];
            //                  cqsellTickets.TryDequeue(out date);//出队，赋值到sellTicket
            //                  string strReceiveData = Encoding.ASCII.GetString(date);//接收数据转字符串

            //                  //BeginInvoke(new MethodInvoker(() =>
            //                  //{


            //                  //    MessageBox.Show(BitConverter.ToString(date));

            //                  //}));


            //                  if (bytecount % 4 == 0)
            //                  {
            //                      graphFlag++;
            //                  }
            //                  bytecount++;
            //                  //方法一 
            //                  //获取扭矩系数
            //                  var TorqueCoeff = strReceiveData.Substring(47, 12);
            //                  //转换成浮点类型
            //                  var tcFloat = double.Parse(TorqueCoeff, System.Globalization.NumberStyles.Float);
            //                  //获取角度系数    
            //                  var AngleCoeff = strReceiveData.Substring(63, 12);
            //                  //转换成浮点类型
            //                  var acFloat = double.Parse(AngleCoeff, System.Globalization.NumberStyles.Float);

            //                  ////方法二
            //                  ////获取扭矩系数转换成浮点类型
            //                  //var tcFloat = BitConverter.ToSingle(date.Skip(48).Take(13).ToArray(), 0);
            //                  ////获取角度系数转换成浮点类型
            //                  //var acFloat = BitConverter.ToSingle(date.Skip(64).Take(13).ToArray(), 0);
            //                  //获取曲线数据
            //                  byte[] curveData = date.Skip(92).Take(date.Length - 92).ToArray();
            //                  byte[] replacebyteNew = new byte[curveData.Length];
            //                  int j= 0;
            //                  ////第一步：把所有FFFF或者FFFE换成FF或者00
            //                  if (curveData.Length % 2 == 0) { 
            //                      for (int i = 0; i < curveData.Length; i += 2)
            //                      {

            //                          if (curveData[i] == 0xFF && curveData[i + 1] == 0XFF)
            //                          {
            //                              replacebyteNew[j] = 0xFF;
            //                              j++;
            //                          }
            //                          else if (curveData[i] == 0xFF && curveData[i + 1] == 0XFE)
            //                          {
            //                              replacebyteNew[j] = 0xFF;
            //                              j++;
            //                          }
            //                          else
            //                          {
            //                              replacebyteNew[j] = curveData[i];
            //                              replacebyteNew[j + 1] = curveData[i + 1];
            //                              j += 2;
            //                          }

            //                      }
            //              }
            //                  else
            //                  {
            //                      for (int i = 0; i < curveData.Length-1; i += 2)
            //                      {

            //                          if (curveData[i] == 0xFF && curveData[i + 1] == 0XFF)
            //                          {
            //                              replacebyteNew[j] = 0xFF;
            //                              j++;
            //                          }
            //                          else if (curveData[i] == 0xFF && curveData[i + 1] == 0XFE)
            //                          {
            //                              replacebyteNew[j] = 0xFF;
            //                              j++;
            //                          }
            //                          else
            //                          {
            //                              replacebyteNew[j] = curveData[i];
            //                              replacebyteNew[j + 1] = curveData[i + 1];
            //                              j += 2;
            //                          }

            //                      }
            //                      for(int i = curveData.Length - 2; i < curveData.Length; i += 2)
            //                      {
            //                          if (curveData[i] == 0xFF && curveData[i + 1] == 0XFF)
            //                          {
            //                              replacebyteNew[j] = 0xFF;
            //                              j++;
            //                          }
            //                          else if (curveData[i] == 0xFF && curveData[i + 1] == 0XFE)
            //                          {
            //                              replacebyteNew[j] = 0xFF;
            //                              j++;
            //                          }
            //                          else
            //                          {
            //                              replacebyteNew[j] = curveData[i];
            //                              replacebyteNew[j + 1] = curveData[i + 1];
            //                              j += 2;
            //                          }
            //                      }

            //                  }
            //                  ////第二步：所有字节减一
            //                  for (int i = 0; i < replacebyteNew.Length; i++)
            //                  {
            //                      replacebyteNew[i] -= 1;
            //                  }
            //                  ////第三步，交换扭矩两个字节，交换角度的四个字节，
            //                  for (int i = 0; i < replacebyteNew.Length; i += 6)
            //                  {
            //                      var Torque = replacebyteNew.Skip(i).Take(2).ToArray();
            //                      var Angle = replacebyteNew.Skip(i + 2).Take(4).ToArray();
            //                      Array.Reverse(Torque);
            //                      Array.Reverse(Angle);
            //                      //第四步：转整数
            //                      int intTorque = byteToInt((Torque));
            //                      int intAngle = byteToInt((Angle));
            //                      //第五步，扭矩乘以扭矩系数，角度乘以角度系数
            //                      var qTorque = intTorque * tcFloat;
            //                      var qAngle = intAngle * acFloat;

            //                      ControlHelper.Invoke(this, delegate
            //          {
            //             lock (_objGraphoneorTowLock)
            //              {
            //                  if (graphFlag % 2 != 0)
            //                  {
            //                      //把点位添加到曲线2中
            //                      TorOnTick1(qTorque, qAngle);
            //                      to1++;
            //                  }
            //                  if (graphFlag % 2 == 0)
            //                  {
            //                      // 把点位添加到曲线1中
            //                      TorOnTick2(qTorque, qAngle);
            //                      to2++;
            //                  }

            //              }
            //          });



            //                  }
            //                  Debug.WriteLine("[曲线一" + to1 + "]\n");
            //                  Debug.WriteLine("[曲线二" + to2 + "]\n");
            //                  Debug.WriteLine("[报文数量" + bytecount + "]\n");
            //                  Debug.WriteLine("[曲线1或2graphFlag" + graphFlag + "]\n");
            //                  Debug.WriteLine("[-------------------------------------------------------"  + "]\n");
            //              }
            //          }
            //      }
            //  }
            //);

            //连接socket
            // btnCannectSocket();

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
        }

        #region 配方opc地址

        #region 绑定数据
        public void BindFormulaDLL()
        { 
                            
                    var data = BLLBseInfo.GetBaseProductModel();
                    cmbProdNo.DataSource = data;
                    cmbProdNo.DisplayMember = "Pmodel";
                    cmbProdNo.ValueMember = "ID";
                    var formulamodel = BLLBseInfo.GetBaseProductModelId((int)cmbProdNo.SelectedValue);
                    this.lblFormulaCode.Text = formulamodel.formulaNo;
                    this.lblTorque.Text = formulamodel.tighteningTorque + "N.m.";
                    flag = true;
                    formula = cmbProdNo.Text;
                
            
           
        }

        #endregion


        #region 实体类
        class formulaPoint
        {
            public string formulaCode { get { return "GJGZ22027.PLC.Parameter.配方号"; } }
            public string formulaName { get { return "GJGZ22027.PLC.Parameter.配方名称"; } }
            /// <summary>
            /// 螺丝拧紧个数
            /// </summary>
            public string BoltsNum { get { return "GJGZ22027.PLC.Parameter.螺栓拧紧个数"; } }
            /// <summary>
            /// 拧紧轴1程序号
            /// </summary>
            public string TighteningNum { get { return "GJGZ22027.PLC.Parameter.拧紧轴1程序号"; } }
            /// <summary>
            /// 拧紧轴2程序号 程序设置只有一个端口
            /// </summary>
          //  public string TighteningNum2 { get { return "GJGZ22027.PLC.Parameter.拧紧轴2程序号"; } }
            /// <summary>
            /// 拧紧升降变频速度（%）
            /// </summary>
            public string TightenSJSpeed { get { return "GJGZ22027.PLC.Parameter.拧紧升降变频速度"; } }
            /// <summary>
            /// 拧紧升降变频准备位
            /// </summary>
            public string TightenSJReady { get { return "GJGZ22027.PLC.Parameter.拧紧升降变频退回安全位置"; } }
            /// <summary>
            /// 拧紧升降变频最终位
            /// </summary>
            public string TightenSJFinal { get { return "GJGZ22027.PLC.Parameter.拧紧升降变频最终位置"; } }
            /// <summary>
            /// 定心机构初始位
            /// </summary>
            public string CenteringReady { get { return "GJGZ22027.PLC.Parameter.定心机构初始位"; } }
            /// <summary>
            /// 定心机构定心位
            /// </summary>
            public string CenteringPosition { get { return "GJGZ22027.PLC.Parameter.定心机构定心位"; } }
            /// <summary>
            /// 定心机构速度
            /// </summary>
            public string CenteringSpeed { get { return "GJGZ22027.PLC.Parameter.定心机构速度"; } }
            /// <summary>
            /// Y轴平移伺服初始位
            /// </summary>
            public string YReady { get { return "GJGZ22027.PLC.Parameter.Y轴平移伺服初始位"; } }
            /// <summary>
            /// Y轴平移伺服装配位
            /// </summary>
            public string YAssembly { get { return "GJGZ22027.PLC.Parameter.Y轴平移伺服装配位"; } }
            /// <summary>
            /// Y轴平移伺服速度
            /// </summary>
            public string YSpeed { get { return "GJGZ22027.PLC.Parameter.Y轴平移伺服速度"; } }
            /// <summary>
            /// X轴平移伺服初始位
            /// </summary>
            public string XReady { get { return "GJGZ22027.PLC.Parameter.X轴平移伺服初始位"; } }
            /// <summary>
            /// X轴平移伺服装配位
            /// </summary>
            public string XAssembly { get { return "GJGZ22027.PLC.Parameter.X轴平移伺服装配位"; } }
            /// <summary>
            /// X轴平移伺服速度
            /// </summary>
            public string XSpeed { get { return "GJGZ22027.PLC.Parameter.X轴平移伺服速度"; } }
            /// <summary>
            /// Z轴平移伺服初始位
            /// </summary>
            public string ZReady { get { return "GJGZ22027.PLC.Parameter.Z轴平移伺服初始位"; } }
            /// <summary>
            /// Z轴平移伺服装配
            /// </summary>
            public string ZAssembly { get { return "GJGZ22027.PLC.Parameter.Z轴平移伺服装配位"; } }
            /// <summary>
            /// Z轴平移伺服速度
            /// </summary>
            public string ZSpeed { get { return "GJGZ22027.PLC.Parameter.Z轴平移伺服速度"; } }
            /// <summary>
            /// 平移伺服1初始位
            /// </summary>
            public string OneReady { get { return "GJGZ22027.PLC.Parameter.平移伺服1初始位"; } }
            /// <summary>
            /// 平移伺服1最终位
            /// </summary>
            public string OneFinal { get { return "GJGZ22027.PLC.Parameter.平移伺服1最终位"; } }
            /// <summary>
            /// 平移伺服1速度
            /// </summary>
            public string OneSpeed { get { return "GJGZ22027.PLC.Parameter.平移伺服1速度"; } }
            /// <summary>
            /// 平移伺服2初始位
            /// </summary>
            public string TwoReady { get { return "GJGZ22027.PLC.Parameter.平移伺服2初始位"; } }
            /// <summary>
            /// 平移伺服2最终位
            /// </summary>
            public string TwoFinal { get { return "GJGZ22027.PLC.Parameter.平移伺服2最终位"; } }
            /// <summary>
            /// 平移伺服2速度
            /// </summary>
            public string TwoSpeed { get { return "GJGZ22027.PLC.Parameter.平移伺服2速度"; } }
            /// <summary>
            /// 旋转伺服初始位
            /// </summary>
            public string RotateReady { get { return "GJGZ22027.PLC.Parameter.旋转伺服初始位"; } }
            /// <summary>
            /// 旋转伺服最终位(弃用)
            /// </summary>
            //public string RotateFinal { get { return "GJGZ22027.PLC.Parameter.旋转伺服最终位"; } }
            /// <summary>
            /// 旋转伺服速度
            /// </summary>
            public string RotateSpeed { get { return "GJGZ22027.PLC.Parameter.旋转伺服速度"; } }
            /// <summary>
            /// 辅助支撑定位位置
            /// </summary>
            public string Support { get { return "GJGZ22027.PLC.Parameter.辅助支撑定位位置"; } }
            /// <summary>
            /// 螺栓间隔角度 
            /// </summary>
            public string SpacingAngle { get { return "GJGZ22027.PLC.Parameter.螺栓间隔角度"; } }
            /// <summary>
            /// Z轴伺服升降到位的力
            /// </summary>
            public string ZSJInPlace { get { return "GJGZ22027.PLC.Parameter.Z轴伺服升降到位的力"; } }
            /// <summary>
            /// Y轴平移伺服准备位
            /// </summary>
            public string YSJprepare { get { return "GJGZ22027.PLC.Parameter.Y轴平移伺服准备位"; } }
            /// <summary>
            /// Z轴升降伺服装螺栓位
            /// </summary>
            public string Zbolt { get { return "GJGZ22027.PLC.Parameter.Z轴升降伺服装螺栓位"; } }
            /// <summary>
            /// Z轴升降伺服装螺栓位速度
            /// </summary>
            public string ZboltSpeed { get { return "GJGZ22027.PLC.Parameter.Z轴升降伺服装螺栓位速度"; } }
            /// <summary>
            /// 单个螺栓的位置
            /// </summary>
            public string OneBlotPosition { get { return "GJGZ22027.PLC.Parameter.单个螺栓的位置"; } }
        }

        //装配opc点位信息
        class formulaOPCInfo
        {
            public string FormulaName { get; set; }

            public string TagName { get; set; }

            public string OPCValue { get; set; }
        }


        #endregion


        #endregion

       // #region opc点位控制

        public void Read()
        {
        //    Thread.Sleep(1000);
        //    Task.Run(()=>
        //    {
        //        bool rr = false;
        //        while (true)
        //        {
        //            _opcFunc.OpcTagWriteValue("GJGZ22027.PLC.回复心跳", rr, _opcTagValueCharge1);
        //            rr = !rr;
        //           // Thread.Sleep(1000);
        //        }
        //    });

        }

        //点位控制
        private void opcTagValueCharge1_NameValueChanged(object sender, string tagKey, object tagValue)
        {
            //监听PLC心跳且回复PLC,保证程序与PLC的通讯,不回复拧紧试验台灰报错
            if (_opcFunc != null)
            {
                if (!string.IsNullOrEmpty(tagKey))
                {
                    //if (tagKey == "GJGZ22027.PLC.心跳")
                    //{
                    //    var XT = _opcFunc.OpcTagReadValue("GJGZ22027.PLC.心跳", _opcTagValueCharge1);
                    //    _opcFunc.OpcTagWriteValue("GJGZ22027.PLC.回复心跳", !XT, _opcTagValueCharge1);
                    //}
                }
            }

            if (!_IsMonitor)
            {
                return;
            }
            lock (_objOPCTagLock)
            {
                if (!string.IsNullOrEmpty(tagKey))
                {


                    //获取所有点位信息
                    var AllPoint = _asseDataControl.GetPointInfo();
                    var tagKeys = tagKey.Substring(14);
                    //判断是否是报警信号
                    if (AllPoint.Where(t => t.Address == tagKeys).Count() > 0)
                    {
                        string excuteresult = "";
                        switch (tagValue.ToBool())
                        {
                            case true: excuteresult = "报警提示"; break;
                            case false: excuteresult = "报警解除"; break;
                        }

                        //是报警信息，则保存数据到日志信息中
                        _asseDataControl.AddSysLog(new Model.Sys.SysLogModel()
                        {
                            empName = PublicVariable.CurEmpName,
                            excuteResult = excuteresult,
                            description = AllPoint.Where(t => t.Address == tagKeys).First().ExplainInfo,
                            datetime = DateTime.Now,
                            formulaCode = formula
                        });
                        var logInfo = _asseDataControl.GetSysLog();
                        if (logInfo.Count > 0)
                        {
                            ControlHelper.Invoke(this, delegate
                            {
                                txtLog.Text = logInfo.First().datetime.ToString("yyyy-MM-dd HH:mm:ss") + " " + logInfo.First().excuteResult + "：" + logInfo.First().description + "\r\n" + txtLog.Text;
                            });

                        }
                    }
                    //判断是否是拧紧完成信号
                    if (tagKey == ConfigurationManager.AppSettings["ProdEndTagKey"])
                    {
                        WriteTXT("完成信号[  " + " -----------" + DateTime.Now + "    ]\r\n");
                        if ((bool)tagValue)
                        {
                            //是的话，则将所有螺栓点位设置成已选中状态
                            for (int i = 0; i < boltsnum; i++)
                            {
                                ucEllipseDialAisle1.Items[i].Selected = true;
                                ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);
                            }

                            //修改prodInfo数据为已完成状态
                            if (prodId != 0)
                            {
                                _prodInfoBll.SaveProductInfo(new ProductInfoModel() { pf_ID = prodId }, 0);
                            }

                            //恢复下发按钮的使用
                            _IsStart = true;
                            //opc点位恢复   
                            //RecoveryOpc();
                            //弹框提示
                            //MessageBox.Show("拧紧完成！");
                            txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 作业完成" + "\r\n" + txtLog.Text;
                            //拧紧记录id恢复为0
                            tigRecordId1 = 0;
                            tigRecordId2 = 0;
                            //拧紧次数置为0
                            ProTigTimes = 0;
                            prodId = 0;

                            //  _logTxt = "";
                            ControlHelper.Invoke(this, delegate
                            {
                                this.txtLog.Clear();
                            });
                            ControlHelper.Invoke(this, delegate
                            {
                                InitDiskAndProgram();
                            });


                        }
                    }
                }
            }
        }

        //#endregion


        #region 窗体控件

        private void toolbtnExit_Click(object sender, EventArgs e)
        {
            Application.DoEvents();
            Application.Exit();
        }

        private void toolbtnChecking_Click(object sender, EventArgs e)
        {
            FrmProModel f = new FrmProModel();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void toolbtnDevice_Click(object sender, EventArgs e)
        {
            FromMaintenanceSetting f = new FromMaintenanceSetting();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void toolbtnRecord_Click(object sender, EventArgs e)
        {
            FrmTighteningRecord f = new FrmTighteningRecord();
            f.ShowDialog(this);
            f.Dispose();
        }

        private void toolbtnLog_Click(object sender, EventArgs e)
        {
            FrmSysLog frm = new FrmSysLog();
            frm.ShowDialog();
        }

        private void toolbtnFormula_Click(object sender, EventArgs e)
        {
            FrmFormula frm = new FrmFormula();
            frm.ShowDialog();
        }

        private void toolbtnPoint_Click(object sender, EventArgs e)
        {
            FrmPointInfo frm = new FrmPointInfo();
            frm.ShowDialog();
        }
        private void toolbtnShutdown_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否关闭当前计算机！", "关机确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
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


        List<formulaOPCInfo> formulaopcinfo = null;

        /// <summary>
        /// 下发配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolbtnStart_Click_1(object sender, EventArgs e)
        {
            //DialogResult msgGoOn = MessageBox.Show("是否下发配方？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            //if (msgGoOn.ToString() == "No")
            //{
            //    return;
            //}
            _IsStart = false;

            //根据配方编号获取配方信息
            var formulaData = BLLBseInfo.GetFormulaByFCode(lblFormulaCode.Text.Trim());
            if (formulaData != null)
            {
                //配方opc点位信息表    
                formulaopcinfo = new List<formulaOPCInfo>();
                formulaopcinfo.Add(new formulaOPCInfo() { FormulaName = "formulaCode", TagName = "GJGZ22027.PLC.Parameter.配方号", OPCValue = formulaData[0].formulaCode });
                formulaopcinfo.Add(new formulaOPCInfo() { FormulaName = "formulaName", TagName = "GJGZ22027.PLC.Parameter.配方名称", OPCValue = formulaData[0].formulaName });

                //获取formulaPoint实体的所有属性
                var formulapoint = new formulaPoint();
                System.Reflection.PropertyInfo[] properties = formulapoint.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

                //获取数据库中保存的配方opc点位信息
                var opcPointinfo = JsonConvert.DeserializeObject<FormulaParam>(formulaData[0].pointInfoDes);

                int i = 0;
                foreach (System.Reflection.PropertyInfo item in properties)
                {
                    //装配下发所需点位
                    string name = item.Name;
                    //完整标记名称    
                    object value = item.GetValue(formulapoint);

                    if (i++ > 1)
                    {
                        var formulaName = opcPointinfo.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public).Where(t => t.Name == name);

                        formulaOPCInfo formulaopcInfo = new formulaOPCInfo()
                        {
                            FormulaName = name,
                            TagName = value.ToString(),
                            OPCValue = formulaName.FirstOrDefault().GetValue(opcPointinfo)?.ToString()
                        };
                        formulaopcinfo.Add(formulaopcInfo);
                    }
                }
                //如果配方opc点位信息有数据，则下发点位信息
                if (formulaopcinfo != null)
                {
                    foreach (var item in formulaopcinfo)
                    {

                        if (item.TagName.Equals("GJGZ22027.PLC.Parameter.配方名称"))
                        {
                            _opcTagValueCharge1.Write(item.TagName, item.OPCValue);
                        }
                        else
                            _opcFunc.OpcTagWriteValue(item.TagName, item.OPCValue.ToDouble(), _opcTagValueCharge1);
                    }
                    //自动生成虚拟画面拧紧螺栓个数
                    if (!string.IsNullOrEmpty(opcPointinfo.BoltsNum))
                    {
                        //获取拧紧个数
                        boltsnum = opcPointinfo.BoltsNum.ToInt() * 2;
                    }


                }
                //请求连接扭力扳手
                btnCannectSocket();

                //下发配方编号到控制器
                btnPSet(lblFormulaCode.Text.Trim().ToInt());
                MessageBox.Show("下发配方成功 请点击启动装配按钮！");

            }

        }

        private void cmbformula_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                var formulamodel = BLLBseInfo.GetBaseProductModelId((int)cmbProdNo.SelectedValue);
                this.lblFormulaCode.Text = formulamodel.formulaNo;
                lblTorque.Text = formulamodel.tighteningTorque + "N.m.";
                tighteningTorque = formulamodel.tighteningTorque.ToDecimal();
                formula = cmbProdNo.Text;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnStopSocket();
            //RecoveryOpc();
        }

        /// <summary>
        /// opc点位恢复 
        /// </summary>
        public void RecoveryOpc()
        {
            if (formulaopcinfo != null)
            {
                foreach (var item in formulaopcinfo)
                {
                    _opcFunc.OpcTagWriteValue(item.TagName, 0.ToDouble(), _opcTagValueCharge1);
                }
                formulaopcinfo = null;
            }
        }

        #endregion

        #region 拧紧信息

        object obj = new object();

        private void axTcpClient1_OnReceviceByte(byte[] date)
        {
            lock (obj)
            {


                try
                {
                    string strReceiveData = Encoding.ASCII.GetString(date);//接收数据转字符串
                    //Debug.WriteLine(strReceiveData + "\n");
                    if (strReceiveData.Length >= 8 && strReceiveData.Substring(4, 4).Equals("7410"))
                    {
                        // Debug.WriteLine("【"+strReceiveData + "\n");
                        datacountbw++;
                        WriteTXT("接收报文[  " + datacountbw + " -----------" + DateTime.Now + "    ]\r\n");

                        //画曲线
                        ThreadPool.QueueUserWorkItem(delegate
                            {
                                asd(date);
                            });




                        // cqsellTickets.Enqueue(date);
                        //while (true)
                        //{
                        //    if (sendflag == 0) break;
                        //}
                        //sendflag = 1;

                        //Thread.Sleep(200);
                        //7411：确认收到曲线，不会有反应
                        axTcpClient1.SendCommand(Encoding.ASCII.GetBytes("00207411001000000000\0"));
                        // sendflag = 0;
                    }
                    if (!strReceiveData.Contains(","))
                    {
                        #region 开放协议
                        string strResult = strReceiveData.Substring(4, 4);

                        if (strResult.Equals("0004"))
                        {
                            //异常    
                            string strItem = strReceiveData.Substring(strReceiveData.Length - 7, 4);
                            string strError = strReceiveData.Substring(strReceiveData.Length - 3, 2);
                            ControlHelper.Invoke(this, delegate
                            {
                                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器1 异常项：[" + strItem + "]异常原因：[" + strError + "]\r\n" + txtLog.Text;
                            });
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
                                        string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 断开连接成功...\r\n";
                                    });
                                    break;
                                case "0018":
                                    ControlHelper.Invoke(this, delegate
                                    {
                                        txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器1 程序切换成功\r\n" + txtLog.Text;
                                    });

                                    break;
                                case "0060":
                                    ControlHelper.Invoke(this, delegate
                                    {
                                        txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器1 2 拧紧结果值订阅成功\r\n" + txtLog.Text;

                                    });
                                    break;
                                default:
                                    strReceiveData = strReceiveData.Replace("\0", "");
                                    ControlHelper.Invoke(this, delegate { string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收字符串[" + strReceiveData + "]\r\n"; });
                                    break;
                            }
                        }
                        // else if (strReceiveData.Contains("08417410001"))
                        //else if (strResult.Equals("7410"))
                        //{
                        //    //添加数据到队列
                        //    cqsellTickets.Enqueue(date);
                        //    //while (true)
                        //    //{
                        //    //    if (sendflag == 0) break;
                        //    //}
                        //    //sendflag = 1;

                        //    //Thread.Sleep(200);
                        //    //7411：确认收到曲线，不会有反应
                        //    axTcpClient1.SendCommand(Encoding.ASCII.GetBytes("00207411001000000000\0"));
                        //    // sendflag = 0;
                        //}
                        else
                        {
                            if (strReceiveData.StartsWith("00570002"))
                            {


                                // 
                                //连接成功
                                ControlHelper.Invoke(this, delegate
                                {
                                    txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器1 连接成功\r\n" + txtLog.Text;


                                    //订阅    
                                    axTcpClient1.SendCommand(Encoding.ASCII.GetBytes("00200060001000000000\0"));
                                    // Thread.Sleep(2000);
                                    axTcpClient1.SendCommand(Encoding.ASCII.GetBytes("00207408001000000000\0"));

                                });
                            }
                            else if (strReceiveData.StartsWith("02310061001"))
                            {
                                //while (true)
                                //{
                                //    if (sendflag == 0) break;
                                //}
                                // sendflag = 1;
                                string strTorque = Convert.ToDecimal(strReceiveData.Substring(140, 4) + "." + strReceiveData.Substring(144, 2)).ToString();
                                string strAngle = Convert.ToDecimal(strReceiveData.Substring(169, 5)).ToString();
                                ControlHelper.Invoke(this, delegate
                                {
                                    var ThisWZ = _opcFunc.OpcTagReadValueByInt("GJGZ22027.PLC.自动拧紧位置", _opcTagValueCharge1);
                                    if (TightenShaft % 2 != 0)
                                    {
                                        txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器1 扭力值[" + strTorque + "]角度[" + strAngle + "]...\r\n" + txtLog.Text;
                                        lblAngle.Text = strAngle;
                                        lblTorqueShow.Text = strTorque;
                                        //再次添加螺栓拧紧信息数据到TighteningRecord数据表
                                        TighteningRecordModel tighteningRecordModel1 = new TighteningRecordModel() { PID = prodId, TorqueValue = strTorque.ToDecimal(), TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = strAngle.ToDecimal(), BoltNo = (ThisWZ + 1) };
                                        tigRecordId1 = BLLBseInfo.AddTighteningRecordModel(tighteningRecordModel1);
                                    }
                                    else
                                    {
                                        txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器2 扭力值[" + strTorque + "]角度[" + strAngle + "]...\r\n" + txtLog.Text;
                                        lblAngle2.Text = strAngle;
                                        lblTorqueShow2.Text = strTorque;
                                        //再次添加螺栓拧紧信息数据到TighteningRecord数据表
                                        TighteningRecordModel tighteningRecordModel1 = new TighteningRecordModel() { PID = prodId, TorqueValue = strTorque.ToDecimal(), TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = strAngle.ToDecimal(), BoltNo = (ThisWZ + 1) };
                                        tigRecordId1 = BLLBseInfo.AddTighteningRecordModel(tighteningRecordModel1);
                                    }

                                });
                                TightenShaft++;
                                // ConcurrentQueue cqsellTickets = new ConcurrentQueue();


                                //最后一次拧紧曲线订阅

                                //则判断拧紧值是否合格    
                                //if (tighteningTorque == strTorque.ToDecimal())
                                //{
                                //-合格 则判断本次拧紧作业螺栓是否是基数
                                //if (_isJS)
                                //{
                                //    //-是 则判断本次产品拧紧螺栓次数是否是倒数第二次:count/2
                                //    if (boltsnum / 2 == ProTigTimes)
                                //    {
                                //        //是的话则将当前正在拧紧的第二个螺栓点位设置到下一个，第一个设置成已完成(该区域为第一个)
                                //        ucEllipseDialAisle1.Items[TigNO1].Selected = true;
                                //    }
                                //    else
                                //    {
                                //        //不是的话则将当前正在拧紧的两个螺栓点设置到下一个（黄绿色），将上一次的螺栓点位设置成为已选中的状态(该区域为第一个)
                                //        ucEllipseDialAisle1.Items[TigNO1].Selected = true;
                                //        ucEllipseDialAisle1.Items[++TigNO1].BGColor = Color.YellowGreen;

                                //        //再次添加螺栓拧紧信息数据到TighteningRecord数据表
                                //        TighteningRecordModel tighteningRecordModel1 = new TighteningRecordModel() { PID = prodId, TorqueValue = 0, TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = 0, BoltNo = TigNO1 };
                                //        tigRecordId1 = BLLBseInfo.AddTighteningRecordModel(tighteningRecordModel1);
                                //    }
                                //}
                                //else
                                //{
                                //-否 将当前正在拧紧的两个螺栓点设置到下一个（黄绿色），将上一次的螺栓点位设置成为已选中的状态

                                //0062：确认收到，不会有反应
                                axTcpClient1.SendCommand(Encoding.ASCII.GetBytes("00200062001000000000\0"));

                                if (TightenShaft % 2 == 0)
                                {
                                    Task.Run(() =>
                                    {
                                        if (TigNO1 + 1 == boltsnum / 2 && TigNO2 + 1 == boltsnum)
                                        {
                                            if ((double.Parse(lblTorqueShow.Text.Trim())) < (double.Parse(lblTorque.Text.Trim().Substring(0, lblTorque.Text.Trim().LastIndexOf("N")))))
                                            {
                                                ucEllipseDialAisle1.Items[TigNO1].BGColor = Color.Red;
                                            }
                                            else
                                            {
                                                ucEllipseDialAisle1.Items[TigNO1].BGColor = Color.Green;
                                                
                                                ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);

                                            }
                                            if ((double.Parse(lblTorqueShow2.Text.Trim())) < (double.Parse(lblTorque.Text.Trim().Substring(0, lblTorque.Text.Trim().LastIndexOf("N")))))
                                            {
                                                ucEllipseDialAisle1.Items[TigNO2].BGColor = Color.Red;
                                            }
                                            else
                                            {
                                               
                                                ucEllipseDialAisle1.Items[TigNO2].BGColor = Color.Green;
                                                ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);

                                            }
                                            //修改prodInfo数据为已完成状态
                                            if (prodId != 0)
                                            {
                                                _prodInfoBll.SaveProductInfo(new ProductInfoModel() { pf_ID = prodId }, 0);
                                            }
                                            TigNO1 = 0;
                                            TigNO2 = boltsnum / 2;
                                            //Task.Run(() =>
                                            //{
                                            //    MessageBox.Show("装配完成！");
                                            //}
                                            //    );


                                            _IsStart = true;

                                            return;
                                        }
                                        else
                                        {
                                            var ThisWZ = _opcFunc.OpcTagReadValueByInt("GJGZ22027.PLC.自动拧紧位置", _opcTagValueCharge1);
                                            ControlHelper.Invoke(this, delegate
                                            {
                                                Debug.WriteLine(double.Parse(lblTorqueShow.Text.Trim()) < double.Parse(lblTorque.Text.Trim().Substring(0, lblTorque.Text.Trim().LastIndexOf("N"))));

                                            });
                                          
                                            if ((double.Parse(lblTorqueShow.Text.Trim()) < (double.Parse(lblTorque.Text.Trim().Substring(0, lblTorque.Text.Trim().LastIndexOf("N"))))))
                                            {
                                                ucEllipseDialAisle1.Items[TigNO1].BGColor = Color.Red;
                                                ucEllipseDialAisle1.Items[++TigNO1].BGColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                ucEllipseDialAisle1.Items[TigNO1].BGColor = Color.Green;
                                                ucEllipseDialAisle1.Items[++TigNO1].BGColor = Color.Yellow;
                                            
                                            }
                                             if ((double.Parse(lblTorqueShow2.Text.Trim()) < (double.Parse(lblTorque.Text.Trim().Substring(0, lblTorque.Text.Trim().LastIndexOf("N"))))))
                                            {
                                                ucEllipseDialAisle1.Items[TigNO2].BGColor = Color.Red;
                                                ucEllipseDialAisle1.Items[++TigNO2].BGColor = Color.Yellow;
                                            }
                                            else
                                            {
                                                
                                                ucEllipseDialAisle1.Items[TigNO2].BGColor = Color.Green;
                                                ucEllipseDialAisle1.Items[++TigNO2].BGColor = Color.Yellow;
                                            }
                                         
                                            //}
                                            //ProTigTimes++;
                                            ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);
                                            //}
                                            //else
                                            //{
                                            //    //-不合格 则提示拧紧值不合格，需人工检查
                                            //    MessageBox.Show("拧紧值1不合格，请进行人工检查");
                                            //} 

                                            //保存扭力值和角度
                                            //TighteningRecordModel tighteningRecord = new TighteningRecordModel() { ID = tigRecordId1, TorqueValue = strTorque.ToDecimal(), TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = strAngle.ToDecimal() };
                                            //BLLBseInfo.EditTighteningRecordModel(tighteningRecord);
                                        }
                                    });

                                }
                                //  sendflag = 0;
                            }

                            else
                            {
                                strReceiveData = strReceiveData.Replace("\0", "");
                                ControlHelper.Invoke(this, delegate { string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收字符串[" + strReceiveData + "]\r\n"; });
                            }
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("系统错误：" + ex.Message);
                }
            }
        }

        public void asd(byte[] date)

        {
            lock (phlock)
            {
                cqsellTickets.Add(date);

                if (cqsellTickets.Count == 4)
                {

                    foreach (var item in cqsellTickets)
                    {


                        //画曲线
                        byte[] gdate = item;

                        string gstrReceiveData = Encoding.ASCII.GetString(gdate);//接收数据转字符串

                        //BeginInvoke(new MethodInvoker(() =>
                        //{


                        //    MessageBox.Show(BitConverter.ToString(date));

                        //}));


                        if (bytecount % 4 == 0)
                        {
                            graphFlag++;


                        }
                        bytecount++;
                        if (graphFlag % 2 != 0)
                        {

                            WriteTXT("拿取曲线1报文数量[  " + bytecount + " -----------" + " -----------" + date.Length + " -----------" + DateTime.Now + "    ]\r\n");
                        }
                        else
                            WriteTXT("拿取曲线2报文数量[  " + bytecount + " -----------" + " -----------" + date.Length + " -----------" + DateTime.Now + "    ]\r\n");
                        //方法一 
                        //获取扭矩系数
                        var TorqueCoeff = gstrReceiveData.Substring(47, 12);
                        //转换成浮点类型
                        var tcFloat = double.Parse(TorqueCoeff, System.Globalization.NumberStyles.Float);
                        //获取角度系数    
                        var AngleCoeff = gstrReceiveData.Substring(63, 12);
                        //转换成浮点类型
                        var acFloat = double.Parse(AngleCoeff, System.Globalization.NumberStyles.Float);

                        ////方法二
                        ////获取扭矩系数转换成浮点类型
                        //var tcFloat = BitConverter.ToSingle(date.Skip(48).Take(13).ToArray(), 0);
                        ////获取角度系数转换成浮点类型
                        //var acFloat = BitConverter.ToSingle(date.Skip(64).Take(13).ToArray(), 0);
                        //获取曲线数据
                        byte[] curveData = gdate.Skip(92).Take(gdate.Length - 92).ToArray();
                        byte[] replacebyteNew = new byte[curveData.Length];
                        int j = 0;
                        ////第一步：把所有FFFF或者FFFE换成FF或者00
                        if (curveData.Length % 2 == 0)
                        {
                            for (int i = 0; i < curveData.Length; i += 2)
                            {

                                if (curveData[i] == 0xFF && curveData[i + 1] == 0XFF)
                                {
                                    replacebyteNew[j] = 0xFF;
                                    j++;
                                }
                                else if (curveData[i] == 0xFF && curveData[i + 1] == 0XFE)
                                {
                                    replacebyteNew[j] = 0xFF;
                                    j++;
                                }
                                else
                                {
                                    replacebyteNew[j] = curveData[i];
                                    replacebyteNew[j + 1] = curveData[i + 1];
                                    j += 2;
                                }

                            }
                        }
                        else
                        {
                            for (int i = 0; i < curveData.Length - 1; i += 2)
                            {

                                if (curveData[i] == 0xFF && curveData[i + 1] == 0XFF)
                                {
                                    replacebyteNew[j] = 0xFF;
                                    j++;
                                }
                                else if (curveData[i] == 0xFF && curveData[i + 1] == 0XFE)
                                {
                                    replacebyteNew[j] = 0xFF;
                                    j++;
                                }
                                else
                                {
                                    replacebyteNew[j] = curveData[i];
                                    replacebyteNew[j + 1] = curveData[i + 1];
                                    j += 2;
                                }

                            }
                            for (int i = curveData.Length - 2; i < curveData.Length; i += 2)
                            {
                                if (curveData[i] == 0xFF && curveData[i + 1] == 0XFF)
                                {
                                    replacebyteNew[j] = 0xFF;
                                    j++;
                                }
                                else if (curveData[i] == 0xFF && curveData[i + 1] == 0XFE)
                                {
                                    replacebyteNew[j] = 0xFF;
                                    j++;
                                }
                                else
                                {
                                    replacebyteNew[j] = curveData[i];
                                    replacebyteNew[j + 1] = curveData[i + 1];
                                    j += 2;
                                }
                            }

                        }
                        ////第二步：所有字节减一
                        for (int i = 0; i < replacebyteNew.Length; i++)
                        {
                            replacebyteNew[i] -= 1;
                        }
                        ////第三步，交换扭矩两个字节，交换角度的四个字节，
                        for (int i = 0; i < replacebyteNew.Length; i += 6)
                        {
                            var Torque = replacebyteNew.Skip(i).Take(2).ToArray();
                            var Angle = replacebyteNew.Skip(i + 2).Take(4).ToArray();
                            Array.Reverse(Torque);
                            Array.Reverse(Angle);
                            //第四步：转整数
                            int intTorque = byteToInt((Torque));
                            int intAngle = byteToInt((Angle));
                            //第五步，扭矩乘以扭矩系数，角度乘以角度系数
                            var qTorque = intTorque * tcFloat;
                            var qAngle = intAngle * acFloat;
                            pointList.Add(new GraphPoint(qTorque, qAngle));

                            if (bytecount == 4 && i + 6 > replacebyteNew.Length)
                            {


                                ControlHelper.Invoke(this, delegate
                                {
                                    lock (_objGraphoneorTowLock)
                                    {
                                        if (graphFlag % 2 != 0)
                                        {
                                            WriteTXT("画曲线1点数[  " + to1 + " -----------" + DateTime.Now + "    ]\r\n");
                                            //把点位添加到曲线1中
                                            TorOnTick1(pointList);
                                            WriteTXT("画曲线1长度[  " + pointList.Count + " -----------" + DateTime.Now + "    ]\r\n");
                                            to1++;
                                        }
                                        if (graphFlag % 2 == 0)
                                        {
                                            WriteTXT("画曲线2点数[  " + to2 + " -----------" + DateTime.Now + "    ]\r\n");
                                            // 把点位添加到曲线2中
                                            TorOnTick2(pointList);
                                            WriteTXT("画曲线2长度[  " + pointList.Count + " -----------" + DateTime.Now + "    ]\r\n");
                                            to2++;
                                        }

                                    }
                                });
                                bytecount = 0;
                                pointList.Clear();
                            }


                        }

                        Debug.WriteLine("[曲线一" + to1 + "]\n");
                        Debug.WriteLine("[曲线二" + to2 + "]\n");
                        Debug.WriteLine("[报文数量" + bytecount + "]\n");
                        Debug.WriteLine("[曲线1或2graphFlag" + graphFlag + "]\n");
                        Debug.WriteLine("[-------------------------------------------------------" + "]\n");
                    }
                    cqsellTickets.Clear();
                }
            }
        }


        private void axTcpClient2_OnReceviceByte(byte[] date)
        {
            //try
            //{
            //    string strReceiveData = Encoding.ASCII.GetString(date);//接收数据转字符串

            //    if (!strReceiveData.Contains(","))
            //    {
            //        #region 开放协议
            //        string strResult = strReceiveData.Substring(4, 4);

            //        if (strResult.Equals("0004"))
            //        {
            //            //异常
            //            string strItem = strReceiveData.Substring(strReceiveData.Length - 7, 4);
            //            string strError = strReceiveData.Substring(strReceiveData.Length - 3, 2);
            //            ControlHelper.Invoke(this, delegate
            //            {
            //                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器2 异常项：[" + strItem + "]异常原因：[" + strError + "]\r\n" + txtLog.Text;
            //            });
            //        }
            //        else if (strResult.Equals("0005"))
            //        {
            //            //成功    
            //            string strItem = strReceiveData.Substring(strReceiveData.Length - 5, 4);
            //            switch (strItem)
            //            {
            //                case "0003":
            //                    ControlHelper.Invoke(this, delegate
            //                    {
            //                        string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 断开连接成功...\r\n";
            //                    });
            //                    break;
            //                case "0018":
            //                    ControlHelper.Invoke(this, delegate
            //                    {
            //                        txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器2 程序切换成功\r\n" + txtLog.Text;
            //                    });
            //                    break;
            //                case "0060":
            //                    ControlHelper.Invoke(this, delegate
            //                    {
            //                        txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器2 拧紧结果值订阅成功\r\n" + txtLog.Text;
            //                    });
            //                    break;
            //                default:
            //                    strReceiveData = strReceiveData.Replace("\0", "");
            //                    ControlHelper.Invoke(this, delegate { string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收字符串[" + strReceiveData + "]\r\n"; });
            //                    break;
            //            }
            //        }
            //        else
            //        {
            //            if (strReceiveData.StartsWith("00570002"))
            //            {
            //                //连接成功
            //                ControlHelper.Invoke(this, delegate
            //                {
            //                    txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器2 连接成功\r\n" + txtLog.Text;

            //                    //订阅
            //                    axTcpClient2.SendCommand(Encoding.ASCII.GetBytes("00200060001000000000\0"));
            //                });
            //            }
            //            else if (strReceiveData.StartsWith("0231006100"))
            //            {

            //                string strTorque = Convert.ToDecimal(strReceiveData.Substring(140, 4) + "." + strReceiveData.Substring(144, 2)).ToString();
            //                string strAngle = Convert.ToDecimal(strReceiveData.Substring(169, 5)).ToString();
            //                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器2 扭力值[" + strTorque + "]角度[" + strAngle + "]...\r\n" + txtLog.Text;

            //                lblAngle2.Text = strAngle;
            //                lblTorqueShow2.Text = strTorque;
            //                //判断拧紧值是否合格
            //                //if (tighteningTorque == strTorque.ToDecimal())
            //                //{
            //                //    //-合格 将当前正在拧紧的两个螺栓点设置到下一个（黄绿色），将上一次的螺栓点位设置成为已选中的状态
            //                //    ucEllipseDialAisle1.Items[TigNO2].Selected = true;
            //                //    ucEllipseDialAisle1.Items[++TigNO2].BGColor = Color.YellowGreen;
            //                //    //再次添加螺栓拧紧信息数据到TighteningRecord数据表
            //                //    TighteningRecordModel tighteningRecordModel1 = new TighteningRecordModel() { PID = prodId, TorqueValue = 0, TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = 0, BoltNo = TigNO2 };
            //                //    tigRecordId2 = BLLBseInfo.AddTighteningRecordModel(tighteningRecordModel1);
            //                //    ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);
            //                //}
            //                ////else
            //                ////{
            //                ////    //-不合格 则提示拧紧值不合格，需人工检查
            //                ////    MessageBox.Show("拧紧值2不合格，请进行人工检查");
            //                ////}
            //                ////保存扭力值和角度
            //                //TighteningRecordModel tighteningRecord = new TighteningRecordModel() { ID = tigRecordId2, TorqueValue = strTorque.ToDecimal(), TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = strAngle.ToDecimal() };
            //                //BLLBseInfo.EditTighteningRecordModel(tighteningRecord);
            //                //ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);

            //                var ThisWZ = _opcFunc.OpcTagReadValueByInt("GJGZ22027.PLC.自动拧紧位置", _opcTagValueCharge1);
            //                ucEllipseDialAisle1.Items[TigNO2].Selected = true;
            //                ucEllipseDialAisle1.Items[++TigNO2].BGColor = Color.YellowGreen;
            //                //再次添加螺栓拧紧信息数据到TighteningRecord数据表
            //                TighteningRecordModel tighteningRecordModel1 = new TighteningRecordModel() { PID = prodId, TorqueValue = strTorque.ToDecimal(), TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = strAngle.ToDecimal(), BoltNo = (ThisWZ + 1) };
            //                tigRecordId2 = BLLBseInfo.AddTighteningRecordModel(tighteningRecordModel1);
            //                ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);

            //                //0062：确认收到，不会有反应
            //                axTcpClient2.SendCommand(Encoding.ASCII.GetBytes("00200062001000000000\0"));
            //            }
            //            else if (strReceiveData.Contains("08417410001"))
            //            {
            //                //获取扭矩系数
            //                var TorqueCoeff = strReceiveData.Substring(146, 24);
            //                //转换成浮点类型
            //                var tcFloat = double.Parse(TorqueCoeff, System.Globalization.NumberStyles.Float);
            //                //获取角度系数    
            //                var AngleCoeff = strReceiveData.Substring(178, 24);
            //                //转换成浮点类型
            //                var acFloat = double.Parse(AngleCoeff, System.Globalization.NumberStyles.Float);

            //                //开始计算：例如：BCD1 7D01 0101 -BCD1为扭矩，7D010101为角度
            //                var strASCII = "BCD17D010101";
            //                //第一步：把所有FFFF或者FFFE换成FF或者00
            //                strASCII = strASCII.Replace("FFFF", "FF");
            //                strASCII = strASCII.Replace("FFFE", "00");
            //                //第二步：每个字节减去1   
            //                List<string> ASCIIarr = new List<string>();
            //                for (int i = 1; i <= strASCII.Length; i++)
            //                {
            //                    if (i % 2 == 0)
            //                    {
            //                        ASCIIarr.Add(strASCII[i - 2] + "" + strASCII[i - 1]);
            //                    }
            //                }
            //                for (int j = 0; j <= ASCIIarr.Count; j++)
            //                {
            //                    if (!string.IsNullOrEmpty(ASCIIarr[j]) && ASCIIarr[j].Any(t => char.IsUpper(t)))
            //                    {
            //                        ASCIIarr[j] = (Convert.ToInt32(ASCIIarr[j], 16) - 1).ToString("X").PadLeft(2, '0');
            //                    }
            //                    else
            //                    {
            //                        ASCIIarr[j] = (Convert.ToInt32(ASCIIarr[j], 16) - 1).ToString("x").PadLeft(2, '0');
            //                    }
            //                }

            //                //第三步：换算成整数计算：扭矩*扭矩系数，角度*角度系数
            //                string s = string.Join("", ASCIIarr.ToArray());
            //            var Torque = HexToDecimal(s.Substring(0, 4)) * tcFloat;
            //                var Angle = HexToDecimal(s.Substring(5, 8)) * acFloat;

            //                //把点位添加到曲线中
            //                TorOnTick2(Torque, Angle);

            //                //TODO：保存该曲线信息

            //                //7411：确认收到曲线，不会有反应
            //                axTcpClient2.SendCommand(Encoding.ASCII.GetBytes("00207411001000000000\0"));
            //            }
            //            else
            //            {
            //                strReceiveData = strReceiveData.Replace("\0", "");
            //                ControlHelper.Invoke(this, delegate { string a = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 接收字符串[" + strReceiveData + "]\r\n"; });
            //            }
            //        }
            //        #endregion
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }
        /// <summary>
        /// 将byte[]转换成int类型
        /// </summary>
        /// <param name="b">需转换的字节数组</param>
        /// <returns>转换成的整型数字</returns>
        public static int byteToInt(byte[] b)//将字节数组转换成int类型
        {

            int mask = 0xff;
            int temp = 0;
            int n = 0;
            for (int i = 0; i < b.Length; i++)
            {
                n <<= 8;
                temp = b[i] & mask;
                n |= temp;
            }
            return n;
        }

        /// <summary>
        /// string转16进制字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public byte[] stringTo16Bytes(string s)
        {
            return Enumerable.Range(0, s.Length)
                 .Where(x => x % 2 == 0)
                 .Select(x => Convert.ToByte(s.Substring(x, 2), 16))
                 .ToArray();
        }
        #region 十六进制转十进制
        /// <summary>
        /// Hex十六进制数字转十进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        public static int HexToDecimal(string hex)
        {
            if (!Regex.Match(hex, "^[0-9A-F]$", RegexOptions.IgnoreCase).Success)
            {
                throw new Exception("不是十六进制数字");
            }
            var decimalValue = 0;
            var hexUp = hex.ToUpper();
            // 从最后一位到第一位循环获取每位的值，并乘以基数的n-1次方
            for (int i = hexUp.Length - 1; i >= 0; i--)
            {
                int currV = 0;
                switch (hexUp[i])
                {
                    case 'A':
                        currV = 10;
                        break;
                    case 'B':
                        currV = 11;
                        break;
                    case 'C':
                        currV = 12;
                        break;
                    case 'D':
                        currV = 13;
                        break;
                    case 'E':
                        currV = 14;
                        break;
                    case 'F':
                        currV = 15;
                        break;
                    case '0':
                        currV = 0;
                        break;
                    case '1':
                        currV = 1;
                        break;
                    case '2':
                        currV = 2;
                        break;
                    case '3':
                        currV = 3;
                        break;
                    case '4':
                        currV = 4;
                        break;
                    case '5':
                        currV = 5;
                        break;
                    case '6':
                        currV = 6;
                        break;
                    case '7':
                        currV = 7;
                        break;
                    case '8':
                        currV = 8;
                        break;
                    case '9':
                        currV = 9;
                        break;
                    default:
                        break;
                }

                for (int n = 0; n < hexUp.Length - 1 - i; n++)
                {
                    currV *= 16;
                }
                decimalValue += currV;
            }
            return decimalValue;
        }
        #endregion

        #region 发送数据
        private void SendData(string strSendData)
        {
            try
            {
                byte[] senddata = Encoding.ASCII.GetBytes(strSendData);

                axTcpClient1.SendCommand(senddata);
            }
            catch (Exception)
            {
            }
        }

        private void SendData2(string strSendData)
        {
            try
            {
                byte[] senddata = Encoding.ASCII.GetBytes(strSendData);

                // axTcpClient2.SendCommand(senddata);
            }
            catch (Exception)
            {
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
        private void axTcpClient1_OnStateInfo(string msg, SocketHelper.SocketState state)
        {
            ControlHelper.Invoke(this, delegate
            {
                txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器1 状态[" + state.ToString() + "]消息[" + msg + "]\r\n" + txtLog.Text;

                if (msg == "已连接服务器")
                {
                    //连接控制器     
                    axTcpClient1.SendCommand(Encoding.ASCII.GetBytes("00200001000000000000\0"));
                }
            });
        }

        private void axTcpClient2_OnStateInfo(string msg, SocketHelper.SocketState state)
        {
            //ControlHelper.Invoke(this, delegate
            //{
            //    txtLog.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 拧紧轴控制器2 状态[" + state.ToString() + "]消息[" + msg + "]\r\n" + txtLog.Text;

            //    if (msg == "已连接服务器")
            //    {
            //        //连接控制器
            //        axTcpClient2.SendCommand(Encoding.ASCII.GetBytes("00200001000000000000\0"));
            //    }
            //});
        }
        #endregion

        #region 请求连接Socket
        private void btnCannectSocket()
        {
            try
            {
                string IP = ConfigurationManager.AppSettings["TorqueLocalIP"];
                axTcpClient1.ServerIp = IP;
                axTcpClient1.ServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["TorqueLocal1Port"]);
                axTcpClient1.StartConnection();

                //axTcpClient2.ServerIp = IP;
                //axTcpClient2.ServerPort = Convert.ToInt32(ConfigurationManager.AppSettings["TorqueLocal2Port"]);
                //axTcpClient2.StartConnection();

                tmrTorque.Enabled = true;
                this.timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请求连接Socket" + ex.Message);
            }
        }
        #endregion

        #region 断开Socket连接
        private void btnStopSocket()
        {
            try
            {
                if (!axTcpClient1.Isclosed)
                {
                    tmrTorque.Enabled = false;
                    axTcpClient1.Isclosed = true;
                    axTcpClient1.StopConnection();//断开
                }
                //if (!axTcpClient2.Isclosed)
                //{
                //    tmrTorque.Enabled = false;
                //    axTcpClient2.Isclosed = true;
                //    axTcpClient2.StopConnection();//断开
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("断开Socket连接" + ex.Message);
            }
        }
        #endregion

        #region 请求连接控制器
        private void btnCannect()
        {
            try
            {
                SendData("00200001000000000000\0");//请求连接
                SendData2("00200001000000000000\0");//请求连接
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 请求断开控制器
        private void btnStop()
        {
            try
            {
                SendData("00200003000000000000\0");//请求断开
                SendData2("00200003000000000000\0");//请求断开
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 切换程序
        private void btnPSet(int ProcedureID)
        {
            try
            {
                string temp = "";
                ControlHelper.Invoke(this, delegate { temp = ProcedureID + ""; });

                byte[] senddata = Encoding.ASCII.GetBytes("00230018000000000000" + "5" + "\0");
                //axTcpClient1.SendCommand(senddata);
                // axTcpClient2.SendCommand(senddata);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 订阅
        private void btnSubscribe()
        {
            try
            {
                SendData("00200060001000000000\0");//上次拧紧结果值订阅  
                SendData2("00200060001000000000\0");//上次拧紧结果值订阅  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 取消订阅
        private void btnCancel()
        {
            try
            {
                SendData("00200063000000000000\0");//取消订阅
                SendData2("00200063000000000000\0");//取消订阅
            }
            catch (Exception ex)
            {
                MessageBox.Show("取消订阅" + ex.Message);
            }
        }
        #endregion

        #region 订阅最后一次拧紧曲线
        public void LastCurveSubscribe()
        {
            try
            {
                SendData("00207408001000000000\0");//最后一次拧紧曲线订阅
                SendData2("00207408001000000000\0");//最后一次拧紧曲线订阅
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 轮询扭力任务
        private void timer1_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    timer1.Stop();

            //    axTcpClient1.SendCommand(Encoding.ASCII.GetBytes("00230018000000000000" + lblFormulaCode.Text.Trim() + "\0"));
            //    axTcpClient2.SendCommand(Encoding.ASCII.GetBytes("00230018000000000000" + lblFormulaCode.Text.Trim() + "\0"));

            //    timer1.Start();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }


        #endregion

        #region 保持通讯
        private void tmrTorque_Tick(object sender, EventArgs e)
        {
            try
            {
                //while (true)
                //{
                //    if (sendflag == 0) break;
                //}
                SendData("00209999000000000000\0");//保持通讯
                //SendData2("00209999000000000000\0");//保持通讯
            }
            catch (Exception ex)
            {
                MessageBox.Show("保持通讯" + ex.Message);
            }
        }


        #endregion

        #endregion

        #region 曲线方法
        /// <summary>
        /// 曲线初始化
        /// </summary>
        public void InitCurve1()
        {
            var mapper = Mappers.Xy<MeasureModel>()
               .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
               .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the ChartValues property will store our values array
            ChartValues = new ChartValues<double>();
            ChartValues2 = new ChartValues<double>();
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title="扭矩",
                    Values = ChartValues,
                    PointGeometrySize = 8,
                    StrokeThickness = 2,
                    ScalesYAt=0
                },
                new LineSeries
                {
                    Title="角度",
                    Values = ChartValues2,
                    PointGeometrySize = 8,
                    StrokeThickness = 2,
                    ScalesYAt=1
                }
            };

            //cartesianChart1.AxisX.Add(new Axis
            //{
            //    DisableAnimations = true,
            //    LabelFormatter = value => new DateTime((long)value).ToString("mm:ss"),
            //    Separator = new Separator
            //    {
            //        Step = TimeSpan.FromSeconds(1).Ticks
            //    }
            //});

            cartesianChart1.AxisY.Add(new Axis
            {
                Foreground = System.Windows.Media.Brushes.DodgerBlue,
                Title = "扭矩 Nm"
            });
            cartesianChart1.AxisY.Add(new Axis
            {
                Foreground = System.Windows.Media.Brushes.IndianRed,
                Title = "角度 °",
                Position = AxisPosition.RightTop
            });

            // SetAxisLimits1(DateTime.Now);
        }
        public void InitCurve2()
        {
            var mapper = Mappers.Xy<MeasureModel>()
               .X(model => model.DateTime.Ticks)   //DateTime.Ticks作为X轴
               .Y(model => model.Value);           //value属性作为Y轴

            //全局保存映射    
            Charting.For<MeasureModel>(mapper);

            //ChartValues、Chart2Values2存储值数组
            Chart2Values = new ChartValues<double>();
            Chart2Values2 = new ChartValues<double>();
            cartesianChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title="扭矩",
                    Values = Chart2Values,
                    PointGeometrySize = 8,
                    StrokeThickness = 2,
                    ScalesYAt=0
                },
                new LineSeries
                {
                    Title="角度",
                    Values = Chart2Values2,
                    PointGeometrySize = 8,
                    StrokeThickness = 2,
                    ScalesYAt=1
                }
            };

            //cartesianChart2.AxisX.Add(new Axis
            //{
            //    DisableAnimations = true,
            //    LabelFormatter = value => new DateTime((long)value).ToString("mm:ss"),
            //    Separator = new Separator
            //    {
            //        Step = TimeSpan.FromSeconds(1).Ticks
            //    }
            //});

            cartesianChart2.AxisY.Add(new Axis
            {
                Foreground = System.Windows.Media.Brushes.DodgerBlue,
                Title = "扭矩 Nm"
            });
            cartesianChart2.AxisY.Add(new Axis
            {
                Foreground = System.Windows.Media.Brushes.IndianRed,
                Title = "角度 °",
                Position = AxisPosition.RightTop
            });

            //  SetAxisLimits2(DateTime.Now);
        }

        private void SetAxisLimits1(DateTime now)
        {
            //cartesianChart1.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(0.1).Ticks; //迫使x值向前移动1毫秒
            //cartesianChart1.AxisX[0].MinValue = now.Ticks- TimeSpan.FromSeconds(1.2).Ticks; //只考虑、显示后面的2.8秒
        }

        private void SetAxisLimits2(DateTime now)
        {
            //cartesianChart2.AxisX[0].MaxValue = now.Ticks+ TimeSpan.FromSeconds(0.1).Ticks; //迫使x值向前移动1毫秒
            //cartesianChart2.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(1.2).Ticks; //只考虑、显示后面的2.8秒
        }

        //private void TimerOnTick(object sender, EventArgs eventArgs)
        //{
        //    var now = DateTime.Now;

        //    ChartValues.Add(new MeasureModel
        //    {
        //        DateTime = now,
        //        Value = R.Next(0, 10)
        //    });

        //    ChartValues2.Add(new MeasureModel
        //    {
        //        DateTime = now,
        //        Value = R.Next(0, 20)
        //    });

        //    SetAxisLimits1(now);

        //    //lets only use the last 30 values
        //    if (ChartValues.Count > 500) ChartValues.RemoveAt(0);
        //    if (ChartValues2.Count > 500) ChartValues2.RemoveAt(0);
        //}

        private void TorOnTick1(List<GraphPoint> pointList)
        {
            var dt = DateTime.Now;

            //一次添加多个
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();

            int ii = 0;
            foreach (var item in pointList)
            {
                dt = DateTime.Now;

                list1.Add(item.qTorque);
                list2.Add(item.qAngle);
                // SetAxisLimits1(now);

                // dt.AddMilliseconds(1);

                //写入数据库
                graphbll.AddGraphData(new GraphModel(DateTime.Now, item.qTorque, item.qAngle, "曲线一"));

            }
            ChartValues.Clear();
            ChartValues2.Clear();

            ChartValues.AddRange(list1);
            //cartesianChart1.Series[0].Values = ChartValues;


            // ChartValues.AddRange(list1);

            ChartValues2.AddRange(list2);


            //  SetAxisLimits1(dt);


            //只使用最后30个值
            //if (ChartValues.Count > 500) ChartValues.Clear();
            // if (ChartValues2.Count > 500) ChartValues2.Clear();


        }
        private void TorOnTick2(List<GraphPoint> pointList)
        {
            Chart2Values.Clear();
            Chart2Values2.Clear();
            var dt = DateTime.Now;

            //一次添加多个
            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            foreach (var item in pointList)
            {
                dt = DateTime.Now;

                //Thread.Sleep(100);

                list1.Add(item.qTorque);
                list2.Add(item.qAngle);
                //写入数据库
                graphbll.AddGraphData(new GraphModel(DateTime.Now, item.qTorque, item.qAngle, "曲线二"));


            }

            Chart2Values.AddRange(list1);


            Chart2Values2.AddRange(list2);


            //  SetAxisLimits2(dt);



            //只使用最后30个值
            // if (Chart2Values.Count > 500) Chart2Values.Clear();
            //a if (Chart2Values2.Count > 500) Chart2Values2.Clear();


        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            InitDiskAndProgram();
        }

        //初始化拧紧位置虚拟圆盘
        private void InitDiskAndProgram()
        {

            //先判断拧紧设备是否需要保养
            var maintenanceSetting = _asseDataControl.GetMaintenanceSettingAll();
            if (maintenanceSetting.Count > 0)
            {
                if (maintenanceSetting[0].Frequency <= maintenanceSetting[0].usedTimes)
                {
                    //需要保养则弹框提醒
                    DialogResult MsgBoxResult = MessageBox.Show("拧紧设备使用频率已到达，请问是否继续下发？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (MsgBoxResult.ToString() == "Yes")
                    {
                        //继续下发，则给拧紧设备已使用次数+1
                        _asseDataControl.AddUsedTimes();
                    }
                    if (MsgBoxResult.ToString() == "No")
                    {
                        return;
                    }
                }
                //使用频率未到达，则给拧紧设备已使用次数+1
                _asseDataControl.AddUsedTimes();
            }

            //添加产品信息    
            FrmCreateProd frm = new FrmCreateProd(cmbProdNo.SelectedValue.ToInt());
            if (frm.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            prodId = frm.prodId;

            if (boltsnum != 0)
            {
                List<EllipseDialAisleItem> items = new List<EllipseDialAisleItem>();
                for (int a = 0; a < boltsnum; a++)
                {
                    items.Add(new EllipseDialAisleItem() { Text = " " });
                }

                //判断当前螺栓点数是否是基数
                //var isOS = items.Count % 2 == 0;
                //_isJS = !isOS;
                //if (_isJS)
                //{
                //    items.Add(new EllipseDialAisleItem() { Text = " " });
                //}
                if (boltsnum > 50)
                    ucEllipseDialAisle1.ItemSize = 8;
                else
                    ucEllipseDialAisle1.ItemSize = 18;

                //动态生成虚拟画面拧紧螺栓个数
                ucEllipseDialAisle1.Items = items.ToArray();
                //if (_isJS)
                //    ucEllipseDialAisle1.Items[boltsnum].BGColor = Color.WhiteSmoke;
                ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);

                //设置最开始正的在拧紧的螺栓位置：0、count/2
                TigNO1 = 0;
                TigNO2 = boltsnum / 2;
                ucEllipseDialAisle1.Items[TigNO1].BGColor = Color.Yellow;
                ucEllipseDialAisle1.Items[TigNO2].BGColor = Color.Yellow;


                //添加两个螺栓拧紧信息数据到TighteningRecord数据表
                //TighteningRecordModel tighteningRecordModel1 = new TighteningRecordModel() { PID = prodId, TorqueValue = 0, TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = 0, BoltNo = TigNO1 };
                //TighteningRecordModel tighteningRecordModel2 = new TighteningRecordModel() { PID = prodId, TorqueValue = 0, TighteningDate = DateTime.Now, Operators = PublicVariable.CurEmpID, AngleValue = 0, BoltNo = TigNO2 };
                //tigRecordId1 = BLLBseInfo.AddTighteningRecordModel(tighteningRecordModel1);
                //tigRecordId2 = BLLBseInfo.AddTighteningRecordModel(tighteningRecordModel2);
            }

            //清除日志  
            //_logTxt = "";
            _IsMonitor = true;
            _IsStart = false;
            this.toolbtnStart.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ucEllipseDialAisle1.Items[TigNO1].Selected = true;
            //ucEllipseDialAisle1.Items[++TigNO1].BGColor = Color.YellowGreen;

            //ucEllipseDialAisle1.Items[TigNO2].Selected = true;
            //ucEllipseDialAisle1.Items[++TigNO2].BGColor = Color.YellowGreen;

            //ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //是的话，则将所有螺栓点位设置成已选中状态
            for (int i = 0; i < boltsnum; i++)
            {
                ucEllipseDialAisle1.Items[i].Selected = true;
                ucEllipseDialAisle1.UCEllipseDialAisle_SizeChanged(null, null);
            }

            //修改prodInfo数据为已完成状态
            if (prodId != 0)
            {
                _prodInfoBll.SaveProductInfo(new ProductInfoModel() { pf_ID = prodId }, 0);
            }

            //恢复下发按钮的使用
            _IsStart = true;
            //opc点位恢复   
            //RecoveryOpc();
            //弹框提示
            //MessageBox.Show("拧紧完成！");
            _logTxt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " 作业完成" + "\r\n" + _logTxt;
            //拧紧记录id恢复为0
            tigRecordId1 = 0;
            tigRecordId2 = 0;
            //拧紧次数置为0
            ProTigTimes = 0;
            prodId = 0;

            // _logTxt = "";
            this.txtLog.Clear();

            InitDiskAndProgram();
        }
        /// <summary>
        /// 追加写入txt数据
        /// </summary>
        /// <param name="FilePath">txt完整路径</param>
        /// <param name="str">要写入的内容</param>
        /// <remarks></remarks>
        public void WriteTXT(string str)
        {
            try
            {
                byte[] s = System.Text.Encoding.Default.GetBytes(str.ToString());
                FileStream fs = new FileStream("D:\\log.txt", FileMode.Append, FileAccess.Write);
                fs.Write(s, 0, s.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                //WriteLog("WriteTXT", ex.ToString());
            }
        }

        private void Main_Load_1(object sender, EventArgs e)
        {
            Load1();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
       

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ////打印内容 为 局部的 this.panel1
            //Bitmap _NewBitmap = new Bitmap(panel.Width, panel.Height);
            //panel.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            //e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);
        }
    }
}
