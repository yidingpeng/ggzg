using System;
using System.Collections.Generic;
using System.Text;
using RW.PMS.Utils.Configuration;

namespace RW.PMS.Utils.Modules
{
    /// <summary>
    /// 用于描述支持零点增益的硬件模块
    /// </summary>
    public class Hardware : IniConfig, IHardware
    {
        public virtual event ValueHandler GainValueChanged;
        public virtual event ValueHandler ZeroValueChanged;
        public virtual event ValueHandler ValueChanged;
        public virtual event ValueHandler BaseValueChanged;
        public virtual event ValueHandler<int> RadixValueChanged;

        private double valueBase;
        /// <summary>
        /// 工程量数字
        /// </summary>
        public virtual double ValueBase
        {
            get { return valueBase / Math.Pow(10, this.Radix); }
            set
            {
                valueBase = value;
                if (BaseValueChanged != null)
                    BaseValueChanged(this, this.ValueBase);
                SetActual();
            }
        }

        private double _value;
        /// <summary>
        /// 实际值
        /// </summary>
        public virtual double Value
        {
            get { return _value; }
            protected set
            {
                _value = value;
                if (ValueChanged != null)
                    ValueChanged(this, value);
            }
        }

        private bool setLocal = true;
        /// <summary>
        /// 由本地计算实际值还是由设备本身计算后返回
        /// </summary>
        public bool SetLocal
        {
            get { return setLocal; }
            set { setLocal = value; }
        }


        protected virtual void SetActual()
        {
            if (SetLocal)
                Value = ValueBase * GainValue - ZeroValue;
            else
                Value = ValueBase;
        }

        private double GetActual()
        {
            return Value;
        }

        private double gainValue = 1;
        /// <summary>
        /// 增益值
        /// </summary>
        public virtual double GainValue
        {
            get { return gainValue; }
            set
            {
                gainValue = value;
                if (GainValueChanged != null)
                    GainValueChanged(this, value);
                SetActual();
            }
        }

        private double zeroValue;
        /// <summary>
        /// 零点值
        /// </summary>
        public virtual double ZeroValue
        {
            get { return zeroValue; }
            set
            {
                zeroValue = value;
                if (ZeroValueChanged != null)
                    ZeroValueChanged(this, value);
                SetActual();
            }
        }

        private int radix;
        /// <summary>
        /// 小数点位数，默认为0
        /// </summary>
        public virtual int Radix
        {
            get { return radix; }
            set
            {
                radix = value;
                if (RadixValueChanged != null)
                    RadixValueChanged(this, value);
                SetActual();
            }
        }

        #region IHardware 成员

        private int index;
        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format("{Value:{0},ValueBase:{1},GainValue:{2},ZeroValue:{3},Radix:{4}}", Value, ValueBase, GainValue, ZeroValue);
            //return base.ToString();
        }
    }

    [Obsolete("由于命名的问题，请使用Hardware，而不是HardWare")]
    public class HardWare : Hardware
    {
    }
}
