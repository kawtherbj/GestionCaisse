using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T GetById(Guid id);

        IEnumerable<T> Get() ;

        void Remove(Guid id);

        void Save();

        void Update(T entity);
    }
}
