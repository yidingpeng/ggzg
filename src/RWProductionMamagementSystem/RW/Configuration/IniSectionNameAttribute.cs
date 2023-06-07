using System;
using System.Collections.Generic;
using System.Text;

namespace RW.PMS.Utils.Configuration
{
    public class IniSectionNameAttribute : Attribute
    {
        public IniSectionNameAttribute(string name)
        {
            this.Name = name;
        }

        private string name;
        public string Name { get { return name; } set { name = value; } }
    }
}
