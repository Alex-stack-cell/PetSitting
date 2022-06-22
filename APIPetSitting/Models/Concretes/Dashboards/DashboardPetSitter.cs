﻿using APIPetSitting.Models.Abstracts;

namespace APIPetSitting.Models.Concretes.Dashboards
{
    /// <summary>
    /// Modèle tableau de bord pour le pet-sitter
    /// </summary>
    public class DashboardPetSitter : Dashboard
    {
        public string PetPreference { get; set; }
    }
}
