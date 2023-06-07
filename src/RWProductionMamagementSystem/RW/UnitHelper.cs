using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils
{
    public static class UnitHelper
    {
        public static string GetString(UnitEnum unit)
        {
            string unitText = "";
            switch (unit)
            {
                case UnitEnum.None: break;
                case UnitEnum.percent: unitText = "%"; break;
                case UnitEnum.celsius: unitText = "℃"; break;
                case UnitEnum.rps: unitText = "r/s"; break;
                case UnitEnum.rpm: unitText = "r/m"; break;
                case UnitEnum.mmps: unitText = "mm/s"; break;
                case UnitEnum.mps: unitText = "m/s"; break;
                case UnitEnum.kmph: unitText = "km/h"; break;
                case UnitEnum.angle: unitText = "°"; break;
                case UnitEnum.mmmpmin: unitText = "m³/min"; break;
                default: unitText = unit.ToString(); break;
            }
            return unitText;
        }
    }
}
