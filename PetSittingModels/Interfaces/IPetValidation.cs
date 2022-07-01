using BLLPetSitting.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLLPetSitting.Interfaces
{
    public interface IPetValidation
    {
        /// <summary>
        /// Évalue l'âge d'un animal de compagnie
        /// Les animaux ne doivent pas être des "bébés" et il est interdit de founir un age incohérent
        /// Les animaux de compagnies (chat, chien, lapin, gerbille, cochon d'Inde) ne vivent pas plus de 20 ans
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public static bool ValidateAge(DateTime birthDate, string nickName)
        {
            int birthYear = birthDate.Year;
            int currentYear = DateTime.Now.Year;
            bool verifyAge = false;

            if (birthYear >= 1)
            {
                verifyAge = true;
            }
            else if (currentYear - birthYear <= 20)
            {
                verifyAge = true;
            }
            else
            {
                throw new CustomException($" L'âge fournit pour votre compagnon, {nickName}, ne respecte pas les critères!");
            }
            return verifyAge;
        }
        /// <summary>
        /// Évalue le prénom et le nom selon un pattern spécifique
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <exception cref="CustomException"></exception>
        public static void ValidateName(string nickName)
        {
            string pattern = @"[a-zA-Z]+[\s|-]?[a-zA-Z]+[\s|-]?[a-zA-Z]+$";
            Regex validateName = new Regex(pattern);

            if (!validateName.IsMatch(nickName))
            {
                throw new CustomException($"Le prénom de votre compagnon, {nickName}, ne respecte pas le format attendu");
            }
        }
    }
}
