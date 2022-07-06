using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models.Concretes.Users.Updates
{
    /// <summary>
    /// Permet de maj le mdp de l'utilisateur
    /// L'utilisateur doit renseigner son mdp courrant et le nouveau (x2)
    /// </summary>
    public class UpdatePassword
    {
        //Identifiant du user
        [Required]
        public int id { get; set; } 
        [Required]
        public string currentPassword { get; set; }
        [Required]
        public string newPassword { get; set; }
        [Required]
        public string confirmNewPassword { get; set; }
    }
}
