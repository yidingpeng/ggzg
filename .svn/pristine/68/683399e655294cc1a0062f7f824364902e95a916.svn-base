using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace RW.PMS.Utils.Modules
{
    public class VibrationHardWare : Hardware, IHardwareVibration
    {
        private double sensitivity = 1000d;

        /// <summary>
        /// 灵敏度
        /// </summary>
        [DefaultValue(1000d)]
        [Description("灵敏度")]
        public double Sensitivity
        {
            get { return sensitivity; }
            set
            {
                sensitivity = value;
                if (SensitivityChanged != null) SensitivityChanged(this, value);
                SetActual();
            }
        }

        const double g = 9.80665;

        private bool calSensitivity = true;
        [DefaultValue(true)]
        [Description("当SetLocal=true时，仪表是否已经计算过值")]
        public bool CalSensitivity
        {
            get { return calSensitivity; }
            set { calSensitivity = value; }
        }


        protected override void SetActual()
        {
            if (SetLocal)
            {
                double v = 0;
                if (CalSensitivity)
                    v = ValueBase;
                else
                    v = Math.Abs(Math.Round(ValueBase * g * 10000 / sensitivity, 4));//测定值为0-5V电压；实际值=测定电压*98066.5/灵敏度
                Value = (v - ZeroValue) * GainValue;
            }
            else
                Value = ValueBase;
        }

        public event ValueHandler SensitivityChanged;
    }
}
