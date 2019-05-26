using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCaisseData.Models
{
   public class Vente
    {
        public Vente()
        {
            DateV = DateTime.Now;
        }

        public Guid idV { get;  private set; }

        public string Numc { get;  set; }

        public int Nump { get;  set; }

        public string Date { get;  set; }

        public DateTime DateV { get; set; }
    }

}
