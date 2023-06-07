using System;
using System.Collections.Generic;
using RW.PMS.Common;
using RW.PMS.Model;

namespace RW.PMS.IBLL
{
    public interface IBLL_GBInfo : IDependence
    {
        /// <summary>
        /// 根据工序配置ID获取工步配置信息列表
        /// </summary>
        /// <param name="gxID"></param>
        /// <returns></returns>
        GBInfo GetGBInfoDetail(int id);

        /// <summary>
        /// 根据工序配置ID获取工步配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<GBInfo> GetGBInfoList(int gxID);

        /// <summary>
        /// 添加工步信息
        /// </summary>
        /// <param name="gbInfo"></param>
        void AddGBInfo(GBInfo gbInfo);

        /// <summary>
        /// 编辑工步信息
        /// </summary>
        /// <param name="gbInfo"></param>
        void EditGBInfo(GBInfo gbInfo);

        /// <summary>
        /// 排序设置
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isUp">是否为向上排序</param>
        void OrderSet(int id, bool isUp);

        /// <summary>
        /// 删除工步信息
        /// </summary>
        /// <param name="id"></param>
        void DeleteGBInfo(int id);
    }
}
