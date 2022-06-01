using System;

namespace DALPetSitting.Entities
{
    /// <summary>
    /// Entité prestation dans la base de données
    /// </summary>
    public class Prestation
    {
        public int ID { get; set; }
        public int ID_PetSitter { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
