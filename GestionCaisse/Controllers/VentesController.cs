using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionCaisse.Controllers
{
    [Route("api/[controller]")]
    public class VentesController : Controller
    {
        public readonly IVenteRepository VenteRepository;

        public VentesController(IVenteRepository venteRepository)
        {
            VenteRepository = venteRepository;
        }


        [HttpGet("{id:guid}")]
        [Authorize]
        public IActionResult GetVente(Guid id)
        {
            var v = VenteRepository.GetById(id);

            return Ok(v);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetVentes()
        {
            return Ok(VenteRepository.Get());
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateVente()
        {
            var v = new Vente()
            {
                Numc = "1234",
                Nomp = "ABCD",
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