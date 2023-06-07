using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Core
{
    public static class FormartHelper
    {
        public static string TimeSpan(TimeSpan ts, string format)
        {
            return format
                .Replace("MM", ts.Minutes.ToString().PadLeft(2, '0'))
                .Replace("M", ts.Minutes.ToString())
                .Replace("HH", ts.Hours.ToString().PadLeft(2, '0'))
                .Replace("H", ts.Hours.ToString())
                .Replace("ss", ts.Seconds.ToString().PadLeft(2, '0'))
                .Replace("s", ts.Seconds.ToString())
                .Replace("fff", ts.Minutes.ToString().Substring(0, 3))

            ;
        }
    }
}
