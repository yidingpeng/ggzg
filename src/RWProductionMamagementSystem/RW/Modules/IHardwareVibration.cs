using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Modules
{
    public interface IHardwareVibration : IHardware
    {
        double Sensitivity { get;set; }

        event ValueHandler SensitivityChanged;
    }
}
