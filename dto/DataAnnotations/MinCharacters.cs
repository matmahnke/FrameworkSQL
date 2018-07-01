using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MinCharacters : Attribute
    {
        public MinCharacters(int min)
        {
            Value = min;
        }
        public int Value { private set; get; }
    }
}
