using System;
using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models.Abstracts.Users.Read
{
    /// <summary>
    /// Modèle abstrait regroupant les propriétés communes des utilisateurs
    /// </summary>
    public abstract class User
    {
        public int? ID { get; set; }

        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Passwd { get; set; }
    }
}
