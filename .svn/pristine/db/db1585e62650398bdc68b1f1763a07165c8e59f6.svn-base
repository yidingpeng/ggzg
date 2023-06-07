using Fleck;
using log4net;
using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.Model.BaseInfo;
using RW.PMS.WebSocketWinService.Driver;
using RW.PMS.WebSocketWinService.Log;
using RW.PMS.WebSocketWinService.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;

namespace RW.PMS.WebSocketWinService
{
    public delegate void NameValueHandler<T>(object sender, string name, T value);
    partial class WebSocketService : ServiceBase
    {
        WebSocketServer server;
        event NameValueHandler<bool> NameValueChanged;
        List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();//所有连接集合
        OPCDriver opcDriver = new OPCDriver();
        object lockObj = new object();
        object lockChange = new object();
        Dictionary<string, Delegate> dicMap = new Dictionary<string, Delegate>();
        Dictionary<string, Delegate> dicBool = new Dictionary<string, Delegate>();
        Dictionary<string, Delegate> dicDouble = new Dictionary<string, Delegate>();
        Dictionary<string, bool> dicCurKeyValue = new Dictionary<string, bool>();
        IBLL_BaseInfo bll = DIService.GetService<IBLL_BaseInfo>();
        public WebSocketService()
        {
            InitializeComponent();
            opcDriver.Connect();//连接OPC
            opcDriver.ValueChanged += BaseValueChange;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                #region Log
                ILog logger = LogManager.GetLogger(typeof(FleckLog));
                FleckLog.LogAction = (level, message, ex) =>
                {
                    switch (level)
                    {
                        case LogLevel.Debug:
                            logger.Debug(message, ex);
                            break;
                        case LogLevel.Error:
                            logger.Error(message, ex);
                            break;
                        case LogLevel.Warn:
                            logger.Warn(message, ex);
                            break;
                        default:
                            logger.Info(message, ex);
                            break;
                    }
                };
                #endregion

                #region IP & 端口号
                string ip = ConfigurationManager.AppSettings["APWebSocketIP"];
                string port = ConfigurationManager.AppSettings["APWebSocketPort"];
                if (string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port))
                    server = new WebSocketServer("ws://0.0.0.0:7181");
                else
                    server = new WebSocketServer("ws://" + ip + ":" + port);
                #endregion

                #region WebSocket 初始化
                server.ListenerSocket.NoDelay = true;//禁用Nagle的缓冲器算法
                server.RestartAfterListenError = true;//监听过程中出现错误自动重启
                server.Start(socket =>
                {
                    socket.OnOpen = () =>
                    {
                        allSockets.Add(socket);
                    };
                    socket.OnClose = () =>
                    {
                        allSockets.Remove(socket);
                    };
                    socket.OnMessage = message =>
                    {
                        #region 暂时用不到此逻辑
                        //List<string> strList = message.Split(';').ToList();
                        //if (strList.Count == 2)
                        //{
                        //    string strKey = strList[0];
                        //    if (strList[1] == "0")
                        //        opcDriver.Write(strKey, false);
                        //    else if (strList[1] == "1")
                        //        opcDriver.Write(strKey, true);
                        //    else
                        //        opcDriver.Write(strList[0], strList[1]);
                        //}
                        #endregion
                    };
                });
                #endregion

                #region OPC初始化
                List<BaseTempAreaModel> psTAList = bll.GetTempAreaList(new BaseTempAreaModel() { ta_areaID = (int)EDAEnums.TempArea.PartStore });
                List<OPCPointModel> OPCPointList = new List<OPCPointModel>();
                foreach (var item in psTAList)
                {
                    if (string.IsNullOrEmpty(item.ta_opcStoreI)) continue;
                    OPCPointList.Add(new OPCPointModel() { OPCTypeCode = item.ta_opcStoreI, OPCValue = item.ta_opcStoreI });
                }
                foreach (var item in OPCPointList)
                {
                    if (!string.IsNullOrEmpty(item.OPCValue))
                    {
                        string key = item.Value + "";

                        this.Register<bool>(key, delegate(bool value)
                        {
                            lock (lockObj)
                            {
                                if (dicCurKeyValue.ContainsKey(key))
                                    dicCurKeyValue[key] = value;
                                else
                                    dicCurKeyValue.Add(key, value);
                                if (NameValueChanged != null) NameValueChanged(this, key, value);
                            }
                        });
                    }
                }
                #endregion

