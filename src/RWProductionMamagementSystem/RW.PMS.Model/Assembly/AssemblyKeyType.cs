using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    /// <summary>
    /// 生产装配关键信息类型
    /// </summary>
    public enum AssemblyKeyType
    {
        /// <summary>
        /// 物料编码
        /// </summary>
        MaterialCode,
        /// <summary>
        /// 设备
        /// </summary>
        Device
    }

    /// <summary>
    /// 生产装配关键信息设备名称
    /// </summary>
    public enum AssemblyKeyDeviceName
    {
        /// <summary>
        /// 扭力扳手
        /// </summary>
        TorqueEquipment,
        /// <summary>
        /// 拧紧机
        /// </summary>
        TighteningMachine,
        /// <summary>
        /// 调阀机
        /// </summary>
        RegulatingValve
    }

}
