using APIPetSitting.Mappers;
using APIPetSitting.Models;
using BLLPetSitting.Services;
using System.Collections.Generic;
using System.Linq;

namespace APIPetSitting.CredentialsHelpers
{
    /// <summary>
    /// Vérifie si les informations renseignées par l'utilisateur existe en base de données (compte propriétaire et pet-sitter)
    /// </summary>
    public class VerifyEmail
    {
       private readonly AccountService _accountService;
        public VerifyEmail(AccountService accountService)
        {
            this._accountService = accountService;
        }

        /// <summary>
        /// Vérifie si l'email du propriétaire existe
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public bool emailOwnerExist(string userLogins)
        {
            string email = _accountService.GetEmailOwner(userLogins);
            bool exist = (email != null) ? true : false ;

            return exist;
            
        }
        /// <summary>
        /// Vérifie si l'email du pet sitter existe
        /// </summary>
        /// <param name="userLogins"></param>
        /// <returns></returns>
        public bool emailPetSitterExist(string userLogins)
        {
            string email = _accountService.GetEmailPetSitter(userLogins);

            bool exist = (email!=null) ? true : false;
            return exist;
        }

        public Account GetOwnerCredential(string credentialToVerify)
        {
            Account ownerCredential = _accountService.GetOwnerCredentials(credentialToVerify).ToApi();

            return ownerCredential;
        }

        public Account GetPetSitterCredential(string credentialToVerify)
        {
            Account petSitterCredential = _accountService.GetPetSitterCredentials(credentialToVerify).ToApi();

            return petSitterCredential;
        }
    }
}
