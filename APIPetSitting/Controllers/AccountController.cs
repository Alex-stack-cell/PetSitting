using APIPetSitting.Mappers;
using BLLPetSitting.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using jwt = APIPetSitting.JwtHelpers;
using APIPetSitting.CredentialsHelpers;
using Microsoft.Extensions.Logging;
using APIPetSitting.Models.Concretes.Auth;

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
            VerifyPasswd verifyPasswd = new VerifyPasswd(_accountService);
            GetCredentials getCredentials = new GetCredentials(_accountService);

            bool ownerExist = verifyEmail.emailOwnerExist(userLogins.UserEmail);           

            UserTokens Token = new UserTokens();

            try
            {
                //vérifie si le compte utilisateur est : propriétaire 
                if (ownerExist)
                {
                    bool ownerPasswdValid = verifyPasswd.isOwnerPasswordValid(userLogins.UserEmail, userLogins.Password);
                    if (ownerPasswdValid) // vérifie si le mdp fournit est ok
                    {
                        // Si le compte existe et mdp correct un token est généré
                        Account ownerCredential = getCredentials.GetOwnerCredential(userLogins.UserEmail);

                        Token = jwt.JwtHelpers.GenTokenkey(new UserTokens()
                        {
                            Id = (int)ownerCredential.ID,
                            Email = ownerCredential.Email,
                            FirstName = ownerCredential.FirstName,
                            isOwner = true
                        }, _jwtSettings);
                        return Ok(new { token = Token.Token });
                    }
                }
                else //Sinon check si le compte appartient à un petSitter
                {
                    bool petSitterExist = verifyEmail.emailPetSitterExist(userLogins.UserEmail);                  
                    if (petSitterExist)
                    {
                        bool petSitterPasswdValid = verifyPasswd.isPetSitterPasswordValid(userLogins.UserEmail, userLogins.Password);
                        if (petSitterPasswdValid)// vérifie si le mdp fournit est ok
                        {
                            Account sitterCredential = getCredentials.GetPetSitterCredential(userLogins.UserEmail);

                            Token = jwt.JwtHelpers.GenTokenkey(new UserTokens()
                            {
                                Id = (int)sitterCredential.ID,
                                Email = sitterCredential.Email,
                                FirstName = sitterCredential.FirstName,
                                isOwner = false
                            }, _jwtSettings);
                            return Ok(new { token = Token.Token });
                        }                       
                    }  
                }
                // A contrario l'utilisateur n'existe pas dans la db
                return BadRequest("Le mot de passe ou l'email est incorrecte");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
