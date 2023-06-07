using System;
using System.Collections.Generic;
using System.Text;
using RW.PMS.Utils.Procedure.Result;

namespace RW.PMS.Utils.Procedure
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
