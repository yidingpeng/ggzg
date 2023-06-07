using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RW.PMS.Model
{
    public class TreeviewModel
    {
        public TreeviewModel()
        {
            nodes = new List<TreeViewChild>();
        }
        public string nodeid { get; set; }
        public string text { get; set; }
        public IEnumerable<TreeViewChild> nodes { get; set; }
    }
    public class TreeViewChild
    {
        public string parentID { get; set; }

        public string nodeid { get; set; }

        public string text { get; set; }
    }

}
