using DTO.DataAnnotations;
using DTO.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Enderecos")]
    public class Endereco: Entity
    {
        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        [ForeignKey("Usuarios", "ID")]
        public Usuario usuarioID { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (MAX)")]
        public string Rua { get; set; }
        
        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Bairro { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Cidade { get; set; }
    }
}
