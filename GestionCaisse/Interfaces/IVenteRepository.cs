using GestionCaisseData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCaisse.Interfaces
{
   public interface IVenteRepository : IRepository<Vente>
    {
        IEnumerable<Vente> GetAll(string adresse);
        IEnumerable<Vente> GetByCaisse(string id);
        IEnumerable<Vente> GetByDate(string jour, string mois, string annee, string id, string adresse);
    }
}
