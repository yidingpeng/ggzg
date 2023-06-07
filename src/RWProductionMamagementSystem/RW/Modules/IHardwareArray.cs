using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Modules
{
    /// <summary>
    /// 用于描述硬件的统一接口，包含值和事件。
    /// </summary>
    public interface IHardwareArray
    {
        HardwareList Hardwares { get; }
        //HardwareGroup SortedHardwares { get; }

        double GetGainValue(int index);
        double GetZeroValue(int index);

        event ValueListHandler ValuesChanged;
        event ValueListHandler GainValuesChanged;
        event ValueListHandler ZeroValuesChanged;
    }
}
