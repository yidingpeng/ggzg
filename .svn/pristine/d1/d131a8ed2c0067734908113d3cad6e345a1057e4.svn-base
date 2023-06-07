using OPCAutomation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace RW.PMS.WebSocketWinService.Driver
{
    public delegate void ValueChangeHandler(string key, object value);
    public delegate void AsyncWriteHandler(int TransactionID, int NumItems, string[] keys, int[] errors);
    public delegate void AsyncReadHandler(int TransactionID, int NumItems, string[] keys, object[] values, int[] qualities, DateTime[] TimeStamps, int[] Errors);

    /// <summary>
    /// OPC驱动类
    /// </summary>
    public class OPCDriver : Component, IDisposable
    {
        #region 属性
        /// <summary>
        /// OPC服务
        /// </summary>
        public OPCServer Server { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        OPCGroup Group { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, OPCItem> dicKeyItem = new Dictionary<string, OPCItem>();

        /// <summary>
        /// 
        /// </summary>
        Dictionary<int, string> dicIndexKey = new Dictionary<int, string>();

        /// <summary>
        /// 用于储存最新的数据，不会每次读取OPC，减少IO
        /// </summary>
        Dictionary<string, object> dicKeyValue = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        object dicLock = new object();

        /// <summary>
        /// 
        /// </summary>
        int clientIndex = 0;

        string serverName = "KEPware.KEPServerEx.V4";
        /// <summary>
        /// OPC服务名称
        /// </summary>
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// 外部的IP地址，为空表示为本地连接。
        /// </summary>
        public string IP { get; set; }

        public object this[string key]
        {
            get { return this.Read(key); }
            set { this.Write(key, value); }
        }

        public event ValueChangeHandler ValueChanged;
        public event AsyncWriteHandler AsyncWriteComplete;
        public event AsyncReadHandler AsyncReadComplete;
        public event EventHandler Connected;

        #endregion

        #region 构造函数
        public OPCDriver()
        {

        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="autoConnect">自动连接标识</param>
        public OPCDriver(bool autoConnect)
        {
            if (autoConnect)
            {
                Connect();
            }
        }
        public OPCDriver(string serverName)
        {
            this.ServerName = serverName;
        }

        public OPCDriver(string serverName, string prefix)
        {
            this.ServerName = serverName;
            this.Prefix = prefix;
        }

        public OPCDriver(string serverName, string prefix, string ip)
        {
            this.ServerName = serverName;
            this.Prefix = prefix;
            this.IP = ip;
        }
        #endregion

        #region 事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Reason"></param>
        private void Server_ServerShutDown(string Reason)
        {
            Debug.WriteLine("================================" + Reason + Server.ServerState.ToString() + "==============");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientIndexList"></param>
        /// <param name="ItemValueList"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        private void KepGroup_DataChange(int TransactionID, int NumItems, ref Array ClientIndexList, ref Array ItemValueList, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                int index = Convert.ToInt32(ClientIndexList.GetValue(i));
                object value = ItemValueList.GetValue(i);
                string key = "";
                if (dicIndexKey.ContainsKey(index))
                {
                    key = dicIndexKey[index];
                    dicKeyValue[key] = value;
                }
                if (ValueChanged != null)
                {
                    ThreadPool.QueueUserWorkItem(delegate
                    {
                        try
                        {
                            ValueChanged(key, value);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    });
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientIndexList"></param>
        /// <param name="ItemValueList"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        /// <param name="Errors"></param>
        private void Group_AsyncReadComplete(int TransactionID, int NumItems, ref Array ClientIndexList, ref Array ItemValueList, ref Array Qualities, ref Array TimeStamps, ref Array Errors)
        {
            string[] keyList = new string[ClientIndexList.Length];
            for (int i = 0; i < ClientIndexList.Length; i++)
                keyList[i] = dicIndexKey[Convert.ToInt32(ClientIndexList.GetValue(i + 1))];
            object[] valueList = new object[ItemValueList.Length];
            Array.Copy(ItemValueList, 1, valueList, 0, valueList.Length);
            int[] qualities = new int[Qualities.Length];
            Array.Copy(Qualities, 1, qualities, 0, qualities.Length);
            DateTime[] times = new DateTime[TimeStamps.Length];
            Array.Copy(TimeStamps, 1, times, 0, times.Length);
            int[] errors = new int[Errors.Length];
            Array.Copy(Errors, 1, errors, 0, errors.Length);
            if (AsyncReadComplete != null) AsyncReadComplete(TransactionID, NumItems, keyList, valueList, qualities, times, errors);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="Errors"></param>
        private void Group_AsyncWriteComplete(int TransactionID, int NumItems, ref Array ClientHandles, ref Array Errors)
        {
            string[] keys = new string[ClientHandles.Length];
            for (int i = 0; i < ClientHandles.Length; i++)
                keys[i] = dicIndexKey[Convert.ToInt32(ClientHandles.GetValue(i + 1))];
            int[] errors = new int[Errors.Length];
            Array.Copy(Errors, 1, errors, 0, errors.Length);
            if (AsyncWriteComplete != null) AsyncWriteComplete(TransactionID, NumItems, keys, errors);
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitItem()
        {
            Group = Server.OPCGroups.Add("AO");
            Group.IsSubscribed = true;
            Group.IsActive = true;
            Group.UpdateRate = 50;
            Group.DataChange += new DIOPCGroupEvent_DataChangeEventHandler(KepGroup_DataChange);
            Group.AsyncReadComplete += new DIOPCGroupEvent_AsyncReadCompleteEventHandler(Group_AsyncReadComplete);
            Group.AsyncWriteComplete += new DIOPCGroupEvent_AsyncWriteCompleteEventHandler(Group_AsyncWriteComplete);
        }
        #endregion

        #region 连接

        /// <summary>
        /// 连接
        /// </summary>
        public void Connect()
        {
            if (Server != null && Server.ServerState == (int)OPCServerState.OPCRunning)
                throw new COMException("OPCServer is Connected.");
            try
            {
                Server = new OPCServer();
                Server.OPCGroups.DefaultGroupIsActive = true;
                Server.OPCGroups.DefaultGroupUpdateRate = 50;
                Server.Connect(ServerName, IP);
                Server.ServerShutDown += new DIOPCServerEvent_ServerShutDownEventHandler(Server_ServerShutDown);
                if (Server.ServerState == (int)OPCServerState.OPCRunning)
                {
                    InitItem();
                    if (Connected != null)
                        Connected(this, EventArgs.Empty);
                }
                else
                {
                    Debug.WriteLine("连接失败：" + Server.ServerState);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("=============================================");
                Debug.WriteLine(ex.ToString());
                throw ex;
            }
        }
        #endregion

        #region 操作

        /// <summary>
        /// 获取OPCItem
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private OPCItem GetOrAddItem(string key)
        {
            if (Server == null || Group == null)
            {
                Debug.WriteLine("Server:" + Server);
                throw new NullReferenceException("没有连接OPC");
            }
            if (string.IsNullOrEmpty(key)) return null;

            if (!dicKeyItem.ContainsKey(key))//单例模型，多线程互锁问题。多线程同一个key进入会导致添加相同key
            {
                lock (dicLock)
                {
                    if (!dicKeyItem.ContainsKey(key))
                    {
                        string fullKey = this.Prefix + key;
                        OPCItem opcItem = Group.OPCItems.AddItem(fullKey, clientIndex);
                        dicKeyItem.Add(key, opcItem);
                        dicIndexKey.Add(clientIndex, key);
                        clientIndex++;
                    }
                }
            }
            return dicKeyItem[key];
        }

        /// <summary>
        /// 读
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Read(string key)
        {
            object value = GetOrAddItem(key).Value;
            Debug.WriteLine("read item [" + key + "]:[" + value + "]");
            return value;
        }

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Write(string key, object value)
        {
            Debug.WriteLine("write item [" + key + "]:[" + value + "]");
            OPCItem item = GetOrAddItem(key);
            item.Write(value);
        }

        /// <summary>
        /// 判断指定的点位的通讯质量是否正常
        /// </summary>
        /// <param name="key">指定的点位名称</param>
        /// <returns>通讯是否正常</returns>
        public bool IsGood(string key)
        {
            OPCItem item = GetOrAddItem(key);//判断指定的点位的通讯质量是否正常
            return item.Quality == 192;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            try
            {
                if (Group != null)
                    Group.DataChange -= KepGroup_DataChange;

                if (Server != null && Server.ServerState != (int)OPCServerState.OPCDisconnected)
                    Server.Disconnect();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        #endregion

        #region IDisposable 成员

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #endregion
    }
}
