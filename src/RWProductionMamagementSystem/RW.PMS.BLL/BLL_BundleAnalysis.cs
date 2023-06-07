using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Plan;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.BLL
{
    /// <summary>
    /// 齐套分析功能
    /// </summary>
    internal class BLL_BundleAnalysis : IBLL_BundleAnalysis
    {
        /// <summary>
        /// 齐套分析
        /// </summary>
        /// <param name="ppCodes"></param>
        public List<BundleAnalysisPlanModel> BundleAnalysis(params string[] ppCodes)
        {
            //齐套分析结果
            var result = new List<BundleAnalysisPlanModel>();

            var dalPlan = DIService.GetService<IDAL_Plan>();

            //获取生产计划相关信息
            var planList = dalPlan.GetPlanInfoByBundleAnalysis(ppCodes);
            if (planList == null && planList.Count == 0)
            {
                return result;
            }

            //获取齐套分析参数配置
            foreach (var plan in planList)
            {
                plan.Config = new BundleAnalysisConfigModel();
                //*获取齐套物料配置cfg信息列表
                var BundleAnalysisMaterialConfig = dalPlan.GetBundleAnalysisMaterialConfigList(new BundleAnalysisMaterialConfigModel { ProdModelID = plan.pp_prodModelID, PageIndex = 0 });
                plan.Config.MaterialModels = BundleAnalysisMaterialConfig;
                //获取产品型号下所配置的阀值
                plan.Config.ThresholdValue = DIService.GetService<IDAL_BaseInfo>().GetBaseProductModelId(plan.pp_prodModelID ?? 0).threshold.ToDecimal() / 100;
            }

            //获取库存信息
            var inventoryList = DIService.GetService<IDAL_BaseInfo>().GetInventoryList();

            //获取物料所占百分比
            foreach (var plan in planList)
            {
                //*获取当物料所占百分比
                GetPlanMaterialPercent(plan);
            }

            //齐套分析
            while (planList.Count > 0)
            {
                //复制生产计划
                RestoreBundleAnalysisModel(planList);
                //单个齐套分析结果
                foreach (var plan in planList)
                {
                    //*设置库存与预扣库存数量
                    RestorePlanInventoryModel(inventoryList);

                    //*进行单个计划齐套分析
                    BundleAnalysis(plan, inventoryList);
                }
                //根据结果排序
                planList = planList.OrderByDescending(f => f.CheckRestult).ThenByDescending(f => f.ActualPercent).ToList();
                //获取排在第一位的计划
                var firstVal = planList.First();
                //扣掉实际库存
                foreach (var tech in firstVal.TechModels)
                {
                    foreach (var wl in tech.StockModels)
                    {
                        var inv = inventoryList.Where(f => f.wlID == wl.ps_materialID && wl.ps_qty > 0).FirstOrDefault();
                        if (inv != null)
                        {
                            if (inv.qty >= wl.ps_qty)
                            {
                                //减去实际库存
                                inv.qty -= wl.ps_qty;
                            }
                            else
                            {
                                inv.qty = 0;
                            }
                        }
                    }
                }
                //移到结果集中
                //result.Add(Clone(firstVal));
                result.Add(firstVal);
                planList.Remove(firstVal);
            }
            return result;
        }

        /// <summary>
        /// 进行单个计划齐套分析
        /// </summary>
        /// <param name="bundleAnalysisPlanModel"></param>
        /// <param name="inventoryModels"></param>
        private void BundleAnalysis(BundleAnalysisPlanModel bundleAnalysisPlanModel, List<BundleAnalysisInventoryModel> inventoryModels)
        {
            //满足关键物料
            var wlMust = true;

            foreach (var tech in bundleAnalysisPlanModel.TechModels)
            {
                foreach (var wl in tech.StockModels)
                {
                    var inv = inventoryModels.Where(f => f.wlID == wl.ps_materialID && wl.ps_qty > 0).FirstOrDefault();
                    if (inv != null)
                    {
                        if (inv.qty >= wl.ps_qty)
                        {
                            //减去预计库存
                            inv.PlanQty -= wl.ps_qty;
                            wl.ActualQty = wl.ps_qty.Value;
                        }
                        else
                        {
                            wl.ActualQty = inv.PlanQty.Value;
                            //预计库存清零
                            inv.PlanQty = 0;
                        }
                    }

                    //关键物料必须要有
                    if (wlMust && wl.Must == 1 && wl.ActualQty == 0)
                    {
                        //缺乏关键物料
                        wlMust = false;
                    }

                }
                //实际所占百分比
                tech.ActualPercent = tech.StockModels.Sum(f => f.ActualPercent);
            }

            //生产计划实际所占百分比
            bundleAnalysisPlanModel.ActualPercent = bundleAnalysisPlanModel.TechModels.Sum(f => f.ActualPercent);

            //分析结果
            //1.是否缺乏关键物料
            if (wlMust)
            {
                //2.是否达到所配置的阀值
                if (bundleAnalysisPlanModel.ActualPercent >= bundleAnalysisPlanModel.Config.ThresholdValue)
                {
                    //合格
                    bundleAnalysisPlanModel.CheckRestult = 1;
                    return;
                }
            }
            //不合格
            bundleAnalysisPlanModel.CheckRestult = 0;

        }

        /// <summary>
        /// 获取当物料所占百分比
        /// </summary>
        /// <param name="bundleAnalysisPlanModel"></param>
        private void GetPlanMaterialPercent(BundleAnalysisPlanModel bundleAnalysisPlanModel)
        {
            //获取参数配置的物料总百分比
            decimal allConfigPercent = bundleAnalysisPlanModel.Config.MaterialModels.Sum(f => f.percentValue ?? 0) / 100;
            if (allConfigPercent > 1)
            {
                throw new Exception("参数配置的物料总百分比不能超过100%！");
            }

            //齐套物料所占百分比
            var otherWLPercent = 1 - allConfigPercent;

            //获取所有物料列表
            var wlList = bundleAnalysisPlanModel.TechModels.SelectMany(f => f.StockModels.Select(ff => ff));

            //需要计算的物料(所有物料减去配置的物料)
            var wlOtherList = wlList.Where(f => !bundleAnalysisPlanModel.Config.MaterialModels.Select(ff => ff.MCode).Contains(f.ps_materialCode));

            //获取其他物料的所有数量
            var wlOtherCount = wlOtherList.Sum(f => f.ps_qty ?? 0);
            if (wlOtherCount == 0)
            {
                throw new Exception("其他物料的所有数量不能为0！");
            }

            //获取平均单个物料所占百分比
            var wlOtherOnePercent = otherWLPercent / wlOtherCount;


            foreach (var tech in bundleAnalysisPlanModel.TechModels)
            {
                //计算单个物料所占总体百分比
                foreach (var wl in tech.StockModels)
                {
                    //是否在齐套分析参数设置了该物料
                    var val = bundleAnalysisPlanModel.Config.MaterialModels.Where(f => f.MID == wl.ps_materialID).FirstOrDefault();
                    if (val != null)
                    {
                        wl.Percent = val.percentValue ?? 0;

                        wl.Must = val.Must ?? 0;
                    }
                    else//否则，按实际物料数量所占百分比来计算
                    {
                        wl.Percent = (wl.ps_qty ?? 0) * wlOtherOnePercent;
                    }
                }
                //计算单个工序所占总体百分比
                tech.Percent = tech.StockModels.Sum(f => f.Percent);
            }
        }

        /// <summary>
        /// 还原生产计划数据
        /// </summary>
        /// <param name="models"></param>
        public void RestoreBundleAnalysisModel(List<BundleAnalysisPlanModel> models)
        {
            foreach (var model in models)
            {
                foreach (var tech in model.TechModels)
                {
                    foreach (var wl in tech.StockModels)
                    {
                        wl.ActualQty = 0;
                    }
                    tech.ActualPercent = 0;
                }
                model.ActualPercent = 0;
                model.CheckRestult = -1;
            }
        }

        /// <summary>
        /// 设置库存与预扣库存数量
        /// </summary>
        /// <param name="models"></param>
        public void RestorePlanInventoryModel(List<BundleAnalysisInventoryModel> models)
        {
            foreach (var model in models)
            {
                model.PlanQty = model.qty;
            }
        }

        /// <summary>
        ///  深度复制方法（内存复制）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public T Clone<T>(T input) where T : class
        {
            var formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, input);
                stream.Position = 0;
                var outList = formatter.Deserialize(stream) as T;
                return outList;
            }
        }

        /// <summary>
        /// 保存齐套分析结果
        /// </summary>
        /// <param name="BundleAnalysisPlanModel"></param>
        /// <returns></returns>
        public int SaveBundleAnalysisResults(List<BundleAnalysisPlanModel> BundleAnalysisList)
        {
            var dalPlan = DIService.GetService<IDAL_Plan>();
            return dalPlan.SaveBundleAnalysisResults(BundleAnalysisList);
        }



    }
}
