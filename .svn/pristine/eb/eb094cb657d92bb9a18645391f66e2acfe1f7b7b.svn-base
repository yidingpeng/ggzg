using System;
using System.Collections.Generic;
using System.Text;

namespace RW.Proceduce.Result
{

    public delegate void ResultHandler(object sender, BaseResult result);
    public delegate void ResultHandler<T>(object sender, T result) where T : BaseResult;

    public class BaseResult
    {
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        private string testID;

        public string TestID
        {
            get { return testID; }
            set { testID = value; }
        }

        private bool result;

        public virtual bool Result
        {
            get { return result; }
            protected set { result = value; }
        }

        public void SetResult(bool result)
        {
            this.Result = result;
        }
    }
}
