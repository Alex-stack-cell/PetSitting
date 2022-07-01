
using BLLPetSitting.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace BLLPetSitting.Interfaces
{
    /// <summary>
    /// Méthode de base vérifiant si un compte utilisateur est valide ou existant
    /// </summary>
    public interface IUserValidation
    {
        /// <summary>
        /// Évalue si une personne est majeure ou non
        /// Dans le cas contraire une exception est levée.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public static bool ValidateAge(DateTime birthDate, string firstName)
        {
            int birthYear = birthDate.Year;
            int currentYear = DateTime.Now.Year;
            bool verifyAge = false;

            if (currentYear - birthYear >= 18)
            {
                verifyAge = true;
            }
            else
            {
                throw new CustomException($"{firstName}, vous devez être majeur pour vous inscrire !");
            }
            return verifyAge;
        }
        /// <summary>
        /// Évalue le prénom et le nom selon un pattern spécifique
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <exception cref="CustomException"></exception>
        public static void ValidateName(string firstName, string lastName)
        {
            string pattern = @"[a-zA-Z]+[\s|-]?[a-zA-Z]+[\s|-]?[a-zA-Z]+$";
            Regex validateName = new Regex(pattern);
            if (!validateName.IsMatch(firstName))
            {
                throw new CustomException($"{firstName}, votre prénom ne respecte pas le format attendu");
            }
            else if (!validateName.IsMatch(lastName))
            {
                throw new CustomException($"{lastName}, votre nom ne respecte pas le format attendu");
            }
        }
        /// <summary>
        /// Vérification de l'existance de son compte
        /// </summary>
        /// <returns></returns>
        //public bool hasAccount();


        public static void ValidatePassword(string passwd, string firstName)
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

            if (!verifyNumber.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir un nombre pour {firstName}");
            }
            else if (!verifyUpperChar.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir au moins une majuscule pour {firstName}");
            }
            else if (!verifyLowerChar.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir au moins une minuscule pour {firstName}");
            }
            else if (!verifyLength.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe ne peut pas contenir moins de 8 caractères ou plus de 15 caractères pour {firstName}");
            }
            else if (!verifySymbols.IsMatch(passwd))
            {
                throw new CustomException($"Le mot de passe doit contenir au moins un caractère spéciale pour {firstName}");
            }
        }
    }
}
