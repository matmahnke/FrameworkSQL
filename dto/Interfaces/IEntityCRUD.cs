using DTO.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IEntityCRUD<T>
    {
        void Insert(T item);

        int Update(T item);

        int Delete(T item);

        List<T> Select(T item);
    }
}
