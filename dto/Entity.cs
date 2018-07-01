using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DataAnnotations;

namespace DTO
{
    public class Entity
    {
        [NotNull]
        [PropertyType("INT           IDENTITY (1, 1)")]
        [NonEditable()]
        public int? ID { get; set; }
        [NotNull]
        [PropertyType(Enumeradores.SQLDataTypes.BIT)]
        public bool Ativo { get; set; }
    }
}
