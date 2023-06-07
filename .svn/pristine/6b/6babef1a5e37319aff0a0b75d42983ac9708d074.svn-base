using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.PMS.Utils.Modules
{

    public class BaseDigitalGroup : BaseInput<bool>, IDigitalGroup
    {
        public BaseDigitalGroup() { }
        public BaseDigitalGroup(IContainer contianer) : base(contianer) { }
        private int start;
        [DefaultValue(0)]
        public int Start { get { return start; } set { start = value; } }

        private int offset;
        [DefaultValue(0)]
        public int Offset { get { return offset; } set { offset = value; } }

        protected override string GetFullKey(int start, int index)
        {
            int a = (index - Offset) / 8;//8的倍数
            int b = (index - Offset) % 8;//8的余数
            string key = string.Format(Pre, start + a + "." + b);
            return key;
        }

        protected virtual string GetFullKey(int index)
        {
            return GetFullKey(this.Start, index);
        }

        public override bool this[int index]
        {
            get
            {
                return GetValue(index);
            }
        }

        public virtual bool GetValue(int index)
        {

            string key = GetFullKey(index);

            object value = Driver[key];

            return value is bool && Convert.ToBoolean(value);
        }

        public override void Add(int index)
        {
            string key = GetFullKey(index);
            this.Register<bool>(key, delegate(bool value) { OnValueGroupChanged(index, value); });
        }

    }
}
