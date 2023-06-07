using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace RW.PMS.Utils.Serialize
{
    public class JsonSerialize : ISerialize
    {

        #region ISerialize ≥…‘±

        public string SerializeObject(object value)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }

        public object DeserializeObject(string value, Type type)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(value, type);
        }

        public T DeserializeObject<T>(string value)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
        }

        #endregion
    }
}
