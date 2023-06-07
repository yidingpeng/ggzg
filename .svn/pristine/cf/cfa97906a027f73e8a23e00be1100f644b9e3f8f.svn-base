using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace RW.PMS.Utils
{
    /// <summary>
    /// 提供一种开关的属性和事件的接口
    /// </summary>
    public interface ISwitch
    {
        bool Switch { get; set; }
        event SwitchHandler SwitchChanged;
    }

    public delegate void SwitchHandler(object sender, bool value);


    /// <summary>
    /// 提供一种带颜色开关的接口
    /// </summary>
    public interface ISwitchColor : ISwitch
    {
        Color TrueColor { get; set; }
        Color FalseColor { get; set; }
    }

    /// <summary>
    /// 提供一种带图片切换开关的接口
    /// </summary>
    public interface ISwitchImage : ISwitch
    {
        Image TrueImage { get; set; }
        Image FalseImage { get; set; }
    }
}
