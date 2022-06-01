using System;
using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models
{
    /// <summary>
    /// Propriétaire d'un animal de compagnie issus de l'API
    /// </summary>
    public class Owner
    {
        public int? ID{ get; set; }
        [Required]
        public string LastName{ get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Passwd { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
