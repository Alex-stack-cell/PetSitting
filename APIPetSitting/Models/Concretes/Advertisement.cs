using System;
using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models.Concretes
{
    /// <summary>
    /// Entité Advertissement côté API
    /// </summary>
    public class Advertisement
    {
        public int? ID { get; set; }

        public int? ID_Owner { get; set; }
        public int? ID_Prestation { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Region { get; set; }
        public string City { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
