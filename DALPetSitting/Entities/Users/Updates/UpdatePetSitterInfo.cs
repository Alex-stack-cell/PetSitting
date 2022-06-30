using DALPetSitting.Abstracts.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALPetSitting.Entities.Users.Updates
{
    public class UpdatePetSitterInfo : UserUpdateInfo
    {
        public string PetPreference { get; set; }
    }
}
