using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models.Concretes.Auth
{
    /// <summary>
    /// Modèle permettant à l'utilisateur de se connecter pour l'authentification
    /// </summary>
    public class UserLogins
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
