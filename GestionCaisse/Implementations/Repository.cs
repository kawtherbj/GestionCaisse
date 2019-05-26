using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CaisseContext Context;

        public Repository(CaisseContext context)
            => Context = context;

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> Get()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);

        }

        public void Remove(Guid id)
        {
            var type = Context.Set<T>().Find(id);
            Context.Remove(type);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
        }
    }
}
