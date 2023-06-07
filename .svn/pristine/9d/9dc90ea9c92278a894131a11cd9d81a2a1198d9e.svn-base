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
    internal class BLL_GJInfo : IBLL_GJInfo
    {

        private IDAL_GJInfo _DAL = null;

        public BLL_GJInfo()
        {
            _DAL = DIService.GetService<IDAL_GJInfo>();
        }

        /// <summary>
        /// 根据工步配置ID获取工具配置信息列表
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        public List<GJInfo> GetGJInfoList(int gbID)
        {
            var list = _DAL.GetGJInfoList(gbID);
            return list;
        }

        /// <summary>
        /// 获取工具/物料opc点位Tilte
        /// </summary>
        /// <returns></returns>
        public List<GJOPCType> GetGJOPCTypes() 
        {
            var list = _DAL.GetGJOPCTypes();
            return list;
        }

        /// <summary>
        /// 获取工位绑定的工具/物料 opc point 信息
        /// </summary>
        /// <returns></returns>
        public List<GJGWOPCPointInfo> GetGJGWOPCPointInfo(int progbID, int? gjID, int? wlID) 
        {
            var list = _DAL.GetGJGWOPCPointInfo(progbID, gjID, wlID);
            return list;
        }
    
        /// <summary>
        /// 根据工步配置ID获取工具配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GJInfo GetGJInfoDetail(int id)
        {
            var detail = _DAL.GetGJInfoDetail(id);
            return detail;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="gjInfo"></param>
        public void AddGJInfo(GJInfo gjInfo)
        {
            _DAL.AddGJInfo(gjInfo);
        }

        /// <summary>
        /// 编辑工具配置信息
        /// </summary>
        /// <param name="gjInfo"></param>
        public void EditGJInfo(GJInfo gjInfo)
        {
            _DAL.EditGJInfo(gjInfo);
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
        /// 删除工具配置信息
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGJInfo(int id)
        {
            _DAL.DeleteGJInfo(id);
        }

    }
}
