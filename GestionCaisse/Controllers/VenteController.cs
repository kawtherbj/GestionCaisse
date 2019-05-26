using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionCaisseData.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionCaisse.Controllers
{
    [Route("api/[controller]")]
    public class VenteController : Controller
    {
        readonly CaisseContext Context;

        public VenteController(CaisseContext context)
          => Context = context;

        [HttpGet]
        public IActionResult GetVente()
        {
            var ventes = Context.vente.ToList();
            return Ok(ventes);
        }

        [HttpPost]
        public IActionResult CreateVente()
        {
            var v = new Vente()
            {   
                Numc = "123",
                Nomp = "ABC",
            };
            Context.Add(v);
            Context.SaveChanges();
            return Ok(" succesfully created ");
        }
    }
}