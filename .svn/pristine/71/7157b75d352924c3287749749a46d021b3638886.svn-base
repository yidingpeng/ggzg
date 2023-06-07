using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace RW.PMS.Utils.Modules
{
    public partial class ModuleGroup : Component, IInit, ISupportInitialize
    {
        public ModuleGroup() { }

        public ModuleGroup(IContainer container)
        {
            container.Add(this);
        }

        #region IInit 成员
        private bool autoInit = true;
        [DefaultValue(true)]
        public bool AutoInit
        {
            get { return autoInit; }
            set { autoInit = value; }
        }

        public void Init()
        {
            List<Exception> lst = new List<Exception>();
            inited = false;
            foreach (Component c in this.Container.Components)
            {
                if (c is BaseModule)
                {
                    BaseModule item = c as BaseModule;
                    try
                    {
                        if (!item.IsInitialized) item.Init();
                    }
                    catch (Exception ex)
                    {
                        lst.Add(ex);
                    }
                }
            }
            inited = true;
            if (lst.Count > 0)
            {
                if (InitError == null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (Exception e in lst)
                    {
                        sb.AppendLine(e.Message.ToString());
                    }
                    System.Windows.Forms.MessageBox.Show(sb.ToString());
                }
                else
                {
                    InitError(this, new ExceptionEventArgs(lst[0]));
                }
            }
        }

        private bool inited;
        public bool IsInitialized
        {
            get { return inited; }
        }

        public event EventHandler<ExceptionEventArgs> InitError;

        #endregion

        #region ISupportInitialize 成员

        public void BeginInit()
        {

        }

        public void EndInit()
        {
            if (this.DesignMode) return;
            if (AutoInit && !IsInitialized)
                Init();
        }

        #endregion
    }
}
