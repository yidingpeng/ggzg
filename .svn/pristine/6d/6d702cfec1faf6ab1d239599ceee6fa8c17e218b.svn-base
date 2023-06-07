using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Modules
{

    /// <summary>
    /// 主要针对数据对象创建如果包含类似400001[6]或VD100[6]的情况时，可以使用该类
    /// </summary>
    public class HardwareList
    {
        private int count;
        public int Count { get { return count; } private set{ count = value;} }

        public double this[int index]
        {
            get
            {
                if (index + 1 > Count) return 0;
                return this.Values[index];
            }
            private set { this.Values[index] = value; }
        }

        private double[] values = null;
        public double[] Values { get { return values; } protected set { values = value; this.Count = values.Length; OnValuesChanged(value); } }

        private double[] baseValues = null;
        public double[] BaseValues { get { return baseValues; } set { baseValues = value; OnBaseValuesChanged(value); SetValues(); } }
        private double[] gainValues = null;
        public double[] GainValues { get { return gainValues; } set { gainValues = value; OnGainValuesChanged(value); SetValues(); } }
        private double[] zeroValues = null;
        public double[] ZeroValues { get { return zeroValues; } set { zeroValues = value; OnZeroValuesChanged(value); SetValues(); } }

        public event ValueListHandler BaseValuesChanged;
        public event ValueListHandler ValuesChanged;
        public event ValueListHandler GainsChanged;
        public event ValueListHandler ZerosChanged;

        protected virtual void SetValues()
        {
            if (GainValues == null && BaseValues != null) GainValues = new double[BaseValues.Length];
            if (ZeroValues == null && BaseValues != null) ZeroValues = new double[BaseValues.Length];
            if (BaseValues == null) return;
            double[] values = new double[BaseValues.Length]; ;
            for (int i = 0; i < BaseValues.Length; i++)
            {
                values[i] = BaseValues[i] * GainValues[i] - ZeroValues[i];
            }
            this.Values = values;
        }

        protected virtual void OnBaseValuesChanged(double[] values)
        {
            if (BaseValuesChanged != null) BaseValuesChanged(this, values);
        }

        protected virtual void OnValuesChanged(double[] values)
        {
            if (ValuesChanged != null) ValuesChanged(this, values);
        }

        protected virtual void OnGainValuesChanged(double[] values)
        {
            if (GainsChanged != null) GainsChanged(this, values);
        }

        protected virtual void OnZeroValuesChanged(double[] values)
        {
            if (ZerosChanged != null) ZerosChanged(this, values);
        }
    }
}
