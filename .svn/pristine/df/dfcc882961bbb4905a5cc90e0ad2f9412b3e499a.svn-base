using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using RW.Modules;
using RW.Proceduce.Result;

namespace RW.Proceduce
{
    public delegate bool TickHandler(object sender, int tick);
    public delegate bool DefaultHandler(int tick);
    /// <summary>
    /// 所有处理过程的基类，通过调用Execute执行
    /// 根据先后顺序触发，before，ing，end事件 修改与2016-10-19
    /// </summary>
    public class BaseProcedure : System.ComponentModel.Component, IProcedure
    {
        private BaseTestBed testBed1;

        public virtual BaseTestBed TestBed
        {
            get { return testBed1; }
            set { testBed1 = value; }
        }

        public BaseProcedure()
        {
        }

        public event EventHandler BeforeExecute;
        public event EventHandler Executing;
        public event EventHandler EndExecuted;
        public event TickHandler Ticked;

        private string model;
        /// <summary>
        /// 被试品型号
        /// </summary>
        [DefaultValue(null)]
        [Description("被试品型号")]
        public virtual string Model
        {
            get { return model; }
            set { model = value; }
        }

        /// <summary>
        /// 按照一定间隔一段时间，并且每次间隔执行一个方法
        /// </summary>
        /// <param name="milliseconds">总时长</param>
        /// <param name="interval">间隔</param>
        /// <param name="del">需要委托执行的方法</param>
        /// <returns></returns>
        protected bool OnTicked(double milliseconds, int interval, DefaultHandler del)
        {
            int t = 0;
            while ((t += interval) <= milliseconds && Testing && del(t))
            {
                if (Ticked != null && !Ticked(this, t))
                    return false;
                Thread.Sleep(interval);
            }
            return Testing && t <= milliseconds;
        }

        protected bool OnTicked(TimeSpan ts, int interval, DefaultHandler del)
        {
            return OnTicked(ts.TotalMilliseconds, interval, del);
        }

        protected bool OnTicked(double milliseconds)
        {
            return OnTicked(milliseconds, 1000, delegate { return true; });
        }

        protected bool OnTicked(double milliseconds, DefaultHandler del)
        {
            return OnTicked(milliseconds, 1000, del);
        }

        protected bool OnTicked(double milliseconds, int interval)
        {
            return OnTicked(milliseconds, interval, delegate { return true; });
        }

        public virtual void Execute()
        {
            StartExecute();
            Debug.WriteLine("准备开始试验：" + this.GetType().Name);
            OnBeforeExecute();
            Debug.WriteLine("试验中：" + this.GetType().Name);
            OnExecuting();
            Debug.WriteLine("试验结束：" + this.GetType().Name);
            OnEndExecute();
            StopExecute();
            Debug.WriteLine("完成试验");
        }

        public virtual void StartExecute()
        {
            Testing = true;
        }

        public virtual void StopExecute()
        {
            Testing = false;
        }

        private bool testing;

        public bool Testing
        {
            get { return testing; }
            set
            {
                testing = value;
                onTestingChange(value);
            }
        }

        protected virtual void OnBeforeExecute()
        {
            if (BeforeExecute != null && Testing) BeforeExecute(this, EventArgs.Empty);
        }
        protected virtual void OnExecuting()
        {
            if (Executing != null && Testing) Executing(this, EventArgs.Empty);
        }
        protected virtual void OnEndExecute()
        {
            if (EndExecuted != null && Testing) EndExecuted(this, EventArgs.Empty);
        }

        protected virtual void onTestingChange(bool value)
        {
            if (TestChanged != null) TestChanged(value);
        }

        public delegate void TestChangedHandler(bool value);
        public event TestChangedHandler TestChanged;

        public virtual BaseResult Collect()
        {
            return null;
        }


        protected virtual void AsyncTime(int ms, WaitCallback wait)
        {
            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                Thread.Sleep(ms);
                wait(state);
            });
        }
    }
}
