using BLLPetSitting.Abstracts.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Concretes.Users
{
    /// <summary>
    /// PetSitter issu de la BLL
    /// </summary>
    public sealed class PetSitter : User
    {
        private string _petPreference;
        public string PetPreference { get { return _petPreference; } set { _petPreference = value; } }
        public PetSitter(int? id, string lastName, string firstName, string email, DateTime birthDate, string passwd) : base(id, lastName, firstName, email, birthDate, passwd)
        {
        }


    }
}
