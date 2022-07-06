using BLLPetSitting.Services;

namespace APIPetSitting.CredentialsHelpers
{
    public class VerifyPasswd
    {
        private readonly AccountService _accountService;
        public VerifyPasswd(AccountService accountService)
        {
            _accountService = accountService;
        }

        public bool isOwnerPasswordValid(string ownerEmail, string passwdToVerify)
        {
            return _accountService.isOwnerPasswordValid(ownerEmail, passwdToVerify);
        }

        /// <summary>
        /// Utiliser pour maj le mdp de l'utilisateur sur base de son id (récup via token)
        /// </summary>
        /// <param name="passwdToVerify"></param>
        /// <returns></returns>
        public bool isOwnerPasswordValid(string passwdToVerify, int id)
        {
            return _accountService.isOwnerPasswordValid(passwdToVerify, id);
        }

        public bool isPetSitterPasswordValid(string sitterEmail, string passwdToVerify)
        {
            return _accountService.isPetSitterPasswordValid(sitterEmail, passwdToVerify);
        }
    }
}
