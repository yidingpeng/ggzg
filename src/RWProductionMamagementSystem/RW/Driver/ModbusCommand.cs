using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Driver
{
    /// <summary>
    /// 用于描述modbus的命令
    /// </summary>
    public class ModbusCommand
    {
        public const byte READ_COIL = 0x01;
        public const byte WRITE_COIL = 0x05;
        public const byte WRITE_COILS = 0x0F;

        public const byte READ_REGISTER = 0x03;
        public const byte WRITE_REGISTER = 0x06;
        public const byte WRITE_REGISTERS = 0x10;
    }
}
