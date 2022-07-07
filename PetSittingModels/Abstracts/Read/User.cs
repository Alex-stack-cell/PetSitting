using BLLPetSitting.Interfaces;
using System;


namespace BLLPetSitting.Abstracts.Read
{
    /// <summary>
    /// Classe abstraite regroupant les caractéristiques communes d'une compte utilisateur
    /// ainsi que les méthodes de validation d'inscription
    /// Propriétaire - Prestataire
    /// </summary>
    public abstract class User : IUserValidation
    {
        /// <summary>
        /// Identifiant unique d'une personne
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Prénom d'une personne accessible uniquement dans le constructeur
        /// </summary>
        private string _lastName;
        /// <summary>
        /// Nom de famille d'une personne accessible uniquement dans le constructeur
        /// </summary>
        private string _firstName;
        /// <summary>
        /// E-mail d'une personne
        /// </summary>
        private string _email;
        /// <summary>
        /// Date de naissance d'une personne accessible uniquement dans le constructeur
        /// </summary>
        private DateTime _birthDate;
        /// <summary>
        /// Mot de passe d'une personne
        /// </summary>
        private string _passwd;

        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public DateTime BirthDate { get { return _birthDate; } set { _birthDate = value; } }
        public string Passwd { get { return _passwd; } set { _passwd = value; } }

        /// <summary>
        /// Constructeur permettant d'initialiser une personne
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="email"></param>
        /// <param name="birthDate"></param>
        public User(int? id, string lastName, string firstName, string email, DateTime birthDate, string passwd)
        {
            Id = id;
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
            _birthDate = birthDate;
            _passwd = passwd;

            // validation
            IUserValidation.ValidateAge(birthDate,firstName);
            IUserValidation.ValidateName(firstName, lastName);
            // validation du mdp seulement si c'est une opération d'écriture  
            if (!string.IsNullOrWhiteSpace(passwd) && passwd != "")
            {
                IUserValidation.ValidatePassword(passwd, firstName);
            }
        }
    }
}
