using GestionCaisseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Interfaces
{
   public  interface ICaisseRepository : IRepository<Caisse>
    {

        IEnumerable<Caisse> GetAll(string adresse);

    }
}
