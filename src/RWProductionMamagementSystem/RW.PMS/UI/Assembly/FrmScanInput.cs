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
    public partial class FrmScanInput : FormSkin
    {
        public event EventHandler<string> EnterOnClick;

        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="tilte">窗体标题</param>
        /// <param name="subTitle">提示文本内容</param>
        /// <param name="showCloseButton">默认为不显示关闭窗体按钮</param>
        /// <param name="showControlBox">默认为不显示窗体右上角关闭按钮</param>
        public FrmScanInput(string tilte = "扫码", string subTitle = "条形码", bool showCloseButton = false, bool showControlBox = false)
        {
            InitializeComponent();
            //this.ControlBox = false;
            this.ControlBox = showControlBox;//禁用窗体关闭按钮
            Text = tilte;
            lblQRcode.Text = subTitle;
            btnClose.Visible = showCloseButton;
            this.txtCode.KeyDown += TxtCode_KeyDown;
        }

        /// <summary>
        /// 回车事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterOnClick?.Invoke(this, txtCode.Text);
            }
        }


        /// <summary>
        /// 重新定位label控件位置
        /// </summary>
        /// <param name="x"></param>
        public void lblLocation(int x)
        {
            lblMessage.Location = new Point(x, 89);
        }

        /// <summary>
        /// 清空文本功能
        /// </summary>
        public void clearTxt()
        {
            txtCode.Text = string.Empty;//清空文本功能
        }

        /// <summary>
        /// 显示 提示
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMessage(string msg)
        {
            this.lblMessage.Visible = true;
            this.lblMessage.Text = msg;
            txtCode.Text = string.Empty;//添加错误后清空文本功能
        }

        /// <summary>
        /// 显示 文本框内提示
        /// </summary>
        /// <param name="msg"></param>
        public void ShowHunit(string msg)
        {
            txtCode.Hint = msg;//添加文本框内提示功能
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
