using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Implementations
{
    public class CaisseRepository : Repository<Caisse> , ICaisseRepository
    {
        private readonly CaisseContext Context;

        public CaisseRepository(CaisseContext context) : base(context)
        {
            Context = context;
        }
    }
}
