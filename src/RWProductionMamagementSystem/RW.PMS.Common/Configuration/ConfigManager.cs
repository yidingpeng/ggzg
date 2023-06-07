using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;

namespace RW.PMS.Common
{
    /// <summary>
    /// 配置文件管理
    /// </summary>
    public static class ConfigManager
    {
        public static Dictionary<string, string> GetSections(string sectionName)
        {
            var hashTable = ConfigurationManager.GetSection(sectionName) as Hashtable;

            var dict = new Dictionary<string, string>();

            foreach (DictionaryEntry item in hashTable)
            {
                dict.Add(item.Key.ToString(), item.Value.ToString());
            }

            return dict;
        }

        public static string GetConnectionString(string name)
        {

            var connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;

            return connectionString;

        }

        public static string GetSetting(string key)
        {
            var value = ConfigurationManager.AppSettings[key];

            return value;
        }
    }
}