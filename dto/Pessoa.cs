using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Pessoa
    {
        public int? ID { get; private set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
    }
}
