using RW.PMS.Common;
using RW.PMS.Model;
using System;
using System.Collections.Generic;
namespace RW.PMS.IDAL
{
    public interface IDAL_Crumbs : IDependence
    {
        List<CrumbsModel> GetCrumbs(string Path);
        string GetViewTitle(string Path);
    }
}
