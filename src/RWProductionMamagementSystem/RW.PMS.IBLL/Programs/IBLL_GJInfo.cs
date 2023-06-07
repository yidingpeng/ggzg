using System;
using System.Collections.Generic;
using RW.PMS.Common;
using RW.PMS.Model;

namespace RW.PMS.IBLL
{
    public interface IBLL_GJInfo : IDependence
    {

        /// <summary>
        /// 更具工具配置ID获取工具信息
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        List<GJInfo> GetGJInfoList(int gbID);

        /// <summary>
        /// 获取工具/物料opc点位Tilte
        /// </summary>
        /// <returns></returns>
        List<GJOPCType> GetGJOPCTypes();
        /// <summary>
        /// 获取工具配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GJInfo GetGJInfoDetail(int id);

         /// <summary>
        /// 获取工位绑定的工具/物料 opc point 信息
        /// </summary>
        /// <returns></returns>
        List<GJGWOPCPointInfo> GetGJGWOPCPointInfo(int progbID, int? gjID, int? wlID);

        /// <summary>
        /// 添加工具配置信息
        /// </summary>
        /// <param name="gjInfo"></param>
        void AddGJInfo(GJInfo gjInfo);

        /// <summary>
        /// 编辑工具配置信息
        /// </summary>
        /// <param name="gjInfo"></param>
        void EditGJInfo(GJInfo gjInfo);

        /// <summary>
        /// 排序设置
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isUp">是否为向上排序</param>
        void OrderSet(int id, bool isUp);

        /// <summary>
        /// 删除工具配置信息
        /// </summary>
        /// <param name="id"></param>
        void DeleteGJInfo(int id);

    }
}
