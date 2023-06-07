using System;
using System.Collections.Generic;
using System.Text;
using RW.PMS.Utils.Serialize;
using System.Reflection;
using System.IO;

namespace RW.PMS.Utils.IO
{
    /// <summary>
    /// 用于读写操作.CSV文件
    /// 默认情况下，使用','进行分隔。
    /// </summary>
    public class CSVFile
    {
        public string Filename { get; set; }

        public void Write<T>(List<T> lst) where T : new()
        {
            InitTitle(typeof(T));
            AppedData<T>(lst.ToArray());
        }

        public void InitTitle(Type t)
        {
            PropertyInfo[] infos = t.GetProperties();

            StringBuilder sbTitle = new StringBuilder();
            foreach (var item in infos)
            {
                sbTitle.Append(item.Name + ",");
            }
            if (sbTitle.Length > 0)
                sbTitle.Remove(sbTitle.Length - 1, 1);
            File.WriteAllText(Filename, sbTitle.AppendLine().ToString());
        }

        public void AppedData<T>(params T[] lst)
        {
            PropertyInfo[] infos = typeof(T).GetProperties();
            StringBuilder sbContent = new StringBuilder();
            foreach (var obj in lst)
            {
                foreach (var item in infos)
                {
                    object o = item.GetValue(obj, null);
                    sbContent.Append(o + ",");
                }
                sbContent.Remove(sbContent.Length - 1, 1);
                sbContent.AppendLine();
            }

            File.AppendAllText(Filename, sbContent.ToString());
        }

        public List<T> Read<T>()
        {
            PropertyInfo[] infos = typeof(T).GetProperties();
            string text = File.ReadAllText(Filename);

            return null;
        }
    }
}
