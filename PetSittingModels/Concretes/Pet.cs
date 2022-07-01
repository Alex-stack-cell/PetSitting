using BLLPetSitting.Exceptions;
using BLLPetSitting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLLPetSitting.Concretes
{
    /// <summary>
    /// Animal issu de la BLL
    /// </summary>
    public sealed class Pet : IPetValidation
    {
        public int? Id { get; set; }
        public int? IdOwner { get; set; }
        private string _nickName;
        private string _type;
        private string _breed;
        private DateTime _birthDate;

        public int? ID_Owner { get { return this.IdOwner; } set { this.IdOwner = value; } }
        public string NickName { get { return this._nickName; } set { this._nickName = value; } }
        public string Type { get { return this._type; } set { this._type = value; } }
        public string Breed { get { return this._breed; } set { this._breed = value; } }
        public DateTime BirthDate { get { return this._birthDate; } set { this._birthDate = value; } }

        public Pet(int? id, string nickName, string type, string breed, DateTime birthDate)
        {
            this.Id = id;
            this._nickName = nickName;
            this._type = type;
            this._breed = breed;
            this._birthDate = birthDate;

            //Validation
            IPetValidation.ValidateAge(birthDate, nickName);
            IPetValidation.ValidateName(nickName);
        }
    }
}
