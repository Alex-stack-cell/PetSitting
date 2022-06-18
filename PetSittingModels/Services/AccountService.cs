using BLLPetSitting.Concretes;
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

        public bool isOwnerPasswordValid(string ownerEmail, string passwdToVerify)
        {
            return _accountService.isOwnerPasswordValid(ownerEmail, passwdToVerify);
        }
    }
}


