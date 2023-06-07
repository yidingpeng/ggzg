using RW.PMS.Utils.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace RW.PMS.Utils.Modules
{
    /// <summary>
    /// 基础单元
    /// </summary>
    public class BaseModule : Component, ISupportInitialize, IInit, IDigitalValueEvent, IAnalogValueEvent
    {
        protected Dictionary<string, Delegate> dicMap = new Dictionary<string, Delegate>();
        private Dictionary<string, Delegate> dicBool = new Dictionary<string, Delegate>();
        private Dictionary<string, Delegate> dicDouble = new Dictionary<string, Delegate>();
        public event EventHandler<ExceptionEventArgs> InitError;
        public event ValueGroupHandler<bool> DigitalValueChanged;
        public event ValueGroupHandler<double> AnalogValueChanged;
        public delegate bool RightHandler();

        /// <summary>
        /// 虚方法 提供给子类实现用 可重载可不重载
        /// </summary>
        protected virtual void InitComponts() { }

        /// <summary>
        /// 驱动
        /// </summary>
        private IDriver driver = null;

        /// <summary>
        /// OPC驱动
        /// </summary>
        protected virtual IDriver Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        /// <summary>
        /// 根据Key获取值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual object this[string key]
        {
            get { return Driver[key]; }
            set { Driver[key] = value; }
        }

        private bool autoInit = false;
        [DefaultValue(false)]
        [Description("是否自动初始化OPC，还是手动初始化")]
        public virtual bool AutoInit
        {
            get { return autoInit; }
            set { autoInit = value; }
        }

        private bool inited;

        /// <summary>
        /// 是否已经调用了初始化
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsInitialized
        {
            get { return inited; }
            private set { inited = value; }
        }

        #region 构造函数
        public BaseModule() { }

        public BaseModule(IContainer container)
        {
            container.Add(this);
        }

        #endregion

        #region 析构函数
        /// <summary>
        /// 析构函数
        /// </summary>
        ~BaseModule()
        {
            try
            {
                if (Driver != null)
                    Driver.ValueChanged -= BaseValueChange;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {
            if (this.DesignMode) return;//设计模式直接返回
            if (IsInitialized) return;//已调用过初始化直接返回
            if (Driver == null) return;//throw new NullReferenceException("The driver is not specified.");//驱动为空直接抛出异常

            string error = string.Empty;

            Driver.ValueChanged += BaseValueChange;
            foreach (KeyValuePair<string, Delegate> item in dicMap)
            {
                try
                {
                    object value = Driver[item.Key];
                    //if (value == null) throw new Exception("驱动中不包含[" + item.Key + "]");
                    BaseValueChange(item.Key, value, item.Value);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Equals("异常来自 HRESULT:0xC0040007"))
                        error += "OPC初始化异常,请检查OPC点位配置!" +item.Key+ Environment.NewLine;
                    else
                        error += "Init items error.[" + item.Key + "]" + ex.Message + Environment.NewLine;
                }
            }

            IsInitialized = true;

            if (!string.IsNullOrEmpty(error))
            {
                throw new Exception(error);
            }
        }

        /// <summary>
        /// 值变事件
        /// </summary>
        /// <param name="key2"></param>
        /// <param name="value"></param>
        protected void BaseValueChange(string key2, object value)
        {
            BaseValueChange(key2, value, dicMap.ContainsKey(key2) ? dicMap[key2] : null);
        }

        /// <summary>
        /// 值变事件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="del"></param>
        protected void BaseValueChange(string key, object value, Delegate del)
        {
            if (this.DesignMode) return;
            if (value == null) return;
            try
            {
                if (dicMap.ContainsKey(key) && del != null)
                {
                    if (value.GetType() == typeof(byte))//byte转bool
                        del.DynamicInvoke(Convert.ToBoolean(value));
                    else if (value.GetType() == typeof(float) && del.Method.GetParameters()[0].ParameterType == typeof(double))//float转double
                        del.DynamicInvoke(Convert.ToDouble(value.ToString()));
                    else
                        del.DynamicInvoke(Convert.ChangeType(value, del.Method.GetParameters()[0].ParameterType));
                }

                if (dicBool.ContainsKey(key))
                {
                    int i = 0;
                    foreach (KeyValuePair<string, Delegate> item in dicBool)
                    {
                        if (item.Key == key)
                        {
                            break;
                        }
                        i++;
                    }
                    this.OnDigitalValueChanged(i, Convert.ToBoolean(value));
                }
                else if (dicDouble.ContainsKey(key))
                {
                    int i = 0;
                    foreach (KeyValuePair<string, Delegate> item in dicDouble)
                    {
                        if (item.Key == key) break;
                        i++;
                    }
                    this.OnAnalogValueChanged(i, Convert.ToDouble(value.ToString()));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("初始化注册[" + key + "]失败：" + ex.ToString());
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// 注册，并数据分组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        protected virtual void Register<T>(string key, Action<T> handler)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (this.DesignMode) return;
            dicMap[key] = handler;
            if (typeof(T) == typeof(bool))
            {
                dicBool[key] = handler;
            }
            else if (typeof(T) == typeof(double) || typeof(T) == typeof(float) || typeof(T) == typeof(long) || typeof(T) == typeof(int) || typeof(T) == typeof(short) || typeof(T) == typeof(string))
            {
                dicDouble[key] = handler;
            }
            else
            {
                Debug.WriteLine(string.Format("数据分组失败 key={0} TT is :{1}", key, typeof(T).Name));
            }
        }

        /// <summary>
        /// 取消注册
        /// </summary>
        /// <param name="key"></param>
        protected virtual void UnRegister(string key)
        {
            if (this.DesignMode) return;
            if (key != null && dicMap.ContainsKey(key))
            {
                dicMap.Remove(key);
            }
        }

        /// <summary>
        /// 写值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public virtual void Write(string key, object value)
        {
            this.Write(key, value, key, 3000);
        }

        public virtual void Write(string key, object value, string diKey, int timeout)
        {
            this.Write(key, value, diKey, value, timeout);
        }

        public virtual void Write(string key, object value, string diKey, object diValue, int timeout)
        {
            if (value is ValueType && !(value is bool) || value is Array)
                this.Write(key, value, delegate { return true; }, 0);
            else
                this.Write(key, value, delegate { return diValue.Equals(Driver[diKey]); }, timeout);
        }

        public virtual void Write(string key, object value, RightHandler trueHandler, int timeout)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (this.DesignMode) return;
            Driver[key] = value;
            if (trueHandler != null)
                WaitSetting(trueHandler, timeout);
        }

        /// <summary>
        /// 检测某个开关是否打开，并设置其超时时间
        /// </summary>
        /// <param name="trueHandler">待检测的条件，返回bool</param>
        /// <param name="timeout">超时时间（毫秒）</param>
        /// <returns></returns>
        public static bool WaitSetting(RightHandler trueHandler, int timeout)
        {
            bool b = true;
            if (!trueHandler())
            {
                AutoResetEvent auto = new AutoResetEvent(false);
                ThreadPool.QueueUserWorkItem(delegate
                {
                    while (!trueHandler() && b) Thread.Sleep(50);
                    auto.Set();
                });
                b = auto.WaitOne(timeout);
            }
            if (b == false)
                throw new TimeoutException();
            return b == true;
        }

        /// <summary>
        /// 脉冲写
        /// </summary>
        /// <param name="key"></param>
        public void PluseWrite(string key)
        {
            this.PluseWrite(key, 0);
        }

        public void PluseWrite(string key, int sleep)
        {
            this.Write(key, false);
            this.Write(key, true);
            Thread.Sleep(sleep);
            this.Write(key, false);
        }

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual object Read(string key)
        {
            try
            {
                if (this.DesignMode) return null;
                return Driver[key];
            }
            catch
            {
                return null;
            }
        }

        #region ISupportInitialize 成员

        public virtual void BeginInit() { }

        public virtual void EndInit()
        {
            //若当前为设计模式则返回
            if (this.DesignMode) return;
            //若自动初始化标识为真，则自动初始化
            if (AutoInit)
            {
                //若驱动程序不为空则委托BaseValueChange值变函数
                if (Driver != null)
                    Driver.ValueChanged += BaseValueChange;
                try
                {
                    Init();//初始化
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("=====-----=====-----=====-----=====");
                    Debug.WriteLine(ex.ToString());
                    if (InitError != null)
                        InitError(this, new ExceptionEventArgs(ex));
                    else
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        #endregion

        protected virtual void OnDigitalValueChanged(int index, bool value)
        {
            if (DigitalValueChanged != null) DigitalValueChanged(this, index, value);
        }

        protected virtual void OnAnalogValueChanged(int index, double value)
        {
            if (AnalogValueChanged != null) AnalogValueChanged(this, index, value);
        }
    }
}
