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
        private string? _petPreference;
        public string PetPreference { get { return this._petPreference; } set { this._petPreference = value; } }
    }
}
