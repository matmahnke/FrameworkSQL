using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Usuarios")]
    public class Usuario : Entity
    {
        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Nome { get; set; }


        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Email { get; set; }


        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Senha { get; set; }


        [NotNull]
        [PropertyType(Enumeradores.SQLDataTypes.BIT)]
        public bool? ReceberOfertas { get; set; }


        [NotNull]
        [PropertyType(Enumeradores.SQLDataTypes.INT)]
        public int? DistanciaDeBusca { get; set; }


        [NotNull]
        [PropertyType(Enumeradores.SQLDataTypes.DATETIME2)]
        public DateTime? UltimoLogin { get; set; }
    }
}
