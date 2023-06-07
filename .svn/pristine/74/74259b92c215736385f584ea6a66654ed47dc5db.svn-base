using System;
using System.Collections.Generic;
using RW.PMS.Common;
using RW.PMS.Model;
namespace RW.PMS.IDAL
{
    public interface IDAL_ValueInfo : IDependence
    {
        /// <summary>
        /// 获取检测项标准范围列表
        /// </summary>
        /// <param name="gjID"></param>
        /// <returns></returns>
        List<ValueInfo> GetValueInfoList(int gjID);

        /// <summary>
        /// 获取检测项标准范围明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueInfo GetValueInfoDetail(int id);

        /// <summary>
        /// 添加检测项标准范围信息
        /// </summary>
        /// <param name="valueInfo"></param>
        void AddValueInfo(ValueInfo valueInfo);


        /// <summary>
        /// 编辑检测项标准范围信息
        /// </summary>
        /// <param name="valueInfo"></param>
        void EditValueInfo(ValueInfo valueInfo);


        /// <summary>
        /// 删除检测项标准范围信息
        /// </summary>
        /// <param name="id"></param>
        void DeleteValueInfo(int id);

        /// <summary>
        /// 删除检测项标准范围信息
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="context"></param>
        void DeleteValueInfo(int[] ids);
        
    }
}
