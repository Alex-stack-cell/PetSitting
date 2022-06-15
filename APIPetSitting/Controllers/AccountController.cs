using APIPetSitting.Mappers;
using APIPetSitting.Models;
using BLLPetSitting.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using jwt =  APIPetSitting.JwtHelpers;

namespace APIPetSitting.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly OwnerService _ownerService;
        private readonly PetSitterService _petSitterService;
        public AccountController(JwtSettings jwtSettings, OwnerService ownerService, PetSitterService petSitterService)
        {
            this._jwtSettings = jwtSettings;
            this._ownerService = ownerService;
            this._petSitterService = petSitterService;
        }
        /// <summary>
        /// Génère un token unique pour un utilisateur
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns></returns>
        [Route("api/login")]
        [HttpPost]
        public IActionResult GetAuthOwner(UserLogins userLogins)
        {
            // Changer : 35 - 36 => Via controlleur GetByLogin() (Cool pour perf, et sécu. car tu peux pas récup toutes les data de tes users
            IEnumerable<Owner> logins = _ownerService.GetAll().Select(o => o.ToApi());
            IEnumerable<PetSitter> loginsSitter = _petSitterService.GetAll().Select(p => p.ToApi());
            try
            {
                UserTokens Token = new UserTokens();
                bool isOwner = logins.Any(x => x.Email.Equals(userLogins.UserEmail));
                bool isSitter = loginsSitter.Any(x => x.Email.Equals(userLogins.UserEmail));
                if (isOwner) // authentification compte proprio
                {
                    Owner user = logins.FirstOrDefault(x => x.Email.Equals(userLogins.UserEmail));
                    Token = jwt.JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        Id = (int)user.ID,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        isOwner = true
                    }, _jwtSettings);                    
                }
                else
                {                      
                    if (isSitter)//authentification compte pet sitter
                    {
                        PetSitter user = loginsSitter.FirstOrDefault(x => x.Email.Equals(userLogins.UserEmail));
                        Token = JwtHelpers.JwtHelpers.GenTokenkey(new UserTokens()
                        {
                            Id = (int)user.ID,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            isOwner=false
                        }, _jwtSettings);
                    }
                    else
                    {
                        return BadRequest("Le mot de passe ou l'email est incorrecte");
                    }                    
                }
                return Ok(new { token = Token.Token });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
