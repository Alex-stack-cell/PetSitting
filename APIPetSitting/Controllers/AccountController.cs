using APIPetSitting.Mappers;
using APIPetSitting.Models;
using BLLPetSitting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIPetSitting.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly OwnerService _ownerService;
        public AccountController(JwtSettings jwtSettings, OwnerService ownerService)
        {
            this._jwtSettings = jwtSettings;
            this._ownerService = ownerService;
        }
        /// <summary>
        /// Génère un token unique pour un utilisateur
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetToken(UserLogins userLogins)
        {
            IEnumerable<Owner> logins = _ownerService.GetAll().Select(o => o.ToApi());
            try
            {
                UserTokens Token = new UserTokens();
                bool Valid = logins.Any(x => x.Email.Equals(userLogins.UserEmail));
                if (Valid)
                {
                    var user = logins.FirstOrDefault(x => x.Email.Equals(userLogins.UserEmail/*, StringComparison.OrdinalIgnoreCase)*/));
                    Token = JwtHelpers.JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        Email = user.Email,
                        GuidId = Guid.NewGuid(),
                        FirstName = user.FirstName,
                    }, _jwtSettings);
                }
                else
                {
                    return BadRequest("Le mot de passe ou l'email est incorrecte");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// Récupère la liste des comptes utilisateurs
        /// </summary>
        /// <returns>Liste d'utilisateurs</returns>
        [HttpGet]
        [Authorize]
        public IActionResult GetList()
        {
            IEnumerable<Owner> logins = _ownerService.GetAll().Select(o => o.ToApi());
            return Ok(logins);
        }
    }
}
