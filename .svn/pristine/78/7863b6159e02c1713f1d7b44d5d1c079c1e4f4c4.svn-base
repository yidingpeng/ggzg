using RW.PMS.Common;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Test;
using System;
using System.Collections.Generic;
namespace RW.PMS.IBLL
{
    public interface IBLL_Test : IDependence
    {

        #region 试验配置主表

        /// <summary>
        /// 试验配置主表 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<TestConfigMainModel> GetTestConfigMain(TestConfigMainModel model);


        /// <summary>
        /// 添加试验配置主表
        /// </summary>
        /// <param name="model"></param>
        void AddTestConfigMain(TestConfigMainModel model);

        /// <summary>
        /// 修改试验配置主表
        /// </summary>
        /// <param name="model"></param>
        void UpdateTestConfigMain(TestConfigMainModel model);

        /// <summary>
        /// 保存 试验配置主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveTestConfigMain(TestConfigMainModel model);

        /// <summary>
        /// 根据配置主表GUID 删除主从表所有信息
        /// 删除：如果删除主表下面的子表也会被同时删除
        /// </summary>
        /// <param name="gwid"></param>
        bool DelTestConfigMain(string id);

        #endregion

        #region 试验配置明细表


        /// <summary>
        /// 试验配置明细表 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<TestConfigDetailModel> GetTestConfigDetail(TestConfigDetailModel model);

        /// <summary>
        /// 添加试验配置明细表
        /// </summary>
        /// <param name="model"></param>
        void AddTestConfigDetail(TestConfigDetailModel model);

        /// <summary>
        /// 修改试验配置明细表
        /// </summary>
        /// <param name="model"></param>
        void UpdateTestConfigDetail(TestConfigDetailModel model);

        /// <summary>
        /// 保存 试验配置从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveTestConfigDetail(TestConfigDetailModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tcdID"></param>
        void DeleteTestConfigDetail(string tcdID);

        #endregion

        #region 试验结果表

        List<TestResultMainModel> GetTestResultMainList(TestResultMainModel model);

        int SaveTestResult(TestResultMainModel model);

        int DeleteTestResultMain(TestResultMainModel model);

        List<TestResultDetailModel> GetTestResultDetailList(TestResultDetailModel model);

        int DeleteTestResultDetail(TestResultDetailModel model);

        #endregion

        #region 试验报表查看

        TestConfigMainModel GetTestDataByProdNo(string strProdNo);

        #endregion

    }
}
