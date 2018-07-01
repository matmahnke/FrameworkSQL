using DTO.DataAnnotations;
using DTO.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Produtos")]
    public class Produto: Entity
    {
        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        [ForeignKey("Setores","ID")]
        public Setor setorID { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        [ForeignKey("Supermercados","ID")]
        public Supermercado mercadoID { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Nome { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.MONEY)]
        public double Preco { get; set; }

        [NotNull]
        [PropertyType(" FLOAT (8) ")]
        public double Peso { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Imagem { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        public int Acessos { get; set; }
    }
}
