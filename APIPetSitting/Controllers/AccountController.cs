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
using APIPetSitting.CredentialsHelpers;

namespace APIPetSitting.Controllers
{
    /// <summary>
    /// Controlleur responsable de la connection d'un utilisateur sur la plateforme.
    /// Une fois reconnu dans la db, un token lui est affublé.
    /// Rmq générale : La logique ne se met pas dans le controller. Cependant par soucis de lecture et de temps elle fût implémenté insitu
    /// </summary>
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly AccountService _accountService;
        public AccountController(JwtSettings jwtSettings, AccountService accountService)
        {
            this._jwtSettings = jwtSettings;
      
            this._accountService = accountService;
        }
        /// <summary>
        /// Génère un token unique pour un utilisateur
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns></returns>
        [Route("api/login")]
        [HttpPost]
        public IActionResult GetAuth(UserLogins userLogins)
        {
            VerifyEmail verifyEmail = new VerifyEmail(_accountService);
            bool ownerExist = verifyEmail.emailOwnerExist(userLogins.UserEmail);
            UserTokens Token = new UserTokens();

            try
            {
                //vérifie si le compte utilisateur est : propriétaire
                if (ownerExist)
                {
                    // Si le compte existe un token est généré
                    Account ownerCredential = verifyEmail.GetOwnerCredential(userLogins.UserEmail);

                    Token = jwt.JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        Id = (int)ownerCredential.ID,
                        Email = ownerCredential.Email,
                        FirstName = ownerCredential.FirstName,
                        isOwner = true
                    }, _jwtSettings);

                }
                else //Sinon check si c'est un petSitter
                {
                    bool petSitterExist = verifyEmail.emailPetSitterExist(userLogins.UserEmail);
                    if (petSitterExist)
                    {
                        Account sitterCredential = verifyEmail.GetPetSitterCredential(userLogins.UserEmail);

                        Token = jwt.JwtHelpers.GenTokenkey(new UserTokens()
                        {
                            Id = (int)sitterCredential.ID,
                            Email = sitterCredential.Email,
                            FirstName = sitterCredential.FirstName,
                            isOwner = true
                        }, _jwtSettings);
                    }
                    else // A contrario l'utilisateur n'existe pas dans la db
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
