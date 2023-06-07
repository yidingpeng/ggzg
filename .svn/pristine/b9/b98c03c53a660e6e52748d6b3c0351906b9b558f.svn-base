using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RW.PMS.Common;
using RW.PMS.Common.Logger;
using RW.PMS.IBLL;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.Sys;
using RW.PMS.Utils;
using RW.PMS.WinForm.Module;

namespace RW.PMS.WinForm
{
    internal class SysStatusBar :IDisposable
    {
        IBLL_System _systemBLL = DIService.GetService<IBLL_System>();

        /// <summary>
        /// 获取网络状态
        /// </summary>
        public event EventHandler<bool> PingNetworkStatus;

        /// <summary>
        /// 获取OPC设备状态
        /// </summary>
        public event EventHandler<bool> OPCDeviceStatus;

        private Control _control = null;

        private OPCTagValueCharge _opcTag = null;

        private Thread _timeThread = null;

        public SysStatusBar(Control control, OPCTagValueCharge opcTag)
        {
            this._control = control;
            this._opcTag = opcTag;
            Init();

            _timeThread = new Thread(NetworkAndOPCDeviceStatus);
            _timeThread.IsBackground = true;
            _timeThread.Start();
        }

        /// <summary>
        /// 获取比对照片图片
        /// </summary>
        /// <returns></returns>
        //public byte[] GetLastCameraFile()
        //{
        //    byte[] img = null;
        //    var dicInfo = new DirectoryInfo(SysConfig.CameraPath);
        //    var fileInfo = dicInfo.GetFiles().OrderBy(n => n.LastWriteTime).LastOrDefault();

        //    if (fileInfo != null)
        //    {
        //        using (var fileStream = fileInfo.OpenRead())
        //        {
        //            byte[] bytedata = new byte[fileStream.Length];
        //            fileStream.Read(bytedata, 0, bytedata.Length);
        //        }
        //    }

        //    return img;
        //}

        private void Init()
        {
            Logger.AppName = "装配管理系统";
            Logger.IPAddress = SysConfig.LocalIP;
            Logger.UserName = PublicVariable.CurEmpName;
        }

        private void NetworkAndOPCDeviceStatus()
        {
            try
            {
                while (true)
                {
                    var networkStatus = false;
                    var plcStatus = false;

                    string mes = string.Empty;
                    var status = NetworkHelper.Ping(SysConfig.ServerIP);
                    if (status)
                    {
                        networkStatus = true;
                    }
                    if (PingNetworkStatus != null && !_control.IsDisposed)
                    {
                        _control.Invoke(new MethodInvoker(delegate()
                        {
                            PingNetworkStatus(this, networkStatus);
                        }));
                    }

                    var opcstatus = _opcTag.PLCstatus(SysConfig.PLCTag);
                    if (opcstatus)
                    {
                        plcStatus = true;
                    }
                    if (OPCDeviceStatus != null && !_control.IsDisposed)
                    {
                        _control.Invoke(new MethodInvoker(delegate ()
                        {
                            OPCDeviceStatus(this, plcStatus);
                        }));
                    }

                    Thread.Sleep(SysConfig.PingServerTimer * 1000);
                }

            }
            catch (Exception ex)
            {
                Logger.Default.Error("获取网络和设备状态出错！" + ex.Message);
            }
        }

        public void Dispose()
        {
            try
            {

                if (_timeThread != null)
                {
                    _timeThread.Abort();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
