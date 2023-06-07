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
    internal class BLL_GXInfo : IBLL_GXInfo
    {

        private IDAL_GXInfo _DAL = null;

        public BLL_GXInfo()
        {
            _DAL = DIService.GetService<IDAL_GXInfo>();
        }

        /// <summary>
        /// 根据程序ID获取工序配置信息列表
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        public List<GXInfo> GetGXInfoList(int progID)
        {
            var list = _DAL.GetGXInfoList(progID);

            return list;
        }

        /// <summary>
        /// 根据程序ID获取工序配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GXInfo GetGXInfoDetail(int id)
        {
            var detail = _DAL.GetGXInfoDetail(id);

            return detail;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="gxInfo"></param>
        public void AddGXInfo(GXInfo gxInfo)
        {
            _DAL.AddGXInfo(gxInfo);
        }

        /// <summary>
        /// 修改工序配置信息
        /// </summary>
        /// <param name="gxInfo"></param>
        public void EditGXInfo(GXInfo gxInfo)
        {
            _DAL.EditGXInfo(gxInfo);
        }

        /// <summary>
        /// 排序设置
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isUp">是否为向上排序</param>
        public void OrderSet(int id, bool isUp)
        {
            _DAL.OrderSet(id, isUp);
        }

        /// <summary>
        /// 删除单个工序配置信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGXInfo(int id)
        {
            _DAL.DeleteGXInfo(id);
        }

    }
}
