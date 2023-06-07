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
    public partial class FrmTorque : FormSkin
    {
        private decimal maxVal = 0;
        private decimal minVal = 0;
        private Action callback = null;
        private FrmMain frmMain = null;
        public decimal Torque 
        { 
            get 
            { 
                return txtTorque.Value; 
            } 
        }
        public decimal Angle 
        { 
            get 
            { 
                return txtAngle.Value;
            } 
        }

        public FrmTorque(FrmMain frmMain ,decimal maxVal, decimal minVal , Action callback)
        {
            InitializeComponent();
            this.frmMain = frmMain;
            this.maxVal = maxVal;
            this.minVal = minVal;
            this.callback = callback;

            this.btnOK.Click += OKClick;
            this.lblMsg.Text = string.Empty;

        }

         public void SetTorque(decimal torque)
        {
            this.txtTorque.Value = torque;
        }

        public void SetTorque(decimal torque, decimal angle)
        {
            this.txtTorque.Value = torque;

            this.txtAngle.Value = angle;
        }

        public void OKClick(object sender = null, EventArgs e = null)
        {
            if (txtTorque.Value <= 0)
            {
                ShowGJMsg("扭力值不能为零！",true);
                return;
            }

            //if (txtAngle.Value <= 0)
            //{
            //    ShowGJMsg("角度值不能为零！",true);
            //    return;
            //}

            if (txtTorque.Value >= minVal && txtTorque.Value <= maxVal)
            {
                if (callback != null)
                {
                    callback.Invoke();
                }
            }
            else
            {
                ShowGJMsg("扭力值不合格",true);
                frmMain.AddError(11, "扭力值不合格");
            }
        }

        //显示工具的提示信息
        public void ShowGJMsg(string msg, bool isRed = false)
        {
            lblMsg.Text = msg;
            if (isRed)
            {
                lblMsg.ForeColor = Color.Red;
            }
            else
            {
                lblMsg.ForeColor = Color.Blue;
            }
        }
    }
}
