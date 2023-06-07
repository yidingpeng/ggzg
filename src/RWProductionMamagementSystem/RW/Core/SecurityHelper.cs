using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace RW.PMS.Utils.Core
{
    /// <summary>
    /// 通用的安全算法类
    /// </summary>
    public static class SecurityHelper
    {
        public static string GetMD5(string s, string _input_charset)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        public static string GetMD5(string s)
        {
            return GetMD5(s, "UTF-8");
        }

    }
}
