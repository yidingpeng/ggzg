using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Core
{
    /// <summary>
    /// 提供润伟专用计算器
    /// </summary>
    public static class RWCal
    {
        public static double Add(double a, double b, int decimals)
        {
            return Math.Round(a + b, decimals);
        }
        public static double Add(double a, double b)
        {
            return Add(a, b, 4);
        }

        /// <summary>
        /// 获取均方根
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static double GetRMS(double[] values)
        {
            if (values == null || values.Length == 0)
                return 0;
            double temp = 0;
            for (int i = 0; i < values.Length; i++)
            {
                temp += Math.Pow(values[i], 2);
            }
            temp = temp / values.Length;
            return Math.Sqrt(temp);
        }
    }
}
