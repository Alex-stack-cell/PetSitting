using BLLPetSitting.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Concretes
{
    /// <summary>
    /// PetSitter issu de la BLL
    /// </summary>
    public sealed class PetSitter : User
    {
        public PetSitter(int? id,string lastName, string firstName, string email, DateTime birthDate, string passwd, int score) : base(id, lastName, firstName, email, birthDate, passwd, score)
        {
        }

        public string PetPreference { get; set; }
    }
}
