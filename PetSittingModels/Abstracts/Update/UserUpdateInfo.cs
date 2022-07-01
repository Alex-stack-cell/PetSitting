using BLLPetSitting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLPetSitting.Abstracts.Update
{
    public abstract class UserUpdateInfo : IUserValidation
    {
        public int? Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }

        public UserUpdateInfo(string lastName, string firstName, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            Email = email;

            //validation
            IUserValidation.ValidateName(firstName, lastName);
        }
    }
}
