using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace RW.PMS.Utils.Modules
{
    [Obsolete("请使用BaseSensor类，该类已经弃用")]
    public class BaseReadModule : BaseModule, IComponent, IHardware
    {
        public BaseReadModule() { }

        public BaseReadModule(IContainer container) : base(container) { }

        public event EventHandler ChangedError;

        public virtual void OnValueChanged(double value) { if (ValueChanged != null) ValueChanged(this, value); }
        public virtual void OnGainValueChanged(double value) { if (GainValueChanged != null) GainValueChanged(this, value); }
        public virtual void OnZeroValueChanged(double value) { if (ZeroValueChanged != null) ZeroValueChanged(this, value); }
        public virtual void OnChangedError() { if (ChangedError != null) ChangedError(this, EventArgs.Empty); }

        public override void Init()
        {
            this.Register<double>(ReadKey, delegate(double value)
           {
               this.Value = value;
               OnValueChanged(value);
           });
            this.Register<double>(GainKey, delegate(double value)
            {
                gainValue = value;
                OnGainValueChanged(value);
            });
            this.Register<double>(ZeroKey, delegate(double value)
            {
                zeroValue = value;
                OnZeroValueChanged(value);
            });
            base.Init();
        }

        private string readKey;
        [Description("指定读取的OPC点变量名称")]
        [DefaultValue(null)]
        public virtual string ReadKey
        {
            get { return readKey; }
            set { readKey = value; }
        }

        private string gainKey;
        /// <summary>
        /// 增益值
        /// </summary>
        [Description("读取或写入OPC的增益值点")]
        [DefaultValue(null)]
        public virtual string GainKey
        {
            get { return gainKey; }
            set { gainKey = value; }
        }

        private string zeroKey;
        /// <summary>
        /// 零点值
        /// </summary>
        [Description("读取或写入OPC的零点值点")]
        [DefaultValue(null)]
        public virtual string ZeroKey
        {
            get { return zeroKey; }
            set { zeroKey = value; }
        }


        #region IGain 成员

        private double value;
        public virtual double Value
        {
            get { return value; }
            protected set { this.value = value; }
        }

        private double gainValue = 1d;
        [Description("增益值，实测值=传感器值*增益值-零点值")]
        [DefaultValue(1d)]
        public virtual double GainValue
        {
            get { return gainValue; }
            set { this.Write(gainKey, value); }
        }

        private double zeroValue;
        [Description("零点值,实测值=传感器值*增益值-零点值")]
        [DefaultValue(0d)]
        public virtual double ZeroValue
        {
            get { return zeroValue; }
            set { this.Write(zeroKey, value); }
        }

        public event ValueHandler ValueChanged;
        public event ValueHandler GainValueChanged;
        public event ValueHandler ZeroValueChanged;

        #endregion
    }
}
