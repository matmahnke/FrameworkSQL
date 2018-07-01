using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyType : Attribute
    {
        public PropertyType(string text)
        {
            Text = text;
        }
        public string Text { private set; get; }
    }
}
