using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCaisse.Interfaces;
using GestionCaisseData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GestionCaisse.Controllers
{
    [Route("api/[controller]")]
   
    public class LoginController : Controller
    {
        private IConfiguration _config;
        public readonly IUserRepository UserRepository;
        public LoginController(IConfiguration config, IUserRepository userRepository)
        {
            _config = config;
            UserRepository = userRepository; 
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]Gerant login)
        {
            IActionResult response = Unauthorized();
            var user = UserRepository.Login(login.email, login.password);

            if (user.Any())
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString , User = user });
            }

            return response;
        }

        private string GenerateJSONWebToken(IQueryable<Gerant> userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

      /*  private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials  
            //Demo Purpose, I have Passed HardCoded User Information  
            if (user.Username == "Jignesh")
            {
                user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
            }
            return user;
        }*/
    }
}