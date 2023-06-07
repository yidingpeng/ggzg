using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.Utils.Torque
{
    public abstract class BaseTorque
    {

        public BaseTorque() 
        { }

        public BaseTorque(Control control)
        {
            Control = control;
        }

        public string TorqueIP { get; set; }

        public int Port { get; set; }

        public string PortName { get; set; }

        public abstract bool ConnectionIsOK { get; }


        public event EventHandler<string> Error;

        public event EventHandler<bool> Online;

        public event EventHandler<TorqueData> DataReceived;

        public Control Control { get; set; }

        public abstract void Connection();

        public abstract void CloseConnection();

        //调用方式可能还要给 现在参照马头 dvI3
        public virtual void StartTorque(object param) 
        {

        }

        protected void ActionError(string msg)
        {
            if (Error != null)
            {
                if (Control != null && !Control.IsDisposed)
                {
                    Control.Invoke(new MethodInvoker(delegate()
                    {
                        Error(this, msg);
                    }));
                }
                else
                {
                    Error(this, msg);
                }
            }
        }

        protected void ActionOnline(bool onLine)
        {
            if (Online != null)
            {
                if (Control != null && !Control.IsDisposed)
                {
                    Control.Invoke(new MethodInvoker(delegate()
                    {
                        Online(this, onLine);
                    }));
                }
                else
                {
                    Online(this, onLine);
                }
            }
        }

        protected void ActionDataReceived(TorqueData data)
        {
            if (DataReceived != null)
            {
                if (Control != null && !Control.IsDisposed)
                {
                    Control.Invoke(new MethodInvoker(delegate()
                    {
                        DataReceived(this, data);
                    }));
                }
                else
                {
                    DataReceived(this, data);
                }
            }
        }
    }

    public class TorqueData
    {
        /// <summary>
        /// 扭力值
        /// </summary>
        public decimal Torque { get; private set; }

        /// <summary>
        /// 角度
        /// </summary>
        public decimal Angle { get; private set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; private set; }

        /// <summary>
        /// 其他
        /// </summary>
        public string Other{get;private set;}


        public TorqueData(decimal torque)
        {
            this.Torque = torque;
        }

        public TorqueData(decimal torque, decimal angle)
        {
            this.Torque = torque;
            this.Angle = angle;
        }

        public TorqueData(decimal torque, decimal angle, int status)
        {
            this.Torque = torque;
            this.Angle = angle;
            this.Status = status;
        }

        public TorqueData(string other)
        {
            this.Other = other;
        }
        
    }

}


