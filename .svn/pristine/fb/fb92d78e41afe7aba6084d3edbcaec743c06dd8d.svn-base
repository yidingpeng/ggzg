using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace RW.PMS.Common
{
    /// <summary>
    /// 加密 解密
    /// </summary>
    public class DecryptAndEncryptHelper
    {
        private readonly SymmetricAlgorithm _symmetricAlgorithm;

        private const string DefKey = "qazwsxedcrfvtgb!@#$%^&*(tgbrfvedcwsxqaz)(*&^%$#@!++RWPMS";

        private string _key = string.Empty;
        public string Key
        {
            get { return _key; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _key = value;
                }
                else
                {
                    _key = DefKey;
                }
            }
        }

        private const string DefIV = "tgbrfvedcwsxqaz)(*&^%$#@!qazwsxedcrfvtgb!@#$%^&*(++RWPMS";

        private string _iv = string.Empty;
        public string IV
        {
            get { return _iv; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _iv = value;
                }
                else
                {
                    _iv = DefIV;
                }
            }
        }

        public DecryptAndEncryptHelper()
        {
            _symmetricAlgorithm = new RijndaelManaged();
        }

        public DecryptAndEncryptHelper(string Key="", string IV="")
        {
            _symmetricAlgorithm = new RijndaelManaged();
            _key = string.IsNullOrEmpty(Key) ? DefKey : Key;
            _iv = string.IsNullOrEmpty(IV) ? DefIV : IV;
        }

        /// <summary>
        /// Get Key
        /// </summary>
        /// <returns>密钥</returns>
        private byte[] GetLegalKey()
        {
            _symmetricAlgorithm.GenerateKey();

            byte[] bytTemp = _symmetricAlgorithm.Key;
            int KeyLength = bytTemp.Length;

            if (_key.Length > KeyLength)
            {
                _key = _key.Substring(0, KeyLength);
            }
            else if (_key.Length < KeyLength)
            { 
                _key = _key.PadRight(KeyLength, '#');
            }

            return ASCIIEncoding.ASCII.GetBytes(_key);
        }

        /// <summary>
        /// Get IV
        /// </summary>
        private byte[] GetLegalIV()
        {
            _symmetricAlgorithm.GenerateIV();
            byte[] bytTemp = _symmetricAlgorithm.IV;
            int IVLength = bytTemp.Length;
            if (_iv.Length > IVLength)
            {
                _iv = _iv.Substring(0, IVLength);
            }
            else if (_iv.Length < IVLength)
            {
                _iv = _iv.PadRight(IVLength, '#');
            }
            return ASCIIEncoding.ASCII.GetBytes(_iv);
        }

        /// <summary>
        /// Encrypto 加密
        /// </summary>
        public string Encrypto(string Source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);

            using (MemoryStream ms = new MemoryStream())
            {
                _symmetricAlgorithm.Key = GetLegalKey();
                _symmetricAlgorithm.IV = GetLegalIV();
                ICryptoTransform encrypto = _symmetricAlgorithm.CreateEncryptor();

                using (CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write))
                {
                    cs.Write(bytIn, 0, bytIn.Length);
                    cs.FlushFinalBlock();
                    byte[] bytOut = ms.ToArray();
                    return Convert.ToBase64String(bytOut);
                }
            }
        }

        /// <summary>
        /// Decrypto 解密
        /// </summary>
        public string Decrypto(string Source)
        {
            byte[] bytIn = Convert.FromBase64String(Source);

            using (MemoryStream ms = new MemoryStream(bytIn, 0, bytIn.Length))
            {
                _symmetricAlgorithm.Key = GetLegalKey();
                _symmetricAlgorithm.IV = GetLegalIV();

                ICryptoTransform encrypto = _symmetricAlgorithm.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);

                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
                
        }
    }
}
