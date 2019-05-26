using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Implementations
{
    public class UserRepository : Repository<Gerant>, IUserRepository
    {
        private readonly CaisseContext Context;
        public UserRepository(CaisseContext context) : base(context)
        {
            Context = context; 
        }


        public IQueryable<Gerant> Login(string email, string password)
        {
            var q = from p in Context.gerant

                    where p.email == email

                    && p.password == password

                    select p;
            Console.Write(q);
            return q; 
        }
    }
}
