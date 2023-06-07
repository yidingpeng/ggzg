using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace RW.Security
{

    public static class MD5Helper
    {
        public static string GetMD5(string text)
        {
            byte[] result = Encoding.Default.GetBytes(text);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
    }
}
