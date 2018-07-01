using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Interfaces
{
    public interface IQuartoRules
    {
        IList<Quarto> GetQuartosDisponiveis();
        IList<Quarto> GetQuartosOcupados();
    }
}
