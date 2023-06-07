using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Modules
{
    /// <summary>
    /// 用于描述硬件的统一接口，包含值和事件。
    /// </summary>
    public interface IHardware
    {
        double Value { get; }
        double GainValue { get;set;}
        double ZeroValue { get;set;}

        event ValueHandler ValueChanged;
        event ValueHandler GainValueChanged;
        event ValueHandler ZeroValueChanged;
    }
}
