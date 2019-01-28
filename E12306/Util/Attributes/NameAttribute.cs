using System;
using System.Collections.Generic;
using System.Text;

namespace E12306.Util.Attributes
{
    public class NameAttribute : Attribute
    {
        public NameAttribute(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; }
    }
}
