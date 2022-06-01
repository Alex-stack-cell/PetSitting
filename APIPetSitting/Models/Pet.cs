using System;
using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models
{
    public class Pet
    {
        public int? ID { get; set; }
        public int? ID_Owner { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Type { get; set; }        
        public string Breed { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
