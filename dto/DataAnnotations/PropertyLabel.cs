using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyLabel : Attribute
    {
        public PropertyLabel(string label)
        {
            Value = label;
        }
        public string Value { private set; get; }
    }
}
