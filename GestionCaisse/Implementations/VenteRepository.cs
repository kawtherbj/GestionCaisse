using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Implementations
{
    public class VenteRepository : Repository<Vente>, IVenteRepository
    {
        public VenteRepository(CaisseContext context ) : base(context)
        {

        } 

    }
}
