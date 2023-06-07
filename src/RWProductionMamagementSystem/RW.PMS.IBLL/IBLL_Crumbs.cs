using RW.PMS.Common;
using RW.PMS.Model;
using System;
using System.Collections.Generic;
namespace RW.PMS.IBLL
{
    public interface IBLL_Crumbs : IDependence
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        List<CrumbsModel> GetCrumbs(string Path);

        /// <summary>
        /// 根据地址获取菜单名称
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        string GetViewTitle(string Path);
    }
}
