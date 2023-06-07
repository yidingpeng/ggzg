using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace RW.PMS.WinForm.Common
{
    /// <summary>
    /// 截图帮助类
    /// </summary>
    public class LeonCaptureHelper
    {
        /// <summary>
        /// 根据窗口截图
        /// </summary>
        /// <param name="handle">窗口句柄</param>
        /// <returns>图片</returns>
        public Image CaptureWindow(IntPtr handle)
        {
            User32.ShowWindow(handle, 3);
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            IntPtr hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            IntPtr hDC = GDI32.CreateCompatibleDC(hdcSrc);
            IntPtr hOld = GDI32.SelectObject(hDC, hBitmap);
            User32.PrintWindow(handle, hDC, 0);
            Image img = Image.FromHbitmap(hBitmap);
            GDI32.DeleteDC(hdcSrc);
            GDI32.DeleteDC(hDC);
            User32.ShowWindow(handle, 2);
            return img;
        }

        /// <summary>
        /// 全屏截图
        /// </summary>
        /// <returns>图片</returns>
        public Image CaptureScreen()
        {
            return CaptureWindow(User32.GetDesktopWindow());
        }

        /// <summary>
        /// 0 关闭窗口
        /// 1 正常大小显示窗口
        /// 2 最小化窗口
        /// 3 最大化窗口
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public int ShowWindow(IntPtr handle, int i)
        {
            return User32.ShowWindow(handle, i);
        }
    }

    /// <summary>
    /// User32 API
    /// </summary>
    public class User32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hDC, UInt32 nFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
    }

    /// <summary>
    /// GDI32 API
    /// </summary>
    public class GDI32
    {
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
            int nHeight);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    }
}