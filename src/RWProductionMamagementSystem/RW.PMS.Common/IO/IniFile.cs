using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace RW.IO
{
    /// <summary>
    /// 用于读写ini文件的帮助类
    /// 定义：
    /// filename：文件名称
    /// Section：结点名称
    /// key：键名称
    /// Value：值
    /// </summary>
    public class IniFile
    {
        //函数作用：向INI文件中写信息，若文件不存在则新建一个
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile()
        {

        }

        public IniFile(string filename)
        {
            this.Filename = filename;
        }

        public string Filename;

        public T Get<T>(string section, string key, T def) where T : struct
        {
            StringBuilder temp = new StringBuilder(102400);
            GetPrivateProfileString(section, key, def.ToString(), temp, temp.Capacity, Filename);
            return (T)Convert.ChangeType(temp.ToString(), typeof(T));
        }

        public string GetString(string section, string key, string def)
        {
            StringBuilder temp = new StringBuilder(102400);
            GetPrivateProfileString(section, key, def, temp, temp.Capacity, Filename);
            return temp.ToString();
        }

        public string GetString(string section, string key)
        {
            return GetString(section, key, default(string));
        }

        public string[] GetArray(string section, string key)
        {
            return GetArray(section, key, default(string[]));
        }

        public string[] GetArray(string section, string key, string[] def)
        {
            string source = GetString(section, key, string.Empty);
            return source == null ? def : source.Split(',');
        }

        public int[] GetIntArray(string section, string key)
        {
            return GetIntArray(section, key, null);
        }

        public int[] GetIntArray(string section, string key, int[] def)
        {
            string[] arr = GetArray(section, key, null);
            if (arr == null)
                return def;
            int[] cArr = Array.ConvertAll<string, int>(arr, delegate(string input) { return Convert.ToInt32(input); });
            return cArr;
        }

        public float[] GetFloatArray(string section, string key)
        {
            return GetFloatArray(section, key, null);
        }

        public float[] GetFloatArray(string section, string key, float[] def)
        {
            string[] arr = GetArray(section, key, null);
            if (arr == null)
                return def;
            float[] cArr = Array.ConvertAll<string, float>(arr, delegate(string input) { return Convert.ToSingle(input); });
            return cArr;
        }

        public double[] GetDoubleArray(string section, string key)
        {
            return GetDoubleArray(section, key, null);
        }

        public double[] GetDoubleArray(string section, string key, double[] def)
        {
            string[] arr = GetArray(section, key);
            if (arr == null)
                return def;
            double[] cArr = Array.ConvertAll<string, double>(arr, delegate(string input) { return Convert.ToDouble(input); });
            return cArr;
        }

        public decimal[] GetDecimalArray(string section, string key)
        {
            return GetDecimalArray(section, key, null);
        }

        public decimal[] GetDecimalArray(string section, string key, decimal[] def)
        {
            string[] arr = GetArray(section, key);
            if (arr == null)
                return def;
            decimal[] cArr = Array.ConvertAll<string, decimal>(arr, delegate(string input) { return Convert.ToDecimal(input); });
            return cArr;
        }

        public bool[] GetBoolArray(string section, string key)
        {
            return GetBoolArray(section, key, null);
        }

        public bool[] GetBoolArray(string section, string key, bool[] def)
        {
            string[] arr = GetArray(section, key);
            if (arr == null)
                return def;
            bool[] cArr = Array.ConvertAll<string, bool>(arr, delegate(string input) { return Convert.ToBoolean(input); });
            return cArr;
        }

        public int GetInt(string section, string key)
        {
            return GetInt(section, key, 0);
        }

        public int GetInt(string section, string key, int def)
        {
            int _value;
            if (int.TryParse(GetString(section, key, def.ToString()), out _value))
                return _value;
            else
                return def;
        }

        public decimal GetDecimal(string section, string key)
        {
            return GetDecimal(section, key, 0M);
        }

        public decimal GetDecimal(string section, string key, decimal def)
        {
            decimal _value;
            if (decimal.TryParse(GetString(section, key, def.ToString()), out _value))
                return _value;
            else
                return def;
        }

        public double GetDouble(string section, string key)
        {
            return GetDouble(section, key, 0d);
        }

        public double GetDouble(string section, string key, double def)
        {
            double _value;
            if (double.TryParse(GetString(section, key, def.ToString()), out _value))
                return _value;
            else
                return def;
        }

        public float GetFloat(string section, string key)
        {
            return GetFloat(section, key, 0f);
        }

        public float GetFloat(string section, string key, float def)
        {
            float _value;
            if (float.TryParse(GetString(section, key, def.ToString()), out _value))
                return _value;
            else
                return def;
        }

        public bool GetBool(string section, string key)
        {
            return GetBool(section, key, false);
        }

        public bool GetBool(string section, string key, bool def)
        {
            bool _value;
            if (bool.TryParse(GetString(section, key, def.ToString()), out _value))
                return _value;
            else
                return def;
        }

        public void Set(string section, string key, object value)
        {
            WritePrivateProfileString(section, key, Convert.ToString(value), Filename);
        }

        public void SetString(string section, string key, string value)
        {
            Set(section, key, value);
        }

        public void SetArray<T>(string section, string key, T[] array)
        {
            string value = "";
            for (int i = 0; i < array.Length; i++)
            {
                value += array[i] + ",";
            }
            if (value.Length > 0) value = value.Substring(0, value.Length - 1);
            Set(section, key, value);
        }

        public void SetArray(string section, string key, string[] array)
        {
            SetArray<string>(section, key, array);
        }

        public void SetInt(string section, string key, int value)
        {
            Set(section, key, value);
        }

        public void SetIntArray(string section, string key, int[] array)
        {
            SetArray<int>(section, key, array);
        }

        public void SetFloat(string section, string key, float value)
        {
            Set(section, key, value);
        }

        public void SetFloatArray(string section, string key, float[] array)
        {
            SetArray<float>(section, key, array);
        }

        public void SetDouble(string section, string key, double value)
        {
            Set(section, key, value);
        }

        public void SetDoubleArray(string section, string key, double[] array)
        {
            SetArray<double>(section, key, array);
        }

        public void SetBool(string section, string key, bool value)
        {
            Set(section, key, value);
        }

        public void SetBoolArray(string section, string key, bool[] array)
        {
            SetArray<bool>(section, key, array);
        }

        public void SetDecimal(string section, string key, decimal value)
        {
            Set(section, key, value);
        }

        public void SetDecimalArray(string section, string key, decimal[] array)
        {
            SetArray<decimal>(section, key, array);
        }

        public void RemoveKey(string section, string key)
        {
            WritePrivateProfileString(section, key, null, Filename);
        }

        public void RemoveSection(string section)
        {
            WritePrivateProfileString(section, null, null, Filename);
        }
    }
}
