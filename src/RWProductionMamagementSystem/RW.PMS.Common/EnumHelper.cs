using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace RW.PMS.Common
{
    /// <summary>
    /// 枚举帮助类 Add By Leon 20190724
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// 枚举转List(给select使用)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumEntity> EnumToList<T>()
        {
            List<EnumEntity> list = new List<EnumEntity>();
            try
            {
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    EnumEntity e = new EnumEntity();
                    e.Value = (int)item;
                    e.Name = ((T)item).GetDescription();
                    list.Add(e);
                }
            }
            catch { }
            return list;
        }
    }

    /// <summary>
    /// 枚举实体类
    /// </summary>
    public class EnumEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    /// <summary>
    /// 通用扩展函数类
    /// Author Leon 李明达
    /// </summary>
    public static class Constructor
    {
        /// <summary>
        /// 获取自定义属性的说明 Add By Leon 20190810
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T t)
        {
            try
            {
                foreach (var memb in typeof(T).GetMembers())
                {
                    if (memb.Name != t.ToString()) continue;
                    foreach (Attribute attr in memb.GetCustomAttributes(true))
                    {
                        var dscript = attr as System.ComponentModel.DescriptionAttribute;
                        if (dscript != null) return dscript.Description;
                    }
                }
                return t.ToString();
            }
            catch { }
            return "";
        }

        /// <summary>
        /// 转Byte数组
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static byte[] ToBytes(this object obj, byte[] ret = null)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    IFormatter iFormatter = new BinaryFormatter();
                    iFormatter.Serialize(ms, obj);
                    return ms.GetBuffer();
                }
            }
            catch { }
            return ret;
        }

        /// <summary>
        /// Bytes转Image
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Image ToImage(this byte[] bytes, Image img = null)
        {
            try
            {
                //byte[] bytes = Convert.FromBase64String(str);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    ms.Write(bytes, 0, bytes.Length);
                    img = Image.FromStream(ms, true);
                }
            }
            catch { }
            return img;
        }

        /// <summary>
        /// 图片Base64解码
        /// </summary>
        /// <param name="img"></param>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] ToBase64(this Image img, byte[] bytes = null)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Jpeg);
                    bytes = new byte[ms.Length];
                    ms.Position = 0;
                    ms.Read(bytes, 0, (int)ms.Length);
                    //str = Convert.ToBase64String(bytes);
                }
            }
            catch { }
            return bytes;
        }

        /// <summary>
        /// 转Int
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static int ToInt(this object obj, int ret = 0)
        {
            int.TryParse(obj + "", out ret);
            return ret;
        }

        /// <summary>
        /// 转Float
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static float ToFloat(this object obj, float ret = 0)
        {
            float.TryParse(obj + "", out ret);
            return ret;
        }

        /// <summary>
        /// 转Double
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static double ToDouble(this object obj, double ret = 0)
        {
            double.TryParse(obj + "", out ret);
            return ret;
        }
        public static char ToStrings(this object obj, char ret = ' ')
        {
            char.TryParse(obj + "", out ret);
            return ret;
        }
        /// <summary>
        /// 转Decimal
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ret"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this object obj, decimal ret = 0)
        {
            decimal.TryParse(obj + "", out ret);
            return ret;
        }

        /// <summary>
        /// 转Bool
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool ToBool(this object obj)
        {
            bool ret = false;
            bool.TryParse(obj + "", out ret);
            return ret;
        }

        /// <summary>
        /// 转DateTime
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj, DateTime? dt = null)
        {
            DateTime ret = dt ?? DateTime.MinValue;
            DateTime.TryParse(obj + "", out ret);
            return ret;
        }

        /// <summary>
        /// 转GUID
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static Guid ToGuid(this object obj, Guid? guid = null)
        {
            Guid g = guid ?? Guid.Empty;
            Guid.TryParse(obj + "", out g);
            return g;
        }
    }
}
