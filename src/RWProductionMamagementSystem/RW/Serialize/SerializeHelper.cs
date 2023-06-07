using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Serialize
{
    public static class SerializeHelper
    {
        public static ISerialize Instance = new JsonSerialize();
    }
}
