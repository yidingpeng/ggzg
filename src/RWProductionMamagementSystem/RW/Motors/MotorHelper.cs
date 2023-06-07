using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Motors
{
    /// <summary>
    /// 提供对电机的一些帮助方法
    /// </summary>
    public static class MotorHelper
    {

        /// <summary>
        /// 根据电机的极数与速度获取运行频率
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="poles"></param>
        /// <returns></returns>
        public static double GetSpeedFrequency(double speed, int poles)
        {
            double frequency = speed * poles / 60;
            return frequency;

        }

        /// <summary>
        /// 获取电机当前设置的运行速度
        /// </summary>
        public static double GetMotorSpeed(int poles, double frequency)
        {
            return 60 * frequency / poles;
        }
    }
}
