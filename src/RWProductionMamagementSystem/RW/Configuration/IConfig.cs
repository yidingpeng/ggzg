using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Configuration
{
    /// <summary>
    /// 提供对配置文件的读写统一接口
    /// </summary>
    public interface IConfig
    {
        T Get<T>(string key) where T : struct;
        void Set(string key, object value);
        void Load();
        void Save();
    }
}
