using DTO.DataAnnotations;
using DTO.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Supermercados")]
    public class Supermercado : Entity
    {
        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Nome { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string RazaoSocial { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string CNPJ { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Rua { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        public int Numero { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Bairro { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Cidade { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Telefone { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Email { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Senha { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Logo { get; set; }
    }
}
