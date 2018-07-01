using DTO.DataAnnotations;
using DTO.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Promocoes")]
    public class Promocao: Entity
    {
        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        [ForeignKey("Produtos","ID")]
        public Produto produtoID { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.MONEY)]
        public double Preco { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.DATETIME2)]
        public DateTime DataInicio { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.DATETIME2)]
        public DateTime DataFim { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.BIT)]
        public bool Periodicidade { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.DATETIME2)]
        public DateTime DataPeriodicidade { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        public DiaDaSemana Semanalmente { get; set; }
    }
}
