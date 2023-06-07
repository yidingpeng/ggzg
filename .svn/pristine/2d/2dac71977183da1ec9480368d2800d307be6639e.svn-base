using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Driver
{
    /// <summary>
    /// 驱动接口
    /// </summary>
    public interface IDriver : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object this[string key] { get; set; }

        /// <summary>
        /// 读
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object Read(string key);

        /// <summary>
        /// 写
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Write(string key, object value);

        /// <summary>
        /// 连接
        /// </summary>
        void Connect();

        /// <summary>
        /// 关闭
        /// </summary>
        void Close();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(string key);

        /// <summary>
        /// 连接事件
        /// </summary>
        event EventHandler Connected;

        /// <summary>
        /// 值变事件
        /// </summary>
        event ValueChangeHandler ValueChanged;
    }
}
