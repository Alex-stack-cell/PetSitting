using DALPetSitting.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Entities
{
    /// <summary>
    /// Entité PetSitter en base de données
    /// </summary>
    public class PetSitter : User
    {
        public string PetPreference { get; set; }
    }
}
