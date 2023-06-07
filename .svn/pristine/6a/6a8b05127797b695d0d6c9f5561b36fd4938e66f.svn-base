using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace RW.PMS.WebApi
{
    public class JsonDataTimeConverter : IsoDateTimeConverter
    {
        public JsonDataTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// Json转时间
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objecType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objecType, object existingValue, JsonSerializer serializer)
        {
            DateTime dataTime;

            if (DateTime.TryParse(reader.Value == null ? "" : reader.Value.ToString(), out dataTime))
                return dataTime;
            else
                return existingValue;
        }
    }
}