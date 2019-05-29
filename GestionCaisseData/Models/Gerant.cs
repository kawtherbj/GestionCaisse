using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCaisseData.Models
{
    public class Gerant
    {
        public Guid idG { get; private set; }

        public string email { get; set; }

        public string nom { get; set; }

        public string prenom { get; set; }

        public string password { get; set; }

        public string Adresse { get; set; }

    }
}
