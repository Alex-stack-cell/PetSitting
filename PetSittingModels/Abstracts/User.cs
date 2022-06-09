using BLLPetSitting.Exceptions;
using BLLPetSitting.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace BLLPetSitting.Abstracts
{
    /// <summary>
    /// Classe abstraite regroupant les caractéristiques communes d'une compte utilisateur
    /// ainsi que les méthodes de validation d'inscription
    /// Propriétaire - Prestataire
    /// </summary>
    public abstract class User : IValidation
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
        private int? _score;

        public string LastName { get { return _lastName; }set { this._lastName = value; } }
        public string FirstName { get { return _firstName; }set { this._firstName = value; } }
        public string Email { get { return _email; } set { this._email = value; } }
        public DateTime BirthDate { get { return _birthDate; }set { this._birthDate = value; } }
        public string Passwd { get { return _passwd; } set { this._passwd = value; } }
        public int? Score { get { return _score; } set{ this._score = value; } }

        /// <summary>
        /// Constructeur permettant d'initialiser une personne
        /// </summary>
        /// <param name="lastName"></param>
        /// <param name="firstName"></param>
        /// <param name="email"></param>
        /// <param name="birthDate"></param>
        public User(int? id, string lastName, string firstName, string email,DateTime birthDate, string passwd, int? score)
        {
            this.Id = id;
            this._lastName = lastName;
            this._firstName = firstName;
            this._email = email;
            this._birthDate = birthDate;
            this._passwd = passwd;
            this._score = score;

            // validation
            ValidateAge();
            ValidateName(firstName, lastName);
            ValidatePassword(passwd);
            ValidateScore();
        }

        /// <summary>
        /// Évalue si une personne est majeure ou non
        /// Dans le cas contraire une exception est levée.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public bool ValidateAge()
        {
            int birthYear = this.BirthDate.Year;
            int currentYear = DateTime.Now.Year;
            bool verifyAge = false;

            if (currentYear - birthYear >= 18)
            {
                verifyAge = true;
            }
            else
            {
                throw new CustomException($"{this.FirstName}, vous devez être majeur pour vous inscrire !");
            }
            return verifyAge;
        }

        /// <summary>
        /// Évalue le prénom et le nom selon un pattern spécifique
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <exception cref="CustomException"></exception>
        public void ValidateName(string firstName, string lastName)
        {
            string pattern = @"[a-zA-Z]+[\s|-]?[a-zA-Z]+[\s|-]?[a-zA-Z]+$";
            Regex validateName = new Regex(pattern);
            if (!validateName.IsMatch(firstName))
            {
                throw new CustomException($"{this.FirstName}, votre prénom ne respecte pas le format attendu");
            }
            else if (!validateName.IsMatch(lastName))
            {
                throw new CustomException($"{this.FirstName}, votre nom ne respecte pas le format attendu");
            }
        }

        /// <summary>
        /// Évalue le mot de passe selon un pattern spécifique
        /// Il doit contenir 1 chiffre, 1 majuscule, 1 minuscule, entre 8 et 15 caractères
        /// et un symbol spéciale
        /// Si les conditions ne sont pas remplies, une exception est levée
        /// </summary>
        /// <param name="passwd"></param>
        /// <exception cref="CustomException"></exception>
        public void ValidatePassword(string passwd)
        {
            // le mot de passe doit contenir au moins un chiffre
            Regex verifyNumber = new Regex(@"[0-9]");
            // le mot de passe doit contenir au moins une lettre en majuscule
            Regex verifyUpperChar = new Regex(@"[A-Z]+");
            // le mot de passe doit contenu au moins une lettre minuscule
            Regex verifyLowerChar = new Regex(@"[a-z]+");
            // le mot de passe doit être contenir entre 8 et 15 caractères
            Regex verifyLength = new Regex(@".{8,15}");
            // le mot de passe doit contenir au moins un symbol
            Regex verifySymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (string.IsNullOrWhiteSpace(passwd) && passwd != "")
            {
                throw new CustomException($"Le mot de passe ne peut pas être vide pour { this.FirstName }");
            }
            else if (!verifyNumber.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir un nombre pour { this.FirstName }");
            }
            else if (!verifyUpperChar.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir au moins une majuscule pour { this.FirstName }");
            }
            else if (!verifyLowerChar.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir au moins une minuscule pour { this.FirstName }");
            }
            else if (!verifyLength.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe ne peut pas contenir moins de 8 caractères ou plus de 15 caractères pour { this.FirstName }");
            }
            else if (!verifySymbols.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir au moins un caractère spéciale pour { this.FirstName }");
            }
        }

        /// <summary>
        /// Évalue le score, cela doit être un nombre entier entre 0 et 5
        /// </summary>
        /// <exception cref="CustomException"></exception>
        public void ValidateScore()
        {
            int? score = this.Score;
            if (score < 0 || score>5)
            {
                throw new CustomException("Le score doit être compris entre 0 et 5");
            }
        }
    }
}
