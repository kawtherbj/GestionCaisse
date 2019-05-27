using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionCaisseData.Models
{
   public class Vente
    {
        public Vente()
        {
            DateV = DateTime.Today;
        }

        public Guid idV { get;  private set; }

        public string Numc { get;  set; }

        [ForeignKey(nameof(Numc))]
        public Caisse ca { get; set; }

        public int Nump { get;  set; }

        [ForeignKey(nameof(Nump))]
        public Produit prdt { get; set; }

        public int Quantite { get;  set; }

        public DateTime DateV { get; set; }
    }

}
