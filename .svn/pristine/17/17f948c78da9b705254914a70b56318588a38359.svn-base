using RW.PMS.Common;
using RW.PMS.IBLL;
using RW.PMS.IDAL;
using RW.PMS.Model;
using RW.PMS.Model.Assembly;
using RW.PMS.Model.BaseInfo;
using RW.PMS.Model.Follow;
using RW.PMS.Model.InComming;
using System;
using System.Collections.Generic;

namespace RW.PMS.BLL
{
    internal class BLL_InComming : IBLL_InComming
    {
        private IDAL_InComming _DAL = null;

        public BLL_InComming()
        {
            _DAL = DIService.GetService<IDAL_InComming>();
        }

        #region 入场存放区 存放记录表 Add By Leon 20190918
        public List<PutInfo> GetPutInfo()
        {
            return _DAL.GetPutInfo();
        }

        #endregion
    }
}
