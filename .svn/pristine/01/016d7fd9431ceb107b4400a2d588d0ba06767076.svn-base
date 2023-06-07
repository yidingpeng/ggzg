using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace RW.PMS.Utils
{
    public sealed class ConvertHelper
    {
        public static string ConvertBase(string value, int from, int to)
        {
            if (!ConvertHelper.isBaseNumber(from))
            {
                throw new ArgumentException("参数from只能是2,8,10,16四个值。");
            }
            if (!ConvertHelper.isBaseNumber(to))
            {
                throw new ArgumentException("参数to只能是2,8,10,16四个值。");
            }
            int intValue = Convert.ToInt32(value, from);
            string result = Convert.ToString(intValue, to);
            if (to == 2)
            {
                switch (result.Length)
                {
                    case 3:
                        result = "00000" + result;
                        break;

                    case 4:
                        result = "0000" + result;
                        break;

                    case 5:
                        result = "000" + result;
                        break;

                    case 6:
                        result = "00" + result;
                        break;

                    case 7:
                        result = "0" + result;
                        break;
                }
            }
            return result;
        }

        private static bool isBaseNumber(int baseNumber)
        {
            return baseNumber == 2 || baseNumber == 8 || baseNumber == 10 || baseNumber == 16;
        }

        public static byte[] StringToBytes(string text)
        {
            return Encoding.Default.GetBytes(text);
        }

        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        public static string BytesToString(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }

        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        public static int BytesToInt32(byte[] data)
        {
            int result;
            if (data.Length < 4)
            {
                result = 0;
            }
            else
            {
                int num = 0;
                if (data.Length >= 4)
                {
                    byte[] tempBuffer = new byte[4];
                    Buffer.BlockCopy(data, 0, tempBuffer, 0, 4);
                    num = BitConverter.ToInt32(tempBuffer, 0);
                }
                result = num;
            }
            return result;
        }

        public static int ToInt32<T>(T data, int defValue)
        {
            int result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToInt32(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static int ToInt32(string data, int defValue)
        {
            int result;
            if (string.IsNullOrEmpty(data))
            {
                result = defValue;
            }
            else
            {
                int temp = 0;
                if (int.TryParse(data, out temp))
                {
                    result = temp;
                }
                else
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static int ToInt32(object data, int defValue)
        {
            int result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToInt32(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static bool ToBoolean<T>(T data, bool defValue)
        {
            bool result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToBoolean(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static bool ToBoolean(string data, bool defValue)
        {
            bool result;
            if (string.IsNullOrEmpty(data))
            {
                result = defValue;
            }
            else
            {
                bool temp = false;
                if (bool.TryParse(data, out temp))
                {
                    result = temp;
                }
                else
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static bool ToBoolean(object data, bool defValue)
        {
            bool result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToBoolean(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static float ToFloat<T>(T data, float defValue)
        {
            float result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToSingle(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static float ToFloat(object data, float defValue)
        {
            float result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToSingle(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static float ToFloat(string data, float defValue)
        {
            float result;
            if (string.IsNullOrEmpty(data))
            {
                result = defValue;
            }
            else
            {
                float temp = 0f;
                if (float.TryParse(data, out temp))
                {
                    result = temp;
                }
                else
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static double ToDouble<T>(T data, double defValue)
        {
            double result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToDouble(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static double ToDouble<T>(T data, int decimals, double defValue)
        {
            double result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Math.Round(Convert.ToDouble(data), decimals);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static double ToDouble(object data, double defValue)
        {
            double result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToDouble(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static double ToDouble(string data, double defValue)
        {
            double result;
            if (string.IsNullOrEmpty(data))
            {
                result = defValue;
            }
            else
            {
                double temp = 0.0;
                if (double.TryParse(data, out temp))
                {
                    result = temp;
                }
                else
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static double ToDouble(object data, int decimals, double defValue)
        {
            double result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Math.Round(Convert.ToDouble(data), decimals);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static double ToDouble(string data, int decimals, double defValue)
        {
            double result;
            if (string.IsNullOrEmpty(data))
            {
                result = defValue;
            }
            else
            {
                double temp = 0.0;
                if (double.TryParse(data, out temp))
                {
                    result = Math.Round(temp, decimals);
                }
                else
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static object ConvertTo(object value, Type targetType)
        {
            object result;
            if (value == null || Convert.IsDBNull(value))
            {
                return null;
            }
            Type valueType = value.GetType();
            if (targetType == valueType)
            {
                return value;
            }
            //string转Guid或Guid?
            if ((targetType == typeof(Guid) || targetType == typeof(Guid?)) && valueType == typeof(string))
            {
                if (string.IsNullOrEmpty(value.ToString()))
                    return null;
                else
                    return new Guid(value.ToString());
            }
            //转枚举
            if (targetType.IsEnum)
            {
                try
                {
                    return Enum.Parse(targetType, value.ToString(), true);
                }
                catch
                {
                    result = Enum.ToObject(targetType, value);
                    return result;
                }
            }
            if (targetType.IsGenericType)
            {
                targetType = targetType.GetGenericArguments()[0];
            }
            result = Convert.ChangeType(value, targetType);
            return result;
        }

        /// <summary>
        /// Convert.ChangeType改进版,增加可空类型判定
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object ChanageType(object value, Type targetType)
        {
            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null || value.ToString().Length == 0)
                {
                    return null;
                }
                NullableConverter nullableConverter = new NullableConverter(targetType);
                targetType = nullableConverter.UnderlyingType;
            }
            return Convert.ChangeType(value, targetType);
        }

        /// <summary>
        /// 泛型类转
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(object data)
        {
            T result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = default(T);
            }
            else
            {
                object obj = ConvertHelper.ConvertTo(data, typeof(T));
                if (obj == null)
                {
                    result = default(T);
                }
                else
                {
                    result = (T)((object)obj);
                }
            }
            return result;
        }

        public static decimal ToDecimal<T>(T data, decimal defValue)
        {
            decimal result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToDecimal(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static decimal ToDecimal(object data, decimal defValue)
        {
            decimal result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToDecimal(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static decimal ToDecimal(string data, decimal defValue)
        {
            decimal result;
            if (string.IsNullOrEmpty(data))
            {
                result = defValue;
            }
            else
            {
                decimal temp = 0m;
                if (decimal.TryParse(data, out temp))
                {
                    result = temp;
                }
                else
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static DateTime ToDateTime<T>(T data, DateTime defValue)
        {
            DateTime result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToDateTime(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static DateTime ToDateTime(object data, DateTime defValue)
        {
            DateTime result;
            if (data == null || Convert.IsDBNull(data))
            {
                result = defValue;
            }
            else
            {
                try
                {
                    result = Convert.ToDateTime(data);
                }
                catch
                {
                    result = defValue;
                }
            }
            return result;
        }

        public static DateTime ToDateTime(string data, DateTime defValue)
        {
            DateTime result;
            if (string.IsNullOrEmpty(data))
            {
                result = defValue;
            }
            else
            {
                DateTime temp = DateTime.Now;
                if (DateTime.TryParse(data, out temp))
                {
                    result = temp;
                }
                else
                {
                    result = defValue;
                }
            }
            return result;
        }

        /// <summary>
        /// Table转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static T GetEntity<T>(DataTable table) where T : new()
        {
            T entity = new T();
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in entity.GetType().GetProperties())
                {
                    if (row.Table.Columns.Contains(item.Name))
                    {
                        if (DBNull.Value != row[item.Name])
                        {
                            item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                        }
                    }
                }
            }
            return entity;
        }

        /// <summary>
        /// Table转List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static IList<T> GetEntities<T>(DataTable table) where T : new()
        {
            IList<T> entities = new List<T>();
            foreach (DataRow row in table.Rows)
            {
                T entity = new T();
                foreach (var item in entity.GetType().GetProperties())
                {
                    item.SetValue(entity, Convert.ChangeType(row[item.Name], item.PropertyType), null);
                }
                entities.Add(entity);
            }
            return entities;
        }
    }
}