using System;
using System.Text;
using System.Windows.Forms;

namespace RW.PMS.WinForm.Utils
{
    internal class CardOperation
    {
        private IntPtr icdev = IntPtr.Zero;
        private Int16 st;
        private byte[] snr = new byte[5];//卡片序列号
        private Int16 port = 0;    //端口号
        private Int32 baud = 9600;//波特率
        private byte sector = 1;  //扇区号

        private Control _control = null;
        private System.Timers.Timer _timer = null;

        private DateTime _tempTime = DateTime.MinValue;
        /// <summary>
        /// 连接时是否发出声音
        /// </summary>
        public bool IsConnBeep { get; set; }

        /// <summary>
        /// 简易模式
        /// </summary>
        public bool SimpleModel { get; set; }

        public event EventHandler<string> CardReader;

        public CardOperation(Control control)
        {
            _control = control;
            _timer = new System.Timers.Timer(200);
            _timer.Elapsed += _timer_Elapsed;
        }

        public void Open()
        {
            icdev = CardInterop.rf_init(port, baud);  //连接设备
            if (icdev.ToInt32() > 0)
            {
                var status = new byte[30];
                st = CardInterop.rf_get_status(icdev, status);  //读取硬件版本号
                if (IsConnBeep)
                {
                    CardInterop.rf_beep(icdev, 25);
                }

            }
            else
            {
                throw new Exception("连接失败！");
            }
        }

        public void ReadStart()
        {
            _timer.Start();
        }

        public void ReadStop()
        {
            _timer.Stop();
        }

        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            st = CardInterop.rf_card(icdev, (byte)0, snr);//寻卡
            if (SimpleModel)
            {
                byte[] value = new byte[8];
                CardInterop.hex_a(this.snr, value, 4);

                var val = Encoding.Default.GetString(value);

                if (val != "00000000" && (DateTime.Now - _tempTime).TotalSeconds > 2)
                {
                    Reader(value);

                    _tempTime = DateTime.Now;
                }

                return;

            }
            if (st == 0)
            {
                //读取卡号
                var databuffer = new byte[32];
                byte block = Convert.ToByte(sector * 4);
                st = CardInterop.rf_read_hex(icdev, block, databuffer);  //读数据,此函数读出来的是16进制字符串，也就是把每个字节数据的16进制A​S​C​Ⅱ码以字符串形式输出
                if (st == 0)
                {
                    Reader(databuffer);
                }
                else
                {

                }
            }
        }

        private void Reader(byte[] databuffer)
        {
            var value = Encoding.Default.GetString(databuffer);
            if (_control != null && !_control.IsDisposed && CardReader != null)
            {
                _control.Invoke(new MethodInvoker(delegate ()
                {
                    CardReader(this, value);
                }));
            }
        }

        public void Write(string value)
        {
            var bytes = Encoding.Default.GetBytes(value);
            byte block = Convert.ToByte(sector * 4);
            // var retVal = CardInterop.rf_write_hex(icdev, block, bytes);
            var retVal = CardInterop.rf_write(icdev, block, bytes);

        }

        public void Close()
        {
            ReadStop();
            st = CardInterop.rf_exit(icdev);

        }

    }
}
