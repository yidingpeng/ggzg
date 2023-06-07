using System;
using System.Collections.Generic;
using System.Text;
using RW.Proceduce.Result;

namespace RW.Proceduce
{
    public class TestEventArgs<T> : EventArgs
        where T : BaseResult, new()
    {
        private T result = new T();

        public virtual T Result
        {
            get { return result; }
            set { result = value; }
        }

    }
}
