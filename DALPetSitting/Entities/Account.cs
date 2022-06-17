using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Entities
{
    /// <summary>
    /// Information permettant de valier l'existance ou non du compte
    /// </summary>
    public class Account
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
    }
}
