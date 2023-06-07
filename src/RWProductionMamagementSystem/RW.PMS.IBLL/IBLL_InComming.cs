using RW.PMS.Common;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.InComming;
using System;
using System.Collections.Generic;

namespace RW.PMS.IBLL
{
    /// <summary>
    /// 来料
    /// </summary>
    public interface IBLL_InComming : IDependence
    {

        #region 入场存放区 存放记录表 Add By Leon 20190918
        /// <summary>
        /// 获取存放情况（型号-数量）
        /// </summary>
        /// <returns>存放情况（型号-数量）</returns>
        List<PutInfo> GetPutInfo();

        #endregion
    }
}
