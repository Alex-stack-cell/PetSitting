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
        /// Génère un token unique pour un propriétaire
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns></returns>
        [Route("api/login/owner")]
        [HttpPost]
        public IActionResult GetAuthOwner(UserLogins userLogins)
        {
            IEnumerable<Owner> logins = _ownerService.GetAll().Select(o => o.ToApi());
            try
            {
                UserTokens Token = new UserTokens();
                bool Valid = logins.Any(x => x.Email.Equals(userLogins.UserEmail));
                if (Valid)
                {
                    var user = logins.FirstOrDefault(x => x.Email.Equals(userLogins.UserEmail));
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
                throw ex;
            }
        }
        /// <summary>
        /// Génère un token unique pour un pet-sitter
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns></returns>
        [Route("api/login/petSitter")]
        [HttpPost]
        public IActionResult GetAuthPetSitter(UserLogins userLogins)
        {
            IEnumerable<PetSitter> logins = _petSitterService.GetAll().Select(o => o.ToApi());
            try
            {
                UserTokens Token = new UserTokens();
                bool Valid = logins.Any(x => x.Email.Equals(userLogins.UserEmail));
                if (Valid)
                {
                    var user = logins.FirstOrDefault(x => x.Email.Equals(userLogins.UserEmail));
                    Token = JwtHelpers.JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        Email = user.Email,
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
                throw ex;
            }
        }
    }
}
