using BLLPetSitting.Abstracts.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Concretes.Users.Updates
{
    public class UpdatePetSitterInfo : UserUpdateInfo
    {
        public UpdatePetSitterInfo(string lastName, string firstName, string email) : base(lastName, firstName, email)
        {
        }

        public string PetPreference { get; set; }
    }
}
