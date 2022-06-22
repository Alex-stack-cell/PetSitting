using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Abstracts
{
    /// <summary>
    /// Information d'un user capturé par le tableau de bord
    /// </summary>
    public abstract class Dashboard
    {
        public int? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public float? Score { get; set; }
    }
}
