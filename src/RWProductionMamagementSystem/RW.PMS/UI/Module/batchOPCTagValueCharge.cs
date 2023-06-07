using RW.PMS.Utils.Modules;
using RW.PMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace RW.PMS.WinForm.Module
{
    /// <summary>
    /// 
    /// </summary>
    public partial class batchOPCTagValueCharge : BaseModule
    {
        public batchOPCTagValueCharge()
        {
            string strAutoInitOPC = "";
            try
            {
                strAutoInitOPC = ConfigurationManager.AppSettings["AutoInitOPC"];//是否自动打开OPC
                if (strAutoInitOPC == "1")
                {
                    this.Driver = Var.opcDriver;
                }
            }
            catch (Exception)
            {
            }
        }

        public override void Init()
        {
            base.Init();
        }
    }
}
