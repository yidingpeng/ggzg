using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Modules
{
    /// <summary>
    /// 用于描述硬件的统一接口，包含值和事件。
    /// </summary>
    public interface IHardwareVibrationGroup : IHardwareGroup
    {
        new VibrationHardWare[] Hardwares { get; }

        double GetSensitivityValue(int index);

        event ValueGroupHandler SensitivityGroupChanged;
    }
}
