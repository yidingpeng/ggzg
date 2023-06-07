using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RW.PMS.Web.Models
{
    public class AssemblyGWProdVModel
    {
        public List<GWVModel> GWModels { get; set; }

        public List<int> XAxisData{ get; set; }

        public List<string> ProdNames { get; set; }
        public List<ProdRecords> Records { get; set; }

    }

    public class GWVModel
    {
        public string Name { get; set; }

        public int BegXAxis { get; set; }

        public int EndXAxis { get; set; }


    }

    public class ProdRecords
    {
        public string ProdNo { get; set; }

        public List<string>  Values { get; set; }
    }
}