using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Implementations
{
    public class VenteRepository : Repository<Vente>, IVenteRepository
    {
        private readonly CaisseContext Context;

        public VenteRepository(CaisseContext context) : base(context)
        {
            Context = context;
        }

        public IEnumerable<Vente> GetAll()
        {
            var q = from pr in Context.vente.Include(o=>o.ca).Include(v => v.prdt).ToList()
                    
                    where pr.DateV.Day == DateTime.Now.Day &&
                            pr.DateV.Month == DateTime.Now.Month &&
                            pr.DateV.Year == DateTime.Now.Year
                    select pr; 
            return q;
        }

        public IEnumerable<Vente> GetByCaisse(string id)
        {
            var q = from pr in Context.vente.Include(o => o.ca).Include(v => v.prdt).ToList()

                    where pr.DateV.Day == DateTime.Now.Day &&
                            pr.DateV.Month == DateTime.Now.Month &&
                            pr.DateV.Year == DateTime.Now.Year &&
                            pr.Numc == id
                    select pr;
            return q;
        }
    }
}
