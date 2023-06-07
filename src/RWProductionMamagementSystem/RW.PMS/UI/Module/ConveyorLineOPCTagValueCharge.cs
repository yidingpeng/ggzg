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
    public partial class ConveyorLineOPCTagValueCharge : BaseModule
    {

        public ConveyorLineOPCTagValueCharge()
        {
            this.Driver = Var.opcDriver;
        }


        public override void Init()
        {
            try
            {
                //是否启用输送线配置
                string IsEnableConveyorLine =PublicVariable.GetSysConfig("IsEnableConveyorLine");

                if (IsEnableConveyorLine=="1")
                {
                    string ConveyorLine = PublicVariable.GetSysConfig("ConveyorLineConfigs");
                    string ConveyorLineArea = PublicVariable.GetSysConfig("ConveyorLineAreas");

                    string[] clAreas = ConveyorLineArea.Split(',');

                    bool areaIsExist = clAreas.ToList().Contains(PublicVariable.CurAreaBDCode);

                    //阀类组装区才初始化输送线点位信息
                    if (!string.IsNullOrEmpty(ConveyorLine) && areaIsExist)
                    {

                        //var dtallTag = DIService.GetService<IBLL_System>().GetConfigs(ConveyorLine.Split(','));

                        //foreach (var item in dtallTag)
                        //{
                        //    if (!string.IsNullOrEmpty(item.Value))
                        //    {
                        //        string[] cfgs = item.Value.Split(',');
                        //        foreach (string key in cfgs)
                        //        {

                        //            this.Register<object>(key, delegate(object value)
                        //            {
                        //                if (this.current.ContainsKey(key) && this.current[key] == value) return;
                        //                this.current[key] = value;
                        //                if (NameValueChanged != null) NameValueChanged(this, key, value);
                        //            });
                        //        }

                        //    }

                        //}

                    }
                }
            }
            catch (Exception )
            {
                System.Windows.Forms.MessageBox.Show("组装区输送线OPC参数错误！");
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
