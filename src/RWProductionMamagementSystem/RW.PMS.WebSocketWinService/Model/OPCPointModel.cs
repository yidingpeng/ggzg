using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.WebSocketWinService.Model
{
    /// <summary>
    /// OPC点位实体类
    /// </summary>
    public class OPCPointModel
    {
        public string OPCDeviceName { get; set; }
        public string OPCTypeCode { get; set; }
        public string OPCValue { get; set; }
        public string Value { get { return OPCDeviceName + OPCValue; } }
    }
}
