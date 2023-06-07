using System;
using System.Collections.Generic;
using System.Text;
using RW.PMS.Utils.IO;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using RW.PMS.Utils.Serialize;
using System.IO;
using System.ComponentModel;

namespace RW.PMS.Utils.Configuration
{
    [Description("关于读写Ini配置文件的基类")]
    public class IniConfig : IConfig
    {
        public IniFile Config = new IniFile();

        public IniConfig()
        {
        }

        public IniConfig(string filename)
        {
            this.Filename = filename;
        }

        /// <summary>
        /// 文件路径
        /// </summary>
        protected string Filename
        {
            get { return Config.Filename; }
            set { Config.Filename = value; }
        }

        public void SetFilename(string filename)
        {
            this.Filename = filename;
            Config = new IniFile(filename);
        }

        public virtual void Save()
        {
            Save(this.Filename);
        }

        PropertyInfo[] objs = null;

        Dictionary<string, string> dicKeyMap = new Dictionary<string, string>();
        Dictionary<string, string> dicKeyValue = new Dictionary<string, string>();

        /// <summary>
        /// 保存配置文件
        /// </summary>
        public virtual void Save(string filename)
        {
            //string dir = filename.Substring(0, filename.LastIndexOf('\\'));
            //if (!Directory.Exists(dir))
            //    Directory.CreateDirectory(dir);
            //Config = new IniFile(filename);
            //string cname = GetSectionName();
            //if (objs == null)
            //    objs = this.GetType().GetProperties();
            //foreach (PropertyInfo p in objs)
            //{
            //    string pname = p.Name;
            //    object[] datas = p.GetCustomAttributes(typeof(IniKeyNameAttribute), false);
            //    if (datas.Length > 0)
            //    {
            //        IniKeyNameAttribute iname = datas[0] as IniKeyNameAttribute;
            //        pname = iname.Name;
            //    }

            //    object pvalue = p.GetValue(this, null);

            //    if (p.PropertyType.IsValueType || (p.PropertyType == typeof(string)))
            //    {
            //        if (pvalue != null)
            //            Config.Set(cname, pname, pvalue);
            //    }
            //    else
            //    {
            //        string text = SerializeHelper.Instance.SerializeObject(pvalue);
            //        Config.Set(cname, pname, text);
            //    }
            //    //}
            //    //else
            //    //{
            //    //    Config.Set(cname, pname, pvalue);
            //    //}
            //}

            Save(this, GetSectionName(), filename);
        }

        public static void Save(object obj, string sectionName, string filename)
        {
            string dir = filename.Substring(0, filename.LastIndexOf('\\'));
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            IniFile Config = new IniFile(filename);
            string cname = sectionName;
            PropertyInfo[] objs = null;
            if (objs == null)
                objs = obj.GetType().GetProperties();
            foreach (PropertyInfo p in objs)
            {
                string pname = p.Name;
                object[] datas = p.GetCustomAttributes(typeof(IniKeyNameAttribute), false);
                if (datas.Length > 0)
                {
                    IniKeyNameAttribute iname = datas[0] as IniKeyNameAttribute;
                    pname = iname.Name;
                }

                object pvalue = p.GetValue(obj, null);

                if (p.PropertyType.IsValueType || (p.PropertyType == typeof(string)))
                {
                    if (pvalue != null)
                        Config.Set(cname, pname, pvalue);
                }
                else
                {
                    string text = SerializeHelper.Instance.SerializeObject(pvalue);
                    Config.Set(cname, pname, text);
                }
                //}
                //else
                //{
                //    Config.Set(cname, pname, pvalue);
                //}
            }
        }

        public static void Save(object obj, string filename)
        {
            Save(obj, obj.GetType().Name, filename);
        }

        public virtual void Load()
        {
            Load(this.Filename);
        }

        public static void Load<T>(T obj, string sectionName, string filename)
        {
            IniFile Config = new IniFile(filename);
            string cname = sectionName;
            //object obj = new T();
            PropertyInfo[] objs = null;
            if (objs == null)
                objs = obj.GetType().GetProperties();
            foreach (PropertyInfo p in objs)
            {
                string pname = p.Name;

                object[] datas = p.GetCustomAttributes(typeof(IniKeyNameAttribute), false);
                if (datas.Length > 0)
                {
                    IniKeyNameAttribute iname = datas[0] as IniKeyNameAttribute;
                    pname = iname.Name;
                }

                string value = Config.GetString(cname, pname, "");

                //TODO: 如果是数组，读取方式将不同
                if (!string.IsNullOrEmpty(value))
                {
                    SetProperty(obj, p, value);
                }
            }
            //return obj;
        }

        public static void Load<T>(T obj, string filename)
        {
            Load(obj, obj.GetType().Name, filename);
        }

        /// <summary>
        /// 加载配置文件
        /// </summary>
        public virtual void Load(string filename)
        {

            Load(this, GetSectionName(), filename);

            //Config = new IniFile(filename);
            //string cname = GetSectionName();
            //if (objs == null)
            //    objs = this.GetType().GetProperties();
            //foreach (PropertyInfo p in objs)
            //{
            //    string pname = p.Name;


            //    object[] datas = p.GetCustomAttributes(typeof(IniKeyNameAttribute), false);
            //    if (datas.Length > 0)
            //    {
            //        IniKeyNameAttribute iname = datas[0] as IniKeyNameAttribute;
            //        pname = iname.Name;
            //    }

            //    string value = Config.GetString(cname, pname, "");

            //    dicKeyMap[pname] = p.Name;
            //    dicKeyValue[pname] = value;
            //    //TODO: 如果是数组，读取方式将不同
            //    if (!string.IsNullOrEmpty(value))
            //    {
            //        this.SetProperty(p, value);
            //    }
            //}


        }

        private void SetProperty(PropertyInfo p, string value)
        {
            SetProperty(this, p, value);
        }

        private static void SetProperty(object obj, PropertyInfo p, string value)
        {
            if (p.PropertyType.IsValueType || (p.PropertyType == typeof(string)))
            {
                if (p.PropertyType.IsEnum)
                    p.SetValue(obj, Enum.Parse(p.PropertyType, value), null);
                else
                    p.SetValue(obj, Convert.ChangeType(value, p.PropertyType, null), null);
            }
            else
            {
                object obj2 = SerializeHelper.Instance.DeserializeObject(value, p.PropertyType);
                p.SetValue(obj, obj2, null);
            }
        }

        public virtual string GetSectionName()
        {
            if (!string.IsNullOrEmpty(sectionName))
            {
                return sectionName;
            }
            return this.GetType().Name;
        }

        private string sectionName;
        public void SetSectionName(string name)
        {
            this.sectionName = name;
        }

        public Dictionary<string, string> GetProperty()
        {
            return dicKeyValue;
        }

        public void SetProperty(string key, string value)
        {
            //Config.SetString(this.GetSectionName(), key, value);

            foreach (PropertyInfo p in objs)
            {
                if (p.Name == key || p.Name == dicKeyMap[key])
                {
                    this.SetProperty(p, value);
                    break;
                }
            }
        }


        #region IConfig 成员

        public T Get<T>(string key) where T : struct
        {
            return Config.Get<T>(this.GetSectionName(), key, default(T));
        }

        public void Set(string key, object value)
        {
            Config.Set(this.GetSectionName(), key, value);
        }

        #endregion
    }

    [Obsolete("由于之前的设计问题，请使用IniConfig，该类即将作废")]
    public class BaseConfig : IniConfig
    {
        public BaseConfig()
        {

        }

        public BaseConfig(string filename)
            : base(filename)
        {

        }
    }
}
