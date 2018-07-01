using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNull : Attribute
    {
        public NotNull()
        {
            Value = true;
        }
        public bool Value { private set; get; }
    }
}
