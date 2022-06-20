using DALPetSitting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Repositories
{
    /// <summary>
    /// Repository associé à l'entité Account
    /// </summary>
    public interface IAccount
    {
        public string GetEmailOwner(string emailToVerify);
        public string GetEmailPetSitter(string emailToVerify);
        public Account GetOwnerCredentials(string credentialToVerify);
        public Account GetPetSitterCredentials(string credentialToVerify);
        public bool isOwnerPasswordValid(string ownerEmail, string passwdToVerify);
        public bool isPetSitterPasswordValid(string sitterEmail, string passwdToVerify);
    }
}
