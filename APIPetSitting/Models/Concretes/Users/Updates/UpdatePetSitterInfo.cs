﻿using APIPetSitting.Models.Abstracts.Users.Update;

namespace APIPetSitting.Models.Concretes.Users.Updates
{
    public class UpdatePetSitterInfo : UserUpdateInfo
    {
        public string PetPreference { get;set; }
    }
}
