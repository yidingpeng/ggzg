using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Common.Logger;
using SocketHelper;
using System.Net.Sockets;
using System.Net;

namespace RW.PMS.WinForm.Utils.Torque
{
    public class Torque_AtlasPF600_1 : BaseTorque, IDisposable
    {

        private AxTcpServer _axTcpServer = null;

        public override bool ConnectionIsOK
        {
            get { return true; }
        }

        public Torque_AtlasPF600_1()
        {
            _axTcpServer = new AxTcpServer();
            _axTcpServer.OnStateInfo += _axTcpClient_OnStateInfo;
            _axTcpServer.OnErrorMsg += _axTcpClient_OnErrorMsg;
            _axTcpServer.OnReceviceByte += ReceviceByteEventHandler;
        }

        private void ReceviceByteEventHandler(Socket temp, byte[] data)
        {

            /*
                * 数据输出格式："finalTorque" : XX.XX,"finalAngle" : XXXX.XX,"status" : X
                    说明："finalTorque" : XX.XX为最终扭矩数值
                "finalAngle" : XXXX.XX为最终的角度设置
                "status" : X为扭矩状态，0为扭矩OK，1为扭矩NOK，9为反松
            */
            //以文本转ASCIIEncoding转码形式显示数据
            var receiveResult = Encoding.ASCII.GetString(data);
            if (receiveResult.Contains("\""))
            {
                receiveResult = receiveResult.Replace("\"", "");
            }
            if (!receiveResult.StartsWith("finalTorque"))
            {
                return;
            }

            var items = receiveResult.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var finalTorque = string.Empty;
            var finalAngle = string.Empty;
            var status = string.Empty;
            if (items.Count() == 3)
            {
                var item = items[0].Split(':');
                if (item.Count() == 2)
                {
                    finalTorque = item[1];
                }
                var item1 = items[1].Split(':');
                if (item1.Count() == 2)
                {
                    finalAngle = item1[1];
                }
                var item2 = items[2].Split(':');
                if (item2.Count() == 2)
                {
                    status = item2[1];
                }
            }

            decimal torque = 0;
            decimal angle = 0;
            int intStatus = -1;
            decimal.TryParse(finalTorque, out torque);
            decimal.TryParse(finalAngle, out angle);
            int.TryParse(status, out intStatus);
            ActionDataReceived(new TorqueData(torque, angle, intStatus));
        }

        private void _axTcpClient_OnErrorMsg(string msg)
        {
            Logger.Default.Error(msg);
        }

        private void _axTcpClient_OnStateInfo(string msg, SocketState state)
        {

        }

        public override void Connection()
        {
            if (string.IsNullOrEmpty(TorqueIP))
            {
                throw new Exception("TorqueIP 不能为空！");
            }
            if (Port == 0)
            {
                throw new Exception("Port 不能为0！");
            }
            _axTcpServer.ServerIp = SysConfig.LocalIP;
            _axTcpServer.ServerPort = Port;
            _axTcpServer.Start();
        }

        public override void CloseConnection()
        {
           // _axTcpServer.IsStartListening = false;
            _axTcpServer.Dispose();
            
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
