using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils
{
    /// <summary>
    /// 用于描述可点击的控件
    /// </summary>
    public interface IClickable
    {
        bool CanClick { get;set; }
        bool ClickSwitch { get;set; }

        event EventHandler Click;
    }

    /// <summary>
    /// 用于描述支持异步点击的控件
    /// </summary>
    public interface IAsyncClickabe : IClickable
    {
        bool AsyncClick { get;set; }
    }
}
