using APIPetSitting.Models.Abstracts;


namespace APIPetSitting.Models.Concretes.Users
{
    /// <summary>
    /// Pet sitter issus de l'API
    /// </summary>
    public class PetSitter : User
    {
        public string PetPreference { get; set; }
    }
}
