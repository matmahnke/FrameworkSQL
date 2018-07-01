using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DTO
{
    [TableName("Setores")]
    public class Setor : Entity
    {
        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Nome { get; set; }

        [NotNull]
        [PropertyType("NVARCHAR (50)")]
        public string Descricao { get; set; }
    }
}
