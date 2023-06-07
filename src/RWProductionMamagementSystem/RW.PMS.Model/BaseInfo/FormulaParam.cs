using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.BaseInfo
{
    public class FormulaParam
    {
        /// <summary>
        /// 螺栓拧紧个数
        /// </summary>
        public string BoltsNum { get; set; }

        /// <summary>
        /// 拧紧轴1程序号
        /// </summary>
        public string TighteningNum { get; set; }

        /// <summary>
        /// 拧紧轴2程序号
        /// </summary>
      //  public string TighteningNum2 { get; set; }

        /// <summary>
        /// 拧紧升降变频速度（%）
        /// </summary>
        public string TightenSJSpeed { get; set; }


        /// <summary>
        /// 拧紧升降变频准备
        /// </summary>
        public string TightenSJReady { get; set; }


        /// <summary>
        /// 拧紧升降变频最终位置
        /// </summary>
        public string TightenSJFinal { get; set; }

        /// <summary>
        /// 定心机构初始位
        /// </summary>
        public string CenteringReady { get; set; }

        /// <summary>
        /// 定心机构定心位
        /// </summary>
        public string CenteringPosition { get; set; }

        /// <summary>
        /// 定心机构速度
        /// </summary>
        public string CenteringSpeed { get; set; }

        /// <summary>
        /// Y轴平移伺服初始位
        /// </summary>
        public string YReady { get; set; }

        /// <summary>
        /// Y轴平移伺服装配位
        /// </summary>
        public string YAssembly { get; set; }

        /// <summary>
        /// Y轴平移伺服速度
        /// </summary>
        public string YSpeed { get; set; }

        /// <summary>
        /// X轴平移伺服初始位
        /// </summary>
        public string XReady { get; set; }

        /// <summary>
        /// X轴平移伺服装配位
        /// </summary>
        public string XAssembly { get; set; }

        /// <summary>
        /// X轴平移伺服速度
        /// </summary>
        public string XSpeed { get; set; }

        /// <summary>
        /// Z轴平移伺服初始位
        /// </summary>
        public string ZReady { get; set; }

        /// <summary>
        /// Z轴平移伺服装配位
        /// </summary>
        public string ZAssembly { get; set; }

        /// <summary>
        /// Z轴平移伺服速度
        /// </summary>
        public string ZSpeed { get; set; }

        /// <summary>
        /// 平移伺服1初始位
        /// </summary>
        public string OneReady { get; set; }

        /// <summary>
        /// 平移伺服1最终位
        /// </summary>
        public string OneFinal { get; set; }

        /// <summary>
        /// 平移伺服1速度
        /// </summary>
        public string OneSpeed { get; set; }

        /// <summary>
        /// 平移伺服2初始位
        /// </summary>
        public string TwoReady { get; set; }

        /// <summary>
        /// 平移伺服2最终位
        /// </summary>
        public string TwoFinal { get; set; }

        /// <summary>
        /// 平移伺服2速度
        /// </summary>
        public string TwoSpeed { get; set; }

        /// <summary>
        /// 旋转伺服初始位
        /// </summary>
        public string RotateReady { get; set; }

        /// <summary>
        /// 旋转伺服最终位(弃用)
        /// </summary>
        //public string RotateFinal { get; set; }

        /// <summary>
        /// 旋转伺服速度
        /// </summary>
        public string RotateSpeed { get; set; }

        /// <summary>
        /// 辅助支撑定位位置
        /// </summary>
        public string Support { get; set; }

        /// <summary>
        /// 螺栓间隔角度
        /// </summary>
        public string SpacingAngle { get; set; }

        /// <summary>
        /// Z轴伺服升降到位的力
        /// </summary>
        public string ZSJInPlace { get; set; }
        /// <summary>
        /// Y轴平移伺服准备位
        /// </summary>
        public string YSJprepare { get; set; }
        /// <summary>
        /// Z轴升降伺服装螺栓位
        /// </summary>
        public string Zbolt { get; set; }
        /// <summary>
        /// Z轴升降伺服装螺栓位速度
        /// </summary>
        public string ZboltSpeed { get; set; }
        /// <summary>
        /// 单个螺栓的位置
        /// </summary>
        public string OneBlotPosition { get; set; }
    }
}
