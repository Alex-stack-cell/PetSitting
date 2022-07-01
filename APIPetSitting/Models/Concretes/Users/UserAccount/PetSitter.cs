using APIPetSitting.Models.Abstracts.Users.Read;

namespace APIPetSitting.Models.Concretes.Users.UserAccount
{
    /// <summary>
    /// Pet sitter issus de l'API
    /// </summary>
    public class PetSitter : User
    {
        public string PetPreference { get; set; }
    }
}
