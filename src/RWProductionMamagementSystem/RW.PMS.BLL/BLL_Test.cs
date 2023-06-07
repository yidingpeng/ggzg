using RW.PMS.Common;
using RW.PMS.DAL;
using RW.PMS.IBLL;
using RW.PMS.Model.Follow;
using RW.PMS.Model.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.BLL
{
    internal class BLL_Test : IBLL_Test
    {

        private IDAL_Test _DAl = null;
        public BLL_Test()
        {
            _DAl = DIService.GetService<IDAL_Test>();
        }


        #region 试验配置主表

        /// <summary>
        /// 试验配置主表 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TestConfigMainModel> GetTestConfigMain(TestConfigMainModel model) { return _DAl.GetTestConfigMain(model); }


        /// <summary>
        /// 添加试验配置主表
        /// </summary>
        /// <param name="model"></param>
        public void AddTestConfigMain(TestConfigMainModel model) { _DAl.AddTestConfigMain(model); }

        /// <summary>
        /// 修改试验配置主表
        /// </summary>
        /// <param name="model"></param>
        public void UpdateTestConfigMain(TestConfigMainModel model) { _DAl.UpdateTestConfigMain(model); }



        /// <summary>
        /// 保存 试验配置主表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTestConfigMain(TestConfigMainModel model) { return _DAl.SaveTestConfigMain(model); }

        /// <summary>
        /// 根据配置主表GUID 删除主从表所有信息
        /// 删除：如果删除主表下面的子表也会被同时删除
        /// </summary>
        /// <param name="gwid"></param>
        public bool DelTestConfigMain(string id) { return _DAl.DelTestConfigMain(id); }

        #endregion

        #region 试验配置明细表


        /// <summary>
        /// 试验配置明细表 分页查询
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public List<TestConfigDetailModel> GetTestConfigDetail(TestConfigDetailModel model) { return _DAl.GetTestConfigDetail(model); }

        /// <summary>
        /// 添加试验配置明细表
        /// </summary>
        /// <param name="model"></param>
        public void AddTestConfigDetail(TestConfigDetailModel model) { _DAl.AddTestConfigDetail(model); }

        /// <summary>
        /// 修改试验配置明细表
        /// </summary>
        /// <param name="model"></param>
        public void UpdateTestConfigDetail(TestConfigDetailModel model) { _DAl.UpdateTestConfigDetail(model); }


        /// <summary>
        /// 保存 试验配置从表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool SaveTestConfigDetail(TestConfigDetailModel model) { return _DAl.SaveTestConfigDetail(model); }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="tcdID"></param>
        public void DeleteTestConfigDetail(string tcdID) { _DAl.DeleteTestConfigDetail(tcdID); }

        #endregion

        #region 试验结果表


        public List<TestResultMainModel> GetTestResultMainList(TestResultMainModel model) { return _DAl.GetTestResultMainList(model); }

        public int SaveTestResult(TestResultMainModel model) { return _DAl.SaveTestResult(model); }

        public int DeleteTestResultMain(TestResultMainModel model) { return _DAl.DeleteTestResultMain(model); }

        public List<TestResultDetailModel> GetTestResultDetailList(TestResultDetailModel model) { return _DAl.GetTestResultDetailList(model); }

        public int DeleteTestResultDetail(TestResultDetailModel model) { return _DAl.DeleteTestResultDetail(model); }

        #endregion

        #region 试验报表查看

        public TestConfigMainModel GetTestDataByProdNo(string strProdNo) { return _DAl.GetTestDataByProdNo(strProdNo); }

        #endregion


    }
}
