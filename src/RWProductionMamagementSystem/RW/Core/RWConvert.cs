using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Core
{
    public static class RWConvert
    {
        /// <summary>
        /// 将数组转换为2进制字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToBinary(long value)
        {
            return Convert.ToString(value, 2);
        }

        /// <summary>
        /// 将数字装换为16进制字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHex(long value)
        {
            return Convert.ToString(value, 16);
        }

        /// <summary>
        /// 将1-24转换为长度为3的字节数组
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] IndexToByteArray(int value)
        {
            int mod = (value - 1) % 8;//7
            int arrIndex = (value - 1) / 8;//2
            byte bts = (byte)(1 << mod);//10000000
            //data[index]

            byte[] data = new byte[arrIndex + 1];
            data[arrIndex] = bts;

            return data;
            //return 1 << value - 1;
        }

        public static int StringToInt32(string str)
        {
            return Convert.ToInt32(str);
        }

        public static int ObjectToInt32(object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static int[] ArrayStringToInt32(string[] arr)
        {
            return Array.ConvertAll<string, int>(arr, new Converter<string, int>(StringToInt32));
        }

        public static int[] ArrayObjectToInt32(object[] arr)
        {
            return Array.ConvertAll<object, int>(arr, new Converter<object, int>(ObjectToInt32));
        }

        public static byte[] HexStringToBytes(string source)
        {
            byte[] ret = new byte[source.Length / 2];
            for (int i = 0; i < ret.Length; i++)
            {
                byte temp = Convert.ToByte(source.Substring(i, 2), 16);
                ret[i] = temp;
            }
            return ret;
        }

        /// <summary>
        /// 将字节数组转换成16进制数，并在中间插入指定的字符
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="insert"></param>
        /// <returns></returns>
        public static string BytesToHexString(byte[] bytes, string insert)
        {
            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
                ret += insert;
            }
            if (ret.Length > 0)
                ret = ret.Substring(0, ret.Length - insert.Length);
            return ret;
        }

        public static string BytesToHexString(byte[] bytes)
        {
            return BytesToHexString(bytes, "");
        }
    }
}
