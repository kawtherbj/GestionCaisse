using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestionCaisseData.Models
{
   public class Produit
    {
        [Key]
        public int idPrdt { get; private set; }

        public string Nom { get; set; }

        public float Prix { get; set; }
    
        
     //   public IList<Vente> venteProduit { get; set; }
    }
}
