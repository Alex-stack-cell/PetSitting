﻿using System;
using System.ComponentModel.DataAnnotations;

namespace APIPetSitting.Models
{
    public class Comment
    {
        public int? ID { get; set; }
        public int? ID_Prestation { get; set; }
        public int? ID_Owner { get; set; }
        public int? ID_PetSitter { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        public int Score { get; set; }
    }
}