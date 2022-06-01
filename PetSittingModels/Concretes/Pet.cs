using BLLPetSitting.Exceptions;
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
    public sealed class Pet
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
            ValidateAge();
            ValidateName(nickName);
        }

        /// <summary>
        /// Évalue l'âge d'un animal de compagnie
        /// Les animaux ne doivent pas être des "bébés" et il est interdit de founir un age incohérent
        /// Les animaux de compagnies (chat, chien, lapin, gerbille, cochon d'Inde) ne vivent pas plus de 20 ans
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public bool ValidateAge()
        {
            int birthYear = this.BirthDate.Year;
            int currentYear = DateTime.Now.Year;
            bool verifyAge = false;

            if (birthYear >= 1)
            {
                verifyAge = true;
            }
            else if(currentYear- birthYear <=20)
            {
                verifyAge = true;
            }
            else
            {
                throw new CustomException($" L'âge fournit pour votre compagnon, {this.NickName}, ne respecte pas les critères!");
            }
            return verifyAge;
        }
        /// <summary>
        /// Évalue le prénom et le nom selon un pattern spécifique
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <exception cref="CustomException"></exception>
        public void ValidateName(string nickName)
        {
            string pattern = @"[a-zA-Z]+[\s|-]?[a-zA-Z]+[\s|-]?[a-zA-Z]+$";
            Regex validateName = new Regex(pattern);

            if (!validateName.IsMatch(nickName))
            {
                throw new CustomException($"Le prénom de votre compagnon, {this.NickName}, ne respecte pas le format attendu");
            }
        }
    }
}
