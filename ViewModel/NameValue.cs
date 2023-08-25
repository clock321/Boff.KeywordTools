using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boff.KeywordTools.ViewModel
{
    public class NameValue
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public NameValue() { }
        public NameValue(string name, string value) { this.Name = name; this.Value = value; }
    }
}
