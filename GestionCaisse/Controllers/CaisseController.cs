using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using GestionCaisse.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionCaisse.Controllers
{
   

    [Route("api/[controller]")]
    public class CaisseController : Controller
    {
        public readonly ICaisseRepository CaisseRepository;

        public CaisseController(ICaisseRepository caisseRepository)
        {
            CaisseRepository = caisseRepository;
        }
        [HttpGet]
       // [Authorize]
        public IActionResult GetVentes()
        {
          
            return Ok(CaisseRepository.Get());
        }
    }
}