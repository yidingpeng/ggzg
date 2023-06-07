using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.IDAL;
using RW.PMS.IBLL;
using RW.PMS.Model;
using RW.PMS.Common;

namespace RW.PMS.BLL
{
    internal class BLL_ValueInfo : IBLL_ValueInfo
    {

        private IDAL_ValueInfo _DAL = null;

        public BLL_ValueInfo()
        {
            _DAL = DIService.GetService<IDAL_ValueInfo>();
        }

        /// <summary>
        /// 根据工步配置ID获取配置检测项标准范信息列表
        /// </summary>
        /// <param name="gjID"></param>
        /// <returns></returns>
        public List<ValueInfo> GetValueInfoList(int gjID)
        {
            var list = _DAL.GetValueInfoList(gjID);
            return list;
        }

        /// <summary>
        /// 根据工步配置ID获取配置检测项标准范信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ValueInfo GetValueInfoDetail(int id)
        {
            var detail = _DAL.GetValueInfoDetail(id);
            return detail;
        }

        /// <summary>
        /// 添加检测项标准范围
        /// </summary>
        /// <param name="valueInfo"></param>
        public void AddValueInfo(ValueInfo valueInfo)
        {
            _DAL.AddValueInfo(valueInfo);
        }

        /// <summary>
        /// 修改检测项标准范围
        /// </summary>
        /// <param name="valueInfo"></param>
        public void EditValueInfo(ValueInfo valueInfo)
        {
            _DAL.EditValueInfo(valueInfo);
        }

        /// <summary>
        /// 删除检测项标准范围
        /// </summary>
        /// <param name="id"></param>
        public void DeleteValueInfo(int id)
        {
            _DAL.DeleteValueInfo(id);
        }

    }
}
