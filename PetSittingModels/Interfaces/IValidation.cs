
namespace BLLPetSitting.Interfaces
{
    /// <summary>
    /// Méthode de base vérifiant si un compte utilisateur est valide ou existant
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// Évalue si une personne est majeure ou non
        /// Dans le cas contraire une exception est levée.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public bool ValidateAge();

        /// <summary>
        /// Évalue le prénom et le nom selon un pattern spécifique
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <exception cref="CustomException"></exception>
        public void ValidateName(string firstName, string lastName);

        /// <summary>
        /// Vérification de l'existance de son compte
        /// </summary>
        /// <returns></returns>
        //public bool hasAccount();


        /// <summary>
        /// Évalue le mot de passe selon un pattern spécifique
        /// Il doit contenir 1 chiffre, 1 majuscule, 1 minuscule, entre 8 et 15 caractères
        /// et un symbol spéciale
        /// Si les conditions ne sont pas remplies, une exception est levée
        /// </summary>
        /// <param name="passwd"></param>
        /// <exception cref="CustomException"></exception>
        public void ValidatePassword(string passwd);
    }
}
