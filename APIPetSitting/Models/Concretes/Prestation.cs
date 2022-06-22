using System;
using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models.Concretes
{
    /// <summary>
    /// Prestation côté API
    /// </summary>
    public class Prestation
    {
        public int? ID { get; set; }
        public int? ID_PetSitter { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
    }
}
