using DTO.DataAnnotations;
using DTO.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [TableName("Favoritos")]
    public class Favoritos : Entity
    {
        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        [ForeignKey("Usuarios","ID")]
        public Usuario usuarioID { get; set; }

        [NotNull]
        [PropertyType(SQLDataTypes.INT)]
        [ForeignKey("Produtos", "ID")]
        public Produto produtoID { get; set; }
    }
}
