using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Entities.Auth
{
    /// <summary>
    /// Information permettant de valier l'existance ou non du compte
    /// </summary>
    public class Account
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string Passwd { get; set; }
        public string HashPasswd { get; set; }
        public byte[] Salt { get; set; }
    }
}
