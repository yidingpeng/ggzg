using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Procedure.Result
{

    public delegate void ResultHandler(object sender, BaseResult result);
    public delegate void ResultHandler<T>(object sender, T result) where T : BaseResult;
    public delegate void ResultCollectionHandler<T>(object sender, T[] result) where T : BaseResult;

    public class BaseResult
    {
        public BaseResult()
        {

        }

        public BaseResult(bool result)
        {
            this.Result = result;
        }

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
