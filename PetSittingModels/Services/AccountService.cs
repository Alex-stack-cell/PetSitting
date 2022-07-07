using BLLPetSitting.Concretes.Auth;
using BLLPetSitting.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountDalService = DALPetSitting.Services.AccountService;

namespace BLLPetSitting.Services
{
    public class AccountService
    {
        private readonly AccountDalService _accountService;

        public AccountService(AccountDalService accountService)
        {
           _accountService = accountService;
        }

        public string GetEmailOwner(string emailOwner)
        {
            return _accountService.GetEmailOwner(emailOwner);
        }

        public string GetEmailPetSitter(string emailPetSitter)
        {
            return _accountService.GetEmailPetSitter(emailPetSitter);

        }

        public Account GetOwnerCredentials(string credentialToVerify)
        {
            return _accountService.GetOwnerCredentials(credentialToVerify).ToBll();
        }

        public Account GetPetSitterCredentials(string credentialToVerify)
        {
            return _accountService.GetPetSitterCredentials(credentialToVerify).ToBll();
        }
        /// <summary>
        /// Utiliser pour évaluer la validité du compte avant connection
        /// </summary>
        /// <param name="ownerEmail"></param>
        /// <param name="passwdToVerify"></param>
        /// <returns></returns>
        public bool isOwnerPasswordValid(string ownerEmail, string passwdToVerify)
        {
            return _accountService.isOwnerPasswordValid(ownerEmail, passwdToVerify);
        }

        /// <summary>
        /// Utiliser pour maj le mdp de l'utilisateur, plus besoin de l'email car le user est déjà connecté. Il faut récupéré son Identifiant via le token
        /// </summary>
        /// <param name="passwdToVerify"></param>
        /// <returns></returns>
        public bool isOwnerPasswordValid(string passwdToVerify, int id)
        {
            return _accountService.isOwnerPasswordValid(passwdToVerify, id);
        }
        /// <summary>
        /// Utiliser pour évaluer la validité du compte avant connection
        /// </summary>
        /// <param name="sitterEmail"></param>
        /// <param name="passwdToVerify"></param>
        /// <returns></returns>
        public bool isPetSitterPasswordValid(string sitterEmail, string passwdToVerify)
        {
            return _accountService.isPetSitterPasswordValid(sitterEmail, passwdToVerify);
        }
        /// <summary>
        /// Utiliser pour maj le mdp de l'utilisateur, plus besoin de l'email car le user est déjà connecté. Il faut récupéré son Identifiant via le token
        /// </summary>
        /// <param name="sitterEmail"></param>
        /// <param name="passwdToVerify"></param>
        /// <returns></returns>
        public bool isPetSitterPasswordValid(string passwdToVerify, int  id)
        {
            return _accountService.isPetSitterPasswordValid(passwdToVerify, id);
        }
    }
}


