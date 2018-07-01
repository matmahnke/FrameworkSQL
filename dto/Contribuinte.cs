using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Contribuinte : Pessoa
    {
        //public ICollection<Dependente> Dependentes { get; set; }
        public double Renda { get; set; }
        //public virtual ICollection<Dependente> Dependente { get; set; }
    }
    public class Tabela
    {
        public IList<Contribuinte> Contribuintes { get; set; }
        public IList<double> Imposto { get; set; }
    }
}
