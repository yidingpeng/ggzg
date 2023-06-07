using RW.PMS.Common;
using RW.PMS.IBLL.Programs;
using RW.PMS.IDAL.Programs;
using RW.PMS.Model.Programs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.BLL.Programs
{
    internal class BLL_PointInfo: IBLL_PointInfo
    {
        private IDAL_PointInfo _DAL = null;

        public BLL_PointInfo()
        {
            _DAL = DIService.GetService<IDAL_PointInfo>();
        }

        public List<PointInfoModel> GetPointInfo(string explain, int id)
        {
            return _DAL.GetPointInfo(explain,id);
        }

        public int EditPointInfo(PointInfoModel model)
        {
            return _DAL.EditPointInfo(model);
        }

        public int DeletePointInfo(int ID)
        {
            return _DAL.DeletePointInfo(ID);
        }

    }
}