                #region OPC绑定值变事件
                string error = string.Empty;
                foreach (KeyValuePair<string, Delegate> item in dicMap)
                {
                    try
                    {
                        object value = opcDriver[item.Key];
                        BaseValueChange(item.Key, value);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals("异常来自 HRESULT:0xC0040007"))
                            error += "OPC初始化异常,请检查OPC点位配置!" + Environment.NewLine;
                        else
                            error += "Init items error.[" + item.Key + "]" + ex.Message + Environment.NewLine;
                    }
                }
                if (!string.IsNullOrEmpty(error))
                {
                    LogHelper.WriteLog(error);
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("E0001-[OnStart]函数异常", ex);
            }
        }

        protected override void OnStop()
        {
            try
            {
                opcDriver.Close();
                allSockets.Clear();
                server.Dispose();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("E0002-[OnStop]函数异常", ex);
            }
        }

        protected override void OnPause()
        {
            //服务暂停执行代码
            base.OnPause();
        }

        protected override void OnContinue()
        {
            //服务恢复执行代码
            base.OnContinue();
        }
        protected override void OnShutdown()
        {
            //系统即将关闭执行代码
            base.OnShutdown();
        }

        /// <summary>
        /// 值变事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private void BaseValueChange(string key, object value)
        {
            if (this.DesignMode) return;
            if (value == null) return;
            try
            {
                Delegate del;
                if (dicMap.ContainsKey(key))
                    del = dicMap[key];
                else
                    del = null;

                if (dicMap.ContainsKey(key) && del != null)
                {
                    if (value.GetType() == typeof(byte))//byte转bool
                        del.DynamicInvoke(Convert.ToBoolean(value));
                    else if (value.GetType() == typeof(float) && del.Method.GetParameters()[0].ParameterType == typeof(double))//float转double
                        del.DynamicInvoke(Convert.ToDouble(value.ToString()));
                    else
                        del.DynamicInvoke(Convert.ChangeType(value, del.Method.GetParameters()[0].ParameterType));

                    #region 更新数据库数据
                    lock (lockChange)
                    {
                        //LogHelper.WriteLog("I0001-Key[" + key + "]Value[" + value + "]ValueType[" + value.GetType() + "]psTAList.Count[" + psTAList.Count + "]");
                        List<BaseTempAreaModel> psTAList = bll.GetTempAreaList(new BaseTempAreaModel() { ta_areaID = (int)EDAEnums.TempArea.PartStore });
                        bool reloadFlag = false;
                        foreach (var model in psTAList)
                        {
                            if (model.ta_opcStoreI.Equals(key))
                            {
                                bool bVal = (bool)value;
                                if (!bVal && model.ta_status != (int)EDAEnums.PutStatus.Deposit)//如果存放点变为了0,但数据库里数据不为存放则改为存放
                                {
                                    model.ta_status = (int)EDAEnums.PutStatus.Deposit;
                                    int i = bll.EditTempArea(model);
                                    reloadFlag = true;
                                    //LogHelper.WriteLog("I0004-[" + model.ta_ID + "]改为存放,受影响行数[" + i + "],追溯主表编号为[" + model.ta_curFmGuid + "]");
                                }
                                else if (bVal && model.ta_status != (int)EDAEnums.PutStatus.Null)//如果存放点变为了1,但数据库里数据不为未存放则改为未存放
                                {
                                    model.ta_status = (int)EDAEnums.PutStatus.Null;
                                    model.ta_curFmGuid = null;
                                    model.ta_planGuid = null;
                                    model.ta_curSysProdNo = null;
                                    int i = bll.EditTempArea(model);
                                    //LogHelper.WriteLog("I0005-[" + model.ta_ID + "]改为未存放,受影响行数[" + i + "]");
                                    reloadFlag = true;
                                }
                                else
                                {
                                    //LogHelper.WriteLog("I0003-变更值[" + value + "]存放点位[" + model.ta_opcStoreI + "]存放状态[" + model.ta_status + "]");
                                }
                                break;
                            }
                        }
                        //LogHelper.WriteLog("I0002-Key[" + key + "]Value[" + value + "]ValueType[" + value.GetType() + "]psTAList.Count[" + psTAList.Count + "]刷新标识为[" + reloadFlag + "]");
                        if (reloadFlag)//传值
                        {
                            foreach (var socket in allSockets.ToList())
                            {
                                socket.Send("RELOAD");
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("初始化注册[" + key + "]失败：" + ex.ToString(), ex);
            }
        }

        private void Register<T>(string key, Action<T> handler)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (this.DesignMode) return;
            dicMap[key] = handler;
            if (typeof(T) == typeof(bool))
                dicBool[key] = handler;
            else if (typeof(T) == typeof(double) || typeof(T) == typeof(float) || typeof(T) == typeof(long) || typeof(T) == typeof(int) || typeof(T) == typeof(short))
                dicDouble[key] = handler;
            else
                LogHelper.WriteLog(string.Format("数据分组失败 key={0} TT is :{1}", key, typeof(T).Name));
        }
    }
}
