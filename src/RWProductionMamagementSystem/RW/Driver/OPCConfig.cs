using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Driver
{
    public class OPCConfig
    {
        private string serverName;
        public string ServerName { get { return serverName; } set { serverName = value; } }

        private string prefix;
        public string Prefix { get { return prefix; } set { prefix = value; } }

        private string ip;
        public string IP { get { return ip; } set { ip = value; } }
    }
}
