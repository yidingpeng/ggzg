using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.PMS.Utils.Modules
{

    public class BaseAnalogGroup : BaseInput
    {
        public BaseAnalogGroup() { }
        public BaseAnalogGroup(IContainer contianer) : base(contianer) { }

        private int valueStart;

        /// <summary>
        /// 值的起始地址
        /// </summary>
        [DefaultValue(0)]
        public virtual int ValueStart { get { return valueStart; } set { valueStart = value; } }

        private int zeroStart;
        /// <summary>
        /// 零点的起始地址
        /// </summary>
        [DefaultValue(0)]
        public virtual int ZeroStart { get { return zeroStart; } set { zeroStart = value; } }

        private int gainStart;
        /// <summary>
        /// 增益的起始地址
        /// </summary>
        [DefaultValue(0)]
        public virtual int GainStart { get { return gainStart; } set { gainStart = value; } }

        public override double this[int index] { get { return Convert.ToDouble(this[GetFullKey(ValueStart, index)]); } }

        public override void Add(int index)
        {
            string valueKey = GetFullKey(ValueStart, index);
            string gainKey = GetFullKey(GainStart, index);
            string zeroKey = GetFullKey(ZeroStart, index);

            this.Register<double>(valueKey, delegate(double value)
            {
                OnValueGroupChanged(index, value);
            });
            this.Register<double>(gainKey, delegate(double value)
            {
                OnGainValueGroupChanged(index, value);
            });
            this.Register<double>(zeroKey, delegate(double value)
            {
                OnZeroValueGroupChanged(index, value);
            });
            base.Add(index);
        }

        public void SetGain(int index, double value)
        {
            this.Write(GetFullKey(GainStart, index), value);
        }

        public void SetZero(int index, double value)
        {
            this.Write(GetFullKey(ZeroStart, index), value);
        }

        public virtual void Submit(int index, double gain, double zero)
        {
            string gainKey = GetFullKey(GainStart, index);
            string zeroKey = GetFullKey(ZeroStart, index);

            this.Write(gainKey, gain);
            this.Write(zeroKey, zero);
        }
    }
}
