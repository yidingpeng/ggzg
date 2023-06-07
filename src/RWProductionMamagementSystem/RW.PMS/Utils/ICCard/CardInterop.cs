using System;
using System.Runtime.InteropServices;

namespace RW.PMS.WinForm.Utils
{
    internal static class CardInterop
    {
        #region 加载读卡器的DLL

        [DllImport("mwrf32.dll", EntryPoint = "rf_init", SetLastError = true,
               CharSet = CharSet.Auto, ExactSpelling = false,
               CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr rf_init(Int16 port, int baud);

        [DllImport("mwrf32.dll", EntryPoint = "rf_exit", SetLastError = true,
               CharSet = CharSet.Auto, ExactSpelling = false,
               CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_exit(IntPtr icdev);

        [DllImport("mwrf32.dll", EntryPoint = "rf_beep", SetLastError = true,
               CharSet = CharSet.Auto, ExactSpelling = false,
               CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_beep(IntPtr icdev, int msec);

        [DllImport("mwrf32.dll", EntryPoint = "rf_get_status", SetLastError = true,
              CharSet = CharSet.Auto, ExactSpelling = false,
              CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_get_status(IntPtr icdev, byte[] state);

        [DllImport("mwrf32.dll", EntryPoint = "rf_load_key", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_load_key(IntPtr icdev, byte mode, byte secnr, byte[] keybuff);

        [DllImport("mwrf32.dll", EntryPoint = "rf_load_key_hex", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_load_key_hex(IntPtr icdev, byte mode, byte secnr, byte[] keybuff);


        [DllImport("mwrf32.dll", EntryPoint = "a_hex", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 a_hex(byte[] asc, byte[] hex, Int16 len);

        [DllImport("mwrf32.dll", EntryPoint = "hex_a", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 hex_a(byte[] hex, byte[] asc, Int16 len);

        [DllImport("mwrf32.dll", EntryPoint = "rf_reset", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_reset(IntPtr icdev, Int16 msec);

        [DllImport("mwrf32.dll", EntryPoint = "rf_request", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_request(IntPtr icdev, byte mode, out UInt16 tagtype);


        [DllImport("mwrf32.dll", EntryPoint = "rf_anticoll", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_anticoll(IntPtr icdev, byte bcnt, out UInt32 snr);

        [DllImport("mwrf32.dll", EntryPoint = "rf_select", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_select(IntPtr icdev, UInt32 snr, out byte size);

        [DllImport("mwrf32.dll", EntryPoint = "rf_card", SetLastError = true,
            CharSet = CharSet.Auto, ExactSpelling = false,
            CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_card(IntPtr icdev, byte mode, byte[] snr); //这里将第三个参数设置为byte数组，以便直接返回16进制卡号
        //public static extern Int16 rf_card(IntPtr icdev, int mode, out UInt32 snr);

        [DllImport("mwrf32.dll", EntryPoint = "rf_read", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_read(IntPtr icdev, byte blocknr, byte[] databuff);

        [DllImport("mwrf32.dll", EntryPoint = "rf_read_hex", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_read_hex(IntPtr icdev, byte blocknr, byte[] databuff);

        [DllImport("mwrf32.dll", EntryPoint = "rf_write_hex", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_write_hex(IntPtr icdev, int blocknr, byte[] databuff);

        [DllImport("mwrf32.dll", EntryPoint = "rf_write", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_write(IntPtr icdev, byte blocknr, byte[] databuff);

        [DllImport("mwrf32.dll", EntryPoint = "rf_halt", SetLastError = true,
             CharSet = CharSet.Auto, ExactSpelling = false,
             CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_halt(IntPtr icdev);

        [DllImport("mwrf32.dll", EntryPoint = "rf_changeb3", SetLastError = true,
            CharSet = CharSet.Auto, ExactSpelling = false,
            CallingConvention = CallingConvention.StdCall)]
        public static extern Int16 rf_changeb3(IntPtr icdev, byte sector, byte[] keya, byte B0, byte B1,
              byte B2, byte B3, byte Bk, byte[] keyb);

        #endregion
    }
}
