using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.PMS.Utils.Modules
{

    public class BaseSensorGroup : BaseAnalogGroup, IHardwareGroup, IIndexes
    {
        public BaseSensorGroup() { }

        public BaseSensorGroup(IContainer contianer) : base(contianer) { }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get { return Hardwares.Count; } }

        public override double this[int index]
        {
            get
            {
                if (mapped == null)
                    return Hardwares[index].Value;
                return Hardwares[mapped[index]].Value;
            }
        }

        private HardwareGroup hardwares = new HardwareGroup();
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual HardwareGroup Hardwares { get { return hardwares; } }

        private int[] mapped = null;
        /// <summary>
        /// 映射的索引，与Hardwares的index对应。
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual int[] MappedHardware { get { return mapped; } protected set { mapped = value; } }

        public virtual double GetMapedValue(int index)
        {
            return this.Hardwares[this.MappedHardware[index]].Value;
        }

        public override void Init()
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (Hardwares[i] != null)
                {
                    int temp = i;

                    Hardwares[temp].ValueChanged += delegate(object sender, double value)
                    {
                        OnValueGroupChanged(temp, value);
                    };
                    Hardwares[temp].GainValueChanged += delegate(object sender, double value)
                    {
                        OnGainValueGroupChanged(temp, value);
                    };
                    Hardwares[temp].ZeroValueChanged += delegate(object sender, double value)
                    {
                        OnZeroValueGroupChanged(temp, value);
                    };
                }
            }
            base.Init();
        }

        public void InitHardware(Hardware[] hardwares)
        {
            this.Hardwares.Clear();
            this.Hardwares.AddRange(hardwares);
            mapped = new int[hardwares.Length];
        }

        protected virtual void OnIndexGroupChanged(int index, int value)
        {
            if (IndexGroupChanged != null) IndexGroupChanged(this, index, value);
        }

        public override double GetGainValue(int index)
        {
            return Hardwares[index].GainValue;
        }

        public override double GetZeroValue(int index)
        {
            return Hardwares[index].ZeroValue;
        }




        #region IHardwareGroup 成员

        public event ValueGroupHandler<int> IndexGroupChanged;

        #endregion
    }
}
