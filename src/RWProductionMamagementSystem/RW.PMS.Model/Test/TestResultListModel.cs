using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model.Test
{
    public class TestResultListModel
    {

        #region 基础信息
        /// <summary>
        /// 产品型号
        /// </summary>
        public string Modelname { get; set; }
        /// <summary>
        /// 试验人
        /// </summary>
        public string TestUser { get; set; }
        /// <summary>
        /// 试验时间
        /// </summary>
        public string TestTime { get; set; }
        /// <summary>
        /// 试验产品编号
        /// </summary>
        public string TestNo { get; set; }
        /// <summary>
        /// 检验人
        /// </summary>
        public string InspectUser { get; set; }
        /// <summary>
        /// 检验时间
        /// </summary>
        public string InspectTime { get; set; }


        #endregion


        #region 升降弓时间测试


        /// <summary>
        /// 升弓标准最小值√
        /// </summary>
        public int SGTimeMin { get; set; }
        /// <summary>
        /// 升弓标准最大值√
        /// </summary>
        public int SGTimeMax { get; set; }
        /// <summary>
        /// 升弓实际测量值√ 在范围（合格）
        /// </summary>
        public double SGTime { get; set; }


        /// <summary>
        /// 1:合格 0 :不合格
        /// </summary>
        public int? SGFlag
        {
            get
            {
                if (SGTime >= SGTimeMin && SGTime <= SGTimeMax)
                    return 1;
                return 0;
            }
        }


        /// <summary>
        /// 降弓标准最小值√
        /// </summary>
        public int JGTimeMin { get; set; }
        /// <summary>
        /// 降弓标准最大值√
        /// </summary>
        public int JGTimeMax { get; set; }
        /// <summary>
        /// 降弓实际测量值√ 在范围（合格）
        /// </summary>
        public double JGTime { get; set; }


        /// <summary>
        /// 1:合格 0 :不合格
        /// </summary>
        public int? JGFlag
        {
            get
            {
                if (JGTime >= JGTimeMin && JGTime <= JGTimeMax)
                    return 1;
                return 0;
            }
        }


        #endregion

        #region 静态拉力测试


        /// <summary>
        /// 同高差标准值√
        /// </summary>
        public double standardTGC { get; set; }

        /// <summary>
        /// 同高差测量值√ 小于 同高差标准值（合格)
        /// </summary>
        public double realityTGC { get; set; }


        /// <summary>
        /// 1:合格 0 :不合格
        /// </summary>
        public int? TGCFlag
        {
            get
            {
                if (realityTGC < standardTGC)
                    return 1;
                return 0;
            }
        }


        /// <summary>
        /// 中间段标准力值文本
        /// </summary>
        public string standardMidText { get; set; }
        /// <summary>
        /// 中间段标准力值(以","隔开)  （(1,2),3,4）
        /// </summary>
        public string standardMid { get; set; }
        /// <summary>
        /// 中间段测试最小力值
        /// </summary>
        public double realityMidMin { get; set; }
        /// <summary>
        /// 中间段测试最大力值
        /// </summary>
        public double realityMidMax { get; set; }



        /// <summary>
        /// 1:合格 0 :不合格
        /// </summary>
        //public int? MidFlag
        //{
        //    get
        //    {
        //        string[] standardMidStr = standardMid.Split(',');
        //        double midmin = Convert.ToDouble(standardMidStr[0].ToString());
        //        double midmax = Convert.ToDouble(standardMidStr[1].ToString());

        //        if (realityMidMin >= midmin && realityMidMax <= midmax)
        //            return 1;
        //        return 0;
        //    }
        //}


        /// <summary>
        /// 整段标准力值文本
        /// </summary>
        public string standardFullText { get; set; }
        /// <summary>
        /// 整段标准力值(以","隔开)
        /// </summary>
        public string standardFull { get; set; }
        /// <summary>
        /// 整段测试最小力值
        /// </summary>
        public double realityFullMin { get; set; }
        /// <summary>
        /// 整段测试最大力值
        /// </summary>
        public double realityFullMax { get; set; }

        /// <summary>
        /// 1:合格 0 :不合格
        /// </summary>
        //public int? FullFlag
        //{
        //    get
        //    {
        //        string[] standardFullStr = standardFull.Split(',');
        //        double fullmin = Convert.ToDouble(standardFullStr[0]);
        //        double fullmax = Convert.ToDouble(standardFullStr[1]);

        //        if (realityFullMin >= fullmin && realityFullMax <= fullmax)
        //            return 1;
        //        return 0;
        //    }
        //}

        #endregion

        #region 气密性测试
        /// <summary>
        /// 泄漏量标准值
        /// </summary>
        public double standardLeakage { get; set; }
        /// <summary>
        /// 泄漏量测量值
        /// </summary>
        public double realityLeakage { get; set; }
        #endregion

        #region ADD测试
        /// <summary>
        /// ADD时间标准值
        /// </summary> 
        public double standardADDTime { get; set; }
        /// <summary>
        /// ADD时间测量值
        /// </summary>
        public double realityADDTime { get; set; }
        #endregion

        #region 最大高度测试
        /// <summary>
        /// 最大高度标准值 2400
        /// </summary>
        public double standardMaxHeight { get; set; }

        /// <summary>
        /// 最大高度标准正负偏差 50  （2350~ 2450）
        /// </summary>
        public int standardMaxHeightUpDown { get; set; }


        public double standardMaxHeightMax
        {
            get
            {
                return standardMaxHeight + standardMaxHeightUpDown;
            }
        }

        public double standardMaxHeightMin
        {
            get
            {
                return standardMaxHeight - standardMaxHeightUpDown;
            }
        }





        /// <summary>
        /// 最大高度测量值  2401 在范围（合格）
        /// </summary>
        public double realityMaxHeight { get; set; }



        /// <summary>
        /// 1:合格 0 :不合格
        /// </summary>
        public int? realityMaxHeightFlag
        {
            get
            {
                if (realityMaxHeight >= standardMaxHeightMin && realityMaxHeight <= standardMaxHeightMax)
                    return 1;
                return 0;
            }
        }


        #endregion

        #region 称重测试
        /// <summary>
        /// 重量标准最小值
        /// </summary>
        public double standardWeighMin { get; set; }
        /// <summary>
        /// 重量标准最大值
        /// </summary>
        public double standardWeighMax { get; set; }
        /// <summary>
        /// 重量实际测量值
        /// </summary>
        public double realityWeigh { get; set; }
        #endregion

    }
}
