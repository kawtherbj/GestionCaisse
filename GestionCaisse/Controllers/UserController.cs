using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionCaisse.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public readonly IUserRepository UserRepository;

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        [HttpPost]
        public IActionResult CreateUser()
        {
            var v = new Gerant()
            { Adresse="Ariana",
                nom = "Somrani",
                prenom = "Nader",
                password = "1234",
                email = "nader.somrani@gmail.com",
            };
            UserRepository.Add(v);
            UserRepository.Save();
            return Ok(" succesfully created ");
        }

    }
}