using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

namespace RW.PMS.Utils.Modules
{
    /// <summary>
    /// 试验台基类，包含急停
    /// </summary>
    public class BaseTestBed : BaseModule
    {

        public BaseTestBed() { }

        public BaseTestBed(IContainer contianer) : base(contianer) { }

        public override void Init()
        {
            this.Register<bool>(ScramKey, OnScramChanged);
            base.Init();
        }

        //[Description("急停时触发该事件")]
        //public event ValueHandler<bool> Scramed;
        [Description("急停状态发生改变时触发该事件")]
        public event ValueHandler<bool> ScramChanged;

        protected virtual void OnScramChanged(bool value)
        {
            this.scram = value;
            if (ScramChanged != null) ScramChanged(this, value);
        }

        private bool scram;
        [Description("是否急停")]
        [DefaultValue(false)]
        public bool Scram { get { return scram; } protected set { scram = value; } }

        private string scramKey;
        [Description("急停所用的Key")]
        [DefaultValue(null)]
        public string ScramKey
        {
            get { return scramKey; }
            set { scramKey = value; }
        }
    }
}
