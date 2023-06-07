using RW.PMS.Common;
using RW.PMS.Model.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.UI.Assembly
{
    public partial class FrmPressure : Form
    {
        public FrmPressure()
        {
            InitializeComponent();

        }

        private void FrmPressure_Load(object sender, EventArgs e)
        {


        }


        ///// <summary>
        ///// 采集 左压力曲线数据
        ///// </summary>
        ///// <param name="pValue">曲线值</param>
        ///// <param name="dValue">位移值</param>
        //private void AddLeftPressure(object pValue,object dValue)
        //{
        //    //采集曲线值
        //    var curJarPressureValue = pValue.ToDouble();
        //    if (curJarPressureValue == 0)
        //        return;
        //    //采集位移值
        //    var curDisplacementValue = dValue.ToDouble();
        //    curPressureCurveList.PressureCurveLeft.Add(new PressureCurve() { PValue = curJarPressureValue, DValue = curDisplacementValue });
        //    ctPressureCurveLeft.Series[0].Points.AddY(curJarPressureValue);
        //}

        ///// <summary>
        ///// 采集 右压力曲线数据
        ///// </summary>
        ///// <param name="pValue">曲线值</param>
        ///// <param name="dValue">位移值</param>
        //private void AddRightPressure(object pValue, object dValue)
        //{
        //    //采集曲线值
        //    var curJarPressureValue = pValue.ToDouble();
        //    if (curJarPressureValue == 0)
        //        return;
        //    //采集位移值
        //    var curDisplacementValue = dValue.ToDouble();
        //    curPressureCurveList.PressureCurveRight.Add(new PressureCurve() { PValue = curJarPressureValue, DValue = curDisplacementValue });
        //    ctPressureCurveRight.Series[0].Points.AddY(curJarPressureValue);
        //}


        /// <summary>
        /// 左侧 底架轴轴承压力曲线
        /// </summary>
        /// <param name="x">位移值</param>
        /// <param name="y">压力值</param>
        public void pressureCurveLeft_Change(object x, object y)
        {
            //ctPressureCurveLeft.Series[0].Points.AddY(e);
            ctPressureCurveLeft.Series[0].Points.AddXY(x, y);
        }


        /// <summary>
        /// 右侧 肘接轴压力曲线
        /// </summary>
        /// <param name="x">位移值</param>
        /// <param name="y">压力值</param>
        public void pressureCurveRight_Change(object x, object y)
        {
            ctPressureCurveRight.Series[0].Points.AddXY(x, y);
        }


        public void BtnShow(bool show)
        {
            btnCanel.Visible = show;
        }



        private void btnCanel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

    }

}
