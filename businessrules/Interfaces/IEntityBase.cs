using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules.Interfaces
{
    public interface IEntityBase<T>
    {
        void Add(T item);
        void Edit(T item);
        void Delete(T item);
        T GetByID(int id);
        IList<T> GetAll();
    }
}
