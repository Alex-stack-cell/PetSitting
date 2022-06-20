using System;
using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models
{
    /// <summary>
    /// Pet sitter issus de l'API
    /// </summary>
    public class PetSitter
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
        public string? PetPreference { get; set; }
    }
}
