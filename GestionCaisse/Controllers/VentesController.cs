using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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


        [HttpGet("{caisse}")]
      //  [Authorize]
        public IActionResult GetVente()
        {
            var queryParams = HttpContext.Request.Query;
            
            var id = queryParams["id"];
            var v = VenteRepository.GetByCaisse(id);

            return Ok(v);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetVentes()
        {
            var p = VenteRepository.GetAll();
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
            var c = CaisseRepository.Get();
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
                Numc = "123",
                Nump = 14,
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