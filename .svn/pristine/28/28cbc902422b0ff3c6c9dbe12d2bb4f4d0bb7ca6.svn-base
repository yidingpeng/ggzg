using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RW.PMS.WinForm
{
    public class EDAEnums
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public enum ActionType
        {
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 修改
            /// </summary>
            Edit
        }

        /// <summary>
        /// 统一管理操作枚举
        /// </summary>
        public enum ActionEnum
        {
            /// <summary>
            /// 所有
            /// </summary>
            All,
            /// <summary>
            /// 查看
            /// </summary>
            View,
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 修改
            /// </summary>
            Edit,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 克隆
            /// </summary>
            Clone,
            /// <summary>
            /// 审核
            /// </summary>
            Check,
        }



        /// <summary>
        /// 统一工具类型枚举
        /// </summary>
        //public enum GjTypeValueEnum
        //{
        //    /// <summary>
        //    /// 钮力值
        //    /// </summary>
        //    扭力值,
        //    /// <summary>
        //    /// 工装
        //    /// </summary>
        //    工装,
        //    /// <summary>
        //    /// 相机
        //    /// </summary>
        //    相机,

        //}
        /// <summary>
        ///  统一工具类型
        /// </summary>
        public sealed class GjTypeValue
        {
            /// <summary>
            /// 钮力值
            /// </summary>
            public const string TorqueValue = "钮力值";
            /// <summary>
            /// 工装
            /// </summary>
            public const string GongZhuang = "工装";
            /// <summary>
            /// 相机
            /// </summary>
            public const string Camera = "相机";
        }


        /// <summary>
        /// 统一工具类型枚举
        /// </summary>
        public enum GjTypeCodeEnum
        {
            /// <summary>
            /// 扭力扳手
            /// </summary>
            niulibanshou,
            /// <summary>
            /// 工装
            /// </summary>
            gwgongzhuang,
            /// <summary>
            /// 相机
            /// </summary>
            camera,
            /// <summary>
            /// 注油枪
            /// </summary>
            InjectionOilGun,
            /// <summary>
            /// 压机
            /// </summary>
            pressure,
            /// <summary>
            /// 工业手柄
            /// </summary>
            gongyeshoubing,
            /// <summary>
            /// 无线扳手
            /// </summary>
            wuxianbanshou,
        }


        /// <summary>
        /// 统一工具结果值范围比较类型枚举
        /// </summary>
        //public enum GjEqualTypeEnum
        //{
        //    /// <summary>
        //    /// 范围,大于等于 and 小于等于
        //    /// </summary>
        //    范围,
        //    /// <summary>
        //    /// 等于,==
        //    /// </summary>
        //    等于,
        //    /// <summary>
        //    /// 包含，in
        //    /// </summary>
        //    包含,
        //}

        /// <summary>
        /// 统一工具结果值范围比较类型
        /// </summary>
        public sealed class GjEqualType
        {
            /// <summary>
            /// 范围,大于等于 and 小于等于
            /// </summary>
            public const string Scope = "范围";
            /// <summary>
            /// 等于,==
            /// </summary>
            public const string Equre = "等于";
            /// <summary>
            /// 包含，in
            /// </summary>
            public const string Include = "包含";
        }


        /// <summary>
        /// 统一工具结果值范围比较类型枚举
        /// </summary>
        public enum AreaBdCodeEnum
        {
            /// <summary>
            /// 来料区
            /// </summary>
            incommingArea,

            /// <summary>
            /// 拆卸区
            /// </summary>
            disassemblyArea,

            /// <summary>
            /// 分检配料区
            /// </summary>
            checkArea,

            /// <summary>
            /// 小部件组装区
            /// </summary>
            assemblyArea,

            /// <summary>
            /// 总装区
            /// </summary>
            ZassemblyArea,

            /// <summary>
            /// 发货区 
            /// </summary>
            sendArea,

            /// <summary>
            /// 备料区
            /// </summary>
            MaterialArea,

        }


        /// <summary>
        /// 产品装配完成状态: 0：未完成，1：已完成，2：异常下线，3：重新装配 4：返回上一步; 5:例外转序
        /// </summary>
        public enum AssemblyStatus
        {
            /// <summary>
            /// 未完成
            /// </summary>
            notFinish = 0,

            /// <summary>
            /// 完成
            /// </summary>
            finished = 1,

            /// <summary>
            /// 异常下线
            /// </summary>
            errorDown = 2,

            /// <summary>
            /// 重新装配
            /// </summary>
            reAssembly = 3,


            /// <summary>
            /// 返回上一步
            /// </summary>
            BackReturn = 4,


            /// <summary>
            /// 例外转序
            /// </summary>
            Convers = 5,

        }



        /// <summary>
        /// --追溯状态:-1:无状态；0:未完成；1:完成，2:异常下线；3：重新装配; 4:已发货；
        /// </summary>
        public enum FollowStatus
        {
            /// <summary>
            /// 无状态
            /// </summary>
            Non = -1,

            /// <summary>
            /// 未完成
            /// </summary>
            notFinish = 0,

            /// <summary>
            /// 已完成,未发货
            /// </summary>
            finished = 1,

            /// <summary>
            /// 异常下线
            /// </summary>
            errorDown = 2,

            /// <summary>
            /// 重新装配
            /// </summary>
            reAssembly = 3,

            /// <summary>
            /// 已发货
            /// </summary>
            sended = 4,

        }


        /// <summary>
        /// 检验结果:0:不合格；1:合格
        /// </summary>
        public enum CheckResult
        {
            /// <summary>
            /// 无结果
            /// </summary>
            Non = -1,
            /// <summary>
            /// 不合格
            /// </summary>
            NG = 0,

            /// <summary>
            /// 合格
            /// </summary>
            OK = 1,


        }


        ///// <summary>
        ///// 检验结果:0:不合格；1:合格
        ///// </summary>
        //public enum CheckResultMemo
        //{
        //    /// <summary>
        //    /// 不合格
        //    /// </summary>
        //    不合格,

        //    /// <summary>
        //    /// 合格
        //    /// </summary>
        //    合格,


        //}
        /// <summary>
        /// 检验结果:0:不合格；1:合格
        /// </summary>
        public sealed class CheckResultMemo
        {
            /// <summary>
            /// 合格
            /// </summary>
            public const string Qualified = "合格";

            /// <summary>
            /// 不合格
            /// </summary>
            public const string DisQualified = "不合格";
        }

        /// <summary>
        /// 工具物料点位类型
        /// </summary>
        public sealed class GJWLOPCType
        {
            public const string GJWLGet = "gjwlGet";
            public const string GJWLPut = "gjwlPut";
            public const string CameraTemplateNo = "cameraTemplateNo";
            public const string TorqueFormula = "TorqueFormula";
            /// <summary>
            /// 注油偏移量配方
            /// </summary>
            public const string OilOffseFormula = "OilOffseFormula";
            /// <summary>
            /// 注油油脂类型
            /// </summary>
            public const string InjectionOilType = "InjectionOilType";

        }
        /// <summary>
        /// 工位点位类型
        /// </summary>
        public sealed class GWOPCType
        {
            public const string Opc_Red = "Opc_Red";
            public const string Opc_Green = "Opc_Green";
            public const string Opc_Yellow = "Opc_Yellow";
            public const string Opc_OK = "Opc_OK";
            public const string Opc_NG = "Opc_NG";
            public const string Opc_ErrRang = "Opc_ErrRang";
            public const string Opc_CameraEnter = "Opc_CameraEnter";
            /// <summary>
            /// 注油机油脂种类
            /// </summary>
            public const string Opc_InjectionOilType = "OPC_InjectionOilType";
            /// <summary>
            /// 注油偏移量配方
            /// </summary>
            public const string OPC_InjectionOilOffseFormula = "OPC_InjectionOilOffseFormula";
            /// <summary>
            /// 注油机结果反馈
            /// </summary>
            public const string OPC_InjectionOilOK = "OPC_InjectionOilOK";
            /// <summary>
            /// 注油系统油量反馈
            /// </summary>
            public const string OPC_InjectionOilValue = "OPC_InjectionOilValue";


        }


        /// <summary>
        /// 管控方式
        /// </summary>
        public enum ControlType
        {
            /// <summary>
            /// 手动管控
            /// </summary>
            SDGK,
            /// <summary>
            /// 工具管控
            /// </summary>
            GJGK,
            /// <summary>
            /// 物料管控
            /// </summary>
            WLGK,
            /// <summary>
            /// 参数值管控
            /// </summary>
            CSGK,
            /// <summary>
            /// 时间管控
            /// </summary>
            SJGK,
            /// <summary>
            /// 扫码管控
            /// </summary>
            SMGK,
            /// <summary>
            /// 自检管控
            /// </summary>
            ZJGK
        }


        /// <summary>
        /// 压机系统OPC点位
        /// </summary>
        public sealed class PressureOPC
        {
            /// <summary>
            /// 左头-加工成功
            /// </summary>
            public const string I1030 = "Channel1.Device1.I103.0";
            /// <summary>
            /// 左头-加工失败
            /// </summary>
            public const string I1031 = "Channel1.Device1.I103.1";
            /// <summary>
            /// 右头-加工成功
            /// </summary>
            public const string I2030 = "Channel1.Device1.I203.0";
            /// <summary>
            /// 右头-加工失败
            /// </summary>
            public const string I2031 = "Channel1.Device1.I203.1";


            /// <summary>
            /// 左头-位置实时值
            /// </summary>
            public const string ID104 = "Channel1.Device1.ID104";
            /// <summary>
            /// 左头-压力实时值
            /// </summary>
            public const string ID108 = "Channel1.Device1.ID108";
            /// <summary>
            /// 右头-位置实时值
            /// </summary>
            public const string ID204 = "Channel1.Device1.ID204";
            /// <summary>
            /// 右头-压力实时值
            /// </summary>
            public const string ID208 = "Channel1.Device1.ID208";

        }

    }
}
