using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RW.PMS.Model;
using RW.PMS.IDAL;
using RW.PMS.Common;
using RW.PMS.IBLL;

namespace RW.PMS.BLL
{
    internal class BLL_Crumbs : IBLL_Crumbs
    {

        private IDAL_Crumbs _DAL = null;

        public BLL_Crumbs()
        {
            _DAL = DIService.GetService<IDAL_Crumbs>();
        }

        public List<CrumbsModel> GetCrumbs(string Path)
        {
            return _DAL.GetCrumbs(Path);
        }

        public string GetViewTitle(string Path)
        {
            return _DAL.GetViewTitle(Path);
        }
    }
}
