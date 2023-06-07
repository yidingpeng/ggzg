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
    internal class BLL_GBInfo : IBLL_GBInfo
    {

        private IDAL_GBInfo _DAL = null;

        public BLL_GBInfo()
        {
            _DAL = DIService.GetService<IDAL_GBInfo>();
        }

        /// <summary>
        /// 根据工序配置ID获取工步配置信息列表
        /// </summary>
        /// <param name="gxID"></param>
        /// <returns></returns>
        public List<GBInfo> GetGBInfoList(int gxID)
        {
            var list = _DAL.GetGBInfoList(gxID);
            return list;
        }

        /// <summary>
        /// 根据工序配置ID获取工步配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GBInfo GetGBInfoDetail(int id)
        {
            var detail = _DAL.GetGBInfoDetail(id);
            return detail;
        }

        /// <summary>
        /// 添加工步信息
        /// </summary>
        /// <param name="gbInfo"></param>
        public void AddGBInfo(GBInfo gbInfo)
        {
            _DAL.AddGBInfo(gbInfo);
        }

        /// <summary>
        /// 编辑工步配置信息
        /// </summary>
        /// <param name="gbInfo"></param>
        public void EditGBInfo(GBInfo gbInfo)
        {
            _DAL.EditGBInfo(gbInfo);
        }

        /// <summary>
        /// 排序设置
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isUp">是否为向上排序</param>
        public void OrderSet(int id, bool isUp)
        {
            _DAL.OrderSet(id,isUp);
        }

        /// <summary>
        /// 删除一个工步配置信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGBInfo(int id)
        {
            _DAL.DeleteGBInfo(id);
        }
    }
}
