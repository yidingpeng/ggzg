using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.PMS.Utils.Modules
{
    /// <summary>
    /// 用于描述硬件的统一接口，包含值和事件。
    /// </summary>
    public interface IHardwareGroup : IAnalogGroup
    {
        HardwareGroup Hardwares { get; }

        event ValueGroupHandler<int> IndexGroupChanged;
    }

    /// <summary>
    /// 描述所有模拟量并支持零点增益的事件
    /// </summary>
    public interface IAnalogGroup : IIndexes
    {
        ///// <summary>
        ///// 值的起始地址
        ///// </summary>
        //[DefaultValue(0)]
        //int ValueStart { get; set; }
        ///// <summary>
        ///// 零点的起始地址
        ///// </summary>
        //[DefaultValue(0)]
        //int ZeroStart { get; set; }
        ///// <summary>
        ///// 增益的起始地址
        ///// </summary>
        //[DefaultValue(0)]
        //int GainStart { get; set; }

        //double GetGainValue(int index);
        //double GetZeroValue(int index);

        event ValueGroupHandler ValueGroupChanged;
        event ValueGroupHandler GainValueGroupChanged;
        event ValueGroupHandler ZeroValueGroupChanged;
    }

    public interface IDigitalGroup : IIndexes<bool>
    {
        int Start { get; set; }
        int Offset { get; set; }

        event ValueGroupHandler<bool> ValueGroupChanged;
    }
}
