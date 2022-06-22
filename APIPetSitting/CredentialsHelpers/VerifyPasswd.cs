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

        public bool isPetSitterPasswordValid(string sitterEmail, string passwdToVerify)
        {
            return _accountService.isPetSitterPasswordValid(sitterEmail, passwdToVerify);
        }
    }
}
