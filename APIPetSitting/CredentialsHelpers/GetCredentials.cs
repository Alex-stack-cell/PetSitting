using APIPetSitting.Mappers;
using APIPetSitting.Models.Concretes.Auth;
using BLLPetSitting.Services;

namespace APIPetSitting.CredentialsHelpers
{
    /// <summary>
    /// Récupération des crédentials nécessaire pour les claims (Token)
    /// </summary>
    public class GetCredentials
    {
        private readonly AccountService _accountService;
        public GetCredentials(AccountService accountService)
        {
            _accountService = accountService;
        }
        /// <summary>
        /// Récupère les credentials essentiels pour les claims du owner
        /// </summary>
        /// <param name="credentialToVerify"></param>
        /// <returns></returns>
        public Account GetOwnerCredential(string credentialToVerify)
        {
            Account ownerCredential = _accountService.GetOwnerCredentials(credentialToVerify).ToApi();

            return ownerCredential;
        }
        /// <summary>
        /// Récupère les credentials essentiels pour les claims du sitter
        /// </summary>
        /// <param name="credentialToVerify"></param>
        /// <returns></returns>
        public Account GetPetSitterCredential(string credentialToVerify)
        {
            Account petSitterCredential = _accountService.GetPetSitterCredentials(credentialToVerify).ToApi();

            return petSitterCredential;
        }
    }
}
