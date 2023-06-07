using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Utils;
using RW.PMS.Utils.Modules;
using RW.PMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using RW.PMS.Common.Logger;
using System.Threading.Tasks;
using System.Threading;

namespace RW.PMS.WinForm.OPC
{
    /// <summary>
    /// OPC点位类
    /// </summary>
    public class OPC_Function
    {
        /// <summary>
        /// 工位三色灯黄色类点位
        /// </summary>
        public string CurGwYellowOPC { get; private set; }

        /// <summary>
        /// 工位三色灯绿色类点位
        /// </summary>
        public string CurGwGreenOPC { get; private set; }

        /// <summary>
        /// 工位三色灯红色类点位
        /// </summary>
        public string CurGwRedOPC { get; private set; }

        /// <summary>
        /// 警鸣灯点位
        /// </summary>
        public string CurGwErrRangOPC { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(int isGwHasThreeLight = 0)
        {
            //装配系统的工位机是否有三色灯 获取配置信息
            if (isGwHasThreeLight == 0)
                isGwHasThreeLight = PublicVariable.GetSysConfig("isGwHasThreeLight").ToInt();
            if (isGwHasThreeLight == 0) return;

            if (PublicVariable.GWModel == null)
                throw new Exception("获取工位信息出错！");
            if (PublicVariable.GWModel.OPC.Count() == 0) return;

            //获取三色灯黄灯地址
            CurGwYellowOPC = GetGWOPCValue(PublicVariable.GWModel.OPC, EDAEnums.GWOPCType.Opc_Yellow);
            if (string.IsNullOrEmpty(CurGwYellowOPC) && isGwHasThreeLight == 1)
            {
                throw new Exception("获取黄色指示灯OPC点位失败！请检查OPC");
            }

            //获取三色灯绿灯地址
            CurGwGreenOPC = GetGWOPCValue(PublicVariable.GWModel.OPC, EDAEnums.GWOPCType.Opc_Green);
            if (string.IsNullOrEmpty(CurGwGreenOPC) && isGwHasThreeLight == 1)
            {
                throw new Exception("获取绿色指示灯OPC点位失败！请检查OPC");
            }

            //获取三色灯红灯地址
            CurGwRedOPC = GetGWOPCValue(PublicVariable.GWModel.OPC, EDAEnums.GWOPCType.Opc_Red);
            if (string.IsNullOrEmpty(CurGwRedOPC) && isGwHasThreeLight == 1)
            {
                throw new Exception("获取红色指示灯OPC点位失败！请检查OPC");
            }

            ////获取蜂鸣器地址
            //CurGwErrRangOPC = GetGWOPCValue(PublicVariable.GWModel.OPC, EDAEnums.GWOPCType.Opc_ErrRang);
            //if (string.IsNullOrEmpty(CurGwErrRangOPC) && isGwHasThreeLight == 1)
            //{
            //    throw new Exception("获取警鸣器OPC点位失败！请检查OPC");
            //}
        }

        /// <summary>
        /// 黄色灯亮
        /// </summary>
        public void YellowLight(BaseModule opcTagValueCharge)
        {
            try
            {
                Task.Run(() =>
                {
                    OpcTagWriteValue(CurGwYellowOPC, 2, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwGreenOPC, false, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwRedOPC, false, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwErrRangOPC, false, opcTagValueCharge);
                });
            }
            catch (Exception ex)
            {
                Logger.Default.Error("黄色灯亮失败", ex);
            }
        }

        /// <summary>
        /// 绿色灯亮
        /// </summary>
        public void GreenLight(BaseModule opcTagValueCharge)
        {
            try
            {
                Task.Run(() =>
                {
                    //OpcTagWriteValue(CurGwYellowOPC, false, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwGreenOPC, true, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwRedOPC, false, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwErrRangOPC, false, opcTagValueCharge);

                    OpcTagWriteValue(CurGwGreenOPC, 1, opcTagValueCharge);
                });
            }
            catch (Exception ex)
            {
                Logger.Default.Error("绿色灯亮失败", ex);
            }
        }

        /// <summary>
        /// 红色+警鸣灯亮
        /// </summary>
        /// <param name="timer">亮灯+警鸣的时间控件</param>
        public void RedLight(BaseModule opcTagValueCharge)
        {
            try
            {
                Task.Run(() =>
                {
                    //要亮报警红灯，并鸣警
                    //OpcTagWriteValue(CurGwYellowOPC, false, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwGreenOPC, false, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwRedOPC, true, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwErrRangOPC, true, opcTagValueCharge);

                    OpcTagWriteValue(CurGwRedOPC, 4, opcTagValueCharge);
                });
            }
            catch (Exception ex)
            {
                Logger.Default.Error("红色+警鸣灯亮失败", ex);
            }
        }

        /// <summary>
        /// 关闭所有三色灯
        /// </summary>
        public void CloseLight(BaseModule opcTagValueCharge)
        {
            try
            {
                Task.Run(() =>
                {
                    //OpcTagWriteValue(CurGwYellowOPC, false, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwGreenOPC, false, opcTagValueCharge);
                    OpcTagWriteValue(CurGwGreenOPC, 1, opcTagValueCharge);
                    //OpcTagWriteValue(CurGwErrRangOPC, false, opcTagValueCharge);
                });
            }
            catch (Exception ex)
            {
                Logger.Default.Error("关闭所有三色灯失败", ex);
            }
        }

        /// <summary>
        /// 往指定的opc点位里写值 Bool 类型
        /// </summary>
        /// <param name="tagKey"></param>
        /// <param name="tagValue">bool 类型</param>
        /// <param name="opcTagValueCharge"></param>
        public void OpcTagWriteValue(string tagKey, bool tagValue, BaseModule opcTagValueCharge)
        {
            try
            {
                if (opcTagValueCharge == null)
                    return;

                if (!string.IsNullOrEmpty(tagKey))
                    opcTagValueCharge.Write(tagKey, tagValue ? 1 : 0);
            }
            catch (Exception ex)
            {
                Logger.Default.Error(string.Format("点位{0}写值{1}失败!", tagKey, tagValue) + ex.Message, ex);
            }
        }

        /// <summary>
        /// 往指定的opc点位里写值 int 类型
        /// </summary>
        /// <param name="tagKey"></param>
        /// <param name="tagValue">int 类型</param>
        /// <param name="opcTagValueCharge"></param>
        public void OpcTagWriteValue(string tagKey, int tagValue, BaseModule opcTagValueCharge)
        {
            try
            {
                if (opcTagValueCharge == null)
                    return;

                if (!string.IsNullOrEmpty(tagKey))
                {
                    Thread.Sleep(100);
                    opcTagValueCharge.Write(tagKey, tagValue);
                }
            }
            catch (Exception ex)
            {
                Logger.Default.Error(string.Format("点位{0}写值{1}失败!", tagKey, tagValue) + ex.Message, ex);
            }

        }

        /// <summary>
        /// 往指定的opc点位里写值 double 类型
        /// </summary>
        /// <param name="tagKey"></param>
        /// <param name="tagValue">double 类型</param>
        /// <param name="opcTagValueCharge"></param>
        public void OpcTagWriteValue(string tagKey, double tagValue, BaseModule opcTagValueCharge)
        {
            try
            {
                if (opcTagValueCharge == null)
                    return;

                if (!string.IsNullOrEmpty(tagKey))
                {
                    Thread.Sleep(100);
                    opcTagValueCharge.Write(tagKey, tagValue);
                }
            }
            catch (Exception ex)
            {
                Logger.Default.Error(string.Format("点位{0}写值{1}失败!", tagKey, tagValue) + ex.Message, ex);
            }

        }


        //读取指定的opc点位值
        public bool OpcTagReadValue(string tagKey, BaseModule opcTagValueCharge)
        {
            if (opcTagValueCharge == null)
                return false;

            var res = OpcTagReadValueByInt(tagKey, opcTagValueCharge);

            return res == 1;
        }

        public int OpcTagReadValueByInt(string tagKey, BaseModule opcTagValueCharge)
        {
            if (opcTagValueCharge == null)
                return 0;

            var obj = opcTagValueCharge.Read(tagKey);
            var boolVal = false;
            var intVal = 0;
            if (bool.TryParse(obj.ToString(), out boolVal))
            {
                return boolVal ? 1 : 0;
            }
            else if (int.TryParse(obj.ToString(), out intVal))
            {
                return intVal;
            }
            else
            {
                throw new Exception(string.Format("点位{0}读取错误!值为:{1}", tagKey, obj));
            }
        }

        /// <summary>
        /// 灭掉所有灯
        /// </summary>
        /// <param name="opcTagValueCharge"></param>
        public void ClearOPCtag(List<GwGJWLOPCPointModel> allOPCTag, BaseModule opcTagValueCharge)
        {
            string curtag = string.Empty;
            try
            {
                if (opcTagValueCharge == null)
                    return;
               
                foreach (var item in allOPCTag)
                {
                    OpcTagWriteValue(item.Value, false, opcTagValueCharge);
                }
                OpcTagWriteValue(CurGwGreenOPC, 1, opcTagValueCharge);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("灭掉所有灯失败,点位：" + curtag, ex);
                //MessageBox.Show(ex.Message + "点位："+curtag);
            }
        }

        /// <summary>
        /// 获取工具物料OPC点位信息
        /// </summary>
        /// <param name="gjwlOpcType"></param>
        public string GetGJWLOPCValue(IEnumerable<GJOPCType> gjwlOPCTypes, string gjwlOpcType)
        {
            var value = string.Empty;
            var detail = gjwlOPCTypes.Where(f => f.Code == gjwlOpcType).FirstOrDefault();
            if (detail != null && !string.IsNullOrEmpty(detail.Value))
            {
                value = detail.OPCDeviceName + detail.Value;
            }
            return value;
        }

        /// <summary>
        /// 根据OPC点位类型获取OPC点位信息
        /// </summary>
        /// <param name="OPC">OPC点位集合</param>
        /// <param name="gwOPCType">OPC点位类型</param>
        /// <returns>OPC点位信息</returns>
        public string GetGWOPCValue(IEnumerable<BaseGongweiOpcModel> OPC, string gwOPCType)
        {
            var model = OPC.Where(f => f.opcTypeCode == gwOPCType).FirstOrDefault();
            if (model == null) return "";
            return model.opcValue + "";
        }
    }
}