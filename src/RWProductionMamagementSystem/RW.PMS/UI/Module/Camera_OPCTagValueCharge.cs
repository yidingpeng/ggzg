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


namespace RW.PMS.WinForm.Module
{

    public partial class Camera_OPCTagValueCharge : BaseModule
    {
        public Camera_OPCTagValueCharge()
        {
            this.Driver = Var.opcDriver;
        }

        public override void Init()
        {
            //try
            //{
            //    string localip = PublicVariable.LocalIP;

            //    var dtallTag = DIService.GetService<IBLL_Assembly>().GetCameraOPCTag(localip);

            //    foreach (var item in dtallTag)
            //    {
            //        if (!string.IsNullOrEmpty(item.OPCValue))
            //        {
            //            string caption = item.OPCTypeCode;
            //            string key = item.Value;

            //            this.Register<object>(key, delegate(object value)
            //            {
            //                if (this.current.ContainsKey(key) && this.current[key] == value) return;
            //                this.current[key] = value;
            //                if (NameValueChanged != null) NameValueChanged(this, key, value);
            //            });
                       
            //        }
            //        //相机漏装检测项, 漏装检测项保存在工具配置表的remark字段，多个用,号隔开
            //        if (!string.IsNullOrEmpty(item.Remark) && !string.IsNullOrEmpty(item.OPCDeviceName))
            //        {
            //            string key = item.Remark;

            //            string[] strLostArray = key.Split(',');
            //            foreach (string strLost in strLostArray)
            //            {
            //                key = item.OPCDeviceName.Trim() + strLost;

            //                this.Register<object>(key, delegate(object value)
            //                {
            //                    if (this.current.ContainsKey(key) && this.current[key] == value) return;
            //                    this.current[key] = value;
            //                    if (NameValueChanged != null) NameValueChanged(this, key, value);
            //                });
            //            }
            //        }
            //    }
            //}
            //catch (Exception )
            //{
            //    //System.Windows.Forms.MessageBox.Show("OPC通讯异常！");
            //}

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
