using System;
using System.Collections.Generic;
using RW.PMS.Common;
using RW.PMS.Model;

namespace RW.PMS.IBLL
{
    public interface IBLL_GXInfo : IDependence
    {

        /// <summary>
        /// 根据程序ID获取工序配置信息
        /// </summary>
        /// <param name="progID"></param>
        /// <returns></returns>
        List<GXInfo> GetGXInfoList(int progID);

        /// <summary>
        /// 获取工序配置信息明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GXInfo GetGXInfoDetail(int id);

        /// <summary>
        /// 添加工序配置信息
        /// </summary>
        /// <param name="gxInfo"></param>
        void AddGXInfo(GXInfo gxInfo);

        /// <summary>
        /// 编辑工序配置信息
        /// </summary>
        /// <param name="gxInfo"></param>

        void EditGXInfo(GXInfo gxInfo);

        /// <summary>
        /// 排序设置
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="isUp">是否为向上排序</param>
        void OrderSet(int id, bool isUp);

        /// <summary>
        /// 删除工序配置信息
        /// </summary>
        /// <param name="id"></param>
        void DeleteGXInfo(int id);

    }
}
