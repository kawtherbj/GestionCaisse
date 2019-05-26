using GestionCaisseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Interfaces
{
   public interface IUserRepository : IRepository<Gerant>
    {

        IQueryable<Gerant> Login(string email , string password);

    }
}
