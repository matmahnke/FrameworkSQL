using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKey : Attribute
    {
        public ForeignKey(string tabela, string prop)
        {
            this.Prop = prop;
            this.Tabela = tabela;
        }
        public string Tabela { private set; get; }
        public string Prop { private set; get; }
    }
}
