using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using RW.PMS.Utils.Modules;
using RW.PMS.Common;
using RW.PMS.IBLL;
using System.Configuration;


namespace RW.PMS.WinForm.Module
{

    public partial class TemperatureOPCTagValueCharge : BaseModule
    {
        public TemperatureOPCTagValueCharge()
        {
            this.Driver = Var.opcDriver;
        }


        public override void Init()
        {

            try
            {
                //获取温湿仪点位
                string TemperatureOPCtags = PublicVariable.GetSysConfig("ETemperatureOPCTag");
                string[] TemperatureOPCtagName = TemperatureOPCtags.Split(',');

                for (int i = 0; i < TemperatureOPCtagName.Length; i++)
                {
                    string tagName = TemperatureOPCtagName[i];
                    this.Register<object>(tagName, delegate(object value)
                    {
                        if (this.current.ContainsKey(tagName) && this.current[tagName] == value) return;
                        this.current[tagName] = value;
                        if (NameValueChanged != null) NameValueChanged(this, tagName, value);
                    });

                }

            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("温湿仪OPC参数错误！");
            }
            base.Init();

        }

        private Dictionary<string, object> current = new Dictionary<string, object>();

        public Dictionary<string, object> Current
        {
            get { return current; }
        }

        public void SetLed(string name, object value)
        {
            this.Write(name, value);
        }

        /// <summary>
        /// 指定的点位的值发生变化触发的事件
        /// </summary>
        public event NameValueHandler<object> NameValueChanged;

    }
}
