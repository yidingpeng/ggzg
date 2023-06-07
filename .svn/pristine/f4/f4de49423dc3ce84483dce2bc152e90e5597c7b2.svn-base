using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.PMS.Utils.Modules
{

    public class BaseSensorArray : BaseModule, IHardwareArray
    {
        public BaseSensorArray() { }

        public BaseSensorArray(IContainer contianer) : base(contianer) { }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get { return Hardwares.Count; } }

        public virtual double this[int index] { get { return Hardwares[index]; } }

        private HardwareList hardwares = new HardwareList();
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HardwareList Hardwares { get { return hardwares; } }

        public virtual double GetMapedValue(int index)
        {
            return this.Hardwares[index];
        }

        public override void Init()
        {
            Hardwares.ValuesChanged += delegate(object sender, double[] value)
            {
                OnValueGroupChanged(value);
            };
            Hardwares.GainsChanged += delegate(object sender, double[] value)
            {
                OnGainValueGroupChanged(value);
            };
            Hardwares.ZerosChanged += delegate(object sender, double[] value)
            {
                OnZeroValueGroupChanged( value);
            };

            base.Init();
        }

        protected virtual void OnValueGroupChanged(double[] value)
        {
            if (ValuesChanged != null) ValuesChanged(this, value);
        }

        protected virtual void OnGainValueGroupChanged(double[] value)
        {
            if (GainValuesChanged != null) GainValuesChanged(this, value);
        }

        protected virtual void OnZeroValueGroupChanged(double[] value)
        {
            if (ZeroValuesChanged != null) ZeroValuesChanged(this, value);
        }

        public virtual double GetGainValue(int index)
        {
            return Hardwares.GainValues[index];
        }

        public virtual double GetZeroValue(int index)
        {
            return Hardwares.ZeroValues[index];
        }




        #region IHardwareGroup 成员

        public event ValueListHandler ValuesChanged;
        public event ValueListHandler GainValuesChanged;
        public event ValueListHandler ZeroValuesChanged;

        #endregion
    }
}
