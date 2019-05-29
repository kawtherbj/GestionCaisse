using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace GestionCaisse.Controllers
{

    [Route("api/[controller]")]
    public class VentesController : Controller
    {
        public readonly IVenteRepository VenteRepository;
        public readonly ICaisseRepository CaisseRepository;

        public VentesController(IVenteRepository venteRepository, ICaisseRepository caisseRepository)
        {
            VenteRepository = venteRepository;
            CaisseRepository = caisseRepository;
        }


        [HttpGet("caisse")]
      //  [Authorize]
        public IActionResult GetVente()
        {
            var queryParams = HttpContext.Request.Query;
            
            var id = queryParams["id"];
            var v = VenteRepository.GetByCaisse(id);

            return Ok(v);
        }


        [HttpGet("historiques")]
        //  [Authorize]
        public IActionResult GetByVenteDate()
        {
            var queryParams = HttpContext.Request.Query;

            var id = queryParams["id"];
            var j = queryParams["jour"];
            var m = queryParams["mois"];
            var a = queryParams["annee"];
            var adresse = queryParams["adresse"];
            var hist = VenteRepository.GetByDate(j, m, a, id,adresse);

            return Ok(hist);
        }
       
        [HttpGet]
      //  [Authorize]
        public IActionResult GetVentes()
        {
            var queryParams = HttpContext.Request.Query;
            var adresse = queryParams["adresse"];

            var p = VenteRepository.GetAll(adresse);
            float recette = 0;
            foreach (var i in p)
            {
                recette += i.Quantite * i.prdt.Prix;
               
            }

            return Ok(new { produits = p , recettes = recette });
        }

        [HttpGet("caisses")]
     //   [Authorize]
        public IActionResult GetCaisse()
        {
            var queryParams = HttpContext.Request.Query;
            var adresse = queryParams["adresse"];

            var c = CaisseRepository.GetAll(adresse);
            JArray j = new JArray() ;
            
            foreach(var it in c) {
                float recette = 0;
                var p = VenteRepository.GetByCaisse(it.Numero);

                if (p!= null) { 

                foreach (var i in p)
                   {
                    recette += i.Quantite * i.prdt.Prix;
                   }

                }
                JObject x = new JObject(new JProperty("Numero", it.Numero),
                                        new JProperty("Magasin", it.Magasin), 
                                        new JProperty("Adresse", it.Adresse),
                                        new JProperty("recettes", recette)
                                        );
                j.Add(x);

                
            }
            return Ok(j);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateVente()
        {
            var v = new Vente()
            {
                Numc = "12",
                Nump = 17,
                Quantite = 2,
            };
            VenteRepository.Add(v);
            VenteRepository.Save();
            return Ok(" succesfully created ");
        }

        [HttpDelete("{id:guid}")]
        public IActionResult RemoveVente(Guid id)
        {
          
            VenteRepository.Remove(id);
            VenteRepository.Save();
            return Ok(" succesfully removed ");
        }


    }
}