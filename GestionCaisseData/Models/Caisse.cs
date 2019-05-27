using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionCaisseData.Models
{
    public class Caisse
    {
        [Key]
        public string Numero { get; set; }

        public string Adresse { get; set; }

        public string Magasin { get; set; }
        // public IList<Vente> venteCaisse { get; set; }

    }
}
