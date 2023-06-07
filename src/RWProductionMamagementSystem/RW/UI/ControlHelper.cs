using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace RW.PMS.Utils.UI
{
    /// <summary>
    /// 控件帮助类
    /// </summary>
    public static class ControlHelper
    {
        public delegate void Del();
        public delegate void Callback_Error(Control control, Exception ex);

        public static int timeLimit;

        /// <summary>
        /// 提供控件的异步点击行为，点击后设置Enabled为false，调用指定的方法，执行完毕后设置为Enabled=true。
        /// </summary>
        public static void ButtonClickAsync(object sender, Del del, Callback_Error error_callback, int timeLimit)
        {
            Control button = sender as Control;
            bool b = false;
            ThreadPool.QueueUserWorkItem(delegate
            {
                Thread.Sleep(timeLimit);
                if (!b)
                    ControlHelper.Invoke(sender, delegate { button.Enabled = false; });
            });
            //button.Enabled = false;
            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                    //Thread.Sleep(50);
                    del();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    error_callback(button, ex);
                    //MessageBox.Show(button.FindForm(), string.IsNullOrEmpty(message) ? ex.Message.ToString() : message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    b = true;
                    ControlHelper.Invoke(sender, delegate
                    {
                        button.Enabled = true;
                    });
                }
            });
        }

        public static void ButtonClickAsync(object sender, Del del, string message, int timeLimit)
        {
            ButtonClickAsync(sender, del, delegate(Control control, Exception ex)
            {
                MessageBox.Show(control.FindForm(), string.IsNullOrEmpty(message) ? ex.Message.ToString() : message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }, 100);
        }

        public static void ButtonClickAsync(object sender, Del del, int timeLimit)
        {
            ButtonClickAsync(sender, del, "", timeLimit);
        }

        public static void ButtonClickAsync(object sender, Del del)
        {
            ButtonClickAsync(sender, del, 100);
        }

        /// <summary>
        /// 调用
        /// </summary>
        /// <param name="forms"></param>
        /// <param name="del"></param>
        public static void Invoke(object forms, Del del)
        {
            Control c = forms as Control;
            try
            {
                if (c!=null && !c.IsDisposed && c.Created && c.InvokeRequired)
                {
                    c.Invoke(del);
                }
                else
                {
                    del();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                Debug.WriteLine("---------------");
                Debug.WriteLine(ex.StackTrace);
                MessageBox.Show("系统错误：" + ex.Message.ToString(), "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Bitmap GetBitmap(Control uc, Rectangle rec)
        {
            //Bitmap bit = new Bitmap(rec.Width, rec.Height);//
            Bitmap bit = new Bitmap(uc.Width, uc.Height);

            uc.DrawToBitmap(bit, uc.ClientRectangle);
            //Graphics g = Graphics.FromImage(bit);
            //g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            //Point pd = new Point(0, 0);
            //Point ps = uc.PointToScreen(pd);
            ////Debug.WriteLine(p.X, p.Y);
            //g.CopyFromScreen(source, destination, picSize);

            //uc.DrawToBitmap(bit, uc.ClientRectangle);

            Bitmap map = (Bitmap)bit.GetThumbnailImage(rec.Width, rec.Height, null, IntPtr.Zero);
            return map;
        }

        public static Bitmap GetBitmap(Control uc, Size size)
        {
            return GetBitmap(uc, new Rectangle(new Point(0, 0), size));
        }

        public static Bitmap GetBitmap(Control uc, Point location, Size size)
        {
            return GetBitmap(uc, new Rectangle(location, size));
        }
    }
}
