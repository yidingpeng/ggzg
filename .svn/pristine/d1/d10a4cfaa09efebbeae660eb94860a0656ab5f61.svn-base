using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using RW.Modules;

namespace RW.Driver
{

    //public delegate void PCIValueChanged(object sender, int index, double value);
    /// <summary>
    /// 暂时未完成实现
    /// </summary>
    public class PCIDriver : Component, ISupportInitialize, IDriver
    {
        //float[][] values = new float[32][];

        double[] values = new double[32];
        public event ValueGroupHandler ValueChanged;
        public event CollectHandler Collected;
        //private WaveformAiCtrl ai;
        //[DefaultValue(null)]
        //public WaveformAiCtrl AI
        //{
        //    get { return ai; }
        //    set { ai = value; }
        //}


        public PCIDriver()
        {
            this.ValueChanged += new ValueGroupHandler(PCIDriver_ValueChanged);
        }

        /// <summary>
        /// 获取某个通道的最新值
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                return values[index];
            }
            private set
            {
                values[index] = value;
                if (this.ValueChanged != null)
                {
                    ValueChanged(this, index, value);
                }
            }
        }

        public double GetLatestValue(int chNo)
        {
            return this[chNo];
        }

        public double[] GetBufferedData(int chNo)
        {
            if (buffers.ContainsKey(chNo))
            {
                return buffers[chNo].ToArray();
            }
            else
            {
                return null;
            }
        }

        //private double[][] buffers = new double[32][];堆栈
        private Dictionary<int, List<double>> buffers = new Dictionary<int, List<double>>();



        private int channelCount;
        /// <summary>
        /// 获取或设置通道数
        /// </summary>
        [DefaultValue(0)]
        [Description("获取或设置通道数")]
        public int ChannelCount
        {
            get { return channelCount; }
            set { channelCount = value; }
        }

        private int deviceNumber;
        /// <summary>
        /// 设备地址ID
        /// </summary>
        [DefaultValue(0)]
        [Description("设备地址ID")]
        public int DeviceNumber
        {
            get { return deviceNumber; }
            set { deviceNumber = value; }
        }

        /// <summary>
        /// 频率
        /// </summary>
        public float Frequency
        {
            get { return 1 / 250 * this.ChannelCount; }
        }

        protected override void Dispose(bool disposing)
        {
            //ai.Stop();
            base.Dispose(disposing);
        }

        void PCIDriver_ValueChanged(object sender, int index, double value)
        {
            values[index] = value;
            //throw new Exception("The method or operation is not implemented.");
        }

        public void Start()
        {
            //if (ai != null)
            //    ai.Start();
        }

        public void Stop()
        {
            //if (ai != null)
            //    ai.Stop();
        }


        public void Init()
        {
            if (DesignMode)
                return;
            try
            {
                //ai.Conversion.ChannelCount = this.ChannelCount;
                //ai.Conversion.ChannelStart = 0;
                //ai.DataReady += new EventHandler<BfdAiEventArgs>(AI_DataReady);
                //ai.Prepare();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        ////double[] buffer = null;
        //void ai_Stopped(object sender, BfdAiEventArgs e)
        //{
        //    double[] buffer = new double[e.Count];
        //    ai.GetData(e.Count, buffer);
        //    //throw new Exception("The method or operation is not implemented.");
        //}

        //void AI_DataReady(object sender, BfdAiEventArgs e)
        //{
        //    double[] buffer = new double[e.Count];
        //    ErrorCode code = ai.GetData(e.Count, buffer);
        //    double[] avgs = new double[this.ChannelCount];
        //    for (int i = 0; i < e.Count; i++)
        //    {
        //        int chNo = i % this.ChannelCount;
        //        this[chNo] = buffer[i];
        //        avgs[chNo] += buffer[i];
        //        if (!buffers.ContainsKey(chNo) || buffers[chNo] == null)
        //            buffers[chNo] = new List<double>();
        //        buffers[chNo].Add(buffer[i]);
        //    }
        //    if (Collected != null)
        //    {
        //        for (int i = 0; i < this.ChannelCount; i++)
        //        {
        //            Collected(this, i, buffers[i].ToArray());
        //        }
        //    }
        //    //for (int i = 0; i < this.ChannelCount; i++)
        //    //{
        //    //    this[i] = avgs[i] / (e.Count / this.ChannelCount);
        //    //}
        //}

        #region ISupportInitialize 成员

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            Init();
        }

        #endregion

        #region IDriver 成员

        public string ServerName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public object Read(string key)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Write(string key, object value)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Connect()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Connect(string serverName)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public event EventHandler Connected;

        event ValueChangeHandler IDriver.ValueChanged
        {
            add { throw new Exception("The method or operation is not implemented."); }
            remove { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IDriver 成员


        public object this[string key]
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        #endregion

        #region IDriver 成员


        public void Close()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
