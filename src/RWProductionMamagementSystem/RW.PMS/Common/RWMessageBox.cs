using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RW.PMS.WinForm.Common
{
    /// <summary>
    /// 润伟提示框
    /// </summary>
    public class RWMessageBox
    {

        /// <summary>
        /// 蓝色i提示框.OK按钮
        /// </summary>
        /// <param name="text">提示文本内容</param>
        /// <returns></returns>
        public static DialogResult Show(string text)
        {
            return MessageBox.Show(text, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 黄色感叹号提示框.OK按钮
        /// </summary>
        /// <param name="text">提示文本内容</param>
        /// <returns></returns>
        public static DialogResult ShowExclamation(string text)
        {
            return MessageBox.Show(text, "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }
}