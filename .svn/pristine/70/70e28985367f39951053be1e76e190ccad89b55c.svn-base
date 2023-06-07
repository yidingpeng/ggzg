using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using RW.PMS.Utils.Modules;

namespace RW.PMS.WinForm.Module
{
    public partial class ClearnerTagOPCValueCharge : BaseModule
    {
        public ClearnerTagOPCValueCharge()
        {
            this.Driver = Var.opcDriver;
        }

        public override void Init()
        {

            try
            {

                string ClearnerOPCtags = PublicVariable.GetSysConfig("clearnerOPCtags");
                string[] ClearnerOPCtagName = ClearnerOPCtags.Split(',');

                for (int i = 0; i < ClearnerOPCtagName.Length; i++)
                {

                    string tagName = ClearnerOPCtagName[i];
                    this.Register<object>(tagName, delegate(object value)
                    {
                        if (this.current.ContainsKey(tagName) && this.current[tagName] == value) return;
                        this.current[tagName] = value;
                        if (NameValueChanged != null) NameValueChanged(this, tagName, value);
                    });

                }
              
            }
            catch (Exception )
            {
                System.Windows.Forms.MessageBox.Show("清洗机OPC参数错误！");
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
