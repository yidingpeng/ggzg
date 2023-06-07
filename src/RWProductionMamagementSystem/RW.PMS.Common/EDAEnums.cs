using System.ComponentModel;

namespace RW.PMS.Common
{
    /// <summary>
    /// 枚举
    /// </summary>
    public class EDAEnums
    {
        public enum YesOrNo
        {
            None = -1,
            Yes = 1,
            No = 0
        }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public enum DataBaseType
        {
            MsSql,
            MySql
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
        public enum GjTypeValueEnum
        {
            /// <summary>
            /// 钮力值
            /// </summary>
            扭力值,
            /// <summary>
            /// 工装
            /// </summary>
            工装,
            /// <summary>
            /// 相机
            /// </summary>
            相机,

        }

        /// <summary>
        /// 统一工具类型枚举
        /// </summary>
        public enum GjTypeCodeEnum
        {
            /// <summary>
            /// 钮力值
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

        }

        /// <summary>
        /// 统一工具结果值范围比较类型枚举
        /// </summary>
        public enum GjEqualTypeEnum
        {
            /// <summary>
            /// 范围,大于等于 and 小于等于
            /// </summary>
            范围,
            /// <summary>
            /// 等于,==
            /// </summary>
            等于,
            /// <summary>
            /// 包含，in
            /// </summary>
            包含,
        }

        /// <summary>
        /// 统一工具结果值范围比较类型枚举(暂无处使用20190819)
        /// </summary>
        public enum AreaBdCodeEnum
        {
            /// <summary>
            /// 来料区
            /// </summary>
            incommingArea,

            /// <summary>
            /// 制动柜拆解区
            /// </summary>
            ZdisassemblyArea,

            /// <summary>
            /// 拆卸区
            /// </summary>
            DisassemblyArea = 34,

            /// <summary>
            /// 外来部件检修区 
            /// </summary>
            MustWlBatchArea,

            /// <summary>
            /// 检验区
            /// </summary>
            checkArea,

            /// <summary>
            /// 探伤区
            /// </summary>
            woundArea,

            /// <summary>
            /// 配料区
            /// </summary>
            batchingArea,

            /// <summary>
            /// 组装区
            /// </summary>
            assemblyArea,

            /// <summary>
            /// 制动柜总装区
            /// </summary>
            ZassemblyArea,

            /// <summary>
            /// 试验区 
            /// </summary>
            testArea,

            /// <summary>
            /// 发货区 
            /// </summary>
            sendArea,

            /// <summary>
            /// 电子部件检修区
            /// </summary>
            ElectronicArea,

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

            /// <summary>
            /// 已入场（未检修）
            /// </summary>
            inHouse = 5
        }

        /// <summary>
        /// 检验结果:0:不合格；1:合格
        /// </summary>
        public enum CheckResult
        {
            /// <summary>
            /// 无结果
            /// </summary>
            [Description("无结果")]
            Non = -1,
            /// <summary>
            /// 不合格
            /// </summary>
            [Description("不合格")]
            NG = 0,
            /// <summary>
            /// 合格
            /// </summary>
            [Description("合格")]
            OK = 1,
        }

        /// <summary>
        /// 检验结果:0:不合格；1:合格
        /// </summary>
        public enum CheckResultMemo
        {
            /// <summary>
            /// 不合格
            /// </summary>
            不合格,
            /// <summary>
            /// 合格
            /// </summary>
            合格,
        }

        /// <summary>
        /// 存放状态
        /// </summary>
        public enum PutStatus
        {
            /// <summary>
            /// 空
            /// </summary>
            Null = 192,
            /// <summary>
            /// 待存
            /// </summary>
            StayPut = 193,
            /// <summary>
            /// 已存
            /// </summary>
            Deposit = 194
        }

        /// <summary>
        /// 计划明细状态
        /// </summary>
        public enum PlanDetailStatus
        {
            /// <summary>
            /// 新建
            /// </summary>
            [Description("新建")]
            New = 1,
            /// <summary>
            /// 缓存区
            /// </summary>
            [Description("缓存区")]
            Cache = 2,
            /// <summary>
            /// 待存
            /// </summary>
            [Description("待存")]
            Write = 3,
            /// <summary>
            /// 已存
            /// </summary>
            [Description("已存")]
            Put = 4,
            /// <summary>
            /// 生产 离场
            /// </summary>
            [Description("生产")]
            Production = 5
        }

        /// <summary>
        /// 库存变动类型
        /// </summary>
        public enum INVChangeType
        {
            [Description("库存盘点")]
            INVCheck = 1,
            [Description("线边库配盘")]
            LWBatching = 2,
            [Description("线边库配盘取消")]
            CancelLWBatching = 3,
            [Description("偶换件入库检验")]
            EvenCheck = 4,
            [Description("偶换件检验取消")]
            CancelEvenCheck = 5
        }

        public enum TempArea
        {
            /// <summary>
            /// 入场存放区
            /// </summary>
            [Description("入场存放区")]
            InComming = 190,
            /// <summary>
            /// 缓存区
            /// </summary>
            [Description("缓存区")]
            Cache = 191,
            /// <summary>
            /// 小风机存放区 208
            /// </summary>
            [Description("小风机存放区")]
            SmallFan = 208,
            /// <summary>
            /// 部件检验存放区 232
            /// </summary>
            [Description("部件检验存放区")]
            PartStore = 232,
            /// <summary>
            /// 分装部件检验存放区 281
            /// </summary>
            [Description("分装部件检验存放区")]
            SeparatePartStore = 281
        }
    }
}
