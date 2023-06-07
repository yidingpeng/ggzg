using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.SelfTest
{
    /// <summary>
    /// 自检控制器，可注册自检模块，可注册自检组
    /// 可执行自检动作
    /// </summary>
    public interface ISelfTest
    {
        /// <summary>
        /// 分组注册自检方法
        /// </summary>
        /// <param name="groupName">组名称</param>
        /// <param name="name">显示名称</param>
        /// <param name="del">自检行为</param>
        void Register(string groupName, string name, Del del);

        /// <summary>
        /// 移除注册自检
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="name"></param>
        void UnRegister(string groupName, string name);

        /// <summary>
        /// 执行自检
        /// </summary>
        void Execute();

        event SelfTestHandler SelfTestEvent;
    }

    public delegate void Del();
    public delegate void SelfTestHandler(string groupName, string name);
}
