using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.PMS.Utils.Modules
{
    public class BaseInput<T> : BaseModule, IIndexes<T>
    {
        public BaseInput() { }

        public BaseInput(IContainer contianer) : base(contianer) { }

        protected override void InitComponts()
        {
            this.DataLength = 4;
            base.InitComponts();
        }

        public virtual T this[int index] { get { throw new NotImplementedException("未实现索引器，无法获取值"); } }

        private string pre = "";
        [DefaultValue("")]
        public virtual string Pre { get { return pre; } set { pre = value; } }
        protected virtual string GetFullKey(int start, int index)
        {
            string key = string.Format(Pre == null ? pre : Pre, (start + index * DataLength).ToString());
            return key;
        }

        private int length;

        /// <summary>
        /// 数据长度
        /// </summary>
        [DefaultValue(4)]
        public virtual int DataLength { get { return length; } protected set { length = value; } }

        public virtual void Add(int index) { }

        protected virtual void OnValueGroupChanged(int index, T value)
        {
            if (ValueGroupChanged != null) ValueGroupChanged(this, index, value);
        }

        public event ValueGroupHandler<T> ValueGroupChanged;
    }

    public class BaseInput : BaseInput<double>, IAnalogGroup
    {
        public BaseInput() { }
        public BaseInput(IContainer contianer) : base(contianer) { }


        #region IAnalogGroup 成员

        public virtual double GetGainValue(int index)
        {
            throw new NotImplementedException();
        }

        public virtual double GetZeroValue(int index)
        {
            throw new NotImplementedException();
        }

        protected override void OnValueGroupChanged(int index, double value)
        {
            if (ValueGroupChanged != null) ValueGroupChanged(this, index, value);
        }

        protected virtual void OnGainValueGroupChanged(int index, double value)
        {
            if (GainValueGroupChanged != null) GainValueGroupChanged(this, index, value);
        }

        protected virtual void OnZeroValueGroupChanged(int index, double value)
        {
            if (ZeroValueGroupChanged != null) ZeroValueGroupChanged(this, index, value);
        }

        public new event ValueGroupHandler ValueGroupChanged;

        public event ValueGroupHandler GainValueGroupChanged;

        public event ValueGroupHandler ZeroValueGroupChanged;


        #endregion
    }

    public class BaseOutput : BaseAnalogGroup
    {
        public virtual void SetValue(int index, double value)
        {
            string valueKey = GetFullKey(this.ValueStart, index);
            this.Write(valueKey, value);
        }
    }
}
