using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.Modules
{
    /// <summary>
    /// 传感器
    /// 使用时，请先设置Readkey，便可获取Value和ValueChanged事件。
    /// 如有需要，可设置零点值（ZeroValue）和增益值(GainValue)
    /// </summary>
    public class Sensor : BaseReadModule
    {
        public Sensor()
        {

        }

        public Sensor(IContainer contianer)
            : base(contianer)
        {

        }
    }
}
